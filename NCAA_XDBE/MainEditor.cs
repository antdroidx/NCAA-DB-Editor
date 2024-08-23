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


    public partial class MainEditor : Form
    {
        #region Global Variables

        Random rand = new Random();

        string dbFile = "";
        int dbIndex = -1;  // 0 = Open/Save, 1 = Save As..., 2 = settings.db, 3 = streameddata.db, 4 = 00012-DB_TEMPLATES.db

        string SelectedTableName = "";
        int SelectedTableIndex = -1;

        bool DBModified = false;
        bool exportAll = false;
        bool BigEndian = false;
        bool addendum = false;
        bool importRec = false;
        bool DoNotTrigger = false; //team/player editor
        bool coachProgComplete = false;
        bool TDYN = false;
        bool TEAM = false;


        int EditorIndex;
        Color primary = Color.Black;
        Color secondary = Color.White;
        List<List<string>> AllTeamPlayers;
        List<List<string>> OffPlayers;
        List<List<string>> DefPlayers;
        int OCAPmem, DCAPmem, TSI1mem, TSI2mem, TPIOmem, TPIDmem;


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

        // current table's Fields Index  string = FieldName, int = FieldIndex
        Dictionary<string, int> ctFieldsID = new Dictionary<string, int>();

        // 
        Dictionary<int, int> tmpManagement = new Dictionary<int, int>();

        Dictionary<int, int> TGIDrecNo = new Dictionary<int, int>();  //  RecNo/TGID
        Dictionary<int, int> TGIDlist = new Dictionary<int, int>();   //  SelectedIndex/Recno

        Dictionary<int, int> PGIDrecNo = new Dictionary<int, int>();  //  RecNo/PGID
        Dictionary<int, int> PGIDlist = new Dictionary<int, int>();   //  SelectedIndex/RecNo
        Dictionary<int, int> ROSrecNo = new Dictionary<int, int>();   //  RecNo/PGID

        Dictionary<int, int> CONFrecNo = new Dictionary<int, int>();  //  RecNo/CONF
        Dictionary<int, int> CONFlist = new Dictionary<int, int>();   //  SelectedIndex/Recno

        Dictionary<int, string> Alphabet = new Dictionary<int, string>();
        Dictionary<string, int> AlphabetX = new Dictionary<string, int>();

        int maxTeamsDB = 511; //max team number for team db

        int fCount_addon = 5; //number of extra columns (fields) to add to PLAY table
        int fCount_First = 4; //5-4 = 1 = 1st new column
        int fCount_Last = 3;
        int fCount_Pos = 2;
        int fCount_Team = 1;



        string[] teamNameDB = new string[511]; //temporary holder of Team Names assigned by TGID location in the array
        string[] teamMascot = new string[511]; //temporary holder of Team Names assigned by TGID location in the array
        int maxNameChar = 10; //maximum number of name characters (reserving extra last name letters for modding)
        Dictionary<int, string> Positions = new Dictionary<int, string>(); //database of ppos id,position name
        Dictionary<string, int> PositionsX = new Dictionary<string, int>(); //database of position name, ppos id
        Dictionary<int, int> Ratings = new Dictionary<int, int>(); //database of db rating, in-game rating
        Dictionary<int, int> RatingsX = new Dictionary<int, int>(); //database of in-game rating, db rating

        double[,] POCI;
        List<List<int>> RCAT;
        List<string> FirstNames;
        List<string> LastNames;

        #endregion

        public MainEditor()
        {
            InitializeComponent();
            DefaultSettings();

        }

        private void DefaultSettings()
        {
            this.Text = "NCAA Next DB Editor";
            dbFile = "";
            TablePropsLabel.Text = "";
            FieldsPropsLabel.Text = "";
            dbIndex = -1;


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

            DoNotTrigger = false;

            coachProgComplete = false;
            TDYN = false;
            TEAM = false;
            EditorIndex = -1;


            tabControl1.Visible = false;

            tabControl1.TabPages.Remove(tabTeams);
            tabControl1.TabPages.Remove(tabPlayers);
            tabControl1.TabPages.Remove(tabSeason);
            tabControl1.TabPages.Remove(tabOffSeason);
            tabControl1.TabPages.Remove(tabTools);
            tabControl1.TabPages.Remove(tabCoaches);
            tabControl1.TabPages.Remove(tabConf);
            tabControl1.TabPages.Remove(tabDev);


            /*
            tabControl1.TabPages["tabTeams"].Enabled = false;
            tabControl1.TabPages["tabPlayers"].Enabled = false;
            tabControl1.TabPages["tabSeason"].Enabled = false;
            tabControl1.TabPages["tabCoaches"].Enabled = false;
            tabControl1.TabPages["tabConf"].Enabled = false;
            tabControl1.TabPages["tabOffSeason"].Enabled = false;
            tabControl1.TabPages["tabTools"].Enabled = false;
            tabControl1.TabPages["tabDev"].Enabled = false;
            */


            tabDelimited = false;

            //ColorDialog
            colorDialog1.AnyColor = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.SolidColorOnly = false;


            TGIDrecNo.Clear();
            PGIDrecNo.Clear();

            activeDB = 0;
        }


        #region MAIN MENU ITEMS
        // menuStrip1 -- where the save file loading begins
        private void OpenMenuItem_Click(object sender, EventArgs e)
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

                if (dbIndex == -1)
                {
                    MessageBox.Show("Error Opening File.", "DB File Error");
                    return;
                }

                if (dbFile != "")
                    this.Text = "NCAA Next DB Editor  [ " + Path.GetFileName(dbFile) + " ]";
                else
                    this.Text = "NCAA Next DB Editor";

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
                OpenTabs();

                #endregion

                GetTables(dbIndex);
                LoadTables();

                GetFields(dbIndex, SelectedTableIndex);
                LoadFields();

                createConsoleData();

            }
        }

        private void EnableOffSeasonDBMenuItem_Click(object sender, EventArgs e)
        {
            if (enableOffSeasonMenuItem.Checked)
            {
                enableOffSeasonMenuItem.Checked = false;
                offSeasonSave = false;
            }
            else
            {
                enableOffSeasonMenuItem.Checked = true;
                offSeasonSave = true;
            }
        }


        //SAVE FILE
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDB(dbIndex))
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


            if (CloseDB(dbIndex))
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
            ExportMain();
        }
        private void importMenuItem_Click(object sender, EventArgs e)
        {
            ImportMain();
        }
        private void exportAllMenuItem_Click(object sender, EventArgs e)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            exportAll = true;
            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbIndex); i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(dbIndex, i, ref TableProps))
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
            ExportField();
        }
        private void importRecordsMenuItem_Click(object sender, EventArgs e)
        {
            importRec = true;
            addendum = true;
            TDB.TDBDatabaseCompact(dbIndex);
            importMenuItem.PerformClick();
            importRec = false;
            addendum = false;
        }
        private void addendumMenuItem_Click(object sender, EventArgs e)
        {
            addendum = true;
            ImportMain();
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
                    TDB.TDBTableRecordAdd(dbIndex, SelectedTableName, true);

                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);


                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    for (int fCount = 0; fCount != TableProps.FieldCount; fCount++)
                    {
                        TDB.TDBFieldGetProperties(dbIndex, SelectedTableName, fCount, ref FieldProps);

                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            TDB.TDBFieldSetValueAsString(dbIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToString(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToUInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            TDB.TDBFieldSetValueAsFloat(dbIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToSingle(row.Cells[fCount + 1].Value));
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
                    TDB.TDBTableRecordAdd(dbIndex, SelectedTableName, true);
                else
                {
                    for (int r = 0; r < rowcount; r++)
                    {
                        // Shouldnt use expand flag as it causes problems in certain tables when it doesnt expect more than
                        // a certain amount of records.  Player table I know has this issue...
                        TDB.TDBTableRecordAdd(dbIndex, SelectedTableName, true);
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
                    if (TDB.TDBTableRecordChangeDeleted(dbIndex, SelectedTableName, Convert.ToInt32(row.Cells[0].Value), true))
                    {
                        fieldsGridView.Rows.RemoveAt(row.Index);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                TDB.TDBDatabaseCompact(dbIndex);
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

            GetTables(dbIndex);
            LoadTables();

            GetFields(dbIndex, SelectedTableIndex);
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

            //File.Open(Path.ChangeExtension(currentDBfile, null) + ".db", FileMode.Open).Close();
            //if(db == 2) File.Open(Path.ChangeExtension(currentDBfile, null) + ".db2", FileMode.Open).Close();
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
                SaveDB(dbIndex);
                array = File.ReadAllBytes(dbFile); //db2
                x = 0;
                y = array.Length;
                psuTmp = db2Data;
            }
            else
            {
                foreach (byte b in db2Data)
                    psuTmp.Add(b);

                SaveDB(dbIndex);
                array = File.ReadAllBytes(dbFile); //db1
                x = array.Length;
                y = db2Data.Count;
            }

            for (int i = x + y; i < psuTmp.Count; i++)
                psuExtras.Add(psuTmp[i]);

            // Debug Output
            /*
            BinaryWriter dbWriter = new BinaryWriter(File.Open(System.IO.Path.ChangeExtension(currentDBfile, null) + ".dbPSU", FileMode.Create));
            for (int i = 0; i < psuExtras.Count; i++)
                dbWriter.Write(psuExtras[i]);


            dbWriter.Close();
            dbWriter.Dispose();
            */

        }
        public void OpenDB(string dbFileName)
        {
            if (dbIndex == -1)
                dbIndex = TDB.TDBOpen(dbFileName);
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
            tableGridView.Columns[0].Name = "RecNo";
            tableGridView.Columns[0].Width = 45;
            tableGridView.Columns[1].Name = "Name";
            tableGridView.Columns[1].Width = 47;

            SetPositions();
            CreateRatingsDB();
            CreatePOCItable();

            int tmpi = 0;
            foreach (KeyValuePair<int, string> TABLE in TableNames)
            {
                // Populate Table Grid
                object[] DataGrid = new object[2];
                DataGrid[0] = TABLE.Key;
                DataGrid[1] = TABLE.Value;

                if (TABLE.Value == "TEAM")
                {
                    TEAM = true;
                    CreateTeamDB();

                    //BOOKMARK TAB PAGES ON/OFF

                    tabControl1.TabPages.Add(tabTeams);
                }
                if (TABLE.Value == "PLAY")
                {
                    tabControl1.TabPages.Add(tabPlayers);
                    activeDB = 1;
                    OpenTabs();
                }
                if (TABLE.Value == "TDYN")
                {
                    TDYN = true;
                    CreateTeamDB();
                    tabControl1.TabPages.Add(tabDev);
                }
                if (TABLE.Value == "CONF")
                {
                    tabControl1.TabPages.Add(tabConf);
                }
                if (TABLE.Value == "COCH")
                {
                    //tabControl1.TabPages.Add(tabCoaches);
                }


                string tmpDef = FieldDEF(TABLE.Value);

                tableGridView.Rows.Add(DataGrid);

                if (tmpDef != TABLE.Value)
                {
                    tableGridView.Rows[tmpi].Cells[1].ToolTipText = tmpDef;
                    tableGridView.Rows[tmpi].Cells[1].Style.BackColor = Color.Khaki;
                }
                tmpi = tmpi + 1;
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

            if (tableGridView.SelectedRows.Count <= 0 || dbIndex == -1)
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
            GetFields(dbIndex, SelectedTableIndex);
            LoadFields();


        }
        private void GetTableProperties()
        {
            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);

            // TablePropsLabel.Text = "Tables: " + TDB.TDBDatabaseGetTableCount(currentDBfileIndex) + "    Table Name: " + tableGridView.SelectedRows[0].Cells[1].Value.ToString() + "   Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString();
            TablePropsLabel.Text = "Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString() + "  CID: " + dbIndex;

        }

        private void GetFields(int dbFILEindex, int tmpTABLEindex)
        {
            if (TDB.TableIndex(dbFILEindex, "PNLU") != -1)
            {
                //Creates a Name Conversion table from the Dynasty DB PNLU table
                CloneNameConversionTable(dbFILEindex, "PNLU", "PNNU");
            }
            else
            {
                //Creates a hard-coded Conversion Table
                CreateNameConversionTable();
            }

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

                tmpi = tmpi + 1;
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
            if (!TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps))
                return;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TableProps.RecordCount;
            progressBar1.Step = 1;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(dbIndex, TableProps.Name, r))
                    continue;

                int tmpf = 0;

                int fCount = TableProps.FieldCount + 1;

                if (TableProps.Name == "PLAY" && TDB.FieldIndex(dbIndex, SelectedTableName, "First Name") == -1 && TDB.FieldIndex(dbIndex, SelectedTableName, "Last Name") == -1)
                    fCount = TableProps.FieldCount + fCount_addon;


                // Format FieldGridView by tdbFieldType.
                object[] DataGridRow = new object[fCount];
                DataGridRow[0] = r;

                if (SelectedTableName == "PLAY")
                {
                    if (TDB.FieldIndex(dbIndex, SelectedTableName, "First Name") == -1)
                    {
                        fieldsGridView.Columns[fCount - fCount_First].Width = 86;
                        DataGridRow[fCount - fCount_First] = GetFirstNameFromRecord(r);
                    }
                    if (TDB.FieldIndex(dbIndex, SelectedTableName, "Last Name") == -1)
                    {
                        fieldsGridView.Columns[fCount - fCount_Last].Width = 86;
                        DataGridRow[fCount - fCount_Last] = GetLastNameFromRecord(r);
                        fieldsGridView.Columns[fCount - fCount_Team].Width = 86;
                        fieldsGridView.Columns[fCount - fCount_Pos].Width = 86;
                    }
                }



                foreach (KeyValuePair<int, string> f in FieldNames)
                {
                    if (TableProps.Name == "PLAY" && f.Key > FieldNames.Count - fCount_addon)
                        continue;

                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(dbIndex, TableProps.Name, f.Key, ref FieldProps);

                    #region Load fieldsGridView by tdbFieldType.
                    //
                    if (FieldProps.FieldType == TdbFieldType.tdbString)
                    {
                        // I think Values that are a string might have to be formatted to a specific length
                        // it probably has something to do with the language he made the dll with
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);


                        TDB.TDBFieldGetValueAsString(dbIndex, TableProps.Name, FieldProps.Name, r, ref val);
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

                        if (FieldProps.Name == "PGID" && teamNameDB.Length > 0 && TableProps.Name == "PLAY")
                        {
                            DataGridRow[fCount - fCount_Team] = GetTeamName((int)intval / 70);
                        }
                        else if (FieldProps.Name == "PPOS" && TableProps.Name == "PLAY")
                        {
                            pos = (UInt32)GetDBValueInt("PLAY", "PPOS", r);
                            DataGridRow[fCount - fCount_Pos] = GetPositionName((int)pos);
                        }
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
                        floatval = TDB.TDBFieldGetValueAsFloat(dbIndex, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = floatval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                    {
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);
                        TDB.TDBFieldGetValueAsString(dbIndex, TableProps.Name, FieldProps.Name, r, ref val);

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
            if (dbIndex == -1 || FieldNames.Count < 0)
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

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbIndex, tmpTableIndex, ref tableProps);

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
                TDB.TDBFieldGetProperties(dbIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
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

            if (fieldsGridView.SelectedRows.Count <= 0 || dbIndex == -1 || colnum < 0 || rownum < 0)
                return;

            DBModified = true;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(dbIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(dbIndex, tmpTableIndex, ref tableProps);

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
                TDB.TDBFieldGetProperties(dbIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion

            if (SelectedTableName == "PLAY" && tmpFieldName == "First Name" || tmpFieldName == "Last Name")
            {
                if (tmpFieldName == "First Name" && TDB.FieldIndex(dbIndex, SelectedTableName, "First Name") == -1)
                {
                    string tmpPFNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();


                    ConvertFirstNameStringToInt(tmpPFNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }

                if (tmpFieldName == "Last Name" && TDB.FieldIndex(dbIndex, SelectedTableName, "Last Name") == -1)
                {
                    string tmpPLNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();

                    ConvertLastNameStringToInt(tmpPLNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }

            }
            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                string tmpval = Convert.ToString(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                // string val = new string((char)0, (FieldProps.Size / 8) + 1);

                tmpval = tmpval.Replace(",", "");

                if (!TDB.TDBFieldSetValueAsString(dbIndex, SelectedTableName, fieldProps.Name, tmpcol, tmpval))
                    fieldsGridView.Rows[rownum].Cells[colnum].Value = tmpval;

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                int tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                UInt32 intval = Convert.ToUInt32(tmpval);

                // int val = (Int32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(tmpcol));
                if (IsUIntNumber(Convert.ToString(tmpval)))
                {
                    if (!TDB.TDBFieldSetValueAsInteger(dbIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(intval)))
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

                    bool tmpTDB = TDB.TDBFieldSetValueAsInteger(dbIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(tmpval));
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

                    bool tmpTDB = TDB.TDBFieldSetValueAsFloat(dbIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToSingle(tmpval));
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

            TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            FieldProps.Name = new string((char)0, 5);

            for (int index = 0; index < TableProps.FieldCount; index++)
            {
                TDB.TDBFieldGetProperties(dbIndex, SelectedTableName, index, ref FieldProps);

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



        #region TAB CONTROLS
        private void TabControl1_IndexChange(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabDB) TabDB_Start();
            if (tabControl1.SelectedTab == tabTeams || tabControl1.SelectedTab == tabPlayers) EditorTabs();
            if (tabControl1.SelectedTab == tabConf) ConferenceSetup();
            else TabTools_Start();

        }

        public void EditorTabs()
        {

            if (tabControl1.SelectedTab == tabTeams)
            {
                if (TGIDrecNo.Count < 1)
                {
                    Management(dbIndex, "TEAM", "TORD");  //Load Teams by their team order.
                    StartTeamEditor(dbIndex);
                    //LoadTGIDlistBox(dbIndex, "TTYP", 0);  // -1 = to all teams.

                    // If table exixts in current DB.
                    if (TDB.TableIndex(dbIndex, "CONF") != -1)
                    {
                        Management(dbIndex, "CONF", "CGID");
                        GetEditorConfList();
                    }
                }

                LoadTGIDlistBox(dbIndex, "TTYP", 0);  // -1 = to all teams.

            }
            else if (tabControl1.SelectedTab == tabPlayers)
            {
                if (PGIDrecNo.Count < 1)
                {
                    Management(dbIndex, "PLAY", "POVR");  //Load players by their overall.
                    StartPlayerEditor(dbIndex);
                }
            }

        }
        private void OpenTabs()
        {
            if (activeDB == 1) tabControl1.TabPages.Add(tabSeason);
            if (activeDB == 2) tabControl1.TabPages.Add(tabOffSeason);
            if (activeDB > 0) tabControl1.TabPages.Add(tabTools);
        }
        private void TabTools_Start()
        {
            /*
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = false;
            FieldsPropsgroupBox.Visible = false;
            */
        }

        private void TabDB_Start()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = true;
            FieldsPropsgroupBox.Visible = true;
            TableGridView_SelectionChanged(null, null);
        }
        #endregion


        #region MAIN DB TOOLS CLICKS

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void BodyFix_Click(object sender, EventArgs e)
        {
            RecalculateBMI("PLAY");
        }

        //Increases minium speed for skill positions to 80
        private void IncreaseSpeed_Click(object sender, EventArgs e)
        {
            IncreaseMinimumSpeed();
        }

        //Recalculates QB Tendencies based on original game criteria
        private void QB_Tend_Click(object sender, EventArgs e)
        {
            RecalculateQBTendencies();
        }

        //Randomize Player Potential
        private void ButtonRandPotential_Click(object sender, EventArgs e)
        {
            RandomizePotential();
        }

        //Randomize Player Faces/Heads
        private void RandomizeHeadButton_Click(object sender, EventArgs e)
        {
            RandomizeRecruitFace("PLAY");
        }

        //Recalculate Overall Ratings
        private void buttonCalcOverall_Click(object sender, EventArgs e)
        {
            RecalculateOverall();
        }

        //Recalculate Team Overalls
        private void TYDNButton_Click(object sender, EventArgs e)
        {
            if (TEAM) CalculateTeamRatings("TEAM");
            if (TDYN) CalculateTeamRatings("TDYN");
        }

        //Determine Impact Players
        private void buttonImpactPlayers_Click(object sender, EventArgs e)
        {
            DetermineImpactPlayers();
        }

        //Fantasy Roster Generator
        private void buttonFantasyRoster_Click(object sender, EventArgs e)
        {
            if (TDYN)
                FantasyRosterGenerator("TDYN");
            else if (TEAM)
                FantasyRosterGenerator("TEAM");
        }

        //Depth Chart Generator
        private void buttonAutoDepthChart_Click(object sender, EventArgs e)
        {
            if (TDYN)
                DepthChartMaker("TDYN");
            else if (TEAM)
                DepthChartMaker("TEAM");
        }

        //Fill Rosters
        private void buttonFillRosters_Click(object sender, EventArgs e)
        {
            if (TDYN)
                FillRosters("TDYN", Convert.ToInt32(FillRosterPCT.Value));
            else if (TEAM)
                FillRosters("TEAM", Convert.ToInt32(FillRosterPCT.Value));
        }


        #endregion

        #region Dynasty Tools


        //Pre-Season Injury Distributor
        private void ButtonPSInjuries_Click(object sender, EventArgs e)
        {
            PreseasonInjuries();
        }

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void MedRS_Click(object sender, EventArgs e)
        {
            MedicalRedshirt();
        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled
        /* 
        Use current TEAM's TMPR and COCH's CTOP to make CPRE updated, then update CTOP to match previous TMPR
        */
        private void CoachProg_Click(object sender, EventArgs e)
        {
            CoachPrestigeProgression();
        }

        //Randomizes the Coaching Budgets - Must be done prior to 1st Off-Season Task

        private void ButtonRandomBudgets_Click(object sender, EventArgs e)
        {
            RandomizeBudgets();
        }

        //Coaching Carousel -- Must be done at end of Season
        private void ButtonCarousel_Click(object sender, EventArgs e)
        {
            CoachCarousel();
        }

        //Conference Realignment
        private void buttonRealignment_Click(object sender, EventArgs e)
        {
            ConfRealignment();
        }


        //Players to Coaches
        private void buttonPlayerCoach_Click(object sender, EventArgs e)
        {
            PlayerToCoach();
        }


        //Randomly Generate Coach Prestiges for Free Agents
        private void CoachPrestigeButton_Click(object sender, EventArgs e)
        {
            AssignCoachPrestigeFreeAgents();
        }

        #endregion


        #region RECRUITING TOOLS CLICKS


        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void ButtonMinRecruitingPts_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RCYR"); i++)
            {
                if (Convert.ToInt32(GetDBValue("RCYR", "SEWN", i)) >= 1)
                {
                    RaiseMinimumRecruitingPoints();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        //Randomize or Remove Recruiting Interested Teams
        private void ButtonInterestedTeams_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RCYR"); i++)
            {
                if (GetDBValue("RCYR", "SEWN", i) == "1")
                {
                    RemoveInterestedTeams();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        //Randomize the Recruits to give a little bit more variety and evaluation randomness -- Must be done at start of Recruiting
        private void ButtonRandRecruits_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RCYR"); i++)
            {
                if (GetDBValue("RCYR", "SEWN", i) == "1")
                {
                    RandomizeRecruitDB("RCPT");
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }

        }

        //Randomize Walk-On Database -- Must be done prior to Cut Players stage
        private void ButtonRandWalkOns_Click(object sender, EventArgs e)
        {
            RandomizeWalkOnDB();
        }

        //Polynesian Surname Generator
        private void PolyNames_Click(object sender, EventArgs e)
        {
            PolynesianNameGenerator();
        }

        //Randomize Face & Skins
        private void buttonRandomizeFaceSkin_Click(object sender, EventArgs e)
        {
            RandomizeRecruitFace("RCPT");
        }




        #endregion

        //DEV TAB TOOLS

        #region DEV TOOLS

        //Graduate/Transfer Players (DEV ONLY)
        private void GraduateButton_Click(object sender, EventArgs e)
        {
            GraduateAndTransferPlayers();
        }

        private void ImportRecruitsButton_Click(object sender, EventArgs e)
        {
            CreateRecruitsFromCSV();
        }

        private void FireCoachButton_Click(object sender, EventArgs e)
        {
            FireHeadCoach();
        }


        //Create Transfers from CSV File
        private void CreateTransfersCSVButton_Click(object sender, EventArgs e)
        {
            CreateTransfersFromCSV();
        }

        private void DevFillRosterButton_Click(object sender, EventArgs e)
        {
            FillRosters("TDYN", 85);
        }

        private void DevCalcTeamRatingsButton_Click(object sender, EventArgs e)
        {
            CalculateTeamRatings("TDYN");
        }


        private void DevDepthChartButton_Click(object sender, EventArgs e)
        {
            DepthChartMaker("TDYN");
        }


        private void DevRandomizeFaceButton_Click(object sender, EventArgs e)
        {
            RandomizeRecruitFace("PLAY");
        }

        private void DevCalcOVRButton_Click(object sender, EventArgs e)
        {
            RecalculateOverall();
        }

        #endregion





        //EXPERIMENTAL ITEMS -- WORK IN PROGRESS

        private void buttonChaosTransfers_Click(object sender, EventArgs e)
        {
            ChaosTransfers();
        }

        private void buttonScheduleGen_Click(object sender, EventArgs e)
        {
            ScheduleGenerator();
        }

        private void CFUSAexportButton_Click(object sender, EventArgs e)
        {
            ExportToCollegeFootballUSA();
        }


    }

}
