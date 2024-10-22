﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /*
        * PLAYER EDITOR
        */
        #region PLAYER EDITOR

        public void StartPlayerEditor()
        {
            PlayerTransferButton.Visible = false;
            LoadPlayerTGIDBox();

            if(dbIndex2 == 1) PlayerTransferButton.Visible = true;
        }

        private void LoadPlayerTGIDBox()
        {
            TGIDplayerBox.Items.Clear();
            List<string> teamList = new List<string>();
            if (TDYN)
            {
                for (int i = 0; i < GetTableRecCount("TDYN"); i++)
                {
                    teamList.Add(teamNameDB[GetDBValueInt("TDYN", "TOID", i)]);
                }
            }
            else
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    if (GetDBValueInt("TEAM", "TTYP", i) == 0)
                        teamList.Add(teamNameDB[GetDBValueInt("TEAM", "TGID", i)]);
                }
            }
            teamList.Add("_ALL PLAYERS_");

            teamList.Sort();

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) TGIDplayerBox.Items.Add(teamList[i]);
            }

        }

        public void LoadPGIDlistBox()
        {
            PlayerEditorList = new List<List<string>>();
            PJENList = new List<int>();
            int pgidBeg;
            int pgidEnd;

            if (TGIDplayerBox.Text != "_ALL PLAYERS_")
            {
                int tgid = -1;
                for (int i = 0; i < teamNameDB.Length; i++)
                {
                    if (TGIDplayerBox.Text == teamNameDB[i])
                    {
                        tgid = i;
                        break;
                    }
                }

                pgidBeg = tgid * 70;
                pgidEnd = tgid * 70 + 69;
            }
            else
            {
                pgidBeg = 0;
                pgidEnd = 8400;
            }

            int row = 0;
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd)
                {
                    PlayerEditorList.Add(new List<string>());
                    PlayerEditorList[row].Add(GetFirstNameFromRecord(i));
                    PlayerEditorList[row].Add(GetLastNameFromRecord(i));
                    PlayerEditorList[row].Add(GetDBValue("PLAY", "PPOS", i));
                    PlayerEditorList[row].Add(GetDBValue("PLAY", "POVR", i));
                    PlayerEditorList[row].Add(GetDBValue("PLAY", "PGID", i));
                    PlayerEditorList[row].Add(Convert.ToString(i));
                    PlayerEditorList[row].Add(Convert.ToString(GetPOSGfromPPOS(GetDBValueInt("PLAY", "PPOS", i))));

                    // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec

                    if (TGIDplayerBox.Text != "_ALL PLAYERS_") PJENList.Add(GetDBValueInt("PLAY", "PJEN", i));
                        
                    row++;
                }
            }

            PlayerEditorList.Sort((player1, player2) => player1[0].CompareTo(player2[0]));
            if (ShowPosCheckBox.Checked && ShowRatingCheckbox.Checked)
            {
                // Assuming you want to sort by position first and then by overall rating
                PlayerEditorList = PlayerEditorList
                    .OrderBy(player => int.Parse(player[2])) // Sort by position
                    .ThenByDescending(player => int.Parse(player[3])) // Sort by overall rating descending
                    .ToList();

            }
            else if (ShowPOSGBox.Checked && ShowRatingCheckbox.Checked)
            {
                // Assuming you want to sort by position first and then by overall rating
                PlayerEditorList = PlayerEditorList
                    .OrderBy(player => int.Parse(player[6])) // Sort by position
                    .ThenByDescending(player => int.Parse(player[3])) // Sort by overall rating descending
                    .ToList();

            }
            else if (ShowRatingCheckbox.Checked) PlayerEditorList.Sort((player1, player2) => Convert.ToInt32(player2[3]).CompareTo(Convert.ToInt32(player1[3])));
            else if (ShowPosCheckBox.Checked) PlayerEditorList.Sort((player1, player2) => Convert.ToInt32(player1[2]).CompareTo(Convert.ToInt32(player2[2])));
            else if (ShowPOSGBox.Checked) PlayerEditorList.Sort((player1, player2) => Convert.ToInt32(player1[6]).CompareTo(Convert.ToInt32(player2[6])));


            PGIDlistBox.Items.Clear();
            foreach (var player in PlayerEditorList)
            {
                string text = "";
                if (ShowPosCheckBox.Checked) text += "[" + Convert.ToString(Positions[Convert.ToInt32(player[2])]) + "] ";
                else if (ShowPOSGBox.Checked) text += "[" + GetPOSGName(Convert.ToInt32(player[6])) + "] ";
                text += player[0] + " " + player[1];
                if (ShowRatingCheckbox.Checked) text += "  (" + Convert.ToString(ConvertRating(Convert.ToInt32(player[3]))) + ")";

                PGIDlistBox.Items.Add(text);


            }

            RosterSizeLabel.Text = "Roster Size: " + Convert.ToString(PlayerEditorList.Count);
        }

        //Change Selected Team
        public void TGIDplayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPGIDlistBox();
        }
        //Player Selection
        public void PGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.SelectedIndex == -1)
                return;

            PlayerIndex = Convert.ToInt32(PlayerEditorList[PGIDlistBox.SelectedIndex][5]);

            LoadPlayerData();
        }

        public void LoadPlayerData()
        {
            DoNotTrigger = true;

            ResetPlayerPOSbutton.Visible = false;
            
            //Player Name
            PFNAtextBox.Text = GetFirstNameFromRecord(PlayerIndex); //...first name from numeric to text conversion
            PLNAtextBox.Text = GetLastNameFromRecord(PlayerIndex); //...last name from numeric to text conversion

            //Position
            AddPositionsItems();
            PPOSBox.SelectedIndex = GetDBValueInt("PLAY", "PPOS", PlayerIndex);


            //Overall Rating
            POVRbox.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", PlayerIndex)));


            //PGID Box
            PGIDbox.Text = GetDBValue("PLAY", "PGID", PlayerIndex);

            //Team

            playerTeamBox.Text = teamNameDB[GetDBValueInt("PLAY", "PGID", PlayerIndex) / 70];

            //Pride Stickers
            PRST.Text = GetDBValue("PLAY", "PRST", PlayerIndex);

            //Year & Redshirt
            AddYearItems();
            AddRedshirtItems();
            PYERBox.SelectedIndex = GetDBValueInt("PLAY", "PYER", PlayerIndex);
            PRSDBox.SelectedIndex = GetDBValueInt("PLAY", "PRSD", PlayerIndex);

            //Jersey
            PJEN.Value = GetDBValueInt("PLAY", "PJEN", PlayerIndex);

            //Height & Weight
            PHGTBox.Value = GetDBValueInt("PLAY", "PHGT", PlayerIndex);
            PWGTBox.Value = GetDBValueInt("PLAY", "PWGT", PlayerIndex) + 160;

            //Head Appearance
            AddSkinColorItems();
            AddFaceShapeItems();
            AddFaceItems();
            AddHairColorItems();
            AddHairStyleItems();

            PSKIBox.SelectedIndex = GetDBValueInt("PLAY", "PSKI", PlayerIndex);
            PFGMBox.SelectedIndex = GetDBValueInt("PLAY", "PFGM", PlayerIndex);
            PFMPBox.SelectedIndex = GetDBValueInt("PLAY", "PFMP", PlayerIndex) % 8;
            PHCLBox.SelectedIndex = GetDBValueInt("PLAY", "PHCL", PlayerIndex);
            PHEDBox.SelectedIndex = GetDBValueInt("PLAY", "PHED", PlayerIndex);


            //Attributes
            //
            //


            //Importance
            PIMPBox.Value = GetDBValueInt("PLAY", "PIMP", PlayerIndex);
            PIMPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PIMPBox.Value)));

            //Potential
            PPOEBox.Value = GetDBValueInt("PLAY", "PPOE", PlayerIndex);
            PPOEtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PPOEBox.Value)));

            //Injury
            PINJBox.Value = GetDBValueInt("PLAY", "PINJ", PlayerIndex);
            PINJtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PINJBox.Value)));

            //Awareness
            PAWRBox.Value = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
            PAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAWRBox.Value)));

            //Speed
            PSPDBox.Value = GetDBValueInt("PLAY", "PSPD", PlayerIndex);
            PSPDtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PSPDBox.Value)));

            //Agility
            PAGIBox.Value = GetDBValueInt("PLAY", "PAGI", PlayerIndex);
            PAGItext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAGIBox.Value)));

            //Acceleration
            PACCBox.Value = GetDBValueInt("PLAY", "PACC", PlayerIndex);
            PACCtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PACCBox.Value)));

            //Jumping
            PJMPBox.Value = GetDBValueInt("PLAY", "PJMP", PlayerIndex);
            PJMPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PJMPBox.Value)));

            //Strength
            PSTRBox.Value = GetDBValueInt("PLAY", "PSTR", PlayerIndex);
            PSTRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PSTRBox.Value)));

            //Throw Power
            PTHPBox.Value = GetDBValueInt("PLAY", "PTHP", PlayerIndex);
            PTHPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTHPBox.Value)));

            //Throw Accuracy
            PTHABox.Value = GetDBValueInt("PLAY", "PTHA", PlayerIndex);
            PTHAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTHABox.Value)));

            //Break Tackle
            PBTKBox.Value = GetDBValueInt("PLAY", "PBTK", PlayerIndex);
            PBTKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PBTKBox.Value)));

            //Ball Carry
            PCARBox.Value = GetDBValueInt("PLAY", "PCAR", PlayerIndex);
            PCARtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PCARBox.Value)));

            //Run Blocking
            PRBKBox.Value = GetDBValueInt("PLAY", "PRBK", PlayerIndex);
            PRBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PRBKBox.Value)));

            //Pass Blocking
            PPBKBox.Value = GetDBValueInt("PLAY", "PPBK", PlayerIndex);
            PPBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PPBKBox.Value)));

            //Catching
            PCTHBox.Value = GetDBValueInt("PLAY", "PCTH", PlayerIndex);
            PCTHtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PCTHBox.Value)));

            //Tackling
            PTAKBox.Value = GetDBValueInt("PLAY", "PTAK", PlayerIndex);
            PTAKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTAKBox.Value)));

            //Kick Power
            PKPRBox.Value = GetDBValueInt("PLAY", "PKPR", PlayerIndex);
            PKPRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PKPRBox.Value)));

            //Kick Accuracy
            PKACBox.Value = GetDBValueInt("PLAY", "PKAC", PlayerIndex);
            PKACtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PKACBox.Value)));

            //Player Tendency/Archeatype
            PTEN.Text = GetPTENType(GetDBValueInt("PLAY", "PPOS", PlayerIndex), GetDBValueInt("PLAY", "PTEN", PlayerIndex));

            //Off-Season Type

            AddPTYPItems();
            PTYPBox.SelectedIndex = GetDBValueInt("PLAY", "PTYP", PlayerIndex);


            /* PLAYER GEAR */

            //Helmet & Head Gear
            Helmet.SelectedIndex = GetDBValueInt("PLAY", "HELM", PlayerIndex);
            Facemask.SelectedIndex = GetDBValueInt("PLAY", "PFMK", PlayerIndex);
            Visor.SelectedIndex = GetDBValueInt("PLAY", "PVIS", PlayerIndex);
            NeckPad.SelectedIndex = GetDBValueInt("PLAY", "PNEK", PlayerIndex);
            EyeBlack.SelectedIndex = GetDBValueInt("PLAY", "PEYE", PlayerIndex);
            NasalStrip.SelectedIndex = GetDBValueInt("PLAY", "PBRE", PlayerIndex);

            // Arms
            Sleeves.SelectedIndex = GetDBValueInt("PLAY", "PSLO", PlayerIndex);
            SleeveColor.SelectedIndex = GetDBValueInt("PLAY", "PSLT", PlayerIndex);

            //Elbows
            LeftElbow.SelectedIndex = GetDBValueInt("PLAY", "PLEB", PlayerIndex);
            RightElbow.SelectedIndex = GetDBValueInt("PLAY", "PREB", PlayerIndex);

            //Wrists
            LeftWrist.SelectedIndex = GetDBValueInt("PLAY", "PLWS", PlayerIndex);
            RightWrist.SelectedIndex = GetDBValueInt("PLAY", "PRWS", PlayerIndex);


            //Hands
            LeftHand.SelectedIndex = GetDBValueInt("PLAY", "PLHN", PlayerIndex);
            RightHand.SelectedIndex = GetDBValueInt("PLAY", "PRHN", PlayerIndex);

            // Shoes
            LeftShoe.SelectedIndex = GetDBValueInt("PLAY", "PLSH", PlayerIndex);
            RightShoe.SelectedIndex = GetDBValueInt("PLAY", "PRSH", PlayerIndex);

            DoNotTrigger = false;
        }



        #endregion

        #region Add Items

        private void AddPositionsItems()
        {
            PPOSBox.Items.Clear();
            foreach (var p in Positions.Values)
            {
                PPOSBox.Items.Add(p);
            }
        }

        private void AddYearItems()
        {
            PYERBox.Items.Clear();
            List<string> classes = CreateClassYears();
            foreach (var x in classes)
            {
                PYERBox.Items.Add(x);
            }
        }

        private void AddRedshirtItems()
        {
            PRSDBox.Items.Clear();
            List<string> Redshirt = CreateRedshirtStatus();
            foreach (var x in Redshirt)
            {
                PRSDBox.Items.Add(x);
            }
        }

        private void AddSkinColorItems()
        {
            PSKIBox.Items.Clear();
            List<string> skin = CreateSkinColorDB();
            foreach (var x in skin)
            {
                PSKIBox.Items.Add(x);
            }
        }

        private void AddFaceShapeItems()
        {
            PFGMBox.Items.Clear();

            for (int i = 0; i < 16; i++)
            {
                PFGMBox.Items.Add(i);
            }
        }

        private void AddFaceItems()
        {
            PFMPBox.Items.Clear();

            int skin = GetDBValueInt("PLAY", "PSKI", PlayerIndex);

            for (int i = 0; i < 8; i++)
            {
                PFMPBox.Items.Add(skin * 8 + i);
            }
        }

        private void AddHairColorItems()
        {
            PHCLBox.Items.Clear();
            List<string> hair = CreatePHCL();
            foreach (var x in hair)
            {
                PHCLBox.Items.Add(x);
            }
        }

        private void AddHairStyleItems()
        {
            PHEDBox.Items.Clear();
            List<string> hair = CreateHair();
            foreach (var x in hair)
            {
                PHEDBox.Items.Add(x);
            }
        }

        private void AddPTYPItems()
        {
            PTYPBox.Items.Clear();
            List<string> type = CreateOffSeasonPTYP();
            foreach (var x in type)
            {
                PTYPBox.Items.Add(x);
            }
        }

        #endregion

        //TRIGGERS
        #region triggers

        private void ShowRatingCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LoadPGIDlistBox();
        }

        private void ShowPosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPOSGBox.Checked) ShowPOSGBox.Checked = false;
            LoadPGIDlistBox();
        }

        private void ShowPOSGBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPosCheckBox.Checked) ShowPosCheckBox.Checked = false;
            LoadPGIDlistBox();

        }

        //Change Name
        public void PFNAtextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void PFNA_Leave(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            Editor_ConvertFN_InttoString(PlayerIndex);  // ...first name from text to numeric conversion
        }
        public void PLNAtextBox_TextChanged(object sender, EventArgs e)
        {


        }
        private void PLNA_Leave(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            Editor_ConvertLN_IntToString(PlayerIndex);  // ...last name from text to numeric conversion
        }

        //Change Position
        private void PPOSBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            if(AWHRBox.Checked)
            {
                DoNotTrigger = true;
                PPOSmem = GetDBValueInt("PLAY", "PPOS", PlayerIndex);
                AWRHmem = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
                double hit = 0.19;

                if (NextMod)  hit = 0.08;

                ResetPlayerPOSbutton.Visible = true;

                List<List<int>> AWRH = GetAwarenessHitList();
                double PosHit = hit * AWRH[PPOSmem][PPOSBox.SelectedIndex];

                int AWRog = ConvertRating(AWRHmem);
                int AWR = Convert.ToInt32(AWRog - (AWRog * PosHit));
                if (AWR < 40) AWR = 40;

                AWR = RevertRating(AWR);
                ChangeDBInt("PLAY", "PAWR", PlayerIndex, AWR);
                ChangeDBInt("PLAY", "PPOS", PlayerIndex, PPOSBox.SelectedIndex);
                PAWRBox.Value = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
                PAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAWRBox.Value)));
            }
            else
            {
                ChangeDBInt("PLAY", "PPOS", PlayerIndex, PPOSBox.SelectedIndex);
            } 

            DisplayNewOverallRating();
            DoNotTrigger = false;
        }

        private void ResetPlayerPOSbutton_Click(object sender, EventArgs e)
        {
            ChangeDBInt("PLAY", "PAWR", PlayerIndex, AWRHmem);
            ChangeDBInt("PLAY", "PPOS", PlayerIndex, PPOSmem);
            PPOSBox.SelectedIndex = GetDBValueInt("PLAY", "PPOS", PlayerIndex);
            PAWRBox.Value = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
            PAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAWRBox.Value)));
            ResetPlayerPOSbutton.Visible = false;
        }

        //Change Year/Redshirt

        private void PYERBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PYER", PlayerIndex, PYERBox.SelectedIndex);
        }

        private void PRSDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRSD", PlayerIndex, PRSDBox.SelectedIndex);
        }

        //Jersey Number

        private void PJEN_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PJEN", PlayerIndex, Convert.ToInt32(PJEN.Value));
        }


        //Height and Weight

        private void PHGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PHGT", PlayerIndex, Convert.ToInt32(PHGTBox.Value));
            RecalculateIndividualBMI(PlayerIndex);
        }

        private void PWGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PWGT", PlayerIndex, Convert.ToInt32(PWGTBox.Value) - 160);
            RecalculateIndividualBMI(PlayerIndex);

        }


        //Change Skin/Head Apperance

        private void PSKIBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSKI", PlayerIndex, PSKIBox.SelectedIndex);
            AddFaceItems();
            PFMPBox.SelectedIndex = GetDBValueInt("PLAY", "PFMP", PlayerIndex) % 8;
            ChangeDBInt("PLAY", "PFMP", PlayerIndex, PSKIBox.SelectedIndex * 8 + PFMPBox.SelectedIndex);
        }

        private void PFGMBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PFGM", PlayerIndex, PFGMBox.SelectedIndex);
        }

        private void PFMPBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PFMP", PlayerIndex, PSKIBox.SelectedIndex * 8 + PFMPBox.SelectedIndex);
        }

        private void PHCLBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PHCL", PlayerIndex, PHCLBox.SelectedIndex);
        }

        private void PHEDBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PHED", PlayerIndex, PHEDBox.SelectedIndex);
        }


        //Rating Attributes


        private void PIMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PIMP", PlayerIndex, Convert.ToInt32(PIMPBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PIMP", PlayerIndex)));
            DisplayNewOverallRating();

        }

        private void PPOEBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PPOE", PlayerIndex, Convert.ToInt32(PPOEBox.Value));
            PPOEtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PPOE", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PINJBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PINJ", PlayerIndex, Convert.ToInt32(PINJBox.Value));
            PINJtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PINJ", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PAWRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAWR", PlayerIndex, Convert.ToInt32(PAWRBox.Value));
            PAWRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAWR", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PSPDBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSPD", PlayerIndex, Convert.ToInt32(PSPDBox.Value));
            PSPDtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSPD", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PAGIBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAGI", PlayerIndex, Convert.ToInt32(PAGIBox.Value));
            PAGItext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAGI", PlayerIndex)));
            DisplayNewOverallRating();
        }
        private void PACCBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PACC", PlayerIndex, Convert.ToInt32(PACCBox.Value));
            PACCtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PACC", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PJMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PJMP", PlayerIndex, Convert.ToInt32(PJMPBox.Value));
            PJMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PJMP", PlayerIndex)));
            DisplayNewOverallRating();
        }
        private void PSTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSTR", PlayerIndex, Convert.ToInt32(PSTRBox.Value));
            PSTRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSTR", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTHPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHP", PlayerIndex, Convert.ToInt32(PTHPBox.Value));
            PTHPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHP", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTHABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHA", PlayerIndex, Convert.ToInt32(PTHABox.Value));
            PTHAtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHA", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PBTKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PBTK", PlayerIndex, Convert.ToInt32(PBTKBox.Value));
            PBTKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PBTK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PCARBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCAR", PlayerIndex, Convert.ToInt32(PCARBox.Value));
            PCARtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCAR", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PRBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRBK", PlayerIndex, Convert.ToInt32(PRBKBox.Value));
            PRBKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PRBK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PPBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PPBK", PlayerIndex, Convert.ToInt32(PPBKBox.Value));
            PPBKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PPBK", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PCTHBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCTH", PlayerIndex, Convert.ToInt32(PCTHBox.Value));
            PCTHtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCTH", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTAKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTAK", PlayerIndex, Convert.ToInt32(PTAKBox.Value));
            PTAKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTAK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PKPRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKPR", PlayerIndex, Convert.ToInt32(PKPRBox.Value));
            PKPRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKPR", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PKACBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKAC", PlayerIndex, Convert.ToInt32(PKACBox.Value));
            PKACtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKAC", PlayerIndex)));
            DisplayNewOverallRating();
        }

        /* Gear */

        private void Helmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "HELM", PlayerIndex, Helmet.SelectedIndex);
        }

        private void Facemask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PFMK", PlayerIndex, Facemask.SelectedIndex);
        }

        private void Visor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PVIS", PlayerIndex, Visor.SelectedIndex);
        }

        private void EyeBlack_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PEYE", PlayerIndex, EyeBlack.SelectedIndex);
        }

        private void NasalStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PBRE", PlayerIndex, NasalStrip.SelectedIndex);
        }

        private void NeckPad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PNEK", PlayerIndex, NeckPad.SelectedIndex);
        }

        private void Sleeves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSLO", PlayerIndex, Sleeves.SelectedIndex);
        }

        private void SleeveColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSLT", PlayerIndex, SleeveColor.SelectedIndex);
        }

        private void LeftElbow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PLEB", PlayerIndex, LeftElbow.SelectedIndex);
        }

        private void RightElbow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PREB", PlayerIndex, RightElbow.SelectedIndex);
        }

        private void LeftWrist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PLWS", PlayerIndex, LeftWrist.SelectedIndex);
        }

        private void RightWrist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRWS", PlayerIndex, RightWrist.SelectedIndex);
        }

        private void LeftHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PLHN", PlayerIndex, LeftHand.SelectedIndex);
        }

        private void RightHand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRHN", PlayerIndex, RightHand.SelectedIndex);
        }

        private void LeftShoe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PLSH", PlayerIndex, LeftShoe.SelectedIndex);
        }

        private void RightShoe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRSH", PlayerIndex, RightShoe.SelectedIndex);
        }

        //Change PTYP
        private void PTYPBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTYP", PlayerIndex, PTYPBox.SelectedIndex);
        }

        #endregion

        #region ConversionMethods
        public void Editor_ConvertFN_InttoString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PFNAtextBox.Text.Length)
                        if (CHAR.Value == PFNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(dbIndex,
                                      "PLAY",
                                      "PF" + AddLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            /* if (PGIDlistBox.Items.Count > 0)
                 PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
            */
            LoadPGIDlistBox();
        }
        public void Editor_ConvertLN_IntToString(int tmpRecNo)
        {
            if (DoNotTrigger)
                return;

            for (int i = 1; i <= maxNameChar; i++)
            {
                string tmpSTR = "0";

                foreach (KeyValuePair<int, string> CHAR in Alphabet)
                {

                    if (i <= PLNAtextBox.Text.Length)
                        if (CHAR.Value == PLNAtextBox.Text.Substring(i - 1, 1))
                            tmpSTR = Convert.ToString(CHAR.Key);

                    TDB.NewfieldValue(dbIndex,
                                      "PLAY",
                                      "PL" + AddLeadingZeros(Convert.ToString(i), 2),
                                      tmpRecNo,
                                      tmpSTR);

                }

            }
            /*
             * if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
            */
            LoadPGIDlistBox();

        }

        private void DisplayNewOverallRating()
        {
            RecalculateOverallByRec(PlayerIndex);
            POVRbox.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", PlayerIndex)));
        }

        private void CheckPJEN()
        {
            int jersey = GetDBValueInt("PLAY", "PJEN", PlayerIndex);

            int count = 0;
            foreach (var x in PJENList)
            {
                if (x == jersey) count++;
            }

            if (count > 1) PJEN.BackColor = Color.Coral;
            else PJEN.BackColor = Color.NavajoWhite;
        }

        #endregion

        #region Special Functions
        //Team Depth Chart
        private void PlayerSetDepthChartButton_Click(object sender, EventArgs e)
        {
            DepthChartMakerSingle("DCHT", GetDBValueInt("PLAY", "PGID", PlayerIndex) / 70);
        }

        private void PlayerTransferButton_Click(object sender, EventArgs e)
        {
            var response = MessageBox.Show("Are you sure you want to send this player to the Transfer Portal?", "Transfer Player", MessageBoxButtons.OKCancel);

            if (response == DialogResult.OK)
            {
                TransferPlayer(PlayerIndex, GetDBValueInt("PLAY", "PGID", PlayerIndex));
            }
            LoadPlayerData();
        }


        private void ImportPlayerTeam_Click(object sender, EventArgs e)
        {

        }

        private void ExportPlayerTeam_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
