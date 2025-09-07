using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        //Spring Portal 

        private void StartSpringPortal()
        {
            if (NextConfigRadio.Checked)
            {
                TransferEligible.Enabled = false;
            }
            else
            {
                TransferEligible.Enabled = true;
            }
        }

        private void SpringPortalButton_Click(object sender, EventArgs e)
        {
            bool correctWeek = false;
            for (int i = 0; i < GetTable2RecCount("RCYR"); i++)
            {
                if (GetDB2ValueInt("RCYR", "SEWN", i) >= 6)
                {
                    correctWeek = true;
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

        private void RunSpringPortal()
        {
            PortalData.ClearSelection();
            TotalTransfersCount.Text = "Total Transfers: 0";

            for (int x = 0; x < PortalCycleCount.Value; x++)
            {
                {
                    SpringPortal = new List<List<int>>();
                    TeamPortalNeeds = new List<List<int>>();

                    for (int t = 0; t < 511; t++)
                    {
                        TeamPortalNeeds.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                                      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                    }


                    CollectSpringRoster();

                    progressBar1.Visible = true;
                    progressBar1.Maximum = GetTableRecCount("TEAM");
                    progressBar1.Value = 0;

                    for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                    {
                        if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                        {
                            int tgid = GetDBValueInt("TEAM", "TGID", i);
                            DetermineTeamCuts(tgid);
                        }
                        progressBar1.PerformStep();
                    }

                    progressBar1.Visible = false;
                    progressBar1.Value = 0;

                    if(FCSTransferPortalCheckBox.Checked) CreateFCSPlayers();

                    RedistributePlayers();
                }
            }

            //Remove unused FCS players
            for(int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                int pgid = GetDBValueInt("PLAY", "PGID", i);
                if(pgid >= 30000)
                {
                    DeleteRecord("PLAY", i, true);
                }
            }

            for(int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                int pgid = GetDBValueInt("TRAN", "PGID", i);
                if (pgid >= 30000)
                {
                    DeleteRecord("TRAN", i, true);
                }
            }

            CompactDB();

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

            progressBar1.Visible = true;
            progressBar1.Maximum = GetTableRecCount("PLAY");
            progressBar1.Value = 0;

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

                if (PortalRatingBoost.Checked)
                    SpringRoster[TGID][count][7] = POVR - (SpringRoster[TGID][count][6] / 2);
                else
                    SpringRoster[TGID][count][7] = POVR;

                progressBar1.PerformStep();
            }

            //Check for Transfers in TRAN
            for (int t = 0; t < GetTableRecCount("TRAN"); t++)
            {
                int pgid = GetDBValueInt("TRAN", "PGID", t);
                int tgid = pgid / 70;
                for (int i = 0; i < SpringRoster[tgid].Count; i++)
                {
                    if (SpringRoster[tgid][i][2] == pgid)
                    {
                        SpringRoster[tgid][i][9] = 1;
                        break;
                    }
                }
            }



            progressBar1.Value = 0;
            progressBar1.Maximum = GetTable2RecCount("RCPR");

            //Add Recruits
            for (int i = 0; i < GetTable2RecCount("RCPR"); i++)
            {
                int TGID = GetDB2ValueInt("RCPR", "PTCM", i);
                int PRID = GetDB2ValueInt("RCPR", "PRID", i);
                int POVR = GetDB2ValueInt("RCPT", "POVR", i);
                int PPOS = GetDB2ValueInt("RCPT", "PPOS", i);
                int PYER = GetDBValueInt("RCPT", "PYER", i);

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


                SpringRoster[TGID][count][4] = POVR;
                if (PortalRatingBoost.Checked)
                    SpringRoster[TGID][count][7] = POVR - (SpringRoster[TGID][count][6] / 2);
                else
                    SpringRoster[TGID][count][7] = POVR;

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void DetermineTeamCuts(int tgid)
        {
            List<decimal> depth = new List<decimal> { PortalQB.Value, PortalHB.Value, PortalFB.Value, PortalWR.Value, PortalTE.Value, PortalOT.Value, PortalOG.Value, PortalOC.Value, PortalDE.Value, PortalDT.Value, PortalOLB.Value, PortalMLB.Value, PortalCB.Value, PortalFS.Value, PortalSS.Value, PortalK.Value, PortalP.Value };

            for (int p = 0; p < depth.Count; p++)
            {
                List<List<int>> posList = new List<List<int>>();

                //Create a list of players at the position
                for (int i = 0; i < SpringRoster[tgid].Count; i++)
                {
                    if (SpringRoster[tgid][i][3] == p)
                    {
                        posList.Add(SpringRoster[tgid][i]);
                    }
                }

                //Sort by OVR
                posList.Sort((player1, player2) => player2[7].CompareTo(player1[7]));

                //Adds to all scenarios
                if (posList.Count > 0) TeamPortalNeeds[tgid][p * 2] = posList[0][4]; //add starter rating (looks for starters)

                //team has enough players
                if (posList.Count > depth[p])
                {
                    //add players to the portal
                    for (int x = Convert.ToInt32(depth[p]); x < posList.Count; x++)
                    {
                        if (posList[x][0] != -1 && posList[x][9] == 0 || posList[x][2] >= 21000 && PortalTransfers.Checked || posList[x][9] == 1 && PortalTransfers.Checked)
                        {
                            if (rand.Next(0, 100) < portalChance.Value)
                                SpringPortal.Add(posList[x]);
                        }
                    }
                    //allow team to add a player if its large portal & available player is better than 2nd best
                    if (largePortal.Checked && posList.Count > 1) TeamPortalNeeds[tgid][p * 2 + 1] = posList[1][4];
                }

                //team does not have enough players
                else if (posList.Count <= depth[p])
                {
                    if (posList.Count <= 1 && p != 15 && p != 16 && p != 2 || posList.Count == 0 || depth[p] - posList.Count >= 3)
                    {
                        //allow team to add player to fill depth gaps
                        TeamPortalNeeds[tgid][p * 2 + 1] = 1;
                    }
                    else
                    {
                        //allow team to add player that is better than the worst player at the depth position
                        TeamPortalNeeds[tgid][p * 2 + 1] = posList[posList.Count - 1][4];
                    }
                }

                if (AllowBackupQBPortal.Checked && p == 0 && rand.Next(0, 100) < portalChance.Value && posList.Count > 1)
                {
                    // If the team has a backup QB, allow them to add a player to the portal
                    if (posList[1][0] != -1 && posList[1][9] == 0 || posList[1][2] >= 21000 && PortalTransfers.Checked || posList[1][9] == 1 && PortalTransfers.Checked)
                    {
                        SpringPortal.Add(posList[1]);
                        TeamPortalNeeds[tgid][p * 2 + 1] = 0;
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
            if(newPlayers > maxFCSPlayers) newPlayers = maxFCSPlayers; //limit to XX players max

            for (int i = 0; i < newPlayers; i++)
            {
                int rec = GetTableRecCount("PLAY");
                AddTableRecord("PLAY", false);

                List<int> AvailablePJEN = new List<int>();

                int PGID = 30000 + rec;
                TransferRCATtoPLAY(rec, rand.Next(0, 17), PGID, RCATmapper, PJEN, AvailablePJEN, 0);
                RandomizeAttribute("PLAY", rec, 1);
                RecalculateOverallByRec(rec);

                //Add to TRAN
                int TGID = fcsTeams[rand.Next(0, fcsTeams.Count)];
                AddPlayertoTRAN(PGID, TGID);

                //Add To Portal
                int POVR = GetDBValueInt("PLAY", "POVR", rec);
                int PPOS = GetDBValueInt("PLAY", "PPOS", rec);
                int PYER = GetDBValueInt("PLAY", "PYER", rec);


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

                if (ConvertRating(POVR) >= 65)
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
            if (SpringPortal.Count == 0) return;

            SpringPortal.Sort((player1, player2) => player2[7].CompareTo(player1[7]));

            List<List<int>> teamList = new List<List<int>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int tgid = GetDBValueInt("TEAM", "TGID", i);
                    int rank = GetDBValueInt("TEAM", "TMRK", i);
                    teamList.Add(new List<int> { tgid, rank });
                }
            }

            if (PortalFirst.Checked)
            {
                teamList.Sort((player1, player2) => player1[1].CompareTo(player2[1]));
                SpringPortalNormalDistribution(teamList);
            }
            else if (PortalReverse.Checked)
            {
                teamList.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
                SpringPortalNormalDistribution(teamList);
            }
            else
            {
                Random rnd = new Random();
                teamList = teamList.OrderBy(x => rnd.Next()).ToList();
                SpringPortalRandomDistribution(teamList);
            }
        }


        private void SpringPortalNormalDistribution(List<List<int>> teamList)
        {
            List<List<string>> portalList = new List<List<string>>();


            progressBar1.Visible = true;
            progressBar1.Maximum = teamList.Count;
            progressBar1.Value = 0;

            for (int t = 0; t < teamList.Count; t++)
            {
                if (SpringPortal.Count <= 0) break;
                int tgid = teamList[t][0];

                //Check for team needs
                if (OccupiedPGIDList[tgid].Count > 0 && OccupiedPGIDList[tgid].Count < 70 && SpringPortal.Count > 0)
                {
                    for (int p = 0; p < TeamPortalNeeds[tgid].Count; p++)
                    {
                        portalList = SpringTransfer(tgid, p, portalList);
                    }
                }
                progressBar1.PerformStep();
            }


            DisplayPortalNews(portalList);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

        }

        private void SpringPortalRandomDistribution(List<List<int>> teamList)
        {
            List<List<string>> portalList = new List<List<string>>();

            int round = 0;

            progressBar1.Visible = true;
            progressBar1.Maximum = teamList.Count * 34;
            progressBar1.Value = 0;

            List<int> randPos = new List<int>();
            for (int p = 0; p < 34; p++)
            {
                randPos.Add(p);
            }

            Random rnd = new Random();
            randPos = randPos.OrderBy(x => rnd.Next()).ToList();

            for (int p = 0; p < randPos.Count; p++)
            {

                if (PortalSnake.Checked)
                {
                    if (round % 2 == 0) teamList.Sort((team1, team2) => team2[1].CompareTo(team1[1]));
                    else teamList.Sort((team1, team2) => team1[1].CompareTo(team2[1]));
                    round++;
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
                    portalList = SpringTransfer(tgid, randPos[p], portalList);
                    progressBar1.PerformStep();
                }

            }

            DisplayPortalNews(portalList);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

        }

        private List<List<string>> SpringTransfer(int tgid, int p, List<List<string>> portalList)
        {
            List<string> years = CreateClassYearsAbbr();

            //Check for team needs
            if (TeamPortalNeeds[tgid][p] > 0)
            {
                bool need = true;
                for (int i = 0; i < SpringPortal.Count; i++)
                {
                    int rec = SpringPortal[i][0];
                    int pgid = SpringPortal[i][2];
                    int pos = SpringPortal[i][3];
                    int ov = SpringPortal[i][7];
                    int team = SpringPortal[i][5];

                    if (pos == p / 2)
                    {
                        if (ov <= TeamPortalNeeds[tgid][p] || rand.Next(0, 99) > portalChance.Value)
                        {
                            break;
                        }
                        else
                        {
                            //Check for open PGID slots
                            for (int j = tgid * 70; j <= tgid * 70 + 69; j++)
                            {
                                if (!OccupiedPGIDList[tgid].Contains(j))
                                {

                                    int row = portalList.Count;
                                    portalList.Add(new List<string>());
                                    portalList[row].Add(GetPOSG2Name(pos));
                                    portalList[row].Add(GetPlayerNamefromPGID(pgid));

                                    string yr = years[SpringPortal[i][6]];
                                    if (SpringPortal[i][10] == 2) yr += " (RS)";

                                    portalList[row].Add(yr);
                                    portalList[row].Add(Convert.ToString(ConvertRating(ov)));

                                    if (PortalRatingBoost.Checked)
                                    {
                                        int boost = SpringPortal[i][7] + (SpringPortal[i][6] / 2);
                                        portalList[row][3] = Convert.ToString(ConvertRating(boost));
                                    }

                                    portalList[row].Add(teamNameDB[tgid]);

                                    if (pgid >= 21000 && pgid < 30000)
                                    {
                                        portalList[row].Add(teamNameDB[team] + "*");

                                        //Update their commitment to the new team
                                        for (int y = 0; y < GetTable2RecCount("RCPR"); y++)
                                        {
                                            if (GetDB2ValueInt("RCPR", "PRID", y) == pgid)
                                            {
                                                ChangeDB2Int("RCPR", "PTCM", y, tgid);
                                                ChangeDB2Int("RCPR", "PT01", y, tgid);
                                                break;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        if (pgid >= 30000)
                                            portalList[row].Add(teamNameDB[team] + "+");
                                        else if (SpringPortal[i][9] == 1)
                                            portalList[row].Add(teamNameDB[team] + "*");
                                        else
                                            portalList[row].Add(teamNameDB[team]);

                                        ChangeDBInt("PLAY", "PGID", rec, j);


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
                                            if (GetDB2ValueInt("RCTN", "PGID", y) == tgid)
                                            {
                                                ChangeDB2Int("RCTN", "PGID", y, j);
                                                break;
                                            }
                                        }

                                        // Change Player Stats ID
                                        ChangePlayerStatsID(SpringPortal[i][2], j);
                                    }

                                    if (p % 2 == 1 && TeamPortalNeeds[tgid][p] == 1 && smallPortal.Checked)
                                        TeamPortalNeeds[tgid][p - 1] = 0;

                                    else if (p % 2 == 0 && TeamPortalNeeds[tgid][p + 1] == 1 && smallPortal.Checked)
                                        TeamPortalNeeds[tgid][p + 1] = 0;

                                    TeamPortalNeeds[tgid][p] = 0;

                                    //Remove Player from TRAN table (if needed)
                                    if (SpringPortal[i][9] == 1 || SpringPortal[i][2] >= 21000) RemovePlayerFromTRAN(pgid);

                                    //Add Player to TRAN Table
                                    AddPlayertoTRAN(j, team);


                                    OccupiedPGIDList[tgid].Add(j);
                                    if (pgid / 70 < 512) OccupiedPGIDList[pgid / 70].Remove(pgid);
                                    SpringPortal.RemoveAt(i);
                                    i--;
                                    need = false;


                                    break;
                                }
                            }
                        }
                    }

                    if (need == false) break;
                }
            }


            return portalList;
        }

        private void DisplayPortalNews(List<List<string>> portalList2)
        {
            int NewsCount = PortalData.Rows.Count;
            for (int x = NewsCount; x < portalList2.Count + NewsCount; x++)
            {
                PortalData.Rows.Add(new DataGridViewRow());

                PortalData.Rows[x].Cells[0].Value = portalList2[x - NewsCount][0];
                PortalData.Rows[x].Cells[1].Value = portalList2[x - NewsCount][1];
                PortalData.Rows[x].Cells[2].Value = portalList2[x - NewsCount][2];
                PortalData.Rows[x].Cells[3].Value = portalList2[x - NewsCount][3];
                PortalData.Rows[x].Cells[4].Value = portalList2[x - NewsCount][4];
                PortalData.Rows[x].Cells[5].Value = portalList2[x - NewsCount][5];

            }

            int prevTransfersCount = TotalTransfersCount.Text.Contains(":") ? Convert.ToInt32(TotalTransfersCount.Text.Split(':')[1].Trim()) : 0;

            TotalTransfersCount.Text = "Total Transfers: " + Convert.ToString(portalList2.Count + prevTransfersCount);

        }

        private void AddPlayertoTRAN(int PGID, int TGID)
        {
            int count = GetTableRecCount("TRAN");
            AddTableRecord("TRAN", false);
            ChangeDBInt("TRAN", "PGID", count, PGID);
            ChangeDBInt("TRAN", "PTID", count, TGID);
            ChangeDBInt("TRAN", "TRYR", count, 0);

            if (TransferEligible.Checked && !NextMod && !Next26Mod)
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


        /* These are not used anymore */
        #region Creating/Randomizing Recruits

        //Transfers RCAT to RCPT field
        private void TransferRCATtoRCPT(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN)
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

                        ChangeDB2String("RCPT", field, rec, Convert.ToString(RCAT[r][RCATcol]));
                    }

                    int redshirt = 0;
                    if (rand.Next(0, 3) > 2) redshirt = 2;


                    int ht = PickRandomHometown();

                    ChangeDB2Int("RCPT", "RCHD", rec, ht); //hometown
                    ChangeDB2Int("RCPT", "PRID", rec, PGID); //RCPTer id
                    ChangeDB2Int("RCPT", "PHPD", rec, 0); //PHPD
                    ChangeDB2Int("RCPT", "PRSD", rec, redshirt); //Redshirt
                    ChangeDB2Int("RCPT", "PLMG", rec, 0); //Mouthguard
                    ChangeDB2Int("RCPT", "PFGM", rec, 0); //face shape (to be calculated later)
                    ChangeDB2Int("RCPT", "PJEN", rec, ChooseJerseyNumber(ppos, PJEN)); //jersey num
                    ChangeDB2Int("RCPT", "PTEN", rec, 15); //tendency (to be calculated later)
                    ChangeDB2Int("RCPT", "PFMP", rec, 0); //face (to be calculated later)
                    ChangeDB2Int("RCPT", "PIMP", rec, rand.Next(0, maxRatingVal)); //importance (to be re-calculated later)
                    ChangeDB2Int("RCPT", "POVR", rec, 0); //overall, to be calculated later
                    ChangeDB2Int("RCPT", "PSLY", rec, 0); //PSLY
                    ChangeDB2Int("RCPT", "PRST", rec, 0); //PRST
                    ChangeDB2Int("RCPT", "PYER", rec, rand.Next(1, 4)); //year/class
                    ChangeDB2Int("RCPT", "PTYP", rec, 0); //player type (graduation/nfl,etc)

                    string FN, LN;

                    FN = FirstNames[rand.Next(0, FirstNames.Count)];
                    LN = LastNames[rand.Next(0, LastNames.Count)];

                    ChangeDB2String("RCPT", "PFNA", rec, FN); //first name
                    ChangeDB2String("RCPT", "PLNA", rec, LN); //last name

                    x = false;
                }
            }
        }


        //Randomize the Players to give a little bit more variety and evaluation randomness
        private void RandomizeRCPTAttribute(string TableName, int rec, int teamRating)
        {
            int tolEXP = rand.Next(3, 8);

            int tolRAND = 3;  //half the tolerance for specific attributes

            teamRating = (int)((teamRating - 3) * 4);

            //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
            //PPOE, PINJ, PAWR

            int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PIMP, PDIS;

            PHGT = GetDB2ValueInt(TableName, "PHGT", rec);
            PWGT = GetDB2ValueInt(TableName, "PWGT", rec);
            PAWR = GetDB2ValueInt(TableName, "PAWR", rec);

            PTHA = GetDB2ValueInt(TableName, "PTHA", rec);
            PSTA = GetDB2ValueInt(TableName, "PSTA", rec);
            PKAC = GetDB2ValueInt(TableName, "PKAC", rec);
            PACC = GetDB2ValueInt(TableName, "PACC", rec);
            PSPD = GetDB2ValueInt(TableName, "PSPD", rec);
            PCTH = GetDB2ValueInt(TableName, "PCTH", rec);
            PAGI = GetDB2ValueInt(TableName, "PAGI", rec);
            PTAK = GetDB2ValueInt(TableName, "PTAK", rec);
            PPBK = GetDB2ValueInt(TableName, "PPBK", rec);
            PRBK = GetDB2ValueInt(TableName, "PRBK", rec);
            PBTK = GetDB2ValueInt(TableName, "PBTK", rec);
            PTHP = GetDB2ValueInt(TableName, "PTHP", rec);
            PJMP = GetDB2ValueInt(TableName, "PJMP", rec);
            PCAR = GetDB2ValueInt(TableName, "PCAR", rec);
            PKPR = GetDB2ValueInt(TableName, "PKPR", rec);
            PSTR = GetDB2ValueInt(TableName, "PSTR", rec);
            PDIS = GetDB2ValueInt(TableName, "PDIS", rec);

            PBRE = rand.Next(0, 2);
            PEYE = rand.Next(0, 2);
            PHGT += rand.Next(0, 0);
            PWGT += rand.Next(-8, 9);
            if (PWGT < 0) PWGT = 0;
            if (PWGT > 340) PWGT = 340;
            if (PHGT > 82) PHGT = 82;
            if (PHGT < 0) PHGT = 0;

            PPOE = rand.Next(1, 31);
            PINJ = rand.Next(1, maxRatingVal);
            PIMP = rand.Next(1, maxRatingVal);
            PDIS = rand.Next(2, 7);


            //Add team rating factor
            PAWR = GetRandomPositiveAttribute(PAWR, teamRating);
            PSTA = GetRandomPositiveAttribute(PSTA, teamRating);
            PKAC = GetRandomPositiveAttribute(PKAC, teamRating);
            PACC = GetRandomPositiveAttribute(PACC, teamRating);
            PSPD = GetRandomPositiveAttribute(PSPD, teamRating);
            PCTH = GetRandomPositiveAttribute(PCTH, teamRating);
            PAGI = GetRandomPositiveAttribute(PAGI, teamRating);
            PTAK = GetRandomPositiveAttribute(PTAK, teamRating);
            PPBK = GetRandomPositiveAttribute(PPBK, teamRating);
            PRBK = GetRandomPositiveAttribute(PRBK, teamRating);
            PBTK = GetRandomPositiveAttribute(PBTK, teamRating);

            PJMP = GetRandomPositiveAttribute(PJMP, teamRating);
            PCAR = GetRandomPositiveAttribute(PCAR, teamRating);
            PKPR = GetRandomPositiveAttribute(PKPR, teamRating);
            PSTR = GetRandomPositiveAttribute(PSTR, teamRating);

            if (GetDBValueInt(TableName, "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, teamRating);
                PTHP = GetRandomPositiveAttribute(PTHP, teamRating);
            }


            //Randomizer
            PAWR = GetRandomAttribute(PAWR, tolRAND);
            PSTA = GetRandomAttribute(PSTA, tolRAND);
            PKAC = GetRandomAttribute(PKAC, tolRAND);
            PACC = GetRandomAttribute(PACC, tolRAND);
            PSPD = GetRandomAttribute(PSPD, tolRAND);
            PCTH = GetRandomAttribute(PCTH, tolRAND);
            PAGI = GetRandomAttribute(PAGI, tolRAND);
            PTAK = GetRandomAttribute(PTAK, tolRAND);
            PPBK = GetRandomAttribute(PPBK, tolRAND);
            PRBK = GetRandomAttribute(PRBK, tolRAND);
            PBTK = GetRandomAttribute(PBTK, tolRAND);

            PJMP = GetRandomAttribute(PJMP, tolRAND);
            PCAR = GetRandomAttribute(PCAR, tolRAND);
            PKPR = GetRandomAttribute(PKPR, tolRAND);
            PSTR = GetRandomAttribute(PSTR, tolRAND);


            //Add Year Experience
            PAWR = GetRandomPositiveAttribute(PAWR, tolEXP);
            PSTA = GetRandomPositiveAttribute(PSTA, tolEXP);
            PKAC = GetRandomPositiveAttribute(PKAC, tolEXP);
            PACC = GetRandomPositiveAttribute(PACC, tolEXP);
            PSPD = GetRandomPositiveAttribute(PSPD, tolEXP);
            PCTH = GetRandomPositiveAttribute(PCTH, tolEXP);
            PAGI = GetRandomPositiveAttribute(PAGI, tolEXP);
            PTAK = GetRandomPositiveAttribute(PTAK, tolEXP);
            PPBK = GetRandomPositiveAttribute(PPBK, tolEXP);
            PRBK = GetRandomPositiveAttribute(PRBK, tolEXP);
            PBTK = GetRandomPositiveAttribute(PBTK, tolEXP);

            PJMP = GetRandomPositiveAttribute(PJMP, tolEXP);
            PCAR = GetRandomPositiveAttribute(PCAR, tolEXP);
            PKPR = GetRandomPositiveAttribute(PKPR, tolEXP);
            PSTR = GetRandomPositiveAttribute(PSTR, tolEXP);

            if (GetDB2ValueInt(TableName, "PPOS", rec) == 0)
            {
                PTHA = GetRandomPositiveAttribute(PTHA, tolEXP);
                PTHP = GetRandomPositiveAttribute(PTHP, tolEXP);
            }


            ChangeDB2Int(TableName, "PBRE", rec, PBRE);
            ChangeDB2Int(TableName, "PEYE", rec, PEYE);
            ChangeDB2Int(TableName, "PPOE", rec, PPOE);
            ChangeDB2Int(TableName, "PINJ", rec, PINJ);
            ChangeDB2Int(TableName, "PAWR", rec, PAWR);
            ChangeDB2Int(TableName, "PHGT", rec, PHGT);
            ChangeDB2Int(TableName, "PWGT", rec, PWGT);


            ChangeDB2Int(TableName, "PTHA", rec, PTHA);
            ChangeDB2Int(TableName, "PSTA", rec, PSTA);
            ChangeDB2Int(TableName, "PKAC", rec, PKAC);
            ChangeDB2Int(TableName, "PACC", rec, PACC);
            ChangeDB2Int(TableName, "PSPD", rec, PSPD);
            ChangeDB2Int(TableName, "PCTH", rec, PCTH);
            ChangeDB2Int(TableName, "PAGI", rec, PAGI);
            ChangeDB2Int(TableName, "PTAK", rec, PTAK);
            ChangeDB2Int(TableName, "PPBK", rec, PPBK);
            ChangeDB2Int(TableName, "PRBK", rec, PRBK);
            ChangeDB2Int(TableName, "PBTK", rec, PBTK);
            ChangeDB2Int(TableName, "PTHP", rec, PTHP);
            ChangeDB2Int(TableName, "PJMP", rec, PJMP);
            ChangeDB2Int(TableName, "PCAR", rec, PCAR);
            ChangeDB2Int(TableName, "PKPR", rec, PKPR);
            ChangeDB2Int(TableName, "PSTR", rec, PSTR);
            ChangeDB2Int(TableName, "PIMP", rec, PIMP);
            ChangeDB2Int(TableName, "PDIS", rec, PDIS);


            //Randomizes Face Shape (PGFM)
            int shape = rand.Next(0, 16);
            ChangeDB2Int(TableName, "PFGM", rec, shape);

            //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)

            int skin = GetDBValueInt(TableName, "PSKI", rec);

            if (skin <= 2) skin = rand.Next(0, 3);
            else if (skin <= 6) skin = rand.Next(3, 7);
            else skin = 7;


            ChangeDB2Int(TableName, "PSKI", rec, skin);

            //Randomizes Face Type based on new Skin Type
            int face = GetDB2ValueInt(TableName, "PSKI", rec) * 8 + rand.Next(0, 8);
            ChangeDB2Int(TableName, "PFMP", rec, face);

            //Randomize Hair Color
            int hcl = 0;
            if (skin < 3 || skin == 7)
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
            ChangeDB2Int(TableName, "PHCL", rec, hcl);

            //Randomize Hair Style
            int hairstyle = 5;

            if (skin < 3 || skin == 7)
            {

                if (rand.Next(1, 101) <= 50)
                    hairstyle = rand.Next(2, 8);
                else
                    hairstyle = rand.Next(9, 14);

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
                        hairstyle = rand.Next(9, 15);
                }
            }


            ChangeDB2Int(TableName, "PHED", rec, hairstyle);

            CalculateRecruitOverall(rec);
        }

        #endregion
    }
}
