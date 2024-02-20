using System;
using System.Collections.Generic;
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

        private void CreateNameConversionTable()
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

            foreach (KeyValuePair<string, int> CHAR in AlphabetX)
            {
                Alphabet.Add(CHAR.Value, CHAR.Key);
            }


        }

        public string ConvertFN_IntToString(int tmpRecNo)
        {

            string tmpSTR = "";
            string xPFNA = "";

            for (int PF = 1; PF <= maxNameChar; PF++)
            {
                if (Alphabet[Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PF" + AddLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPFNA = xPFNA + Alphabet[Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PF" + AddLeadingZeros(Convert.ToString(PF), 2), tmpRecNo))];

            }
            tmpSTR = xPFNA;
            return tmpSTR;
        }
        public string ConvertLN_IntToString(int tmpRecNo)
        {
            string tmpSTR = "";
            string xPLNA = "";

            for (int PL = 1; PL <= maxNameChar; PL++)
            {
                if (Alphabet[Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PL" + AddLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))] == "")
                {
                    break;
                }
                xPLNA = xPLNA + Alphabet[Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PL" + AddLeadingZeros(Convert.ToString(PL), 2), tmpRecNo))];

            }
            tmpSTR = xPLNA;
            return tmpSTR;
        }

        private void ImportFN_StringToInt(string PFNA, int tmpRecNo, string tableName)
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
        private void ImportLN_StringToInt(string PLNA, int tmpRecNo, string tableName)
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

        private string AddLeadingZeros(string tmpSTR, int tmpLen)
        {
            for (int i = 1; i < tmpLen; i++)
                tmpSTR = "0" + tmpSTR;

            if (tmpSTR.Length > tmpLen)
                tmpSTR = tmpSTR.Substring(tmpSTR.Length - tmpLen, tmpLen);

            return tmpSTR;
        }

        #endregion

        #region Positions

        private void SetPositions()
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

        public string GetPositionName(int tmpRecNo)
        {

            string tmpSTR = Positions[tmpRecNo];
            return tmpSTR;
        }

        #endregion

        #region Ratings

        private void CreateRatingsDB()
        {
            Ratings.Clear();
            RatingsX.Clear();

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

        #endregion

        #region Teams

        public void CreateTeamDB()
        {
            for (int i = 0; i < maxTeamsDB; i++)
            {
                int j = Convert.ToInt32(TDB.FieldValue(dbIndex, "TEAM", "TGID", i));

                teamNameDB[j] = Convert.ToString(TDB.FieldValue(dbIndex, "TEAM", "TDNA", i));
            }
        }

        public string GetTeamName(int tmpRecNo)
        {

            string tmpSTR = teamNameDB[tmpRecNo];
            return tmpSTR;
        }

        private int FindTeamPrestige(int TGID)
        {
            int TMPR = 0;
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
            {
                if (TGID == Convert.ToInt32(TDB.FieldValue(dbIndex, "TEAM", "TGID", i)))
                {
                    TMPR = Convert.ToInt32(TDB.FieldValue(dbIndex, "TEAM", "TMPR", i));
                }
            }
            return TMPR;
        }

        private int GetTeamRanking(int i)
        {
            int teamRanking = 0;

            teamRanking = Convert.ToInt32(TDB.FieldValue(dbIndex, "TEAM", "TCRK", i));

            return teamRanking;
        }

        private int GetTeamTGIDfromRecord(int i)
        {
            i = Convert.ToInt32(TDB.FieldValue(dbIndex, "TEAM", "TGID", i));

            return i;
        }


        #endregion

        #region Coaches

        private int FindRecNumberCCID(int CCID)
        {
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "COCH"); i++)
            {
                if (CCID == Convert.ToInt32(TDB.FieldValue(dbIndex, "COCH", "CCID", i)))
                {
                    return i;
                }
            }

            return -1;
        }

        #endregion

        #region Players

        private int GetPGIDfromRecord(int i)
        {
            return Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PGID", i));

        }

        private int GetPPOSfromRecord(int i)
        {
            return Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PPOS", i));

        }

        private int GetPOVRfromRecord(int i)
        {
            return Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "POVR", i));

        }

        private int GetPTYPfromRecord(int i)
        {
            return Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PTYP", i));

        }

        private int GetPYERfromRecord(int i)
        {
            return Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PYER", i));

        }

        #endregion

        #region Skill Attributes

        private int GetRandomAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(tol, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        private int GetReducedAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(0, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > 31) attribute = 31;

            return attribute;
        }

        #endregion

    }
}
