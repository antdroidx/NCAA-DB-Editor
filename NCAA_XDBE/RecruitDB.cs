using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
// using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_EDITOR
{
    partial class MainEditor : Form
    {
        //RCAT EDITOR
        private void StartRCATeditor()
        {
            StartRCATGlobaEditors();
        }

        #region RCAT Randomizers
        private void buttonRCATBody_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                RecalculateIndividualBodyShape(i, "RCAT");
            }

            MessageBox.Show("Body Model updates are complete!");
        }

        private void RCATAppearanceRandomizerButton_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                int handVal = rand.Next(1, 101);
                int hand = 0;
                if (handVal <= 9) hand = 1; //left handed 9% chance
                ChangeDBInt("RCAT", "PHAN", i, hand);

                RandomizeSkinTone("RCAT", i);
                RandomizePlayerHead("RCAT", i);
            }
            MessageBox.Show("Player Appearance Randomized!");

        }

        private void RCATGearRandomizerButton_Click(object sender, EventArgs e)
        {
            RandomizeAllPlayerGears("RCAT");
            MessageBox.Show("Player Gears Randomized!");
        }
        
        private void ExportRCATButton_Click(object sender, EventArgs e)
        {
            // TdbTableProperties class
            TdbTableProperties TableProps = new TdbTableProperties();

            // 4 character string, max value of 5
            StringBuilder TableName = new StringBuilder("    ", 5);

            for (int i = 0; i < TDB.TDBDatabaseGetTableCount(dbIndex); i++)
            {
                // Get the tableproperties for the given table number
                if (GetTableName(dbIndex, i) == "RCAT")
                {
                    SelectedTableName = "RCAT";
                    SelectedTableIndex = i;
                    exportToolItem.PerformClick();
                    break;
                }
            }
        }
        private void RandomizeRCATDisciplineBtn_Click(object sender, EventArgs e)
        {
            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                int x = rand.Next(2, 7);

                ChangeDBInt("RCAT", "PDIS", i, x);

                ProgressBarStep();
            }

            EndProgressBar();
            MessageBox.Show("RCAT Discipline Updates are complete!");
        }

        private void RandomizeRCATRatingsBtn_Click(object sender, EventArgs e)
        {
            StartProgressBar(GetTableRecCount("RCAT"));

            for (int rec = 0; rec < GetTableRecCount("RCAT"); rec++)
            {
                string TableName = "RCAT";
                int tolRAND = 3;  //half the tolerance for specific attributes

                //PTHA	PSTA	PKAC	PACC	PSPD	PPOE	PCTH	PAGI	PINJ	PTAK	PPBK	PRBK	PBTK	PTHP	PJMP	PCAR	PKPR	PSTR	PAWR
                //PPOE, PINJ, PAWR

                int PBRE, PEYE, PPOE, PINJ, PAWR, PTHA, PSTA, PKAC, PACC, PSPD, PCTH, PAGI, PTAK, PPBK, PRBK, PBTK, PTHP, PJMP, PCAR, PKPR, PSTR, PDIS;

                PAWR = GetDBValueInt(TableName, "PAWR", rec);

                PTHA = GetDBValueInt(TableName, "PTHA", rec);
                PSTA = GetDBValueInt(TableName, "PSTA", rec);
                PKAC = GetDBValueInt(TableName, "PKAC", rec);
                PACC = GetDBValueInt(TableName, "PACC", rec);
                PSPD = GetDBValueInt(TableName, "PSPD", rec);
                PCTH = GetDBValueInt(TableName, "PCTH", rec);
                PAGI = GetDBValueInt(TableName, "PAGI", rec);
                PTAK = GetDBValueInt(TableName, "PTAK", rec);
                PPBK = GetDBValueInt(TableName, "PPBK", rec);
                PRBK = GetDBValueInt(TableName, "PRBK", rec);
                PBTK = GetDBValueInt(TableName, "PBTK", rec);
                PTHP = GetDBValueInt(TableName, "PTHP", rec);
                PJMP = GetDBValueInt(TableName, "PJMP", rec);
                PCAR = GetDBValueInt(TableName, "PCAR", rec);
                PKPR = GetDBValueInt(TableName, "PKPR", rec);
                PSTR = GetDBValueInt(TableName, "PSTR", rec);
                PDIS = GetDBValueInt(TableName, "PDIS", rec);

                //Randomizer
                PAWR = GetRandomAttribute(PAWR, tolRAND);
                PSTA = GetRandomAttribute(PSTA, tolRAND);
                PKAC = GetRandomAttribute(PKAC, tolRAND);
                PACC = GetRandomAttribute(PACC, tolRAND);
                PSPD = GetRandomAttribute(PSPD, tolRAND);
                PCTH = GetRandomAttribute(PCTH, tolRAND);
                PAGI = GetRandomAttribute(PAGI, tolRAND);
                PTAK = GetRandomAttribute(PTAK, tolRAND);
                PPBK = GetRandomAttribute(PPBK, tolRAND);
                PRBK = GetRandomAttribute(PRBK, tolRAND);
                PBTK = GetRandomAttribute(PBTK, tolRAND);

                PJMP = GetRandomAttribute(PJMP, tolRAND);
                PCAR = GetRandomAttribute(PCAR, tolRAND);
                PKPR = GetRandomAttribute(PKPR, tolRAND);
                PSTR = GetRandomAttribute(PSTR, tolRAND);

                PPOE = rand.Next(1, 31);
                PINJ = rand.Next(1, maxRatingVal); 
                PDIS = rand.Next(2, 7);

                //Thowing Hand
                int handVal = rand.Next(1, 101);
                int hand = 0;
                if (handVal <= 9) hand = 1; //left handed 9% chance
                ChangeDBInt(TableName, "PHAN", rec, hand);

                ChangeDBInt(TableName, "PPOE", rec, PPOE);
                ChangeDBInt(TableName, "PINJ", rec, PINJ);
                ChangeDBInt(TableName, "PAWR", rec, PAWR);
                ChangeDBInt(TableName, "PTHA", rec, PTHA);
                ChangeDBInt(TableName, "PSTA", rec, PSTA);
                ChangeDBInt(TableName, "PKAC", rec, PKAC);
                ChangeDBInt(TableName, "PACC", rec, PACC);
                ChangeDBInt(TableName, "PSPD", rec, PSPD);
                ChangeDBInt(TableName, "PCTH", rec, PCTH);
                ChangeDBInt(TableName, "PAGI", rec, PAGI);
                ChangeDBInt(TableName, "PTAK", rec, PTAK);
                ChangeDBInt(TableName, "PPBK", rec, PPBK);
                ChangeDBInt(TableName, "PRBK", rec, PRBK);
                ChangeDBInt(TableName, "PBTK", rec, PBTK);
                ChangeDBInt(TableName, "PTHP", rec, PTHP);
                ChangeDBInt(TableName, "PJMP", rec, PJMP);
                ChangeDBInt(TableName, "PCAR", rec, PCAR);
                ChangeDBInt(TableName, "PKPR", rec, PKPR);
                ChangeDBInt(TableName, "PSTR", rec, PSTR);
                ChangeDBInt(TableName, "PDIS", rec, PDIS);

                ProgressBarStep();
            }

            MessageBox.Show("RCAT Ratings Randomization Complete!");
            EndProgressBar();
        }

        private void RandomizeRCATBodyBtn_Click(object sender, EventArgs e)
        {
            string TableName = "RCAT";
            for (int rec = 0; rec < GetTableRecCount("RCAT"); rec++)
            {
                int PHGT = GetDBValueInt(TableName, "PHGT", rec);
                int PWGT = GetDBValueInt(TableName, "PWGT", rec);

                PHGT += rand.Next(-2, 2);
                PWGT += rand.Next(-10, 11);

                if (PWGT < 0) PWGT = 0;
                if (PWGT > 340) PWGT = 340;
                if (PHGT > 82) PHGT = 82;
                if (PHGT < 0) PHGT = 0;

                ChangeDBInt(TableName, "PHGT", rec, PHGT);
                ChangeDBInt(TableName, "PWGT", rec, PWGT);
                RecalculateIndividualBodyShape(rec, "RCAT");

            }

            MessageBox.Show("RCAT Body Randomization Complete!");
        }

        #endregion

        #region RCAT Global Editors

        private void StartRCATGlobaEditors()
        {
            if (rcatGlobalAttBox.Items.Count > 0) return;
            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);

            rcatGlobalAttBox.Items.Clear();
            rcatMinAttBox.Items.Clear();
            rcatMaxAttBox.Items.Clear();

            foreach (List<string> a in atb)
            {
                rcatGlobalAttBox.Items.Add(a[1]);
                rcatMinAttBox.Items.Add(a[1]);
                rcatMaxAttBox.Items.Add(a[1]);
            }


            if (rcatGlobalAttPosBox.Items.Count > 0) return;

            rcatGlobalAttPosBox.Items.Clear();
            rcatMinAttPosBox.Items.Clear();
            rcatMaxAttPosBox.Items.Clear();
            rcatMinBodyPosBox.Items.Clear();
            rcatMaxBodyPosBox.Items.Clear();

            rcatGlobalAttPosBox.Items.Add("ALL");
            rcatMinAttPosBox.Items.Add("ALL");
            rcatMaxAttPosBox.Items.Add("ALL");
            rcatMinBodyPosBox.Items.Add("ALL");
            rcatMaxBodyPosBox.Items.Add("ALL");

            for (int i = 0; i < 17; i++)
            {
                rcatGlobalAttPosBox.Items.Add(GetPOSG2Name(i));
                rcatMinAttPosBox.Items.Add(GetPOSG2Name(i));
                rcatMaxAttPosBox.Items.Add(GetPOSG2Name(i));
                rcatMinBodyPosBox.Items.Add(GetPOSG2Name(i));
                rcatMaxBodyPosBox.Items.Add(GetPOSG2Name(i));
            }

            rcatGlobalAttPosBox.SelectedIndex = 0;
            rcatMinAttPosBox.SelectedIndex = 0;
            rcatMaxAttPosBox.SelectedIndex = 0;
            rcatMinBodyPosBox.SelectedIndex = 0;
            rcatMaxBodyPosBox.SelectedIndex = 0;


            rcatGlobalAttNum.Minimum = -maxRatingVal;
            rcatGlobalAttNum.Maximum = maxRatingVal;

            rcatMinAttNum.Minimum = 0;
            rcatMinAttNum.Maximum = maxRatingVal;

            rcatMaxAttNum.Minimum = 0;
            rcatMaxAttNum.Maximum = maxRatingVal;
        }


        private void rcatGlobalAttBtn_Click(object sender, EventArgs e)
        {
            if (rcatGlobalAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);

            double tol = 1;
            string attribute = atb[rcatGlobalAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(rcatGlobalAttNum.Value);
            int posg = rcatGlobalAttPosBox.SelectedIndex - 1;
            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                if (posg == -1)
                {
                    UpdateRCATAttribute(i, val, attribute, tol);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("RCAT", "PPOS", i)) == posg)
                {
                    UpdateRCATAttribute(i, val, attribute, tol);
                }

                ProgressBarStep();
            }


            string pos = "All Positions";
            if (posg != -1) pos = GetPOSG2Name(posg);

            MessageBox.Show("A change of " + val + " pts to " + attribute + " Attribute has been applied to " + pos + "!\n\nRecalculate Player Overall and Team Ratings when completed!");

            EndProgressBar();
        }

        private void rcatMinAttbtn_Click(object sender, EventArgs e)
        {
            if (rcatMinAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);
            string attribute = atb[rcatMinAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(rcatMinAttNum.Value);
            int posg = rcatMinAttPosBox.SelectedIndex - 1;

            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating < val) ChangeDBInt("RCAT", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("RCAT", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating < val) ChangeDBInt("RCAT", attribute, i, val);
                }

                ProgressBarStep();
            }

            string pos = "All Positions";
            if (posg != -1) pos = GetPOSG2Name(posg);

            MessageBox.Show("A change of " + val + " pts to " + attribute + " Attribute has been applied to " + pos + "!\n\nRecalculate Player Overall and Team Ratings when completed!");

            EndProgressBar();
        }


        private void rcatMinAttNum_ValueChanged(object sender, EventArgs e)
        {
           rcatMinAttText.Text = Convert.ToString(ConvertRating(Convert.ToInt32(rcatMinAttNum.Value)));
        }

        private void rcatMaxAttNum_ValueChanged(object sender, EventArgs e)
        {
            rcatMaxAttText.Text = Convert.ToString(ConvertRating(Convert.ToInt32(rcatMaxAttNum.Value)));

        }

        private void rcatMaxAttBtn_Click(object sender, EventArgs e)
        {
            if (rcatMaxAttBox.SelectedIndex == -1) return;

            /* Create attribute list || 0 - DB value  1 - Name */
            List<List<string>> atb = CreateStringListsFromCSV(@"resources\players\attributes.csv", true);
            string attribute = atb[rcatMaxAttBox.SelectedIndex][0];
            int val = Convert.ToInt32(rcatMaxAttNum.Value);
            int posg = rcatMaxAttPosBox.SelectedIndex - 1;

            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating > val) ChangeDBInt("RCAT", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("RCAT", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating > val) ChangeDBInt("RCAT", attribute, i, val);
                }   

                ProgressBarStep();
            }


            string pos = "All Positions";
            if (posg != -1) pos = GetPOSG2Name(posg);

            MessageBox.Show("A change of " + val + " pts to " + attribute + " Attribute has been applied to " + pos + "!\n\nRecalculate Player Overall and Team Ratings when completed!");

            EndProgressBar();
        }



        private void rcatMinBodyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rcatMinBodyBox.SelectedIndex == -1) return;
            else if (rcatMinBodyBox.SelectedIndex == 0)
            {
                rcatMinBodyNum.Minimum = 0;
                rcatMinBodyNum.Maximum = 127;
                rcatMinBodyNum.Value = 0;
            }
            else if (MinBodyType.SelectedIndex == 1)
            {
                rcatMinBodyNum.Minimum = 160;
                rcatMinBodyNum.Maximum = 160 + 255;
                rcatMinBodyNum.Value = 160;
            }
        }

        private void rcatMaxBodyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rcatMaxBodyBox.SelectedIndex == -1) return;
            else if (rcatMaxBodyBox.SelectedIndex == 0)
            {
                rcatMaxBodyNum.Minimum = 0;
                rcatMaxBodyNum.Maximum = 127;
                rcatMaxBodyNum.Value = 78;
            }
            else if (MaxBodyType.SelectedIndex == 1)
            {
                rcatMaxBodyNum.Minimum = 160;
                rcatMaxBodyNum.Maximum = 160 + 255;
                rcatMaxBodyNum.Value = 415;
            }
        }
        private void rcatMinBodyBtn_Click(object sender, EventArgs e)
        {
            if (rcatMinBodyBox.SelectedIndex == -1) return;

            int val = Convert.ToInt32(rcatMinBodyNum.Value);
            int posg = rcatMinBodyPosBox.SelectedIndex - 1;
            string attribute = "PHGT";
            if (rcatMinBodyBox.SelectedIndex == 1)
            {
                attribute = "PWGT";
                val = val - 160;
            }

            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating < val) ChangeDBInt("RCAT", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("RCAT", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating < val) ChangeDBInt("RCAT", attribute, i, val);
                }

                ProgressBarStep();
            }


            string pos = "All Positions";
            if (posg != -1) pos = GetPOSG2Name(posg);

            MessageBox.Show("A change of " + val + " to " + attribute + " has been applied to " + pos + "!\n\nRecalculate Player Overall and Team Ratings when completed!");

            EndProgressBar();
        }

        private void rcatMaxBodyBtn_Click(object sender, EventArgs e)
        {
            if (rcatMaxBodyBox.SelectedIndex == -1) return;

            int val = Convert.ToInt32(rcatMaxBodyNum.Value);
            int posg = rcatMaxBodyPosBox.SelectedIndex - 1;
            string attribute = "PHGT";
            if (rcatMaxBodyBox.SelectedIndex == 1)
            {
                attribute = "PWGT";
                val = val - 160;
            }

            StartProgressBar(GetTableRecCount("RCAT"));

            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                if (posg == -1)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating > val) ChangeDBInt("RCAT", attribute, i, val);
                }
                else if (GetPOSG2fromPPOS(GetDBValueInt("RCAT", "PPOS", i)) == posg)
                {
                    int rating = GetDBValueInt("RCAT", attribute, i);
                    if (rating > val) ChangeDBInt("RCAT", attribute, i, val);
                }

                ProgressBarStep();
            }


            string pos = "All Positions";
            if (posg != -1) pos = GetPOSG2Name(posg);

            MessageBox.Show("A change of " + val + " to " + attribute + " has been applied to " + pos + "!\n\nRecalculate Player Overall and Team Ratings when completed!");

            EndProgressBar();
        }


        private void UpdateRCATAttribute(int rec, int val, string attribute, double tol)
        {
            int rating = 0;
            if (val > 0) rating = GetDBValueInt("RCAT", attribute, rec) + rand.Next(Convert.ToInt32(tol * (double)val), val);
            else rating = GetDBValueInt("RCAT", attribute, rec) + rand.Next(val, Convert.ToInt32(tol * (double)val));

            if (rating < 0) rating = 0;
            if (rating > maxRatingVal) rating = maxRatingVal;

            ChangeDBInt("RCAT", attribute, rec, rating);
        }

        #endregion

        #region RCAT Overall Recalculation
        public int RecalculateRCATOverallByRec(int rec)
        {
            int ppos = Convert.ToInt32(GetDBValue("RCAT", "PPOS", rec));
            double PCAR = Convert.ToInt32(GetDBValue("RCAT", "PCAR", rec)); //CAWT
            double PKAC = Convert.ToInt32(GetDBValue("RCAT", "PKAC", rec)); //KAWT
            double PTHA = Convert.ToInt32(GetDBValue("RCAT", "PTHA", rec)); //TAWT
            double PPBK = Convert.ToInt32(GetDBValue("RCAT", "PPBK", rec)); //PBWT
            double PRBK = Convert.ToInt32(GetDBValue("RCAT", "PRBK", rec)); //RBWT
            double PACC = Convert.ToInt32(GetDBValue("RCAT", "PACC", rec)); //ACWT
            double PAGI = Convert.ToInt32(GetDBValue("RCAT", "PAGI", rec)); //AGWT
            double PTAK = Convert.ToInt32(GetDBValue("RCAT", "PTAK", rec)); //TKWT
            double PINJ = Convert.ToInt32(GetDBValue("RCAT", "PINJ", rec)); //INWT
            double PKPR = Convert.ToInt32(GetDBValue("RCAT", "PKPR", rec)); //KPWT
            double PSPD = Convert.ToInt32(GetDBValue("RCAT", "PSPD", rec)); //SPWT
            double PTHP = Convert.ToInt32(GetDBValue("RCAT", "PTHP", rec)); //TPWT
            double PBKT = Convert.ToInt32(GetDBValue("RCAT", "PBTK", rec)); //BTWT
            double PCTH = Convert.ToInt32(GetDBValue("RCAT", "PCTH", rec)); //CTWT
            double PSTR = Convert.ToInt32(GetDBValue("RCAT", "PSTR", rec)); //STWT
            double PJMP = Convert.ToInt32(GetDBValue("RCAT", "PJMP", rec)); //JUWT
            double PAWR = Convert.ToInt32(GetDBValue("RCAT", "PAWR", rec)); //AWWT

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
            //val = RevertRating(val);

            return val;
        }


        #endregion

        #region Visualizer

        private void btnUpdateRCATchart_Click(object sender, EventArgs e)
        {
            BuildRCATChart();
        }

        private void BuildRCATChart()
        {
            // Example categories (replace with your positions)
            string[] positions = { "QB","HB","FB","WR","TE","LT","LG","C","RG","RT",
                               "LE","RE","DT","LOLB","MLB","ROLB","CB","FS","SS","K","P" };

            // Prepare buckets per position
            List<List<int>> ratingsData = new List<List<int>>();
            for (int i = 0; i < positions.Length; i++)
            {
                ratingsData.Add(new List<int>());
            }

            StartProgressBar(GetTableRecCount("RCAT"));
            for (int i = 0; i < GetTableRecCount("RCAT"); i++)
            {
                int ppos = GetDBValueInt("RCAT", "PPOS", i);          
                int overall = RecalculateRCATOverallByRec(i);

                ratingsData[ppos].Add(overall);
                ProgressBarStep();
            }
            EndProgressBar();

            rcatChart.Series.Clear();
            rcatChart.ChartAreas.Clear();
            rcatChart.Titles.Clear();
            rcatChart.Legends.Clear();

            var area = new ChartArea("Area");
            rcatChart.ChartAreas.Add(area);

            // Title
            rcatChart.Titles.Add("Overall by Position");

            // Scatter style series (we will add one point per unique x,y and vary marker size)
            var s = new Series("Overall")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                Color = Color.RoyalBlue
            };
            rcatChart.Series.Add(s);

            // Axis ranges
            area.AxisY.Minimum = 40;
            area.AxisY.Maximum = 100;
            area.AxisY.Interval = 10;

            area.AxisX.Minimum = -0.5;
            area.AxisX.Maximum = positions.Length - 0.5;
            area.AxisX.Interval = 1;

            area.AxisX.MajorGrid.Enabled = true;
            area.AxisY.MajorGrid.Enabled = true;

            area.AxisX.CustomLabels.Clear();
            for (int i = 0; i < positions.Length; i++)
            {
                area.AxisX.CustomLabels.Add(new CustomLabel(i - 0.5, i + 0.5, positions[i], 0, LabelMarkStyle.None));
            }

            // Build a map of (x,y) -> count so same-position+rating collisions can be shown by larger markers
            var pointCounts = new Dictionary<(int x, int y), int>();
            for (int x = 0; x < ratingsData.Count; x++)
            {
                foreach (var y in ratingsData[x])
                {
                    var key = (x, y);
                    if (pointCounts.ContainsKey(key)) pointCounts[key]++;
                    else pointCounts[key] = 1;
                }
            }

            // Add unique points with marker size proportional to the count at that (x,y)
            foreach (var kv in pointCounts)
            {
                int x = kv.Key.x;
                int y = kv.Key.y;
                int count = kv.Value;

                var idx = s.Points.AddXY(x, y);
                var pt = s.Points[idx];

                // Scale marker size using a simple mapping:
                // 1 -> baseSize, 2-4 -> medium, 5+ -> larger; capped to avoid huge markers.
                int baseSize = 3;
                int size;
                if (count <= 1) size = baseSize;
                else size = Math.Min(40, baseSize + (int)Math.Round(Math.Log(count) * 6)); // logarithmic growth, capped

                pt.MarkerSize = size;

                // Keep interactive tooltip so users still see counts on hover.
                pt.ToolTip = $"Pos: {positions[x]}\nRating: {y}\nCount: {count}";
            }

            // Make it fill nicely
            rcatChart.Dock = DockStyle.Fill;
            area.AxisX.LabelStyle.Angle = -45; // optional, if labels get crowded
        }


        #endregion


    }
}
