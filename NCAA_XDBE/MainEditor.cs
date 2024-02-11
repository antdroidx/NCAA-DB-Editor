using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DB_EDITOR

{


    public partial class MainEditor : Form
    {
        Random rand = new Random();

        string currentDBfile = "";
        int currentDBfileIndex = -1;  // 0 = Open/Save, 1 = Save As..., 2 = settings.db, 3 = streameddata.db, 4 = 00012-DB_TEMPLATES.db

        string SelectedTableName = "";
        int SelectedTableIndex = 0;

        public bool DBModified = false;
        public bool exportAll = false;
        public bool BigEndian = false;
        public bool addendum = false;
        public bool importRec = false;
        public bool DoNotTrigger = false; //team/player editor

        public bool tabDelimited = false;


        public List<byte> binData = new List<byte>();     // Holds file header data. (MC02, FBChunks...)
        public List<byte> dbData = new List<byte>();      // Holds the db file.
        public List<byte> db2Data = new List<byte>();  // Holds any extra data at end of db file. (off-season)
        public List<byte> psuExtras = new List<byte>(); // Holds remaining data from PSU saves

        public bool offSeasonSave = false; //True if off-season save DB is present
        public int activeDB = 1; //1 - season, 2 - off-season

        public List<string> deflist = new List<string>();

        public Dictionary<string, Dictionary<string, string>> TableDefinitions = new Dictionary<string, Dictionary<string, string>>();

        public Dictionary<int, string> TABLEnames = new Dictionary<int, string>();
        public Dictionary<int, string> FIELDnames = new Dictionary<int, string>();

        // current table's Fields Index  string = FieldName, int = FieldIndex
        public Dictionary<string, int> ctFieldsID = new Dictionary<string, int>();

        // 
        public Dictionary<int, int> tmpManagement = new Dictionary<int, int>();

        public Dictionary<int, int> TGIDrecNo = new Dictionary<int, int>();  //  RecNo/TGID
        public Dictionary<int, int> TGIDlist = new Dictionary<int, int>();   //  SelectedIndex/Recno

        public Dictionary<int, int> PGIDrecNo = new Dictionary<int, int>();  //  RecNo/PGID
        public Dictionary<int, int> PGIDlist = new Dictionary<int, int>();   //  SelectedIndex/RecNo
        public Dictionary<int, int> ROSrecNo = new Dictionary<int, int>();   //  RecNo/PGID

        public Dictionary<int, int> CONFrecNo = new Dictionary<int, int>();  //  RecNo/CONF
        public Dictionary<int, int> CONFlist = new Dictionary<int, int>();   //  SelectedIndex/Recno

        public Dictionary<int, string> Alphabet = new Dictionary<int, string>();
        public Dictionary<string, int> AlphabetX = new Dictionary<string, int>();

        public int maxTeamsDB = 511; //max team number for team db

        public int fCount_addon = 5; //number of extra columns (fields) to add to PLAY table
        public int fCount_First = 4; //5-4 = 1 = 1st new column
        public int fCount_Last = 3;
        public int fCount_Team = 2;
        public int fCount_Pos = 1;


        public string[] teamNameDB = new string[511]; //temporary holder of Team Names assigned by TGID location in the array
        public int maxNameChar = 10; //maximum number of name characters (reserving extra last name letters for modding)
        public Dictionary<int, string> Positions = new Dictionary<int, string>(); //database of ppos id,position name
        public Dictionary<string, int> PositionsX = new Dictionary<string, int>(); //database of position name, ppos id
        public Dictionary<int, int> Ratings = new Dictionary<int, int>(); //database of db rating, in-game rating
        public Dictionary<int, int> RatingsX = new Dictionary<int, int>(); //database of in-game rating, db rating


        public MainEditor()
        {
            InitializeComponent();
            defaultSettings();

        }

        private void defaultSettings()
        {
            this.Text = "NCAA Next DB Editor";
            currentDBfile = "";
            TablePropsLabel.Text = "";
            FieldsPropsLabel.Text = "";
            currentDBfileIndex = -1;

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


            tabControl1.Visible = false;
            tabControl1.TabPages.Remove(tabTeams);
            tabControl1.TabPages.Remove(tabPlayers);
            tabControl1.TabPages.Remove(tabTools);
            tabControl1.TabPages.Remove(tabOffSeason);

            tabDelimited = false;

            //selectDBTabPage();

            TGIDrecNo.Clear();
            PGIDrecNo.Clear();

        }

        /*
         * MENU STRIP ACTIONS
        */

        #region MAIN MENU ITEMS
        // menuStrip1 -- where the save file loading begins
        private void openMenuItem_Click(object sender, EventArgs e)
        {
            //currentDBfile = GetFileName("", "All Files|*.*|Madden|*.ros; *.fra; *.dbt; *.db; *.pbd; *.pbo; *.rpl; *.spg; *.usr|Roster|*.ros|Franchise|*.fra|Teams|*.dbt|Database|*.db|Playbook|*.pbd; *.pbo|Replay|*.rpl|Spawn|*.spg|Users|*.usr|Console|*.mc02");
            currentDBfile = GetFileName("", "All Files|*.*|");

            if (currentDBfile.Contains(".psu") || currentDBfile.Contains(".max"))
            {
                MessageBox.Show("PSU and MAX Saves from off-season are not supported.\n\nUse at your own risk.\n\nIt is recommended to use save files from Memory Card Folders, or to use PS2 Save Builder to extract the save file from the PSU or MAX Container.");
            }

            if (currentDBfile != "")
            {
                CheckDB(currentDBfile);

                OpenDB(currentDBfile);

                if (currentDBfileIndex == -1)
                {
                    MessageBox.Show("Error Opening File.", "DB File Error");
                    return;
                }

                if (currentDBfile != "")
                    this.Text = "NCAA Next DB Editor  [ " + Path.GetFileName(currentDBfile) + " ]";
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
                openTabs();

                #endregion

                getTABLES(currentDBfileIndex);
                LoadTables();

                getFIELDS(currentDBfileIndex, SelectedTableIndex);
                LoadFields();

                createConsoleData();
            }
        }

        private void enableOffSeasonDBMenuItem_Click(object sender, EventArgs e)
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
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveDB(currentDBfileIndex))
            {

                #region Compile Console Data and DB information.

                byte[] dbarray = File.ReadAllBytes(currentDBfile);

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
        private void saveAsMenuItem_Click(object sender, EventArgs e)
        {
            openMenuItem.Enabled = false;
            saveMenuItem.Enabled = false;
            saveAsMenuItem.Enabled = false;
            closeMenuItem.Enabled = true;

        }
        private void closeMenuItem_Click(object sender, EventArgs e)
        {
            if (DBModified)
            {
                DialogResult result;

                result = MessageBox.Show("              Save changes to " + Path.GetFileName(currentDBfile) + "?", "Save ", MessageBoxButtons.YesNoCancel);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    saveMenuItem.PerformClick();
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                    return;

            }

            DeleteDBFiles();


            if (CloseDB(currentDBfileIndex))
            {
                defaultSettings();
            }


        }
        private void definitionFileMenuItem_Click(object sender, EventArgs e)
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

            sortTABLES();
            LoadTables();

            sortFIELDS();
            LoadFields();

        }
        private void exitToolItem_Click(object sender, EventArgs e)
        {
            if (DBModified)
            {
                DialogResult result;

                result = MessageBox.Show("              Save changes to " + Path.GetFileName(currentDBfile) + "?", "Save ", MessageBoxButtons.YesNoCancel);

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

        private void closeMainEditor_Click()
        {
            closeMenuItem.PerformClick();
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutBox = new AboutBox1();
            AboutBox.ShowDialog();
        }

        #endregion

        #region CSV Events
        //mainMenuStrip
        private void exportMenuItem_Click(object sender, EventArgs e)
        {
            string tmpReverse = "";
            string tmpcurrentDBfile = Path.GetFileNameWithoutExtension(currentDBfile);


            Stream myStream = null;
            SaveFileDialog SaveDialog1 = new SaveFileDialog();

            if (tabDelimited)
                SaveDialog1.Filter = "TXT Files (*.txt)|*.txt|All files (*.*)|*.*";
            else SaveDialog1.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

            if (BigEndian)
                SaveDialog1.FileName = tmpcurrentDBfile + " - " + StrReverse(SelectedTableName);
            else SaveDialog1.FileName = tmpcurrentDBfile + " - " + SelectedTableName;

            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                // use a try-catch here
#pragma warning disable CS0168 // Variable is declared but never used
                try
                {

                    // Open the file using Stream, if it succeeds do stuff with it
                    if ((myStream = SaveDialog1.OpenFile()) != null)
                    {
                        StreamWriter wText = new StreamWriter(myStream);    // create writer using the stream that opened the savefile earlier

                        StringBuilder hbuilder = new StringBuilder();       // hbuilder is for the header, which are the fieldnames
                        // builder.Append(Whatever string you want here, probably the field names in the table
                        // builder.Append(",");  separate each name with a comma

                        TdbTableProperties TableProps = new TdbTableProperties();
                        TableProps.Name = new string((char)0, 5);

                        TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);

                        #region Write CSV Header (field names).
                        for (int i = 0; i < TableProps.FieldCount; i++)
                        {
                            TdbFieldProperties FieldProps = new TdbFieldProperties();
                            FieldProps.Name = new string((char)0, 5);



                            TDB.TDBFieldGetProperties(currentDBfileIndex, SelectedTableName, i, ref FieldProps);
                            tmpReverse = FieldProps.Name;

                            // Reverse field name if BigEndian file.
                            if (BigEndian)
                                tmpReverse = StrReverse(tmpReverse);

                            hbuilder.Append(tmpReverse);

                            // Excempt comma if there are no more field names to add.
                            if (i != TableProps.FieldCount - 1)
                            {
                                if (tabDelimited)
                                    hbuilder.Append("\t");
                                else hbuilder.Append(",");

                            }

                        }
                        if (TableProps.Name == "PLAY")
                        {
                            hbuilder.Append(",");
                            hbuilder.Append("FirstName");
                            hbuilder.Append(",");
                            hbuilder.Append("LastName");
                            hbuilder.Append(",");
                            hbuilder.Append("College");
                            hbuilder.Append(",");
                            hbuilder.Append("Position");
                        }

                        wText.WriteLine(hbuilder.ToString());   // Convert the string builder to an actual string and write to the stream/file
                        #endregion

                        // Progress bar for large table records to write.
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TableProps.RecordCount;
                        progressBar1.Step = 1;

                        #region Write CSV cells (field values).

                        for (int r = 0; r < TableProps.RecordCount; r++)
                        {
                            hbuilder.Clear();
                            int tmpTGID = -1;
                            int tmpPos = -1;
                            for (int f = 0; f < TableProps.FieldCount; f++)
                            {
                                TdbFieldProperties FieldProps = new TdbFieldProperties();
                                FieldProps.Name = new string((char)0, 5);

                                TDB.TDBFieldGetProperties(currentDBfileIndex, TableProps.Name, f, ref FieldProps);

                                if (FieldProps.FieldType == TdbFieldType.tdbString)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);

                                    TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, r, ref val);

                                    if (!tabDelimited)
                                        val = val.Replace(",", "");

                                    hbuilder.Append(val.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                                {
                                    UInt32 intval;
                                    intval = (UInt32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(intval.ToString());

                                    if (FieldProps.Name == "PGID")
                                    {
                                        tmpTGID = (int)intval / 70;
                                    }
                                    if (FieldProps.Name == "PPOS") tmpPos = (int)intval;

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                                {
                                    Int32 signedval;
                                    signedval = TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(signedval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                                {
                                    float floatval;
                                    floatval = TDB.TDBFieldGetValueAsFloat(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);
                                    hbuilder.Append(floatval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);
                                    TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, r, ref val);

                                    // hbuilder.Append(val.ToString());
                                    hbuilder.Append("usft");

                                }
                                else hbuilder.Append("[na]");

                                // Excempt comma if there are no more field names to add.
                                if (f != TableProps.FieldCount - 1)
                                    if (tabDelimited)
                                        hbuilder.Append("\t");
                                    else hbuilder.Append(",");
                            }
                            if (TableProps.Name == "PLAY")
                            {
                                hbuilder.Append(",");
                                hbuilder.Append(convertFN_IntToString(r)); //write first name string to csv
                                hbuilder.Append(",");
                                hbuilder.Append(convertLN_IntToString(r)); //write last name string to csv
                                hbuilder.Append(",");
                                if (TDB.TableIndex(currentDBfileIndex, "TEAM") == 1)
                                {
                                    hbuilder.Append(getTeamName((int)tmpTGID)); //convert and write team name to csv
                                    hbuilder.Append(",");
                                }
                                hbuilder.Append(getPlayerPosition((int)tmpPos)); //convert and write position name to csv
                            }

                            progressBar1.PerformStep();
                            wText.WriteLine(hbuilder.ToString());   // Convert the strin builder to an actual string and write to the stream/file
                        }
                        #endregion

                        progressBar1.Value = 0;
                        wText.Flush();
                        wText.Close();

                        if (!exportAll)
                            MessageBox.Show(Path.GetFileNameWithoutExtension(SaveDialog1.FileName) + Path.GetExtension(SaveDialog1.FileName).ToLower() + " saved.", "Export");

                    }
                }
                catch (IOException err)
                {
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#pragma warning restore CS0168 // Variable is declared but never used

                myStream.Dispose();
                myStream.Close();  // I get an error when saving the file when it is opened in excel.
            }
        }

        private void importMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> AvailableFields = new Dictionary<string, int>();
            Dictionary<string, int> TableFields = new Dictionary<string, int>();

            if (SelectedTableName == "TEAM" && TDB.TDBDatabaseGetTableCount(currentDBfileIndex) > 50)
            {
                MessageBox.Show("DO NOT USE IMPORT CSV FUNCTION FOR TEAM TABLE.\n\nPlease use Addendum instead and DO NOT IMPORT TPIP and JJNM COLUMNS!");
                return;
            }

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            Stream myStream = null;

            if (tabDelimited)
                openFileDialog2.Filter = "TXT Files (*.txt)|*.txt|All files (*.*)|*.*";
            else openFileDialog2.Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*";

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog2.OpenFile()) != null)
                {
                    #region Setup  Existing table field names
                    //
                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = TableProps.FieldCount;
                    progressBar1.Step = 1;

                    TableFields.Clear();

                    for (int i = 0; i < TableProps.FieldCount; i++)
                    {
                        TdbFieldProperties FieldProps = new TdbFieldProperties();
                        FieldProps.Name = new string((char)0, 5);

                        TDB.TDBFieldGetProperties(currentDBfileIndex, TableProps.Name, i, ref FieldProps);

                        TableFields.Add(FieldProps.Name, (int)FieldProps.FieldType);

                        progressBar1.PerformStep();
                    }
                    progressBar1.Value = 0;
                    #endregion

                    #region Delete All Records
                    if (!addendum)
                    {
                        if (TableProps.RecordCount != 0)
                        {
                            progressBar1.Minimum = 0;
                            progressBar1.Maximum = TableProps.RecordCount;
                            progressBar1.Step = 1;

                            for (int r = TableProps.RecordCount; r != -1; r--)
                            {
                                TDB.TDBTableRecordRemove(currentDBfileIndex, SelectedTableName, r);

                                progressBar1.PerformStep();
                            }
                            progressBar1.Value = 0;
                        }
                    }

                    // TableProps.RecordCount = 0;
                    DBModified = true;
                    #endregion

                    #region setup import table field names

                    // new streamreader based on mystream which is an open file
                    StreamReader sr = new StreamReader(myStream);
                    string headerline = sr.ReadLine();

                    // string[] csvfieldnames = headerline.Split(',');
                    string[] csvfieldnames;

                    if (tabDelimited)
                        csvfieldnames = headerline.Split('\t');
                    else csvfieldnames = headerline.Split(',');


                    AvailableFields.Clear();

                    for (int c = 0; c < csvfieldnames.Length; c++)
                    {
                        if (BigEndian)
                            csvfieldnames[c] = StrReverse(csvfieldnames[c]);

                        // if the current table fieldnames has this field, then add to our import list
                        if (TableFields.ContainsKey(csvfieldnames[c]))
                        {
                            // if available fields does not contain the fieldname from csv read
                            if (!AvailableFields.ContainsKey(csvfieldnames[c]))
                                AvailableFields.Add(csvfieldnames[c], c);
                        }
                    }


                    // Done with reading in the csv file
                    //sr.Close();
                    #endregion

                    #region Main Loop
                    // Progress bar for large table records to write.
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = TableProps.RecordCount;
                    progressBar1.Step = 1;

                    int recnum = 0;
                    while (!sr.EndOfStream)
                    {
                        // Readline (record) as string
                        // split string

                        string recordline = sr.ReadLine();
                        string[] record;

                        if (tabDelimited)
                            record = recordline.Split('\t');
                        else record = recordline.Split(',');

                        // add new record
                        if (!addendum || importRec)
                        {
                            TDB.TDBTableRecordAdd(currentDBfileIndex, SelectedTableName, true);
                            //TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);
                            // Import record's record index.
                            if (importRec)
                                recnum = recnum + 1;
                        }

                        int importtmpfieldindex = -1;

                        foreach (KeyValuePair<string, int> import in AvailableFields)
                        {
                            //if (TableProps.Name == "PLAY" && getFieldIndex(import.Key) > AvailableFields.Count - 2)
                            //    continue;

                            string importfieldnames = import.Key;

                            importtmpfieldindex = importtmpfieldindex + 1;

                            #region Comment code.
                            // we only want to import the fields that actually exist in the current table
                            // which have already been stored in the available fields dictionary

                            // check tablefields for the name of the importing field
                            // if it corresponds to a string data type, set it
                            // you can look at tdbfieldtype to see what values the enum is set to
                            // MessageBox.Show(import.Key, record[import.Value]);
                            #endregion

                            //TdbFieldProperties FieldProps = new TdbFieldProperties();
                            //                   FieldProps.Name = new string((char)0, 5);

                            //TDB.TDBFieldGetProperties(currentDBfileIndex, 
                            //                          SelectedTableName, 
                            //                          TDB.FieldIndex(currentDBfileIndex, SelectedTableName, import.Key), 
                            //                          ref FieldProps);

                            if (TableFields[import.Key] == (int)TdbFieldType.tdbString)
                            {
                                // ok so tableprops.name is current table
                                // import.key is the fieldname we are setting
                                // record is array with split values from the csv readline
                                // import.value is the position in the record array of the fieldname
                                // this is already a string, so we dont need to convert it



                                TDB.TDBFieldSetValueAsString(currentDBfileIndex,
                                                                   SelectedTableName,
                                                                   importfieldnames,
                                                                   recnum,
                                                                   record[import.Value]);


                                //break;
                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbInt || TableFields[import.Key] == (int)TdbFieldType.tdbSInt)
                            {
                                // signed integer and integer are the same thing, unsigned is different
                                string importfieldname = import.Key;

                                //Check if import value is within parameters.
                                if (!IsIntNumber(record[import.Value]) ||
                                    !TDB.TDBFieldSetValueAsInteger(currentDBfileIndex,
                                                                   SelectedTableName,
                                                                   importfieldname,
                                                                   recnum,
                                                                   (int)Convert.ToInt32(record[import.Value])))

                                { }  // Don't need to set it to zero on error since adding a record will automatically set it to zero.
                                     // I think you can do it this way too
                                     // so if setting the value fails, set it to 0
                                     // if (!TDB.TDBFieldSetValueAsInteger(OpenIndex, TableProps.Name, importfieldnames, recnum, (int)Convert.ToInt32(record[import.Value])))
                                     //TDB.TDBFieldSetValueAsInteger(OpenIndex, TableProps.Name, importfieldnames, recnum, 0);

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbUInt)
                            {
                                // unsigned integer
                                string importfieldname = import.Key;

                                // Check if import value is within parameters.
                                if (!IsUIntNumber(record[import.Value]) || !TDB.TDBFieldSetValueAsInteger(currentDBfileIndex, SelectedTableName, importfieldname, recnum, (int)Convert.ToUInt32(record[import.Value])))
                                { }

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbFloat)
                            {
                                // float
                                string importfieldname = import.Key;

                                // Check if import value is within parameters, if not set to max parameter.
                                if (!IsFloat(record[import.Value]) || !TDB.TDBFieldSetValueAsFloat(currentDBfileIndex, SelectedTableName, importfieldname, recnum, Convert.ToSingle(record[import.Value])))
                                { }

                            }
                            else if (TableFields[import.Key] == (int)TdbFieldType.tdbBinary || TableFields[import.Key] == (int)TdbFieldType.tdbVarchar || TableFields[import.Key] == (int)TdbFieldType.tdbLongVarchar)
                            {
                                // unsupported field types
                            }

                        }

                        if (TableProps.Name == "PLAY")
                        {
                            importFN_StringToInt(record[importtmpfieldindex + 1], recnum, "PLAY");
                            importLN_StringToInt(record[importtmpfieldindex + 2], recnum, "PLAY");
                        }

                        recnum++;
                        progressBar1.PerformStep();
                    }

                    progressBar1.Value = 0;

                    myStream.Dispose();
                    myStream.Close();
                    #endregion

                    DBModified = true;
                    saveMenuItem.Enabled = true;
                    tablePropsLabel();
                    LoadFields();

                }

            }
        }

        private void exportAllMenuItem_Click(object sender, EventArgs e)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            exportAll = true;
            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(currentDBfileIndex); i++)
            {
                // Init the tdbtableproperties name
                TableProps.Name = TableName.ToString();

                // Get the tableproperties for the given table number
                if (TDB.TDBTableGetProperties(currentDBfileIndex, i, ref TableProps))
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
        private void exportALLTableMenuItem_Click(object sender, EventArgs e)
        {
            exportAllMenuItem.PerformClick();
        }

        //fieldMenuStrip
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
                    TDB.TDBTableRecordAdd(currentDBfileIndex, SelectedTableName, true);

                    TdbTableProperties TableProps = new TdbTableProperties();
                    TableProps.Name = new string((char)0, 5);

                    TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);


                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    for (int fCount = 0; fCount != TableProps.FieldCount; fCount++)
                    {
                        TDB.TDBFieldGetProperties(currentDBfileIndex, SelectedTableName, fCount, ref FieldProps);

                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            TDB.TDBFieldSetValueAsString(currentDBfileIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToString(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            TDB.TDBFieldSetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, (int)Convert.ToUInt32(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            TDB.TDBFieldSetValueAsFloat(currentDBfileIndex, SelectedTableName, FieldProps.Name, TableProps.RecordCount - 1, Convert.ToSingle(row.Cells[fCount + 1].Value));
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                        {
                            // Can't edit these fields.
                        }
                    }

                }

                tablePropsLabel();
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
                    TDB.TDBTableRecordAdd(currentDBfileIndex, SelectedTableName, true);
                else
                {
                    for (int r = 0; r < rowcount; r++)
                    {
                        // Shouldnt use expand flag as it causes problems in certain tables when it doesnt expect more than
                        // a certain amount of records.  Player table I know has this issue...
                        TDB.TDBTableRecordAdd(currentDBfileIndex, SelectedTableName, true);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                tablePropsLabel();
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
                    // MessageBox.Show("" + row.Index + "  " + Convert.ToInt32(row.Cells[0].Value));
                    if (TDB.TDBTableRecordChangeDeleted(currentDBfileIndex, SelectedTableName, Convert.ToInt32(row.Cells[0].Value), true))
                    {
                        fieldsGridView.Rows.RemoveAt(row.Index);
                    }
                }

                DBModified = true;
                saveMenuItem.Enabled = true;
                TDB.TDBDatabaseCompact(currentDBfileIndex);
                tablePropsLabel();
                LoadFields();
            }
        }
        private void exportRecordsMenuItem_Click(object sender, EventArgs e)
        {
            string tmpReverse = "";
            string dbFile = "";

            dbFile = Path.GetFileName(currentDBfile);

            Stream myStream = null;
            SaveFileDialog SaveDialog1 = new SaveFileDialog();

            // Reverse table for file name.
            if (BigEndian)
                SaveDialog1.FileName = "export" + dbFile + " - " + StrReverse(SelectedTableName);
            else SaveDialog1.FileName = "export" + dbFile + " - " + SelectedTableName;

            SaveDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";

            dbFile = SaveDialog1.FileName;

            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                // use a try-catch here
#pragma warning disable CS0168 // Variable is declared but never used
                try
                {

                    // Open the file using Stream, if it succeeds do stuff with it
                    if ((myStream = SaveDialog1.OpenFile()) != null)
                    {
                        StreamWriter wText = new StreamWriter(myStream);    // create writer using the stream that opened the savefile earlier

                        StringBuilder hbuilder = new StringBuilder();       // hbuilder is for the header, which are the fieldnames
                        // builder.Append(Whatever string you want here, probably the field names in the table
                        // builder.Append(",");  separate each name with a comma

                        TdbTableProperties TableProps = new TdbTableProperties();
                        TableProps.Name = new string((char)0, 5);

                        TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);

                        #region Write CSV Header (field names).
                        for (int i = 0; i < TableProps.FieldCount; i++)
                        {
                            TdbFieldProperties FieldProps = new TdbFieldProperties();
                            FieldProps.Name = new string((char)0, 5);

                            if (TDB.TDBFieldGetProperties(currentDBfileIndex, SelectedTableName, i, ref FieldProps))
                            {
                                tmpReverse = FieldProps.Name;

                                // Reverse field name if BigEndian file.
                                if (BigEndian)
                                    tmpReverse = StrReverse(tmpReverse);
                            }
                            hbuilder.Append(tmpReverse);

                            // Excempt comma if there are no more field names to add.
                            if (i != TableProps.FieldCount - 1)
                                hbuilder.Append(",");
                        }

                        wText.WriteLine(hbuilder.ToString());   // Convert the string builder to an actual string and write to the stream/file
                        #endregion

                        // Progress bar for large table records to write.
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = TableProps.RecordCount;
                        progressBar1.Step = 1;

                        #region Write CSV cells (field values).

                        foreach (DataGridViewRow row in fieldsGridView.SelectedRows)
                        {
                            hbuilder.Clear();
                            for (int f = 0; f < TableProps.FieldCount; f++)
                            {
                                TdbFieldProperties FieldProps = new TdbFieldProperties();
                                FieldProps.Name = new string((char)0, 5);

                                TDB.TDBFieldGetProperties(currentDBfileIndex, TableProps.Name, f, ref FieldProps);

                                if (FieldProps.FieldType == TdbFieldType.tdbString)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);

                                    TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value), ref val);
                                    val = val.Replace(",", "");

                                    hbuilder.Append(val.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                                {
                                    UInt32 intval;
                                    intval = (UInt32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(intval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                                {
                                    Int32 signedval;
                                    signedval = TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(signedval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                                {
                                    float floatval;
                                    floatval = TDB.TDBFieldGetValueAsFloat(currentDBfileIndex, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value));
                                    hbuilder.Append(floatval.ToString());

                                }
                                else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                                {
                                    string val = new string((char)0, (FieldProps.Size / 8) + 1);
                                    TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, Convert.ToInt32(row.Cells[0].Value), ref val);

                                    // hbuilder.Append(val.ToString());
                                    hbuilder.Append("usft");

                                }
                                else hbuilder.Append("[na]");

                                // Excempt comma if there are no more field names to add.
                                if (f != TableProps.FieldCount - 1)
                                    hbuilder.Append(",");
                            }
                            progressBar1.PerformStep();
                            wText.WriteLine(hbuilder.ToString());   // Convert the strin builder to an actual string and write to the stream/file
                        }
                        #endregion

                        progressBar1.Value = 0;
                        wText.Flush();
                        wText.Close();

                        MessageBox.Show(dbFile + Path.GetExtension(SaveDialog1.FileName).ToLower() + " saved.", "Export");

                    }
                }
                catch (IOException err)
                {
                    MessageBox.Show("Error opening file\r\n\r\n Check that the file is not already opened", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
#pragma warning restore CS0168 // Variable is declared but never used
                myStream.Close();  // I get an error when saving the file when it is opened in excel.
            }

            DBModified = true;
        }
        private void importRecordsMenuItem_Click(object sender, EventArgs e)
        {
            importRec = true;
            addendum = true;
            TDB.TDBDatabaseCompact(currentDBfileIndex);
            importMenuItem.PerformClick();
            importRec = false;
            addendum = false;
        }

        private void addendumMenuItem_Click(object sender, EventArgs e)
        {
            addendum = true;
            importMenuItem.PerformClick();
            addendum = false;
        }
        //
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

            getTABLES(currentDBfileIndex);
            LoadTables();

            getFIELDS(currentDBfileIndex, SelectedTableIndex);
            LoadFields();
        }
        private void ascendingMenuItem_Click(object sender, EventArgs e)
        {
            ascendingFieldOrderMenuItem.Checked = true;
            defaultFieldOrderMenuItem.Checked = false;
            descendingFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            //getTABLES(currentDBfileIndex);
            sortTABLES();
            LoadTables();

            //getFIELDS(currentDBfileIndex, SelectedTableIndex);
            sortFIELDS();
            LoadFields();
        }
        private void descendingMenuItem_Click(object sender, EventArgs e)
        {
            descendingFieldOrderMenuItem.Checked = true;
            ascendingFieldOrderMenuItem.Checked = false;
            defaultFieldOrderMenuItem.Checked = false;
            customOrderMenuItem.Checked = false;

            //getTABLES(currentDBfileIndex);
            sortTABLES();
            LoadTables();

            //getFIELDS(currentDBfileIndex, SelectedTableIndex);
            sortFIELDS();
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
                            foreach (KeyValuePair<int, string> sortAZ in FIELDnames)
                            {
                                if (csvfieldnames[c] == sortAZ.Value)
                                {
                                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);
                                    break;
                                }
                            }
                        }

                        FIELDnames.Clear();
                        foreach (KeyValuePair<int, string> sortAZ in tmpFIELDnames)
                            FIELDnames.Add(sortAZ.Key, sortAZ.Value);

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




        /*
         * LOAD & SAVE
         */
        #region LOAD/SAVE ACTIONS
        public string GetFileName(string ext, string filter)
        {
            openFileDialog1.FileName = Path.GetFileName(currentDBfile);

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentDBfile = openFileDialog1.FileName;
            }
            else
                currentDBfile = "";

            return currentDBfile;
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
                currentDBfile = filename + ".db2";
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
                currentDBfile = filename + ".db";
                activeDB = 1;
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
                SaveDB(currentDBfileIndex);
                array = File.ReadAllBytes(currentDBfile); //db2
                x = 0;
                y = array.Length;
                psuTmp = db2Data;
            }
            else
            {
                foreach (byte b in db2Data)
                    psuTmp.Add(b);

                SaveDB(currentDBfileIndex);
                array = File.ReadAllBytes(currentDBfile); //db1
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
            if (currentDBfileIndex == -1)
                currentDBfileIndex = TDB.TDBOpen(dbFileName);
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
            string tmpFilename = Path.GetDirectoryName(currentDBfile) + @"\" + Path.GetFileNameWithoutExtension(currentDBfile) + ".db";
            string tmpFilename2 = Path.GetDirectoryName(currentDBfile) + @"\" + Path.GetFileNameWithoutExtension(currentDBfile) + ".db2";
            File.Delete(tmpFilename);
            File.Delete(tmpFilename2);
        }

        #endregion


        /*
         *  TDB DATA ACTIONS
         */
        #region TDB DATA ACTIONS

        private void getTABLES(int dbFILEindex)
        {
            TABLEnames.Clear();

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

                    TABLEnames.Add(i, tmpTABLEname);
                }
                //progressBar1.PerformStep();
                progressBar1.Value = i;

            }
            progressBar1.Value = 0;
            sortTABLES();

        }
        private void sortTABLES()
        {
            Dictionary<int, string> tmpTABLEnames = new Dictionary<int, string>();

            tmpTABLEnames.Clear();

            //Sort TABLES
            if (ascendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in TABLEnames.OrderBy(value => value.Value))
                    tmpTABLEnames.Add(sortAZ.Key, sortAZ.Value);

                TABLEnames.Clear();
            }
            else if (descendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in TABLEnames.OrderByDescending(value => value.Value))
                    tmpTABLEnames.Add(sortAZ.Key, sortAZ.Value);

                TABLEnames.Clear();
            }

            foreach (KeyValuePair<int, string> sortAZ in tmpTABLEnames)
                TABLEnames.Add(sortAZ.Key, sortAZ.Value);
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

            setPositions();
            createRatingsDB();

            int tmpi = 0;
            foreach (KeyValuePair<int, string> TABLE in TABLEnames)
            {
                // Populate Table Grid
                object[] DataGrid = new object[2];
                DataGrid[0] = TABLE.Key;
                DataGrid[1] = TABLE.Value;

                if (TABLE.Value == "TEAM")
                {
                    createTeamDB();

                    //BOOKMARK TAB PAGES ON/OFF

                    //tabControl1.TabPages.Add(tabTeams);
                }
                if (TABLE.Value == "PLAY")
                {
                    //tabControl1.TabPages.Add(tabPlayers);
                }

                string tmpDef = fieldDEF(TABLE.Value);

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
            FIELDnames.Clear();
            // int rownum = fieldsGridView.CurrentCellAddress.Y;
            // int colnum = fieldsGridView.CurrentCellAddress.X;

            TablePropsLabel.Text = "";

            if (tableGridView.SelectedRows.Count <= 0 || currentDBfileIndex == -1)
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

            tablePropsLabel();

            // MessageBox.Show(SelectedTableName);
            getFIELDS(currentDBfileIndex, SelectedTableIndex);
            LoadFields();


        }
        private void tablePropsLabel()
        {
            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);

            // TablePropsLabel.Text = "Tables: " + TDB.TDBDatabaseGetTableCount(currentDBfileIndex) + "    Table Name: " + tableGridView.SelectedRows[0].Cells[1].Value.ToString() + "   Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString();
            TablePropsLabel.Text = "Fields: " + TableProps.FieldCount.ToString() + "   Capacity: " + TableProps.Capacity.ToString() + "   Records: " + TableProps.RecordCount.ToString() + "    DelRec: " + TableProps.DeletedCount.ToString() + "  CID: " + currentDBfileIndex;

        }

        private void getFIELDS(int dbFILEindex, int tmpTABLEindex)
        {
            if (TDB.TableIndex(dbFILEindex, "PNLU") != -1)
            {
                managPNLU(dbFILEindex, "PNLU", "PNNU");

            }
            else
            {
                // Clone PNLU table
                clonePNLU();
            }

            FIELDnames.Clear();

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

                TDB.TDBFieldGetProperties(dbFILEindex, getTABLEname(dbFILEindex, tmpTABLEindex), i, ref FieldProps);

                string tmpFIELDname = FieldProps.Name;
                if (BigEndian)
                    tmpFIELDname = StrReverse(tmpFIELDname);

                FIELDnames.Add(i, tmpFIELDname);

                progressBar1.PerformStep();
            }

            progressBar1.Value = 0;

            if (TableProps.Name == "PLAY")
            {
                if (TDB.TableIndex(dbFILEindex, "First Name") == -1)
                    FIELDnames.Add(FIELDnames.Count, "First Name");

                if (TDB.TableIndex(dbFILEindex, "Last Name") == -1)
                    FIELDnames.Add(FIELDnames.Count, "Last Name");

                if (TDB.TableIndex(dbFILEindex, "Team Name") == -1)
                    FIELDnames.Add(FIELDnames.Count, "College");

                if (TDB.TableIndex(dbFILEindex, "Position") == -1)
                    FIELDnames.Add(FIELDnames.Count, "Position");
            }

            sortFIELDS();
        }
        private void sortFIELDS()
        {
            Dictionary<int, string> tmpFIELDnames = new Dictionary<int, string>();

            tmpFIELDnames.Clear();

            //Sort TABLES
            if (ascendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in FIELDnames.OrderBy(value => value.Value))
                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);

                FIELDnames.Clear();
            }
            else if (descendingFieldOrderMenuItem.Checked)
            {
                foreach (KeyValuePair<int, string> sortAZ in FIELDnames.OrderByDescending(value => value.Value))
                    tmpFIELDnames.Add(sortAZ.Key, sortAZ.Value);

                FIELDnames.Clear();
            }

            foreach (KeyValuePair<int, string> sortAZ in tmpFIELDnames)
                FIELDnames.Add(sortAZ.Key, sortAZ.Value);
        }
        private void LoadFields()
        {
            int tmpFIELDcount = FIELDnames.Count;

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
            foreach (KeyValuePair<int, string> sortAZ in FIELDnames)
            {
                // add columns to FieldGridView
                fieldsGridView.Columns[tmpi + 1].Width = 47;
                fieldsGridView.Columns[tmpi + 1].Name = sortAZ.Value;

                string tmpDef = fieldDEF(sortAZ.Value);

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
            if (!TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps))
                return;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TableProps.RecordCount;
            progressBar1.Step = 1;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(currentDBfileIndex, TableProps.Name, r))
                    continue;

                int tmpf = 0;

                int fCount = TableProps.FieldCount + 1;

                if (TableProps.Name == "PLAY" &&
                                      TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "First Name") == -1 &&
                                      TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "Last Name") == -1)
                    fCount = TableProps.FieldCount + fCount_addon;


                // Format FieldGridView by tdbFieldType.
                object[] DataGridRow = new object[fCount];
                DataGridRow[0] = r;

                if (SelectedTableName == "PLAY")
                {
                    if (TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "First Name") == -1)
                    {
                        fieldsGridView.Columns[fCount - fCount_First].Width = 86;
                        DataGridRow[fCount - fCount_First] = convertFN_IntToString(r);
                    }
                    if (TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "Last Name") == -1)
                    {
                        fieldsGridView.Columns[fCount - fCount_Last].Width = 86;
                        DataGridRow[fCount - fCount_Last] = convertLN_IntToString(r);
                        fieldsGridView.Columns[fCount - fCount_Team].Width = 86;
                        fieldsGridView.Columns[fCount - fCount_Pos].Width = 86;
                    }
                }



                foreach (KeyValuePair<int, string> f in FIELDnames)
                {
                    if (TableProps.Name == "PLAY" && f.Key > FIELDnames.Count - fCount_addon)
                        continue;

                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(currentDBfileIndex, TableProps.Name, f.Key, ref FieldProps);

                    #region Load fieldsGridView by tdbFieldType.
                    //
                    if (FieldProps.FieldType == TdbFieldType.tdbString)
                    {
                        // I think Values that are a string might have to be formatted to a specific length
                        // it probably has something to do with the language he made the dll with
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);


                        TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, r, ref val);
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
                        intval = (UInt32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = intval;

                        if (FieldProps.Name == "PGID" && TDB.TableIndex(currentDBfileIndex, "TEAM") == 1)
                        {
                            DataGridRow[fCount - fCount_Team] = getTeamName((int)intval / 70);
                        }
                        else if (FieldProps.Name == "PPOS")
                        {
                            pos = (UInt32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, "PLAY", "PPOS", r);
                            DataGridRow[fCount - fCount_Pos] = getPlayerPosition((int)pos);
                        }
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                    {
                        Int32 signedval;
                        signedval = TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = signedval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                    {
                        float floatval;
                        floatval = TDB.TDBFieldGetValueAsFloat(currentDBfileIndex, TableProps.Name, FieldProps.Name, r);

                        DataGridRow[tmpf + 1] = floatval;
                    }
                    else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                    {
                        string val = new string((char)0, (FieldProps.Size / 8) + 1);
                        TDB.TDBFieldGetValueAsString(currentDBfileIndex, TableProps.Name, FieldProps.Name, r, ref val);

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
            if (currentDBfileIndex == -1 || FIELDnames.Count < 0)
                return;

            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;



            FieldsPropsLabel.Text = "";

            if (colnum > FIELDnames.Count || colnum < 0 || rownum < 0)
                return;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(currentDBfileIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(currentDBfileIndex, tmpTableIndex, ref tableProps);

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
                TDB.TDBFieldGetProperties(currentDBfileIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion


            FieldsPropsLabel.Text = "Field: " + fieldProps.Name.ToString() +
                                 "    Bits: " + fieldProps.Size.ToString() +
                                 "    Type: " + fieldProps.FieldType.ToString() +
                                 "  MaxVal: " + bitMax(fieldProps.Size);

        }
        private void FieldGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rownum = fieldsGridView.CurrentCellAddress.Y;
            int colnum = fieldsGridView.CurrentCellAddress.X;
            fieldsGridView.Rows[rownum].Cells[colnum].Style.ForeColor = Color.Red;

            string tmpFieldName = Convert.ToString(fieldsGridView.Columns[colnum].HeaderText);
            int tmpcol = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[0].Value);

            // MessageBox.Show(tmpFieldName);

            if (fieldsGridView.SelectedRows.Count <= 0 || currentDBfileIndex == -1 || colnum < 0 || rownum < 0)
                return;

            DBModified = true;

            #region Get TABLE Properties
            TdbTableProperties tableProps = new TdbTableProperties();
            tableProps.Name = new string((char)0, 5);

            int tmpTableCount = TDB.TDBDatabaseGetTableCount(currentDBfileIndex);

            for (int tmpTableIndex = 0; tmpTableIndex < tmpTableCount; tmpTableIndex++)
            {
                TDB.TDBTableGetProperties(currentDBfileIndex, tmpTableIndex, ref tableProps);

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
                TDB.TDBFieldGetProperties(currentDBfileIndex, tableProps.Name, tmpFieldIndex, ref fieldProps);
                if (fieldProps.Name == tmpFieldName)
                    break;
            }
            #endregion

            if (SelectedTableName == "PLAY" && tmpFieldName == "First Name" || tmpFieldName == "Last Name")
            {
                if (tmpFieldName == "First Name" && TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "First Name") == -1)
                {
                    string tmpPFNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();


                    importFN_StringToInt(tmpPFNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }

                if (tmpFieldName == "Last Name" && TDB.FieldIndex(currentDBfileIndex, SelectedTableName, "Last Name") == -1)
                {
                    string tmpPLNA = fieldsGridView.Rows[rownum].Cells[colnum].Value.ToString();

                    importLN_StringToInt(tmpPLNA, tmpcol, "PLAY"); //converts name to digits
                    return;
                }

            }
            if (fieldProps.FieldType == TdbFieldType.tdbString)
            {
                string tmpval = Convert.ToString(fieldsGridView.Rows[rownum].Cells[colnum].Value);

                // string val = new string((char)0, (FieldProps.Size / 8) + 1);

                tmpval = tmpval.Replace(",", "");

                if (!TDB.TDBFieldSetValueAsString(currentDBfileIndex, SelectedTableName, fieldProps.Name, tmpcol, tmpval))
                    fieldsGridView.Rows[rownum].Cells[colnum].Value = tmpval;

            }
            else if (fieldProps.FieldType == TdbFieldType.tdbUInt)
            {
                int tmpval = Convert.ToInt32(fieldsGridView.Rows[rownum].Cells[colnum].Value);
                UInt32 intval = Convert.ToUInt32(tmpval);

                // int val = (Int32)TDB.TDBFieldGetValueAsInteger(currentDBfileIndex, SelectedTableName, FieldProps.Name, Convert.ToInt32(tmpcol));
                if (IsUIntNumber(Convert.ToString(tmpval)))
                {
                    if (!TDB.TDBFieldSetValueAsInteger(currentDBfileIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(intval)))
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

                    bool tmpTDB = TDB.TDBFieldSetValueAsInteger(currentDBfileIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToInt32(tmpval));
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

                    bool tmpTDB = TDB.TDBFieldSetValueAsFloat(currentDBfileIndex, SelectedTableName, fieldProps.Name, Convert.ToInt32(tmpcol), Convert.ToSingle(tmpval));
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

        private string fieldDEF(string fieldname)
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
        private string bitMax(int bitsize)
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
        private int getFieldIndex(string tmpFName)
        {
            int tmpIndex = 0;

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            TDB.TDBTableGetProperties(currentDBfileIndex, SelectedTableIndex, ref TableProps);

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            FieldProps.Name = new string((char)0, 5);

            for (int index = 0; index < TableProps.FieldCount; index++)
            {
                TDB.TDBFieldGetProperties(currentDBfileIndex, SelectedTableName, index, ref FieldProps);

                if (tmpFName == FieldProps.Name)
                {
                    tmpIndex = index;
                    break;
                }
            }
            // MessageBox.Show(tmpIndex + " ", tmpFName + " - " + FieldProps.Name);
            return tmpIndex;
        }
        private string getTABLEname(int dbFILEindex, int tmpTABLEindex)
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
        private int getTABLEindex(int dbFILEindex, string tmpTABLEname)
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


        /*
         * CREATING NCAA SPECIFIC CONVERSION TABLES AND ACTIONS
         */
        #region CONVERSION LIBRARY
        private void clonePNLU()
        {
            Alphabet.Clear();
            AlphabetX.Clear();

            AlphabetX.Add("", 0);
            AlphabetX.Add("a", 1);
            AlphabetX.Add("b", 2);
            AlphabetX.Add("c", 3);
            AlphabetX.Add("d", 4);
            AlphabetX.Add("e", 5);
            AlphabetX.Add("f", 6);
            AlphabetX.Add("g", 7);
            AlphabetX.Add("h", 8);
            AlphabetX.Add("i", 9);
            AlphabetX.Add("j", 10);
            AlphabetX.Add("k", 11);
            AlphabetX.Add("l", 12);
            AlphabetX.Add("m", 13);
            AlphabetX.Add("n", 14);
            AlphabetX.Add("o", 15);
            AlphabetX.Add("p", 16);
            AlphabetX.Add("q", 17);
            AlphabetX.Add("r", 18);
            AlphabetX.Add("s", 19);
            AlphabetX.Add("t", 20);
            AlphabetX.Add("u", 21);
            AlphabetX.Add("v", 22);
            AlphabetX.Add("w", 23);
            AlphabetX.Add("x", 24);
            AlphabetX.Add("y", 25);
            AlphabetX.Add("z", 26);
            AlphabetX.Add("A", 27);
            AlphabetX.Add("B", 28);
            AlphabetX.Add("C", 29);
            AlphabetX.Add("D", 30);
            AlphabetX.Add("E", 31);
            AlphabetX.Add("F", 32);
            AlphabetX.Add("G", 33);
            AlphabetX.Add("H", 34);
            AlphabetX.Add("I", 35);
            AlphabetX.Add("J", 36);
            AlphabetX.Add("K", 37);
            AlphabetX.Add("L", 38);
            AlphabetX.Add("M", 39);
            AlphabetX.Add("N", 40);
            AlphabetX.Add("O", 41);
            AlphabetX.Add("P", 42);
            AlphabetX.Add("Q", 43);
            AlphabetX.Add("R", 44);
            AlphabetX.Add("S", 45);
            AlphabetX.Add("T", 46);
            AlphabetX.Add("U", 47);
            AlphabetX.Add("V", 48);
            AlphabetX.Add("W", 49);
            AlphabetX.Add("X", 50);
            AlphabetX.Add("Y", 51);
            AlphabetX.Add("Z", 52);
            AlphabetX.Add("-", 53);
            AlphabetX.Add("'", 54);
            AlphabetX.Add(".", 55);
            AlphabetX.Add(" ", 56);
            AlphabetX.Add("@", 57);

            foreach (KeyValuePair<string, int> CHAR in AlphabetX)
            {
                Alphabet.Add(CHAR.Value, CHAR.Key);
            }


        }

        public string convertFN_IntToString(int tmpRecNo)
        {

            string tmpSTR = "";
            string xPFNA = "";

            for (int PF = 1; PF <= maxNameChar; PF++)
            {
                if (Alphabet[Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PF" + addLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPFNA = xPFNA + Alphabet[Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PF" + addLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))];

            }
            tmpSTR = xPFNA;
            return tmpSTR;
        }
        public string convertLN_IntToString(int tmpRecNo)
        {
            string tmpSTR = "";
            string xPLNA = "";

            for (int PL = 1; PL <= maxNameChar; PL++)
            {
                if (Alphabet[Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PL" + addLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPLNA = xPLNA + Alphabet[Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PL" + addLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))];

            }
            tmpSTR = xPLNA;
            return tmpSTR;
        }

        private void importFN_StringToInt(string PFNA, int tmpRecNo, string tableName)
        {
            for (int i = 1; i <= maxNameChar; i++)
            {
                int tmpSTR = 0;

                if (i <= PFNA.Length)
                    tmpSTR = AlphabetX[PFNA.Substring(i - 1, 1)];

                // MessageBox.Show(tmpSTR.ToString());
                TDB.NewfieldValue(currentDBfileIndex,
                                  tableName,
                                  "PF" + addLeadingZeros(Convert.ToString(i), 2),
                                  tmpRecNo,
                                  Convert.ToString(tmpSTR));

            }
        }
        private void importLN_StringToInt(string PLNA, int tmpRecNo, string tableName)
        {
            for (int i = 1; i <= maxNameChar; i++)
            {
                int tmpSTR = 0;

                if (i <= PLNA.Length)
                    tmpSTR = AlphabetX[PLNA.Substring(i - 1, 1)];

                TDB.NewfieldValue(currentDBfileIndex,
                                  tableName,
                                  "PL" + addLeadingZeros(Convert.ToString(i), 2),
                                  tmpRecNo,
                                  Convert.ToString(tmpSTR));


            }
        }

        private string addLeadingZeros(string tmpSTR, int tmpLen)
        {
            for (int i = 1; i < tmpLen; i++)
                tmpSTR = "0" + tmpSTR;

            if (tmpSTR.Length > tmpLen)
                tmpSTR = tmpSTR.Substring(tmpSTR.Length - tmpLen, tmpLen);

            return tmpSTR;
        }

        private void setPositions()
        {
            Positions.Clear();
            PositionsX.Clear();

            Positions.Add(0, "QB");
            Positions.Add(1, "HB");
            Positions.Add(2, "FB");
            Positions.Add(3, "WR");
            Positions.Add(4, "TE");
            Positions.Add(5, "LT");
            Positions.Add(6, "LG");
            Positions.Add(7, "OC");
            Positions.Add(8, "RG");
            Positions.Add(9, "RT");
            Positions.Add(10, "LE");
            Positions.Add(11, "RE");
            Positions.Add(12, "DT");
            Positions.Add(13, "LOLB");
            Positions.Add(14, "MLB");
            Positions.Add(15, "ROLB");
            Positions.Add(16, "CB");
            Positions.Add(17, "FS");
            Positions.Add(18, "SS");
            Positions.Add(19, "K");
            Positions.Add(20, "P");

            foreach (KeyValuePair<int, string> CHAR in Positions)
            {
                PositionsX.Add(CHAR.Value, CHAR.Key);
            }
        }

        public string getPlayerPosition(int tmpRecNo)
        {

            string tmpSTR = Positions[tmpRecNo];
            return tmpSTR;
        }

        private void createRatingsDB()
        {
            Ratings.Clear();
            RatingsX.Clear();

            Ratings.Add(0, 40);
            Ratings.Add(1, 44);
            Ratings.Add(2, 48);
            Ratings.Add(3, 52);
            Ratings.Add(4, 56);
            Ratings.Add(5, 59);
            Ratings.Add(6, 62);
            Ratings.Add(7, 65);
            Ratings.Add(8, 68);
            Ratings.Add(9, 70);
            Ratings.Add(10, 72);
            Ratings.Add(11, 74);
            Ratings.Add(12, 76);
            Ratings.Add(13, 78);
            Ratings.Add(14, 80);
            Ratings.Add(15, 82);
            Ratings.Add(16, 84);
            Ratings.Add(17, 85);
            Ratings.Add(18, 86);
            Ratings.Add(19, 87);
            Ratings.Add(20, 88);
            Ratings.Add(21, 89);
            Ratings.Add(22, 90);
            Ratings.Add(23, 91);
            Ratings.Add(24, 92);
            Ratings.Add(25, 93);
            Ratings.Add(26, 94);
            Ratings.Add(27, 95);
            Ratings.Add(28, 96);
            Ratings.Add(29, 97);
            Ratings.Add(30, 98);
            Ratings.Add(31, 99);

            foreach (KeyValuePair<int, int> CHAR in Ratings)
            {
                RatingsX.Add(CHAR.Value, CHAR.Key);
            }
        }

        public int convertRating(int value)
        {
            return Ratings[value];
        }

        public int revertRating(int value)
        {
            while (!RatingsX.ContainsKey(value))
            {
                value--;
            }
            return RatingsX[value];
        }

        public void createTeamDB()
        {
            for (int i = 0; i < maxTeamsDB; i++)
            {
                int j = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "TEAM", "TGID", i));

                teamNameDB[j] = Convert.ToString(TDB.FieldValue(currentDBfileIndex, "TEAM", "TDNA", i));
            }
        }

        public string getTeamName(int tmpRecNo)
        {

            string tmpSTR = teamNameDB[tmpRecNo];
            return tmpSTR;
        }

        private int findTeamPrestige(int TGID)
        {
            int TMPR = 0;
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "TEAM"); i++)
            {
                if (TGID == Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "TEAM", "TGID", i)))
                {
                    TMPR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "TEAM", "TMPR", i));
                }
            }
            return TMPR;
        }

        private int findRecNumberCCID(int CCID)
        {
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "COCH"); i++)
            {
                if (CCID == Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CCID", i)))
                {
                    return i;
                }
            }

            return -1;
        }

        private int getRandomAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(tol, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        private int getReducedAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(0, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        #endregion


        /* 
         * TAB SWITCHING AREA
         */
        #region TAB CONTROLS
        private void tabControl1_IndexChange(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabDB) tabDB_Start();
            else tabTools_Start();

        }
        private void openTabs()
        {
            if (activeDB == 1) tabControl1.TabPages.Add(tabTools);
            if (activeDB == 2) tabControl1.TabPages.Add(tabOffSeason);
        }
        private void tabTools_Start()
        {
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = false;
            FieldsPropsgroupBox.Visible = false;
        }

        private void tabDB_Start()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = true;
            FieldsPropsgroupBox.Visible = true;
            TableGridView_SelectionChanged(null,null);
        }
        #endregion


        /* 
         * DB TOOLS TAB AREA
         */
        #region MAIN DB TOOLS

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void medRS_Click(object sender, EventArgs e)
        {
            medicalRedshirt();
        }
        private void medicalRedshirt()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "INJY");
            string names = "";
            //looks at INJY table
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "INJY"); i++)
            {
                string tmpRec = TDB.FieldValue(currentDBfileIndex, "INJY", "INJL", i);
                //check to see if value is greater than 225
                /* 254 = Season Ending
                 * 196 = 10 weeks
                 */
                if (Convert.ToInt32(tmpRec) >= 196)
                {
                    //find the corresponding PGID
                    string PGID = TDB.FieldValue(currentDBfileIndex, "INJY", "PGID", i);
                    //find the corresponding recNo of the PGID in PLAY
                    for (int j = 0; j < TDB.TableRecordCount(currentDBfileIndex, "PLAY"); j++)
                    {
                        if (PGID == TDB.FieldValue(currentDBfileIndex, "PLAY", "PGID", j))
                        {
                            //checks to see if player has only played 4 or less games
                            if (checkBoxMedRSNEXT.Checked)
                            {
                                if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PL13", j)) <= 4 && TDB.FieldValue(currentDBfileIndex, "PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PRSD", j, "1");
                                    string team = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        reduceSkills(i);
                                    }

                                    names += "\n * " + convertFN_IntToString(j) + " " + convertLN_IntToString(j) + " (" + team + ")";
                                }
                            } 
                            else
                            {
                                if (TDB.FieldValue(currentDBfileIndex, "PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PRSD", j, "1");
                                    string team = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        reduceSkills(i);
                                    }

                                    names += "\n * " + convertFN_IntToString(j) + " " + convertLN_IntToString(j) + " (" + team + ")";
                                }
                            }

                            break;
                        }
                    }

                }
                progressBar1.PerformStep();
            }
            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("The NCAA has approved the following Medical Redshirts:\n\r" + names);
        }

        private void reduceSkills(int i)
        {
            int PPOE, PINJ, PSTA, PACC, PSPD, PAGI, PJMP, PSTR;
            int tol = (int)skillDrop.Value;

            PPOE = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOE", i)));
            PINJ = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PINJ", i)));
            PSTA = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PSTA", i)));
            PACC = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PACC", i)));
            PSPD = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PSPD", i)));
            PAGI = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PAGI", i)));
            PJMP = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PJMP", i)));
            PSTR = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PSTR", i)));

            PPOE = revertRating(getReducedAttribute(PPOE, tol));
            PINJ = revertRating(getReducedAttribute(PINJ, tol));
            PSTA = revertRating(getReducedAttribute(PSTA, tol));
            PACC = revertRating(getReducedAttribute(PACC, tol));
            PSPD = revertRating(getReducedAttribute(PSPD, tol));
            PAGI = revertRating(getReducedAttribute(PAGI, tol));
            PJMP = revertRating(getReducedAttribute(PJMP, tol));
            PSTR = revertRating(getReducedAttribute(PSTR, tol));

            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PPOE", i, Convert.ToString(PPOE));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PINJ", i, Convert.ToString(PINJ));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PSTA", i, Convert.ToString(PSTA));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PACC", i, Convert.ToString(PACC));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PSPD", i, Convert.ToString(PSPD));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PAGI", i, Convert.ToString(PAGI));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PJMP", i, Convert.ToString(PJMP));
            TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PSTR", i, Convert.ToString(PSTR));
        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled
        /* 
        Use current TEAM's TMPR and COCH's CTOP to make CPRE updated, then update CTOP to match previous TMPR
        */
        private void coachProg_Click(object sender, EventArgs e)
        {
            coachPrestigeProgression();
        }
        private void coachPrestigeProgression()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "COCH");

            string coach = "";
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "COCH"); i++)
            {
                if (TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i) != "511")
                {
                    string TGID = TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i);
                    int oldPrestige = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CPRE", i));
                    int newPrestige = oldPrestige;
                    int CTOP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CTOP", i));
                    int CLTF = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CLTF", i));

                    if (CLTF > 6) CLTF = CTOP;

                    newPrestige += findTeamPrestige(Convert.ToInt32(TGID)) - CLTF;

                    if (newPrestige > 6) newPrestige = 6;
                    if (newPrestige < 1) newPrestige = 1;


                    if (newPrestige > oldPrestige)
                    {
                        coach += "\n* " + getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i))) + ": " + TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", i) + " " + TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", i) + " (+" + (newPrestige - oldPrestige) + ")";
                    }
                    else if (newPrestige < oldPrestige)
                    {
                        coach += "\n* " + getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i))) + ": " + TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", i) + " " + TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", i) + " (" + (newPrestige - oldPrestige) + ")";
                    }
                    TDB.NewfieldValue(currentDBfileIndex, "COCH", "CPRE", i, Convert.ToString(newPrestige));
                    TDB.NewfieldValue(currentDBfileIndex, "COCH", "CLTF", i, Convert.ToString(findTeamPrestige(Convert.ToInt32(TGID))));



                } else
                {
                    TDB.NewfieldValue(currentDBfileIndex, "COCH", "CLTF", i, "511"); //resets their value
                    TDB.NewfieldValue(currentDBfileIndex, "COCH", "CCPO", i, "60"); //fixes coach status
                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Coach Prestige Changes:\n\n" + coach);
        }

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void bodyFix_Click(object sender, EventArgs e)
        {
            recalculateBMI("PLAY");
        }
        private void recalculateBMI(string tableName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\BMI-Calc.csv");
            //string csvLocation = Properties.Resources.BMI_Calc;


            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[402, Line.Length];
                }
                for (int column = 0; column < Line.Length; column++)
                {
                    strArray[Row, column] = Line[column];
                }
                Row++;
            }
            sr.Close();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, tableName);
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, tableName); i++)
            {
                double bmi = Math.Round(Convert.ToDouble(TDB.FieldValue(currentDBfileIndex, tableName, "PWGT", i)) / Convert.ToDouble(TDB.FieldValue(currentDBfileIndex, tableName, "PHGT", i)), 2); 

                for (int j = 0; j < 401; j++)
                {
                    if (Convert.ToString(bmi) == strArray[j, 0])
                    {
                        TDB.NewfieldValue(currentDBfileIndex, tableName, "PFSH", i, strArray[j, 1]);
                        TDB.NewfieldValue(currentDBfileIndex, tableName, "PMSH", i, strArray[j, 2]);
                        TDB.NewfieldValue(currentDBfileIndex, tableName, "PSSH", i, strArray[j, 3]);
                        break;
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Body Model updates are complete!");
        }

        //Increases minium speed for skill positions to 80
        private void increaseSpeed_Click(object sender, EventArgs e)
        {
            increaseMinimumSpeed();
        }
        private void increaseMinimumSpeed()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "1" || TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "3"
                    || TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "16" || TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "17" || TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "18")
                {
                    if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PSPD", i)) < 14)
                    {
                        TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PSPD", i, "14");
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Speed updates are complete!");
        }

        //Recalculates QB Tendencies based on original game criteria
        private void qbTend_Click(object sender, EventArgs e)
        {
            recalculateQBTendencies();
        }
        private void recalculateQBTendencies()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "PLAY");
            progressBar1.Step = 1;

            int pocket = 0;
            int balanced = 0;
            int scrambler = 0;


            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(currentDBfileIndex, "PLAY", "PPOS", i) == "0")
                {
                    int tendies;
                    int speed = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PSPD", i)));
                    int acceleration = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PACC", i)));
                    int agility = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PAGI", i)));
                    int ThPow = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PTHP", i)));
                    int ThAcc = convertRating(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "PLAY", "PTHA", i)));


                    tendies = (100 + 10 * speed + acceleration + agility - 3 * ThPow - 5 * ThAcc) / 20;

                    if (tendies > 31) tendies = 31;
                    if (tendies < 0) tendies = 0;

                    TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PTEN", i, Convert.ToString(tendies));

                    if (tendies < 10) pocket++;
                    else if (tendies > 19) scrambler++;
                    else balanced++;

                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("QB updates are complete!\n\nThe Stats:\n\n* Pocket-Passers: " + pocket + "\n\n* Balanced: " + balanced + "\n\n* Scramblers: " + scrambler);
        }


        //Randomizes the Coaching Budgets - Must be done prior to 1st Off-Season Task

        private void buttonRandomBudgets_Click(object sender, EventArgs e)
        {
            randomizeBudgets();
        }
        private void randomizeBudgets()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "COCH");

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "COCH"); i++)
            {
                //CDPC, CRPC, CTPC
                int CDPC, CRPC, CTPC;
                CRPC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CRPC", i));
                CTPC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CTPC", i));
                CDPC = 0;

                while (CDPC < 15 || CDPC > 25) {
                    CTPC += rand.Next(-4, 5);
                    CRPC += rand.Next(-4, 5);
                    CDPC = 100 - CTPC - CRPC;
                }

                TDB.NewfieldValue(currentDBfileIndex, "COCH", "CDPC", i, Convert.ToString(CDPC));
                TDB.NewfieldValue(currentDBfileIndex, "COCH", "CRPC", i, Convert.ToString(CRPC));
                TDB.NewfieldValue(currentDBfileIndex, "COCH", "CTPC", i, Convert.ToString(CTPC));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Team Budgets Changed!");
        }


        //Randomize Player Potential
        private void buttonRandPotential_Click(object sender, EventArgs e)
        {
            randomizePotential();
        }

        private void randomizePotential()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "PLAY"); i++)
            {
                int x = rand.Next(0, 32);

                TDB.NewfieldValue(currentDBfileIndex, "PLAY", "PPOE", i, Convert.ToString(x));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Potential Updates are complete!");
        }


        //Transfer Portal Chaos Mode -- Must be done at Players Leaving stage
        private void chaosTransfers()
        {
            /*
             *  For every G5 school, pick 2 starters
             *  For every P5 school, pick 1 starter
             *  Pick a random position, find the highest ranked active starter
             */


        }

        //Coaching Carousel -- Must be done at end of Season
        private void buttonCarousel_Click(object sender, EventArgs e)
        {
            coachCarousel();
        }
        private void coachCarousel()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "COCH");

            List<string> CCID_FAList = new List<string>();
            List<string> CCID_FiredList = new List<string>();
            List<string> CCID_PromoteList = new List<string>();
            List<string> TGID_VacancyList = new List<string>();


            string news = "";
            string news2 = "";

            //Get List of Coaches and Fire Some
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "COCH"); i++)
            {
                //ADD COACHING FREE AGENCY POOL TO THE LIST
                if(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i) == "511") {
                    CCID_FAList.Add(TDB.FieldValue(currentDBfileIndex, "COCH", "CCID", i));     
                } 
                else
                {
                    int CTOP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CTOP", i));
                    int CLTF = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CLTF", i));
                    int CCPO = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CCPO", i));

                    //FIRE COACHES
                    if(CCPO < (int)jobSecurityValue.Value && CTOP > CLTF && TDB.FieldValue(currentDBfileIndex, "COCH", "CFUC", i) != "1")
                    {
                        CCID_FiredList.Add(TDB.FieldValue(currentDBfileIndex, "COCH", "CCID", i));
                        TGID_VacancyList.Add(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i));

                        string coachFN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", i);
                        string coachLN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", i);
                        string teamID = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i)));

                        news2 += "Fired: " + coachFN + " " + coachLN + " (" + teamID + ")\n\n";

                        TDB.NewfieldValue(currentDBfileIndex, "COCH", "TGID", i, "511");
                        TDB.NewfieldValue(currentDBfileIndex, "COCH", "CLTF", i, "511");
                        TDB.NewfieldValue(currentDBfileIndex, "COCH", "CCPO", i, "60");
                    } 
                    //ADD COACHES TO CANDIDATE LIST
                    else if (CCPO > 99 && CTOP < CLTF && TDB.FieldValue(currentDBfileIndex, "COCH", "CFUC", i) != "1")
                    {
                        CCID_PromoteList.Add(TDB.FieldValue(currentDBfileIndex, "COCH", "CCID", i));

                        string coachFN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", i);
                        string coachLN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", i);
                        string teamID = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", i)));
                    }
                }
                progressBar1.PerformStep();
            }

            //MessageBox.Show(news2, "Fired Head Coaches");

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TGID_VacancyList.Count;

            //HIRE NEW COACHES
            while (TGID_VacancyList.Count > 0)
            {
                int TGID = Convert.ToInt32(TGID_VacancyList[0]);
                int TMPR = findTeamPrestige(TGID);
                bool hired = false;
                int downgrade = 0;

                while (!hired)
                {
                    if(rand.Next(0,100) > (100 - (int)poachValue.Value))
                    {
                        int r = rand.Next(CCID_FAList.Count);
                        int CCID = Convert.ToInt32(CCID_FAList[r]);

                        int x = findRecNumberCCID(CCID);
                        if (x == -1) MessageBox.Show("ERROR");

                        int CPRS = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "CPRS", x));
                        if (CPRS >= TMPR - downgrade)
                        {

                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "TGID", x, Convert.ToString(TGID));
                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "CLTF", x, Convert.ToString(TMPR));
                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "CCPO", x, "60");

                            string coachFN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", x);
                            string coachLN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", x);
                            string teamID = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", x)));

                            news += "Hired: " + coachFN + " " + coachLN + " (" + teamID + ")\n\n";

                            CCID_FAList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            hired = true;

                        }

                    } 
                    else if (CCID_PromoteList.Count > 0)
                    {
                        int r = rand.Next(CCID_PromoteList.Count);
                        int CCID = Convert.ToInt32(CCID_PromoteList[r]);

                        int x = findRecNumberCCID(CCID);
                        if(x == -1) MessageBox.Show("ERROR");


                        string currentTGID = TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", x);
                        int currentTMPR = findTeamPrestige(Convert.ToInt32(currentTGID));

                        if (currentTMPR < TMPR)
                        {
                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "TGID", x, Convert.ToString(TGID));
                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "CLTF", x, Convert.ToString(TMPR));
                            TDB.NewfieldValue(currentDBfileIndex, "COCH", "CCPO", x, "60");

                            string coachFN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLFN", x);
                            string coachLN = TDB.FieldValue(currentDBfileIndex, "COCH", "CLLN", x);
                            string teamID = getTeamName(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "COCH", "TGID", x)));
                            string oldTeamID = getTeamName(Convert.ToInt32(currentTGID));


                            news += "Poached! " + coachFN + " " + coachLN + " (" + teamID + ") from (" + oldTeamID + ")\n\n";

                            CCID_PromoteList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            TGID_VacancyList.Add(currentTGID);
                            hired = true;
                        }
                    }

                    downgrade++;
                }

                TGID_VacancyList.OrderBy(z => z).ToList();
                progressBar1.PerformStep();
            }


            if (news == "") news = "No Coaching Changes!";
            MessageBox.Show(news2 + "................................\n\n" + news, "COACHING CAROUSEL");

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }



        //Pre-Season Injuries -- randomly give injuries to players in pre-season

        #endregion


        /* 
        * OFF-SEASON RECRUITING TAB AREA
        */
        #region RECRUITING TOOLS



        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void buttonMinRecruitingPts_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCYR"); i++)
            {
                if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCYR", "SEWN", i)) >= 1)
                {
                    raiseMinimumRecruitingPoints();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }
        private void raiseMinimumRecruitingPoints()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "RTRI");

            Random rand = new Random();

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RTRI"); i++)
            {
                int TRPA, TRPR;
                TRPA = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RTRI", "TRPA", i));
                TRPR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RTRI", "TRPR", i));

                if (TRPR < (int)minRecPts.Value) TRPR = (int)minRecPts.Value;
                if (TRPA < (int)minTRPA.Value) TRPA = (int)minTRPA.Value;

                TDB.NewfieldValue(currentDBfileIndex, "RTRI", "TRPA", i, Convert.ToString(TRPA));
                TDB.NewfieldValue(currentDBfileIndex, "RTRI", "TRPR", i, Convert.ToString(TRPR));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Team Budgets Changed!");
        }

        //Randomize or Remove Recruiting Interested Teams
        private void buttonInterestedTeams_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCYR"); i++)
            {
                if (TDB.FieldValue(currentDBfileIndex, "RCYR", "SEWN", i) == "1")
                {
                    removeInterestedTeams();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        private void randomizeInterestedTeams()
        {

        }

        private void removeInterestedTeams()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "RCPR");

            Random rand = new Random();

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCPR"); i++)
            {
                

                for (int j = (int)removeInterestTeams.Value - 1; j < 11; j++)
                {
                    if (j < 10)
                    {
                        TDB.NewfieldValue(currentDBfileIndex, "RCPR", "PS0" + j, i, "0");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPR", "PT0" + j, i, "511");
                    } else
                    {
                        TDB.NewfieldValue(currentDBfileIndex, "RCPR", "PS" + j, i, "0");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPR", "PT" + j, i, "511");
                    }
                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Recruit Interested Teams Changed!");
        }

        //Randomize the Recruits to give a little bit more variety and evaluation randomness -- Must be done at start of Recruiting
        private void buttonRandRecruits_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCYR"); i++)
            {
                if (TDB.FieldValue(currentDBfileIndex, "RCYR", "SEWN", i) == "1")
                {
                    randomizeRecruitDB();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }

        }
        private void randomizeRecruitDB()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "RCPT");

            int tol =  (int)recruitTolerance.Value;
            int tolA = 2;

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCPT"); i++)
            {
                if(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)  //skips transfers
                {
                    //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                    //PPOE, PINJ, PAWR

                    int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                    PHGT = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PHGT", i));
                    PWGT = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PWGT", i));
                    PAWR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PAWR", i));

                    PTHA = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PTHA", i));
                    PSTA = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PSTA", i));
                    PKAC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PKAC", i));
                    PACC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PACC", i));
                    PSPD = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PSPD", i));
                    PCTH = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PCTH", i));
                    PAGI = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PAGI", i));
                    PTAK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PTAK", i));
                    PPBK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PPBK", i));
                    PRBK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRBK", i));
                    PBTK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PBTK", i));
                    PTHP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PTHP", i));
                    PJMP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PJMP", i));
                    PCAR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PCAR", i));
                    PKPR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PKPR", i));
                    PSTR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PSTR", i));

                    PBRE = rand.Next(0, 2);
                    PEYE = rand.Next(0, 2);
                    PHGT += rand.Next(-1, 2);
                    PWGT += rand.Next(-8, 9);
                    if (PWGT < 0) PWGT = 0;
                    if (PHGT > 82) PHGT = 82;
                    PPOE = rand.Next(1, 30);
                    PINJ = rand.Next(1, 30);
                    PAWR = getRandomAttribute(PAWR, tolA);

                    PTHA = getRandomAttribute(PTHA, tol);
                    PSTA = getRandomAttribute(PSTA, tol);
                    PKAC = getRandomAttribute(PKAC, tol);
                    PACC = getRandomAttribute(PACC, tol);
                    PSPD = getRandomAttribute(PSPD, tol);
                    PCTH = getRandomAttribute(PCTH, tol);
                    PAGI = getRandomAttribute(PAGI, tol);
                    PTAK = getRandomAttribute(PTAK, tol);
                    PPBK = getRandomAttribute(PPBK, tol);
                    PRBK = getRandomAttribute(PRBK, tol);
                    PBTK = getRandomAttribute(PBTK, tol);
                    PTHP = getRandomAttribute(PTHP, tol);
                    PJMP = getRandomAttribute(PJMP, tol);
                    PCAR = getRandomAttribute(PCAR, tol);
                    PKPR = getRandomAttribute(PKPR, tol);
                    PSTR = getRandomAttribute(PSTR, tol);

                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PBRE", i, Convert.ToString(PBRE));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PEYE", i, Convert.ToString(PEYE));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PPOE", i, Convert.ToString(PPOE));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PINJ", i, Convert.ToString(PINJ));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PAWR", i, Convert.ToString(PAWR));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PHGT", i, Convert.ToString(PHGT));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PWGT", i, Convert.ToString(PWGT));


                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PTHA", i, Convert.ToString(PTHA));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSTA", i, Convert.ToString(PSTA));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PKAC", i, Convert.ToString(PKAC));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PACC", i, Convert.ToString(PACC));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSPD", i, Convert.ToString(PSPD));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PCTH", i, Convert.ToString(PCTH));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PAGI", i, Convert.ToString(PAGI));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PTAK", i, Convert.ToString(PTAK));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PPBK", i, Convert.ToString(PPBK));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PRBK", i, Convert.ToString(PRBK));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PBTK", i, Convert.ToString(PBTK));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PTHP", i, Convert.ToString(PTHP));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PJMP", i, Convert.ToString(PJMP));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PCAR", i, Convert.ToString(PCAR));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PKPR", i, Convert.ToString(PKPR));
                    TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSTR", i, Convert.ToString(PKPR));
                }


                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Recruits Randomized!");

            recalculateBMI("RCPT");
        }

        //Randomize Walk-On Database -- Must be done prior to Cut Players stage
        private void buttonRandWalkOns_Click(object sender, EventArgs e)
        {
            randomizeWalkOnDB();
        }
        private void randomizeWalkOnDB()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "WKON");

            int tol = (int)toleranceWalkOn.Value;

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "WKON"); i++)
            {
                //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                //PPOE, PINJ, PAWR

                int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                PHGT = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PHGT", i));
                PWGT = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PWGT", i));

                PTHA = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PTHA", i));
                PSTA = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PSTA", i));
                PKAC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PKAC", i));
                PACC = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PACC", i));
                PSPD = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PSPD", i));
                PCTH = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PCTH", i));
                PAGI = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PAGI", i));
                PTAK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PTAK", i));
                PPBK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PPBK", i));
                PRBK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PRBK", i));
                PBTK = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PBTK", i));
                PTHP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PTHP", i));
                PJMP = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PJMP", i));
                PCAR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PCAR", i));
                PKPR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PKPR", i));
                PSTR = Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "WKON", "PSTR", i));

                PBRE = rand.Next(0, 2);
                PEYE = rand.Next(0, 2);
                PHGT += rand.Next(-2, 3);
                PWGT += rand.Next(-12, 13);
                if (PWGT < 0) PWGT = 0;
                if (PHGT > 82) PHGT = 82;
                PPOE = rand.Next(1, 31);
                PINJ = rand.Next(1, 31);
                PAWR = rand.Next(1, 31);

                PTHA = getRandomAttribute(PTHA, tol);
                PSTA = getRandomAttribute(PSTA, tol);
                PKAC = getRandomAttribute(PKAC, tol);
                PACC = getRandomAttribute(PACC, tol);
                PSPD = getRandomAttribute(PSPD, tol);
                PCTH = getRandomAttribute(PCTH, tol);
                PAGI = getRandomAttribute(PAGI, tol);
                PTAK = getRandomAttribute(PTAK, tol);
                PPBK = getRandomAttribute(PPBK, tol);
                PRBK = getRandomAttribute(PRBK, tol);
                PBTK = getRandomAttribute(PBTK, tol);
                PTHP = getRandomAttribute(PTHP, tol);
                PJMP = getRandomAttribute(PJMP, tol);
                PCAR = getRandomAttribute(PCAR, tol);
                PKPR = getRandomAttribute(PKPR, tol);
                PSTR = getRandomAttribute(PSTR, tol);

                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PBRE", i, Convert.ToString(PBRE));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PEYE", i, Convert.ToString(PEYE));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PPOE", i, Convert.ToString(PPOE));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PINJ", i, Convert.ToString(PINJ));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PAWR", i, Convert.ToString(PAWR));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PHGT", i, Convert.ToString(PHGT));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PWGT", i, Convert.ToString(PWGT));

                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PTHA", i, Convert.ToString(PTHA));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PSTA", i, Convert.ToString(PSTA));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PKAC", i, Convert.ToString(PKAC));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PACC", i, Convert.ToString(PACC));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PSPD", i, Convert.ToString(PSPD));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PCTH", i, Convert.ToString(PCTH));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PAGI", i, Convert.ToString(PAGI));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PTAK", i, Convert.ToString(PTAK));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PPBK", i, Convert.ToString(PPBK));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PRBK", i, Convert.ToString(PRBK));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PBTK", i, Convert.ToString(PBTK));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PTHP", i, Convert.ToString(PTHP));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PJMP", i, Convert.ToString(PJMP));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PCAR", i, Convert.ToString(PCAR));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PKPR", i, Convert.ToString(PKPR));
                TDB.NewfieldValue(currentDBfileIndex, "WKON", "PSTR", i, Convert.ToString(PKPR));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Walk-Ons Randomized!");
            recalculateBMI("WKON");
        }

        //Polynesian Surname Generator
        private void polyNames_Click(object sender, EventArgs e)
        {
            polynesianNameGenerator();
        }
        private void polynesianNameGenerator()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\poly-surnames.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            List<string> surnames = new List<string>();
            while (!sr.EndOfStream)
            {
                surnames.Add(sr.ReadLine());
            }
            sr.Close();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(currentDBfileIndex, "RCPT");
            progressBar1.Step = 1;

            /*States STID
             * Hawaii 10
             * California 4
             * Utah 43
             * Washington 46
             * Arizona 2
             */

            for (int i = 0; i < TDB.TableRecordCount(currentDBfileIndex, "RCPT"); i++)
            {
                //Check for Hawaii recruits (256 x 10 - 2560)
                if(Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) >= 2560 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) < 2816)
                {
                    if (rand.Next(0,100) < polyNamesPCT.Value && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        int x = rand.Next(0, surnames.Count);
                        string newName = surnames[x];
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PLNA", i, newName);
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSKI", i, "2");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
                    }
                } 
                //Check for California 4 
                else if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) >= 1024 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) < 1280)
                {
                    if (rand.Next(0, 100) < 0.25 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        int x = rand.Next(0, surnames.Count);
                        string newName = surnames[x];
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PLNA", i, newName);
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSKI", i, "2");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
                    }
                }
                //Check for Utah 43
                else if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) >= 11008 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) < 11264)
                {
                    if (rand.Next(0, 100) < 0.25 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        int x = rand.Next(0, surnames.Count);
                        string newName = surnames[x];
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PLNA", i, newName);
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSKI", i, "2");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
                    }
                }
                //Check for Washington  46
                else if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) >= 11776 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) < 12032)
                {
                    if (rand.Next(0, 100) < 0.15 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        int x = rand.Next(0, surnames.Count);
                        string newName = surnames[x];
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PLNA", i, newName);
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSKI", i, "2");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
                    }
                }
                //Check for Arizona  2
                else if (Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) >= 512 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "RCHD", i)) < 768)
                {
                    if (rand.Next(0, 100) < 0.15 && Convert.ToInt32(TDB.FieldValue(currentDBfileIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        int x = rand.Next(0, surnames.Count);
                        string newName = surnames[x];
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PLNA", i, newName);
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PSKI", i, "2");
                        TDB.NewfieldValue(currentDBfileIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
                    }
                }


                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Surname updates are complete!");

        }







        #endregion




        /*
        * PLAYER & TEAM EDITOR (work from elguapo - not used currently)
        */
        #region PLAYER/TEAM EDITOR - NOT COMPLETE


        private void selectDBTabPage()
        {
            // NB Find returns an array of controls - see the [0] at the end here...
            TabControl dbTabPage = (TabControl)this.Controls.Find(tabControl1.Name, true)[0];
            dbTabPage.SelectedIndexChanged += dbTabPage_Click;
        }
        private void dbTabPage_Click(object sender, EventArgs e)
        {
            TabControl dbTabPage = (TabControl)this.Controls.Find(tabControl1.Name, true)[0];
            if (dbTabPage.TabPages.Count < 1)
                return;

            // this.Text = " [" + dbTabPage.SelectedTab.Text + "]";
            // dbTabPage.SelectedIndex = SelectIndex;
            // MessageBox.Show("triggered");

            if (dbTabPage.SelectedTab.Text == "Teams")
            {
                if (TGIDrecNo.Count < 1)
                {
                    Management(currentDBfileIndex, "TEAM", "TORD");  //Load Teams by their team order.
                    mangTGID(currentDBfileIndex);
                    loadTGIDlistBox(currentDBfileIndex, "TTYP", -1);  // -1 = to all teams.

                    // If table exixts in current DB.
                    if (TDB.TableIndex(currentDBfileIndex, "CONF") != -1)
                    {
                        Management(currentDBfileIndex, "CONF", "CGID");
                        mangCONF();
                    }
                }

            }
            else if (dbTabPage.SelectedTab.Text == "Players")
            {
                if (PGIDrecNo.Count < 1)
                {
                    Management(currentDBfileIndex, "PLAY", "POVR");  //Load players by their overall.
                    mangPGID(currentDBfileIndex);

                }
            }

        }

        private void Management(int tmpDBindex, string tmpTName, string tmpFName)
        {
            string tmpVal = "";

            tmpManagement.Clear();

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            // Get Tableprops based on the selected table index
            if (!TDB.TDBTableGetProperties(tmpDBindex, getTABLEindex(tmpDBindex, tmpTName), ref TableProps))
                return;

            for (int r = 0; r < TableProps.RecordCount; r++)
            {
                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(tmpDBindex, TableProps.Name, r))
                    continue;


                for (int f = 0; f < TableProps.FieldCount; f++)
                {
                    TdbFieldProperties FieldProps = new TdbFieldProperties();
                    FieldProps.Name = new string((char)0, 5);

                    TDB.TDBFieldGetProperties(tmpDBindex, TableProps.Name, f, ref FieldProps);

                    #region Load recTMP by tdbFieldType.
                    if (tmpFName == FieldProps.Name)
                    {
                        //
                        if (FieldProps.FieldType == TdbFieldType.tdbString)
                        {
                            // I think Values that are a string might have to be formatted to a specific length
                            // it probably has something to do with the language he made the dll with
                            string val = new string((char)0, (FieldProps.Size / 8) + 1);

                            TDB.TDBFieldGetValueAsString(tmpDBindex, TableProps.Name, FieldProps.Name, r, ref val);
                            val = val.Replace(",", "");

                            tmpVal = val;

                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbUInt)
                        {
                            UInt32 intval;
                            intval = (UInt32)TDB.TDBFieldGetValueAsInteger(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(intval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbInt || FieldProps.FieldType == TdbFieldType.tdbSInt)
                        {
                            Int32 signedval;
                            signedval = TDB.TDBFieldGetValueAsInteger(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(signedval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbFloat)
                        {
                            float floatval;
                            floatval = TDB.TDBFieldGetValueAsFloat(tmpDBindex, TableProps.Name, FieldProps.Name, r);

                            tmpVal = Convert.ToString(floatval);
                        }
                        else if (FieldProps.FieldType == TdbFieldType.tdbBinary || FieldProps.FieldType == TdbFieldType.tdbVarchar || FieldProps.FieldType == TdbFieldType.tdbLongVarchar)
                        {
                            string val = new string((char)0, (FieldProps.Size / 8) + 1);
                            TDB.TDBFieldGetValueAsString(tmpDBindex, TableProps.Name, FieldProps.Name, r, ref val);

                            // unsupportedFieltype;
                            tmpVal = val;
                        }
                        else
                        {
                            // unsupportedFieltype;
                            tmpVal = "NA";

                        }
                        tmpManagement.Add(r, Convert.ToInt32(tmpVal));
                        break;
                    }
                    #endregion
                }

            }


        }

        private void managPNLU(int tmpDBindex, string tmpTName, string tmpFName)
        {

            Alphabet.Clear();
            AlphabetX.Clear();

            int tmpRecCount = TDB.TableRecordCount(tmpDBindex, tmpTName);


            for (int r = 0; r < tmpRecCount; r++)
            {

                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(tmpDBindex, tmpTName, r))
                    continue;

                string PNCH = TDB.FieldValue(tmpDBindex, tmpTName, "PNCH", r);
                int PNNU = Convert.ToInt32(TDB.FieldValue(tmpDBindex, tmpTName, tmpFName, r));

                Alphabet.Add(PNNU, PNCH);
                AlphabetX.Add(PNCH, PNNU);

            }

        }

        private void mangTGID(int tmpDB)
        {
            // List<int> tmpTTYP = new List<int>();
            List<int> tmpTTYP = new List<int>();
            List<int> tmpDGID = new List<int>();
            List<int> tmpLGID = new List<int>();
            List<int> tmpCGID = new List<int>();
            List<int> tmpTGRP = new List<int>();

            var tmpList = new Dictionary<int, int>();
            tmpList.Clear();
            TGIDrecNo.Clear();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpManagement.Count;
            progressBar1.Step = 1;

            // TORD
            foreach (KeyValuePair<int, int> TGID in tmpManagement.OrderBy(key => key.Value))
            {
                progressBar1.PerformStep();
                TGIDrecNo.Add(TGID.Key, Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "TGID", TGID.Key)));

                tmpTTYP.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "TTYP", TGID.Key)));

                tmpDGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "DGID", TGID.Key)));

                tmpLGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "LGID", TGID.Key)));

                if (TDB.TableIndex(currentDBfileIndex, "CONF") == -1)
                    tmpCGID.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "CGID", TGID.Key)));

                //tmpTGRP.Add(Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", "TGRP", TGID.Key)));
            }
            progressBar1.Value = 0;
            tmpTTYP.Sort();
            tmpDGID.Sort();
            tmpLGID.Sort();
            tmpCGID.Sort();
            tmpTGRP.Sort();

            if (TDB.TableIndex(currentDBfileIndex, "CONF") == -1)
            {
                CONFlist.Clear();
            }

            #region Team Type Combo Box
            // TTYP
            TTYPcomboBox.Items.Clear();
            for (int i = 0; i < tmpTTYP.Count; i++)
            {
                tmpList.AddSafe(tmpTTYP[i], 0);
            }
            foreach (KeyValuePair<int, int> TTYP in tmpList)
            {
                TTYPcomboBox.Items.Add(TTYP.Key);
            }
            if (TTYPcomboBox.Items.Count > 0)
            {
                TTYPcomboBox.Items.Add(-1);
                TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            }
            tmpList.Clear();
            tmpTTYP.Clear();
            #endregion

            #region Team Division Combo Box
            // DGID
            DGIDcomboBox.Items.Clear();
            for (int i = 0; i < tmpDGID.Count; i++)
            {

                tmpList.AddSafe(tmpDGID[i], 0);

            }
            foreach (KeyValuePair<int, int> DGID in tmpList)
            {
                DGIDcomboBox.Items.Add(DGID.Key);
            }
            //if (DGIDcomboBox.Items.Count > 0)
            //{
            //    TTYPcomboBox.Items.Add(-1);
            //    TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            //}
            tmpList.Clear();
            tmpDGID.Clear();
            #endregion

            #region Team League Combo Box
            // LGID
            LGIDcomboBox.Items.Clear();
            for (int i = 0; i < tmpLGID.Count; i++)
            {

                tmpList.AddSafe(tmpLGID[i], 0);

            }
            foreach (KeyValuePair<int, int> LGID in tmpList)
            {
                LGIDcomboBox.Items.Add(LGID.Key);
            }
            //if (DGIDcomboBox.Items.Count > 0)
            //{
            //    TTYPcomboBox.Items.Add(-1);
            //    TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            //}
            tmpList.Clear();
            tmpLGID.Clear();
            #endregion

            #region Team Conference Combo Box
            // CGID
            CGIDcomboBox.Items.Clear();
            CONFlist.Clear();
            for (int i = 0; i < tmpCGID.Count; i++)
            {
                tmpList.AddSafe(tmpCGID[i], 0);
            }

            int tmpSelectedIndex = -1;
            foreach (KeyValuePair<int, int> CGID in tmpList)
            {
                CGIDcomboBox.Items.Add(CGID.Key);

                tmpSelectedIndex = tmpSelectedIndex + 1;
                CONFlist.Add(tmpSelectedIndex, CGID.Key);
            }
            //if (DGIDcomboBox.Items.Count > 0)
            //{
            //    TTYPcomboBox.Items.Add(-1);
            //    TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            //}
            tmpList.Clear();
            tmpCGID.Clear();
            #endregion

            #region Team Group Combo Box
            // TGRP
            // TGRPcomboBox.Items.Clear();
            for (int i = 0; i < tmpTGRP.Count; i++)
            {

                tmpList.AddSafe(tmpTGRP[i], 0);

            }
            foreach (KeyValuePair<int, int> TGRP in tmpList)
            {
                //TGRPcomboBox.Items.Add(TGRP.Key);
            }
            //if (DGIDcomboBox.Items.Count > 0)
            //{
            //    TTYPcomboBox.Items.Add(-1);
            //    TTYPcomboBox.SelectedIndex = TTYPcomboBox.Items.Count - 1;
            //}
            tmpList.Clear();
            tmpTGRP.Clear();
            #endregion

            tmpManagement.Clear();
        }
        private void loadTGIDlistBox(int tmpDB, string tmpBOX, int tmpVAL)
        {
            //mangTGID();

            TGIDlistBox.Items.Clear();
            TGIDplayerBox.Items.Clear();
            //TGIDcoachBox.Items.Clear();
            TGIDlist.Clear();

            //TRV1comboBox.Items.Clear();
            //TRV2comboBox.Items.Clear();
            //TRV3comboBox.Items.Clear();

            if (TGIDrecNo.Count < 1)
                return;

            int tmpIndex = -1;
            string tmpTDNA = "";
            string tmpTLNA = "";
            string tmpFULL = "";
            int tmpFIELD = -1;

            progressBar1.Minimum = 0;
            progressBar1.Maximum = TGIDrecNo.Count;
            progressBar1.Step = 1;

            foreach (KeyValuePair<int, int> TGID in TGIDrecNo)
            {
                progressBar1.PerformStep();

                tmpTDNA = TDB.FieldValue(tmpDB, "TEAM", "TMNA", TGID.Key);
                tmpTLNA = TDB.FieldValue(tmpDB, "TEAM", "TDNA", TGID.Key) + " ";
                tmpFIELD = Convert.ToInt32(TDB.FieldValue(tmpDB, "TEAM", tmpBOX, TGID.Key));

                if (LocationcheckBox.Checked)
                {
                    tmpFULL = tmpTLNA;
                }
                else if (MascotcheckBox.Checked)
                {
                    tmpFULL = tmpTDNA;
                }
                else tmpFULL = tmpTLNA + tmpTDNA;

                if (tmpVAL == -1)
                    tmpFIELD = -1;

                if (tmpFIELD == tmpVAL)
                {
                    tmpIndex = tmpIndex + 1;
                    TGIDlistBox.Items.Add(tmpFULL);
                    TGIDplayerBox.Items.Add(tmpFULL);
                    //TGIDcoachBox.Items.Add(tmpFULL);
                    TGIDlist.Add(tmpIndex, TGID.Key);

                    //TRV1comboBox.Items.Add(tmpFULL);
                    //TRV2comboBox.Items.Add(tmpFULL);
                    //TRV3comboBox.Items.Add(tmpFULL);
                }
            }
            progressBar1.Value = 0;

            //if (TGIDlistBox.Items.Count > 0)
            //    TGIDlistBox.SelectedIndex = 0;
        }

        private void mangPGID(int tmpDBindex)
        {
            PGIDrecNo.Clear();

            var TGIDd = new Dictionary<int, int>();
            bool tmpDIC = false;
            int tmpSelectIndex = -1;


            progressBar1.Minimum = 0;
            progressBar1.Maximum = tmpManagement.Count;
            progressBar1.Step = 1;

            if (TDB.TableIndex(currentDBfileIndex, "TEAM") == -1)
            {
                tmpDIC = true;
                TGIDplayerBox.Items.Clear();
                TGIDrecNo.Clear();
            }

            foreach (KeyValuePair<int, int> PGID in tmpManagement.OrderByDescending(key => key.Value))
            {
                progressBar1.PerformStep();

                int tmpPGID = Convert.ToInt32(TDB.FieldValue(tmpDBindex, "PLAY", "PGID", PGID.Key));
                int tmpTGID = (int)tmpPGID / 70;

                PGIDrecNo.Add(PGID.Key, tmpPGID);

                #region Add team's TGID if no TEAM table
                if (tmpDIC)
                {

                    TGIDd.AddSafe(tmpTGID, tmpTGID);

                }
                #endregion

            }
            progressBar1.Value = 0;

            if (tmpDIC)
            {
                foreach (KeyValuePair<int, int> TGID in TGIDd.OrderBy(key => key.Key))
                {
                    tmpSelectIndex = tmpSelectIndex + 1;
                    TGIDrecNo.Add(TGID.Key, TGID.Value);
                    TGIDplayerBox.Items.Add(TGID.Key);
                    TGIDlist.Add(tmpSelectIndex, TGID.Key);
                    TGIDlistBox.Items.Add(TGID.Key);
                }
            }

            TGIDd.Clear();

            tmpManagement.Clear();
        }
        private void loadPGIDlistBox(int tmpDBindex, int tmpTGID)
        {
            if (PGIDrecNo.Count < 1)
                return;



            int tmpIndex = -1;
            string tmpPFNA = "";
            string tmpPLNA = "";

            PGIDlistBox.Items.Clear();
            PGIDlist.Clear();
            ROSrecNo.Clear();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = PGIDrecNo.Count;
            progressBar1.Step = 1;

            foreach (KeyValuePair<int, int> PGID in PGIDrecNo)
            {
                progressBar1.PerformStep();

                int TGID = (int)PGID.Value / 70;

                if (tmpTGID == TGID)
                {
                    tmpIndex = tmpIndex + 1;

                    tmpPFNA = convertFN_IntToString(PGID.Key);
                    tmpPLNA = convertLN_IntToString(PGID.Key);

                    PGIDlistBox.Items.Add(tmpPFNA + " " + tmpPLNA);
                    PGIDlist.Add(tmpIndex, PGID.Key);
                    ROSrecNo.Add(PGID.Key, PGID.Value);
                }

            }



            label4.Text = "Roster Size: " + Convert.ToString(PGIDlistBox.Items.Count);
            progressBar1.Value = 0;

            //if (PGIDlistBox.Items.Count > 0)
            //    PGIDlistBox.SelectedIndex = 0;

        }

        private void mangCONF()
        {
            CONFrecNo.Clear();
            CONFlist.Clear();
            CGIDcomboBox.Items.Clear();

            int tmpSelectedIndex = -1;
            foreach (KeyValuePair<int, int> CGID in tmpManagement.OrderBy(key => key.Value))
            {
                tmpSelectedIndex = tmpSelectedIndex + 1;
                CONFrecNo.Add(CGID.Key, CGID.Value);
                CONFlist.Add(tmpSelectedIndex, CGID.Value);
            }

            foreach (KeyValuePair<int, int> CGID in CONFrecNo)
            {
                string tmpVal = TDB.FieldValue(currentDBfileIndex, "CONF", "CNAM", CGID.Key);

                CGIDcomboBox.Items.Add(tmpVal);
            }
            tmpManagement.Clear();
        }



        private void editor_ConvertFN_InttoString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PFNAtextBox.Text.Length)
                        if (CHAR.Value == PFNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(currentDBfileIndex,
                                      "PLAY",
                                      "PF" + addLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
        }
        private void editor_ConvertLN_IntToString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PLNAtextBox.Text.Length)
                        if (CHAR.Value == PLNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(currentDBfileIndex,
                                      "PLAY",
                                      "PL" + addLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
        }



        private void PGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.SelectedIndex == -1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            GetPGID(tmpRecNo);
        }

        private void GetPGID(int tmpRecNo)
        {
            DoNotTrigger = true;

            PFNAtextBox.Text = convertFN_IntToString(tmpRecNo); //...first name from numeric to text conversion
            PLNAtextBox.Text = convertLN_IntToString(tmpRecNo); //...last name from numeric to text conversion

            DoNotTrigger = false;
        }

        private void TGIDplayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tmpTGID = TGIDrecNo[TGIDlist[TGIDplayerBox.SelectedIndex]];

            TGIDlistBox.SelectedIndex = TGIDplayerBox.SelectedIndex;

            loadPGIDlistBox(currentDBfileIndex, tmpTGID);
        }

        private void PFNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            editor_ConvertFN_InttoString(tmpRecNo);  // ...first name from text to numeric conversion

        }
        private void PLNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            int tmpRecNo = PGIDlist[PGIDlistBox.SelectedIndex];

            editor_ConvertLN_IntToString(tmpRecNo);  // ...last name from text to numeric conversion

        }

        private void TTYPcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TTYPcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            //TRV1comboBox.SelectedIndex = -1;
            //TRV2comboBox.SelectedIndex = -1;
            //TRV3comboBox.SelectedIndex = -1;


            // TTYPcomboBox.SelectedIndex = -1;
            DGIDcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;
            //TGRPcomboBox.SelectedIndex = -1;


            loadTGIDlistBox(currentDBfileIndex, "TTYP", Convert.ToInt32(TTYPcomboBox.Items[TTYPcomboBox.SelectedIndex]));
        }
        private void DGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            //TRV1comboBox.SelectedIndex = -1;
            //TRV2comboBox.SelectedIndex = -1;
            //TRV3comboBox.SelectedIndex = -1;


            TTYPcomboBox.SelectedIndex = -1;
            // DGIDcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;
            //TGRPcomboBox.SelectedIndex = -1;

            loadTGIDlistBox(currentDBfileIndex, "DGID", Convert.ToInt32(DGIDcomboBox.Items[DGIDcomboBox.SelectedIndex]));
        }
        private void LGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            //TRV1comboBox.SelectedIndex = -1;
            //TRV2comboBox.SelectedIndex = -1;
            //TRV3comboBox.SelectedIndex = -1;


            TTYPcomboBox.SelectedIndex = -1;
            DGIDcomboBox.SelectedIndex = -1;
            // LGIDcomboBox.SelectedIndex = -1;
            CGIDcomboBox.SelectedIndex = -1;
            //TGRPcomboBox.SelectedIndex = -1;

            loadTGIDlistBox(currentDBfileIndex, "LGID", Convert.ToInt32(LGIDcomboBox.Items[LGIDcomboBox.SelectedIndex]));
        }
        private void CGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;

            //TRV1comboBox.SelectedIndex = -1;
            //TRV2comboBox.SelectedIndex = -1;
            //TRV3comboBox.SelectedIndex = -1;


            TTYPcomboBox.SelectedIndex = -1;
            DGIDcomboBox.SelectedIndex = -1;
            LGIDcomboBox.SelectedIndex = -1;
            // CGIDcomboBox.SelectedIndex = -1;
            //TGRPcomboBox.SelectedIndex = -1;

            loadTGIDlistBox(currentDBfileIndex, "CGID", Convert.ToInt32(CONFlist[CGIDcomboBox.SelectedIndex]));
        }

        private void MascotcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            DoNotTrigger = true;
            LocationcheckBox.Checked = false;

            int tmpSelectedIndex = TGIDlistBox.SelectedIndex;

            TTYPcomboBox_SelectedIndexChanged(null, null);

            TGIDlistBox.SelectedIndex = tmpSelectedIndex;
            DoNotTrigger = false;
        }
        private void LocationcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            DoNotTrigger = true;
            MascotcheckBox.Checked = false;

            int tmpSelectedIndex = TGIDlistBox.SelectedIndex;

            TTYPcomboBox_SelectedIndexChanged(null, null);

            TGIDlistBox.SelectedIndex = tmpSelectedIndex;
            DoNotTrigger = false;
        }

        private void TGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TGIDlistBox.Items.Count < 1 || TGIDlistBox.SelectedIndex == -1)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TGIDplayerBox.SelectedIndex = TGIDlistBox.SelectedIndex;

            GetTGID(tmpRecNo);

        }
        private void GetTGID(int tmpRecNo)
        {
            DoNotTrigger = true;

            TGIDtextBox.Text = TDB.FieldValue(currentDBfileIndex, "TEAM", "TGID", tmpRecNo);

            TLNAtextBox.Text = TDB.FieldValue(currentDBfileIndex, "TEAM", "TDNA", tmpRecNo);
            TDNAtextBox.Text = TDB.FieldValue(currentDBfileIndex, "TEAM", "TMNA", tmpRecNo);

            DoNotTrigger = false;
        }


        private void TLNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TDB.NewfieldValue(currentDBfileIndex, "TEAM", "TDNA", tmpRecNo, TLNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TLNAtextBox.Text + " " + TDNAtextBox.Text;

        }
        private void TDNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int tmpRecNo = TGIDlist[TGIDlistBox.SelectedIndex];

            TDB.NewfieldValue(currentDBfileIndex, "TEAM", "TMNA", tmpRecNo, TDNAtextBox.Text);
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TLNAtextBox.Text + " " + TDNAtextBox.Text;

        }

        #endregion


    }

}
