using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        private void StartDepthChartEditor()
        {
            if (DCHTPlayers != null)
            {

            }
            else
            {

                DoNotTrigger = true;
                DCHTGrid.Rows.Clear();
                DCHTGrid.BackgroundColor = Color.DarkGray;
                AddPositionsToDCHT();
                AddTeamsToDCHT();
                DepthChartIndex = 0;
                DCHTEditorMode.Checked = true;

                // Ensure we handle the editing control to enable owner-draw on combo boxes
                DCHTGrid.EditingControlShowing -= DCHTGrid_EditingControlShowing;
                DCHTGrid.EditingControlShowing += DCHTGrid_EditingControlShowing;

                // Ensure DataGridView cell formatting runs to color the non-editing display
                DCHTGrid.CellFormatting -= DCHTGrid_CellFormatting;
                DCHTGrid.CellFormatting += DCHTGrid_CellFormatting;

                if (verNumber < 16.0)
                {
                    DC136.Checked = false;
                }
                else
                {
                    DC136.Checked = true;
                }
                DoNotTrigger = false;
                DCHTEditorMode.Checked = false;
            }

        }

        //Change Views
        private void DCHTEditorMode_CheckedChanged(object sender, EventArgs e)
        {
            // Do not replace the DCHTGrid instance; modify its columns in-place so the UI and event handlers remain intact.
            DoNotTrigger = true;

            // Preserve layout and parent by working on the existing control
            DCHTGrid.SuspendLayout();
            DCHTGrid.Columns.Clear();
            DCHTGrid.Rows.Clear();

            var col = new DataGridViewTextBoxColumn();

            col.DataPropertyName = "DCHTPos";
            col.Name = "Pos";
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.BackColor = Color.LightGray;
            col.DefaultCellStyle.ForeColor = Color.Black;
            DCHTGrid.Columns.Add(col);

            if (DCHTEditorMode.Checked)
            {
                for (int i = 1; i <= 6; i++)
                {

                    var colCombo = new DataGridViewComboBoxColumn();

                    colCombo.DataPropertyName = "DCHT" + (i);
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                    DCHTGrid.Columns.Add(colCombo);

                }
                DCHTGrid.Columns[1].Name = "Starter";
                DCHTGrid.Columns[2].Name = "2nd String";
                DCHTGrid.Columns[3].Name = "3rd String";
                DCHTGrid.Columns[4].Name = "4th String";
                DCHTGrid.Columns[5].Name = "5th String";
                DCHTGrid.Columns[6].Name = "6th String";
            }
            else
            {
                for (int i = 1; i <= 18; i++)
                {
                    col = new DataGridViewTextBoxColumn();
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    col.DefaultCellStyle.Font = new Font("Verdana", 8);
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    col.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                    col.DefaultCellStyle.ForeColor = Color.Black;
                    col.DefaultCellStyle.SelectionBackColor = Color.Ivory;
                    col.DefaultCellStyle.SelectionForeColor = Color.Black;

                    if (i % 3 == 0)
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    else
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    }


                    DCHTGrid.Columns.Add(col);
                }
                DCHTGrid.Columns[1].Name = "Starter";
                DCHTGrid.Columns[2].Name = "Class";
                DCHTGrid.Columns[3].Name = "OVR";
                DCHTGrid.Columns[4].Name = "2nd String";
                DCHTGrid.Columns[5].Name = "Class";
                DCHTGrid.Columns[6].Name = "OVR";
                DCHTGrid.Columns[7].Name = "3rd String";
                DCHTGrid.Columns[8].Name = "Class";
                DCHTGrid.Columns[9].Name = "OVR";
                DCHTGrid.Columns[10].Name = "4th String";
                DCHTGrid.Columns[11].Name = "Class";
                DCHTGrid.Columns[12].Name = "OVR";
                DCHTGrid.Columns[13].Name = "5th String";
                DCHTGrid.Columns[14].Name = "Class";
                DCHTGrid.Columns[15].Name = "OVR";
                DCHTGrid.Columns[16].Name = "6th String";
                DCHTGrid.Columns[17].Name = "Class";
                DCHTGrid.Columns[18].Name = "OVR";
            }



            AddPositionsToDCHT();

            // Reload data and repopulate cells
            LoadDCHTPlayerData();
            LoadTeamDCHTData();

            // If editable mode, configure combo behavior and populate combo lists
            if (DCHTEditorMode.Checked)
            {
                // Ensure the editing control handler is attached so owner-draw is applied
                DCHTGrid.EditingControlShowing -= DCHTGrid_EditingControlShowing;
                DCHTGrid.EditingControlShowing += DCHTGrid_EditingControlShowing;

                if (DCHTGrid.CurrentCell != null) LoadDCHTBoxData(DCHTGrid.CurrentCell.RowIndex);
            }
            else
            {
                // Ensure cell formatting is applied for read-only view
                DCHTGrid.CellFormatting -= DCHTGrid_CellFormatting;
                DCHTGrid.CellFormatting += DCHTGrid_CellFormatting;
            }

            DCHTGrid.ResumeLayout();
            DoNotTrigger = false;
        }


        private void AddTeamsToDCHT()
        {
            DCHTTeam.Items.Clear();
            List<string> teamList = new List<string>();
            if (TDYN)
            {
                for (int i = 0; i < GetTableRecCount("TDYN"); i++)
                {
                    teamList.Add(teamNameDB[GetDBValueInt("TDYN", "TOID", i)]);
                }
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                        teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
                }
            }

            teamList.Sort();

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) DCHTTeam.Items.Add(teamList[i]);
            }
        }

        private void AddPositionsToDCHT()
        {
            for (int i = 0; i < 25; i++)
            {
                DCHTGrid.Rows.Add(new DataGridViewRow());
                if (i == 21) DCHTGrid.Rows[i].Cells[0].Value = "KR";
                else if (i == 22) DCHTGrid.Rows[i].Cells[0].Value = "PR";
                else if (i == 23) DCHTGrid.Rows[i].Cells[0].Value = "KOS";
                else if (i == 24) DCHTGrid.Rows[i].Cells[0].Value = "LS";
                else DCHTGrid.Rows[i].Cells[0].Value = Positions[i];

                if (i <= 9)
                {
                    DCHTGrid.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }
                else if (i <= 18)
                {
                    DCHTGrid.Rows[i].DefaultCellStyle.BackColor = Color.Ivory;
                }
                else
                {
                    DCHTGrid.Rows[i].DefaultCellStyle.BackColor = Color.Gainsboro;
                }

            }
        }

        //Team Selection
        private void DCHTTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoNotTrigger = true;
            DepthChartIndex = FindTGIDfromTeamName(Convert.ToString(DCHTTeam.SelectedItem));

            LoadDCHTPlayerData();
            LoadTeamDCHTData();
            if (DCHTGrid.CurrentCell != null) LoadDCHTBoxData(DCHTGrid.CurrentCell.RowIndex);

            DoNotTrigger = false;

        }

        //Load Players List for ComboBox
        private void LoadDCHTPlayerData()
        {
            StartProgressBar(GetTableRecCount("PLAY"));

            DCHTPlayers = new List<List<string>>();

            int tgid = DepthChartIndex;
            int pgidBeg = tgid * 70;
            int pgidEnd = tgid * 70 + 69;
            int row = 0;

            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd)
                {
                    DCHTPlayers.Add(new List<string>());
                    for (int p = 0; p < 25; p++)
                    {
                        if (p <= 20) DCHTPlayers[row].Add((CalculatePositionRating(i, p)).ToString("0.00"));
                        else if (p <= 22) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 3)));
                        else if (p == 23) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 19)));
                        else if (p == 24) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 5)));
                    }
                    DCHTPlayers[row].Add(Convert.ToString(i));  //25
                    DCHTPlayers[row].Add(GetDBValue("PLAY", "PGID", i));  //26

                    int pos = GetDBValueInt("PLAY", "PPOS", i);

                    DCHTPlayers[row].Add(GetPOSG2Name(GetPOSG2fromPPOS(pos)) + ": " + GetPlayerNamefromRec(i) + " [" + ConvertRating(GetDBValueInt("PLAY", "POVR", i)) + "]"); //27


                    DCHTPlayers[row].Add(GetDBValue("PLAY", "PPOS", i)); //28
                    DCHTPlayers[row].Add(GetPlayerNamefromRec(i)); //29



                    /* 0-24 position ratings
                     *  rec  25  pgid  26  name  27  position 28 POVR 29
                     */


                    row++;
                    if (row > 69) break;
                }
                ProgressBarStep();
            }

            DCHTPlayers.Sort((player1, player2) => player1[27].CompareTo(player2[27]));

            EndProgressBar();
        }

        private ComboBox CreateDCHTComboBox(int ppos)
        {

            ComboBox comboBox = new ComboBox();

            DCHTPlayers.Sort((player1, player2) => Convert.ToDouble(player2[ppos]).CompareTo(Convert.ToDouble(player1[ppos])));

            for (int i = 0; i < DCHTPlayers.Count; i++)
            {
                comboBox.Items.Add(DCHTPlayers[i][27]);
            }

            return comboBox;
        }

        // Configure a ComboBox for owner-draw so items can be color-coded
        private void ConfigureComboOwnerDraw(ComboBox cb)
        {
            if (cb == null) return;

            cb.DrawMode = DrawMode.OwnerDrawFixed;
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            // Avoid duplicate subscriptions
            cb.DrawItem -= DCHTCombo_DrawItem;
            cb.DrawItem += DCHTCombo_DrawItem;
        }

        // DataGridView EditingControlShowing handler to set owner-draw on in-place ComboBox controls
        private void DCHTGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox cb)
            {
                ConfigureComboOwnerDraw(cb);
            }
        }

        // Extract numeric rating between the last '[' and ']' in the item string
        private int ExtractBracketRating(string text)
        {
            if (string.IsNullOrEmpty(text)) return -1;
            int r = text.LastIndexOf('[');
            int s = text.LastIndexOf(']');
            if (r >= 0 && s > r)
            {
                string num = text.Substring(r + 1, s - r - 1);
                if (int.TryParse(num, out int val)) return val;
            }
            return -1;
        }

        // Owner-draw handler: color-code based on numeric rating
        private void DCHTCombo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (sender is not ComboBox cb) return;

            // Determine the text to draw: item in drop-down or the selected text when not dropped
            string text;
            if (e.Index >= 0 && e.Index < cb.Items.Count)
            {
                text = Convert.ToString(cb.Items[e.Index]) ?? string.Empty;
            }
            else
            {
                // Draw the selected text shown in the ComboBox's edit area.
                // Prefer SelectedItem if available; fallback to Text.
                text = (cb.SelectedItem != null) ? Convert.ToString(cb.SelectedItem) ?? string.Empty : cb.Text ?? string.Empty;
            }

            int rating = ExtractBracketRating(text);
            Color textColor = GetColorRating(rating);

            // Draw background (handles selection background)
            e.DrawBackground();

            // Draw text using TextRenderer for consistent alignment/clear type
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine;
            TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, textColor, flags);

            e.DrawFocusRectangle();
        }

        private void LoadDCHTBoxData(int ppos)
        {
            if (DCHTEditorMode.Checked)
            {
                var items = CreateDCHTComboBoxItems(ppos);

                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[1]).DataSource = items;
                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[2]).DataSource = items;
                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[3]).DataSource = items;
                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[4]).DataSource = items;
                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[5]).DataSource = items;
            }
        }

        private IList<string> CreateDCHTComboBoxItems(int ppos)
        {
            var items = new List<string>();

            // Avoid mutating global state repeatedly if possible
            DCHTPlayers.Sort((player1, player2) => Convert.ToDouble(player2[ppos])
                                          .CompareTo(Convert.ToDouble(player1[ppos])));

            for (int i = 0; i < DCHTPlayers.Count; i++)
            {
                items.Add(DCHTPlayers[i][27]);
            }

            return items;
        }

        private void LoadTeamDCHTData()
        {
            StartProgressBar(GetTableRecCount("DCHT"));

            int PGIDBeg = DepthChartIndex * 70;
            int PGIDEnd = PGIDBeg + 69;
            int count = 0;
            List<int> impactPlayers = new List<int>();
            int teamRec = FindTeamRecfromTeamName(Convert.ToString(DCHTTeam.SelectedItem));
            int cochREC = FindCOCHRecordfromTeamTGID(GetDBValueInt("TEAM", "TGID", teamRec));
            int off = GetDBValueInt("COCH", "COST", cochREC);
            int def = GetDBValueInt("COCH", "CDST", cochREC);

            if (DCHTTeam.SelectedIndex >= 0)
            {
                DCHTOffType.Text = GetOffTypeName(off);
                DCHTDefType.Text = GetDefTypeName(def);
            }
            else
            {
                DCHTOffType.Text = "---";
                DCHTDefType.Text = "---";
            }



            impactPlayers.Add(GetDBValueInt("TEAM", "TSI1", teamRec) + PGIDBeg);
            impactPlayers.Add(GetDBValueInt("TEAM", "TSI2", teamRec) + PGIDBeg);
            impactPlayers.Add(GetDBValueInt("TEAM", "TPIO", teamRec) + PGIDBeg);
            impactPlayers.Add(GetDBValueInt("TEAM", "TPID", teamRec) + PGIDBeg);

            List<int> captains = new List<int>();
            captains.Add(GetDBValueInt("TEAM", "OCAP", teamRec) + PGIDBeg);
            captains.Add(GetDBValueInt("TEAM", "DCAP", teamRec) + PGIDBeg);

            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) >= PGIDBeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDEnd)
                {
                    int pgid = GetDBValueInt("DCHT", "PGID", i);
                    int ppos = GetDBValueInt("DCHT", "PPOS", i);
                    int ddep = GetDBValueInt("DCHT", "ddep", i);

                    int rec = FindPGIDRecord(pgid);
                    string name = GetPlayerNamefromRec(rec);
                    int pos = GetPPOSfromRecord(rec);
                    string posgName = GetPOSG2Name(GetPOSG2fromPPOS(pos));
                    int povr = GetDBValueInt("PLAY", "POVR", rec);
                    int jersey = GetDBValueInt("PLAY", "PJEN", rec);
                    int year = GetDBValueInt("PLAY", "PYER", rec);
                    int redshirt = GetDBValueInt("PLAY", "PRSD", rec);
                    int ptyp = GetDBValueInt("PLAY", "PTYP", rec);
                    int dchtrow = -1;
                    for (int x = 0; x < DCHTPlayers.Count; x++)
                    {
                        if (Convert.ToInt32(DCHTPlayers[x][26]) == pgid)
                        {
                            dchtrow = x;
                            break;
                        }
                    }
                    //Check Impact Player
                    string impact = "";

                    if (captains.Contains(pgid))
                    {
                        impact += " ©";
                    }
                    if (impactPlayers.Contains(pgid))
                    {
                        impact += " " + ConvertStarNumber(1);
                    }

                    if (dbIndex2 > 0)
                    {
                        if (ptyp == 1) impact += " +";
                        else if (ptyp == 3) impact += " >";
                    }

                    if (DCHTEditorMode.Checked)
                    {
                        DCHTGrid.Rows[ppos].Cells[ddep + 1].Value = (posgName + ": " + name + " [" + ConvertRating(povr) + "]");
                    }
                    else
                    {
                        DCHTGrid.Rows[ppos].Cells[ddep * 3 + 1].Value = "#" + jersey + " " + name + " " + impact;
                        DCHTGrid.Rows[ppos].Cells[ddep * 3 + 2].Value = GetClassYearsAbbr(year, redshirt);
                        DCHTGrid.Rows[ppos].Cells[ddep * 3 + 3].Value = ConvertRating(povr);
                        HighlightStarters(ppos, ddep, off, def);
                    }




                    count++;
                }
                ProgressBarStep();
                if (count > 87) break;
            }

            DisableDCHTCells();

            EndProgressBar();
        }

        private void DisableDCHTCells()
        {
            if (DCHTEditorMode.Checked)
            {
                for (int i = 0; i < DCHTGrid.Rows.Count; i++)
                {
                    for (int c = 0; c < DCHTGrid.Rows[i].Cells.Count; c++)
                    {
                        if (DCHTGrid.Rows[i].Cells[c].Value == null)
                        {
                            DCHTGrid.Rows[i].Cells[c].ReadOnly = true;
                        }
                        else
                        {
                            DCHTGrid.Rows[i].Cells[c].ReadOnly = false;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < DCHTGrid.Rows.Count; i++)
                {
                    for (int c = 0; c < DCHTGrid.Rows[i].Cells.Count; c++)
                    {
                        DCHTGrid.Rows[i].Cells[c].ReadOnly = true;
                    }
                }
            }
        }

        private void HighlightStarters(int ppos, int depth, int off, int def)
        {
            if (ppos == 0 && depth < 1) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 1 && depth < DepthChartHB(off)) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 2 && depth < DepthChartFB(off)) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 3 && depth < DepthChartWR(off)) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 4 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 5 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 6 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 7 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 8 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 9 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 10 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 11 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 12 && depth < DepthChartDT(def)) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 13 && depth < 1 && DepthChartOLB(def) > 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 15 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 14 && depth < DepthChartMLB(def)) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 16 && depth < 2) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 17 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 18 && depth < DepthChartSS(def)) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 19 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 20 && depth < 1) FormatDCHTStartersCell(ppos, depth);

            else if (ppos == 21 && depth < 2) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 22 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 23 && depth < 1) FormatDCHTStartersCell(ppos, depth);
            else if (ppos == 24 && depth < 1) FormatDCHTStartersCell(ppos, depth);

        }

        private void FormatDCHTStartersCell(int ppos, int depth)
        {
            DCHTGrid.Rows[ppos].Cells[depth * 3 + 1].Style.Font = new Font("Verdana", 9, FontStyle.Bold);
            DCHTGrid.Rows[ppos].Cells[depth * 3 + 3].Style.Font = new Font("Verdana", 9, FontStyle.Bold);
        }

        //Update Player List by Cell
        private void DCHT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            if (DCHTTeam.SelectedIndex == -1) return;
            if (!DCHTEditorMode.Checked) return;

            if (DCHTGrid.CurrentCell != null) UpdatePlayerList(DCHTGrid.CurrentCell.RowIndex);
        }


        private void UpdatePlayerList(int row)
        {
            for (int i = 1; i < DCHTGrid.Columns.Count; i++)
            {
                ((DataGridViewComboBoxColumn)DCHTGrid.Columns[1]).DataSource = CreateDCHTComboBox(row).Items;
            }
        }

        private string GetFirstComboItemText(DataGridViewComboBoxColumn col)
        {
            if (col == null || col.DataSource == null) return string.Empty;

            // IList (List<string>, BindingList<string>, etc.)
            if (col.DataSource is IList list && list.Count > 0) return Convert.ToString(list[0]) ?? string.Empty;

            // BindingSource
            if (col.DataSource is BindingSource bs && bs.List != null && bs.List.Count > 0) return Convert.ToString(bs.List[0]) ?? string.Empty;

            // IListSource
            if (col.DataSource is IListSource ils)
            {
                var li = ils.GetList();
                if (li is IList il && il.Count > 0) return Convert.ToString(il[0]) ?? string.Empty;
            }

            return string.Empty;
        }

        private void DCHTGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Only color non-header cells that display the player string (skip column 0 which shows position)
            if (e.RowIndex < 0 || e.ColumnIndex <= 0) return;

            string text = Convert.ToString(e.Value);

            // If there's no value, try to derive a display string from the column's data source (e.g. first item)
            if (string.IsNullOrEmpty(text))
            {
                if (DCHTGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn comboCol)
                {
                    text = GetFirstComboItemText(comboCol);
                }

                // still empty -> nothing to color
                if (string.IsNullOrEmpty(text)) return;
            }

            int rating = -1;

            Color highlightColor = GetColorRating(rating);

            if (DCHTEditorMode.Checked)
            {
                rating = ExtractBracketRating(text);

                // Apply the color to the cell's style so the cell displays colored text when NOT editing
                e.CellStyle.ForeColor = highlightColor;
                e.CellStyle.BackColor = Color.Black;

                // If desired, also adjust selection fore color so selection does not hide color
                e.CellStyle.SelectionForeColor = highlightColor;
                e.CellStyle.SelectionBackColor = Color.DarkGray;
            }
            else
            {
                if (e.ColumnIndex % 3 == 0)
                {
                    highlightColor = GetColorRating(Convert.ToInt32(text));
                    e.CellStyle.ForeColor = ChooseForeground(highlightColor);
                    e.CellStyle.BackColor = highlightColor;
                    e.CellStyle.SelectionBackColor = highlightColor;


                }
                else if (e.ColumnIndex % 1 == 0)
                {
                    if (text.Contains("+"))
                    {
                        e.CellStyle.ForeColor = Color.ForestGreen;

                    }
                    else if (text.Contains(">"))
                    {
                        e.CellStyle.ForeColor = Color.DarkRed;
                    }
                }
                else
                {

                }


                return;
            }
        }

        private void UpdateDatabase()
        {
            //Remove team from DCHT
            DepthChartRemoveTeam(DepthChartIndex);

            /* Add Data to DCHT Table */

            int rec = GetTableRecCount("DCHT");

            for (int row = 0; row < DCHTGrid.Rows.Count; row++)
            {
                for (int col = 0; col < DCHTGrid.Columns.Count; col++)
                {
                    if (col > 0 && DCHTGrid.Rows[row].Cells[col].Value != null)
                    {
                        AddTableRecord("DCHT", false);

                        int pgid = GetDCHTPlayerPGID(Convert.ToString(DCHTGrid.Rows[row].Cells[col].Value));
                        ChangeDBInt("DCHT", "PGID", rec, pgid);
                        ChangeDBInt("DCHT", "PPOS", rec, row);
                        ChangeDBInt("DCHT", "ddep", rec, col - 1);

                        rec++;
                    }
                }

                //row++;
            }

            MessageBox.Show("Depth Chart Database Update Complete!\n\nRemember to Save!");

        }

        private int GetDCHTPlayerPGID(string name)
        {
            for (int i = 0; i < DCHTPlayers.Count; i++)
            {
                if (DCHTPlayers[i][27] == name) return Convert.ToInt32(DCHTPlayers[i][26]);
            }

            return -1;
        }

        private int GetDCHTPGIDfromPlayerName(string name)
        {
            for (int i = 0; i < DCHTPlayers.Count; i++)
            {
                if (DCHTPlayers[i][29] == name) return Convert.ToInt32(DCHTPlayers[i][25]);
            }

            return -1;
        }

        # region Buttons

        private void DCHTAutoSet_Click(object sender, EventArgs e)
        {
            int leaguesize = 120;
            if (DC136.Checked) leaguesize = 136;
            DepthChartMakerSingle("DCHT", DepthChartIndex, leaguesize);
            LoadTeamDCHTData();
            LoadDCHTPlayerData();

            if (DCHTGrid.CurrentCell != null) LoadDCHTBoxData(DCHTGrid.CurrentCell.RowIndex);
        }

        private void DCHTClear_Click(object sender, EventArgs e)
        {
            if (!DCHTEditorMode.Checked)
            {
                MessageBox.Show("Depth Chart must be in Edit Mode to Clear Data.");
                return;
            }
            DoNotTrigger = true;
            LoadTeamDCHTData();
            LoadDCHTPlayerData();

            if (DCHTGrid.CurrentCell != null) LoadDCHTBoxData(DCHTGrid.CurrentCell.RowIndex);

            DoNotTrigger = false;
        }

        private void UpdateDCHT_Click(object sender, EventArgs e)
        {
            if (!DCHTEditorMode.Checked)
            {
                MessageBox.Show("Depth Chart must be in Edit Mode to Update Database.");
                return;
            }
            UpdateDatabase();
        }


        private void DCHTGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DCHTEditorMode.Checked) return;

            int row = e.RowIndex;
            int cell = e.ColumnIndex;

            if (cell % 3 == 1)
            {
                string[] strings = Convert.ToString(DCHTGrid.Rows[row].Cells[cell].Value).Split(' ');
                string playerName = "";
                for (int i = 1; i < strings.Length; i++)
                {
                    playerName += strings[i] + " ";
                }
                playerName = playerName.Trim();

                int playerRec = GetDCHTPGIDfromPlayerName(playerName);


                PlayerIndex = playerRec;
                tabControl1.SelectedTab = tabPlayers;
                LoadPlayerData();
            }

        }

        #endregion

        //Data Error
        private void DCHTGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        #region Depth Chart Maker

        //Depth Chart Maker
        public void DepthChartMaker(string tableName)
        {
            StartProgressBar(GetTableRecCount(tableName));

            //count num of teams
            int teamCount = 0;
            if (TDYN)
            {
                teamCount = GetTableRecCount("TDYN");
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "TTYP", i) == 0) teamCount++;
                }
            }

            //clear DCHT
            for (int i = GetTableRecCount("DCHT"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "DCHT", i);
            }

            CompactDB();

            int count;
            int rec = 0;

            //Create a list of all players sorted by team and pos
            List<List<List<double>>> DCRoster = new List<List<List<double>>>();
            for (int i = 0; i < 512; i++)
            {
                DCRoster.Add(new List<List<double>>());
            }

            //Add Players to the Team Database
            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);
                int TGID = PGID / 70;

                int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                int PRSD = GetDBValueInt("PLAY", "PRSD", j);

                List<double> player = new List<double>();

                if (PRSD != 1)
                {
                    count = DCRoster[TGID].Count;
                    DCRoster[TGID].Add(player);
                    DCRoster[TGID][count].Add(j);
                    DCRoster[TGID][count].Add(PGID);
                    DCRoster[TGID][count].Add(PPOS);
                }
            }



            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                if (TDYN || GetDBValueInt(tableName, "TTYP", i) == 0)
                {
                    int TOID = GetDBValueInt(tableName, "TOID", i);
                    //Sort Depth Chart  KR = 21 PR = 22 KOS = 23 LS = 24

                    //QBs
                    rec = AddDCHTrecord(rec, 0, 3, DCRoster[TOID]);
                    //RBs
                    rec = AddDCHTrecord(rec, 1, 4, DCRoster[TOID]);
                    //WRs
                    rec = AddDCHTrecord(rec, 3, 6, DCRoster[TOID]);
                    //TEs
                    rec = AddDCHTrecord(rec, 4, 3, DCRoster[TOID]);
                    //LTs
                    rec = AddDCHTrecord(rec, 5, 3, DCRoster[TOID]);
                    //RTs
                    rec = AddDCHTrecord(rec, 9, 3, DCRoster[TOID]);
                    //Cs
                    rec = AddDCHTrecord(rec, 7, 3, DCRoster[TOID]);
                    //LGs
                    rec = AddDCHTrecord(rec, 6, 3, DCRoster[TOID]);
                    //RG
                    rec = AddDCHTrecord(rec, 8, 3, DCRoster[TOID]);
                    //LEs
                    rec = AddDCHTrecord(rec, 10, 3, DCRoster[TOID]);
                    //RE
                    rec = AddDCHTrecord(rec, 11, 3, DCRoster[TOID]);
                    //DT
                    rec = AddDCHTrecord(rec, 12, 5, DCRoster[TOID]);
                    //MLBs
                    rec = AddDCHTrecord(rec, 14, 4, DCRoster[TOID]);
                    //ROLBs
                    rec = AddDCHTrecord(rec, 15, 3, DCRoster[TOID]);
                    //LOLBs
                    rec = AddDCHTrecord(rec, 13, 3, DCRoster[TOID]);
                    //CBs
                    rec = AddDCHTrecord(rec, 16, 5, DCRoster[TOID]);
                    //FSs
                    rec = AddDCHTrecord(rec, 18, 3, DCRoster[TOID]);
                    //SSs
                    rec = AddDCHTrecord(rec, 17, 3, DCRoster[TOID]);

                    //63 total up to here...

                    if (DC77.Checked || verNumber >= 16.0)
                    {
                        //FBs
                        rec = AddDCHTrecord(rec, 2, 2, DCRoster[TOID]);
                        //Ks
                        rec = AddDCHTrecord(rec, 19, 2, DCRoster[TOID]);
                        //Ps
                        rec = AddDCHTrecord(rec, 20, 2, DCRoster[TOID]);
                        //KRs
                        rec = AddDCHTrecord(rec, 21, 2, DCRoster[TOID]);
                        //PRs
                        rec = AddDCHTrecord(rec, 22, 2, DCRoster[TOID]);
                        //KOSs
                        rec = AddDCHTrecord(rec, 23, 2, DCRoster[TOID]);
                        //LSs
                        rec = AddDCHTrecord(rec, 24, 2, DCRoster[TOID]);

                        //63 + 16 = 77
                    }
                    else
                    {
                        //FBs
                        rec = AddDCHTrecord(rec, 2, 3, DCRoster[TOID]);
                        //Ks
                        rec = AddDCHTrecord(rec, 19, 3, DCRoster[TOID]);
                        //Ps
                        rec = AddDCHTrecord(rec, 20, 3, DCRoster[TOID]);
                        //KRs
                        rec = AddDCHTrecord(rec, 21, 5, DCRoster[TOID]);
                        //PRs
                        rec = AddDCHTrecord(rec, 22, 5, DCRoster[TOID]);
                        //KOSs
                        rec = AddDCHTrecord(rec, 23, 3, DCRoster[TOID]);
                        //LSs
                        rec = AddDCHTrecord(rec, 24, 3, DCRoster[TOID]);

                        //63 + 25 = 88
                    }

                    ProgressBarStep();

                }
            }

            EndProgressBar();
            MessageBox.Show("Depth Charts are complete!");
        }

        public void DepthChartMakerSingle(string tableName, int tgid, int leaguesize, bool skipPrompt = false)
        {
            StartProgressBar(GetTableRecCount(tableName));


            //count num of teams
            int teamCount = 0;
            if (TDYN)
            {
                teamCount = GetTableRecCount("TDYN");
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "TTYP", i) == 0) teamCount++;
                }
            }

            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;

            //clear DCHT
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) >= PGIDbeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDend)

                    DeleteRecord("DCHT", i, true);
            }

            CompactDB();


            int rec = TDB.TableRecordCount(dbIndex, "DCHT");
            int count = 0;
            List<List<double>> roster = new List<List<double>>();

            for (int j = 0; j < GetTableRecCount("PLAY"); j++)
            {
                int PGID = GetDBValueInt("PLAY", "PGID", j);

                if (PGID >= PGIDbeg && PGID <= PGIDend)
                {
                    int POVR = GetDBValueInt("PLAY", "POVR", j);
                    int PPOS = GetDBValueInt("PLAY", "PPOS", j);
                    int PRSD = GetDBValueInt("PLAY", "PRSD", j);
                    List<double> player = new List<double>();
                    if (PRSD != 1)
                    {
                        roster.Add(player);
                        roster[count].Add(j);
                        roster[count].Add(PGID);
                        roster[count].Add(PPOS);
                        count++;
                    }
                }
            }
            //Sort Depth Chart  KR = 21 PR = 22 KOS = 23 LS = 24

            //QBs
            rec = AddDCHTrecord(rec, 0, 3, roster);
            //RBs
            rec = AddDCHTrecord(rec, 1, 4, roster);
            //WRs
            rec = AddDCHTrecord(rec, 3, 6, roster);
            //TEs
            rec = AddDCHTrecord(rec, 4, 3, roster);
            //LTs
            rec = AddDCHTrecord(rec, 5, 3, roster);
            //RTs
            rec = AddDCHTrecord(rec, 9, 3, roster);
            //LGs
            rec = AddDCHTrecord(rec, 6, 3, roster);
            //RG
            rec = AddDCHTrecord(rec, 8, 3, roster);
            //Cs
            rec = AddDCHTrecord(rec, 7, 3, roster);
            //LEs
            rec = AddDCHTrecord(rec, 10, 3, roster);
            //RE
            rec = AddDCHTrecord(rec, 11, 3, roster);
            //DT
            rec = AddDCHTrecord(rec, 12, 5, roster);
            //MLBs
            rec = AddDCHTrecord(rec, 14, 4, roster);
            //ROLBs
            rec = AddDCHTrecord(rec, 15, 3, roster);
            //LOLBs
            rec = AddDCHTrecord(rec, 13, 3, roster);
            //CBs
            rec = AddDCHTrecord(rec, 16, 5, roster);
            //FSs
            rec = AddDCHTrecord(rec, 18, 3, roster);
            //SSs
            rec = AddDCHTrecord(rec, 17, 3, roster);

            if (leaguesize >= 136 || verNumber >= 16.0)
            {
                //FBs
                rec = AddDCHTrecord(rec, 2, 2, roster);
                //Ks
                rec = AddDCHTrecord(rec, 19, 2, roster);
                //Ps
                rec = AddDCHTrecord(rec, 20, 2, roster);
                //KRs
                rec = AddDCHTrecord(rec, 21, 2, roster);
                //PRs
                rec = AddDCHTrecord(rec, 22, 2, roster);
                //KOSs
                rec = AddDCHTrecord(rec, 23, 2, roster);
                //LSs
                rec = AddDCHTrecord(rec, 24, 2, roster);
            }
            else
            {
                //FBs
                rec = AddDCHTrecord(rec, 2, 3, roster);
                //Ks
                rec = AddDCHTrecord(rec, 19, 3, roster);
                //Ps
                rec = AddDCHTrecord(rec, 20, 3, roster);
                //KRs
                rec = AddDCHTrecord(rec, 21, 5, roster);
                //PRs
                rec = AddDCHTrecord(rec, 22, 5, roster);
                //KOSs
                rec = AddDCHTrecord(rec, 23, 3, roster);
                //LSs
                rec = AddDCHTrecord(rec, 24, 3, roster);
            }

            ProgressBarStep();



            EndProgressBar();
            if (!skipPrompt) MessageBox.Show(teamNameDB[tgid] + " Depth Charts are complete!");
        }

        public void DepthChartRemoveTeam(int tgid)
        {

            int PGIDbeg = tgid * 70;
            int PGIDend = PGIDbeg + 69;

            //clear DCHT
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) >= PGIDbeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDend)

                    DeleteRecord("DCHT", i, true);
            }

            CompactDB();
        }

        private int AddDCHTrecord(int rec, int ppos, int depthCount, List<List<double>> roster)
        {
            //Determine Position Ratings and sort by Position Overall Rating
            List<List<double>> PosRating = new List<List<double>>();
            double rating = 0;

            for (int k = 0; k < roster.Count; k++)
            {
                if (ppos <= 20) rating = CalculatePositionRating(roster[k][0], ppos);
                else if (ppos == 21) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 22) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 23) rating = CalculatePositionRating(roster[k][0], 19);
                else if (ppos == 24) rating = CalculatePositionRating(roster[k][0], 5);


                PosRating.Add(new List<double>());
                if (roster[k][2] == ppos) rating += 0;
                PosRating[k].Add(rating); //rating
                PosRating[k].Add(roster[k][1]); //pgid
                PosRating[k].Add(roster[k][2]); //ppos
                PosRating[k].Add(roster[k][0]); //rec

            }

            //sort by rating
            PosRating.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

            int count = 0;
            int i = 0;
            while (count < depthCount)
            {
                if (ppos > 20 || !IsStarter(PosRating[i][1]))
                {
                    AddTableRecord("DCHT", true);
                    double pgid = PosRating[i][1];
                    int playRec = Convert.ToInt32(PosRating[i][3]);
                    ChangeDBString("DCHT", "PGID", rec, Convert.ToString(pgid));
                    ChangeDBString("DCHT", "PPOS", rec, Convert.ToString(ppos));
                    ChangeDBString("DCHT", "ddep", rec, Convert.ToString(count));

                    if (DUMPER && ppos <= 18) ChangeDBInt("PLAY", "PPOS", playRec, ppos);
                    count++;
                    rec++;
                }
                i++;
            }

            return rec;
        }

        private bool IsStarter(double pgid)
        {
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) == Convert.ToInt32(pgid) && GetDBValueInt("DCHT", "ddep", i) == 0) return true;
            }
            return false;
        }
        #endregion



    }

}
