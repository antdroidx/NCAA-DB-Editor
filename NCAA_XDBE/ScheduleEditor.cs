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
            //LoadScheduleView();

            ScheduleComboBox.SelectedIndex = 0;
            LoadScheduleTeamsBox();

            DoNotTrigger = false;
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

            for (int i = 0; i <= seow; i++)
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
            ScheduleView.Rows.Clear();

            for (int i = 0; i < 23; i++)
            {
                ScheduleView.Rows.Add(new DataGridViewRow());

                ScheduleView.Rows[i].Cells[0].Value = i;
            }

            SchdTeamName.Text = teamNameDB[tgid];

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "GATG", i) == tgid || GetDBValueInt("SCHD", "GHTG", i) == tgid)
                {
                    int w = GetDBValueInt("SCHD", "SEWN", i);

                    ScheduleView.Rows[w].Cells[1].Value = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    ScheduleView.Rows[w].Cells[1].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GHTG", i)]));
                    ScheduleView.Rows[w].Cells[1].Style.ForeColor = Color.WhiteSmoke;

                    ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GHSC", i);

                    ScheduleView.Rows[w].Cells[3].Value = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                    ScheduleView.Rows[w].Cells[3].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GATG", i)]));
                    ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.WhiteSmoke;

                    ScheduleView.Rows[w].Cells[4].Value = GetDBValueInt("SCHD", "GASC", i);


                    if (GetDBValueInt("SCHD", "GASC", i) > GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[2].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                    }
                    else if (GetDBValueInt("SCHD", "GASC", i) < GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[4].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                    }
                    else
                    {
                        ScheduleView.Rows[w].Cells[2].Value = "";
                        ScheduleView.Rows[w].Cells[4].Value = "";

                    }
                }
            }

            int rec = FindTeamRecfromTeamName(teamNameDB[tgid]);
            SCHDrecord.Text = "Season Record: " + GetDBValue("TEAM", "TSWI", rec) + " - " + GetDBValue("TEAM", "TSLO", rec);

        }

        private void LoadScheduleWeekView(int sewn)
        {
            ScheduleView.Rows.Clear();
            SchdTeamName.Text = "Week " + sewn;
            SCHDrecord.Text = "  ";

            for (int i = 0; i < GetTableRecCount("SCHD"); i++)
            {
                if (GetDBValueInt("SCHD", "SEWN", i) == sewn)
                {
                    int w = ScheduleView.Rows.Count;
                    ScheduleView.Rows.Add(new DataGridViewRow());
                    ScheduleView.Rows[w].Cells[0].Value = sewn;
                    ScheduleView.Rows[w].Cells[1].Value = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];
                    ScheduleView.Rows[w].Cells[1].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GHTG", i)]));
                    ScheduleView.Rows[w].Cells[1].Style.ForeColor = Color.WhiteSmoke;

                    ScheduleView.Rows[w].Cells[2].Value = GetDBValueInt("SCHD", "GHSC", i);

                    ScheduleView.Rows[w].Cells[3].Value = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                    ScheduleView.Rows[w].Cells[3].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("SCHD", "GATG", i)]));
                    ScheduleView.Rows[w].Cells[3].Style.ForeColor = Color.WhiteSmoke;

                    ScheduleView.Rows[w].Cells[4].Value = GetDBValueInt("SCHD", "GASC", i);

                    if (GetDBValueInt("SCHD", "GASC", i) > GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[2].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                    }
                    else if (GetDBValueInt("SCHD", "GASC", i) <  GetDBValueInt("SCHD", "GHSC", i))
                    {
                        ScheduleView.Rows[w].Cells[4].Style.Font = new Font(ScheduleView.Font, FontStyle.Bold);
                    }
                    else
                    {
                        ScheduleView.Rows[w].Cells[2].Value = "";
                        ScheduleView.Rows[w].Cells[4].Value = "";

                    }

                }
            }

            ScheduleView.ClearSelection();
        }





        //Match Viewer

        private void ScheduleView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            int row = (e.RowIndex);

            string hometeam = Convert.ToString(ScheduleView.Rows[row].Cells[1].Value);
            string awayteam = Convert.ToString(ScheduleView.Rows[row].Cells[3].Value);

            int recH = FindTeamRecfromTeamName(hometeam);
            int recA = FindTeamRecfromTeamName(awayteam);

            MatchView.Rows.Clear();
            if(recH != recA)
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

                if(i == 0)
                {
                    MatchView.Rows[i].Cells[1].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(homeTeam[i]));
                    MatchView.Rows[i].Cells[1].Style.ForeColor = Color.WhiteSmoke;

                    MatchView.Rows[i].Cells[2].Style.BackColor = GetTeamPrimaryColor(FindTeamRecfromTeamName(awayTeam[i]));
                    MatchView.Rows[i].Cells[2].Style.ForeColor = Color.WhiteSmoke;
                }

            }
            MatchView.CellPainting += MatchView_CellPainting;
            MatchView.ClearSelection();
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
            categories.Add("Coach Hot Seat");


            return categories;
        }

        private List<string> LoadTeamRatings(int rec)
        {
            List<string> categories = new List<string>();
            int cochrec = FindCOCHRecordfromTeamTGID(GetDBValueInt("TEAM", "TGID", rec));

            categories.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", rec)]);
            categories.Add(ConvertStarNumber(GetDBValueInt("TEAM", "TMPR", rec)));
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
            categories.Add(ConvertStarNumber(GetDBValueInt("COCH", "CPRE", cochrec)));
            categories.Add(GetDBValue("COCH", "CCPO", cochrec));


            return categories;
        }

        //Reschedule Out of Conference Games
        private void RescheduleOOC_Click(object sender, EventArgs e)
        {
            ClearOutOfConferenceOnly();
            CreateMasterScheduleDB();
            OutOfConferenceScheduling();
        }

        private void MatchView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Only paint value bars for rows 3 to 13 (index 2 to 14) and columns 1 and 2 (team ratings)
            if (e.RowIndex >= 3 && e.RowIndex <= 13 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
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

                    Color col = GetColorValue(value);


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
                        Color.WhiteSmoke,
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter
                    );
                }
                // Only paint value bars for rows 3 to 13 (index 2 to 14) and columns 1 and 2 (team ratings)
            }
            else if (e.RowIndex == 16 && (e.ColumnIndex == 1 || e.ColumnIndex == 2))
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
                        Color.WhiteSmoke,
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
