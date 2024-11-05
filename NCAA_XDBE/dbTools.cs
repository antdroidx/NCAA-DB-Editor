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
        }

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
            if (TEAM) CalculateTeamRatings("TEAM");
            if (TDYN) CalculateTeamRatings("TDYN");
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

        //Increases minium speed for skill positions to 80
        private void IncreaseMinimumSpeed()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValue("PLAY", "PPOS", i) == "1" || GetDBValue("PLAY", "PPOS", i) == "3"
                    || GetDBValue("PLAY", "PPOS", i) == "16" || GetDBValue("PLAY", "PPOS", i) == "17" || GetDBValue("PLAY", "PPOS", i) == "18")
                {
                    if (Convert.ToInt32(GetDBValue("PLAY", "PSPD", i)) < 14)
                    {
                        ChangeDBString("PLAY", "PSPD", i, "14");
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Speed updates are complete!");
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

        //Assign Random Coach Prestige to Free Agents
        private void AssignCoachPrestigeFreeAgents()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                if (GetDBValueInt("COCH", "TGID", i) == 511)
                {
                    ChangeDBInt("COCH", "CPRE", i, rand.Next(1, 4));
                }
                progressBar1.PerformStep();
            }

            MessageBox.Show("Free Agent Coaches now have prestige!");
            progressBar1.Value = 0;
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
        public void CalculateTeamRatings(string tableName)
        {

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;


            int rating, count;
            int bonus = 0;

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (GetDBValueInt(tableName, "TTYP", i) < 1)
                {
                    int TOID = GetDBValueInt(tableName, "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    count = 0;
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
                    roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));


                    //TRDB - Defensive Backs  PPOS = 16, 17, 18
                    rating = 0;
                    count = 0;
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

                    ChangeDBString(tableName, "TRDB", i, Convert.ToString(rating));


                    //TRLB - Linebackers 13, 14, 15
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 13 && PPOS <= 15)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 4) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    ChangeDBString(tableName, "TRLB", i, Convert.ToString(rating));



                    //TRQB - Quarterbacks 0
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS == 0)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 1) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    ChangeDBString(tableName, "TRQB", i, Convert.ToString(rating));


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

                    ChangeDBString(tableName, "TRRB", i, Convert.ToString(rating));

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

                    ChangeDBString(tableName, "TRDL", i, Convert.ToString(rating));

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

                    ChangeDBString(tableName, "TROL", i, Convert.ToString(rating));

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

                    ChangeDBString(tableName, "TWRR", i, Convert.ToString(rating));

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

                    rating = ConvertRating(rating / count) + bonus;

                    ChangeDBString(tableName, "TRST", i, Convert.ToString(rating));


                    //TRDE - Defense 10 - 18, 20
                    rating = (Convert.ToInt32(GetDBValue(tableName, "TRDB", i)) + Convert.ToInt32(GetDBValue(tableName, "TRLB", i)) + Convert.ToInt32(GetDBValue(tableName, "TRDL", i))) / 3;

                    ChangeDBString(tableName, "TRDE", i, Convert.ToString(rating));

                    //TROF - Offense 0 - 9, 19
                    rating = (Convert.ToInt32(GetDBValue(tableName, "TRQB", i)) * 2 + Convert.ToInt32(GetDBValue(tableName, "TRRB", i)) + Convert.ToInt32(GetDBValue(tableName, "TWRR", i)) + Convert.ToInt32(GetDBValue(tableName, "TROL", i))) / 5;

                    ChangeDBString(tableName, "TROF", i, Convert.ToString(rating));

                    //TROV - Team Overall
                    rating = (Convert.ToInt32(GetDBValue(tableName, "TROF", i))*3 + Convert.ToInt32(GetDBValue(tableName, "TRDE", i))*3 + Convert.ToInt32(GetDBValue(tableName, "TRST", i))) / 7;

                    ChangeDBString(tableName, "TROV", i, Convert.ToString(rating));


                    progressBar1.PerformStep();

                }
            }

            NormalizeTeamRatings(tableName);

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Team Rating Calculations are complete!");
        }

        //Calculate Single Team Ratings
        public void CalculateTeamRatingsSingle(string tableName, int tgid)
        {

            int rating, count;
            int bonus = 0;
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

            count = 0;
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
            roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));


            //TRDB - Defensive Backs  PPOS = 16, 17, 18
            rating = 0;
            count = 0;
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

            ChangeDBString(tableName, "TRDB", i, Convert.ToString(rating));


            //TRLB - Linebackers 13, 14, 15
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS >= 13 && PPOS <= 15)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 4) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRLB", i, Convert.ToString(rating));



            //TRQB - Quarterbacks 0
            rating = 0;
            count = 0;
            for (int j = 0; j < roster.Count; j++)
            {
                int PPOS = roster[j][1];

                if (PPOS == 0)
                {
                    rating += roster[j][0];
                    count++;
                }
                if (count >= 1) break;
            }

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRQB", i, Convert.ToString(rating));


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

            ChangeDBString(tableName, "TRRB", i, Convert.ToString(rating));

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

            ChangeDBString(tableName, "TRDL", i, Convert.ToString(rating));

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

            ChangeDBString(tableName, "TROL", i, Convert.ToString(rating));

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

            ChangeDBString(tableName, "TWRR", i, Convert.ToString(rating));

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

            rating = ConvertRating(rating / count) + bonus;

            ChangeDBString(tableName, "TRST", i, Convert.ToString(rating));


            //TRDE - Defense 10 - 18, 20
            rating = (Convert.ToInt32(GetDBValue(tableName, "TRDB", i)) + Convert.ToInt32(GetDBValue(tableName, "TRLB", i)) + Convert.ToInt32(GetDBValue(tableName, "TRDL", i))) / 3;

            ChangeDBString(tableName, "TRDE", i, Convert.ToString(rating));

            //TROF - Offense 0 - 9, 19
            rating = (Convert.ToInt32(GetDBValue(tableName, "TRQB", i)) * 2 + Convert.ToInt32(GetDBValue(tableName, "TRRB", i)) + Convert.ToInt32(GetDBValue(tableName, "TWRR", i)) + Convert.ToInt32(GetDBValue(tableName, "TROL", i))) / 5;

            ChangeDBString(tableName, "TROF", i, Convert.ToString(rating));

            //TROV - Team Overall
            rating = (Convert.ToInt32(GetDBValue(tableName, "TROF", i)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRDE", i)) * 3 + Convert.ToInt32(GetDBValue(tableName, "TRST", i))) / 7;

            ChangeDBString(tableName, "TROV", i, Convert.ToString(rating));

            NormalizeTeamRatings(tableName);

            MessageBox.Show(teamNameDB[tgid] + " Team Rating Calculations are complete!");
        }

        public void NormalizeTeamRatings(string tableName)
        {
            double meanOff = 78;
            double meanDef = 78;
            double rangeOffFactor = 1.33;
            double rangeDefFactor = 1.33;
            List<int> offRatings = new List<int>();
            List<int> defRatings = new List<int>();

            if (GetTableRecCount("TEAM") >= 119)
            {
                //Collect Team Rating Data
                for (int x = 0; x < GetTableRecCount(tableName); x++)
                {
                    if (TEAM && GetDBValueInt(tableName, "TTYP", x) < 1 || TDYN)
                    {
                        offRatings.Add(GetDBValueInt(tableName, "TROF", x));
                        defRatings.Add(GetDBValueInt(tableName, "TRDE", x));
                    }
                }

                //Calculate Stats
                meanOff = offRatings.Average();
                meanDef = defRatings.Average();
                int rangeOff = offRatings.Max() - offRatings.Min();
                int rangeDef = defRatings.Max() - defRatings.Min();
                rangeOffFactor = 44 / rangeOff;
                rangeDefFactor = 44 / rangeDef;
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
                    ChangeDBInt(tableName, "TROV", x, (offRating+defRating)/2);
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


            int recCounter = GetTableRecCount("PLAY");
            int maxRecords = TableProps.Capacity;
            int created = 0;

            //Create a list of PGIDs in the database

            List<int> rosters = new List<int>();
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                rosters.Add(GetDBValueInt("PLAY", "PGID", i));
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

                    for (int j = pgidSTART; j < pgidEND; j++)
                    {
                        if (!rosters.Contains(j) && recCounter < maxRecords)
                        {
                            List<int> POSG = new List<int> { 3, 5, 6, 3, 12, 12, 7, 11, 2, 1 };
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


                            if (TeamPos[8] < POSG[8]) TransferRCATtoPLAY(recCounter, 19, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[9] < POSG[9]) TransferRCATtoPLAY(recCounter, 20, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[0] < POSG[0]) TransferRCATtoPLAY(recCounter, 0, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[1] < POSG[1]) TransferRCATtoPLAY(recCounter, 1, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[2] < POSG[2]) TransferRCATtoPLAY(recCounter, 3, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[3] < POSG[3]) TransferRCATtoPLAY(recCounter, 4, j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[4] < POSG[4]) TransferRCATtoPLAY(recCounter, rand.Next(5, 10), j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[5] < POSG[5]) TransferRCATtoPLAY(recCounter, rand.Next(10, 13), j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[6] < POSG[6]) TransferRCATtoPLAY(recCounter, rand.Next(13, 16), j, RCATmapper, PJEN, FreshmanPCT);
                            else if (TeamPos[7] < POSG[7]) TransferRCATtoPLAY(recCounter, rand.Next(16, 19), j, RCATmapper, PJEN, FreshmanPCT);

                            else TransferRCATtoPLAY(recCounter, rand.Next(0, 19), j, RCATmapper, PJEN, FreshmanPCT);


                            RandomizePlayerHead("PLAY", recCounter);

                            recCounter++;
                            created++;
                        }
                    }


                    //Check for Kickers and Punters
                    List<int> POSG2 = new List<int> { 3, 5, 6, 3, 12, 12, 7, 11, 2, 1 };
                    List<int> TeamPos2 = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    List<List<int>> Diff = new List<List<int>>();
                    List<List<int>> list = new List<List<int>>();
                    int rowx = 0;
                    for (int k = 0; k < GetTableRecCount("PLAY"); k++)
                    {
                        int pgid = GetDBValueInt("PLAY", "PGID", k);
                        if (pgid >= pgidSTART && pgid < pgidEND)
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

                            list.Add(new List<int>());
                            list[rowx].Add(GetDBValueInt("PLAY", "POVR", k));
                            list[rowx].Add(GetDBValueInt("PLAY", "PPOS", k));
                            list[rowx].Add(k);
                            list[rowx].Add(GetDBValueInt("PLAY", "PGID", k));


                            rowx++;

                        }
                    }


                    for (int k = 0; k < 10; k++)
                    {
                        Diff.Add(new List<int>());
                        Diff[k].Add(POSG2[k] - TeamPos2[k]);
                    }


                    //Diff.Sort();
                    //Diff.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

                    for (int k = 9; k >= 0; k--)
                    {
                        if (Diff[k][0] > 0)
                        {
                            list.Sort((player1, player2) => player2[0].CompareTo(player1[0]));
                            for (int x = list.Count - 1; x >= 0; x--)
                            {
                                if (list[x][1] != 19 && list[x][1] != 20)
                                {
                                    TransferRCATtoPLAY(list[x][2], ChooseRandomPosFromPOSG(k), list[x][3], RCATmapper, PJEN, 50);
                                    RandomizePlayerHead("PLAY", Convert.ToInt32(list[x][2]));
                                    list.RemoveAt(x);
                                    break;
                                }
                            }
                        }
                    }
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

        #endregion

        #region Fantasy Roster Generator
        //Fantasy Roster Generator
        private void FantasyRosterGenerator(string tableName)
        {
            /* Creates a fantasy roster from team overall rating
             * Use RCAT, sort by position, count position players
             * randomize each raing + random from 0 to overall rating/10
             * make sure there's a mininum number of positions then randomize rest
             */


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            //Clear PLAY Table
            for (int i = GetTableRecCount("PLAY"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "PLAY", i);
            }
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            List<List<string>> teamData = new List<List<string>>();
            teamData = CreateStringListsFromCSV(@"resources\FantasyGenData.csv", true);

            int rec = 0;

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TDYN || GetDBValueInt(tableName, "TTYP", i) == 0)
                {
                    int TOID = GetDBValueInt(tableName, "TOID", i);
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

                    //Finish team and perform step counter
                    progressBar1.PerformStep();
                }
            }


            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Fantasy Players Created!");

            RecalculateOverall();
            RandomizeRecruitFace("PLAY");
            RecalculateBMI("PLAY");
            RecalculateQBTendencies();
            CalculateTeamRatings(tableName);

            MessageBox.Show("Fantasy Roster Generation is complete!\n\nRun the Depth Chart Tool to create Depth Charts!");

        }

        public void FantasyRosterGeneratorSingle(int tgid, int rating)
        {

            //Remove existing Players
            ClearTeamPlayers(tgid);


            //Clear Old Stats
            ClearOldTeamStats(tgid);

            //Create New Roster
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            CreateTeamDB();


            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            int rec = GetTableRecCount("PLAY");
            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;
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

            CalculateTeamRatingsSingle("TEAM", tgid);
            DepthChartMakerSingle("TEAM", tgid);

            MessageBox.Show(teamNameDB[tgid] + " Roster has been generated.");
        }


        private int GetFantasyTeamRating(List<List<String>> teamData, int TGID)
        {
            int value = 0;

            for (int i = 0; i < teamData.Count; i++)
            {
                if (teamData[i][0] == Convert.ToString(TGID))
                {
                    return Convert.ToInt32(teamData[i][2]);
                }
            }

            return value;
        }

        //Transfers RCAT to PLAY field
        private void TransferRCATtoPLAY(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN, int FreshmanPCT)
        {
            bool x = true;
            while (x)
            {
                int r = rand.Next(0, RCAT.Count);
                if (RCAT[r][45] == ppos)
                {
                    for (int i = 0; i < map.Count; i++)
                    {
                        int RCATcol = Convert.ToInt32(map[i][0]); //finds the column number that the RCAT attribute value lives in
                        string field = map[i][1]; //finds the name of the attribute

                        ChangeDBString("PLAY", field, rec, Convert.ToString(RCAT[r][RCATcol]));
                    }

                    string redshirt = "0";
                    if (rand.Next(0, 3) > 2) redshirt = "2";

                    ChangeDBInt("PLAY", "RCHD", rec, rand.Next(0, 12864)); //hometown
                    ChangeDBString("PLAY", "PGID", rec, Convert.ToString(PGID)); //player id
                    ChangeDBString("PLAY", "PHPD", rec, "0"); //PHPD
                    ChangeDBString("PLAY", "PRSD", rec, redshirt); //Redshirt
                    ChangeDBString("PLAY", "PLMG", rec, "0"); //Mouthguard
                    ChangeDBString("PLAY", "PFGM", rec, "0"); //face shape (to be calculated later)
                    ChangeDBInt("PLAY", "PJEN", rec, ChooseJerseyNumber(ppos, PJEN)); //jersey num
                    ChangeDBString("PLAY", "PTEN", rec, "0"); //tendency (to be calculated later)
                    ChangeDBString("PLAY", "PFMP", rec, "0"); //face (to be calculated later)
                    ChangeDBInt("PLAY", "PIMP", rec, rand.Next(0, 32)); //importance (to be re-calculated later)
                    ChangeDBString("PLAY", "PTYP", rec, "0"); //player type (graduation/nfl,etc)
                    ChangeDBString("PLAY", "POVR", rec, "0"); //overall, to be calculated later
                    ChangeDBString("PLAY", "PSLY", rec, "0"); //PSLY
                    ChangeDBString("PLAY", "PRST", rec, "0"); //PRST

                    if (rand.Next(1, 101) < FreshmanPCT) ChangeDBInt("PLAY", "PYER", rec, 0); //year/class
                    else ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 4)); //year/class

                    string FN, LN;

                    FN = FirstNames[rand.Next(0, FirstNames.Count)];
                    LN = LastNames[rand.Next(0, LastNames.Count)];

                    ConvertFirstNameStringToInt(FN, rec, "PLAY");
                    ConvertLastNameStringToInt(LN, rec, "PLAY");

                    x = false;
                }
            }
        }

        //Randomize the Players to give a little bit more variety and evaluation randomness
        private void RandomizeAttribute(string TableName, int rec, int tol)
        {
            tol += 3 - GetDBValueInt("PLAY", "PYER", rec);

            int tolB = tol / 2;  //half the tolerance for specific attributes

            //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
            //PPOE, PINJ, PAWR

            int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PIMP, PDIS;

            PHGT = Convert.ToInt32(GetDBValue(TableName, "PHGT", rec));
            PWGT = Convert.ToInt32(GetDBValue(TableName, "PWGT", rec));
            PAWR = Convert.ToInt32(GetDBValue(TableName, "PAWR", rec));

            PTHA = Convert.ToInt32(GetDBValue(TableName, "PTHA", rec));
            PSTA = Convert.ToInt32(GetDBValue(TableName, "PSTA", rec));
            PKAC = Convert.ToInt32(GetDBValue(TableName, "PKAC", rec));
            PACC = Convert.ToInt32(GetDBValue(TableName, "PACC", rec));
            PSPD = Convert.ToInt32(GetDBValue(TableName, "PSPD", rec));
            PCTH = Convert.ToInt32(GetDBValue(TableName, "PCTH", rec));
            PAGI = Convert.ToInt32(GetDBValue(TableName, "PAGI", rec));
            PTAK = Convert.ToInt32(GetDBValue(TableName, "PTAK", rec));
            PPBK = Convert.ToInt32(GetDBValue(TableName, "PPBK", rec));
            PRBK = Convert.ToInt32(GetDBValue(TableName, "PRBK", rec));
            PBTK = Convert.ToInt32(GetDBValue(TableName, "PBTK", rec));
            PTHP = Convert.ToInt32(GetDBValue(TableName, "PTHP", rec));
            PJMP = Convert.ToInt32(GetDBValue(TableName, "PJMP", rec));
            PCAR = Convert.ToInt32(GetDBValue(TableName, "PCAR", rec));
            PKPR = Convert.ToInt32(GetDBValue(TableName, "PKPR", rec));
            PSTR = Convert.ToInt32(GetDBValue(TableName, "PSTR", rec));
            PDIS = Convert.ToInt32(GetDBValue(TableName, "PDIS", rec));

            PBRE = rand.Next(0, 2);
            PEYE = rand.Next(0, 2);
            PHGT += rand.Next(0, 0);
            PWGT += rand.Next(-8, 9);
            if (PWGT < 0) PWGT = 0;
            if (PWGT > 340) PWGT = 340;
            if (PHGT > 82) PHGT = 82;
            if (PHGT < 0) PHGT = 0;

            PPOE = rand.Next(1, 30);
            PINJ = rand.Next(1, 30);
            PIMP = rand.Next(1, 30);
            PAWR = GetRandomPositiveAttribute(PAWR, tolB);
            PDIS = rand.Next(2, 7);

            PSTA = GetRandomPositiveAttribute(PSTA, tol);
            PKAC = GetRandomPositiveAttribute(PKAC, tol);
            PACC = GetRandomPositiveAttribute(PACC, tolB);
            PSPD = GetRandomPositiveAttribute(PSPD, tolB);
            PCTH = GetRandomPositiveAttribute(PCTH, tol);
            PAGI = GetRandomPositiveAttribute(PAGI, tolB);
            PTAK = GetRandomPositiveAttribute(PTAK, tol);
            PPBK = GetRandomPositiveAttribute(PPBK, tol);
            PRBK = GetRandomPositiveAttribute(PRBK, tol);
            PBTK = GetRandomPositiveAttribute(PBTK, tol);

            PJMP = GetRandomPositiveAttribute(PJMP, tol);
            PCAR = GetRandomPositiveAttribute(PCAR, tol);
            PKPR = GetRandomPositiveAttribute(PKPR, tol);
            PSTR = GetRandomPositiveAttribute(PSTR, tol);

            if (GetDBValueInt("PLAY", "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, tol);
                PTHP = GetRandomPositiveAttribute(PTHP, tol);
            }


            ChangeDBString(TableName, "PBRE", rec, Convert.ToString(PBRE));
            ChangeDBString(TableName, "PEYE", rec, Convert.ToString(PEYE));
            ChangeDBString(TableName, "PPOE", rec, Convert.ToString(PPOE));
            ChangeDBString(TableName, "PINJ", rec, Convert.ToString(PINJ));
            ChangeDBString(TableName, "PAWR", rec, Convert.ToString(PAWR));
            ChangeDBString(TableName, "PHGT", rec, Convert.ToString(PHGT));
            ChangeDBString(TableName, "PWGT", rec, Convert.ToString(PWGT));


            ChangeDBString(TableName, "PTHA", rec, Convert.ToString(PTHA));
            ChangeDBString(TableName, "PSTA", rec, Convert.ToString(PSTA));
            ChangeDBString(TableName, "PKAC", rec, Convert.ToString(PKAC));
            ChangeDBString(TableName, "PACC", rec, Convert.ToString(PACC));
            ChangeDBString(TableName, "PSPD", rec, Convert.ToString(PSPD));
            ChangeDBString(TableName, "PCTH", rec, Convert.ToString(PCTH));
            ChangeDBString(TableName, "PAGI", rec, Convert.ToString(PAGI));
            ChangeDBString(TableName, "PTAK", rec, Convert.ToString(PTAK));
            ChangeDBString(TableName, "PPBK", rec, Convert.ToString(PPBK));
            ChangeDBString(TableName, "PRBK", rec, Convert.ToString(PRBK));
            ChangeDBString(TableName, "PBTK", rec, Convert.ToString(PBTK));
            ChangeDBString(TableName, "PTHP", rec, Convert.ToString(PTHP));
            ChangeDBString(TableName, "PJMP", rec, Convert.ToString(PJMP));
            ChangeDBString(TableName, "PCAR", rec, Convert.ToString(PCAR));
            ChangeDBString(TableName, "PKPR", rec, Convert.ToString(PKPR));
            ChangeDBString(TableName, "PSTR", rec, Convert.ToString(PSTR));
            ChangeDBString(TableName, "PIMP", rec, Convert.ToString(PIMP));
            ChangeDBString(TableName, "PDIS", rec, Convert.ToString(PDIS));
        }

        private int ChooseJerseyNumber(int PPOS, List<List<int>> PJEN)
        {
            int jersey = 99;

            for (int i = 0; i < PJEN.Count; i++)
            {
                if (PJEN[i][0] == PPOS)
                {
                    return rand.Next(PJEN[i][1], PJEN[i][2] + 1);
                }
            }

            return jersey;
        }
        #endregion

        #region Depth Chart Maker
        //Depth Chart Maker
        public void DepthChartMaker(string tableName)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;

            //clear DCHT
            for (int i = GetTableRecCount("DCHT"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "DCHT", i);
            }

            CompactDB();

            int count;
            int rec = 0;

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TDYN || GetDBValueInt(tableName, "TTYP", i) == 0)
                {
                    int TOID = GetDBValueInt(tableName, "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    count = 0;
                    List<List<int>> roster = new List<List<int>>();

                    for (int j = 0; j < GetTableRecCount("PLAY"); j++)
                    {
                        int PGID = GetDBValueInt("PLAY", "PGID", j);

                        if (PGID >= PGIDbeg && PGID <= PGIDend)
                        {
                            int POVR = GetDBValueInt("PLAY", "POVR", j);
                            int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                            int PRSD = GetDBValueInt("PLAY", "PRSD", j);
                            List<int> player = new List<int>();
                            if (PRSD != 1)
                            {
                                roster.Add(player);
                                roster[count].Add(j);
                                roster[count].Add(PGID);
                                roster[count].Add(PPOS);
                                count++;
                            }
                        }
                    }
                    //roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

                    //Sort Depth Chart  KR = 21 PR = 22 KOS = 23 LS = 24

                    //QBs
                    rec = AddDCHTrecord(rec, 0, 3, roster);
                    //RBs
                    rec = AddDCHTrecord(rec, 1, 4, roster);
                    //WRs
                    rec = AddDCHTrecord(rec, 3, 6, roster);
                    //TEs
                    rec = AddDCHTrecord(rec, 4, 3, roster);
                    //LTs
                    rec = AddDCHTrecord(rec, 5, 3, roster);
                    //RTs
                    rec = AddDCHTrecord(rec, 9, 3, roster);
                    //Cs
                    rec = AddDCHTrecord(rec, 7, 3, roster);
                    //LGs
                    rec = AddDCHTrecord(rec, 6, 3, roster);
                    //RG
                    rec = AddDCHTrecord(rec, 8, 3, roster);
                    //LEs
                    rec = AddDCHTrecord(rec, 10, 3, roster);
                    //RE
                    rec = AddDCHTrecord(rec, 11, 3, roster);
                    //DT
                    rec = AddDCHTrecord(rec, 12, 5, roster);
                    //MLBs
                    rec = AddDCHTrecord(rec, 14, 4, roster);
                    //ROLBs
                    rec = AddDCHTrecord(rec, 15, 3, roster);
                    //LOLBs
                    rec = AddDCHTrecord(rec, 13, 3, roster);
                    //CBs
                    rec = AddDCHTrecord(rec, 16, 5, roster);
                    //FSs
                    rec = AddDCHTrecord(rec, 18, 3, roster);
                    //SSs
                    rec = AddDCHTrecord(rec, 17, 3, roster);
                    //FBs
                    rec = AddDCHTrecord(rec, 2, 3, roster);
                    //Ks
                    rec = AddDCHTrecord(rec, 19, 3, roster);
                    //Ps
                    rec = AddDCHTrecord(rec, 20, 3, roster);
                    //KRs
                    rec = AddDCHTrecord(rec, 21, 5, roster);
                    //PRs
                    rec = AddDCHTrecord(rec, 22, 5, roster);
                    //KOSs
                    rec = AddDCHTrecord(rec, 23, 3, roster);
                    //LSs
                    rec = AddDCHTrecord(rec, 24, 3, roster);

                    progressBar1.PerformStep();

                }
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Depth Charts are complete!");
        }

        public void DepthChartMakerSingle(string tableName, int tgid)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount(tableName);
            progressBar1.Step = 1;

            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;

            //clear DCHT
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if(GetDBValueInt("DCHT", "PGID", i) >= PGIDbeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDend)

                DeleteRecordChange("DCHT", i, true);
            }

            CompactDB();

            
            int rec = TDB.TableRecordCount(dbIndex, "DCHT");
            int count = 0;
            List<List<int>> roster = new List<List<int>>();

            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);

                if (PGID >= PGIDbeg && PGID <= PGIDend)
                {
                    int POVR = GetDBValueInt("PLAY", "POVR", j);
                    int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                    int PRSD = GetDBValueInt("PLAY", "PRSD", j);
                    List<int> player = new List<int>();
                    if (PRSD != 1)
                    {
                        roster.Add(player);
                        roster[count].Add(j);
                        roster[count].Add(PGID);
                        roster[count].Add(PPOS);
                        count++;
                    }
                }
            }
            //Sort Depth Chart  KR = 21 PR = 22 KOS = 23 LS = 24

            //QBs
            rec = AddDCHTrecord(rec, 0, 3, roster);
            //RBs
            rec = AddDCHTrecord(rec, 1, 4, roster);
            //WRs
            rec = AddDCHTrecord(rec, 3, 6, roster);
            //TEs
            rec = AddDCHTrecord(rec, 4, 3, roster);
            //LTs
            rec = AddDCHTrecord(rec, 5, 3, roster);
            //RTs
            rec = AddDCHTrecord(rec, 9, 3, roster);
            //Cs
            rec = AddDCHTrecord(rec, 7, 3, roster);
            //LGs
            rec = AddDCHTrecord(rec, 6, 3, roster);
            //RG
            rec = AddDCHTrecord(rec, 8, 3, roster);
            //LEs
            rec = AddDCHTrecord(rec, 10, 3, roster);
            //RE
            rec = AddDCHTrecord(rec, 11, 3, roster);
            //DT
            rec = AddDCHTrecord(rec, 12, 5, roster);
            //MLBs
            rec = AddDCHTrecord(rec, 14, 4, roster);
            //ROLBs
            rec = AddDCHTrecord(rec, 15, 3, roster);
            //LOLBs
            rec = AddDCHTrecord(rec, 13, 3, roster);
            //CBs
            rec = AddDCHTrecord(rec, 16, 5, roster);
            //FSs
            rec = AddDCHTrecord(rec, 18, 3, roster);
            //SSs
            rec = AddDCHTrecord(rec, 17, 3, roster);
            //FBs
            rec = AddDCHTrecord(rec, 2, 3, roster);
            //Ks
            rec = AddDCHTrecord(rec, 19, 3, roster);
            //Ps
            rec = AddDCHTrecord(rec, 20, 3, roster);
            //KRs
            rec = AddDCHTrecord(rec, 21, 5, roster);
            //PRs
            rec = AddDCHTrecord(rec, 22, 5, roster);
            //KOSs
            rec = AddDCHTrecord(rec, 23, 3, roster);
            //LSs
            rec = AddDCHTrecord(rec, 24, 3, roster);

            progressBar1.PerformStep();



            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show(teamNameDB[tgid] + " Depth Charts are complete!");
        }

        public void DepthChartRemoveTeam(int tgid)
        {

            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;

            //clear DCHT
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) >= PGIDbeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDend)

                    DeleteRecordChange("DCHT", i, true);
            }

            CompactDB();
        }

        private int AddDCHTrecord(int rec, int ppos, int depthCount, List<List<int>> roster)
        {
            //Determine Position Ratings and sort by Position Overall Rating
            List<List<int>> PosRating = new List<List<int>>();
            int rating = 0;

            for (int k = 0; k < roster.Count; k++)
            {
                if (ppos <= 20) rating = CalculatePositionRating(roster[k][0], ppos);
                else if (ppos == 21) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 22) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 23) rating = CalculatePositionRating(roster[k][0], 19);
                else if (ppos == 24) rating = CalculatePositionRating(roster[k][0], 5);
                PosRating.Add(new List<int>());
                if (roster[k][2] == ppos) rating += 15;
                PosRating[k].Add(rating);
                PosRating[k].Add(roster[k][1]);
                PosRating[k].Add(roster[k][2]);

            }

            //sort by rating
            PosRating.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

            int count = 0;
            int i = 0;
            while (count < depthCount)
            {
                if (ppos > 20 || !IsStarter(PosRating[i][1]))
                {
                    AddTableRecord("DCHT", false);
                    int pgid = PosRating[i][1];
                    ChangeDBString("DCHT", "PGID", rec, Convert.ToString(pgid));
                    ChangeDBString("DCHT", "PPOS", rec, Convert.ToString(ppos));
                    ChangeDBString("DCHT", "ddep", rec, Convert.ToString(count));
                    count++;
                    rec++;
                }
                i++;
            }

            return rec;
        }

        private bool IsStarter(int pgid)
        {
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) == pgid && GetDBValueInt("DCHT", "ddep", i) == 0) return true;
            }
            return false;
        }
        #endregion

        #region Fantasy Coach Generators

        private void CreateFantasyCoach(int rec)
        {
            //collect ccid and tgid
            int ccid = GetDBValueInt("COCH", "CCID", rec);
            int tgid = GetDBValueInt("COCH", "TGID", rec);
            int cfuc = GetDBValueInt("COCH", "CFUC", rec);

            //reset stats

            TdbFieldProperties FieldProps = new TdbFieldProperties();
            
            for(int i = 0; i < TDB.FieldCount(dbIndex, "COCH"); i++)
            {
                TDB.TDBFieldGetProperties(dbIndex, "COCH", i, ref FieldProps);

                ChangeDBInt("COCH", FieldProps.Name, rec, 0);
            }

            //set CPID CLTF and CLTR

            ChangeDBInt("COCH", "CPID", rec, 511);
            ChangeDBInt("COCH", "CLTF", rec, 65535);
            ChangeDBInt("COCH", "CLTR", rec, 65535);

            //Set CCID & TGID
            ChangeDBInt("COCH", "CCID", rec, ccid);
            ChangeDBInt("COCH", "TGID", rec, tgid);
            ChangeDBInt("COCH", "CFUC", rec, cfuc);
            ChangeDBInt("COCH", "CFRC", rec, 1);
            ChangeDBInt("COCH", "CSAS", rec, 1);

            //set ccpo & ctop
            ChangeDBInt("COCH", "CCPO", rec, 60);
            ChangeDBInt("COCH", "CTOP", rec, FindTeamPrestige(tgid));

            //name
            CreateFirstNamesDB();
            CreateLastNamesDB();
            string FN, LN;
            FN = FirstNames[rand.Next(0, FirstNames.Count)];
            LN = LastNames[rand.Next(0, LastNames.Count)];
            ChangeDBString("COCH", "CLFN", rec, FN);
            ChangeDBString("COCH", "CLLN", rec, LN);

            //skin, body, hair color, hair style, face, glasses, headwear
            ChangeDBInt("COCH", "CSKI", rec, rand.Next(0,6));
            ChangeDBInt("COCH", "CBSZ", rec, rand.Next(0, 3));
            ChangeDBInt("COCH", "CHAR", rec, rand.Next(0, 5));
            ChangeDBInt("COCH", "CThg", rec, rand.Next(0, 11));
            ChangeDBInt("COCH", "CFEX", rec, rand.Next(0, 6));
            ChangeDBInt("COCH", "CTgw", rec, rand.Next(0, 2));
            ChangeDBInt("COCH", "COHT", rec, rand.Next(0, 3));

            //prestige 
            ChangeDBInt("COCH", "CPRE", rec, rand.Next(1, 7));

            //budget
            int disc = rand.Next(20, 30);
            int recruit = rand.Next(25, 40);
            int train = 100 - disc - recruit;

            ChangeDBInt("COCH", "CDPC", rec, disc);
            ChangeDBInt("COCH", "CTPC", rec, train);
            ChangeDBInt("COCH", "CRPC", rec, recruit);

            //playbook & strategy
            if(NextMod) ChangeDBInt("COCH", "CPID", rec, rand.Next(136,159));
            else ChangeDBInt("COCH", "CPID", rec, rand.Next(0, 125));

            ChangeDBInt("COCH", "COST", rec, rand.Next(0, 5));
            ChangeDBInt("COCH", "CDST", rec, rand.Next(0, 5));

            ChangeDBInt("COCH", "COTR", rec, rand.Next(30, 70));
            ChangeDBInt("COCH", "COTA", rec, rand.Next(25, 75));
            ChangeDBInt("COCH", "COTS", rec, rand.Next(50, 80));
            ChangeDBInt("COCH", "CDTR", rec, rand.Next(30, 70));
            ChangeDBInt("COCH", "CDTA", rec, rand.Next(25, 75));
            ChangeDBInt("COCH", "CDTS", rec, rand.Next(50, 80));
        }

        private void CreateFantasyCoachDB()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");

            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                CreateFantasyCoach(i);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Fantasy Coach Database Completed!");
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

            GlobalAttPosBox.Items.Add("ALL");
            MinAttPosBox.Items.Add("ALL");
            MaxAttPosBox.Items.Add("ALL");

            for (int i = 0; i < 10; i++)
            {
                GlobalAttPosBox.Items.Add(GetPOSGName(i));
                MinAttPosBox.Items.Add(GetPOSGName(i));
                MaxAttPosBox.Items.Add(GetPOSGName(i));
            }

            GlobalAttPosBox.SelectedIndex = 0;
            MinAttPosBox.SelectedIndex = 0;
            MaxAttPosBox.SelectedIndex = 0;
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
                else if (GetPOSGfromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
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
                else if (GetPOSGfromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
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
                else if (GetPOSGfromPPOS(GetDBValueInt("PLAY", "PPOS", i)) == posg)
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
            if(val > 0) rating = GetDBValueInt("PLAY", attribute, rec) + rand.Next(Convert.ToInt32(tol * (double)val), val);
            else rating = GetDBValueInt("PLAY", attribute, rec) + rand.Next(val, Convert.ToInt32(tol * (double)val));

            if (rating < 0) rating = 0;
            if (rating > 31) rating = 31;

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



        #endregion

    }

}
