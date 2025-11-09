using System;
using System.Collections.Generic;
using System.Drawing;
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

        /* This section is for player randomization features */

        #region Randomizing Appearance Variables

        //Randomize Skin Tones for all players
        private void RandomizeAllSkinTones(string tableName)
        {
            int start = 0;
            int count = 0;
            if (tableName == "RCPT")
            {
                start = 480;
                count = GetTable2RecCount(tableName);
            }
            else
            {
                start = 0;
                count = GetTableRecCount(tableName);
            }

            List<List<int>> skinToneRatios = GetSkinToneRatios();

            StartProgressBar(count);

            for (int i = start; i < count; i++)
            {
                RandomizeSkinTone(tableName, i);
                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("Skin Tones Randomized!");
        }

        //Randomize Skin Tone for a specific player
        private void RandomizeSkinTone(string tableName, int rec)
        {
            List<List<int>> skinToneRatios = GetSkinToneRatios();
            for(int i = 0; i < skinToneRatios.Count; i++)
            {
                skinToneRatios[i].RemoveAt(0);
            }

            int ppos = GetDBValueInt(tableName, "PPOS", rec);
            List<int> positionSkinTones = skinToneRatios[ppos];
            int total = positionSkinTones.Sum();
            int randNum = rand.Next(1, total + 1);
            int cumulative = 0;
            int selectedSkinTone = 0;
            for (int j = 0; j < positionSkinTones.Count; j++)
            {
                cumulative += positionSkinTones[j];
                if (randNum <= cumulative)
                {
                    selectedSkinTone = j;
                    break;
                }
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PSKI", rec, selectedSkinTone);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PSKI", rec, selectedSkinTone);
        }


        //Randomize Player Faces
        private void RandomizeAllPlayerHeads(string tableName)
        {
            StartProgressBar(GetTableRecCount(tableName));

            for (int i = 0; i < GetTableRecCount(tableName); i++)
            {
                RandomizePlayerHead(tableName, i);
                ProgressBarStep();
            }

            EndProgressBar();

            MessageBox.Show("Faces & Skin Tones Randomized!");
        }

        //Randomizes a specific player face based on record, i
        private void RandomizePlayerHead(string tableName, int rec)
        {

            //Randomizes Face Shape (PGFM)
            int shape = rand.Next(0, 16);

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PFGM", rec, shape);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PFGM", rec, shape);


            //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
            int skin = -1;
            if (tableName == "PLAY" || tableName == "RCAT") skin = GetDBValueInt(tableName, "PSKI", rec);
            else skin = GetDB2ValueInt(tableName, "PSKI", rec);

            if (skin <= 2) skin = rand.Next(0, 3);
            else if (skin <= 6) skin = rand.Next(3, 7);
            else skin = 7;

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PSKI", rec, skin);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PSKI", rec, skin);


            //Randomizes Face Type based on new Skin Type
            int face = skin * 8 + rand.Next(0, 8);

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PFMP", rec, face);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PFMP", rec, face);


            //Randomize Hair Color
            int hcl = 0;
            if (skin < 2)
            {
                hcl = rand.Next(1, 101);
                if (hcl <= 55) hcl = 2; //brown
                else if (hcl <= 65) hcl = 0; //black
                else if (hcl <= 80) hcl = 1; //blonde
                else if (hcl <= 95) hcl = 4; //light brown
                else hcl = 3; //red
            }
            else if (skin == 2 || skin == 7)
            {
                hcl = rand.Next(1, 101);
                if (hcl <= 80) hcl = 0;
                else hcl = 4;
            }
            else
            {
                hcl = rand.Next(1, 101);
                if (hcl <= 92) hcl = 0;
                else if (hcl <= 70) hcl = 2;
                else hcl = rand.Next(0, 6);
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PHCL", rec, hcl);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PHCL", rec, hcl);


            //Randomize Hair Style
            int hairstyle = 5;

            if (skin < 3 || skin == 7)
            {

                if (rand.Next(1, 101) <= 50)
                    hairstyle = rand.Next(2, 8);
                else if (rand.Next(1, 101) <= 75)
                    hairstyle = rand.Next(11, 14);
                else hairstyle = 0;

            }
            else
            {
                if (rand.Next(1, 101) <= 50)
                {
                    int hair = rand.Next(1, 5);
                    if (hair == 1) hairstyle = 1;
                    else if (hair == 2) hairstyle = 2;
                    else if (hair == 3) hairstyle = 3;
                    else if (hair == 4) hairstyle = 14;
                }
                else
                {
                    if (rand.Next(1, 101) <= 50)
                        hairstyle = rand.Next(0, 8);
                    else
                        hairstyle = rand.Next(11, 15);
                }
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PHED", rec, hairstyle);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PHED", rec, hairstyle);

            //Randomize Eye Black
            if (Next26Mod || NextMod)
            {
                int eyeblack = rand.Next(0, 2);

                if (tableName == "PLAY" || tableName == "RCAT")
                    ChangeDBInt(tableName, "PEYE", rec, eyeblack);
                else if (tableName == "RCPT" || tableName ==  "WKON")
                    ChangeDB2Int(tableName, "PEYE", rec, eyeblack);
            }
            else
            {
                int val = rand.Next(1, 101);
                int eyeblack = 0;
                if (val <= 40) eyeblack = 1;

                if (tableName == "PLAY" || tableName == "RCAT")
                    ChangeDBInt(tableName, "PEYE", rec, eyeblack);
                else if (tableName == "RCPT" || tableName ==  "WKON")
                    ChangeDB2Int(tableName, "PEYE", rec, eyeblack);
            }


            //Randomize Nasal Strip
            if (Next26Mod || NextMod)
            {
                int nasal = rand.Next(0, 2);

                if (tableName == "PLAY" || tableName == "RCAT")
                    ChangeDBInt(tableName, "PBRE", rec, nasal);
                else if (tableName == "RCPT" || tableName ==  "WKON")
                    ChangeDB2Int(tableName, "PBRE", rec, nasal);
            }
            else
            {
                int val = rand.Next(1, 101);
                int nasal = 0;
                if (val <= 15) nasal = 1;

                if (tableName == "PLAY" || tableName == "RCAT")
                    ChangeDBInt(tableName, "PBRE", rec, nasal);
                else if (tableName == "RCPT" || tableName ==  "WKON")
                    ChangeDB2Int(tableName, "PBRE", rec, nasal);
            }

        }

        #endregion


        #region Randomizing Gear

        //Randomize Gears for all players
        private void RandomizeAllPlayerGears(string tableName)
        {
            int start = 0;
            int count = 0;
            if (tableName == "RCPT")
            {
                start = 480;
                count = GetTable2RecCount(tableName);
            }
            else
            {
                start = 0;
                count = GetTableRecCount(tableName);
            }

            StartProgressBar(count);

            for (int i = start; i < count; i++)
            {
                RandomizePlayerGear(tableName, i);
                ProgressBarStep();
            }

            EndProgressBar();

        }

        //Randomize Individual Player's Gear
        private void RandomizePlayerGear(string tableName, int rec)
        {
            RandomizeHelmet(tableName, rec);
            RandomizeFacemask(tableName, rec);
            RandomizeNeckpad(tableName, rec);
            RandomizeMouthguard(tableName, rec);
            RandomizeVisor(tableName, rec);
            RandomizeSleeves(tableName, rec);
            RandomizeWristGear(tableName, rec);
            RandomizeElbowGear(tableName, rec);
            RandomizeHands(tableName, rec);
            RandomizeShoe(tableName, rec);
        }


        //Randomize Helmets
        private void RandomizeHelmet(string tableName, int rec)
        {
            int val = rand.Next(1, 101);
            int helmet = 0;

            if (val <= 55)
            {
                helmet = 0; //Normal
            }
            else if (val <= 75)
            {
                helmet = 1; //Adams
            }
            else if (val <= 100)
            {
                helmet = 2; //Schutt
            }
            else
            {
                helmet = 3; //Revolution
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "HELM", rec, helmet);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "HELM", rec, helmet);
        }

        //Facemask Types
        private void RandomizeFacemask(string tableName, int rec)
        {
            int pos = -1;
            if (tableName == "PLAY" || tableName == "RCAT")
                pos = GetDBValueInt(tableName, "PPOS", rec);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                pos = GetDB2ValueInt(tableName, "PPOS", rec);

            int val = rand.Next(1, 101);
            int facemask = 0;

            //QBs
            if (pos == 0)
            {
                if (val <= 30)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 45)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 45)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 45)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 75)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 75)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 90)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 90)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //HBs
            else if (pos == 1)
            {
                if (val <= 10)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 20)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 20)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 20)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 40)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 40)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 70)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 70)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //FBs & TEs
            else if (pos == 2 || pos == 4)
            {
                if (val <= 10)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 15)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 15)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 25)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 50)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 50)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 80)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 90)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //WRs & CBs
            else if (pos == 3 || pos == 16)
            {
                if (val <= 35)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 45)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 45)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 45)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 80)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 80)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 95)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 95)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //OLs & DT
            else if (pos >= 5 && pos <= 9 || pos == 11)
            {
                if (val <= 0)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 0)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 3)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 27)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 42)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 42)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 57)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 81)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //DEs & LBs
            else if (pos >= 12 && pos <= 15 || pos == 10)
            {
                if (val <= 0)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 0)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 0)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 20)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 40)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 40)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 60)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 80)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //Safeties
            else if (pos >= 17 && pos <= 18)
            {
                if (val <= 20)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 25)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 25)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 25)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 60)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 60)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 85)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 85)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }
            //Kickers/Punters
            else
            {
                if (val <= 40)
                {
                    facemask = 1; //2-Bar
                }
                else if (val <= 80)
                {
                    facemask = 2; //3-Bar
                }
                else if (val <= 80)
                {
                    facemask = 3; //Half-Cage
                }
                else if (val <= 80)
                {
                    facemask = 4; //Full-Cage 1
                }
                else if (val <= 100)
                {
                    facemask = 7; //2-Bar RB
                }
                else if (val <= 100)
                {
                    facemask = 8; //3-Bar QB
                }
                else if (val <= 100)
                {
                    facemask = 9; //3-Bar RB 1
                }
                else if (val <= 100)
                {
                    facemask = 10; //Full-Cage 2
                }
                else
                {
                    facemask = 11; //3-Bar RB 2
                }
            }


            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PFMK", rec, facemask);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PFMK", rec, facemask);
        }


        //Randomize Neckpads
        private void RandomizeNeckpad(string tableName, int rec)
        {
            int pos = -1;
            if (tableName == "PLAY" || tableName == "RCAT")
                pos = GetDBValueInt(tableName, "PPOS", rec);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                pos = GetDB2ValueInt(tableName, "PPOS", rec);

            int val = rand.Next(1, 101);
            int neckpad = 0;

            //QBs, HBs, WRs, TE, CBs, Safeties, Kickers & punters
            if (pos <= 4 || pos >= 16)
            {
                if (val <= 100)
                {
                    neckpad = 0; //None
                }
                else if (val <= 100)
                {
                    neckpad = 1; //Neck Roll
                }
                else
                {
                    neckpad = 2; //Extended
                }
            }
            //OLs, DTs
            else if (pos >= 5 && pos <= 9 || pos == 11)
            {
                if (val <= 75)
                {
                    neckpad = 0; //None
                }
                else if (val <= 100)
                {
                    neckpad = 1; //Neck Roll
                }
                else
                {
                    neckpad = 2; //Extended
                }

            }
            //DEs and LBs
            else
            {
                if (val <= 80)
                {
                    neckpad = 0; //None
                }
                else if (val <= 90)
                {
                    neckpad = 1; //Neck Roll
                }
                else
                {
                    neckpad = 2; //Extended
                }
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PNEK", rec, neckpad);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PNEK", rec, neckpad);
        }


        //Visors
        private void RandomizeVisor(string tableName, int rec)
        {
            int pos = -1;
            if (tableName == "PLAY" || tableName == "RCAT")
                pos = GetDBValueInt(tableName, "PPOS", rec);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                pos = GetDB2ValueInt(tableName, "PPOS", rec);

            int val = rand.Next(1, 101);
            int visor = 0;

            //HBs, LBs, Safeties
            if (pos == 1 || pos >= 13 && pos <= 15 || pos >= 17 && pos <= 18)
            {
                if (val <= 60)
                {
                    visor = 0; //None
                }
                else if (val <= 100)
                {
                    visor = 1; //Clear
                }
                else if (val <= 100)
                {
                    visor = 2; //Dark
                }
                else
                {
                    visor = 3; //Orange
                }
            }
            else
            {
                if (val <= 80)
                {
                    visor = 0; //None
                }
                else if (val <= 100)
                {
                    visor = 1; //Clear
                }
                else if (val <= 100)
                {
                    visor = 2; //Dark
                }
                else
                {
                    visor = 3; //Orange
                }
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PVIS", rec, visor);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PVIS", rec, visor);
        }


        //Mouthguards
        private void RandomizeMouthguard(string tableName, int rec)
        {
            int val = rand.Next(1, 101);
            int mouthguard = 0;
            if (val <= 50)
            {
                mouthguard = 0; //No
            }
            else
            {
                mouthguard = 1; //Yes
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PLMG", rec, mouthguard);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PLMG", rec, mouthguard);
        }


        //Randomize Sleeves/Tattoos + Long Sleeves Frequency
        private void RandomizeSleeves(string tableName, int rec)
        {
            //Sleeve Frequency
            int val = rand.Next(1, 101);
            int sleeves = 0;

            if (val <= 60)
            {
                sleeves = 0; //Cold Only
            }
            else if (val <= 90)
            {
                sleeves = 1; //Always
            }
            else
            {
                sleeves = 2; //Never
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PSLO", rec, sleeves);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PSLO", rec, sleeves);

            //Sleeve Colors
            val = rand.Next(1, 101);
            sleeves = 0;

            if (val <= 33)
            {
                sleeves = 0; //Black
            }
            else if (val <= 66)
            {
                sleeves = 1; //White
            }
            else
            {
                sleeves = 2; //Team Color
            }

            if (tableName == "PLAY" || tableName == "RCAT")
                ChangeDBInt(tableName, "PSLT", rec, sleeves);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                ChangeDB2Int(tableName, "PSLT", rec, sleeves);
        }


        //Wrist Gears & Player Hand (PHAN)
        private void RandomizeWristGear(string tableName, int rec)
        {
            int armpadRatio = 10;
            int pos = -1;
            int hand = 0;
            if (tableName == "PLAY" || tableName == "RCAT")
            {
                pos = GetDBValueInt(tableName, "PPOS", rec);
                hand = GetDBValueInt(tableName, "PHAN", rec);
            }
            else if (tableName == "RCPT" || tableName ==  "WKON")
            {
                pos = GetDB2ValueInt(tableName, "PPOS", rec);
                hand = GetDB2ValueInt(tableName, "PHAN", rec);
            }


            int val = rand.Next(1, 101);
            int armpadRand = rand.Next(1, 101);
            int randHand = rand.Next(0, 2);
            int wristLeft = 0;
            int wristRight = 0;

            //Initial Choice
            #region Initial Wrist Choice
            //QB only
            if (pos == 0)
            {
                if (val <= 30) //NORMAL
                {
                    wristLeft = 0;
                    wristRight = 0;
                }
                else if (val <= 70) //QB WRIST
                {
                    int color = rand.Next(1, 4);
                    if (hand == 0)
                    {
                        wristLeft = color;
                        wristRight = 0;
                    }
                    else
                    {
                        wristLeft = 0;
                        wristRight = color;
                    }
                }
                else if (val <= 85) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 4;
                        wristRight = 4;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 5;
                        wristRight = 5;
                    }
                    else
                    {
                        wristLeft = 6;
                        wristRight = 6;
                    }
                }
                else //Half-Sleeve
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 8;
                        wristRight = 8;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 9;
                        wristRight = 9;
                    }
                    else
                    {
                        wristLeft = 10;
                        wristRight = 10;
                    }
                }
            }
            //Kickers & Punters
            else if (pos >= 19)
            {
                if (val <= 60) //NORMAL
                {
                    wristLeft = 0;
                    wristRight = 0;
                }
                else if (val <= 85) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 4;
                        wristRight = 4;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 5;
                        wristRight = 5;
                    }
                    else
                    {
                        wristLeft = 6;
                        wristRight = 6;
                    }
                }
                else //Half-Sleeve
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 8;
                        wristRight = 8;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 9;
                        wristRight = 9;
                    }
                    else
                    {
                        wristLeft = 10;
                        wristRight = 10;
                    }
                }
            }
            //RBs, WRs & Defense
            else if (pos <= 3 || pos >= 10)
            {
                if (val <= 25) //NORMAL
                {
                    wristLeft = 0;
                    wristRight = 0;
                }
                else if (val <= 70) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 4;
                        wristRight = 4;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 5;
                        wristRight = 5;
                    }
                    else
                    {
                        wristLeft = 6;
                        wristRight = 6;
                    }
                }
                else //Half-Sleeve
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 8;
                        wristRight = 8;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 9;
                        wristRight = 9;
                    }
                    else
                    {
                        wristLeft = 10;
                        wristRight = 10;
                    }
                }
            }
            //TEs & OL
            else
            {
                if (val <= 38) //NORMAL
                {
                    wristLeft = 0;
                    wristRight = 0;
                }
                else if (val <= 95) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 4;
                        wristRight = 4;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 5;
                        wristRight = 5;
                    }
                    else
                    {
                        wristLeft = 6;
                        wristRight = 6;
                    }
                }
                else //Half-Sleeve
                {
                    int color = rand.Next(1, 101);
                    if (color <= 15)
                    {
                        wristLeft = 8;
                        wristRight = 8;
                    }
                    else if (color <= 30)
                    {
                        wristLeft = 9;
                        wristRight = 9;
                    }
                    else
                    {
                        wristLeft = 10;
                        wristRight = 10;
                    }
                }
            }

            #endregion

            //Asymmetrical Wrist Gear Calculations
            #region Assymetry Wrist Selection
            randHand = rand.Next(0, 2);
            armpadRand = rand.Next(1, 101);

            //QBs
            if (pos == 0)
            {
                val = rand.Next(1, 101);

                if (val <= 55) //NORMAL
                {
                    if (hand == 0)
                    {
                        wristRight = 0;
                    }
                    else
                    {
                        wristLeft = 0;
                    }
                    //Add Arm Pad (used for single-sided tattoo in NEXT Mod)
                    if (armpadRatio <= armpadRand)
                    {
                        if (hand == 0)
                        {
                            wristRight = 7;
                        }
                        else
                        {
                            wristLeft = 7;
                        }
                    }
                }
                else if (val <= 85) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 10)
                    {
                        if (hand == 0)
                        {
                            wristRight = 4;
                        }
                        else
                        {
                            wristLeft = 4;
                        }
                    }
                    else if (color <= 20)
                    {
                        if (hand == 0)
                        {
                            wristRight = 5;
                        }
                        else
                        {
                            wristLeft = 5;
                        }
                    }
                    else
                    {
                        if (hand == 0)
                        {
                            wristRight = 6;
                        }
                        else
                        {
                            wristLeft = 6;
                        }
                    }
                }
                //Half-Sleeve
                else if (wristLeft >= 8)
                {
                    int color = rand.Next(1, 101);
                    if (color <= 10)
                    {
                        if (hand == 0)
                        {
                            wristRight = 8;
                        }
                        else
                        {
                            wristLeft = 8;
                        }
                    }
                    else if (color <= 20)
                    {
                        if (hand == 0)
                        {
                            wristRight = 9;
                        }
                        else
                        {
                            wristLeft = 9;
                        }
                    }
                    else
                    {
                        if (hand == 0)
                        {
                            wristRight = 10;
                        }
                        else
                        {
                            wristLeft = 10;
                        }
                    }
                }
            }
            //Half-Sleeve Wrists Assymetry
            else /*if (wristLeft >= 8)*/
            {
                val = rand.Next(1, 101);
                if (val <= 25) //NORMAL
                {
                    if (randHand == 0)
                    {
                        wristRight = 0;
                    }
                    else
                    {
                        wristLeft = 0;
                    }

                    //Add Arm Pad (used for single-sided tattoo in NEXT Mod)
                    if (armpadRatio <= armpadRand)
                    {
                        if (randHand == 0)
                        {
                            wristRight = 7;
                        }
                        else
                        {
                            wristLeft = 7;
                        }
                    }
                }
                else if (val <= 75) //WRIST PAD
                {
                    int color = rand.Next(1, 101);
                    if (color <= 10)
                    {
                        if (randHand == 0)
                        {
                            wristRight = 4;
                        }
                        else
                        {
                            wristLeft = 4;
                        }
                    }
                    else if (color <= 20)
                    {
                        if (randHand == 0)
                        {
                            wristRight = 5;
                        }
                        else
                        {
                            wristLeft = 5;
                        }
                    }
                    else
                    {
                        if (randHand == 0)
                        {
                            wristRight = 6;
                        }
                        else
                        {
                            wristLeft = 6;
                        }
                    }
                }
                else //Half-Sleeve
                {
                    int color = rand.Next(1, 101);
                    if (color <= 10)
                    {
                        if (randHand == 0)
                        {
                            wristRight = 8;
                        }
                        else
                        {
                            wristLeft = 8;
                        }
                    }
                    else if (color <= 20)
                    {
                        if (randHand == 0)
                        {
                            wristRight = 9;
                        }
                        else
                        {
                            wristLeft = 9;
                        }
                    }
                    else
                    {
                        if (randHand == 0)
                        {
                            wristRight = 10;
                        }
                        else
                        {
                            wristLeft = 10;
                        }
                    }


                    //OVERRIDE - Matching Sleeve Colors
                    if (wristLeft >= 8 && wristRight >= 8)
                    {
                        if (randHand <= 50)
                        {
                            wristRight = wristLeft;
                        }
                        else
                        {
                            wristLeft = wristRight;
                        }
                    }
                    
                }
            }


            #endregion

            if (tableName == "PLAY" || tableName == "RCAT")
            {
                ChangeDBInt(tableName, "PLWS", rec, wristLeft);
                ChangeDBInt(tableName, "PRWS", rec, wristRight);
            }
            else if (tableName == "RCPT" || tableName == "WKON")
            {
                ChangeDB2Int(tableName, "PLWS", rec, wristLeft);
                ChangeDB2Int(tableName, "PRWS", rec, wristRight);
            }
        }

        //Elbow Gears
        private void RandomizeElbowGear(string tableName, int rec)
        {
            int val = rand.Next(1, 101);
            int elbowLeft = 0;
            int elbowRight = 0;

            int wristLeft = GetDBValueInt(tableName, "PLWS", rec);
            int wristRight = GetDBValueInt(tableName, "PRWS", rec);

            //Determine if Shooter Sleeves are needed (Half-Sleeve must be enabled)
            if (wristLeft >= 8 || wristRight >= 8)
            {
                if (wristLeft == 8) //White Half-Sleeve
                {
                    elbowLeft = 7;
                }
                else if (wristLeft == 9) //Black Half-Sleeve
                {
                    elbowLeft = 6;
                }
                else if (wristLeft == 10) //Team Color Half-Sleeve
                {
                    elbowLeft = 8;
                }

                if (wristRight == 8)
                {
                    elbowRight = 7;
                }
                else if (wristRight == 9)
                {
                    elbowRight = 6;
                }
                else if (wristRight == 10)
                {
                    elbowRight = 8;
                }
            }
            else
            {
                if (val <= 65)
                {
                    elbowLeft = 0;
                    elbowRight = 0;

                    if (val <= 20) elbowRight = 11;
                    else if (val <= 30) elbowRight = 10;
                }
                else if (val <= 90)
                {
                    elbowLeft = 10;
                    elbowRight = 10;
                    if (val <= 70) elbowRight = 0;
                }
                else
                {
                    elbowLeft = 11;
                    elbowRight = 11;
                    if (val <= 95) elbowRight = 0;
                }
            }


            if (tableName == "PLAY" || tableName == "RCAT")
            {
                ChangeDBInt(tableName, "PLEB", rec, elbowLeft);
                ChangeDBInt(tableName, "PREB", rec, elbowRight);
            }
            else if (tableName == "RCPT" || tableName ==  "WKON")
            {
                ChangeDB2Int(tableName, "PLEB", rec, elbowLeft);
                ChangeDB2Int(tableName, "PREB", rec, elbowRight);
            }


        }


        //Hand vs Gloves (PRHN PLHN)
        private void RandomizeHands(string tableName, int rec)
        {
            int pos = -1;
            if (tableName == "PLAY" || tableName == "RCAT")
                pos = GetDBValueInt(tableName, "PPOS", rec);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                pos = GetDB2ValueInt(tableName, "PPOS", rec);

            int val = rand.Next(1, 101);
            int hands = 0;

            if (pos == 0 || pos >= 19)
            {
                if (val <= 100)
                {
                    hands = 0; //None
                }
                else if (val <= 100)
                {
                    hands = 1; //Taped Fingers
                }
                else
                {
                    hands = 2; //Gloves
                }
            }
            else
            {
                if (val <= 10)
                {
                    hands = 0; //None
                }
                else if (val <= 20)
                {
                    hands = 1; //Taped Fingers
                }
                else
                {
                    hands = 2; //Gloves
                }
            }

            if (tableName == "PLAY" || tableName == "RCAT")
            {
                ChangeDBInt(tableName, "PLHN", rec, hands);
                ChangeDBInt(tableName, "PRHN", rec, hands);
            }

            else if (tableName == "RCPT" || tableName ==  "WKON")
            {
                ChangeDB2Int(tableName, "PLHN", rec, hands);
                ChangeDB2Int(tableName, "PRHN", rec, hands);
            }
        }

        //Shoes
        private void RandomizeShoe(string tableName, int rec)
        {
            int pos = -1;
            if (tableName == "PLAY" || tableName == "RCAT")
                pos = GetDBValueInt(tableName, "PPOS", rec);
            else if (tableName == "RCPT" || tableName ==  "WKON")
                pos = GetDB2ValueInt(tableName, "PPOS", rec);


            int val = rand.Next(1, 101);
            int shoe = 0;

            //QBs, HBs, WRs, CBs, Safeties
            if (pos <= 1 || pos == 3 || pos >= 16 && pos <= 18)
            {
                if (val <= 60)
                {
                    shoe = 0; //Normal
                }
                else if (val <= 75)
                {
                    shoe = 1; //White Tape
                }
                else if (val <= 90)
                {
                    shoe = 2; //Black Tape
                }
                else
                {
                    shoe = 3; //Team Color Tape
                }
            }
            else if (pos == 2 || pos == 4 || pos == 10 || pos >= 12 && pos <= 15)
            {
                if (val <= 50)
                {
                    shoe = 0; //Normal
                }
                else if (val <= 80)
                {
                    shoe = 1; //White Tape
                }
                else if (val <= 90)
                {
                    shoe = 2; //Black Tape
                }
                else
                {
                    shoe = 3; //Team Color Tape
                }
            }
            //OL + DT
            else if (pos == 11 || pos >= 5 && pos <= 9)
            {
                if (val <= 50)
                {
                    shoe = 0; //Normal
                }
                else if (val <= 80)
                {
                    shoe = 1; //White Tape
                }
                else if (val <= 90)
                {
                    shoe = 2; //Black Tape
                }
                else
                {
                    shoe = 3; //Team Color Tape
                }
            }
            //kickers & punters
            else
            {
                if (val <= 100)
                {
                    shoe = 0; //Normal
                }
                else if (val <= 100)
                {
                    shoe = 1; //White Tape
                }
                else if (val <= 100)
                {
                    shoe = 2; //Black Tape
                }
                else
                {
                    shoe = 3; //Team Color Tape
                }
            }



            if (tableName == "PLAY" || tableName == "RCAT")
            {
                ChangeDBInt(tableName, "PLSH", rec, shoe);
                ChangeDBInt(tableName, "PRSH", rec, shoe);
            }
            else if (tableName == "RCPT" || tableName ==  "WKON")
            {
                ChangeDB2Int(tableName, "PLSH", rec, shoe);
                ChangeDB2Int(tableName, "PRSH", rec, shoe);
            }
        }

        #endregion


        #region Ratios

        //Skin-Tone Ratios
        private List<List<int>> GetSkinToneRatios()
        {
            List<List<int>> skinToneRatios = new List<List<int>>();

            skinToneRatios = CreateIntListsFromCSV(@"Resources\players\skintones.csv", true);

            return skinToneRatios;
        }


        #endregion

    }

}
