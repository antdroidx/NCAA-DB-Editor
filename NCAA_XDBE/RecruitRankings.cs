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
            LoadRecruitRankingViewNew(RecruitRankingComboBox.SelectedIndex);

        }

        private void LoadRecruitRankingViewNew(int view)
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

            if (view <= 1) RecruitHomeTeam.HeaderText = "Home";
            else if (view == 2) RecruitHomeTeam.HeaderText = "Prev";


            List<List<int>> teamRecruits = new List<List<int>>();
            for (int i = 0; i < 512; i++)
            {
                teamRecruits.Add(new List<int>() { i, 0, 0, 0, 0, 0 }); // TGID, one, two, three, four, five
            }
            
            List<int> playTable = new List<int>();
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                playTable.Add(GetDBValueInt("PLAY", "PGID", i));
            }


            if (!Next26Mod && !NextMod)
            {
                StartProgressBar(GetTable2RecCount("RCTC"));
                for (int i = 0; i < GetTable2RecCount("RCTC"); i++)
                {

                    int tgid = GetDB2ValueInt("RCTC", "TGID", i);

                    if (view == 0) //All View
                    {
                        teamRecruits[tgid][5] = GetDB2ValueInt("RCTC", "RC5S", i);
                        teamRecruits[tgid][4] = GetDB2ValueInt("RCTC", "RC4S", i);
                        teamRecruits[tgid][3] = GetDB2ValueInt("RCTC", "RC3S", i) + GetDB2ValueInt("RCTC", "RTC3", i);
                        teamRecruits[tgid][2] = GetDB2ValueInt("RCTC", "RC2S", i) + GetDB2ValueInt("RCTC", "RTC2", i);
                        teamRecruits[tgid][1] = GetDB2ValueInt("RCTC", "RC1S", i) + GetDB2ValueInt("RCTC", "RTC1", i);
                    }
                    else if (view == 1)  //recruits only
                    {
                        teamRecruits[tgid][5] = GetDB2ValueInt("RCTC", "RC5S", i);
                        teamRecruits[tgid][4] = GetDB2ValueInt("RCTC", "RC4S", i);
                        teamRecruits[tgid][3] = GetDB2ValueInt("RCTC", "RC3S", i);
                        teamRecruits[tgid][2] = GetDB2ValueInt("RCTC", "RC2S", i);
                        teamRecruits[tgid][1] = GetDB2ValueInt("RCTC", "RC1S", i);
                    }
                    else  //Transfers Only
                    {
                        teamRecruits[tgid][5] = 0;
                        teamRecruits[tgid][4] = 0;
                        teamRecruits[tgid][3] = GetDB2ValueInt("RCTC", "RTC3", i);
                        teamRecruits[tgid][2] = GetDB2ValueInt("RCTC", "RTC2", i);
                        teamRecruits[tgid][1] = GetDB2ValueInt("RCTC", "RTC1", i);
                    }
                    
                    ProgressBarStep();
                }
                EndProgressBar();
            }
            else
            {
                if (view == 0) //All Recruits
                {
                    StartProgressBar(GetTable2RecCount("RCPR") + GetTableRecCount("TRAN"));
                    //check DB2 First
                    for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        int ptcm = GetDB2ValueInt("RCPR", "PTCM", x);
                        int star = GetDB2ValueInt("RCPT", "RCCB", x);

                        teamRecruits[ptcm][star]++;

                        //Remove returning transfers if box not checked
                        if (!IncludeReturningTransfersBox.Checked && prid >= 21000)
                        {
                            for (int tran = 0; tran < GetTableRecCount("TRAN"); tran++)
                            {
                                int ptid = GetDBValueInt("TRAN", "PTID", tran);

                                if (GetDBValueInt("TRAN", "PGID", tran) == prid)
                                {
                                    if (ptid == ptcm)
                                    {
                                        teamRecruits[ptcm][star]--;
                                    }
                                    break;
                                }
                            }
                        }
                        ProgressBarStep();
                    }

                    //Check DB1
                    for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                    {
                        int tgid = GetDBValueInt("TRAN", "PGID", x) / 70;
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        int rec = FindTRANRecFromPlayList(GetDBValueInt("TRAN", "PGID", x), playTable);
                        int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", rec));
                        int star = 0;
                        if (ovr >= 86) star = 5;
                        else if (ovr >= 80) star = 4;
                        else if (ovr >= 74) star = 3;
                        else if (ovr >= 68) star = 2;
                        else star = 1;

                        teamRecruits[tgid][star]++;

                        if (ptid == tgid && !IncludeReturningTransfersBox.Checked)
                        {
                            teamRecruits[tgid][star]--;
                        }
                        ProgressBarStep();
                    }
                }
                //Recruits Only
                else if (view == 1)
                {
                    StartProgressBar(GetTable2RecCount("RCPR"));
                    //check DB2
                    for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        int ptcm = GetDB2ValueInt("RCPR", "PTCM", x);
                        if (prid < 21000)
                        {
                            int star = GetDB2ValueInt("RCPT", "RCCB", x);
                            teamRecruits[ptcm][star]++;
                        }
                        ProgressBarStep();  
                    }
                }
                //Transfers Only
                else
                {
                    StartProgressBar(GetTable2RecCount("RCPR") + GetTableRecCount("TRAN"));
                    //check DB2
                    for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        int ptcm = GetDB2ValueInt("RCPR", "PTCM", x);
                        if (prid >= 21000)
                        {
                            int star = GetDB2ValueInt("RCPT", "RCCB", x);
                            teamRecruits[ptcm][star]++;
                            //Remove returning transfers if box not checked
                            if (!IncludeReturningTransfersBox.Checked)
                            {
                                for (int tran = 0; tran < GetTableRecCount("TRAN"); tran++)
                                {
                                    int ptid = GetDBValueInt("TRAN", "PTID", tran);
                                    if (GetDBValueInt("TRAN", "PGID", tran) == prid)
                                    {
                                        if (ptid == ptcm)
                                        {
                                            teamRecruits[ptcm][star]--;
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                        ProgressBarStep();
                    }


                    //Check DB1
                    for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                    {
                        int tgid = GetDBValueInt("TRAN", "PGID", x) / 70;
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        int rec = FindTRANRecFromPlayList(GetDBValueInt("TRAN", "PGID", x), playTable);
                        int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", rec));
                        int star = 0;
                        if (ovr >= 86) star = 5;
                        else if (ovr >= 80) star = 4;
                        else if (ovr >= 74) star = 3;
                        else if (ovr >= 68) star = 2;
                        else star = 1;

                        teamRecruits[tgid][star]++;

                        if (ptid == tgid && !IncludeReturningTransfersBox.Checked)
                        {
                            teamRecruits[tgid][star]--;
                        }
                        ProgressBarStep();  
                    }
                }
            }

            EndProgressBar();

            StartProgressBar(512);
            //Add to Recruit Ranking View
            for (int i = 0; i < teamRecruits.Count; i++)
            {
                int one = teamRecruits[i][1];
                int two = teamRecruits[i][2];
                int three = teamRecruits[i][3];
                int four = teamRecruits[i][4];
                int five = teamRecruits[i][5];

                if (one + two + three + four + five > 0)
                {
                    FillRecruitRankingView(i, five, four, three, two, one);
                }

                ProgressBarStep();
            }

            RecruitRankingView.Sort(RecruitRankingPts, System.ComponentModel.ListSortDirection.Descending);

            for (int r = 0; r < RecruitRankingView.Rows.Count; r++)
            {
                RecruitRankingView.Rows[r].Cells[0].Value = r + 1;
            }

            EndProgressBar();
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

                    if (!Next26Mod && !NextMod)
                    {
                        five = GetDB2ValueInt("RCTC", "RC5S", i);
                        four = GetDB2ValueInt("RCTC", "RC4S", i);
                        three = GetDB2ValueInt("RCTC", "RC3S", i) + GetDB2ValueInt("RCTC", "RTC3", i);
                        two = GetDB2ValueInt("RCTC", "RC2S", i) + GetDB2ValueInt("RCTC", "RTC2", i);
                        one = GetDB2ValueInt("RCTC", "RC1S", i) + GetDB2ValueInt("RCTC", "RTC1", i);

                    }
                    //Remove returning recruits if box not checked
                    else
                    {
                        //check DB2
                        for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                        {
                            int prid = GetDB2ValueInt("RCPR", "PRID", x);
                            int ptcm = GetDB2ValueInt("RCPR", "PTCM", x);

                            if (ptcm == tgid)
                            {
                                int star = GetDB2ValueInt("RCPT", "RCCB", x);

                                if (star == 5) five++;
                                if (star == 4) four++;
                                if (star == 3) three++;
                                if (star == 2) two++;
                                if (star == 1) one++;

                                //Remove returning transfers if box not checked
                                if (!IncludeReturningTransfersBox.Checked && prid >= 21000)
                                {
                                    for (int tran = 0; tran < GetTableRecCount("TRAN"); tran++)
                                    {
                                        int ptid = GetDBValueInt("TRAN", "PTID", tran);

                                        if (GetDBValueInt("TRAN", "PGID", tran) == prid)
                                        {
                                            if (ptid == tgid)
                                            {
                                                if (star == 5) five--;
                                                if (star == 4) four--;
                                                if (star == 3) three--;
                                                if (star == 2) two--;
                                                if (star == 1) one--;
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        //Check DB1
                        for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                        {
                            if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69)
                            {
                                int ptid = GetDBValueInt("TRAN", "PTID", x);
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


                                if (ptid == tgid && !IncludeReturningTransfersBox.Checked)
                                {
                                    if (star == 5) five--;
                                    if (star == 4) four--;
                                    if (star == 3) three--;
                                    if (star == 2) two--;
                                    if (star == 1) one--;
                                }
                            }
                        }
                    }

                }
                else if (view == 1)  //recruits only
                {
                    RecruitHomeTeam.HeaderText = "State";

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
                else  //Transfers Only
                {
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

                        //check DB2
                        for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                        {
                            int prid = GetDB2ValueInt("RCPR", "PRID", x);
                            int ptcm = GetDB2ValueInt("RCPR", "PTCM", x);

                            if (ptcm == tgid && prid >= 21000)
                            {
                                int star = GetDB2ValueInt("RCPT", "RCCB", x);

                                if (star == 5) five++;
                                if (star == 4) four++;
                                if (star == 3) three++;
                                if (star == 2) two++;
                                if (star == 1) one++;

                                //Remove returning transfers if box not checked
                                if (!IncludeReturningTransfersBox.Checked)
                                {
                                    for (int tran = 0; tran < GetTableRecCount("TRAN"); tran++)
                                    {
                                        int ptid = GetDBValueInt("TRAN", "PTID", tran);

                                        if (GetDBValueInt("TRAN", "PGID", tran) == prid)
                                        {
                                            if (ptid == tgid)
                                            {
                                                if (star == 5) five--;
                                                if (star == 4) four--;
                                                if (star == 3) three--;
                                                if (star == 2) two--;
                                                if (star == 1) one--;
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        //Check DB1
                        for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                        {
                            if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69)
                            {
                                int ptid = GetDBValueInt("TRAN", "PTID", x);
                                int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", FindPGIDRecord(GetDBValueInt("TRAN", "PGID", x))));
                                int star = 0;
                                if (ovr >= 86) star = 5;
                                else if (ovr >= 80) star = 4;
                                else if (ovr >= 74) star = 3;
                                else if (ovr >= 68) star = 2;
                                else star = 1;

                                if (ptid == tgid && !IncludeReturningTransfersBox.Checked)
                                {
                                    if (star == 5) five--;
                                    if (star == 4) four--;
                                    if (star == 3) three--;
                                    if (star == 2) two--;
                                    if (star == 1) one--;
                                }
                                else
                                {
                                    if (star == 5) five++;
                                    if (star == 4) four++;
                                    if (star == 3) three++;
                                    if (star == 2) two++;
                                    if (star == 1) one++;
                                }
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
            RecruitRankingView.Rows[row].Cells[2].Value = one + two + three + four + five;
            RecruitRankingView.Rows[row].Cells[3].Value = five;
            RecruitRankingView.Rows[row].Cells[4].Value = four;
            RecruitRankingView.Rows[row].Cells[5].Value = three;
            RecruitRankingView.Rows[row].Cells[6].Value = two;
            RecruitRankingView.Rows[row].Cells[7].Value = one;
            RecruitRankingView.Rows[row].Cells[8].Value = (double)CalculateRecruitPoints(five, four, three, two, one);
            RecruitRankingView.Rows[row].Cells[9].Value = (double)CalculateRecruitAvg(five, four, three, two, one);
        }

        private void RecruitRankingView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int col = (e.ColumnIndex);
            if (col >= 8)
            {
                if (RecruitRankingView.Columns[col].HeaderCell.SortGlyphDirection == SortOrder.Ascending)
                {
                    for (int r = RecruitRankingView.Rows.Count; r > 0; r--)
                    {
                        RecruitRankingView.Rows[RecruitRankingView.Rows.Count - r].Cells[0].Value = r;
                    }

                }
                else
                {

                    for (int r = 0; r < RecruitRankingView.Rows.Count; r++)
                    {
                        RecruitRankingView.Rows[r].Cells[0].Value = r + 1;
                    }
                }

            }
        }

        //RECRUIT TEAM VIEW

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

            //All View
            if (RecruitRankingComboBox.SelectedIndex == 0)
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Overall Combined Class";
                progressBar1.Maximum = GetTable2RecCount("RCPR") + GetTableRecCount("TRAN");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && IncludeReturningTransfersBox.Checked)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        GetRecruitRankPlayer(x);
                    }
                    else if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && !IncludeReturningTransfersBox.Checked)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid >= 21000)
                        {
                            bool sameTeam = CheckTransferTeam(tgid, prid);
                            if (!sameTeam) GetRecruitRankPlayer(x);
                        }
                        else
                        {
                            GetRecruitRankPlayer(x);

                        }
                    }

                    ProgressBarStep();
                }

                for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                {
                    if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69 && IncludeReturningTransfersBox.Checked)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);

                        GetTransferRankPlayer(pgid, ptid);
                    }
                    else if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69 && !IncludeReturningTransfersBox.Checked)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        if (ptid != tgid) GetTransferRankPlayer(pgid, ptid);
                    }
                    ProgressBarStep();
                }

            }
            //Recruits Only View
            else if (RecruitRankingComboBox.SelectedIndex == 1)
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Recruiting Class";
                progressBar1.Maximum = GetTable2RecCount("RCTC");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid < 21000) GetRecruitRankPlayer(x);
                    }
                    ProgressBarStep();

                }

            }
            //Transfers Only View
            else
            {
                RecruitTeamName.Text = teamNameDB[tgid] + " Transfer Class";
                progressBar1.Maximum = GetTable2RecCount("RCPR") + GetTableRecCount("TRAN");

                for (int x = 0; x < GetTable2RecCount("RCPR"); x++)
                {
                    if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && IncludeReturningTransfersBox.Checked)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid >= 21000) GetRecruitRankPlayer(x);
                    }
                    else if (GetDB2ValueInt("RCPR", "PTCM", x) == tgid && !IncludeReturningTransfersBox.Checked)
                    {
                        int prid = GetDB2ValueInt("RCPR", "PRID", x);
                        if (prid >= 21000)
                        {
                            bool sameTeam = CheckTransferTeam(tgid, prid);
                            if (!sameTeam) GetRecruitRankPlayer(x);
                        }
                    }

                    ProgressBarStep();

                }

                for (int x = 0; x < GetTableRecCount("TRAN"); x++)
                {
                    if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69 && IncludeReturningTransfersBox.Checked)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);

                        GetTransferRankPlayer(pgid, ptid);
                    }
                    else if (GetDBValueInt("TRAN", "PGID", x) >= tgid * 70 && GetDBValueInt("TRAN", "PGID", x) <= tgid * 70 + 69 && !IncludeReturningTransfersBox.Checked)
                    {
                        int pgid = GetDBValueInt("TRAN", "PGID", x);
                        int ptid = GetDBValueInt("TRAN", "PTID", x);
                        if (ptid != tgid) GetTransferRankPlayer(pgid, ptid);
                    }

                    ProgressBarStep();

                }
            }

            RecruitTeamView.Sort(RecruitTeamOVR, System.ComponentModel.ListSortDirection.Descending);
            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void GetRecruitRankPlayer(int x)
        {
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);
            bool transfer = false;
            int prid = GetDB2ValueInt("RCPR", "PRID", x);

            if (prid >= 21000)
            {
                prid = FindPRIDRecord(prid);
                transfer = true;
            }

            string pos = GetPositionName(GetDB2ValueInt("RCPT", "PPOS", x));
            string player = GetDB2Value("RCPT", "PFNA", x) + " " + GetDB2Value("RCPT", "PLNA", x);
            string home = states[GetDB2ValueInt("RCPT", "RCHD", x) / 256];
            int height = GetDB2ValueInt("RCPT", "PHGT", x);
            int weight = GetDB2ValueInt("RCPT", "PWGT", x) + 160;
            int ovr = ConvertRating(GetDB2ValueInt("RCPT", "POVR", x));
            int star = GetDB2ValueInt("RCPT", "RCCB", x);
            int posRank = GetDB2ValueInt("RCPT", "RCRK", x);

            if (transfer)
            {
                player += " +";

                for (int i = 0; i < GetTableRecCount("TRAN"); i++)
                {
                    if (GetDBValueInt("TRAN", "PGID", i) == prid)
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
            string player = GetFirstNameFromRecord(rec) + " " + GetLastNameFromRecord(rec);
            string home = teamNameDB[ptid];
            int height = GetDBValueInt("PLAY", "PHGT", rec);
            int weight = GetDBValueInt("PLAY", "PWGT", rec) + 160;
            int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", rec));
            int posRank = 0;

            int star = 0;
            if (ovr >= 86) star = 5;
            else if (ovr >= 80) star = 4;
            else if (ovr >= 74) star = 3;
            else if (ovr >= 68) star = 2;
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
            RecruitTeamView.Rows[row].Cells[3].Value = (height / 12) + " ft " + (height % 12) + " in";
            RecruitTeamView.Rows[row].Cells[4].Value = weight + " lbs";
            RecruitTeamView.Rows[row].Cells[5].Value = ovr;
            RecruitTeamView.Rows[row].Cells[6].Value = ConvertStarNumber(star);
            RecruitTeamView.Rows[row].Cells[7].Value = posRank + 1;

        }


        private double CalculateRecruitPoints(int five, int four, int three, int two, int one)
        {
            double points = 0;
            int total = five + four + three + two + one;

            List<double> starValues = new List<double>();
            for (int i = 0; i < total; i++)
            {
                if (five > 0)
                {
                    starValues.Add(25);
                    five--;
                }
                else if (four > 0)
                {
                    starValues.Add(20);
                    four--;
                }
                else if (three > 0)
                {
                    starValues.Add(15);
                    three--;
                }
                else if (two > 0)
                {
                    starValues.Add(10);
                    two--;
                }
                else
                {
                    starValues.Add(5);
                    one--;
                }
            }

            for (double x = total; x > 0; x--)
            {
                double slotFactor = x / total;
                double rankFactor = Math.Pow(slotFactor, 0.482 / slotFactor);
                points += (double)(starValues[total - Convert.ToInt32(x)] * rankFactor);
            }

            return Math.Round((double)points, 2);
        }

        private double CalculateRecruitAvg(int five, int four, int three, int two, int one)
        {
            double points = 0;
            int total = five + four + three + two + one;

            points += five * 110 + four * 97 + three * 89 + two * 83 + one * 70;

            return Math.Round((double)points / (double)total, 2);
        }

        private bool CheckTransferTeam(int tgid, int prid)
        {
            bool sameTeam = false;

            for (int x = 0; x < GetTableRecCount("TRAN"); x++)
            {
                if (GetDBValueInt("TRAN", "PGID", x) == prid)
                {
                    int ptid = GetDBValueInt("TRAN", "PTID", x);

                    if (ptid == tgid)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return sameTeam;
        }

        private int FindTRANRecFromPlayList(int pgid, List<int> playTable)
        {
            int rec = -1;
            for (int i = 0; i < playTable.Count; i++)
            {
                if (pgid == playTable[i]) return i;
            }

            return rec;
        }

    }

}
