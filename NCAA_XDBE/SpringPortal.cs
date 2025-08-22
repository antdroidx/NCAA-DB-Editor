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

            RedistributePlayers();
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
                int team = GetDBValueInt("TRAN", "TRYR", t);
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

                if(AllowBackupQBPortal.Checked && p == 0 && rand.Next(0,100) < portalChance.Value)
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
                        if (ov < TeamPortalNeeds[tgid][p] || rand.Next(0, 99) > portalChance.Value)
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

                                    if(PortalRatingBoost.Checked)
                                    {
                                        int boost = SpringPortal[i][7] + (SpringPortal[i][6] / 2);
                                        portalList[row][3] = Convert.ToString(ConvertRating(boost));
                                    }

                                    portalList[row].Add(teamNameDB[tgid]);

                                    if (pgid >= 21000)
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
                                        if(SpringPortal[i][9] == 1)
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
                                    if(SpringPortal[i][9] == 1 || SpringPortal[i][2] >= 21000) RemovePlayerFromTRAN(pgid);

                                    //Add Player to TRAN Table
                                    AddPlayertoTRAN(j, team);


                                    OccupiedPGIDList[tgid].Add(j);
                                    OccupiedPGIDList[pgid / 70].Remove(pgid);
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
            PortalData.ClearSelection();
            for (int x = 0; x < portalList2.Count; x++)
            {
                PortalData.Rows.Add(new DataGridViewRow());

                PortalData.Rows[x].Cells[0].Value = portalList2[x][0];
                PortalData.Rows[x].Cells[1].Value = portalList2[x][1];
                PortalData.Rows[x].Cells[2].Value = portalList2[x][2];
                PortalData.Rows[x].Cells[3].Value = portalList2[x][3];
                PortalData.Rows[x].Cells[4].Value = portalList2[x][4];
                PortalData.Rows[x].Cells[5].Value = portalList2[x][5];

            }

            TotalTransfersCount.Text = "Total Transfers: " + Convert.ToString(portalList2.Count);
        }

        private void AddPlayertoTRAN(int PGID, int TGID)
        {
            int count = GetTableRecCount("TRAN");
            AddTableRecord("TRAN", false);
            ChangeDBInt("TRAN", "PGID", count, PGID);
            ChangeDBInt("TRAN", "PTID", count, TGID);
            ChangeDBInt("TRAN", "TRYR", count, 0);

            if (TransferEligible.Checked && !NextConfigRadio.Checked)
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
    }
}
