using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        private void StartUniformEditor()
        {
            DoNotTrigger = true;

            //Clear Table
            UniformGrid.Rows.Clear();

            //Create Columnms
            CreateUniformComboBoxes();

            //Create Table
            CreateUNIFTable();

            //Load Table Data
            LoadUNIFData();
            LoadTUNIData();

            //Load Filters
            LoadUnifTeams();

            CheckUniformExpansion();

            TeamPrimaryUniCheck.Enabled = false;
            TeamAltUniCheck.Enabled = false;
            TeamPrimaryUniCheck.Checked = false;
            TeamAltUniCheck.Checked = false;
            UniformsActivated.Text = "";
            ExportTeamUNIF.Enabled = false;
            ImportTeamUNIF.Enabled = false;


            DoNotTrigger = false;
        }

        #region Loading Data
        private void CreateUniformComboBoxes()
        {
            ULTF.DataSource = AddULTFData().Items;
            HelmetNums.DataSource = AddHelmetNumData().Items;
        }

        private ComboBox AddULTFData()
        {
            ComboBox comboBox = new ComboBox();

            comboBox.Items.Add("Dark");
            comboBox.Items.Add("Light");

            return comboBox;
        }

        private ComboBox AddHelmetNumData()
        {
            ComboBox comboBox = new ComboBox();
            List<string> list = GetHelmetNumbers();

            foreach (string s in list)
            {
                comboBox.Items.Add(s);
            }

            return comboBox;
        }

        /* Activate - 0
         * UFID - 1
         * Team Name - 2
         * Uniform Slot - 3
         * Uniform Color - 4
         * Shoulder Num - 5
         * Sleeve Num - 6
         * Sleeve Decal - 7
         * Helmnet Num - 8
         * Helmet Side - 9
         */

        private void CreateUNIFTable()
        {
            int UNIFORMDATsize = 0;
            for (int i = 0; i < GetTableRecCount("UNIF"); i++)
            {
                if (GetDBValueInt("UNIF", "UFID", i) > UNIFORMDATsize)
                {
                    UNIFORMDATsize = GetDBValueInt("UNIF", "UFID", i);
                }
            }


            UniformGrid.ClearSelection();

            for (int i = 0; i < UNIFORMDATsize + 1; i++)
            {
                UniformGrid.Rows.Add(new List<string>());

                if (i >= 1200) UniformGrid.Rows[i].HeaderCell.Style.BackColor = Color.LightSkyBlue;
            }
        }

        private void LoadUNIFData()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("UNIF");
            UniformGrid.ClearSelection();

            for (int i = 0; i < GetTableRecCount("UNIF"); i++)
            {
                //UniformGrid.Rows.Add(new List<string>());
                int UFID = GetDBValueInt("UNIF", "UFID", i);
                var uniform = UniformGrid.Rows[UFID];

                uniform.Cells[0].Value = false;
                uniform.Cells[1].ValueType = typeof(int);

                uniform.Cells[1].Value = UFID;
                uniform.Cells[2].Value = "XXX";
                uniform.Cells[3].Value = "";

                uniform.Cells[4].Value = ULTF.Items[GetDBValueInt("UNIF", "ULTF", i)];
                LoadShoulderNum(i, UFID); //5
                LoadSleeveNum(i, UFID); //6
                LoadSleeveDecal(i, UFID); //7

                uniform.Cells[8].Value = HelmetNums.Items[GetDBValueInt("UNIF", "UHNB", i)];
                LoadHelmetSideNum(i, UFID); //9

                ProgressBarStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void LoadShoulderNum(int row, int UFID)
        {
            var uniform = UniformGrid.Rows[UFID];

            if (GetDBValueInt("UNIF", "USHF", row) > 0)
            {
                uniform.Cells[5].Value = true;
            }
        }

        private void LoadSleeveNum(int row, int UFID)
        {
            var uniform = UniformGrid.Rows[UFID];

            if (GetDBValueInt("UNIF", "USLF", row) > 0)
            {
                uniform.Cells[6].Value = true;
            }
        }

        private void LoadSleeveDecal(int row, int UFID)
        {
            var uniform = UniformGrid.Rows[UFID];

            if (GetDBValueInt("UNIF", "UDSV", row) > 0)
            {
                uniform.Cells[7].Value = true;
            }
        }

        private void LoadHelmetSideNum(int row, int UFID)
        {
            var uniform = UniformGrid.Rows[UFID];

            if (GetDBValueInt("UNIF", "UHNS", row) > 0)
            {
                uniform.Cells[9].Value = true;
            }

        }

        private void LoadTUNIData()
        {
            //Import Data
            List<List<string>> LeagueData = new List<List<string>>();

            //UniformGrid.Sort(UFID, ListSortDirection.Ascending);
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\uniforms\TUNI-MASTER.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);

            int Row = 0;
            while (!sr.EndOfStream)
            {

                string[] Line = sr.ReadLine().Split(',');
                if (Row != 0)
                {
                    int UFID = Convert.ToInt32(Line[1]);
                    var uniform = UniformGrid.Rows[UFID];

                    //uniform.Cells[0].Value = true;
                    uniform.Cells[2].Value = GetUFIDTeam(Convert.ToInt32(Line[2]));
                    uniform.Cells[3].Value = GetUniformSlot(Convert.ToInt32(Line[3]));

                }
                Row++;
            }
            sr.Close();

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("TUNI");


            for (int i = 0; i < GetTableRecCount("TUNI"); i++)
            {
                int UFID = GetDBValueInt("TUNI", "UFID", i);

                var uniform = UniformGrid.Rows[UFID];

                uniform.Cells[0].Value = true;
                //uniform.Cells[3].Value = GetUFIDTeam(GetDBValueInt("TUNI", "TOID", i));
                //uniform.Cells[4].Value = GetUniformSlot(GetDBValueInt("TUNI", "TUCO", i));

                ProgressBarStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void MasterUniformListButton_Click(object sender, EventArgs e)
        {
            //Import Data
            List<List<string>> LeagueData = new List<List<string>>();
            openFileDialog2.Filter = "CSV Files (*.csv)|*.csv";
            Stream myStream = null;

            UniformGrid.Sort(UFID, ListSortDirection.Ascending);


            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                myStream = openFileDialog2.OpenFile();
                StreamReader sr = new StreamReader(myStream);


                int Row = 0;
                while (!sr.EndOfStream)
                {

                    string[] Line = sr.ReadLine().Split(',');
                    if (Row != 0)
                    {
                        int UFID = Convert.ToInt32(Line[1]);
                        var uniform = UniformGrid.Rows[UFID];

                        //uniform.Cells[0].Value = true;
                        uniform.Cells[2].Value = GetUFIDTeam(Convert.ToInt32(Line[2]));
                        uniform.Cells[3].Value = GetUniformSlot(Convert.ToInt32(Line[3]));

                    }
                    Row++;
                }
                sr.Close();
            }
            CheckUniformExpansion();
        }

        private void LoadUnifTeams()
        {
            TeamUniformSelectBox.Items.Clear();
            TeamUniformSelectBox.Items.Add("_ALL TEAMS_");


            for (int i = 0; i < teamNameDB.Length; i++)
            {
                if (teamNameDB[i] != null)
                {
                    TeamUniformSelectBox.Items.Add(teamNameDB[i]);
                }
            }

            TeamUniformSelectBox.Sorted = true;
        }

        #endregion

        #region Uniform Slot Validations

        private void CheckUniformExpansion()
        {
            DoNotTrigger = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 1200;

            for (int i = 1200; i < UniformGrid.Rows.Count; i = i + 20)
            {
                string team = (UniformGrid.Rows[i].Cells[2].Value).ToString();

                if (UniformGrid.Rows[i].Cells[0].Value.Equals(true) && team != "XXX")
                {
                    for (int j = 0; j < 1200; j++)
                    {
                        if (UniformGrid.Rows[j].Cells[2].Value == DBNull.Value || UniformGrid.Rows[j].Cells[2].Value == null || UniformGrid.Rows[j].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[j].Cells[2].Value.Equals("XXX"))
                        {
                        }
                        else if (UniformGrid.Rows[j].Cells[2].Value.ToString().Equals(team))
                        {
                            UniformGrid.Rows[j].Cells[0].Value = false;
                        }
                    }
                }

                ProgressBarStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            DoNotTrigger = false;
        }

        private void RemoveTeamExpansionAll(string team)
        {
            DoNotTrigger = true;

            int count = 0;
            for (int row = 1200; row < UniformGrid.Rows.Count; row++)
            {

                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                }
                //Disable All Expanded Uniforms
                else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                {
                    UniformGrid.Rows[row].Cells[0].Value = false;
                    count++;
                }
                if (count == 20) break;
            }
            TeamAltUniCheck.Checked = false;

            //Enable OG Uniforms
            for (int row = 0; row < 1200; row++)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                }
                else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                    count++;
                }
            }
            DoNotTrigger = false;

        }

        private void RemoveTeamExpansionAlts(string team)
        {
            DoNotTrigger = true;

            int count = 0;
            for (int row = 1200; row < UniformGrid.Rows.Count; row++)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                }
                //Disable Expanded Alt Uniforms
                else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team) && !UniformGrid.Rows[row].Cells[3].Value.Equals("Home") && !UniformGrid.Rows[row].Cells[3].Value.Equals("Away"))
                {
                    UniformGrid.Rows[row].Cells[0].Value = false;
                    count++;
                }
                if (count == 20) break;
            }
            DoNotTrigger = false;

        }

        private void AddTeamExpansion(string team)
        {
            DoNotTrigger = true;

            int count = 0;
            for (int row = 1200; row < UniformGrid.Rows.Count; row++)
            {

                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                }
                //Enable Expanded Primary Uniforms
                else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team) && UniformGrid.Rows[row].Cells[3].Value.Equals("Home") || UniformGrid.Rows[row].Cells[2].Value.Equals(team) && UniformGrid.Rows[row].Cells[3].Value.Equals("Away"))
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                    count++;
                }
                if (count == 2) break;
            }

            DoNotTrigger = false;
        }

        private void AddTeamExpansionAlts(string team)
        {
            DoNotTrigger = true;

            int count = 0;
            //Enable Expanded Alt Uniforms
            for (int row = 1200; row < UniformGrid.Rows.Count; row++)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                }
                else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                    count++;
                }
                if (count == 20) break;
            }

            DoNotTrigger = false;

        }

        #endregion


        #region Trigger Actions

        private void TeamUniformSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUniformTeamFilter();
        }

        private void LoadUniformTeamFilter()
        {
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);
            for (int row = 0; row < UniformGrid.Rows.Count; row++)
            {

                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                    UniformGrid.Rows[row].Visible = false;
                }
                else if (team == "_ALL TEAMS_" || UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                {
                    UniformGrid.Rows[row].Visible = true;
                }
                else
                {
                    UniformGrid.Rows[row].Visible = false;
                }
            }
            CheckTeamUniformExpansionCounter();
        }

        private void CheckTeamUniformExpansionCounter()
        {
            DoNotTrigger = true;
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);
            TeamPrimaryUniCheck.Enabled = true;
            TeamAltUniCheck.Enabled = true;
            TeamPrimaryUniCheck.Checked = false;
            TeamAltUniCheck.Checked = false;
            UniformsActivated.Text = "Uniforms Exp Activated: " + 0 + " / 20";
            ExportTeamUNIF.Enabled = true;
            ImportTeamUNIF.Enabled = true;

            if (Convert.ToString(TeamUniformSelectBox.SelectedItem) == "_ALL TEAMS_")
            {
                TeamPrimaryUniCheck.Enabled = false;
                TeamAltUniCheck.Enabled = false;
                UniformsActivated.Text = "";
                ExportTeamUNIF.Enabled = false;
                ImportTeamUNIF.Enabled = false;
            }


            for (int row = 1200; row < UniformGrid.Rows.Count; row += 20)
            {

                if (UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                {
                    var check = UniformGrid.Rows[row].Cells[0].Value;
                    if (UniformGrid.Rows[row].Cells[0].Value.Equals(true))
                    {
                        TeamPrimaryUniCheck.Checked = true;

                        UniformsActivated.Text = "Uniforms Exp Activated: " + 2 + " / 20";

                        int alts = 0;
                        for (int j = row + 2; j < row + 20; j++)
                        {
                            if (UniformGrid.Rows[j].Cells[0].Value.Equals(true)) alts++;
                        }

                        if (alts == 18)
                            TeamAltUniCheck.Checked = true;

                        UniformsActivated.Text = "Uniforms Exp Activated: " + (alts + 2) + " / 20";

                        break;
                    }
                }
            }
            DoNotTrigger = false;
        }

        private void TeamPrimaryUniCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);

            if (TeamPrimaryUniCheck.Checked == true) AddTeamExpansion(team);
            else RemoveTeamExpansionAll(team);

            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
        }

        private void TeamAltUniCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);
            int count = 0;

            if (TeamAltUniCheck.Checked == true) AddTeamExpansionAlts(team);
            else RemoveTeamExpansionAlts(team);

            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
        }

        //Single Uniform Activated
        private void UniformGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            if (e.ColumnIndex == 0 && e.RowIndex < 1200)
            {
                if (UniformGrid.Rows[e.RowIndex].Cells[0].Value.Equals(false))
                {
                    RemoveTeamExpansionAll(Convert.ToString(UniformGrid.Rows[e.RowIndex].Cells[2].Value));
                }
                else
                {

                }
                CheckUniformExpansion();
                CheckTeamUniformExpansionCounter();
            }
            else if (e.ColumnIndex == 0 && e.RowIndex > 1199)
            {
                if (UniformGrid.Rows[e.RowIndex].Cells[0].Value.Equals(false))
                {
                    AddTeamExpansion(Convert.ToString(UniformGrid.Rows[e.RowIndex].Cells[2].Value));
                }
                else
                {

                }
                CheckUniformExpansion();
                CheckTeamUniformExpansionCounter();
            }
        }

        //Global Editors

        private void GlobalPrimaryCheck_CheckedChanged(object sender, EventArgs e)
        {
            DoNotTrigger = true;
            for (int i = 0; i < teamNameDB.Length; i++)
            {
                if (GlobalPrimaryCheck.Checked) AddTeamExpansion(teamNameDB[i]);
                else RemoveTeamExpansionAll(teamNameDB[i]);
            }

            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
            DoNotTrigger = false;
        }


        private void GlobalAltCheck_CheckedChanged(object sender, EventArgs e)
        {
            DoNotTrigger = true;

            if (GlobalAltCheck.Checked) GlobalPrimaryCheck.Checked = true;

            for (int row = 0; row < UniformGrid.Rows.Count; row++)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                    UniformGrid.Rows[row].Visible = false;
                }
                //CHECKED
                else if (row < 1200 && GlobalAltCheck.Checked)
                {
                    UniformGrid.Rows[row].Cells[0].Value = false;
                }
                else if (row >= 1200 && GlobalAltCheck.Checked)
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                }
                //UNCHECKED
                else if (row < 1200 && !GlobalAltCheck.Checked)
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                }
                else if (row >= 1200 && !GlobalAltCheck.Checked)
                {
                    UniformGrid.Rows[row].Cells[0].Value = false;
                }
                if (NextMod && row == 12 || NextMod && row == 13) //kennesaw state
                {
                    UniformGrid.Rows[row].Cells[0].Value = true;
                }
            }

            if (GlobalPrimaryCheck.Checked && !GlobalAltCheck.Checked)
            {
                for (int i = 0; i < teamNameDB.Length; i++)
                {
                    if (GlobalPrimaryCheck.Checked == true) AddTeamExpansion(teamNameDB[i]);
                    else RemoveTeamExpansionAll(teamNameDB[i]);
                }
            }
            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
            DoNotTrigger = false;
        }



        private void GlobalAltExpOnlyCheck_CheckedChanged(object sender, EventArgs e)
        {
            DoNotTrigger = true;

            for (int row = 1200; row < UniformGrid.Rows.Count; row+=20)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                    UniformGrid.Rows[row].Visible = false;
                }
                //CHECKED
                else if (UniformGrid.Rows[row].Cells[0].Value.Equals(true) && UniformGrid.Rows[row].Cells[3].Value.Equals("Home") || UniformGrid.Rows[row].Cells[0].Value.Equals(true) && UniformGrid.Rows[row].Cells[3].Value.Equals("Away"))
                {
                    for (int i = row; i < row + 20; i++)
                    {
                        UniformGrid.Rows[i].Cells[0].Value = true;
                    }
                }
            }

            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
            DoNotTrigger = false;
        }


        #endregion

        #region import/export

        private void ImportTeamUNIF_Click(object sender, EventArgs e)
        {
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);

            ImportTeamUNIFData(team);
        }

        private void ImportTeamUNIFData(string team)
        {
            //Import Data
            List<List<string>> LeagueData = new List<List<string>>();
            openFileDialog2.Filter = "CSV Files (*.csv)|*.csv";
            Stream myStream = null;

            //UniformGrid.Sort(UFID, ListSortDirection.Ascending);


            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                myStream = openFileDialog2.OpenFile();
                StreamReader sr = new StreamReader(myStream);


                int Row = 0;
                while (!sr.EndOfStream)
                {

                    string[] Line = sr.ReadLine().Split(',');
                    if (Row != 0)
                    {
                        int UFID = Convert.ToInt32(Line[1]);
                        var uniform = UniformGrid.Rows[UFID];

                        uniform.Cells[0].Value = ReturnImportedUNIFData(Line[0]).Value;
                        uniform.Cells[2].Value = GetUFIDTeam(Convert.ToInt32(Line[2]));
                        uniform.Cells[3].Value = GetUniformSlot(Convert.ToInt32(Line[3]));
                        uniform.Cells[4].Value = ULTF.Items[Convert.ToInt32(Line[4])];
                        uniform.Cells[5].Value = ReturnImportedUNIFData(Line[5]).Value;
                        uniform.Cells[6].Value = ReturnImportedUNIFData(Line[6]).Value;
                        uniform.Cells[7].Value = ReturnImportedUNIFData(Line[7]).Value;
                        uniform.Cells[8].Value = HelmetNums.Items[Convert.ToInt32(Line[8])];
                        uniform.Cells[9].Value = ReturnImportedUNIFData(Line[9]).Value;
                    }
                    Row++;
                }
                sr.Close();
            }
            CheckUniformExpansion();
            CheckTeamUniformExpansionCounter();
        }

        private DataGridViewCheckBoxCell ReturnImportedUNIFData(string x)
        {
            DataGridViewCheckBoxCell checkbox = new DataGridViewCheckBoxCell();

            if (x.Equals("TRUE") || x.Equals("True") || x.Equals("true") || x == "1")
            {
                checkbox.Value = true;
                return checkbox;
            }
            else
            {
                checkbox.Value = false;
                return checkbox;
            }
        }

        private void ExportTeamUNIF_Click(object sender, EventArgs e)
        {
            string team = Convert.ToString(TeamUniformSelectBox.SelectedItem);
            ExportTeamUNIFData(team);
        }

        private void ExportTeamUNIFData(string team)
        {
            //Save Dialog
            SaveFileDialog SaveDialog1 = new SaveFileDialog();
            SaveDialog1.Filter = "CSV Files (*.csv)|*.csv";
            //Stream myStream = File.Create("CustomLeague.csv");
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = SaveDialog1.OpenFile();
                StreamWriter wText = new StreamWriter(myStream);
                StringBuilder hbuilder = new StringBuilder();

                for (int i = 0; i < UniformGrid.Columns.Count; i++)
                {
                    hbuilder.Append(Convert.ToString(UniformGrid.Columns[i].Name));
                    hbuilder.Append(", ");
                }
                wText.WriteLine(hbuilder);


                for (int row = 0; row < UniformGrid.Rows.Count; row++)
                {
                    if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                    {
                    }
                    else if (UniformGrid.Rows[row].Cells[2].Value.Equals(team))
                    {
                        bool active = Convert.ToBoolean(UniformGrid.Rows[row].Cells[0].Value);
                        int ufid = Convert.ToInt32(UniformGrid.Rows[row].Cells[1].Value);
                        int toid = FindTGIDfromTeamName(Convert.ToString(UniformGrid.Rows[row].Cells[2].Value));
                        int tuco = ReturnUniformSlot(Convert.ToString(UniformGrid.Rows[row].Cells[3].Value));
                        int ultf = ReturnUniformULTF(Convert.ToString(UniformGrid.Rows[row].Cells[4].Value));
                        bool ushf = Convert.ToBoolean(UniformGrid.Rows[row].Cells[5].Value);
                        bool uslf = Convert.ToBoolean(UniformGrid.Rows[row].Cells[6].Value);
                        bool udsv = Convert.ToBoolean(UniformGrid.Rows[row].Cells[7].Value);
                        int uhnb = ReturnHelmetNumberVal(Convert.ToString(UniformGrid.Rows[row].Cells[8].Value));
                        bool uhns = Convert.ToBoolean(UniformGrid.Rows[row].Cells[9].Value);
                        wText.WriteLine(active + "," + ufid + "," + toid + "," + tuco + "," + ultf + "," + ushf + "," + uslf + "," + udsv + "," + uhnb + "," + uhns);
                    }
                }

                MessageBox.Show("Export Complete");
                wText.Dispose();
                wText.Close();
            }
        }

        #endregion


        #region Database Updates

        private void UpdateUNIFButton_Click(object sender, EventArgs e)
        {
            UpdateTUNI();
            UpdateUNIF();

            MessageBox.Show("Database Update Completed!\n\nRemember to Save this file before exiting!");
        }

        private void UpdateTUNI()
        {
            //Clear TUCO table
            for (int i = 0; i < GetTableRecCount("TUNI"); i++)
            {
                DeleteRecord("TUNI", i, true);
            }

            CompactDB();

            //Add Data to UNIF table
            int rec = 0;
            for (int row = 0; row < UniformGrid.Rows.Count; row++)
            {
                if (UniformGrid.Rows[row].Cells[0].Value.Equals(true) && !UniformGrid.Rows[row].Cells[2].Value.Equals("N/A"))
                {
                    AddTableRecord("TUNI", true);
                    ChangeDBInt("TUNI", "UFID", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[1].Value));
                    ChangeDBInt("TUNI", "TOID", rec, FindTGIDfromTeamName(Convert.ToString(UniformGrid.Rows[row].Cells[2].Value)));
                    ChangeDBInt("TUNI", "TUCO", rec, ReturnUniformSlot(Convert.ToString(UniformGrid.Rows[row].Cells[3].Value)));
                    rec++;
                }
            }
        }

        private void UpdateUNIF()
        {
            //Clear UNIF table
            for (int i = 0; i < GetTableRecCount("UNIF"); i++)
            {
                DeleteRecord("UNIF", i, true);
            }

            CompactDB();

            //Add Data to UNIF table
            int rec = 0;
            for (int row = 0; row < UniformGrid.Rows.Count; row++)
            {
                if (UniformGrid.Rows[row].Cells[2].Value == DBNull.Value || UniformGrid.Rows[row].Cells[2].Value == null || UniformGrid.Rows[row].Cells[2].Value.Equals("N/A") || UniformGrid.Rows[row].Cells[2].Value.Equals("XXX"))
                {
                    //skip
                }
                else
                {
                    AddTableRecord("UNIF", true);
                    ChangeDBInt("UNIF", "UFID", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[1].Value));
                    ChangeDBInt("UNIF", "ULTF", rec, ReturnUniformULTF(Convert.ToString(UniformGrid.Rows[row].Cells[4].Value)));
                    ChangeDBInt("UNIF", "USHF", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[5].Value));
                    ChangeDBInt("UNIF", "USLF", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[6].Value));
                    ChangeDBInt("UNIF", "UDSV", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[7].Value));
                    ChangeDBInt("UNIF", "UHNB", rec, ReturnHelmetNumberVal(Convert.ToString(UniformGrid.Rows[row].Cells[8].Value)));
                    ChangeDBInt("UNIF", "UHNS", rec, Convert.ToInt32(UniformGrid.Rows[row].Cells[9].Value));
                    rec++;
                }
            }
        }

        #endregion


        #region Conversions

        private string GetUniformSlot(int TUCO)
        {
            if (TUCO == 0) return "Home";
            else if (TUCO == 1) return "Away";
            else return "Alt " + (TUCO - 1);
        }

        private string GetUFIDTeam(int TOID)
        {
            string teamName = teamNameDB[TOID];
            if (teamName == null) return "N/A";
            else return teamName;
        }

        private int ReturnUniformSlot(string TUCO)
        {
            if (TUCO == "Home") return 0;
            else if (TUCO == "Away") return 1;
            else
            {
                return (Convert.ToInt32(TUCO.Substring(4)) + 1);
            }
        }

        private int ReturnUniformULTF(string ULTF)
        {
            if (ULTF == "Dark") return 0;
            else return 1;
        }

        #endregion

        /* Activate - 0
        * UFID - 1
        * Team Name - 2
        * Uniform Slot - 3
        * Uniform Color - 4
        * Shoulder Num - 5
        * Sleeve Num - 6
        * Sleeve Decal - 7
        * Helmnet Num - 8
        * Helmet Side - 9
        */

        #region Data Errors

        private void UniformGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion

    }

}
