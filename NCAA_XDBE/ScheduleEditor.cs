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

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        private void StartScheduleEditor()
        {
            DoNotTrigger = true;
            ScheduleView.Rows.Clear();
            LoadScheduleTeamsBox();
            //LoadScheduleView();

            DoNotTrigger = false;
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

        //Pick Team
        private void SCHDTeamBox_SelectedIndexChanged(object sender, EventArgs e)
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

            LoadScheduleView(tgid);
        }

        private void LoadScheduleView(int tgid)
        {
            ScheduleView.Rows.Clear();

            for (int i = 0; i < 23; i++)
            {
                ScheduleView.Rows.Add(new DataGridViewRow());

                ScheduleView.Rows[i].Cells[0].Value = i;
            }

            SchdTeamName.Text = teamNameDB[tgid];

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if(GetDBValueInt("SCHD", "GATG", i) == tgid || GetDBValueInt("SCHD", "GHTG", i) == tgid)
                {
                    int w = GetDBValueInt("SCHD", "SEWN", i);
                    ScheduleView.Rows[w].Cells[1].Value = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GHSC", i);
                    ScheduleView.Rows[w].Cells[3].Value = "vs";
                    ScheduleView.Rows[w].Cells[4].Value = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                    ScheduleView.Rows[w].Cells[5].Value = GetDBValueInt("SCHD", "GASC", i);

                    if(GetDBValueInt("SCHD", "GHTG", i) == tgid)
                    {
                        ScheduleView.Rows[w].Cells[4].Style.Font = new Font(FontFamily.GenericSansSerif, emSize:10, FontStyle.Bold);
                    }
                    else
                    {
                        ScheduleView.Rows[w].Cells[1].Style.Font = new Font(FontFamily.GenericSansSerif, emSize:10, FontStyle.Bold);
                    }
                }
            }

            int rec = FindTeamRecfromTeamName(teamNameDB[tgid]);
            SCHDrecord.Text = "Season Record: " + GetDBValue("TEAM", "TSWI", rec) + " - " + GetDBValue("TEAM", "TSLO", rec);

        }

        //Match Viewer

        private void ScheduleView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            int row = (e.RowIndex);

            string hometeam = Convert.ToString(ScheduleView.Rows[row].Cells[1].Value);
            string awayteam = Convert.ToString(ScheduleView.Rows[row].Cells[4].Value);

            int recH = FindTeamRecfromTeamName(hometeam);
            int recA = FindTeamRecfromTeamName(awayteam);

            LoadMatchViewerBox(recH, recA);
        }

        private void LoadMatchViewerBox(int recH, int recA)
        {
            if (DoNotTrigger) return;

            MatchView.Rows.Clear();
            List<string> categories = LoadMatchViewRatingCats();
            List<string> homeTeam = LoadTeamRatings(recH);
            List<string> awayTeam = LoadTeamRatings(recA);

            for (int i = 0; i < categories.Count; i++)
            {
                MatchView.Rows.Add(new DataGridViewRow());
                MatchView.Rows[i].Cells[0].Value = categories[i];
                MatchView.Rows[i].Cells[1].Value = homeTeam[i];
                MatchView.Rows[i].Cells[2].Value = awayTeam[i];
                if (i > 2 && i < 14)
                {
                    MatchView.Rows[i].Cells[1].Style.BackColor = GetDataGridTextColor(MatchView.Rows[i].Cells[1]).Style.BackColor;
                    MatchView.Rows[i].Cells[2].Style.BackColor = GetDataGridTextColor(MatchView.Rows[i].Cells[2]).Style.BackColor;


                    if (Convert.ToInt32(MatchView.Rows[i].Cells[1].Value) > Convert.ToInt32(MatchView.Rows[i].Cells[2].Value))
                    {
                        MatchView.Rows[i].Cells[2].Style.ForeColor = Color.Gray;
                        MatchView.Rows[i].Cells[1].Style.Font = new Font(MatchView.Font, FontStyle.Bold);

                    }
                    else if (Convert.ToInt32(MatchView.Rows[i].Cells[1].Value) < Convert.ToInt32(MatchView.Rows[i].Cells[2].Value))
                    {
                        MatchView.Rows[i].Cells[1].Style.ForeColor = Color.Gray;
                        MatchView.Rows[i].Cells[2].Style.Font = new Font(MatchView.Font, FontStyle.Bold);

                    }
                    else
                    {
                        MatchView.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                        MatchView.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                    }
                }
                else if (i == 1 || i == 15)
                {
                    MatchView.Rows[i].Cells[1].Style.BackColor = GetDataGridPrestigeTextColor(MatchView.Rows[i].Cells[1]).Style.BackColor;
                    MatchView.Rows[i].Cells[2].Style.BackColor = GetDataGridPrestigeTextColor(MatchView.Rows[i].Cells[2]).Style.BackColor;

                    if (Convert.ToInt32(MatchView.Rows[i].Cells[1].Value) > Convert.ToInt32(MatchView.Rows[i].Cells[2].Value))
                    {
                        MatchView.Rows[i].Cells[2].Style.ForeColor = Color.Gray;
                        MatchView.Rows[i].Cells[1].Style.Font = new Font(MatchView.Font, FontStyle.Bold);

                    }
                    else if (Convert.ToInt32(MatchView.Rows[i].Cells[1].Value) < Convert.ToInt32(MatchView.Rows[i].Cells[2].Value))
                    {
                        MatchView.Rows[i].Cells[1].Style.ForeColor = Color.Gray;
                        MatchView.Rows[i].Cells[2].Style.Font = new Font(MatchView.Font, FontStyle.Bold);

                    }
                    else
                    {
                        MatchView.Rows[i].Cells[1].Style.ForeColor = Color.Black;
                        MatchView.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                    }
                }

            }
        }

        private List<string> LoadMatchViewRatingCats()
        {
            List<string> categories = new List<string>();
            categories.Add("Teams");
            categories.Add("Team Prestige");
            categories.Add("Playbook");
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
            categories.Add("Coach Prestige");


            return categories;
        }

        private List<string> LoadTeamRatings(int rec)
        {
            List<string> categories = new List<string>();
            int cochrec = FindCOCHRecordfromTeamTGID(GetDBValueInt("TEAM", "TGID", rec));

            categories.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", rec)]);
            categories.Add(GetDBValue("TEAM", "TMPR", rec));
            categories.Add(GetPlaybookName(GetDBValueInt("COCH", "CPID", cochrec)));
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
            categories.Add(GetDBValue("COCH", "CPRE", cochrec));


            return categories;
        }

        //Reschedule Out of Conference Games
        private void RescheduleOOC_Click(object sender, EventArgs e)
        {
            ClearOutOfConferenceOnly();
            CreateMasterScheduleDB();
            OutOfConferenceScheduling();
        }

    }

}
