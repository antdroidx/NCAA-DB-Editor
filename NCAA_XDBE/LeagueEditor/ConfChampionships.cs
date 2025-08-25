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

        /* Bowl Updater for Conf Championships (NEXT MOD ONLY!)
         *  Next Mod - Usable Bowl Range = 1 - 16
         *  Need way to determine if it is next mod == Look for Kennesaw State and tgid?
         *  Add new Champs as BIDX 41+
         *  
         *  Remove Conf Champ if it does not exist anymore (<8)
         *  
         */


        private void ConfChampsSetup()
        {
            ChampGrid.Rows.Clear();
            ChampGrid.AllowUserToDeleteRows = false;
            ChampGrid.AllowUserToAddRows = false;

            // Set the column header style.
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            ChampGrid.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            //Set Data Sources
            ((DataGridViewComboBoxColumn)ChampGrid.Columns[1]).DataSource = GetAvailableBowls().Items;

            AddMissingChampionshipGames();
        }

        private void AddMissingChampionshipGames()
        {
            //Check for SEWN 16 and if all BCI1 values are in it.

            List<int> confChamps = new List<int>();
            //Check Bowls
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (main.GetDBValueInt("BOWL", "SEWN", i) == 16) confChamps.Add(main.GetDBValueInt("BOWL", "BCI1", i));
            }

            //Get List of FBS Conferences
            List<int> missingCChamps = new List<int>();
            for (int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (main.GetDBValueInt("CONF", "LGID", i) == 0 && main.GetDBValueInt("CONF", "CGID", i) != 5 && !confChamps.Contains(main.GetDBValueInt("CONF", "CGID", i))) missingCChamps.Add(i);
            }

            for (int i = 0; i < missingCChamps.Count; i++) 
            {
                ChampGrid.Rows.Add(new DataGridViewRow());
                ChampGrid.Rows[i].Cells[0].Value = main.GetDBValue("CONF", "CNAM", missingCChamps[i]);
            }
        }

        private ComboBox GetAvailableBowls()
        {
            ComboBox availableBowls = new ComboBox();

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
                    availableBowls.Items.Add(main.GetDBValue("BOWL", "BNME", i));
                }
            }


            //Add Non-Required Bowls to List (BIDX 1-16)
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (!Next26Mod) 
                { 
                    if (main.GetDBValueInt("BOWL", "BIDX", i) > 1 && main.GetDBValueInt("BOWL", "BIDX", i) <= 16)
                    availableBowls.Items.Add(main.GetDBValue("BOWL", "BNME", i));
                }
                else
                {
                    if (main.GetDBValueInt("BOWL", "BIDX", i) >= 28 && main.GetDBValueInt("BOWL", "BIDX", i) <= 53)
                        availableBowls.Items.Add(main.GetDBValue("BOWL", "BNME", i));
                }

            }

            return availableBowls;
        }

        private void SaveChamps_Click(object sender, EventArgs e)
        {
            ConvertBowlsToConfChamps();
        }

        private void ConvertBowlsToConfChamps()
        {
            //Count Champs for SGNM/BIDX
            int count = 0;
            for (int i = 0; i < main.GetTableRecCount("BOWL"); i++)
            {
                if (main.GetDBValueInt("BOWL", "SEWN", i) == 16) count++;
            }

            //Swap Bowls
            for (int i = 0; i < ChampGrid.Rows.Count; i++)
            {
                if (ChampGrid.Rows[i].Cells[0].Value != null && ChampGrid.Rows[i].Cells[1].Value != null)
                {
                    //replacing rec
                    int rec = main.GetBOWLrecfromBNME(Convert.ToString(ChampGrid.Rows[i].Cells[1].Value));

                    SwapBIDX(rec, main.GetCONFrecFromCNAM(Convert.ToString(ChampGrid.Rows[i].Cells[0].Value)), count);
                    count++;
                }
            }

            MessageBox.Show("Conf Championships Updated!");
            ConfChampsSetup();
            ReOrderBowl();
        }

        private void SwapBIDX(int rec, int recA, int count)
        {
            main.ChangeDBInt("BOWL", "BCI1", rec, main.GetConfCGID(recA));
            main.ChangeDBInt("BOWL", "BCR1", rec, 1);
            main.ChangeDBInt("BOWL", "BCI2", rec, main.GetConfCGID(recA));
            main.ChangeDBInt("BOWL", "BCR2", rec, 1);
            main.ChangeDBString("BOWL", "BNME", rec, main.GetConfNameFromCGID(main.GetConfCGID(recA)) + " Championship");
            main.ChangeDBInt("BOWL", "SGNM", rec, count);
            main.ChangeDBInt("BOWL", "BMON", rec, 12);
            main.ChangeDBInt("BOWL", "SEWN", rec, 16);
            if (!Next26Mod || main.GetTableRecCount("BOWL") < 40)
            {
                main.ChangeDBInt("BOWL", "BIDX", rec, 33 + count);
                main.ChangeDBInt("BOWL", "BDAY", rec, 1);
            }
            else
            {
                main.ChangeDBInt("BOWL", "BIDX", rec, 54 + count);
                main.ChangeDBInt("BOWL", "BDAY", rec, 6);
            }
        }

        private void ReOrderBowl()
        {
            main.ReOrderTable("BOWL", "BIDX");
        }

    }
}
