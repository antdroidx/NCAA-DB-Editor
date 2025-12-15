using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            LoadPlayerPosBox();

            if (dbIndex2 == 1) PlayerTransferButton.Visible = true;

            if (PlayerIndex > 0) LoadPGIDlistBox();

            PlayerStatsView.Rows.Clear();

            InjuryLabel.Visible = false;

            PGIDlistBox.DrawMode = DrawMode.OwnerDrawVariable;
            PGIDlistBox.MeasureItem -= PGIDlistBox_MeasureItem;
            PGIDlistBox.MeasureItem += PGIDlistBox_MeasureItem;
            PGIDlistBox.DrawItem -= PGIDlistBox_DrawItem;
            PGIDlistBox.DrawItem += PGIDlistBox_DrawItem;
        }

        private void LoadPlayerTGIDBox()
        {
            if (TGIDplayerBox.Items.Count > 0) return;
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


            teamList.Sort();
            //teamList.Add("_ALL PLAYERS_");
            teamList.Insert(0, "ALL PLAYERS");
            teamList.Add("OTHER");

            for (int i = 0; i < teamList.Count; i++)
            {
                if (teamList[i] != null) TGIDplayerBox.Items.Add(teamList[i]);
            }

        }

        private void LoadPlayerPosBox()
        {
            if (PlayerPosBox.Items.Count > 0) return;
            PlayerPosBox.Items.Clear();
            List<string> posList = new List<string>();
            posList.Add("ALL");


            for (int i = 0; i < 17; i++)
            {
                posList.Add(GetPOSG2Name(i));
            }

            for (int i = 0; i < posList.Count; i++)
            {
                if (posList[i] != null) PlayerPosBox.Items.Add(posList[i]);
            }

        }



        public void LoadPGIDlistBox()
        {
            PlayerEditorList = new List<List<string>>();
            PJENList = new List<int>();
            int pgidBeg = -1;
            int pgidEnd = -1;
            int playersLeaving = 0;


            if (TGIDplayerBox.Text != "ALL PLAYERS" && TGIDplayerBox.Text != "OTHER")
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
                pgidEnd = 255*70;
            }

            int row = 0;
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) >= pgidBeg && GetDBValueInt("PLAY", "PGID", i) <= pgidEnd && !TDB.TDBTableRecordDeleted(dbIndex, "PLAY", i))
                {
                    int PlayerPOSG2 = GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i));
                    if (PlayerPosBox.SelectedIndex <= 0 || PlayerPOSG2 == PlayerPosBox.SelectedIndex - 1)
                    {
                        PlayerEditorList.Add(new List<string>());
                        PlayerEditorList[row].Add(GetFirstNameFromRecord(i));
                        PlayerEditorList[row].Add(GetLastNameFromRecord(i));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "PPOS", i));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "POVR", i));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "PGID", i));
                        PlayerEditorList[row].Add(Convert.ToString(i));
                        PlayerEditorList[row].Add(Convert.ToString(GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i))));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "PTYP", i));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "PYER", i));
                        PlayerEditorList[row].Add(GetDBValue("PLAY", "PRSD", i));


                        // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec

                        if (TGIDplayerBox.Text != "ALL PLAYERS") PJENList.Add(GetDBValueInt("PLAY", "PJEN", i));

                        row++;
                    }
                }
            }

            if (TGIDplayerBox.Text == "OTHER")
            {
                //create a list of fcs teams
                PlayerEditorList = new List<List<string>>();
                List<int> FCSpgid = new List<int>();

                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    int tgid = GetDBValueInt("TEAM", "TGID", i);
                    if (GetDBValueInt("TEAM", "TTYP", i) == 1)
                    {
                        for (int j = tgid * 70; j < tgid * 70 + 70; j++)
                        {
                            FCSpgid.Add(j);
                        }
                    }
                }


                row = 0;
                for (int i = 0; i < GetTableRecCount("PLAY"); i++)
                {
                    if (FCSpgid.Contains(GetDBValueInt("PLAY", "PGID", i)) && !TDB.TDBTableRecordDeleted(dbIndex, "PLAY", i))
                    {
                        int PlayerPOSG2 = GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i));
                        if (PlayerPosBox.SelectedIndex <= 0 || PlayerPOSG2 == PlayerPosBox.SelectedIndex - 1)
                        {
                            PlayerEditorList.Add(new List<string>());
                            PlayerEditorList[row].Add(GetFirstNameFromRecord(i));
                            PlayerEditorList[row].Add(GetLastNameFromRecord(i));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "PPOS", i));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "POVR", i));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "PGID", i));
                            PlayerEditorList[row].Add(Convert.ToString(i));
                            PlayerEditorList[row].Add(Convert.ToString(GetPOSG2fromPPOS(GetDBValueInt("PLAY", "PPOS", i))));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "PTYP", i));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "PYER", i));
                            PlayerEditorList[row].Add(GetDBValue("PLAY", "PRSD", i));
                            // 0 First Name  1 Last Name 2 Position 3 Overall 4 PGID 5 rec

                            row++;
                        }
                    }
                }
            }


            //Display Filters

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


            PGIDlistBox.BeginUpdate();
            PGIDlistBox.Items.Clear();

            foreach (var player in PlayerEditorList)
            {
                string text = "";
                string status = "";
                if (player[9] == "1") status = " [RS]";
                else if (player[9] == "3") status = " [MED]";
                if (player[7] == "1") status = " [TRAN]";
                else if (player[7] == "3" && player[8] == "3") status = " [GRAD]";
                else if (player[7] == "3" && player[8] != "3") status = " [NFL]";

                if (status != "" && status != " [RS]") playersLeaving++;

                if (ShowPosCheckBox.Checked) text += "[" + Convert.ToString(Positions[Convert.ToInt32(player[2])]) + "] ";
                else if (ShowPOSGBox.Checked) text += "[" + GetPOSG2Name(Convert.ToInt32(player[6])) + "] ";
                text += player[0] + " " + player[1];
                if (ShowRatingCheckbox.Checked) text += "  (" + Convert.ToString(ConvertRating(Convert.ToInt32(player[3]))) + ")";

                text += status;
                PGIDlistBox.Items.Add(text);
            }


            PGIDlistBox.EndUpdate();

            // ensure layout/measurement happens after form has laid out controls
            PGIDlistBox.Invalidate();
            PGIDlistBox.Update();
            // Optionally force refresh on UI thread after layout:
            this.BeginInvoke((Action)(() => PGIDlistBox.Refresh()));


            RosterSizeLabel.Text = "Roster: " + Convert.ToString(PlayerEditorList.Count);
            if (PlayerEditorList.Count > 0 && playersLeaving > 0) RosterSizeLabel.Text += " | Leaving: " + playersLeaving;
        }

        //Change Selected Team
        public void TGIDplayerBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPGIDlistBox();
        }

        //Position Filter
        private void PlayerPosBox_SelectedIndexChanged(object sender, EventArgs e)
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

            //Home
            int home = GetDBValueInt("PLAY", "RCHD", PlayerIndex);
            int state = home / 256;
            AddStateItems();
            PStateBox.SelectedIndex = state;

            AddPHometownItems();
            if (home - (state * 256) > PHometownBox.Items.Count)
            {
                home = state * 256 + rand.Next(0, PHometownBox.Items.Count - 1);
                ChangeDBInt("PLAY", "RCHD", PlayerIndex, home);
            }
            PHometownBox.SelectedIndex = home - (state * 256);


            //Overall Rating
            POVRbox.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "POVR", PlayerIndex)));
            POVRbox.BackColor = GetColorRating(Convert.ToInt32(POVRbox.Text));

            //Discipline
            PDIS.Value = GetDBValueInt("PLAY", "PDIS", PlayerIndex);
            PDIS.BackColor = GetPrestigeColor(PDIS.Value);

            //PGID Box
            PGIDbox.Text = GetDBValue("PLAY", "PGID", PlayerIndex);

            //Team & Transfer
            PlayerTransferLabel.Visible = true;
            string team = teamNameDB[GetDBValueInt("PLAY", "PGID", PlayerIndex) / 70];
            PlayerTransferLabel.Text = "" + team;

            for (int i = 0; i < GetTableRecCount("TRAN"); i++)
            {
                if (GetDBValueInt("TRAN", "PGID", i) == (GetDBValueInt("PLAY", "PGID", PlayerIndex)) && GetDBValueInt("TRAN", "PTID", i) < 300)
                {
                    PlayerTransferLabel.Text += " | Transfer From " + teamNameDB[GetDBValueInt("TRAN", "PTID", i)];
                    break;
                }
            }


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

            int height = Convert.ToInt32(PHGTBox.Value);
            int feet = height / 12;
            int inches = height % 12;
            PlayerHeight.Text = feet + "'" + inches + "\"";


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

            //Primary Hand
            PlayerHandBox.SelectedIndex = GetDBValueInt("PLAY", "PHAN", PlayerIndex);

            //Injury Status

            int injuryrec = CheckPlayerInjuryStatus();
            if (injuryrec >= 0)
            {
                InjuryLabel.Visible = true;
                List<string> injuryTypes = CreateInjuryTypeTable();
                List<string> injuryLength = CreateInjuryLengthTable();
                InjuryLabel.Text = "INJURED: " + injuryTypes[GetDBValueInt("INJY", "INJT", injuryrec)] + "  [" + injuryLength[GetDBValueInt("INJY", "INJL", injuryrec)] + "]";
            }
            else
            {
                InjuryLabel.Visible = false;
            }


            //Attributes
            //
            //

            //Potential
            PPOEBox.Value = GetDBValueInt("PLAY", "PPOE", PlayerIndex);
            PPOEtext.Text = Convert.ToString(ConvertPotentialRating(Convert.ToInt32(PPOEBox.Value)));
            PPOEtext.BackColor = GetColorRating(Convert.ToInt32(PPOEtext.Text));

            //Injury
            PINJBox.Maximum = maxRatingVal;
            PINJBox.Value = GetDBValueInt("PLAY", "PINJ", PlayerIndex);
            PINJtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PINJBox.Value)));
            PINJtext.BackColor = GetColorRating(Convert.ToInt32(PINJtext.Text));


            //Stamina
            PSTAbox.Maximum = maxRatingVal;
            PSTAbox.Value = GetDBValueInt("PLAY", "PSTA", PlayerIndex);
            PSTAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PSTAbox.Value)));
            PSTAtext.BackColor = GetColorRating(Convert.ToInt32(PSTAtext.Text));

            //Awareness
            PAWRBox.Maximum = maxRatingVal;
            PAWRBox.Value = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
            PAWRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAWRBox.Value)));
            PAWRtext.BackColor = GetColorRating(Convert.ToInt32(PAWRtext.Text));

            //Speed
            PSPDBox.Maximum = maxRatingVal;
            PSPDBox.Value = GetDBValueInt("PLAY", "PSPD", PlayerIndex);
            PSPDtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PSPDBox.Value)));
            PSPDtext.BackColor = GetColorRating(Convert.ToInt32(PSPDtext.Text));

            //Agility
            PAGIBox.Maximum = maxRatingVal;
            PAGIBox.Value = GetDBValueInt("PLAY", "PAGI", PlayerIndex);
            PAGItext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PAGIBox.Value)));
            PAGItext.BackColor = GetColorRating(Convert.ToInt32(PAGItext.Text));

            //Acceleration
            PACCBox.Maximum = maxRatingVal;
            PACCBox.Value = GetDBValueInt("PLAY", "PACC", PlayerIndex);
            PACCtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PACCBox.Value)));
            PACCtext.BackColor = GetColorRating(Convert.ToInt32(PACCtext.Text));

            //Jumping
            PJMPBox.Maximum = maxRatingVal;
            PJMPBox.Value = GetDBValueInt("PLAY", "PJMP", PlayerIndex);
            PJMPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PJMPBox.Value)));
            PJMPtext.BackColor = GetColorRating(Convert.ToInt32(PJMPtext.Text));

            //Strength
            PSTRBox.Maximum = maxRatingVal;
            PSTRBox.Value = GetDBValueInt("PLAY", "PSTR", PlayerIndex);
            PSTRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PSTRBox.Value)));
            PSTRtext.BackColor = GetColorRating(Convert.ToInt32(PSTRtext.Text));

            //Throw Power
            PTHPBox.Maximum = maxRatingVal;
            PTHPBox.Value = GetDBValueInt("PLAY", "PTHP", PlayerIndex);
            PTHPtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTHPBox.Value)));
            PTHPtext.BackColor = GetColorRating(Convert.ToInt32(PTHPtext.Text));

            //Throw Accuracy
            PTHABox.Maximum = maxRatingVal;
            PTHABox.Value = GetDBValueInt("PLAY", "PTHA", PlayerIndex);
            PTHAtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTHABox.Value)));
            PTHAtext.BackColor = GetColorRating(Convert.ToInt32(PTHAtext.Text));

            //Break Tackle
            PBTKBox.Maximum = maxRatingVal;
            PBTKBox.Value = GetDBValueInt("PLAY", "PBTK", PlayerIndex);
            PBTKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PBTKBox.Value)));
            PBTKtext.BackColor = GetColorRating(Convert.ToInt32(PBTKtext.Text));

            //Ball Carry
            PCARBox.Maximum = maxRatingVal;
            PCARBox.Value = GetDBValueInt("PLAY", "PCAR", PlayerIndex);
            PCARtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PCARBox.Value)));
            PCARtext.BackColor = GetColorRating(Convert.ToInt32(PCARtext.Text));

            //Run Blocking
            PRBKBox.Maximum = maxRatingVal;
            PRBKBox.Value = GetDBValueInt("PLAY", "PRBK", PlayerIndex);
            PRBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PRBKBox.Value)));
            PRBKtext.BackColor = GetColorRating(Convert.ToInt32(PRBKtext.Text));

            //Pass Blocking
            PPBKBox.Maximum = maxRatingVal;
            PPBKBox.Value = GetDBValueInt("PLAY", "PPBK", PlayerIndex);
            PPBKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PPBKBox.Value)));
            PPBKtext.BackColor = GetColorRating(Convert.ToInt32(PPBKtext.Text));

            //Catching
            PCTHBox.Maximum = maxRatingVal;
            PCTHBox.Value = GetDBValueInt("PLAY", "PCTH", PlayerIndex);
            PCTHtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PCTHBox.Value)));
            PCTHtext.BackColor = GetColorRating(Convert.ToInt32(PCTHtext.Text));

            //Tackling
            PTAKBox.Maximum = maxRatingVal;
            PTAKBox.Value = GetDBValueInt("PLAY", "PTAK", PlayerIndex);
            PTAKtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PTAKBox.Value)));
            PTAKtext.BackColor = GetColorRating(Convert.ToInt32(PTAKtext.Text));

            //Kick Power
            PKPRBox.Maximum = maxRatingVal;
            PKPRBox.Value = GetDBValueInt("PLAY", "PKPR", PlayerIndex);
            PKPRtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PKPRBox.Value)));
            PKPRtext.BackColor = GetColorRating(Convert.ToInt32(PKPRtext.Text));

            //Kick Accuracy
            PKACBox.Maximum = maxRatingVal;
            PKACBox.Value = GetDBValueInt("PLAY", "PKAC", PlayerIndex);
            PKACtext.Text = Convert.ToString(ConvertRating(Convert.ToInt32(PKACBox.Value)));
            PKACtext.BackColor = GetColorRating(Convert.ToInt32(PKACtext.Text));

            //Player Tendency/Archeatype
            PTEN.Text = GetPTENType(GetDBValueInt("PLAY", "PPOS", PlayerIndex), GetDBValueInt("PLAY", "PTEN", PlayerIndex));


            //POCI CHECK
            int pos = GetDBValueInt("PLAY", "PPOS", PlayerIndex);
            // PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR

            if (POCI[pos, 3] > 0) PCARlabel.ForeColor = Color.DarkSlateBlue;
            else PCARlabel.ForeColor = Color.Black;

            if (POCI[pos, 4] > 0) PKAClabel.ForeColor = Color.DarkSlateBlue;
            else PKAClabel.ForeColor = Color.Black;

            if (POCI[pos, 5] > 0) PTHAlabel.ForeColor = Color.DarkSlateBlue;
            else PTHAlabel.ForeColor = Color.Black;

            if (POCI[pos, 6] > 0) PPBKlabel.ForeColor = Color.DarkSlateBlue;
            else PPBKlabel.ForeColor = Color.Black;

            if (POCI[pos, 7] > 0) PRBKlabel.ForeColor = Color.DarkSlateBlue;
            else PRBKlabel.ForeColor = Color.Black;

            if (POCI[pos, 8] > 0) PACClabel.ForeColor = Color.DarkSlateBlue;
            else PACClabel.ForeColor = Color.Black;

            if (POCI[pos, 9] > 0) PAGIlabel.ForeColor = Color.DarkSlateBlue;
            else PAGIlabel.ForeColor = Color.Black;

            if (POCI[pos, 10] > 0) PTAKlabel.ForeColor = Color.DarkSlateBlue;
            else PTAKlabel.ForeColor = Color.Black;

            if (POCI[pos, 12] > 0) PKPRlabel.ForeColor = Color.DarkSlateBlue;
            else PKPRlabel.ForeColor = Color.Black;

            if (POCI[pos, 13] > 0) PSPDlabel.ForeColor = Color.DarkSlateBlue;
            else PSPDlabel.ForeColor = Color.Black;

            if (POCI[pos, 14] > 0) PTHPlabel.ForeColor = Color.DarkSlateBlue;
            else PTHPlabel.ForeColor = Color.Black;

            if (POCI[pos, 15] > 0) PBTKlabel.ForeColor = Color.DarkSlateBlue;
            else PBTKlabel.ForeColor = Color.Black;

            if (POCI[pos, 16] > 0) PCTHlabel.ForeColor = Color.DarkSlateBlue;
            else PCTHlabel.ForeColor = Color.Black;

            if (POCI[pos, 17] > 0) PSTRlabel.ForeColor = Color.DarkSlateBlue;
            else PSTRlabel.ForeColor = Color.Black;

            if (POCI[pos, 18] > 0) PJMPlabel.ForeColor = Color.DarkSlateBlue;
            else PJMPlabel.ForeColor = Color.Black;

            if (POCI[pos, 19] > 0) PAWRlabel.ForeColor = Color.DarkSlateBlue;
            else PAWRlabel.ForeColor = Color.Black;





            //Off-Season Type
            AddPTYPItems();
            PTYPBox.SelectedIndex = GetDBValueInt("PLAY", "PTYP", PlayerIndex);


            /* PLAYER GEAR */

            //Add Data
            AddHelmetTypes();
            AddFaceMaskItems();
            AddVisorTypes();
            AddQBJacketTypes();
            AddFaceProtectorTypes();

            AddEyeBlackTypes();
            AddNasalStripTypes();
            AddMouthGuardTypes();
            AddNeckPadTypes();

            AddSleevesTypes();
            AddSleevesColors();
            AddTurfTapeTypes();
            AddLeftWristTypes();
            AddRightWristTypes();
            AddLeftElbowTypes();
            AddRightElbowTypes();
            AddLeftHandTypes();
            AddRightHandTypes();

            AddLeftShoeTypes();
            AddRightShoeTypes();

            //Helmet & Head Gear
            int HELM = GetDBValueInt("PLAY", "HELM", PlayerIndex);
            int FCMK = GetDBValueInt("PLAY", "PFMK", PlayerIndex);

            if (HELM == 3 && FCMK > 3) RandomizeHelmet("PLAY", PlayerIndex);

            Helmet.SelectedIndex = GetDBValueInt("PLAY", "HELM", PlayerIndex);
            Facemask.SelectedIndex = GetDBValueInt("PLAY", "PFMK", PlayerIndex);
            Visor.SelectedIndex = GetDBValueInt("PLAY", "PVIS", PlayerIndex);

            int pfjs = GetDBValueInt("PLAY", "PFJS", PlayerIndex);
            if (pfjs > 0) QBJacket.SelectedIndex = 1;
            else QBJacket.SelectedIndex = 0;

            FaceProtector.SelectedIndex = GetDBValueInt("PLAY", "PLFP", PlayerIndex);
            EyeBlack.SelectedIndex = GetDBValueInt("PLAY", "PEYE", PlayerIndex);
            NasalStrip.SelectedIndex = GetDBValueInt("PLAY", "PBRE", PlayerIndex);
            Mouthguard.SelectedIndex = GetDBValueInt("PLAY", "PLMG", PlayerIndex);
            NeckPad.SelectedIndex = GetDBValueInt("PLAY", "PNEK", PlayerIndex);

            // Arms
            Sleeves.SelectedIndex = GetDBValueInt("PLAY", "PSLO", PlayerIndex);
            SleeveColor.SelectedIndex = GetDBValueInt("PLAY", "PSLT", PlayerIndex);
            TurfTape.SelectedIndex = GetDBValueInt("PLAY", "PTTO", PlayerIndex);

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

            LoadPlayerStats();

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

        private void AddStateItems()
        {
            PStateBox.Items.Clear();
            List<string> states = CreateStringListfromCSV(@"resources\players\RCST.csv", true);

            foreach (string state in states)
            {
                PStateBox.Items.Add(state);
            }
        }

        private void AddPHometownItems()
        {
            PHometownBox.Items.Clear();
            string[] home = new string[13057];

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\RCHT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                home[Convert.ToInt32(Line[0])] = Line[1];

            }
            sr.Close();


            int start = (GetDBValueInt("PLAY", "RCHD", PlayerIndex) / 256) * 256;
            for (int i = start; i < start + 256; i++)
            {
                if (i >= home.Length) break;
                if (home[i] == null) break;
                PHometownBox.Items.Add(home[i]);
            }
        }

        //GEAR

        private void AddHelmetTypes()
        {
            Helmet.Items.Clear();
            List<string> type = GetHelmetTypes();
            foreach (var x in type)
            {
                Helmet.Items.Add(x);
            }
        }

        private void AddFaceMaskItems()
        {
            Facemask.Items.Clear();
            List<string> type = GetFaceMaskTypes(GetDBValueInt("PLAY", "HELM", PlayerIndex));
            foreach (var x in type)
            {
                Facemask.Items.Add(x);
            }
        }

        private void AddVisorTypes()
        {
            Visor.Items.Clear();
            List<string> type = GetVisorTypes();
            foreach (var x in type)
            {
                Visor.Items.Add(x);
            }
        }
        private void AddQBJacketTypes()
        {
            QBJacket.Items.Clear();
            List<string> type = GetQBJacketTypes();
            foreach (var x in type)
            {
                QBJacket.Items.Add(x);
            }
        }

        private void AddFaceProtectorTypes()
        {
            FaceProtector.Items.Clear();
            List<string> type = GetFaceProtectorTypes();
            foreach (var x in type)
            {
                FaceProtector.Items.Add(x);
            }
        }


        private void AddEyeBlackTypes()
        {
            EyeBlack.Items.Clear();
            List<string> type = GetEyeBlackTypes();
            foreach (var x in type)
            {
                EyeBlack.Items.Add(x);
            }
        }

        private void AddNasalStripTypes()
        {
            NasalStrip.Items.Clear();
            List<string> type = GetNasalStripTypes();
            foreach (var x in type)
            {
                NasalStrip.Items.Add(x);
            }
        }

        private void AddMouthGuardTypes()
        {
            Mouthguard.Items.Clear();
            List<string> type = GetMouthguardTypes();
            foreach (var x in type)
            {
                Mouthguard.Items.Add(x);
            }
        }

        private void AddNeckPadTypes()
        {
            NeckPad.Items.Clear();
            List<string> type = GetNeckPadTypes();
            foreach (var x in type)
            {
                NeckPad.Items.Add(x);
            }
        }

        private void AddTurfTapeTypes()
        {
            TurfTape.Items.Clear();
            List<string> type = GetTurfTapeTypes();
            foreach (var x in type)
            {
                TurfTape.Items.Add(x);
            }
        }
        private void AddSleevesTypes()
        {
            Sleeves.Items.Clear();
            List<string> type = GetSleevesType();
            foreach (var x in type)
            {
                Sleeves.Items.Add(x);
            }
        }

        private void AddSleevesColors()
        {
            SleeveColor.Items.Clear();
            List<string> type = GetSleevesColors();
            foreach (var x in type)
            {
                SleeveColor.Items.Add(x);
            }
        }

        private void AddRightElbowTypes()
        {
            RightElbow.Items.Clear();
            List<string> type = GetElbowTypes();
            foreach (var x in type)
            {
                RightElbow.Items.Add(x);
            }
        }

        private void AddLeftElbowTypes()
        {
            LeftElbow.Items.Clear();
            List<string> type = GetElbowTypes();
            foreach (var x in type)
            {
                LeftElbow.Items.Add(x);
            }
        }

        private void AddRightWristTypes()
        {
            RightWrist.Items.Clear();
            List<string> type = GetWristsTypes();
            foreach (var x in type)
            {
                RightWrist.Items.Add(x);
            }
        }

        private void AddLeftWristTypes()
        {
            LeftWrist.Items.Clear();
            List<string> type = GetWristsTypes();
            foreach (var x in type)
            {
                LeftWrist.Items.Add(x);
            }
        }

        private void AddRightHandTypes()
        {
            RightHand.Items.Clear();
            List<string> type = GetHandTypes();
            foreach (var x in type)
            {
                RightHand.Items.Add(x);
            }
        }

        private void AddLeftHandTypes()
        {
            LeftHand.Items.Clear();
            List<string> type = GetHandTypes();
            foreach (var x in type)
            {
                LeftHand.Items.Add(x);
            }
        }

        private void AddRightShoeTypes()
        {
            RightShoe.Items.Clear();
            List<string> type = GetCleatTypes();
            foreach (var x in type)
            {
                RightShoe.Items.Add(x);
            }
        }

        private void AddLeftShoeTypes()
        {
            LeftShoe.Items.Clear();
            List<string> type = GetCleatTypes();
            foreach (var x in type)
            {
                LeftShoe.Items.Add(x);
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

            if (AWHRBox.Checked)
            {
                DoNotTrigger = true;
                PPOSmem = GetDBValueInt("PLAY", "PPOS", PlayerIndex);
                AWRHmem = GetDBValueInt("PLAY", "PAWR", PlayerIndex);
                double hit = 0.19;

                if (verNumber >= 15.0) hit = 0.08;

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
            LoadPGIDlistBox();
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

        // Change Home
        private void PStateBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            AddPHometownItems();
            PHometownBox.SelectedIndex = rand.Next(0, PHometownBox.Items.Count);
        }

        private void PHometownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;
            int hometown = PHometownBox.SelectedIndex + (256 * PStateBox.SelectedIndex);

            ChangeDBInt("PLAY", "RCHD", PlayerIndex, hometown);
        }


        //Discipline

        private void PDIS_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PDIS", PlayerIndex, Convert.ToInt32(PDIS.Value));
            PDIS.BackColor = GetPrestigeColor(PDIS.Value);

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
            RecalculateIndividualBodyShape(PlayerIndex, "PLAY");


            int height = Convert.ToInt32(PHGTBox.Value);
            int feet = height / 12;
            int inches = height % 12;
            PlayerHeight.Text = feet + "'" + inches + "\"";
        }

        private void PWGTBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PWGT", PlayerIndex, Convert.ToInt32(PWGTBox.Value) - 160);
            RecalculateIndividualBodyShape(PlayerIndex, "PLAY");

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

        //Change Primary Hand

        private void PlayerHandBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PHAN", PlayerIndex, PlayerHandBox.SelectedIndex);

        }

        //Rating Attributes


        private void PPOEBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PPOE", PlayerIndex, Convert.ToInt32(PPOEBox.Value));
            PPOEtext.Text = Convert.ToString(ConvertPotentialRating(GetDBValueInt("PLAY", "PPOE", PlayerIndex)));
            PPOEtext.BackColor = GetColorRating(Convert.ToInt32(PPOEtext.Text));

        }


        private void PSTAbox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSTA", PlayerIndex, Convert.ToInt32(PSTAbox.Value));
            PSTAtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSTA", PlayerIndex)));
            PSTAtext.BackColor = GetColorRating(Convert.ToInt32(PSTAtext.Text));

            DisplayNewOverallRating();
        }


        private void PINJBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PINJ", PlayerIndex, Convert.ToInt32(PINJBox.Value));
            PINJtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PINJ", PlayerIndex)));
            PINJtext.BackColor = GetColorRating(Convert.ToInt32(PINJtext.Text));

            DisplayNewOverallRating();
        }

        private void PAWRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAWR", PlayerIndex, Convert.ToInt32(PAWRBox.Value));
            PAWRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAWR", PlayerIndex)));
            PAWRtext.BackColor = GetColorRating(Convert.ToInt32(PAWRtext.Text));

            DisplayNewOverallRating();
        }


        private void PSPDBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSPD", PlayerIndex, Convert.ToInt32(PSPDBox.Value));
            PSPDtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSPD", PlayerIndex)));
            PSPDtext.BackColor = GetColorRating(Convert.ToInt32(PSPDtext.Text));

            DisplayNewOverallRating();
        }

        private void PAGIBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PAGI", PlayerIndex, Convert.ToInt32(PAGIBox.Value));
            PAGItext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PAGI", PlayerIndex)));
            PAGItext.BackColor = GetColorRating(Convert.ToInt32(PAGItext.Text));

            DisplayNewOverallRating();
        }
        private void PACCBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PACC", PlayerIndex, Convert.ToInt32(PACCBox.Value));
            PACCtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PACC", PlayerIndex)));
            PACCtext.BackColor = GetColorRating(Convert.ToInt32(PACCtext.Text));

            DisplayNewOverallRating();
        }

        private void PJMPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PJMP", PlayerIndex, Convert.ToInt32(PJMPBox.Value));
            PJMPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PJMP", PlayerIndex)));
            PJMPtext.BackColor = GetColorRating(Convert.ToInt32(PJMPtext.Text));

            DisplayNewOverallRating();
        }
        private void PSTRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PSTR", PlayerIndex, Convert.ToInt32(PSTRBox.Value));
            PSTRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PSTR", PlayerIndex)));
            PSTRtext.BackColor = GetColorRating(Convert.ToInt32(PSTRtext.Text));

            DisplayNewOverallRating();
        }

        private void PTHPBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHP", PlayerIndex, Convert.ToInt32(PTHPBox.Value));
            PTHPtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHP", PlayerIndex)));
            PTHPtext.BackColor = GetColorRating(Convert.ToInt32(PTHPtext.Text));

            DisplayNewOverallRating();
        }

        private void PTHABox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTHA", PlayerIndex, Convert.ToInt32(PTHABox.Value));
            PTHAtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTHA", PlayerIndex)));
            PTHAtext.BackColor = GetColorRating(Convert.ToInt32(PTHAtext.Text));

            DisplayNewOverallRating();
        }

        private void PBTKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PBTK", PlayerIndex, Convert.ToInt32(PBTKBox.Value));
            PBTKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PBTK", PlayerIndex)));
            PBTKtext.BackColor = GetColorRating(Convert.ToInt32(PBTKtext.Text));

            DisplayNewOverallRating();
        }

        private void PCARBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCAR", PlayerIndex, Convert.ToInt32(PCARBox.Value));
            PCARtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCAR", PlayerIndex)));
            PCARtext.BackColor = GetColorRating(Convert.ToInt32(PCARtext.Text));

            DisplayNewOverallRating();
        }

        private void PRBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PRBK", PlayerIndex, Convert.ToInt32(PRBKBox.Value));
            PRBKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PRBK", PlayerIndex)));
            PRBKtext.BackColor = GetColorRating(Convert.ToInt32(PRBKtext.Text));

            DisplayNewOverallRating();
        }

        private void PPBKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PPBK", PlayerIndex, Convert.ToInt32(PPBKBox.Value));
            PPBKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PPBK", PlayerIndex)));
            PPBKtext.BackColor = GetColorRating(Convert.ToInt32(PPBKtext.Text));

            DisplayNewOverallRating();
        }


        private void PCTHBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PCTH", PlayerIndex, Convert.ToInt32(PCTHBox.Value));
            PCTHtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PCTH", PlayerIndex)));
            PCTHtext.BackColor = GetColorRating(Convert.ToInt32(PCTHtext.Text));

            DisplayNewOverallRating();
        }

        private void PTAKBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTAK", PlayerIndex, Convert.ToInt32(PTAKBox.Value));
            PTAKtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PTAK", PlayerIndex)));
            PTAKtext.BackColor = GetColorRating(Convert.ToInt32(PTAKtext.Text));

            DisplayNewOverallRating();
        }

        private void PKPRBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKPR", PlayerIndex, Convert.ToInt32(PKPRBox.Value));
            PKPRtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKPR", PlayerIndex)));
            PKPRtext.BackColor = GetColorRating(Convert.ToInt32(PKPRtext.Text));

            DisplayNewOverallRating();
        }


        private void PKACBox_ValueChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PKAC", PlayerIndex, Convert.ToInt32(PKACBox.Value));
            PKACtext.Text = Convert.ToString(ConvertRating(GetDBValueInt("PLAY", "PKAC", PlayerIndex)));
            PKACtext.BackColor = GetColorRating(Convert.ToInt32(PKACtext.Text));

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

        private void QBJacket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;
            int x = Visor.SelectedIndex;
            if (x > 0) x = 6;
            ChangeDBInt("PLAY", "PFJS", PlayerIndex, x);
        }


        private void FaceProtector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;
            int x = Visor.SelectedIndex;
            if (x > 0) x = 6;
            ChangeDBInt("PLAY", "PLFP", PlayerIndex, x);
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

        private void Mouthguard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PLMG", PlayerIndex, Mouthguard.SelectedIndex);
        }

        private void NeckPad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PNEK", PlayerIndex, NeckPad.SelectedIndex);
        }

        private void TurfTape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DoNotTrigger)
                return;

            ChangeDBInt("PLAY", "PTTO", PlayerIndex, TurfTape.SelectedIndex);
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
            POVRbox.BackColor = GetColorRating(Convert.ToInt32(POVRbox.Text));
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
            int leaguesize = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TTYP", "TEAM", i) == 0) leaguesize++;

            }


            DepthChartMakerSingle("DCHT", GetDBValueInt("PLAY", "PGID", PlayerIndex) / 70, leaguesize);
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

        private int CheckPlayerInjuryStatus()
        {
            int rec = -1;
            int PGID = GetDBValueInt("PLAY", "PGID", PlayerIndex);

            for (int i = 0; i < GetTableRecCount("INJY"); i++)
            {
                if (GetDBValueInt("INJY", "PGID", i) == PGID)
                {
                    return i;
                }
            }

            return rec;
        }

        private void RandPlayerGear_Click(object sender, EventArgs e)
        {
            RandomizePlayerGear("PLAY", PlayerIndex);
            LoadPlayerData();
        }

        private void ImportPlayerTeam_Click(object sender, EventArgs e)
        {

        }

        private void ExportPlayerTeam_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Player Stat Tables

        private void LoadPlayerStats()
        {
            PlayerStatsView.Rows.Clear();
            PlayerStatsView.Visible = true;
            PlayerStatsView.Rows.Add(5);

            int pos = GetDBValueInt("PLAY", "PPOS", PlayerIndex);
            int pgid = GetDBValueInt("PLAY", "PGID", PlayerIndex);

            if (pos == 0) LoadQBStatsView(pgid);
            else if (pos == 1 || pos == 2) LoadRushingStatsView(pgid);
            else if (pos == 3 || pos == 4) LoadReceivingStatsView(pgid);
            else if (pos >= 5 && pos <= 9) LoadOLStatsView(pgid);
            else if (pos >= 10 && pos <= 18) LoadDefStatsView(pgid);
            else if (pos == 19) LoadKickStats(pgid);
            else if (pos == 20) LoadPuntStats(pgid);
            else PlayerStatsView.Visible = false;


            for (int i = 0; i < PlayerStatsView.Rows.Count; i++)
            {
                if (PlayerStatsView.Rows[i].Cells[0] == null || PlayerStatsView.Rows[i].Cells[0].Value == null)
                {
                    PlayerStatsView.Rows.RemoveAt(i);
                    i--;
                }
            }

        }

        private void LoadQBStatsView(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "QBR";
            PS3.HeaderText = "Comp";
            PS4.HeaderText = "Att";
            PS5.HeaderText = "PCT";
            PS6.HeaderText = "Yds";
            PS7.HeaderText = "YPG";
            PS8.HeaderText = "TD";
            PS9.HeaderText = "Int";
            PS10.HeaderText = "Sacks";

            int year = GetDBValueInt("SEAI", "SEYR", 0);


            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSOF", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;
                    int gp = GetDBValueInt("PSOF", "sgmp", i);
                    int cmp = GetDBValueInt("PSOF", "sacm", i);
                    int att = GetDBValueInt("PSOF", "saat", i);
                    int yds = GetDBValueInt("PSOF", "saya", i);
                    int td = GetDBValueInt("PSOF", "satd", i);
                    int ints = GetDBValueInt("PSOF", "sain", i);
                    int skd = GetDBValueInt("PSOF", "sasa", i);
                    if (gp <= 0) gp = CountTeamGames(pgid/ 70);

                    double pct = 0;
                    if (att > 0) pct = Math.Round((Convert.ToDouble(cmp) / Convert.ToDouble(att)) * 100, 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);


                    // NCAA Passer Rating Formula:
                    // (8.4 * YDS + 330 * TD + 100 * CMP - 200 * INT) / ATT
                    double qbr = 0;
                    if (att > 0)
                    {
                        qbr = Math.Round(
                            ((8.4 * yds) +
                             (330 * td) +
                             (100 * cmp) -
                             (200 * ints)) / att, 1);
                    }
                    if (qbr < 0) qbr = 0;

                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = qbr;
                    PlayerStatsView.Rows[row].Cells[3].Value = cmp;
                    PlayerStatsView.Rows[row].Cells[4].Value = att;
                    PlayerStatsView.Rows[row].Cells[5].Value = pct;
                    PlayerStatsView.Rows[row].Cells[6].Value = yds;
                    PlayerStatsView.Rows[row].Cells[7].Value = ypg;
                    PlayerStatsView.Rows[row].Cells[8].Value = td;
                    PlayerStatsView.Rows[row].Cells[9].Value = ints;
                    PlayerStatsView.Rows[row].Cells[10].Value = skd;


                }
            }
        }


        private void LoadRushingStatsView(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "Att";
            PS3.HeaderText = "Yds";
            PS4.HeaderText = "TD";
            PS5.HeaderText = "YPC";
            PS6.HeaderText = "YPG";
            PS7.HeaderText = "Fum";
            PS8.HeaderText = "YAI";
            PS9.HeaderText = "BTk";
            PS10.HeaderText = "20+";

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSOF", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;
                    int gp = GetDBValueInt("PSOF", "sgmp", i);
                    int att = GetDBValueInt("PSOF", "suat", i);
                    int yds = GetDBValueInt("PSOF", "suya", i);
                    int td = GetDBValueInt("PSOF", "sutd", i);
                    int fum = GetDBValueInt("PSOF", "sufu", i);
                    int yai = GetDBValueInt("PSOF", "suyh", i);
                    int btk = GetDBValueInt("PSOF", "subt", i);
                    int twenty = GetDBValueInt("PSOF", "su2y", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);

                    double ypc = 0;
                    if (att > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(att)), 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = att;
                    PlayerStatsView.Rows[row].Cells[3].Value = yds;
                    PlayerStatsView.Rows[row].Cells[4].Value = td;
                    PlayerStatsView.Rows[row].Cells[5].Value = ypc;
                    PlayerStatsView.Rows[row].Cells[6].Value = ypg;
                    PlayerStatsView.Rows[row].Cells[7].Value = fum;
                    PlayerStatsView.Rows[row].Cells[8].Value = yai;
                    PlayerStatsView.Rows[row].Cells[9].Value = btk;
                    PlayerStatsView.Rows[row].Cells[10].Value = twenty;

                }
            }

        }


        private void LoadReceivingStatsView(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "Cat";
            PS3.HeaderText = "Yds";
            PS4.HeaderText = "TD";
            PS5.HeaderText = "YPC";
            PS6.HeaderText = "YPG";
            PS7.HeaderText = "Fum";
            PS8.HeaderText = "RAC";
            PS9.HeaderText = "RCA";
            PS10.HeaderText = "Drp";

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSOF"); i++)
            {
                if (GetDBValueInt("PSOF", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSOF", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;

                    int gp = GetDBValueInt("PSOF", "sgmp", i);

                    int cat = GetDBValueInt("PSOF", "scca", i);
                    int yds = GetDBValueInt("PSOF", "scya", i);
                    int td = GetDBValueInt("PSOF", "sctd", i);
                    int fum = GetDBValueInt("PSOF", "sufu", i);
                    int rac = GetDBValueInt("PSOF", "scyc", i);
                    int drp = GetDBValueInt("PSOF", "scdr", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);

                    double ypc = 0;
                    if (cat > 0) ypc = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(cat)), 1);

                    double ypg = 0;
                    if (gp > 0) ypg = Math.Round((Convert.ToDouble(yds) / Convert.ToDouble(gp)), 1);

                    double rca = 0;
                    if (cat > 0) ypc = Math.Round((Convert.ToDouble(rac) / Convert.ToDouble(cat)), 1);


                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = cat;
                    PlayerStatsView.Rows[row].Cells[3].Value = yds;
                    PlayerStatsView.Rows[row].Cells[4].Value = td;
                    PlayerStatsView.Rows[row].Cells[5].Value = ypc;
                    PlayerStatsView.Rows[row].Cells[6].Value = ypg;
                    PlayerStatsView.Rows[row].Cells[7].Value = fum;
                    PlayerStatsView.Rows[row].Cells[8].Value = rac;
                    PlayerStatsView.Rows[row].Cells[9].Value = rca;
                    PlayerStatsView.Rows[row].Cells[10].Value = drp;

                }
            }

        }

        private void LoadOLStatsView(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "Pnck";
            PS3.HeaderText = "Sack";
            PS4.HeaderText = "";
            PS5.HeaderText = "";
            PS6.HeaderText = "";
            PS7.HeaderText = "";
            PS8.HeaderText = "";
            PS9.HeaderText = "";
            PS10.HeaderText = "";


            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSOL"); i++)
            {
                if (GetDBValueInt("PSOL", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSOL", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;

                    int gp = GetDBValueInt("PSOL", "sgmp", i);

                    int pan = GetDBValueInt("PSOL", "sopa", i);
                    int sack = GetDBValueInt("PSOL", "sosa", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);


                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = pan;
                    PlayerStatsView.Rows[row].Cells[3].Value = sack;

                }
            }
        }

        private void LoadDefStatsView(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "Tkl";
            PS3.HeaderText = "TFL";
            PS4.HeaderText = "Sack";
            PS5.HeaderText = "Int";
            PS6.HeaderText = "PDf";
            PS7.HeaderText = "FFum";
            PS8.HeaderText = "FumR";
            PS9.HeaderText = "DTD";
            PS10.HeaderText = "";

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSDE"); i++)
            {
                if (GetDBValueInt("PSDE", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSDE", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;

                    int gp = GetDBValueInt("PSDE", "sgmp", i);
                    int tak = GetDBValueInt("PSDE", "sdta", i);
                    int tfl = GetDBValueInt("PSDE", "sdtl", i);
                    int sack = GetDBValueInt("PSDE", "slsk", i);
                    int ints = GetDBValueInt("PSDE", "ssin", i);
                    int pdef = GetDBValueInt("PSDE", "sdpd", i);
                    int ffum = GetDBValueInt("PSDE", "slff", i);
                    int fumr = GetDBValueInt("PSDE", "slfr", i);
                    int defTD = GetDBValueInt("PSDE", "ssdt", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);

                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = tak;
                    PlayerStatsView.Rows[row].Cells[3].Value = tfl;
                    PlayerStatsView.Rows[row].Cells[4].Value = sack;
                    PlayerStatsView.Rows[row].Cells[5].Value = ints;
                    PlayerStatsView.Rows[row].Cells[6].Value = pdef;
                    PlayerStatsView.Rows[row].Cells[7].Value = ffum;
                    PlayerStatsView.Rows[row].Cells[8].Value = fumr;
                    PlayerStatsView.Rows[row].Cells[9].Value = defTD;
                }
            }

        }

        private void LoadKickStats(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "FGM";
            PS3.HeaderText = "FGA";
            PS4.HeaderText = "Pct";
            PS5.HeaderText = "Long";
            PS6.HeaderText = "XPM";
            PS7.HeaderText = "XPA";
            PS8.HeaderText = "PCT";
            PS9.HeaderText = "40+";
            PS10.HeaderText = "";

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSKI", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;

                    int gp = GetDBValueInt("PSKI", "sgmp", i);
                    int fgm = GetDBValueInt("PSKI", "skfm", i);
                    int fga = GetDBValueInt("PSKI", "skfa", i);
                    int longest = GetDBValueInt("PSKI", "skfL", i);
                    int xpm = GetDBValueInt("PSKI", "skem", i);
                    int xpa = GetDBValueInt("PSKI", "skea", i);
                    int fourty = GetDBValueInt("PSKI", "", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);

                    double fgpct = 0;
                    if (fga > 0) fgpct = Math.Round((Convert.ToDouble(fgm) / Convert.ToDouble(fga)) * 100, 1);

                    double xppct = 0;
                    if (xpa > 0) xppct = Math.Round((Convert.ToDouble(xpm) / Convert.ToDouble(xpa)) * 100, 1);

                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = fgm;
                    PlayerStatsView.Rows[row].Cells[3].Value = fga;
                    PlayerStatsView.Rows[row].Cells[4].Value = fgpct;
                    PlayerStatsView.Rows[row].Cells[5].Value = longest;
                    PlayerStatsView.Rows[row].Cells[6].Value = xpm;
                    PlayerStatsView.Rows[row].Cells[7].Value = xpa;
                    PlayerStatsView.Rows[row].Cells[8].Value = xppct;
                    PlayerStatsView.Rows[row].Cells[9].Value = fourty;
                }
            }
        }

        private void LoadPuntStats(int pgid)
        {
            PS0.HeaderText = "Year";
            PS1.HeaderText = "GP";
            PS2.HeaderText = "Punt";
            PS3.HeaderText = "Yrd";
            PS4.HeaderText = "Avg";
            PS5.HeaderText = "Long";
            PS6.HeaderText = "I20";
            PS7.HeaderText = "Blk";
            PS8.HeaderText = "";
            PS9.HeaderText = "";
            PS10.HeaderText = "";

            int year = GetDBValueInt("SEAI", "SEYR", 0);

            for (int i = 0; i < GetTableRecCount("PSKI"); i++)
            {
                if (GetDBValueInt("PSKI", "PGID", i) == pgid)
                {
                    int sea = GetDBValueInt("PSKI", "SEYR", i);
                    int row = 4 - (year - sea);
                    if (row < 0) continue;

                    int gp = GetDBValueInt("PSKI", "sgmp", i);
                    int punt = GetDBValueInt("PSKI", "spat", i);
                    int yd = GetDBValueInt("PSKI", "spya", i);
                    int longest = GetDBValueInt("PSKI", "splN", i);
                    int intwenty = GetDBValueInt("PSKI", "sppt", i);
                    int blocked = GetDBValueInt("PSKI", "spbl", i);
                    if (gp <= 0) gp = CountTeamGames(pgid / 70);

                    double puntavg = 0;
                    if (punt > 0) puntavg = Math.Round((Convert.ToDouble(yd) / Convert.ToDouble(punt)), 1);

                    PlayerStatsView.Rows[row].Cells[0].Value = sea;
                    PlayerStatsView.Rows[row].Cells[1].Value = gp;
                    PlayerStatsView.Rows[row].Cells[2].Value = punt;
                    PlayerStatsView.Rows[row].Cells[3].Value = yd;
                    PlayerStatsView.Rows[row].Cells[4].Value = puntavg;
                    PlayerStatsView.Rows[row].Cells[5].Value = longest;
                    PlayerStatsView.Rows[row].Cells[6].Value = intwenty;
                    PlayerStatsView.Rows[row].Cells[7].Value = blocked;
                }
            }
        }

        #endregion


        private void PGIDlistBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb = (ListBox)sender;

            // Single-line height based on control font so we don't depend on control width yet
            e.ItemHeight = lb.Font.Height + 6; // tweak padding as needed
            e.ItemWidth = lb.ClientSize.Width;
        }

        private void PGIDlistBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var lb = (ListBox)sender;
            string text = lb.Items[e.Index]?.ToString() ?? string.Empty;

            // draw background
            var bgColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? SystemColors.Highlight : lb.BackColor;
            using (var bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            // choose color based on status substring (case-insensitive), but respect selection text color
            Color foreColor = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ? SystemColors.HighlightText : lb.ForeColor;
            if (text.IndexOf("[TRAN]", StringComparison.OrdinalIgnoreCase) >= 0) foreColor = ((e.State & DrawItemState.Selected) == 0) ? Color.Red : SystemColors.HighlightText;
            else if (text.IndexOf("[GRAD]", StringComparison.OrdinalIgnoreCase) >= 0) foreColor = ((e.State & DrawItemState.Selected) == 0) ? Color.Green : SystemColors.HighlightText;
            else if (text.IndexOf("[NFL]", StringComparison.OrdinalIgnoreCase) >= 0) foreColor = ((e.State & DrawItemState.Selected) == 0) ? Color.SlateBlue : SystemColors.HighlightText;
            else if (text.IndexOf("[RS]", StringComparison.OrdinalIgnoreCase) >= 0) foreColor = ((e.State & DrawItemState.Selected) == 0) ? Color.DarkRed : SystemColors.HighlightText;
            else if (text.IndexOf("[MED]", StringComparison.OrdinalIgnoreCase) >= 0) foreColor = ((e.State & DrawItemState.Selected) == 0) ? Color.DarkRed : SystemColors.HighlightText;


            // draw text with TextRenderer (consistent with MeasureText)
            var textRect = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, text, lb.Font, textRect, foreColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            // draw focus rectangle if needed
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
            {
                e.DrawFocusRectangle();
            }
        }


    }
}
