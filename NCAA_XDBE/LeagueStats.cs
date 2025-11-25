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
        private void StartStatsViewer()
        {
            if (LeagueRankingBox.Items.Count <= 0 || LeagueStatsBox.Items.Count <= 0)
            {
                LeagueStatsView.Rows.Clear();
                LeagueRankingView.Rows.Clear();


                LoadLeagueRankingBox();
                LoadLeagueStatBox();
            }
        }

        #region League Ranking Viewer
        private void LoadLeagueRankingBox()
        {
            LeagueRankingBox.Items.Clear();

            LeagueRankingBox.Items.Add("AP Poll");
            LeagueRankingBox.Items.Add("Coach Poll");
            LeagueRankingBox.Items.Add("Bowl Ranking");
            LeagueRankingBox.Items.Add("Overall Rating");
            LeagueRankingBox.Items.Add("Offense Rating");
            LeagueRankingBox.Items.Add("Defense Rating");
        }


        private void LeagueRankingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeagueRankingView.Rows.Clear();

            if (LeagueRankingBox.SelectedIndex == 0) LoadLeagueMediaPoll();
            else if (LeagueRankingBox.SelectedIndex == 1) LoadLeagueCoachPoll();
            else if (LeagueRankingBox.SelectedIndex == 2) LoadLeagueBowlRanking();
            else if (LeagueRankingBox.SelectedIndex == 3) LoadLeagueTeamOVR();
            else if (LeagueRankingBox.SelectedIndex == 4) LoadLeagueTeamOffRating();
            else if (LeagueRankingBox.SelectedIndex == 5) LoadLeagueTeamDefRating();
        }


        private void AddLeagueTeamRankData(List<List<string>> rankings)
        {
            foreach (List<string> team in rankings)
            {
                int row = LeagueRankingView.Rows.Count;
                LeagueRankingView.Rows.Add(1);

                LeagueRankingView.Rows[row].Cells[0].Value = Convert.ToInt32(team[0]);
                LeagueRankingView.Rows[row].Cells[1].Value = team[1];
                LeagueRankingView.Rows[row].Cells[2].Value = team[2];
                LeagueRankingView.Rows[row].Cells[3].Value = Convert.ToInt32(team[3]);

                if (team[4] == "N/A")
                {
                    LeagueRankingView.Rows[row].Cells[4].Value = "N/A";
                }
                else
                {
                    LeagueRankingView.Rows[row].Cells[4].Value = Convert.ToInt32(team[4]);
                }
            }

        }

        private void LeagueRankingView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // Only handle the Win-Loss "W-L" column
            if (e.Column.Index != 2)
            {
                e.Handled = false;
                return;
            }

            string s1 = (e.CellValue1 ?? string.Empty).ToString().Trim();
            string s2 = (e.CellValue2 ?? string.Empty).ToString().Trim();

            bool ok1 = TryParseWinLoss(s1, out int wins1, out int losses1);
            bool ok2 = TryParseWinLoss(s2, out int wins2, out int losses2);

            int result;
            if (ok1 && ok2)
            {
                // Primary: wins (descending). Secondary: losses (ascending = fewer losses is better).
                result = wins2.CompareTo(wins1);
                if (result == 0) result = losses1.CompareTo(losses2);
            }
            else
            {
                // Fallback to string compare if parse fails for either cell
                result = string.Compare(s1, s2, StringComparison.OrdinalIgnoreCase);
            }

            e.SortResult = result;
            e.Handled = true; // IMPORTANT: tell the grid we've provided the comparison
        }

        private static bool TryParseWinLoss(string s, out int wins, out int losses)
        {
            wins = 0;
            losses = 0;
            if (string.IsNullOrEmpty(s)) return false;

            var parts = s.Split('-', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return false;

            if (!int.TryParse(parts[0].Trim(), out wins)) return false;
            if (parts.Length >= 2)
            {
                if (!int.TryParse(parts[1].Trim(), out losses)) losses = 0;
            }
            return true;
        }




        private void LoadLeagueMediaPoll()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TMRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add(GetDBValue("TEAM", "TMPT", i));

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[0]).CompareTo(Convert.ToInt32(player2[0])));

            AddLeagueTeamRankData(rankings);

        }


        private void LoadLeagueCoachPoll()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TCRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add(GetDBValue("TEAM", "TCPT", i));

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[0]).CompareTo(Convert.ToInt32(player2[0])));

            AddLeagueTeamRankData(rankings);
        }

        private void LoadLeagueBowlRanking()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TBRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add("N/A");

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player1[0]).CompareTo(Convert.ToInt32(player2[0])));

            AddLeagueTeamRankData(rankings);

        }


        private void LoadLeagueTeamOVR()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TCRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add("0");
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add(GetDBValue("TEAM", "TROV", i));

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player2[4]).CompareTo(Convert.ToInt32(player1[4])));

            for (int i = 0; i < rankings.Count; i++)
            {
                rankings[i][0] = "" + (i + 1);
            }

            AddLeagueTeamRankData(rankings);
        }


        private void LoadLeagueTeamOffRating()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TCRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add(GetDBValue("TEAM", "TROF", i));

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player2[4]).CompareTo(Convert.ToInt32(player1[4])));

            for (int i = 0; i < rankings.Count; i++)
            {
                rankings[i][0] = "" + (i + 1);
            }

            AddLeagueTeamRankData(rankings);
        }

        private void LoadLeagueTeamDefRating()
        {
            List<List<string>> rankings = new List<List<string>>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                {
                    int num = rankings.Count;
                    string rank = GetDBValue("TEAM", "TCRK", i);
                    rankings.Add(new List<string>());
                    rankings[num].Add(rank);
                    rankings[num].Add(GetDBValue("TEAM", "TDNA", i));
                    rankings[num].Add("" + (GetDBValueInt("TEAM", "tsdw", i)) + "-" + (GetDBValueInt("TEAM", "tsdl", i)));
                    rankings[num].Add(GetDBValue("TEAM", "TMPR", i));
                    rankings[num].Add(GetDBValue("TEAM", "TRDE", i));

                }

            }

            rankings.Sort((player1, player2) => Convert.ToInt32(player2[4]).CompareTo(Convert.ToInt32(player1[4])));

            for (int i = 0; i < rankings.Count; i++)
            {
                rankings[i][0] = "" + (i + 1);
            }


            AddLeagueTeamRankData(rankings);
        }

        #endregion

        #region League Stat Viewer

        private void LoadLeagueStatBox()
        {
            LeagueStatsBox.Items.Clear();

            LeagueStatsBox.Items.Add("Team Offense Stats");
            LeagueStatsBox.Items.Add("Tean Defense Stats");
            LeagueStatsBox.Items.Add("Passing Stats");
            LeagueStatsBox.Items.Add("Rushing Stats");
            LeagueStatsBox.Items.Add("Receiving Stats");
            LeagueStatsBox.Items.Add("Defensive Stats");
            LeagueStatsBox.Items.Add("Kicking Stats");
            LeagueStatsBox.Items.Add("Punting Stats");
            LeagueStatsBox.Items.Add("Return Stats");
        }

        private void LeagueStatsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeagueStatsView.Rows.Clear();
            int seyr = GetDBValueInt("SEAI", "SEYR", 0);

            if (LeagueStatsBox.SelectedIndex == 0) LoadLeagueTeamOffenseStats();
            else if (LeagueStatsBox.SelectedIndex == 1) LoadLeagueTeamDefenseStats();
            else if (LeagueStatsBox.SelectedIndex == 2) LoadLeaguePassingStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 3) LoadLeagueRushingStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 4) LoadLeagueReceivingStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 5) LoadLeagueDefensiveStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 6) LoadLeagueKickingStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 7) LoadLeaguePuntingStats(seyr);
            else if (LeagueStatsBox.SelectedIndex == 8) LoadLeagueReturnStats(seyr);

            if(LeagueStatsBox.SelectedIndex >= 2)
            {
                LS00.HeaderText = "Team";
                LS01.HeaderText = "Player";
            }
            else
            {
                LS00.HeaderText = "Rank";
                LS01.HeaderText = "Team";
                for(int i = 0; i < LeagueStatsView.Rows.Count; i++)
                {
                    LeagueStatsView.Rows[i].Cells[0].Value = i+1;
                }
            }

        }

        private void LoadLeagueTeamOffenseStats()
        {

            LS1.HeaderText = "Yds/gm";
            LS2.HeaderText = "Pts/gm";
            LS3.HeaderText = "Tot Yds";
            LS4.HeaderText = "Off Yds";
            LS5.HeaderText = "Pass Yds";
            LS6.HeaderText = "Pass TD";
            LS7.HeaderText = "Rush Yds";
            LS8.HeaderText = "Rush TD";
            LS9.HeaderText = "Sacks";

            List<List<int>> teamGP = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                teamGP.Add(new List<int>());
                teamGP[i].Add(0); // games played
                teamGP[i].Add(0); // pts scored
                teamGP[i].Add(0); // pts allowed
            }

            for (int g = 0; g < GetTableRecCount("SCHD"); g++)
            {
                int tgidA = GetDBValueInt("SCHD", "GATG", g);
                int tgidH = GetDBValueInt("SCHD", "GHTG", g);
                int Ascore = GetDBValueInt("SCHD", "GASC", g);
                int Hscore = GetDBValueInt("SCHD", "GHSC", g);

                if(Ascore > 0 || Hscore > 0)
                {
                        teamGP[tgidA][0]++;
                        teamGP[tgidA][1] += Ascore;
                        teamGP[tgidA][2] += Hscore;

                        teamGP[tgidH][0]++;
                        teamGP[tgidH][1] += Hscore;
                        teamGP[tgidH][2] += Ascore;
                }
            }

            StartProgressBar(GetTableRecCount("TSSE"));

            for (int i = 0; i < GetTableRecCount("TSSE"); i++)
            {
                string team = teamNameDB[GetDBValueInt("TSSE", "TGID", i)];
                int teamRec = FindTeamRecfromTeamName(team);

                int totYds = GetDBValueInt("TSSE", "tsTy", i);
                int offYds = GetDBValueInt("TSSE", "tsoy", i);
                int passYds = GetDBValueInt("TSSE", "tsop", i);
                int passTD = GetDBValueInt("TSSE", "tsPt", i);
                int rushYds = GetDBValueInt("TSSE", "tsor", i);
                int rushTD = GetDBValueInt("TSSE", "tsrt", i);
                int firstdowns = GetDBValueInt("TSSE", "ts1d", i);
                int sacks = GetDBValueInt("TSSE", "tssa", i);

                int pts = teamGP[GetDBValueInt("TSSE", "TGID", i)][1];
                double gp = teamGP[GetDBValueInt("TSSE", "TGID", i)][0];

                double ypg = 0;
                if (gp > 0) ypg = Math.Round((Convert.ToDouble(offYds) / Convert.ToDouble(gp)), 1);
                double ppg = 0;
                if (gp > 0) ppg = Math.Round((Convert.ToDouble(pts) / Convert.ToDouble(gp)), 1);

                int row = LeagueStatsView.Rows.Count;
                LeagueStatsView.Rows.Add(1);
                LeagueStatsView.Rows[row].Cells[1].Value = team;
                LeagueStatsView.Rows[row].Cells[2].Value = ypg;
                LeagueStatsView.Rows[row].Cells[3].Value = ppg;
                LeagueStatsView.Rows[row].Cells[4].Value = totYds;
                LeagueStatsView.Rows[row].Cells[5].Value = offYds;
                LeagueStatsView.Rows[row].Cells[6].Value = passYds;
                LeagueStatsView.Rows[row].Cells[7].Value = passTD;
                LeagueStatsView.Rows[row].Cells[8].Value = rushYds;
                LeagueStatsView.Rows[row].Cells[9].Value = rushTD;
                LeagueStatsView.Rows[row].Cells[10].Value = sacks;

            }
            ProgressBarStep();


            LeagueStatsView.Sort(LeagueStatsView.Columns[2], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueTeamDefenseStats()
        {

            LS1.HeaderText = "Yds/Gm";
            LS2.HeaderText = "Pts/Gm";
            LS3.HeaderText = "Tot Yds";
            LS4.HeaderText = "Pass Yds";
            LS5.HeaderText = "Rush Yds";
            LS6.HeaderText = "Sacks";
            LS7.HeaderText = "Ints";
            LS8.HeaderText = "Fum Rec";
            LS9.HeaderText = "";

            List<List<int>> teamGP = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                teamGP.Add(new List<int>());
                teamGP[i].Add(0); // games played
                teamGP[i].Add(0); // pts scored
                teamGP[i].Add(0); // pts allowed
            }

            for (int g = 0; g < GetTableRecCount("SCHD"); g++)
            {
                int tgidA = GetDBValueInt("SCHD", "GATG", g);
                int tgidH = GetDBValueInt("SCHD", "GHTG", g);
                int Ascore = GetDBValueInt("SCHD", "GASC", g);
                int Hscore = GetDBValueInt("SCHD", "GHSC", g);

                if (Ascore > 0 || Hscore > 0)
                {
                    teamGP[tgidA][0]++;
                    teamGP[tgidA][1] += Ascore;
                    teamGP[tgidA][2] += Hscore;

                    teamGP[tgidH][0]++;
                    teamGP[tgidH][1] += Hscore;
                    teamGP[tgidH][2] += Ascore;
                }
            }


            StartProgressBar(GetTableRecCount("TSSE"));

            for (int i = 0; i < GetTableRecCount("TSSE"); i++)
            {
                string team = teamNameDB[GetDBValueInt("TSSE", "TGID", i)];
                int teamRec = FindTeamRecfromTeamName(team);

                int passYds = GetDBValueInt("TSSE", "tsdp", i);
                int rushYds = GetDBValueInt("TSSE", "tsdy", i);
                int totYds = passYds + rushYds;

                int ints = GetDBValueInt("TSSE", "tsDi", i);
                int fumrec = GetDBValueInt("TSSE", "tsfr", i);
                int sacks = GetDBValueInt("TSSE", "tssk", i);

                int pts = teamGP[GetDBValueInt("TSSE", "TGID", i)][2];
                double gp = teamGP[GetDBValueInt("TSSE", "TGID", i)][0];


                double ypg = 0;
                if (gp > 0) ypg = Math.Round((Convert.ToDouble(totYds) / Convert.ToDouble(gp)), 1);
                double ppg = 0;
                if (gp > 0) ppg = Math.Round((Convert.ToDouble(pts) / Convert.ToDouble(gp)), 1);

                int row = LeagueStatsView.Rows.Count;
                LeagueStatsView.Rows.Add(1);
                LeagueStatsView.Rows[row].Cells[1].Value = team;
                LeagueStatsView.Rows[row].Cells[2].Value = ypg;
                LeagueStatsView.Rows[row].Cells[3].Value = ppg;
                LeagueStatsView.Rows[row].Cells[4].Value = totYds;
                LeagueStatsView.Rows[row].Cells[5].Value = passYds;
                LeagueStatsView.Rows[row].Cells[6].Value = rushYds;
                LeagueStatsView.Rows[row].Cells[7].Value = sacks;
                LeagueStatsView.Rows[row].Cells[8].Value = ints;
                LeagueStatsView.Rows[row].Cells[9].Value = fumrec;
            }
            ProgressBarStep();


            LeagueStatsView.Sort(LeagueStatsView.Columns[2], System.ComponentModel.ListSortDirection.Ascending);

            EndProgressBar();
        }

        private void LoadLeaguePassingStats(int year)
        {

            LS1.HeaderText = "QBR";
            LS2.HeaderText = "CMP";
            LS3.HeaderText = "ATT";
            LS4.HeaderText = "PCT";
            LS5.HeaderText = "YDS";
            LS6.HeaderText = "YPG";
            LS7.HeaderText = "TD";
            LS8.HeaderText = "INT";
            LS9.HeaderText = "Sack";

            StartProgressBar(GetTableRecCount("PSOF"));

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {

                int gp = GetDBValueInt("PSOF", "sgmp", i);
                int att = GetDBValueInt("PSOF", "saat", i);
                int seyr = GetDBValueInt("PSOF", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && att > 0)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSOF", "PGID", i) / 70];


                    int cmp = GetDBValueInt("PSOF", "sacm", i);
                    int yds = GetDBValueInt("PSOF", "saya", i);
                    int td = GetDBValueInt("PSOF", "satd", i);
                    int ints = GetDBValueInt("PSOF", "sain", i);
                    int skd = GetDBValueInt("PSOF", "sasa", i);

                    double pct = 0;
                    if (att > 0) pct = Math.Round((Convert.ToDouble(cmp) / Convert.ToDouble(att)) * 100, 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);


                    // NCAA Passer Rating Formula:
                    // (8.4 * YDS + 330 * TD + 100 * CMP - 200 * INT) / ATT
                    double qbr = 0;
                    if (att >= sewn * 10)
                    {
                        qbr = Math.Round(
                            ((8.4 * yds) +
                             (330 * td) +
                             (100 * cmp) -
                             (200 * ints)) / att, 1);
                    }
                    if (qbr < 0) qbr = 0;

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = qbr;
                    LeagueStatsView.Rows[row].Cells[3].Value = cmp;
                    LeagueStatsView.Rows[row].Cells[4].Value = att;
                    LeagueStatsView.Rows[row].Cells[5].Value = pct;
                    LeagueStatsView.Rows[row].Cells[6].Value = yds;
                    LeagueStatsView.Rows[row].Cells[7].Value = ypg;
                    LeagueStatsView.Rows[row].Cells[8].Value = td;
                    LeagueStatsView.Rows[row].Cells[9].Value = ints;
                    LeagueStatsView.Rows[row].Cells[10].Value = skd;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSOF", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec); 
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[6], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueRushingStats(int year)
        {

            LS1.HeaderText = "ATT";
            LS2.HeaderText = "YDS";
            LS3.HeaderText = "TDs";
            LS4.HeaderText = "YPC";
            LS5.HeaderText = "YPG";
            LS6.HeaderText = "FUM";
            LS7.HeaderText = "YAI";
            LS8.HeaderText = "BTK";
            LS9.HeaderText = "20+";

            StartProgressBar(GetTableRecCount("PSOF"));

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {

                int gp = GetDBValueInt("PSOF", "sgmp", i);
                int att = GetDBValueInt("PSOF", "suat", i);
                int seyr = GetDBValueInt("PSOF", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && att > gp * 3)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSOF", "PGID", i) / 70];

                    int yds = GetDBValueInt("PSOF", "suya", i);
                    int td = GetDBValueInt("PSOF", "sutd", i);
                    int fum = GetDBValueInt("PSOF", "sufu", i);
                    int yai = GetDBValueInt("PSOF", "suyh", i);
                    int btk = GetDBValueInt("PSOF", "subt", i);
                    int twenty = GetDBValueInt("PSOF", "su2y", i);

                    double ypc = 0;
                    if (att > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(att)), 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = att;
                    LeagueStatsView.Rows[row].Cells[3].Value = yds;
                    LeagueStatsView.Rows[row].Cells[4].Value = td;
                    LeagueStatsView.Rows[row].Cells[5].Value = ypc;
                    LeagueStatsView.Rows[row].Cells[6].Value = ypg;
                    LeagueStatsView.Rows[row].Cells[7].Value = fum;
                    LeagueStatsView.Rows[row].Cells[8].Value = yai;
                    LeagueStatsView.Rows[row].Cells[9].Value = btk;
                    LeagueStatsView.Rows[row].Cells[10].Value = twenty;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSOF", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[3], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueReceivingStats(int year)
        {

            LS1.HeaderText = "CAT";
            LS2.HeaderText = "YDS";
            LS3.HeaderText = "TDs";
            LS4.HeaderText = "YPC";
            LS5.HeaderText = "YPG";
            LS6.HeaderText = "FUM";
            LS7.HeaderText = "YAC";
            LS8.HeaderText = "YACa";
            LS9.HeaderText = "Drop";

            StartProgressBar(GetTableRecCount("PSOF"));

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {

                int gp = GetDBValueInt("PSOF", "sgmp", i);
                int cat = GetDBValueInt("PSOF", "scca", i);
                int seyr = GetDBValueInt("PSOF", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && cat > 3 * gp)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSOF", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSOF", "PGID", i) / 70];


                    int yds = GetDBValueInt("PSOF", "scya", i);
                    int td = GetDBValueInt("PSOF", "sctd", i);
                    int fum = GetDBValueInt("PSOF", "sufu", i);
                    int rac = GetDBValueInt("PSOF", "scyc", i);
                    int drp = GetDBValueInt("PSOF", "scdr", i);

                    double ypc = 0;
                    if (cat > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(cat)), 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                    double rca = 0;
                    if (cat > 0) rca = Math.Round((Convert.ToDouble(rac) / Convert.ToDouble(cat)), 1);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = cat;
                    LeagueStatsView.Rows[row].Cells[3].Value = yds;
                    LeagueStatsView.Rows[row].Cells[4].Value = td;
                    LeagueStatsView.Rows[row].Cells[5].Value = ypc;
                    LeagueStatsView.Rows[row].Cells[6].Value = ypg;
                    LeagueStatsView.Rows[row].Cells[7].Value = fum;
                    LeagueStatsView.Rows[row].Cells[8].Value = rac;
                    LeagueStatsView.Rows[row].Cells[9].Value = rca;
                    LeagueStatsView.Rows[row].Cells[10].Value = drp;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSOF", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[3], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueDefensiveStats(int year)
        {

            LS1.HeaderText = "Takl";
            LS2.HeaderText = "TFL";
            LS3.HeaderText = "Sack";
            LS4.HeaderText = "Ints";
            LS5.HeaderText = "PDef";
            LS6.HeaderText = "FFum";
            LS7.HeaderText = "FumR";
            LS8.HeaderText = "DefTD";
            LS9.HeaderText = "";

            StartProgressBar(GetTableRecCount("PSDE"));

            for (int i = 0; i < GetTableRecCount("PSDE"); i++)
            {

                int gp = GetDBValueInt("PSDE", "sgmp", i);
                int tak = GetDBValueInt("PSDE", "sdta", i);
                int seyr = GetDBValueInt("PSDE", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && tak > 2 * gp)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSDE", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSDE", "PGID", i) / 70];


                    int tfl = GetDBValueInt("PSDE", "sdtl", i);
                    int sack = GetDBValueInt("PSDE", "slsk", i);
                    int ints = GetDBValueInt("PSDE", "ssin", i);
                    int pdef = GetDBValueInt("PSDE", "sdpd", i);
                    int ffum = GetDBValueInt("PSDE", "slff", i);
                    int fumr = GetDBValueInt("PSDE", "slfr", i);
                    int defTD = GetDBValueInt("PSDE", "ssdt", i);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = tak;
                    LeagueStatsView.Rows[row].Cells[3].Value = tfl;
                    LeagueStatsView.Rows[row].Cells[4].Value = sack;
                    LeagueStatsView.Rows[row].Cells[5].Value = ints;
                    LeagueStatsView.Rows[row].Cells[6].Value = pdef;
                    LeagueStatsView.Rows[row].Cells[7].Value = ffum;
                    LeagueStatsView.Rows[row].Cells[8].Value = fumr;
                    LeagueStatsView.Rows[row].Cells[9].Value = defTD;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSDE", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[2], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueKickingStats(int year)
        {

            LS1.HeaderText = "FGM";
            LS2.HeaderText = "FGA";
            LS3.HeaderText = "PCT";
            LS4.HeaderText = "Long";
            LS5.HeaderText = "XPM";
            LS6.HeaderText = "XPA";
            LS7.HeaderText = "PCT";
            LS8.HeaderText = "40+";
            LS9.HeaderText = "";

            StartProgressBar(GetTableRecCount("PSKI"));

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {

                int gp = GetDBValueInt("PSKI", "sgmp", i);
                int fga = GetDBValueInt("PSKI", "skfa", i);
                int seyr = GetDBValueInt("PSKI", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && fga > 0)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSKI", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSKI", "PGID", i) / 70];


                    int fgm = GetDBValueInt("PSKI", "skfm", i);
                    int longest = GetDBValueInt("PSKI", "skfL", i);
                    int xpm = GetDBValueInt("PSKI", "skem", i);
                    int xpa = GetDBValueInt("PSKI", "skea", i);
                    int fourty = GetDBValueInt("PSKI", "", i);

                    double fgpct = 0;
                    if (fga > 0) fgpct = Math.Round((Convert.ToDouble(fgm) / Convert.ToDouble(fga)) * 100, 1);

                    double xppct = 0;
                    if (xpa > 0) xppct = Math.Round((Convert.ToDouble(xpm) / Convert.ToDouble(xpa)) * 100, 1);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = fgm;
                    LeagueStatsView.Rows[row].Cells[3].Value = fga;
                    LeagueStatsView.Rows[row].Cells[4].Value = fgpct;
                    LeagueStatsView.Rows[row].Cells[5].Value = longest;
                    LeagueStatsView.Rows[row].Cells[6].Value = xpm;
                    LeagueStatsView.Rows[row].Cells[7].Value = xpa;
                    LeagueStatsView.Rows[row].Cells[8].Value = xppct;
                    LeagueStatsView.Rows[row].Cells[9].Value = fourty;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSKI", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[2], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeaguePuntingStats(int year)
        {

            LS1.HeaderText = "Punts";
            LS2.HeaderText = "Yds";
            LS3.HeaderText = "Avg";
            LS4.HeaderText = "Long";
            LS5.HeaderText = "In 20";
            LS6.HeaderText = "Blocked";
            LS7.HeaderText = "";
            LS8.HeaderText = "";
            LS9.HeaderText = "";

            StartProgressBar(GetTableRecCount("PSKI"));

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {

                int gp = GetDBValueInt("PSKI", "sgmp", i);
                int punt = GetDBValueInt("PSKI", "spat", i);
                int seyr = GetDBValueInt("PSKI", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && punt > 0)
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSKI", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSKI", "PGID", i) / 70];

                    int yd = GetDBValueInt("PSKI", "spya", i);
                    int longest = GetDBValueInt("PSKI", "splN", i);
                    int intwenty = GetDBValueInt("PSKI", "sppt", i);
                    int blocked = GetDBValueInt("PSKI", "spbl", i);


                    double puntavg = 0;
                    if (punt > 0) puntavg = Math.Round((Convert.ToDouble(yd) / Convert.ToDouble(punt)), 1);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = punt;
                    LeagueStatsView.Rows[row].Cells[3].Value = yd;
                    LeagueStatsView.Rows[row].Cells[4].Value = puntavg;
                    LeagueStatsView.Rows[row].Cells[5].Value = longest;
                    LeagueStatsView.Rows[row].Cells[6].Value = intwenty;
                    LeagueStatsView.Rows[row].Cells[7].Value = blocked;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSKI", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[3], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        private void LoadLeagueReturnStats(int year)
        {

            LS1.HeaderText = "KR";
            LS2.HeaderText = "Yds";
            LS3.HeaderText = "TDs";
            LS4.HeaderText = "Long";
            LS5.HeaderText = "PR";
            LS6.HeaderText = "Yds";
            LS7.HeaderText = "TDs";
            LS8.HeaderText = "Long";
            LS9.HeaderText = "TotYds";

            StartProgressBar(GetTableRecCount("PSKP"));

            for (int i = 0; i < GetTableRecCount("PSKP"); i++)
            {

                int gp = GetDBValueInt("PSKP", "sgmp", i);
                int KRAtt = GetDBValueInt("PSKP", "srka", i);
                int PRAtt = GetDBValueInt("PSKP", "srpa", i);
                int seyr = GetDBValueInt("PSKP", "SEYR", i);
                int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                if (gp <= 0) gp = CountTeamGames(GetDBValueInt("PSOF", "PGID", i) / 70);

                if (seyr == year && (KRAtt > gp || PRAtt > gp))
                {
                    string player = GetPlayerNamefromPGID(GetDBValueInt("PSKP", "PGID", i));
                    string team = teamNameDB[GetDBValueInt("PSKP", "PGID", i) / 70];

                    int KRYds = GetDBValueInt("PSKP", "srky", i);
                    int KRTD = GetDBValueInt("PSKP", "srkt", i);
                    int KRLong = GetDBValueInt("PSKP", "srkL", i);
                    int PRYds = GetDBValueInt("PSKP", "srpy", i);
                    int PRTD = GetDBValueInt("PSKP", "srpt", i);
                    int PRLong = GetDBValueInt("PSKP", "srpL", i);

                    int row = LeagueStatsView.Rows.Count;
                    LeagueStatsView.Rows.Add(1);
                    LeagueStatsView.Rows[row].Cells[0].Value = team;
                    LeagueStatsView.Rows[row].Cells[1].Value = player;
                    LeagueStatsView.Rows[row].Cells[2].Value = KRAtt;
                    LeagueStatsView.Rows[row].Cells[3].Value = KRYds;
                    LeagueStatsView.Rows[row].Cells[4].Value = KRTD;
                    LeagueStatsView.Rows[row].Cells[5].Value = KRLong;
                    LeagueStatsView.Rows[row].Cells[6].Value = PRAtt;
                    LeagueStatsView.Rows[row].Cells[7].Value = PRYds;
                    LeagueStatsView.Rows[row].Cells[8].Value = PRTD;
                    LeagueStatsView.Rows[row].Cells[9].Value = PRLong;
                    LeagueStatsView.Rows[row].Cells[10].Value = KRYds + PRYds;

                    int playerRec = FindPGIDRecord(GetDBValueInt("PSKP", "PGID", i));
                    DisplayLeagueStatsViewID(row, playerRec);
                }
                ProgressBarStep();
            }

            LeagueStatsView.Sort(LeagueStatsView.Columns[10], System.ComponentModel.ListSortDirection.Descending);

            EndProgressBar();
        }

        #endregion
        private void DisplayLeagueStatsViewID(int row, int ID)
        {
            LeagueStatsView.Rows[row].Cells[11].Value = ID;
        }

        //Hyperlinks
        private void LeagueStatsView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;

            //Player
            if (cell == 1 && LeagueStatsBox.SelectedIndex >= 2)
            {
                int PLAYrec = Convert.ToInt32(LeagueStatsView.Rows[row].Cells[11].Value);

                PlayerIndex = PLAYrec;
                tabControl1.SelectedTab = tabPlayers;
                LoadPlayerData();
            }
            //Team
            else if (cell == 0 && LeagueStatsBox.SelectedIndex >= 2)
            {
                int teamRec = FindTeamRecfromTeamName(Convert.ToString(LeagueStatsView.Rows[row].Cells[1].Value));
                TeamIndex = teamRec;
                tabControl1.SelectedTab = tabTeams;
                GetTeamEditorData(teamRec);
            }
            //Team
            else if (cell == 1 && LeagueStatsBox.SelectedIndex < 2)
            {
                int teamRec = FindTeamRecfromTeamName(Convert.ToString(LeagueStatsView.Rows[row].Cells[1].Value));
                TeamIndex = teamRec;
                tabControl1.SelectedTab = tabTeams;
                GetTeamEditorData(teamRec);
            }
        }
    }

}
