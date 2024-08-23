using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

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

        //List of Labels
        private List<Label> GetConfNameLabels()
        {
            List<Label> confNames = new List<Label>();

            confNames.Add(ConfName1);
            confNames.Add(ConfName2);
            confNames.Add(ConfName3);
            confNames.Add(ConfName4);
            confNames.Add(ConfName5);
            confNames.Add(ConfName6);
            confNames.Add(ConfName7);
            confNames.Add(ConfName8);
            confNames.Add(ConfName9);
            confNames.Add(ConfName10);
            confNames.Add(ConfName11);
            confNames.Add(ConfName12);

            return confNames;
        }

        //Clear and Setup Tab Page
        private void ConferenceSetup()
        {
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            List<Label> confNames = GetConfNameLabels();

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

            SwapButton.Enabled = false;


            int box = 0;
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "CONF"); i++)
            {
                if (GetDBValueInt("CONF", "LGID", i) == 0)
                {
                    AddTeamsToConfSetup(GetDBValueInt("CONF", "CGID", i), confBoxes[box], i, confNames[box]);
                    box++;
                }
            }

            for (int i = box; i < confBoxes.Count; i++)
            {
                confBoxes[i].Visible = false;
                confNames[i].Visible = false;
            }

        }

        //Add Teams to Conferences and Label the Conference
        private void AddTeamsToConfSetup(int conf, CheckedListBox conferenceBox, int confRec, Label confName)
        {
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "CGID", i) == conf)
                {
                    conferenceBox.Items.Add(GetDBValue("TEAM", "TDNA", i));
                    confName.Text = GetDBValue("CONF", "CNAM", confRec);
                }
            }
        }


        //Team Checked in Conference Trigger
        private void TeamChecked(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox confBox = (CheckedListBox)sender;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();
            string teamsSelected = "";

            confBox.Enabled = false;

            int count = 0;
            foreach (var c in confBoxes)
            {
                if(!c.Enabled) count++;
            }

            if (count >= 2) 
            {
                foreach (var c in confBoxes)
                {
                    if(!c.Enabled)
                    {
                        //c.Enabled = true;
                        teamsSelected += c.SelectedItem.ToString() + " ";
                    }
                    else c.Enabled = false;
                }

                SwapButton.Enabled = true;

                //MessageBox.Show(teamsSelected);
            }
            
        }

        //Swap/Reset Button
        private void SwapButton_Click(object sender, EventArgs e)
        {
            SwapTeams();
            ConferenceSetup();
        }


        private void DeselectTeamsButton_Click(object sender, EventArgs e)
        {
            ConferenceSetup();
        }

        //Swap Teams in TSWP and in TEAM
        private void SwapTeams()
        {
            string TeamA = "";
            string TeamB = "";
            bool ASelected = false;
            List<CheckedListBox> confBoxes = GetConfBoxObjects();

            foreach (var c in confBoxes)
            {
                if(!ASelected && c.SelectedItems.Count > 0)
                {
                    TeamA = c.SelectedItem.ToString();
                    ASelected = true;
                } else if(ASelected && c.SelectedItems.Count > 0)
                {
                    TeamB = c.SelectedItem.ToString();
                    break;
                }
            }

            int recA = FindTeamRecfromTeamName(TeamA);
            int recB = FindTeamRecfromTeamName(TeamB);

            int swor = TDB.TableRecordCount(dbIndex, "TSWP");

            TDB.TDBTableRecordAdd(dbIndex, "TSWP", false);
            ChangeDBString("TSWP", "TGID", swor, GetDBValue("TEAM", "TGID", recA));
            ChangeDBString("TSWP", "TIDR", swor, GetDBValue("TEAM", "TGID", recB));
            ChangeDBInt("TSWP", "SWOR", swor, swor);

            int cgidA = GetTeamCGID(recA);
            int dgidA = GetTeamDGID(recA);
            int cgidB = GetTeamCGID(recB);
            int dgidB= GetTeamDGID(recB);

            ChangeDBInt("TEAM", "CGID", recA, cgidB);
            ChangeDBInt("TEAM", "DGIG", recA, dgidB);
            ChangeDBInt("TEAM", "CGID", recB, cgidA);
            ChangeDBInt("TEAM", "DGIG", recB, dgidA);

            MessageBox.Show(TeamA + " and " + TeamB + " have been swapped!");

        }

        //Swap Teams in the Schedule if in Pre-Season
        private void SwapSchedule()
        {

        }


    }
}
