using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DB_EDITOR

{


    public partial class LeagueMain : Form
    {
        #region Global Variables

        Random rand = new Random();

        string dbFile = "";
        int dbIndex2 = -1;

        string SelectedTableName = "";
        int SelectedTableIndex = -1;

        bool DBModified = false;
        bool exportAll = false;
        bool BigEndian = false;
        bool addendum = false;
        bool importRec = false;

        bool tabDelimited = false;

        List<byte> binData = new List<byte>();     // Holds file header data. (MC02, FBChunks...)
        List<byte> dbData = new List<byte>();      // Holds the db file.
        List<byte> db2Data = new List<byte>();  // Holds any extra data at end of db file. (off-season)
        List<byte> psuExtras = new List<byte>(); // Holds remaining data from PSU saves

        bool offSeasonSave = false; //True if off-season save DB is present
        int activeDB = 0; //1 - season, 2 - off-season

        List<string> deflist = new List<string>();

        Dictionary<string, Dictionary<string, string>> TableDefinitions = new Dictionary<string, Dictionary<string, string>>();

        Dictionary<int, string> TableNames = new Dictionary<int, string>();
        Dictionary<int, string> FieldNames = new Dictionary<int, string>();

        int maxFBSTeams = 120; //max team number for FBSTeams db

        MainEditor main = new MainEditor();

        Point p = Point.Empty;

        int TeamCount = 0;
        int maxTeams = 24;
        bool ArmyNavy = false;
        bool NextMod = false;
        bool Next26Mod = false;


        List<int> bowlsDeleted = new List<int>();

        bool DISABLE = true;

        #endregion

        public LeagueMain(bool next)
        {
            InitializeComponent();
            DefaultSettings();
            OpenFile();
            KeyPreview = true;
            NextMod = next;
            if (NextMod) NextConfigRadio.Checked = true;

            CheckArmyNavyLaunch();
        }

        private void DefaultSettings()
        {
            this.Text = "League Editor";
            dbFile = "";
            TablePropsLabel.Text = "";
            FieldsPropsLabel.Text = "";
            dbIndex2 = -1;


            toolStripSeparator1.Enabled = true;
            saveMenuItem.Enabled = false;
            saveAsMenuItem.Enabled = false;
            closeMenuItem.Enabled = false;
            //
            toolStripSeparator1.Visible = true;
            openMenuItem.Visible = true;
            openMenuItem.Enabled = true;
            saveMenuItem.Visible = true;
            saveAsMenuItem.Visible = true;
            closeMenuItem.Visible = true;
            toolStripSeparator1.Visible = true;
            definitionFileMenuItem.Visible = true;
            toolStripSeparator7.Visible = true;


            CSVMenuItem.Visible = false;

            TablePropsgroupBox.Visible = false;
            FieldsPropsgroupBox.Visible = false;
            progressBar1.Visible = false;

            DBModified = false;
            exportAll = false;
            BigEndian = false;
            addendum = false;
            importRec = false;

            tabControl1.Visible = false;

            tabDelimited = false;

            //ColorDialog
            colorDialog1.AnyColor = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.SolidColorOnly = false;

            activeDB = 0;
            main.dbIndex = 0;

            CustomLeagueToolStrip.Visible = false;

        }

        private void CheckArmyNavyLaunch()
        {
            int teamArmy = main.FindTeamRecfromTeamName("Army");
            int teamNavy = main.FindTeamRecfromTeamName("Navy");

            if(main.GetTeamCGID(teamNavy) == main.GetTeamCGID(teamArmy))
            {
                ArmyNavy = true;
            }

        }


        #region MAIN MENU ITEMS
        // menuStrip1 -- where the save file loading begins
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            tabControl1.SelectTab(tabHome);

            //currentDBfile = GetFileName("", "All Files|*.*|Madden|*.ros; *.fra; *.dbt; *.db; *.pbd; *.pbo; *.rpl; *.spg; *.usr|Roster|*.ros|Franchise|*.fra|Teams|*.dbt|Database|*.db|Playbook|*.pbd; *.pbo|Replay|*.rpl|Spawn|*.spg|Users|*.usr|Console|*.mc02");
            dbFile = GetFileName("", "All Files|*.*|");

            if (dbFile.Contains(".psu") || dbFile.Contains(".max"))
            {
                MessageBox.Show("PSU and MAX Saves from off-season are not supported.\n\nUse at your own risk.\n\nIt is recommended to use save files from Memory Card Folders, or to use PS2 Save Builder to extract the save file from the PSU or MAX Container.");
            }

            if (dbFile != "")
            {
                CheckDB(dbFile);

                OpenDB(dbFile);

                if (dbIndex2 == -1)
                {
                    MessageBox.Show("Error Opening File.", "DB File Error");
                    return;
                }

                if (dbFile != "")
                    this.Text = "League Editor  [ " + Path.GetFileName(dbFile) + " ]";
                else
                    this.Text = "League Editor";

                #region Set Buttons
                openMenuItem.Enabled = false;
                saveMenuItem.Enabled = true;
                saveAsMenuItem.Enabled = false;
                closeMenuItem.Enabled = true;
                CSVMenuItem.Visible = true;

                TablePropsgroupBox.Visible = true;
                FieldsPropsgroupBox.Visible = true;
                progressBar1.Visible = true;


                tabControl1.Visible = true;
                #endregion

                GetTables(dbIndex2);
                LoadTables();

                GetFields(dbIndex2, SelectedTableIndex);
                LoadFields();

                createConsoleData();

            }
        }


        //SAVE FILE
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDB(dbIndex2))
            {

                #region Compile Console Data and DB information.

                byte[] dbarray = File.ReadAllBytes(dbFile);

                BinaryWriter binwriter = new BinaryWriter(File.Open(openFileDialog1.FileName, FileMode.Create));

                // Add pre-DB data 
                if (binData.Count > 0)
                    for (int i = 0; i < binData.Count; i++)
                    {
                        binwriter.Write(binData[i]);
                    }

                if (offSeasonSave && db2Data.Count > 0)
                {
                    // Add DB data.
                    if (dbData.Count > 0)
                        for (int i = 0; i < dbData.Count; i++)
                        {
                            binwriter.Write(dbData[i]);
                        }

                    // add DB2 data.
                    if (dbarray.Length > 0)
                    {
                        for (int i = 0; i < dbarray.Length; i++)
                        {
                            binwriter.Write(dbarray[i]);
                        }
                    }
                }
                else
                {
                    // Add DB data.
                    if (dbarray.Length > 0)
                        for (int i = 0; i < dbarray.Length; i++)
                        {
                            binwriter.Write(dbarray[i]);
                        }

                    // add DB2 data.
                    if (db2Data.Count > 0)
                    {
                        for (int i = 0; i < db2Data.Count; i++)
                            binwriter.Write(db2Data[i]);
                    }
                }


                // add Post-DB data
                if (psuExtras.Count > 0)
                {
                    for (int i = 0; i < psuExtras.Count; i++)
                    {
                        binwriter.Write(psuExtras[i]);
                    }
                }

                binwriter.Dispose();
                binwriter.Close();



                #endregion



                MessageBox.Show(Path.GetFileName(openFileDialog1.FileName) + " saved!", "Save File");
                DBModified = false;
            }
        }
        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            openMenuItem.Enabled = false;
            saveMenuItem.Enabled = false;
            saveAsMenuItem.Enabled = false;
            closeMenuItem.Enabled = true;

        }
        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (DBModified)
            {
                DialogResult result;

                result = MessageBox.Show("              Save changes to " + Path.GetFileName(dbFile) + "?", "Save ", MessageBoxButtons.YesNoCancel);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    saveMenuItem.PerformClick();
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

            }

            DeleteDBFiles();


            if (CloseDB(dbIndex2))
            {
                DefaultSettings();
            }


        }
        private void DefinitionFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            Stream myStream = null;
            openFileDialog2.Filter = "definition files (*.def, *.csv)|*.def; *.csv|All files (*.*)|*.*";
            openFileDialog2.RestoreDirectory = true;

            TableDefinitions.Clear();
            deflist.Clear();

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog2.OpenFile()) != null)
                    {
                        #region setup import table field names

                        // new streamreader based on mystream which is an open file
                        StreamReader sr = new StreamReader(myStream);
                        while (!sr.EndOfStream)
                        {
                            // first line You want something like Editorname, tablecount
                            string headerline = sr.ReadLine();
                            deflist.Add(headerline);

                        }
                        // MessageBox.Show("" + deflist.Count);
                        #endregion

                        // Done with reading in the csv file
                        sr.Close();
                    }

                    // int defcount = 0;
                    // foreach (KeyValuePair<string, Dictionary<string, string>> kvp in TableDefinitions)                    
                    // defcount += kvp.Value.Count;

                }
                catch (IOException err)
                {
#pragma warning disable CS1717 // Assignment made to same variable
                    err = err;
#pragma warning restore CS1717 // Assignment made to same variable
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // close the file before leaving
            if (myStream != null)
                myStream.Close();

            MessageBox.Show(deflist.Count + " definitions loaded.", "Definition File");

            SortTables();
            LoadTables();

            SortFields();
            LoadFields();

        }
        private void ExitToolItem_Click(object sender, EventArgs e)
        {
            if (DBModified)
            {
                DialogResult result;

                result = MessageBox.Show("              Save changes to " + Path.GetFileName(dbFile) + "?", "Save ", MessageBoxButtons.YesNoCancel);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    saveMenuItem.PerformClick();
                    DBModified = false;
                }
                else if (result == System.Windows.Forms.DialogResult.No)
                    DBModified = false;
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

            }
            closeMenuItem.PerformClick();
            Close();
        }

        private void CloseMainEditor_Click()
        {
            closeMenuItem.PerformClick();
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }

        #endregion

        #region CSV Events
        //mainMenuStrip
        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            //ExportMain();
        }
        private void importMenuItem_Click(object sender, EventArgs e)
        {
            //ImportMain();
        }
        private void exportAllMenuItem_Click(object sender, EventArgs e)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            exportAll = true;
            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbIndex2); i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(dbIndex2, i, ref TableProps))
                {
                    SelectedTableName = TableProps.Name;
                    SelectedTableIndex = i;
                    exportToolItem.PerformClick();
                }
            }
            exportAll = false;
        }

        //tableMenuStrip
        private void exportTableMenuItem_Click(object sender, EventArgs e)
        {
            exportToolItem.PerformClick();
        }
        private void importTableMenuItem_Click(object sender, EventArgs e)
        {
            importMenuItem.PerformClick();
        }
        private void exportAllTableMenuItem_Click(object sender, EventArgs e)
        {
            exportAllMenuItem.PerformClick();
        }

        //fieldMenuStrip
        private void exportRecordsMenuItem_Click(object sender, EventArgs e)
        {
            //ExportField();
        }
        private void importRecordsMenuItem_Click(object sender, EventArgs e)
        {
            importRec = true;
            addendum = true;
            TDB.TDBDatabaseCompact(dbIndex2);
            importMenuItem.PerformClick();
            importRec = false;
            addendum = false;
        }
        private void addendumMenuItem_Click(object sender, EventArgs e)
        {
            addendum = true;
            //ImportMain();
            addendum = false;
        }
        //
        #endregion

        #region Copy/Add/Delete 

        private void copyRecordsMenuItem_Click(object sender, EventArgs e)
        {
            int rowcount = fieldsGridView.SelectedRows.Count;
            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;

            DialogResult result = MessageBox.Show("             Copy record(s)?", "Copy Records ", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in fieldsGridView.SelectedRows)
                {
                    // Shouldnt use expand flag as it causes problems in certain tables when it doesnt expect more than
                    // a certain amount of records.  Player table I know has this issue...
                    TDB.TDBTableRecordAdd(dbIndex2, SelectedTableName, true);

                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(dbIndex2, SelectedTableIndex, ref TableProps);


                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    for (int fCount = 0; fCount != TableProps.FieldCount; fCount++)
                    {
                        TDB.TDBFieldGetProperties(dbIndex2, SelectedTableName, fCount, ref FieldProps);

                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            TDB.TDBFieldSetValueAsString(dbIndex2, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToString(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbIndex2, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbIndex2, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToUInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            TDB.TDBFieldSetValueAsFloat(dbIndex2, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToSingle(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                        {
                            // Can't edit these fields.
                        }
                    }

                }

                GetTableProperties();
                DBModified = true;
                // saveToolStripMenuItem.Enabled = true;
                LoadFields();
            }
        }
        private void addRecordsMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("             Add new record(s)?", "Add New Records ", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int rowcount = fieldsGridView.SelectedRows.Count;

                if (rowcount == 0)
                    TDB.TDBTableRecordAdd(dbIndex2, SelectedTableName, true);
                else
                {
                    for (int r = 0; r < rowcount; r++)
                    {
                        // Shouldnt use expand flag as it causes problems in certain tables when it doesnt expect more than
                        // a certain amount of records.  Player table I know has this issue...
                        TDB.TDBTableRecordAdd(dbIndex2, SelectedTableName, true);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                GetTableProperties();
                LoadFields();
            }
        }
        private void deleteRecordsMenuItem_Click(object sender, EventArgs e)
        {
            int rowcount = fieldsGridView.SelectedRows.Count;
            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;

            DialogResult result3 = MessageBox.Show("            Delete selected record(s)?", "Delete Records ", MessageBoxButtons.YesNo);
            if (result3 == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (DataGridViewRow row in fieldsGridView.SelectedRows)
                {
                    // cell 0 contains the record number
                    if (TDB.TDBTableRecordChangeDeleted(dbIndex2, SelectedTableName, Convert.ToInt32(row.Cells[0].Value), true))
                    {
                        fieldsGridView.Rows.RemoveAt(row.Index);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                TDB.TDBDatabaseCompact(dbIndex2);
                GetTableProperties();
                LoadFields();
            }
        }

        #endregion

        #region Options

        private void tabDelimitedMenuItem_Click(object sender, EventArgs e)
        {
            if (tabDelimitedMenuItem.Checked == false)
            {
                tabDelimitedMenuItem.Checked = true;
                tabDelimited = true;
            }
            else
            {
                tabDelimitedMenuItem.Checked = false;
                tabDelimited = false;
            }
        }


        private void defaultMenuItem_Click(object sender, EventArgs e)
        {
            defaultFieldOrderMenuItem.Checked = true;
            ascendingFieldOrderMenuItem.Checked = false;
            descendingFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            GetTables(dbIndex2);
            LoadTables();

            GetFields(dbIndex2, SelectedTableIndex);
            LoadFields();
        }
        private void ascendingMenuItem_Click(object sender, EventArgs e)
        {
            ascendingFieldOrderMenuItem.Checked = true;
            defaultFieldOrderMenuItem.Checked = false;
            descendingFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            //getTABLES(currentDBfileIndex);
            SortTables();
            LoadTables();

            //getFIELDS(currentDBfileIndex, SelectedTableIndex);
            SortFields();
            LoadFields();
        }
        private void descendingMenuItem_Click(object sender, EventArgs e)
        {
            descendingFieldOrderMenuItem.Checked = true;
            ascendingFieldOrderMenuItem.Checked = false;
            defaultFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            //getTABLES(currentDBfileIndex);
            SortTables();
            LoadTables();

            //getFIELDS(currentDBfileIndex, SelectedTableIndex);
            SortFields();
            LoadFields();
        }
        private void customMenuItem_Click(object sender, EventArgs e)
        {
            //customToolStripMenuItem.Checked = true;
            //defaultToolStripMenuItem.Checked = false;
            //ascendingToolStripMenuItem.Checked = false;
            //descendingToolStripMenuItem.Checked = false;

            customTABLE();
        }

        private void customTABLE()
        {
            Dictionary<int, string> tmpFIELDnames = new Dictionary<int, string>();

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            Stream myStream = null;
            openFileDialog2.Filter = "custom table files (*.def, *.csv)|*.def; *.csv|All files (*.*)|*.*";
            openFileDialog2.RestoreDirectory = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog2.OpenFile()) != null)
                    {
                        #region setup import table field names

                        // new streamreader based on mystream which is an open file
                        StreamReader sr = new StreamReader(myStream);
                        string headerline = sr.ReadLine();
                        sr.Close();

                        string[] csvfieldnames = headerline.Split(',');

                        tmpFIELDnames.Clear();
                        for (int c = 0; c < csvfieldnames.Length; c++)
                        {
                            foreach (KeyValuePair<int, string> sortAZ in FieldNames)
                            {
                                if (csvfieldnames[c] == sortAZ.Value)
                                {
                                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);
                                    break;
                                }
                            }
                        }

                        FieldNames.Clear();
                        foreach (KeyValuePair<int, string> sortAZ in tmpFIELDnames)
                            FieldNames.Add(sortAZ.Key, sortAZ.Value);

                        #endregion

                    }

                }
                catch (IOException err)
                {
#pragma warning disable CS1717 // Assignment made to same variable
                    err = err;
#pragma warning restore CS1717 // Assignment made to same variable
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // close the file before leaving
            if (myStream != null)
            {
                myStream.Close();
                LoadFields();
            }


        }

        #endregion



        #region LOAD/SAVE ACTIONS
        public string GetFileName(string ext, string filter)
        {
            openFileDialog1.FileName = Path.GetFileName(dbFile);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbFile = openFileDialog1.FileName;
            }
            else
                dbFile = "";

            return dbFile;
        }
        private void CheckDB(string filename)
        {

            binData.Clear();
            dbData.Clear();
            db2Data.Clear();

            BigEndian = false;
            byte[] array = File.ReadAllBytes(filename);  // Load file into memory.

            int i = 0;
            int db = 0;

            while (i < array.Length)
            {
                if (Convert.ToChar(array[i]) + "" + Convert.ToChar(array[i + 1]) == "DB")
                {
                    // Check if DB is BigEndian.
                    if (Convert.ToUInt32(array[i + 4]) == 1)
                        BigEndian = true;

                    // Save DB information.
                    for (int j = i; j < array.Length; j++)
                    {
                        //Checks to see if a second database exists and if so, store it in off-season db array
                        //Checks using bin values of the first four bytes of database header
                        if (array[j] == 68 && array[j + 1] == 66 && array[j + 2] == 0 && array[j + 3] == 8 && db == 1)
                        {
                            for (int k = j; k < array.Length; k++)
                            {
                                db2Data.Add(array[k]);
                            }
                            db = 2;
                            break;
                        }


                        dbData.Add(array[j]);
                        db = 1; //sets db to 1 to signify it found the 1st DB (i.e. the normal db)
                    }
                    // end Save DB information.

                    break;
                }

                binData.Add(array[i]);
                i++;
            }

            BinaryWriter dbWriter;

            // Save BIN information for Debugging
            #region
            /*
            if (binData.Count > 0)
            {
            dbbinwriter = new BinaryWriter(File.Open(System.IO.Path.ChangeExtension(filename, null) + ".dbBIN", FileMode.Create));
            for (int j = 0; j < binData.Count; j++)
                dbbinwriter.Write(binData[j]);
            }
            */
            #endregion


            // If off-season is checked, it will load the 2nd DB intead of main DB
            if (offSeasonSave && db2Data.Count > 0)
            {
                // Save DB information.
                dbWriter = new BinaryWriter(File.Create(filename + ".db"));

                for (int j = 0; j < dbData.Count; j++)
                    dbWriter.Write(dbData[j]);
                dbWriter.Dispose();
                dbWriter.Close();

                // Save OS DB information.
                if (db2Data.Count > 0)
                {
                    dbWriter = new BinaryWriter(File.Create(filename + ".db2"));

                    for (int j = 0; j < db2Data.Count; j++)
                        dbWriter.Write(db2Data[j]);
                    dbWriter.Dispose();
                    dbWriter.Close();
                }
                // end Save DB information.

                //choose active DB
                dbFile = filename + ".db2";
                activeDB = 2; //sets activeDB to DB2


            }
            else
            {
                // Save OS DB information.
                if (db2Data.Count > 0)
                {
                    dbWriter = new BinaryWriter(File.Create(filename + ".db2"));

                    for (int j = 0; j < db2Data.Count; j++)
                        dbWriter.Write(db2Data[j]);
                    dbWriter.Dispose();
                    dbWriter.Close();
                }


                // Save DB information.
                dbWriter = new BinaryWriter(File.Create(filename + ".db"));

                for (int j = 0; j < dbData.Count; j++)
                    dbWriter.Write(dbData[j]);
                dbWriter.Dispose();
                dbWriter.Close();
                // end Save DB information.

                //choose active DB
                dbFile = filename + ".db";
            }
        }

        //Extra Console Data for PSU, MAX containers
        private void createConsoleData()
        {
            //Determine and Write PSU File
            psuExtras.Clear();

            List<byte> psuTmp = dbData;
            Array array;
            int x, y;

            if (offSeasonSave && db2Data.Count > 0)
            {
                SaveDB(dbIndex2);
                array = File.ReadAllBytes(dbFile); //db2
                x = 0;
                y = array.Length;
                psuTmp = db2Data;
            }
            else
            {
                foreach (byte b in db2Data)
                    psuTmp.Add(b);

                SaveDB(dbIndex2);
                array = File.ReadAllBytes(dbFile); //db1
                x = array.Length;
                y = db2Data.Count;
            }

            for (int i = x + y; i < psuTmp.Count; i++)
                psuExtras.Add(psuTmp[i]);

        }
        public void OpenDB(string dbFileName)
        {
            if (dbIndex2 == -1)
                dbIndex2 = TDB.TDBOpen(dbFileName);
        }

        public bool SaveDB(int DBIndex)
        {
            // If you want to remove any records that were set to delete    TDB.TDBDatabaseCompact(OpenIndex);
            TDB.TDBDatabaseCompact(DBIndex);
            if (!TDB.TDBSave(DBIndex))
            {
                MessageBox.Show("Error Saving File.", "DB Save File Error");
                return false;
            }
            else
                return true;
        }
        public bool CloseDB(int DBIndex)
        {
            if (!TDB.TDBClose(DBIndex))
            {
                MessageBox.Show("Error Closing File.", "DB Close File Error");
                return false;
            }
            else return true;

        }
        public void DeleteDBFiles()
        {
            string tmpFilename = Path.GetDirectoryName(dbFile) + @"\" + Path.GetFileNameWithoutExtension(dbFile) + ".db";
            string tmpFilename2 = Path.GetDirectoryName(dbFile) + @"\" + Path.GetFileNameWithoutExtension(dbFile) + ".db2";
            File.Delete(tmpFilename);
            File.Delete(tmpFilename2);
        }

        #endregion



        #region TDB DATA ACTIONS

        private void GetTables(int dbFILEindex)
        {
            TableNames.Clear();

            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

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
                //progressBar1.PerformStep();
                progressBar1.Value = i;

            }
            progressBar1.Value = 0;
            SortTables();

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
            FieldNames.Clear();
            // int rownum = fieldsGridView.CurrentCellAddress.Y;
            // int colnum = fieldsGridView.CurrentCellAddress.X;

            TablePropsLabel.Text = "";

            if (tableGridView.SelectedRows.Count <= 0 || dbIndex2 == -1)
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
            GetFields(dbIndex2, SelectedTableIndex);
            LoadFields();


        }
        private void GetTableProperties()
        {
            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbIndex2, SelectedTableIndex, ref TableProps);

            // TablePropsLabel.Text = "Tables: " + TDB.TDBDatabaseGetTableCount(currentDBfileIndex) + "    Table Name: " + tableGridView.SelectedRows[0].Cells[1].Value.ToString() + "   Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString();
            TablePropsLabel.Text = "Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString() + "  CID: " + dbIndex2;

        }

        private void GetFields(int dbFILEindex, int tmpTABLEindex)
        {
            FieldNames.Clear();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

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
                FieldProps.Name = new string((char)0, 5);

                TDB.TDBFieldGetProperties(dbFILEindex, GetTableName(dbFILEindex, tmpTABLEindex), i, ref FieldProps);

                string tmpFIELDname = FieldProps.Name;
                if (BigEndian)
                    tmpFIELDname = StrReverse(tmpFIELDname);

                FieldNames.Add(i, tmpFIELDname);

                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;

            if (TableProps.Name == "PLAY")
            {
                if (TDB.TableIndex(dbFILEindex, "First Name") == -1)
                    FieldNames.Add(FieldNames.Count, "First Name");

                if (TDB.TableIndex(dbFILEindex, "Last Name") == -1)
                    FieldNames.Add(FieldNames.Count, "Last Name");

                if (TDB.TableIndex(dbFILEindex, "Position") == -1)
                    FieldNames.Add(FieldNames.Count, "Position");

                if (TDB.TableIndex(dbFILEindex, "Team Name") == -1)
                    FieldNames.Add(FieldNames.Count, "College");
            }

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
            int tmpFIELDcount = FieldNames.Count;

            fieldsGridView.EnableHeadersVisualStyles = false;
            fieldsGridView.Rows.Clear();
            fieldsGridView.Columns.Clear();

            #region Populate column header with field names.
            //
            fieldsGridView.ColumnCount = tmpFIELDcount + 2;  // set maximum columns (FieldCount + RecNo + autofill last column)
            fieldsGridView.Columns[0].Name = "Rec";
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
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(dbIndex2, SelectedTableIndex, ref TableProps))
                return;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TableProps.RecordCount;
            progressBar1.Step = 1;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(dbIndex2, TableProps.Name, r))
                    continue;

                int tmpf = 0;

                int fCount = TableProps.FieldCount + 1;


                // Format FieldGridView by tdbFieldType.
                object[] DataGridRow = new object[fCount];
                DataGridRow[0] = r;

                foreach (KeyValuePair<int, string> f in FieldNames)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex2, TableProps.Name, f.Key, ref FieldProps);

                    #region Load fieldsGridView by tdbFieldType.
                    //
                    if (FieldProps.FieldType == TdbFieldType.tdbString)
                    {
                        // I think Values that are a string might have to be formatted to a specific length
                        // it probably has something to do with the language he made the dll with
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);


                        TDB.TDBFieldGetValueAsString(dbIndex2, TableProps.Name, FieldProps.Name, r, ref val);
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
                        intval = (UInt32)GetDBValueInt(TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = intval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                    {
                        Int32 signedval;
                        signedval = GetDBValueInt(TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = signedval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                    {
                        float floatval;
                        floatval = TDB.TDBFieldGetValueAsFloat(dbIndex2, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = floatval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                    {
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);
                        TDB.TDBFieldGetValueAsString(dbIndex2, TableProps.Name, FieldProps.Name, r, ref val);

                        DataGridRow[tmpf + 1] = val;
                    }
                    else
                    {
                        DataGridRow[tmpf + 1] = "na";
                    }
                    //
                    #endregion

                    tmpf = tmpf + 1;

                }


                fieldsGridView.Rows.Add(DataGridRow);
                progressBar1.PerformStep();
            }


            progressBar1.Value = 0;
            #endregion

        }
        private void FieldGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dbIndex2 == -1 || FieldNames.Count < 0)
                return;

            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;



            FieldsPropsLabel.Text = "";

            if (colnum > FieldNames.Count || colnum < 0 || rownum < 0)
                return;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbIndex2);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbIndex2, tmpTableIndex, ref tableProps);

                if (tableProps.Name == SelectedTableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(dbIndex2, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion


            FieldsPropsLabel.Text = "Field: " + fieldProps.Name.ToString() +
                                 "    Bits: " + fieldProps.Size.ToString() +
                                 "    Type: " + fieldProps.FieldType.ToString() +
                                 "  MaxVal: " + BitMax(fieldProps.Size);

        }
        private void FieldGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;
            fieldsGridView.Rows[rownum].Cells[colnum].Style.ForeColor = Color.Red;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);
            int tmpcol = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[0].Value);

            // MessageBox.Show(tmpFieldName);

            if (fieldsGridView.SelectedRows.Count <= 0 || dbIndex2 == -1 || colnum < 0 || rownum < 0)
                return;

            DBModified = true;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbIndex2);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbIndex2, tmpTableIndex, ref tableProps);

                if (tableProps.Name == SelectedTableName)
                    break;
            }
            #endregion

            #region Get FIELD Properties
            TdbFieldProperties fieldProps = new TdbFieldProperties();
            fieldProps.Name = new string((char)0, 5);

            int tmpFieldCount = tableProps.FieldCount;
            for (int tmpFieldIndex = 0; tmpFieldIndex < tmpFieldCount; tmpFieldIndex++)
            {
                TDB.TDBFieldGetProperties(dbIndex2, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion

            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                string tmpval = Convert.ToString(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                // string val = new string((char)0, (FieldProps.Size / 8) + 1);

                tmpval = tmpval.Replace(",", "");

                if (!TDB.TDBFieldSetValueAsString(dbIndex2, SelectedTableName, fieldProps.Name, tmpcol, tmpval))
                    fieldsGridView.Rows[rownum].Cells[colnum].Value = tmpval;

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                int tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                UInt32 intval = Convert.ToUInt32(tmpval);

                // int val = (Int32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(tmpcol));
                if (IsUIntNumber(Convert.ToString(tmpval)))
                {
                    if (!TDB.TDBFieldSetValueAsInteger(dbIndex2, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(intval)))
                        fieldsGridView.Rows[rownum].Cells[colnum].Value = Convert.ToUInt32(intval);

                }

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbInt || fieldProps.FieldType == TdbFieldType.tdbSInt)
            {
                int tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                Int32 intval = Convert.ToInt32(tmpval);

                // int val = (Int32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(tmpcol));

                if (IsIntNumber(Convert.ToString(tmpval)))
                {

                    bool tmpTDB = TDB.TDBFieldSetValueAsInteger(dbIndex2, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(tmpval));
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
                float tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                // Int32 intval = Convert.ToInt32(tmpval);

                // float val = (float)TDB.TDBFieldGetValueAsFloat(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(tmpcol));

                if (IsFloat(Convert.ToString(tmpval)))
                {

                    bool tmpTDB = TDB.TDBFieldSetValueAsFloat(dbIndex2, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToSingle(tmpval));
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
                //string val = new string((char)0, (FieldProps.Size / 8) + 1);

                // TDB.TDBFieldGetValueAsString(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[0].Value), ref val);

                //val = Convert.ToString(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                //val = val.Replace(",", "");

                //fieldsGridView.Rows[rownum].Cells[colnum].Value = Convert.ToString(val);
            }


        }

        private string FieldDEF(string fieldname)
        {
            // MessageBox.Show(fieldname + " " + deflist.Count);

            if (deflist.Count <= 0)
                return fieldname;

            for (int defCount = 1; defCount < deflist.Count; defCount++)
            {
                string s = deflist[defCount];
                string newstring = "";
                // MessageBox.Show(s);
                if (s.Length > 3)
                    newstring = s.Substring(0, 4);

                // MessageBox.Show(newstring + "   " + s.Length);

                if (newstring == fieldname)
                {
                    fieldname = s.Substring(5, s.Length - 5);
                    // fieldname = defstring;
                    break;
                }
            }

            return fieldname;
        }
        private string BitMax(int bitsize)
        {
            int temp = (int)Math.Pow(2, bitsize) - 1;
            return temp.ToString();
        }
        private static string StrReverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        private static bool IsIntNumber(String str)
        {
            Int32 a;
            if (Int32.TryParse(str, out a))
            {
                // Value is numberic
                return true;
            }
            else
            {
                //Not a valid number
                return false;
            }
        }
        private static bool IsUIntNumber(String str)
        {
            UInt32 a;
            if (UInt32.TryParse(str, out a))
            {
                // Value is numberic
                return true;
            }
            else
            {
                //Not a valid number
                return false;
            }

        }
        private static bool IsFloat(String str)
        {
            decimal a;
            if (Decimal.TryParse(str, out a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private int GetFieldIndex(string tmpFName)
        {
            int tmpIndex = 0;

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            TDB.TDBTableGetProperties(dbIndex2, SelectedTableIndex, ref TableProps);

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            FieldProps.Name = new string((char)0, 5);

            for (int index = 0; index < TableProps.FieldCount; index++)
            {
                TDB.TDBFieldGetProperties(dbIndex2, SelectedTableName, index, ref FieldProps);

                if (tmpFName == FieldProps.Name)
                {
                    tmpIndex = index;
                    break;
                }
            }
            // MessageBox.Show(tmpIndex + " ", tmpFName + " - " + FieldProps.Name);
            return tmpIndex;
        }
        private string GetTableName(int dbFILEindex, int tmpTABLEindex)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbFILEindex);

            string tmpTABLEname = "";

            if (tmpTABLEindex < tmpTableCount)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                TDB.TDBTableGetProperties(dbFILEindex, tmpTABLEindex, ref TableProps);

                tmpTABLEname = TableProps.Name;

                if (BigEndian)
                    tmpTABLEname = StrReverse(tmpTABLEname);
            }
            // MessageBox.Show(tmpTABLEname + "  index: " + tmpTABLEindex);
            return tmpTABLEname;
        }
        private int GetTableIndex(int dbFILEindex, string tmpTABLEname)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbFILEindex);
            int tmpTABLEindex = -1;

            for (int i = 0; i < tmpTableCount; i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                TDB.TDBTableGetProperties(dbFILEindex, i, ref TableProps);

                if (BigEndian)
                    TableProps.Name = StrReverse(TableProps.Name);

                if (tmpTABLEname == TableProps.Name)
                {
                    tmpTABLEindex = i;
                    break;
                }

            }
            // MessageBox.Show(TableProps.Name + "  index: " + tmpTABLEindex);
            return tmpTABLEindex;
        }

        #endregion

        //Tab Start
        private void TabControl1_IndexChange(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabConf) ConferenceSetup();
            if (tabControl1.SelectedTab == tabAnnuals) AnnualsSetup();
            if (tabControl1.SelectedTab == tabBowls) BowlsSetup();
            if (tabControl1.SelectedTab == tabCChamps) ConfChampsSetup();

        }

        #region DataErrors
        private void BowlsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void ChampGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void AnnualsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }













        #endregion

        private void NextConfigRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NextConfigRadio.Checked)
            {
                NextMod = true;
                Next26Mod = false;
                radio120.Checked = true;
            }
            else if (Next26Config.Checked)
            {
                NextMod = false;
                Next26Mod = true;
                radio136.Checked = true;
            }
            else
            {
                NextMod = false;
                Next26Mod = false;
                radio120.Checked = true;
            }
        }

        private void OGConfigRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (NextConfigRadio.Checked)
            {
                NextMod = true;
                Next26Mod = false;
                radio120.Checked = true;
            }
            else if (Next26Config.Checked)
            {
                NextMod = false;
                Next26Mod = true;
                radio136.Checked = true;
            }
            else
            {
                NextMod = false;
                Next26Mod = false;
                radio120.Checked = true;
            }
        }

        private void Next26Config_CheckedChanged(object sender, EventArgs e)
        {
            if (NextConfigRadio.Checked)
            {
                NextMod = true;
                Next26Mod = false;
                radio120.Checked = true;
            }
            else if (Next26Config.Checked)
            {
                NextMod = false;
                Next26Mod = true;
                radio136.Checked = true;
            }
            else
            {
                NextMod = false;
                Next26Mod = false;
                radio120.Checked = true;
            }
        }
    }

}
