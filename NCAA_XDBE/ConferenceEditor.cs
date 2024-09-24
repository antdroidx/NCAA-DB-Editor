using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

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
        private List<Label> GetConfNameLabels()
        {
            List<Label> confNames = new List<Label>();

            confNames.Add(ConfName1);
            confNames.Add(ConfName2);
            confNames.Add(ConfName3);
            confNames.Add(ConfName4);
            confNames.Add(ConfName5);
            confNames.Add(ConfName6);
            confNames.Add(ConfName7);
            confNames.Add(ConfName8);
            confNames.Add(ConfName9);
            confNames.Add(ConfName10);
            confNames.Add(ConfName11);
            confNames.Add(ConfName12);

            return confNames;
        }

        //Clear and Setup Tab Page
        private void ConferenceSetup()
        {
            if (GetDBValueInt("SEAI", "SEWN", 0) > 0 && GetDBValueInt("SEAI", "SEWN", 0) < 22)
            {
                MessageBox.Show("Please only make conference edits during pre-season, at end of season, or in off-season!\n\n\nFCS Swapping will only safely work at end of season or beginning of off-season!");
                tabConf.Enabled = false;
            }
            else
            {
                tabConf.Enabled = true;
            }

            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<Label> confNames = GetConfNameLabels();

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
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetDBValueInt("CONF", "LGID", i) == 0)
                {
                    AddTeamsToConfSetup(GetDBValueInt("CONF", "CGID", i), confBoxes[box], i, confNames[box]);
                    box++;
                }
            }

            for (int i = box; i < confBoxes.Count; i++)
            {
                confBoxes[i].Visible = false;
                confNames[i].Visible = false;
            }


            FCSSwapListBox.Enabled = false;
            SwapRosterBox.Enabled = false;
            EnableFCSSwapBox.Enabled = false;
            EnableFCSSwapBox.Checked = false;
            if (GetDBValueInt("SEAI", "SEWN", 0) >= 22) EnableFCSSwapBox.Enabled = true;
            AddFCSTeams();
        }

        //Add Teams to Conferences and Label the Conference
        private void AddTeamsToConfSetup(int conf, CheckedListBox conferenceBox, int confRec, Label confName)
        {
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "CGID", i) == conf)
                {
                    conferenceBox.Items.Add(GetDBValue("TEAM", "TDNA", i));
                    confName.Text = GetDBValue("CONF", "CNAM", confRec);
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


            if (count == 1 && EnableFCSSwapBox.Checked || count >= 2)
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
                if (count >= 2) EnableFCSSwapBox.Enabled = false;

                if (EnableFCSSwapBox.Checked) teamsSelected += FCSSwapListBox.Text;

                //MessageBox.Show(teamsSelected);
            }

        }

        private void EnableFCSSwapBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnableFCSSwapBox.Checked && SwapRosterBox.Enabled)
            {
                EnableFCSSwapBox.Checked = false;
            }
            else if (EnableFCSSwapBox.Checked)
            {
                FCSSwapListBox.Enabled = true;
                SwapRosterBox.Enabled = true;
                FCSSwapListBox.SelectedIndex = 0;
                SwapRosterBox.SelectedIndex = 0;

                List<CheckedListBox> confBoxes = GetConfBoxObjects();
                string teamsSelected = "";

                int count = 0;
                foreach (var c in confBoxes)
                {
                    if (!c.Enabled) count++;
                }


                if (count == 1 && EnableFCSSwapBox.Checked || count >= 2)
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

                    if (EnableFCSSwapBox.Checked) teamsSelected += FCSSwapListBox.Text;

                    MessageBox.Show(teamsSelected);
                }

            }
            else
            {
                FCSSwapListBox.Enabled = false;
                SwapRosterBox.Enabled = false;
                ConferenceSetup();
            }

        }
        private void AddFCSTeams()
        {
            FCSSwapListBox.Items.Clear();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                    FCSSwapListBox.Items.Add(GetDBValue("TEAM", "TDNA", i));
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

            if (EnableFCSSwapBox.Checked) TeamB = FCSSwapListBox.Text;

            int recA = FindTeamRecfromTeamName(TeamA);
            int recB = FindTeamRecfromTeamName(TeamB);

            int swor = GetTableRecCount("TSWP");

            AddTableRecord("TSWP", false);
            ChangeDBString("TSWP", "TGID", swor, GetDBValue("TEAM", "TGID", recA));
            ChangeDBString("TSWP", "TIDR", swor, GetDBValue("TEAM", "TGID", recB));
            ChangeDBInt("TSWP", "SWOR", swor, swor);

            int cgidA = GetTeamCGID(recA);
            int dgidA = GetTeamDGID(recA);
            int cgidB = GetTeamCGID(recB);
            int dgidB = GetTeamDGID(recB);

            ChangeDBInt("TEAM", "CGID", recA, cgidB);
            ChangeDBInt("TEAM", "DGID", recA, dgidB);
            ChangeDBInt("TEAM", "CGID", recB, cgidA);
            ChangeDBInt("TEAM", "DGID", recB, dgidA);


            if (GetDBValueInt("SEAI", "SEWN", 0) == 0)
            {
                SwapSchedule(GetDBValueInt("TEAM", "TGID", recA), GetDBValueInt("TEAM", "TGID", recB), TeamA, TeamB);
            }
            else
            {
                MessageBox.Show(TeamA + " and " + TeamB + " have been swapped!\n\nIf FCS Swapping, please wait a few moments for databases to be updated!");
            }

            if (EnableFCSSwapBox.Checked)
            {
                if (SwapRosterBox.SelectedIndex == 0) SwapRosters(recA, recB);
                else if (SwapRosterBox.SelectedIndex == 1) GenerateFCSRosters(recA, recB);
                else NoRosterOption(recA, recB);
            }

        }

        //Swap Teams in the Schedule if in Pre-Season
        private void SwapSchedule(int tgidA, int tgidB, string TeamA, string TeamB)
        {
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "GATG", i) == tgidA) ChangeDBInt("SCHD", "GATG", i, tgidB);
                else if (GetDBValueInt("SCHD", "GATG", i) == tgidB) ChangeDBInt("SCHD", "GATG", i, tgidA);
            }

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "GHTG", i) == tgidA) ChangeDBInt("SCHD", "GHTG", i, tgidB);
                else if (GetDBValueInt("SCHD", "GHTG", i) == tgidB) ChangeDBInt("SCHD", "GHTG", i, tgidA);
            }

            MessageBox.Show(TeamA + " and " + TeamB + " schedules have been swapped!\n\nIf FCS Swapping, please wait a few moments for databases to be updated!");
        }


        private void SwapRosters(int recA, int recB)
        {
            int OLDtgid = GetDBValueInt("TEAM", "TGID", recA);
            int NEWtgid = GetDBValueInt("TEAM", "TGID", recB);

            //Team Type
            ChangeDBInt("TEAM", "TTYP", recA, 1);
            ChangeDBInt("TEAM", "TTYP", recB, 0);


            //swap PLAY
            for (int i = 0; i < 70; i++)
            {
                int oldPGID = OLDtgid * 70 + i;
                int newPGID = NEWtgid * 70 + i;

                ChangeDBInt("PLAY", "PGID", FindPGIDRecord(oldPGID), newPGID);

            }

            //swap STATS & DCHT
            for (int i = 0; i < 70; i++)
            {
                int oldPGID = OLDtgid * 70 + i;
                int newPGID = NEWtgid * 70 + i;

                ChangePlayerStatsID(oldPGID, newPGID);
            }

            //swap COACH
            ChangeDBInt("COCH", "TGID", FindCOCHRecordfromTeamTGID(OLDtgid), NEWtgid);

            ReorderTORD();
            MessageBox.Show("Swapping Process Complete.");
        }

        private void GenerateFCSRosters(int recA, int recB)
        {
            int tgid = GetDBValueInt("TEAM", "TGID", recA);
            int NEWtgid = GetDBValueInt("TEAM", "TGID", recB);


            //Team Type
            ChangeDBInt("TEAM", "TTYP", recA, 1);
            ChangeDBInt("TEAM", "TTYP", recB, 0);

            //Remove existing Players
            ClearTeamPlayers(tgid);


            //Clear Old Stats
            ClearOldTeamStats(tgid);

            //Create New Roster
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();

            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\RCAT-MAPPER.csv", false);

            List<List<string>> teamData = new List<List<string>>();
            teamData = CreateStringListsFromCSV(@"resources\FantasyGenData.csv", true);
            int rec = GetTableRecCount("PLAY");
            int TOID = GetDBValueInt("TEAM", "TOID", recB);
            int PGIDbeg = TOID * 70;
            int PGIDend = PGIDbeg + 69;
            int rating = GetFantasyTeamRating(teamData, TOID);
            int ST = 0;
            int freshmanPCT = 25;


            for (int j = 0; j < 68; j++)
            {
                //Add a record
                AddTableRecord("PLAY", false);

                //QB
                if (j < 3) TransferRCATtoPLAY(rec, 0, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //RB
                else if (j < 6) TransferRCATtoPLAY(rec, 1, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //FB
                else if (j < 7) TransferRCATtoPLAY(rec, 2, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //WR
                else if (j < 13) TransferRCATtoPLAY(rec, 3, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //TE
                else if (j < 16) TransferRCATtoPLAY(rec, 4, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //LT
                else if (j < 18) TransferRCATtoPLAY(rec, 5, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //LG
                else if (j < 20) TransferRCATtoPLAY(rec, 6, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //C
                else if (j < 22) TransferRCATtoPLAY(rec, 7, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //RG
                else if (j < 24) TransferRCATtoPLAY(rec, 8, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //RT
                else if (j < 26) TransferRCATtoPLAY(rec, 9, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //LE
                else if (j < 28) TransferRCATtoPLAY(rec, 10, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //DT
                else if (j < 32) TransferRCATtoPLAY(rec, 11, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //RE
                else if (j < 34) TransferRCATtoPLAY(rec, 12, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //LOLB
                else if (j < 36) TransferRCATtoPLAY(rec, 13, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //MLB
                else if (j < 39) TransferRCATtoPLAY(rec, 14, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //ROLB
                else if (j < 41) TransferRCATtoPLAY(rec, 15, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //CB
                else if (j < 46) TransferRCATtoPLAY(rec, 16, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //SS
                else if (j < 48) TransferRCATtoPLAY(rec, 17, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //FS
                else if (j < 50) TransferRCATtoPLAY(rec, 18, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //K
                else if (j < 51) TransferRCATtoPLAY(rec, 19, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                //P
                else if (j < 52) TransferRCATtoPLAY(rec, 20, PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);

                else
                {
                    if (ST < 1)
                    {
                        TransferRCATtoPLAY(rec, rand.Next(0, 21), PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);
                        ST++;
                    }
                    else TransferRCATtoPLAY(rec, rand.Next(0, 19), PGIDbeg + j, RCATmapper, PJEN, freshmanPCT);
                }



                //randomizes the attributes from team overall
                RandomizeAttribute("PLAY", rec, rating + GetDBValueInt("PLAY", "PYER", rec) - 1);
                rec++;
            }

            RecalculateOverall();
            CalculateTeamRatingsSingle("TEAM", tgid);
            DepthChartMakerSingle("TEAM", tgid);

            //Select new coach
            SelectFCSCoach(NEWtgid);
            ReorderTORD();
            MessageBox.Show("Swapping Process Complete.");
        }

        private void NoRosterOption(int recA, int recB)
        {
            int tgid = GetDBValueInt("TEAM", "TGID", recA);
            int NEWtgid = GetDBValueInt("TEAM", "TGID", recB);


            //Team Type
            ChangeDBInt("TEAM", "TTYP", recA, 1);
            ChangeDBInt("TEAM", "TTYP", recB, 0);

            //Remove Existing Players
            ClearTeamPlayers(tgid);

            //Clear Stats
            ClearOldTeamStats(tgid);

            //Select New Coach
            SelectFCSCoach(NEWtgid);

            CalculateTeamRatingsSingle("TEAM", NEWtgid);
            DepthChartMakerSingle("TEAM", NEWtgid);

            ReorderTORD();
            MessageBox.Show("Swapping Process Complete.");
        }

        private void SelectFCSCoach(int tgid)
        {
            bool hired = false;
            while (!hired)
            {
                int applicant = rand.Next(0, GetTableRecCount("COCH"));
                if (GetDBValueInt("COCH", "TGID", applicant) == 511)
                {
                    ChangeDBInt("COCH", "TGID", GetCOCHrecFromTeamRec(TeamIndex), 511);
                    ChangeDBInt("COCH", "CCPO", GetCOCHrecFromTeamRec(TeamIndex), 65);

                    ChangeDBInt("COCH", "TGID", applicant, tgid);
                    ChangeDBInt("COCH", "CCPO", applicant, 65);

                    GetTeamEditorData(TeamIndex);

                    hired = true;
                    MessageBox.Show(GetDBValue("COCH", "CLFN", applicant) + " " + GetDBValue("COCH", "CLLN", applicant) + " was hired!");

                }
            }
        }

        public void ClearTeamPlayers(int tgid)
        {
            int pgidBeg = tgid * 70;
            int pgidEnd = tgid * 70 + 69;
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd)
                {
                    DeleteRecordChange("PLAY", i, true);
                }
            }
            CompactDB();
        }

        public void ClearOldTeamStats(int tgid)
        {
            for (int i = tgid * 70; i < tgid * 70 + 70; i++)
            {
                ClearPlayerStats(i);
            }
        }


    }
}
