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
        private void StartStatsViewer()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = 6;

            LoadTop25Rankings();
            progressBar1.PerformStep();

            LoadTeamRatingsRankings();
            progressBar1.PerformStep();

            int sewn = GetDBValueInt("SEAI", "SEWN", 0);

            if (sewn > 0)
            {
                LoadTeamOffenseRankings();
                progressBar1.PerformStep();

                LoadTeamDefenseRankings();
                progressBar1.PerformStep();

                LoadPlayerOffStatLeaders();
                progressBar1.PerformStep();

                LoadPlayerDefStatLeaders();
                progressBar1.PerformStep();
            }


            progressBar1.Visible = false;
        }

        private void LoadTop25Rankings()
        {
            CoachPollListBox.Items.Clear();

            List<List<int>> rankings = new List<List<int>>();
            int num = 0;


            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int rank = GetDBValueInt("TEAM", "TCRK", i);
                if(rank < 26)
                {
                    rankings.Add(new List<int>());
                    rankings[num].Add(i);
                    rankings[num].Add(rank);
                    num++;
                    if (num > 25) break;
                }
            }

            rankings.Sort((player1, player2) => player1[1].CompareTo(player2[1]));

            foreach (List<int> team in rankings)
            {
                CoachPollListBox.Items.Add("#" + team[1] + " " + GetDBValue("TEAM", "TDNA", team[0]));
            }
        }

        private void LoadTeamRatingsRankings()
        {
            TopTeamRatingsBox.Items.Clear();

            List<List<int>> rankings = new List<List<int>>();
            int num = 0;

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                int rank = GetDBValueInt("TEAM", "TROV", i);
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    rankings.Add(new List<int>());
                    rankings[num].Add(i);
                    rankings[num].Add(rank);
                    num++;
                }
            }

            rankings.Sort((player1, player2) => player2[1].CompareTo(player1[1]));
            int r = 1;
            foreach (List<int> team in rankings)
            {
                TopTeamRatingsBox.Items.Add("#" + r + " " + GetDBValue("TEAM", "TDNA", team[0]) + " [" + team[1] + "]");
                r++;
            }
        }

        private void LoadTeamOffenseRankings()
        {
            TopTeamOffBox.Items.Clear();

            List<List<string>> rankings = new List<List<string>>();
            int num = 0;

            for (int i = 0; i < GetTableRecCount("TSSE"); i++)
            {
                string teamName = teamNameDB[GetDBValueInt("TSSE", "TGID", i)];
                int yards = GetDBValueInt("TSSE", "tsoy", i);
                int gp = GetDBValueInt("TEAM", "TSWI", FindTeamRecfromTeamName(teamName)) + GetDBValueInt("TEAM", "TSLO", FindTeamRecfromTeamName(teamName));


                rankings.Add(new List<string>());
                rankings[num].Add(teamName);
                rankings[num].Add(Convert.ToString((double)(yards)/(double)(gp)));
                num++;
            }

            rankings.Sort((player1, player2) => Convert.ToDouble(player2[1]).CompareTo(Convert.ToDouble(player1[1])));

            int r = 1;
            foreach (List<string> team in rankings)
            {
                TopTeamOffBox.Items.Add("#" + r + " " + team[0] + " [" + Convert.ToDouble(team[1]).ToString("0.0") + " ypg]");
                r++;
            }
        }

        private void LoadTeamDefenseRankings()
        {
            TopTeamDefBox.Items.Clear();

            List<List<string>> rankings = new List<List<string>>();
            int num = 0;

            for (int i = 0; i < GetTableRecCount("TSSE"); i++)
            {
                string teamName = teamNameDB[GetDBValueInt("TSSE", "TGID", i)];
                int yards = GetDBValueInt("TSSE", "tsdp", i) + GetDBValueInt("TSSE", "tsdy", i);
                int gp = GetDBValueInt("TEAM", "TSWI", FindTeamRecfromTeamName(teamName)) + GetDBValueInt("TEAM", "TSLO", FindTeamRecfromTeamName(teamName));


                rankings.Add(new List<string>());
                rankings[num].Add(teamName);
                rankings[num].Add(Convert.ToString((double)(yards) / (double)(gp)));
                num++;
            }

            rankings.Sort((player1, player2) => Convert.ToDouble(player1[1]).CompareTo(Convert.ToDouble(player2[1])));

            int r = 1;
            foreach (List<string> team in rankings)
            {
                TopTeamDefBox.Items.Add("#" + r + " " + team[0] + " [" + Convert.ToDouble(team[1]).ToString("0.0") + " ypg]");
                r++;
            }
        }


        private void LoadPlayerOffStatLeaders()
        {
            PassingLeadersBox.Items.Clear();
            RushingLeadersBox.Items.Clear();
            ReceivingLeadersBox.Items.Clear();

            List<List<int>> rankings = new List<List<int>>();
            int num = 0;
            int seyr = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "SEYR", i) == seyr)
                {
                    rankings.Add(new List<int>());
                    rankings[num].Add(GetDBValueInt("PSOF", "PGID", i));
                    rankings[num].Add(GetDBValueInt("PSOF", "saya", i));
                    rankings[num].Add(GetDBValueInt("PSOF", "suya", i));
                    rankings[num].Add(GetDBValueInt("PSOF", "scya", i));
                    num++;
                }
            }

            //passing
            rankings.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

            for(int r = 1; r < 26; r++)
            {
                var team = rankings[r];
                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0]/ 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                PassingLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[1] + " yds]");
            }


            //rushing
            rankings.Sort((player1, player2) => player2[2].CompareTo(player1[2]));

            for (int r = 1; r < 26; r++)
            {
                var team = rankings[r];
                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0] / 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                RushingLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[2] + " yds]");
            }


            //receiving
            rankings.Sort((player1, player2) => player2[3].CompareTo(player1[3]));

            for (int r = 1; r < 26; r++)
            {
                var team = rankings[r];

                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0] / 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                ReceivingLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[3] + " yds]");
            }

        }

        private void LoadPlayerDefStatLeaders()
        {
            SacksLeadersBox.Items.Clear();
            TacklesLeadersBox.Items.Clear();
            IntLeadersBox.Items.Clear();

            List<List<int>> rankings = new List<List<int>>();
            int num = 0;
            int seyr = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSDE"); i++)
            {
                if (GetDBValueInt("PSOF", "SEYR", i) == seyr)
                {
                    rankings.Add(new List<int>());
                    rankings[num].Add(GetDBValueInt("PSDE", "PGID", i));
                    rankings[num].Add(GetDBValueInt("PSDE", "slsk", i));
                    rankings[num].Add(GetDBValueInt("PSDE", "sdta", i));
                    rankings[num].Add(GetDBValueInt("PSDE", "ssin", i));

                    num++;
                }
            }

            //sacks
            rankings.Sort((player1, player2) => player2[1].CompareTo(player1[1]));

            for (int r = 1; r < 26; r++)
            {
                var team = rankings[r];
                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0] / 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                SacksLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[1] + " sacks]");
            }


            //tackles
            rankings.Sort((player1, player2) => player2[2].CompareTo(player1[2]));

            for (int r = 1; r < 26; r++)
            {
                var team = rankings[r];

                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0] / 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                TacklesLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[2] + " tkls]");
            }


            //ints
            rankings.Sort((player1, player2) => player2[3].CompareTo(player1[3]));

            for (int r = 1; r < 26; r++)
            {
                var team = rankings[r];

                int rec = FindTeamRecfromTeamName(teamNameDB[rankings[r][0] / 70]);
                string tsna = GetDBValue("TEAM", "TSNA", rec);

                IntLeadersBox.Items.Add("#" + r + " " + GetPlayerNamefromPGID(team[0]) + ", " + tsna + " [" + team[3] + " ints]");
            }

        }

    }

}
