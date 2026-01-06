using ComboBox = System.Windows.Forms.ComboBox;

namespace DB_EDITOR
{
    partial class LeagueMain : Form
    {

        /* Bowl Editing Table
         *  For editing Bowl Bids and Names
         *  Must check for non-affiliated Conf Champ Games and re-assign or remove
         * 
         */


        private void BowlsSetup()
        {
            DISABLE = true;

            bowlsDeleted = new List<int>();

            //Set Data Source
            BCI1.DataSource = BowlConferences().Items;
            //BCR1.DataSource = BowlSeeds().Items;
            BCI2.DataSource = BowlConferences().Items;
            //BCR2.DataSource = BowlSeeds().Items;
            SGID.DataSource = StadiumNames().Items;
            BMON.DataSource = BowlMonths().Items;
            BDAY.DataSource = BowlDates().Items;

            GetBOWLData();

            DISABLE = false;
        }

        private ComboBox BowlConferences()
        {
            ComboBox comboBox = new ComboBox();

            for (int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (main.GetDBValueInt("CONF", "LGID", i) == 0) comboBox.Items.Add(main.GetDBValue("CONF", "CNAM", i));
            }

            comboBox.Items.Add("At-Large");

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

            for (int i = 0; i < main.GetTableRecCount("STAD"); i++)
            {
                comboBox.Items.Add(main.GetDBValue("STAD", "TDNA", i));
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

        private void GetBOWLData()
        {
            BowlsGrid.Rows.Clear();
            List<int> confChampExtras = CheckForExtraConfChamps();

            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                BowlsGrid.Rows.Add(new DataGridViewRow());
                if (main.GetTableRecCount("BOWL") > 40 && main.GetDBValueInt("BOWL", "BIDX", i) < 28 || main.GetTableRecCount("BOWL") > 40 && main.GetDBValueInt("BOWL", "BIDX", i) >= 54 || main.GetTableRecCount("BOWL") < 40 && main.GetDBValueInt("BOWL", "BIDX", i) == 0 || main.GetTableRecCount("BOWL") < 40 && main.GetDBValueInt("BOWL", "BIDX", i) > 16)
                {
                    BowlsGrid.Rows[i].ReadOnly = true;
                    BowlsGrid.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
                }
                if (confChampExtras.Contains(main.GetDBValueInt("BOWL", "BIDX", i)))
                {
                    BowlsGrid.Rows[i].ReadOnly = false;
                    BowlsGrid.Rows[i].Cells[1].Style.ForeColor = Color.Red;
                    BowlsGrid.Rows[i].Cells[0].Value = FindAvailableBIDX(main.GetDBValueInt("BOWL", "BIDX", i));
                    BowlsGrid.Rows[i].Cells[1].Value = "NCAA Next Bowl";
                    BowlsGrid.Rows[i].Cells[2].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[3].Value = 0;
                    BowlsGrid.Rows[i].Cells[4].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[5].Value = 0;
                    BowlsGrid.Rows[i].Cells[6].Value = "NCAA Next";
                    BowlsGrid.Rows[i].Cells[7].Value = 12;
                    BowlsGrid.Rows[i].Cells[8].Value = 25;
                }
                else
                {
                    BowlsGrid.Rows[i].Cells[0].Value = main.GetDBValueInt("BOWL", "BIDX", i);
                    BowlsGrid.Rows[i].Cells[1].Value = main.GetDBValue("BOWL", "BNME", i);
                    BowlsGrid.Rows[i].Cells[2].Value = main.GetConfNameFromCGID(main.GetDBValueInt("BOWL", "BCI1", i));
                    BowlsGrid.Rows[i].Cells[3].Value = main.GetDBValueInt("BOWL", "BCR1", i);
                    BowlsGrid.Rows[i].Cells[4].Value = main.GetConfNameFromCGID(main.GetDBValueInt("BOWL", "BCI2", i));
                    BowlsGrid.Rows[i].Cells[5].Value = main.GetDBValueInt("BOWL", "BCR2", i);
                    BowlsGrid.Rows[i].Cells[6].Value = main.GetTDNAfromSGID(main.GetDBValue("BOWL", "SGID", i));
                    BowlsGrid.Rows[i].Cells[7].Value = main.GetDBValueInt("BOWL", "BMON", i);
                    BowlsGrid.Rows[i].Cells[8].Value = main.GetDBValueInt("BOWL", "BDAY", i);
                }
                if (main.GetDBValueInt("BOWL", "BIDX", i) > 27 && main.GetDBValue("BOWL", "BNME", i).Contains("Championship"))
                {
                    BowlsGrid.Rows[i].Cells[1].Value = main.GetConfNameFromCGID(main.GetDBValueInt("BOWL", "BCI1", i)) + " Championship";
                }
            }

            BowlsGrid.Sort(BIDX, System.ComponentModel.ListSortDirection.Ascending);
        }

        private List<int> CheckForExtraConfChamps()
        {
            //Check for outdated conf champs

            List<int> confs = new List<int>();
            for (int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (main.GetDBValueInt("CONF", "LGID", i) == 0 && main.GetDBValueInt("CONF", "CGID", i) != 5) confs.Add(i);
            }

            List<int> confChamps = new List<int>();
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (main.GetDBValueInt("BOWL", "SEWN", i) == 16 && !confs.Contains(main.GetDBValueInt("BOWL", "BCI1", i)))
                {
                    confChamps.Add(main.GetDBValueInt("BOWL", "BIDX", i));
                }
            }

            return confChamps;
        }

        private void DeleteBowlButton_Click(object sender, EventArgs e)
        {
            while (BowlsGrid.SelectedRows.Count > 0)
            {
                bowlsDeleted.Add(Convert.ToInt32(BowlsGrid.SelectedRows[0].Cells[0].Value));
                BowlsGrid.Rows.RemoveAt(BowlsGrid.SelectedRows[0].Index);
            }
        }

        private void SaveBowlButton_Click(object sender, EventArgs e)
        {
            if (CheckBowlTable())
            {
                SaveBowlData();
            }
            else
            {
                MessageBox.Show("Please Remove or Update the Red Text Bowl Row");
            }

        }

        private bool CheckBowlTable()
        {
            bool ready = true;

            /*
            for (int i = 0; i < BowlsGrid.Rows.Count; i++)
            {
                if (BowlsGrid.Rows[i].Cells[1].Style.ForeColor == Color.Red) return false;
            }
            */

            return ready;
        }


        private void BowlCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DISABLE) return;
            DataGridView row = (DataGridView)sender;

            if (BowlsGrid.Rows[row.SelectedCells[0].RowIndex].Cells[1].Style.ForeColor == Color.Red)
            {
                BowlsGrid.Rows[row.SelectedCells[0].RowIndex].Cells[1].Style.ForeColor = Color.Black;
            }
        }

        private int FindAvailableBIDX(int currentBIDX)
        {
            //Determine rec for conf champ that needs to be replaced
            int rec = -1;
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (main.GetDBValueInt("BOWL", "BIDX", i) == currentBIDX) rec = i;
            }

            //Get list of BIDX between 0-16
            List<int> BIDX = new List<int>();
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (main.GetDBValueInt("BOWL", "BIDX", i) < 17) BIDX.Add(main.GetDBValueInt("BOWL", "BIDX", i));
            }

            //find number available
            for (int i = 0; i < 17; i++)
            {
                if (!BIDX.Contains(i))
                {
                    main.ChangeDBInt("BOWL", "BIDX", rec, i);
                    MessageBox.Show(main.GetDBValue("BOWL", "BNME", rec) + " bowl index value and data was changed!");
                    return i;
                }
            }

            return -1;
        }

        private void SaveBowlData()
        {
            main.ReOrderTable("BOWL", "BIDX");

            //Remove Bowls that were deleted
            for (int k = 0; k < bowlsDeleted.Count; k++)
            {
                for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
                {
                    if (main.GetDBValueInt("BOWL", "BIDX", i) == bowlsDeleted[k]) TDB.TDBTableRecordChangeDeleted(0, "BOWL", i, true);
                }
            }

            TDB.TDBDatabaseCompact(0);

            for (int i = 0; i < BowlsGrid.Rows.Count; i++)
            {
                main.ChangeDBInt("BOWL", "BIDX", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[0].Value));
                main.ChangeDBString("BOWL", "BNME", i, Convert.ToString(BowlsGrid.Rows[i].Cells[1].Value));
                main.ChangeDBInt("BOWL", "BCI1", i, main.GetConfCGID(main.GetCONFrecFromCNAM(Convert.ToString(BowlsGrid.Rows[i].Cells[2].Value))));
                main.ChangeDBInt("BOWL", "BCR1", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[3].Value));
                main.ChangeDBInt("BOWL", "BCI2", i, main.GetConfCGID(main.GetCONFrecFromCNAM(Convert.ToString(BowlsGrid.Rows[i].Cells[4].Value))));
                main.ChangeDBInt("BOWL", "BCR2", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[5].Value));
                main.ChangeDBInt("BOWL", "SGID", i, main.GetSGIDfromTDNA(Convert.ToString(BowlsGrid.Rows[i].Cells[6].Value)));
                main.ChangeDBInt("BOWL", "BMON", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[7].Value));
                main.ChangeDBInt("BOWL", "BDAY", i, Convert.ToInt32(BowlsGrid.Rows[i].Cells[8].Value));
                if (Convert.ToInt32(BowlsGrid.Rows[i].Cells[0].Value) < 28)
                {
                    main.ChangeDBInt("BOWL", "SGNM", i, 127);
                    main.ChangeDBInt("BOWL", "SEWN", i, 31);
                }
            }



            MessageBox.Show("Bowl Update Complete!");
        }


        private void AtLargeButton_Click(object sender, EventArgs e)
        {
            SetBowlsToAtLarge();
        }

        private void SetBowlsToAtLarge()
        {
            for (int i = 0; i < BowlsGrid.Rows.Count; i++)
            {
                if (main.GetTableRecCount("BOWL") > 40 && Convert.ToInt32(BowlsGrid.Rows[i].Cells[0].Value) < 54)
                {
                    BowlsGrid.Rows[i].Cells[2].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[3].Value = 0;
                    BowlsGrid.Rows[i].Cells[4].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[5].Value = 0;
                }
                else if (main.GetTableRecCount("BOWL") < 40 && Convert.ToInt32(BowlsGrid.Rows[i].Cells[0].Value) < 28)
                {
                    BowlsGrid.Rows[i].Cells[2].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[3].Value = 0;
                    BowlsGrid.Rows[i].Cells[4].Value = "At-Large";
                    BowlsGrid.Rows[i].Cells[5].Value = 0;
                }


            }
        }

    }
}