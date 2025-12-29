using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Label = System.Windows.Forms.Label;

namespace DB_EDITOR
{
    partial class LeagueMain : Form
    {

        /* Annuals Updater
         *  
         */

        private void AnnualsSetup()
        {
            AnnualsGrid.Rows.Clear();
            AnnualsGrid.AllowUserToDeleteRows = true;
            AnnualsGrid.Columns.Clear();

            // Add the RowsAdded event handler
            //AnnualsGrid.RowsAdded += AnnualsGrid_RowsAdded;

            //Add Selection Boxes
            for (int i = 0; i < 3; i++)
            {
                DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
                AnnualsGrid.Columns.Add(column);
            }

            // Set the column header names.
            AnnualsGrid.Columns[0].Name = "Team A";
            AnnualsGrid.Columns[1].Name = "Team B";
            AnnualsGrid.Columns[2].Name = "Week";
            AnnualsGrid.Columns[0].Width = 120;
            AnnualsGrid.Columns[1].Width = 120;
            AnnualsGrid.Columns[2].Width = 100;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            AnnualsGrid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            //Set Data Sources
            ((DataGridViewComboBoxColumn)AnnualsGrid.Columns[0]).DataSource = GetSANNTeamItems().Items;
            ((DataGridViewComboBoxColumn)AnnualsGrid.Columns[1]).DataSource = GetSANNTeamItems().Items;
            ((DataGridViewComboBoxColumn)AnnualsGrid.Columns[2]).DataSource = GetWeekItems().Items;



            AddSANNData();
        }

        private void AddSANNData()
        {
            string[] teamNameDB = main.GetTeamNameDB();
            int count = 0;
            for (int i = 0; i < GetTableRecCount("SANN"); i++)
            {
                if (GetDBValueInt("SANN", "SESI", i) == 0)
                {
                    int tgidA = GetDBValueInt("SANN", "GATG", i);
                    int tgidH = GetDBValueInt("SANN", "GHTG", i);
                    int recA = main.FindTeamRecfromTGID(tgidA);
                    int recH = main.FindTeamRecfromTGID(tgidH);


                    //check for Army-Navy game and change to week 15
                    if (tgidA == 57 & tgidH == 8)
                    {
                        ChangeDBInt("SANN", "SEWN", i, 15);
                        ChangeDBInt("SANN", "SEWT", i, 15);
                        ArmyNavy = true;
                    }
                    else if (tgidA == 8 && tgidH == 57)
                    {
                        ChangeDBInt("SANN", "SEWN", i, 15);
                        ChangeDBInt("SANN", "SEWT", i, 15);
                        ArmyNavy = true;
                    }

                    //check for same conference
                    if (main.GetTeamCGID(recA) != main.GetTeamCGID(recH) || main.GetTeamCGID(recA) == 5 || main.GetTeamCGID(recH) == 5)
                    {

                        string[] game = new string[] { teamNameDB[tgidA], teamNameDB[tgidH], GetDBValue("SANN", "SEWN", i) };

                        AnnualsGrid.Rows.Add(game);
                    }
                    else
                    {
                        MessageBox.Show("" + main.teamNameDB[tgidA] + " and " + main.teamNameDB[tgidH] + " was removed. They are in the same conference.");
                    }

                    count++;
                }

                //if (count >= 26) break; // Limit to 50 rows
            }

            //Add Army-Navy if not present
            if (!ArmyNavy && verNumber >= 15.0)
            {
                int rec = GetTableRecCount("SANN");
                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", rec, 1200);
                ChangeDBInt("SANN", "GATG", rec, 8);
                ChangeDBInt("SANN", "GHTG", rec, 57);
                ChangeDBInt("SANN", "SESI", rec, 1);
                ChangeDBInt("SANN", "SEWN", rec, 15);
                ChangeDBInt("SANN", "GDAT", rec, 5);
                ChangeDBInt("SANN", "SEWT", rec, 15);

                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", rec + 1, 1200);
                ChangeDBInt("SANN", "GATG", rec + 1, 57);
                ChangeDBInt("SANN", "GHTG", rec + 1, 8);
                ChangeDBInt("SANN", "SESI", rec + 1, 0);
                ChangeDBInt("SANN", "SEWN", rec + 1, 15);
                ChangeDBInt("SANN", "GDAT", rec + 1, 5);
                ChangeDBInt("SANN", "SEWT", rec + 1, 15);

                ArmyNavy = true;

                AddSANNData();
                AddtoSKNW();
            }


        }

        private ComboBox GetSANNTeamItems()
        {
            string[] teamNameDB = main.GetTeamNameDB();

            ComboBox teams = new ComboBox();
            for (int i = 0; i < teamNameDB.Length; i++)
            {
                if (teamNameDB[i] != null) teams.Items.Add(teamNameDB[i]);
            }

            return teams;
        }

        private ComboBox GetWeekItems()
        {
            ComboBox weeks = new ComboBox();
            for (int i = 0; i < 16; i++)
            {
                weeks.Items.Add(Convert.ToString(i));
            }

            return weeks;
        }

        private void DeleteRow()
        {

            while (AnnualsGrid.SelectedRows.Count > 0)
                AnnualsGrid.Rows.RemoveAt(AnnualsGrid.SelectedRows[0].Index);

        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            AnnualsGrid.Rows.Clear();
        }

        private void DeleteGameButton_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void SaveSANNButton_Click(object sender, EventArgs e)
        {
            ClearAnnuals();

            int rec = 0;
            for (int i = 0; i < AnnualsGrid.Rows.Count; i++)
            {
                if (AnnualsGrid.Rows[i].Cells[0].Value != null && AnnualsGrid.Rows[i].Cells[1].Value != null && AnnualsGrid.Rows[i].Cells[2].Value != null)
                {
                    int time = 1080;
                    int gdat = 5;
                    if (rand.Next(0, 2) == 1) time = 1200;
                    int home = GetTGIDfromTeamName(Convert.ToString(AnnualsGrid.Rows[i].Cells[1].Value));
                    int away = GetTGIDfromTeamName(Convert.ToString(AnnualsGrid.Rows[i].Cells[0].Value));

                    //check for same conference
                    if (main.GetTeamCGID(GetTeamRecFromTGID(home)) != main.GetTeamCGID(GetTeamRecFromTGID(away)) || main.GetTeamCGID(GetTeamRecFromTGID(home)) == 5 || main.GetTeamCGID(GetTeamRecFromTGID(away)) == 5)
                    {
                        //year 0
                        rec = TDB.TableRecordCount(dbIndex2, "SANN");
                        TDB.TDBTableRecordAdd(dbIndex2, "SANN", true);
                        ChangeDBInt("SANN", "GTOD", rec, time);
                        ChangeDBInt("SANN", "GATG", rec, away);
                        ChangeDBInt("SANN", "GHTG", rec, home);
                        ChangeDBInt("SANN", "SESI", rec, 0);
                        ChangeDBInt("SANN", "SEWN", rec, Convert.ToInt32(AnnualsGrid.Rows[i].Cells[2].Value));
                        ChangeDBInt("SANN", "GDAT", rec, gdat);
                        ChangeDBInt("SANN", "SEWT", rec, Convert.ToInt32(AnnualsGrid.Rows[i].Cells[2].Value));

                        //check for Army-Navy game
                        if (away == 57 & home == 8)
                        {
                            ChangeDBInt("SANN", "SEWN", rec, 15);
                            ChangeDBInt("SANN", "SEWT", rec, 15);
                            ArmyNavy = true;
                        }
                        else if (away == 8 && home == 57)
                        {
                            ChangeDBInt("SANN", "SEWN", rec, 15);
                            ChangeDBInt("SANN", "SEWT", rec, 15);
                            ArmyNavy = true;
                        }



                        //year 1
                        rec = TDB.TableRecordCount(dbIndex2, "SANN");
                        TDB.TDBTableRecordAdd(dbIndex2, "SANN", true);
                        ChangeDBInt("SANN", "GTOD", rec, time);
                        ChangeDBInt("SANN", "GATG", rec, home);
                        ChangeDBInt("SANN", "GHTG", rec, away);
                        ChangeDBInt("SANN", "SESI", rec, 1);
                        ChangeDBInt("SANN", "SEWN", rec, Convert.ToInt32(AnnualsGrid.Rows[i].Cells[2].Value));
                        ChangeDBInt("SANN", "GDAT", rec, gdat);
                        ChangeDBInt("SANN", "SEWT", rec, Convert.ToInt32(AnnualsGrid.Rows[i].Cells[2].Value));

                        //check for Army-Navy game
                        if (away == 57 & home == 8)
                        {
                            ChangeDBInt("SANN", "SEWN", rec, 15);
                            ChangeDBInt("SANN", "SEWT", rec, 15);
                            ArmyNavy = true;
                        }
                        else if (away == 8 && home == 57)
                        {
                            ChangeDBInt("SANN", "SEWN", rec, 15);
                            ChangeDBInt("SANN", "SEWT", rec, 15);
                            ArmyNavy = true;
                        }

                    }

                    else
                    {
                        MessageBox.Show("" + main.teamNameDB[away] + " and " + main.teamNameDB[home] + " was removed. They are in the same conference.");
                    }
                }
            }

            if (!ArmyNavy && verNumber >= 15.0)
            {
                rec = TDB.TableRecordCount(dbIndex2, "SANN");
                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", rec, 1200);
                ChangeDBInt("SANN", "GATG", rec, 8);
                ChangeDBInt("SANN", "GHTG", rec, 57);
                ChangeDBInt("SANN", "SESI", rec, 1);
                ChangeDBInt("SANN", "SEWN", rec, 15);
                ChangeDBInt("SANN", "GDAT", rec, 5);
                ChangeDBInt("SANN", "SEWT", rec, 15);

                rec = TDB.TableRecordCount(dbIndex2, "SANN");
                TDB.TDBTableRecordAdd(dbIndex2, "SANN", false);
                ChangeDBInt("SANN", "GTOD", rec, 1200);
                ChangeDBInt("SANN", "GATG", rec, 57);
                ChangeDBInt("SANN", "GHTG", rec, 8);
                ChangeDBInt("SANN", "SESI", rec, 0);
                ChangeDBInt("SANN", "SEWN", rec, 15);
                ChangeDBInt("SANN", "GDAT", rec, 5);
                ChangeDBInt("SANN", "SEWT", rec, 15);

            }

            //Check Schedules for Errors
            for (int j = 0; j < GetTableRecCount("SANN"); j++)
            {
                if (GetDBValueInt("SANN", "GATG", j) == 0 && GetDBValueInt("SANN", "GHTG", j) == 0)
                {
                    TDB.TDBTableRecordChangeDeleted(dbIndex2, "SANN", j, true);
                }
            }

            TDB.TDBDatabaseCompact(dbIndex2);

            AddtoSKNW();

            MessageBox.Show("Annual Match-Ups Added!");
        }

        private int GetTGIDfromTeamName(string teamName)
        {
            string[] teamNameDB = main.GetTeamNameDB();

            int tgid = -1;

            for (int i = 0; i < teamNameDB.Count(); i++)
            {
                if (teamNameDB[i] == teamName) return i;
            }

            return tgid;

        }

        private int GetTeamRecFromTGID(int tgid)
        {
            int teamRec = -1;

            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValueInt("TEAM", "TGID", i) == tgid) return i;
            }

            return teamRec;
        }
        private void AddtoSKNW()
        {
            //Recreate SKNW table
            GenerateSKNW();

            int tableRec = GetTableRecCount("SKNW");
            string table = "SANN";

            for (int g = 0; g < GetTableRecCount(table); g++)
            {
                if (GetDBValueInt(table, "SESI", g) == 0)
                {
                    TDB.TDBTableRecordAdd(dbIndex2, "SKNW", true);
                    ChangeDBInt("SKNW", "GTOD", tableRec, GetDBValueInt(table, "GTOD", g));
                    ChangeDBInt("SKNW", "GATG", tableRec, GetDBValueInt(table, "GATG", g));
                    ChangeDBInt("SKNW", "GHTG", tableRec, GetDBValueInt(table, "GHTG", g));
                    ChangeDBInt("SKNW", "SESI", tableRec, GetDBValueInt(table, "SESI", g));
                    ChangeDBInt("SKNW", "SEWN", tableRec, GetDBValueInt(table, "SEWN", g));
                    ChangeDBInt("SKNW", "GDAT", tableRec, GetDBValueInt(table, "GDAT", g));
                    ChangeDBInt("SKNW", "SEWT", tableRec, GetDBValueInt(table, "SEWT", g));
                    tableRec++;
                }
            }

            //Check Schedules for Errors
            for (int j = 0; j < GetTableRecCount("SKNW"); j++)
            {
                if (GetDBValueInt("SKNW", "GATG", j) == 0 && GetDBValueInt("SKNW", "GHTG", j) == 0)
                {
                    TDB.TDBTableRecordChangeDeleted(dbIndex2, "SKNW", j, true);
                }
            }

            TDB.TDBDatabaseCompact(dbIndex2);
        }

        private void AnnualsGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (AnnualsGrid.Rows.Count > 26)
            {
                MessageBox.Show("Maximum of 26 rows allowed.", "Row Limit Reached",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                while (AnnualsGrid.Rows.Count > 26)
                {
                    AnnualsGrid.Rows.RemoveAt(AnnualsGrid.Rows.Count - 1);
                }
            }
        }
    }
}
