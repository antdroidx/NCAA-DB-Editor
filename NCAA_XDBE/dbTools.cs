using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        private void StartDBTools()
        {
            AddAttributesToBoxes();
            AddPositionsToBoxes();

            //Fantasy Roster Gen Options
            if (TDYN)
            {
                FantasyTeamDB.Enabled = false;
                FantasyTeamDB.Checked = false;
                FantasyCSV.Enabled = true;
                FantasyCSV.Checked = true;
            }
            else
            {
                FantasyTeamDB.Enabled = true;
                FantasyTeamDB.Checked = true;
                FantasyCSV.Enabled = true;
                FantasyCSV.Checked = false;
            }

            GlobalAttNum.Minimum = -maxRatingVal;
            GlobalAttNum.Maximum = maxRatingVal;

            MinAttNum.Minimum = -maxRatingVal;
            MinAttNum.Maximum = maxRatingVal;

            MaxAttNum.Minimum = -maxRatingVal;
            MaxAttNum.Maximum = maxRatingVal;

            if (TDYN) FantastyRosterLeague.Visible = true;
            else FantastyRosterLeague.Visible = false;

        }

        #region MAIN DB TOOLS CLICKS

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void BodyFix_Click(object sender, EventArgs e)
        {
            RecalculateBMI("PLAY");
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
            RandomizeAllPlayerHeads();
        }

        //Unique Player Tool
        private void UniquePlayer_Click(object sender, EventArgs e)
        {
            UniquePlayers();
        }

        //Recalculate Overall Ratings
        private void buttonCalcOverall_Click(object sender, EventArgs e)
        {
            RecalculateOverall();
        }

        //Recalculate Team Overalls
        private void TYDNButton_Click(object sender, EventArgs e)
        {
            if (TEAM) CalculateAllTeamRatings("TEAM");
            if (TDYN) CalculateAllTeamRatings("TDYN");
        }

        //Determine Impact Players
        private void buttonImpactPlayers_Click(object sender, EventArgs e)
        {
            DetermineAllImpactPlayers();
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

        //Reorder Teams TORD
        private void TORDButton_Click(object sender, EventArgs e)
        {
            ReorderTORD();
        }

        //Reorder PLAY by PGID
        private void ReorderPGIDButton_Click(object sender, EventArgs e)
        {
            ReOrderTable("PLAY", "PGID");
        }


        private void SyncPBButton_Click(object sender, EventArgs e)
        {
            SyncTeamCoachPlaybooks();
        }

        private void FantasyCoachesButton_Click(object sender, EventArgs e)
        {
            CreateFantasyCoachDB();
        }

        private void FixHCBugsButton_Click(object sender, EventArgs e)
        {
            FixHCBugs();
        }

        private void ClearExpiredStats_Click(object sender, EventArgs e)
        {
            ClearExpiredStatsData();
        }

        //Fix Hometown Button
        private void FixHometownButton_Click(object sender, EventArgs e)
        {
            FixHometown();
        }


        #endregion



        #region General Tools
        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void RecalculateBMI(string tableName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\BMI-Calc.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[432, Line.Length];
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
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                double bmi = (double)Math.Round(Convert.ToDouble(GetDBValue(tableName, "PWGT", i)) / Convert.ToDouble(GetDBValue(tableName, "PHGT", i)), 2);

                for (int j = 0; j < 401; j++)
                {
                    if (Convert.ToString(bmi) == strArray[j, 0])
                    {
                        ChangeDBString(tableName, "PFSH", i, strArray[j, 1]);
                        ChangeDBString(tableName, "PMSH", i, strArray[j, 2]);
                        ChangeDBString(tableName, "PSSH", i, strArray[j, 3]);
                        break;
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Body Model updates are complete!");
        }

        private void RecalculateIndividualBMI(int rec)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\BMI-Calc.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[432, Line.Length];
                }
                for (int column = 0; column < Line.Length; column++)
                {
                    strArray[Row, column] = Line[column];
                }
                Row++;
            }
            sr.Close();



            double bmi = (double)Math.Round(Convert.ToDouble(GetDBValue("PLAY", "PWGT", rec)) / Convert.ToDouble(GetDBValue("PLAY", "PHGT", rec)), 2);
            for (int j = 0; j < 401; j++)
            {
                if (Convert.ToString(bmi) == strArray[j, 0])
                {
                    ChangeDBString("PLAY", "PFSH", rec, strArray[j, 1]);
                    ChangeDBString("PLAY", "PMSH", rec, strArray[j, 2]);
                    ChangeDBString("PLAY", "PSSH", rec, strArray[j, 3]);
                    break;
                }
            }

        }


        //Recalc Recruit BMI

        private void RecalculateRecruitIndividualBMI(int rec)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\BMI-Calc.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[432, Line.Length];
                }
                for (int column = 0; column < Line.Length; column++)
                {
                    strArray[Row, column] = Line[column];
                }
                Row++;
            }
            sr.Close();



            double bmi = (double)Math.Round(Convert.ToDouble(GetDB2Value("RCPT", "PWGT", rec)) / Convert.ToDouble(GetDB2Value("RCPT", "PHGT", rec)), 2);
            for (int j = 0; j < 401; j++)
            {
                if (Convert.ToString(bmi) == strArray[j, 0])
                {
                    ChangeDB2String("RCPT", "PFSH", rec, strArray[j, 1]);
                    ChangeDB2String("RCPT", "PMSH", rec, strArray[j, 2]);
                    ChangeDB2String("RCPT", "PSSH", rec, strArray[j, 3]);
                    break;
                }
            }

        }

        //Recalculates QB Tendencies based on original game criteria
        private void RecalculateQBTendencies()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;

            int pocket = 0;
            int balanced = 0;
            int scrambler = 0;


            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValue("PLAY", "PPOS", i) == "0")
                {
                    int tendies;
                    int speed = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PSPD", i)));
                    int acceleration = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PACC", i)));
                    int agility = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PAGI", i)));
                    int ThPow = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PTHP", i)));
                    int ThAcc = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PTHA", i)));


                    tendies = (100 + 10 * speed + acceleration + agility - 3 * ThPow - 5 * ThAcc) / 20;

                    if (tendies > 31) tendies = 31;
                    if (tendies < 0) tendies = 0;

                    ChangeDBString("PLAY", "PTEN", i, Convert.ToString(tendies));

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

        //Randomize Player Potential
        private void RandomizePotential()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                int x = rand.Next(0, 32);

                ChangeDBString("PLAY", "PPOE", i, Convert.ToString(x));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Potential Updates are complete!");
        }

        //Recalculate Player Overalls
        public void RecalculateOverall()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                RecalculateOverallByRec(i);

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Overall Calculations are complete!");
        }


        //Sync Playbook/Strategies with Team
        private void SyncTeamCoachPlaybooks()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                int tgid = GetDBValueInt("COCH", "TGID", i);
                if (tgid != 511)
                {
                    int offPB = GetDBValueInt("COCH", "CPID", i);
                    int defPB = GetDBValueInt("COCH", "CDST", i);

                    ChangeDBInt("TEAM", "TOPB", FindTeamRecfromTeamName(teamNameDB[tgid]), offPB);
                    ChangeDBInt("TEAM", "TDPB", FindTeamRecfromTeamName(teamNameDB[tgid]), defPB);
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Completed Sync");

        }

        //Calculate Team Ratings
        public void CalculateAllTeamRatings(string tableName)
        {

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;

            List<List<List<int>>> AllRosters = new List<List<List<int>>>();

            for (int i = 0; i < 512; i++)
            {
                List<List<int>> roster = new List<List<int>>();
                AllRosters.Add(roster);
            }



            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);
                int TGID = PGID / 70;

                int POVR = GetDBValueInt("PLAY", "POVR", j);
                int PPOS = GetDBValueInt("PLAY", "PPOS", j);

                int count = AllRosters[TGID].Count;
                List<int> player = new List<int>();
                AllRosters[TGID].Add(player);
                AllRosters[TGID][count].Add(POVR);
                AllRosters[TGID][count].Add(PPOS);
                AllRosters[TGID][count].Add(PGID); // Add PGID to roster for reference
            }

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TEAM && GetDBValueInt(tableName, "TTYP", i) < 1 || TDYN)
                {
                    int TGID = GetDBValueInt(tableName, "TOID", i);

                    CalculateTeamRatings(tableName, i, AllRosters[TGID]);
                }

                progressBar1.PerformStep();
            }


            NormalizeTeamRatings(tableName);

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Team Rating Calculations are complete!");
        }

        //Calculate Single Team Ratings
        public void CalculateTeamRatingsSingle(string tableName, int tgid)
        {
            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;
            int i = -1;

            for (int x = 0; x < GetTableRecCount(tableName); x++)
            {
                if (GetDBValueInt(tableName, "TOID", x) == tgid)
                {
                    i = x;
                    break;
                }
            }

            int count = 0;
            List<List<int>> roster = new List<List<int>>();

            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);

                if (PGID >= PGIDbeg && PGID <= PGIDend)
                {
                    int POVR = GetDBValueInt("PLAY", "POVR", j);
                    int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                    List<int> player = new List<int>();
                    roster.Add(player);
                    roster[count].Add(POVR);
                    roster[count].Add(PPOS);
                    count++;
                }
            }

            CalculateTeamRatings(tableName, i, roster);

            NormalizeTeamRatings(tableName);

            MessageBox.Show(teamNameDB[tgid] + " Team Rating Calculations are complete!");
        }

        //Actually calculate the team ratings
        public void CalculateTeamRatings(string tableName, int teamRec, List<List<int>> roster)
        {

            roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));
            int bonus = 0;

            //TRDB - Defensive Backs  PPOS = 16, 17, 18
            int rating = 0;
            int count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 16 && PPOS <= 18)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 5) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRDB", teamRec, Convert.ToString(rating));


            //TRLB - Linebackers 13, 14, 15
            rating = 0;
            count = 0;
            int topPlayer = 0;
            int topPlayerRating = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 13 && PPOS <= 15)
                {
                    rating += roster[j][0];

                    if (roster[j][0] > topPlayerRating)
                    {
                        topPlayerRating = roster[j][0];
                        topPlayer = roster[j][2] - GetDBValueInt(tableName, "TOID", teamRec)*70;
                    }
                    count++;
                }
                if (count >= 4) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRLB", teamRec, Convert.ToString(rating));
            if(TDYN) ChangeDBInt(tableName, "DCAP", teamRec, topPlayer);

            //TRQB - Quarterbacks 0
            rating = 0;
            count = 0;
            topPlayer = 0;
            topPlayerRating = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];


                if (PPOS == 0)
                {
                    rating += roster[j][0];

                    if (roster[j][0] > topPlayerRating)
                    {
                        topPlayerRating = roster[j][0];
                        topPlayer = roster[j][2] - GetDBValueInt(tableName, "TOID", teamRec) * 70;
                    }

                    count++;
                }
                if (count >= 1) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRQB", teamRec, Convert.ToString(rating));
            if (TDYN) ChangeDBInt(tableName, "OCAP", teamRec, topPlayer);


            //TRRB - Running Backs 1, 2
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 1 && PPOS <= 2)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 3) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRRB", teamRec, Convert.ToString(rating));

            //TRDL - Defensive Line 10, 11, 12
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 10 && PPOS <= 12)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 4) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRDL", teamRec, Convert.ToString(rating));

            //TROL - Offensive Line 5 - 9
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 5 && PPOS <= 9)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 6) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TROL", teamRec, Convert.ToString(rating));

            //TWRR - Wide Receivers 3, 4
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 3 && PPOS <= 4)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 5) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TWRR", teamRec, Convert.ToString(rating));

            //TRST - Special Teams 19, 20
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 19 && PPOS <= 20)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 2) break;
            }

            if (count <= 0) ChangeDBInt(tableName, "TRST", teamRec, 0);
            else
            {
                rating = ConvertRating(rating / count) + bonus;

                ChangeDBString(tableName, "TRST", teamRec, Convert.ToString(rating));
            }


            //TRDE - Defense 10 - 18, 20
            rating = (Convert.ToInt32(GetDBValue(tableName, "TRDB", teamRec)) + Convert.ToInt32(GetDBValue(tableName, "TRLB", teamRec)) + Convert.ToInt32(GetDBValue(tableName, "TRDL", teamRec))) / 3;

            ChangeDBString(tableName, "TRDE", teamRec, Convert.ToString(rating));

            //TROF - Offense 0 - 9, 19
            rating = (Convert.ToInt32(GetDBValue(tableName, "TRQB", teamRec)) * 2 + Convert.ToInt32(GetDBValue(tableName, "TRRB", teamRec)) + Convert.ToInt32(GetDBValue(tableName, "TWRR", teamRec)) + Convert.ToInt32(GetDBValue(tableName, "TROL", teamRec))) / 5;

            ChangeDBString(tableName, "TROF", teamRec, Convert.ToString(rating));

            //TROV - Team Overall
            rating = (Convert.ToInt32(GetDBValue(tableName, "TROF", teamRec)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRDE", teamRec)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRST", teamRec))) / 7;

            ChangeDBString(tableName, "TROV", teamRec, Convert.ToString(rating));

        }



        public void NormalizeTeamRatings(string tableName)
        {
            double meanOff = 78;
            double meanDef = 78;
            double rangeOffFactor = 1.33;
            double rangeDefFactor = 1.33;
            List<int> offRatings = new List<int>();
            List<int> defRatings = new List<int>();

            if (GetTableRecCount(tableName) >= 119)
            {
                //Collect Team Rating Data
                for (int x = 0; x < GetTableRecCount(tableName); x++)
                {
                    if (TEAM && GetDBValueInt(tableName, "TTYP", x) < 1 || TDYN)
                    {
                        int rating = 0;
                        //TRDE - Defense 10 - 18, 20
                        rating = (Convert.ToInt32(GetDBValue(tableName, "TRDB", x)) + Convert.ToInt32(GetDBValue(tableName, "TRLB", x)) + Convert.ToInt32(GetDBValue(tableName, "TRDL", x))) / 3;

                        ChangeDBString(tableName, "TRDE", x, Convert.ToString(rating));

                        //TROF - Offense 0 - 9, 19
                        rating = (Convert.ToInt32(GetDBValue(tableName, "TRQB", x)) * 2 + Convert.ToInt32(GetDBValue(tableName, "TRRB", x)) + Convert.ToInt32(GetDBValue(tableName, "TWRR", x)) + Convert.ToInt32(GetDBValue(tableName, "TROL", x))) / 5;

                        ChangeDBString(tableName, "TROF", x, Convert.ToString(rating));

                        //TROV - Team Overall
                        rating = (Convert.ToInt32(GetDBValue(tableName, "TROF", x)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRDE", x)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRST", x))) / 7;

                        offRatings.Add(GetDBValueInt(tableName, "TROF", x));
                        defRatings.Add(GetDBValueInt(tableName, "TRDE", x));
                    }
                }

                //Calculate Stats
                meanOff = offRatings.Average();
                meanDef = defRatings.Average();
                int rangeOff = offRatings.Max() - offRatings.Min();
                int rangeDef = defRatings.Max() - defRatings.Min();
                rangeOffFactor = 50 / rangeOff;
                rangeDefFactor = 50 / rangeDef;
            }

            //Calculate Normalized Rating on a 55-99scale
            for (int x = 0; x < GetTableRecCount(tableName); x++)
            {
                if (TEAM && GetDBValueInt(tableName, "TTYP", x) < 1 || TDYN)
                {
                    double normalOff = GetDBValueInt(tableName, "TROF", x) - meanOff;
                    double normalDef = GetDBValueInt(tableName, "TRDE", x) - meanDef;
                    int offRating = Convert.ToInt32(normalOff * rangeOffFactor + meanOff);
                    int defRating = Convert.ToInt32(normalDef * rangeDefFactor + meanDef);
                    ChangeDBInt(tableName, "TROF", x, offRating);
                    ChangeDBInt(tableName, "TRDE", x, defRating);
                    ChangeDBInt(tableName, "TROV", x, (offRating + defRating) / 2);
                }
            }

            if (ReRankTeams.Checked || ReRankTeamsAP.Checked) ReRankPreseason();
        }

        public void ReRankPreseason()
        {
            List<List<int>> teams = new List<List<int>>();

            int row = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    teams.Add(new List<int>());
                    teams[row].Add(GetDBValueInt("TEAM", "TROV", i));
                    teams[row].Add(i);
                    row++;
                }
            }

            teams.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

            if (ReRankTeams.Checked)
            {
                int rank = 1;
                foreach (var team in teams)
                {
                    ChangeDBInt("TEAM", "TCRK", team[1], rank);
                    rank++;
                }
            }

            if (ReRankTeamsAP.Checked)
            {
                int rank = 1;
                foreach (var team in teams)
                {
                    ChangeDBInt("TEAM", "TMRK", team[1], rank);
                    rank++;
                }
            }
        }


        //Fill Rosters
        private void FillRosters(string tableName, int FreshmanPCT)
        {
            //Setup
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = new List<List<string>>();
            RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            SelectedTableIndex = TDB.TableIndex(dbIndex, "PLAY");
            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);


            //count num of teams
            int teamCount = 0;
            if (TDYN)
            {
                teamCount = GetTableRecCount("TDYN");
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "TTYP", i) == 0) teamCount++;
                }
            }

            int recCounter = GetTableRecCount("PLAY");
            int maxRecords = TableProps.Capacity;
            int created = 0;

            //Create a list of PGIDs in the database
            OccupiedPGIDList = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                List<int> PGIDList = new List<int>();
                OccupiedPGIDList.Add(PGIDList);
            }


            List<int> rosters = new List<int>();
            AvailablePJEN = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                AvailablePJEN.Add(new List<int>());
            }

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", i);
                rosters.Add(PGID);
                int TGID = PGID / 70;

                OccupiedPGIDList[TGID].Add(PGID);
            }


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            //Go through each team and find missing PGID
            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TDYN || GetDBValueInt(tableName, "TTYP", i) == 0)
                {
                    int tgid = GetDBValueInt(tableName, "TOID", i);
                    int pgidSTART = tgid * 70;
                    int pgidEND = pgidSTART + 69;

                    if (teamCount != 120 || teamCount != 119) 
                    { 
                       if (DC77.Checked) maxPlayers = 66;
                       else maxPlayers = 70;
                        pgidEND = pgidSTART + maxPlayers - 1; 
                    }

                    for (int j = pgidSTART; j < pgidEND; j++)
                    {
                        if (!rosters.Contains(j) && recCounter < maxRecords)
                        {
                            List<int> POSG = new List<int> { 3, 5, 6, 3, 12, 12, 7, 11, 1, 1 };
                            List<int> TeamPos = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                            for (int k = 0; k < GetTableRecCount("PLAY"); k++)
                            {
                                int pgid = GetDBValueInt("PLAY", "PGID", k);
                                if (pgid >= pgidSTART && pgid < pgidEND)
                                {
                                    if (GetDBValueInt("PLAY", "PPOS", k) == 0) TeamPos[0]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 2) TeamPos[1]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) == 3) TeamPos[2]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) == 4) TeamPos[3]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 9) TeamPos[4]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 12) TeamPos[5]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 15) TeamPos[6]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 18) TeamPos[7]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) == 19) TeamPos[8]++;
                                    else if (GetDBValueInt("PLAY", "PPOS", k) == 20) TeamPos[9]++;
                                }
                            }

                            AddTableRecord("PLAY", false);


                            if (TeamPos[8] < POSG[8]) TransferRCATtoPLAY(recCounter, 19, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[9] < POSG[9]) TransferRCATtoPLAY(recCounter, 20, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[0] < POSG[0]) TransferRCATtoPLAY(recCounter, 0, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[1] < POSG[1]) TransferRCATtoPLAY(recCounter, 1, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[2] < POSG[2]) TransferRCATtoPLAY(recCounter, 3, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[3] < POSG[3]) TransferRCATtoPLAY(recCounter, 4, j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[4] < POSG[4]) TransferRCATtoPLAY(recCounter, rand.Next(5, 10), j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[5] < POSG[5]) TransferRCATtoPLAY(recCounter, rand.Next(10, 13), j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[6] < POSG[6]) TransferRCATtoPLAY(recCounter, rand.Next(13, 16), j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);
                            else if (TeamPos[7] < POSG[7]) TransferRCATtoPLAY(recCounter, rand.Next(16, 19), j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);

                            else TransferRCATtoPLAY(recCounter, rand.Next(0, 19), j, RCATmapper, PJEN, AvailablePJEN[tgid], FreshmanPCT);


                            RandomizePlayerHead("PLAY", recCounter);

                            recCounter++;
                            created++;
                        }
                    }

                    CheckSpecialTeamsCount(tgid, AvailablePJEN[tgid]);
                }
                progressBar1.PerformStep();
            }


            RecalculateBMI("PLAY");
            RecalculateOverall();
            RecalculateQBTendencies();

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Team Roster Filled in! " + created + " players created!");
        }

        //Check for Kickers/Punters
        private void CheckSpecialTeamsCount(int tgid, List<int> AvailablePJEN)
        {
            //Check for Kickers and Punters

            //Setup
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<int> POSG2 = new List<int> { 2, 4, 4, 2, 7, 7, 4, 6, 1, 1 };
            List<int> TeamPos2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            List<List<int>> Diff = new List<List<int>>();
            List<List<int>> rosterList = new List<List<int>>();
            List<List<string>> RCATmapper = new List<List<string>>();
            RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            int pgidSTART = tgid * 70;
            int pgidEND = pgidSTART + 69;
            int recCounter = GetTableRecCount("PLAY");

            int rowx = 0;
            for (int k = 0; k < GetTableRecCount("PLAY"); k++)
            {
                int pgid = GetDBValueInt("PLAY", "PGID", k);
                if (pgid >= pgidSTART && pgid <= pgidEND)
                {
                    if (GetDBValueInt("PLAY", "PPOS", k) == 0) TeamPos2[0]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 2) TeamPos2[1]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) == 3) TeamPos2[2]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) == 4) TeamPos2[3]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 9) TeamPos2[4]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 12) TeamPos2[5]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 15) TeamPos2[6]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) <= 18) TeamPos2[7]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) == 19) TeamPos2[8]++;
                    else if (GetDBValueInt("PLAY", "PPOS", k) == 20) TeamPos2[9]++;

                    rosterList.Add(new List<int>());
                    rosterList[rowx].Add(GetDBValueInt("PLAY", "POVR", k));
                    rosterList[rowx].Add(GetDBValueInt("PLAY", "PPOS", k));
                    rosterList[rowx].Add(k);
                    rosterList[rowx].Add(GetDBValueInt("PLAY", "PGID", k));

                    rowx++;
                }
            }


            for (int k = 0; k < 10; k++)
            {
                Diff.Add(new List<int>());
                Diff[k].Add(POSG2[k] - TeamPos2[k]);
            }

            for (int k = 9; k >= 0; k--)
            {
                if (Diff[k][0] > 0)
                {
                    rosterList.Sort((player1, player2) => player2[0].CompareTo(player1[0]));
                    for (int x = rosterList.Count - 1; x >= 0; x--)
                    {
                        if (rosterList[x][1] != 19 && rosterList[x][1] != 20)
                        {
                            TransferRCATtoPLAY(rosterList[x][2], ChooseRandomPosFromPOSG(k), rosterList[x][3], RCATmapper, PJEN, AvailablePJEN, 50);
                            RandomizePlayerHead("PLAY", Convert.ToInt32(rosterList[x][2]));
                            rosterList.RemoveAt(x);
                            break;
                        }
                    }
                }
            }
        }

        //Randomize Player Faces
        private void RandomizeAllPlayerHeads()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                RandomizePlayerHead("PLAY", i);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Faces & Skin Tones Randomized!");
        }

        //Randomizes a specific player face based on record, i
        private void RandomizePlayerHead(string tableName, int i)
        {
            //Randomizes Face Shape (PGFM)
            int shape = rand.Next(0, 16);
            ChangeDBString(tableName, "PFGM", i, Convert.ToString(shape));

            //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
            int skin = GetDBValueInt(tableName, "PSKI", i);
            if (skin <= 2) skin = rand.Next(0, 3);
            else if (skin <= 6) skin = rand.Next(3, 7);
            else skin = rand.Next(7, 8);

            ChangeDBString(tableName, "PSKI", i, Convert.ToString(skin));

            //Randomizes Face Type based on new Skin Type
            int face = GetDBValueInt(tableName, "PSKI", i) * 8 + rand.Next(0, 8);
            ChangeDBString(tableName, "PFMP", i, Convert.ToString(face));

            //Randomize Hair Color
            int hcl = 0;
            if (skin < 3)
            {
                hcl = rand.Next(1, 101);
                if (hcl <= 55) hcl = 2; //brown
                else if (hcl <= 65) hcl = 0; //black
                else if (hcl <= 80) hcl = 1; //blonde
                else if (hcl <= 95) hcl = 4; //light brown
                else hcl = 3; //red
            }
            else
            {
                hcl = rand.Next(1, 101);
                if (hcl <= 92) hcl = 0;
                else hcl = rand.Next(1, 6);
            }
            ChangeDBString(tableName, "PHCL", i, Convert.ToString(hcl));

            //Randomize Hair Style



        }

        //Unique Players
        private void UniquePlayers()
        {
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
                int skin = GetDBValueInt("PLAY", "PSKI", i);
                if (skin == 1)
                {
                    skin = rand.Next(0, 3);
                    if (skin == 1) skin = 2;
                }
                else if (skin == 4)
                {
                    skin = rand.Next(3, 7);
                    if (skin == 4) skin = 5;
                }

                ChangeDBInt("PLAY", "PSKI", i, skin);

                //Randomizes Face Type based on new Skin Type
                int face = GetDBValueInt("PLAY", "PSKI", i) * 8 + rand.Next(0, 8);
                ChangeDBInt("PLAY", "PFMP", i, face);
            }

            MessageBox.Show("Completed!");
        }

        //Fix HC Bugs
        private void FixHCBugs()
        {
            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                //skin tone
                int CSKI = GetDBValueInt("COCH", "CSKI", i);
                if (CSKI > 0 && CSKI < 4) ChangeDBInt("COCH", "CSKI", i, 2);
                else if (CSKI >= 4) ChangeDBInt("COCH", "CSKI", i, 5);

                //hair type
                int CThg = GetDBValueInt("COCH", "CThg", i);
                if (CThg == 1) ChangeDBInt("COCH", "CThg", i, 0);
                if (CThg > 4) ChangeDBInt("COCH", "CThg", i, rand.Next(1, 4));

                //Hat/Visor
                int COHT = GetDBValueInt("COCH", "COHT", i);
                if (COHT == 1) ChangeDBInt("COCH", "CThg", i, 1);
                else if (COHT == 0) ChangeDBInt("COCH", "CThg", i, 0);

            }

            MessageBox.Show("Head Coach Fix Complete");
        }

        //Clear Expired Stats
        private void ClearExpiredStatsData()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("TEAM");

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) > 0)
                {
                    ClearTeamPlayers(GetDBValueInt("TEAM", "TGID", i));
                }
                progressBar1.PerformStep();
            }


            progressBar1.Visible = false;
            MessageBox.Show("Task Complete!");
        }


        //Reset Dynasty Year

        private void ResetDynYear_Click(object sender, EventArgs e)
        {
            ResetDynastyYear();
        }

        private void ResetDynastyYear()
        {
            int year = GetDBValueInt("SEAI", "SEYR", 0);
            year = 5 - year;

            ChangeDBInt("SEAI", "SEYR", 0, 5);

            for (int i = 0; i < GetTableRecCount("PSDE"); i++)
            {
                if (GetDBValueInt("PSDE", "PGID", i) == 65535) DeleteRecord("PSDE", i, true);
                else
                {
                    int seyr = GetDBValueInt("PSDE", "SEYR", i);
                    ChangeDBInt("PSDE", "SEYR", i, seyr + year);
                }

            }

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "PGID", i) == 65535) DeleteRecord("PSKI", i, true);
                else
                {
                    int seyr = GetDBValueInt("PSKI", "SEYR", i);
                    ChangeDBInt("PSKI", "SEYR", i, seyr + year);
                }
            }

            for (int i = 0; i < GetTableRecCount("PSKP"); i++)
            {
                if (GetDBValueInt("PSKP", "PGID", i) == 65535) DeleteRecord("PSKP", i, true);
                else
                {
                    int seyr = GetDBValueInt("PSKP", "SEYR", i);
                    ChangeDBInt("PSKP", "SEYR", i, seyr + year);
                }
            }

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == 65535) DeleteRecord("PSOF", i, true);
                else
                {
                    int seyr = GetDBValueInt("PSOF", "SEYR", i);
                    ChangeDBInt("PSOF", "SEYR", i, seyr + year);
                }
            }

            for (int i = 0; i < GetTableRecCount("PSOL"); i++)
            {
                if (GetDBValueInt("PSOL", "PGID", i) == 65535) DeleteRecord("PSOL", i, true);
                else
                {
                    int seyr = GetDBValueInt("PSOL", "SEYR", i);
                    ChangeDBInt("PSOL", "SEYR", i, seyr + year);
                }
            }

            CompactDB();

            MessageBox.Show("Dynasty Year Reset!");
        }


        //Check and Fix hometowns if they exist or missing
        private void FixHometown()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                int hometown = GetDBValueInt("PLAY", "RCHD", i);

                hometown = CheckHometown(hometown);
                ChangeDBInt("PLAY", "RCHD", i, hometown);

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            MessageBox.Show("Hometowns Fixed!");
        }

        private int CheckHometown(int hometown)
        {
            int ht = 0;

            List<string> home = new List<string>();

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\RCHT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                home.Add(Line[0]);
            }
            sr.Close();

            if (home.Contains(Convert.ToString(hometown))) 
            {
                return hometown;
            }
            else
            {
                int state = hometown / 256;
                bool realHT = false;
                while (!realHT)
                {
                    ht = rand.Next(state * 256, state * 256 + 256);
                    if (home.Contains(Convert.ToString(ht))) realHT = true;
                }
            }

            return ht;
        }

        //Changed League Size
        private void DC77_CheckedChanged(object sender, EventArgs e)
        {
            if(DC77.Checked)
            {
                MaxFantasyPlayers.Maximum = 66;
                MaxFantasyPlayers.Value = 66;
            }
            else
            {
                MaxFantasyPlayers.Maximum = 70;
                MaxFantasyPlayers.Value = 70;
            }
        }

        private void DC88_CheckedChanged(object sender, EventArgs e)
        {
            if (DC77.Checked)
            {
                MaxFantasyPlayers.Maximum = 66;
                MaxFantasyPlayers.Value = 66;
            }
            else
            {
                MaxFantasyPlayers.Maximum = 70;
                MaxFantasyPlayers.Value = 70;
            }
        }

        #endregion


        #region Attribute Editors

        private void AddAttributesToBoxes()
        {
            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);

            GlobalAttBox.Items.Clear();
            MinAttBox.Items.Clear();
            MaxAttBox.Items.Clear();

            foreach (List<string> a in atb)
            {
                GlobalAttBox.Items.Add(a[1]);
                MinAttBox.Items.Add(a[1]);
                MaxAttBox.Items.Add(a[1]);
            }
        }

        private void AddPositionsToBoxes()
        {

            GlobalAttPosBox.Items.Clear();
            MinAttPosBox.Items.Clear();
            MaxAttPosBox.Items.Clear();
            MinBodyPos.Items.Clear();
            MaxBodyPos.Items.Clear();

            GlobalAttPosBox.Items.Add("ALL");
            MinAttPosBox.Items.Add("ALL");
            MaxAttPosBox.Items.Add("ALL");
            MinBodyPos.Items.Add("ALL");
            MaxBodyPos.Items.Add("ALL");

            for (int i = 0; i < 17; i++)
            {
                GlobalAttPosBox.Items.Add(GetPOSG2Name(i));
                MinAttPosBox.Items.Add(GetPOSG2Name(i));
                MaxAttPosBox.Items.Add(GetPOSG2Name(i));
                MinBodyPos.Items.Add(GetPOSG2Name(i));
                MaxBodyPos.Items.Add(GetPOSG2Name(i));
            }

            GlobalAttPosBox.SelectedIndex = 0;
            MinAttPosBox.SelectedIndex = 0;
            MaxAttPosBox.SelectedIndex = 0;
            MinBodyPos.SelectedIndex = 0;
            MaxBodyPos.SelectedIndex = 0;   
        }

        private void GlobalAttButton_Click(object sender, EventArgs e)
        {
            if (GlobalAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);
            List<List<string>> teamData = new List<List<string>>();
            teamData = CreateStringListsFromCSV(@"resources\FantasyGenData.csv", true);

            double tol = 1;
            string attribute = atb[GlobalAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(GlobalAttNum.Value);
            int posg = GlobalAttPosBox.SelectedIndex - 1;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GlobalAttCheck.Checked & TEAM && val > 0)
                {
                    //prestige-based rating drop :  tol = 0 if 6, .25 if 4-5, .5 if 2-3, 1 if 0-1. // 1 if TDYN
                    int prs = FindTeamPrestige(GetDBValueInt("PLAY", "PGID", i) / 70);
                    if (prs >= 6) tol = .8;
                    else if (prs >= 4) tol = 0.6;
                    else if (prs >= 2) tol = 0.4;
                    else tol = .2;
                }
                else if (GlobalAttCheck.Checked & TEAM && val < 0)
                {
                    //prestige-based rating drop :  tol = 0 if 6, .25 if 4-5, .5 if 2-3, 1 if 0-1. // 1 if TDYN
                    int prs = FindTeamPrestige(GetDBValueInt("PLAY", "PGID", i) / 70);
                    if (prs >= 6) tol = .2;
                    else if (prs >= 4) tol = 0.4;
                    else if (prs >= 2) tol = 0.8;
                    else tol = 1;
                }
                else if (GlobalAttCheck.Checked && val > 0)
                {
                    //prestige-based rating drop :  tol = 0 if 6, .25 if 4-5, .5 if 2-3, 1 if 0-1. // 1 if TDYN
                    int prs = GetFantasyTeamRating(teamData, GetDBValueInt("PLAY", "PGID", i) / 70);
                    if (prs >= 6) tol = .8;
                    else if (prs >= 4) tol = 0.6;
                    else if (prs >= 2) tol = 0.4;
                    else tol = .2;
                }
                else if (GlobalAttCheck.Checked && val < 0)
                {
                    //prestige-based rating drop :  tol = 0 if 6, .25 if 4-5, .5 if 2-3, 1 if 0-1. // 1 if TDYN
                    int prs = GetFantasyTeamRating(teamData, GetDBValueInt("PLAY", "PGID", i) / 70);
                    if (prs >= 6) tol = .2;
                    else if (prs >= 4) tol = 0.4;
                    else if (prs >= 2) tol = 0.8;
                    else tol = 1;
                }


                if (posg == -1)
                {
                    UpdatePlayerAttribute(i, val, attribute, tol);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
                {
                    UpdatePlayerAttribute(i, val, attribute, tol);
                }

                progressBar1.PerformStep();
            }

            MessageBox.Show("Attribute has been updated!\n\nRecalculate Player Overall and Team Ratings when completed!");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void MinAttButton_Click(object sender, EventArgs e)
        {
            if (MinAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);
            string attribute = atb[MinAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(MinAttNum.Value);
            int posg = MinAttPosBox.SelectedIndex - 1;

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating < val) ChangeDBInt("PLAY", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating < val) ChangeDBInt("PLAY", attribute, i, val);
                }

                progressBar1.PerformStep();
            }

            MessageBox.Show("Attribute has been updated!\n\nRecalculate Player Overall and Team Ratings when completed!");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void MaxAttButton_Click(object sender, EventArgs e)
        {
            if (MaxAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);
            string attribute = atb[MaxAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(MaxAttNum.Value);
            int posg = MaxAttPosBox.SelectedIndex - 1;

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating > val) ChangeDBInt("PLAY", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating > val) ChangeDBInt("PLAY", attribute, i, val);
                }

                progressBar1.PerformStep();
            }

            MessageBox.Show("Attribute has been updated!\n\nRecalculate Player Overall and Team Ratings when completed!");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void UpdatePlayerAttribute(int rec, int val, string attribute, double tol)
        {
            int rating = 0;
            if (val > 0) rating = GetDBValueInt("PLAY", attribute, rec) + rand.Next(Convert.ToInt32(tol * (double)val), val);
            else rating = GetDBValueInt("PLAY", attribute, rec) + rand.Next(val, Convert.ToInt32(tol * (double)val));

            if (rating < 0) rating = 0;
            if (rating > maxRatingVal) rating = maxRatingVal;

            ChangeDBInt("PLAY", attribute, rec, rating);
        }

        private void MinAttNum_ValueChanged(object sender, EventArgs e)
        {
            MinAttRating.Text = Convert.ToString(ConvertRating(Convert.ToInt32(MinAttNum.Value)));
        }

        private void MaxAttNum_ValueChanged(object sender, EventArgs e)
        {
            MaxAttRating.Text = Convert.ToString(ConvertRating(Convert.ToInt32(MaxAttNum.Value)));
        }

        //Body Size
        //0 - Height ; 1 - Weight


        private void MinBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MinBodyType.SelectedIndex == -1) return;
            else if (MinBodyType.SelectedIndex == 0)
            {
                MinBodyValue.Minimum = 0;
                MinBodyValue.Maximum = 127;
                MinBodyValue.Value = 0;
            }
            else if (MinBodyType.SelectedIndex == 1)
            {
                MinBodyValue.Minimum = 160;
                MinBodyValue.Maximum = 160+255;
                MinBodyValue.Value = 160;
            }
        }

        private void MaxBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MaxBodyType.SelectedIndex == -1) return;
            else if (MaxBodyType.SelectedIndex == 0)
            {
                MaxBodyValue.Minimum = 0;
                MaxBodyValue.Maximum = 127;
                MaxBodyValue.Value = 78;
            }
            else if (MaxBodyType.SelectedIndex == 1)
            {
                MaxBodyValue.Minimum = 160;
                MaxBodyValue.Maximum = 160 + 255;
                MaxBodyValue.Value = 415;
            }
        }


        private void UpdateMinBody_Click(object sender, EventArgs e)
        {
            if (MinBodyType.SelectedIndex == -1) return;

            int val = Convert.ToInt32(MinBodyValue.Value);
            int posg = MinBodyPos.SelectedIndex - 1;
            string attribute = "PHGT";
            if (MinBodyType.SelectedIndex == 1)
            {
                attribute = "PWGT";
                val = val - 160;
            }

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating < val) ChangeDBInt("PLAY", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating < val) ChangeDBInt("PLAY", attribute, i, val);
                }

                progressBar1.PerformStep();
            }

            MessageBox.Show("Body Attribute was updated!");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void UpdateMaxBody_Click(object sender, EventArgs e)
        {
            if (MaxBodyType.SelectedIndex == -1) return;

            int val = Convert.ToInt32(MaxBodyValue.Value);
            int posg = MaxBodyPos.SelectedIndex - 1;
            string attribute = "PHGT";
            if (MaxBodyType.SelectedIndex == 1)
            {
                attribute = "PWGT";
                val = val - 160;
            }

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating > val) ChangeDBInt("PLAY", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("PLAY", attribute, i);
                    if (rating > val) ChangeDBInt("PLAY", attribute, i, val);
                }

                progressBar1.PerformStep();
            }

            MessageBox.Show("Body Attribute was updated!");
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        #endregion

    }

}
