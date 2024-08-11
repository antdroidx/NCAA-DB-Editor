using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {

      
        //Fixes Body Size Models if user does manipulation of the player attributes in the in-game player editor
        private void RecalculateBMI(string tableName)
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, @"resources\BMI-Calc.csv");

            string filePath = csvLocation;
            StreamReader sr = new StreamReader(filePath);
            string[,] strArray = null;
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                if (Row == 0)
                {
                    strArray = new string[432, Line.Length];
                }
                for (int column = 0; column < Line.Length; column++)
                {
                    strArray[Row, column] = Line[column];
                }
                Row++;
            }
            sr.Close();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                double bmi = (double)Math.Round(Convert.ToDouble(TDB.FieldValue(dbIndex, tableName, "PWGT", i)) / Convert.ToDouble(TDB.FieldValue(dbIndex, tableName, "PHGT", i)), 2);

                for (int j = 0; j < 401; j++)
                {
                    if (Convert.ToString(bmi) == strArray[j, 0])
                    {
                        TDB.NewfieldValue(dbIndex, tableName, "PFSH", i, strArray[j, 1]);
                        TDB.NewfieldValue(dbIndex, tableName, "PMSH", i, strArray[j, 2]);
                        TDB.NewfieldValue(dbIndex, tableName, "PSSH", i, strArray[j, 3]);
                        break;
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;

            MessageBox.Show("Body Model updates are complete!");
        }

        //Increases minium speed for skill positions to 80
        private void IncreaseMinimumSpeed()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "1" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "3"
                    || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "16" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "17" || TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "18")
                {
                    if (Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)) < 14)
                    {
                        TDB.NewfieldValue(dbIndex, "PLAY", "PSPD", i, "14");
                    }
                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Speed updates are complete!");
        }

        //Recalculates QB Tendencies based on original game criteria
        private void RecalculateQBTendencies()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            int pocket = 0;
            int balanced = 0;
            int scrambler = 0;


            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                if (TDB.FieldValue(dbIndex, "PLAY", "PPOS", i) == "0")
                {
                    int tendies;
                    int speed = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PSPD", i)));
                    int acceleration = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PACC", i)));
                    int agility = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PAGI", i)));
                    int ThPow = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PTHP", i)));
                    int ThAcc = ConvertRating(Convert.ToInt32(TDB.FieldValue(dbIndex, "PLAY", "PTHA", i)));


                    tendies = (100 + 10 * speed + acceleration + agility - 3 * ThPow - 5 * ThAcc) / 20;

                    if (tendies > 31) tendies = 31;
                    if (tendies < 0) tendies = 0;

                    TDB.NewfieldValue(dbIndex, "PLAY", "PTEN", i, Convert.ToString(tendies));

                    if (tendies < 10) pocket++;
                    else if (tendies > 19) scrambler++;
                    else balanced++;

                }
                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("QB updates are complete!\n\nThe Stats:\n\n* Pocket-Passers: " + pocket + "\n\n* Balanced: " + balanced + "\n\n* Scramblers: " + scrambler);
        }

        //Randomize Player Potential
        private void RandomizePotential()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                int x = rand.Next(0, 32);

                TDB.NewfieldValue(dbIndex, "PLAY", "PPOE", i, Convert.ToString(x));

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Potential Updates are complete!");
        }

        //Recalculate Player Overalls
        private void RecalculateOverall()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "PLAY");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                RecalculateOverallByRec(i);

                progressBar1.PerformStep();
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Player Overall Calculations are complete!");
        }


        //Export Recruiting Class from Roster

        //Calculate Team Ratings
        private void CalculateTeamRatings(string tableName)
        {

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;


            int rating, count;
            int bonus = 2;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                if(TDYN || TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TTYP", i) == 0)
                {
                    int TOID = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    count = 0;
                    List<List<int>> roster = new List<List<int>>();

                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        int PGID = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PGID", j);

                        if (PGID >= PGIDbeg && PGID <= PGIDend)
                        {
                            int POVR = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "POVR", j);
                            int PPOS = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PPOS", j);
                            List<int> player = new List<int>();
                            roster.Add(player);
                            roster[count].Add(POVR);
                            roster[count].Add(PPOS);
                            count++;
                        }
                    }
                    roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));


                    //TRDB - Defensive Backs  PPOS = 16, 17, 18
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 16 && PPOS <= 18)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 5) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRDB", i, Convert.ToString(rating));


                    //TRLB - Linebackers 13, 14, 15
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 13 && PPOS <= 15)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 4) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRLB", i, Convert.ToString(rating));



                    //TRQB - Quarterbacks 0
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS == 0)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 1) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRQB", i, Convert.ToString(rating));


                    //TRRB - Running Backs 1, 2
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 1 && PPOS <= 2)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 3) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRRB", i, Convert.ToString(rating));

                    //TRDL - Defensive Line 10, 11, 12
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 10 && PPOS <= 12)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 4) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRDL", i, Convert.ToString(rating));

                    //TROL - Offensive Line 5 - 9
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 5 && PPOS <= 9)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 6) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TROL", i, Convert.ToString(rating));

                    //TWRR - Wide Receivers 3, 4
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 3 && PPOS <= 4)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 5) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TWRR", i, Convert.ToString(rating));

                    //TRST - Special Teams 19, 20
                    rating = 0;
                    count = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        int PPOS = roster[j][1];

                        if (PPOS >= 19 && PPOS <= 20)
                        {
                            rating += roster[j][0];
                            count++;
                        }
                        if (count >= 2) break;
                    }

                    rating = ConvertRating(rating / count) + bonus;

                    TDB.NewfieldValue(dbIndex, tableName, "TRST", i, Convert.ToString(rating));


                    //TRDE - Defense 10 - 18, 20
                    rating = (Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRDB", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRLB", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRDL", i))) / 3;

                    TDB.NewfieldValue(dbIndex, tableName, "TRDE", i, Convert.ToString(rating));

                    //TROF - Offense 0 - 9, 19
                    rating = (Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRQB", i)) * 2 + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRRB", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TWRR", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TROL", i))) / 5;

                    TDB.NewfieldValue(dbIndex, tableName, "TROF", i, Convert.ToString(rating));

                    //TROV - Team Overall
                    rating = (Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TROF", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, tableName, "TRDE", i))) / 2;

                    TDB.NewfieldValue(dbIndex, tableName, "TROV", i, Convert.ToString(rating));


                    progressBar1.PerformStep();

                }
            }
                

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Team Rating Calculations are complete!");
        }

        //Determine Impact Players
        private void DetermineImpactPlayers()
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "TEAM");
            progressBar1.Step = 1;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TEAM"); i++)
            {
                int TGID = TDB.TDBFieldGetValueAsInteger(dbIndex, "TEAM", "TGID", i);
                int PGIDbeg = TGID * 70;
                int PGIDend = PGIDbeg + 69;
                int count = 0;
                List<List<int>> roster = new List<List<int>>();

                for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                {
                    int PGID = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PGID", j);

                    if (PGID >= PGIDbeg && PGID <= PGIDend)
                    {
                        int POVR = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "POVR", j);
                        int PPOS = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PPOS", j);

                        List<int> player = new List<int>();
                        roster.Add(player);
                        roster[count].Add(POVR);
                        roster[count].Add(PPOS);
                        roster[count].Add(PGID);
                        count++;
                    }
                }
                roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

                if (roster.Count == 0)
                {
                    progressBar1.PerformStep();
                } 
                else 
                { 

                int countOff = 0;
                int countDef = 0;
                    for (int j = 0; j < roster.Count; j++)
                    {
                        //pick offensive impact
                        if (roster[j][1] <= 4)
                        {
                            if (countOff == 0)
                            {
                                int impactID = roster[j][2] - PGIDbeg;
                                TDB.NewfieldValue(dbIndex, "TEAM", "TPIO", i, Convert.ToString(impactID));
                            }
                            if (countOff == 1)
                            {
                                int impactID = roster[j][2] - PGIDbeg;
                                TDB.NewfieldValue(dbIndex, "TEAM", "TSI1", i, Convert.ToString(impactID));
                            }
                            countOff++;
                        }

                        //pick defensive impact
                        if (roster[j][1] >= 10 && roster[j][1] <= 18)
                        {
                            if (countDef == 0)
                            {
                                int impactID = roster[j][2] - PGIDbeg;
                                TDB.NewfieldValue(dbIndex, "TEAM", "TPID", i, Convert.ToString(impactID));
                            }
                            if (countDef == 1)
                            {
                                int impactID = roster[j][2] - PGIDbeg;
                                TDB.NewfieldValue(dbIndex, "TEAM", "TSI2", i, Convert.ToString(impactID));
                            }
                            countDef++;
                        }

                        if (countOff > 1 && countDef > 1)
                        {
                            progressBar1.PerformStep();
                            break;
                        }
                    }
                }
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Impact Players are Set!");
        }

        //Fantasy Roster Generator
        #region Fantasy Roster Generator
        private void FantasyRosterGenerator(string tableName)
        {
            /* Creates a fantasy roster from team overall rating
             * Use RCAT, sort by position, count position players
             * randomize each raing + random from 0 to overall rating/10
             * make sure there's a mininum number of positions then randomize rest
             */


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;
            progressBar1.Value = 0;


            //Clear PLAY Table
            for (int i = TDB.TableRecordCount(dbIndex, "PLAY"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "PLAY", i);
            }
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = new List<List<string>>();
            RCATmapper = CreateStringListfromCSV(@"resources\RCAT-MAPPER.csv");

            List<List<string>> teamData = new List<List<string>>();
            teamData = CreateStringListfromCSV(@"resources\FantasyGenData.csv");

            int rec = 0;

            //sort RCAT by positions
            //RCAT.Sort((player1, player2) => player2[45].CompareTo(player1[45]));


            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                if (TDYN || TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TTYP", i) == 0)
                {
                    int TOID = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    int rating = GetFantasyTeamRating(teamData, TOID);

                    for (int j = 0; j < 68; j++)
                    {
                        //Add a record
                        TDB.TDBTableRecordAdd(dbIndex, "PLAY", false);

                        //QB
                        if (j < 3) TransferRCATtoPLAY(rec, 0, PGIDbeg + j, RCATmapper, PJEN);

                        //RB
                        else if (j < 6) TransferRCATtoPLAY(rec, 1, PGIDbeg + j, RCATmapper, PJEN);

                        //FB
                        else if (j < 7) TransferRCATtoPLAY(rec, 2, PGIDbeg + j, RCATmapper, PJEN);

                        //WR
                        else if (j < 13) TransferRCATtoPLAY(rec, 3, PGIDbeg + j, RCATmapper, PJEN);

                        //TE
                        else if (j < 16) TransferRCATtoPLAY(rec, 4, PGIDbeg + j, RCATmapper, PJEN);

                        //LT
                        else if (j < 18) TransferRCATtoPLAY(rec, 5, PGIDbeg + j, RCATmapper, PJEN);

                        //LG
                        else if (j < 20) TransferRCATtoPLAY(rec, 6, PGIDbeg + j, RCATmapper, PJEN);

                        //C
                        else if (j < 22) TransferRCATtoPLAY(rec, 7, PGIDbeg + j, RCATmapper, PJEN);

                        //RG
                        else if (j < 24) TransferRCATtoPLAY(rec, 8, PGIDbeg + j, RCATmapper, PJEN);

                        //RT
                        else if (j < 26) TransferRCATtoPLAY(rec, 9, PGIDbeg + j, RCATmapper, PJEN);

                        //LE
                        else if (j < 28) TransferRCATtoPLAY(rec, 10, PGIDbeg + j, RCATmapper, PJEN);

                        //DT
                        else if (j < 32) TransferRCATtoPLAY(rec, 11, PGIDbeg + j, RCATmapper, PJEN);

                        //RE
                        else if (j < 34) TransferRCATtoPLAY(rec, 12, PGIDbeg + j, RCATmapper, PJEN);

                        //LOLB
                        else if (j < 36) TransferRCATtoPLAY(rec, 13, PGIDbeg + j, RCATmapper, PJEN);

                        //MLB
                        else if (j < 39) TransferRCATtoPLAY(rec, 14, PGIDbeg + j, RCATmapper, PJEN);

                        //ROLB
                        else if (j < 41) TransferRCATtoPLAY(rec, 15, PGIDbeg + j, RCATmapper, PJEN);

                        //CB
                        else if (j < 46) TransferRCATtoPLAY(rec, 16, PGIDbeg + j, RCATmapper, PJEN);

                        //SS
                        else if (j < 48) TransferRCATtoPLAY(rec, 17, PGIDbeg + j, RCATmapper, PJEN);

                        //FS
                        else if (j < 50) TransferRCATtoPLAY(rec, 18, PGIDbeg + j, RCATmapper, PJEN);

                        //K
                        else if (j < 51) TransferRCATtoPLAY(rec, 19, PGIDbeg + j, RCATmapper, PJEN);

                        //P
                        else if (j < 52) TransferRCATtoPLAY(rec, 20, PGIDbeg + j, RCATmapper, PJEN);

                        else TransferRCATtoPLAY(rec, rand.Next(0, 21), PGIDbeg + j, RCATmapper, PJEN);

                        //randomizes the attributes from team overall
                        RandomizeAttribute("PLAY", rec, rating + TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PYER", rec));


                        rec++;
                    }

                    //Finish team and perform step counter
                    progressBar1.PerformStep();
                }   
            }
                   

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Fantasy Players Created!");

            RecalculateOverall();
            RandomizeRecruitFace("PLAY");
            RecalculateBMI("PLAY");
            RecalculateQBTendencies();
            CalculateTeamRatings(tableName);

            MessageBox.Show("Fantasy Roster Generation is complete!");

        }

        private int GetFantasyTeamRating(List<List<String>> teamData, int TGID)
        {
            int value = 0;

            for(int i = 0; i < teamData.Count; i++)
            {
                if (teamData[i][0] == Convert.ToString(TGID))
                {
                    return Convert.ToInt32(teamData[i][2]);
                }
            }

            return value;
        }

        //Transfers RCAT to PLAY field
        private void TransferRCATtoPLAY(int rec, int ppos, int PGID, List<List<string>> map, List<List<int>> PJEN)
        {
            bool x = true;
            while (x)
            {
                int r = rand.Next(0, RCAT.Count);
                if (RCAT[r][45] == ppos)
                {
                    for (int i = 0; i < map.Count; i++)
                    {
                        int RCATcol = Convert.ToInt32(map[i][0]); //finds the column number that the RCAT attribute value lives in
                        string field = map[i][1]; //finds the name of the attribute

                        TDB.NewfieldValue(dbIndex, "PLAY", field, rec, Convert.ToString(RCAT[r][RCATcol]));
                    }

                    string redshirt = "0";
                    if (rand.Next(0, 3) > 2) redshirt = "2";

                    TDB.NewfieldValue(dbIndex, "PLAY", "RCHD", rec, Convert.ToString(rand.Next(0,12864))); //hometown
                    TDB.NewfieldValue(dbIndex, "PLAY", "PGID", rec, Convert.ToString(PGID)); //player id
                    TDB.NewfieldValue(dbIndex, "PLAY", "PHPD", rec, "0"); //PHPD
                    TDB.NewfieldValue(dbIndex, "PLAY", "PRSD", rec, redshirt); //Redshirt
                    TDB.NewfieldValue(dbIndex, "PLAY", "PLMG", rec, "0"); //Mouthguard
                    TDB.NewfieldValue(dbIndex, "PLAY", "PFGM", rec, "0"); //face shape (to be calculated later)
                    TDB.NewfieldValue(dbIndex, "PLAY", "PJEN", rec, Convert.ToString(ChooseJerseyNumber(ppos, PJEN))); //jersey num
                    TDB.NewfieldValue(dbIndex, "PLAY", "PTEN", rec, "0"); //tendency (to be calculated later)
                    TDB.NewfieldValue(dbIndex, "PLAY", "PFMP", rec, "0"); //face (to be calculated later)
                    TDB.NewfieldValue(dbIndex, "PLAY", "PIMP", rec, Convert.ToString(rand.Next(0,32))); //importance (to be re-calculated later)
                    TDB.NewfieldValue(dbIndex, "PLAY", "PTYP", rec, "0"); //player type (graduation/nfl,etc)
                    TDB.NewfieldValue(dbIndex, "PLAY", "PYER", rec, Convert.ToString(rand.Next(0,4))); //year/class
                    TDB.NewfieldValue(dbIndex, "PLAY", "POVR", rec, "0"); //overall, to be calculated later
                    TDB.NewfieldValue(dbIndex, "PLAY", "PSLY", rec, "0"); //PSLY
                    TDB.NewfieldValue(dbIndex, "PLAY", "PRST", rec, "0"); //PRST

                    string FN, LN;

                    FN = FirstNames[rand.Next(0, FirstNames.Count)];
                    LN = LastNames[rand.Next(0, LastNames.Count)];

                    ImportFN_StringToInt(FN, rec, "PLAY");
                    ImportLN_StringToInt(LN, rec, "PLAY");

                    x = false;
                }
            }
        }

        //Randomize the Players to give a little bit more variety and evaluation randomness
        private void RandomizeAttribute(string FieldName, int rec, int tol)
        {
            int tolB = tol / 2;  //half the tolerance for specific attributes

            //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
            //PPOE, PINJ, PAWR

            int PBRE, PEYE, PPOE, PINJ, PAWR, PWGT, PHGT, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PIMP, PDIS;

            PHGT = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PHGT", rec));
            PWGT = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PWGT", rec));
            PAWR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PAWR", rec));

            PTHA = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTHA", rec));
            PSTA = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSTA", rec));
            PKAC = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PKAC", rec));
            PACC = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PACC", rec));
            PSPD = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSPD", rec));
            PCTH = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PCTH", rec));
            PAGI = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PAGI", rec));
            PTAK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTAK", rec));
            PPBK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PPBK", rec));
            PRBK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PRBK", rec));
            PBTK = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PBTK", rec));
            PTHP = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PTHP", rec));
            PJMP = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PJMP", rec));
            PCAR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PCAR", rec));
            PKPR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PKPR", rec));
            PSTR = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PSTR", rec));
            PDIS = Convert.ToInt32(TDB.FieldValue(dbIndex, FieldName, "PDIS", rec));

            PBRE = rand.Next(0, 2);
            PEYE = rand.Next(0, 2);
            PHGT += rand.Next(-1, 2);
            PWGT += rand.Next(-8, 9);
            if (PWGT < 0) PWGT = 0;
            if (PWGT > 340) PWGT = 340;
            if (PHGT > 82) PHGT = 82;
            if (PHGT < 0) PHGT = 0;

            PPOE = rand.Next(1, 30);
            PINJ = rand.Next(1, 30);
            PIMP = rand.Next(1, 30);
            PAWR = GetRandomPositiveAttribute(PAWR, tolB);
            PDIS = rand.Next(2, 7);

            PSTA = GetRandomPositiveAttribute(PSTA, tol);
            PKAC = GetRandomPositiveAttribute(PKAC, tol);
            PACC = GetRandomPositiveAttribute(PACC, tolB);
            PSPD = GetRandomPositiveAttribute(PSPD, tolB);
            PCTH = GetRandomPositiveAttribute(PCTH, tol);
            PAGI = GetRandomPositiveAttribute(PAGI, tolB);
            PTAK = GetRandomPositiveAttribute(PTAK, tol);
            PPBK = GetRandomPositiveAttribute(PPBK, tol);
            PRBK = GetRandomPositiveAttribute(PRBK, tol);
            PBTK = GetRandomPositiveAttribute(PBTK, tol);

            PJMP = GetRandomPositiveAttribute(PJMP, tol);
            PCAR = GetRandomPositiveAttribute(PCAR, tol);
            PKPR = GetRandomPositiveAttribute(PKPR, tol);
            PSTR = GetRandomPositiveAttribute(PSTR, tol);

            if(TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PPOS", rec) == 0) 
            {
                PTHA = GetRandomPositiveAttribute(PTHA, tol);
                PTHP = GetRandomPositiveAttribute(PTHP, tol);
            }


            TDB.NewfieldValue(dbIndex, FieldName, "PBRE", rec, Convert.ToString(PBRE));
            TDB.NewfieldValue(dbIndex, FieldName, "PEYE", rec, Convert.ToString(PEYE));
            TDB.NewfieldValue(dbIndex, FieldName, "PPOE", rec, Convert.ToString(PPOE));
            TDB.NewfieldValue(dbIndex, FieldName, "PINJ", rec, Convert.ToString(PINJ));
            TDB.NewfieldValue(dbIndex, FieldName, "PAWR", rec, Convert.ToString(PAWR));
            TDB.NewfieldValue(dbIndex, FieldName, "PHGT", rec, Convert.ToString(PHGT));
            TDB.NewfieldValue(dbIndex, FieldName, "PWGT", rec, Convert.ToString(PWGT));


            TDB.NewfieldValue(dbIndex, FieldName, "PTHA", rec, Convert.ToString(PTHA));
            TDB.NewfieldValue(dbIndex, FieldName, "PSTA", rec, Convert.ToString(PSTA));
            TDB.NewfieldValue(dbIndex, FieldName, "PKAC", rec, Convert.ToString(PKAC));
            TDB.NewfieldValue(dbIndex, FieldName, "PACC", rec, Convert.ToString(PACC));
            TDB.NewfieldValue(dbIndex, FieldName, "PSPD", rec, Convert.ToString(PSPD));
            TDB.NewfieldValue(dbIndex, FieldName, "PCTH", rec, Convert.ToString(PCTH));
            TDB.NewfieldValue(dbIndex, FieldName, "PAGI", rec, Convert.ToString(PAGI));
            TDB.NewfieldValue(dbIndex, FieldName, "PTAK", rec, Convert.ToString(PTAK));
            TDB.NewfieldValue(dbIndex, FieldName, "PPBK", rec, Convert.ToString(PPBK));
            TDB.NewfieldValue(dbIndex, FieldName, "PRBK", rec, Convert.ToString(PRBK));
            TDB.NewfieldValue(dbIndex, FieldName, "PBTK", rec, Convert.ToString(PBTK));
            TDB.NewfieldValue(dbIndex, FieldName, "PTHP", rec, Convert.ToString(PTHP));
            TDB.NewfieldValue(dbIndex, FieldName, "PJMP", rec, Convert.ToString(PJMP));
            TDB.NewfieldValue(dbIndex, FieldName, "PCAR", rec, Convert.ToString(PCAR));
            TDB.NewfieldValue(dbIndex, FieldName, "PKPR", rec, Convert.ToString(PKPR));
            TDB.NewfieldValue(dbIndex, FieldName, "PSTR", rec, Convert.ToString(PSTR));
            TDB.NewfieldValue(dbIndex, FieldName, "PIMP", rec, Convert.ToString(PIMP));
            TDB.NewfieldValue(dbIndex, FieldName, "PDIS", rec, Convert.ToString(PDIS));
        }

        private int ChooseJerseyNumber(int PPOS, List<List<int>> PJEN)
        {
            int jersey = 99;

            for(int i = 0; i < PJEN.Count; i++)
            {
                if (PJEN[i][0] == PPOS)
                {
                    return rand.Next(PJEN[i][1], PJEN[i][2]+1);
                }
            }

            return jersey;
        }
        #endregion

        //Depth Chart Maker
        #region Depth Chart Maker

        private void DepthChartMaker(string tableName)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;

            //clear DCHT
            for (int i = TDB.TableRecordCount(dbIndex, "DCHT"); i != -1; i--)
            {
                TDB.TDBTableRecordRemove(dbIndex, "DCHT", i);
            }


            int count;
            int rec = 0;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "tableName"); i++)
            {
                if (TDYN || TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TTYP", i) == 0)
                {
                    int TOID = TDB.TDBFieldGetValueAsInteger(dbIndex, "tableName", "TOID", i);
                    int PGIDbeg = TOID * 70;
                    int PGIDend = PGIDbeg + 69;
                    count = 0;
                    List<List<int>> roster = new List<List<int>>();

                    for (int j = 0; j < TDB.TableRecordCount(dbIndex, "PLAY"); j++)
                    {
                        int PGID = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PGID", j);

                        if (PGID >= PGIDbeg && PGID <= PGIDend)
                        {
                            int POVR = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "POVR", j);
                            int PPOS = TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PPOS", j);

                            List<int> player = new List<int>();
                            roster.Add(player);
                            roster[count].Add(j);
                            roster[count].Add(PGID);
                            roster[count].Add(PPOS);
                            count++;
                        }
                    }
                    //roster.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

                    //Sort Depth Chart  KR = 21 PR = 22 KOS = 23 LS = 24

                    //QBs
                    rec = AddDCHTrecord(rec, 0, 3, roster);
                    //RBs
                    rec = AddDCHTrecord(rec, 1, 4, roster);
                    //FBs
                    rec = AddDCHTrecord(rec, 2, 3, roster);
                    //WRs
                    rec = AddDCHTrecord(rec, 3, 6, roster);
                    //TEs
                    rec = AddDCHTrecord(rec, 4, 3, roster);
                    //LTs
                    rec = AddDCHTrecord(rec, 5, 3, roster);
                    //LGs
                    rec = AddDCHTrecord(rec, 6, 3, roster);
                    //Cs
                    rec = AddDCHTrecord(rec, 7, 3, roster);
                    //RG
                    rec = AddDCHTrecord(rec, 8, 3, roster);
                    //RTs
                    rec = AddDCHTrecord(rec, 9, 3, roster);
                    //LEs
                    rec = AddDCHTrecord(rec, 10, 3, roster);
                    //RE
                    rec = AddDCHTrecord(rec, 11, 3, roster);
                    //DT
                    rec = AddDCHTrecord(rec, 12, 5, roster);
                    //LOLBs
                    rec = AddDCHTrecord(rec, 13, 3, roster);
                    //MLBs
                    rec = AddDCHTrecord(rec, 14, 4, roster);
                    //ROLBs
                    rec = AddDCHTrecord(rec, 15, 3, roster);
                    //CBs
                    rec = AddDCHTrecord(rec, 16, 5, roster);
                    //SSs
                    rec = AddDCHTrecord(rec, 17, 3, roster);
                    //FSs
                    rec = AddDCHTrecord(rec, 18, 3, roster);
                    //Ks
                    rec = AddDCHTrecord(rec, 19, 3, roster);
                    //Ps
                    rec = AddDCHTrecord(rec, 20, 3, roster);
                    //KRs
                    rec = AddDCHTrecord(rec, 21, 5, roster);
                    //PRs
                    rec = AddDCHTrecord(rec, 22, 5, roster);
                    //KOSs
                    rec = AddDCHTrecord(rec, 23, 3, roster);
                    //LSs
                    rec = AddDCHTrecord(rec, 24, 3, roster);

                    progressBar1.PerformStep();

                }
            }

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Depth Charts are complete!");
        }

        private int AddDCHTrecord(int rec, int ppos, int depthCount, List<List<int>> roster)
        {
            //Determine Position Ratings and sort by Position Overall Rating
            List<List<int>> PosRating = new List<List<int>>();
            int rating = 0;

            for(int k = 0; k < roster.Count; k++)
            {
                if(ppos <= 20)  rating = CalculatePositionRating(roster[k][0], ppos);
                else if (ppos == 21) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 22) rating = CalculatePositionRating(roster[k][0], 3);
                else if (ppos == 23) rating = CalculatePositionRating(roster[k][0], 19);
                else if (ppos == 24) rating = CalculatePositionRating(roster[k][0], 5);
                PosRating.Add(new List<int>());
                if (roster[k][2] == ppos) rating += 15;
                PosRating[k].Add(rating);
                PosRating[k].Add(roster[k][1]);
                PosRating[k].Add(roster[k][2]);

            }

            //sort by rating
            PosRating.Sort((player1, player2) => player2[0].CompareTo(player1[0]));

            int count = 0;
            int i = 0;
            while (count < depthCount)
            {
                TDB.TDBTableRecordAdd(dbIndex, "DCHT", false);

                if (ppos > 20 || !IsStarter(PosRating[i][1])) 
                {
                    int pgid = PosRating[i][1];
                    TDB.NewfieldValue(dbIndex, "DCHT", "PGID", rec, Convert.ToString(pgid));
                    TDB.NewfieldValue(dbIndex, "DCHT", "PPOS", rec, Convert.ToString(ppos));
                    TDB.NewfieldValue(dbIndex, "DCHT", "ddep", rec, Convert.ToString(count));
                    count++;
                    rec++;
                }
                i++;
            }

            return rec;
        }

        private bool IsStarter(int pgid)
        {
            for(int i = 0; i < TDB.TableRecordCount(dbIndex, "DCHT"); i++) {
                if (TDB.TDBFieldGetValueAsInteger(dbIndex, "DCHT", "PGID", i) == pgid && TDB.TDBFieldGetValueAsInteger(dbIndex, "DCHT", "ddep", i) == 0) return true;
            }
            return false;
        }
        #endregion


        //Fill Rosters
        private void FillRosters(string tableName)
        {
            //Setup
            CreateRCATtable();
            CreateFirstNamesDB();
            CreateLastNamesDB();
            List<List<int>> PJEN = CreateJerseyNumberDB();

            List<List<string>> RCATmapper = new List<List<string>>();
            RCATmapper = CreateStringListfromCSV(@"resources\RCAT-MAPPER.csv");

            TdbTableProperties TableProps = new TdbTableProperties();
            TableProps.Name = new string((char)0, 5);

            SelectedTableIndex = TDB.TableIndex(dbIndex, "PLAY");
            // Get Tableprops based on the selected index
            TDB.TDBTableGetProperties(dbIndex, SelectedTableIndex, ref TableProps);


            int recCounter = TDB.TableRecordCount(dbIndex, "PLAY");
            int maxRecords = TableProps.Capacity;
            int created = 0;

            //Create a list of PGIDs in the database
            //bool[] rosters = new bool[511*70];
            List<int> rosters = new List<int>();
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "PLAY"); i++)
            {
                rosters.Add(TDB.TDBFieldGetValueAsInteger(dbIndex, "PLAY", "PGID", i));
            }


            //Setup Progress bar
            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, tableName);
            progressBar1.Step = 1;
            progressBar1.Value = 0;

            //Go through each team and find missing PGID
            for (int i = 0; i < TDB.TableRecordCount(dbIndex, tableName); i++)
            {
                if(TDYN || TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TTYP", i) == 0)
                {
                    int tgid = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "TOID", i);
                    int pgidSTART = tgid * 70;
                    int pgidEND = pgidSTART + 70;

                    for (int j = pgidSTART ; j < pgidEND  ; j++ )
                    {
                        if (!rosters.Contains(j) && recCounter < maxRecords) 
                        {
                            TDB.TDBTableRecordAdd(dbIndex, "PLAY", false);
                            TransferRCATtoPLAY(recCounter, rand.Next(0, 21), j, RCATmapper, PJEN);
                            RandomizePlayerFace("PLAY", recCounter);

                            recCounter++;
                            created++;
                        }
                    }
                }
                progressBar1.PerformStep();
            }

            RecalculateBMI("PLAY");
            RecalculateOverall();
            RecalculateQBTendencies();

            progressBar1.Visible = false;
            progressBar1.Value = 0;
            MessageBox.Show("Team Roster Filled in! " + created + " players created!");
        }

        //Randomizes a specific player face based on record, i
        private void RandomizePlayerFace(string tableName, int i)
        {
            //Randomizes Face Shape (PGFM)
            int shape = rand.Next(0, 16);
            TDB.NewfieldValue(dbIndex, tableName, "PFGM", i, Convert.ToString(shape));

            //Finds current skin tone and randomizes within it's Light/Medium/Dark general tone (PSKI)
            int skin = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "PSKI", i);
            if (skin <= 2) rand.Next(0, 3);
            else if (skin <= 6) rand.Next(3, 7);
            else rand.Next(8, 8);

            TDB.NewfieldValue(dbIndex, tableName, "PSKI", i, Convert.ToString(skin));

            //Randomizes Face Type based on new Skin Type
            int face = TDB.TDBFieldGetValueAsInteger(dbIndex, tableName, "PSKI", i) * 8 + rand.Next(0, 8);
            TDB.NewfieldValue(dbIndex, tableName, "PFMP", i, Convert.ToString(face));
        }

    }
}
