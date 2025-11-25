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


        private void CFUSAexportButton_Click(object sender, EventArgs e)
        {
            ExportToCollegeFootballUSA();
        }

        #region College Football USA 97 Mod
        //Export to College Football USA 
        private void ExportToCollegeFootballUSA()
        {

            //Setup Progress bar
            StartProgressBar(GetTableRecCount("TDYN"));

            List<List<int>> roster = new List<List<int>>();
            List<List<string>> cfbusa97 = CreateStringListsFromCSV(@"resources\college-football-usa.csv", false);

            Stream myStream = File.Create("CollegeFB-USA-export.csv");
            StreamWriter wText = new StreamWriter(myStream);
            //StringBuilder hbuilder = new StringBuilder();

            //write headers
            wText.WriteLine("Team,Position,Full Name,Overall Rating,Jersey Number,Awareness,Speed,Quickness,Power,Catching,Blocking,Tackling,Throw Power,Throw Accuracy,Kick Power,Kick Accuracy,Weight");

            //Get Roster Lists
            for (int i = 0; i < GetTableRecCount("TDYN"); i++)
            {
                int TOID = GetDBValueInt("TDYN", "TOID", i);

                if (TDYN && TOID <= 115)
                {
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    int row = 0;
                    roster.Clear();

                    for (int j = 0; j < GetTableRecCount("PLAY"); j++)
                    {
                        int PGID = GetDBValueInt("PLAY", "PGID", j);

                        if (PGID >= PGIDbeg && PGID <= PGIDend)
                        {
                            int POVR = GetDBValueInt("PLAY", "POVR", j);
                            int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                            List<int> player = new List<int>();
                            roster.Add(player);
                            roster[row].Add(ConvertRating(POVR));
                            roster[row].Add(PPOS);
                            roster[row].Add(j);
                            row++;
                        }
                    }

                    roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));



                    /*                  QB	2
                                        HB	3
                                        FB	2
                                        WR	4
                                        TE	3
                                        LT	2
                                        LG	2
                                        C	2
                                        RG	2
                                        RT	2
                                        LDE	1
                                        RDE	1
                                        LDT	1
                                        RDT	1
                                        NT	1
                                        LOLB	1
                                        LILB	1
                                        RILB	1
                                        ROLB	1
                                        RCB	2
                                        LCB	2
                                        FS	2
                                        SS	2
                                        K	1
                                        P	1
                    */

                    int count = 0;

                    //QBs x 2
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;
                    }


                    //HBs x 2
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 1 && count % 2 == 0 || roster[j][1] == 2 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",HB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 1 && count % 2 != 0 || roster[j][1] == 2 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",FB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 5) break;
                    }


                    //WR
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 3)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 4) break;
                    }



                    //TE
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 4)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 3) break;
                    }


                    //OT
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 5 && count % 2 == 0 || roster[j][1] == 9 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",LT," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 5 && count % 2 != 0 || roster[j][1] == 9 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",RT," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 3) break;
                    }



                    //OG
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 6 && count % 2 == 0 || roster[j][1] == 8 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",LG," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 6 && count % 2 != 0 || roster[j][1] == 8 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",RG," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 3) break;
                    }



                    //C
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 7)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",C," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;
                    }


                    //EDGE
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 10 && count % 2 == 0 || roster[j][1] == 11 && count == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",LE," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 10 && count == 1 || roster[j][1] == 11 && count == 1)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",RE," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 10 && count == 3 || roster[j][1] == 11 && count == 3)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",LE," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 10 && count == 4 || roster[j][1] == 11 && count == 4)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",RE," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 4) break;
                    }



                    //DT
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 12 && count == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",DT," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 12 && count == 1)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",DT," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;
                    }




                    //OLB
                    count = 0;


                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 13 && count % 2 == 0 || roster[j][1] == 15 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",LOLB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 13 && count % 2 != 0 || roster[j][1] == 15 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",ROLB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 3) break;
                    }



                    //ILB
                    count = 0;


                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 14 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",MLB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 14 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",MLB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;
                    }



                    //CB
                    count = 0;


                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 16 && count % 2 == 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",CB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        else if (roster[j][1] == 16 && count % 2 != 0)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + ",CB," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 4) break;
                    }



                    //SS
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 17)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;
                    }


                    //FS
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 18)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            count++;
                        }
                        if (count >= 2) break;

                    }


                    //K

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 19)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            break;
                        }

                    }


                    //P
                    count = 0;

                    for (int j = 0; j < roster.Count; j++)
                    {
                        if (roster[j][1] == 20)
                        {
                            wText.WriteLine(GetTeamNameCFBUSA(TOID, cfbusa97) + "," + Positions[roster[j][1]] + "," + GetPlayerInfoCFBUSA(roster[j][2]));
                            break;
                        }

                    }


                }
                ProgressBarStep();
            }
            MessageBox.Show("Complete");
            wText.Dispose();
            wText.Close();

            EndProgressBar();
        }

        private string GetTeamNameCFBUSA(int TOID, List<List<string>> cfbusa97)
        {
            for(int i = 0; i < cfbusa97.Count; i++)
            {
                if (cfbusa97[i][0] == Convert.ToString(TOID)) return cfbusa97[i][1];
            }
            return "";
        }

        private string GetPlayerInfoCFBUSA(int rec)
        {
            return GetFirstNameFromRecord(rec) + " " + GetLastNameFromRecord(rec) + "," + ConvertRating(GetDBValueInt("PLAY", "POVR", rec)) + "," + GetDBValue("PLAY", "PJEN", rec) + "," + ConvertRating(GetDBValueInt("PLAY", "PAWR", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PSPD", rec)) + ","
                + ConvertRating(GetDBValueInt("PLAY", "PAGI", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PSTR", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PCTH", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PPBK", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PTAK", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PTHP", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PTHA", rec)) + ","
                + ConvertRating(GetDBValueInt("PLAY", "PKPR", rec)) + "," + ConvertRating(GetDBValueInt("PLAY", "PKAC", rec)) + "," + (GetDBValueInt("PLAY", "PWGT", rec) + 160);
        }
        #endregion

    }

}
