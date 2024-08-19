using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        //Raise minimum recruiting point allocation and off-season TPRA values -- Must be done at start of Recruiting
        private void RaiseMinimumRecruitingPoints()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "RTRI");

            Random rand = new Random();

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RTRI"); i++)
            {
                int TRPA, TRPR;
                TRPA = GetDBValueInt("RTRI", "TRPA", i);
                TRPR = GetDBValueInt("RTRI", "TRPR", i);

                if (TRPR < (int)minRecPts.Value) TRPR = (int)minRecPts.Value;
                if (TRPA < (int)minTRPA.Value) TRPA = (int)minTRPA.Value;

                ChangeDBInt("RTRI", "TRPA", i, TRPA);
                ChangeDBInt("RTRI", "TRPR", i, TRPR);

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
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "RCPR");

            Random rand = new Random();

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RCPR"); i++)
            {


                for (int j = (int)removeInterestTeams.Value - 1; j < 11; j++)
                {
                    if (j < 10)
                    {
                        ChangeDBString("RCPR", "PS0" + j, i, "0");
                        ChangeDBString("RCPR", "PT0" + j, i, "511");
                    }
                    else
                    {
                        ChangeDBString("RCPR", "PS" + j, i, "0");
                        ChangeDBString("RCPR", "PT" + j, i, "511");
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
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, FieldName);

            int tol = (int)recruitTolerance.Value;
            int tolA = 2;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, FieldName); i++)
            {
                if (GetDBValueInt(FieldName, "PRID", i) < 21000)  //skips transfers
                {
                    //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                    //PPOE, PINJ, PAWR

                    int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                    PHGT = GetDBValueInt(FieldName, "PHGT", i);
                    PWGT = GetDBValueInt(FieldName, "PWGT", i);
                    PAWR = GetDBValueInt(FieldName, "PAWR", i);

                    PTHA = GetDBValueInt(FieldName, "PTHA", i);
                    PSTA = GetDBValueInt(FieldName, "PSTA", i);
                    PKAC = GetDBValueInt(FieldName, "PKAC", i);
                    PACC = GetDBValueInt(FieldName, "PACC", i);
                    PSPD = GetDBValueInt(FieldName, "PSPD", i);
                    PCTH = GetDBValueInt(FieldName, "PCTH", i);
                    PAGI = GetDBValueInt(FieldName, "PAGI", i);
                    PTAK = GetDBValueInt(FieldName, "PTAK", i);
                    PPBK = GetDBValueInt(FieldName, "PPBK", i);
                    PRBK = GetDBValueInt(FieldName, "PRBK", i);
                    PBTK = GetDBValueInt(FieldName, "PBTK", i);
                    PTHP = GetDBValueInt(FieldName, "PTHP", i);
                    PJMP = GetDBValueInt(FieldName, "PJMP", i);
                    PCAR = GetDBValueInt(FieldName, "PCAR", i);
                    PKPR = GetDBValueInt(FieldName, "PKPR", i);
                    PSTR = GetDBValueInt(FieldName, "PSTR", i);

                    PBRE = rand.Next(0, 2);
                    PEYE = rand.Next(0, 2);
                    PHGT += rand.Next(-1, 2);
                    PWGT += rand.Next(-8, 9);
                    if (PWGT < 0) PWGT = 0;
                    if (PWGT > 340) PWGT = 340;
                    if (PHGT > 82) PHGT = 82;
                    if (PHGT < 0) PHGT = 0;
                    PPOE = rand.Next(1, 30);
                    PINJ = rand.Next(1, 30);
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

                    ChangeDBInt(FieldName, "PBRE", i, PBRE);
                    ChangeDBInt(FieldName, "PEYE", i, PEYE);
                    ChangeDBInt(FieldName, "PPOE", i, PPOE);
                    ChangeDBInt(FieldName, "PINJ", i, PINJ);
                    ChangeDBInt(FieldName, "PAWR", i, PAWR);
                    ChangeDBInt(FieldName, "PHGT", i, PHGT);
                    ChangeDBInt(FieldName, "PWGT", i, PWGT);


                    ChangeDBInt(FieldName, "PTHA", i, PTHA);
                    ChangeDBInt(FieldName, "PSTA", i, PSTA);
                    ChangeDBInt(FieldName, "PKAC", i, PKAC);
                    ChangeDBInt(FieldName, "PACC", i, PACC);
                    ChangeDBInt(FieldName, "PSPD", i, PSPD);
                    ChangeDBInt(FieldName, "PCTH", i, PCTH);
                    ChangeDBInt(FieldName, "PAGI", i, PAGI);
                    ChangeDBInt(FieldName, "PTAK", i, PTAK);
                    ChangeDBInt(FieldName, "PPBK", i, PPBK);
                    ChangeDBInt(FieldName, "PRBK", i, PRBK);
                    ChangeDBInt(FieldName, "PBTK", i, PBTK);
                    ChangeDBInt(FieldName, "PTHP", i, PTHP);
                    ChangeDBInt(FieldName, "PJMP", i, PJMP);
                    ChangeDBInt(FieldName, "PCAR", i, PCAR);
                    ChangeDBInt(FieldName, "PKPR", i, PKPR);
                    ChangeDBInt(FieldName, "PSTR", i, PSTR);
                }


                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Recruits Randomized!");

            RecalculateBMI(FieldName);
        }

        //Randomize the Recruits Skin Tone, Face and Face Shape
        private void RandomizeRecruitFace(string tableName)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                if (tableName != "RCPT" || GetDBValueInt(tableName, "PRID", i) < 21000)  //skips transfers
                {

                    //Randomizes Face Shape (PGFM)
                    int shape = rand.Next(0, 16);
                    ChangeDBInt(tableName, "PFGM", i, shape);

                    //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
                    int skin = GetDBValueInt(tableName, "PSKI", i);
                    if (skin <= 2) skin = rand.Next(0, 3);
                    else if (skin <= 6) skin = rand.Next(3, 7);
                    else skin = rand.Next(7, 8);

                    ChangeDBInt(tableName, "PSKI", i, skin);

                    //Randomizes Face Type based on new Skin Type
                    int face = GetDBValueInt(tableName, "PSKI", i) * 8 + rand.Next(0, 8);
                    ChangeDBInt(tableName, "PFMP", i, face);

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
                    ChangeDBInt(tableName, "PHCL", i, hcl);

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
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "WKON");

            int tol = (int)toleranceWalkOn.Value;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "WKON"); i++)
            {
                //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                //PPOE, PINJ, PAWR

                int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                PHGT = GetDBValueInt("WKON", "PHGT", i);
                PWGT = GetDBValueInt("WKON", "PWGT", i);

                PTHA = GetDBValueInt("WKON", "PTHA", i);
                PSTA = GetDBValueInt("WKON", "PSTA", i);
                PKAC = GetDBValueInt("WKON", "PKAC", i);
                PACC = GetDBValueInt("WKON", "PACC", i);
                PSPD = GetDBValueInt("WKON", "PSPD", i);
                PCTH = GetDBValueInt("WKON", "PCTH", i);
                PAGI = GetDBValueInt("WKON", "PAGI", i);
                PTAK = GetDBValueInt("WKON", "PTAK", i);
                PPBK = GetDBValueInt("WKON", "PPBK", i);
                PRBK = GetDBValueInt("WKON", "PRBK", i);
                PBTK = GetDBValueInt("WKON", "PBTK", i);
                PTHP = GetDBValueInt("WKON", "PTHP", i);
                PJMP = GetDBValueInt("WKON", "PJMP", i);
                PCAR = GetDBValueInt("WKON", "PCAR", i);
                PKPR = GetDBValueInt("WKON", "PKPR", i);
                PSTR = GetDBValueInt("WKON", "PSTR", i);

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

                ChangeDBInt("WKON", "PBRE", i, PBRE);
                ChangeDBInt("WKON", "PEYE", i, PEYE);
                ChangeDBInt("WKON", "PPOE", i, PPOE);
                ChangeDBInt("WKON", "PINJ", i, PINJ);
                ChangeDBInt("WKON", "PAWR", i, PAWR);
                ChangeDBInt("WKON", "PHGT", i, PHGT);
                ChangeDBInt("WKON", "PWGT", i, PWGT);

                ChangeDBInt("WKON", "PTHA", i, PTHA);
                ChangeDBInt("WKON", "PSTA", i, PSTA);
                ChangeDBInt("WKON", "PKAC", i, PKAC);
                ChangeDBInt("WKON", "PACC", i, PACC);
                ChangeDBInt("WKON", "PSPD", i, PSPD);
                ChangeDBInt("WKON", "PCTH", i, PCTH);
                ChangeDBInt("WKON", "PAGI", i, PAGI);
                ChangeDBInt("WKON", "PTAK", i, PTAK);
                ChangeDBInt("WKON", "PPBK", i, PPBK);
                ChangeDBInt("WKON", "PRBK", i, PRBK);
                ChangeDBInt("WKON", "PBTK", i, PBTK);
                ChangeDBInt("WKON", "PTHP", i, PTHP);
                ChangeDBInt("WKON", "PJMP", i, PJMP);
                ChangeDBInt("WKON", "PCAR", i, PCAR);
                ChangeDBInt("WKON", "PKPR", i, PKPR);
                ChangeDBInt("WKON", "PSTR", i, PKPR);

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Walk-Ons Randomized!");
            RecalculateBMI("WKON");
        }

        //Polynesian Surname Generator
        private void PolynesianNameGenerator()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\poly-surnames.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            List<string> surnames = new List<string>();
            while (!sr.EndOfStream)
            {
                surnames.Add(sr.ReadLine());
            }
            sr.Close();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "RCPT");
            progressBar1.Step = 1;

            /*States STID
             * Hawaii 10
             * California 4
             * Utah 43
             * Washington 46
             * Arizona 2
             * */


            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "RCPT"); i++)
            {
                //Check for Arizona  2
                if (GetDBValueInt("RCPT", "RCHD", i) >= 512 && GetDBValueInt("RCPT", "RCHD", i) < 768)
                {
                    if (rand.Next(0, 100) < 0.15 && GetDBValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for California 4 
                else if (GetDBValueInt("RCPT", "RCHD", i) >= 1024 && GetDBValueInt("RCPT", "RCHD", i) < 1280)
                {
                    if (rand.Next(0, 100) < 0.25 && GetDBValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Hawaii recruits (256 x 10 - 2560)
                else if (GetDBValueInt("RCPT", "RCHD", i) >= 2560 && GetDBValueInt("RCPT", "RCHD", i) < 2816)
                {
                    if (rand.Next(0, 100) < polyNamesPCT.Value && GetDBValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Utah 43
                else if (GetDBValueInt("RCPT", "RCHD", i) >= 11008 && GetDBValueInt("RCPT", "RCHD", i) < 11264)
                {
                    if (rand.Next(0, 100) < 0.25 && GetDBValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Washington  46
                else if (GetDBValueInt("RCPT", "RCHD", i) >= 11776 && GetDBValueInt("RCPT", "RCHD", i) < 12032)
                {
                    if (rand.Next(0, 100) < 0.15 && GetDBValueInt("RCPT", "PRID", i) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Surname updates are complete!");

        }

        //Creates the Polynesian Player
        private void PolynesianPlayerMaker(List<string> surnames, int i)
        {
            int x = rand.Next(0, surnames.Count);
            string newName = surnames[x];
            ChangeDBString("RCPT", "PLNA", i, newName);
            ChangeDBString("RCPT", "PSKI", i, "2");
            ChangeDBInt("RCPT", "PFMP", i, rand.Next(16, 24));
        }


    }
}
