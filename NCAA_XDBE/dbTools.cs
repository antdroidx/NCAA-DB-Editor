using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void MedicalRedshirt()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "INJY");
            string names = "";
            //looks at INJY table
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "INJY"); i++)
            {
                string tmpRec = TDB.FieldValue(dbIndex, "INJY", "INJL", i);
                //check to see if value is greater than 225
                /* 254 = Season Ending
                 * 196 = 10 weeks
                 */
                if (Convert.ToInt32(tmpRec) >= 196 || Convert.ToInt32(TDB.FieldValue(dbIndex, "SEAI", "SEWN", 0)) >= 16 && checkBoxMedRSNEXT.Checked)
                {
                    //find the corresponding PGID
                    string PGID = TDB.FieldValue(dbIndex, "INJY", "PGID", i);
                    //find the corresponding recNo of the PGID in PLAY
                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        if (PGID == TDB.FieldValue(dbIndex, "PLAY", "PGID", j))
                        {
                            //checks to see if player has only played 4 or less games
                            if (checkBoxMedRSNEXT.Checked)
                            {
                                if (Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PL13", j)) <= 4 && TDB.FieldValue(dbIndex, "PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    TDB.NewfieldValue(dbIndex, "PLAY", "PRSD", j, "1");
                                    string team = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        ReduceSkills(i, (int)skillDrop.Value);
                                    }

                                    names += "\n * " + ConvertFN_IntToString(j) + " " + ConvertLN_IntToString(j) + " (" + team + ")";
                                }
                            }
                            else
                            {
                                if (TDB.FieldValue(dbIndex, "PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    TDB.NewfieldValue(dbIndex, "PLAY", "PRSD", j, "1");
                                    string team = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        ReduceSkills(i, (int)skillDrop.Value);
                                    }

                                    names += "\n * " + ConvertFN_IntToString(j) + " " + ConvertLN_IntToString(j) + " (" + team + ")";
                                }
                            }

                            break;
                        }
                    }

                }
                progressBar1.PerformStep();
            }
            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("The NCAA has approved the following Medical Redshirts:\n\r" + names);
        }

        private void ReduceSkills(int i, int maxDrop)
        {
            int PPOE, PINJ, PSTA, PACC, PSPD, PAGI, PJMP, PSTR;
            int tol = maxDrop;

            PPOE = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PPOE", i)));
            PINJ = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PINJ", i)));
            PSTA = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSTA", i)));
            PACC = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PACC", i)));
            PSPD = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)));
            PAGI = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PAGI", i)));
            PJMP = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PJMP", i)));
            PSTR = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSTR", i)));

            PPOE = RevertRating(GetReducedAttribute(PPOE, tol));
            PINJ = RevertRating(GetReducedAttribute(PINJ, tol));
            PSTA = RevertRating(GetReducedAttribute(PSTA, tol));
            PACC = RevertRating(GetReducedAttribute(PACC, tol));
            PSPD = RevertRating(GetReducedAttribute(PSPD, tol));
            PAGI = RevertRating(GetReducedAttribute(PAGI, tol));
            PJMP = RevertRating(GetReducedAttribute(PJMP, tol));
            PSTR = RevertRating(GetReducedAttribute(PSTR, tol));

            TDB.NewfieldValue(dbIndex, "PLAY", "PPOE", i, Convert.ToString(PPOE));
            TDB.NewfieldValue(dbIndex, "PLAY", "PINJ", i, Convert.ToString(PINJ));
            TDB.NewfieldValue(dbIndex, "PLAY", "PSTA", i, Convert.ToString(PSTA));
            TDB.NewfieldValue(dbIndex, "PLAY", "PACC", i, Convert.ToString(PACC));
            TDB.NewfieldValue(dbIndex, "PLAY", "PSPD", i, Convert.ToString(PSPD));
            TDB.NewfieldValue(dbIndex, "PLAY", "PAGI", i, Convert.ToString(PAGI));
            TDB.NewfieldValue(dbIndex, "PLAY", "PJMP", i, Convert.ToString(PJMP));
            TDB.NewfieldValue(dbIndex, "PLAY", "PSTR", i, Convert.ToString(PSTR));
        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled
        /* 
        Use current TEAM's TMPR and COCH's CTOP to make CPRE updated, then update CTOP to match previous TMPR
        */
        private void CoachPrestigeProgression()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "COCH");

            string coach = "";
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                if (TDB.FieldValue(dbIndex, "COCH", "TGID", i) != "511")
                {
                    string TGID = TDB.FieldValue(dbIndex, "COCH", "TGID", i);
                    int oldPrestige = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CPRE", i));
                    int newPrestige = oldPrestige;
                    int CTOP = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CTOP", i));
                    int CLTF = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CLTF", i));

                    if (CLTF > 6) CLTF = CTOP;

                    newPrestige += FindTeamPrestige(Convert.ToInt32(TGID)) - CLTF;

                    if (newPrestige > 6) newPrestige = 6;
                    if (newPrestige < 1) newPrestige = 1;


                    if (newPrestige > oldPrestige)
                    {
                        coach += "\n* " + GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i))) + ": " + TDB.FieldValue(dbIndex, "COCH", "CLFN", i) + " " + TDB.FieldValue(dbIndex, "COCH", "CLLN", i) + " (+" + (newPrestige - oldPrestige) + ")";
                    }
                    else if (newPrestige < oldPrestige)
                    {
                        coach += "\n* " + GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i))) + ": " + TDB.FieldValue(dbIndex, "COCH", "CLFN", i) + " " + TDB.FieldValue(dbIndex, "COCH", "CLLN", i) + " (" + (newPrestige - oldPrestige) + ")";
                    }
                    TDB.NewfieldValue(dbIndex, "COCH", "CPRE", i, Convert.ToString(newPrestige));
                    TDB.NewfieldValue(dbIndex, "COCH", "CLTF", i, Convert.ToString(FindTeamPrestige(Convert.ToInt32(TGID))));



                }
                else
                {
                    TDB.NewfieldValue(dbIndex, "COCH", "CLTF", i, "511"); //resets their value
                    TDB.NewfieldValue(dbIndex, "COCH", "CCPO", i, "60"); //fixes coach status
                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Coach Prestige Changes:\n\n" + coach);
            coachProgComplete = true;
        }

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void RecalculateBMI(string tableName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\BMI-Calc.csv");
            //string csvLocation = Properties.Resources.BMI_Calc;


            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[402, Line.Length];
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
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                double bmi = Math.Round(Convert.ToDouble(TDB.FieldValue(dbIndex, tableName, "PWGT", i)) / Convert.ToDouble(TDB.FieldValue(dbIndex, tableName, "PHGT", i)), 2);

                for (int j = 0; j < 401; j++)
                {
                    if (Convert.ToString(bmi) == strArray[j, 0])
                    {
                        TDB.NewfieldValue(dbIndex, tableName, "PFSH", i, strArray[j, 1]);
                        TDB.NewfieldValue(dbIndex, tableName, "PMSH", i, strArray[j, 2]);
                        TDB.NewfieldValue(dbIndex, tableName, "PSSH", i, strArray[j, 3]);
                        break;
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Body Model updates are complete!");
        }

        //Increases minium speed for skill positions to 80
        private void IncreaseMinimumSpeed()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "1" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "3"
                    || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "16" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "17" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "18")
                {
                    if (Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)) < 14)
                    {
                        TDB.NewfieldValue(dbIndex, "PLAY", "PSPD", i, "14");
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
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            int pocket = 0;
            int balanced = 0;
            int scrambler = 0;


            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "0")
                {
                    int tendies;
                    int speed = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)));
                    int acceleration = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PACC", i)));
                    int agility = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PAGI", i)));
                    int ThPow = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PTHP", i)));
                    int ThAcc = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PTHA", i)));


                    tendies = (100 + 10 * speed + acceleration + agility - 3 * ThPow - 5 * ThAcc) / 20;

                    if (tendies > 31) tendies = 31;
                    if (tendies < 0) tendies = 0;

                    TDB.NewfieldValue(dbIndex, "PLAY", "PTEN", i, Convert.ToString(tendies));

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

        //Randomizes the Coaching Budgets - Must be done prior to 1st Off-Season Task
        private void RandomizeBudgets()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "COCH");

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                //CDPC, CRPC, CTPC
                int CDPC, CRPC, CTPC;
                CRPC = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CRPC", i));
                CTPC = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CTPC", i));
                CDPC = 0;

                while (CDPC < 15 || CDPC > 25)
                {
                    CTPC += rand.Next(-4, 5);
                    CRPC += rand.Next(-4, 5);
                    CDPC = 100 - CTPC - CRPC;
                }

                TDB.NewfieldValue(dbIndex, "COCH", "CDPC", i, Convert.ToString(CDPC));
                TDB.NewfieldValue(dbIndex, "COCH", "CRPC", i, Convert.ToString(CRPC));
                TDB.NewfieldValue(dbIndex, "COCH", "CTPC", i, Convert.ToString(CTPC));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Team Budgets Changed!");
        }

        //Randomize Player Potential
        private void RandomizePotential()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                int x = rand.Next(0, 32);

                TDB.NewfieldValue(dbIndex, "PLAY", "PPOE", i, Convert.ToString(x));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Potential Updates are complete!");
        }

        //Coaching Carousel Mod
        private void CoachCarousel()
        {
            if (!coachProgComplete)
            {
                MessageBox.Show("Please run Coaching Progressions first before running this module.");
                return;
            }
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "COCH");

            List<string> CCID_FAList = new List<string>();
            List<string> CCID_FiredList = new List<string>();
            List<string> CCID_PromoteList = new List<string>();
            List<string> TGID_VacancyList = new List<string>();


            string news = "";
            string news2 = "";

            //Get List of Coaches and Fire Some
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                //ADD COACHING FREE AGENCY POOL TO THE LIST
                if (TDB.FieldValue(dbIndex, "COCH", "TGID", i) == "511")
                {
                    CCID_FAList.Add(TDB.FieldValue(dbIndex, "COCH", "CCID", i));
                }
                else
                {
                    int CTOP = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CTOP", i));
                    int CLTF = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CLTF", i));
                    int CCPO = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CCPO", i));

                    //FIRE COACHES
                    if (CCPO < (int)jobSecurityValue.Value && CTOP > CLTF && TDB.FieldValue(dbIndex, "COCH", "CFUC", i) != "1")
                    {
                        CCID_FiredList.Add(TDB.FieldValue(dbIndex, "COCH", "CCID", i));
                        TGID_VacancyList.Add(TDB.FieldValue(dbIndex, "COCH", "TGID", i));

                        string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", i);
                        string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", i);
                        string teamID = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i)));


                        if(checkBoxFiredTransfers.Checked)  CoachTransferPortal(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i)), false);


                        news2 += "Fired: " + coachFN + " " + coachLN + " (" + teamID + ")\n\n";

                        TDB.NewfieldValue(dbIndex, "COCH", "TGID", i, "511");
                        TDB.NewfieldValue(dbIndex, "COCH", "CLTF", i, "511");
                        TDB.NewfieldValue(dbIndex, "COCH", "CCPO", i, "60");

                    }
                    //ADD COACHES TO CANDIDATE LIST
                    else if (CCPO > 99 && CTOP < CLTF && TDB.FieldValue(dbIndex, "COCH", "CFUC", i) != "1")
                    {
                        CCID_PromoteList.Add(TDB.FieldValue(dbIndex, "COCH", "CCID", i));

                        string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", i);
                        string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", i);
                        string teamID = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i)));
                    }
                }
                progressBar1.PerformStep();
            }

            //MessageBox.Show(news2, "Fired Head Coaches");

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TGID_VacancyList.Count;

            //HIRE NEW COACHES
            while (TGID_VacancyList.Count > 0)
            {
                int TGID = Convert.ToInt32(TGID_VacancyList[0]);
                int TMPR = FindTeamPrestige(TGID);
                bool hired = false;
                int downgrade = 0;

                while (!hired)
                {
                    if (rand.Next(0, 100) > (100 - (int)poachValue.Value))
                    {
                        int r = rand.Next(CCID_FAList.Count);
                        int CCID = Convert.ToInt32(CCID_FAList[r]);

                        int x = FindRecNumberCCID(CCID);
                        if (x == -1) MessageBox.Show("ERROR");

                        int CPRS = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CPRS", x));
                        if (CPRS >= TMPR - downgrade)
                        {

                            TDB.NewfieldValue(dbIndex, "COCH", "TGID", x, Convert.ToString(TGID));
                            TDB.NewfieldValue(dbIndex, "COCH", "CLTF", x, Convert.ToString(TMPR));
                            TDB.NewfieldValue(dbIndex, "COCH", "CCPO", x, "60");

                            string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", x);
                            string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", x);
                            string teamID = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", x)));

                            news += "Hired: " + coachFN + " " + coachLN + " (" + teamID + ")\n\n";

                            CCID_FAList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            hired = true;

                        }

                    }
                    else if (CCID_PromoteList.Count > 0)
                    {
                        int r = rand.Next(CCID_PromoteList.Count);
                        int CCID = Convert.ToInt32(CCID_PromoteList[r]);

                        int x = FindRecNumberCCID(CCID);
                        if (x == -1) MessageBox.Show("ERROR");


                        string currentTGID = TDB.FieldValue(dbIndex, "COCH", "TGID", x);
                        int currentTMPR = FindTeamPrestige(Convert.ToInt32(currentTGID));

                        if (currentTMPR < TMPR)
                        {
                            TDB.NewfieldValue(dbIndex, "COCH", "TGID", x, Convert.ToString(TGID));
                            TDB.NewfieldValue(dbIndex, "COCH", "CLTF", x, Convert.ToString(TMPR));
                            TDB.NewfieldValue(dbIndex, "COCH", "CCPO", x, "60");

                            string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", x);
                            string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", x);
                            string teamID = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", x)));
                            string oldTeamID = GetTeamName(Convert.ToInt32(currentTGID));

                            CoachTransferPortal(Convert.ToInt32(currentTGID), true);

                            news += "Poached! " + coachFN + " " + coachLN + " (" + teamID + ") from (" + oldTeamID + ")\n\n";

                            CCID_PromoteList.RemoveAt(r);
                            TGID_VacancyList.RemoveAt(0);
                            TGID_VacancyList.Add(currentTGID);
                            hired = true;
                        }
                    }

                    downgrade++;
                }

                TGID_VacancyList.OrderBy(z => z).ToList();
                progressBar1.PerformStep();
            }


            if (news == "") news = "No Coaching Changes!";
            MessageBox.Show(news2 + "................................\n\n" + news, "COACHING CAROUSEL");

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        //Opens a Transfer Portal for Coach Firings
        private void CoachTransferPortal(int teamRec, bool poached)
        {
            /*
             *  Coach Transfer Portal
             *  Since this is done before off-season, we need to evaluate whether the player will graduate and if they will go Pro anyway. 
             *  
             */

            int maxTransfers = 1520;
            int currentRecCount = TDB.TableRecordCount(dbIndex, "TRAN");
            string transferNews = "";
            int xfers = (int)maxFiredTransfers.Value;

            int[,] players = GetTeamPlayersList(teamRec);

            for (int k = 0; k < xfers; k++)
            {
                if (currentRecCount >= maxTransfers) break;

                if (rand.Next(1, 100) < 66 && currentRecCount < maxTransfers)
                {
                    int xfer = rand.Next(0, 70);
                    int tgid = teamRec;

                    if (players[xfer, 0] != 0 && GetPTYPfromRecord(players[xfer, 0]) == 0)
                    {
                        TransferPlayer(players[xfer, 0], players[xfer, 1]);

                        transferNews += GetPositionName(GetPPOSfromRecord(players[xfer, 3])) + " " + ConvertFN_IntToString(players[xfer, 0]) + " " + ConvertLN_IntToString(players[xfer, 0]) + " (" + GetTeamName(tgid) + ") OVR: " + ConvertRating(players[xfer, 2]) + "\n\n";

                        currentRecCount++;
                    }
                }
            }
            if (poached)
            {
                MessageBox.Show(transferNews, GetTeamName(teamRec) + " Resigns: TRANSFER PORTAL NEWS");
            }
            else
            {
                MessageBox.Show(transferNews, GetTeamName(teamRec) + " Firing: TRANSFER PORTAL NEWS");

            }

        }

        //Transfer Portal Chaos Mode -- Must be done at Players Leaving stage
        private void ChaosTransfers()
        {
            /*
             *  Use Rankings
             *  Top 30 : 1 Starter
             *  31-90 : 2 Starters
             *  91-120 : 3 Starters
             *  Pick a random position, find the highest ranked active starter
             */

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "TEAM");

            int maxTransfers = 1520;
            int currentRecCount = TDB.TableRecordCount(dbIndex, "TRAN");
            string transferNews = "";

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
            {
                if (currentRecCount >= maxTransfers) break;

                if (TDB.FieldValue(dbIndex, "TEAM", "TTYP", i) == "0")
                {
                    int xfers = 1;

                    if (GetTeamRanking(i) < 30) xfers = 1;
                    else if (GetTeamRanking(i) < 90) xfers = 2;
                    else xfers = 3;


                    for (int k = 0; k < xfers; k++)
                    {
                        if (rand.Next(1, 100) < 33 && currentRecCount < maxTransfers)
                        {
                            int xferPos = rand.Next(0, 19);
                            int tgid = GetTeamTGIDfromRecord(i);
                            int[,] players = GetPGIDPositionList(tgid, xferPos);
                            int maxOVR = players[0, 2];
                            int maxOVRid = 0;

                            if (players[0, 0] != 0)
                            {
                                for (int j = 0; j < players.GetLength(0); j++)
                                {
                                    if (maxOVR < players[j, 2])
                                    {
                                        maxOVR = players[j, 2];
                                        maxOVRid = j;
                                    }
                                }

                                TransferPlayer(players[maxOVRid, 0], players[maxOVRid, 1]);

                                transferNews += ConvertFN_IntToString(players[maxOVRid, 0]) + " " + ConvertLN_IntToString(players[maxOVRid, 0]) + " (" + GetTeamName(tgid) + ") OVR: " + ConvertRating(maxOVR) + "\n\n";

                                currentRecCount++;
                            }

                        }
                    }

                }
                progressBar1.PerformStep();
            }


            MessageBox.Show(transferNews, "TRANSFER PORTAL NEWS");

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        //Get a list of Players for the Coaching Portal
        private int[,] GetTeamPlayersList(int tgid)
        {
            int[,] list = new int[70, 4];

            int pgidStart = tgid * 70;
            int j = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (GetPGIDfromRecord(i) >= pgidStart && GetPGIDfromRecord(i) < pgidStart + 70 && GetPTYPfromRecord(i) != 3 && GetPTYPfromRecord(i) != 1 && GetPYERfromRecord(i) < 3 && GetPOVRfromRecord(i) < 25)
                {
                    list[j, 0] = i;
                    list[j, 1] = GetPGIDfromRecord(i);
                    list[j, 2] = GetPOVRfromRecord(i);
                    list[j, 3] = GetPPOSfromRecord(i);
                    j++;
                }
            }

            return list;
        }

        //Get a list of Players by Team at a specific Position for Chaos Transfers
        private int[,] GetPGIDPositionList(int tgid, int pos)
        {
            int[,] list = new int[15, 3];  // record id, pgid, povr

            int pgidStart = tgid * 70;
            int j = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (GetPGIDfromRecord(i) >= pgidStart && GetPGIDfromRecord(i) < pgidStart + 70 && GetPPOSfromRecord(i) == pos && GetPTYPfromRecord(i) != 3 && GetPTYPfromRecord(i) != 1)
                {
                    list[j, 0] = i; 
                    list[j, 1] = GetPGIDfromRecord(i);
                    list[j, 2] = GetPOVRfromRecord(i);
                    j++;
                }
            }

            return list;
        }

        //Transfers Players - Updates TRAN table and sets PLAY-PTYP field to 1
        private void TransferPlayer(int i, int PGID)
        {
            int row = TDB.TableRecordCount(dbIndex, "TRAN");
            TDB.TDBTableRecordAdd(dbIndex, "TRAN", false);
            TDB.NewfieldValue(dbIndex, "TRAN", "PGID", row, Convert.ToString(PGID));
            TDB.NewfieldValue(dbIndex, "TRAN", "PTID", row, "300");
            TDB.NewfieldValue(dbIndex, "TRAN", "TRYR", row, "0");
            TDB.NewfieldValue(dbIndex, "PLAY", "PTYP", i, "1");
        }

        //Pre-Season Injuries -- randomly give injuries to players in pre-season
        private void PreseasonInjuries()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            int inj = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (rand.Next(0, 8280) < numInjuries.Value && inj < 450)
                {
                    int injl = rand.Next(50, 255);
                    int injt = rand.Next(180, 221);
                    TDB.TDBTableRecordAdd(dbIndex, "INJY", true);
                    TDB.NewfieldValue(dbIndex, "INJY", "PGID", inj, TDB.FieldValue(dbIndex, "PLAY", "PGID", i));
                    TDB.NewfieldValue(dbIndex, "INJY", "INJL", inj, Convert.ToString(injl));
                    TDB.NewfieldValue(dbIndex, "INJY", "INJT", inj, Convert.ToString(injt));
                    TDB.NewfieldValue(dbIndex, "INJY", "SEWN", inj, "0");
                    ReduceSkills(i, (int)MaxSkillDropPS.Value);
                    inj++;
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Injury Distributions are complete!");
        }


    }
}
