using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /*
        * TEAM EDITOR
        */

        #region TEAM EDITOR - STARTUP

        public void StartTeamEditor()
        {
            if (LGIDcomboBox.Items.Count <= 0)
            {
                LoadLeagueListBox();
                CreateTeamColorPalettes();
                LoadTGIDlistBox(-1, LGIDcomboBox.SelectedIndex);  // 2 = to all teams.
            }

            LoadCGIDListBox();

            DoNotTrigger = false;
        }
        private void LoadLeagueListBox()
        {
            LGIDcomboBox.Items.Clear();
            LGIDcomboBox.Items.Add("FBS");
            LGIDcomboBox.Items.Add("FCS");
            LGIDcomboBox.Items.Add("ALL");
            LGIDcomboBox.SelectedItem = LGIDcomboBox.Items[0];
        }

        private void LoadCGIDListBox()
        {
            CGIDcomboBox.Items.Clear();
            List<string> confs = new List<string>();
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetDBValueInt("CONF", "LGID", i) < 2)
                {
                    confs.Add(GetDBValue("CONF", "CNAM", i));
                }
            }

            confs.Sort();

            foreach (var c in confs)
            {
                CGIDcomboBox.Items.Add(c);
            }

        }

        public void LoadTGIDlistBox(int cgid, int lgid)
        {
            TGIDlistBox.Items.Clear();
            List<string> teamList = new List<string>();
            List<List<int>> rankList = new List<List<int>>();

            if (cgid > -1)
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "CGID", i) == cgid)
                    {
                        if (TeamShowNormal.Checked)
                        {
                            teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);

                        }
                        else
                        {
                            int rank = GetDBValueInt("TEAM", "TCRK", i);
                            int count = rankList.Count;
                            rankList.Add(new List<int>());
                            rankList[count].Add(rank);
                            rankList[count].Add(i);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (lgid == 2 || GetDBValueInt("TEAM", "TTYP", i) == lgid)
                    {
                        if (TeamShowNormal.Checked)
                        {
                            teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
                        }
                        else
                        {
                            int rank = GetDBValueInt("TEAM", "TCRK", i);
                            int count = rankList.Count;
                            rankList.Add(new List<int>());
                            rankList[count].Add(rank);
                            rankList[count].Add(i);
                        }
                    }
                }
            }

            if (TeamShowNormal.Checked) teamList.Sort();
            else
            {
                rankList.Sort((x, y) => x[0].CompareTo(y[0]));
                for (int i = 0; i < rankList.Count; i++)
                {
                    teamList.Add(rankList[i][0] + ". " + teamNameDB[GetDBValueInt("TEAM", "TGID", rankList[i][1])]);
                }

            }

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) TGIDlistBox.Items.Add(teamList[i]);
            }
        }


        public void LGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;
            CGIDcomboBox.SelectedIndex = -1;

            LoadTGIDlistBox(-1, LGIDcomboBox.SelectedIndex);
        }
        public void CGIDcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;
            LGIDcomboBox.SelectedIndex = -1;

            int cgid = GetCONFrecFromCNAM(CGIDcomboBox.Text);

            LoadTGIDlistBox(cgid, LGIDcomboBox.SelectedIndex);
        }


        private void TeamShowNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (LGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;
            CGIDcomboBox.SelectedIndex = -1;

            LoadTGIDlistBox(-1, LGIDcomboBox.SelectedIndex);
        }

        private void TeamShowRanking_CheckedChanged(object sender, EventArgs e)
        {
            if (LGIDcomboBox.SelectedIndex == -1 || DoNotTrigger)
                return;
            CGIDcomboBox.SelectedIndex = -1;

            LoadTGIDlistBox(-1, LGIDcomboBox.SelectedIndex);
        }


        public void TGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TGIDlistBox.Items.Count < 1 || TGIDlistBox.SelectedIndex == -1)
                return;

            if (TeamShowNormal.Checked)
            {
                TeamIndex = FindTeamRecfromTeamName(Convert.ToString(TGIDlistBox.SelectedItem));
            }
            else
            {
                string[] teamName = Convert.ToString(TGIDlistBox.SelectedItem).Split('.');
                string[] split = teamName[1].Split(' ');
                string splitName = "";

                for (int i = 1; i < split.Length; i++)
                {
                    if (i == split.Length - 1) splitName += split[i];
                    else splitName += split[i] + " ";
                }

                TeamIndex = FindTeamRecfromTeamName(splitName);

            }

            GetTeamEditorData(TeamIndex);

        }



        #endregion

        //GET DATA
        #region Load Team Data

        public void GetTeamEditorData(int EditorIndex)
        {
            DoNotTrigger = true;

            StartProgressBar(11);

            ProgressBarStep();

            //User Coach
            if (GetDBValue("COCH", "CFUC", GetCOCHrecFromTeamRec(EditorIndex)) == "1") UserCoachCheckBox.Checked = true;
            else UserCoachCheckBox.Checked = false;

            //Affiliation Info
            LeagueBox.Text = GetLeaguefromTTYP(GetDBValueInt("TEAM", "TTYP", EditorIndex));
            TeamConferenceBox.Text = GetConfNameFromCGID(GetDBValueInt("TEAM", "CGID", EditorIndex));
            TeamDivisionBox.Text = GetDivisionNamefromDGID(GetDBValueInt("TEAM", "DGID", EditorIndex));

            ProgressBarStep();

            //Team Name
            TGIDtextBox.Text = GetDBValue("TEAM", "TGID", EditorIndex);
            TDNAtextBox.Text = GetDBValue("TEAM", "TDNA", EditorIndex);
            TMNAtextBox.Text = GetDBValue("TEAM", "TMNA", EditorIndex);
            TSNAtextBox.Text = GetDBValue("TEAM", "TSNA", EditorIndex);

            ProgressBarStep();

            //Team Ratings


            TMPRNumBox.Value = GetDBValueInt("TEAM", "TMPR", EditorIndex);
            tmprStars.Text = ConvertStarNumber(Convert.ToInt32(TMPRNumBox.Value));

            TMARNumBox.Value = GetDBValueInt("TEAM", "TMAR", EditorIndex);
            tmarStars.Text = ConvertStarNumber(Convert.ToInt32(TMARNumBox.Value));

            TMPRNumBox.BackColor = GetPrestigeColor(TMPRNumBox.Value);
            TMARNumBox.BackColor = GetPrestigeColor(TMARNumBox.Value);


            ProgressBarStep();

            //Season Records
            APPollBox.Text = GetDBValue("TEAM", "TMRK", EditorIndex);
            CoachPollBox.Text = GetDBValue("TEAM", "TCRK", EditorIndex);
            SeasonRecordBox.Text = GetDBValue("TEAM", "tsdw", EditorIndex) + " - " + GetDBValue("TEAM", "tsdl", EditorIndex);
            ConfRecordBox.Text = GetDBValue("TEAM", "tscw", EditorIndex) + " - " + GetDBValue("TEAM", "tscl", EditorIndex);

            ProgressBarStep();

            //NCAA Investigation
            INPOnumbox.Value = GetDBValueInt("TEAM", "INPO", EditorIndex);
            INPOnumbox.BackColor = GetColorValueFullRange(INPOnumbox.Value, true);
            NCDPnumbox.Value = GetDBValueInt("TEAM", "NCDP", EditorIndex);
            NCDPnumbox.BackColor = GetColorValueFullRange(NCDPnumbox.Value);
            SDURnumbox.Value = GetDBValueInt("TEAM", "SDUR", EditorIndex);
            SNCTnumbox.Value = GetDBValueInt("TEAM", "SNCT", EditorIndex);

            ProgressBarStep();


            //Team Captains & Impact Players

            CreateTeamPlayerList();
            SetCaptainAndImpactItems();
            GetCaptainAndImpactPlayersToMemory();
            CaptainOffSelectBox.Text = "";
            CaptainDefSelectBox.Text = "";
            ImpactTPIOSelect.Text = "";
            ImpactTPIDSelect.Text = "";
            ImpactTSI1Select.Text = "";
            ImpactTSI2Select.Text = "";
            CaptainOffSelectBox.SelectedIndex = FindCaptainImpactOffPlayer(GetDBValueInt("TEAM", "OCAP", EditorIndex));
            CaptainDefSelectBox.SelectedIndex = FindCaptainImpactDefPlayer(GetDBValueInt("TEAM", "DCAP", EditorIndex));
            ImpactTPIOSelect.SelectedIndex = FindCaptainImpactOffPlayer(GetDBValueInt("TEAM", "TPIO", EditorIndex));
            ImpactTPIDSelect.SelectedIndex = FindCaptainImpactDefPlayer(GetDBValueInt("TEAM", "TPID", EditorIndex));
            ImpactTSI1Select.SelectedIndex = FindImpactTSIPlayer(GetDBValueInt("TEAM", "TSI1", EditorIndex));
            ImpactTSI2Select.SelectedIndex = FindImpactTSIPlayer(GetDBValueInt("TEAM", "TSI2", EditorIndex));

            ProgressBarStep();

            //Head Coach Info
            HCFirstNameBox.Text = GetCoachFirstNamefromRec(GetCOCHrecFromTeamRec(EditorIndex));
            HCLastNameBox.Text = GetCoachLastNamefromRec(GetCOCHrecFromTeamRec(EditorIndex));
            TeamHCPrestigeNumBox.Value = GetDBValueInt("COCH", "CPRE", GetCOCHrecFromTeamRec(EditorIndex));
            TeamHCPrestigeNumBox.BackColor = GetPrestigeColor(TeamHCPrestigeNumBox.Value);
            TeamCCPONumBox.Value = GetDBValueInt("COCH", "CCPO", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCCPONumBox.BackColor = GetColorValueFullRange(TeamCCPONumBox.Value);

            ProgressBarStep();

            //Off-Season Budgets
            TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCTPCNumber.Value = GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCRPCNumber.Value = GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(EditorIndex));

            ProgressBarStep();

            //Playbook & Strategies
            GetPlaybookItems();
            PlaybookSelectBox.SelectedIndex = GetPlaybookSelectedIndex();

            GetOffTypeItems();
            OffTypeSelectBox.SelectedIndex = GetDBValueInt("COCH", "COST", GetCOCHrecFromTeamRec(EditorIndex));

            GetDefTypeItems();
            DefTypeSelectBox.SelectedIndex = GetDBValueInt("COCH", "CDST", GetCOCHrecFromTeamRec(EditorIndex));

            TeamCOTRbox.Value = GetDBValueInt("COCH", "COTR", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCOTAbox.Value = GetDBValueInt("COCH", "COTA", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCOTSbox.Value = GetDBValueInt("COCH", "COTS", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTRbox.Value = GetDBValueInt("COCH", "CDTR", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTAbox.Value = GetDBValueInt("COCH", "CDTA", GetCOCHrecFromTeamRec(EditorIndex));
            TeamCDTSbox.Value = GetDBValueInt("COCH", "CDTS", GetCOCHrecFromTeamRec(EditorIndex));

            ProgressBarStep();


            //Team Colors
            TeamColor1Button.BackColor = Color.FromArgb(GetDBValueInt("TEAM", "TFRD", EditorIndex), GetDBValueInt("TEAM", "TFFG", EditorIndex), GetDBValueInt("TEAM", "TFFB", EditorIndex));
            TeamColor2Button.BackColor = Color.FromArgb(GetDBValueInt("TEAM", "TFOR", EditorIndex), GetDBValueInt("TEAM", "TFOG", EditorIndex), GetDBValueInt("TEAM", "TFOB", EditorIndex));
            primary = TeamColor1Button.BackColor;
            secondary = TeamColor2Button.BackColor;

            GetCrowdColorPaletteItems();
            GetCheerColorPaletteItems();
            CrowdBox.SelectedIndex = FindTeamIndexfromPalette(GetDBValueInt("TEAM", "TCRP", EditorIndex), "crowd");
            CheerleaderBox.SelectedIndex = FindTeamIndexfromPalette(GetDBValueInt("TEAM", "TMCP", EditorIndex), "cheer");

            ProgressBarStep();

            //City, State, Stadium Info
            stadiumNameBox.Text = GetDBValue("STAD", "SNAM", FindSTADrecFromTEAMrec(EditorIndex));
            CityNameBox.Text = GetDBValue("STAD", "SCIT", FindSTADrecFromTEAMrec(EditorIndex));
            GetStateBoxItems();
            StateBox.SelectedIndex = GetDBValueInt("STAD", "STID", FindSTADrecFromTEAMrec(EditorIndex));

            AttendanceNumBox.Value = GetDBValueInt("TEAM", "TMAA", EditorIndex);
            CapacityNumbox.Value = GetDBValueInt("STAD", "SCAP", FindSTADrecFromTEAMrec(EditorIndex));
            TeamStadRank.Text = Convert.ToString(GetDBValueInt("STAD", "STDR", FindSTADrecFromTEAMrec(EditorIndex)));
            TeamStadRank.BackColor = GetColorRating(Convert.ToInt32(TeamStadRank.Text));



            if (GetDBValueInt("TEAM", "TTYP", EditorIndex) == 0 && TEAM) GenerateNewRosterButton.Enabled = true;
            else GenerateNewRosterButton.Enabled = false;

            LoadTeamRivalBox();
            TeamRivalBox.Text = teamNameDB[GetDBValueInt("TEAM", "TMRV", EditorIndex)];

            LoadTeamRatingsViewer();
            LoadTopPlayersViewer();

            DoNotTrigger = false;
            EndProgressBar();
        }

        #endregion


        #region Load Box Data
        private void GetStateBoxItems()
        {
            StateBox.Items.Clear();
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);

            foreach (string state in states)
            {
                StateBox.Items.Add(state);
            }
        }

        private void GetPlaybookItems()
        {
            PlaybookSelectBox.Items.Clear();
            List<List<string>> pb = CreatePlaybookNames();
            //136-158 next ||  124 and below is vanilla
            if (verNumber == 15.0)
            {
                for (int i = 136; i < pb.Count - 2; i++)
                {
                    PlaybookSelectBox.Items.Add(pb[i][1]);
                }
            }
            else if (verNumber >= 16.0 || GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(TeamIndex)) > 135)
            {
                for (int i = 136; i < pb.Count; i++)
                {
                    PlaybookSelectBox.Items.Add(pb[i][1]);
                }
            }
            else
            {
                for (int i = 0; i <= 124; i++)
                {
                    PlaybookSelectBox.Items.Add(pb[i][1]);
                }
            }
        }

        private int GetPlaybookSelectedIndex()
        {
            int pbVal = GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(TeamIndex));

            //136-158 next ||  124 and below is vanilla
            if (pbVal > 135) pbVal = pbVal - 136;

            return pbVal;
        }

        private void GetOffTypeItems()
        {
            OffTypeSelectBox.Items.Clear();
            List<string> OffTypes = CreateOffTypes();

            foreach (string name in OffTypes)
            {
                OffTypeSelectBox.Items.Add(name);
            }

        }

        private void GetDefTypeItems()
        {
            DefTypeSelectBox.Items.Clear();
            List<string> DefTypes = CreateBaseDef();


            foreach (string name in DefTypes)
            {
                DefTypeSelectBox.Items.Add(name);
            }

        }

        private void CreateTeamPlayerList()
        {
            AllTeamPlayers = new List<List<string>>();
            OffPlayers = new List<List<string>>();
            DefPlayers = new List<List<string>>();

            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgidBeg = tgid * 70;
            int pgidEnd = tgid * 70 + 69;
            int row = 0;
            int rowOff = 0;
            int rowDef = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd)
                {
                    AllTeamPlayers.Add(new List<string>());
                    AllTeamPlayers[row].Add(GetFirstNameFromRecord(i));
                    AllTeamPlayers[row].Add(GetLastNameFromRecord(i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "PPOS", i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "POVR", i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "PGID", i));
                    AllTeamPlayers[row].Add(Convert.ToString(i));
                    AllTeamPlayers[row].Add(CalculatePositionRating(i, GetDBValueInt("PLAY", "PPOS", i)).ToString("0.000"));


                    // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec


                    //Create offense and defense player lists
                    if (GetDBValueInt("PLAY", "PPOS", i) <= 9)
                    {
                        OffPlayers.Add(new List<string>());
                        OffPlayers[rowOff] = AllTeamPlayers[row];
                        rowOff++;
                    }
                    else if (GetDBValueInt("PLAY", "PPOS", i) > 9 && GetDBValueInt("PLAY", "PPOS", i) <= 18)
                    {
                        DefPlayers.Add(new List<string>());
                        DefPlayers[rowDef] = AllTeamPlayers[row];
                        rowDef++;
                    }

                    row++;
                }
            }

            AllTeamPlayers.Sort((player1, player2) => Convert.ToDouble(player2[6]).CompareTo(Convert.ToDouble(player1[6])));
            OffPlayers.Sort((player1, player2) => Convert.ToDouble(player2[6]).CompareTo(Convert.ToDouble(player1[6])));
            DefPlayers.Sort((player1, player2) => Convert.ToDouble(player2[6]).CompareTo(Convert.ToDouble(player1[6])));


            if (AllTeamPlayers.Count < 1) ClearTeamComboBoxes();

            TeamRosterSizeLabel.Text = "Roster Size: " + Convert.ToString(AllTeamPlayers.Count);

        }

        private void SetCaptainAndImpactItems()
        {
            CaptainOffSelectBox.Items.Clear();
            CaptainDefSelectBox.Items.Clear();
            ImpactTPIDSelect.Items.Clear();
            ImpactTPIOSelect.Items.Clear();
            ImpactTSI1Select.Items.Clear();
            ImpactTSI2Select.Items.Clear();

            foreach (var players in AllTeamPlayers)
            {
                ImpactTSI1Select.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
                ImpactTSI2Select.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
            }

            foreach (var players in OffPlayers)
            {
                CaptainOffSelectBox.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
                ImpactTPIOSelect.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
            }
            foreach (var players in DefPlayers)
            {
                CaptainDefSelectBox.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
                ImpactTPIDSelect.Items.Add(players[0] + " " + players[1] + " | " + GetPositionName(Convert.ToInt32(players[2])) + " [" + ConvertRating(Convert.ToInt32(players[3])) + "]");
            }
        }

        private void GetCaptainAndImpactPlayersToMemory()
        {
            OCAPmem = GetDBValueInt("TEAM", "OCAP", TeamIndex);
            DCAPmem = GetDBValueInt("TEAM", "DCAP", TeamIndex);
            TSI1mem = GetDBValueInt("TEAM", "TSI1", TeamIndex);
            TSI2mem = GetDBValueInt("TEAM", "TSI2", TeamIndex);
            TPIOmem = GetDBValueInt("TEAM", "TPIO", TeamIndex);
            TPIDmem = GetDBValueInt("TEAM", "TPID", TeamIndex);
        }

        private int FindCaptainImpactOffPlayer(int ocap)
        {
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = ocap + (tgid * 70);

            for (int i = 0; i < OffPlayers.Count; i++)
            {
                if (OffPlayers[i][4] == Convert.ToString(pgid)) return i;
            }

            return -1;
        }

        private int FindCaptainImpactDefPlayer(int dcap)
        {
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = dcap + (tgid * 70);

            for (int i = 0; i < DefPlayers.Count; i++)
            {
                if (DefPlayers[i][4] == Convert.ToString(pgid)) return i;
            }

            return -1;
        }

        private int FindImpactTSIPlayer(int ocap)
        {
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = ocap + (tgid * 70);

            for (int i = 0; i < AllTeamPlayers.Count; i++)
            {
                if (AllTeamPlayers[i][4] == Convert.ToString(pgid)) return i;
            }

            return -1;
        }

        private void ClearTeamComboBoxes()
        {
            CaptainOffSelectBox.Text = String.Empty;
            CaptainDefSelectBox.Text = String.Empty;
            ImpactTPIOSelect.Text = String.Empty;
            ImpactTPIDSelect.Text = String.Empty;
            ImpactTSI1Select.Text = String.Empty;
            ImpactTSI2Select.Text = String.Empty;

        }

        private void GetCrowdColorPaletteItems()
        {
            CrowdBox.Items.Clear();
            for (int i = 0; i < TeamColorPalettes.Count; i++)
            {
                CrowdBox.Items.Add(TeamColorPalettes[i][0]);
            }
        }

        private void GetCheerColorPaletteItems()
        {
            CheerleaderBox.Items.Clear();
            for (int i = 0; i < TeamColorPalettes.Count; i++)
            {
                CheerleaderBox.Items.Add(TeamColorPalettes[i][0]);
            }
        }

        private int FindTeamIndexfromPalette(int pal, string type)
        {
            if (type == "crowd")
            {
                for (int i = 0; i < TeamColorPalettes.Count; i++)
                {
                    if (Convert.ToInt32(TeamColorPalettes[i][3]) == pal)
                    {
                        return i;
                    }
                }
            }
            else if (type == "cheer")
            {
                for (int i = 0; i < TeamColorPalettes.Count; i++)
                {
                    if (Convert.ToInt32(TeamColorPalettes[i][2]) == pal)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private void LoadTeamRivalBox()
        {
            TeamRivalBox.Items.Clear();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (i != TeamIndex)
                {
                    TeamRivalBox.Items.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
                }
            }
        }

        #endregion




        //Text Change Triggers
        #region Text Box Changes

        //User Coach
        private void UserCoachCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (UserCoachCheckBox.Checked) ChangeDBInt("COCH", "CFUC", GetCOCHrecFromTeamRec(TeamIndex), 1);
            else if (!UserCoachCheckBox.Checked) ChangeDBInt("COCH", "CFUC", GetCOCHrecFromTeamRec(TeamIndex), 0);

        }

        //Team Name

        private void TDNAtextBox_Leave(object sender, EventArgs e)
        {
            ChangeDBString("TEAM", "TDNA", TeamIndex, TDNAtextBox.Text);
            teamNameDB[GetTeamTGIDfromRecord(TeamIndex)] = TDNAtextBox.Text;
            TGIDlistBox.Items[TGIDlistBox.SelectedIndex] = TDNAtextBox.Text;
            ReorderTORD();
        }

        private void TMNAtextBox_Leave(object sender, EventArgs e)
        {
            ChangeDBString("TEAM", "TMNA", TeamIndex, TMNAtextBox.Text);
            teamMascot[GetTeamTGIDfromRecord(TeamIndex)] = TMNAtextBox.Text;
        }

        private void TSNAtextBox_Leave(object sender, EventArgs e)
        {
            ChangeDBString("TEAM", "TSNA", TeamIndex, TSNAtextBox.Text);

        }

        private void CaptainOffSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = CaptainOffSelectBox.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(OffPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("OCAP", val);

        }

        private void CaptainDefSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = CaptainDefSelectBox.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(DefPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("DCAP", val);

        }

        private void ImpactTPIOSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = ImpactTPIOSelect.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(OffPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("TPIO", val);
        }

        private void ImpactTPIDSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = ImpactTPIDSelect.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(DefPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("TPID", val);
        }

        private void ImpactTSI2Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = ImpactTSI2Select.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(AllTeamPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("TSI2", val);
        }

        private void ImpactTSI1Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int sel = ImpactTSI1Select.SelectedIndex;
            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);
            int pgid = Convert.ToInt32(AllTeamPlayers[sel][4]);
            int val = pgid - tgid * 70;

            SetImpactorCaptain("TSI1", val);
        }
        private void SetImpactorCaptain(string FieldName, int val)
        {
            ChangeDBInt("TEAM", FieldName, TeamIndex, val);

        }



        //Team Prestige
        private void TMPRNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "TMPR", TeamIndex, Convert.ToString(TMPRNumBox.Value));
            TMPRNumBox.BackColor = GetPrestigeColor(TMPRNumBox.Value);
            tmprStars.Text = ConvertStarNumber(Convert.ToInt32(TMPRNumBox.Value));

        }
        //Team Academics
        private void TMARNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "TMAR", TeamIndex, Convert.ToString(TMARNumBox.Value));
            TMARNumBox.BackColor = GetPrestigeColor(TMARNumBox.Value);
            tmarStars.Text = ConvertStarNumber(Convert.ToInt32(TMARNumBox.Value));

        }

        //NCAA Investigation
        private void INPOnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "INPO", TeamIndex, Convert.ToString(INPOnumbox.Value));
            INPOnumbox.BackColor = GetColorValueFullRange(INPOnumbox.Value, true);

        }

        //Discipline Points

        private void NCDPnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "NCDP", TeamIndex, Convert.ToString(NCDPnumbox.Value));
            NCDPnumbox.BackColor = GetColorValueFullRange(NCDPnumbox.Value);

        }

        //NCAA Sanction

        private void SNCTnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "SNCT", TeamIndex, Convert.ToString(SNCTnumbox.Value));
        }

        //Sanction Duration

        private void SDURnumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("TEAM", "SDUR", TeamIndex, Convert.ToString(SDURnumbox.Value));
        }

        //Head Coach First Name
        private void HCFirstNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLFN", GetCOCHrecFromTeamRec(TeamIndex), HCFirstNameBox.Text);
        }

        //Head Coach Last Name
        private void HCLastNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLLN", GetCOCHrecFromTeamRec(TeamIndex), HCLastNameBox.Text);
        }

        //Head Coach Prestige
        private void TeamHCPrestigeNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CPRE", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(TeamHCPrestigeNumBox.Value));
            TeamHCPrestigeNumBox.BackColor = GetPrestigeColor(TeamHCPrestigeNumBox.Value);

        }

        //Coach Performance
        private void TeamCCPONumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("COCH", "CCPO", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(TeamCCPONumBox.Value));
            TeamCCPONumBox.BackColor = GetColorValueFullRange(TeamCCPONumBox.Value);
        }

        //Training
        private void TeamCTPCNumber_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (TeamCRPCNumber.Value + TeamCTPCNumber.Value < 100)
            {
                ChangeDBString("COCH", "CTPC", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(TeamCTPCNumber.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(TeamIndex)) + GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(TeamIndex)));
                ChangeDBString("COCH", "CDPC", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(discpts));

                TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(TeamIndex));
            }
            else
            {
                TeamCTPCNumber.Value = GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(TeamIndex));
            }
        }

        //Recruiting
        private void TeamCRPCNumber_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (TeamCRPCNumber.Value + TeamCTPCNumber.Value < 100)
            {
                ChangeDBString("COCH", "CRPC", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(TeamCRPCNumber.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", GetCOCHrecFromTeamRec(TeamIndex)) + GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(TeamIndex)));
                ChangeDBString("COCH", "CDPC", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToString(discpts));

                TeamCDPCBox.Text = GetDBValue("COCH", "CDPC", GetCOCHrecFromTeamRec(TeamIndex));
            }

            else
            {
                TeamCRPCNumber.Value = GetDBValueInt("COCH", "CRPC", GetCOCHrecFromTeamRec(TeamIndex));
            }
        }


        //Strategy

        //Playbook Selection
        private void PlaybookSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            int pbVal = 0;

            List<List<string>> pb = CreatePlaybookNames();
            //136-158 next ||  124 and below is vanilla

            if (GetDBValueInt("COCH", "CPID", GetCOCHrecFromTeamRec(TeamIndex)) > 135)
            {
                pbVal = PlaybookSelectBox.SelectedIndex + 136;
            }
            else
            {
                pbVal = PlaybookSelectBox.SelectedIndex;
            }


            ChangeDBInt("COCH", "CPID", GetCOCHrecFromTeamRec(TeamIndex), pbVal);
            ChangeDBInt("TEAM", "TOPB", TeamIndex, pbVal);

        }

        //Off Type Selection
        private void OffTypeSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COST", GetCOCHrecFromTeamRec(TeamIndex), OffTypeSelectBox.SelectedIndex);
        }
        //Def Type Selection

        private void DefTypeSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDST", GetCOCHrecFromTeamRec(TeamIndex), DefTypeSelectBox.SelectedIndex);
            ChangeDBInt("TEAM", "TDPB", TeamIndex, DefTypeSelectBox.SelectedIndex);
        }

        //Off Passing Strategy 
        private void TeamCOTRbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTR", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCOTRbox.Value));
        }

        //Off Aggressiveness
        private void TeamCOTAbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTA", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCOTAbox.Value));
        }

        //Off Subs
        private void TeamCOTSbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTS", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCOTSbox.Value));
        }

        //Def Passing Strategy
        private void TeamCDTRbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTR", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCDTRbox.Value));
        }

        //Def Aggessiveness
        private void TeamCDTAbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTA", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCDTAbox.Value));
        }

        //Def Subs
        private void TeamCDTSbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTS", GetCOCHrecFromTeamRec(TeamIndex), Convert.ToInt32(TeamCDTSbox.Value));
        }





        //Avg Attendance
        private void AttendanceNumBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("TEAM", "TMAA", TeamIndex, Convert.ToInt32(AttendanceNumBox.Value));
            if (AttendanceNumBox.Value > CapacityNumbox.Value)
            {
                CapacityNumbox.Value = AttendanceNumBox.Value;
                ChangeDBInt("STAD", "SCAP", FindSTADrecFromTEAMrec(TeamIndex), Convert.ToInt32(CapacityNumbox.Value));

            }

        }

        //Stadium Capacity
        private void CapacityNumbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("STAD", "SCAP", FindSTADrecFromTEAMrec(TeamIndex), Convert.ToInt32(CapacityNumbox.Value));
        }

        private void StateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("STAD", "STID", FindSTADrecFromTEAMrec(TeamIndex), StateBox.SelectedIndex);
            ChangeDBString("STAD", "SSTA", FindSTADrecFromTEAMrec(TeamIndex), Convert.ToString(StateBox.SelectedItem));

        }

        private void stadiumNameBox_Leave(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBString("STAD", "SNAM", FindSTADrecFromTEAMrec(TeamIndex), stadiumNameBox.Text);

        }

        private void CityNameBox_Leave(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBString("STAD", "SCIT", FindSTADrecFromTEAMrec(TeamIndex), CityNameBox.Text);
        }


        //Team Primary Color
        private void TeamColor1Button_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = new int[] { ColorTranslator.ToOle(primary), ColorTranslator.ToOle(secondary), };
            colorDialog1.ShowDialog();
            TeamColor1Button.BackColor = colorDialog1.Color;

            ChangeDBString("TEAM", "TFRD", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.R)));
            ChangeDBString("TEAM", "TFFG", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.G)));
            ChangeDBString("TEAM", "TFFB", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.B)));

        }

        //Team Secondary Color
        private void TeamColor2Button_Click(object sender, EventArgs e)
        {
            colorDialog1.CustomColors = new int[] { ColorTranslator.ToOle(primary), ColorTranslator.ToOle(secondary), };
            colorDialog1.ShowDialog();
            TeamColor2Button.BackColor = colorDialog1.Color;

            ChangeDBString("TEAM", "TFOR", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.R)));
            ChangeDBString("TEAM", "TFOG", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.G)));
            ChangeDBString("TEAM", "TFOB", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.B)));
        }

        //Reset Primary Color
        private void ResetPrimaryColorButton_Click(object sender, EventArgs e)
        {
            TeamColor1Button.BackColor = primary;

            ChangeDBString("TEAM", "TFRD", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.R)));
            ChangeDBString("TEAM", "TFFG", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.G)));
            ChangeDBString("TEAM", "TFFB", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor1Button.BackColor.B)));
        }

        //Reset Secondary Color
        private void ResetSecondaryColorButton_Click(object sender, EventArgs e)
        {
            TeamColor2Button.BackColor = secondary;

            ChangeDBString("TEAM", "TFOR", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.R)));
            ChangeDBString("TEAM", "TFOG", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.G)));
            ChangeDBString("TEAM", "TFOB", TeamIndex, Convert.ToString(Convert.ToDecimal(TeamColor2Button.BackColor.B)));
        }


        private void CrowdBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = TeamColorPalettes[CrowdBox.SelectedIndex][3];
            ChangeDBString("TEAM", "TCRP", TeamIndex, val);
        }

        private void CheerleaderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = TeamColorPalettes[CheerleaderBox.SelectedIndex][2];
            ChangeDBString("TEAM", "TMCP", TeamIndex, val);
        }


        //Rival Change
        private void TeamRivalBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("TEAM", "TMRV", TeamIndex, FindTGIDfromTeamName(TeamRivalBox.SelectedText));
        }

        #endregion



        //Fire Single Head Coach

        private void FireHeadCoach()
        {
            if (UserCoachCheckBox.Checked)
            {
                MessageBox.Show("User Coach cannot be fired.");
                return;
            }

            var result = MessageBox.Show("Are you sure?", "Fire Head Coach", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {

                int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);

                bool hired = false;

                while (!hired)
                {
                    int applicant = rand.Next(0, GetTableRecCount("COCH"));
                    if (GetDBValueInt("COCH", "TGID", applicant) == 511)
                    {
                        ChangeDBInt("COCH", "CCPO", GetCOCHrecFromTeamRec(TeamIndex), 60);
                        ChangeDBInt("COCH", "CTOP", GetCOCHrecFromTeamRec(TeamIndex), 0);
                        ChangeDBInt("COCH", "TGID", GetCOCHrecFromTeamRec(TeamIndex), 511);

                        ChangeDBInt("COCH", "TGID", applicant, tgid);
                        ChangeDBInt("COCH", "CCPO", applicant, 60);

                        GetTeamEditorData(TeamIndex);

                        hired = true;
                        MessageBox.Show(GetDBValue("COCH", "CLFN", applicant) + " " + GetDBValue("COCH", "CLLN", applicant) + " was hired!");

                    }
                }
            }

        }

        //Reset Impact Players
        private void ResetImpactPlayers_Click(object sender, EventArgs e)
        {
            ChangeDBInt("TEAM", "OCAP", TeamIndex, OCAPmem);
            ChangeDBInt("TEAM", "DCAP", TeamIndex, DCAPmem);

            ChangeDBInt("TEAM", "TPIO", TeamIndex, TPIOmem);
            ChangeDBInt("TEAM", "TPID", TeamIndex, TPIDmem);
            ChangeDBInt("TEAM", "TSI1", TeamIndex, TSI1mem);
            ChangeDBInt("TEAM", "TSI2", TeamIndex, TSI2mem);

            GetTeamEditorData(TeamIndex);

        }

        //Death Penalty Mode
        private void DeathPenaltyButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("The DEATH PENALTY will remove all players from the team and give a 2 year sanction period. Are you sure you want to do this?", "The Death Penalty", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                ClearTeamPlayers(GetDBValueInt("TEAM", "TGID", TeamIndex));
                ClearOldTeamStats(GetDBValueInt("TEAM", "TGID", TeamIndex));
                ChangeDBInt("TEAM", "SDUR", TeamIndex, 2);
                ChangeDBInt("TEAM", "SNCT", TeamIndex, 4);
                ChangeDBInt("TEAM", "INPO", TeamIndex, 0);
                MessageBox.Show(GetDBValue("TEAM", "TDNA", TeamIndex) + " has been hit with the Death Penalty!");
                GetTeamEditorData(TeamIndex);
            }

        }


        //Generate New Roster
        private void TeamEditorGenRoster_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("The new roster will be based on the Prestige Set.\n\nAre you sure? ", "Generate New Rosters", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                GenerateFantasyRoster(GetDBValueInt("TEAM", "TGID", TeamIndex), Convert.ToInt32(TMPRNumBox.Value));
            }
            RecalculateOverall();

            int leaguesize = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TTYP", "TEAM", i) == 0) leaguesize++;

            }
            DepthChartMakerSingle("TEAM", GetDBValueInt("TEAM", "TGID", TeamIndex), leaguesize);
            CalculateAllTeamRatings("TEAM");

            GetTeamEditorData(TeamIndex);
        }

        //Team Depth Chart

        private void TeamSetDepthChart_Click(object sender, EventArgs e)
        {
            int leaguesize = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TTYP", "TEAM", i) == 0) leaguesize++;

            }
            DepthChartMakerSingle("DCHT", GetDBValueInt("TEAM", "TGID", TeamIndex), leaguesize);
        }

        //Auto Impact 

        private void TeamAutoImpact_Click(object sender, EventArgs e)
        {
            DetermineTeamImpactPlayers(TeamIndex, 0);
            GetTeamEditorData(TeamIndex);
        }


        //Team Ratings Box

        private void LoadTeamRatingsViewer()
        {
            TeamRatingView.Rows.Clear();

            List<string> categories = LoadTeamViewRatingCats();
            List<string> teamRat = LoadTeamViewRatings(TeamIndex);

            for (int i = 0; i < categories.Count; i++)
            {
                TeamRatingView.Rows.Add(1);
                TeamRatingView.Rows[i].Cells[0].Value = categories[i];
                TeamRatingView.Rows[i].Cells[0].Style.BackColor = Color.LightGray;

                TeamRatingView.Rows[i].Cells[1].Value = teamRat[i];
                if (i == 0)
                {
                    TeamRatingView.Rows[i].DefaultCellStyle.Font = new Font(TeamRatingView.Font.FontFamily, 11, FontStyle.Bold);
                }
            }

            TeamRatingView.CellPainting += TeamRatingView_CellPainting;
            TeamRatingView.ClearSelection();
        }

        private List<string> LoadTeamViewRatingCats()
        {
            List<string> categories = new List<string>();
            categories.Add("OVR");
            categories.Add("Off");
            categories.Add("Def");
            categories.Add("ST");
            categories.Add("");
            categories.Add("QB");
            categories.Add("RB");
            categories.Add("WR");
            categories.Add("OL");
            categories.Add("DL");
            categories.Add("LB");
            categories.Add("DB");
            categories.Add("");

            return categories;
        }

        private List<string> LoadTeamViewRatings(int rec)
        {
            List<string> categories = new List<string>();

            categories.Add(GetDBValue("TEAM", "TROV", rec));
            categories.Add(GetDBValue("TEAM", "TROF", rec));
            categories.Add(GetDBValue("TEAM", "TRDE", rec));
            categories.Add(GetDBValue("TEAM", "TRST", rec));
            categories.Add("");
            categories.Add(GetDBValue("TEAM", "TRQB", rec));
            categories.Add(GetDBValue("TEAM", "TRRB", rec));
            categories.Add(GetDBValue("TEAM", "TWRR", rec));
            categories.Add(GetDBValue("TEAM", "TROL", rec));
            categories.Add(GetDBValue("TEAM", "TRDL", rec));
            categories.Add(GetDBValue("TEAM", "TRLB", rec));
            categories.Add(GetDBValue("TEAM", "TRDB", rec));
            categories.Add("");

            return categories;
        }

        private void TeamRatingView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only paint value bars for column 1
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                // Get the value as integer
                if (int.TryParse(Convert.ToString(e.FormattedValue), out int value))
                {
                    // Define min/max for the bar (adjust as needed)
                    int min = 40;
                    int max = 99;

                    // Calculate bar width
                    int barWidth = (int)((e.CellBounds.Width - 2) * (value - min) / (float)(max - min));
                    barWidth = Math.Max(0, Math.Min(barWidth, e.CellBounds.Width - 2));

                    Color col = GetColorRating(value);


                    // Draw the bar
                    Rectangle barRect = new Rectangle(e.CellBounds.X + 0, e.CellBounds.Y + 1, barWidth, e.CellBounds.Height - 1);
                    using (Brush b = new SolidBrush(col))
                    {
                        e.Graphics.FillRectangle(b, barRect);
                    }

                    // Draw the value as text on top of the bar
                    TextRenderer.DrawText(
                        e.Graphics,
                        value.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        Color.Black,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                    );
                }
            }
        }

        //Top Players Viewer

        private void LoadTopPlayersViewer()
        {
            int ttyp = GetDBValueInt("TEAM", "TTYP", TeamIndex);

            TopPlayersView.Rows.Clear();
            if(GetTableRecCount("PLAY") < 1 || ttyp > 0)
            {
                TopPlayersView.ClearSelection();
                return;
            }

            int tgid = GetDBValueInt("TEAM", "TGID", TeamIndex);

            int pgidBeg = tgid * 70;
            int pgidEnd = tgid * 70 + 69;

            List<List<string>> PlayerList = new List<List<string>>();

            int row = 0;
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd)
                {
                    int PlayerPOSG2 = GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i));
                    PlayerList.Add(new List<string>());
                    PlayerList[row].Add(GetFirstNameFromRecord(i));
                    PlayerList[row].Add(GetLastNameFromRecord(i));
                    PlayerList[row].Add(GetPOSG2Name(PlayerPOSG2));
                    PlayerList[row].Add(Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", i))));
                    PlayerList[row].Add(Convert.ToString(i));
                    row++;
                }
            }

            PlayerList.Sort((player1, player2) => Convert.ToInt32(player2[3]).CompareTo(Convert.ToInt32(player1[3])));

            for(int i = 0; i < 11; i++)
            {
                TopPlayersView.Rows.Add(1);
                TopPlayersView.Rows[i].Cells[0].Value = PlayerList[i][2];
                TopPlayersView.Rows[i].Cells[1].Value = PlayerList[i][0] + " " + PlayerList[i][1];
                TopPlayersView.Rows[i].Cells[2].Value = PlayerList[i][3];
                TopPlayersView.Rows[i].Cells[2].Style.BackColor = GetColorRating(Convert.ToInt32(TopPlayersView.Rows[i].Cells[2].Value));
                TopPlayersView.Rows[i].Cells[3].Value = PlayerList[i][4];
            }

            TopPlayersView.Rows.Add(1);
            TopPlayersView.ClearSelection();
        }

        private void TopPlayersView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;

            if (cell == 1)
            {
                int PLAYrec = Convert.ToInt32(TopPlayersView.Rows[row].Cells[3].Value);

                PlayerIndex = PLAYrec;
                tabControl1.SelectedTab = tabPlayers;
                LoadPlayerData();
            }

        }


    }
}
    

