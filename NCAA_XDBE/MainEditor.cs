using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DB_EDITOR

{


    public partial class MainEditor : Form
    {
        #region Global Variables

        Random rand = new Random();

        int minRatingVal = 0;
        int minConvRatingVal = 40;
        int maxRatingVal = 31;
        int maxConvRatingVal = 99;
        int maxPlayers = 70; //player per team

        string dbFile = "";
        string dbFile2 = "";
        public int dbIndex = -1;
        public int dbIndex2 = -1;
        public int dbSelected = 0;

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
        public bool TEAM = false;
        public bool devMode = false;
        double verNumber = 1.0;

        int TeamIndex;
        int PlayerIndex;
        int CoachIndex;
        int DepthChartIndex;
        int RecruitIndex;
        int StadiumIndex;

        Color primary = Color.Black;
        Color secondary = Color.White;
        List<List<string>> AllTeamPlayers;
        List<List<string>> OffPlayers;
        List<List<string>> DefPlayers;
        List<List<string>> DCHTPlayers;
        List<List<string>> TeamColorPalettes = new List<List<string>>();
        List<List<string>> PlayerEditorList;
        List<List<string>> CoachEditorList;
        List<List<string>> RecruitEditorList;
        List<List<List<int>>> SpringRoster;
        List<List<int>> SpringPortal;
        List<List<int>> TeamPortalNeeds;
        List<List<int>> OccupiedPGIDList;
        List<List<int>> AvailablePJEN;


        List<int> PJENList;
        List<List<int>> MasterSchedule;


        int OCAPmem, DCAPmem, TSI1mem, TSI2mem, TPIOmem, TPIDmem;
        int PPOSmem, AWRHmem;

        bool tabDelimited = false;
        bool commaPresent = false;
        bool DUMPER = false;

        List<byte> binData = new List<byte>();     // Holds file header data. (MC02, FBChunks...)
        List<byte> dbData = new List<byte>();      // Holds the db file.
        List<byte> db2Data = new List<byte>();  // Holds any extra data at end of db file. (off-season)
        List<byte> psuExtras = new List<byte>(); // Holds remaining data from PSU saves

        List<string> deflist = new List<string>();

        Dictionary<string, Dictionary<string, string>> TableDefinitions = new Dictionary<string, Dictionary<string, string>>();

        Dictionary<int, string> TableNames = new Dictionary<int, string>();
        Dictionary<int, string> FieldNames = new Dictionary<int, string>();

        Dictionary<int, string> Alphabet = new Dictionary<int, string>();
        Dictionary<string, int> AlphabetX = new Dictionary<string, int>();


        public string[] teamNameDB = new string[512]; //temporary holder of Team Names assigned by TGID location in the array
        string[] teamMascot = new string[512]; //temporary holder of Team Names assigned by TGID location in the array
        int maxNameChar = 10; //maximum number of name characters (reserving extra last name letters for modding)
        Dictionary<int, string> Positions = new Dictionary<int, string>(); //database of ppos id,position name
        Dictionary<string, int> PositionsX = new Dictionary<string, int>(); //database of position name, ppos id
        Dictionary<int, int> Ratings = new Dictionary<int, int>(); //database of db rating, in-game rating
        Dictionary<int, int> RatingsX = new Dictionary<int, int>(); //database of in-game rating, db rating

        double[,] POCI;
        List<List<int>> RCAT;
        List<string> FirstNames;
        List<string> LastNames;


        // Add this near the top of the MainEditor class, after existing DllImport
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        #endregion



        public MainEditor()
        {
            // Enable DPI awareness - should be one of the first things we do
            SetProcessDPIAware();

            // Enable better DPI scaling
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Handle DPI changes dynamically
            this.HandleCreated += (s, e) =>
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetProcessDPIAware();
                }
            };

            InitializeComponent();
            DefaultSettings();
        }


        private void DefaultSettings()
        {
            this.Text = "NCAA Next Database Editor";
            this.Controls.Clear();
            this.InitializeComponent();

            dbFile = "";
            TablePropsLabel.Text = "";
            FieldsPropsLabel.Text = "";
            dbIndex = -1;
            dbIndex2 = -1;
            dbSelected = 0;
            SelectedTableIndex = -1;

            minRatingVal = 0;
            minConvRatingVal = 40;
            maxRatingVal = 31;
            maxConvRatingVal = 99;
            maxPlayers = 70; //player per team

            saveMenuItem.Enabled = false;
            closeMenuItem.Enabled = false;
            openMenuItem.Visible = true;
            openMenuItem.Enabled = true;
            saveMenuItem.Visible = true;
            closeMenuItem.Visible = true;
            definitionFileMenuItem.Visible = true;
            toolStripSeparator7.Visible = true;

            optionsMenuItem.Enabled = true;
            CSVMenu.Enabled = true;
            CSVMenu.Visible = false;
            optionsMenuItem.Visible = false;


            TablePropsgroupBox.Visible = false;
            FieldsPropsgroupBox.Visible = false;
            progressBar1.Visible = false;

            DBModified = false;
            exportAll = false;
            BigEndian = false;
            addendum = false;
            importRec = false;


            coachProgComplete = false;
            TDYN = false;
            TEAM = false;
            TeamIndex = -1;

            tabControl1.Visible = false;

            tabControl1.TabPages.Remove(tabTeams);
            tabControl1.TabPages.Remove(tabPlayers);
            tabControl1.TabPages.Remove(tabDynasty);
            tabControl1.TabPages.Remove(tabOffSeason);
            tabControl1.TabPages.Remove(tabTools);
            tabControl1.TabPages.Remove(tabCoaches);
            tabControl1.TabPages.Remove(tabConf);
            tabControl1.TabPages.Remove(tabDev);
            tabControl1.TabPages.Remove(tabPlaybook);
            tabControl1.TabPages.Remove(tabDepthCharts);
            tabControl1.TabPages.Remove(tabRecruits);
            tabControl1.TabPages.Remove(tabUniforms);
            tabControl1.TabPages.Remove(tabBowls);
            tabControl1.TabPages.Remove(tabLeagueStats);
            tabControl1.TabPages.Remove(tabSchedule);
            tabControl1.TabPages.Remove(tabStadiums);
            tabControl1.TabPages.Remove(tabPortal);
            tabControl1.TabPages.Remove(tabSTRMDATA);
            tabControl1.TabPages.Remove(tabCarousel);
            tabControl1.TabPages.Remove(tabPlayoff);
            tabControl1.TabPages.Remove(tabTeamStats);
            tabControl1.TabPages.Remove(tabRecruiting);
            tabControl1.TabPages.Remove(tabHeadlines);

            tabDelimited = false;
            commaPresent = false;

            //ColorDialog
            colorDialog1.AnyColor = true;
            colorDialog1.AllowFullOpen = true;
            colorDialog1.SolidColorOnly = false;

            LeagueMakerToolStripMenuItem.Visible = false;

            DB2Button.Enabled = false;
            DB1Button.Checked = true;

            PortalData.ClearSelection();
            PortalData.Rows.Clear();

            devMode = false;

            DoNotTrigger = false;
        }

        #region OPEN, SAVE & CLOSE

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabHome);

            dbFile = GetFileName("", "All Files|*.*|");

            if (dbFile.Contains(".psu") || dbFile.Contains(".max"))
            {
                MessageBox.Show("PSU and MAX Saves from off-season are not supported.\n\nUse at your own risk.\n\nIt is recommended to use save files from Memory Card Folders, or to use PS2 Save Builder to extract the save file from the PSU or MAX Container.");
            }

            if (dbFile != "")
            {
                CheckDB(dbFile);

                OpenDB();

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
                closeMenuItem.Enabled = true;

                TablePropsgroupBox.Visible = true;
                FieldsPropsgroupBox.Visible = true;
                tabControl1.Visible = true;

                #endregion

                CreateExtraFileDataContainers();


                //NCAA Football Editor Tabs Check

                if (TDB.TableIndex(dbIndex, "SETL") >= 0) AddPlaybooksTab(); //checks Playbooks first because of SGF table (3 char) causes TDB problems (expecting 4 char)
                else if (TDB.TableIndex(dbIndex, "AIGR") >= 0 || TDB.FieldIndex(dbIndex, "TEAM", "TMNA") != -1 || TDB.FieldIndex(dbIndex, "PLAY", "PF10") != -1) DBTableAddOns();

                StartHomeTab();
                ModVersionChecker();
            }
        }

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
            int activeDB = 0;
            int i = 0;

            while (i < array.Length - 3)
            {
                if (Convert.ToChar(array[i]) + "" + Convert.ToChar(array[i + 1]) + "" + Convert.ToDecimal(array[i + 2]) + "" + Convert.ToDecimal(array[i + 3]) == "DB08")
                {
                    // Check if DB is BigEndian.
                    if (Convert.ToUInt32(array[i + 4]) == 1)
                        BigEndian = true;

                    byte[] dbLengthArray = new byte[4];
                    int c = 0;
                    for (int b = i + 8; b < i + 12; b++)
                    {
                        dbLengthArray[c] = array[b];
                        c++;
                    }

                    //Array.Reverse(dbLengthArray);
                    int dbLength = BitConverter.ToInt32(dbLengthArray, 0);


                    // Save DB information.

                    for (int j = i; j < array.Length; j++)
                    {
                        dbData.Add(array[j]);
                        activeDB = 1; //sets db to 1 to signify it found the 1st DB (i.e. the normal db)
                    }
                    // end Save DB information.

                    int k = i + dbLength;
                    if (k + 5 < array.Length && k > 0)
                    {
                        if (array[k] == 68 && array[k + 1] == 66 && array[k + 2] == 0 && array[k + 3] == 8 && array[k + 4] == 0 && array[k + 5] == 0 && activeDB == 1)
                        {
                            for (int x = k; x < array.Length; x++)
                            {
                                db2Data.Add(array[x]);
                            }
                            activeDB = 2;
                            break;
                        }
                    }

                    break;
                }

                binData.Add(array[i]);
                i++;
            }

            BinaryWriter dbWriter;

            // Save DB information.
            dbWriter = new BinaryWriter(File.Create(filename + ".db"));

            for (int j = 0; j < dbData.Count; j++)
            {
                dbWriter.Write(dbData[j]);
            }
            dbWriter.Dispose();
            dbWriter.Close();
            dbFile = filename + ".db";


            // Save DB2 information.
            if (db2Data.Count > 0)
            {
                dbWriter = new BinaryWriter(File.Create(filename + ".db2"));

                for (int j = 0; j < db2Data.Count; j++)
                {
                    dbWriter.Write(db2Data[j]);
                }
                dbWriter.Dispose();
                dbWriter.Close();
                dbFile2 = filename + ".db2";
            }

            // end Save DB information.
        }

        //Extra Console Data for PSU, MAX containers
        private void CreateExtraFileDataContainers()
        {
            //Determine and Write PSU File
            psuExtras.Clear();

            List<byte> psuTmp = dbData;
            Array array;
            int x, y;

            if (db2Data.Count > 0 && dbIndex2 == 1)
            {
                SaveDB(dbIndex2);
                array = File.ReadAllBytes(dbFile2); //db2
                x = 0;
                y = array.Length;
                psuTmp = db2Data;
            }
            else if (db2Data.Count > 0 && dbIndex2 == -1)
            {
                foreach (byte b in db2Data)
                    psuTmp.Add(b);

                SaveDB(dbIndex);
                array = File.ReadAllBytes(dbFile); //db1
                x = 0;
                y = 0;
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
                psuTmp = dbData;
            }

            for (int i = x + y; i < psuTmp.Count; i++)
                psuExtras.Add(psuTmp[i]);

        }

        public void OpenDB()
        {
            if (dbIndex == -1)
            {
                dbIndex = TDB.TDBOpen(dbFile);
            }

            if (dbIndex2 == -1 && db2Data.Count > 0)
            {
                dbIndex2 = TDB.TDBOpen(dbFile2);
                DB2Button.Enabled = true;
            }

        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDB(dbSelected))
            {
                SaveDB(0);
                if (dbIndex2 == 1) SaveDB(1);

                #region Compile Console Data and DB information.
                byte[] db1, db2;

                BinaryWriter binwriter = new BinaryWriter(File.Open(openFileDialog1.FileName, FileMode.Create));

                // Add pre-DB data 
                if (binData.Count > 0)
                    for (int i = 0; i < binData.Count; i++)
                    {
                        binwriter.Write(binData[i]);
                    }

                // Add DB data.
                db1 = File.ReadAllBytes(dbFile);

                if (db1.Length > 0)
                    for (int i = 0; i < db1.Length; i++)
                    {
                        binwriter.Write(db1[i]);
                    }

                // add DB2 data.
                if (dbIndex2 == 1)
                {
                    db2 = File.ReadAllBytes(dbFile2);
                    for (int i = 0; i < db2.Length; i++)
                    {
                        binwriter.Write(db2[i]);
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


        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            DoNotTrigger = true;
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
                if (dbIndex2 == 1) CloseDB(dbIndex2);
                DefaultSettings();
            }

            DoNotTrigger = false;
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

        private void CloseMainEditor_Click()
        {
            closeMenuItem.PerformClick();
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


        #endregion

        #region CSV Events
        //mainMenuStrip
        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            ExportDB();
        }
        private void importMenuItem_Click(object sender, EventArgs e)
        {
            ImportDB();
        }

        private void exportAllMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will export every table in this database and may take some time depending on the size of the database. Do you want to proceed?", "Export All Tables", MessageBoxButtons.YesNo);

            if (DialogResult == System.Windows.Forms.DialogResult.No) return;


            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            TableProps.Name = new string((char)0, 5);

            exportAll = true;
            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbSelected); i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = new string((char)0, 5);

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(dbSelected, i, ref TableProps))
                {
                    SelectedTableName = TableProps.Name;
                    SelectedTableIndex = i;
                    exportToolItem.PerformClick();
                }
            }
            exportAll = false;
            MessageBox.Show("Export Complete", "Export All Tables");
        }

        private void importAllMenuItem_Click(object sender, EventArgs e)
        {

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, SelectedTableName + ".csv");
            if (tabDelimited) csvLocation = Path.Combine(executableLocation, SelectedTableName + ".txt");


            if (File.Exists(csvLocation))
            {


                // TdbTableProperties class
                TdbTableProperties TableProps = new TdbTableProperties();

                // 4 character string, max value of 5
                TableProps.Name = new string((char)0, 5);

                exportAll = true;
                for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbSelected); i++)
                {
                    // Init the tdbtableproperties name
                    TableProps.Name = new string((char)0, 5);

                    // Get the tableproperties for the given table number
                    if (TDB.TDBTableGetProperties(dbSelected, i, ref TableProps))
                    {
                        SelectedTableName = TableProps.Name;
                        SelectedTableIndex = i;

                        if (TableProps.Name != "TEAM")
                            importTableMenuItem.PerformClick();
                    }
                }
                exportAll = false;
                MessageBox.Show("Import Complete", "Import All Tables");
            }
            else
            {
                MessageBox.Show("No importable files found in the DB Editor directory");
                return;
            }
        }

        private void ExportSelectedMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This will export every selected table. Do you want to proceed?", "Export Selected Tables", MessageBoxButtons.YesNo);

            if (DialogResult == System.Windows.Forms.DialogResult.No) return;

            List<int> tablesSelected = new List<int>();
            for(int i = 0; i < tableGridView.Rows.Count; i++)
            {
                if (tableGridView.Rows[i].Selected)
                    tablesSelected.Add(i);
            }

           // TdbTableProperties class
           TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            TableProps.Name = new string((char)0, 5);

            exportAll = true;
            for (int i = 0; i < tablesSelected.Count; i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = new string((char)0, 5);

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(dbSelected, tablesSelected[i], ref TableProps))
                {
                    SelectedTableName = TableProps.Name;
                    SelectedTableIndex = tablesSelected[i];
                    exportToolItem.PerformClick();
                }
            }
            exportAll = false;
            MessageBox.Show("Export Complete", "Export Selected Tables");

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

        private void importAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importAllMenuItem.PerformClick();
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
            TDB.TDBDatabaseCompact(dbSelected);
            importMenuItem.PerformClick();
            importRec = false;
            addendum = false;
        }
        private void addendumMenuItem_Click(object sender, EventArgs e)
        {
            addendum = true;
            ImportDB();
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
                    TDB.TDBTableRecordAdd(dbSelected, SelectedTableName, true);

                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(dbSelected, SelectedTableIndex, ref TableProps);


                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    for (int fCount = 0; fCount != TableProps.FieldCount; fCount++)
                    {
                        TDB.TDBFieldGetProperties(dbSelected, SelectedTableName, fCount, ref FieldProps);

                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            TDB.TDBFieldSetValueAsString(dbSelected, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToString(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbSelected, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(dbSelected, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToUInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            TDB.TDBFieldSetValueAsFloat(dbSelected, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToSingle(row.Cells[fCount + 1].Value));
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
                    TDB.TDBTableRecordAdd(dbSelected, SelectedTableName, true);
                else
                {
                    for (int r = 0; r < rowcount; r++)
                    {
                        // Shouldnt use expand flag as it causes problems in certain tables when it doesnt expect more than
                        // a certain amount of records.  Player table I know has this issue...
                        TDB.TDBTableRecordAdd(dbSelected, SelectedTableName, true);
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
                    if (TDB.TDBTableRecordChangeDeleted(dbSelected, SelectedTableName, Convert.ToInt32(row.Cells[0].Value), true))
                    {
                        fieldsGridView.Rows.RemoveAt(row.Index);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                TDB.TDBDatabaseCompact(dbSelected);
                GetTableProperties();
                LoadFields();
            }
        }

        #endregion

        #region Options

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

            SortTables();
            LoadTables();

            SortFields();
            LoadFields();
        }
        private void descendingMenuItem_Click(object sender, EventArgs e)
        {
            descendingFieldOrderMenuItem.Checked = true;
            ascendingFieldOrderMenuItem.Checked = false;
            defaultFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            SortTables();
            LoadTables();

            SortFields();
            LoadFields();
        }
        private void customMenuItem_Click(object sender, EventArgs e)
        {
            UseCustomTable();
        }
        private string FieldDEF(string fieldname)
        {
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
        private void UseCustomTable()
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

        private void ScheduleGenMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please load the Schedule Template file (File 3 from TEMPLATE.DAT).");
            LeagueMain scheduleGen = new LeagueMain(verNumber);
            scheduleGen.ShowDialog();
        }


        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }


        #endregion

        #region Configuration Selection

        //Database Chooser
        private void DB2Button_CheckedChanged(object sender, EventArgs e)
        {
            dbSelected = 1;
            GetTables(dbSelected);
            LoadTables();

            GetFields(dbSelected, SelectedTableIndex);
            LoadFields();
            TDB.TDBSave(dbIndex);
        }

        private void DB1Button_CheckedChanged(object sender, EventArgs e)
        {
            dbSelected = 0;
            GetTables(dbSelected);
            LoadTables();

            GetFields(dbSelected, SelectedTableIndex);
            LoadFields();
            TDB.TDBSave(dbIndex2);
        }

        //MOD VERSION CHECK

        private void ModVersionChecker()
        {

            if (TDB.TableCapacity(dbIndex, "PLAY") > 8400)
            {
                radioNEXT26.Checked = true;
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (GetDBValueInt("PLAY", "PLHN", i) > 2)
                    {
                        radioNext26v162.Checked = true;
                        break;
                    }
                }
            }
            else if (TDB.TableCapacity(dbIndex, "RCAT") > 0)
            {
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (GetDBValueInt("PLAY", "PLHN", i) > 2)
                    {
                        radioNext26v162.Checked = true;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("BOWL"); i++)
                {
                    if (GetDBValue("BOWL", "BNAM", i).Contains("CFP"))
                    {
                        NextConfigRadio.Checked = true;
                        break;
                    }
                }
            }
        }

        private void OGConfigRadio_CheckedChanged(object sender, EventArgs e)
        {
            verNumber = 1.0;
            CreatePOCItable();
            CreateRatingsDB();
        }

        private void NextConfigRadio_CheckedChanged(object sender, EventArgs e)
        {
            verNumber = 15.0;
            CreatePOCItable();
            CreateRatingsDB();

        }

        private void radioNEXT26_CheckedChanged(object sender, EventArgs e)
        {
            verNumber = 16.0;
            CreatePOCItable();
            CreateRatingsDB();
            maxPlayers = 66;

        }

        private void radioNext26v162_CheckedChanged(object sender, EventArgs e)
        {
            verNumber = 16.2;
            CreatePOCItable();
            CreateRatingsDB();
            maxPlayers = 66;
        }



        #endregion


        #region TAB CONTROLS
        private void TabControl1_IndexChange(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab != tabDB)
            {
                CSVMenu.Visible = false;
                optionsMenuItem.Visible = false;
                TablePropsgroupBox.Visible = false;
                FieldsPropsgroupBox.Visible = false;
                DBChooserGroupBox.Visible = false;
            }
            else
            {
                CSVMenu.Visible = true;
                optionsMenuItem.Visible = true;
                TablePropsgroupBox.Visible = true;
                FieldsPropsgroupBox.Visible = true;
                DBChooserGroupBox.Visible = true;
            }

            if (tabControl1.SelectedTab == tabDB) TabDB_Start();
            else if (tabControl1.SelectedTab == tabDynasty) StartDynastyEditor();
            else if (tabControl1.SelectedTab == tabTeams) StartTeamEditor();
            else if (tabControl1.SelectedTab == tabPlayers) StartPlayerEditor();
            else if (tabControl1.SelectedTab == tabConf) ConferenceSetup();
            else if (tabControl1.SelectedTab == tabCoaches) StartCoachEditor();
            else if (tabControl1.SelectedTab == tabTools) StartDBTools();
            else if (tabControl1.SelectedTab == tabPlaybook) StartPlaybookEditor();
            else if (tabControl1.SelectedTab == tabDepthCharts) StartDepthChartEditor();
            else if (tabControl1.SelectedTab == tabHome) StartHomeTab();
            else if (tabControl1.SelectedTab == tabUniforms) StartUniformEditor();
            else if (tabControl1.SelectedTab == tabBowls) StartBowlEditor();
            else if (tabControl1.SelectedTab == tabRecruits) StartRecruitEditor();
            else if (tabControl1.SelectedTab == tabSchedule) StartScheduleEditor();
            else if (tabControl1.SelectedTab == tabLeagueStats) StartStatsViewer();
            else if (tabControl1.SelectedTab == tabStadiums) StartStadiumEditor();
            else if (tabControl1.SelectedTab == tabPortal) StartSpringPortal();
            else if (tabControl1.SelectedTab == tabSTRMDATA) { /* do nothing */ }
            else if (tabControl1.SelectedTab == tabPlayoff) { StartPlayoffViewer(); }
            else if (tabControl1.SelectedTab == tabTeamStats) { StartTeamStatsViewer(); }
            else if (tabControl1.SelectedTab == tabRecruiting) { StartRecruitRankingsView(); }
            else if (tabControl1.SelectedTab == tabOffSeason) { StartOffSeasonEditor(); }
            else if (tabControl1.SelectedTab == tabHeadlines) { StartHeadlinesViewer(); }

        }



        private void StartHomeTab()
        {
        }
        #endregion

        #region Global Progress Bar
        private void StartProgressBar(int steps)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = steps;
            progressBar1.ForeColor = Color.Red;
        }

        private void ProgressBarStep()
        {
            progressBar1.PerformStep();
        }

        private void EndProgressBar()
        {
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        #endregion


        private void devTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.Contains(tabDev))
            {
                tabControl1.TabPages.Remove(tabDev);
            }
            else
            {
                tabControl1.TabPages.Add(tabDev);
            }
        }

        private void EnableDevGearsMod_Click(object sender, EventArgs e)
        {
            devMode = true;
            MessageBox.Show("Dev Mode Enabled");
        }


    }

}
