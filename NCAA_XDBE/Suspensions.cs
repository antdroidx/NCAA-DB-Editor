using System;
using System.Collections.Generic;
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

        private void StartSuspensionEditorButton_Click(object sender, EventArgs e)
        {
            StartSuspensionEditor();
        }

        private void StartSuspensionEditor()
        {
            SuspensionView.Rows.Clear();
            LoadSuspensionList();
            RemoveSuspensionButton.Visible = true;
            RemoveAllSuspensionsButton.Visible = true;
        }

        private void LoadSuspensionList()
        {
            SuspensionView.Rows.Clear();

            List<string> SuspensionType = CreateInjuryTypeTable();
            List<string> SuspensionLength = CreateInjuryLengthTable();

            int row = 0;
            for (int i = GetTableRecCount("SPYR")-1; i >= 0; i--)
            {
                int pgid = GetDBValueInt("SPYR", "PGID", i);
                int rec = FindPGIDRecord(pgid);


                string pos = Positions[GetDBValueInt("PLAY", "PPOS", rec)];
                string name = GetPlayerNamefromPGID(pgid);
                string team = teamNameDB[(int)(GetDBValueInt("PLAY", "PGID", rec) / 70)];
                int rating = ConvertRating( GetDBValueInt("PLAY", "POVR", rec));

                string suspensionType = "";
                int type = GetDBValueInt("SPYR", "SINF", i);
                if (type == 0)
                {
                    suspensionType = "Team Rules";
                }
                else if (type == 1)
                {
                    suspensionType = "Academics";
                }
                else if (type == 2)
                {
                    suspensionType = "Suspension";
                }
                
                
                int suspensionLength = GetDBValueInt("SPYR", "SEWN", i) - GetDBValueInt("SEAI", "SEWN", 0);
                string length = suspensionLength + " weeks";
                if (suspensionLength <= 0)
                {
                    suspensionLength = 0;
                    length = "Ended";
                }
                else if (suspensionLength == 1)
                {
                    length = "1 Week";
                }

                if (GetDBValueInt("SPYR", "SSUS", i) == 1)
                {
                    length = "TBD";
                }
                SuspensionView.Rows.Add(1);
                SuspensionView.Rows[row].Cells[0].Value = i;
                SuspensionView.Rows[row].Cells[1].Value = team;
                SuspensionView.Rows[row].Cells[2].Value = pos;
                SuspensionView.Rows[row].Cells[3].Value = name;
                SuspensionView.Rows[row].Cells[4].Value = rating;
                SuspensionView.Rows[row].Cells[5].Value = suspensionType;
                SuspensionView.Rows[row].Cells[6].Value = length;
                row++;
            }
            SuspensionView.ClearSelection();
        }

        private void RemoveSuspensionButton_Click(object sender, EventArgs e)
        {
            if (SuspensionView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this injury?",
                    "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    int rowIndex = SuspensionView.SelectedRows[0].Index;
                    RemoveSuspension(Convert.ToInt32(SuspensionView.Rows[rowIndex].Cells[0].Value));
                    
                    CompactDB();

                    LoadSuspensionList(); // Refresh the grid after removal
                }
            }
            else
            {
                MessageBox.Show("Please select an suspension to remove.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveAllSuspensions_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove ALL SUSPENSIONS?",
                "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < GetTableRecCount("SPYR"); i++)
                {
                    RemoveSuspension(i);
                }
                CompactDB();

                LoadSuspensionList(); // Refresh the grid after removal
            }


        }

        private void RemoveSuspension(int rec)
        {
            DeleteRecord("SPYR", rec, true);
        }



    }

}
