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
                string injLength = TDB.FieldValue(dbIndex, "INJY", "INJL", i);
                //check to see if value is greater than 225
                /* 254 = Season Ending
                 * 196 = 10 weeks
                 */
                if (Convert.ToInt32(injLength) >= 196 || Convert.ToInt32(TDB.FieldValue(dbIndex, "SEAI", "SEWN", 0)) >= 16)
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
                                    break;
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
                                    break;
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
            int PPOE, PINJ, PSTA, PSTR;
            //int PACC, PSPD, PAGI, PJMP;
            int tol = maxDrop;

            PPOE = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PPOE", i)));
            PINJ = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PINJ", i)));
            PSTA = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSTA", i)));
            PSTR = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSTR", i)));
            //PACC = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PACC", i)));
            //PSPD = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)));
            //PAGI = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PAGI", i)));
            //PJMP = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PJMP", i)));


            PPOE = RevertRating(GetReducedAttribute(PPOE, tol));
            PINJ = RevertRating(GetReducedAttribute(PINJ, tol));
            PSTA = RevertRating(GetReducedAttribute(PSTA, tol));
            PSTR = RevertRating(GetReducedAttribute(PSTR, tol));
            //PACC = RevertRating(GetReducedAttribute(PACC, tol));
            //PSPD = RevertRating(GetReducedAttribute(PSPD, tol));
            //PAGI = RevertRating(GetReducedAttribute(PAGI, tol));
            //PJMP = RevertRating(GetReducedAttribute(PJMP, tol));


            TDB.NewfieldValue(dbIndex, "PLAY", "PPOE", i, Convert.ToString(PPOE));
            TDB.NewfieldValue(dbIndex, "PLAY", "PINJ", i, Convert.ToString(PINJ));
            TDB.NewfieldValue(dbIndex, "PLAY", "PSTA", i, Convert.ToString(PSTA));
            TDB.NewfieldValue(dbIndex, "PLAY", "PSTR", i, Convert.ToString(PSTR));
            //TDB.NewfieldValue(dbIndex, "PLAY", "PACC", i, Convert.ToString(PACC));
            //TDB.NewfieldValue(dbIndex, "PLAY", "PSPD", i, Convert.ToString(PSPD));
            //TDB.NewfieldValue(dbIndex, "PLAY", "PAGI", i, Convert.ToString(PAGI));
            //TDB.NewfieldValue(dbIndex, "PLAY", "PJMP", i, Convert.ToString(PJMP));

            RecalculateOverallByRec(i);

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


        /* new method idea: 
         * look and compare team prestige and team rankings
         * 
         * team prestige categories:
         * 0-2
         * 3-4
         * 5-6
         * 
         * rankings:
         * 0-10 6
         * 11-20 5
         * 21-35 4
         * 36-60 3
         * 61-90 2
         * 76-90 1
         * 91-120 0
         * */

            string coach = "";
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                if (TDB.FieldValue(dbIndex, "COCH", "TGID", i) != "511")
                {
                    string TGID = TDB.FieldValue(dbIndex, "COCH", "TGID", i);
                    int oldPrestige = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CPRE", i));
                    int newPrestige = oldPrestige;

                    int TMPR = FindTeamPrestige(Convert.ToInt32(TGID));
                    int TMRK = FindTeamRanking(Convert.ToInt32(TGID));
                    int prestigePerformed = 0;

                    //calculate the prestige level of the team's season performance
                    if (TMRK <= 15) prestigePerformed = 6;
                    else if (TMRK <= 25) prestigePerformed = 5;
                    else if (TMRK <= 40) prestigePerformed = 4;
                    else if (TMRK <= 65) prestigePerformed = 3;
                    else if (TMRK <= 90) prestigePerformed = 2; 
                    else prestigePerformed = 1;

                    if (TMPR > prestigePerformed) newPrestige--;
                    if (TMPR < prestigePerformed) newPrestige++;

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
                }
                else
                {
                    TDB.NewfieldValue(dbIndex, "COCH", "CCPO", i, "60"); //fixes coach status
                }

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Coach Prestige Changes:\n\n" + coach);
            coachProgComplete = true;
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
                    CTPC = rand.Next(25, 46);
                    CRPC = rand.Next(25, 46);
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
                    string TGID = TDB.FieldValue(dbIndex, "COCH", "TGID", i);
                    int CTOP = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CTOP", i));
                    int TMPR = FindTeamPrestige(Convert.ToInt32(TGID));
                    int CCPO = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CCPO", i));

                    //FIRE COACHES
                    if (CCPO < jobSecurityValue.Value && CTOP > TMPR && TDB.FieldValue(dbIndex, "COCH", "CFUC", i) != "1" && rand.Next(0, 100) < (50 + jobSecurityValue.Value - CCPO))
                    {
                        CCID_FiredList.Add(TDB.FieldValue(dbIndex, "COCH", "CCID", i));
                        TGID_VacancyList.Add(TDB.FieldValue(dbIndex, "COCH", "TGID", i));

                        string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", i);
                        string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", i);
                        string teamID = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i)));


                        if (checkBoxFiredTransfers.Checked) CoachTransferPortal(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "TGID", i)), false);


                        news2 += "Fired: " + coachFN + " " + coachLN + " (" + teamID + ")\n\n";

                        TDB.NewfieldValue(dbIndex, "COCH", "TGID", i, "511");
                        TDB.NewfieldValue(dbIndex, "COCH", "CLTF", i, "511");
                        TDB.NewfieldValue(dbIndex, "COCH", "CCPO", i, "60");
                        TDB.NewfieldValue(dbIndex, "COCH", "CTYR", i, "0");


                    }
                    //ADD COACHES TO CANDIDATE LIST
                    else if (CCPO > 99 && CTOP < TMPR && TDB.FieldValue(dbIndex, "COCH", "CFUC", i) != "1")
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
                            TDB.NewfieldValue(dbIndex, "COCH", "CTYR", x, "0");


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
                            TDB.NewfieldValue(dbIndex, "COCH", "CTYR", x, "0");


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
            else news = news2 + "................................\n\n" + news;
            MessageBox.Show(news, "COACHING CAROUSEL");

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
                MessageBox.Show(transferNews, GetTeamName(teamRec) + "'s Coach Hired: TRANSFER PORTAL NEWS");
            }
            else
            {
                MessageBox.Show(transferNews, GetTeamName(teamRec) + "'s Coach Fired: TRANSFER PORTAL NEWS");

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

        //Conference Realignment Mod
        private void ConfRealignment()
        {
            List<int> PowerConfList = new List<int>(); //determines the Power Conferences
            List<int> GroupConfList = new List<int>(); //determines the non-Power Conferences
            int maxPrestige = 0;

            //determines what power conference prestige value is...
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "CONF"); i++)
            {
                if (GetConfPrestige(i) < maxPrestige) maxPrestige = GetConfPrestige(i);
            }

            //creates a list of power and non-power conferences
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "CONF"); i++)
            {
                if (GetConfPrestige(i) < maxPrestige && GetConfLeague(i) == 0)
                {
                    GroupConfList.Add(GetConfCGID(i));
                }
                else if (GetConfPrestige(i) == 3 && GetConfLeague(i) == 0)
                {
                    PowerConfList.Add(GetConfCGID(i));
                }
            }

            //Create a list of Teams to Promote and Demote based on Team and Conf Prestige Requirements

            List<int> PromoteTeamRecList = new List<int>();
            List<int> DemoteTeamRecList = new List<int>();
            string promote = "Promotion Qualified:\n\n";
            string demote = "Demotion Qualified:\n\n";

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
            {
                int TMPR = GetTeamPrestige(i);
                int CGID = GetTeamCGID(i);
                int TeamCONFRecID = GetTeamCONFrecID(CGID);

                if (GroupConfList.Contains(CGID) && TMPR >= GetConfCMXP(TeamCONFRecID))
                {
                    PromoteTeamRecList.Add(i);
                    promote += GetTeamName(GetTeamTGIDfromRecord(i)) + "\n";
                }

                else if (PowerConfList.Contains(CGID) && TMPR <= GetConfCMNP(TeamCONFRecID))
                {
                    DemoteTeamRecList.Add(i);
                    demote += GetTeamName(GetTeamTGIDfromRecord(i)) + "\n";
                }

            }

            MessageBox.Show(promote + demote);

            int[,] regionList = CreateRegionDB();
            string news = "";

            //Determine if there is a matching team/conf pair to swap
            if (PromoteTeamRecList.Count > 0 && DemoteTeamRecList.Count > 0)
            {
                while (PromoteTeamRecList.Count > 0)
                {
                    if (rand.Next(0, 100) < 50)
                    {
                        int x = rand.Next(0, DemoteTeamRecList.Count);

                        int pTeamStateID = GetTeamStateID(PromoteTeamRecList[0]);
                        int dTeamStateID = GetTeamStateID(DemoteTeamRecList[x]);
                        int region = GetRegionDifference(pTeamStateID, dTeamStateID, regionList);

                        if (rand.Next(0, 100) < 50 && DemoteTeamRecList.Count > 0 && region <= 3)
                        {

                            SwapTeams(DemoteTeamRecList[x], PromoteTeamRecList[0]);

                            news += GetTeamName(GetTeamTGIDfromRecord(DemoteTeamRecList[x])) + " swapped with " + GetTeamName(GetTeamTGIDfromRecord(PromoteTeamRecList[0])) + "\n\n";
                            DemoteTeamRecList.RemoveAt(x);
                        }
                    }

                    PromoteTeamRecList.RemoveAt(0);
                }
            }

            if (news == "") news = "No Realignments this Cycle!";

            MessageBox.Show(news);

        }

        private void SwapTeams(int teamA, int teamB)
        {
            int x = TDB.TableRecordCount(dbIndex, "TSWP");
            TDB.TDBTableRecordAdd(dbIndex, "TSWP", false);
            TDB.NewfieldValue(dbIndex, "TSWP", "TGID", x, Convert.ToString(GetTeamTGIDfromRecord(teamA)));
            TDB.NewfieldValue(dbIndex, "TSWP", "TIDR", x, Convert.ToString(GetTeamTGIDfromRecord(teamB)));
            TDB.NewfieldValue(dbIndex, "TSWP", "TORD", x, Convert.ToString(x));

            int teamACGID = GetTeamCGID(teamA);
            int teamADGID = GetTeamDGID(teamA);
            int teamBCGID = GetTeamCGID(teamB);
            int teamBDGID = GetTeamDGID(teamB);

            TDB.NewfieldValue(dbIndex, "TEAM", "CGID", teamA, Convert.ToString(teamBCGID));
            TDB.NewfieldValue(dbIndex, "TEAM", "CGID", teamB, Convert.ToString(teamACGID));
            TDB.NewfieldValue(dbIndex, "TEAM", "DGID", teamA, Convert.ToString(teamBDGID));
            TDB.NewfieldValue(dbIndex, "TEAM", "DGID", teamB, Convert.ToString(teamADGID));


        }

        private int[,] CreateRegionDB()
        {

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\SRGN.csv");

            //SRGN == Region Distance, State A, State B

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new int[2704, Line.Length];
                }
                for (int column = 0; column < Line.Length; column++)
                {
                    strArray[Row, column] = Convert.ToInt32(Line[column]);
                }
                Row++;
            }
            sr.Close();

            return strArray;
        }

        private int GetRegionDifference(int a, int b, int[,] regionList)
        {
            int region = -1;

            for (int i = 0; i < regionList.GetLength(0); i++) 
            {
                if (regionList[i,1] == a && regionList[i,2] == b)
                {
                    region = regionList[i, 0];
                    break;
                }
            }

            return region;
        }


        //Graduate to Coaching Mod

        private void PlayerToCoach()
        {

            List<string> CCID_FAList = new List<string>();
            List<int> PGID_List = new List<int>();
            string news = "";

            //Create a list of Free Agent Coach's from COCH

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "COCH");

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                //ADD COACHING FREE AGENCY POOL TO THE LIST
                if (TDB.FieldValue(dbIndex, "COCH", "TGID", i) == "511" && Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CPRE", i)) < 2)
                {
                    CCID_FAList.Add(TDB.FieldValue(dbIndex, "COCH", "CCID", i));
                }
                progressBar1.PerformStep();
            }


            //Create a list of graduating players
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                //Create a list of Players that are seniors and have high awareness
                if (Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PAWR", i)) >= 20 && TDB.FieldValue(dbIndex, "PLAY", "PYER", i) == "3")
                {
                    PGID_List.Add(i);
                }
                progressBar1.PerformStep();
            }


            if (PGID_List.Count >= numberPlayerCoach.Value)
            {
                //Randomly pick a FA Coach and replace with Player

                for (int i = 0; i < numberPlayerCoach.Value; i++)
                {
                    int x = rand.Next(0, CCID_FAList.Count);
                    string ccid = CCID_FAList[x];
                    int rec = FindRecNumberCCID(Convert.ToInt32(ccid));


                    string coachFN = TDB.FieldValue(dbIndex, "COCH", "CLFN", rec);
                    string coachLN = TDB.FieldValue(dbIndex, "COCH", "CLLN", rec);

                    news += "Removed: " + coachFN + " " + coachLN + "\n\n";

                    CCID_FAList.RemoveAt(x);

                    int y = rand.Next(0, PGID_List.Count);
                    int recP = PGID_List[y];

                    string playFN = ConvertFN_IntToString(recP);
                    string playLN = ConvertLN_IntToString(recP);
                    string team = GetTeamName(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PGID", recP))/70);
                    PGID_List.RemoveAt(y);

                    TDB.NewfieldValue(dbIndex, "COCH", "CLFN", rec, playFN);
                    TDB.NewfieldValue(dbIndex, "COCH", "CLLN", rec, playLN);

                    //SKIN COLOR, need to convert to 0, 1, 5

                    int skin = Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSKI", recP));
                    if (skin > 1) skin = 5;

                    TDB.NewfieldValue(dbIndex, "COCH", "CSKI", rec, Convert.ToString(skin));


                    news += "Added: " + playFN + " " + playLN + " (" + team + ")\n\n";



                    //Clear COCH Stats Data
                    ClearCoachStats(rec);


                    //Calculate COCH PRESTIGE
                    int prestige = Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "POVR", recP));

                    if (prestige > 27) prestige = 4;
                    else if (prestige > 24) prestige = 3;
                    else if (prestige > 21) prestige = 2;
                    else prestige = 1;

                    TDB.NewfieldValue(dbIndex, "COCH", "CPRE", rec, Convert.ToString(prestige));


                    //Determine Coaching Playbook and Strategies
                    int TGID = Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PGID", recP)) / 70;
                    int recCOCH = -1;
                    
                    for(int j = 0; j < TDB.TableRecordCount(dbIndex, "COCH"); j++)
                    {
                        if(TDB.FieldValue(dbIndex, "COCH", "TGID", j) == Convert.ToString(TGID))
                        {
                            recCOCH = j;
                        }
                    }

                    AssignPlayerCoachStrategies(recCOCH, rec);

                }

                MessageBox.Show(news, "Coaching List Changes");

            }
            else
            {
                MessageBox.Show("Please run this module with lower player settings");
            }


            progressBar1.Visible = false;


        }

        private void ClearCoachStats(int rec)
        {
            TDB.NewfieldValue(dbIndex, "COCH", "CT05", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CT15", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CT25", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCBB", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CFUC", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCWI", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CSWI", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "C25L", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CBLL", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCOL", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCRL", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CNTL", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CRVL", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCWN", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CTWN", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCLO", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CSLO", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCPO", rec, "60");
            TDB.NewfieldValue(dbIndex, "COCH", "CTOP", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCTP", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCYR", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CTYR", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "COFS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCLS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CSLS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CTLS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCWS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CRWS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CSWS", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCCT", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCNT", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CWST", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "C25W", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CBLW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCRW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCSW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCTW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CNTW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CRTW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CTTW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CNVW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CRVW", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "CCFY", rec, "0");
            TDB.NewfieldValue(dbIndex, "COCH", "COTY", rec, "0");

        }

        private void AssignPlayerCoachStrategies(int recCOCH, int rec)
        {
            TDB.NewfieldValue(dbIndex, "COCH", "CDTA", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CDTA", recCOCH)) + rand.Next(-3,4)));
            TDB.NewfieldValue(dbIndex, "COCH", "COTA", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "COTA", recCOCH)) + rand.Next(-3, 4)));

            TDB.NewfieldValue(dbIndex, "COCH", "CDST", rec, TDB.FieldValue(dbIndex, "COCH", "CDST", recCOCH));
            TDB.NewfieldValue(dbIndex, "COCH", "COST", rec, TDB.FieldValue(dbIndex, "COCH", "COST", recCOCH));
            TDB.NewfieldValue(dbIndex, "COCH", "CPID", rec, TDB.FieldValue(dbIndex, "COCH", "CPID", recCOCH));

            TDB.NewfieldValue(dbIndex, "COCH", "CDTR", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CDTR", recCOCH)) + rand.Next(-3, 4)));
            TDB.NewfieldValue(dbIndex, "COCH", "COTR", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "COTR", recCOCH)) + rand.Next(-3, 4)));

            TDB.NewfieldValue(dbIndex, "COCH", "CDTS", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CDTS", recCOCH)) + rand.Next(-3, 4)));
            TDB.NewfieldValue(dbIndex, "COCH", "COTS", rec, Convert.ToString(Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "COTS", recCOCH)) + rand.Next(-3, 4)));

            //CDPC, CRPC, CTPC
            int CDPC, CRPC, CTPC;
            CRPC = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CRPC", rec));
            CTPC = Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CTPC", rec));
            CDPC = 0;

            while (CDPC < 15 || CDPC > 25)
            {
                CTPC = rand.Next(25, 46);
                CRPC = rand.Next(25, 46);
                CDPC = 100 - CTPC - CRPC;
            }

            TDB.NewfieldValue(dbIndex, "COCH", "CDPC", rec, Convert.ToString(CDPC));
            TDB.NewfieldValue(dbIndex, "COCH", "CRPC", rec, Convert.ToString(CRPC));
            TDB.NewfieldValue(dbIndex, "COCH", "CTPC", rec, Convert.ToString(CTPC));

        }


    }
}