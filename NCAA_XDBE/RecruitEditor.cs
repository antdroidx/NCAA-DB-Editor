using System.Reflection;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        #region RECRUIT EDITOR

        public void StartRecruitEditor()
        {
            DoNotTrigger = true;
            CompactDB2();
            AddFilters();
            LoadCommittedToBox();
            LoadTransferTeamBox();
            LoadRCPTBox();

            DoNotTrigger = false;
        }

        public void LoadRCPTBox()
        {
            RecruitEditorList = new List<List<string>>();

            int TGID = -1;
            List<List<int>> RCWK = new List<List<int>>();

            if (RecruitTeamComboBox.SelectedIndex > 0)
            {
                TGID = FindTGIDfromTeamName(RecruitTeamComboBox.Text);
            }
            else if (TransferTeamComboBox.SelectedIndex > 0)
            {
                TGID = FindTGIDfromTeamName(TransferTeamComboBox.Text);
            }
            else if (TeamInterestComboBox.SelectedIndex > 0)
            {
                TGID = FindTGIDfromTeamName(TeamInterestComboBox.Text);
            }
            else if (TargetedByComboBox.SelectedIndex > 0)
            {
                TGID = FindTGIDfromTeamName(TargetedByComboBox.Text);

                for (int i = 0; i < GetTable2RecCount("RCWK"); i++)
                {
                    RCWK.Add(new List<int>());
                    RCWK[i].Add(GetDB2ValueInt("RCWK", "TGID", i));
                    RCWK[i].Add(GetDB2ValueInt("RCWK", "PRID", i));
                }
            }

            int row = 0;
            for (int i = 0; i < GetTable2RecCount("RCPT"); i++)
            {
                int PRID = GetDB2ValueInt("RCPT", "PRID", i);
                int POSG = GetPOSGfromPPOS(GetDB2ValueInt("RCPT", "PPOS", i));
                int STID = GetDB2ValueInt("RCPT", "STID", i);
                int RATH = GetDB2ValueInt("RCPT", "RATH", i);
                int PTCM = GetDB2ValueInt("RCPR", "PTCM", i);
                int PTID = -1;
                bool interest = false;

                //Transfer Team Load
                if (PRID >= 21000 && TransferTeamComboBox.SelectedIndex > 0)
                {
                    for (int t = 0; t < GetTableRecCount("TRAN"); t++)
                    {
                        if (GetDBValueInt("TRAN", "PGID", t) == PRID)
                        {
                            PTID = GetDBValueInt("TRAN", "PTID", t);
                            break;
                        }
                    }
                }
                //Team Interest Load
                else if (TeamInterestComboBox.SelectedIndex > 0 && PTCM == 511 || PTCM == TGID)
                {
                    for (int j = 1; j < 11; j++)
                    {
                        if (j < 10)
                        {
                            int teamID = GetDB2ValueInt("RCPR", "PT0" + j, i);
                            if (TGID == teamID) interest = true;

                        }
                        else
                        {
                            int teamID = GetDB2ValueInt("RCPR", "PT" + j, i);
                            if (TGID == teamID) interest = true;
                        }
                    }
                }
                //Team Targets Load
                else if (TargetedByComboBox.SelectedIndex > 0 || PTCM == TGID)
                {
                    if (PTCM == TGID)
                    {
                        interest = true;
                    }
                    else
                    {
                        //ADD CODE
                        for (int t = 0; t < RCWK.Count; t++)
                        {
                            int teamID = RCWK[t][0];
                            int prid = RCWK[t][1];
                            if (PRID == prid && teamID == TGID)
                            {
                                interest = true;
                                break;
                            }
                        }
                    }
                }



                //Load the Boxes

                if (RecruitTypeFilter.SelectedIndex == 0 || RecruitTypeFilter.SelectedIndex == 1 && PRID < 21000 || RecruitTypeFilter.SelectedIndex == 2 && PRID >= 21000)
                {
                    if (TGID == -1 || PTCM == TGID && RecruitTeamComboBox.SelectedIndex > 0 || PTID == TGID && TransferTeamComboBox.SelectedIndex > 0 || interest && TeamInterestComboBox.SelectedIndex > 0 || interest && TargetedByComboBox.SelectedIndex > 0)
                    {
                        if (RecruitStateFilter.SelectedIndex == 0 || RecruitStateFilter.SelectedIndex - 1 == STID)
                        {
                            if (RecruitPosFilter.SelectedIndex == 0 || RecruitPosFilter.SelectedIndex - 2 == POSG || RecruitPosFilter.SelectedIndex == 1 && RATH == 1)
                            {
                                RecruitEditorList.Add(new List<string>());
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "PFNA", i));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "PLNA", i));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "PPOS", i));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "POVR", i));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "PRID", i));
                                RecruitEditorList[row].Add(Convert.ToString(i));
                                RecruitEditorList[row].Add(Convert.ToString(GetPOSGfromPPOS(GetDB2ValueInt("RCPT", "PPOS", i))));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "RATH", i)); //7
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "RCCB", i));
                                RecruitEditorList[row].Add(GetDB2Value("RCPT", "STID", i));

                                // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec
                                row++;
                            }
                        }
                    }

                }



            }

            RecruitEditorList.Sort((player1, player2) => Convert.ToInt32(player2[3]).CompareTo(Convert.ToInt32(player1[3])));


            RecruitListBox.Items.Clear();
            foreach (var player in RecruitEditorList)
            {
                string ath = "";
                if (Convert.ToInt32(player[7]) == 1) ath = " @";

                string transfer = "";
                if (Convert.ToInt32(player[4]) > 20000) transfer = " +";

                string rating = " (" + ConvertRating(Convert.ToInt32(player[3])) + ")";

                string text = "[" + GetPositionName(Convert.ToInt32(player[2])) + "] " + player[0] + " " + player[1] + rating + ath + transfer;
                if (Convert.ToInt32(player[4]) >= 21000)
                {
                    //text += " (T)";
                }
                RecruitListBox.Items.Add(text);
            }

            RecruitCounter.Text = "Recruit Count: " + row;
        }

        private ComboBox RecruitTeams()
        {
            ComboBox comboBox = new ComboBox();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0) comboBox.Items.Add(GetDBValue("TEAM", "TDNA", i));
            }

            return comboBox;
        }

        private void UpdateRecruitOffers_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < RecruitDataGrid.Rows.Count; i++)
            {
                int tgid = FindTGIDfromTeamName(Convert.ToString(RecruitDataGrid.Rows[i].Cells[1].Value));
                ChangeDB2Int("RCPR", "PT" + AddLeadingZeros(Convert.ToString(i + 1), 2), RecruitIndex, tgid);

                ChangeDB2Int("RCPR", "PS" + AddLeadingZeros(Convert.ToString(i + 1), 2), RecruitIndex, Convert.ToInt32(RecruitDataGrid.Rows[i].Cells[2].Value));
            }

            MessageBox.Show("Recruiting Table Updated!");
        }

        private void LoadCommittedToBox()
        {
            if (RecruitTeamComboBox.Items.Count > 0) return;


            RecruitTeamComboBox.Items.Clear();
            TeamInterestComboBox.Items.Clear();
            TargetedByComboBox.Items.Clear();

            List<string> teamList = new List<string>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                    teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
            }

            teamList.Sort();
            teamList.Insert(0, "ALL PLAYERS");

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null)
                {
                    RecruitTeamComboBox.Items.Add(teamList[i]);
                    TeamInterestComboBox.Items.Add(teamList[i]);
                    TargetedByComboBox.Items.Add(teamList[i]);
                }
            }

            RecruitTeamComboBox.SelectedIndex = 0;
            TeamInterestComboBox.SelectedIndex = 0;
            TargetedByComboBox.SelectedIndex = 0;
        }

        private void LoadTransferTeamBox()
        {
            if (TransferTeamComboBox.Items.Count > 0) return;
            TransferTeamComboBox.Items.Clear();
            List<string> teamList = new List<string>();

            for (int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                if (!teamList.Contains(teamNameDB[GetDBValueInt("TRAN", "PTID", i)]))
                    teamList.Add(teamNameDB[GetDBValueInt("TRAN", "PTID", i)]);
            }

            teamList.Sort();
            teamList.Insert(0, "ALL PLAYERS");

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) TransferTeamComboBox.Items.Add(teamList[i]);
            }

            TransferTeamComboBox.SelectedIndex = 0;
        }


        //Filters

        private void AddFilters()
        {
            if (RecruitTypeFilter.Items.Count > 0) return;

            RecruitTypeFilter.Items.Clear();
            RecruitStateFilter.Items.Clear();
            RecruitPosFilter.Items.Clear();

            //Type
            RecruitTypeFilter.Items.Add("ALL");
            RecruitTypeFilter.Items.Add("Recruits");
            RecruitTypeFilter.Items.Add("Transfers");

            //State
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);

            RecruitStateFilter.Items.Add("ALL");
            foreach (string state in states)
            {
                RecruitStateFilter.Items.Add(state);
            }

            //Positions
            RecruitPosFilter.Items.Add("ALL");
            RecruitPosFilter.Items.Add("ATH");

            for (int i = 0; i < 10; i++)
            {
                RecruitPosFilter.Items.Add(GetPOSGName(i));
            }

            RecruitTypeFilter.SelectedIndex = 0;
            RecruitStateFilter.SelectedIndex = 0;
            RecruitPosFilter.SelectedIndex = 0;
        }

        private void RecruitTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            LoadRCPTBox();
        }

        private void RecruitStateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            LoadRCPTBox();
        }

        private void RecruitPosFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            LoadRCPTBox();
        }

        private void RecruitTeamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            DoNotTrigger = true;

            TransferTeamComboBox.SelectedIndex = 0;
            TeamInterestComboBox.SelectedIndex = 0;
            TargetedByComboBox.SelectedIndex = 0;

            LoadRCPTBox();
            DoNotTrigger = false;

        }

        private void TransferTeamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            DoNotTrigger = true;

            RecruitTeamComboBox.SelectedIndex = 0;
            TeamInterestComboBox.SelectedIndex = 0;
            TargetedByComboBox.SelectedIndex = 0;

            LoadRCPTBox();
            DoNotTrigger = false;

        }

        private void TeamInterestComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            DoNotTrigger = true;

            TransferTeamComboBox.SelectedIndex = 0;
            RecruitTeamComboBox.SelectedIndex = 0;
            TargetedByComboBox.SelectedIndex = 0;

            LoadRCPTBox();
            DoNotTrigger = false;
        }


        private void TargetedBycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            DoNotTrigger = true;

            TransferTeamComboBox.SelectedIndex = 0;
            RecruitTeamComboBox.SelectedIndex = 0;
            TeamInterestComboBox.SelectedIndex = 0;

            LoadRCPTBox();
            DoNotTrigger = false;
        }


        #region Add Items

        private void AddRPositionsItems()
        {
            RPPOSBox.Items.Clear();
            foreach (var p in Positions.Values)
            {
                RPPOSBox.Items.Add(p);
            }
        }

        private void AddRYearItems()
        {
            RYER.Items.Clear();
            List<string> classes = CreateClassYears();
            foreach (var x in classes)
            {
                RYER.Items.Add(x);
            }
        }

        private void AddRSkinColorItems()
        {
            RSKIBox.Items.Clear();
            List<string> skin = CreateSkinColorDB();
            foreach (var x in skin)
            {
                RSKIBox.Items.Add(x);
            }
        }

        private void AddRFaceShapeItems()
        {
            RFGMBox.Items.Clear();

            for (int i = 0; i < 16; i++)
            {
                RFGMBox.Items.Add(i);
            }
        }

        private void AddRFaceItems()
        {
            RFMPBox.Items.Clear();

            int skin = GetDB2ValueInt("RCPT", "PSKI", RecruitIndex);

            for (int i = 0; i < 8; i++)
            {
                RFMPBox.Items.Add(skin * 8 + i);
            }
        }

        private void AddRHairColorItems()
        {
            RHCLBox.Items.Clear();
            List<string> hair = CreatePHCL();
            foreach (var x in hair)
            {
                RHCLBox.Items.Add(x);
            }
        }

        private void AddRHairStyleItems()
        {
            RHEDBox.Items.Clear();
            List<string> hair = CreateHair();
            foreach (var x in hair)
            {
                RHEDBox.Items.Add(x);
            }
        }

        private void AddRStateItems()
        {
            RStateBox.Items.Clear();
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);

            foreach (string state in states)
            {
                RStateBox.Items.Add(state);
            }
        }

        private void AddRHometownItems()
        {
            RHometownBox.Items.Clear();
            string[] home = new string[13057];

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\RCHT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                home[Convert.ToInt32(Line[0])] = Line[1];

            }
            sr.Close();


            int start = RStateBox.SelectedIndex * 256;
            for (int i = start; i < start + 256; i++)
            {
                if (i >= home.Length) break;
                if (home[i] == null) break;
                RHometownBox.Items.Add(home[i]);
            }
        }




        #endregion



        //Player Selection
        private void RecruitListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RecruitListBox.SelectedIndex == -1)
                return;

            RecruitIndex = Convert.ToInt32(RecruitEditorList[RecruitListBox.SelectedIndex][5]);

            LoadRecruitData();
        }

        private void LoadRecruitData()
        {
            DoNotTrigger = true;


            //Player Name
            PFNABox.Text = GetDB2Value("RCPT", "PFNA", RecruitIndex);
            PLNABox.Text = GetDB2Value("RCPT", "PLNA", RecruitIndex);

            //Position
            AddRPositionsItems();
            RPPOSBox.SelectedIndex = GetDB2ValueInt("RCPT", "PPOS", RecruitIndex);

            //Home
            int home = GetDB2ValueInt("RCPT", "RCHD", RecruitIndex);
            int state = home / 256;
            AddRStateItems();
            RStateBox.SelectedIndex = state;

            AddRHometownItems();
            if (home - (state * 256) > RHometownBox.Items.Count)
            {
                home = state * 256 + rand.Next(0, RHometownBox.Items.Count - 1);
                ChangeDB2Int("RCPT", "RCHD", RecruitIndex, home);
            }
            RHometownBox.SelectedIndex = home - (state * 256);

            //Transfer Status
            string transfer = "";
            if (GetDB2ValueInt("RCPT", "PRID", RecruitIndex) >= 21000)
            {
                int prid = GetDB2ValueInt("RCPT", "PRID", RecruitIndex);
                for (int i = 0; i < GetTableRecCount("TRAN"); i++)
                {
                    if (GetDBValueInt("TRAN", "PGID", i) == prid)
                    {
                        transfer = teamNameDB[GetDBValueInt("TRAN", "PTID", i)];
                        break;
                    }
                }
            }

            //Overall Rating
            int xxx = GetDB2ValueInt("RCPT", "POVR", RecruitIndex);
            ROVR.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "POVR", RecruitIndex)));
            ROVR.BackColor = GetColorRating(Convert.ToInt32(ROVR.Text));

            if (GetDB2ValueInt("RCPT", "PRID", RecruitIndex) < 21000)
                RecruitStarsText.Text = GetDB2Value("RCPT", "RCCB", RecruitIndex) + " Star Recruit";
            else RecruitStarsText.Text = GetDB2Value("RCPT", "RCCB", RecruitIndex) + " Star Transfer" + " from " + transfer;

            PosRanking.Text = "Position Ranking: #" + (GetDB2ValueInt("RCPT", "RCRK", RecruitIndex) + 1);

            //PGID Box
            PRIDBox.Text = GetDB2Value("RCPT", "PRID", RecruitIndex);

            //Year & Redshirt
            AddRYearItems();
            RYER.SelectedIndex = GetDB2ValueInt("RCPT", "PYER", RecruitIndex);

            //Height & Weight
            RHGTBox.Value = GetDB2ValueInt("RCPT", "PHGT", RecruitIndex);
            RWGTBox.Value = GetDB2ValueInt("RCPT", "PWGT", RecruitIndex) + 160;

            //Hand
            RHAN.SelectedIndex = GetDB2ValueInt("RCPT", "PHAN", RecruitIndex);

            //Head Appearance
            AddRSkinColorItems();
            AddRFaceShapeItems();
            AddRFaceItems();
            AddRHairColorItems();
            AddRHairStyleItems();

            RSKIBox.SelectedIndex = GetDB2ValueInt("RCPT", "PSKI", RecruitIndex);
            RFGMBox.SelectedIndex = GetDB2ValueInt("RCPT", "PFGM", RecruitIndex);
            RFMPBox.SelectedIndex = GetDB2ValueInt("RCPT", "PFMP", RecruitIndex) % 8;
            RHCLBox.SelectedIndex = GetDB2ValueInt("RCPT", "PHCL", RecruitIndex);
            RHEDBox.SelectedIndex = GetDB2ValueInt("RCPT", "PHED", RecruitIndex);

            //Athlete
            if (GetDB2ValueInt("RCPT", "RATH", RecruitIndex) == 1) AthleteBox.Checked = true;
            else AthleteBox.Checked = false;


            //Commitment Status
            CommitStatus.Checked = false;
            CommitStatus.ForeColor = Color.IndianRed;


            int rec = FindRCPRRecfromPRID(GetDB2ValueInt("RCPT", "PRID", RecruitIndex));
            int team = GetDB2ValueInt("RCPR", "PTCM", rec);

            if (team == 511) CommitStatus.Text = "Uncommitted";
            else
            {
                CommitStatus.Text = "Committed to " + teamNameDB[team];
                CommitStatus.Checked = true;
                CommitStatus.ForeColor = Color.Green;
            }



            //Attributes

            //Discipline
            RDIS.Value = GetDB2ValueInt("RCPT", "PDIS", RecruitIndex);
            RDIS.BackColor = GetPrestigeColor(RDIS.Value);


            //Potential
            RPOEBox.Value = GetDB2ValueInt("RCPT", "PPOE", RecruitIndex);
            RPOEtext.Text = Convert.ToString(ConvertPotentialRating(Convert.ToInt32(RPOEBox.Value)));
            RPOEtext.BackColor = GetColorRating(Convert.ToInt32(RPOEtext.Text));

            //Injury
            RINJBox.Maximum = maxRatingVal;
            RINJBox.Value = GetDB2ValueInt("RCPT", "PINJ", RecruitIndex);
            RINJtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RINJBox.Value)));
            RINJtext.BackColor = GetColorRating(Convert.ToInt32(RINJtext.Text));

            //Stamina
            RSTAbox.Maximum = maxRatingVal;
            RSTAbox.Value = GetDB2ValueInt("RCPT", "PSTA", RecruitIndex);
            RSTAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RSTAbox.Value)));
            RSTAtext.BackColor = GetColorRating(Convert.ToInt32(RSTAtext.Text));


            //Awareness
            RAWRBox.Maximum = maxRatingVal;
            RAWRBox.Value = GetDB2ValueInt("RCPT", "PAWR", RecruitIndex);
            RAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RAWRBox.Value)));
            RAWRtext.BackColor = GetColorRating(Convert.ToInt32(RAWRtext.Text));

            //Speed
            RSPDBox.Maximum = maxRatingVal;
            RSPDBox.Value = GetDB2ValueInt("RCPT", "PSPD", RecruitIndex);
            RSPDtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RSPDBox.Value)));
            RSPDtext.BackColor = GetColorRating(Convert.ToInt32(RSPDtext.Text));

            //Agility
            RAGIBox.Maximum = maxRatingVal;
            RAGIBox.Value = GetDB2ValueInt("RCPT", "PAGI", RecruitIndex);
            RAGItext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RAGIBox.Value)));
            RAGItext.BackColor = GetColorRating(Convert.ToInt32(RAGItext.Text));

            //Acceleration
            RACCBox.Maximum = maxRatingVal;
            RACCBox.Value = GetDB2ValueInt("RCPT", "PACC", RecruitIndex);
            RACCtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RACCBox.Value)));
            RACCtext.BackColor = GetColorRating(Convert.ToInt32(RACCtext.Text));

            //Jumping
            RJMPBox.Maximum = maxRatingVal;
            RJMPBox.Value = GetDB2ValueInt("RCPT", "PJMP", RecruitIndex);
            RJMPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RJMPBox.Value)));
            RJMPtext.BackColor = GetColorRating(Convert.ToInt32(RJMPtext.Text));

            //Strength
            RSTRBox.Maximum = maxRatingVal;
            RSTRBox.Value = GetDB2ValueInt("RCPT", "PSTR", RecruitIndex);
            RSTRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RSTRBox.Value)));
            RSTRtext.BackColor = GetColorRating(Convert.ToInt32(RSTRtext.Text));

            //Throw Rower
            RTHPBox.Maximum = maxRatingVal;
            RTHPBox.Value = GetDB2ValueInt("RCPT", "PTHP", RecruitIndex);
            RTHPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTHPBox.Value)));
            RTHPtext.BackColor = GetColorRating(Convert.ToInt32(RTHPtext.Text));

            //Throw Accuracy
            RTHABox.Maximum = maxRatingVal;
            RTHABox.Value = GetDB2ValueInt("RCPT", "PTHA", RecruitIndex);
            RTHAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTHABox.Value)));
            RTHAtext.BackColor = GetColorRating(Convert.ToInt32(RTHAtext.Text));

            //Break Tackle
            RBTKBox.Maximum = maxRatingVal;
            RBTKBox.Value = GetDB2ValueInt("RCPT", "PBTK", RecruitIndex);
            RBTKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RBTKBox.Value)));
            RBTKtext.BackColor = GetColorRating(Convert.ToInt32(RBTKtext.Text));

            //Ball Carry
            RCARBox.Maximum = maxRatingVal;
            RCARBox.Value = GetDB2ValueInt("RCPT", "PCAR", RecruitIndex);
            RCARtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RCARBox.Value)));
            RCARtext.BackColor = GetColorRating(Convert.ToInt32(RCARtext.Text));

            //Run Blocking
            RRBKBox.Maximum = maxRatingVal;
            RRBKBox.Value = GetDB2ValueInt("RCPT", "PRBK", RecruitIndex);
            RRBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RRBKBox.Value)));
            RRBKtext.BackColor = GetColorRating(Convert.ToInt32(RRBKtext.Text));

            //Pass Blocking
            RPBKBox.Maximum = maxRatingVal;
            RPBKBox.Value = GetDB2ValueInt("RCPT", "PRBK", RecruitIndex);
            RPBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RPBKBox.Value)));
            RPBKtext.BackColor = GetColorRating(Convert.ToInt32(RPBKtext.Text));

            //Catching
            RCTHBox.Maximum = maxRatingVal;
            RCTHBox.Value = GetDB2ValueInt("RCPT", "PCTH", RecruitIndex);
            RCTHtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RCTHBox.Value)));
            RCTHtext.BackColor = GetColorRating(Convert.ToInt32(RCTHtext.Text));

            //Tackling
            RTAKBox.Maximum = maxRatingVal;
            RTAKBox.Value = GetDB2ValueInt("RCPT", "PTAK", RecruitIndex);
            RTAKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTAKBox.Value)));
            RTAKtext.BackColor = GetColorRating(Convert.ToInt32(RTAKtext.Text));

            //Kick Rower
            RKPRBox.Maximum = maxRatingVal;
            RKPRBox.Value = GetDB2ValueInt("RCPT", "PKPR", RecruitIndex);
            RKPRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RKPRBox.Value)));
            RKPRtext.BackColor = GetColorRating(Convert.ToInt32(RKPRtext.Text));

            //Kick Accuracy
            RKACBox.Maximum = maxRatingVal;
            RKACBox.Value = GetDB2ValueInt("RCPT", "PKAC", RecruitIndex);
            RKACtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RKACBox.Value)));
            RKACtext.BackColor = GetColorRating(Convert.ToInt32(RKACtext.Text));

            //Rlayer Tendency/Archeatype
            RTENBox.Text = GetPTENType(GetDB2ValueInt("RCPT", "PROS", RecruitIndex), GetDB2ValueInt("RCPT", "PTEN", RecruitIndex));



            //POCI CHECK
            int Pos = GetDBValueInt("RCPT", "PPOS", PlayerIndex);
            // PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR

            if (POCI[Pos, 3] > 0) RCARlabel.ForeColor = Color.DarkSlateBlue;
            else RCARlabel.ForeColor = Color.Black;

            if (POCI[Pos, 4] > 0) RKAClabel.ForeColor = Color.DarkSlateBlue;
            else RKAClabel.ForeColor = Color.Black;

            if (POCI[Pos, 5] > 0) RTHAlabel.ForeColor = Color.DarkSlateBlue;
            else RTHAlabel.ForeColor = Color.Black;

            if (POCI[Pos, 6] > 0) RRBKlabel.ForeColor = Color.DarkSlateBlue;
            else RRBKlabel.ForeColor = Color.Black;

            if (POCI[Pos, 7] > 0) RRBKlabel.ForeColor = Color.DarkSlateBlue;
            else RRBKlabel.ForeColor = Color.Black;

            if (POCI[Pos, 8] > 0) RACClabel.ForeColor = Color.DarkSlateBlue;
            else RACClabel.ForeColor = Color.Black;

            if (POCI[Pos, 9] > 0) RAGIlabel.ForeColor = Color.DarkSlateBlue;
            else RAGIlabel.ForeColor = Color.Black;

            if (POCI[Pos, 10] > 0) RTAKlabel.ForeColor = Color.DarkSlateBlue;
            else RTAKlabel.ForeColor = Color.Black;

            if (POCI[Pos, 12] > 0) RKPRlabel.ForeColor = Color.DarkSlateBlue;
            else RKPRlabel.ForeColor = Color.Black;

            if (POCI[Pos, 13] > 0) RSPDlabel.ForeColor = Color.DarkSlateBlue;
            else RSPDlabel.ForeColor = Color.Black;

            if (POCI[Pos, 14] > 0) RTHPlabel.ForeColor = Color.DarkSlateBlue;
            else RTHPlabel.ForeColor = Color.Black;

            if (POCI[Pos, 15] > 0) RBTKlabel.ForeColor = Color.DarkSlateBlue;
            else RBTKlabel.ForeColor = Color.Black;

            if (POCI[Pos, 16] > 0) RCTHlabel.ForeColor = Color.DarkSlateBlue;
            else RCTHlabel.ForeColor = Color.Black;

            if (POCI[Pos, 17] > 0) RSTRlabel.ForeColor = Color.DarkSlateBlue;
            else RSTRlabel.ForeColor = Color.Black;

            if (POCI[Pos, 18] > 0) RJMPlabel.ForeColor = Color.DarkSlateBlue;
            else RJMPlabel.ForeColor = Color.Black;

            if (POCI[Pos, 19] > 0) RAWRlabel.ForeColor = Color.DarkSlateBlue;
            else RAWRlabel.ForeColor = Color.Black;


            LoadRecruitingTable();
            LoadScholarshipOffersView();

            RecruitPitch.Text = "Favorite Pitch: " + GetRecruitPitch(GetDB2ValueInt("RCPR", "PIT1", RecruitIndex));



            DoNotTrigger = false;
        }


        #endregion


        #region Triggers

        //Ratings
        private void RDIS_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PDIS", RecruitIndex, Convert.ToInt32(RDIS.Value));
            RDIS.BackColor = GetPrestigeColor(RDIS.Value);

        }

        private void RINJBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PINJ", RecruitIndex, Convert.ToInt32(RINJBox.Value));
            RINJtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PINJ", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RINJBox.BackColor = GetColorRating(Convert.ToInt32(RINJtext.Text));
        }

        private void RSPDBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PSPD", RecruitIndex, Convert.ToInt32(RSPDBox.Value));
            RSPDtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PSPD", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RSPDBox.BackColor = GetColorRating(Convert.ToInt32(RSPDtext.Text));
        }

        private void RACCBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PACC", RecruitIndex, Convert.ToInt32(RACCBox.Value));
            RACCtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PACC", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RACCBox.BackColor = GetColorRating(Convert.ToInt32(RACCtext.Text));
        }

        private void RSTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PSTR", RecruitIndex, Convert.ToInt32(RSTRBox.Value));
            RSTRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PSTR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RSTRBox.BackColor = GetColorRating(Convert.ToInt32(RSTRtext.Text));
        }

        private void RTHPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTHP", RecruitIndex, Convert.ToInt32(RTHPBox.Value));
            RTHPtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTHP", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTHPBox.BackColor = GetColorRating(Convert.ToInt32(RTHPtext.Text));
        }

        private void RBTKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PBTK", RecruitIndex, Convert.ToInt32(RBTKBox.Value));
            RBTKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PINJ", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RBTKBox.BackColor = GetColorRating(Convert.ToInt32(RBTKtext.Text));
        }

        private void RRBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PRBK", RecruitIndex, Convert.ToInt32(RRBKBox.Value));
            RRBKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PRBK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RRBKBox.BackColor = GetColorRating(Convert.ToInt32(RRBKtext.Text));
        }

        private void RCTHBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PCTH", RecruitIndex, Convert.ToInt32(RCTHBox.Value));
            RCTHtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PCTH", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RCTHBox.BackColor = GetColorRating(Convert.ToInt32(RCTHtext.Text));
        }

        private void RKPRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PKPR", RecruitIndex, Convert.ToInt32(RKPRBox.Value));
            RKPRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PKPR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RKPRBox.BackColor = GetColorRating(Convert.ToInt32(RKPRtext.Text));
        }

        private void RPOEBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PPOE", RecruitIndex, Convert.ToInt32(RPOEBox.Value));
            RPOEtext.Text = Convert.ToString(ConvertPotentialRating(GetDB2ValueInt("RCPT", "PPOE", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RPOEBox.BackColor = GetColorRating(Convert.ToInt32(RPOEtext.Text));

        }

        private void RAWRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PAWR", RecruitIndex, Convert.ToInt32(RAWRBox.Value));
            RAWRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PAWR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RAWRBox.BackColor = GetColorRating(Convert.ToInt32(RAWRtext.Text));
        }

        private void RAGIBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PAGI", RecruitIndex, Convert.ToInt32(RAGIBox.Value));
            RAGItext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PAGI", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RAGIBox.BackColor = GetColorRating(Convert.ToInt32(RAGItext.Text));
        }

        private void RJMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PJMP", RecruitIndex, Convert.ToInt32(RJMPBox.Value));
            RJMPtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PJMP", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RJMPBox.BackColor = GetColorRating(Convert.ToInt32(RJMPtext.Text));
        }

        private void RTHABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTHA", RecruitIndex, Convert.ToInt32(RTHABox.Value));
            RTHAtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTHA", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTHABox.BackColor = GetColorRating(Convert.ToInt32(RTHAtext.Text));
        }

        private void RCARBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PCAR", RecruitIndex, Convert.ToInt32(RCARBox.Value));
            RCARtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PCAR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RCARBox.BackColor = GetColorRating(Convert.ToInt32(RCARtext.Text));
        }

        private void RPBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PPBK", RecruitIndex, Convert.ToInt32(RPBKBox.Value));
            RPBKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PPBK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RPBKBox.BackColor = GetColorRating(Convert.ToInt32(RPBKtext.Text));
        }

        private void RTAKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTAK", RecruitIndex, Convert.ToInt32(RTAKBox.Value));
            RTAKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTAK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTAKBox.BackColor = GetColorRating(Convert.ToInt32(RTAKtext.Text));
        }

        private void RKACBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PKAC", RecruitIndex, Convert.ToInt32(RKACBox.Value));
            RKACtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PKAC", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RKACBox.BackColor = GetColorRating(Convert.ToInt32(RKACtext.Text));
        }





        //Change Name

        private void PFNABox_Leave(object sender, EventArgs e)
        {
            if (RecruitListBox.Items.Count < 1)
                return;

            ChangeDB2String("RCPT", "PFNA", RecruitIndex, PFNABox.Text);
            LoadRCPTBox();
        }

        private void PLNABox_Leave(object sender, EventArgs e)
        {
            if (RecruitListBox.Items.Count < 1)
                return;

            ChangeDB2String("RCPT", "PLNA", RecruitIndex, PLNABox.Text);
            LoadRCPTBox();
        }

        //Change Position
        private void RPPOSBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            int pos = RPPOSBox.SelectedIndex;

            ChangeDB2Int("RCPT", "PPOS", RecruitIndex, pos);
            LoadRCPTBox();
            DisplayNewRCPTOverallRating();
            DoNotTrigger = false;
        }

        //Change YER
        private void RYER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PYER", RecruitIndex, RYER.SelectedIndex);

            DoNotTrigger = false;
        }

        //Change State
        private void RStateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "STID", RecruitIndex, RStateBox.SelectedIndex);
            AddRHometownItems();
            RHometownBox.SelectedIndex = rand.Next(0, RHometownBox.Items.Count);

            DoNotTrigger = false;
        }

        //Home

        //Change HT
        private void RHometownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;
            int hometown = RHometownBox.SelectedIndex + (256 * RStateBox.SelectedIndex);

            ChangeDB2Int("RCPT", "RCHD", RecruitIndex, hometown);
        }

        //Change Height/Weight
        private void RHGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PHGT", RecruitIndex, Convert.ToInt32(RHGTBox.Value));
            RecalculateRecruitIndividualBodyShape(RecruitIndex);
        }

        private void RWGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PWGT", RecruitIndex, Convert.ToInt32(RWGTBox.Value) - 160);
            RecalculateRecruitIndividualBodyShape(RecruitIndex);
        }

        //Change Hand
        private void RHAN_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PHAN", RecruitIndex, RHAN.SelectedIndex);
        }

        //Change Face
        private void RSKIBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PSKI", RecruitIndex, RSKIBox.SelectedIndex);
            AddFaceItems();
            RFMPBox.SelectedIndex = GetDB2ValueInt("RCPT", "PFMP", RecruitIndex) % 8;
            ChangeDB2Int("RCPT", "PFMP", RecruitIndex, RSKIBox.SelectedIndex * 8 + RFMPBox.SelectedIndex);
        }

        private void RFGMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PFGM", RecruitIndex, RFGMBox.SelectedIndex);
        }

        private void RFMPBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PFMP", RecruitIndex, RSKIBox.SelectedIndex * 8 + RFMPBox.SelectedIndex);
        }

        private void RHCLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)

                ChangeDB2Int("RCPT", "PHCL", RecruitIndex, RHCLBox.SelectedIndex);
        }

        private void RHEDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PHED", RecruitIndex, RHEDBox.SelectedIndex);
        }

        private void AthleteBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AthleteBox.Checked) ChangeDB2Int("RCPT", "RATH", RecruitIndex, 1);
            else ChangeDB2Int("RCPT", "RATH", RecruitIndex, 0);

        }

        #endregion



        #region Recruiting Table
        private void LoadRecruitingTable()
        {
            RecruitDataGrid.Rows.Clear();
            RCTeam.DataSource = RecruitTeams().Items;

            for (int i = 1; i < 11; i++)
            {
                RecruitDataGrid.Rows.Add(new DataGridViewRow());

                RecruitDataGrid.Rows[i - 1].Cells[0].Value = i;

                //team data
                int team = GetDB2ValueInt("RCPR", "PT" + AddLeadingZeros(Convert.ToString(i), 2), RecruitIndex);
                RecruitDataGrid.Rows[i - 1].Cells[1].Value = teamNameDB[team];

                //team score
                int score = GetDB2ValueInt("RCPR", "PS" + AddLeadingZeros(Convert.ToString(i), 2), RecruitIndex);
                RecruitDataGrid.Rows[i - 1].Cells[2].Value = score;
            }

        }

        private void LoadScholarshipOffersView()
        {
            ScholarshipOffersView.Rows.Clear();
            List<List<int>> RCWK = new List<List<int>>();
            int PRID = GetDB2ValueInt("RCPT", "PRID", RecruitIndex);

            for (int i = 0; i < GetTable2RecCount("RCWK"); i++)
            {
                RCWK.Add(new List<int>());
                RCWK[i].Add(GetDB2ValueInt("RCWK", "TGID", i));
                RCWK[i].Add(GetDB2ValueInt("RCWK", "PRID", i));
            }


            //ADD CODE
            for (int t = 0; t < RCWK.Count; t++)
            {
                int teamID = RCWK[t][0];
                int prid = RCWK[t][1];
                if (PRID == prid)
                {
                    int row = ScholarshipOffersView.Rows.Count;
                    ScholarshipOffersView.Rows.Add(new DataGridViewRow());

                    //team data
                    int team = GetDB2ValueInt("RCWK", "TGID", t);
                    ScholarshipOffersView.Rows[row].Cells[0].Value = teamNameDB[team];

                    //team prestige
                    int tprs = FindTeamPrestige(team);
                    ScholarshipOffersView.Rows[row].Cells[1].Value = ConvertStarNumber(tprs);
                }

            }


        }

        #endregion

        #region Commit & Decommit Players
        //Commit/Decomit Recruit

        private void CommitStatus_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRecruitStatus();
        }

        private void ChangeRecruitStatus()
        {
            if (DoNotTrigger)
                return;

            int recruitID = GetDB2ValueInt("RCPT", "PRID", RecruitIndex);

            if (CommitStatus.Checked)
            {
                List<string> teams = RecruitTeams().Items.Cast<string>().ToList();

                int teamID = PromptSelectTeam(teams);

                if (teamID == -1)
                {
                    CommitStatus.Checked = false;
                    return;
                }
                else
                {
                    int tgid = FindTGIDfromTeamName(teams[teamID]);
                    ChangeDB2Int("RCPR", "PTCM", RecruitIndex, tgid);
                    ChangeDB2Int("RCPT", "RCCM", RecruitIndex, 1);
                    for (int i = 0; i < GetTable2RecCount("RCWK"); i++)
                    {
                        int prid = GetDB2ValueInt("RCWK", "PRID", i);
                        if (recruitID == prid)
                        {
                            ChangeDB2Int("RCWK", "RCCM", i, 1);
                        }

                    }
                    CommitStatus.Text = "Committed to " + teams[teamID];
                    CommitStatus.ForeColor = Color.IndianRed;
                }

            }
            else
            {
                //Decommit Recruit
                ChangeDB2Int("RCPR", "PTCM", RecruitIndex, 511);
                ChangeDB2Int("RCPT", "RCCM", RecruitIndex, 0);
                for (int i = 0; i < GetTable2RecCount("RCWK"); i++)
                {
                    int prid = GetDB2ValueInt("RCWK", "PRID", i);
                    if (recruitID == prid)
                    {
                        ChangeDB2Int("RCWK", "RCCM", i, 0);
                    }

                }
                CommitStatus.Text = "Uncommitted";
                CommitStatus.ForeColor = Color.IndianRed;
            }


        }

        private int PromptSelectTeam(List<string> teams, string title = "Select Team")
        {
            if (teams == null || teams.Count == 0) return -1;

            using (Form dlg = new Form())
            {
                dlg.Text = title;
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.MinimizeBox = false;
                dlg.MaximizeBox = false;
                dlg.ShowIcon = false;
                dlg.ShowInTaskbar = false;
                dlg.AutoSize = true;
                dlg.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                dlg.Padding = new Padding(8);

                var listBox = new ListBox()
                {
                    SelectionMode = SelectionMode.One,
                    Dock = DockStyle.Top,
                    Height = 400
                };

                listBox.Items.AddRange(teams.ToArray());

                var btnPanel = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.RightToLeft,
                    Dock = DockStyle.Bottom,
                    AutoSize = true
                };

                var ok = new Button() { Text = "OK", DialogResult = DialogResult.OK, Enabled = false, AutoSize = true };
                var cancel = new Button() { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true };

                btnPanel.Controls.Add(ok);
                btnPanel.Controls.Add(cancel);

                dlg.Controls.Add(listBox);
                dlg.Controls.Add(btnPanel);

                dlg.AcceptButton = ok;
                dlg.CancelButton = cancel;

                listBox.SelectedIndexChanged += (s, e) => { ok.Enabled = listBox.SelectedIndex >= 0; };
                listBox.DoubleClick += (s, e) => { if (listBox.SelectedIndex >= 0) dlg.DialogResult = DialogResult.OK; };

                var result = dlg.ShowDialog(this);
                if (result == DialogResult.OK && listBox.SelectedIndex >= 0)
                    return listBox.SelectedIndex;

                return -1;
            }
        }

        #endregion

        #region ConversionMethods

        private void DisplayNewRCPTOverallRating()
        {
            RecalculateRecruitOverallByRec(RecruitIndex);
            ROVR.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "POVR", RecruitIndex)));
            ROVR.BackColor = GetColorRating(Convert.ToInt32(ROVR.Text));
        }


        public void RecalculateRecruitOverallByRec(int rec)
        {
            int ppos = Convert.ToInt32(GetDB2Value("RCPT", "PPOS", rec));
            double PCAR = Convert.ToInt32(GetDB2Value("RCPT", "PCAR", rec)); //CAWT
            double PKAC = Convert.ToInt32(GetDB2Value("RCPT", "PKAC", rec)); //KAWT
            double PTHA = Convert.ToInt32(GetDB2Value("RCPT", "PTHA", rec)); //TAWT
            double PPBK = Convert.ToInt32(GetDB2Value("RCPT", "PPBK", rec)); //PBWT
            double PRBK = Convert.ToInt32(GetDB2Value("RCPT", "PRBK", rec)); //RBWT
            double PACC = Convert.ToInt32(GetDB2Value("RCPT", "PACC", rec)); //ACWT
            double PAGI = Convert.ToInt32(GetDB2Value("RCPT", "PAGI", rec)); //AGWT
            double PTAK = Convert.ToInt32(GetDB2Value("RCPT", "PTAK", rec)); //TKWT
            double PINJ = Convert.ToInt32(GetDB2Value("RCPT", "PINJ", rec)); //INWT
            double PKPR = Convert.ToInt32(GetDB2Value("RCPT", "PKPR", rec)); //KPWT
            double PSPD = Convert.ToInt32(GetDB2Value("RCPT", "PSPD", rec)); //SPWT
            double PTHP = Convert.ToInt32(GetDB2Value("RCPT", "PTHP", rec)); //TPWT
            double PBKT = Convert.ToInt32(GetDB2Value("RCPT", "PBTK", rec)); //BTWT
            double PCTH = Convert.ToInt32(GetDB2Value("RCPT", "PCTH", rec)); //CTWT
            double PSTR = Convert.ToInt32(GetDB2Value("RCPT", "PSTR", rec)); //STWT
            double PJMP = Convert.ToInt32(GetDB2Value("RCPT", "PJMP", rec)); //JUWT
            double PAWR = Convert.ToInt32(GetDB2Value("RCPT", "PAWR", rec)); //AWWT

            double[] ratings = new double[] { PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR };

            for (int i = 0; i < ratings.Length; i++)
            {
                ratings[i] = CalcOVRIndividuals(i + 3, ratings[i], ppos);
            }

            double newRating = 50;

            for (int i = 0; i < ratings.Length; i++)
            {
                newRating += ratings[i];
            }

            int val = Convert.ToInt32(newRating);
            if (val < minConvRatingVal) val = minConvRatingVal;
            val = RevertRating(val);

            ChangeDB2Int("RCPT", "POVR", rec, val);

        }
        #endregion

        #region Special Functions

        private int FindRCPRRecfromPRID(int PRID)
        {
            for (int i = 0; i < GetTable2RecCount("RCPR"); i++)
            {
                if (PRID == GetDB2ValueInt("RCPR", "PRID", i)) return i;
            }

            return -1;
        }


        private void RecruitDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        #endregion



    }
}