using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        #region RECRUIT EDITOR

        public void StartRecruitEditor()
        {
            TransferTeam.Visible = false;

            AddFilters();
            LoadRCPTBox();
        }

        public void LoadRCPTBox()
        {
            RecruitEditorList = new List<List<string>>();

            int row = 0;
            for (int i = 0; i < GetTable2RecCount("RCPT"); i++)
            {
                int PRID = GetDB2ValueInt("RCPT", "PRID", i);
                int POSG = GetPOSGfromPPOS(GetDB2ValueInt("RCPT", "PPOS", i));
                int STID = GetDB2ValueInt("RCPT", "STID", i);
                int RATH = GetDB2ValueInt("RCPT", "RATH", i);

                if (RecruitTypeFilter.SelectedIndex == 0 || RecruitTypeFilter.SelectedIndex == 1 && PRID < 21000 || RecruitTypeFilter.SelectedIndex == 2 && PRID >= 21000)
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
                            RecruitEditorList[row].Add(GetDB2Value("RCPT", "RATH", i));
                            RecruitEditorList[row].Add(GetDB2Value("RCPT", "RCCB", i));
                            RecruitEditorList[row].Add(GetDB2Value("RCPT", "STID", i));

                            // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec
                            row++;
                        }
                    }

                }



            }

            RecruitEditorList.Sort((player1, player2) => Convert.ToInt32(player2[3]).CompareTo(Convert.ToInt32(player1[3])));


            RecruitListBox.Items.Clear();
            foreach (var player in RecruitEditorList)
            {
                string text = player[0] + " " + player[1] + " [" + GetPositionName(Convert.ToInt32(player[2])) + "]";
                if (Convert.ToInt32(player[4]) >= 21000)
                {
                    //text += " (T)";
                }
                RecruitListBox.Items.Add(text);
            }

            RecruitCounter.Text = "Recruit Count: " + row;
        }

        private void LoadRecruitingTable()
        {
            RecruitDataGrid.Rows.Clear();
            RCTeam.DataSource = RecruitTeams().Items;

            for(int i = 1; i < 11; i++)
            {
                RecruitDataGrid.Rows.Add(new DataGridViewRow());

                RecruitDataGrid.Rows[i-1].Cells[0].Value = i;

                //team data
                int team = GetDB2ValueInt("RCPR", "PT" + AddLeadingZeros(Convert.ToString(i), 2), RecruitIndex);
                RecruitDataGrid.Rows[i - 1].Cells[1].Value = teamNameDB[team];

                //team score
                int score = GetDB2ValueInt("RCPR", "PS" + AddLeadingZeros(Convert.ToString(i), 2), RecruitIndex);
                RecruitDataGrid.Rows[i - 1].Cells[2].Value = score;
            }

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
            for(int i = 0; i < RecruitDataGrid.Rows.Count; i++)
            {
                int tgid = FindTGIDfromTeamName(Convert.ToString(RecruitDataGrid.Rows[i].Cells[1].Value));
                ChangeDB2Int("RCPR", "PT" + AddLeadingZeros(Convert.ToString(i+1), 2), RecruitIndex, tgid);

                ChangeDB2Int("RCPR", "PS" + AddLeadingZeros(Convert.ToString(i+1), 2), RecruitIndex, Convert.ToInt32(RecruitDataGrid.Rows[i].Cells[2].Value));
            }

            MessageBox.Show("Recruiting Table Updated!");
        }


        //Filters

        private void AddFilters()
        {
            RecruitTypeFilter.Items.Clear();
            RecruitStateFilter.Items.Clear();
            RecruitPosFilter.Items.Clear();

            //Type
            RecruitTypeFilter.Items.Add("All");
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
            RecruitPosFilter.Items.Add("Athlete");

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
            LoadRCPTBox();
        }

        private void RecruitStateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRCPTBox();

        }

        private void RecruitPosFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRCPTBox();
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
            TransferTeam.Visible = false;


            //Player Name
            PFNABox.Text = GetDB2Value("RCPT", "PFNA", RecruitIndex);
            PLNABox.Text = GetDB2Value("RCPT", "PLNA", RecruitIndex);

            //Position
            AddRPositionsItems();
            RPPOSBox.SelectedIndex = GetDB2ValueInt("RCPT", "PPOS", RecruitIndex);

            //Home
            AddRStateItems();
            RStateBox.SelectedIndex = GetDB2ValueInt("RCPT", "STID", RecruitIndex);

            AddRHometownItems();
            RHometownBox.SelectedIndex = GetDB2ValueInt("RCPT", "RCHD", RecruitIndex) - (256 * GetDB2ValueInt("RCPT", "STID", RecruitIndex));

            //Overall Rating
            int xxx = GetDB2ValueInt("RCPT", "POVR", RecruitIndex);
            ROVR.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "POVR", RecruitIndex)));
            ROVR.BackColor = GetRatingColor(ROVR).BackColor;

            if (GetDB2ValueInt("RCPT", "PRID", RecruitIndex) < 21000)
                RecruitStarsText.Text = GetDB2Value("RCPT", "RCCB", RecruitIndex) + " Star Recruit";
            else RecruitStarsText.Text = GetDB2Value("RCPT", "RCCB", RecruitIndex) + " Star Transfer";

            PosRanking.Text = "Position Ranking: #" + (GetDB2ValueInt("RCPT", "RCRK", RecruitIndex)+1);

            //PGID Box
            PRIDBox.Text = GetDB2Value("RCPT", "PRID", RecruitIndex);

            TransferTeam.Visible = false;
            if(GetDB2ValueInt("RCPT", "PRID", RecruitIndex) >= 21000)
            {
                TransferTeam.Visible = true;
                string transfer = "";
                int prid = GetDB2ValueInt("RCPT", "PRID", RecruitIndex);
                for(int i = 0; i < GetTableRecCount("TRAN"); i++)
                {
                    if(GetDBValueInt("TRAN", "PGID", i) == prid)
                    {
                        transfer = teamNameDB[GetDBValueInt("TRAN", "PTID", i)];
                        break;
                    }
                }

                TransferTeam.Text = "Transferring from " + transfer;

            }

            //Year & Redshirt
            AddRYearItems();
            RYER.SelectedIndex = GetDB2ValueInt("RCPT", "PYER", RecruitIndex);

            //Height & Weight
            RHGTBox.Value = GetDB2ValueInt("RCPT", "PHGT", RecruitIndex);
            RWGTBox.Value = GetDB2ValueInt("RCPT", "PWGT", RecruitIndex) + 160;

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
            RDIS.BackColor = GetPrestigeColor(RDIS).BackColor;


            //Potential
            RPOEBox.Value = GetDB2ValueInt("RCPT", "PPOE", RecruitIndex);
            RPOEtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RPOEBox.Value)));
            RPOEtext.BackColor = GetRatingColor(RPOEtext).BackColor;

            //Injury
            RINJBox.Value = GetDB2ValueInt("RCPT", "PINJ", RecruitIndex);
            RINJtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RINJBox.Value)));
            RINJtext.BackColor = GetRatingColor(RINJtext).BackColor;

            //Awareness
            RAWRBox.Value = GetDB2ValueInt("RCPT", "PAWR", RecruitIndex);
            RAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RAWRBox.Value)));
            RAWRtext.BackColor = GetRatingColor(RAWRtext).BackColor;

            //Speed
            RSPDBox.Value = GetDB2ValueInt("RCPT", "PSRD", RecruitIndex);
            RSPDtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RSPDBox.Value)));
            RSPDtext.BackColor = GetRatingColor(RSPDtext).BackColor;

            //Agility
            RAGIBox.Value = GetDB2ValueInt("RCPT", "PAGI", RecruitIndex);
            RAGItext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RAGIBox.Value)));
            RAGItext.BackColor = GetRatingColor(RAGItext).BackColor;

            //Acceleration
            RACCBox.Value = GetDB2ValueInt("RCPT", "PACC", RecruitIndex);
            RACCtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RACCBox.Value)));
            RACCtext.BackColor = GetRatingColor(RACCtext).BackColor;

            //Jumping
            RJMPBox.Value = GetDB2ValueInt("RCPT", "PJMP", RecruitIndex);
            RJMPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RJMPBox.Value)));
            RJMPtext.BackColor = GetRatingColor(RJMPtext).BackColor;

            //Strength
            RSTRBox.Value = GetDB2ValueInt("RCPT", "PSTR", RecruitIndex);
            RSTRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RSTRBox.Value)));
            RSTRtext.BackColor = GetRatingColor(RSTRtext).BackColor;

            //Throw Rower
            RTHPBox.Value = GetDB2ValueInt("RCPT", "PTHP", RecruitIndex);
            RTHPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTHPBox.Value)));
            RTHPtext.BackColor = GetRatingColor(RTHPtext).BackColor;

            //Throw Accuracy
            RTHABox.Value = GetDB2ValueInt("RCPT", "PTHA", RecruitIndex);
            RTHAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTHABox.Value)));
            RTHAtext.BackColor = GetRatingColor(RTHAtext).BackColor;

            //Break Tackle
            RBTKBox.Value = GetDB2ValueInt("RCPT", "PBTK", RecruitIndex);
            RBTKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RBTKBox.Value)));
            RBTKtext.BackColor = GetRatingColor(RBTKtext).BackColor;

            //Ball Carry
            RCARBox.Value = GetDB2ValueInt("RCPT", "PCAR", RecruitIndex);
            RCARtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RCARBox.Value)));
            RCARtext.BackColor = GetRatingColor(RCARtext).BackColor;

            //Run Blocking
            RRBKBox.Value = GetDB2ValueInt("RCPT", "PRBK", RecruitIndex);
            RRBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RRBKBox.Value)));
            RRBKtext.BackColor = GetRatingColor(RRBKtext).BackColor;

            //Pass Blocking
            RPBKBox.Value = GetDB2ValueInt("RCPT", "PRBK", RecruitIndex);
            RPBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RPBKBox.Value)));
            RPBKtext.BackColor = GetRatingColor(RPBKtext).BackColor;

            //Catching
            RCTHBox.Value = GetDB2ValueInt("RCPT", "PCTH", RecruitIndex);
            RCTHtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RCTHBox.Value)));
            RCTHtext.BackColor = GetRatingColor(RCTHtext).BackColor;

            //Tackling
            RTAKBox.Value = GetDB2ValueInt("RCPT", "PTAK", RecruitIndex);
            RTAKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RTAKBox.Value)));
            RTAKtext.BackColor = GetRatingColor(RTAKtext).BackColor;

            //Kick Rower
            RKPRBox.Value = GetDB2ValueInt("RCPT", "PKPR", RecruitIndex);
            RKPRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RKPRBox.Value)));
            RKPRtext.BackColor = GetRatingColor(RKPRtext).BackColor;

            //Kick Accuracy
            RKACBox.Value = GetDB2ValueInt("RCPT", "PKAC", RecruitIndex);
            RKACtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(RKACBox.Value)));
            RKACtext.BackColor = GetRatingColor(RKACtext).BackColor;

            //Rlayer Tendency/Archeatype
            RTENBox.Text = GetPTENType(GetDB2ValueInt("RCPT", "PROS", RecruitIndex), GetDB2ValueInt("RCPT", "PTEN", RecruitIndex));


            LoadRecruitingTable();
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
            RDIS.BackColor = GetPrestigeColor(RDIS).BackColor;

        }

        private void RINJBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PINJ", RecruitIndex, Convert.ToInt32(RINJBox.Value));
            RINJtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PINJ", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RINJBox.BackColor = GetRatingColor(RINJtext).BackColor;
        }

        private void RSPDBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PSPD", RecruitIndex, Convert.ToInt32(RSPDBox.Value));
            RSPDtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PSPD", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RSPDBox.BackColor = GetRatingColor(RSPDtext).BackColor;
        }

        private void RACCBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PACC", RecruitIndex, Convert.ToInt32(RACCBox.Value));
            RACCtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PACC", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RACCBox.BackColor = GetRatingColor(RACCtext).BackColor;
        }

        private void RSTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PSTR", RecruitIndex, Convert.ToInt32(RSTRBox.Value));
            RSTRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PSTR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RSTRBox.BackColor = GetRatingColor(RSTRtext).BackColor;
        }

        private void RTHPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTHP", RecruitIndex, Convert.ToInt32(RTHPBox.Value));
            RTHPtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTHP", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTHPBox.BackColor = GetRatingColor(RTHPtext).BackColor;
        }

        private void RBTKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PBTK", RecruitIndex, Convert.ToInt32(RBTKBox.Value));
            RBTKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PINJ", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RBTKBox.BackColor = GetRatingColor(RBTKtext).BackColor;
        }

        private void RRBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PRBK", RecruitIndex, Convert.ToInt32(RRBKBox.Value));
            RRBKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PRBK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RRBKBox.BackColor = GetRatingColor(RRBKtext).BackColor;
        }

        private void RCTHBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PCTH", RecruitIndex, Convert.ToInt32(RCTHBox.Value));
            RCTHtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PCTH", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RCTHBox.BackColor = GetRatingColor(RCTHtext).BackColor;
        }

        private void RKPRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PKPR", RecruitIndex, Convert.ToInt32(RKPRBox.Value));
            RKPRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PKPR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RKPRBox.BackColor = GetRatingColor(RKPRtext).BackColor;
        }

        private void RPOEBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PPOE", RecruitIndex, Convert.ToInt32(RPOEBox.Value));
            RPOEtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PPOE", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RPOEBox.BackColor = GetRatingColor(RPOEtext).BackColor;

        }

        private void RAWRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PAWR", RecruitIndex, Convert.ToInt32(RAWRBox.Value));
            RAWRtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PAWR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RAWRBox.BackColor = GetRatingColor(RAWRtext).BackColor;
        }

        private void RAGIBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PAGI", RecruitIndex, Convert.ToInt32(RAGIBox.Value));
            RAGItext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PAGI", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RAGIBox.BackColor = GetRatingColor(RAGItext).BackColor;
        }

        private void RJMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PJMP", RecruitIndex, Convert.ToInt32(RJMPBox.Value));
            RJMPtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PJMP", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RJMPBox.BackColor = GetRatingColor(RJMPtext).BackColor;
        }

        private void RTHABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTHA", RecruitIndex, Convert.ToInt32(RTHABox.Value));
            RTHAtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTHA", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTHABox.BackColor = GetRatingColor(RTHAtext).BackColor;
        }

        private void RCARBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PCAR", RecruitIndex, Convert.ToInt32(RCARBox.Value));
            RCARtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PCAR", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RCARBox.BackColor = GetRatingColor(RCARtext).BackColor;
        }

        private void RPBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PPBK", RecruitIndex, Convert.ToInt32(RPBKBox.Value));
            RPBKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PPBK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RPBKBox.BackColor = GetRatingColor(RPBKtext).BackColor;
        }

        private void RTAKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PTAK", RecruitIndex, Convert.ToInt32(RTAKBox.Value));
            RTAKtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PTAK", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RTAKBox.BackColor = GetRatingColor(RTAKtext).BackColor;
        }

        private void RKACBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PKAC", RecruitIndex, Convert.ToInt32(RKACBox.Value));
            RKACtext.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "PKAC", RecruitIndex)));
            DisplayNewRCPTOverallRating();
            RKACBox.BackColor = GetRatingColor(RKACtext).BackColor;
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
            RecalculateRecruitIndividualBMI(RecruitIndex);
        }

        private void RWGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDB2Int("RCPT", "PWGT", RecruitIndex, Convert.ToInt32(RWGTBox.Value) - 160);
            RecalculateRecruitIndividualBMI(RecruitIndex);
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

        #endregion


        #region ConversionMethods

        private void DisplayNewRCPTOverallRating()
        {
            RecalculateRecruitOverallByRec(RecruitIndex);
            ROVR.Text = Convert.ToString(ConvertRating(GetDB2ValueInt("RCPT", "POVR", RecruitIndex)));
            ROVR.BackColor = GetRatingColor(ROVR).BackColor;
        }


        public void RecalculateRecruitOverallByRec(int rec)
        {
            int ppos = Convert.ToInt32(GetDBValue("RCPT", "PPOS", rec));
            double PCAR = Convert.ToInt32(GetDBValue("RCPT", "PCAR", rec)); //CAWT
            double PKAC = Convert.ToInt32(GetDBValue("RCPT", "PKAC", rec)); //KAWT
            double PTHA = Convert.ToInt32(GetDBValue("RCPT", "PTHA", rec)); //TAWT
            double PPBK = Convert.ToInt32(GetDBValue("RCPT", "PPBK", rec)); //PBWT
            double PRBK = Convert.ToInt32(GetDBValue("RCPT", "PRBK", rec)); //RBWT
            double PACC = Convert.ToInt32(GetDBValue("RCPT", "PACC", rec)); //ACWT
            double PAGI = Convert.ToInt32(GetDBValue("RCPT", "PAGI", rec)); //AGWT
            double PTAK = Convert.ToInt32(GetDBValue("RCPT", "PTAK", rec)); //TKWT
            double PINJ = Convert.ToInt32(GetDBValue("RCPT", "PINJ", rec)); //INWT
            double PKPR = Convert.ToInt32(GetDBValue("RCPT", "PKPR", rec)); //KPWT
            double PSPD = Convert.ToInt32(GetDBValue("RCPT", "PSPD", rec)); //SPWT
            double PTHP = Convert.ToInt32(GetDBValue("RCPT", "PTHP", rec)); //TPWT
            double PBKT = Convert.ToInt32(GetDBValue("RCPT", "PBTK", rec)); //BTWT
            double PCTH = Convert.ToInt32(GetDBValue("RCPT", "PCTH", rec)); //CTWT
            double PSTR = Convert.ToInt32(GetDBValue("RCPT", "PSTR", rec)); //STWT
            double PJMP = Convert.ToInt32(GetDBValue("RCPT", "PJMP", rec)); //JUWT
            double PAWR = Convert.ToInt32(GetDBValue("RCPT", "PAWR", rec)); //AWWT

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
            if (val < 40) val = 40;
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