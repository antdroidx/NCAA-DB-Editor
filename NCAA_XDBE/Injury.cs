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

        private void StartInjuryEditorButton_Click(object sender, EventArgs e)
        {
            StartInjuryEditor();
        }

        private void StartInjuryEditor()
        {
            InjuryGridView.Rows.Clear();
            LoadInjuryList();
            RemoveInjuryButton.Visible = true;
            RemoveAllInjuryButton.Visible = true;
        }

        private void LoadInjuryList()
        {
            InjuryGridView.Rows.Clear();

            List<string> InjuryType = CreateInjuryTypeTable();
            List<string> InjuryLength = CreateInjuryLengthTable();


            for (int i = 0; i < GetTableRecCount("INJY"); i++)
            {
                int pgid = GetDBValueInt("INJY", "PGID", i);
                int rec = FindPGIDRecord(pgid);


                string pos = Positions[GetDBValueInt("PLAY", "PPOS", rec)];
                string name = GetPlayerNamefromPGID(pgid);
                string team = teamNameDB[(int)(GetDBValueInt("PLAY", "PGID", rec) / 70)];
                int rating = ConvertRating( GetDBValueInt("PLAY", "POVR", rec));
                string injuryType = InjuryType[GetDBValueInt("INJY", "INJT", i)];
                string injuryLength = InjuryLength[GetDBValueInt("INJY", "INJL", i)];

                if(GetDBValueInt("PLAY", "PRSD", rec) == 1 || GetDBValueInt("PLAY", "PRSD", rec) == 3)
                {
                    ChangeDBInt("INJY", "INJL", rec, 254);
                    injuryLength = "Season (RS)";
                }

                InjuryGridView.Rows.Add(1);
                InjuryGridView.Rows[i].Cells[0].Value = i;
                InjuryGridView.Rows[i].Cells[1].Value = team;
                InjuryGridView.Rows[i].Cells[2].Value = pos;
                InjuryGridView.Rows[i].Cells[3].Value = name;
                InjuryGridView.Rows[i].Cells[4].Value = rating;
                InjuryGridView.Rows[i].Cells[5].Value = injuryType;
                InjuryGridView.Rows[i].Cells[6].Value = injuryLength;

            }
            InjuryGridView.ClearSelection();
        }

        private void RemoveInjuryButton_Click(object sender, EventArgs e)
        {
            if (InjuryGridView.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove this injury?",
                    "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    int rowIndex = InjuryGridView.SelectedRows[0].Index;
                    RemoveInjury(Convert.ToInt32(InjuryGridView.Rows[rowIndex].Cells[0].Value));
                    
                    CompactDB();

                    LoadInjuryList(); // Refresh the grid after removal
                }
            }
            else
            {
                MessageBox.Show("Please select an injury to remove.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveAllInjuryButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to remove ALL INJURIES?",
                "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < GetTableRecCount("INJY"); i++)
                {
                    RemoveInjury(i);
                }
                CompactDB();

                LoadInjuryList(); // Refresh the grid after removal
            }


        }

        private void RemoveInjury(int rec)
        {
            DeleteRecord("INJY", rec, true);
        }



    }

}
