using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        //Spring Portal 

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
                TeamPortalNeeds.Add(new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
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
            AvailablePGIDList = new List<List<int>>();
            SpringRoster = new List<List<List<int>>>();


            for (int i = 0; i < 512; i++)
            {
                AvailablePGIDList.Add(new List<int>());
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

                AvailablePGIDList[TGID].Add(PGID);

                int POVR = GetDBValueInt("PLAY", "POVR", i);
                int PPOS = GetDBValueInt("PLAY", "PPOS", i);
                int PYER = GetDBValueInt("PLAY", "PYER", i);

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
                SpringRoster[TGID][count].Add(POVR - (PYER / 2));
                SpringRoster[TGID][count].Add(TGID);


                for (int y = 0; y < GetTable2RecCount("RCTN"); y++)
                {
                    if (GetDB2ValueInt("RCTN", "PGID", y) == PGID)
                    {
                        POVR = GetDB2ValueInt("RCTN", "POVR", i) - (PYER / 2);
                        SpringRoster[TGID][count][4] = POVR;
                        break;
                    }
                }


                progressBar1.PerformStep();
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
                SpringRoster[TGID][count].Add(POVR - (PYER / 2));
                SpringRoster[TGID][count].Add(TGID);

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void DetermineTeamCuts(int tgid)
        {
            List<decimal> depth = new List<decimal> { PortalQB.Value, PortalHB.Value, PortalFB.Value, PortalWR.Value, PortalTE.Value, PortalOT.Value, PortalOG.Value, PortalOC.Value, PortalDE.Value, PortalDT.Value, PortalOLB.Value, PortalCB.Value, PortalFS.Value, PortalSS.Value, PortalK.Value, PortalP.Value };

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
                posList.Sort((player1, player2) => player2[4].CompareTo(player1[4]));


                if (posList.Count > depth[p])
                {
                    for (int x = Convert.ToInt32(depth[p]); x < posList.Count; x++)
                    {
                        if (posList[x][0] != -1 || posList[x][2] >= 21000 && PortalTransfers.Checked)
                        {
                            if (rand.Next(0, 100) < portalChance.Value)
                                SpringPortal.Add(posList[x]);
                        }
                    }

                    if (largePortal.Checked) TeamPortalNeeds[tgid][p] = posList[1][4]; //add last overall rating
                }
                else if (posList.Count <= depth[p])
                {
                    if (posList.Count <= 1 && p != 15 && p != 16 || posList.Count == 0 || depth[p]-posList.Count >= 3) TeamPortalNeeds[tgid][p] = 1;
                    else TeamPortalNeeds[tgid][p] = posList[posList.Count - 1][4]; //add last overall rating
                }
            }
        }


        private void RedistributePlayers()
        {
            if (SpringPortal.Count == 0) return;

            SpringPortal.Sort((player1, player2) => player2[4].CompareTo(player1[4]));

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
                if (AvailablePGIDList[tgid].Count > 0 && AvailablePGIDList[tgid].Count < 70 && SpringPortal.Count > 0)
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
            progressBar1.Maximum = teamList.Count * 17;
            progressBar1.Value = 0;


            for (int p = 0; p < 17; p++)
            {

                if (PortalSnake.Checked)
                {
                    if (round % 2 == 0) teamList.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
                    else teamList.Sort((player1, player2) => player1[1].CompareTo(player2[1]));
                    round++;
                }
                else
                {
                    Random rnd = new Random();
                    teamList = teamList.OrderBy(x => rnd.Next()).ToList();
                }


                for (int t = 0; t < teamList.Count; t++)
                {
                    if (SpringPortal.Count <= 0) break;
                    int tgid = teamList[t][0];
                    portalList = SpringTransfer(tgid, p, portalList);
                    progressBar1.PerformStep();
                }

            }

            DisplayPortalNews(portalList);

            progressBar1.Visible = false;
            progressBar1.Value = 0;

        }

        private List<List<string>> SpringTransfer(int tgid, int p, List<List<string>> portalList)
        {

            //Check for team needs
            if (TeamPortalNeeds[tgid][p] > 0)
            {
                bool need = true;
                for (int i = 0; i < SpringPortal.Count; i++)
                {
                    int rec = SpringPortal[i][0];
                    int pgid = SpringPortal[i][2];
                    int pos = SpringPortal[i][3];
                    int ov = SpringPortal[i][4];
                    int team = SpringPortal[i][5];

                    if (pos == p)
                    {
                        if (ov < TeamPortalNeeds[tgid][p])
                        {
                            break;
                        }
                        else
                        {
                            //Check for open PGID slots
                            for (int j = tgid * 70; j <= tgid * 70 + 69; j++)
                            {
                                if (!AvailablePGIDList[tgid].Contains(j))
                                {

                                    int row = portalList.Count;
                                    portalList.Add(new List<string>());
                                    portalList[row].Add(GetPOSG2Name(pos));
                                    portalList[row].Add(GetPlayerNamefromPGID(pgid));
                                    portalList[row].Add(Convert.ToString(ConvertRating(ov)));
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
                                        portalList[row].Add(teamNameDB[team]);

                                        ChangeDBInt("PLAY", "PGID", rec, j);

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

                                    TeamPortalNeeds[tgid][p] = 0;

                                    SpringPortal.RemoveAt(i);
                                    i--;
                                    need = false;
                                    AvailablePGIDList[tgid].Add(j);

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

            }

            TotalTransfersCount.Text = "Total Tranfers: " + Convert.ToString(portalList2.Count);
        }




    }

}
