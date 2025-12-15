using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
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
            if (verNumber == 15.0) csvLocation = Path.Combine(executableLocation, @"resources\RCAT-NEXT.csv");
            else if (verNumber >= 16.2) csvLocation = Path.Combine(executableLocation, @"resources\RCAT-NEXT26v2.csv");
            else if (verNumber >= 16.0) csvLocation = Path.Combine(executableLocation, @"resources\RCAT-NEXT26.csv");

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

        public string GetPlayerNamefromRec(int rec)
        {
            string playername = "";

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
                if (GetDBValueInt("PLAY", "PGID", i) == PGID)
                {
                    return i;
                }
            }
            return rec;
        }

        public List<string> CreateRedshirtStatus()
        {
            List<string> status = new List<string>();

            status.Add("None");
            status.Add("Current");
            status.Add("Redshirted");
            if (verNumber >= 16.0) status.Add("Medical");
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

        public List<string> CreateClassYearsAbbr()
        {
            List<string> status = new List<string>();

            status.Add("FR");
            status.Add("SO");
            status.Add("JR");
            status.Add("SR");
            return status;
        }

        public string GetClassYearsAbbr(int year, int redshirt)
        {
            if (redshirt == 0)
            {
                if (year == 0) return "FR";
                else if (year == 1) return "SO";
                else if (year == 2) return "JR";
                else return "SR";
            }
            else
            {
                if (year == 0) return "FR (RS)";
                else if (year == 1) return "SO (RS)";
                else if (year == 2) return "JR (RS)";
                else return "SR (RS)";
            }

        }

        public string GetClassYear(int year, int redshirt)
        {
            string classYear = "";
            if (redshirt == 0)
            {
                classYear += "RS ";
            }

            if (year == 0) classYear+= "Freshman";
            else if (year == 1) classYear += "Sophomore";
            else if (year == 2) classYear += "Junior";
            else classYear += "Senior";
            
            return classYear;
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
            skinColors.Add("Med-Dark - 3");
            skinColors.Add("Dark - 4");
            skinColors.Add("Dark - 5");
            skinColors.Add("Dark - 6");
            skinColors.Add("Med-Light - 7");
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

            hair.Add("Bald"); //0
            hair.Add("Corn Rows");
            hair.Add("Afro");
            hair.Add("Flat Top");
            hair.Add("Buzzcut");
            hair.Add("Fade");
            hair.Add("Balding");
            hair.Add("Close Crop");
            hair.Add("Bald (Hidden)"); //8
            hair.Add("Bald 2");
            hair.Add("Balding 2"); //10
            hair.Add("Buzzcut 2");
            hair.Add("Fade 2");
            hair.Add("Mullet");
            hair.Add("Dreadlocks");  //14
            return hair;
        }

        public List<List<int>> GetBodySizeAverages()
        {
            List<List<int>> bodysize = CreateIntListsFromCSV(@"resources\players\Body_Size_AVG.csv", true);

            return bodysize;

        }

        private string GetPTENType(int ppos, int pten)
        {
            string type = "";
            int cat = 2;
            List<List<string>> types = CreateStringListsFromCSV(@"resources\players\PTEN.csv", true);

            if (pten < 10) cat = 1;
            else if (pten < 20) cat = 2;
            else cat = 3;

            type = types[ppos][cat];

            return type;
        }

        #endregion

        #region Skill Attributes

        public int GetRandomAttribute(int attribute, int tol)
        {
            Random rand = new Random();

            attribute += rand.Next(-tol, tol + 1);

            if (attribute < 0) attribute = 0; if (attribute > maxRatingVal) attribute = maxRatingVal;

            return attribute;
        }

        public int GetRandomPositiveAttribute(int attribute, int tol)
        {
            if (verNumber >= 16.0) tol = (int)(tol * 1.0);
            Random rand = new Random();

            if (tol < 0) attribute += rand.Next(tol, 0);
            else attribute += rand.Next(0, tol + 1);

            if (attribute < minRatingVal) attribute = minRatingVal;
            if (attribute > maxRatingVal) attribute = maxRatingVal;

            return attribute;
        }

        public int GetReducedAttribute(int attribute, int tol)
        {

            attribute += rand.Next(0, tol + 1);

            if (attribute < minRatingVal) attribute = minRatingVal;
            if (attribute > maxRatingVal) attribute = maxRatingVal;

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

            for (int i = 0; i < helmets.Count; i++)
            {
                if (helmets[i] == helmet) return i;
            }

            return -1;
        }

        #endregion

        #region Equipment Lists

        private List<string> GetHelmetTypes()
        {
            List<string> Helmets = new List<string>();
            if (verNumber > 16.0)
            {
                Helmets.Add("SpeedFlex");
                Helmets.Add("Vicis Zero2");
                Helmets.Add("Schutt F7");
                Helmets.Add("SpeedFlex 2");
            }
            else
            {
                Helmets.Add("Normal");
                Helmets.Add("Adams");
                Helmets.Add("Schutt");
                Helmets.Add("Revolution");
            }

            return Helmets;
        }

        private List<string> GetFaceMaskTypes(int HELM)
        {
            List<string> FaceMasks = new List<string>();

            if (verNumber > 16.0)
            {
                if (HELM == 3)
                {
                    FaceMasks.Add("*");
                    FaceMasks.Add("SF-Kicker");  //K+P
                    FaceMasks.Add("SF-3BD (Skill Pos)"); //Skill
                    FaceMasks.Add("SF-2EG-II (Linemen)"); //Linemen
                }
                else
                {
                    FaceMasks.Add("*");
                    FaceMasks.Add("2-Bar");
                    FaceMasks.Add("3-Bar");
                    FaceMasks.Add("Half-Cage");
                    FaceMasks.Add("Full-Cage 1");
                    FaceMasks.Add("2-Bar Thin");
                    FaceMasks.Add("1-Bar");
                    FaceMasks.Add("2-Bar RB");
                    FaceMasks.Add("3-Bar QB");
                    FaceMasks.Add("3-Bar RB 1");
                    FaceMasks.Add("Full-Cage 2");
                    FaceMasks.Add("3-Bar RB 2");
                }
            }
            else
            {
                if (HELM == 3)
                {
                    FaceMasks.Add("*");
                    FaceMasks.Add("REVOG3BDU");  //K+P
                    FaceMasks.Add("REVOG2EG"); //Skill
                    FaceMasks.Add("REVOG2B"); //Linemen
                }
                else
                {
                    FaceMasks.Add("*");
                    FaceMasks.Add("2-Bar");
                    FaceMasks.Add("3-Bar");
                    FaceMasks.Add("Half-Cage");
                    FaceMasks.Add("Full-Cage 1");
                    FaceMasks.Add("2-Bar Thin");
                    FaceMasks.Add("1-Bar");
                    FaceMasks.Add("2-Bar RB");
                    FaceMasks.Add("3-Bar QB");
                    FaceMasks.Add("3-Bar RB 1");
                    FaceMasks.Add("Full-Cage 2");
                    FaceMasks.Add("3-Bar RB 2");
                }
            }

                return FaceMasks;
        }

        private List<string> GetVisorTypes()
        {
            List<string> Visors = new List<string>();
            if (verNumber >= 16.2)
            {
                Visors.Add("None");
                Visors.Add("Clear");
                Visors.Add("Dark");
                Visors.Add("Tinted");
            }
            else 
            { 
            Visors.Add("None");
            Visors.Add("Clear");
            Visors.Add("Dark");
            Visors.Add("Orange");
            }
            return Visors;
        }

        private List<string> GetFaceProtectorTypes()
        {
            List<string> FaceProtector = new List<string>();
            FaceProtector.Add("No");
            FaceProtector.Add("Cold Only");
            return FaceProtector;
        }


        private List<string> GetQBJacketTypes()
        {
            List<string> Flak = new List<string>();
            Flak.Add("No");
            Flak.Add("Yes");
            return Flak;
        }

        private List<string> GetEyeBlackTypes()
        {
            List<string> EyeBlacks = new List<string>();
            EyeBlacks.Add("None");
            EyeBlacks.Add("Eye Black");
            return EyeBlacks;
        }

        private List<string> GetNasalStripTypes()
        {
            List<string> NasalStrips = new List<string>();
            NasalStrips.Add("None");
            NasalStrips.Add("Nasal Strip");
            return NasalStrips;
        }

        private List<string> GetMouthguardTypes()
        {
            List<string> Mouthguards = new List<string>();
            Mouthguards.Add("None");
            Mouthguards.Add("Normal");
            return Mouthguards;
        }

        private List<string> GetNeckPadTypes()
        {
            List<string> NeckPads = new List<string>();
            NeckPads.Add("None");
            NeckPads.Add("Neck Roll");
            NeckPads.Add("Extended");
            return NeckPads;
        }

        private List<string> GetTurfTapeTypes()
        {
            List<string> TurfTape = new List<string>();
            TurfTape.Add("None");
            TurfTape.Add("Always");
            TurfTape.Add("Turf Only");
            return TurfTape;
        }
        private List<string> GetSleevesType()
        {
            List<string> Sleeves = new List<string>();
            if (verNumber >= 16.0)
            {
                Sleeves.Add("Cold Only");
                Sleeves.Add("Always/Tattoos");
                Sleeves.Add("None");
            }
            else
            {
                Sleeves.Add("Cold Only");
                Sleeves.Add("Always On");
                Sleeves.Add("None");
            }
            return Sleeves;
        }

        private List<string> GetSleevesColors()
        {
            List<string> SleevesColors = new List<string>();
            if (verNumber >= 16.0)
            {
                SleevesColors.Add("Tattoos 1");
                SleevesColors.Add("Tattoos 2");
                SleevesColors.Add("Team Color");
            }
            else
            {
                SleevesColors.Add("Black");
                SleevesColors.Add("White");
                SleevesColors.Add("Team Color");
            }

            return SleevesColors;
        }

        private List<string> GetElbowTypes()
        {
            List<string> Elbows = new List<string>();
            if (verNumber >= 16.2)
            {
                Elbows.Add("Normal");
                Elbows.Add("Rubber Pad");
                Elbows.Add("Arm Restraint");
                Elbows.Add("XL Undershirt");
                Elbows.Add("TC Misc Band");
                Elbows.Add("TC Shirt");
                Elbows.Add("Black Sleeve Top");
                Elbows.Add("White Sleeve Top");
                Elbows.Add("Team Sleeve Top");
                Elbows.Add("Black Undershirt");
                Elbows.Add("White Undershirt");
                Elbows.Add("TC Thin Band");
            }
            else if (verNumber >= 15.0)
            {
                Elbows.Add("Normal");
                Elbows.Add("Rubber Pad");
                Elbows.Add("Black Pad");
                Elbows.Add("White Pad");
                Elbows.Add("Black TC Pad");
                Elbows.Add("White TC Pad");
                Elbows.Add("Black Sleeve Top");
                Elbows.Add("White Sleeve Top");
                Elbows.Add("Team Sleeve Top");
                Elbows.Add("Black Undershirt");
                Elbows.Add("White Undershirt");
                Elbows.Add("TC Thin Band");
            }
            else
            {
                Elbows.Add("Normal");
                Elbows.Add("Rubber Pad");
                Elbows.Add("Black Pad");
                Elbows.Add("White Pad");
                Elbows.Add("Black TC Pad");
                Elbows.Add("White TC Pad");
                Elbows.Add("Black Med Band");
                Elbows.Add("White Med Band");
                Elbows.Add("Team Med Band");
                Elbows.Add("Black Thin Band");
                Elbows.Add("White Thin Band");
                Elbows.Add("TC Thin Band");
            }

            return Elbows;
        }

        private List<string> GetWristsTypes()
        {
            List<string> Wrists = new List<string>();
            if (verNumber >= 15.0)
            {
                Wrists.Add("None");
                Wrists.Add("White QB Wrist");
                Wrists.Add("Black QB Wrist");
                Wrists.Add("TC QB Wrist");
                Wrists.Add("Black Wrist");
                Wrists.Add("White Wrist");
                Wrists.Add("Team Wrist");
                Wrists.Add("Plain Arm");
                Wrists.Add("White Sleeve Bot");
                Wrists.Add("Black Sleeve Bot");
                Wrists.Add("Team Sleeve Bot");
                Wrists.Add("Taped");
            }
            else
            {
                Wrists.Add("Normal");
                Wrists.Add("White QB Wrist");
                Wrists.Add("Black QB Wrist");
                Wrists.Add("TC QB Wrist");
                Wrists.Add("Black Wrist");
                Wrists.Add("White Wrist");
                Wrists.Add("Team Wrist");
                Wrists.Add("Arm Pad");
                Wrists.Add("White Half-Sleeve");
                Wrists.Add("Black Half-Sleeve");
                Wrists.Add("Team Half-Sleeve");
                Wrists.Add("Taped");
            }

            return Wrists;

        }


        private List<string> GetHandTypes()
        {
            List<string> Gloves = new List<string>();
            if(verNumber >= 16.2)
            {
                
                Gloves.Add("Bare"); //0
                Gloves.Add("White");
                Gloves.Add("Black");
                Gloves.Add("Taped Hand");  //3
                Gloves.Add("Team 1");
                Gloves.Add("Team 2");
                Gloves.Add("Uniform 1");
                Gloves.Add("Uniform 2");

            }
            else if (verNumber >= 16.0)
            {
               
                Gloves.Add("None");
                Gloves.Add("Gloves (not used)");
                Gloves.Add("Gloves");

            }
            else
            {
                Gloves.Add("None");
                Gloves.Add("Taped Hand");
                Gloves.Add("Gloves");
            }
                
            return Gloves;
        }

        private List<string> GetCleatTypes()
        {
            List<string> Cleats = new List<string>();

            if (verNumber >= 16.2)
            {
                Cleats.Add("Normal");
                Cleats.Add("Alt 1 (White)");
                Cleats.Add("Alt 2 (Black)");
                Cleats.Add("Alt 3 (Team)");
            }
            else
            {
                Cleats.Add("Normal");
                Cleats.Add("White Taped");
                Cleats.Add("Black Taped");
                Cleats.Add("Team Taped");
            }

            return Cleats;
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

        public int GetPOSG2fromPPOS(int posg)
        {
            if (posg == 0) return 0;
            else if (posg == 1) return 1;
            else if (posg == 2) return 2;
            else if (posg == 3) return 3;
            else if (posg == 4) return 4;
            else if (posg == 5) return 5;
            else if (posg == 6) return 6;
            else if (posg == 7) return 7;
            else if (posg == 8) return 6;
            else if (posg == 9) return 5;
            else if (posg == 10) return 8;
            else if (posg == 11) return 8;
            else if (posg == 12) return 9;
            else if (posg == 13) return 10;
            else if (posg == 14) return 11;
            else if (posg == 15) return 10;
            else if (posg == 16) return 12;
            else if (posg == 17) return 13;
            else if (posg == 18) return 14;
            else if (posg == 19) return 15;
            else if (posg == 20) return 16;
            else return -1;
        }
        public string GetPOSG2Name(int posg)
        {
            if (posg == 0) return "QB";
            else if (posg == 1) return "HB";
            else if (posg == 2) return "FB";
            else if (posg == 3) return "WR";
            else if (posg == 4) return "TE";
            else if (posg == 5) return "OT";
            else if (posg == 6) return "OG";
            else if (posg == 7) return "C";
            else if (posg == 8) return "DE";
            else if (posg == 9) return "DT";
            else if (posg == 10) return "OLB";
            else if (posg == 11) return "MLB";
            else if (posg == 12) return "CB";
            else if (posg == 13) return "FS";
            else if (posg == 14) return "SS";
            else if (posg == 15) return "K";
            else if (posg == 16) return "P";

            else return "";
        }

        public List<List<int>> GetAwarenessHitList()
        {
            return CreateIntListsFromCSV(@"resources\players\awareness.csv", true);
        }

        private int DepthChartHB(int off)
        {
            if (off == 3) return 2;
            else return 1;
        }

        private int DepthChartFB(int off)
        {
            if (off == 1) return 0;
            else return 1;
        }

        private int DepthChartWR(int off)
        {
            if (off == 3) return 1;
            else if (off == 0 || off == 2 || off == 4) return 2;
            else return 3;
        }

        private int DepthChartDT(int def)
        {
            if (def <= 2) return 1;
            else return 2;
        }

        private int DepthChartOLB(int def)
        {
            if (def == 2) return 1;
            else return 2;
        }

        private int DepthChartMLB(int def)
        {
            if (def == 0 || def == 4) return 1;
            else return 2;
        }

        private int DepthChartSS(int def)
        {
            if (def == 0 || def == 3) return 1;
            else if (def <=3) return 2;
            else return 0;
        }

        #endregion

        #region Ratings

        public void CreateRatingsDB()
        {
            Ratings.Clear();
            RatingsX.Clear();

            TdbFieldProperties fieldProps = new TdbFieldProperties();

            fieldProps.Name = TDBNameLength;


            if (TEAM && GetTableRecCount("PRLU") > 0)
            {
                for (int i = 0; i < GetTableRecCount("PRLU"); i++)
                {
                    Ratings.Add(i, Convert.ToInt32(GetDBValue("PRLU", "LURT", i)));
                }
            }
            else if (Convert.ToInt32(TDB.FieldBitmax(dbIndex, "PLAY", "POVR")) > 31)
            {
                for (int i = 0; i < 60; i++)
                {
                    Ratings.Add(i, i + 40);
                }
            }
            else
            {
                List<int> ratingsList = new List<int>();
                ratingsList = CreateIntListfromCSV(@"resources\players\PRLU.csv", true);
                for (int i = 0; i < ratingsList.Count; i++)
                {
                    Ratings.Add(i, ratingsList[i]);
                }
            }

            foreach (KeyValuePair<int, int> CHAR in Ratings)
            {
                RatingsX.Add(CHAR.Value, CHAR.Key);
            }

            minRatingVal = 0;
            maxRatingVal = Ratings.Count - 1;
            minConvRatingVal = Ratings[minRatingVal];
            maxConvRatingVal = Ratings[maxRatingVal];
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

        private int ConvertPotentialRating(int value)
        {
            List<int> ratingsList = new List<int>();
            ratingsList = CreateIntListfromCSV(@"resources\players\PRLU.csv", true);

            return ratingsList[value];

        }

        public void CreatePOCItable()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\POCI.csv");

            if (verNumber == 15.0) csvLocation = Path.Combine(executableLocation, @"resources\POCI-NEXT.csv");
            else if (verNumber == 16.0) csvLocation = Path.Combine(executableLocation, @"resources\POCI-NEXT26.csv");
            else if (verNumber >= 16.2) csvLocation = Path.Combine(executableLocation, @"resources\POCI-NEXT26v2.csv");


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
            if (val < minConvRatingVal) val = minConvRatingVal;
            val = RevertRating(val);

            ChangeDBString("PLAY", "POVR", rec, Convert.ToString(val));

        }

        public double CalculatePositionRating(double r, int ppos)
        {
            int rec = Convert.ToInt32(r);
            int posg = GetPOSG2fromPPOS(ppos);
            int playerPos = GetDBValueInt("PLAY", "PPOS", rec);
            int playerPOSG = GetPOSG2fromPPOS(playerPos);

            List<List<int>> AWRH = GetAwarenessHitList();
            double hit = 0.13;

            //if (NextConfigRadio.Checked) hit = 0.08;
            //else hit = 0.19;

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

            double AWRog = ConvertRating(Convert.ToInt32(PAWR));

            double PosHit = hit * AWRH[playerPos][ppos];

            double AWR = Convert.ToInt32(AWRog - (AWRog * PosHit));

            if (AWR < minConvRatingVal) AWR = minConvRatingVal;

            PAWR = RevertRating(Convert.ToInt32(AWR));

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

            double val = newRating;

            // Positional Penalty
            if (playerPOSG != posg) val -= 15;



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
            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValue("TEAM", "TDNA", i) == tmName)
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
                if (teamNameDB[i] == tmName)
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

        private int FindTGIDfromSGID(int SGID)
        {
            int tgid = -1;

            for (int i = 0; i < GetTableRecCount("TEAM"); i++)
            {
                if (GetDBValueInt("TEAM", "SGID", i) == SGID) return GetDBValueInt("TEAM", "TGID", i);
            }


            return tgid;
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
            for (int i = 0; i < GetTableRecCount("CONF"); i++)
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

        private List<string> GetFieldTypes()
        {
            List<string> fieldsList = new List<string>()
            {
                "Natural - Light",
                "Natural - Dark",
                "Artificial",
                "Blue Turf",
                "Grassy Turf",
                "Multi-Turf"
            };

            return fieldsList;
        }

        private List<string> GetCreateTeamSRESList()
        {
            List<string> sresList = new List<string>()
            {
                "Bowl",
                "Square",
                "Horseshoe",
                "Upper Deck",
                "Dual Sides",
                "Dome"
            };

            return sresList;
        }

        private List<string> GetSTYPList()
        {
            List<string> stypList = new List<string>()
            {
                "Outdoor", 
                "Dome"
            };
            return stypList;
        }

        private List<string> GetSORIList()
        {
            List<string> sori = new List<string>()
            {
                "North/South",
                "East/West"            
            };
            return sori;
        }

        private List<string> GetBackdropList()
        {
            List<string> sori = new List<string>()
            {
                "Campus",
                "Metro",
                "Rural",
                "Moutains",
                "Desert"
            };
            return sori;
        }

        private List<string> GetEndzoneArtList()
        {
            List<string> endzone = new List<string>()
            {
                "School Name 1",
                "School Name 2",
                "Nickname 1",
                "Nickname 2",
                "Diamonds",
                "Checkerboard",
                "Slashes",
                "None"
            };
            return endzone;
        }

        private List<string> GetEndzoneBGList()
        {
            List<string> endzone = new List<string>()
            {
                "White", 
                "Black",
                "Primary Color",
                "Secondary Color",
                "None"
            };
            return endzone;
        }

        private List<string> Get25YardLogoList()
        {
            List<string> logo = new List<string>()
            {
                "School",
                "EA Sports",
                "NCAA",
                "None"
            };
            return logo;
        }

        private List<string> GetMidfieldLogoList()
        {
            List<string> logo = new List<string>()
            {
                "School",
                "EA Sports",
                "NCAA",
                "None"
            };
            return logo;
        }

        private List<string> GetVideoScreenList()
        {
            List<string> video = new List<string>()
            {
                "East/North",
                "West/South",
                "Both",
                "None",
            };
            return video;
        }

        private List<string> GetPressBoxList()
        {
            List<string> press = new List<string>()
            {
                "West/South",
                "East/North",
                "Both",
                "None",
            };
            return press;
        }

        private List<string> GetScoreboardList()
        {
            List<string> scoreboard = new List<string>()
            {
                "East/North",
                "West/South",
                "Both",
                "None",
            };
            return scoreboard;
        }

        private List<string> GetStadiumTrackList()
        {
            List<string> track = new List<string>()
            {
                "No", "Yes"
            };
            return track;
        }




        #endregion

        #region Injuries

        public List<string> CreateInjuryTypeTable()
        {
            List<string> injuryTypes = new List<string>();

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\injuries\INJT.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            double sum = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    //do nothing
                }
                else
                {
                    injuryTypes.Add(Line[1]);
                }
                Row++;
            }
            sr.Close();

            return injuryTypes;
        }

        public List<string> CreateInjuryLengthTable()
        {
            List<string> injuryTypes = new List<string>();

            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\injuries\INJL.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            int Row = 0;
            double sum = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    //do nothing
                }
                else
                {
                    injuryTypes.Add(Line[1]);
                }
                Row++;
            }
            sr.Close();

            return injuryTypes;
        }


        #endregion

        #region Recruiting

        private string GetRecruitPitch(int pitch)
        {
            if (pitch == 0) return "Team Prestige";
            else if (pitch == 1) return "Location";
            else if (pitch == 2) return "Playing Time";
            else if (pitch == 3) return "Coaching Style";
            else if (pitch == 4) return "Coaching Prestige";
            else if (pitch == 5) return "Academics";
            else return "";
        }

        private string ConvertStarNumber(int stars)
        {
            char whiteStar = '\u2606'; // ☆ White Star
            char blackStar = '\u2605'; // ★ Black Star

            string starPattern = "";
            for (int i = 0; i < stars; i++)
            {
                starPattern += blackStar;
            }

            return starPattern;

        }

        public int FindPRIDRecord(int PRID)
        {
            int rec = -1;
            for (int i = 0; i < GetTable2RecCount("RCPT"); i++)
            {
                if (GetDB2ValueInt("RCPT", "PRID", i) == PRID)
                {
                    return i;
                }
            }
            return rec;
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

        #region

        private int GetCurrentWeek()
        {
            int week = 0;
            week = Convert.ToInt32(GetDBValue("SEAI", "SEWN", 0));
            return week;
        }

        private int GetCurrentYear()
        {
            int year = 0;
            year = Convert.ToInt32(GetDBValue("SEAI", "SEYR", 0));
            return year;
        }

        #endregion


        #region Coloring

        private Color GetColorValueFullRange(decimal rating, bool inverted = false)
        {
            if (inverted) rating = 100 - rating;

            if (rating >= 100) return Color.DeepSkyBlue;
            else if (rating >= 90) return Color.Aqua;
            else if (rating >= 80) return Color.Aquamarine;
            else if (rating >= 70) return Color.Lime;
            else if (rating >= 60) return Color.GreenYellow;
            else if (rating >= 50) return Color.Yellow;
            else if (rating >= 40) return Color.Gold;
            else if (rating >= 30) return Color.Orange;
            else if (rating >= 20) return Color.Tomato;
            else if (rating >= 10) return Color.LightCoral;
            else return Color.IndianRed;

            // default (no rating found)
            return Color.DarkGray;
        }


        private Color GetColorRating(decimal rating)
        {
            if (rating >= 97) return Color.DeepSkyBlue;
            else if (rating >= 94) return Color.Aqua;
            else if (rating >= 90) return Color.Aquamarine;
            else if (rating >= 85) return Color.Lime;
            else if (rating >= 80) return Color.GreenYellow;
            else if (rating >= 75) return Color.Yellow;
            else if (rating >= 70) return Color.Gold;
            else if (rating >= 65) return Color.Orange;
            else if (rating >= 60) return Color.Tomato;
            else if (rating >= 50) return Color.LightCoral;
            else return Color.IndianRed;

            // default (no rating found)
            return Color.DarkGray;
        }

        private Color GetPrestigeColor(decimal rating)
        {
            if (rating == 6) return Color.DeepSkyBlue;
            else if (rating == 5) return Color.Aqua;
            else if (rating == 4) return Color.Lime;
            else if (rating == 3) return Color.Gold;
            else if (rating == 2) return Color.Orange;
            else return Color.LightCoral;

            // default (no rating found)
            return Color.DarkGray;
        }

        private Color GetTeamPrimaryColor(int teamRec)
        {
            Color col = Color.FromArgb(GetDBValueInt("TEAM", "TFRD", teamRec), GetDBValueInt("TEAM", "TFFG", teamRec), GetDBValueInt("TEAM", "TFFB", teamRec));
            return col;
        }


        Color ChooseForeground(Color bg)
        {
            if (bg.R * 2 + bg.G * 7 + bg.B < 1000)
                return Color.Gainsboro;
            else
                return Color.Black;
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
