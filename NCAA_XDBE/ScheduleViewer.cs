using System;
using System.Collections.Generic;
using System.Drawing;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        private void StartScheduleEditor()
        {
            ScheduleView.Rows.Clear();
            ScheduleComboBox.SelectedIndex = 0;
            LoadScheduleTeamsBox();

            int sea = GetDBValueInt("SEAI", "SEYR", 0);
            int week = GetDBValueInt("SEAI", "SEWN", 0);
            lblSCHDCurrent.Text = "Current Week: " + (sea + DynStartYear.Value) + ", Week " + week;

        }

        private void ScheduleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScheduleComboBoxChoice();
        }

        private void ScheduleComboBoxChoice()
        {
            if (ScheduleComboBox.SelectedIndex == 0) LoadScheduleTeamsBox();
            else LoadScheduleWeekBox();
        }


        private void LoadScheduleTeamsBox()
        {

            SCHDTeamBox.Items.Clear();
            List<string> teamList = new List<string>();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                    teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
            }

            teamList.Sort();

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) SCHDTeamBox.Items.Add(teamList[i]);
            }

        }

        private void LoadScheduleWeekBox()
        {

            SCHDTeamBox.Items.Clear();
            int seow = GetDBValueInt("SEAI", "SEOW", 0);

            for (int i = 0; i < seow; i++)
            {
                SCHDTeamBox.Items.Add(i);
            }

        }

        //Pick Team
        private void SCHDTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScheduleComboBox.SelectedIndex == -1) return;


            else if (ScheduleComboBox.SelectedIndex == 0)
            {
                if (SCHDTeamBox.Items.Count < 1 || SCHDTeamBox.SelectedIndex == -1)
                    return;

                int tgid = -1;
                for (int i = 0; i < teamNameDB.Length; i++)
                {
                    if (SCHDTeamBox.Text == teamNameDB[i])
                    {
                        tgid = i;
                        break;
                    }
                }

                LoadScheduleTeamView(tgid);
            }

            else
            {
                if (SCHDTeamBox.Items.Count < 1 || SCHDTeamBox.SelectedIndex == -1)
                    return;
                LoadScheduleWeekView(SCHDTeamBox.SelectedIndex);
            }
        }

        private void LoadScheduleTeamView(int tgid)
        {
            DoNotTrigger = true;

            ScheduleView.Rows.Clear();

            List<string> fcslist = new List<string>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                    fcslist.Add(GetDBValue("TEAM", "TDNA", i));
            }


            for (int i = 0; i < 23; i++)
            {
                ScheduleView.Rows.Add(new DataGridViewRow());

                ScheduleView.Rows[i].Cells[0].Value = i;
            }

            SchdTeamName.Text = teamNameDB[tgid];

            double strength = 0;
            double games = 0;
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "GATG", i) == tgid || GetDBValueInt("SCHD", "GHTG", i) == tgid)
                {
                    SCHDWeek.HeaderText = "Wk";
                    SCHDAWAY.HeaderText = "Opponent";
                    SCHDHOME.HeaderText = "Team";
                    int w = GetDBValueInt("SCHD", "SEWN", i);

                    string rankA = "";
                    int teamRecA = -1;
                    string teamNameA = "";
                    int teamRecH = -1;
                    string rankH = "";
                    string teamNameH = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];

                    if (GetDBValueInt("SCHD", "GATG", i) == tgid)
                    {

                        teamNameA = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                        teamRecA = FindTeamRecfromTeamName(teamNameA);
                        int rank = GetDBValueInt("TEAM", "TCRK", teamRecA);
                        int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                        if (sewn >= 11 && sewn < GetDBValueInt("SEAI", "SEOW", 0)) rank = GetDBValueInt("TEAM", "TBRK", teamRecA);
                        rankA = "@ ";
                        if (rank <= 25) rankA += "#" + rank + " ";

                        teamNameH = teamNameDB[tgid];
                        teamRecH = FindTeamRecfromTeamName(teamNameH);
                        rank = GetDBValueInt("TEAM", "TCRK", teamRecH);
                        if (sewn >= 11 && sewn < GetDBValueInt("SEAI", "SEOW", 0)) rank = GetDBValueInt("TEAM", "TBRK", teamRecH);
                        if (rank > 0 && rank <= 25) rankH += "#" + rank + " ";

                        if (sewn <= 16)
                        {
                            strength += GetDBValueInt("TEAM", "TROV", teamRecH);
                            games++;
                        }

                        ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GHSC", i);
                        ScheduleView.Rows[w].Cells[3].Value = GetDBValueInt("SCHD", "GASC", i);

                    }
                    else
                    {
                        teamNameA = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                        teamRecA = FindTeamRecfromTeamName(teamNameA);
                        int rank = GetDBValueInt("TEAM", "TCRK", teamRecA);
                        int sewn = GetDBValueInt("SEAI", "SEWN", 0);
                        if (sewn >= 11 && sewn < GetDBValueInt("SEAI", "SEOW", 0)) rank = GetDBValueInt("TEAM", "TBRK", teamRecA);
                        rankA = "vs ";
                        if (rank > 0 && rank <= 25) rankA += "#" + rank + " ";


                        teamNameH = teamNameDB[tgid];
                        teamRecH = FindTeamRecfromTeamName(teamNameH);
                        rank = GetDBValueInt("TEAM", "TCRK", teamRecH);
                        if (sewn >= 11 && sewn < GetDBValueInt("SEAI", "SEOW", 0)) rank = GetDBValueInt("TEAM", "TBRK", teamRecH);
                        if (rank > 0 && rank <= 25) rankH += "#" + rank + " ";

                        if (sewn <= 16)
                        {
                            strength += GetDBValueInt("TEAM", "TROV", teamRecA);
                            games++;
                        }

                        ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GASC", i);
                        ScheduleView.Rows[w].Cells[3].Value = GetDBValueInt("SCHD", "GHSC", i);
                    }

                    ScheduleView.Rows[w].Cells[1].Value = rankA + teamNameA;
                    ScheduleView.Rows[w].Cells[1].Style.BackColor = GetTeamPrimaryColor(teamRecA);
                    ScheduleView.Rows[w].Cells[1].Style.ForeColor = ChooseForeground(ScheduleView.Rows[w].Cells[1].Style.BackColor);
                    ScheduleView.Rows[w].Cells[1].Style.Font = new Font(ScheduleView.Font.FontFamily, 9, FontStyle.Bold);


                    ScheduleView.Rows[w].Cells[4].Value = rankH + teamNameH;
                    ScheduleView.Rows[w].Cells[4].Style.BackColor = GetTeamPrimaryColor(teamRecH);
                    ScheduleView.Rows[w].Cells[4].Style.ForeColor = ChooseForeground(ScheduleView.Rows[w].Cells[4].Style.BackColor);
                    ScheduleView.Rows[w].Cells[4].Style.Font = new Font(ScheduleView.Font.FontFamily, 9, FontStyle.Bold);

                    ScheduleView.Rows[w].Cells[2].Style.BackColor = Color.Black;
                    ScheduleView.Rows[w].Cells[3].Style.BackColor = Color.Black;
                    ScheduleView.Rows[w].Cells[2].Style.ForeColor = Color.WhiteSmoke;
                    ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.WhiteSmoke;



                    if (Convert.ToInt32(ScheduleView.Rows[w].Cells[2].Value) > Convert.ToInt32(ScheduleView.Rows[w].Cells[3].Value))
                    {
                        ScheduleView.Rows[w].Cells[2].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                        ScheduleView.Rows[w].Cells[2].Style.ForeColor = Color.Goldenrod;
                    }
                    else if (Convert.ToInt32(ScheduleView.Rows[w].Cells[2].Value) < Convert.ToInt32(ScheduleView.Rows[w].Cells[3].Value))
                    {
                        ScheduleView.Rows[w].Cells[3].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                        ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.Goldenrod;
                    }
                    else
                    {
                        ScheduleView.Rows[w].Cells[2].Value = "";
                        ScheduleView.Rows[w].Cells[3].Value = "";

                    }

                    if (rankH.Contains("#") && rankA.Contains("#"))
                    {
                        ScheduleView.Rows[w].Cells[5].Value = ConvertStarNumber(2);
                    }
                    else if (rankA.Contains("#"))
                    {
                        ScheduleView.Rows[w].Cells[5].Value = ConvertStarNumber(1);
                    }


                    if (fcslist.Contains(teamNameH) || fcslist.Contains(teamNameA))
                        ScheduleView.Rows[w].Cells[5].Value = "FCS";
                }
            }

            int rec = FindTeamRecfromTGID(tgid);
            SCHDrecord.Text = "Season Record: " + GetDBValue("TEAM", "TSWI", rec) + " - " + GetDBValue("TEAM", "TSLO", rec);

            string StrengthGrade = "";
            double score = Math.Round(strength / games, 2);
            if (score >= 86) StrengthGrade = "A+";
            else if (score >= 84) StrengthGrade = "A";
            else if (score >= 82) StrengthGrade = "A-";
            else if (score >= 80) StrengthGrade = "B+";
            else if (score >= 78) StrengthGrade = "B";
            else if (score >= 76) StrengthGrade = "B-";
            else if (score >= 74) StrengthGrade = "C+";
            else if (score >= 72) StrengthGrade = "C";
            else if (score >= 68) StrengthGrade = "C-";
            else if (score >= 66) StrengthGrade = "D+";
            else if (score >= 64) StrengthGrade = "D";
            else if (score >= 62) StrengthGrade = "D-";
            else StrengthGrade = "(F)";
            ScheduleStrengthLabel.Text = "Schedule Strength: " + score + " | " + StrengthGrade;

            DoNotTrigger = false;

            ScheduleView.ClearSelection();
            int currentWeek = GetDBValueInt("SEAI", "SEWN", 0);

            // Force selection and trigger the event for any row including 0
            if (currentWeek >= 0 && currentWeek < ScheduleView.Rows.Count)
            {
                // Set the current cell first (this helps with row 0 selection)
                ScheduleView.CurrentCell = ScheduleView.Rows[currentWeek].Cells[0];

                // Select the row
                //ScheduleView.Rows[currentWeek].Selected = true;

                // Manually trigger the row enter event if needed
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, currentWeek);
                ScheduleView_RowEnter(ScheduleView, args);
            }

        }

        private void LoadScheduleWeekView(int sewn)
        {
            DoNotTrigger = true;

            ScheduleView.Rows.Clear();
            SchdTeamName.Text = "Week " + sewn;
            SCHDrecord.Text = "   ";
            SCHDAWAY.HeaderText = "Away Team";
            SCHDHOME.HeaderText = "Home Team";
            ScheduleStrengthLabel.Text = "";
            List<int> GameScore = new List<int>();

            List<string> fcslist = new List<string>();
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if(GetDBValueInt("TEAM", "TTYP", i) == 1)
                fcslist.Add(GetDBValue("TEAM", "TDNA", i));
            }

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) == sewn)
                {
                    int w = ScheduleView.Rows.Count;
                    ScheduleView.Rows.Add(new DataGridViewRow());
                    ScheduleView.Rows.Add(new DataGridViewRow());
                    GameScore.Add(0);
                    GameScore.Add(0);

                    SCHDWeek.HeaderText = "   ";
                    //ScheduleView.Rows[w].Cells[0].Value = sewn;


                    string rankA = "";
                    string teamNameA = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                    int teamRecA = FindTeamRecfromTeamName(teamNameA);
                    int rank = GetDBValueInt("TEAM", "TCRK", teamRecA);
                    int sewnX = GetDBValueInt("SEAI", "SEWN", 0);
                    int seow = GetDBValueInt("SEAI", "SEOW", 0);
                    if (sewnX >= 11 && sewnX < seow) rank = GetDBValueInt("TEAM", "TBRK", teamRecA);
                    if (rank > 0 && rank <= 25) rankA = "#" + rank + " ";
                    GameScore[w] += rank;
                    ScheduleView.Rows[w].Cells[1].Value = rankA + teamNameA;
                    ScheduleView.Rows[w].Cells[1].Style.BackColor = GetTeamPrimaryColor(teamRecA);
                    ScheduleView.Rows[w].Cells[1].Style.ForeColor = ChooseForeground(ScheduleView.Rows[w].Cells[1].Style.BackColor);
                    ScheduleView.Rows[w].Cells[1].Style.Font = new Font(ScheduleView.Font.FontFamily, 10, FontStyle.Bold);


                    ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GASC", i);
                    ScheduleView.Rows[w].Cells[3].Value = GetDBValueInt("SCHD", "GHSC", i);


                    string rankH = "";
                    string teamNameH = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    int teamRecH = FindTeamRecfromTeamName(teamNameH);

                    rank = GetDBValueInt("TEAM", "TCRK", teamRecH);
                    if (sewnX >= 11 && sewnX < seow) rank = GetDBValueInt("TEAM", "TBRK", teamRecH);
                    if (rank > 0 && rank <= 25) rankH = "#" + rank + " ";
                    GameScore[w] += rank;

                    ScheduleView.Rows[w].Cells[4].Value = rankH + teamNameH;
                    ScheduleView.Rows[w].Cells[4].Style.BackColor = GetTeamPrimaryColor(teamRecH);
                    ScheduleView.Rows[w].Cells[4].Style.ForeColor = ChooseForeground(ScheduleView.Rows[w].Cells[4].Style.BackColor);
                    ScheduleView.Rows[w].Cells[4].Style.Font = new Font(ScheduleView.Font.FontFamily, 10, FontStyle.Bold);

                    ScheduleView.Rows[w].Cells[2].Style.BackColor = Color.Black;
                    ScheduleView.Rows[w].Cells[3].Style.BackColor = Color.Black;
                    ScheduleView.Rows[w].Cells[2].Style.ForeColor = Color.WhiteSmoke;
                    ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.WhiteSmoke;


                    if (GetDBValueInt("SCHD", "GASC", i) > GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[2].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                        ScheduleView.Rows[w].Cells[2].Style.ForeColor = Color.Goldenrod;
                    }
                    else if (GetDBValueInt("SCHD", "GASC", i) < GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[3].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                        ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.Goldenrod;
                    }
                    else
                    {
                        ScheduleView.Rows[w].Cells[2].Value = "";
                        ScheduleView.Rows[w].Cells[3].Value = "";

                    }

                    //Add Stars for Ranked Games
                    if (rankH.Contains("#") && rankA.Contains("#"))
                    {
                        ScheduleView.Rows[w].Cells[0].Value = ConvertStarNumber(2);
                    }
                    else if (rankH.Contains("#") || rankA.Contains("#"))
                    {
                        ScheduleView.Rows[w].Cells[0].Value = ConvertStarNumber(1);
                    }

                    if (fcslist.Contains(teamNameH) || fcslist.Contains(teamNameA))
                        ScheduleView.Rows[w].Cells[0].Value = "FCS";

                    
                }
            }

            int topW = 0;
            int lowscore = 1000;
            for(int i = 0; i < GameScore.Count; i++)
            {
                if (GameScore[i] > 0 && GameScore[i] < lowscore)
                {
                    lowscore = GameScore[i];
                    topW = i;
                }
            }

            string GOTW = ScheduleView.Rows[topW].Cells[1].Value + " vs " + ScheduleView.Rows[topW].Cells[4].Value;
            ScheduleStrengthLabel.Text = "Game of the Week: " + GOTW;

            DoNotTrigger = false;

            ScheduleView.ClearSelection();
            // Force selection and trigger the event for any row including 0
            if (topW >= 0 && topW < ScheduleView.Rows.Count)
            {
                // Set the current cell first (this helps with row 0 selection)
                ScheduleView.CurrentCell = ScheduleView.Rows[topW].Cells[0];

                // Select the row
                //ScheduleView.Rows[topW].Selected = true;

                // Manually trigger the row enter event if needed
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, topW);
                ScheduleView_RowEnter(ScheduleView, args);
            }

        }





        //Match Viewer

        private void ScheduleView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            int row = (e.RowIndex);

            string hometeam = Convert.ToString(ScheduleView.Rows[row].Cells[4].Value);
            string awayteam = Convert.ToString(ScheduleView.Rows[row].Cells[1].Value);

            List<string> homeTeamList = hometeam.Split('#').ToList();
            if (homeTeamList.Count > 1)
            {
                homeTeamList.RemoveAt(0);
                hometeam = string.Join(" ", homeTeamList).Trim();
                homeTeamList = hometeam.Split(' ').ToList();
                homeTeamList.RemoveAt(0);
                hometeam = string.Join(" ", homeTeamList).Trim();
            }

            List<string> awayTeamList = awayteam.Split('#').ToList();
            if (awayTeamList.Count > 1)
            {
                awayTeamList.RemoveAt(0);
                awayteam = string.Join(" ", awayTeamList).Trim();
                awayTeamList = awayteam.Split(' ').ToList();
                awayTeamList.RemoveAt(0);
                awayteam = string.Join(" ", awayTeamList).Trim();
            }

            awayTeamList = awayteam.Split("vs ").ToList();
            if (awayTeamList.Count > 1)
            {
                awayTeamList.RemoveAt(0);
                awayteam = string.Join(" ", awayTeamList).Trim();
            }


            awayTeamList = awayteam.Split("@ ").ToList();
            if (awayTeamList.Count > 1)
            {
                awayTeamList.RemoveAt(0);
                awayteam = string.Join(" ", awayTeamList).Trim();
            }

            int recH = FindTeamRecfromTeamName(hometeam);
            int recA = FindTeamRecfromTeamName(awayteam);

            MatchView.Rows.Clear();
            WeeklyBoxscoreView.Rows.Clear();
            WeeklyBoxscoreView.Columns.Clear();
            WeeklyHighlightView.Rows.Clear();
            WeeklyHighlightView.Columns.Clear();

            if (recH != recA)
            {
                LoadMatchViewerBox(recH, recA);
                LoadBoxScore(recH, recA);
                LoadWeeklyHighlights(recH, recA);
            }


        }

        private void LoadMatchViewerBox(int recH, int recA)
        {
            //if (DoNotTrigger) return;

            MatchView.Rows.Clear();
            List<string> categories = LoadMatchViewRatingCats();
            List<string> homeTeam = LoadTeamRatings(recH);
            List<string> awayTeam = LoadTeamRatings(recA);

            for (int i = 0; i < categories.Count; i++)
            {
                MatchView.Rows.Add(new DataGridViewRow());
                MatchView.Rows[i].Cells[0].Value = categories[i];
                MatchView.Rows[i].Cells[2].Value = homeTeam[i];
                MatchView.Rows[i].Cells[1].Value = awayTeam[i];

                if (i == 0)
                {

                    MatchView.Rows[i].Cells[1].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(awayTeam[i]));
                    MatchView.Rows[i].Cells[1].Style.ForeColor = ChooseForeground(MatchView.Rows[i].Cells[1].Style.BackColor);
                    MatchView.Rows[i].Cells[1].Style.Font = new Font(ScheduleView.Font.FontFamily, 10, FontStyle.Bold);

                    MatchView.Rows[i].Cells[2].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(homeTeam[i]));
                    MatchView.Rows[i].Cells[2].Style.ForeColor = ChooseForeground(MatchView.Rows[i].Cells[2].Style.BackColor);
                    MatchView.Rows[i].Cells[2].Style.Font = new Font(ScheduleView.Font.FontFamily, 10, FontStyle.Bold);

                }

            }
            MatchView.CellPainting += MatchView_CellPainting;
            MatchView.ClearSelection();
        }

        private List<string> LoadMatchViewRatingCats()
        {
            int sewn = GetDBValueInt("SEAI", "SEWN", 0);
            int seow = GetDBValueInt("SEAI", "SEOW", 0);

            List<string> categories = new List<string>();
            categories.Add("Teams");
            categories.Add("Record");
            if (sewn >= 11 & sewn < seow) categories.Add("Bowl Rank");
            else categories.Add("Coach Poll Rank");
            categories.Add("Team Prestige");
            categories.Add("Overall");
            categories.Add("Offense");
            categories.Add("Defense");
            categories.Add("Special Teams");
            categories.Add("Quarterback");
            categories.Add("Running Backs");
            categories.Add("Receivers");
            categories.Add("Offensive Line");
            categories.Add("Defensive Line");
            categories.Add("Linebackers");
            categories.Add("Def Backs");
            categories.Add("Coach");
            categories.Add("Playbook");
            categories.Add("Coach Prestige");
            categories.Add("Coach Hot Seat");


            return categories;
        }

        private List<string> LoadTeamRatings(int rec)
        {
            List<string> categories = new List<string>();
            int cochrec = FindCOCHRecordfromTeamTGID(GetDBValueInt("TEAM", "TGID", rec));

            categories.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", rec)]);
            categories.Add(GetDBValue("TEAM", "TSWI", rec) + " - " + GetDBValue("TEAM", "TSLO", rec));

            int sewn = GetDBValueInt("SEAI", "SEWN", 0);
            int seow = GetDBValueInt("SEAI", "SEOW", 0);
            int rank = GetDBValueInt("TEAM", "TCRK", rec);

            if (sewn >= 11 && sewn < seow) rank = GetDBValueInt("TEAM", "TBRK", rec);
            categories.Add(Convert.ToString(rank));
            categories.Add(ConvertStarNumber(GetDBValueInt("TEAM", "TMPR", rec)));
            categories.Add(GetDBValue("TEAM", "TROV", rec));
            categories.Add(GetDBValue("TEAM", "TROF", rec));
            categories.Add(GetDBValue("TEAM", "TRDE", rec));
            categories.Add(GetDBValue("TEAM", "TRST", rec));
            categories.Add(GetDBValue("TEAM", "TRQB", rec));
            categories.Add(GetDBValue("TEAM", "TRRB", rec));
            categories.Add(GetDBValue("TEAM", "TWRR", rec));
            categories.Add(GetDBValue("TEAM", "TROL", rec));
            categories.Add(GetDBValue("TEAM", "TRDL", rec));
            categories.Add(GetDBValue("TEAM", "TRLB", rec));
            categories.Add(GetDBValue("TEAM", "TRDB", rec));

            categories.Add(GetCoachFirstNamefromRec(cochrec) + " " + GetCoachLastNamefromRec(cochrec));
            categories.Add(GetPlaybookName(GetDBValueInt("COCH", "CPID", cochrec)));
            categories.Add(ConvertStarNumber(GetDBValueInt("COCH", "CPRE", cochrec)));
            categories.Add(GetDBValue("COCH", "CCPO", cochrec));


            return categories;
        }


        //Weekly Highlight Box
        /* Match Detail Viewer or Headline Box */

        private void LoadBoxScore(int recH, int recA)
        {
            WeeklyBoxscoreView.Rows.Clear();
            WeeklyBoxscoreView.Columns.Clear();
            WeeklyBoxscoreView.DefaultCellStyle.Font = new Font(WeeklyBoxscoreView.Font.FontFamily, 10, FontStyle.Bold);
            WeeklyBoxscoreView.AlternatingRowsDefaultCellStyle.Font = new Font(WeeklyBoxscoreView.Font.FontFamily, 10, FontStyle.Bold);
            WeeklyBoxscoreView.DefaultCellStyle.BackColor = Color.LightGray;
            WeeklyBoxscoreView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            WeeklyBoxscoreView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            WeeklyBoxscoreView.Columns.Add("Team", "Team");
            WeeklyBoxscoreView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            WeeklyBoxscoreView.Columns[0].MinimumWidth = 200;
            WeeklyBoxscoreView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            WeeklyBoxscoreView.Columns.Add("Q1", "Q1");
            WeeklyBoxscoreView.Columns.Add("Q2", "Q2");
            WeeklyBoxscoreView.Columns.Add("Q3", "Q3");
            WeeklyBoxscoreView.Columns.Add("Q4", "Q4");
            WeeklyBoxscoreView.Columns.Add("OT", "OT");
            WeeklyBoxscoreView.Columns.Add("Score", "Score");

            WeeklyBoxscoreView.Rows.Add(1);
            WeeklyBoxscoreView.Rows.Add(1);

            int tgidA = GetTeamTGIDfromRecord(recA);
            int tgidH = GetTeamTGIDfromRecord(recH);

            int sewn = -1;
            int sgnm = -1;

            //Find Game in SCHD
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if ((GetDBValueInt("SCHD", "GATG", i) == tgidA && GetDBValueInt("SCHD", "GHTG", i) == tgidH) || (GetDBValueInt("SCHD", "GATG", i) == tgidH && GetDBValueInt("SCHD", "GHTG", i) == tgidA))
                {
                    tgidA = GetDBValueInt("SCHD", "GATG", i);
                    tgidH = GetDBValueInt("SCHD", "GHTG", i);
                    recA = FindTeamRecfromTGID(tgidA);
                    recH = FindTeamRecfromTGID(tgidH);
                    sewn = GetDBValueInt("SCHD", "SEWN", i);
                    sgnm = GetDBValueInt("SCHD", "SGNM", i);
                    break;
                }
            }

            //Find Box Score in WQTS
            int rec = -1;
            bool ot = false;
            for (int i = 0; i < GetTableRecCount("WQTS"); i++)
            {
                if ((GetDBValueInt("WQTS", "SEWN", i) == sewn && GetDBValueInt("WQTS", "SGNM", i) == sgnm))
                {
                    rec = i;
                    break;
                }
            }

            int sewnX = GetDBValueInt("SEAI", "SEWN", 0);
            int seow = GetDBValueInt("SEAI", "SEOW", 0);

            //Away Team
            string rankA = "";
            int rank = GetDBValueInt("TEAM", "TCRK", recA);
            if (sewnX >= 11 && sewnX < seow) rank = GetDBValueInt("TEAM", "TBRK", recA);
            if (rank > 0 && rank <= 25) rankA = "#" + rank + " ";

            WeeklyBoxscoreView.Rows[0].Cells[0].Value = rankA + teamNameDB[tgidA];
            WeeklyBoxscoreView.Rows[0].Cells[0].Style.BackColor = GetTeamPrimaryColor(recA);
            WeeklyBoxscoreView.Rows[0].Cells[0].Style.ForeColor = ChooseForeground(WeeklyBoxscoreView.Rows[0].Cells[0].Style.BackColor);
            WeeklyBoxscoreView.Rows[0].Cells[0].Style.Font = new Font(WeeklyBoxscoreView.Font.FontFamily, 10, FontStyle.Bold);

            string rankH = "";
            rank = GetDBValueInt("TEAM", "TCRK", recH);
            if (sewnX >= 11 && sewnX < seow) rank = GetDBValueInt("TEAM", "TBRK", recH);
            if (rank > 0 && rank <= 25) rankH = "#" + rank + " ";

            //Home Team
            WeeklyBoxscoreView.Rows[1].Cells[0].Value = rankH + teamNameDB[tgidH];
            WeeklyBoxscoreView.Rows[1].Cells[0].Style.BackColor = GetTeamPrimaryColor(recH);
            WeeklyBoxscoreView.Rows[1].Cells[0].Style.ForeColor = ChooseForeground(WeeklyBoxscoreView.Rows[1].Cells[0].Style.BackColor);
            WeeklyBoxscoreView.Rows[1].Cells[0].Style.Font = new Font(WeeklyBoxscoreView.Font.FontFamily, 10, FontStyle.Bold);

            WeeklyBoxscoreView.ClearSelection();

            if (rec < 0) return;





            WeeklyBoxscoreView.Rows[0].Cells[1].Value = GetDBValueInt("WQTS", "GASC", rec);
            WeeklyBoxscoreView.Rows[0].Cells[2].Value = GetDBValueInt("WQTS", "GASC", rec + 1);
            WeeklyBoxscoreView.Rows[0].Cells[3].Value = GetDBValueInt("WQTS", "GASC", rec + 2);
            WeeklyBoxscoreView.Rows[0].Cells[4].Value = GetDBValueInt("WQTS", "GASC", rec + 3);

            if (GetDBValueInt("WQTS", "GASC", rec + 4) > 0 && GetDBValueInt("WQTS", "SGNM", rec + 4) == sgnm)
            {
                WeeklyBoxscoreView.Rows[0].Cells[5].Value = GetDBValueInt("WQTS", "GASC", rec + 4);
                WeeklyBoxscoreView.Rows[0].Cells[6].Value = GetDBValueInt("WQTS", "GASC", rec) + GetDBValueInt("WQTS", "GASC", rec + 1) + GetDBValueInt("WQTS", "GASC", rec + 2) + GetDBValueInt("WQTS", "GASC", rec + 3) + GetDBValueInt("WQTS", "GASC", rec + 4);
                ot = true;
            }
            else
            {
                WeeklyBoxscoreView.Columns.Remove("OT");
                WeeklyBoxscoreView.Rows[0].Cells[5].Value = GetDBValueInt("WQTS", "GASC", rec) + GetDBValueInt("WQTS", "GASC", rec + 1) + GetDBValueInt("WQTS", "GASC", rec + 2) + GetDBValueInt("WQTS", "GASC", rec + 3);
            }

            WeeklyBoxscoreView.Rows[1].Cells[1].Value = GetDBValueInt("WQTS", "GHSC", rec);
            WeeklyBoxscoreView.Rows[1].Cells[2].Value = GetDBValueInt("WQTS", "GHSC", rec + 1);
            WeeklyBoxscoreView.Rows[1].Cells[3].Value = GetDBValueInt("WQTS", "GHSC", rec + 2);
            WeeklyBoxscoreView.Rows[1].Cells[4].Value = GetDBValueInt("WQTS", "GHSC", rec + 3);

            if (ot)
            {
                WeeklyBoxscoreView.Rows[1].Cells[5].Value = GetDBValueInt("WQTS", "GHSC", rec + 4);
                WeeklyBoxscoreView.Rows[1].Cells[6].Value = GetDBValueInt("WQTS", "GHSC", rec) + GetDBValueInt("WQTS", "GHSC", rec + 1) + GetDBValueInt("WQTS", "GHSC", rec + 2) + GetDBValueInt("WQTS", "GHSC", rec + 3) + GetDBValueInt("WQTS", "GHSC", rec + 4);
            }
            else
            {
                WeeklyBoxscoreView.Rows[1].Cells[5].Value = GetDBValueInt("WQTS", "GHSC", rec) + GetDBValueInt("WQTS", "GHSC", rec + 1) + GetDBValueInt("WQTS", "GHSC", rec + 2) + GetDBValueInt("WQTS", "GHSC", rec + 3);
            }



            WeeklyBoxscoreView.ClearSelection();

        }

        private void LoadWeeklyHighlights(int recH, int recA)
        {
            WeeklyHighlightView.Rows.Clear();
            WeeklyHighlightView.Columns.Clear();

            WeeklyHighlightView.DefaultCellStyle.Font = new Font(WeeklyHighlightView.Font.FontFamily, 8);
            WeeklyHighlightView.AlternatingRowsDefaultCellStyle.Font = new Font(WeeklyHighlightView.Font.FontFamily, 8);
            WeeklyHighlightView.Columns.Add("Player", "Player");
            WeeklyHighlightView.Columns.Add("Highlight", "Highlight");
            WeeklyHighlightView.Columns[1].MinimumWidth = 275;
            WeeklyHighlightView.Columns[0].MinimumWidth = 80;
            WeeklyHighlightView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            WeeklyHighlightView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            WeeklyHighlightView.ColumnHeadersVisible = false;

            int tgidA = GetTeamTGIDfromRecord(recA);
            int tgidH = GetTeamTGIDfromRecord(recH);

            int sewn = -1;
            int sgnm = -1;

            //Find Game in SCHD
            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if ((GetDBValueInt("SCHD", "GATG", i) == tgidA && GetDBValueInt("SCHD", "GHTG", i) == tgidH) || (GetDBValueInt("SCHD", "GATG", i) == tgidH && GetDBValueInt("SCHD", "GHTG", i) == tgidA))
                {
                    sewn = GetDBValueInt("SCHD", "SEWN", i);
                    sgnm = GetDBValueInt("SCHD", "SGNM", i);
                    break;
                }
            }

            //Find Highlights in PLAC
            int rec = -1;
            int row = -1;
            for (int i = 0; i < GetTableRecCount("PLAC"); i++)
            {
                if ((GetDBValueInt("PLAC", "SEWN", i) == sewn && GetDBValueInt("PLAC", "SGNM", i) == sgnm))
                {
                    row++;
                    WeeklyHighlightView.Rows.Add(1);
                    int pgid = GetDBValueInt("PLAC", "PGID", i);
                    int tgid = pgid / 70;
                    int recP = FindPGIDRecord(pgid);
                    string ppos = Positions[GetDBValueInt("PLAY", "PPOS", recP)];
                    int ovr = ConvertRating(GetDBValueInt("PLAY", "POVR", recP));
                    string highlight = GetHighlights(i);

                    WeeklyHighlightView.Rows[row].Cells[0].Value = ppos + " " + GetPlayerNamefromPGID(pgid);
                    WeeklyHighlightView.Rows[row].Cells[1].Value = highlight;
                    WeeklyHighlightView.Rows[row].Cells[0].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTGID(tgid));
                    WeeklyHighlightView.Rows[row].Cells[0].Style.ForeColor = ChooseForeground(WeeklyHighlightView.Rows[row].Cells[0].Style.BackColor);
                    WeeklyHighlightView.Rows[row].Cells[1].Style.BackColor = Color.LightGray;
                }

                if (row > 3) break;
            }

            WeeklyHighlightView.ClearSelection();
        }

        private string GetHighlights(int rec)
        {
            string highlights = "";

            int PAty = GetDBValueInt("PLAC", "PAty", rec);

            int stat0 = GetDBValueInt("PLAC", "PAcC", rec);
            int stat1 = GetDBValueInt("PLAC", "PAsC", rec);
            int stat2 = GetDBValueInt("PLAC", "PAcS", rec);
            int stat3 = GetDBValueInt("PLAC", "PAsS", rec);
            int stat4 = GetDBValueInt("PLAC", "PAcV", rec);
            int stat5 = GetDBValueInt("PLAC", "PAsV", rec);
            int stat6 = GetDBValueInt("PLAC", "PAas", rec);
            int stat7 = GetDBValueInt("PLAC", "PAat", rec);

            if (PAty == 0) //All-Purpose Highlight
            {
                return highlights = "" + (stat2 + stat3 + stat5) + " all-purpose yards and " + stat0 + " TDs";
            }
            else if (PAty == 1) //Returns
            {
                return highlights = "" + stat2 + " PR yards and " + stat3 + " KR yards with " + stat4 + " TDs";
            }
            else if (PAty == 2) //QB1
            {
                return highlights = "" + stat1 + "/" + stat5 + " " + stat3 + " yards, " + stat4 + " TDs and " + stat0 + " rush yds";

            }
            else if (PAty == 3) //QB1
            {
                return highlights = "" + stat1 + "/" + stat5 + " " + stat3 + " yards, " + stat4 + " TDs and " + stat0 + " rush yds";
            }
            else if (PAty == 5) //RB1
            {
                return highlights = "" + stat1 + " carries " + stat5 + " yds, " + stat0 + " TDs. " + stat3 + " rec " + stat2 + " yds " + stat4 + " TDs.";
            }
            else if (PAty == 6) //RB2
            {
                return highlights = "" + stat1 + " carries " + stat5 + " yds. " + stat0 + " TDs";
            }
            else if (PAty == 7) //WR1
            {
                return highlights = "" + stat3 + " rec " + stat2 + " yds " + stat4 + " TDs";
            }
            else if (PAty == 8) //Def1
            {
                return highlights = "" + stat1 + " tkls, " + stat4 + " TFLs and " + stat3 + " sacks and " + stat2 + " ints";
            }
            else if (PAty == 9) //Def1
            {
                return highlights = "" + stat1 + " tkls, " + stat4 + " TFLs and " + stat3 + " sacks and " + stat2 + " ints";
            }
            else if (PAty == 10) //kicking
            {
                return highlights = "" + stat0 + "/" + stat2 + " XPs and " + stat1 + "/" + stat5 + " FGs with a long of " + stat3 + " yds.";
            }
            return highlights;
        }


        //Colorizations
        private void MatchView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only paint value bars for rows 3 to 13 (index 2 to 14) and columns 1 and 2 (team ratings)
            if (e.RowIndex >= 4 && e.RowIndex <= 14 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                // Get the value as integer
                if (int.TryParse(Convert.ToString(e.FormattedValue), out int value))
                {
                    // Define min/max for the bar (adjust as needed)
                    int min = 40;
                    int max = 99;

                    // Calculate bar width
                    int barWidth = (int)((e.CellBounds.Width - 2) * (value - min) / (float)(max - min));
                    barWidth = Math.Max(0, Math.Min(barWidth, e.CellBounds.Width - 2));

                    Color col = GetColorRating(value);


                    // Draw the bar
                    Rectangle barRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, barWidth, e.CellBounds.Height - 2);
                    using (Brush b = new SolidBrush(col))
                    {
                        e.Graphics.FillRectangle(b, barRect);
                    }

                    // Draw the value as text on top of the bar
                    TextRenderer.DrawText(
                        e.Graphics,
                        value.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        Color.Black,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                    );
                }
                // Only paint value bars for rows 3 to 13 (index 2 to 14) and columns 1 and 2 (team ratings)
            }
            else if (e.RowIndex == 18 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
            {
                e.Handled = true;
                e.PaintBackground(e.ClipBounds, true);

                // Get the value as integer
                if (int.TryParse(Convert.ToString(e.FormattedValue), out int value))
                {
                    // Define min/max for the bar (adjust as needed)
                    int min = 0;
                    int max = 99;

                    // Calculate bar width
                    int barWidth = (int)((e.CellBounds.Width - 2) * (value - min) / (float)(max - min));
                    barWidth = Math.Max(0, Math.Min(barWidth, e.CellBounds.Width - 2));

                    Color col = GetColorValueFullRange(value);


                    // Draw the bar
                    Rectangle barRect = new Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, barWidth, e.CellBounds.Height - 2);
                    using (Brush b = new SolidBrush(col))
                    {
                        e.Graphics.FillRectangle(b, barRect);
                    }

                    // Draw the value as text on top of the bar
                    TextRenderer.DrawText(
                        e.Graphics,
                        value.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        Color.Black,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                    );
                }
            }
            else
            {
                // If not a number, just draw the text
                e.PaintContent(e.ClipBounds);
            }

        }

    }

}
