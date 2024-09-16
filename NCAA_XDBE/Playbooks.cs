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
using System.Xml.Linq;
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
            List<string> AIGRNames = GetAIGRNames();
            PlaybookGrid.Rows.Clear();

            //DataGrid | 0: recNo  1: PBPL  2: AIGR  3: AIGR Name 4: prct  5: PLYL   6: PlayName 7: PTYP 8: Type Name
            for (int i = 0; i < GetTableRecCount("PBAI"); i++)
            {
                PlaybookGrid.Rows.Add(new List<string>());
                PlaybookGrid.Rows[i].Cells[0].Value = i;
                PlaybookGrid.Rows[i].Cells[1].Value = GetDBValueInt("PBAI", "PBPL", i);
                PlaybookGrid.Rows[i].Cells[2].Value = GetDBValueInt("PBAI", "AIGR", i);
                PlaybookGrid.Rows[i].Cells[3].Value = AIGRNames[GetDBValueInt("PBAI", "AIGR", i)];
                PlaybookGrid.Rows[i].Cells[4].Value = GetDBValueInt("PBAI", "prct", i);
                PlaybookGrid.Rows[i].Cells[5].Value = GetPLYLfromPBPL(GetDBValueInt("PBAI", "PBPL", i));
                PlaybookGrid.Rows[i].Cells[6].Value = GetPlayNameFomPLYL(Convert.ToInt32(PlaybookGrid.Rows[i].Cells[5].Value), PlayBookNames);
                PlaybookGrid.Rows[i].Cells[7].Value = GetPlayTypeFomPLYL(Convert.ToInt32(PlaybookGrid.Rows[i].Cells[5].Value), PlayBookNames);
                PlaybookGrid.Rows[i].Cells[8].Value = GetPlayTypeName(Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value));

                //Checks to see if play exists, if not, set PBAI to 0
                if (Convert.ToInt32(PlaybookGrid.Rows[i].Cells[5].Value) == -1) PlaybookGrid.Rows[i].Cells[4].Value = 0;
            }

            SetUpAIGRFilter();
            SetUpPlayTypeEditor();
            SetUpPlayNameEditor();
            CalculateProjPassRatio();

        }

        private List<List<string>> GetPlaybookNames()
        {
            List<List<string>> PlayBookNames = new List<List<string>>();

            PlayBookNames = CreateStringListsFromCSV(@"resources\playbooks\PLYL.csv", false);

            return PlayBookNames;
        }

        private List<string> GetAIGRNames()
        {
            List<string> AIGRNames = new List<string>();

            if (AIGRNameButton.Text == "Change to \r\nDefense AIGR")
                AIGRNames = CreateStringListfromCSV(@"resources\playbooks\AIGR.csv", false);
            else
                AIGRNames = CreateStringListfromCSV(@"resources\playbooks\AIGR-DEF.csv", false);

            return AIGRNames;
        }

        private void SetUpAIGRFilter()
        {
            List<string> AIGRNames = new List<string>();

            aigrFilterBox.Items.Clear();
            aigrFilterBox.Items.Add("ALL");

            if (AIGRNameButton.Text == "Change to \r\nDefense AIGR")
                AIGRNames = CreateStringListfromCSV(@"resources\playbooks\AIGR.csv", false);
            else
                AIGRNames = CreateStringListfromCSV(@"resources\playbooks\AIGR-DEF.csv", false);

            foreach (string name in AIGRNames)
            {
                for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
                {
                    if (PlaybookGrid.Rows[i].Cells[3].Value.Equals(name))
                    {
                        aigrFilterBox.Items.Add(name);
                        break;
                    }
                }
            }

            aigrFilterBox.SelectedIndex = 7;
        }

        private void SetUpPlayTypeEditor()
        {
            string[] name = CreatePlayTypeNames();
            PlayTypeBox.Items.Clear();

            PlayTypeBox.Items.Add("All Run Types");
            PlayTypeBox.Items.Add("All Pass Types");
            for (int i = 0; i < name.Length; i++)
            {

                for (int n = 0; n < PlaybookGrid.Rows.Count; n++)
                {
                    if (PlaybookGrid.Rows[n].Cells[8].Value.Equals(name[i]) && PlaybookGrid.Rows[n].Visible && !PlaybookGrid.Rows[n].Cells[8].Value.Equals(""))
                    {
                        PlayTypeBox.Items.Add(name[i]);
                        break;
                    }
                }
               
            }
            PlayTypeBox.SelectedIndex = 0;
        }

        private void SetUpPlayNameEditor()
        {
            PlayNameBox.Items.Clear();

            List<List<string>> PlayBookNames = GetPlaybookNames();

            for (int i = 0; i < PlayBookNames.Count; i++)
            {

                for (int n = 0; n < PlaybookGrid.Rows.Count; n++)
                {
                    if (PlaybookGrid.Rows[n].Cells[6].Value.Equals(PlayBookNames[i][6]) && PlaybookGrid.Rows[n].Visible && !PlaybookGrid.Rows[n].Cells[6].Value.Equals("") && !PlayNameBox.Items.Contains(PlayBookNames[i][6]))
                    {
                        PlayNameBox.Items.Add(PlayBookNames[i][6]);
                        break;
                    }
                }

            }
            PlayNameBox.Sorted = true;
            PlayNameBox.SelectedIndex = 0;
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
            if (PLYL == -1) return "N/A";

            for (int i = 0; i < PlayBookNames.Count; i++)
            {
                if (PlayBookNames[i][1] == Convert.ToString(PLYL)) return PlayBookNames[i][6];
            }
            return name;
        }

        private int GetPlayTypeFomPLYL(int PLYL, List<List<string>> PlayBookNames)
        {
            int name = -1;

            for (int i = 0; i < PlayBookNames.Count; i++)
            {
                if (PlayBookNames[i][1] == Convert.ToString(PLYL)) return Convert.ToInt32(PlayBookNames[i][3]);
            }
            return name;
        }

        private string[] CreatePlayTypeNames()
        {

            string[] name = new string[40];
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = "";
            }
            name[1] = "Flea Flicker";
            name[2] = "Option Pass";
            name[3] = "Pass";
            name[4] = "Play Action Pass";
            name[5] = "Screen Pass";
            name[6] = "Trick Play";
            name[11] = "QB Kneel/Sneak";
            name[12] = "Run";
            name[13] = "Run Counter";
            name[14] = "Run Draw Run";
            name[15] = "Run Pitch";
            name[16] = "Run Reverse";
            name[17] = "Option Run";
            name[18] = "Run Play Action";
            name[19] = "QB Sneak";
            name[21] = "Kick";
            name[31] = "Block";
            name[32] = "";
            name[33] = "Man";
            name[34] = "Man/Zone";
            name[35] = "Return";
            name[36] = "Zone";
            name[37] = "Blitz";
            name[38] = "Man Blitz";
            name[39] = "Zone Blitz";

            return name;

        }

        private string GetPlayTypeName(int val)
        {
            string[] name = CreatePlayTypeNames();
            if (val == -1) return "N/A";

            return name[val];
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
                wText.WriteLine("RecNo,PBPL,AIGR,AIGR Name,prct,PLYL,Play Name,Type,Type Name");


                //Get Team Lists
                for (int row = 0; row < PlaybookGrid.Rows.Count; row++)
                {
                    hbuilder.Clear();
                    for (int col = 0; col < PlaybookGrid.Rows[0].Cells.Count; col++)
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

        private void ImportPlaybookCSV_Click(object sender, EventArgs e)
        {
            //Import Data
            List<List<string>> PlaybookData = new List<List<string>>();
            openFileDialog2.Filter = "CSV Files (*.csv)|*.csv";
            Stream myStream = null;

            PlaybookGrid.Rows.Clear();

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                myStream = openFileDialog2.OpenFile();
                StreamReader sr = new StreamReader(myStream);

                //DataGrid | 0: recNo  1: PBPL  2: AIGR  3: AIGR Name 4: prct  5: PLYL   6: PlayName 7: PTYP 8: Type Name

                int Row = 0;
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(',');

                    if(Row != 0) PlaybookGrid.Rows.Add(new List<string>());

                    for (int column = 0; column < Line.Length; column++)
                    {
                        if (Row == 0) continue;
                        else
                        {
                            if (column < 3 || column == 4 || column == 5 || column == 7)
                            {
                                PlaybookGrid.Rows[Row-1].Cells[column].Value = Convert.ToInt32(Line[column]);
                            }
                            else
                            {
                                PlaybookGrid.Rows[Row-1].Cells[column].Value = Convert.ToString(Line[column]);
                            }
                        }


                    }
                    Row++;
                }
                sr.Close();
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
                ChangeDBInt("PBAI", "prct", i, Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value));
            }

            MessageBox.Show("PBAI Table is Updated!\n\nRemember to Save this File!");
        }

        private void AIGRNameButton_Click(object sender, EventArgs e)
        {
            if (AIGRNameButton.Text == "Change to \r\nDefense AIGR")
            {
                AIGRNameButton.Text = "Change to \r\nOffense AIGR";
            }
            else
            {
                AIGRNameButton.Text = "Change to \r\nDefense AIGR";
            }
            StartPlaybookEditor();
        }

        private void aigrFilterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = aigrFilterBox.SelectedItem as string;

            if (selected.Equals("ALL"))
            {
                for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
                {
                    PlaybookGrid.Rows[i].Visible = true;
                }
            }
            else
            {
                for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
                {
                    PlaybookGrid.Rows[i].Visible = true;
                    if (!PlaybookGrid.Rows[i].Cells[3].Value.Equals(selected))
                        PlaybookGrid.Rows[i].Visible = false;
                }

            }

            SetUpPlayTypeEditor();
            SetUpPlayNameEditor();
            CalculateProjPassRatio();
        }


        private void pcrtValueButton_Click(object sender, EventArgs e)
        {
            if (PlayTypeBox.SelectedIndex == -1) return;

            string selection = Convert.ToString(PlayTypeBox.Items[PlayTypeBox.SelectedIndex]);

            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                if (selection.Equals("All Pass Types"))
                {
                    if (Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) > 0 && Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) < 10 && PlaybookGrid.Rows[i].Visible)
                        PlaybookGrid.Rows[i].Cells[4].Value = Convert.ToInt32(pcrtNumBox.Value);
                }
                else if (selection.Equals("All Run Types"))
                {
                    if (Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) > 10 && Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) < 20 && PlaybookGrid.Rows[i].Visible)
                        PlaybookGrid.Rows[i].Cells[4].Value = Convert.ToInt32(pcrtNumBox.Value);
                }
                else if (PlaybookGrid.Rows[i].Cells[8].Value.Equals(selection) && PlaybookGrid.Rows[i].Visible)
                    PlaybookGrid.Rows[i].Cells[4].Value = Convert.ToInt32(pcrtNumBox.Value);
            }

            CalculateProjPassRatio();
            CalculatePlayTypeRatio();
        }


        private void CalculateProjPassRatio()
        {
            int pass = 0;
            int run = 0;
            int passPRCT = 0;
            int runPRCT = 0;

            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                if (Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) > 0 && Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) < 10 && PlaybookGrid.Rows[i].Visible)
                {
                    pass++;
                    passPRCT += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);
                }
                else if (Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) > 10 && Convert.ToInt32(PlaybookGrid.Rows[i].Cells[7].Value) < 20 && PlaybookGrid.Rows[i].Visible)
                {
                    run++;
                    runPRCT += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);
                }
            }

            if (pass + run > 0)
            {
                PassCounter.Text = "Pass Plays: " + pass + "  (" + (pass * 100 / (pass + run)) + "%)";
                RunCounter.Text = "Run Plays: " + run + "  (" + (run * 100 / (pass + run)) + "%)";
                ProjPassRatio.Text = "Projected Pass Ratio: " + passPRCT * 100 / (passPRCT + runPRCT) + "%";
            }
            else
            {
                PassCounter.Text = "Pass Plays: " + pass;
                RunCounter.Text = "Run Plays: " + run;
                ProjPassRatio.Text = "";
            }

            CalculatePlayNameRatio();

        }

        private void PlayTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePlayTypeRatio();
        }

        private void CalculatePlayTypeRatio()
        {
            string type = (string)PlayTypeBox.SelectedItem;
            int count = 0;
            int total = 0;
            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                if (Convert.ToString(PlaybookGrid.Rows[i].Cells[8].Value) == type && PlaybookGrid.Rows[i].Visible)
                {
                    count += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);

                }
                else if (PlaybookGrid.Rows[i].Visible)
                {
                    total += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);
                }
            }

            if (count > 0)
            {
                ProjTypeRatio.Text = "Projected Type Ratio: " + (count * 100) / (count + total) + "%";
            }
            else
            {
                ProjTypeRatio.Text = "";
            }
        }


        private void SetPlayNameValueButton_Click(object sender, EventArgs e)
        {
            if (PlayNameBox.SelectedIndex == -1) return;

            string selection = Convert.ToString(PlayNameBox.Items[PlayNameBox.SelectedIndex]);

            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                    if (PlaybookGrid.Rows[i].Cells[6].Value.Equals(selection) && PlaybookGrid.Rows[i].Visible)
                    PlaybookGrid.Rows[i].Cells[4].Value = Convert.ToInt32(PlayNameValue.Value);
            }

            CalculateProjPassRatio();
            CalculatePlayTypeRatio();
        }

        private void PlayNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePlayNameRatio();
        }

        private void CalculatePlayNameRatio()
        {
            if (PlayNameBox.SelectedIndex == -1) return;

            string type = (string)PlayNameBox.SelectedItem;
            int count = 0;
            int total = 0;
            for (int i = 0; i < PlaybookGrid.Rows.Count; i++)
            {
                if (Convert.ToString(PlaybookGrid.Rows[i].Cells[6].Value) == type && PlaybookGrid.Rows[i].Visible)
                {
                    count += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);

                }
                else if (PlaybookGrid.Rows[i].Visible)
                {
                    total += Convert.ToInt32(PlaybookGrid.Rows[i].Cells[4].Value);
                }
            }

            if (count > 0)
            {
                ProjTypeRatio.Text = "Projected Play Ratio: " + (count * 100) / (count + total) + "%";
            }
            else
            {
                ProjTypeRatio.Text = "";
            }
        }

    }



}
