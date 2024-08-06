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
        private void CalculateTYDNRatings()
        {

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = TDB.TableRecordCount(dbIndex, "TYDN");
            progressBar1.Step = 1;


            int rating, count;
            int bonus = 3;

            for (int i = 0; i < TDB.TableRecordCount(dbIndex, "TDYN"); i++)
            {
                int TOID = TDB.TDBFieldGetValueAsInteger(dbIndex, "TDYN", "TOID", i);
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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRDB", i, Convert.ToString(rating));


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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRLB", i, Convert.ToString(rating));



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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRQB", i, Convert.ToString(rating));


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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRRB", i, Convert.ToString(rating));

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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRDL", i, Convert.ToString(rating));

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

                TDB.NewfieldValue(dbIndex, "TYDN", "TROL", i, Convert.ToString(rating));

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

                TDB.NewfieldValue(dbIndex, "TYDN", "TWRR", i, Convert.ToString(rating));

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

                TDB.NewfieldValue(dbIndex, "TYDN", "TRST", i, Convert.ToString(rating));


                //TRDE - Defense 10 - 18, 20
                rating = (Convert.ToInt32(TDB.FieldValue(dbIndex,"TYDN","TRDB",i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TRLB", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TRDL", i))) / 3;

                TDB.NewfieldValue(dbIndex, "TYDN", "TRDE", i, Convert.ToString(rating));

                //TROF - Offense 0 - 9, 19
                rating = (Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TRQB", i))*2 + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TRRB", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TWRR", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TROL", i))) / 5;

                TDB.NewfieldValue(dbIndex, "TYDN", "TROF", i, Convert.ToString(rating));

                //TROV - Team Overall
                rating = (Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TROF", i)) + Convert.ToInt32(TDB.FieldValue(dbIndex, "TYDN", "TRDE", i)))/2;

                TDB.NewfieldValue(dbIndex, "TYDN", "TROV", i, Convert.ToString(rating));


                progressBar1.PerformStep();

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

    }
}
