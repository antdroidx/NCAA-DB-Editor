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


    }
}
