using System;
using System.Collections.Generic;
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
        /* Playbook Viewer */

        private void StartPlaybookEditor()
        {
            List<List<string>> PlayBookNames = GetPlaybookNames();
            // PLYL = 1  Name = 6

            PlaybookGrid.Rows.Clear();

            //DataGrid | 0: recNo  1: PBPL  2: AIGR  3: prct  4: PLYL   5: name
            for (int i = 0; i < GetTableRecCount("PBAI"); i++)
            {
                PlaybookGrid.Rows.Add(new List<string>());
                PlaybookGrid.Rows[i].Cells[0].Value = i;
                PlaybookGrid.Rows[i].Cells[1].Value = GetDBValueInt("PBAI", "PBPL", i);
                PlaybookGrid.Rows[i].Cells[2].Value = GetDBValueInt("PBAI", "AIGR", i);
                PlaybookGrid.Rows[i].Cells[3].Value = GetDBValueInt("PBAI", "prct", i);
                PlaybookGrid.Rows[i].Cells[4].Value = GetPLYLfromPBPL(GetDBValueInt("PBAI", "PBPL", i));
                PlaybookGrid.Rows[i].Cells[5].Value = GetPlayNameFomPLYL(Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value), PlayBookNames);
            }


        }

        private List<List<string>> GetPlaybookNames()
        {
            List<List<string>> PlayBookNames = new List<List<string>>();

            PlayBookNames = CreateStringListsFromCSV(@"resources\playbooks\PLYL.csv", false);

            return PlayBookNames;
        }

        private int GetPLYLfromPBPL(int PBPL)
        {
            int PLYL = -1;

            for (int i = 0; i < GetTableRecCount("PBPL"); i++)
            {
                if (GetDBValueInt("PBPL", "PBPL", i) == PBPL) return GetDBValueInt("PBPL", "PLYL", i);
            }
            return PLYL;
        }

        private string GetPlayNameFomPLYL(int PLYL, List<List<string>> PlayBookNames)
        {
            string name = "";

            for (int i = 0; i < PlayBookNames.Count; i++)
            {
                if (PlayBookNames[i][1] == Convert.ToString(PLYL)) return PlayBookNames[i][6];
            }
            return name;
        }

        private void ExportPBData_Click(object sender, EventArgs e)
        {
            //Save Dialog
            SaveFileDialog SaveDialog1 = new SaveFileDialog();
            SaveDialog1.Filter = "CSV Files (*.csv)|*.csv";
            //Stream myStream = File.Create("CustomLeague.csv");
            if (SaveDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream myStream = SaveDialog1.OpenFile();
                StreamWriter wText = new StreamWriter(myStream);
                StringBuilder hbuilder = new StringBuilder();

                //write headers
                //DataGrid |  0: PBPL  1: AIGR  2: prct  3: PLYL   4: name
                wText.WriteLine("RecNo,PBPL,AIGR,prct,PLYL,name");


                //Get Team Lists
                for (int row = 0; row < PlaybookGrid.Rows.Count; row++)
                {
                    hbuilder.Clear();
                    for (int col = 0; col < 6; col++)
                    {
                        if (col != 0) hbuilder.Append(",");
                        hbuilder.Append(PlaybookGrid.Rows[row].Cells[col].Value.ToString());
                    }
                    wText.WriteLine(hbuilder);
                }

                MessageBox.Show("Export Complete");
                wText.Dispose();
                wText.Close();
            }
        }


        private void savePBDataButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GetTableRecCount("PBAI"); i++)
            {
                TDB.TDBTableRecordChangeDeleted(dbIndex, "PBAI", i, true);
            }
            TDB.TDBDatabaseCompact(dbIndex);

            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                TDB.TDBTableRecordAdd(dbIndex, "PBAI", false);
                ChangeDBInt("PBAI", "PBPL", i, Convert.ToInt32(PlaybookGrid.Rows[i].Cells[1].Value));
                ChangeDBInt("PBAI", "AIGR", i, Convert.ToInt32(PlaybookGrid.Rows[i].Cells[2].Value));
                ChangeDBInt("PBAI", "prct", i, Convert.ToInt32(PlaybookGrid.Rows[i].Cells[3].Value));
            }
        }
    }

}
