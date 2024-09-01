using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class LeagueMain : Form
    {

        private void TabControl1_IndexChange(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabConf) ConferenceSetup();
        }

        //List of CheckBox Conferences
        private List<CheckedListBox> GetConfBoxObjects()
        {
            List<CheckedListBox> confBoxes = new List<CheckedListBox>();

            confBoxes.Add(conf1);
            confBoxes.Add(conf2);
            confBoxes.Add(conf3);
            confBoxes.Add(conf4);
            confBoxes.Add(conf5);
            confBoxes.Add(conf6);
            confBoxes.Add(conf7);
            confBoxes.Add(conf8);
            confBoxes.Add(conf9);
            confBoxes.Add(conf10);
            confBoxes.Add(conf11);
            confBoxes.Add(conf12);

            return confBoxes;
        }

        //List of Labels
        private List<TextBox> GetConfNameTextBoxes()
        {
            List<TextBox> confNames = new List<TextBox>();

            confNames.Add(confName1);
            confNames.Add(confName2);
            confNames.Add(confName3);
            confNames.Add(confName4);
            confNames.Add(confName5);
            confNames.Add(confName6);
            confNames.Add(confName7);
            confNames.Add(confName8);
            confNames.Add(confName9);
            confNames.Add(confName10);
            confNames.Add(confName11);
            confNames.Add(confName12);

            return confNames;
        }

        //Clear and Setup Tab Page
        private void ConferenceSetup()
        {
            if (main.GetDBValueInt("SEAI", "SEWN", 0) > 0 && main.GetDBValueInt("SEAI", "SEWN", 0) < 22)
            {
                MessageBox.Show("Please only make conference edits during pre-season, at end of season, or in off-season!\n\n\nFCS Swapping will only safely work at end of season or beginning of off-season!");
                tabConf.Enabled = false;
            }
            else
            {
                tabConf.Enabled = true;
            }

            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();

            foreach (var c in confBoxes)
            {
                c.Items.Clear();
                c.Enabled = true;
            }

            foreach (var c in confNames)
            {
                c.Text = string.Empty;
            }


            for (int i = 0; i < confBoxes.Count; i++)
            {
                confBoxes[i].Items.Clear();
                confNames[i].Text = string.Empty;
            }

            SwapButton.Enabled = false;


            int box = 0;
            for (int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (main.GetDBValueInt("CONF", "LGID", i) == 0)
                {
                    AddTeamsToConfSetup(main.GetDBValueInt("CONF", "CGID", i), confBoxes[box], i, confNames[box]);
                    box++;
                }
            }

            for (int i = box; i < confBoxes.Count; i++)
            {
                confBoxes[i].Visible = false;
                confNames[i].Visible = false;
            }

            AddFCSTeams();
            FCSSwapListBox.Enabled = false;
            SwapRosterBox.Enabled = false;
        }

        //Add Teams to Conferences and Label the Conference
        private void AddTeamsToConfSetup(int conf, CheckedListBox conferenceBox, int confRec, TextBox confName)
        {
            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValueInt("TEAM", "CGID", i) == conf)
                {
                    conferenceBox.Items.Add(main.GetDBValue("TEAM", "TDNA", i));
                    confName.Text = main.GetDBValue("CONF", "CNAM", confRec);
                }
            }
        }


        //Team Checked in Conference Trigger
        private void TeamChecked(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox confBox = (CheckedListBox)sender;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            string teamsSelected = "";

            confBox.Enabled = false;

            int count = 0;
            foreach (var c in confBoxes)
            {
                if (!c.Enabled) count++;
            }


            if (count >= 2)
            {
                foreach (var c in confBoxes)
                {
                    if (!c.Enabled)
                    {
                        teamsSelected += c.SelectedItem.ToString() + " ";
                    }
                    else c.Enabled = false;
                }

                SwapButton.Enabled = true;
                MessageBox.Show(teamsSelected);
            }

        }

        private void AddFCSTeams()
        {
            FCSSwapListBox.Items.Clear();
            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValueInt("TEAM", "TTYP", i) == 1)
                    FCSSwapListBox.Items.Add(main.GetDBValue("TEAM", "TDNA", i));
            }
        }

        private void DeselectTeamsButton_Click(object sender, EventArgs e)
        {
            ConferenceSetup();
        }


        //Swap/Reset Button
        private void SwapButton_Click(object sender, EventArgs e)
        {
            SwapTeams();
            ConferenceSetup();
        }

        //Swap Teams in TSWP and in TEAM
        private void SwapTeams()
        {
            string TeamA = "";
            string TeamB = "";
            bool ASelected = false;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();

            foreach (var c in confBoxes)
            {
                if (!ASelected && c.SelectedItems.Count > 0)
                {
                    TeamA = c.SelectedItem.ToString();
                    ASelected = true;
                }
                else if (ASelected && c.SelectedItems.Count > 0)
                {
                    TeamB = c.SelectedItem.ToString();
                    break;
                }
            }

            int recA = main.FindTeamRecfromTeamName(TeamA);
            int recB = main.FindTeamRecfromTeamName(TeamB);

            int swor = GetTableRecCount("TSWP");

            main.AddTableRecord("TSWP");
            main.ChangeDBString("TSWP", "TGID", swor, main.GetDBValue("TEAM", "TGID", recA));
            main.ChangeDBString("TSWP", "TIDR", swor, main.GetDBValue("TEAM", "TGID", recB));
            main.ChangeDBInt("TSWP", "SWOR", swor, swor);

            int cgidA = main.GetTeamCGID(recA);
            int dgidA = main.GetTeamDGID(recA);
            int cgidB = main.GetTeamCGID(recB);
            int dgidB = main.GetTeamDGID(recB);

            main.ChangeDBInt("TEAM", "CGID", recA, cgidB);
            main.ChangeDBInt("TEAM", "DGID", recA, dgidB);
            main.ChangeDBInt("TEAM", "CGID", recB, cgidA);
            main.ChangeDBInt("TEAM", "DGID", recB, dgidA);


            if (main.GetDBValueInt("SEAI", "SEWN", 0) == 0)
            {
                SwapSchedule(main.GetDBValueInt("TEAM", "TGID", recA), main.GetDBValueInt("TEAM", "TGID", recB), TeamA, TeamB);
            }
            else
            {
                MessageBox.Show(TeamA + " and " + TeamB + " have been swapped!\n\nIf FCS Swapping, please wait a few moments for databases to be updated!");
            }
            

        }

        //Swap Teams in the Schedule if in Pre-Season
        private void SwapSchedule(int tgidA, int tgidB, string TeamA, string TeamB)
        {
            for (int i = 0; i < main.GetTableRecCount("SCHD"); i++)
            {
                if (main.GetDBValueInt("SCHD", "GATG", i) == tgidA) main.ChangeDBInt("SCHD", "GATG", i, tgidB);
                else if (main.GetDBValueInt("SCHD", "GATG", i) == tgidB) main.ChangeDBInt("SCHD", "GATG", i, tgidA);
            }

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (main.GetDBValueInt("SCHD", "GHTG", i) == tgidA) main.ChangeDBInt("SCHD", "GHTG", i, tgidB);
                else if (main.GetDBValueInt("SCHD", "GHTG", i) == tgidB) main.ChangeDBInt("SCHD", "GHTG", i, tgidA);
            }

            MessageBox.Show(TeamA + " and " + TeamB + " schedules have been swapped!\n\nIf FCS Swapping, please wait a few moments for databases to be updated!");
        }

    }
}
