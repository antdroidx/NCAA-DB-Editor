using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        private void StartOffSeasonEditor()
        {
            CompactDB();
            CompactDB2();
        }

        #region RECRUITING TOOLS CLICKS


        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void ButtonMinRecruitingPts_Click(object sender, EventArgs e)
        {
            RaiseMinimumRecruitingPoints();

        }

        //Randomize or Remove Recruiting Interested Teams
        private void ButtonInterestedTeams_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    RemoveInterestedTeams();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        //Randomize the Recruits to give a little bit more variety and evaluation randomness -- Must be done at start of Recruiting
        private void ButtonRandRecruits_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    RandomizeRecruitDB("RCPT");
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }

        }

        //Randomize Walk-On Database -- Must be done prior to Cut Players stage
        private void ButtonRandWalkOns_Click(object sender, EventArgs e)
        {
            RandomizeWalkOnDB();
        }


        //Randomize Face & Skins
        private void buttonRandomizeFaceSkin_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    RandomizeRecruitFace("RCPT");
                    correctWeek = true;
                }
            }
            for (int i = 0; i < GetTable2RecCount("WKON"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    RandomizeRecruitFace("WKON");
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        //Randomize Gears
        private void RandomizeRecruitGear_Click(object sender, EventArgs e)
        {
            RandomizeAllPlayerGears("RCPT");
            RandomizeAllPlayerGears("WKON");
            MessageBox.Show("Player Gears Randomized!");
        }

        //Randomize Names
        private void RandomizeRecruitNamesButton_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    RandomizeRecruitNames("RCPT");
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }

        //Polynesian Surname Generator
        private void PolyNames_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2Value("RCYR", "SEWN", i) == "1")
                {
                    PolynesianNameGenerator();
                    correctWeek = true;
                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
        }


        //Recalculate Star Rankings     
        private void RecalculateStarRankingsButton_Click(object sender, EventArgs e)
        {
            RecalculateAllStarRatings();
        }

        private void DetermineAthleteButton_Click(object sender, EventArgs e)
        {
            ChooseAthletePosition();
        }


        //Auto Adjust Coach Budgets
        private void AutoAdjustCoachBudgetButton2_Click(object sender, EventArgs e)
        {
            AutoAdjustCoachBudgets();
        }

        private void CreateFCSTransferPortalButton_Click(object sender, EventArgs e)
        {
            CreateFCSPlayersForRecruiting();
        }

        //Move Transferred Player Stats Over

        private void TransferPortalStats_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2ValueInt("RCYR", "SEWN", i) >= 5)
                {
                    CompactDB();
                    CompactDB2();
                    MoveTransferredPlayerStats();
                    MessageBox.Show("Transferred Player Stats Moved!");
                    correctWeek = true;

                }
            }
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the after recruiting is completed in off-season!");
            }

        }

        private void MoveTransferredPlayerStats()
        {
            StartProgressBar(GetTableRecCount("TRAN"));

            OccupiedPGIDList = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                OccupiedPGIDList.Add(new List<int>());
            }
            //Add Roster
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {

                int PGID = GetDBValueInt("PLAY", "PGID", i);
                int TGID = PGID / 70;

                if (TGID < 512) OccupiedPGIDList[TGID].Add(PGID);
            }



            //Transfers
            for (int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                int team = -1;
                int rec = -1;
                int PGID = GetDBValueInt("TRAN", "PGID", i);

                for (int r = 0; r < GetTable2RecCount("RCPR"); r++)
                {
                    if (GetDB2ValueInt("RCPR", "PRID", r) == PGID)
                    {
                        rec = r;
                        team = GetDB2ValueInt("RCPR", "PTCM", r);
                        break;
                    }
                }

                //Check for open PGID slots
                for (int j = team * 70; j <= team * 70 + 69; j++)
                {
                    if (!OccupiedPGIDList[team].Contains(j))
                    {
                        ChangePlayerStatsID(PGID, j);

                        ChangePGID(PGID, j);

                        DeleteRecord("TRAN", i, true);
                        DeleteRecord2("RCPR", rec, true);
                        OccupiedPGIDList[team].Add(j);
                        break;
                    }
                }
                ProgressBarStep();
            }

            CompactDB();
            CompactDB2();
            EndProgressBar();

        }


        //Remove Mediocre Transfers from Portal
        private void RemoveBadTransfers_Click(object sender, EventArgs e)
        {
            RemoveTransfers();
        }

        private void RemoveTransfers()
        {
            StartProgressBar(GetTableRecCount("TRAN") + GetTableRecCount("PLAY"));

            List<List<List<int>>> teamPlayers = new List<List<List<int>>>();

            for (int t = 0; t < 512; t++)
            {
                teamPlayers.Add(new List<List<int>>());
            }

            for (int p = 0; p < GetTableRecCount("PLAY"); p++)
            {
                int pgid = GetPGIDfromRecord(p);
                int team = pgid / 70;

                int count = teamPlayers[team].Count;
                teamPlayers[team].Add(new List<int>());
                teamPlayers[team][count].Add(p);
                teamPlayers[team][count].Add(pgid);
                teamPlayers[team][count].Add(GetDBValueInt("PLAY", "POVR", p));
            }


            int counter = 0;
            for (int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                int pgid = GetDBValueInt("TRAN", "PGID", i);
                int tgid = pgid / 70;

                for (int p = 0; p < teamPlayers[tgid].Count; p++)
                {
                    if (teamPlayers[tgid][p][1] == pgid)
                    {
                        if (ConvertRating(teamPlayers[tgid][p][2]) < 65)
                        {
                            ChangeDBInt("PLAY", "PTYP", teamPlayers[tgid][p][0], 3);
                            DeleteRecord("TRAN", i, true);
                            counter++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                }

                ProgressBarStep();
            }


            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (ConvertRating(GetDBValueInt("PLAY", "POVR", i)) < 65 && GetDBValueInt("PLAY", "PTYP", i) == 1)
                {
                    ChangeDBInt("PLAY", "PTYP", i, 3);
                    counter++;
                }
                ProgressBarStep();
            }

            CompactDB();

            EndProgressBar();

            MessageBox.Show("Completed! Removed " + counter + " players from the database.");
        }
        #endregion


        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void RaiseMinimumRecruitingPoints()
        {
            StartProgressBar(GetTable2RecCount("RTRI"));

            Random rand = new Random();

            for (int i = 0; i < GetTable2RecCount("RTRI"); i++)
            {
                int TRPA, TRPR;
                TRPA = GetDB2ValueInt("RTRI", "TRPA", i);
                TRPR = GetDB2ValueInt("RTRI", "TRPR", i);

                if (TRPR < (int)minRecPts.Value) TRPR = (int)minRecPts.Value;
                if (TRPA < (int)minTRPA.Value) TRPA = (int)minTRPA.Value;

                ChangeDB2Int("RTRI", "TRPA", i, TRPA);
                ChangeDB2Int("RTRI", "TRPR", i, TRPR);

                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Team Budgets Changed!");
        }

        //Randomize or Remove Recruiting Interested Teams
        private void RemoveInterestedTeams()
        {
            StartProgressBar(GetTable2RecCount("RCPR"));

            List<int> teamIDs = new List<int>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    teamIDs.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }
            int fcsTeams = 0;
            Random rand = new Random();

            for (int i = 0; i < GetTable2RecCount("RCPR"); i++)
            {
                for (int j = (int)removeInterestTeams.Value; j < 11; j++)
                {
                    if (j < 10)
                    {
                        ChangeDB2String("RCPR", "PS0" + j, i, "0");
                        ChangeDB2String("RCPR", "PT0" + j, i, "511");
                    }
                    else
                    {
                        ChangeDB2String("RCPR", "PS" + j, i, "0");
                        ChangeDB2String("RCPR", "PT" + j, i, "511");
                    }
                }

                //Remove Non-FBS teams
                for (int j = 1; j < 11; j++)
                {
                    if (j < 10)
                    {
                        int TGID = GetDB2ValueInt("RCPR", "PT0" + j, i);
                        if (!teamIDs.Contains(TGID))
                        {
                            ChangeDB2String("RCPR", "PS0" + j, i, "0");
                            ChangeDB2String("RCPR", "PT0" + j, i, "511");
                            fcsTeams++;
                        }
                    }
                    else
                    {
                        int TGID = GetDB2ValueInt("RCPR", "PT" + j, i);
                        if (!teamIDs.Contains(TGID))
                        {
                            ChangeDB2String("RCPR", "PS" + j, i, "0");
                            ChangeDB2String("RCPR", "PT" + j, i, "511");
                            fcsTeams++;
                        }
                    }
                }

                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Recruit Interested Teams Changed!");
            if (fcsTeams > 0) MessageBox.Show(fcsTeams + " FCS Teams were removed from Interested Teams");

        }

        //Randomize the Recruits to give a little bit more variety and evaluation randomness -- Must be done at start of Recruiting
        private void RandomizeRecruitDB(string FieldName)
        {
            StartProgressBar(GetTable2RecCount(FieldName));

            int tol = (int)recruitTolerance.Value;
            int tolA = 3;
            //List<List<int>> recruits = new List<List<int>>();
            int row = 0;
            for (int i = 0; i < GetTable2RecCount(FieldName); i++)
            {
                if (GetDB2ValueInt(FieldName, "PRID", i) < 21000)  //skips transfers
                {
                    //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                    //PPOE, PINJ, PAWR

                    int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                    PHGT = GetDB2ValueInt(FieldName, "PHGT", i);
                    PWGT = GetDB2ValueInt(FieldName, "PWGT", i);
                    PAWR = GetDB2ValueInt(FieldName, "PAWR", i);

                    PTHA = GetDB2ValueInt(FieldName, "PTHA", i);
                    PSTA = GetDB2ValueInt(FieldName, "PSTA", i);
                    PKAC = GetDB2ValueInt(FieldName, "PKAC", i);
                    PACC = GetDB2ValueInt(FieldName, "PACC", i);
                    PSPD = GetDB2ValueInt(FieldName, "PSPD", i);
                    PCTH = GetDB2ValueInt(FieldName, "PCTH", i);
                    PAGI = GetDB2ValueInt(FieldName, "PAGI", i);
                    PTAK = GetDB2ValueInt(FieldName, "PTAK", i);
                    PPBK = GetDB2ValueInt(FieldName, "PPBK", i);
                    PRBK = GetDB2ValueInt(FieldName, "PRBK", i);
                    PBTK = GetDB2ValueInt(FieldName, "PBTK", i);
                    PTHP = GetDB2ValueInt(FieldName, "PTHP", i);
                    PJMP = GetDB2ValueInt(FieldName, "PJMP", i);
                    PCAR = GetDB2ValueInt(FieldName, "PCAR", i);
                    PKPR = GetDB2ValueInt(FieldName, "PKPR", i);
                    PSTR = GetDB2ValueInt(FieldName, "PSTR", i);

                    PBRE = rand.Next(0, 2);
                    PEYE = rand.Next(0, 2);
                    PHGT += rand.Next(-1, 2);
                    PWGT += rand.Next(-15, 15);
                    if (PWGT < 0) PWGT = 0;
                    if (PWGT > 340) PWGT = 340;
                    if (PHGT > 82) PHGT = 82;
                    if (PHGT < 0) PHGT = 0;

                    int handVal = rand.Next(1, 101);
                    int hand = 0;
                    if (handVal <= 9) hand = 1; //left handed 9% chance
                    ChangeDB2Int(FieldName, "PHAN", i, hand);

                    PPOE = rand.Next(1, 32);
                    PINJ = rand.Next(1, maxRatingVal);
                    PAWR = GetRandomAttribute(PAWR, tolA);

                    PTHA = GetRandomAttribute(PTHA, tol);
                    PSTA = GetRandomAttribute(PSTA, tol);
                    PKAC = GetRandomAttribute(PKAC, tol);
                    PACC = GetRandomAttribute(PACC, tol);
                    PSPD = GetRandomAttribute(PSPD, tol);
                    PCTH = GetRandomAttribute(PCTH, tol);
                    PAGI = GetRandomAttribute(PAGI, tol);
                    PTAK = GetRandomAttribute(PTAK, tol);
                    PPBK = GetRandomAttribute(PPBK, tol);
                    PRBK = GetRandomAttribute(PRBK, tol);
                    PBTK = GetRandomAttribute(PBTK, tol);
                    PTHP = GetRandomAttribute(PTHP, tol);
                    PJMP = GetRandomAttribute(PJMP, tol);
                    PCAR = GetRandomAttribute(PCAR, tol);
                    PKPR = GetRandomAttribute(PKPR, tol);
                    PSTR = GetRandomAttribute(PSTR, tol);

                    ChangeDB2Int(FieldName, "PBRE", i, PBRE);
                    ChangeDB2Int(FieldName, "PEYE", i, PEYE);
                    ChangeDB2Int(FieldName, "PPOE", i, PPOE);
                    ChangeDB2Int(FieldName, "PINJ", i, PINJ);
                    ChangeDB2Int(FieldName, "PAWR", i, PAWR);
                    ChangeDB2Int(FieldName, "PHGT", i, PHGT);
                    ChangeDB2Int(FieldName, "PWGT", i, PWGT);


                    ChangeDB2Int(FieldName, "PTHA", i, PTHA);
                    ChangeDB2Int(FieldName, "PSTA", i, PSTA);
                    ChangeDB2Int(FieldName, "PKAC", i, PKAC);
                    ChangeDB2Int(FieldName, "PACC", i, PACC);
                    ChangeDB2Int(FieldName, "PSPD", i, PSPD);
                    ChangeDB2Int(FieldName, "PCTH", i, PCTH);
                    ChangeDB2Int(FieldName, "PAGI", i, PAGI);
                    ChangeDB2Int(FieldName, "PTAK", i, PTAK);
                    ChangeDB2Int(FieldName, "PPBK", i, PPBK);
                    ChangeDB2Int(FieldName, "PRBK", i, PRBK);
                    ChangeDB2Int(FieldName, "PBTK", i, PBTK);
                    ChangeDB2Int(FieldName, "PTHP", i, PTHP);
                    ChangeDB2Int(FieldName, "PJMP", i, PJMP);
                    ChangeDB2Int(FieldName, "PCAR", i, PCAR);
                    ChangeDB2Int(FieldName, "PKPR", i, PKPR);
                    ChangeDB2Int(FieldName, "PSTR", i, PSTR);

                    CalculateRecruitOverall(i);

                    row++;

                }
                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Recruits Randomized!");

            DB2RecalculateBMI(FieldName);
        }

        //Randomize the Recruits Skin Tone, Face and Face Shape
        private void RandomizeRecruitFace(string tableName)
        {
            StartProgressBar(GetTable2RecCount(tableName));

            for (int i = 0; i < GetTable2RecCount(tableName); i++)
            {
                if (tableName != "RCPT" || GetDB2ValueInt(tableName, "PRID", i) < 21000)  //skips transfers
                {
                    RandomizeSkinTone(tableName, i);
                    RandomizePlayerHead(tableName, i);

                    int handVal = rand.Next(1, 101);
                    int hand = 0;
                    if (handVal <= 9) hand = 1; //left handed 9% chance
                    ChangeDB2Int(tableName, "PHAN", i, hand);

                    /*
                    //Randomizes Face Shape (PGFM)
                    int shape = rand.Next(0, 16);
                    ChangeDB2Int(tableName, "PFGM", i, shape);

                    //Randomizes Skin Tone
                    RandomizeSkinTone(tableName, i);

                    //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
                    int skin = GetDB2ValueInt(tableName, "PSKI", i);
                    if (skin <= 3) skin = rand.Next(0, 3);
                    else if (skin > 3 && skin <= 6) skin = rand.Next(3, 7);
                    else skin = 7;

                    ChangeDB2Int(tableName, "PSKI", i, skin);

                    //Randomizes Face Type based on new Skin Type
                    int face = GetDB2ValueInt(tableName, "PSKI", i) * 8 + rand.Next(0, 8);
                    ChangeDB2Int(tableName, "PFMP", i, face);

                    //Randomize Hair Color
                    int hcl = 0;
                    if (skin < 2)
                    {
                        hcl = rand.Next(1, 101);
                        if (hcl <= 55) hcl = 2; //brown
                        else if (hcl <= 65) hcl = 0; //black
                        else if (hcl <= 80) hcl = 1; //blonde
                        else if (hcl <= 95) hcl = 4; //light brown
                        else hcl = 3; //red
                    }
                    else if (skin == 2 || skin == 7)
                    {
                        hcl = rand.Next(1, 101);
                        if (hcl <= 80) hcl = 0;
                        else hcl = 4;
                    }
                    else
                    {
                        hcl = rand.Next(1, 101);
                        if (hcl <= 92) hcl = 0;
                        else if (hcl <= 70) hcl = 2;
                        else hcl = rand.Next(0, 6);
                    }
                    ChangeDB2Int(tableName, "PHCL", i, hcl);

                    //Randomize Hair Style
                    int hairstyle = 5;

                    if (skin < 3 || skin == 7)
                    {

                        if (rand.Next(1, 101) <= 50)
                            hairstyle = rand.Next(2, 8);
                        else if (rand.Next(1, 101) <= 75)
                            hairstyle = rand.Next(11, 14);
                        else hairstyle = 0;

                    }
                    else
                    {
                        if (rand.Next(1, 101) <= 50)
                        {
                            int hair = rand.Next(1, 5);
                            if (hair == 1) hairstyle = 1;
                            else if (hair == 2) hairstyle = 2;
                            else if (hair == 3) hairstyle = 3;
                            else if (hair == 4) hairstyle = 14;
                        }
                        else
                        {
                            if (rand.Next(1, 101) <= 50)
                                hairstyle = rand.Next(0, 8);
                            else
                                hairstyle = rand.Next(11, 15);
                        }
                    }


                    ChangeDB2Int(tableName, "PHED", i, hairstyle);

                    //Randomize Eye Black
                    if (Next26Mod || NextMod)
                    {
                        ChangeDB2Int(tableName, "PEYE", i, rand.Next(0, 2));
                    }
                    else
                    {
                        int val = rand.Next(1, 101);
                        if (val <= 15) ChangeDBInt(tableName, "PEYE", i, 1);
                        else ChangeDB2Int(tableName, "PEYE", i, 0);
                    }


                    //Randomize Nasal Strip
                    if (Next26Mod || NextMod)
                    {
                        ChangeDB2Int(tableName, "PBRE", i, rand.Next(0, 2));
                    }
                    else
                    {
                        int val = rand.Next(1, 101);
                        if (val <= 15) ChangeDBInt(tableName, "PBRE", i, 1);
                        else ChangeDB2Int(tableName, "PBRE", i, 0);
                    }
                    */
                }

                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Faces & Skin Tones Randomized!");
        }

        //Randomize Walk-On Database -- Must be done prior to Cut Players stage
        private void RandomizeWalkOnDB()
        {
            StartProgressBar(GetTable2RecCount("WKON"));

            int tol = (int)toleranceWalkOn.Value;

            for (int i = 0; i < GetTable2RecCount("WKON"); i++)
            {
                //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                //PPOE, PINJ, PAWR

                int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                PHGT = GetDB2ValueInt("WKON", "PHGT", i);
                PWGT = GetDB2ValueInt("WKON", "PWGT", i);

                PTHA = GetDB2ValueInt("WKON", "PTHA", i);
                PSTA = GetDB2ValueInt("WKON", "PSTA", i);
                PKAC = GetDB2ValueInt("WKON", "PKAC", i);
                PACC = GetDB2ValueInt("WKON", "PACC", i);
                PSPD = GetDB2ValueInt("WKON", "PSPD", i);
                PCTH = GetDB2ValueInt("WKON", "PCTH", i);
                PAGI = GetDB2ValueInt("WKON", "PAGI", i);
                PTAK = GetDB2ValueInt("WKON", "PTAK", i);
                PPBK = GetDB2ValueInt("WKON", "PPBK", i);
                PRBK = GetDB2ValueInt("WKON", "PRBK", i);
                PBTK = GetDB2ValueInt("WKON", "PBTK", i);
                PTHP = GetDB2ValueInt("WKON", "PTHP", i);
                PJMP = GetDB2ValueInt("WKON", "PJMP", i);
                PCAR = GetDB2ValueInt("WKON", "PCAR", i);
                PKPR = GetDB2ValueInt("WKON", "PKPR", i);
                PSTR = GetDB2ValueInt("WKON", "PSTR", i);

                PBRE = rand.Next(0, 2);
                PEYE = rand.Next(0, 2);
                PHGT += rand.Next(-2, 3);
                PWGT += rand.Next(-12, 13);
                if (PWGT < 0) PWGT = 0;
                if (PHGT > 82) PHGT = 82;

                int handVal = rand.Next(1, 101);
                int hand = 0;
                if (handVal <= 9) hand = 1; //left handed 9% chance
                ChangeDB2Int("WKON", "PHAN", i, hand);

                PPOE = rand.Next(1, 32);
                PINJ = rand.Next(1, maxRatingVal);
                PAWR = rand.Next(1, maxRatingVal);

                PTHA = GetRandomAttribute(PTHA, tol);
                PSTA = GetRandomAttribute(PSTA, tol);
                PKAC = GetRandomAttribute(PKAC, tol);
                PACC = GetRandomAttribute(PACC, tol);
                PSPD = GetRandomAttribute(PSPD, tol);
                PCTH = GetRandomAttribute(PCTH, tol);
                PAGI = GetRandomAttribute(PAGI, tol);
                PTAK = GetRandomAttribute(PTAK, tol);
                PPBK = GetRandomAttribute(PPBK, tol);
                PRBK = GetRandomAttribute(PRBK, tol);
                PBTK = GetRandomAttribute(PBTK, tol);
                PTHP = GetRandomAttribute(PTHP, tol);
                PJMP = GetRandomAttribute(PJMP, tol);
                PCAR = GetRandomAttribute(PCAR, tol);
                PKPR = GetRandomAttribute(PKPR, tol);
                PSTR = GetRandomAttribute(PSTR, tol);

                ChangeDB2Int("WKON", "PBRE", i, PBRE);
                ChangeDB2Int("WKON", "PEYE", i, PEYE);
                ChangeDB2Int("WKON", "PPOE", i, PPOE);
                ChangeDB2Int("WKON", "PINJ", i, PINJ);
                ChangeDB2Int("WKON", "PAWR", i, PAWR);
                ChangeDB2Int("WKON", "PHGT", i, PHGT);
                ChangeDB2Int("WKON", "PWGT", i, PWGT);

                ChangeDB2Int("WKON", "PTHA", i, PTHA);
                ChangeDB2Int("WKON", "PSTA", i, PSTA);
                ChangeDB2Int("WKON", "PKAC", i, PKAC);
                ChangeDB2Int("WKON", "PACC", i, PACC);
                ChangeDB2Int("WKON", "PSPD", i, PSPD);
                ChangeDB2Int("WKON", "PCTH", i, PCTH);
                ChangeDB2Int("WKON", "PAGI", i, PAGI);
                ChangeDB2Int("WKON", "PTAK", i, PTAK);
                ChangeDB2Int("WKON", "PPBK", i, PPBK);
                ChangeDB2Int("WKON", "PRBK", i, PRBK);
                ChangeDB2Int("WKON", "PBTK", i, PBTK);
                ChangeDB2Int("WKON", "PTHP", i, PTHP);
                ChangeDB2Int("WKON", "PJMP", i, PJMP);
                ChangeDB2Int("WKON", "PCAR", i, PCAR);
                ChangeDB2Int("WKON", "PKPR", i, PKPR);
                ChangeDB2Int("WKON", "PSTR", i, PKPR);

                ProgressBarStep();
            }

            EndProgressBar();

            RandomizeRecruitFace("WKON");
            DB2RecalculateBMI("WKON");
            MessageBox.Show("Walk-Ons Randomized!");

        }

        //Polynesian Surname Generator
        private void PolynesianNameGenerator()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\poly-surnames.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            List<string> surnames = new List<string>();
            while (!sr.EndOfStream)
            {
                surnames.Add(sr.ReadLine());
            }
            sr.Close();

            //dont change in-season recruit names with this
            int start = GetTableRecCount("MRCT");

            StartProgressBar(GetTable2RecCount("RCPT"));

            for (int i = start; i < GetTable2RecCount("RCPT"); i++)
            {
                //Check for Arizona  2
                if (GetDB2ValueInt("RCPT", "STID", i) == 2)
                {
                    if (rand.Next(0, 100) < 15 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for California 4 
                else if (GetDB2ValueInt("RCPT", "STID", i) == 4)
                {
                    if (rand.Next(0, 100) < 30 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Hawaii recruits (256 x 10 - 2560)
                else if (GetDB2ValueInt("RCPT", "STID", i) == 10)
                {
                    if (rand.Next(0, 100) < 90 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Utah 43
                else if (GetDB2ValueInt("RCPT", "STID", i) == 43)
                {
                    if (rand.Next(0, 100) < 25 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Washington  46
                else if (GetDB2ValueInt("RCPT", "STID", i) == 46)
                {
                    if (rand.Next(0, 100) < 20 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Oregon  36
                else if (GetDB2ValueInt("RCPT", "STID", i) == 36)
                {
                    if (rand.Next(0, 100) < 15 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Texas  42
                else if (GetDB2ValueInt("RCPT", "STID", i) == 42)
                {
                    if (rand.Next(0, 100) < 10 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Colorado  5
                else if (GetDB2ValueInt("RCPT", "STID", i) == 5)
                {
                    if (rand.Next(0, 100) < 15 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Alaska  1
                else if (GetDB2ValueInt("RCPT", "STID", i) == 1)
                {
                    if (rand.Next(0, 100) < 33 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Nevada  27
                else if (GetDB2ValueInt("RCPT", "STID", i) == 27)
                {
                    if (rand.Next(0, 100) < 20 && GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Polynesian Players & Names updates are complete!");

        }

        //Creates the Polynesian Player
        private void PolynesianPlayerMaker(List<string> surnames, int i)
        {
            int x = rand.Next(0, surnames.Count);
            string newName = surnames[x];
            ChangeDB2String("RCPT", "PLNA", i, newName);
            int skin = rand.Next(0, 101);

            if (skin <= 40) skin = 2;
            else if (skin <= 80) skin = 7;
            else skin = 3;

            ChangeDB2Int("RCPT", "PSKI", i, skin);
            ChangeDB2Int("RCPT", "PFMP", i, rand.Next(skin * 8, skin * 8 + 8));
            ChangeDB2Int("RCPT", "PFGM", i, rand.Next(0, 16));

            int hairstyle = 13;
            if (rand.Next(1, 101) <= 67) hairstyle = rand.Next(0, 15);
            ChangeDB2Int("RCPT", "PHED", i, hairstyle);
        }

        //Randomize Recruit Names

        private void RandomizeRecruitNames(string tableName)
        {
            //dont change in-season recruit names with this
            int start = GetTableRecCount("MRCT");

            StartProgressBar(GetTable2RecCount(tableName));
            CreateFirstNamesDB();
            CreateLastNamesDB();

            for (int i = start; i < GetTable2RecCount(tableName); i++)
            {
                if (tableName != "RCPT" || GetDB2ValueInt(tableName, "PRID", i) < 21000)  //skips transfers
                {

                    //Randomizes name
                    string FN, LN;

                    FN = FirstNames[rand.Next(0, FirstNames.Count)];
                    LN = LastNames[rand.Next(0, LastNames.Count)];

                    ChangeDB2String("RCPT", "PFNA", i, FN);
                    ChangeDB2String("RCPT", "PLNA", i, LN);
                }

                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Recruit Names Randomized!");
        }

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void DB2RecalculateBMI(string tableName)
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

            StartProgressBar(GetTable2RecCount(tableName));

            for (int rec = 0; rec < GetTable2RecCount(tableName); rec++)
            {
                int ppos = GetDB2ValueInt(tableName, "PPOS", rec);
                int height = GetDB2ValueInt(tableName, "PHGT", rec);
                int weight = GetDB2ValueInt(tableName, "PWGT", rec);

                var (pfsh, pmsh, pssh) = GetBodySizeFromPlayerData(ppos, height, weight);

                ChangeDB2Int(tableName, "PFSH", rec, pfsh);
                ChangeDB2Int(tableName, "PMSH", rec, pmsh);
                ChangeDB2Int(tableName, "PSSH", rec, pssh);

                ProgressBarStep();
            }


            EndProgressBar();

            MessageBox.Show("Body Model updates are complete!");
        }

        //Recalculate Individual Recruit Overall
        public void CalculateRecruitOverall(int rec)
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

            ChangeDB2String("RCPT", "POVR", rec, Convert.ToString(val));

        }

        //Calculate Star Ratings for Recruits
        private void CalculateRecruitStarRating(List<List<int>> recruits)
        {
            StartProgressBar(recruits.Count);

            int five = Convert.ToInt32(recruits.Count * 0.01); //top 30
            int four = Convert.ToInt32(recruits.Count * 0.1); // top 300
            int three = Convert.ToInt32(recruits.Count * 0.33); //top 1000
            int two = Convert.ToInt32(recruits.Count * 0.95);  //top 2800

            for (int i = 0; i < recruits.Count; i++)
            {
                if (i <= five) RecordRecruitStarRating(i, recruits, 5);
                else if (i <= four) RecordRecruitStarRating(i, recruits, 4);
                else if (i <= three) RecordRecruitStarRating(i, recruits, 3);
                else if (i <= two) RecordRecruitStarRating(i, recruits, 2);
                else
                {
                    if (min1Stars.Checked)
                        RecordRecruitStarRating(i, recruits, 1);
                    else RecordRecruitStarRating(i, recruits, 2);
                }
                ProgressBarStep();
            }

            EndProgressBar();
        }

        private void CalculatePOSGRankings(List<List<int>> recruits)
        {
            StartProgressBar(10);

            for (int p = 0; p < 10; p++)
            {
                List<List<int>> list = new List<List<int>>();

                foreach (var recruit in recruits)
                {
                    if (recruit[2] == p)
                    {
                        list.Add(recruit);
                    }
                }

                list.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

                int rank = 0;
                foreach (var player in list)
                {
                    ChangeDB2Int("RCPT", "RCRK", player[3], rank);

                    rank++;
                }

                ProgressBarStep();
            }


            EndProgressBar();
        }

        //Record Star Rating Update
        private void RecordRecruitStarRating(int i, List<List<int>> recruits, int star)
        {
            int prid = recruits[i][0];
            int posg = recruits[i][2];
            if (posg >= 8 && star >= 3)
            {
                star = 3;
            }

            for (int x = 0; x < GetTable2RecCount("RCPT"); x++)
            {
                if (GetDB2ValueInt("RCPT", "PRID", x) == prid)
                {
                    ChangeDB2Int("RCPT", "RCCB", x, star);
                    break;
                }
            }
        }

        //Calculate Recruit & Transfer Star Rating
        private void RecalculateAllStarRatings()
        {
            StartProgressBar(GetTable2RecCount("RCPT"));

            List<List<int>> recruits = new List<List<int>>();
            List<List<int>> transfers = new List<List<int>>();

            int row = 0;
            int rowT = 0;
            for (int i = 0; i < GetTable2RecCount("RCPT"); i++)
            {
                if (GetDB2ValueInt("RCPT", "PRID", i) < 21000)  //recruits
                {
                    recruits.Add(new List<int>());
                    recruits[row].Add(GetDB2ValueInt("RCPT", "PRID", i));
                    recruits[row].Add(GetDB2ValueInt("RCPT", "POVR", i));
                    recruits[row].Add(GetPOSGfromPPOS(GetDB2ValueInt("RCPT", "PPOS", i)));
                    recruits[row].Add(i);

                    //bonus
                    int bonus = GetRecruitRatingBonus(recruits[row][2]);
                    recruits[row][1] += bonus;

                    row++;
                }
                else if (GetDB2ValueInt("RCPT", "PRID", i) >= 21000)  //transfers
                {
                    transfers.Add(new List<int>());
                    transfers[rowT].Add(GetDB2ValueInt("RCPT", "PRID", i));
                    transfers[rowT].Add(GetDB2ValueInt("RCPT", "POVR", i));
                    transfers[rowT].Add(GetPOSGfromPPOS(GetDB2ValueInt("RCPT", "PPOS", i)));
                    transfers[rowT].Add(i);
                    rowT++;
                }

                ProgressBarStep();
            }

            EndProgressBar();


            recruits.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
            CalculateRecruitStarRating(recruits);
            CalculatePOSGRankings(recruits);

            transfers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
            CalculateRecruitStarRating(transfers);
            CalculatePOSGRankings(transfers);

            MessageBox.Show("Recruit & Transfer Star Ratings Recalculated!");

        }

        //Recruit Rating Bonus
        private int GetRecruitRatingBonus(int posg)
        {
            int bonus = 0;

            if (posg == 4 || posg == 6)
            {
                bonus = 2;
            }
            else if (posg == 0)
            {
                bonus = 1;
            }

            return bonus;
        }

        //Choose Athlete Position
        private void ChooseAthletePosition()
        {
            StartProgressBar(GetTable2RecCount("RCPT"));




            for (int i = 0; i < GetTable2RecCount("RCPT"); i++)
            {
                if (GetDB2ValueInt("RCPT", "PRID", i) < 21000 && GetDB2ValueInt("RCPT", "RATH", i) == 1)
                {
                    List<List<int>> position = new List<List<int>>();
                    int row = 0;
                    for (int p = 0; p < 21; p++)
                    {
                        position.Add(new List<int>());
                        position[row].Add(p);
                        position[row].Add(CalculateAthletePositionRating(i, p));
                        row++;
                    }

                    position.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

                    ChangeDB2Int("RCPT", "PPOS", i, position[0][0]);
                    CalculateRecruitOverall(i);
                }

                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Athlete Positions Optimized!");

        }

        public int CalculateAthletePositionRating(int rec, int ppos)
        {
            if (ppos == 2 || ppos > 18) return 0;

            int posg = GetPOSGfromPPOS(ppos);
            int playerPos = GetDBValueInt("PLAY", "PPOS", rec);
            int playerPOSG = GetPOSGfromPPOS(playerPos);

            List<List<int>> AWRH = GetAwarenessHitList();
            double hit = 0.000;

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

            double PosHit = hit * AWRH[playerPos][ppos];

            int AWRog = ConvertRating(Convert.ToInt32(PAWR));
            int AWR = Convert.ToInt32(AWRog - (AWRog * PosHit));

            if (AWR < minConvRatingVal) AWR = minConvRatingVal;

            PAWR = RevertRating(AWR);

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

            if (val < 0) val = 0;
            return val;

        }


        //Create FCS for Transfer Portal (in-game portal)

        private void CreateFCSPlayersForRecruiting()
        {
            int fcsplayers = 0;
            List<int> fcsTeams = new List<int>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                {
                    fcsTeams.Add(GetDBValueInt("TEAM", "TGID", i));
                }
            }

            //Create New Roster
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();

            List<List<int>> PJEN = CreateJerseyNumberDB();
            List<List<string>> RCATmapper = CreateStringListsFromCSV(@"resources\players\RCAT-MAPPER.csv", false);

            int newPlayers = TDB.TableCapacity(dbIndex, "PLAY") - GetTableRecCount("PLAY");

            if (newPlayers <= 0)
            {
                MessageBox.Show("No available roster spots to create FCS Transfer Players!");
                return;
            }

            int maxFCSPlayers = 70;
            if (newPlayers > maxFCSPlayers) newPlayers = maxFCSPlayers; //limit to XX players max

            while (fcsplayers < maxPlayers)
            {
                int rec = GetTableRecCount("PLAY");
                AddTableRecord("PLAY", false);

                List<int> AvailablePJEN = new List<int>();


                //Assign a Team
                int TGID = fcsTeams[rand.Next(0, fcsTeams.Count)];

                int PGID = TGID * 70 + fcsplayers;
                TransferRCATtoPLAY(rec, rand.Next(0, 17), PGID, RCATmapper, PJEN, AvailablePJEN, 0);
                RandomizeAttribute("PLAY", rec, 2);
                RecalculateOverallByRec(rec);
                ChangeDBInt("PLAY", "PYER", rec, rand.Next(1, 3)); //set to Senior
                ChangeDBInt("PLAY", "PRSD", rec, 0); //not redshirted
                ChangeDBInt("PLAY", "PTYP", rec, 1); //Set to Transfer

                //Add To Portal
                int POVR = GetDBValueInt("PLAY", "POVR", rec);
                int PPOS = GetDBValueInt("PLAY", "PPOS", rec);



                if (PPOS == 8) PPOS = 6;
                else if (PPOS == 9) PPOS = 5;
                else if (PPOS == 10 || PPOS == 11) PPOS = 8;
                else if (PPOS == 12) PPOS = 9;
                else if (PPOS == 13 || PPOS == 15) PPOS = 10;
                else if (PPOS == 14) PPOS = 11;
                else if (PPOS == 16) PPOS = 12;
                else if (PPOS == 17) PPOS = 13;
                else if (PPOS == 18) PPOS = 14;
                else if (PPOS == 19) PPOS = 15;
                else if (PPOS == 20) PPOS = 16;

                if (ConvertRating(POVR) >= 68)
                {
                    //add to transfer portal
                    int portalRec = GetTableRecCount("TRAN");
                    AddTableRecord("TRAN", false);
                    ChangeDBInt("TRAN", "PGID", portalRec, PGID);
                    ChangeDBInt("TRAN", "PTID", portalRec, 300);
                    fcsplayers++;
                }
                else
                {
                    //remove
                    DeleteRecord("PLAY", rec, true);
                    CompactDB();
                }
            }

            MessageBox.Show(fcsplayers + " FCS Players Created for Transfer Portal!\n\nPLEASE MAKE SURE TO RUN 'MODIFY RECRUIT INTEREST' AT THE START OF RECRUITING PHASE.\nYou can leave the value at 11 if you do not want to remove interests. Running this will prevent FCS teams from recruiting players.");
        }



    }
}
