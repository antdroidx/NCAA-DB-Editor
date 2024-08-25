﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

        /*
        * PLAYER EDITOR
        */
        #region PLAYER EDITOR - NOT COMPLETE

        public void StartPlayerEditor()
        {

            LoadPlayerTGIDBox();

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
            AllTeamPlayers = new List<List<string>>();
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
                    AllTeamPlayers.Add(new List<string>());
                    AllTeamPlayers[row].Add(GetFirstNameFromRecord(i));
                    AllTeamPlayers[row].Add(GetLastNameFromRecord(i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "PPOS", i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "POVR", i));
                    AllTeamPlayers[row].Add(GetDBValue("PLAY", "PGID", i));
                    AllTeamPlayers[row].Add(Convert.ToString(i));

                    // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec

                    row++;
                }
            }

            AllTeamPlayers.Sort((player1, player2) => player1[0].CompareTo(player2[0]));

            PGIDlistBox.Items.Clear();
            foreach (var player in AllTeamPlayers)
            {
                PGIDlistBox.Items.Add(player[0] + " " + player[1]);
            }


        }

        //Player Selection
        public void PGIDlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.SelectedIndex == -1)
                return;

            PlayerIndex = Convert.ToInt32(AllTeamPlayers[PGIDlistBox.SelectedIndex][5]);

            LoadPlayerData();
        }

        public void LoadPlayerData()
        {
            DoNotTrigger = true;

            //Player Name
            PFNAtextBox.Text = GetFirstNameFromRecord(PlayerIndex); //...first name from numeric to text conversion
            PLNAtextBox.Text = GetLastNameFromRecord(PlayerIndex); //...last name from numeric to text conversion

            //Position
            AddPositionsItems();
            PPOSBox.SelectedIndex = GetDBValueInt("PLAY", "PPOS", PlayerIndex);


            //Overall Rating
            POVRbox.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", PlayerIndex)));


            //Year & Redshirt
            AddYearItems();
            AddRedshirtItems();
            PYERBox.SelectedIndex = GetDBValueInt("PLAY", "PYER", PlayerIndex);
            PRSDBox.SelectedIndex = GetDBValueInt("PLAY", "PSHD", PlayerIndex);


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



            //Off-Season Type

            AddPTYPItems();
            PTYPBox.SelectedIndex = GetDBValueInt("PLAY", "PTYP", PlayerIndex);






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


        //Change Selected Player
        public void TGIDplayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPGIDlistBox();
        }

        //Change Name
        public void PFNAtextBox_TextChanged(object sender, EventArgs e)
        {
            if (PGIDlistBox.Items.Count < 1)
                return;

            Editor_ConvertFN_InttoString(PlayerIndex);  // ...first name from text to numeric conversion

        }
        public void PLNAtextBox_TextChanged(object sender, EventArgs e)
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

            ChangeDBInt("PLAY", "PPOS", PlayerIndex, PPOSBox.SelectedIndex);
            DisplayNewOverallRating();
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

            ChangeDBInt("PLAY", "PYER", PlayerIndex, PYERBox.SelectedIndex);
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
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PPOE", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PINJBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PINJ", PlayerIndex, Convert.ToInt32(PINJBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PINJ", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PAWRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAWR", PlayerIndex, Convert.ToInt32(PAWRBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAWR", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PSPDBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSPD", PlayerIndex, Convert.ToInt32(PSPDBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSPD", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PAGIBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAGI", PlayerIndex, Convert.ToInt32(PAGIBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAGI", PlayerIndex)));
            DisplayNewOverallRating();
        }
        private void PACCBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PACC", PlayerIndex, Convert.ToInt32(PACCBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PACC", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PJMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PJMP", PlayerIndex, Convert.ToInt32(PJMPBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PJMP", PlayerIndex)));
            DisplayNewOverallRating();
        }
        private void PSTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSTR", PlayerIndex, Convert.ToInt32(PSTRBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSTR", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTHPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHP", PlayerIndex, Convert.ToInt32(PTHPBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHP", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTHABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHA", PlayerIndex, Convert.ToInt32(PTHABox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHA", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PBTKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PBTK", PlayerIndex, Convert.ToInt32(PBTKBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PBTK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PCARBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCAR", PlayerIndex, Convert.ToInt32(PCARBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCAR", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PRBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRBK", PlayerIndex, Convert.ToInt32(PRBKBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PRBK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PPBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PPBK", PlayerIndex, Convert.ToInt32(PPBKBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PPBK", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PCTHBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCTH", PlayerIndex, Convert.ToInt32(PCTHBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCTH", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PTAKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTAK", PlayerIndex, Convert.ToInt32(PTAKBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTAK", PlayerIndex)));
            DisplayNewOverallRating();
        }

        private void PKPRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKPR", PlayerIndex, Convert.ToInt32(PKPRBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKPR", PlayerIndex)));
            DisplayNewOverallRating();
        }


        private void PKACBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKAC", PlayerIndex, Convert.ToInt32(PKACBox.Value));
            PIMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKAC", PlayerIndex)));
            DisplayNewOverallRating();
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
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
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
            if (PGIDlistBox.Items.Count > 0)
                PGIDlistBox.Items[PGIDlistBox.SelectedIndex] = PFNAtextBox.Text + " " + PLNAtextBox.Text;
        }

        private void DisplayNewOverallRating()
        {
            RecalculateOverallByRec(PlayerIndex);
            POVRbox.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", PlayerIndex)));
        }

        #endregion
    }
}
