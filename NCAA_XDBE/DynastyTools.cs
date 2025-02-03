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

        #region Dynasty Tools Clicks


        //Pre-Season Injury Distributor
        private void ButtonPSInjuries_Click(object sender, EventArgs e)
        {
            PreseasonInjuries();
        }

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void MedRS_Click(object sender, EventArgs e)
        {
            MedicalRedshirt();
        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled
        /* 
        Use current TEAM's TMPR and COCH's CTOP to make CPRE updated, then update CTOP to match previous TMPR
        */
        private void coachProg_Click(object sender, EventArgs e)
        {
            CoachPrestigeProgression();
        }



        //Conference Realignment
        private void buttonRealignment_Click(object sender, EventArgs e)
        {
            ConfRealignment();
        }


        //Players to Coaches
        private void buttonPlayerCoach_Click(object sender, EventArgs e)
        {
            PlayerToCoach();
        }


        //Body Size Progression Click
        private void BodyProgressionButton_Click(object sender, EventArgs e)
        {
            PlayerBodySizeProgression();
        }

        //Remove all Sanctions
        private void RemoveSanctionsButton_Click(object sender, EventArgs e)
        {
            RemoveAllSanctions();
        }

        //EXPERIMENTAL ITEMS -- WORK IN PROGRESS
        private void buttonChaosTransfers_Click(object sender, EventArgs e)
        {
            ChaosTransfers();
        }

        //Reset Games Played
        private void ResetGamesPlayed_Click(object sender, EventArgs e)
        {
            ResetGP();
        }


        #endregion


        //Pre-Season Injuries -- randomly give injuries to players in pre-season
        private void PreseasonInjuries()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Step = 1;

            int inj = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (rand.Next(0, 8280) < numInjuries.Value && inj < 450)
                {
                    int injl = rand.Next(50, 255);
                    int injt = rand.Next(180, 221);
                    AddTableRecord("INJY", true);
                    ChangeDBString("INJY", "PGID", inj, GetDBValue("PLAY", "PGID", i));
                    ChangeDBString("INJY", "INJL", inj, Convert.ToString(injl));
                    ChangeDBString("INJY", "INJT", inj, Convert.ToString(injt));
                    ChangeDBString("INJY", "SEWN", inj, "0");
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
            progressBar1.Maximum = GetTableRecCount("INJY");
            string names = "";
            //looks at INJY table
            for (int i = 0; i < GetTableRecCount("INJY"); i++)
            {
                string injLength = GetDBValue("INJY", "INJL", i);
                //check to see if value is greater than 225
                /* 254 = Season Ending
                 * 196 = 10 weeks
                 */
                if (Convert.ToInt32(injLength) >= 196 || Convert.ToInt32(GetDBValue("SEAI", "SEWN", 0)) >= 16)
                {
                    //find the corresponding PGID
                    string PGID = GetDBValue("INJY", "PGID", i);
                    //find the corresponding recNo of the PGID in PLAY
                    for (int j = 0; j < GetTableRecCount("PLAY"); j++)
                    {
                        if (PGID == GetDBValue("PLAY", "PGID", j))
                        {
                            //checks to see if player has only played 4 or less games
                            if (NextMod)
                            {
                                if (Convert.ToInt32(GetDBValue("PLAY", "PL13", j)) <= 4 && GetDBValue("PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    ChangeDBString("PLAY", "PRSD", j, "1");
                                    string team = GetTeamName(Convert.ToInt32(GetDBValue("PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        ReduceSkills(i, (int)skillDrop.Value);
                                    }

                                    names += "\n * " + GetFirstNameFromRecord(j) + " " + GetLastNameFromRecord(j) + " (" + team + ")";
                                    break;
                                }
                            }
                            else
                            {
                                if (GetDBValue("PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    ChangeDBString("PLAY", "PRSD", j, "1");
                                    string team = GetTeamName(Convert.ToInt32(GetDBValue("PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        ReduceSkills(i, (int)skillDrop.Value);
                                    }

                                    names += "\n * " + GetFirstNameFromRecord(j) + " " + GetLastNameFromRecord(j) + " (" + team + ")";
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
            int PACC, PSPD, PAGI, PJMP;
            int tol = maxDrop;

            PPOE = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PPOE", i)));
            PINJ = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PINJ", i)));
            PSTA = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PSTA", i)));
            PSTR = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PSTR", i)));
            PACC = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PACC", i)));
            PSPD = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PSPD", i)));
            PAGI = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PAGI", i)));
            PJMP = ConvertRating(Convert.ToInt32(GetDBValue("PLAY", "PJMP", i)));


            PPOE = RevertRating(GetReducedAttribute(PPOE, tol));
            PINJ = RevertRating(GetReducedAttribute(PINJ, tol));
            PSTA = RevertRating(GetReducedAttribute(PSTA, tol));
            PSTR = RevertRating(GetReducedAttribute(PSTR, tol));
            PACC = RevertRating(GetReducedAttribute(PACC, tol));
            PSPD = RevertRating(GetReducedAttribute(PSPD, tol));
            PAGI = RevertRating(GetReducedAttribute(PAGI, tol));
            PJMP = RevertRating(GetReducedAttribute(PJMP, tol));


            ChangeDBString("PLAY", "PPOE", i, Convert.ToString(PPOE));
            ChangeDBString("PLAY", "PINJ", i, Convert.ToString(PINJ));
            ChangeDBString("PLAY", "PSTA", i, Convert.ToString(PSTA));
            ChangeDBString("PLAY", "PSTR", i, Convert.ToString(PSTR));
            ChangeDBString("PLAY", "PACC", i, Convert.ToString(PACC));
            ChangeDBString("PLAY", "PSPD", i, Convert.ToString(PSPD));
            ChangeDBString("PLAY", "PAGI", i, Convert.ToString(PAGI));
            ChangeDBString("PLAY", "PJMP", i, Convert.ToString(PJMP));

            RecalculateOverallByRec(i);

        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled

        private void CoachPrestigeProgression()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");


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

            if (!NextMod)
            {
                string coach = "";
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    if (GetDBValue("COCH", "TGID", i) != "511")
                    {
                        string TGID = GetDBValue("COCH", "TGID", i);
                        int oldPrestige = Convert.ToInt32(GetDBValue("COCH", "CPRE", i));
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
                            coach += "\n* " + GetTeamName(Convert.ToInt32(GetDBValue("COCH", "TGID", i))) + ": " + GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " (+" + (newPrestige - oldPrestige) + ")";
                        }
                        else if (newPrestige < oldPrestige)
                        {
                            coach += "\n* " + GetTeamName(Convert.ToInt32(GetDBValue("COCH", "TGID", i))) + ": " + GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " (" + (newPrestige - oldPrestige) + ")";
                        }
                        ChangeDBString("COCH", "CPRE", i, Convert.ToString(newPrestige));
                    }
                    else
                    {
                        ChangeDBString("COCH", "CCPO", i, "60"); //fixes coach status
                    }

                    //add a year of coaching at the team
                    int year = GetDBValueInt("COCH", "CTYR", i);
                    ChangeDBInt("COCH", "CTYR", i, (year+1));


                    progressBar1.PerformStep();
                }

                progressBar1.Visible = false;
                progressBar1.Value = 0;

                MessageBox.Show("Coach Prestige Changes:\n\n" + coach);
                coachProgComplete = true;
            }
            else
            {
                MessageBox.Show("This module is not available for NCAA NEXT Users.");
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
            progressBar1.Maximum = GetTableRecCount("TEAM");

            int maxTransfers = 500;
            int currentRecCount = GetTableRecCount("TRAN");
            string transferNews = "";

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (currentRecCount >= maxTransfers) break;

                if (GetDBValue("TEAM", "TTYP", i) == "0")
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

                                transferNews += GetFirstNameFromRecord(players[maxOVRid, 0]) + " " + GetLastNameFromRecord(players[maxOVRid, 0]) + " (" + GetTeamName(tgid) + ") OVR: " + ConvertRating(maxOVR) + "\n\n";

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


        //Conference Realignment Mod
        private void ConfRealignment()
        {
            List<int> PowerConfList = new List<int>(); //determines the Power Conferences
            List<int> GroupConfList = new List<int>(); //determines the non-Power Conferences
            int maxPrestige = 0;

            //determines what power conference prestige value is...
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetConfPrestige(i) < maxPrestige) maxPrestige = GetConfPrestige(i);
            }

            //creates a list of power and non-power conferences
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
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

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
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
            int x = GetTableRecCount("TSWP");
            AddTableRecord("TSWP", false);
            ChangeDBString("TSWP", "TGID", x, Convert.ToString(GetTeamTGIDfromRecord(teamA)));
            ChangeDBString("TSWP", "TIDR", x, Convert.ToString(GetTeamTGIDfromRecord(teamB)));
            ChangeDBString("TSWP", "TORD", x, Convert.ToString(x));

            int teamACGID = GetTeamCGID(teamA);
            int teamADGID = GetTeamDGID(teamA);
            int teamBCGID = GetTeamCGID(teamB);
            int teamBDGID = GetTeamDGID(teamB);

            ChangeDBString("TEAM", "CGID", teamA, Convert.ToString(teamBCGID));
            ChangeDBString("TEAM", "CGID", teamB, Convert.ToString(teamACGID));
            ChangeDBString("TEAM", "DGID", teamA, Convert.ToString(teamBDGID));
            ChangeDBString("TEAM", "DGID", teamB, Convert.ToString(teamADGID));


        }

        private int[,] CreateRegionDB()
        {

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\misc\SRGN.csv");

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
                if (regionList[i, 1] == a && regionList[i, 2] == b)
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
            progressBar1.Maximum = GetTableRecCount("COCH");

            int minRating = 0;
            while (CCID_FAList.Count < numberPlayerCoach.Value)
            {
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    //ADD COACHING FREE AGENCY POOL TO THE LIST
                    if (GetDBValue("COCH", "TGID", i) == "511" && Convert.ToInt32(GetDBValue("COCH", "CPRE", i)) < minRating)
                    {
                        CCID_FAList.Add(GetDBValue("COCH", "CCID", i));
                    }
                    progressBar1.PerformStep();
                }
                minRating++;
            }



            //Create a list of graduating players
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                //Create a list of Players that are seniors and have high awareness
                if (ConvertRating(GetDBValueInt("PLAY", "PAWR", i)) >= 90 && GetDBValue("PLAY", "PYER", i) == "3")
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


                    string coachFN = GetDBValue("COCH", "CLFN", rec);
                    string coachLN = GetDBValue("COCH", "CLLN", rec);

                    news += "Removed: " + coachFN + " " + coachLN + "\n\n";

                    CCID_FAList.RemoveAt(x);

                    int y = rand.Next(0, PGID_List.Count);
                    int recP = PGID_List[y];

                    string playFN = GetFirstNameFromRecord(recP);
                    string playLN = GetLastNameFromRecord(recP);
                    string team = GetTeamName(Convert.ToInt32(GetDBValue("PLAY", "PGID", recP)) / 70);
                    PGID_List.RemoveAt(y);

                    ChangeDBString("COCH", "CLFN", rec, playFN);
                    ChangeDBString("COCH", "CLLN", rec, playLN);

                    //SKIN COLOR, need to convert to 0, 1, 5

                    int skin = GetDBValueInt("PLAY", "PSKI", recP);
                    if (skin > 3) skin = 5;
                    else if (skin > 0) skin = 2;
                    ChangeDBInt("COCH", "CSKI", rec, skin);

                    ChangeDBInt("COCH", "CHAR", rec, GetDBValueInt("PLAY", "PHCL", recP));

                    ChangeDBInt("COCH", "CBSZ", rec, rand.Next(0, 3));

                    x = rand.Next(0, 5);
                    if (x > 0) x++;
                    ChangeDBInt("COCH", "CThg", rec, x);

                    ChangeDBInt("COCH", "CFEX", rec, rand.Next(0, 4));
                    ChangeDBInt("COCH", "CTgw", rec, rand.Next(0, 2));

                    x = rand.Next(0, 3);
                    if (x == 1) ChangeDBInt("COCH", "CThg", rec, 1);
                    else if (x == 2) ChangeDBInt("COCH", "CThg", rec, 0);

                    ChangeDBInt("COCH", "COHT", rec, x);

                    news += "Added: " + playFN + " " + playLN + " (" + team + ")\n\n";



                    //Clear COCH Stats Data
                    ClearCoachStats(rec);


                    //Calculate COCH PRESTIGE
                    int prestige = Convert.ToInt32(GetDBValue("PLAY", "POVR", recP));

                    if (prestige > 27) prestige = 4;
                    else if (prestige > 24) prestige = 3;
                    else if (prestige > 21) prestige = 2;
                    else prestige = 1;

                    ChangeDBString("COCH", "CPRE", rec, Convert.ToString(prestige));


                    //Determine Coaching Playbook and Strategies
                    int TGID = Convert.ToInt32(GetDBValue("PLAY", "PGID", recP)) / 70;
                    int recCOCH = -1;

                    for (int j = 0; j < GetTableRecCount("COCH"); j++)
                    {
                        if (GetDBValue("COCH", "TGID", j) == Convert.ToString(TGID))
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
            ChangeDBString("COCH", "CT05", rec, "0");
            ChangeDBString("COCH", "CT15", rec, "0");
            ChangeDBString("COCH", "CT25", rec, "0");
            ChangeDBString("COCH", "CCBB", rec, "0");
            ChangeDBString("COCH", "CFUC", rec, "0");
            ChangeDBString("COCH", "CCWI", rec, "0");
            ChangeDBString("COCH", "CSWI", rec, "0");
            ChangeDBString("COCH", "C25L", rec, "0");
            ChangeDBString("COCH", "CBLL", rec, "0");
            ChangeDBString("COCH", "CCOL", rec, "0");
            ChangeDBString("COCH", "CCRL", rec, "0");
            ChangeDBString("COCH", "CNTL", rec, "0");
            ChangeDBString("COCH", "CRVL", rec, "0");
            ChangeDBString("COCH", "CCWN", rec, "0");
            ChangeDBString("COCH", "CTWN", rec, "0");
            ChangeDBString("COCH", "CCLO", rec, "0");
            ChangeDBString("COCH", "CSLO", rec, "0");
            ChangeDBString("COCH", "CCPO", rec, "60");
            ChangeDBString("COCH", "CTOP", rec, "0");
            ChangeDBString("COCH", "CCTP", rec, "0");
            ChangeDBString("COCH", "CCYR", rec, "0");
            ChangeDBString("COCH", "CTYR", rec, "0");
            ChangeDBString("COCH", "COFS", rec, "0");
            ChangeDBString("COCH", "CCLS", rec, "0");
            ChangeDBString("COCH", "CSLS", rec, "0");
            ChangeDBString("COCH", "CTLS", rec, "0");
            ChangeDBString("COCH", "CCWS", rec, "0");
            ChangeDBString("COCH", "CRWS", rec, "0");
            ChangeDBString("COCH", "CSWS", rec, "0");
            ChangeDBString("COCH", "CCCT", rec, "0");
            ChangeDBString("COCH", "CCNT", rec, "0");
            ChangeDBString("COCH", "CWST", rec, "0");
            ChangeDBString("COCH", "C25W", rec, "0");
            ChangeDBString("COCH", "CBLW", rec, "0");
            ChangeDBString("COCH", "CCRW", rec, "0");
            ChangeDBString("COCH", "CCSW", rec, "0");
            ChangeDBString("COCH", "CCTW", rec, "0");
            ChangeDBString("COCH", "CNTW", rec, "0");
            ChangeDBString("COCH", "CRTW", rec, "0");
            ChangeDBString("COCH", "CTTW", rec, "0");
            ChangeDBString("COCH", "CNVW", rec, "0");
            ChangeDBString("COCH", "CRVW", rec, "0");
            ChangeDBString("COCH", "CCFY", rec, "0");
            ChangeDBString("COCH", "COTY", rec, "0");

        }

        private void AssignPlayerCoachStrategies(int recCOCH, int rec)
        {
            ChangeDBString("COCH", "CDTA", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTA", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTA", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTA", recCOCH)) + rand.Next(-3, 4)));

            ChangeDBString("COCH", "CDST", rec, GetDBValue("COCH", "CDST", recCOCH));
            ChangeDBString("COCH", "COST", rec, GetDBValue("COCH", "COST", recCOCH));
            ChangeDBString("COCH", "CPID", rec, GetDBValue("COCH", "CPID", recCOCH));

            ChangeDBString("COCH", "CDTR", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTR", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTR", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTR", recCOCH)) + rand.Next(-3, 4)));

            ChangeDBString("COCH", "CDTS", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "CDTS", recCOCH)) + rand.Next(-3, 4)));
            ChangeDBString("COCH", "COTS", rec, Convert.ToString(Convert.ToInt32(GetDBValue("COCH", "COTS", recCOCH)) + rand.Next(-3, 4)));

            //CDPC, CRPC, CTPC
            int CDPC, CRPC, CTPC;
            CRPC = Convert.ToInt32(GetDBValue("COCH", "CRPC", rec));
            CTPC = Convert.ToInt32(GetDBValue("COCH", "CTPC", rec));
            CDPC = 0;

            while (CDPC < 15 || CDPC > 25)
            {
                CTPC = rand.Next(25, 46);
                CRPC = rand.Next(25, 46);
                CDPC = 100 - CTPC - CRPC;
            }

            ChangeDBString("COCH", "CDPC", rec, Convert.ToString(CDPC));
            ChangeDBString("COCH", "CRPC", rec, Convert.ToString(CRPC));
            ChangeDBString("COCH", "CTPC", rec, Convert.ToString(CTPC));

        }

        //body size progression
        private void PlayerBodySizeProgression()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

            List<List<int>> bodysize = GetBodySizeAverages();

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PYER", i) <= 1)
                {
                    int pos = GetDBValueInt("PLAY", "PPOS", i);
                    int weight = GetDBValueInt("PLAY", "PWGT", i) + 160;
                    int avg = bodysize[pos][2];
                    int ppoe = GetDBValueInt("PLAY", "PPOE", i);
                    if (weight < avg)
                    {
                        double randSeed = rand.Next(0, ppoe + 1) / 31.0;
                        int gain = Convert.ToInt32((avg - weight) * randSeed);
                        if (gain > 25) gain = 25;
                        weight += gain;
                        ChangeDBInt("PLAY", "PWGT", i, weight - 160);
                    }

                    if (rand.Next(0, ppoe + 1) / 31.0 > 0.67)
                    {
                        int height = GetDBValueInt("PLAY", "PHGT", i) + 1;
                        ChangeDBInt("PLAY", "PHGT", i, height);
                    }

                    RecalculateIndividualBMI(i);
                }
                else
                {

                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;

            MessageBox.Show("Body Progressions Completed!");
        }


        //Determine Impact Players
        private void DetermineAllImpactPlayers()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("TEAM");
            progressBar1.Step = 1;

            int minRating = 0;
            minRating = RevertRating(Convert.ToInt32(ImpactPlayerMin.Value));


            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    ChangeDBInt("TEAM", "TPIO", i, 127);
                    ChangeDBInt("TEAM", "TPID", i, 127);
                    ChangeDBInt("TEAM", "TSI1", i, 127);
                    ChangeDBInt("TEAM", "TSI2", i, 127);

                    DetermineTeamImpactPlayers(i, minRating);
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Impact Players are Set!");
        }

        private void DetermineTeamImpactPlayers(int i, int minRating)
        {
            int TGID = GetDBValueInt("TEAM", "TGID", i);
            int PGIDbeg = TGID * 70;
            int PGIDend = PGIDbeg + 69;
            int count = 0;
            List<List<double>> roster = new List<List<double>>();

            ChangeDBInt("TEAM", "TPIO", i, 127);
            ChangeDBInt("TEAM", "TPID", i, 127);
            ChangeDBInt("TEAM", "TSI1", i, 127);
            ChangeDBInt("TEAM", "TSI2", i, 127);

            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);
                int POVR = GetDBValueInt("PLAY", "POVR", j);

                if (PGID >= PGIDbeg && PGID <= PGIDend && POVR >= minRating)
                {
                    int PPOS = GetDBValueInt("PLAY", "PPOS", j);

                    double POVRd = CalculatePositionRating(Convert.ToDouble(j), PPOS);
                    int PAWR = GetDBValueInt("PLAY", "PAWR", j);
                    int PIMP = GetDBValueInt("PLAY", "PIMP", j);

                    List<double> player = new List<double>();
                    roster.Add(player);
                    roster[count].Add(POVRd);
                    roster[count].Add(PPOS);
                    roster[count].Add(PGID);
                    roster[count].Add(PAWR);

                    count++;
                }
            }
            roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

            roster.OrderBy(player => player[3])
                   .ThenBy(player => player[0]);


            if (roster.Count == 0)
            {
                //do nothing
            }
            else
            {

                int countOff = 0;
                int countDef = 0;
                int impactCount = 0;
                for (int j = 0; j < roster.Count; j++)
                {
                    //pick offensive impact
                    if (roster[j][1] <= 4 && roster[j][1] != 2)
                    {
                        if (countOff == 0)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TPIO", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        else if (GetDBValueInt("TEAM", "TSI1", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        else if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        countOff++;
                    }

                    //pick defensive impact
                    else if (roster[j][1] >= 10 && roster[j][1] <= 18)
                    {
                        if (countDef == 0)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TPID", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        else if (GetDBValueInt("TEAM", "TSI1", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        else if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            impactCount++;
                        }
                        countDef++;
                    }

                    if (impactCount == 4)
                    {
                        break;
                    }
                }

                //pick offensive impact if no skill positions meet criteria
                if (countOff < 1)
                {
                    for (int j = 0; j < roster.Count; j++)
                    {

                        if (roster[j][1] <= 9)
                        {
                            if (countOff == 0)
                            {
                                double impactID = roster[j][2] - PGIDbeg;
                                ChangeDBString("TEAM", "TPIO", i, Convert.ToString(impactID));
                            }
                            if (countOff == 1)
                            {
                                double impactID = roster[j][2] - PGIDbeg;
                                ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            }
                            countOff++;
                        }

                        if (countOff > 1 && countDef > 1)
                        {
                            break;
                        }
                    }
                }
            }
        }

        //Remove All Sanctions
        private void RemoveAllSanctions()
        {
            string teams = "";
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "SNCT", i) > 0)
                {
                    ChangeDBInt("TEAM", "SNCT", i, 0);
                    ChangeDBInt("TEAM", "INPO", i, 0);
                    ChangeDBInt("TEAM", "SDUR", i, 0);
                    teams += "\n" + GetDBValue("TEAM", "TDNA", i);
                }
            }

            MessageBox.Show("All Sanctions Removed!\n\n" + teams);
        }

        //Reset Games Played
        private void ResetGP()
        {
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                ChangeDBInt("PLAY", "PL13", i, 0);
            }

            MessageBox.Show("Games Played Stat Reset to 0");
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
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("TRAN");
            progressBar1.Step = 1;
            
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

                if(TGID < 512) OccupiedPGIDList[TGID].Add(PGID);
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
                progressBar1.PerformStep();
            }

            CompactDB();
            CompactDB2();
            progressBar1.Value = 0;
            progressBar1.Visible = false;

        }


        //Remove Mediocre Transfers from Portal
        private void RemoveBadTransfers_Click(object sender, EventArgs e)
        {
            RemoveTransfers();
        }

        private void RemoveTransfers()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("TRAN");

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

                for(int p = 0; p < teamPlayers[tgid].Count; p++)
                {
                    if (teamPlayers[tgid][p][1] == pgid)
                    {
                        if (ConvertRating(teamPlayers[tgid][p][2]) < 68)
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

                progressBar1.PerformStep();
            }

            CompactDB();

            progressBar1.Visible = false;

            MessageBox.Show("Completed! Removed " + counter + " players from the database.");
        }
    }
}