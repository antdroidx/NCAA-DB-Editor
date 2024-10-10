﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace DB_EDITOR
{
    public partial class MainEditor : Form
    {


        /*
         * CREATING NCAA SPECIFIC CONVERSION TABLES AND ACTIONS
         */


        #region Player Names


        public void CloneNameConversionTable(int tmpDBindex, string tmpTName, string tmpFName)
        {

            Alphabet.Clear();
            AlphabetX.Clear();

            int tmpRecCount = TDB.TableRecordCount(tmpDBindex, tmpTName);


            for (int r = 0; r < tmpRecCount; r++)
            {

                // check if record is deleted, if so, skip
                if (TDB.TDBTableRecordDeleted(tmpDBindex, tmpTName, r))
                    continue;

                string PNCH = TDB.FieldValue(tmpDBindex, tmpTName, "PNCH", r);
                int PNNU = Convert.ToInt32(TDB.FieldValue(tmpDBindex, tmpTName, tmpFName, r));

                Alphabet.Add(PNNU, PNCH);
                AlphabetX.Add(PNCH, PNNU);

            }

        }

        public void CreateNameConversionTable()
        {
            Alphabet.Clear();
            AlphabetX.Clear();

            AlphabetX.Add("", 0);
            AlphabetX.Add("a", 1);
            AlphabetX.Add("b", 2);
            AlphabetX.Add("c", 3);
            AlphabetX.Add("d", 4);
            AlphabetX.Add("e", 5);
            AlphabetX.Add("f", 6);
            AlphabetX.Add("g", 7);
            AlphabetX.Add("h", 8);
            AlphabetX.Add("i", 9);
            AlphabetX.Add("j", 10);
            AlphabetX.Add("k", 11);
            AlphabetX.Add("l", 12);
            AlphabetX.Add("m", 13);
            AlphabetX.Add("n", 14);
            AlphabetX.Add("o", 15);
            AlphabetX.Add("p", 16);
            AlphabetX.Add("q", 17);
            AlphabetX.Add("r", 18);
            AlphabetX.Add("s", 19);
            AlphabetX.Add("t", 20);
            AlphabetX.Add("u", 21);
            AlphabetX.Add("v", 22);
            AlphabetX.Add("w", 23);
            AlphabetX.Add("x", 24);
            AlphabetX.Add("y", 25);
            AlphabetX.Add("z", 26);
            AlphabetX.Add("A", 27);
            AlphabetX.Add("B", 28);
            AlphabetX.Add("C", 29);
            AlphabetX.Add("D", 30);
            AlphabetX.Add("E", 31);
            AlphabetX.Add("F", 32);
            AlphabetX.Add("G", 33);
            AlphabetX.Add("H", 34);
            AlphabetX.Add("I", 35);
            AlphabetX.Add("J", 36);
            AlphabetX.Add("K", 37);
            AlphabetX.Add("L", 38);
            AlphabetX.Add("M", 39);
            AlphabetX.Add("N", 40);
            AlphabetX.Add("O", 41);
            AlphabetX.Add("P", 42);
            AlphabetX.Add("Q", 43);
            AlphabetX.Add("R", 44);
            AlphabetX.Add("S", 45);
            AlphabetX.Add("T", 46);
            AlphabetX.Add("U", 47);
            AlphabetX.Add("V", 48);
            AlphabetX.Add("W", 49);
            AlphabetX.Add("X", 50);
            AlphabetX.Add("Y", 51);
            AlphabetX.Add("Z", 52);
            AlphabetX.Add("-", 53);
            AlphabetX.Add("'", 54);
            AlphabetX.Add(".", 55);
            AlphabetX.Add(" ", 56);
            AlphabetX.Add("@", 57);
            AlphabetX.Add("±", 58);

            foreach (KeyValuePair<string, int> CHAR in AlphabetX)
            {
                Alphabet.Add(CHAR.Value, CHAR.Key);
            }


        }

        public string GetFirstNameFromRecord(int tmpRecNo)
        {

            string tmpSTR = "";
            string xPFNA = "";

            for (int PF = 1; PF <= maxNameChar; PF++)
            {
                if (Alphabet[Convert.ToInt32(GetDBValue("PLAY", "PF" + AddLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPFNA = xPFNA + Alphabet[Convert.ToInt32(GetDBValue("PLAY", "PF" + AddLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))];

            }
            tmpSTR = xPFNA;
            return tmpSTR;
        }
        public string GetLastNameFromRecord(int tmpRecNo)
        {
            string tmpSTR = "";
            string xPLNA = "";

            for (int PL = 1; PL <= maxNameChar; PL++)
            {
                if (Alphabet[Convert.ToInt32(GetDBValue("PLAY", "PL" + AddLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPLNA = xPLNA + Alphabet[Convert.ToInt32(GetDBValue("PLAY", "PL" + AddLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))];

            }
            tmpSTR = xPLNA;
            return tmpSTR;
        }

        public void ConvertFirstNameStringToInt(string PFNA, int tmpRecNo, string tableName)
        {
            for (int i = 1; i <= maxNameChar; i++)
            {
                int tmpSTR = 0;

                if (i <= PFNA.Length)
                    tmpSTR = AlphabetX[PFNA.Substring(i - 1, 1)];

                // MessageBox.Show(tmpSTR.ToString());
                TDB.NewfieldValue(dbIndex,
                                  tableName,
                                  "PF" + AddLeadingZeros(Convert.ToString(i), 2),
                                  tmpRecNo,
                                  Convert.ToString(tmpSTR));

            }
        }
        public void ConvertLastNameStringToInt(string PLNA, int tmpRecNo, string tableName)
        {
            for (int i = 1; i <= maxNameChar; i++)
            {
                int tmpSTR = 0;

                if (i <= PLNA.Length)
                    tmpSTR = AlphabetX[PLNA.Substring(i - 1, 1)];

                TDB.NewfieldValue(dbIndex,
                                  tableName,
                                  "PL" + AddLeadingZeros(Convert.ToString(i), 2),
                                  tmpRecNo,
                                  Convert.ToString(tmpSTR));


            }
        }

        public string AddLeadingZeros(string tmpSTR, int tmpLen)
        {
            for (int i = 1; i < tmpLen; i++)
                tmpSTR = "0" + tmpSTR;

            if (tmpSTR.Length > tmpLen)
                tmpSTR = tmpSTR.Substring(tmpSTR.Length - tmpLen, tmpLen);

            return tmpSTR;
        }

        #endregion

        #region Players

        public int GetPGIDfromRecord(int i)
        {
            return Convert.ToInt32(GetDBValue("PLAY", "PGID", i));

        }

        public int GetPPOSfromRecord(int i)
        {
            return Convert.ToInt32(GetDBValue("PLAY", "PPOS", i));

        }

        public int GetPOVRfromRecord(int i)
        {
            return Convert.ToInt32(GetDBValue("PLAY", "POVR", i));

        }

        public int GetPTYPfromRecord(int i)
        {
            return Convert.ToInt32(GetDBValue("PLAY", "PTYP", i));

        }

        public int GetPYERfromRecord(int i)
        {
            return Convert.ToInt32(GetDBValue("PLAY", "PYER", i));

        }

        public void CreateRCATtable()
        {
            RCAT = new List<List<int>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\RCAT.csv");
            if (NCAANext25Config.Checked) csvLocation = Path.Combine(executableLocation, @"resources\RCAT-NEXT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    //skip header
                }
                else
                {
                    RCAT.Add(new List<int>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        RCAT[Row - 1].Add(Convert.ToInt32(Line[column]));
                    }
                }

                Row++;
            }
            sr.Close();
        }

        public void CreateFirstNamesDB()
        {
            FirstNames = new List<string>();

            FirstNames = CreateStringListfromCSV(@"resources\players\RCFN.csv", true);
        }

        public void CreateLastNamesDB()
        {
            LastNames = new List<string>();
            LastNames = CreateStringListfromCSV(@"resources\players\RCLN.csv", true);
        }

        public List<List<int>> CreateJerseyNumberDB()
        {
            List<List<int>> PJEN = new List<List<int>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\players\PJEN.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    //skip header
                }
                else
                {
                    for (int column = 0; column < Line.Length; column++)
                    {
                        if (column != 1)
                        {
                            PJEN.Add(new List<int>());
                            PJEN[Row - 1].Add(Convert.ToInt32(Line[column]));
                        }

                    }
                }

                Row++;
            }
            sr.Close();

            return PJEN;
        }

        public string GetPlayerNamefromPGID(int pgid)
        {
            string playername = "";

            int rec = FindPGIDRecord(pgid);

            String FN = GetFirstNameFromRecord(rec);
            String LN = GetLastNameFromRecord(rec);

            playername = FN + " " + LN;

            return playername;
        }

        public int FindPGIDRecord(int PGID)
        {
            int rec = -1;
            for (int i = 0; i < GetTableRecCount("PLAY"); i++)
            {
                if (GetDBValueInt("PLAY", "PGID", i) == PGID) return i;
            }
            return rec;
        }

        public List<string> CreateRedshirtStatus()
        {
            List<string> status = new List<string>();

            status.Add("None");
            status.Add("Current");
            status.Add("Redshirted");
            return status;
        }

        public List<string> CreateClassYears()
        {
            List<string> status = new List<string>();

            status.Add("Freshman");
            status.Add("Sophomore");
            status.Add("Junior");
            status.Add("Senior");
            return status;
        }

        public List<string> CreateOffSeasonPTYP()
        {
            List<string> status = new List<string>();

            status.Add("None");
            status.Add("Transferring");
            status.Add("Created Player (Do not use!)"); //Do not use
            status.Add("Graduating / Going Pro");
            return status;
        }
        public List<string> CreateSkinColorDB()
        {
            List<string> skinColors = new List<string>();

            skinColors.Add("Light - 0");
            skinColors.Add("Light - 1");
            skinColors.Add("Medium - 2");
            skinColors.Add("Dark - 3");
            skinColors.Add("Dark - 4");
            skinColors.Add("Dark - 5");
            skinColors.Add("Dark - 6");
            skinColors.Add("Light - 7");
            return skinColors;
        }

        public List<string> CreatePHCL()
        {
            List<string> colors = new List<string>();

            colors.Add("Black");
            colors.Add("Blonde");
            colors.Add("Brown");
            colors.Add("Red");
            colors.Add("Light Brown");
            colors.Add("Grey");
            return colors;
        }

        public List<string> CreateHair()
        {
            List<string> hair = new List<string>();

            hair.Add("Bald");
            hair.Add("Corn Rows");
            hair.Add("Afro");
            hair.Add("Flat Top");
            hair.Add("Buzzcut");
            hair.Add("Fade");
            hair.Add("Balding");
            hair.Add("Close Crop");
            hair.Add("Bald (Hidden)");
            hair.Add("Bald 2");
            hair.Add("Balding 2");
            hair.Add("Buzzcut 2");
            hair.Add("Fade 2");
            hair.Add("Mullet");
            hair.Add("Dreadlocks");
            return hair;
        }

        #endregion

        #region Positions

        public void SetPositions()
        {
            Positions.Clear();
            PositionsX.Clear();

            Positions.Add(0, "QB");
            Positions.Add(1, "HB");
            Positions.Add(2, "FB");
            Positions.Add(3, "WR");
            Positions.Add(4, "TE");
            Positions.Add(5, "LT");
            Positions.Add(6, "LG");
            Positions.Add(7, "OC");
            Positions.Add(8, "RG");
            Positions.Add(9, "RT");
            Positions.Add(10, "LE");
            Positions.Add(11, "RE");
            Positions.Add(12, "DT");
            Positions.Add(13, "LOLB");
            Positions.Add(14, "MLB");
            Positions.Add(15, "ROLB");
            Positions.Add(16, "CB");
            Positions.Add(17, "FS");
            Positions.Add(18, "SS");
            Positions.Add(19, "K");
            Positions.Add(20, "P");

            foreach (KeyValuePair<int, string> CHAR in Positions)
            {
                PositionsX.Add(CHAR.Value, CHAR.Key);
            }
        }

        public string GetPositionName(int ppos)
        {

            string tmpSTR = Positions[ppos];
            return tmpSTR;
        }

        public int ChooseRandomPosFromPOSG(int posg)
        {
            int ppos = posg;

            if (posg == 4) ppos = rand.Next(5, 10);
            else if (posg == 5) ppos = rand.Next(10, 13);
            else if (posg == 6) ppos = rand.Next(13, 16);
            else if (posg == 7) ppos = rand.Next(16, 19);
            else if (posg == 8) ppos = 19;
            else if (posg == 9) ppos = 20;
            else if (posg >= 10) ppos = 7;
            return ppos;
        }

        public int GetPOSGfromPPOS(int ppos)
        {
            int posg = -1;
            if (ppos == 0) posg = 0;
            else if (ppos == 1) posg = 1;
            else if (ppos == 2) posg = 1;
            else if (ppos == 3) posg = 2;
            else if (ppos == 4) posg = 3;
            else if (ppos <= 9) posg = 4;
            else if (ppos <= 12) posg = 5;
            else if (ppos <= 15) posg = 6;
            else if (ppos <= 18) posg = 7;
            else if (ppos == 19) posg = 8;
            else if (ppos == 20) posg = 9;

            return posg;
        }

        public string GetPOSGName(int posg)
        {
            if (posg == 0) return "QB";
            else if (posg == 1) return "RB";
            else if (posg == 2) return "WR";
            else if (posg == 3) return "TE";
            else if (posg == 4) return "OL";
            else if (posg == 5) return "DL";
            else if (posg == 6) return "LB";
            else if (posg == 7) return "DB";
            else if (posg == 8) return "K";
            else if (posg == 9) return "P";

            else return "";
        }

        #endregion

        #region Ratings

        public void CreateRatingsDB()
        {
            Ratings.Clear();
            RatingsX.Clear();
            List<int> ratingsList = new List<int>();

            ratingsList = CreateIntListfromCSV(@"resources\players\PRLU.csv", true);
            for(int i = 0; i  < ratingsList.Count; i++)
            {
                Ratings.Add(i, ratingsList[i]);
            }

            /*
            Ratings.Add(0, 40);
            Ratings.Add(1, 44);
            Ratings.Add(2, 48);
            Ratings.Add(3, 52);
            Ratings.Add(4, 56);
            Ratings.Add(5, 59);
            Ratings.Add(6, 62);
            Ratings.Add(7, 65);
            Ratings.Add(8, 68);
            Ratings.Add(9, 70);
            Ratings.Add(10, 72);
            Ratings.Add(11, 74);
            Ratings.Add(12, 76);
            Ratings.Add(13, 78);
            Ratings.Add(14, 80);
            Ratings.Add(15, 82);
            Ratings.Add(16, 84);
            Ratings.Add(17, 85);
            Ratings.Add(18, 86);
            Ratings.Add(19, 87);
            Ratings.Add(20, 88);
            Ratings.Add(21, 89);
            Ratings.Add(22, 90);
            Ratings.Add(23, 91);
            Ratings.Add(24, 92);
            Ratings.Add(25, 93);
            Ratings.Add(26, 94);
            Ratings.Add(27, 95);
            Ratings.Add(28, 96);
            Ratings.Add(29, 97);
            Ratings.Add(30, 98);
            Ratings.Add(31, 99);
            */
            foreach (KeyValuePair<int, int> CHAR in Ratings)
            {
                RatingsX.Add(CHAR.Value, CHAR.Key);
            }
        }

        public int ConvertRating(int value)
        {
            return Ratings[value];
        }

        public int RevertRating(int value)
        {
            while (!RatingsX.ContainsKey(value))
            {
                value--;
            }
            return RatingsX[value];
        }

        public void CreatePOCItable()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\POCI.csv");

            if (NCAANext25Config.Checked) csvLocation = Path.Combine(executableLocation, @"resources\POCI-NEXT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            double sum = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    POCI = new double[22, Line.Length + 3];
                }
                else
                {
                    for (int column = 0; column < Line.Length; column++)
                    {
                        POCI[Row - 1, column] = Convert.ToDouble(Line[column]);
                    }

                    //Add Average of High/Low Rating
                    POCI[Row - 1, Line.Length] = (POCI[Row - 1, 0] + POCI[Row - 1, 1]) / 2;

                    //Add Sum of Weighed Values
                    sum = 0;

                    for (int j = 3; j < Line.Length; j++)
                    {
                        sum += POCI[Row - 1, j];
                    }
                    POCI[Row - 1, Line.Length + 1] = sum;

                    //Add 99 - (High - Low)
                    POCI[Row - 1, Line.Length + 2] = 100 / (POCI[Row - 1, 0] - POCI[Row - 1, 1]);

                }
                Row++;
            }
            sr.Close();
        }

        public void RecalculateOverallByRec(int rec)
        {
            int ppos = Convert.ToInt32(GetDBValue("PLAY", "PPOS", rec));
            double PCAR = Convert.ToInt32(GetDBValue("PLAY", "PCAR", rec)); //CAWT
            double PKAC = Convert.ToInt32(GetDBValue("PLAY", "PKAC", rec)); //KAWT
            double PTHA = Convert.ToInt32(GetDBValue("PLAY", "PTHA", rec)); //TAWT
            double PPBK = Convert.ToInt32(GetDBValue("PLAY", "PPBK", rec)); //PBWT
            double PRBK = Convert.ToInt32(GetDBValue("PLAY", "PRBK", rec)); //RBWT
            double PACC = Convert.ToInt32(GetDBValue("PLAY", "PACC", rec)); //ACWT
            double PAGI = Convert.ToInt32(GetDBValue("PLAY", "PAGI", rec)); //AGWT
            double PTAK = Convert.ToInt32(GetDBValue("PLAY", "PTAK", rec)); //TKWT
            double PINJ = Convert.ToInt32(GetDBValue("PLAY", "PINJ", rec)); //INWT
            double PKPR = Convert.ToInt32(GetDBValue("PLAY", "PKPR", rec)); //KPWT
            double PSPD = Convert.ToInt32(GetDBValue("PLAY", "PSPD", rec)); //SPWT
            double PTHP = Convert.ToInt32(GetDBValue("PLAY", "PTHP", rec)); //TPWT
            double PBKT = Convert.ToInt32(GetDBValue("PLAY", "PBTK", rec)); //BTWT
            double PCTH = Convert.ToInt32(GetDBValue("PLAY", "PCTH", rec)); //CTWT
            double PSTR = Convert.ToInt32(GetDBValue("PLAY", "PSTR", rec)); //STWT
            double PJMP = Convert.ToInt32(GetDBValue("PLAY", "PJMP", rec)); //JUWT
            double PAWR = Convert.ToInt32(GetDBValue("PLAY", "PAWR", rec)); //AWWT

            double[] ratings = new double[] { PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR };

            for (int i = 0; i < ratings.Length; i++)
            {
                ratings[i] = CalcOVRIndividuals(i + 3, ratings[i], ppos);
            }

            double newRating = 50;

            for (int i = 0; i < ratings.Length; i++)
            {
                newRating += ratings[i];
            }

            int val = Convert.ToInt32(newRating);
            if (val < 40) val = 40;
            val = RevertRating(val);

            ChangeDBString("PLAY", "POVR", rec, Convert.ToString(val));

        }

        public int CalculatePositionRating(int rec, int ppos)
        {
            int posg = GetPOSGfromPPOS(ppos);

            int playerPos = GetDBValueInt("PLAY", "PPOS", rec);
            int playerPOSG = GetPOSGfromPPOS(playerPos);

            double PCAR = Convert.ToInt32(GetDBValue("PLAY", "PCAR", rec)); //CAWT
            double PKAC = Convert.ToInt32(GetDBValue("PLAY", "PKAC", rec)); //KAWT
            double PTHA = Convert.ToInt32(GetDBValue("PLAY", "PTHA", rec)); //TAWT
            double PPBK = Convert.ToInt32(GetDBValue("PLAY", "PPBK", rec)); //PBWT
            double PRBK = Convert.ToInt32(GetDBValue("PLAY", "PRBK", rec)); //RBWT
            double PACC = Convert.ToInt32(GetDBValue("PLAY", "PACC", rec)); //ACWT
            double PAGI = Convert.ToInt32(GetDBValue("PLAY", "PAGI", rec)); //AGWT
            double PTAK = Convert.ToInt32(GetDBValue("PLAY", "PTAK", rec)); //TKWT
            double PINJ = Convert.ToInt32(GetDBValue("PLAY", "PINJ", rec)); //INWT
            double PKPR = Convert.ToInt32(GetDBValue("PLAY", "PKPR", rec)); //KPWT
            double PSPD = Convert.ToInt32(GetDBValue("PLAY", "PSPD", rec)); //SPWT
            double PTHP = Convert.ToInt32(GetDBValue("PLAY", "PTHP", rec)); //TPWT
            double PBKT = Convert.ToInt32(GetDBValue("PLAY", "PBTK", rec)); //BTWT
            double PCTH = Convert.ToInt32(GetDBValue("PLAY", "PCTH", rec)); //CTWT
            double PSTR = Convert.ToInt32(GetDBValue("PLAY", "PSTR", rec)); //STWT
            double PJMP = Convert.ToInt32(GetDBValue("PLAY", "PJMP", rec)); //JUWT
            double PAWR = Convert.ToInt32(GetDBValue("PLAY", "PAWR", rec)); //AWWT

            double[] ratings = new double[] { PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR };

            for (int i = 0; i < ratings.Length; i++)
            {

                ratings[i] = CalcOVRIndividuals(i + 3, ratings[i], ppos);
            }

            double newRating = 50;

            for (int i = 0; i < ratings.Length; i++)
            {
                newRating += ratings[i];
            }

            int val = Convert.ToInt32(newRating);

            if (playerPOSG != posg && posg < 8) val -= 20;

            if (val < 0) val = 0;
            return val;

        }

        public double CalcOVRIndividuals(int row, double val, int ppos)
        {
            double skillRating = (double)ConvertRating(Convert.ToInt32(val));

            //attribute rating - (PLDH + PLDL)/2 * wtPts/total Pts * (99 / (PLDH-PLDL)
            // row 20,   weight/row 21, row 22
            // 

            skillRating = (skillRating - POCI[ppos, 20]) * (POCI[ppos, row] / POCI[ppos, 21]) * POCI[ppos, 22];

            return skillRating;
        }

        #endregion

        #region Coaches

        public int FindRecNumberCCID(int CCID)
        {
            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                if (CCID == Convert.ToInt32(GetDBValue("COCH", "CCID", i)))
                {
                    return i;
                }
            }

            return -1;
        }
        public int FindCOCHRecordfromTeamTGID(int tgid)
        {
            for (int i = 0; i < GetTableRecCount("COCH"); i++)
            {
                if (tgid == GetDBValueInt("COCH", "TGID", i))
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetCoachFirstNamefromRec(int rec)
        {
            return GetDBValue("COCH", "CLFN", rec);
        }

        public string GetCoachLastNamefromRec(int rec)
        {
            return GetDBValue("COCH", "CLLN", rec);
        }

        public List<string> CreateOffTypes()
        {
            List<string> ret = new List<string>() { "Option Run", "Spread", "Balanced", "Flexbone", "West Coast" };

            return ret;
        }

        public List<string> CreateBaseDef()
        {
            List<string> ret = new List<string>() { "3-4", "3-3-5 Stack", "4-2-5", "4-3", "4-4" };

            return ret;
        }

        public string GetOffTypeName(int i)
        {
            List<string> OffTypes = CreateOffTypes();

            return OffTypes[i];

        }

        public string GetDefTypeName(int i)
        {
            List<string> DefTypes = CreateBaseDef();

            return DefTypes[i];

        }

        public List<List<string>> CreatePlaybookNames()
        {
            List<List<string>> pb = CreateStringListsFromCSV(@"resources\playbooks\PlaybookNames.csv", false);

            return pb;
        }

        public string GetPlaybookName(int i)
        {
            List<List<string>> pb = CreatePlaybookNames();
            return pb[i][1];
        }

        public int GetCOCHrecFromTeamRec(int i)
        {
            return FindCOCHRecordfromTeamTGID(GetTeamTGIDfromRecord(i));
        }


        #endregion

        #region Teams

        public void CreateTeamDB()
        {
            if (TEAM)
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    int j = Convert.ToInt32(GetDBValue("TEAM", "TGID", i));

                    teamNameDB[j] = Convert.ToString(GetDBValue("TEAM", "TDNA", i));
                    teamMascot[j] = Convert.ToString(GetDBValue("TEAM", "TMNA", i));
                }
            }
            else
            {

                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string csvLocation = Path.Combine(executableLocation, @"Resources\teams\TeamDB.csv");

                string filePath = csvLocation;
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(',');
                    {
                        teamNameDB[Convert.ToInt32(Line[0])] = Line[1];
                        teamMascot[Convert.ToInt32(Line[0])] = Line[2];
                    }
                }
                sr.Close();
            }
            teamNameDB[511] = "";

        }

        public string[] GetTeamNameDB()
        {
            if (TEAM)
            {
                for (int i = 0; i < GetTableRecCount("TEAM"); i++)
                {
                    int j = Convert.ToInt32(GetDBValue("TEAM", "TGID", i));

                    teamNameDB[j] = Convert.ToString(GetDBValue("TEAM", "TDNA", i));
                    teamMascot[j] = Convert.ToString(GetDBValue("TEAM", "TMNA", i));
                }
            }
            else
            {

                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string csvLocation = Path.Combine(executableLocation, @"Resources\teams\TeamDB.csv");

                string filePath = csvLocation;
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    string[] Line = sr.ReadLine().Split(',');
                    {
                        teamNameDB[Convert.ToInt32(Line[0])] = Line[1];
                        teamMascot[Convert.ToInt32(Line[0])] = Line[2];
                    }
                }
                sr.Close();
            }
            teamNameDB[511] = "";

            return teamNameDB;
        }

        public void CreateTeamColorPalettes()
        {
            TeamColorPalettes = CreateStringListsFromCSV(@"resources\teams\Color-Palettes.csv", true);
        }

        public string GetTeamName(int tgid)
        {

            string tmpSTR = teamNameDB[tgid];
            return tmpSTR;
        }

        public int FindTeamPrestige(int TGID)
        {
            int TMPR = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (TGID == Convert.ToInt32(GetDBValue("TEAM", "TGID", i)))
                {
                    return Convert.ToInt32(GetDBValue("TEAM", "TMPR", i));
                }
            }
            return TMPR;
        }

        public int FindTeamRanking(int TGID)
        {
            int TCRK = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (TGID == Convert.ToInt32(GetDBValue("TEAM", "TGID", i)))
                {
                    TCRK = Convert.ToInt32(GetDBValue("TEAM", "TCRK", i));
                }
            }
            return TCRK;
        }

        public int GetTeamRanking(int i)
        {
            int teamRanking = 0;

            teamRanking = Convert.ToInt32(GetDBValue("TEAM", "TCRK", i));

            return teamRanking;
        }

        public int GetTeamTGIDfromRecord(int i)
        {
            i = Convert.ToInt32(GetDBValue("TEAM", "TGID", i));

            return i;
        }

        public int GetTeamCONFrecID(int cgid)
        {
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (Convert.ToInt32(GetDBValue("CONF", "CGID", i)) == cgid)
                {
                    return i;
                }
            }

            return -1;
        }

        public int GetTeamPrestige(int rec)
        {
            return Convert.ToInt32(GetDBValue("TEAM", "TMPR", rec));

        }
        public int GetTeamCGID(int rec)
        {
            return Convert.ToInt32(GetDBValue("TEAM", "CGID", rec));

        }

        public int GetTeamDGID(int rec)
        {
            return Convert.ToInt32(GetDBValue("TEAM", "DGID", rec));

        }

        public int GetTeamStateID(int rec)
        {
            int stateID = -1;
            string SGID = GetDBValue("TEAM", "SGID", rec);

            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (SGID == GetDBValue("STAD", "SGID", i))
                {
                    stateID = Convert.ToInt32(GetDBValue("STAD", "STID", i));
                    break;
                }

            }

            return stateID;
        }

        public string GetTeamImpactPlayer(int rec, string field)
        {
            string playername = "";

            int tgid = GetDBValueInt("TEAM", "TGID", rec);
            int impactNo = GetDBValueInt("TEAM", field, rec);

            int pgid = tgid * 70 + impactNo;

            playername = GetPlayerNamefromPGID(pgid);

            return playername;

        }

        public int FindSTADrecFromTEAMrec(int tmRec)
        {
            int sgid = GetDBValueInt("TEAM", "SGID", tmRec);

            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (GetDBValueInt("STAD", "SGID", i) == sgid)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FindTeamRecfromTeamName(string tmName)
        {
            int tgid = -1;
            for(int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if(GetDBValue("TEAM", "TDNA", i) == tmName)
                {
                    tgid = i; 
                    break;
                }
            }

            return tgid;
        }

        public int FindTGIDfromTeamName(string tmName)
        {
            for (int i = 0; i < teamNameDB.Length; i++)
            {
                if(teamNameDB[i] == tmName) 
                {
                    return i; 
                }

            }
            return -1;
        }

        public void ReorderTORD()
        {
            List<List<string>> teamList = new List<List<string>>();
            int row = 0;
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                teamList.Add(new List<string>());
                string team = GetDBValue("TEAM", "TDNA", i);
                if (GetDBValueInt("COCH", "CFUC", GetCOCHrecFromTeamRec(i)) == 1)
                {
                    team = "_" + team;
                }
                teamList[row].Add(team);
                teamList[row].Add(Convert.ToString(i));
                row++;
            }

            teamList.Sort((team1, team2) => team1[0].CompareTo(team2[0]));

            int tord = 0;
            for (int i = 0; i < teamList.Count; i++)
            {
                ChangeDBInt("TEAM", "TORD", Convert.ToInt32(teamList[i][1]), tord);
                tord++;
            }


        }

        #endregion

        #region Conferences

        public int GetConfCGID(int rec)
        {
            return Convert.ToInt32(GetDBValue("CONF", "CGID", rec));
        }

        public int GetConfPrestige(int rec)
        {
            return Convert.ToInt32(GetDBValue("CONF", "CPRS", rec));
        }

        public int GetConfLeague(int rec)
        {
            return Convert.ToInt32(GetDBValue("CONF", "LGID", rec));
        }

        public int GetConfCMNP(int rec)
        {
            return Convert.ToInt32(GetDBValue("CONF", "CMNP", rec));
        }

        public int GetConfCMXP(int rec)
        {
            return Convert.ToInt32(GetDBValue("CONF", "CMXP", rec));
        }

        public int GetConfPrestigeFromCGID(int cgid)
        {
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (Convert.ToInt32(GetDBValue("CONF", "CGID", i)) == cgid)
                {
                    return Convert.ToInt32(GetDBValue("CONF", "CPRS", i));
                }
            }

            return -1;
        }

        public string GetConfNameFromCGID(int cgid)
        {
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (Convert.ToInt32(GetDBValue("CONF", "CGID", i)) == cgid)
                {
                    string cnam = GetDBValue("CONF", "CNAM", i);
                    if (cnam == "Generic") cnam = "At-Large";
                    return cnam;
                }
            }

            return "";
        }

        public string GetDivisionNamefromDGID(int dgid)
        {
            for (int i = 0; i < GetTableRecCount("DIVI"); i++)
            {
                if (Convert.ToInt32(GetDBValue("DIVI", "DGID", i)) == dgid)
                {
                    return GetDBValue("DIVI", "DNAM", i);
                }
            }

            return "";
        }

        public string GetLeaguefromTTYP(int ttyp)
        {
            if (ttyp == 0) return "FBS";
            else if (ttyp == 1) return "FCS";
            else if (ttyp == 2) return "Custom";
            else return "";
        }

        public int GetCONFrecFromCNAM(string cnam)
        {
            if (cnam == "At-Large") return 17;
            for(int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetDBValue("CONF", "CNAM", i) == cnam) return i;
            }

            return -1;
        }

        public int GetCONFrecFromCGID(int cgid)
        {
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
            {
                if (GetDBValueInt("CONF", "CGID", i) == cgid) return i;
            }

            return -1;
        }
        #endregion

        #region BOWLS
        public int GetBOWLrecfromBNME(string bnme)
        {
            for (int i = 0; i < GetTableRecCount("BOWL"); i++)
            {
                if (GetDBValue("BOWL", "BNME", i) == bnme) return i;
            }

            return -1;
        }

        #endregion

        #region Stadiums

        public string GetStadNamefromSGID(string sgid)
        {
            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (GetDBValue("STAD", "SGID", i) == sgid) return GetDBValue("STAD", "SNAM", i);
            }

            return "";
        }
        public string GetTDNAfromSGID(string sgid)
        {
            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (GetDBValue("STAD", "SGID", i) == sgid) return GetDBValue("STAD", "TDNA", i);
            }

            return "";
        }

        public int GetSGIDfromSNAM(string snam)
        {
            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (GetDBValue("STAD", "SNAM", i) == snam) return GetDBValueInt("STAD", "SGID", i);
            }

            return 255;
        }

        public int GetSGIDfromTDNA(string tnda)
        {
            for (int i = 0; i < GetTableRecCount("STAD"); i++)
            {
                if (GetDBValue("STAD", "TDNA", i) == tnda) return GetDBValueInt("STAD", "SGID", i);
            }

            return 255;
        }

        #endregion

        #region Skill Attributes

        public int GetRandomAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(-tol, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        public int GetRandomPositiveAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(0, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        public int GetReducedAttribute(int attribute, int tol)
        {

            attribute += rand.Next(0, tol + 1);

            if (attribute < 40) attribute = 40; if (attribute > 99) attribute = 99;

            return attribute;
        }

        #endregion

        #region Uniforms

        private List<string> GetHelmetNumbers()
        {
            List<string> helmets = new List<string>();

            helmets.Add("None");
            helmets.Add("Small-Left");
            helmets.Add("Small-Right");
            helmets.Add("Small-Center");
            helmets.Add("Med-Wide-Gape");
            helmets.Add("Med-Gap");
            helmets.Add("Med-Close");
            helmets.Add("Large-Wide-Gap");
            helmets.Add("Large-Gap");
            helmets.Add("Large-Close");

            return helmets;
        }

        private int ReturnHelmetNumberVal(string helmet)
        {
            List<string> helmets = GetHelmetNumbers(); 
            
            for(int i = 0; i < helmets.Count; i++)
            {
                if (helmets[i] == helmet) return i;
            }

            return -1;
        }

        #endregion


        #region CSV Tools

        public List<List<string>> CreateStringListsFromCSV(string location, bool skipFirstRow)
        {
            List<List<string>> list = new List<List<string>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = 0;
            if (skipFirstRow) skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (skipFirstRow && Row == 0) /*do nothing*/;
                else
                {
                    list.Add(new List<string>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        list[Row + skip].Add(Line[column]);
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        public List<string> CreateStringListfromCSV(string location, bool skipFirstRow)
        {
            List<string> list = new List<string>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0 && skipFirstRow)
                {
                    //skip header
                }
                else
                {
                    list.Add(Line[0]);
                }

                Row++;
            }
            sr.Close();

            return list;
        }


        public List<List<int>> CreateIntListsFromCSV(string location, bool skipFirstRow)
        {
            List<List<int>> list = new List<List<int>>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            int skip = 0;
            if (skipFirstRow) skip = -1;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (skipFirstRow && Row == 0) /*do nothing*/;
                else
                {
                    list.Add(new List<int>());
                    for (int column = 0; column < Line.Length; column++)
                    {
                        list[Row + skip].Add(Convert.ToInt32(Line[column]));
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        public List<int> CreateIntListfromCSV(string location, bool skipFirstRow)
        {
            List<int> list = new List<int>();
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, location);

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0 && skipFirstRow)
                {
                    //skip header
                }
                else
                {
                    for (int column = 0; column < Line.Length; column++)
                    {
                        if (column == 1) list.Add(Convert.ToInt32(Line[column]));
                    }
                }

                Row++;
            }
            sr.Close();

            return list;
        }

        #endregion





    }
}
