﻿using System;
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
                TRPA = Convert.ToInt32(TDB.FieldValue(dbIndex, "RTRI", "TRPA", i));
                TRPR = Convert.ToInt32(TDB.FieldValue(dbIndex, "RTRI", "TRPR", i));

                if (TRPR < (int)minRecPts.Value) TRPR = (int)minRecPts.Value;
                if (TRPA < (int)minTRPA.Value) TRPA = (int)minTRPA.Value;

                TDB.NewfieldValue(dbIndex, "RTRI", "TRPA", i, Convert.ToString(TRPA));
                TDB.NewfieldValue(dbIndex, "RTRI", "TRPR", i, Convert.ToString(TRPR));

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
                        TDB.NewfieldValue(dbIndex, "RCPR", "PS0" + j, i, "0");
                        TDB.NewfieldValue(dbIndex, "RCPR", "PT0" + j, i, "511");
                    }
                    else
                    {
                        TDB.NewfieldValue(dbIndex, "RCPR", "PS" + j, i, "0");
                        TDB.NewfieldValue(dbIndex, "RCPR", "PT" + j, i, "511");
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
                if (Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PRID", i)) < 21000)  //skips transfers
                {
                    //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                    //PPOE, PINJ, PAWR

                    int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR;

                    PHGT = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PHGT", i));
                    PWGT = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PWGT", i));
                    PAWR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PAWR", i));

                    PTHA = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTHA", i));
                    PSTA = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSTA", i));
                    PKAC = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PKAC", i));
                    PACC = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PACC", i));
                    PSPD = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSPD", i));
                    PCTH = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PCTH", i));
                    PAGI = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PAGI", i));
                    PTAK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTAK", i));
                    PPBK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PPBK", i));
                    PRBK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PRBK", i));
                    PBTK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PBTK", i));
                    PTHP = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTHP", i));
                    PJMP = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PJMP", i));
                    PCAR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PCAR", i));
                    PKPR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PKPR", i));
                    PSTR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSTR", i));

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

                    TDB.NewfieldValue(dbIndex, FieldName, "PBRE", i, Convert.ToString(PBRE));
                    TDB.NewfieldValue(dbIndex, FieldName, "PEYE", i, Convert.ToString(PEYE));
                    TDB.NewfieldValue(dbIndex, FieldName, "PPOE", i, Convert.ToString(PPOE));
                    TDB.NewfieldValue(dbIndex, FieldName, "PINJ", i, Convert.ToString(PINJ));
                    TDB.NewfieldValue(dbIndex, FieldName, "PAWR", i, Convert.ToString(PAWR));
                    TDB.NewfieldValue(dbIndex, FieldName, "PHGT", i, Convert.ToString(PHGT));
                    TDB.NewfieldValue(dbIndex, FieldName, "PWGT", i, Convert.ToString(PWGT));


                    TDB.NewfieldValue(dbIndex, FieldName, "PTHA", i, Convert.ToString(PTHA));
                    TDB.NewfieldValue(dbIndex, FieldName, "PSTA", i, Convert.ToString(PSTA));
                    TDB.NewfieldValue(dbIndex, FieldName, "PKAC", i, Convert.ToString(PKAC));
                    TDB.NewfieldValue(dbIndex, FieldName, "PACC", i, Convert.ToString(PACC));
                    TDB.NewfieldValue(dbIndex, FieldName, "PSPD", i, Convert.ToString(PSPD));
                    TDB.NewfieldValue(dbIndex, FieldName, "PCTH", i, Convert.ToString(PCTH));
                    TDB.NewfieldValue(dbIndex, FieldName, "PAGI", i, Convert.ToString(PAGI));
                    TDB.NewfieldValue(dbIndex, FieldName, "PTAK", i, Convert.ToString(PTAK));
                    TDB.NewfieldValue(dbIndex, FieldName, "PPBK", i, Convert.ToString(PPBK));
                    TDB.NewfieldValue(dbIndex, FieldName, "PRBK", i, Convert.ToString(PRBK));
                    TDB.NewfieldValue(dbIndex, FieldName, "PBTK", i, Convert.ToString(PBTK));
                    TDB.NewfieldValue(dbIndex, FieldName, "PTHP", i, Convert.ToString(PTHP));
                    TDB.NewfieldValue(dbIndex, FieldName, "PJMP", i, Convert.ToString(PJMP));
                    TDB.NewfieldValue(dbIndex, FieldName, "PCAR", i, Convert.ToString(PCAR));
                    TDB.NewfieldValue(dbIndex, FieldName, "PKPR", i, Convert.ToString(PKPR));
                    TDB.NewfieldValue(dbIndex, FieldName, "PSTR", i, Convert.ToString(PSTR));
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
                if (tableName != "RCPT" || Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "PRID", i)) < 21000)  //skips transfers
                {

                    //Randomizes Face Shape (PGFM)
                    int shape = rand.Next(0, 16);
                    TDB.NewfieldValue(dbIndex, tableName, "PFGM", i, Convert.ToString(shape));

                    //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
                    int skin = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "PSKI", i);
                    if (skin <= 2) rand.Next(0, 3);
                    else if (skin <= 6) rand.Next(3, 7);
                    else rand.Next(7, 8);

                    TDB.NewfieldValue(dbIndex, tableName, "PSKI", i, Convert.ToString(skin));

                    //Randomizes Face Type based on new Skin Type
                    int face = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "PSKI", i) * 8 + rand.Next(0, 8);
                    TDB.NewfieldValue(dbIndex, tableName, "PFMP", i, Convert.ToString(face));

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

                PHGT = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PHGT", i));
                PWGT = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PWGT", i));

                PTHA = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PTHA", i));
                PSTA = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PSTA", i));
                PKAC = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PKAC", i));
                PACC = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PACC", i));
                PSPD = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PSPD", i));
                PCTH = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PCTH", i));
                PAGI = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PAGI", i));
                PTAK = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PTAK", i));
                PPBK = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PPBK", i));
                PRBK = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PRBK", i));
                PBTK = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PBTK", i));
                PTHP = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PTHP", i));
                PJMP = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PJMP", i));
                PCAR = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PCAR", i));
                PKPR = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PKPR", i));
                PSTR = Convert.ToInt32(TDB.FieldValue(dbIndex, "WKON", "PSTR", i));

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

                TDB.NewfieldValue(dbIndex, "WKON", "PBRE", i, Convert.ToString(PBRE));
                TDB.NewfieldValue(dbIndex, "WKON", "PEYE", i, Convert.ToString(PEYE));
                TDB.NewfieldValue(dbIndex, "WKON", "PPOE", i, Convert.ToString(PPOE));
                TDB.NewfieldValue(dbIndex, "WKON", "PINJ", i, Convert.ToString(PINJ));
                TDB.NewfieldValue(dbIndex, "WKON", "PAWR", i, Convert.ToString(PAWR));
                TDB.NewfieldValue(dbIndex, "WKON", "PHGT", i, Convert.ToString(PHGT));
                TDB.NewfieldValue(dbIndex, "WKON", "PWGT", i, Convert.ToString(PWGT));

                TDB.NewfieldValue(dbIndex, "WKON", "PTHA", i, Convert.ToString(PTHA));
                TDB.NewfieldValue(dbIndex, "WKON", "PSTA", i, Convert.ToString(PSTA));
                TDB.NewfieldValue(dbIndex, "WKON", "PKAC", i, Convert.ToString(PKAC));
                TDB.NewfieldValue(dbIndex, "WKON", "PACC", i, Convert.ToString(PACC));
                TDB.NewfieldValue(dbIndex, "WKON", "PSPD", i, Convert.ToString(PSPD));
                TDB.NewfieldValue(dbIndex, "WKON", "PCTH", i, Convert.ToString(PCTH));
                TDB.NewfieldValue(dbIndex, "WKON", "PAGI", i, Convert.ToString(PAGI));
                TDB.NewfieldValue(dbIndex, "WKON", "PTAK", i, Convert.ToString(PTAK));
                TDB.NewfieldValue(dbIndex, "WKON", "PPBK", i, Convert.ToString(PPBK));
                TDB.NewfieldValue(dbIndex, "WKON", "PRBK", i, Convert.ToString(PRBK));
                TDB.NewfieldValue(dbIndex, "WKON", "PBTK", i, Convert.ToString(PBTK));
                TDB.NewfieldValue(dbIndex, "WKON", "PTHP", i, Convert.ToString(PTHP));
                TDB.NewfieldValue(dbIndex, "WKON", "PJMP", i, Convert.ToString(PJMP));
                TDB.NewfieldValue(dbIndex, "WKON", "PCAR", i, Convert.ToString(PCAR));
                TDB.NewfieldValue(dbIndex, "WKON", "PKPR", i, Convert.ToString(PKPR));
                TDB.NewfieldValue(dbIndex, "WKON", "PSTR", i, Convert.ToString(PKPR));

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
                if (Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) >= 512 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) < 768)
                {
                    if (rand.Next(0, 100) < 0.15 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for California 4 
                else if (Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) >= 1024 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) < 1280)
                {
                    if (rand.Next(0, 100) < 0.25 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Hawaii recruits (256 x 10 - 2560)
                else if (Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) >= 2560 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) < 2816)
                {
                    if (rand.Next(0, 100) < polyNamesPCT.Value && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Utah 43
                else if (Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) >= 11008 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) < 11264)
                {
                    if (rand.Next(0, 100) < 0.25 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "PRID", i)) < 21000)
                    {
                        PolynesianPlayerMaker(surnames, i);
                    }
                }
                //Check for Washington  46
                else if (Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) >= 11776 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "RCHD", i)) < 12032)
                {
                    if (rand.Next(0, 100) < 0.15 && Convert.ToInt32(TDB.FieldValue(dbIndex, "RCPT", "PRID", i)) < 21000)
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
            TDB.NewfieldValue(dbIndex, "RCPT", "PLNA", i, newName);
            TDB.NewfieldValue(dbIndex, "RCPT", "PSKI", i, "2");
            TDB.NewfieldValue(dbIndex, "RCPT", "PFMP", i, Convert.ToString(rand.Next(16, 24)));
        }


    }
}
