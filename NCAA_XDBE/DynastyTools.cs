using System.Reflection;
using System.Text;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        #region Dynasty Tools Clicks

        //Start Dynasty Editor
        private void StartDynastyEditor()
        {
            if (GetDBValueInt("GOPT", "OFCF", 0) == 0)
            {
                ContractsCheckBox.Checked = false;
            }
            else
            {
                ContractsCheckBox.Checked = true;
            }

            InjuryGridView.Rows.Clear();
            SuspensionView.Rows.Clear();
            RemoveInjuryButton.Visible = false;
            RemoveAllInjuryButton.Visible = false;
            RemoveSuspensionButton.Visible = false;
            RemoveAllSuspensionsButton.Visible = false;
        }

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
        private void ResetGP_Click(object sender, EventArgs e)
        {
            ResetGP();
        }

        //Contracts On/Off
        private void ContractsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ContractsCheckBox.Checked)
            {
                ChangeDBInt("GOPT", "OFCF", 0, 1);
            }
            else
            {
                ChangeDBInt("GOPT", "OFCF", 0, 0);
            }
        }

        //Set Min Team Prestige
        private void SetMinTeamPrestigeButton_Click(object sender, EventArgs e)
        {
            SetMinTeamPrestige();
        }


        //Export To Dynasty Tracker
        private void exportDynastyTrackerButton_Click(object sender, EventArgs e)
        {
            StartProgressBar(TDB.TableCount(dbIndex));
            string seasonFolder = "";
            string filePath = "";
            string season = "" + (GetDBValueInt("SEAI", "SEYR", 0) + DynStartYear.Value);
            FolderBrowserDialog folderDialog1 = new FolderBrowserDialog();
            folderDialog1.ShowDialog();
            filePath = folderDialog1.SelectedPath;
            seasonFolder = Path.Combine(filePath, season);
            Directory.CreateDirectory(seasonFolder);

            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);
            exportAll = true;

            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbIndex); i++)
            {
                // Get the tableproperties for the given table number
                SelectedTableName = GetTableName(dbIndex, i);
                SelectedTableIndex = i;


                for (int r = 0; r < GetTableRecCount(SelectedTableName); r++)
                {
                    DeleteRecord(SelectedTableName, r, false);
                }


                ExportDB(seasonFolder);
                ProgressBarStep();
            }
            EndProgressBar();

            exportAll = false;

            MessageBox.Show("Dynasty Tracker files successfully exported to the Dynasty Tracker");
        }


        #endregion


        //Pre-Season Injuries -- randomly give injuries to players in pre-season
        private void PreseasonInjuries()
        {
            StartProgressBar(GetTableRecCount("PLAY"));

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
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Injury Distributions are complete!");
        }

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void MedicalRedshirt()
        {
            StartProgressBar(GetTableRecCount("INJY"));
            string names = "";
            //looks at INJY table
            for (int i = 0; i < GetTableRecCount("INJY"); i++)
            {
                int injLength = GetDBValueInt("INJY", "INJL", i);
                //check to see if value is greater than 225
                /* 254 = Season Ending
                 * 195-214 = 10 weeks
                 * Coding:    ((INJL - 15) / 20)  + 1
                 */

                int injuryWeeks = ((injLength - 15) / 20) + 1;
                int seaWeek = GetDBValueInt("SEAI", "SEWN", 0);

                int val = seaWeek + injuryWeeks;

                //Check at Mid-Season
                if (val >= 12 && Convert.ToInt32(GetDBValue("SEAI", "SEWN", 0)) <= 7)
                {
                    //find the corresponding PGID
                    string PGID = GetDBValue("INJY", "PGID", i);
                    //find the corresponding recNo of the PGID in PLAY
                    for (int j = 0; j < GetTableRecCount("PLAY"); j++)
                    {
                        if (PGID == GetDBValue("PLAY", "PGID", j))
                        {
                            //checks to see if player has only played 4 or less games
                            if (verNumber >= 15.0)
                            {
                                if (Convert.ToInt32(GetDBValue("PLAY", "PL13", j)) <= 4 && GetDBValue("PLAY", "PRSD", j) != "1")
                                {
                                    //changes redshirt status to "1" (active redshirt)
                                    ChangeDBString("PLAY", "PRSD", j, "1");
                                    if (verNumber >= 16.0) ChangeDBInt("PLAY", "PRSD", j, 3);
                                    string team = GetTeamName(Convert.ToInt32(GetDBValue("PLAY", "PGID", j)) / 70);

                                    if (checkBoxInjuryRatings.Checked)
                                    {
                                        ReduceSkills(i, (int)skillDrop.Value);
                                    }

                                    names += "\n * " + GetFirstNameFromRecord(j) + " " + GetLastNameFromRecord(j) + " (" + team + ")";
                                    ChangeDBInt("INJY", "INJL", i, 254); // set to season ending
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
                                    ChangeDBInt("INJY", "INJL", i, 254); // set to season ending
                                    break;
                                }
                            }

                            break;
                        }
                    }
                    ProgressBarStep();
                }
            }
            EndProgressBar();

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
            StartProgressBar(GetTableRecCount("COCH"));


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

            if (verNumber < 15.0)
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
                    ChangeDBInt("COCH", "CTYR", i, (year + 1));


                    ProgressBarStep();
                }

                EndProgressBar();

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

            StartProgressBar(GetTableRecCount("TEAM"));

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
                ProgressBarStep();
            }


            MessageBox.Show(transferNews, "TRANSFER PORTAL NEWS");

            EndProgressBar();
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
                if (GetConfPrestige(i) > maxPrestige) maxPrestige = GetConfPrestige(i);
            }

            //creates a list of power and non-power conferences
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetConfPrestige(i) < maxPrestige && GetConfLeague(i) == 0)
                {
                    GroupConfList.Add(GetConfCGID(i));
                }
                else if (GetConfPrestige(i) >= maxPrestige && GetConfLeague(i) == 0)
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
                    strArray = new int[2705, Line.Length];
                }
                else
                {
                    for (int column = 0; column < Line.Length; column++)
                    {
                        strArray[Row, column] = Convert.ToInt32(Line[column]);
                    }
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




        //body size progression
        private void PlayerBodySizeProgression()
        {
            StartProgressBar(GetTableRecCount("PLAY"));

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

                    RecalculateIndividualBodyShape(i, "PLAY");
                }
                else
                {

                }
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Body Progressions Completed!");
        }


        //Determine Impact Players
        private void DetermineAllImpactPlayers()
        {
            StartProgressBar(GetTableRecCount("TEAM"));
            bool QBHB = false;
            if (ImpactQBHB.Checked) QBHB = true;

            List<int> InjuryList = new List<int>();
            if (ImpactInjuries.Checked)
            {
                for (int i = 0; i < GetTableRecCount("INJY"); i++)
                {
                    int PGID = GetDBValueInt("INJY", "PGID", i);
                    InjuryList.Add(PGID);
                }

                for (int i = 0; i < GetTableRecCount("SPYR"); i++)
                {
                    int suspensionLength = GetDBValueInt("SPYR", "SEWN", i) - GetDBValueInt("SEAI", "SEWN", 0);
                    int PGID = GetDBValueInt("SPYR", "PGID", i);
                    if (suspensionLength > 0) InjuryList.Add(PGID);
                }
            }

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

                    DetermineTeamImpactPlayers(i, minRating, InjuryList, QBHB);
                }
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Impact Players are Set!");
        }

        private void DetermineTeamImpactPlayers(int i, int minRating, List<int> InjuryList, bool QBHB)
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

                if (PGID >= PGIDbeg && PGID <= PGIDend && POVR >= minRating && !InjuryList.Contains(PGID))
                {
                    int PPOS = GetDBValueInt("PLAY", "PPOS", j);

                    double POVRd = CalculatePositionRating(Convert.ToDouble(j), PPOS);
                    int PAWR = GetDBValueInt("PLAY", "PAWR", j);

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


            int countOff = 0;
            int countDef = 0;
            int impactCount = 0;

            if (roster.Count == 0)
            {
                //do nothing
            }
            else if (QBHB)
            {
                //Get Depth Chart
                List<int> QBs = new List<int> { 0, 0, 0 };
                List<int> RBs = new List<int> { 0, 0, 0, 0 };
                int countD = 0;
                for (int d = 0; d < GetTableRecCount("DCHT"); d++)
                {
                    int pgidx = GetDBValueInt("DCHT", "PGID", d);
                    int tgidx = pgidx / 70;
                    int ppos = GetDBValueInt("DCHT", "PPOS", d);
                    int ddep = GetDBValueInt("DCHT", "ddep", d);
                    if (tgidx == TGID && ppos <= 1)
                    {
                        if (ppos == 0) QBs[ddep] = pgidx;
                        else if (ppos == 1) RBs[ddep] = pgidx;
                        countD++;
                    }

                    if (countD >= 7) break;
                }

                for (int d = 0; d < QBs.Count; d++)
                {
                    if (!InjuryList.Contains(QBs[d]))
                    {
                        int impactID = QBs[d] - PGIDbeg;

                        ChangeDBInt("TEAM", "TPIO", i, impactID);
                        roster = RemovePlayerFromImpactList(roster, QBs[d]);

                        countOff++;
                        impactCount++;
                        break;
                    }
                }


                for (int d = 0; d < RBs.Count; d++)
                {
                    if (!InjuryList.Contains(RBs[d]))
                    {
                        int impactID = RBs[d] - PGIDbeg;
                        ChangeDBInt("TEAM", "TSI1", i, impactID);
                        roster = RemovePlayerFromImpactList(roster, RBs[d]);

                        countOff++;
                        impactCount++;
                        break;
                    }
                }



                for (int j = 0; j < roster.Count; j++)
                {
                    //pick offensive impact
                    if (roster[j][1] <= 4 && roster[j][1] != 2)
                    {

                        if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                    }

                    //pick defensive impact
                    else if (roster[j][1] >= 10 && roster[j][1] <= 18)
                    {
                        if (countDef == 0)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TPID", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;

                            impactCount++;
                        }
                        else if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;

                            impactCount++;
                        }
                        countDef++;
                    }

                    if (impactCount == 4)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int j = 0; j < roster.Count; j++)
                {
                    //pick offensive impact
                    if (roster[j][1] <= 4 && roster[j][1] != 2)
                    {
                        if (countOff == 0)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TPIO", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                        else if (GetDBValueInt("TEAM", "TSI1", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                        else if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
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
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                        else if (GetDBValueInt("TEAM", "TSI1", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                        else if (countOff + countDef >= 2 && GetDBValueInt("TEAM", "TSI2", i) == 127)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                            impactCount++;
                        }
                        countDef++;

                    }

                    if (impactCount == 4)
                    {
                        break;
                    }
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
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                        }
                        if (countOff == 1)
                        {
                            double impactID = roster[j][2] - PGIDbeg;
                            ChangeDBString("TEAM", "TSI1", i, Convert.ToString(impactID));
                            roster = RemovePlayerFromImpactList(roster, Convert.ToInt32(roster[j][2]));
                            j--;
                        }
                        countOff++;
                    }

                    if (countOff > 1 && countDef > 1)
                    {
                        break;
                    }
                }
            }

            //pick offensive impact if no skill positions meet criteria
            if (ImpactKickers.Checked)
            {
                //Get Depth Chart

                for (int d = 0; d < GetTableRecCount("DCHT"); d++)
                {
                    int pgidx = GetDBValueInt("DCHT", "PGID", d);
                    int tgidx = pgidx / 70;
                    int ppos = GetDBValueInt("DCHT", "PPOS", d);
                    int ddep = GetDBValueInt("DCHT", "ddep", d);
                    if (tgidx == TGID && ppos == 19 && ddep == 0)
                    {
                        double impactID = pgidx - PGIDbeg;
                        ChangeDBString("TEAM", "TSI2", i, Convert.ToString(impactID));
                        break;
                    }
                }
            }
        }

        private List<List<double>> RemovePlayerFromImpactList(List<List<double>> playerList, int pgid)
        {
            foreach (var player in playerList)
            {
                if (player[2] == pgid)
                {
                    playerList.Remove(player);
                    break;
                }
            }

            return playerList;
        }

        //Remove Impact Players
        private void RemoveAllImpactPlayers()
        {
            StartProgressBar(GetTableRecCount("TEAM"));


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
                }
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Removed All Impact Players!");
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


        //Sets Team Prestige to a minimum value for power conferences
        private void SetMinTeamPrestige()
        {
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int CGID = GetDBValueInt("TEAM", "CGID", i);
                int prestige = GetTeamPrestige(i);
                int confRec = GetTeamCONFrecID(CGID);
                if (GetDBValueInt("CONF", "CMNP", confRec) > prestige)
                {
                    ChangeDBInt("TEAM", "TMPR", i, 3);
                }
            }
            MessageBox.Show("All Power Conference teams have been set to be at least the minimum prestige.");
        }


        //TEST - RANKING 

        private void PlayoffRankerButton_Click(object sender, EventArgs e)
        {
            PlayoffRanker();
        }
        private void PlayoffRanker()
        {
            List<List<double>> TeamRankList = new List<List<double>>();
            StringBuilder rankingOutput = new StringBuilder();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int count = TeamRankList.Count;
                    List<double> team = new List<double>();
                    TeamRankList.Add(team);
                    TeamRankList[count].Add(i); // team record ID in TEAM
                    TeamRankList[count].Add(0); //total poll score
                    TeamRankList[count].Add(0); //games played
                    TeamRankList[count].Add(0); //Normalized Score over games played
                }
            }

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                int awayScore = GetDBValueInt("SCHD", "GASC", i);
                int awayTeam = GetDBValueInt("SCHD", "GATG", i);
                int homeScore = GetDBValueInt("SCHD", "GHSC", i);
                int homeTeam = GetDBValueInt("SCHD", "GHTG", i);
                int awayRank = GetDBValueInt("TEAM", "TROV", FindTeamRecfromTGID(awayTeam));
                int homeRank = GetDBValueInt("TEAM", "TROV", FindTeamRecfromTGID(homeTeam));

                if (awayScore > homeScore)
                {
                    for (int j = 0; j < TeamRankList.Count; j++)
                    {
                        if (GetDBValueInt("TEAM", "TGID", Convert.ToInt32(TeamRankList[j][0])) == awayTeam)
                        {
                            TeamRankList[j][1] += homeRank;
                            TeamRankList[j][2] += 1;
                        }
                        if (GetDBValueInt("TEAM", "TGID", Convert.ToInt32(TeamRankList[j][0])) == homeTeam)
                        {
                            TeamRankList[j][1] -= (100 - awayRank);
                            TeamRankList[j][2] += 1;
                        }
                    }
                }
                else if (homeScore > awayScore)
                {
                    for (int j = 0; j < TeamRankList.Count; j++)
                    {
                        if (GetDBValueInt("TEAM", "TGID", Convert.ToInt32(TeamRankList[j][0])) == homeTeam)
                        {
                            TeamRankList[j][1] += awayRank;
                            TeamRankList[j][2] += 1;
                        }
                        if (GetDBValueInt("TEAM", "TGID", Convert.ToInt32(TeamRankList[j][0])) == awayTeam)
                        {
                            TeamRankList[j][1] -= (100 - homeRank);
                            TeamRankList[j][2] += 1;
                        }
                    }
                }
            }

            foreach (var team in TeamRankList)
            {
                if (team[2] <= 12)
                    team[3] = team[1] / team[2];
                else
                    team[3] = team[1] / 12;
            }

            TeamRankList.Sort((team1, team2) => team2[3].CompareTo(team1[3]));

            rankingOutput.AppendLine("Team Rankings:\n");
            for (int i = 0; i < TeamRankList.Count; i++)
            {
                ChangeDBInt("TEAM", "TCRK", Convert.ToInt32(TeamRankList[i][0]), i + 1);
                if (i < 25)
                    rankingOutput.AppendLine($"{i + 1}. {GetDBValue("TEAM", "TDNA", Convert.ToInt32(TeamRankList[i][0]))} - {TeamRankList[i][3]:F2}");


            }

            MessageBox.Show(rankingOutput.ToString(), "Top 25 Rankings");
            MessageBox.Show("Ranking Update Completed!");
        }

    }
}