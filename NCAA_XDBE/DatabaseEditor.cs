using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        /* Database Editor */

        private void TabDB_Start()
        {
            TablePropsgroupBox.Visible = true;
            FieldsPropsgroupBox.Visible = true;
            fieldMenu.Enabled = true;
            tableMenu.Enabled = true;
            CSVMenu.Visible = true;
            optionsMenuItem.Visible = true;
            StartDBEditor();
        }

        private void StartDBEditor()
        {
            DoNotTrigger = true;
            int ind = 0;
            if (DB2Button.Checked) ind = 1;
            GetTables(ind);
            LoadTables();
            tableGridView.ClearSelection();

            DoNotTrigger = false;
        }

        #region Database Loading

        private void GetTableProperties()
        {

            TdbTableProperties TableProps = new TdbTableProperties();

            TableProps.Name = TDBNameLength;

            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);

            string flags = "";
            if (TableProps.Flag0) flags += " FL0";
            if (TableProps.Flag1) flags += " FL1";
            if (TableProps.Flag2) flags += " FL2";
            if (TableProps.Flag3) flags += " FL3";
            if (TableProps.NonAllocated) flags += " NonAlloc";

            TablePropsLabel.Text = "Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString() + " " + flags;

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

            StartProgressBar(tmpTableCount);

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

            EndProgressBar();
            SortTables();
        }

        private void LoadTables()
        {

            tableGridView.EnableHeadersVisualStyles = false;
            tableGridView.Rows.Clear();
            tableGridView.Columns.Clear();

            tableGridView.ColumnCount = 2;
            tableGridView.Columns[0].Name = "Rec";
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
            if (DoNotTrigger) return;

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

            StartProgressBar(TableProps.FieldCount);


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

                ProgressBarStep();
            }

            EndProgressBar();

            // Add any special Add-Ons for certain tables
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

            int tmpFIELDcount = FieldNames.Count;

            fieldsGridView.EnableHeadersVisualStyles = false;


            fieldsGridView.Rows.Clear();
            fieldsGridView.Columns.Clear();

            fieldsGridView.ColumnCount = tmpFIELDcount + 2;  // set maximum columns (FieldCount + RecNo + autofill last column)

            fieldsGridView.Columns[0].Name = "Rec";
            fieldsGridView.Columns[0].Width = 47;


            StartProgressBar(tmpFIELDcount + 2);

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
                ProgressBarStep();
            }

            HidePLAYColumns();

            EndProgressBar();
            fieldsGridView.Columns[tmpFIELDcount + 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //


            LoadFieldData();
        }

        private void LoadFieldData()
        {
            DoNotTrigger = true;

            TdbTableProperties TableProps = new TdbTableProperties();

            TableProps.Name = TDBNameLength;


            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps))
                return;


            //int fCount = TableProps.FieldCount + 1;
            int fCount = FieldNames.Count + 1;

            StartProgressBar(TableProps.RecordCount);

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(dbSelected, TableProps.Name, r))
                    continue;

                int tmpf = 0;

                //Format FieldGridView by tdbFieldType.
                object[] DataGridRow = new object[fCount];
                DataGridRow[0] = r;

                foreach (KeyValuePair<int, string> f in FieldNames)
                {
                    if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") >= 0 && f.Key > FieldNames.Count - 5)
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
                        intval = (UInt32)TDB.TDBFieldGetValueAsInteger(dbSelected, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = intval;

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

                        if(!BigEndian)
                        TDB.TDBFieldGetValueAsString(dbSelected, TableProps.Name, FieldProps.Name, r, ref val);
                        else val = "na";
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


                if (SelectedTableName == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") >= 0)
                {
                    DataGridRow[fCount - 4] = GetFirstNameFromRecord(r);
                    DataGridRow[fCount - 3] = GetLastNameFromRecord(r);
                    DataGridRow[fCount - 2] = GetPositionName(GetDBValueInt("PLAY", "PPOS", r));
                    DataGridRow[fCount - 1] = GetTeamName(GetDBValueInt("PLAY", "PGID", r) / 70);
                }

                fieldsGridView.Rows.Add(DataGridRow);
                ProgressBarStep();
            }

            MovePLAYTextColumns();

            EndProgressBar();

            DoNotTrigger = false;
        }

        private void FieldGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            GetFieldProps();
        }

        private void FieldGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;

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

            if (SelectedTableName == "PLAY" && tmpFieldName == "First Name" && !DoNotTrigger || SelectedTableName == "PLAY" && tmpFieldName == "Last Name" && !DoNotTrigger)
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

                tmpval = tmpval.Replace(",", "-");

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
                //Not supported Field
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


                    if (table.Name == "RCPT" && !BigEndian)
                    {
                        if (!checkTabExists("Off-Season")) tabControl1.TabPages.Insert(3, tabOffSeason);
                        if (!checkTabExists("Carousel")) tabControl1.TabPages.Insert(4, tabCarousel);
                        if (!checkTabExists("Recruits")) tabControl1.TabPages.Insert(5, tabRecruits);
                        if (!checkTabExists("Recruit Board")) tabControl1.TabPages.Insert(6, tabRecruiting);
                        if (!checkTabExists("Portal")) tabControl1.TabPages.Insert(7, tabPortal);
                    }
                    else if (table.Name == "TDYN" && !BigEndian)
                    {
                        TDYN = true;
                        //if (!checkTabExists("Teams")) tabControl1.TabPages.Add(tabTeams);
                        //tabControl1.TabPages.Add(tabDev);
                    }
                    else if (table.Name == "PLAY" && !BigEndian)
                    {
                        if (!checkTabExists("Players")) tabControl1.TabPages.Insert(2, tabPlayers);
                        if (!checkTabExists("Depth Charts")) tabControl1.TabPages.Add(tabDepthCharts);
                        if (!checkTabExists("dbTools")) tabControl1.TabPages.Insert(2, tabTools);
                    }
                    else if (table.Name == "TEAM" && !BigEndian)
                    {
                        TEAM = true;
                        if (!checkTabExists("Teams")) tabControl1.TabPages.Insert(2, tabTeams);
                    }
                    else if (table.Name == "CONF" && !BigEndian)
                    {
                        if (!checkTabExists("Coaches")) tabControl1.TabPages.Insert(2, tabCoaches);
                        if (!checkTabExists("Bowls")) tabControl1.TabPages.Add(tabBowls);
                        if (!checkTabExists("Stadiums")) tabControl1.TabPages.Add(tabStadiums);
                        if (!checkTabExists("League")) tabControl1.TabPages.Insert(3, tabConf);
                        LeagueMakerToolStripMenuItem.Visible = true;
                    }
                    else if (table.Name == "TRAN" && !BigEndian)
                    {
                        if (!checkTabExists("Dynasty")) tabControl1.TabPages.Insert(4, tabDynasty);
                        if (!checkTabExists("Team Stats")) tabControl1.TabPages.Insert(5, tabTeamStats);
                        if (!checkTabExists("League Stats")) tabControl1.TabPages.Insert(6, tabLeagueStats);
                        if (!checkTabExists("Schedule")) tabControl1.TabPages.Insert(7, tabSchedule);
                        if (!checkTabExists("Playoff") && GetDBValueInt("SEAI", "SEWN", 0) >= 8) tabControl1.TabPages.Insert(8, tabPlayoff);
                    }
                    else if (table.Name == "UNIF" && !BigEndian)
                    {
                        if (!checkTabExists("Uniforms")) tabControl1.TabPages.Add(tabUniforms);
                    }
                    else if (table.Name == "PBAI" && !BigEndian)
                    {
                        if (!checkTabExists("Playbooks") && table.RecordCount > 0) tabControl1.TabPages.Add(tabPlaybook);
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
            if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") >= 0)
            {
                fieldsGridView.Columns.Add("First Name", "First Name");
                fieldsGridView.Columns.Add("Last Name", "Last Name");
                fieldsGridView.Columns.Add("Position", "Position");
                fieldsGridView.Columns.Add("College", "College");

                FieldNames.Add(FieldNames.Count, "First Name");
                FieldNames.Add(FieldNames.Count, "Last Name");
                FieldNames.Add(FieldNames.Count, "Position");
                FieldNames.Add(FieldNames.Count, "College");
            }
        }

        private void HidePLAYColumns()
        {
            if (SelectedTableName != "PLAY" || TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") < 0)
                return;

            for (int PF = 1; PF <= 10; PF++)
            {
                fieldsGridView.Columns["PF" + AddLeadingZeros(Convert.ToString(PF), 2) + ""].Visible = false;
                fieldsGridView.Columns["PL" + AddLeadingZeros(Convert.ToString(PF), 2) + ""].Visible = false;
            }
        }

        private void MovePLAYTextColumns()
        {
            if (SelectedTableName != "PLAY" || TDB.FieldIndex(dbSelected, SelectedTableName, "PF10") < 0)
                return;

            fieldsGridView.Columns["First Name"].DisplayIndex = 1;
            fieldsGridView.Columns["Last Name"].DisplayIndex = 2;
            fieldsGridView.Columns["Position"].DisplayIndex = 3;
            fieldsGridView.Columns["College"].DisplayIndex = 4;

        }

        #endregion

        #region Table Capacity Editor

        private void changeTableCapacityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dbSelected == -1 || SelectedTableIndex < 0)
                return;

            // Get current table properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = TDBNameLength;
            TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref tableProps);

            /*
               // Create and configure the form
               using (Form capacityDialog = new Form())
               {
                   capacityDialog.Text = $"Change Capacity - {tableProps.Name}";
                   capacityDialog.Size = new Size(200, 200);
                   capacityDialog.StartPosition = FormStartPosition.CenterParent;
                   capacityDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                   capacityDialog.MaximizeBox = false;
                   capacityDialog.MinimizeBox = false;

                   // Create controls
                   Label currentCapLabel = new Label
                   {
                       Text = $"Current Capacity: {tableProps.Capacity}",
                       Location = new Point(20, 20),
                       AutoSize = true
                   };

                   Label recordsLabel = new Label
                   {
                       Text = $"Active Records: {tableProps.RecordCount}",
                       Location = new Point(20, 40),
                       AutoSize = true
                   };

                   Label newCapLabel = new Label
                   {
                       Text = "New Capacity:",
                       Location = new Point(20, 70),
                       AutoSize = true
                   };

                   NumericUpDown capacityInput = new NumericUpDown
                   {
                       Location = new Point(100, 68),
                       Size = new Size(60, 20),
                       Minimum = 0,
                       Maximum = 65534,
                       Value = tableProps.RecordCount
                   };

                   Button okButton = new Button
                   {
                       Text = "OK",
                       DialogResult = DialogResult.OK,
                       Location = new Point(20, 110),
                       Size = new Size(60, 30)
                   };

                   Button cancelButton = new Button
                   {
                       Text = "Cancel",
                       DialogResult = DialogResult.Cancel,
                       Location = new Point(100, 110),
                       Size = new Size(60, 30)
                   };

                   // Add controls to form
                   capacityDialog.Controls.AddRange(new Control[]
                   {
                       currentCapLabel,
                       recordsLabel,
                       newCapLabel,
                       capacityInput,
                       okButton,
                       cancelButton
                   });

                   capacityDialog.AcceptButton = okButton;
                   capacityDialog.CancelButton = cancelButton;

                   // Show dialog and process result
                   if (capacityDialog.ShowDialog() == DialogResult.OK)
                   {
                       int newCapacity = (int)capacityInput.Value;
                       if (newCapacity != tableProps.Capacity)
                       {
                           // Attempt to change the capacity
                           if (TDB.TDBTableChangeCapacity(dbSelected, tableProps.Name, newCapacity))
                           {
                               MessageBox.Show($"Table capacity changed to {newCapacity}.", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                               GetTableProperties(); // Refresh the table properties display
                           }
                           else
                           {
                               MessageBox.Show("Failed to change table capacity.", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                           }
                       }


                   }
               }

               */


            // Create and configure the form (responsive layout, DPI-aware)
            using (Form capacityDialog = new Form())
            {
                capacityDialog.Text = $"Change Capacity - {tableProps.Name}";
                capacityDialog.StartPosition = FormStartPosition.CenterParent;
                capacityDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                capacityDialog.MaximizeBox = false;
                capacityDialog.MinimizeBox = false;
                capacityDialog.Size = new Size(300, 300);

                // Make the dialog DPI-aware and auto-size to its contents
                capacityDialog.AutoScaleMode = AutoScaleMode.Dpi;
                capacityDialog.AutoSize = true;
                capacityDialog.AutoSizeMode = AutoSizeMode.GrowOnly;
                capacityDialog.Padding = new Padding(12);


                // Table layout for labels + input
                var tlp = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    ColumnCount = 2,
                    RowCount = 3,
                    Margin = new Padding(0)
                };
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

                var currentCapLabel = new Label
                {
                    Text = "Current Capacity:",
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3)
                };
                var currentCapValue = new Label
                {
                    Text = tableProps.Capacity.ToString(),
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3)
                };

                var recordsLabel = new Label
                {
                    Text = "Active Records:",
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3)
                };
                var recordsValue = new Label
                {
                    Text = tableProps.RecordCount.ToString(),
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3)
                };

                var newCapLabel = new Label
                {
                    Text = "New Capacity:",
                    Anchor = AnchorStyles.Left,
                    AutoSize = true,
                    Margin = new Padding(3)
                };
                var capacityInput = new NumericUpDown
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    Minimum = 0,
                    Maximum = 65534,
                    Value = Math.Max(tableProps.RecordCount, Math.Min(tableProps.Capacity, 65534)),
                    Margin = new Padding(3),
                    Width = 200
                };

                tlp.Controls.Add(currentCapLabel, 0, 0);
                tlp.Controls.Add(currentCapValue, 1, 0);
                tlp.Controls.Add(recordsLabel, 0, 1);
                tlp.Controls.Add(recordsValue, 1, 1);
                tlp.Controls.Add(newCapLabel, 0, 2);
                tlp.Controls.Add(capacityInput, 1, 2);

                // Buttons in a right-aligned flow panel
                var flp = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Dock = DockStyle.Bottom,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Padding = new Padding(0),
                    Margin = new Padding(0)
                };

                var okButton = new Button
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    AutoSize = true,
                    Margin = new Padding(6, 8, 6, 0)
                };
                var cancelButton = new Button
                {
                    Text = "Cancel",
                    DialogResult = DialogResult.Cancel,
                    AutoSize = true,
                    Margin = new Padding(6, 8, 6, 0)
                };

                flp.Controls.Add(okButton);
                flp.Controls.Add(cancelButton);

                // Add controls to form
                capacityDialog.Controls.Add(tlp);
                capacityDialog.Controls.Add(flp);

                capacityDialog.AcceptButton = okButton;
                capacityDialog.CancelButton = cancelButton;

                // Ensure the dialog is not too small on very small screens
                capacityDialog.MinimumSize = new Size(280, capacityDialog.PreferredSize.Height);

                // Show dialog and process result
                if (capacityDialog.ShowDialog() == DialogResult.OK)
                {
                    int newCapacity = (int)capacityInput.Value;
                    if (newCapacity != tableProps.Capacity)
                    {
                        // Attempt to change the capacity
                        if (TDB.TDBTableChangeCapacity(dbSelected, tableProps.Name, newCapacity))
                        {
                            MessageBox.Show($"Table capacity changed to {newCapacity}.", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            GetTableProperties(); // Refresh the table properties display
                        }
                        else
                        {
                            MessageBox.Show("Failed to change table capacity.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        #endregion

    }

}
