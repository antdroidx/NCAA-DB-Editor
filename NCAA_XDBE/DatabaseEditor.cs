using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        /* Database Editor */

        private void StartDBEditor()
        {
            int ind = 0;
            if (DB2Button.Checked) ind = 1;
            GetTables(ind);
            LoadTables();
            GetFields(ind, SelectedTableIndex);
            LoadFields();
        }

        #region Database Loading

        private void GetTableProperties()
        {

            TdbTableProperties TableProps = new TdbTableProperties();

            TableProps.Name = TDBNameLength;

            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);

            TablePropsLabel.Text = "Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString() + "  CID: " + dbSelected;

        }

        private void GetFieldProps()
        {
            if (dbSelected == -1 || FieldNames.Count < 0)
                return;

            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;

            FieldsPropsLabel.Text = "";

            if (colnum > FieldNames.Count || colnum < 0 || rownum < 0)
                return;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();

            tableProps.Name = TDBNameLength;

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbSelected);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbSelected, tmpTableIndex, ref tableProps);

                if (tableProps.Name == SelectedTableName)
                    break;

            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();

            fieldProps.Name = TDBNameLength;

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(dbSelected, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion


            FieldsPropsLabel.Text = "Field: " + fieldProps.Name.ToString() +
                                 "    Bits: " + fieldProps.Size.ToString() +
                                 "    Type: " + fieldProps.FieldType.ToString() +
                                 "  MaxVal: " + BitMax(fieldProps.Size);

        }

        private void GetTables(int dbFILEindex)
        {
            TableNames.Clear();

            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            string TableName = TDBNameLength;

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbFILEindex);

            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpTableCount;
            progressBar1.Step = 1;

            for (int i = 0; i < tmpTableCount; i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(dbFILEindex, i, ref TableProps))
                {
                    string tmpTABLEname = TableProps.Name;
                    if (BigEndian)
                        tmpTABLEname = StrReverse(tmpTABLEname);

                    TableNames.Add(i, tmpTABLEname);
                }

                progressBar1.Value = i;

            }
            progressBar1.Value = 0;
            SortTables();

        }

        private void LoadTables()
        {

            tableGridView.EnableHeadersVisualStyles = false;
            tableGridView.Rows.Clear();
            tableGridView.Columns.Clear();

            tableGridView.ColumnCount = 2;
            tableGridView.Columns[0].Name = "RecNo";
            tableGridView.Columns[0].Width = 45;
            tableGridView.Columns[1].Name = "Name";
            tableGridView.Columns[1].Width = 47;

            int tmpi = 0;
            foreach (KeyValuePair<int, string> TABLE in TableNames)
            {
                // Populate Table Grid
                object[] DataGrid = new object[2];
                DataGrid[0] = TABLE.Key;
                DataGrid[1] = TABLE.Value;

                string tmpDef = FieldDEF(TABLE.Value);

                tableGridView.Rows.Add(DataGrid);

                if (tmpDef != TABLE.Value)
                {
                    tableGridView.Rows[tmpi].Cells[1].ToolTipText = tmpDef;
                    tableGridView.Rows[tmpi].Cells[1].Style.BackColor = Color.Khaki;
                }
                tmpi++;
            }
            // Auto Fill Last Column
            tableGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void TableGridView_SelectionChanged(object sender, EventArgs e)
        {
            FieldNames.Clear();

            TablePropsLabel.Text = "";

            if (tableGridView.SelectedRows.Count <= 0 || dbSelected == -1)
                return;

            // Get the Table Name and RecNo.
            SelectedTableName = tableGridView.SelectedRows[0].Cells[1].Value.ToString();
            SelectedTableIndex = Convert.ToInt32(tableGridView.SelectedRows[0].Cells[0].Value);

            if (BigEndian)
            {
                SelectedTableName = StrReverse(SelectedTableName);
                exportTableMenuItem.Text = "Export " + StrReverse(SelectedTableName);
                importTableMenuItem.Text = "Import " + StrReverse(SelectedTableName);
            }
            else
            {
                exportTableMenuItem.Text = "Export " + SelectedTableName;
                importTableMenuItem.Text = "Import " + SelectedTableName;
            }
            exportToolItem.Text = exportTableMenuItem.Text;
            importMenuItem.Text = importTableMenuItem.Text;

            GetTableProperties();

            // MessageBox.Show(SelectedTableName);
            GetFields(dbSelected, SelectedTableIndex);
            LoadFields();
        }

        private void GetFields(int dbFILEindex, int tmpTABLEindex)
        {

            FieldNames.Clear();

            TdbTableProperties TableProps = new TdbTableProperties();

            TableProps.Name = TDBNameLength;

            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(dbFILEindex, tmpTABLEindex, ref TableProps))
                return;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TableProps.FieldCount;
            progressBar1.Step = 1;

            for (int i = 0; i < TableProps.FieldCount; i++)
            {
                // Get field properties from the selected table
                TdbFieldProperties FieldProps = new TdbFieldProperties();


                FieldProps.Name = TDBNameLength;

                string tableName = GetTableName(dbFILEindex, tmpTABLEindex);

                var tdb = TDB.TDBFieldGetProperties(dbFILEindex, tableName, i, ref FieldProps);

                string tmpFIELDname = FieldProps.Name;

                if (BigEndian)
                    tmpFIELDname = StrReverse(tmpFIELDname);

                FieldNames.Add(i, tmpFIELDname);

                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;

            DBFieldAddOns(TableProps);
            SortFields();
        }

        private void SortFields()
        {
            Dictionary<int, string> tmpFIELDnames = new Dictionary<int, string>();

            tmpFIELDnames.Clear();

            //Sort TABLES
            if (ascendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in FieldNames.OrderBy(value => value.Value))
                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);

                FieldNames.Clear();
            }
            else if (descendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in FieldNames.OrderByDescending(value => value.Value))
                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);

                FieldNames.Clear();
            }

            foreach (KeyValuePair<int, string> sortAZ in tmpFIELDnames)
                FieldNames.Add(sortAZ.Key, sortAZ.Value);
        }

        private void LoadFields()
        {
            DoNotTrigger = true;

            
            int fCount_addon = 5; //number of extra columns (fields) to add to PLAY table
            int fCount_First = 4; //5-4 = 1 = 1st new column
            int fCount_Last = 3;
            int fCount_Pos = 2;
            int fCount_Team = 1;
            

            int tmpFIELDcount = FieldNames.Count;

            fieldsGridView.EnableHeadersVisualStyles = false;
            fieldsGridView.Rows.Clear();
            fieldsGridView.Columns.Clear();

            #region Populate column header with field names.

            fieldsGridView.ColumnCount = tmpFIELDcount + 2;  // set maximum columns (FieldCount + RecNo + autofill last column)
            fieldsGridView.Columns[0].Name = "RecNo";
            fieldsGridView.Columns[0].Width = 47;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpFIELDcount + 2;
            progressBar1.Step = 1;

            int tmpi = 0;
            foreach (KeyValuePair<int, string> sortAZ in FieldNames)
            {
                // add columns to FieldGridView
                fieldsGridView.Columns[tmpi + 1].Width = 47;
                fieldsGridView.Columns[tmpi + 1].Name = sortAZ.Value;

                string tmpDef = FieldDEF(sortAZ.Value);

                fieldsGridView.Columns[tmpi + 1].ToolTipText = tmpDef;

                if (tmpDef != Convert.ToString(sortAZ.Value))
                    fieldsGridView.Columns[tmpi + 1].HeaderCell.Style.BackColor = Color.Khaki;

                tmpi++;
                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;
            fieldsGridView.Columns[tmpFIELDcount + 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //

            #endregion

            #region Populate Field DataGrid

            TdbTableProperties TableProps = new TdbTableProperties();

            TableProps.Name = TDBNameLength;


            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps))
                return;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TableProps.RecordCount;
            progressBar1.Step = 1;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(dbSelected, TableProps.Name, r))
                    continue;

                int tmpf = 0;

                int fCount = TableProps.FieldCount + 1;

                
                
                if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "First Name") == -1 && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                {
                    fCount = TableProps.FieldCount + fCount_addon;
                }
                

                // Format FieldGridView by tdbFieldType.
                object[] DataGridRow = new object[fCount];
                DataGridRow[0] = r;

                
                if (SelectedTableName == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "First Name") == -1 && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                {
                    fieldsGridView.Columns[fCount - fCount_First].Width = 86;
                    DataGridRow[fCount - fCount_First] = GetFirstNameFromRecord(r);
                    fieldsGridView.Columns[fCount - fCount_Last].Width = 86;
                    DataGridRow[fCount - fCount_Last] = GetLastNameFromRecord(r);
                }
                
                


                foreach (KeyValuePair<int, string> f in FieldNames)
                {
                    
                    
                    if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0 && f.Key > FieldNames.Count - fCount_addon)
                        continue;
                    


                    TdbFieldProperties FieldProps = new TdbFieldProperties();

                    FieldProps.Name = TDBNameLength;

                    TDB.TDBFieldGetProperties(dbSelected, TableProps.Name, f.Key, ref FieldProps);

                    #region Load fieldsGridView by tdbFieldType.
                    //
                    if (FieldProps.FieldType == TdbFieldType.tdbString)
                    {
                        // I think Values that are a string might have to be formatted to a specific length
                        // it probably has something to do with the language he made the dll with
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);




                        TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, r, ref val);
                        val = val.Replace(",", "");



                        fieldsGridView.Columns[tmpf + 1].Width = 86;  // Increase the width size for string literals.

                        #region Comment Code.
                        // Again, each row is an array of objects which can be anything, so you don't need to convert them to a type
                        // you just add them and then clicking on the header cells will sort the whole table based on whatever
                        // type of object it is, ie PGID is integer so will sort all the rows based on ascending/descending PGID
                        // you can just delete all this once you read and understand.

                        // This is for later when you are trying to display/edit a particular field and its value
                        // Just remember when you are wanting to get the value of a cell you will need to convert it to
                        // whatever type of variable you need
                        // example PGID, when getting value from cell you have to convert to type you want
                        // int pgid = Convert.ToInt32(dataGridView1.Rows[rownum].Cells[cellnum].Value);
                        // set is easier since, again it is an object, but you still want to make sure you are
                        // using the same type of variable that all the other rows used
                        // assuming cellnum is a field that contains int datatype
                        // dataGridView1.Rows[rownum].Cells[cellnum].Value = pgid
                        #endregion

                        DataGridRow[tmpf + 1] = val;

                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                    {
                        UInt32 intval;
                        UInt32 pos;
                        intval = (UInt32)TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = intval;

                        
                        if (FieldProps.Name == "PGID" && teamNameDB.Length > 0 && TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                        {
                            DataGridRow[fCount - fCount_Team] = GetTeamName((int)intval / 70);
                            fieldsGridView.Columns[fCount - fCount_Team].Width = 86;
                        }
                        else if (FieldProps.Name == "PPOS" && TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
                        {
                            pos = (UInt32)TDB.TDBFieldGetValueAsInteger(dbSelected, "PLAY", "PPOS", r);
                            DataGridRow[fCount - fCount_Pos] = GetPositionName((int)pos);
                            fieldsGridView.Columns[fCount - fCount_Pos].Width = 86;
                        }
                        


                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                    {
                        Int32 signedval;
                        signedval = TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = signedval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                    {
                        float floatval;
                        floatval = TDB.TDBFieldGetValueAsFloat(dbSelected, TableProps.Name, FieldProps.Name, r);
                        DataGridRow[tmpf + 1] = floatval.ToString("0.00");
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                    {
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);
                        TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, r, ref val);

                        DataGridRow[tmpf + 1] = val;
                    }
                    else
                    {
                        DataGridRow[tmpf + 1] = "na";
                    }
                    //
                    #endregion

                    tmpf++;

                }


                fieldsGridView.Rows.Add(DataGridRow);
                progressBar1.PerformStep();
            }


            progressBar1.Value = 0;
            #endregion

            DoNotTrigger = false;
        }

        private void FieldGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            if (!PlaybookDB) GetFieldProps();
            //GetFieldProps();
        }

        private void FieldGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;
            fieldsGridView.Rows[rownum].Cells[colnum].Style.ForeColor = Color.Red;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);
            int tmpcol = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[0].Value);

            if (fieldsGridView.SelectedRows.Count <= 0 || dbSelected == -1 || colnum < 0 || rownum < 0)
                return;

            DBModified = true;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();

            tableProps.Name = TDBNameLength;

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbSelected);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbSelected, tmpTableIndex, ref tableProps);

                if (tableProps.Name == SelectedTableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();

            fieldProps.Name = TDBNameLength;

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(dbSelected, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (BigEndian) tmpFieldName = StrReverse(tmpFieldName);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion


            
            if (SelectedTableName == "PLAY" && tmpFieldName == "First Name" || tmpFieldName == "Last Name" && !DoNotTrigger)
            {
                if (tmpFieldName == "First Name" && TDB.FieldIndex(dbSelected, SelectedTableName, "First Name") == -1)
                {
                    string tmpPFNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();


                    ConvertFirstNameStringToInt(tmpPFNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }

                if (tmpFieldName == "Last Name" && TDB.FieldIndex(dbSelected, SelectedTableName, "Last Name") == -1)
                {
                    string tmpPLNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();

                    ConvertLastNameStringToInt(tmpPLNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }
            }
            


            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                string tmpval = Convert.ToString(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                tmpval = tmpval.Replace(",", "");

                if (!TDB.TDBFieldSetValueAsString(dbSelected, SelectedTableName, fieldProps.Name, tmpcol, tmpval))
                    fieldsGridView.Rows[rownum].Cells[colnum].Value = tmpval;

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                int tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                UInt32 intval = Convert.ToUInt32(tmpval);

                if (IsUIntNumber(Convert.ToString(tmpval)))
                {
                    if (!TDB.TDBFieldSetValueAsInteger(dbSelected, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(intval)))
                        fieldsGridView.Rows[rownum].Cells[colnum].Value = Convert.ToUInt32(intval);

                }

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbInt || fieldProps.FieldType == TdbFieldType.tdbSInt)
            {
                sbyte tmpval = Convert.ToSByte(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                if (IsIntNumber(Convert.ToString(tmpval)))
                {

                    bool tmpTDB = TDB.TDBFieldSetValueAsInteger(dbSelected, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(tmpval));
                    if (!tmpTDB)
                        fieldsGridView.Rows[rownum].Cells[colnum].Value = Convert.ToInt32(tmpval);
                    else
                    {
                        fieldsGridView.Rows[rownum].Cells[colnum].Style.ForeColor = Color.Red;
                        DBModified = true;
                    }

                }

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbFloat)
            {
                //This was a float, changed to double
                //float tmpval = Convert.ToDouble(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                double tmpval = Convert.ToDouble(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                if (IsFloat(Convert.ToString(tmpval)))
                {

                    bool tmpTDB = TDB.TDBFieldSetValueAsFloat(dbSelected, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToSingle(tmpval));
                    if (!tmpTDB)
                        fieldsGridView.Rows[rownum].Cells[colnum].Value = Convert.ToSingle(tmpval);
                    else
                    {
                        fieldsGridView.Rows[rownum].Cells[colnum].Style.ForeColor = Color.Red;
                        DBModified = true;
                    }


                }

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbBinary || fieldProps.FieldType == TdbFieldType.tdbVarchar || fieldProps.FieldType == TdbFieldType.tdbLongVarchar)
            {

            }


        }

        private void SortTables()
        {
            Dictionary<int, string> tmpTABLEnames = new Dictionary<int, string>();

            tmpTABLEnames.Clear();

            //Sort TABLES
            if (ascendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in TableNames.OrderBy(value => value.Value))
                    tmpTABLEnames.Add(sortAZ.Key, sortAZ.Value);

                TableNames.Clear();
            }
            else if (descendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in TableNames.OrderByDescending(value => value.Value))
                    tmpTABLEnames.Add(sortAZ.Key, sortAZ.Value);

                TableNames.Clear();
            }

            foreach (KeyValuePair<int, string> sortAZ in tmpTABLEnames)
                TableNames.Add(sortAZ.Key, sortAZ.Value);
        }

        #endregion

        #region Add-Ons

        
        private void DBTableAddOns()
        {
            TdbTableProperties table = new TdbTableProperties();
            table.Name = TDBNameLength;

            int dbCount = 1;
            if (dbIndex2 == 1) dbCount = 2;
            for (int db = 0; db < dbCount; db++)
            {
                for (int i = 0; i < TDB.TableCount(db); i++)
                {
                    var x = TDB.TDBTableGetProperties(db, i, ref table);

                    if (table.Name == "TEAM" && !BigEndian)
                    {
                        TEAM = true;
                        if (!checkTabExists("Teams")) tabControl1.TabPages.Add(tabTeams);
                    }
                    else if (table.Name == "PLAY" && !BigEndian)
                    {
                        if (!checkTabExists("Players")) tabControl1.TabPages.Add(tabPlayers);
                        if (!checkTabExists("dbTools")) tabControl1.TabPages.Add(tabTools);
                    }
                    else if (table.Name == "TDYN" && !BigEndian)
                    {
                        TDYN = true;
                        //if (!checkTabExists("Teams")) tabControl1.TabPages.Add(tabTeams);
                        //tabControl1.TabPages.Add(tabDev);
                    }
                    else if (table.Name == "CONF" && !BigEndian)
                    {
                        if (!checkTabExists("Conferences")) tabControl1.TabPages.Add(tabConf);
                        LeagueMakerToolStripMenuItem.Visible = true;
                    }
                    else if (table.Name == "COCH" && !BigEndian)
                    {
                        if (!checkTabExists("Coaches")) tabControl1.TabPages.Add(tabCoaches);
                    }
                    else if (table.Name == "TRAN" && !BigEndian)
                    {
                        if (!checkTabExists("Dynasty")) tabControl1.TabPages.Add(tabDynasty);
                    }
                    else if (table.Name == "PBAI" && !BigEndian)
                    {
                        if (!checkTabExists("Playbooks") && table.RecordCount > 0) tabControl1.TabPages.Add(tabPlaybook);
                        PlaybookDB = true;
                    }
                    else if (table.Name == "DCHT" && !BigEndian)
                    {
                        if (!checkTabExists("Depth Charts")) tabControl1.TabPages.Add(tabDepthCharts);
                    }
                    else if (table.Name == "RCPT" && !BigEndian)
                    {
                        if (!checkTabExists("Recruiting")) tabControl1.TabPages.Add(tabOffSeason);
                        if (!checkTabExists("Recruits")) tabControl1.TabPages.Add(tabRecruits);

                    }
                    else if (table.Name == "UNIF" && !BigEndian)
                    {
                        if (!checkTabExists("Uniforms")) tabControl1.TabPages.Add(tabUniforms);
                    }
                    else if (table.Name == "BOWL" && !BigEndian)
                    {
                        if (!checkTabExists("Bowls")) tabControl1.TabPages.Add(tabBowls);
                    }
                    else if (table.Name == "PACL" && !BigEndian)
                    {
                        if (checkTabExists("Bowls")) tabControl1.TabPages.Remove(tabBowls);
                    }
                    else if (table.Name == "SCHD" && !BigEndian)
                    {
                        if (!checkTabExists("Schedule")) tabControl1.TabPages.Add(tabSchedule);
                    }
                    else if (table.Name == "PSOL" && !BigEndian)
                    {
                        if (!checkTabExists("Stats")) tabControl1.TabPages.Add(tabStats);
                    }
                    else if (table.Name == "STAD" && !BigEndian)
                    {
                        if (!checkTabExists("Stadiums")) tabControl1.TabPages.Add(tabStadiums);
                    }
                    else if (table.Name == "RCTN" && !BigEndian)
                    {
                        if (!checkTabExists("Portal")) tabControl1.TabPages.Add(tabPortal);
                    }
                    else if (table.Name == "RCAT" && !BigEndian)
                    {
                        if (!checkTabExists("STRMDATA")) tabControl1.TabPages.Add(tabSTRMDATA);
                    }

                }
            }
                CreateTeamDB();
                SetPositions();
                CreateRatingsDB();
                CreatePOCItable();
                CreateNameConversionTable();
        }
        

        private void AddPlaybooksTab()
        {
            if (GetTableRecCount("FORM") > -1 && GetTableRecCount("FORM") < 1 && !BigEndian)
            {
                if (!checkTabExists("Playbook"))
                {
                    tabControl1.TabPages.Add(tabPlaybook);
                    PlaybookDB = true;
                }
            }
        }



        private bool checkTabExists(string tabName)
        {
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == tabName)
                    return true;
            }
            return false;
        }

        private void DBFieldAddOns(TdbTableProperties TableProps)
        {
            
            if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") == 0)
            {
                if (TDB.TableIndex(dbSelected, "First Name") == -1)
                    FieldNames.Add(FieldNames.Count, "First Name");

                if (TDB.TableIndex(dbSelected, "Last Name") == -1)
                    FieldNames.Add(FieldNames.Count, "Last Name");

                if (TDB.TableIndex(dbSelected, "Position") == -1)
                    FieldNames.Add(FieldNames.Count, "Position");

                if (TDB.TableIndex(dbSelected, "Team Name") == -1)
                    FieldNames.Add(FieldNames.Count, "College");
            }
            

        }

        #endregion

    }

}
