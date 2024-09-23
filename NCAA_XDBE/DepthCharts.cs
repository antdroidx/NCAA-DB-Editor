using System;
using System.Collections.Generic;
using System.Drawing;
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
        private void StartDepthChartEditor()
        {
            DoNotTrigger = true;
            DCHTGrid.Rows.Clear();
            AddPositionsToDCHT();
            AddTeamsToDCHT();
            DepthChartIndex = 0;
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
            }
        }

        private void LoadDCHTPlayerData()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("PLAY");

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
                        if (p <= 20) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, p)));
                        else if (p <= 22) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 3)));
                        else if (p == 23) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 19)));
                        else if (p == 24) DCHTPlayers[row].Add(Convert.ToString(CalculatePositionRating(i, 5)));
                    }
                    DCHTPlayers[row].Add(Convert.ToString(i));
                    DCHTPlayers[row].Add(GetDBValue("PLAY", "PGID", i));
                    DCHTPlayers[row].Add(GetFirstNameFromRecord(i) + " " + GetLastNameFromRecord(i));
                    DCHTPlayers[row].Add(GetDBValue("PLAY", "PPOS", i));
                    DCHTPlayers[row].Add(GetDBValue("PLAY", "POVR", i));


                    /* 0-24 position ratings
                     *  rec  25  pgid  26  name  27  position 28 POVR 29
                     */
                    row++;
                    if (row > 69) break;
                }
                progressBar1.PerformStep();
            }

            DCHTPlayers.Sort((player1, player2) => player1[27].CompareTo(player2[27]));

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }


        private ComboBox CreateDCHTComboBox(int ppos)
        {

            ComboBox comboBox = new ComboBox();

            DCHTPlayers.Sort((player1, player2) => Convert.ToInt32(player2[ppos]).CompareTo(Convert.ToInt32(player1[ppos])));

            for (int i = 0; i < DCHTPlayers.Count; i++)
            {
                comboBox.Items.Add(DCHTPlayers[i][27]);
            }

            return comboBox;
        }

        private void LoadDCHTComboBoxes(int ppos)
        {
            
            DCHT0.DataSource = CreateDCHTComboBox(ppos).Items;
            DCHT1.DataSource = CreateDCHTComboBox(ppos).Items;
            DCHT2.DataSource = CreateDCHTComboBox(ppos).Items;
            DCHT3.DataSource = CreateDCHTComboBox(ppos).Items;
            DCHT4.DataSource = CreateDCHTComboBox(ppos).Items;
            DCHT5.DataSource = CreateDCHTComboBox(ppos).Items;            
        }

        private void LoadTeamDCHTData()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = GetTableRecCount("DCHT");

            int PGIDBeg = DepthChartIndex * 70;
            int PGIDEnd = PGIDBeg + 69;
            int count = 0;
            for (int i = 0; i < GetTableRecCount("DCHT"); i++)
            {
                if (GetDBValueInt("DCHT", "PGID", i) >= PGIDBeg && GetDBValueInt("DCHT", "PGID", i) <= PGIDEnd)
                {
                    int pgid = GetDBValueInt("DCHT", "PGID", i);
                    int ppos = GetDBValueInt("DCHT", "PPOS", i);
                    int ddep = GetDBValueInt("DCHT", "ddep", i);

                    string name = GetPlayerNamefromPGID(pgid);

                    DCHTGrid.Rows[ppos].Cells[ddep + 1].Value = name;
                    count++;
                }
                progressBar1.PerformStep();
                if (count > 87) break;
            }

            DisableDCHTCells();

            progressBar1.Visible = false;
            progressBar1.Value = 0;
        }

        private void DisableDCHTCells()
        {
            for (int i = 0; i < DCHTGrid.Rows.Count; i++)
            {
                for (int c = 0; c < DCHTGrid.Rows[i].Cells.Count; c++)
                {
                    if (DCHTGrid.Rows[i].Cells[c].Value == null)
                    {
                        DCHTGrid.Rows[i].Cells[c].ReadOnly = true;
                    }
                }
            }
        }

        //Team Selection
        private void DCHTTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoNotTrigger = true;
            DepthChartIndex = FindTGIDfromTeamName(Convert.ToString(DCHTTeam.SelectedItem));
            LoadTeamDCHTData();

            LoadDCHTPlayerData();
            LoadDCHTComboBoxes(29);
            DoNotTrigger = false;

        }

        //Update Player List by Cell
        private void DCHT_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DoNotTrigger) return;
            if (DCHTTeam.SelectedIndex == -1) return;
            int row = ((DataGridView)sender).CurrentRow.Index;
            UpdatePlayerList(row);
        }
        private void UpdatePlayerList(int row)
        {
            
            DCHT0.DataSource = CreateDCHTComboBox(row).Items;
            DCHT1.DataSource = CreateDCHTComboBox(row).Items;
            DCHT2.DataSource = CreateDCHTComboBox(row).Items;
            DCHT3.DataSource = CreateDCHTComboBox(row).Items;
            DCHT4.DataSource = CreateDCHTComboBox(row).Items;
            DCHT5.DataSource = CreateDCHTComboBox(row).Items;            
        }

        private void UpdateDatabase()
        {
            //Remove team from DCHT
            DepthChartRemoveTeam(DepthChartIndex);

            /* Add Data to DCHT Table */

            int rec = GetTableRecCount("DCHT");

            for (int row = 0; row < DCHTGrid.Rows.Count; row++)
            {
                for (int col = 0;  col < DCHTGrid.Columns.Count; col++)
                {
                    if(col > 0 && DCHTGrid.Rows[row].Cells[col].Value != null)
                    {
                        TDB.TDBTableRecordAdd(dbIndex, "DCHT", false);

                        int pgid = GetDCHTPlayerPGID(Convert.ToString(DCHTGrid.Rows[row].Cells[col].Value));
                        ChangeDBInt("DCHT", "PGID", rec, pgid);
                        ChangeDBInt("DCHT", "PPOS", rec, row);
                        ChangeDBInt("DCHT", "ddep", rec, col-1);

                        rec++;
                    }
                }

                row++;
            }

            MessageBox.Show("Depth Chart Database Update Complete!\n\nRemember to Save!");

        }

        private int GetDCHTPlayerPGID(string name)
        {
            for(int i = 0; i < DCHTPlayers.Count; i++)
            {
                if (DCHTPlayers[i][27] == name) return Convert.ToInt32(DCHTPlayers[i][26]);
            }

            return -1;
        }

        # region Buttons

        private void DCHTAutoSet_Click(object sender, EventArgs e)
        {
            DepthChartMakerSingle("DCHT", DepthChartIndex);
            LoadTeamDCHTData();
            LoadDCHTPlayerData();
            LoadDCHTComboBoxes(29);
        }

        private void DCHTClear_Click(object sender, EventArgs e)
        {
            DoNotTrigger = true;
            LoadTeamDCHTData();
            LoadDCHTPlayerData();
            LoadDCHTComboBoxes(29);
            DoNotTrigger = false;
        }

        private void UpdateDCHT_Click(object sender, EventArgs e)
        {
            UpdateDatabase();
        }

        #endregion

        //Data Error
        private void DCHTGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }

}
