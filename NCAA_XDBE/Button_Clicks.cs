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
        #region TAB CONTROLS
        private void TabControl1_IndexChange(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != tabDB) CSVMenu.Visible = false;
            if (tabControl1.SelectedTab == tabDB) TabDB_Start();
            else if (tabControl1.SelectedTab == tabTeams) StartTeamEditor();
            else if (tabControl1.SelectedTab == tabPlayers) StartPlayerEditor();
            else if (tabControl1.SelectedTab == tabConf) ConferenceSetup();
            else if (tabControl1.SelectedTab == tabCoaches) StartCoachEditor();
            else if (tabControl1.SelectedTab == tabTools) StartDBTools();
            else if (tabControl1.SelectedTab == tabPlaybook) StartPlaybookEditor();
            else if (tabControl1.SelectedTab == tabDepthCharts) StartDepthChartEditor();
            else if (tabControl1.SelectedTab == tabHome) StartHomeTab();
        }

        private void TabDB_Start()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = true;
            FieldsPropsgroupBox.Visible = true;
            TableGridView_SelectionChanged(null, null);
            fieldMenu.Enabled = true;
            tableMenu.Enabled = true;
            CSVMenu.Visible = true;
        }

        private void TabDB2_Start()
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            TablePropsgroupBox.Visible = true;
            FieldsPropsgroupBox.Visible = true;
            TableGridView_SelectionChanged(null, null);
            fieldMenu.Enabled = false;
            tableMenu.Enabled = false;
            CSVMenu.Visible = false;
        }

        private void StartHomeTab()
        {
            if (NCAANext25Config.Checked == true)
            {
                NextConfigRadio.Checked = true;
                OGConfigRadio.Checked = false;
            }
            else
            {
                NextConfigRadio.Checked = false;
                OGConfigRadio.Checked = true;
            }
        }
        #endregion


        #region MAIN DB TOOLS CLICKS

        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void BodyFix_Click(object sender, EventArgs e)
        {
            RecalculateBMI("PLAY");
        }

        //Increases minium speed for skill positions to 80
        private void IncreaseSpeed_Click(object sender, EventArgs e)
        {
            IncreaseMinimumSpeed();
        }

        //Recalculates QB Tendencies based on original game criteria
        private void QB_Tend_Click(object sender, EventArgs e)
        {
            RecalculateQBTendencies();
        }

        //Randomize Player Potential
        private void ButtonRandPotential_Click(object sender, EventArgs e)
        {
            RandomizePotential();
        }

        //Randomize Player Faces/Heads
        private void RandomizeHeadButton_Click(object sender, EventArgs e)
        {
            RandomizeRecruitFace("PLAY");
        }

        //Unique Player Tool
        private void UniquePlayer_Click(object sender, EventArgs e)
        {
            UniquePlayers();
        }

        //Recalculate Overall Ratings
        private void buttonCalcOverall_Click(object sender, EventArgs e)
        {
            RecalculateOverall();
        }

        //Recalculate Team Overalls
        private void TYDNButton_Click(object sender, EventArgs e)
        {
            if (TEAM) CalculateTeamRatings("TEAM");
            if (TDYN) CalculateTeamRatings("TDYN");
        }

        //Determine Impact Players
        private void buttonImpactPlayers_Click(object sender, EventArgs e)
        {
            DetermineImpactPlayers();
        }

        //Fantasy Roster Generator
        private void buttonFantasyRoster_Click(object sender, EventArgs e)
        {
            if (TDYN)
                FantasyRosterGenerator("TDYN");
            else if (TEAM)
                FantasyRosterGenerator("TEAM");
        }

        //Depth Chart Generator
        private void buttonAutoDepthChart_Click(object sender, EventArgs e)
        {
            if (TDYN)
                DepthChartMaker("TDYN");
            else if (TEAM)
                DepthChartMaker("TEAM");
        }

        //Fill Rosters
        private void buttonFillRosters_Click(object sender, EventArgs e)
        {
            if (TDYN)
                FillRosters("TDYN", Convert.ToInt32(FillRosterPCT.Value));
            else if (TEAM)
                FillRosters("TEAM", Convert.ToInt32(FillRosterPCT.Value));
        }

        //Reorder Teams TORD
        private void TORDButton_Click(object sender, EventArgs e)
        {
            ReorderTORD();
        }

        //Reorder PLAY by PGID
        private void ReorderPGIDButton_Click(object sender, EventArgs e)
        {
            ReOrderTable("PLAY", "PGID");
        }


        private void SyncPBButton_Click(object sender, EventArgs e)
        {
            SyncTeamCoachPlaybooks();
        }

        private void FantasyCoachesButton_Click(object sender, EventArgs e)
        {
            CreateFantasyCoachDB();
        }
        #endregion


        #region Dynasty Tools


        //Pre-Season Injury Distributor
        private void ButtonPSInjuries_Click(object sender, EventArgs e)
        {
            PreseasonInjuries();
        }

        //Medical Redshirt - If player's INJL = 254, they are out of season. Let's give them a medical year!
        private void MedRS_Click(object sender, EventArgs e)
        {
            MedicalRedshirt();
        }

        //Coaching Progression -- useful for "Contracts Off" dynasty setting where coaching progression is disabled
        /* 
        Use current TEAM's TMPR and COCH's CTOP to make CPRE updated, then update CTOP to match previous TMPR
        */
        private void CoachProg_Click(object sender, EventArgs e)
        {
            CoachPrestigeProgression();
        }

        //Randomizes the Coaching Budgets - Must be done prior to 1st Off-Season Task

        private void ButtonRandomBudgets_Click(object sender, EventArgs e)
        {
            RandomizeBudgets();
        }

        //Coaching Carousel -- Must be done at end of Season
        private void ButtonCarousel_Click(object sender, EventArgs e)
        {
            CoachCarousel();
        }

        //Conference Realignment
        private void buttonRealignment_Click(object sender, EventArgs e)
        {
            ConfRealignment();
        }


        //Players to Coaches
        private void buttonPlayerCoach_Click(object sender, EventArgs e)
        {
            PlayerToCoach();
        }


        //Randomly Generate Coach Prestiges for Free Agents
        private void CoachPrestigeButton_Click(object sender, EventArgs e)
        {
            AssignCoachPrestigeFreeAgents();
        }

        #endregion



        //DEV TAB TOOLS

        #region DEV TOOLS

        //Graduate/Transfer Players (DEV ONLY)
        private void GraduateButton_Click(object sender, EventArgs e)
        {
            GraduateAndTransferPlayers();
        }

        private void ImportRecruitsButton_Click(object sender, EventArgs e)
        {
            CreateRecruitsFromCSV();
        }

        private void FireCoachButton_Click(object sender, EventArgs e)
        {
            FireHeadCoach();
        }


        //Create Transfers from CSV File
        private void CreateTransfersCSVButton_Click(object sender, EventArgs e)
        {
            CreateTransfersFromCSV();
        }

        private void DevFillRosterButton_Click(object sender, EventArgs e)
        {
            FillRosters("TDYN", 85);
        }

        private void DevCalcTeamRatingsButton_Click(object sender, EventArgs e)
        {
            CalculateTeamRatings("TDYN");
        }


        private void DevDepthChartButton_Click(object sender, EventArgs e)
        {
            DepthChartMaker("TDYN");
        }

        private void tabTeams_Click(object sender, EventArgs e)
        {
            StartTeamEditor();
        }

        private void DevRandomizeFaceButton_Click(object sender, EventArgs e)
        {
            RandomizeRecruitFace("PLAY");
        }

        private void DevCalcOVRButton_Click(object sender, EventArgs e)
        {
            RecalculateOverall();
        }

        #endregion

        //EXPERIMENTAL ITEMS -- WORK IN PROGRESS

        private void buttonChaosTransfers_Click(object sender, EventArgs e)
        {
            ChaosTransfers();
        }





    }

}
