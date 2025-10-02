using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        private void StartRecruitRankingsView()
        {
            char whiteStar = '\u2606'; // ☆ White Star
            char blackStar = '\u2605'; // ★ Black Star
            LoadRecruitRankingComboBox();

            RB5Star.HeaderText = "5" + whiteStar;
            RB4Star.HeaderText = "4" + whiteStar;
            RB3Star.HeaderText = "3" + whiteStar;
            RB2Star.HeaderText = "2" + whiteStar;
            RB1Star.HeaderText = "1" + whiteStar;
        }

        private void LoadRecruitRankingComboBox()
        {
            RecruitRankingComboBox.Items.Clear();
            RecruitRankingComboBox.Items.Add("Overall");
            RecruitRankingComboBox.Items.Add("Recruits");
            RecruitRankingComboBox.Items.Add("Transfers");
        }



        private void RecruitRankingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecruitRankingView.Rows.Clear();
            LoadRecruitRankingView(RecruitRankingComboBox.SelectedIndex);

        }

        private void LoadRecruitRankingView(int view)
        {
            /* 0 - Rank
             * 1 - Team
             * 2 - 5 star
             * 3 - 4 star
             * 4 - 3 star
             * 5 - 2 star
             * 6 - 1 star
             * 7 - points
             */

            RecruitRankingView.Rows.Clear();

            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTable2RecCount("RCTC");

            for (int i = 0; i < GetTable2RecCount("RCTC"); i++)
            {

                int tgid = GetDB2ValueInt("RCTC", "TGID", i);
                int five = 0;
                int four = 0;
                int three = 0;
                int two = 0;
                int one = 0;


                if (view == 0)
                {
                    RecruitHomeTeam.HeaderText = "Home";

                    five = GetDB2ValueInt("RCTC", "RC5S", i);
                    four = GetDB2ValueInt("RCTC", "RC4S", i);
                    three = GetDB2ValueInt("RCTC", "RC3S", i) + GetDB2ValueInt("RCTC", "RTC3", i);
                    two = GetDB2ValueInt("RCTC", "RC2S", i) + GetDB2ValueInt("RCTC", "RTC2", i);
                    one = GetDB2ValueInt("RCTC", "RC1S", i) + GetDB2ValueInt("RCTC", "RTC1", i);
                }
                else if (view == 1)  //recruits only
                {
                    if (!Next26Mod && !NextMod)
                    {
                        five = GetDB2ValueInt("RCTC", "RC5S", i);
                        four = GetDB2ValueInt("RCTC", "RC4S", i);
                        three = GetDB2ValueInt("RCTC", "RC3S", i);
                        two = GetDB2ValueInt("RCTC", "RC2S", i);
                        one = GetDB2ValueInt("RCTC", "RC1S", i);
                    }
                    else
                    {
                        five = 0;
                        four = 0;
                        three = 0;
                        two = 0;
                        one = 0;

                        for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                        {
                            if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && GetDB2ValueInt("RCPR", "PRID", x) <= 21000)
                            {
                                int star = GetDB2ValueInt("RCPT", "RCCB", x);

                                if (star == 5) five++;
                                if (star == 4) four++;
                                if (star == 3) three++;
                                if (star == 2) two++;
                                if (star == 1) one++;
                            }
                        }
                    }
                }
                else
                {
                    RecruitHomeTeam.HeaderText = "State";

                    if (!Next26Mod && !NextMod)
                    {
                        five = 0;
                        four = 0;
                        three = GetDB2ValueInt("RCTC", "RTC3", i);
                        two = GetDB2ValueInt("RCTC", "RTC2", i);
                        one = GetDB2ValueInt("RCTC", "RTC1", i);
                    }
                    else
                    {
                        RecruitHomeTeam.HeaderText = "Prev";

                        five = 0;
                        four = 0;
                        three = 0;
                        two = 0;
                        one = 0;

                        for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                        {
                            if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && GetDB2ValueInt("RCPR", "PRID", x) >= 21000)
                            {
                                int star = GetDB2ValueInt("RCPT", "RCCB", x);

                                if (star == 5) five++;
                                if (star == 4) four++;
                                if (star == 3) three++;
                                if (star == 2) two++;
                                if (star == 1) one++;
                            }
                        }

                        for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                        {
                            if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69)
                            {
                                int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", FindPGIDRecord(GetDBValueInt("TRAN", "PGID", x))));
                                int star = 0;
                                if (ovr >= 86) star = 5;
                                else if (ovr >= 80) star = 4;
                                else if (ovr >= 74) star = 3;
                                else if (ovr >= 68) star = 2;
                                else star = 1;

                                if (star == 5) five++;
                                if (star == 4) four++;
                                if (star == 3) three++;
                                if (star == 2) two++;
                                if (star == 1) one++;
                            }
                        }
                    }

                }

                FillRecruitRankingView(tgid, five, four, three, two, one);
                ProgressBarStep();
            }

            RecruitRankingView.Sort(RecruitRankingPts, System.ComponentModel.ListSortDirection.Descending);

            for (int r = 0; r < RecruitRankingView.Rows.Count; r++)
            {
                RecruitRankingView.Rows[r].Cells[0].Value = r + 1;
            }

            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        private void FillRecruitRankingView(int tgid, int five, int four, int three, int two, int one)
        {
            int row = RecruitRankingView.Rows.Count;

            RecruitRankingView.Rows.Add(1);

            RecruitRankingView.Rows[row].Cells[1].Value = teamNameDB[tgid];
            RecruitRankingView.Rows[row].Cells[2].Value = five;
            RecruitRankingView.Rows[row].Cells[3].Value = four;
            RecruitRankingView.Rows[row].Cells[4].Value = three;
            RecruitRankingView.Rows[row].Cells[5].Value = two;
            RecruitRankingView.Rows[row].Cells[6].Value = one;
            RecruitRankingView.Rows[row].Cells[7].Value = (double)CalculateRecruitPoints(five, four, three, two, one);
            RecruitRankingView.Rows[row].Cells[8].Value = (double)CalculateRecruitAvg(five, four, three, two, one);
        }


        private void RecruitRankingView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = (e.RowIndex);
            if (row == -1) return;
            string team = Convert.ToString(RecruitRankingView.Rows[row].Cells[1].Value);
            int tgid = FindTGIDfromTeamName(team);

            LoadRecruitTeamView(tgid);
        }

        private void LoadRecruitTeamView(int tgid)
        {
            RecruitTeamView.Rows.Clear();

            progressBar1.Visible = true;
            progressBar1.Value = 0;

            /* 0 - position
             * 1 - player
             * 2 - home
             * 3 - height/weight
             * 4 - ovr
             * 5 - star rating
             * 6 - pos rank
             */

            if (RecruitRankingComboBox.SelectedIndex == 0)
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Overall Combined Class";
                progressBar1.Maximum = GetTable2RecCount("RCPR") + GetTableRecCount("TRAN");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        GetRecruitRankPlayer(prid);
                    }
                    ProgressBarStep();
                }

                for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                {
                    if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        GetTransferRankPlayer(pgid, ptid);
                    }
                    ProgressBarStep();
                }

            }
            else if (RecruitRankingComboBox.SelectedIndex == 1)
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Recruiting Class";
                progressBar1.Maximum = GetTable2RecCount("RCTC");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid < 21000) GetRecruitRankPlayer(prid);
                    }
                    ProgressBarStep();

                }

            }
            else
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Transfer Class";
                progressBar1.Maximum = GetTable2RecCount("RCPR") + GetTableRecCount("TRAN");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid >= 21000) GetRecruitRankPlayer(prid);
                    }
                    ProgressBarStep();

                }

                for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                {
                    if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        GetTransferRankPlayer(pgid, ptid);
                    }
                    ProgressBarStep();

                }
            }

            RecruitTeamView.Sort(RecruitTeamOVR, System.ComponentModel.ListSortDirection.Descending);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void GetRecruitRankPlayer(int prid)
        {
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);
            bool transfer = false;
            int pgid = prid;

            if(prid >= 21000)
            {
                prid = FindPRIDRecord(prid);
                transfer = true;
            }

            string pos = GetPositionName(GetDB2ValueInt("RCPT", "PPOS", prid));
            string player = GetDB2Value("RCPT", "PFNA", prid) + " " + GetDB2Value("RCPT", "PLNA", prid);
            string home = states[GetDB2ValueInt("RCPT", "RCHD", prid) / 256];
            int height = GetDB2ValueInt("RCPT", "PHGT", prid);
            int weight = GetDB2ValueInt("RCPT", "PWGT", prid) + 160;
            int ovr = ConvertRating(GetDB2ValueInt("RCPT", "POVR", prid));
            int star = GetDB2ValueInt("RCPT", "RCCB", prid);
            int posRank = GetDB2ValueInt("RCPT", "RCRK", prid);

            if (transfer)
            {
                player += " +";

                for (int i = 0; i < GetTableRecCount("TRAN"); i++)
                {
                    if (GetDBValueInt("TRAN", "PGID", i) == pgid)
                    {
                        home = teamNameDB[GetDBValueInt("TRAN", "PTID", i)];
                        break;
                    }
                }

            }

            FillRecruitTeamView(pos, player, home, height, weight, ovr, star, posRank);
        }

        private void GetTransferRankPlayer(int pgid, int ptid)
        {
            int rec = FindPGIDRecord(pgid);

            string pos = GetPositionName(GetDBValueInt("PLAY", "PPOS", rec));
            string player = GetFirstNameFromRecord(rec)+ " " + GetLastNameFromRecord(rec);
            string home = teamNameDB[ptid];
            int height = GetDBValueInt("PLAY", "PHGT", rec);
            int weight = GetDBValueInt("PLAY", "PWGT", rec) + 160;
            int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", rec));
            int posRank = 0;

            int star = 0;
            if (ovr > 87) star = 5;
            else if (ovr > 81) star = 4;
            else if (ovr > 75) star = 3;
            else if (ovr > 68) star = 2;
            else star = 1;


            FillRecruitTeamView(pos, player, home, height, weight, ovr, star, posRank);

        }

        private void FillRecruitTeamView(string pos, string player, string home, int height, int weight, int ovr, int star, int posRank)
        {
            int row = RecruitTeamView.Rows.Count;

            RecruitTeamView.Rows.Add(1);

            RecruitTeamView.Rows[row].Cells[0].Value = pos;
            RecruitTeamView.Rows[row].Cells[1].Value = player;
            RecruitTeamView.Rows[row].Cells[2].Value = home;
            RecruitTeamView.Rows[row].Cells[3].Value = (height/12) + " ft " + (height%12) + " in";
            RecruitTeamView.Rows[row].Cells[4].Value = weight + " lbs";
            RecruitTeamView.Rows[row].Cells[5].Value = ovr;
            RecruitTeamView.Rows[row].Cells[6].Value = ConvertStarNumber(star);
            RecruitTeamView.Rows[row].Cells[7].Value = posRank;

        }


        private double CalculateRecruitPoints(int five, int four, int three, int two, int one)
        {
            int points = 0;
            int total = five + four + three + two + one;

            points += five * 25 + four * 16 + three * 9 + two * 4 + one * 1;

            return (double)points;
        }

        private double CalculateRecruitAvg(int five, int four, int three, int two, int one)
        {
            int points = 0;
            int total = five + four + three + two + one;

            points += five * 5 + four * 4 + three * 3 + two * 2 + one * 1;

            return Math.Round((double)points/(double)total,2);
        }

    }

}
