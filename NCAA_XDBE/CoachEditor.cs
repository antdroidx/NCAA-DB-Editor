using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /* COACH EDITOR */

        #region COACH EDITOR - STARTUP

        public void StartCoachEditor()
        {
            AddCoachFilters();
            LoadCoachList(CoachFilter.SelectedIndex);
        }
        private void AddCoachFilters()
        {
            CoachFilter.Items.Clear();
            CoachFilter.Items.Add("ALL");
            CoachFilter.Items.Add("Active");
            CoachFilter.Items.Add("Inactive");
            CoachFilter.SelectedItem = CoachFilter.Items[1];
        }

        private void CoachFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CoachFilter.SelectedIndex == 0) LoadCoachList(0);
            else if (CoachFilter.SelectedIndex == 1) LoadCoachList(1);
            else LoadCoachList(2);
        }

        public void LoadCoachList(int active)
        {
            CoachListBox.Items.Clear();
            CoachEditorList = new List<List<string>>();
            int row = 0;
            if (active == 0)
            {
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    int TGID = GetDBValueInt("COCH", "TGID", i);

                    if (GetDBValueInt("COCH", "TGID", i) < 512)
                    {
                        CoachEditorList.Add(new List<string>());
                        CoachEditorList[row].Add(Convert.ToString(i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + GetDBValue("COCH", "CCPO", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)] + " [" + GetDBValue("COCH", "CCPO", i) + "]");
                        CoachEditorList[row].Add(teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CCPO", i));
                        row++;
                    }
                }
            }
            else if (active == 1)
            {
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    if (GetDBValueInt("COCH", "TGID", i) < 511)
                    {
                        CoachEditorList.Add(new List<string>());
                        CoachEditorList[row].Add(Convert.ToString(i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + GetDBValue("COCH", "CCPO", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)] + " [" + GetDBValue("COCH", "CCPO", i) + "]");
                        CoachEditorList[row].Add(teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CCPO", i));
                        row++;
                    }
                }
            } else
            {
                for (int i = 0; i < GetTableRecCount("COCH"); i++)
                {
                    if (GetDBValueInt("COCH", "TGID", i) == 511)
                    {
                        CoachEditorList.Add(new List<string>());
                        CoachEditorList[row].Add(Convert.ToString(i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + GetDBValue("COCH", "CCPO", i));
                        CoachEditorList[row].Add(GetDBValue("COCH", "CLFN", i) + " " + GetDBValue("COCH", "CLLN", i) + " | " + teamNameDB[GetDBValueInt("COCH", "TGID", i)] + " [" + GetDBValue("COCH", "CCPO", i) + "]");
                        CoachEditorList[row].Add(teamNameDB[GetDBValueInt("COCH", "TGID", i)]);
                        CoachEditorList[row].Add(GetDBValue("COCH", "CCPO", i));
                        row++;
                    }
                }
            }

            /* CoachEditorList
             * 0 - record
             * 1 - name string
             * 2 - name + team string
             * 3 - name + performance string
             * 4 - name + team/performance string
             * 5 - team
             * 6 - performance
             */

            if (CoachShowTeamBox.Checked && !CoachPerfCheckBox.Checked)
            {
                CoachEditorList.Sort((player1, player2) => player1[5].CompareTo(player2[5]));

                for (int i = 0; i < CoachEditorList.Count; i++)
                {
                    if (CoachEditorList[i] != null) CoachListBox.Items.Add(CoachEditorList[i][2]);
                }
            } 
            else if (CoachPerfCheckBox.Checked && !CoachShowTeamBox.Checked)
            {
                CoachEditorList.Sort((player1, player2) => Convert.ToInt32(player2[6]).CompareTo(Convert.ToInt32(player1[6])));

                for (int i = 0; i < CoachEditorList.Count; i++)
                {
                    if (CoachEditorList[i] != null) CoachListBox.Items.Add(CoachEditorList[i][3]);
                }

            }
            else if (CoachPerfCheckBox.Checked && CoachShowTeamBox.Checked)
            {
                CoachEditorList.Sort((player1, player2) => player1[5].CompareTo(player2[5]));

                for (int i = 0; i < CoachEditorList.Count; i++)
                {
                    if (CoachEditorList[i] != null) CoachListBox.Items.Add(CoachEditorList[i][4]);
                }

            }
            else
            {
                CoachEditorList.Sort((player1, player2) => player1[1].CompareTo(player2[1]));

                for (int i = 0; i < CoachEditorList.Count; i++)
                {
                    if (CoachEditorList[i] != null) CoachListBox.Items.Add(CoachEditorList[i][1]);
                }
            }
        }

        private void CoachListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CoachIndex = Convert.ToInt32(CoachEditorList[CoachListBox.SelectedIndex][0]);
            GetCoachEditorData(CoachIndex);
        }

        private void CoachShowTeamBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadCoachList(CoachFilter.SelectedIndex);
        }

        private void CoachPerfCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            LoadCoachList(CoachFilter.SelectedIndex);
        }
        #endregion

        //GET DATA
        #region Load Data

        public void GetCoachEditorData(int EditorIndex)
        {
            DoNotTrigger = true;


            //User Coach
            if (GetDBValue("COCH", "CFUC", EditorIndex) == "1") CFUCBox.Checked = true;
            else CFUCBox.Checked = false;

            //Recruit Assistance
            if (GetDBValue("COCH", "CFRC", EditorIndex) == "1") RecruitAssistanceBox.Checked = true;
            else RecruitAssistanceBox.Checked = false;

            //Discipline Assistance
            if (GetDBValue("COCH", "CSAS", EditorIndex) == "1") DisciplineAssistanceBox.Checked = true;
            else DisciplineAssistanceBox.Checked = false;

            //Head Coach Info
            CoachFirstNameBox.Text = GetCoachFirstNamefromRec(EditorIndex);
            CoachLastNameBox.Text = GetCoachLastNamefromRec(EditorIndex);

            //Coach ID
            CCIDBox.Text = GetDBValue("COCH", "CCID", EditorIndex);

            //Team Name
            GetCoachTeamList();
            if (GetDBValueInt("COCH", "TGID", EditorIndex) == 511) CoachTeamList.SelectedItem = "INACTIVE";
            else CoachTeamList.SelectedItem = teamNameDB[GetDBValueInt("COCH", "TGID", EditorIndex)];


            //Coach Body/Face/Hair
            GetCoachSkinToneItems();
            if (GetDBValueInt("COCH", "CSKI", EditorIndex) > 0 && GetDBValueInt("COCH", "CSKI", EditorIndex) <= 2)
            {
                CSKIBox.SelectedIndex = 1;
                ChangeDBInt("COCH", "CSKI", EditorIndex, 2);
            }
            else if (GetDBValueInt("COCH", "CSKI", EditorIndex) > 3)
            {
                CSKIBox.SelectedIndex = 2;
                ChangeDBInt("COCH", "CSKI", EditorIndex, 5);
            }
            else CSKIBox.SelectedIndex = GetDBValueInt("COCH", "CSKI", EditorIndex);


            GetCoachBodyItems();
            CBSZBox.SelectedIndex = GetDBValueInt("COCH", "CBSZ", EditorIndex);
            GetCoachHairColorItems();
            CHARBox.SelectedIndex = GetDBValueInt("COCH", "CHAR", EditorIndex);
    
            GetCoachFaceItems();
            CFEXBox.SelectedIndex = GetDBValueInt("COCH", "CFEX", EditorIndex);
            GetCoachEyeItems();
            CTgwBox.SelectedIndex = GetDBValueInt("COCH", "CTgw", EditorIndex);
            GetCoachHatItems();
            COHTBox.SelectedIndex = GetDBValueInt("COCH", "COHT", EditorIndex);
            if (COHTBox.SelectedIndex == 1) ChangeDBInt("COCH", "CThg", EditorIndex, 1);
            else if (COHTBox.SelectedIndex == 2) ChangeDBInt("COCH", "CThg", EditorIndex, 0);

            GetCThgItems();
            if (GetDBValueInt("COCH", "CThg", EditorIndex) > 4) ChangeDBInt("COCH", "CThg", EditorIndex, 0);
            else if (GetDBValueInt("COCH", "CThg", EditorIndex) == 1 && COHTBox.SelectedIndex != 1) ChangeDBInt("COCH", "CThg", EditorIndex, 0);
            CTHGBox.SelectedIndex = GetDBValueInt("COCH", "CThg", EditorIndex);


            //Ratings
            HCPrestigeNum.Value = GetDBValueInt("COCH", "CPRE", EditorIndex);
            HCPrestigeNum.BackColor = GetPrestigeColor(HCPrestigeNum).BackColor;

            CoachCCPONum.Value = GetDBValueInt("COCH", "CCPO", EditorIndex);
            CoachCCPONum.BackColor = GetPerformanceColor(CoachCCPONum).BackColor;

            //Off-Season Budgets
            CoachDisciplineBox.Text = GetDBValue("COCH", "CDPC", EditorIndex);
            CoachTrainingBox.Value = GetDBValueInt("COCH", "CTPC", EditorIndex);
            CoachRecruitingBox.Value = GetDBValueInt("COCH", "CRPC", EditorIndex);

            //Playbook & Strategies
            GetCoachPlaybookItems();
            CoachPlaybookBox.SelectedIndex = GetCoachPlaybookSelectedIndex();

            GetCoachOffTypeItems();
            CoachOffTypeBox.SelectedIndex = GetDBValueInt("COCH", "COST", EditorIndex);

            GetCoachDefTypeItems();
            CoachDefTypeBox.SelectedIndex = GetDBValueInt("COCH", "CDST", EditorIndex);
            
            CoachCOTRBox.Value = GetDBValueInt("COCH", "COTR", EditorIndex);
            CoachCOTABox.Value = GetDBValueInt("COCH", "COTA", EditorIndex);
            CoachCOTSBox.Value = GetDBValueInt("COCH", "COTS", EditorIndex);
            CoachCDTRBox.Value = GetDBValueInt("COCH", "CDTR", EditorIndex);
            CoachCDTABox.Value = GetDBValueInt("COCH", "CDTA", EditorIndex);
            CoachCDTSBox.Value = GetDBValueInt("COCH", "CDTS", EditorIndex);


            //Coaching History

            YearsCoached.Text = GetDBValue("COCH", "CYCD", EditorIndex);

            
            int ctop = GetDBValueInt("COCH", "CTOP", EditorIndex);
            int tmpr = FindTeamPrestige(GetDBValueInt("COCH", "TGID", EditorIndex));

            string teamPrs = Convert.ToString(tmpr);
            if (ctop > tmpr) teamPrs += "  (" + (tmpr - ctop) + ")";
            else if (ctop < tmpr) teamPrs += "  (+" + (tmpr - ctop) + ")";

            CoachTeamPrestige.Text = teamPrs;

            ContractInfo.Text = GetDBValue("COCH", "CCYR", CoachIndex) + " / " + GetDBValue("COCH", "CCFY", CoachIndex) + " Years Remaining";

            YearsWithTeam.Text = GetDBValue("COCH", "CTYR", EditorIndex);

            SeasonRecord.Text = GetDBValue("COCH", "CSWI", EditorIndex) + " - " + GetDBValue("COCH", "CSLO", EditorIndex);
            BowlRecord.Text = GetDBValue("COCH", "CBLW", EditorIndex) + " - " + GetDBValue("COCH", "CBLL", EditorIndex);
            Top25Record.Text = GetDBValue("COCH", "C25W", EditorIndex) + " - " + GetDBValue("COCH", "C25L", EditorIndex);
            CareerRecord.Text = GetDBValue("COCH", "CCWI", EditorIndex) + " - " + GetDBValue("COCH", "CCLO", EditorIndex);
            WinningSeasons.Text = GetDBValue("COCH", "CCSW", EditorIndex);
            NationalTitles.Text = GetDBValue("COCH", "CCNT", EditorIndex);
            ConfTitles.Text = GetDBValue("COCH", "CCCT", EditorIndex);



            DoNotTrigger = false;
            progressBar1.Value = 0;
        }

        private void GetCoachTeamList()
        {
            CoachTeamList.Items.Clear();

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if(GetDBValueInt("TEAM", "TTYP", i) == 0)
                CoachTeamList.Items.Add(GetDBValue("TEAM", "TDNA", i));
            }
            CoachTeamList.Items.Add("INACTIVE");
        }

        private void GetCoachSkinToneItems()
        {
            CSKIBox.Items.Clear();
            CSKIBox.Items.Add("Light"); //0
            CSKIBox.Items.Add("Medium"); //2
            CSKIBox.Items.Add("Dark"); //5
        }

        private void GetCoachBodyItems()
        {
            CBSZBox.Items.Clear();
            CBSZBox.Items.Add("Small");
            CBSZBox.Items.Add("Medium");
            CBSZBox.Items.Add("Large");
        }

        private void GetCoachFaceItems()
        {
            CFEXBox.Items.Clear();
            CFEXBox.Items.Add("Young 1");
            CFEXBox.Items.Add("Young 2");
            CFEXBox.Items.Add("Medium 1");
            CFEXBox.Items.Add("Medium 2");
            CFEXBox.Items.Add("Old 1");
            CFEXBox.Items.Add("Old 2");
        }

        private void GetCoachHairColorItems()
        {
            CHARBox.Items.Clear();
            CHARBox.Items.Add("Black");
            CHARBox.Items.Add("Blonde");
            CHARBox.Items.Add("Brown");
            CHARBox.Items.Add("Red");
            CHARBox.Items.Add("Lt Brown");
            CHARBox.Items.Add("Gray");
        }

        private void GetCThgItems()
        {
            CTHGBox.Items.Clear();
            CTHGBox.Items.Add("Short and/or Visor"); //0
            CTHGBox.Items.Add("Hat Only"); //1
            CTHGBox.Items.Add("Medium"); //2
            CTHGBox.Items.Add("Bald"); //3
            CTHGBox.Items.Add("Mullet"); //4
        }

        private void GetCoachHatItems()
        {
            COHTBox.Items.Clear();
            COHTBox.Items.Add("None");
            COHTBox.Items.Add("Hat");
            COHTBox.Items.Add("Visor");

        }

        private void GetCoachEyeItems()
        {
            CTgwBox.Items.Clear();
            CTgwBox.Items.Add("None");
            CTgwBox.Items.Add("Glasses");
        }

        private void GetCoachPlaybookItems()
        {
            CoachPlaybookBox.Items.Clear();
            List<List<string>> pb = CreatePlaybookNames();
                //136-158 next ||  124 and below is vanilla

                if (GetDBValueInt("COCH", "CPID", CoachIndex) > 135)
                {
                    for (int i = 136; i < pb.Count; i++)
                    {
                        CoachPlaybookBox.Items.Add(pb[i][1]);
                    }
                }
                else
                {
                    for (int i = 0; i <= 124; i++)
                    {
                        CoachPlaybookBox.Items.Add(pb[i][1]);
                    }
                }
        }

        private int GetCoachPlaybookSelectedIndex()
        {
            int pbVal = GetDBValueInt("COCH", "CPID", CoachIndex);

            //136-158 next ||  124 and below is vanilla
            if (pbVal > 135) pbVal = pbVal - 136;
           
            return pbVal;
        }

        private void GetCoachOffTypeItems()
        {
            CoachOffTypeBox.Items.Clear();
            List<string> OffTypes = CreateOffTypes();

            foreach (string name in OffTypes)
            {
                CoachOffTypeBox.Items.Add(name);
            }

        }

        private void GetCoachDefTypeItems()
        {
            CoachDefTypeBox.Items.Clear();
            List<string> DefTypes = CreateBaseDef();


            foreach (string name in DefTypes)
            {
                CoachDefTypeBox.Items.Add(name);
            }

        }

        #endregion






        //Text Change Triggers
        #region Text Box Changes


        //User Coach
        private void CFUCBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (CFUCBox.Checked) ChangeDBInt("COCH", "CFUC", CoachIndex, 1);
            else if (!CFUCBox.Checked) ChangeDBInt("COCH", "CFUC", CoachIndex, 0);
        }

        //Recruiting Assistance
        private void RecruitAssistanceBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (RecruitAssistanceBox.Checked) ChangeDBInt("COCH", "CFRC", CoachIndex, 1);
            else if (!RecruitAssistanceBox.Checked) ChangeDBInt("COCH", "CFRC", CoachIndex, 0);
        }

        //Discipline Assistance
        private void DisciplineAssistanceBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (DisciplineAssistanceBox.Checked) ChangeDBInt("COCH", "CSAS", CoachIndex, 1);
            else if (!DisciplineAssistanceBox.Checked) ChangeDBInt("COCH", "CSAS", CoachIndex, 0);
        }


        //Team Name
        private void CoachTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
          
            var result = MessageBox.Show("Are you sure you want to change teams?\n\nThis will swap teams with the existing coach of that team.", "Change Coach Teams", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                int tgidOLD = GetDBValueInt("COCH", "TGID", CoachIndex);
                int tgidSelected = GetTeamTGIDfromRecord(FindTeamRecfromTeamName(CoachTeamList.SelectedText));

                if (tgidSelected == 511)
                {
                    ChangeDBInt("COCH", "TGID", CoachIndex, 511);
                }
                else
                {
                    for (int i = 0; i < GetTableRecCount("COCH"); i++)
                    {
                        if (GetDBValueInt("COCH", "TGID", i) == tgidSelected)
                        {
                            ChangeDBInt("COCH", "TGID", i, tgidOLD);
                            ChangeDBInt("COCH", "CTYR", i, 0);
                        }
                    }

                    ChangeDBInt("COCH", "TGID", CoachIndex, tgidSelected);
                    ChangeDBInt("COCH", "CTYR", CoachIndex, 0);

                }
            }
        }

        //Coach Name
        private void CoachFirstNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLFN", CoachIndex, CoachFirstNameBox.Text);
            //CoachListBox.SelectedItem = CoachFirstNameBox.Text;
            LoadCoachList(CoachFilter.SelectedIndex);
        }

        private void CoachLastNameBox_TextChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CLLN", CoachIndex, CoachLastNameBox.Text);
            //CoachListBox.SelectedItem = CoachLastNameBox.Text;
            LoadCoachList(CoachFilter.SelectedIndex);
        }

        //Skin Tone
        private void CSKIBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            int skin = CSKIBox.SelectedIndex;
            if (skin == 1) skin = 2;
            else if (skin == 2) skin = 5;

            ChangeDBInt("COCH", "CSKI", CoachIndex, skin);

        }

        //Face
        private void CFEXBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("COCH", "CFEX", CoachIndex, CFEXBox.SelectedIndex);
        }

        //Body
        private void CBSZBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("COCH", "CBSZ", CoachIndex, CBSZBox.SelectedIndex);
        }

        //Hair Color
        private void CHARBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("COCH", "CHAR", CoachIndex, CHARBox.SelectedIndex);
        }

        //Hair Type
        private void CTHGBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            int x = CTHGBox.SelectedIndex;

            if (x == 1) COHTBox.SelectedIndex = 1;

            ChangeDBInt("COCH", "CThg", CoachIndex, CTHGBox.SelectedIndex);
        }

        //Hat
        private void COHTBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            int x = COHTBox.SelectedIndex;

            if (x == 1) ChangeDBInt("COCH", "CThg", CoachIndex, 1);
            else if (x == 2) ChangeDBInt("COCH", "CThg", CoachIndex, 0);

            ChangeDBInt("COCH", "COHT", CoachIndex, COHTBox.SelectedIndex);
        }

        //Glasses
        private void CTgwBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBInt("COCH", "CTgw", CoachIndex, CTgwBox.SelectedIndex);
        }

        //Coach Performance & Prestige
        private void CoachCCPONum_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            ChangeDBString("COCH", "CCPO", CoachIndex, Convert.ToString(CoachCCPONum.Value));
            CoachCCPONum.BackColor = GetPerformanceColor(CoachCCPONum).BackColor;
        }

        private void HCPrestigeNum_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBString("COCH", "CPRE", CoachIndex, Convert.ToString(HCPrestigeNum.Value));
            HCPrestigeNum.BackColor = GetPrestigeColor(HCPrestigeNum).BackColor;

        }

        //Budget
        private void CoachTrainingBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (CoachRecruitingBox.Value + CoachTrainingBox.Value < 100)
            {
                ChangeDBString("COCH", "CTPC", CoachIndex, Convert.ToString(CoachTrainingBox.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", CoachIndex) + GetDBValueInt("COCH", "CRPC", CoachIndex));
                ChangeDBString("COCH", "CDPC", CoachIndex, Convert.ToString(discpts));

                CoachDisciplineBox.Text = GetDBValue("COCH", "CDPC", CoachIndex);
            }
            else
            {
                CoachTrainingBox.Value = GetDBValueInt("COCH", "CTPC", CoachIndex);
            }
        }

        private void CoachRecruitingBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            if (CoachRecruitingBox.Value + CoachTrainingBox.Value < 100)
            {
                ChangeDBString("COCH", "CRPC", CoachIndex, Convert.ToString(CoachRecruitingBox.Value));
                int discpts = 100 - (GetDBValueInt("COCH", "CTPC", CoachIndex) + GetDBValueInt("COCH", "CRPC", CoachIndex));
                ChangeDBString("COCH", "CDPC", CoachIndex, Convert.ToString(discpts));

                CoachDisciplineBox.Text = GetDBValue("COCH", "CDPC", CoachIndex);
            }

            else
            {
                CoachRecruitingBox.Value = GetDBValueInt("COCH", "CRPC", CoachIndex);
            }
        }

        //Playbook & Strategy
        private void CoachPlaybookBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;

            int pbVal = 0;

            List<List<string>> pb = CreatePlaybookNames();
            //136-158 next ||  124 and below is vanilla

            if (GetDBValueInt("COCH", "CPID", CoachIndex) > 135)
            {
                pbVal = CoachPlaybookBox.SelectedIndex + 136;
            }
            else
            {
                pbVal = CoachPlaybookBox.SelectedIndex;
            }


            ChangeDBInt("COCH", "CPID", CoachIndex, pbVal);
            ChangeDBInt("TEAM", "TOPB", FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("COCH", "TGID", CoachIndex)]), pbVal);
        }

        private void CoachOffTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COST", CoachIndex, CoachOffTypeBox.SelectedIndex);
        }

        private void CoachDefTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDST", CoachIndex, CoachDefTypeBox.SelectedIndex);
            ChangeDBInt("TEAM", "TDPB", FindTeamRecfromTeamName(teamNameDB[GetDBValueInt("COCH", "TGID", CoachIndex)]), CoachDefTypeBox.SelectedIndex);

        }


        //Offense Strategy

        private void CoachCOTSBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTS", CoachIndex, Convert.ToInt32(CoachCOTSBox.Value));
        }

        private void CoachCOTABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTA", CoachIndex, Convert.ToInt32(CoachCOTABox.Value));
        }

        private void CoachCOTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "COTR", CoachIndex, Convert.ToInt32(CoachCOTRBox.Value));
        }


        //Defense Strategy


        private void CoachCDTSBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTS", CoachIndex, Convert.ToInt32(CoachCDTSBox.Value));
        }

        private void CoachCDTABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTA", CoachIndex, Convert.ToInt32(CoachCDTABox.Value));
        }

        private void CoachCDTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger) return;
            ChangeDBInt("COCH", "CDTR", CoachIndex, Convert.ToInt32(CoachCDTRBox.Value));
        }

        #endregion

        #region Buttons
        private void NewCoachButton_Click(object sender, EventArgs e)
        {
            CreateFantasyCoach(CoachIndex);
            LoadCoachList(CoachFilter.SelectedIndex);
            GetCoachEditorData(CoachIndex);
            MessageBox.Show("Coach Creation Completed!");
        }

        private void SetMaxCoachCCPO_Click(object sender, EventArgs e)
        {
            SetMaxCoachCCPOValue();
        }
        #endregion

        private void SetMaxCoachCCPOValue()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = GetTableRecCount("COCH");

            int maxval = Convert.ToInt32(MaxCCPOVal.Value);

            for(int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                if(GetDBValueInt("COCH", "CCPO", i) > maxval)
                    ChangeDBInt("COCH", "CCPO", i, maxval);

                progressBar1.PerformStep();
            }

            MessageBox.Show("Max Value Set!");

        }

    }
}
