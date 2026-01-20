using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DB_EDITOR
{

    partial class MainEditor : Form
    {
        //Spring Portal 

        private void StartSpringPortal()
        {
            if (verNumber >= 15.0)
            {
                TransferEligible.Enabled = false;
            }
            else
            {
                TransferEligible.Enabled = true;
            }
        }

        #region Portal Roster Requirement Settings
        //Set Default Roster Req

        private void PortalDefaultSetting_Click(object sender, EventArgs e)
        {
            PortalQB.Value = 3;
            PortalHB.Value = 4;
            PortalFB.Value = 1;
            PortalWR.Value = 6;
            PortalTE.Value = 3;
            PortalOT.Value = 6;
            PortalOG.Value = 6;
            PortalOC.Value = 3;
            PortalDE.Value = 6;
            PortalDT.Value = 5;
            PortalOLB.Value = 6;
            PortalMLB.Value = 4;
            PortalCB.Value = 6;
            PortalFS.Value = 3;
            PortalSS.Value = 3;
            PortalK.Value = 1;
            PortalP.Value = 1;
        }

        //Set Minimum Roster Req
        private void SpringPortalMin_Click(object sender, EventArgs e)
        {
            PortalQB.Value = 2;
            PortalHB.Value = 3;
            PortalFB.Value = 1;
            PortalWR.Value = 3;
            PortalTE.Value = 2;
            PortalOT.Value = 3;
            PortalOG.Value = 3;
            PortalOC.Value = 2;
            PortalDE.Value = 4;
            PortalDT.Value = 4;
            PortalOLB.Value = 3;
            PortalMLB.Value = 3;
            PortalCB.Value = 3;
            PortalFS.Value = 2;
            PortalSS.Value = 2;
            PortalK.Value = 1;
            PortalP.Value = 1;
        }
        #endregion

        private void SpringPortalButton_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2ValueInt("RCYR", "SEWN", i) >= 6)
                {
                    correctWeek = true;
                    break;
                }
            }

            if (!correctWeek)
            {
                MessageBox.Show("Please use this feature after training is completed in off-season!");
            }
            else
            {
                CompactDB();
                CompactDB2();

                RunSpringPortal();
            }

        }

        #region Spring Portal Actions

        /* Spring Portal List
         *  0: PLAY Record
         *  1: RCPT Record
         *  2: PGID / PRID
         *  3: PPOS
         *  4: POVR
         *  5: TGID
         *  6: PYER
         *  7: Adjusted OVR
         *  8: PJEN
         *  9: TRAN Status
         *  10: RS
         *  11: DISC
         *  12: Is Starter
         *  13: POE
         */

        private void RunSpringPortal()
        {
            PortalData.ClearSelection();
            TotalTransfersCount.Text = "Total Transfers: 0";

            lblTransferPortalStatus.Text = "Starting the Portal...";
            lblTransferPortalStatus.Refresh();

            for (int x = 0; x < PortalCycleCount.Value; x++)
            {
                {
                    SpringPortal = new List<List<int>>();

                    TeamPortalNeeds = new int[512, 34];

                    lblTransferPortalStatus.Text = "Evaluating Team Rosters...";
                    lblTransferPortalStatus.Refresh();

                    CollectSpringRoster();

                    StartProgressBar(GetTableRecCount("TEAM"));

                    List<int> teamPrestigeList = BuildTeamPrestigeList();

                    lblTransferPortalStatus.Text = "FBS Players are now entering the portal...";
                    lblTransferPortalStatus.Refresh();

                    for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                    {
                        int tgid = GetDBValueInt("TEAM", "TGID", i);
                        if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                        {
                            DetermineTeamCuts(tgid, teamPrestigeList);
                        }
                        //Add any excess players to the Portal (fixes any mistakes)
                        else
                        {
                            //Create a list of players at the position
                            for (int p = 0; p < SpringRoster[tgid].Count; p++)
                            {
                                SpringPortal.Add(SpringRoster[tgid][p]);
                            }
                        }

                        ProgressBarStep();
                    }

                    EndProgressBar();

                    if (FCSTransferPortalCheckBox.Checked)
                    {
                        lblTransferPortalStatus.Text = "FCS Players are now entering the portal...";
                        lblTransferPortalStatus.Refresh();
                        CreateFCSPlayers();
                    }


                    lblTransferPortalStatus.Text = "The Transfer Portal is now active...";
                    lblTransferPortalStatus.Refresh();
                    RedistributePlayers();
                }


                lblTransferPortalStatus.Text = "Database clean-up...";
                lblTransferPortalStatus.Refresh();

                //Remove unused FCS players & change PTYP
                StartProgressBar(GetTableRecCount("PLAY"));

                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    int pgid = GetDBValueInt("PLAY", "PGID", i);
                    int tgid = pgid / 70;

                    if (pgid >= 30000)
                    {
                        DeleteRecord("PLAY", i, true);
                    }
                    else
                    {
                        int teamRec = FindTeamRecfromTGID(tgid);
                        if (GetDBValueInt("TEAM", "TTYP", teamRec) > 0)
                        {
                            RemovePlayerFromTRAN(pgid);
                            ClearPlayerStats(pgid);
                            DeleteRecord("PLAY", i, true);
                        }

                    }

                    ChangeDBInt("PLAY", "PTYP", i, 0);
                    ProgressBarStep();
                }
                EndProgressBar();

                StartProgressBar(GetTableRecCount("TRAN"));
                for (int i = 0; i < GetTableRecCount("TRAN"); i++)
                {
                    int pgid = GetDBValueInt("TRAN", "PGID", i);
                    if (pgid >= 30000)
                    {
                        DeleteRecord("TRAN", i, true);
                    }
                    ProgressBarStep();
                }
                EndProgressBar();
            }


            lblTransferPortalStatus.Text = "Checking Team Depth Chart for Walk-On Needs...";
            lblTransferPortalStatus.Refresh();

            CompactDB();
            PostPortalRosterCheck();
            CompactDB();
            CompactDB2();


            lblTransferPortalStatus.Text = "The Portal is now closed.";
            lblTransferPortalStatus.Refresh();
        }

        private void CollectSpringRoster()
        {
            OccupiedPGIDList = new List<List<int>>();
            AvailablePJEN = new List<List<int>>();
            SpringRoster = new List<List<List<int>>>();


            for (int i = 0; i < 512; i++)
            {
                OccupiedPGIDList.Add(new List<int>());
                AvailablePJEN.Add(new List<int>());
                SpringRoster.Add(new List<List<int>>());
            }

            StartProgressBar(GetTableRecCount("PLAY"));


            //Add Roster
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {

                int PGID = GetDBValueInt("PLAY", "PGID", i);
                int TGID = PGID / 70;

                OccupiedPGIDList[TGID].Add(PGID);

                int POVR = GetDBValueInt("PLAY", "POVR", i);
                int PPOS = GetDBValueInt("PLAY", "PPOS", i);
                int PYER = GetDBValueInt("PLAY", "PYER", i);
                int RS = GetDBValueInt("PLAY", "PRSD", i);
                int PJEN = GetDBValueInt("PLAY", "PJEN", i);
                int DISC = GetDBValueInt("PLAY", "PDIS", i);
                int POE = GetDBValueInt("PLAY", "PPOE", i);

                AvailablePJEN[TGID].Add(PJEN);

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

                int count = SpringRoster[TGID].Count;
                List<int> player = new List<int>();

                SpringRoster[TGID].Add(player);
                SpringRoster[TGID][count].Add(i);
                SpringRoster[TGID][count].Add(-1);
                SpringRoster[TGID][count].Add(PGID);
                SpringRoster[TGID][count].Add(PPOS);
                SpringRoster[TGID][count].Add(POVR);
                SpringRoster[TGID][count].Add(TGID);
                SpringRoster[TGID][count].Add(PYER);
                SpringRoster[TGID][count].Add(POVR);
                SpringRoster[TGID][count].Add(PJEN);
                SpringRoster[TGID][count].Add(0); //TRAN status
                SpringRoster[TGID][count].Add(RS);
                SpringRoster[TGID][count].Add(DISC);
                SpringRoster[TGID][count].Add(0);
                SpringRoster[TGID][count].Add(POE);
                SpringRoster[TGID][count].Add(-1); //Prev Tream if Transferred in Winter

                if (PortalRatingBoost.Checked)
                    SpringRoster[TGID][count][7] = POVR - (int)(SpringRoster[TGID][count][6] / 1.5);
                else
                    SpringRoster[TGID][count][7] = POVR;

                ProgressBarStep();
            }

            //Check for Transfers in TRAN
            for (int t = 0; t < GetTableRecCount("TRAN"); t++)
            {
                int pgid = GetDBValueInt("TRAN", "PGID", t);
                int tgid = pgid / 70;
                int ptid = GetDBValueInt("TRAN", "PTID", t);
                for (int i = 0; i < SpringRoster[tgid].Count; i++)
                {
                    if (SpringRoster[tgid][i][2] == pgid)
                    {
                        SpringRoster[tgid][i][9] = 1;
                        SpringRoster[tgid][i][14] = ptid;
                        break;
                    }
                }
            }



            StartProgressBar(GetTable2RecCount("RCPR"));

            //Add Recruits
            for (int i = 0; i < GetTable2RecCount("RCPR"); i++)
            {
                int TGID = GetDB2ValueInt("RCPR", "PTCM", i);
                int PRID = GetDB2ValueInt("RCPR", "PRID", i);
                int POVR = GetDB2ValueInt("RCPT", "POVR", i);
                int PPOS = GetDB2ValueInt("RCPT", "PPOS", i);
                int PYER = GetDBValueInt("RCPT", "PYER", i);
                int DISC = GetDBValueInt("RCPT", "PDIS", i);
                int POE = GetDBValueInt("RCPT", "PPOE", i);

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


                int count = SpringRoster[TGID].Count;
                List<int> player = new List<int>();

                SpringRoster[TGID].Add(player);
                SpringRoster[TGID][count].Add(-1);
                SpringRoster[TGID][count].Add(i);
                SpringRoster[TGID][count].Add(PRID);
                SpringRoster[TGID][count].Add(PPOS);
                SpringRoster[TGID][count].Add(POVR);
                SpringRoster[TGID][count].Add(TGID);
                SpringRoster[TGID][count].Add(PYER);
                SpringRoster[TGID][count].Add(POVR - (PYER / 2));
                SpringRoster[TGID][count].Add(18); //jersey number
                SpringRoster[TGID][count].Add(0); //TRAN status
                SpringRoster[TGID][count].Add(0);
                SpringRoster[TGID][count].Add(DISC);
                SpringRoster[TGID][count].Add(0);  //is Starter?
                SpringRoster[TGID][count].Add(POE);
                SpringRoster[TGID][count].Add(-1); //Prev Tream if Transferred in Winter

                SpringRoster[TGID][count][4] = POVR;
                if (PortalRatingBoost.Checked)
                    SpringRoster[TGID][count][7] = POVR - (SpringRoster[TGID][count][6] / 2);
                else
                    SpringRoster[TGID][count][7] = POVR;

                if (PRID >= 21000)
                {
                    int playRec = FindPGIDRecord(PRID);
                    PYER = GetDBValueInt("PLAY", "PYER", playRec);
                    SpringRoster[TGID][count][0] = playRec;
                    SpringRoster[TGID][count][6] = PYER;
                    SpringRoster[TGID][count][9] = 1;
                    SpringRoster[TGID][count][10] = GetDBValueInt("PLAY", "PRSD", playRec);
                }


                ProgressBarStep();
            }

            EndProgressBar();
        }

        private void XLportal_CheckedChanged(object sender, EventArgs e)
        {
            if (XLportal.Checked)
            {
                MessageBox.Show("Note: XL Portal has changed other portal settings.");
                SpringPortalMin.PerformClick();
                AllowStartersLeave.Checked = true;
                AllowBackupQBPortal.Checked = true;
                AllowRecentTransfers.Checked = true;
                PortalRatingBoost.Checked = true;
                FCSTransferPortalCheckBox.Checked = true;
                portalChance.Value = 80;
                starterChancePCT.Value = 25;
            }
            else
            {
                MessageBox.Show("Note: XL Portal settings have been reverted back to default.");
                PortalDefaultSetting.PerformClick();
                AllowStartersLeave.Checked = false;
                AllowBackupQBPortal.Checked = false;
                AllowRecentTransfers.Checked = false;
                PortalRatingBoost.Checked = false;
                FCSTransferPortalCheckBox.Checked = false;
                portalChance.Value = 67;
                starterChancePCT.Value = 8;
            }
        }

        private void DetermineTeamCuts(int tgid, List<int> teamPrestigeList)
        {
            decimal starterPCT = starterChancePCT.Value;
            int portalSize = 0;
            if (largePortal.Checked)
            {
                portalSize = 1;
            }

            else if (XLportal.Checked) 
            { 
                portalSize = 2;
            }


            List<decimal> depth = new List<decimal> { PortalQB.Value, PortalHB.Value, PortalFB.Value, PortalWR.Value, PortalTE.Value, PortalOT.Value, PortalOG.Value, PortalOC.Value, PortalDE.Value, PortalDT.Value, PortalOLB.Value, PortalMLB.Value, PortalCB.Value, PortalFS.Value, PortalSS.Value, PortalK.Value, PortalP.Value };

            List<int> depthDefault = new List<int> { 3, 4, 1, 6, 3, 5, 5, 3, 4, 4, 4, 4, 5, 3, 3, 1, 1 };
            int teamRec = FindTeamRecfromTGID(tgid);
            int teamWins = GetDBValueInt("TEAM", "tsdw", teamRec);


            for (int p = 0; p < depth.Count; p++)
            {
                List<List<int>> posList = new List<List<int>>();

                //Create a list of players at the position
                for (int i = 0; i < SpringRoster[tgid].Count; i++)
                {
                    if (SpringRoster[tgid][i][3] == p)
                    {
                        int ptyp = GetDBValueInt("PLAY", "PTYP", SpringRoster[tgid][i][0]);
                        if (ptyp == 1) SpringPortal.Add(SpringRoster[tgid][i]);
                        else posList.Add(SpringRoster[tgid][i]);
                    }
                }

                //Sort by OVR
                posList.Sort((player1, player2) => player2[7].CompareTo(player1[7]));

                //Adds to all scenarios
                if (posList.Count > 0) TeamPortalNeeds[tgid, p * 2] = posList[0][4]; //add starter rating (looks for starters)

                //team has enough players
                if (posList.Count > depth[p])
                {
                    //add players to the portal
                    for (int x = Convert.ToInt32(depth[p]); x < posList.Count; x++)
                    {
                        if (posList[x][0] != -1 && posList[x][9] == 0 || posList[x][2] >= 21000 && AllowRecentTransfers.Checked || posList[x][9] == 1 && AllowRecentTransfers.Checked)
                        {
                            if (rand.Next(1, 100) < portalChance.Value)
                                SpringPortal.Add(posList[x]);
                        }
                    }
                    //allow team to add a player if its large portal & available player is better than 2nd best
                    if (portalSize > 0 && posList.Count > 1) TeamPortalNeeds[tgid, p * 2 + 1] = posList[1][4];
                }

                //team does not have enough players
                else if (posList.Count <= depth[p])
                {
                    if (posList.Count <= 1 && p != 15 && p != 16 && p != 2 || posList.Count == 0 || depthDefault[p] - posList.Count >= 1)
                    {
                        //allow team to add player to fill depth gaps
                        TeamPortalNeeds[tgid, p * 2 + 1] = 1;
                    }
                    else
                    {
                        //allow team to add player that is better than the worst player at the depth position
                        TeamPortalNeeds[tgid, p * 2 + 1] = posList[posList.Count - 1][4];
                    }
                }

                //QB BACKUPS
                if (AllowBackupQBPortal.Checked && p == 0 && rand.Next(1, 100) < portalChance.Value && posList.Count > 1)
                {
                    // If the team has a backup QB, allow them to add a player to the portal
                    if (posList[1][0] != -1 && posList[1][9] == 0 || posList[1][2] >= 21000 && AllowRecentTransfers.Checked || posList[1][9] == 1 && AllowRecentTransfers.Checked)
                    {
                        SpringPortal.Add(posList[1]);
                        TeamPortalNeeds[tgid, p * 2 + 1] = 0;
                    }
                }

                //STARTERS
                if (AllowStartersLeave.Checked && p >= 0 && rand.Next(1, 100) < starterPCT && posList.Count > 1)
                {
                    // If the team has a backup QB, allow them to add a player to the portal
                    if (posList[0][0] != -1 && posList[0][9] == 0 || posList[0][2] >= 21000 && AllowRecentTransfers.Checked || posList[0][9] == 1 && AllowRecentTransfers.Checked)
                    {
                        int ovr = ConvertRating(posList[0][4]);
                        int disc = posList[0][11];
                        int tmpr = teamPrestigeList[tgid];
                        int poe = posList[0][13];

                        if (disc <= rand.Next(0, 8) && tmpr <= rand.Next(0, 8) || poe >= rand.Next(0, 25) && teamWins <= rand.Next(0, 10) || ovr > rand.Next(0, 100) & tmpr < rand.Next(0, 7) & teamWins <= rand.Next(0, 10) )
                        {
                            posList[0][12] = 1; //mark as starter leaving
                            SpringPortal.Add(posList[0]);
                            TeamPortalNeeds[tgid, p * 2 + 1] = 1;
                        }
                    }
                }

            }
        }

        private void CreateFCSPlayers()
        {
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

            int maxFCSPlayers = 300;
            if (newPlayers > maxFCSPlayers) newPlayers = maxFCSPlayers; //limit to XX players max

            for (int i = 0; i < newPlayers; i++)
            {
                int rec = GetTableRecCount("PLAY");
                AddTableRecord("PLAY", false);

                List<int> AvailablePJEN = new List<int>();

                int PGID = 30000 + rec;
                TransferRCATtoPLAY(rec, rand.Next(0, 17), PGID, RCATmapper, PJEN, AvailablePJEN, 0);
                RandomizeAttribute("PLAY", rec, 1);
                RecalculateOverallByRec(rec);

                //Assign a Team
                int TGID = fcsTeams[rand.Next(0, fcsTeams.Count)];

                //Add To Portal
                int POVR = GetDBValueInt("PLAY", "POVR", rec);
                int PPOS = GetDBValueInt("PLAY", "PPOS", rec);
                int PYER = GetDBValueInt("PLAY", "PYER", rec);
                int DISC = GetDBValueInt("PLAY", "PDIS", rec);
                int POE = GetDBValueInt("PLAY", "PPOE", rec);

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

                if (ConvertRating(POVR) >= 66)
                {

                    int count = SpringPortal.Count;
                    List<int> player = new List<int>();

                    SpringPortal.Add(player);
                    SpringPortal[count].Add(rec);
                    SpringPortal[count].Add(-1);
                    SpringPortal[count].Add(PGID);
                    SpringPortal[count].Add(PPOS);
                    SpringPortal[count].Add(POVR);
                    SpringPortal[count].Add(TGID);
                    SpringPortal[count].Add(PYER);
                    SpringPortal[count].Add(POVR - (PYER / 2));
                    SpringPortal[count].Add(18); //jersey number
                    SpringPortal[count].Add(0); //TRAN status
                    SpringPortal[count].Add(0);
                    SpringPortal[count].Add(DISC);
                    SpringPortal[count].Add(0);
                    SpringPortal[count].Add(POE);
                    SpringPortal[count].Add(-1); //Prev Tream if Transferred in Winter

                    SpringPortal[count][4] = POVR;
                    if (PortalRatingBoost.Checked)
                        SpringPortal[count][7] = POVR - (SpringPortal[count][6] / 2);
                    else
                        SpringPortal[count][7] = POVR;
                }
            }
        }

        private void RedistributePlayers()
        {
            PortalTransfersList = new List<List<int>>();

            if (SpringPortal.Count == 0) return;

            SpringPortal.Sort((player1, player2) => player2[7].CompareTo(player1[7]));

            List<List<int>> teamList = new List<List<int>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int tgid = GetDBValueInt("TEAM", "TGID", i);
                int rank = GetDBValueInt("TEAM", "TMRK", i);
                int ttyp = GetDBValueInt("TEAM", "TTYP", i);

                if (ttyp == 0) teamList.Add(new List<int> { tgid, rank, i });
            }

            //Create List of Team Prestige
            List<int> teamPRS = BuildTeamPrestigeList();

            //Create List of User Teams
            List<int> userTeams = BuildUserTeamList();

            if (PortalFirst.Checked)
            {
                teamList.Sort((player1, player2) => player1[1].CompareTo(player2[1]));
                SpringPortalNormalDistribution(teamList, teamPRS, userTeams);
            }
            else if (PortalReverse.Checked)
            {
                teamList.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
                SpringPortalNormalDistribution(teamList, teamPRS, userTeams);
            }
            else
            {
                Random rnd = new Random();
                teamList = teamList.OrderBy(x => rnd.Next()).ToList();
                SpringPortalRandomDistribution(teamList, teamPRS, userTeams);
            }

            CompactDB();

            DisplayPortalNews();
        }

        private void SpringPortalNormalDistribution(List<List<int>> teamList, List<int> teamPRS, List<int> userTeams)
        {

            StartProgressBar(teamList.Count);

            for (int t = 0; t < teamList.Count; t++)
            {
                if (SpringPortal.Count <= 0) break;
                int tgid = teamList[t][0];

                //Check for team needs
                if (OccupiedPGIDList[tgid].Count > 0 && OccupiedPGIDList[tgid].Count < 70 && SpringPortal.Count > 0)
                {
                    for (int p = 0; p < TeamPortalNeeds.GetLength(1); p++)
                    {

                        lblTransferPortalStatus.Text = "Team Pick: " + teamNameDB[tgid] + " | Position Pick: " + GetPOSG2Name(p/2);
                        lblTransferPortalStatus.Refresh();

                        if (SpringPortalUserChoice.Checked && userTeams.Contains(tgid)) UserTransferChoice(tgid, p, teamPRS);
                        else SpringPortalMatcher(tgid, p, teamPRS);
                    }
                }
                ProgressBarStep();
            }

            EndProgressBar();
        }

        private void SpringPortalRandomDistribution(List<List<int>> teamList, List<int> teamPRS, List<int> userTeams)
        {
            int round = 0;
            List<int> randPos = new List<int>(34);
            for (int p = 0; p < TeamPortalNeeds.GetLength(1); p++) randPos.Add(p);

            Random rnd = new Random();
            randPos = randPos.OrderBy(x => rnd.Next()).ToList();

            StartProgressBar(teamList.Count * 34);

            for (int p = 0; p < randPos.Count; p++)
            {
                if (PortalSnake.Checked)
                {
                    if (round % 2 == 0) teamList.Sort((team1, team2) => team2[1].CompareTo(team1[1]));
                    else teamList.Sort((team1, team2) => team1[1].CompareTo(team2[1]));
                    round++;
                }
                else if (RankingOrderPriority.Checked)
                {
                    BuildLotteryTeamList(ref teamList); // Extract to method
                }
                else if (ReverseRankingPriority.Checked)
                {
                    BuildReverseLotteryTeamList(ref teamList); // Extract to method
                }
                else
                {
                    rnd = new Random();
                    teamList = teamList.OrderBy(x => rnd.Next()).ToList();
                }

                for (int t = 0; t < teamList.Count; t++)
                {

                    if (SpringPortal.Count <= 0) break;
                    int tgid = teamList[t][0];

                    lblTransferPortalStatus.Text = "Team Pick: " + teamNameDB[tgid] + " | Position Pick: " + GetPOSG2Name(p / 2);
                    lblTransferPortalStatus.Refresh();

                    if (SpringPortalUserChoice.Checked && userTeams.Contains(tgid)) UserTransferChoice(tgid, p, teamPRS);
                    else SpringPortalMatcher(tgid, p, teamPRS);

                    ProgressBarStep();
                }
            }

            EndProgressBar();
        }

        #region Draft Lottery Methods

        // Draft Lottery
        private void BuildLotteryTeamList(ref List<List<int>> teamList)
        {
            teamList.Clear();
            int teamRecCount = GetTableRecCount("TEAM");
            List<List<int>> Lottery = new List<List<int>>();

            for (int i = 0; i < teamRecCount; i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int rank = GetDBValueInt("TEAM", "TCRK", i);
                    int balls = rank < 10 ? 300 : rank < 25 ? 150 : rank < 50 ? 50 : rank < 75 ? 25 : rank < 100 ? 10 : 5;

                    for (int j = 0; j < balls; j++)
                    {
                        int count = Lottery.Count;
                        Lottery.Add(new List<int>());
                        Lottery[count].Add(GetDBValueInt("TEAM", "TGID", i));
                        Lottery[count].Add(rand.Next(0, 9999));
                    }
                }
            }

            Lottery.Sort((team1, team2) => team1[1].CompareTo(team2[1]));
            PopulateTeamListFromLottery(Lottery, ref teamList);
        }

        // Reverse Draft Lottery
        private void BuildReverseLotteryTeamList(ref List<List<int>> teamList)
        {
            teamList.Clear();
            int teamRecCount = GetTableRecCount("TEAM");
            List<List<int>> Lottery = new List<List<int>>();

            for (int i = 0; i < teamRecCount; i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int rank = GetDBValueInt("TEAM", "TCRK", i);
                    int balls = rank < 10 ? 5 : rank < 25 ? 10 : rank < 50 ? 25 : rank < 75 ? 50 : rank < 100 ? 150 : 300;

                    for (int j = 0; j < balls; j++)
                    {
                        int count = Lottery.Count;
                        Lottery.Add(new List<int>());
                        Lottery[count].Add(GetDBValueInt("TEAM", "TGID", i));
                        Lottery[count].Add(rand.Next(0, 9999));
                    }
                }
            }

            Lottery.Sort((coach1, coach2) => coach1[1].CompareTo(coach2[1]));
            PopulateTeamListFromLottery(Lottery, ref teamList);
        }

        // Populate Team List from Lottery
        private void PopulateTeamListFromLottery(List<List<int>> Lottery, ref List<List<int>> teamList)
        {
            teamList = new List<List<int>>();
            int order = 0;
            while (Lottery.Count > 0)
            {
                int pick = rand.Next(0, Lottery.Count);
                int tgid = Lottery[pick][0];

                teamList.Add(new List<int>());
                teamList[order].Add(tgid);
                teamList[order].Add(order);

                for (int j = Lottery.Count - 1; j >= 0; j--) // Reverse iteration for safe removal
                {
                    if (Lottery[j][0] == tgid)
                    {
                        Lottery.RemoveAt(j);
                    }
                }

                order++;
            }
        }

        #endregion

        //Spring Portal Matchers
        private void SpringPortalMatcher(int tgid, int p, List<int> teamPRS)
        {

            //Check for team needs
            if (TeamPortalNeeds[tgid, p] <= 0) return;

            //Find Available PGID Numbers
            int tgidStart = tgid * 70;
            int tgidEnd = tgidStart + maxPlayers - 1;
            int newPGID = -1;

            //Check for open PGID slots
            for (int j = tgidStart; j <= tgidEnd; j++)
            {
                if (!OccupiedPGIDList[tgid].Contains(j))
                {
                    newPGID = j;
                    break;
                }
            }
            if (newPGID <= -1) return; //no available slots

            for (int i = 0; i < SpringPortal.Count; i++)
                {
                    int rec = SpringPortal[i][0];
                    int pgid = SpringPortal[i][2];
                    int pos = SpringPortal[i][3];
                    int ov = SpringPortal[i][4];
                    int team = SpringPortal[i][5];
                    int starter = SpringPortal[i][12];

                    if (pos == p / 2)
                    {
                        int tmpr = teamPRS[tgid];
                        int playerteamprestige = teamPRS[team];

                        if (starter == 1 && tmpr >= playerteamprestige && ov <= TeamPortalNeeds[tgid, p] || starter == 0 && ov <= TeamPortalNeeds[tgid, p] || rand.Next(0, 99) > portalChance.Value)
                        {
                            continue;
                        }
                        else
                        {
                            TransferPlayerManager(tgid, p, newPGID, i);
                            break;
                        }
                    }
                }
        }

        private void UserTransferChoice(int tgid, int p, List<int> teamPRS)
        {
            List<string> years = CreateClassYearsAbbr();
            List<int> PortalInterestList = new List<int>();

            //Check for team needs & Create Interest List
            if (TeamPortalNeeds[tgid, p] <= 0) return;

            //Find Available PGID Numbers
            int tgidStart = tgid * 70;
            int tgidEnd = tgidStart + maxPlayers - 1;
            int newPGID = -1;

            //Check for open PGID slots
            for (int j = tgidStart; j <= tgidEnd; j++)
            {
                if (!OccupiedPGIDList[tgid].Contains(j))
                {
                    newPGID = j;
                    break;
                }
            }
            if (newPGID <= -1) return; //no available slots


            for (int i = 0; i < SpringPortal.Count; i++)
            {
                int rec = SpringPortal[i][0];
                int pgid = SpringPortal[i][2];
                int pos = SpringPortal[i][3];
                int ov = SpringPortal[i][4];
                int team = SpringPortal[i][5];
                int starter = SpringPortal[i][12];

                if (pos == p / 2)
                {
                    int tmpr = teamPRS[tgid];
                    int playerteamprestige = teamPRS[team];

                    if (starter == 1 && tmpr >= playerteamprestige && ov <= TeamPortalNeeds[tgid, p] || starter == 0 && ov <= TeamPortalNeeds[tgid, p] || rand.Next(0, 99) > portalChance.Value)
                    {
                        continue;
                    }
                    else
                    {
                        PortalInterestList.Add(i);
                    }
                }
            }

            //Load User Choice Dialog

            if (PortalInterestList.Count == 0) return;


            using (var portalBox = new PortalBox(this, SpringPortal, PortalInterestList, p, tgid, newPGID))
            {
                portalBox.ShowDialog(this);

            }
        }


        #endregion


        #region Transfer & Player Table Management

        public void TransferPlayerManager(int newTGID, int p, int newPGID, int portalRec)
        {
            SpringPortal[portalRec].Add(newTGID); //stored at index 14
            PortalTransfersList.Add(SpringPortal[portalRec]);

            TransferPlayer(newTGID, p, newPGID, portalRec);
            AddTransferPlayerNews();
        }

        public void TransferPlayer(int tgid, int p, int newPGID, int portalRec)
        {
            int i = portalRec;


            int rec = SpringPortal[i][0];
            int pgid = SpringPortal[i][2];
            int team = SpringPortal[i][5];
            int pos = SpringPortal[i][3];
            int ptid = SpringPortal[i][14];

            //Transfers
            if (pgid >= 21000 && pgid < 30000)
            {
                //Update their commitment to the new team
                for (int y = 0; y < GetTable2RecCount("RCPR"); y++)
                {
                    if (GetDB2ValueInt("RCPR", "PRID", y) == pgid)
                    {
                        DeleteRecord2("RCPR", y, true);
                        CompactDB2();

                        break;
                    }
                }

                ChangeDBInt("PLAY", "PGID", SpringPortal[i][0], newPGID);

                ChangePlayerStatsID(SpringPortal[i][2], newPGID);
            }
            else
            {
                //Change their ID
                ChangeDBInt("PLAY", "PGID", rec, newPGID);


                int currentPJEN = GetDBValueInt("PLAY", "PJEN", rec);
                if (AvailablePJEN[tgid].Contains(currentPJEN))
                {
                    int newPJEN = ChooseAvailableJerseyNumber(pos, tgid, AvailablePJEN[tgid]);
                    ChangeDBInt("PLAY", "PJEN", rec, newPJEN);
                    AvailablePJEN[tgid].Add(newPJEN);
                }
                else
                {
                    AvailablePJEN[tgid].Add(currentPJEN);
                }

                // Need to add a thing to replace the RCTN table PGID
                for (int y = 0; y < GetTable2RecCount("RCTN"); y++)
                {
                    if (GetDB2ValueInt("RCTN", "PGID", y) == pgid)
                    {
                        ChangeDB2Int("RCTN", "PGID", y, newPGID);
                        break;
                    }
                }

                // Delete old stats & Change Player Stats ID
                ClearPlayerStats(newPGID);
                ChangePlayerStatsID(SpringPortal[i][2], newPGID);
            }

            if (p % 2 == 1 && TeamPortalNeeds[tgid, p] == 1 && smallPortal.Checked)
                TeamPortalNeeds[tgid, p - 1] = 0;

            else if (p % 2 == 0 && TeamPortalNeeds[tgid, p + 1] == 1 && smallPortal.Checked)
                TeamPortalNeeds[tgid, p + 1] = 0;

            TeamPortalNeeds[tgid, p] = 0;

            //Remove Player from TRAN table (if needed)
            if (SpringPortal[i][9] == 1) RemovePlayerFromTRAN(pgid);

            //Add Player to TRAN Table
            AddPlayertoTRAN(newPGID, team, ptid);

            OccupiedPGIDList[tgid].Add(newPGID);
            if (pgid / 70 < 512) OccupiedPGIDList[pgid / 70].Remove(pgid);



            SpringPortal.RemoveAt(i);
        }

        private void AddPlayertoTRAN(int PGID, int TGID, int PTID)
        {
            int count = GetTableRecCount("TRAN");
            AddTableRecord("TRAN", false);
            ChangeDBInt("TRAN", "PGID", count, PGID);
            ChangeDBInt("TRAN", "PTID", count, TGID);
            if(PTID > 0) ChangeDBInt("TRAN", "PTID", count, PTID);

            ChangeDBInt("TRAN", "TRYR", count, 0);

            if (TransferEligible.Checked && verNumber < 15.0)
                ChangeDBInt("TRAN", "TRYR", count, 1);

        }

        private void RemovePlayerFromTRAN(int PGID)
        {
            for (int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                if (GetDBValueInt("TRAN", "PGID", i) == PGID)
                {
                    DeleteRecord("TRAN", i, true);
                    break;
                }
            }
            CompactDB();
        }

        #endregion


        #region Walk-On Roster Management

        //Check for Walk-On Needs
        private void PostPortalRosterCheck()
        {
            for (int i = 0; i < GetTable2RecCount("WONS"); i++)
            {
                DeleteRecord2("WONS", i, true);
            }
            CompactDB2();


            CollectSpringRoster();

            List<int> depth = new List<int> { 3, 4, 2, 6, 3, 4, 4, 2, 4, 4, 4, 4, 5, 2, 3, 1, 1 };
            StartProgressBar(512);
            for (int tgid = 0; tgid < 512; tgid++)
            {
                if (FindTeamRecfromTGID(tgid) > 0 && GetDBValueInt("TEAM", "TTYP", FindTeamRecfromTGID(tgid)) == 0)
                {

                    for (int p = 0; p < depth.Count; p++)
                    {
                        int posCount = 0;

                        //Create a list of players at the position
                        for (int i = 0; i < SpringRoster[tgid].Count; i++)
                        {
                            if (SpringRoster[tgid][i][3] == p)
                            {
                                posCount++;
                            }
                        }


                        if (posCount < depth[p])
                        {
                            int needs = depth[p] - posCount;
                            int rec = GetTable2RecCount("WONS");
                            AddTable2Record("WONS", false);
                            ChangeDB2Int("WONS", "TGID", rec, tgid);
                            ChangeDB2Int("WONS", "WOND", rec, needs);
                            ChangeDB2Int("WONS", "RGRP", rec, p);
                        }
                    }
                }

                ProgressBarStep();
            }

            EndProgressBar();
        }

        #endregion


        #region Portal News Headlines

        private void AddTransferPlayerNews()
        {
            int i = PortalTransfersList.Count - 1;

            int tgid = PortalTransfersList[i][15];

            List<string> years = CreateClassYearsAbbr();

            int rec = PortalTransfersList[i][0];
            int pgid = PortalTransfersList[i][2];
            int pos = PortalTransfersList[i][3];
            int ov = PortalTransfersList[i][4];
            int team = PortalTransfersList[i][5];
            int starter = PortalTransfersList[i][12];


            int row = portalNews.Count;
            portalNews.Add(new List<string>());
            portalNews[row].Add(GetPOSG2Name(pos));

            string playerStarter = "";
            playerStarter += GetPlayerNamefromRec(rec);
            if (PortalTransfersList[i][12] == 1) playerStarter += " (S)";


            portalNews[row].Add(playerStarter);

            string yr = years[PortalTransfersList[i][6]];
            if (PortalTransfersList[i][10] == 2) yr += " (RS)";

            portalNews[row].Add(yr);
            portalNews[row].Add(Convert.ToString(ConvertRating(ov)));

            if (PortalRatingBoost.Checked)
            {
                int boost = PortalTransfersList[i][7] + (PortalTransfersList[i][6] / 2);
                portalNews[row][3] = Convert.ToString(ConvertRating(boost));
            }

            portalNews[row].Add(teamNameDB[tgid]);

            if (pgid >= 21000 && pgid < 30000)
            {
                portalNews[row].Add(teamNameDB[team] + "*");
            }
            else
            {
                //Denote special player status
                if (pgid >= 30000) //fcs
                    portalNews[row].Add(teamNameDB[team] + "+");
                else if (PortalTransfersList[i][9] == 1) //transfer
                    portalNews[row].Add(teamNameDB[team] + "\n(" + teamNameDB[PortalTransfersList[i][14]] + ")");
                else
                    portalNews[row].Add(teamNameDB[team]);
            }
            portalNews[row].Add(Convert.ToString(PortalTransfersList[i][0]));


            //Live Viewer
            if(SpringPortalLiveView.Checked)
            {
                DisplayPortalNews();
            }
        }

        private void DisplayPortalNews()
        {
            // Display all news items that haven't been shown yet
            int startIndex = PortalData.Rows.Count;

            for (int newsIndex = startIndex; newsIndex < portalNews.Count; newsIndex++)
            {
                PortalData.Rows.Add(new DataGridViewRow());
                int row = PortalData.Rows.Count - 1;

                PortalData.Rows[row].Cells[0].Value = portalNews[newsIndex][0];
                PortalData.Rows[row].Cells[1].Value = portalNews[newsIndex][1];
                PortalData.Rows[row].Cells[2].Value = portalNews[newsIndex][2];
                PortalData.Rows[row].Cells[3].Value = portalNews[newsIndex][3];
                PortalData.Rows[row].Cells[4].Value = portalNews[newsIndex][4];
                PortalData.Rows[row].Cells[5].Value = portalNews[newsIndex][5];
                PortalData.Rows[row].Cells[6].Value = portalNews[newsIndex][6];
                PortalData.Rows[row].Cells[7].Value = newsIndex;
            }


            //Count Starters
            int starterCount = 0;
            for (int r = 0; r < PortalData.Rows.Count; r++)
            {
                string test = PortalData.Rows[r].Cells[1].Value.ToString();
                if (test.Contains("(S)"))
                {
                    starterCount++;
                }
            }

            TotalTransfersCount.Text = "Total Transfers: " + PortalData.Rows.Count;
            if (!AllowStartersLeave.Checked) startersCount.Text = "";
            else startersCount.Text = "Starters: " + Convert.ToString(starterCount);

            // Reattach formatting
            PortalData.CellFormatting -= SpringPortal_CellFormatting;
            PortalData.CellFormatting += SpringPortal_CellFormatting;

            // Scroll to the bottom to show the most recent transfer
            if (PortalData.Rows.Count > 0)
            {
                PortalData.FirstDisplayedScrollingRowIndex = PortalData.Rows.Count - 1;
            }

            // Force UI refresh
            PortalData.Refresh();
            TotalTransfersCount.Refresh();
            startersCount.Refresh();
        }

        #endregion


        #region Hyperlink Helpers

        //HyperLinks
        private void PortalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;

            //Player
            if (cell == 1 && row >= 0)
            {
                int PLAYrec = Convert.ToInt32(PortalData.Rows[row].Cells[6].Value);

                PlayerIndex = PLAYrec;
                tabControl1.SelectedTab = tabPlayers;
                LoadPlayerData();
            }
            //Team
            else if (cell == 4 && row >= 0)
            {
                int teamRec = FindTeamRecfromTeamName(Convert.ToString(PortalData.Rows[row].Cells[4].Value));
                TeamIndex = teamRec;
                tabControl1.SelectedTab = tabTeams;
                GetTeamEditorData(teamRec);
            }
            else if (cell == 5 && row >= 0)
            {
                int teamRec = FindTeamRecfromTeamName(Convert.ToString(PortalData.Rows[row].Cells[5].Value));
                TeamIndex = teamRec;
                tabControl1.SelectedTab = tabTeams;
                GetTeamEditorData(teamRec);
            }
        }

        #endregion


        #region colorization
        private void SpringPortal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Only color non-header cells that display the player string (skip column 0 which shows position)
            if (e.RowIndex < 0 || e.ColumnIndex != 3) return;

            string text = Convert.ToString(e.Value);

            // still empty -> nothing to color
            if (string.IsNullOrEmpty(text)) return;

            int rating = Convert.ToInt32(text);

            Color textColor = GetColorRating(rating);


            // Apply the color to the cell's style so the cell displays colored text when NOT editing
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.BackColor = textColor;

            // If desired, also adjust selection fore color so selection does not hide color
            e.CellStyle.SelectionForeColor = Color.Black;
            e.CellStyle.SelectionBackColor = textColor;

        }

        #endregion    

    }
}


