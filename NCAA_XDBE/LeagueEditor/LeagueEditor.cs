using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using Label = System.Windows.Forms.Label;

namespace DB_EDITOR
{
    partial class LeagueMain : Form
    {
        // Drag & Drop state
        private Control dragSourceControl = null;
        private CheckedListBox dragSourceBox = null;
        private int dragSourceIndex = -1;
        private object dragSourceItem = null;



        //List of CheckBox Conferences
        private List<CheckedListBox> GetConfBoxObjects()
        {
            List<CheckedListBox> confBoxes = new List<CheckedListBox>();

            confBoxes.Add(conf1);
            confBoxes.Add(conf2);
            confBoxes.Add(conf3);
            confBoxes.Add(conf4);
            confBoxes.Add(conf5);
            confBoxes.Add(conf6);
            confBoxes.Add(conf7);
            confBoxes.Add(conf8);
            confBoxes.Add(conf9);
            confBoxes.Add(conf10);
            confBoxes.Add(conf11);
            confBoxes.Add(conf12);

            return confBoxes;
        }

        //List of Conf Names
        private List<TextBox> GetConfNameTextBoxes()
        {
            List<TextBox> confNames = new List<TextBox>();

            confNames.Add(confName1);
            confNames.Add(confName2);
            confNames.Add(confName3);
            confNames.Add(confName4);
            confNames.Add(confName5);
            confNames.Add(confName6);
            confNames.Add(confName7);
            confNames.Add(confName8);
            confNames.Add(confName9);
            confNames.Add(confName10);
            confNames.Add(confName11);
            confNames.Add(confName12);

            return confNames;
        }

        //List of Conf CGID Labels
        private List<Label> GetConfCGIDLabels()
        {
            List<Label> confCGID = new List<Label>();

            confCGID.Add(label1);
            confCGID.Add(label2);
            confCGID.Add(label3);
            confCGID.Add(label4);
            confCGID.Add(label5);
            confCGID.Add(label6);
            confCGID.Add(label7);
            confCGID.Add(label8);
            confCGID.Add(label9);
            confCGID.Add(label10);
            confCGID.Add(label11);
            confCGID.Add(label12);

            return confCGID;
        }

        //List of Conf CGID Prestige Boxes
        private List<NumericUpDown> GetConfPrestigeBoxes()
        {
            List<NumericUpDown> confCGID = new List<NumericUpDown>();

            confCGID.Add(numericUpDown1);
            confCGID.Add(numericUpDown2);
            confCGID.Add(numericUpDown3);
            confCGID.Add(numericUpDown4);
            confCGID.Add(numericUpDown5);
            confCGID.Add(numericUpDown6);
            confCGID.Add(numericUpDown7);
            confCGID.Add(numericUpDown8);
            confCGID.Add(numericUpDown9);
            confCGID.Add(numericUpDown10);
            confCGID.Add(numericUpDown11);
            confCGID.Add(numericUpDown12);

            return confCGID;
        }


        //List of FBS/FCS Button
        private List<Button> GetLeagueButtons()
        {
            List<Button> button = new List<Button>();

            button.Add(button1);
            button.Add(button2);
            button.Add(button3);
            button.Add(button4);
            button.Add(button5);
            button.Add(button6);
            button.Add(button7);
            button.Add(button8);
            button.Add(button9);
            button.Add(button10);
            button.Add(button11);
            button.Add(button12);

            return button;
        }

        //List of Conf Status Labels
        private List<Label> GetConfStatusLabels()
        {
            List<Label> confCGID = new List<Label>();

            confCGID.Add(label25);
            confCGID.Add(label26);
            confCGID.Add(label27);
            confCGID.Add(label28);
            confCGID.Add(label29);
            confCGID.Add(label30);
            confCGID.Add(label31);
            confCGID.Add(label32);
            confCGID.Add(label33);
            confCGID.Add(label34);
            confCGID.Add(label35);
            confCGID.Add(label36);

            return confCGID;
        }


        //Clear and Setup Tab Page
        private void ConferenceSetup()
        {
            DISABLE = true;
            TeamCount = 0;

            if (main.GetDBValueInt("SEAI", "SEWN", 0) > 0 && main.GetDBValueInt("SEAI", "SEWN", 0) < 22)
            {
                MessageBox.Show("Please only make conference edits during pre-season, at end of season, or in off-season!\n\n\nFCS Swapping will only safely work at end of season or beginning of off-season!");
                tabConf.Enabled = false;
            }
            else
            {
                tabConf.Enabled = true;
            }

            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();
            List<Label> cgidLabels = GetConfCGIDLabels();
            List<NumericUpDown> prestigeBoxes = GetConfPrestigeBoxes();
            List<Button> leagueButtons = GetLeagueButtons();
            List<int> cgidList = GetCGIDList();
            List<Label> statusLabels = GetConfStatusLabels();

            AddTeamsToListBox();


            foreach (var c in confBoxes)
            {
                c.Items.Clear();
                c.Enabled = true;
            }

            foreach (var c in confNames)
            {
                c.Text = string.Empty;
            }


            for (int i = 0; i < confBoxes.Count; i++)
            {
                confBoxes[i].Items.Clear();
                confNames[i].Text = string.Empty;
            }


            //Conf Names
            int box = 0;
            for (int i = 0; i < main.GetTableRecCount("CONF"); i++)
            {
                if (cgidList.Contains(main.GetDBValueInt("CONF", "CGID", i)))
                {
                    confNames[box].Text = main.GetDBValue("CONF", "CNAM", i);
                    AddTeamsToConfSetup(main.GetDBValueInt("CONF", "CGID", i), confBoxes[box], i, confNames[box]);
                    if (main.GetDBValueInt("CONF", "LGID", i) >= 1)
                    {
                        confBoxes[box].BackColor = Color.DarkGray;
                        leagueButtons[box].BackColor = Color.DarkGray;
                        leagueButtons[box].Text = "FCS";
                    }
                    box++;
                }
            }

            //CGID Labels
            for (int i = 0; i < cgidLabels.Count; i++)
            {
                cgidLabels[i].Text = "CGID: " + Convert.ToString(cgidList[i]);
            }

            //Prestige
            for (int i = 0; i < cgidList.Count; i++)
            {
                prestigeBoxes[i].Value = main.GetConfPrestigeFromCGID(cgidList[i]);

            }




            CountTeams();

            AddButton.Enabled = false;
            DeselectButton.Enabled = false;
            RemoveButton.Enabled = false;
            CustomLeagueToolStrip.Visible = true;

            DISABLE = false;
        }

        //Add Teams to Conferences and Label the Conference
        private void AddTeamsToConfSetup(int conf, CheckedListBox conferenceBox, int confRec, TextBox confName)
        {
            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValueInt("TEAM", "CGID", i) == conf)
                {
                    conferenceBox.Items.Add(main.GetDBValue("TEAM", "TDNA", i));
                    AllTeamsListBox.Items.Remove(main.GetDBValue("TEAM", "TDNA", i));
                }
            }

            for (int i = conferenceBox.Items.Count; i < maxTeams; i++)
            {
                conferenceBox.Items.Add("*");
            }

            // Enable drag/drop on the conference box
            conferenceBox.AllowDrop = true;
            conferenceBox.MouseDown -= CheckedListBox_MouseDown;
            conferenceBox.MouseDown += CheckedListBox_MouseDown;
            conferenceBox.DragOver -= ListBox_DragOver;
            conferenceBox.DragOver += ListBox_DragOver;
            conferenceBox.DragDrop -= CheckedListBox_DragDrop;
            conferenceBox.DragDrop += CheckedListBox_DragDrop;

        }


        private void AllTeamsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<CheckedListBox> confBoxes = GetConfBoxObjects();

            foreach (var c in confBoxes)
            {
                if (!c.Enabled)
                {
                    AddButton.Enabled = true;
                    break;
                }
            }

        }


        //Team Checked in Conference Trigger
        private void TeamChecked(object sender, ItemCheckEventArgs e)
        {
            if (DISABLE) return;

            CheckedListBox confBox = (CheckedListBox)sender;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            string teamsSelected = "";

            confBox.Enabled = false;

            int count = 0;
            foreach (var c in confBoxes)
            {
                if (!c.Enabled) count++;
            }


            if (count >= 1)
            {
                foreach (var c in confBoxes)
                {
                    if (!c.Enabled)
                    {
                        //teamsSelected += c.SelectedItem.ToString() + " ";
                    }
                    else c.Enabled = false;
                }

                //MessageBox.Show(teamsSelected);
            }

            DeselectButton.Enabled = true;
            RemoveButton.Enabled = true;

            if (AllTeamsListBox.SelectedItems.Count > 0) AddButton.Enabled = true;

            CountTeams();
        }



        //Switch Conference League
        private void LeagueChange_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int b = -1;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<Button> leagueButtons = GetLeagueButtons();

            for (int i = 0; i < leagueButtons.Count; i++)
            {
                if (leagueButtons[i] == button)
                {
                    b = i;
                    break;
                }
            }

            if (button.Text == "FBS")
            {
                button.Text = "FCS";
                button.BackColor = Color.DarkGray;
                confBoxes[b].BackColor = Color.DarkGray;
            }
            else
            {
                button.Text = "FBS";
                button.BackColor = Color.LightBlue;
                confBoxes[b].BackColor = Color.Gainsboro;
            }

            ReorderAsterisks(confBoxes[b]);
            /*
            List<string> teams = new List<string>();
            for(int i = 0; i < confBoxes[b].Items.Count; i++)
            {
                if (confBoxes[b].Items[i].ToString() != "*") teams.Add(confBoxes[b].Items[i].ToString());
            }

            for(int i = teams.Count; i < maxTeams; i++)
            {
                teams.Add("*");
            }

            confBoxes[b].Items.Clear();

            for (int i = 0; i < teams.Count; i++)
            {
                confBoxes[b].Items.Add(teams[i].ToString());
            }
            */

            CountTeams();
        }

        private void ReorderAsterisks(CheckedListBox confBox)
        {
            List<string> teams = new List<string>(); ;
            for (int i = 0; i < confBox.Items.Count; i++)
            {
                if (confBox.Items[i].ToString() != "*") teams.Add(confBox.Items[i].ToString());
            }

            for (int i = teams.Count; i < maxTeams; i++)
            {
                teams.Add("*");
            }

            confBox.Items.Clear();

            for (int i = 0; i < teams.Count; i++)
            {
                confBox.Items.Add(teams[i].ToString());
            }

            CountTeams();
        }


        //Add all teams to the box
        private void AddTeamsToListBox()
        {
            AllTeamsListBox.Items.Clear();
            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValueInt("TEAM", "TTYP", i) <= 1)
                    AllTeamsListBox.Items.Add(main.GetDBValue("TEAM", "TDNA", i));
            }
            // Enable drag for the AllTeamsListBox
            AllTeamsListBox.AllowDrop = true;
            AllTeamsListBox.MouseDown -= AllTeamsListBox_MouseDown;
            AllTeamsListBox.MouseDown += AllTeamsListBox_MouseDown;
            AllTeamsListBox.DragOver -= ListBox_DragOver;
            AllTeamsListBox.DragOver += ListBox_DragOver;
            AllTeamsListBox.DragDrop -= AllTeamsListBox_DragDrop;
            AllTeamsListBox.DragDrop += AllTeamsListBox_DragDrop;
        }


        //Add Team Button
        private void AddButton_Click(object sender, EventArgs e)
        {
            AddTeam();
        }

        private void AddTeam()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            int selBox = -1;
            int selItem = -1;
            for (int x = 0; x < confBoxes.Count; x++)
            {
                confBoxes[x].Enabled = true;

                if (confBoxes[x].CheckedItems.Count > 0)
                {
                    int selected = confBoxes[x].SelectedIndex;
                    int sel = AllTeamsListBox.SelectedIndex;
                    if (!confBoxes[x].Items[selected].Equals("*"))
                    {
                        AllTeamsListBox.Items.Add(confBoxes[x].Items[selected]);
                        confBoxes[x].Items[selected] = AllTeamsListBox.SelectedItem;
                        AllTeamsListBox.Items.RemoveAt(sel);
                        selBox = x;
                        selItem = selected;
                    }
                    else
                    {
                        confBoxes[x].Items[selected] = AllTeamsListBox.SelectedItem;
                        AllTeamsListBox.Items.RemoveAt(sel);
                        selBox = x;
                        selItem = selected;
                    }
                }
            }

            DeselectItems();
            AllTeamsListBox.Sorted = true;
            CountTeams();
            if (selItem < 17) confBoxes[selBox].SetSelected(selItem + 1, true);
            if (selItem < 17) confBoxes[selBox].SetItemChecked(selItem + 1, true);


            DISABLE = false;

        }


        //Remove Button
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveItems();
        }

        private void RemoveItems()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            int selBox = -1;
            int selItem = -1;

            for (int x = 0; x < confBoxes.Count; x++)
            {
                confBoxes[x].Enabled = true;

                if (confBoxes[x].CheckedItems.Count > 0)
                {
                    int sel = AllTeamsListBox.SelectedIndex;
                    int selected = confBoxes[x].SelectedIndex;
                    if (!confBoxes[x].Items[selected].Equals("*"))
                    {
                        AllTeamsListBox.Items.Add(confBoxes[x].Items[selected]);
                        confBoxes[x].Items[selected] = "*";
                    }
                    selBox = x;
                    selItem = selected;
                }
            }

            DeselectItems();
            AllTeamsListBox.Sorted = true;
            CountTeams();
            if (selBox != -1)
            {
                if (selItem < 17) confBoxes[selBox].SetSelected(selItem + 1, true);
                if (selItem < 17) confBoxes[selBox].SetItemChecked(selItem + 1, true);
            }

            DISABLE = false;
        }

        //Deselect Button
        private void DeselectTeamsButton_Click(object sender, EventArgs e)
        {
            DeselectItems();

        }

        //Deselect Action
        private void DeselectItems()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();

            for (int x = 0; x < confBoxes.Count; x++)
            {
                confBoxes[x].Enabled = true;
                for (int i = 0; i < confBoxes[x].Items.Count; i++)
                {
                    confBoxes[x].SetItemChecked(i, false);
                    confBoxes[x].SetSelected(i, false);
                }
            }


            AddButton.Enabled = false;
            DeselectButton.Enabled = false;
            RemoveButton.Enabled = false;

            DISABLE = false;
        }

        private void MouseDown_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DeselectItems();
            }
            if (e.Button == MouseButtons.Right)
            {
                RemoveItems();
            }
        }

        private void MouseClick_AddTeam(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //do something
            }
            if (e.Button == MouseButtons.Right)
            {
                if (AddButton.Enabled) AddTeam();
            }
        }

        //Clear League
        private void ClearLeagueButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This will clear all teams from the Conference Editor to start from scratch. If you want to undo this, you can just reopen the Conference Editor tab before you save.", "Clear League Configuration", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                ClearLeague();
            }
        }

        private void ClearLeague()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();

            for (int x = 0; x < confBoxes.Count; x++)
            {
                confBoxes[x].Enabled = true;
                for (int i = 0; i < confBoxes[x].Items.Count; i++)
                {
                    if (!confBoxes[x].Items[i].Equals("*"))
                        AllTeamsListBox.Items.Add(confBoxes[x].Items[i]);
                }
                confBoxes[x].Items.Clear();
                for (int i = confBoxes[x].Items.Count; i < maxTeams; i++)
                {
                    confBoxes[x].Items.Add("*");
                }
            }

            AllTeamsListBox.Sorted = true;
            CountTeams();
            DISABLE = false;
        }

        //Swap/Reset Button
        private void SaveButton_Cick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Updating the League will take a little bit of time. It will update the League data, remove and create new rosters depending on the teams added and removed and update depth charts.", "League Updater", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) UpdateDatabase();
        }

        //Update Status Labels
        private void UpdateConfStatusLabels()
        {
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();
            List<Label> cgidLabels = GetConfCGIDLabels();
            List<NumericUpDown> prestigeBoxes = GetConfPrestigeBoxes();
            List<Button> leagueButtons = GetLeagueButtons();
            List<int> cgidList = GetCGIDList();
            List<Label> statusLabels = GetConfStatusLabels();




        }

        //Count Team and Update Counter
        private void CountTeams()
        {
            TeamCount = 0;
            bool AllValid = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<Label> statusLabels = GetConfStatusLabels();




            for (int i = 0; i < confBoxes.Count; i++)
            {
                int count = 0;
                bool asterisk = false;
                bool valid = true;
                if (confBoxes[i].BackColor != Color.DarkGray)  //Check FBS
                {


                    foreach (var item in confBoxes[i].Items)
                    {
                        if (!item.Equals("*") && !asterisk)
                        {
                            count++;
                            TeamCount++;
                        }
                        else if (!item.Equals("*") && asterisk)
                        {
                            count++;
                            TeamCount++;
                            valid = false;
                        }
                        else
                        {
                            asterisk = true;
                        }
                    }

                    /* Counter and Checks */
                    if (i == 5 && valid && count > 0)
                    {
                        statusLabels[i].Text = "Count: " + count + " | Valid";
                        statusLabels[i].BackColor = Color.LightGreen;
                    }
                    else if (count >= 8 && count <= 24)
                    {
                        statusLabels[i].Text = "Count: " + count + " | Valid";
                        statusLabels[i].BackColor = Color.LightGreen;
                    }
                    else if (!valid)
                    {
                        statusLabels[i].Text = "Count: " + count + " | Not Valid\nMissing Team in * slot";
                        statusLabels[i].BackColor = Color.LightCoral;
                        AllValid = false;
                    }
                    else
                    {
                        statusLabels[i].Text = "Count: " + count + " | Not Valid\nIncorrect Num of Teams";
                        statusLabels[i].BackColor = Color.LightCoral;
                        AllValid = false;
                    }


                }
                else  //Check FCS
                {
                    foreach (var item in confBoxes[i].Items)
                    {
                        if (!item.Equals("*"))
                        {
                            count++;
                        }
                    }

                    if (count > 0)
                    {
                        statusLabels[i].Text = "Count: " + count + " | Valid";
                        statusLabels[i].BackColor = Color.LightGreen;
                    }
                    else
                    {
                        statusLabels[i].Text = "Count: " + count + " | Not Valid\nConf must have at least 1 Team";
                        statusLabels[i].BackColor = Color.LightCoral;
                        AllValid = false;
                    }
                }
            }

            /* Update Team Count and Save Button */

            if (verNumber <= 15.0) maxFBSTeams = 120;
            else maxFBSTeams = 136;

            if (TeamCount == maxFBSTeams && AllValid)
            {
                SaveButton.Visible = true;
                SaveButton.BackColor = Color.Crimson;
                LeagueTeamsLabel.Text = "League Teams: " + TeamCount;

            }
            else
            {
                SaveButton.Visible = false;
                LeagueTeamsLabel.Text = "League Teams: " + TeamCount + " [INVALID NUMBER OF TEAMS]";
            }

        }


        #region Keyboad Commands

        //Keyboard

        private void UserKeyPreview(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void UserKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveTeamUp();
                    break;
                case Keys.Down:
                    MoveTeamDown();
                    break;
            }
        }

        private void MoveTeamUp()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            string selItem = "";
            string nextItem = "";
            for (int x = 0; x < confBoxes.Count; x++)
            {
                //confBoxes[x].Enabled = true;

                if (confBoxes[x].CheckedItems.Count > 0)
                {
                    int selected = confBoxes[x].SelectedIndex;

                    if (!confBoxes[x].Items[selected].Equals("*") && selected > 0)
                    {
                        selItem = confBoxes[x].Items[selected].ToString();
                        nextItem = confBoxes[x].Items[selected - 1].ToString();

                        confBoxes[x].Items[selected] = nextItem;
                        confBoxes[x].Items[selected - 1] = selItem;
                        confBoxes[x].SelectedItems.Clear();
                        confBoxes[x].SelectedItem = selItem;
                        confBoxes[x].SetItemChecked(selected, false);
                        confBoxes[x].SetItemChecked(selected-1, true);
                    }
                }
            }

            CountTeams();
            DISABLE = false;
        }

        private void MoveTeamDown()
        {
            DISABLE = true;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            string selItem = "";
            string nextItem = "";
            for (int x = 0; x < confBoxes.Count; x++)
            {
                //confBoxes[x].Enabled = true;

                if (confBoxes[x].CheckedItems.Count > 0)
                {
                    int selected = confBoxes[x].SelectedIndex;

                    if (!confBoxes[x].Items[selected].Equals("*") && selected < 17)
                    {
                        selItem = confBoxes[x].Items[selected].ToString();
                        nextItem = confBoxes[x].Items[selected + 1].ToString();

                        confBoxes[x].Items[selected] = nextItem;
                        confBoxes[x].Items[selected + 1] = selItem;
                        confBoxes[x].SelectedItems.Clear();
                        confBoxes[x].SelectedItem = selItem;
                        confBoxes[x].SelectedItem = selItem;
                        confBoxes[x].SetItemChecked(selected, false);
                        confBoxes[x].SetItemChecked(selected + 1, true);
                    }
                }
            }
            CountTeams();
            DISABLE = false;
        }

        #endregion

        #region Default Data

        //List of CGIDs that can be used in dynasty
        private List<int> GetCGIDList()
        {

            List<int> cgid = new List<int>();

            cgid.Add(0);
            cgid.Add(1);
            cgid.Add(2);
            cgid.Add(3);
            cgid.Add(4);
            cgid.Add(5);
            cgid.Add(7);
            cgid.Add(9);
            cgid.Add(10);
            cgid.Add(11);
            cgid.Add(13);
            cgid.Add(14);

            return cgid;

        }

        #endregion


        #region Drag & Drop 
        // Event handlers:

        private void AllTeamsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ListBox lb = (ListBox)sender;
            int idx = lb.IndexFromPoint(e.Location);
            if (idx < 0 || idx >= lb.Items.Count) return;
            dragSourceControl = lb;
            dragSourceBox = null;
            dragSourceIndex = idx;
            dragSourceItem = lb.Items[idx];
            lb.DoDragDrop(dragSourceItem, DragDropEffects.Move);
        }

        private void CheckedListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            CheckedListBox clb = (CheckedListBox)sender;
            int idx = clb.IndexFromPoint(e.Location);
            if (idx < 0 || idx >= clb.Items.Count) return;
            if (clb.Items[idx].Equals("*")) return; // don't drag placeholder
            dragSourceControl = clb;
            dragSourceBox = clb;
            dragSourceIndex = idx;
            dragSourceItem = clb.Items[idx];
            clb.DoDragDrop(dragSourceItem, DragDropEffects.Move);
        }

        private void ListBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(string)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void AllTeamsListBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string))) return;
            string data = (string)e.Data.GetData(typeof(string));
            ListBox lb = (ListBox)sender;

            // remove from source
            if (dragSourceControl is ListBox srcLb)
            {
                srcLb.Items.RemoveAt(dragSourceIndex);
            }
            else if (dragSourceBox != null)
            {
                dragSourceBox.Items[dragSourceIndex] = "*";
            }

            // add to target
            lb.Items.Add(data);
            AllTeamsListBox.Sorted = true;
            CountTeams();
            // If item came from a conference, ensure its asterisks are reordered
            if (dragSourceBox != null)
                ReorderAsterisks(dragSourceBox);
        }

        private void CheckedListBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(string))) return;
            string data = (string)e.Data.GetData(typeof(string));
            CheckedListBox clb = (CheckedListBox)sender;

            // find drop index
            Point p = clb.PointToClient(new Point(e.X, e.Y));
            int idx = clb.IndexFromPoint(p);
            if (idx < 0) idx = clb.Items.Count - 1;

            int max = clb.Items.Count;

            // If dragging within same box -> reorder
            if (dragSourceBox == clb)
            {
                int src = dragSourceIndex;
                if (src == idx) return;
                object temp = clb.Items[src];
                if (src < idx)
                {
                    for (int i = src; i < idx; i++)
                        clb.Items[i] = clb.Items[i + 1];
                    clb.Items[idx] = temp;
                }
                else
                {
                    for (int i = src; i > idx; i--)
                        clb.Items[i] = clb.Items[i - 1];
                    clb.Items[idx] = temp;
                }
                CountTeams();
                ReorderAsterisks(clb);
                return;
            }

            // dragging from AllTeamsListBox
            if (dragSourceControl is ListBox srcLb)
            {
                // remove from source list
                srcLb.Items.Remove(data);

                // shift items down in target to make room
                object lastVal = clb.Items[max - 1];
                for (int i = max - 1; i > idx; i--)
                    clb.Items[i] = clb.Items[i - 1];
                clb.Items[idx] = data;

                // if lastVal was a real team, return it to AllTeamsListBox
                if (lastVal != null && !lastVal.Equals("*"))
                {
                    AllTeamsListBox.Items.Add(lastVal);
                    AllTeamsListBox.Sorted = true;
                }

                CountTeams();
                ReorderAsterisks(clb);
                return;
            }

            // dragging from another conference box
            if (dragSourceBox != null && dragSourceBox != clb)
            {
                // remove from source by shifting items up from the dragged index
                int src = dragSourceIndex;
                object removed = dragSourceBox.Items[src];
                for (int i = src; i < dragSourceBox.Items.Count - 1; i++)
                    dragSourceBox.Items[i] = dragSourceBox.Items[i + 1];
                dragSourceBox.Items[dragSourceBox.Items.Count - 1] = "*";

                // shift items down in target to make room
                object lastVal = clb.Items[max - 1];
                for (int i = max - 1; i > idx; i--)
                    clb.Items[i] = clb.Items[i - 1];
                clb.Items[idx] = data;

                // if lastVal was a real team, return it to AllTeamsListBox
                if (lastVal != null && !lastVal.Equals("*"))
                {
                    AllTeamsListBox.Items.Add(lastVal);
                    AllTeamsListBox.Sorted = true;
                }

                CountTeams();
                // reorder asterisks on both source and target
                if (dragSourceBox != null)
                    ReorderAsterisks(dragSourceBox);
                ReorderAsterisks(clb);
                return;
            }
        }

        #endregion

        #region Import Data

        private void importCustomLeagueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportLeagueData();
        }

        private void ImportLeagueData()
        {
            //Import Data
            List<List<string>> LeagueData = new List<List<string>>();
            openFileDialog2.Filter = "CSV Files (*.csv)|*.csv";
            Stream myStream = null;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                myStream = openFileDialog2.OpenFile();
                StreamReader sr = new StreamReader(myStream);


                int Row = 0;
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(',');
                    LeagueData.Add(new List<string>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        LeagueData[Row].Add(Convert.ToString(Line[column]));
                    }
                    Row++;
                }
                sr.Close();
            }

            LoadCustomLeague(LeagueData);
        }

        private void LoadCustomLeague(List<List<string>> LeagueData)
        {
            DISABLE = true;
            TeamCount = 0;

            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();
            main.CreateTeamDB();

            //Clear Conference Data
            foreach (var c in confBoxes)
            {
                c.Items.Clear();
                c.Enabled = true;
            }

            //Add ALL TEAMS to the ListBox
            AddTeamsToListBox();

            /*Load Data
             *  Row 0 = Conf Names
             *  Row 1+ = tgids
             *  Empty/Null =  *
             */

            for (int row = 0; row < LeagueData.Count; row++)
            {
                for (int column = 0; column < LeagueData[row].Count; column++)
                {
                    if (row == 0) confNames[column].Text = LeagueData[row][column].ToString();
                    else
                    {
                        if (LeagueData[row][column] == null || LeagueData[row][column] == "")
                        {
                            confBoxes[column].Items.Add("*");
                        }
                        else
                        {
                            if (AllTeamsListBox.Items.Contains(LeagueData[row][column].ToString()))
                            {
                                confBoxes[column].Items.Add(LeagueData[row][column].ToString());
                                AllTeamsListBox.Items.Remove(LeagueData[row][column].ToString());
                            }
                            else confBoxes[column].Items.Add("*");
                        }
                    }
                }
            }

            foreach (var c in confBoxes)
            {
                for (int i = c.Items.Count; i < maxTeams; i++)
                {
                    c.Items.Add("*");
                }
            }




            // Final Checks
            AllTeamsListBox.Sorted = true;
            CountTeams();
            DISABLE = false;
        }

        private void ExportCustomLeague_Click(object sender, EventArgs e)
        {

            //Set-Up Database
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<TextBox> confNames = GetConfNameTextBoxes();

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
                for (int i = 0; i < confNames.Count; i++)
                {
                    if (i != 0) hbuilder.Append(",");
                    hbuilder.Append(confNames[i].Text.ToString());
                }

                wText.WriteLine(hbuilder);


                //Get Team Lists
                for (int row = 0; row < 18; row++)
                {
                    hbuilder.Clear();
                    for (int col = 0; col < confBoxes.Count; col++)
                    {
                        if (col != 0) hbuilder.Append(",");
                        hbuilder.Append(confBoxes[col].Items[row].ToString());
                    }
                    wText.WriteLine(hbuilder);
                }

                MessageBox.Show("Export Complete");
                wText.Dispose();
                wText.Close();
            }
        }


        #endregion

        #region Randomize League
        private void RandomizeLeagueButton_Click(object sender, EventArgs e)
        {
            if(TeamSelectionBox.SelectedIndex < 0 || TeamsPerConfBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose the league configuration first!");
                return;
            }

            RandomizeLeagueSetup();
        }
        private void RandomizeLeagueSetup()
        {
            //Clear Conferences
            ClearLeague();
            int teamCount = Convert.ToInt32(TeamsPerConfBox.SelectedItem);
            int confCount = maxFBSTeams/teamCount;
            int league = Convert.ToInt32(TeamSelectionBox.SelectedIndex);
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<NumericUpDown> prestigeBoxes = GetConfPrestigeBoxes();
            List<string> teamList = new List<string>();

            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if(league == 2 && main.GetDBValueInt("TEAM", "TTYP", i) < 2 || main.GetDBValueInt("TEAM", "TTYP", i) == league) 
                    teamList.Add(main.GetDBValue("TEAM", "TDNA", i));
            }

            if (league ==1)
            {
                for (int i = 0; 1 < (121 - teamList.Count); i++)
                {
                    int t = rand.Next(0, main.GetTableRecCount("TEAM"));
                    if (main.GetDBValueInt("TEAM", "TTYP", t) == 0)
                        teamList.Add(main.GetDBValue("TEAM", "TDNA", i));
                }
            }

            for (int c = 0; c < confBoxes.Count; c++)
            {
                if (teamCount < 11 && confCount > 0 || teamCount > 10 && c != 5 && confCount > 0)
                {
                    for (int i = 0; i < teamCount; i++)
                    {
                        int x = rand.Next(0, teamList.Count);
                        confBoxes[c].Items[i] = teamList[x];
                        AllTeamsListBox.Items.Remove(teamList[x]);
                        AllTeamsListBox.Sorted = true;
                        teamList.RemoveAt(x);
                        teamList.Sort();
                    }
                    confCount--;
                }
            }

            CountTeams();

        }



        #endregion

    }
}
