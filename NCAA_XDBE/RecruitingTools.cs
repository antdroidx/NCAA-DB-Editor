using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

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
            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature at the beginning of Recruiting Stage!");
            }
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

        //Recalculate Star Rankings     
        private void RecalculateStarRankingsButton_Click(object sender, EventArgs e)
        {
            RecalculateAllStarRatings();
        }

        private void DetermineAthleteButton_Click(object sender, EventArgs e)
        {
            ChooseAthletePosition();
        }



        #endregion


        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void RaiseMinimumRecruitingPoints()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTable2RecCount("RTRI");

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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Team Budgets Changed!");
        }

        //Randomize or Remove Recruiting Interested Teams
        private void RemoveInterestedTeams()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTable2RecCount("RCPR");

            Random rand = new Random();

            for (int i = 0; i < GetTable2RecCount("RCPR"); i++)
            {


                for (int j = (int)removeInterestTeams.Value - 1; j < 11; j++)
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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Recruit Interested Teams Changed!");
        }

        //Randomize the Recruits to give a little bit more variety and evaluation randomness -- Must be done at start of Recruiting
        private void RandomizeRecruitDB(string FieldName)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTable2RecCount(FieldName);

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
                    PPOE = rand.Next(1, 32);
                    PINJ = rand.Next(1, 32);
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
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Recruits Randomized!");

            DB2RecalculateBMI(FieldName);
        }

        //Randomize the Recruits Skin Tone, Face and Face Shape
        private void RandomizeRecruitFace(string tableName)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTable2RecCount(tableName);

            for (int i = 0; i < GetTable2RecCount(tableName); i++)
            {
                if (tableName != "RCPT" || GetDB2ValueInt(tableName, "PRID", i) < 21000)  //skips transfers
                {

                    //Randomizes Face Shape (PGFM)
                    int shape = rand.Next(0, 16);
                    ChangeDB2Int(tableName, "PFGM", i, shape);

                    //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
                    int skin = GetDB2ValueInt(tableName, "PSKI", i);
                    if (skin <= 2) skin = rand.Next(0, 3);
                    else if (skin <= 6) skin = rand.Next(3, 7);
                    else skin = rand.Next(7, 8);

                    ChangeDB2Int(tableName, "PSKI", i, skin);

                    //Randomizes Face Type based on new Skin Type
                    int face = GetDB2ValueInt(tableName, "PSKI", i) * 8 + rand.Next(0, 8);
                    ChangeDB2Int(tableName, "PFMP", i, face);

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
                    ChangeDB2Int(tableName, "PHCL", i, hcl);

                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Faces & Skin Tones Randomized!");
        }

        //Randomize Walk-On Database -- Must be done prior to Cut Players stage
        private void RandomizeWalkOnDB()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTable2RecCount("WKON");

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
                PPOE = rand.Next(1, 31);
                PINJ = rand.Next(1, 31);
                PAWR = rand.Next(1, 31);

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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

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

            progressBar1.Visible = true;
            progressBar1.Value = start;
            progressBar1.Maximum = GetTable2RecCount("RCPT");
            progressBar1.Step = 1;



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
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Polynesian Players & Names updates are complete!");

        }

        //Creates the Polynesian Player
        private void PolynesianPlayerMaker(List<string> surnames, int i)
        {
            int x = rand.Next(0, surnames.Count);
            string newName = surnames[x];
            ChangeDB2String("RCPT", "PLNA", i, newName);
            ChangeDB2String("RCPT", "PSKI", i, "2");
            ChangeDB2Int("RCPT", "PFMP", i, rand.Next(16, 24));
        }

        //Randomize Recruit Names

        private void RandomizeRecruitNames(string tableName)
        {
            //dont change in-season recruit names with this
            int start = GetTableRecCount("MRCT");

            progressBar1.Visible = true;
            progressBar1.Value = start;
            progressBar1.Maximum = GetTable2RecCount(tableName);
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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

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

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTable2RecCount(tableName);
            progressBar1.Step = 1;

            for (int i = 0; i < GetTable2RecCount(tableName); i++)
            {
                double bmi = (double)Math.Round(Convert.ToDouble(GetDB2Value(tableName, "PWGT", i)) / Convert.ToDouble(GetDB2Value(tableName, "PHGT", i)), 2);

                for (int j = 0; j < 401; j++)
                {
                    if (Convert.ToString(bmi) == strArray[j, 0])
                    {
                        ChangeDB2String(tableName, "PFSH", i, strArray[j, 1]);
                        ChangeDB2String(tableName, "PMSH", i, strArray[j, 2]);
                        ChangeDB2String(tableName, "PSSH", i, strArray[j, 3]);
                        break;
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

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
            if (val < 40) val = 40;
            val = RevertRating(val);

            ChangeDB2String("RCPT", "POVR", rec, Convert.ToString(val));

        }

        //Calculate Star Ratings for Recruits
        private void CalculateRecruitStarRating(List<List<int>> recruits)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = recruits.Count;

            int five = Convert.ToInt32(recruits.Count * 0.01); //top 30
            int four = Convert.ToInt32(recruits.Count * 0.1); // top 300
            int three = Convert.ToInt32(recruits.Count * 0.33); //top 1000
            int two = Convert.ToInt32(recruits.Count * 0.95);  //top 2800
            
            for(int i = 0; i < recruits.Count;i++)
            {
                if (i <= five) RecordRecruitStarRating(i, recruits, 5);
                else if (i <= four) RecordRecruitStarRating(i, recruits, 4);
                else if (i <= three) RecordRecruitStarRating(i, recruits, 3);
                else if (i <= two) RecordRecruitStarRating(i, recruits, 2);
                else RecordRecruitStarRating(i, recruits, 1);
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void CalculatePOSGRankings(List<List<int>> recruits)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = 10;

            for(int p = 0; p < 10; p++)
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

                progressBar1.PerformStep();
            }


            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        //Record Star Rating Update
        private void RecordRecruitStarRating(int i,  List<List<int>> recruits, int star)
        {
            int prid = recruits[i][0];

            for(int x = 0; x < GetTable2RecCount("RCPT"); x++)
            {
                if(GetDB2ValueInt("RCPT", "PRID", x) == prid)
                {
                    ChangeDB2Int("RCPT", "RCCB", x, star);
                    break;
                }
            }
        }

        //Calculate Recruit & Transfer Star Rating
        private void RecalculateAllStarRatings()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTable2RecCount("RCPT");

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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;


            recruits.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
            CalculateRecruitStarRating(recruits);
            CalculatePOSGRankings(recruits);

            transfers.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
            CalculateRecruitStarRating(transfers);
            CalculatePOSGRankings(transfers);

            MessageBox.Show("Recruit & Transfer Star Ratings Recalculated!");

        }

        //Choose Athlete Position
        private void ChooseAthletePosition()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTable2RecCount("RCPT");




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

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;

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

            if (AWR < 40) AWR = 40;

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


        //Remove Mediocre Transfers from Portal
        private void RemoveBadTransfers_Click(object sender, EventArgs e)
        {
            RemoveTransfers();
        }

        private void RemoveTransfers()
        {
            int count = 0;
            for(int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                int rec = FindPGIDRecord(GetDBValueInt("TRAN", "PGID", i));
                int povr = GetDBValueInt("PLAY", "POVR", rec);
                if(povr < 8)
                {
                    DeleteRecordChange("PLAY", rec, true);
                    DeleteRecordChange("TRAN", i, true);
                    count++;
                }
            }

            CompactDB();

            MessageBox.Show("Completed! Removed " + count + " players from the database.");
        }
    }
}
