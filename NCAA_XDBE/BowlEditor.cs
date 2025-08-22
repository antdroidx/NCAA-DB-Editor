using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
//// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        /* Bowl Editing Table
         *  For editing Bowl Bids and Names
         *  Must check for non-affiliated Conf Champ Games and re-assign or remove
         * 
         */


        private void StartBowlEditor()
        {
            DoNotTrigger = true;
            ReorderBowlTable();

            //Set Data Source
            TeamA.DataSource = BowlTeams().Items;
            TeamB.DataSource = BowlTeams().Items;
            SGID.DataSource = StadiumNames().Items;
            BMON.DataSource = BowlMonths().Items;
            BDAY.DataSource = BowlDates().Items;

            GetBOWLData();

            DoNotTrigger = false;
        }

        private void ReorderBowlTable()
        {
            ReOrderTable("BOWL", "SEWN");
        }

        private ComboBox BowlTeams()
        {
            ComboBox comboBox = new ComboBox();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "TTYP", i) == 0) comboBox.Items.Add(GetDBValue("TEAM", "TDNA", i));
            }

            return comboBox;
        }

        private ComboBox BowlSeeds()
        {
            ComboBox comboBox = new ComboBox();

            for (int i = 0; i < 6; i++)
            {
                comboBox.Items.Add(i);
            }

            return comboBox;
        }

        private ComboBox StadiumNames()
        {
            ComboBox comboBox = new ComboBox();

            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                comboBox.Items.Add(GetDBValue("STAD", "TDNA", i));
            }

            return comboBox;
        }

        private ComboBox BowlMonths()
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Items.Add(12);
            comboBox.Items.Add(1);
            return comboBox;

        }

        private ComboBox BowlDates()
        {
            ComboBox comboBox = new ComboBox();
            for (int i = 1; i < 32; i++)
            {
                comboBox.Items.Add(i);
            }

            return comboBox;
        }


        /* Bowl Index
         *  0 - Active
         *  1 - BIDX
         *  2 - Bowl Name
         *  3 - Team A
         *  4 - Team A Score
         *  5 - vs
         *  6 - Team B Score
         *  7 - Team B 
         *  8 - Stadium
         *  9 - Month
         *  10 - Day
         *  11 - Week
         */

        private void GetBOWLData()
        {
            BowlsGrid.Rows.Clear();

            for (int i = 0; i < GetTableRecCount("BOWL"); i++)
            {
                if (GetDBValueInt("BOWL", "GTOD", i) > 0)
                {
                    //do nothing
                }
                else
                {
                    TDB.TDBTableRecordChangeDeleted(dbIndex, "BOWL", i, true);
                }
            }
            TDB.TDBDatabaseCompact(dbIndex);

            int x = GetTableRecCount("BOWL");

            for (int i = 0; i < GetTableRecCount("BOWL"); i++)
            {
                BowlsGrid.Rows.Add(new DataGridViewRow());

                BowlsGrid.Rows[i].Cells[0].Value = true;
                BowlsGrid.Rows[i].Cells[1].Value = GetDBValueInt("BOWL", "BIDX", i);
                BowlsGrid.Rows[i].Cells[2].Value = GetDBValue("BOWL", "BNME", i);
                BowlsGrid.Rows[i].Cells[3].Value = "xxx";
                BowlsGrid.Rows[i].Cells[4].Value = 0;
                BowlsGrid.Rows[i].Cells[5].Value = "vs";
                BowlsGrid.Rows[i].Cells[6].Value = 0;
                BowlsGrid.Rows[i].Cells[7].Value = "xxx";
                BowlsGrid.Rows[i].Cells[8].Value = GetTDNAfromSGID(GetDBValue("BOWL", "SGID", i));
                BowlsGrid.Rows[i].Cells[9].ValueType = typeof(int);
                BowlsGrid.Rows[i].Cells[9].Value = GetDBValueInt("BOWL", "BMON", i);
                BowlsGrid.Rows[i].Cells[10].ValueType = typeof(int);
                BowlsGrid.Rows[i].Cells[10].Value = GetDBValueInt("BOWL", "BDAY", i);
                BowlsGrid.Rows[i].Cells[11].Value = GetDBValueInt("BOWL", "SEWN", i);
                LoadBowlTeamData(i);

            }
        }

        private void LoadBowlTeamData(int bowlRec)
        {
            int bowlSGNM = GetDBValueInt("BOWL", "SGNM", bowlRec);
            int bowlSEWN = GetDBValueInt("BOWL", "SEWN", bowlRec);

            //find bowl in schedule
            for (int i = GetTableRecCount("SCHD") - 1; i > 0; i--)
            {
                int schdSGNM = GetDBValueInt("SCHD", "SGNM", i);
                int schdSEWN = GetDBValueInt("SCHD", "SEWN", i);
                if (schdSGNM == bowlSGNM && bowlSEWN == schdSEWN)
                {
                    BowlsGrid.Rows[bowlRec].Cells[3].Value = teamNameDB[GetDBValueInt("SCHD", "GATG", i)];
                    BowlsGrid.Rows[bowlRec].Cells[4].Value = GetDBValueInt("SCHD", "GASC", i);
                    BowlsGrid.Rows[bowlRec].Cells[6].Value = GetDBValueInt("SCHD", "GHSC", i);
                    BowlsGrid.Rows[bowlRec].Cells[7].Value = teamNameDB[GetDBValueInt("SCHD", "GHTG", i)];

                    break;
                }
            }
        }


        private void SaveBowlButton_Click(object sender, EventArgs e)
        {
            SaveBowlData();
        }


        private void SaveBowlData()
        {
            for (int i = 0; i < BowlsGrid.Rows.Count; i++)
            {
                //Check if Bowl is Active
                if (BowlsGrid.Rows[i].Cells[0].Value.Equals(true))
                {

                    ChangeDBString("BOWL", "BNME", i, Convert.ToString(BowlsGrid.Rows[i].Cells[2].Value));
                    //Change Teams in SCHD
                    UpdateBowlSCHD(i);
                    ChangeDBInt("BOWL", "SGID", i, GetSGIDfromTDNA(Convert.ToString(BowlsGrid.Rows[i].Cells[8].Value)));
                    ChangeDBInt("BOWL", "BMON", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[9].Value));
                    ChangeDBInt("BOWL", "BDAY", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[10].Value));
                    ChangeDBInt("BOWL", "SEWN", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[11].Value));
                }
                else
                {
                    RemoveBowlSCHD(i);
                }
            }

            MessageBox.Show("Bowl Update Complete!\n\nPlease remember to File -> Save!");
        }

        private void UpdateBowlSCHD(int bowlRec)
        {
            int bowlSGNM = GetDBValueInt("BOWL", "SGNM", bowlRec);
            int bowlSEWN = GetDBValueInt("BOWL", "SEWN", bowlRec);

            for (int i = GetTableRecCount("SCHD") - 1; i > 0; i--)
            {
                int schdSGNM = GetDBValueInt("SCHD", "SGNM", i);
                int schdSEWN = GetDBValueInt("SCHD", "SEWN", i);
                if (schdSGNM == bowlSGNM && bowlSEWN == schdSEWN)
                {
                    ChangeDBInt("SCHD", "GATG", i, FindTGIDfromTeamName(Convert.ToString(BowlsGrid.Rows[bowlRec].Cells[3].Value)));
                    ChangeDBInt("SCHD", "GHTG", i, FindTGIDfromTeamName(Convert.ToString(BowlsGrid.Rows[bowlRec].Cells[7].Value)));
                    break;
                }
            }
        }

        private void RemoveBowlSCHD(int bowlRec)
        {
            int bowlSGNM = GetDBValueInt("BOWL", "SGNM", bowlRec);
            int bowlSEWN = GetDBValueInt("BOWL", "SEWN", bowlRec);

            for (int i = GetTableRecCount("SCHD") - 1; i > 0; i--)
            {
                int schdSGNM = GetDBValueInt("SCHD", "SGNM", i);
                int schdSEWN = GetDBValueInt("SCHD", "SEWN", i);
                if (schdSGNM == bowlSGNM && bowlSEWN == schdSEWN)
                {
                    DeleteRecord("SCHD", i, true);
                    break;
                }
            }
            CompactDB();
        }

        #region DATA ERROR
        private void BowlsGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
        #endregion
    }
}
