using System.Windows.Forms.DataVisualization.Charting;

namespace DB_EDITOR
{

    public partial class RosterViz : Form
    {
        MainEditor main;
        POCIsimulator pociSim;
        Random rand = new Random();
        public double[,] POCIsimValues;


        public RosterViz(MainEditor parent)
        {
            main = parent;
            InitializeComponent();
            BuildRosterChart();
            LoadRosterVizTeamList();
            LoadRosterVizTypes();
        }

        private void LoadRosterVizTeamList()
        {
            rosterVizTeamBox.Items.Clear();
            rosterVizTeamBox.Items.Add("* All Teams *");

            if (main.dbIndex2 > 0)
            {
                rosterVizTeamBox.Items.Add("* Recruits + Transfers *");
                rosterVizTeamBox.Items.Add("* Recruits Only *");
            }

            List<string> teamNames = new List<string>();
            for (int i = 0; i < main.GetTableRecCount("TEAM"); i++)
            {
                if (main.GetDBValue("TEAM", "TTYP", i) == "0")
                {
                    string teamName = main.GetDBValue("TEAM", "TDNA", i);
                    teamNames.Add(teamName);
                }
            }

            teamNames.Sort();

            foreach (var name in teamNames)
            {
                rosterVizTeamBox.Items.Add(name);
            }

            rosterVizTeamBox.SelectedIndex = 0;
        }

        private void LoadRosterVizTypes()
        {
            rosterVizTypeBox.Items.Clear();


            List<string> attributeNames = new List<string>();
            //PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR
            attributeNames.AddRange(new[] { "PCAR", "PKAC", "PTHA", "PPBK", "PRBK", "PACC", "PAGI", "PTAK", "PINJ", "PKPR", "PSPD", "PTHP", "PBTK", "PCTH", "PSTR", "PJMP", "PAWR" });
            attributeNames.Sort();

            rosterVizTypeBox.Items.Add("POVR");
            foreach (var name in attributeNames)
            {
                rosterVizTypeBox.Items.Add(name);
            }

            rosterVizTypeBox.SelectedIndex = 0;
        }



        public void BuildRosterChart(bool sim = false, int tgid = -1, string ratingType = "POVR")
        {
            if (rosterVizTypeBox.SelectedIndex > 0 && !sim) ratingType = rosterVizTypeBox.SelectedItem.ToString();
            if (sim && rosterVizTeamBox.SelectedIndex > 2) rosterVizTeamBox.SelectedIndex = 0;
            else if (sim && rosterVizTeamBox.SelectedIndex > 0) rosterVizTeamBox.SelectedIndex = 2;

            // Example categories (replace with your positions)
            string[] positions = { "QB","HB","FB","WR","TE","LT","LG","C","RG","RT",
                               "LE","RE","DT","LOLB","MLB","ROLB","CB","FS","SS","K","P" };

            // Prepare buckets per position
            List<List<int>> ratingsData = new List<List<int>>();
            for (int i = 0; i < positions.Length; i++)
            {
                ratingsData.Add(new List<int>());
            }

            if (rosterVizTeamBox.SelectedIndex == 1 && main.dbIndex2 > 0)
            {
                // Recruits + Transfers
                StartProgressBar(main.GetTable2RecCount("RCPT"));
                // Collect from DB2
                for (int i = 0; i < main.GetTable2RecCount("RCPT"); i++)
                {
                    int ppos = main.GetDB2ValueInt("RCPT", "PPOS", i);
                    if (ppos < 0 || ppos >= positions.Length) continue;

                    int overall = 0;
                    if (sim)
                    {
                        // Use the simulated overall as the single value we add
                        overall = SimulateOverallByRec(i, "RCPT");
                    }
                    else
                    {
                        overall = main.ConvertRating(main.GetDB2ValueInt("RCPT", ratingType, i));
                    }

                    ratingsData[ppos].Add(overall);
                    ProgressBarStep();
                }
                EndProgressBar();
            }
            else if (rosterVizTeamBox.SelectedIndex == 2 && main.dbIndex2 > 0)
            {
                // Recruits Only
                StartProgressBar(main.GetTable2RecCount("RCPT"));
                // Collect from DB2 only
                for (int i = 0; i < main.GetTable2RecCount("RCPT"); i++)
                {
                    int ppos = main.GetDB2ValueInt("RCPT", "PPOS", i);
                    if (ppos < 0 || ppos >= positions.Length) continue;
                    if (main.GetDB2ValueInt("RCPT", "PRID", i) < 21000)
                    {
                        int overall = 0;
                        if (sim)
                        {
                            // Use the simulated overall as the single value we add
                            overall = SimulateOverallByRec(i, "RCPT");
                        }
                        else
                        {
                            overall = main.ConvertRating(main.GetDB2ValueInt("RCPT", ratingType, i));
                        }
                        ratingsData[ppos].Add(overall);
                    }
                    ProgressBarStep();
                }
                EndProgressBar();
            }
            else
            {
                StartProgressBar(main.GetTableRecCount("PLAY"));
                // Collect ratings from PLAY table (convert to display rating)
                for (int i = 0; i < main.GetTableRecCount("PLAY"); i++)
                {
                    int ppos = main.GetDBValueInt("PLAY", "PPOS", i);
                    int pgid = main.GetDBValueInt("PLAY", "PGID", i);
                    if (ppos < 0 || ppos >= positions.Length) continue;

                    int overall = 0;

                    if (sim)
                    {
                        // Use the simulated overall as the single value we add
                        overall = SimulateOverallByRec(i, "PLAY");
                    }
                    else
                    {
                        if (tgid > -1 && tgid == pgid / 70)
                        {
                            overall = main.ConvertRating(main.GetDBValueInt("PLAY", ratingType, i));
                        }
                        else if (tgid == -1 || rosterVizTeamBox.SelectedIndex == 0)
                        {
                            overall = main.ConvertRating(main.GetDBValueInt("PLAY", ratingType, i));
                        }
                    }

                    ratingsData[ppos].Add(overall);
                    ProgressBarStep();
                }
                EndProgressBar();
            }


            rosterChart.Series.Clear();
            rosterChart.ChartAreas.Clear();
            rosterChart.Titles.Clear();
            rosterChart.Legends.Clear();

            var area = new ChartArea("Area");
            rosterChart.ChartAreas.Add(area);

            // Title
            rosterChart.Titles.Add("Overall by Position");

            // Scatter style series (we will add one point per unique x,y and vary marker size)
            var s = new Series("Overall")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6,
                Color = Color.RoyalBlue
            };
            rosterChart.Series.Add(s);

            // Mean series: red square for mean value per X (position)
            var meanSeries = new Series("Mean")
            {
                ChartType = SeriesChartType.Point,
                MarkerStyle = MarkerStyle.Square,
                MarkerSize = 10,
                Color = Color.Red,
                IsVisibleInLegend = false
            };
            rosterChart.Series.Add(meanSeries);


            // Axis ranges
            area.AxisY.Minimum = 40;
            area.AxisY.Maximum = 100;
            area.AxisY.Interval = 5;

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
                int baseSize = 5;
                int size;
                if (count <= 1) size = baseSize;
                else size = Math.Min(40, baseSize + (int)Math.Round(Math.Log(count) * 6)); // logarithmic growth, capped

                pt.MarkerSize = size;

                // Keep interactive tooltip so users still see counts on hover.
                pt.ToolTip = $"Pos: {positions[x]}\nRating: {y}\nCount: {count}";
            }

            // Add mean point (red square) for each X where data exists
            for (int x = 0; x < ratingsData.Count; x++)
            {
                var bucket = ratingsData[x];
                if (bucket == null || bucket.Count == 0) continue;
                double mean = bucket.Average();
                var mIdx = meanSeries.Points.AddXY(x, mean);
                var mPt = meanSeries.Points[mIdx];
                mPt.ToolTip = $"Pos: {positions[x]}\nMean: {mean:F2}\nCount: {bucket.Count}";
                // Optionally make the mean marker stand out more:
                mPt.MarkerSize = 10;
                mPt.MarkerStyle = MarkerStyle.Square;
            }

            // Make it fill nicely
            rosterChart.Dock = DockStyle.Fill;
            area.AxisX.LabelStyle.Angle = -45; // optional, if labels get crowded
        }

        private void rosterVizTeamBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rosterVizTeamBox.SelectedIndex == 0)
            {
                BuildRosterChart();
            }
            else
            {
                string selectedTeam = rosterVizTeamBox.SelectedItem.ToString();
                int tgid = main.FindTGIDfromTeamName(selectedTeam);
                BuildRosterChart(false, tgid);
            }
        }


        private void UpdateRosterVizBtn_Click(object sender, EventArgs e)
        {
            main.RecalculateOverall(true);
            BuildRosterChart();
        }



        #region Global Progress Bar
        private void StartProgressBar(int steps)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = steps;
            progressBar1.ForeColor = Color.Red;
        }

        private void ProgressBarStep()
        {
            progressBar1.PerformStep();
        }

        private void EndProgressBar()
        {
            progressBar1.Value = 0;
            progressBar1.Visible = false;
        }

        #endregion

        #region POCI Simulator
        private void POCIsimulatorBtn_Click(object sender, EventArgs e)
        {
            // If the form isn't created or was disposed, create and show it modelessly
            if (pociSim == null || pociSim.IsDisposed)
            {
                pociSim = new POCIsimulator(main, this);
                pociSim.FormClosed += (s, args) => pociSim = null; // clear ref when closed
                pociSim.Show(this); // use __Show__ (modeless) instead of __ShowDialog__
            }
            else
            {
                // If it's already shown, bring it to front and restore if minimized
                if (pociSim.WindowState == FormWindowState.Minimized)
                    pociSim.WindowState = FormWindowState.Normal;

                pociSim.BringToFront();
                pociSim.Activate();
            }
        }

        private void RosterVizType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildRosterChart();
        }

        public int SimulateOverallByRec(int rec, string tableName)
        {
            int ppos = -1;
            double PCAR, PKAC, PTHA, PPBK, PRBK, PACC, PAGI, PTAK, PINJ, PKPR, PSPD, PTHP, PBKT, PCTH, PSTR, PJMP, PAWR;

            if (tableName == "RCPT")
            {
                ppos = Convert.ToInt32(main.GetDB2Value(tableName, "PPOS", rec));
                PCAR = Convert.ToInt32(main.GetDB2Value(tableName, "PCAR", rec)); //CAWT
                PKAC = Convert.ToInt32(main.GetDB2Value(tableName, "PKAC", rec)); //KAWT
                PTHA = Convert.ToInt32(main.GetDB2Value(tableName, "PTHA", rec)); //TAWT
                PPBK = Convert.ToInt32(main.GetDB2Value(tableName, "PPBK", rec)); //PBWT
                PRBK = Convert.ToInt32(main.GetDB2Value(tableName, "PRBK", rec)); //RBWT
                PACC = Convert.ToInt32(main.GetDB2Value(tableName, "PACC", rec)); //ACWT
                PAGI = Convert.ToInt32(main.GetDB2Value(tableName, "PAGI", rec)); //AGWT
                PTAK = Convert.ToInt32(main.GetDB2Value(tableName, "PTAK", rec)); //TKWT
                PINJ = Convert.ToInt32(main.GetDB2Value(tableName, "PINJ", rec)); //INWT
                PKPR = Convert.ToInt32(main.GetDB2Value(tableName, "PKPR", rec)); //KPWT
                PSPD = Convert.ToInt32(main.GetDB2Value(tableName, "PSPD", rec)); //SPWT
                PTHP = Convert.ToInt32(main.GetDB2Value(tableName, "PTHP", rec)); //TPWT
                PBKT = Convert.ToInt32(main.GetDB2Value(tableName, "PBTK", rec)); //BTWT
                PCTH = Convert.ToInt32(main.GetDB2Value(tableName, "PCTH", rec)); //CTWT
                PSTR = Convert.ToInt32(main.GetDB2Value(tableName, "PSTR", rec)); //STWT
                PJMP = Convert.ToInt32(main.GetDB2Value(tableName, "PJMP", rec)); //JUWT
                PAWR = Convert.ToInt32(main.GetDB2Value(tableName, "PAWR", rec)); //AWWT
            }
            else
            {
                ppos = Convert.ToInt32(main.GetDBValue(tableName, "PPOS", rec));
                PCAR = Convert.ToInt32(main.GetDBValue(tableName, "PCAR", rec)); //CAWT
                PKAC = Convert.ToInt32(main.GetDBValue(tableName, "PKAC", rec)); //KAWT
                PTHA = Convert.ToInt32(main.GetDBValue(tableName, "PTHA", rec)); //TAWT
                PPBK = Convert.ToInt32(main.GetDBValue(tableName, "PPBK", rec)); //PBWT
                PRBK = Convert.ToInt32(main.GetDBValue(tableName, "PRBK", rec)); //RBWT
                PACC = Convert.ToInt32(main.GetDBValue(tableName, "PACC", rec)); //ACWT
                PAGI = Convert.ToInt32(main.GetDBValue(tableName, "PAGI", rec)); //AGWT
                PTAK = Convert.ToInt32(main.GetDBValue(tableName, "PTAK", rec)); //TKWT
                PINJ = Convert.ToInt32(main.GetDBValue(tableName, "PINJ", rec)); //INWT
                PKPR = Convert.ToInt32(main.GetDBValue(tableName, "PKPR", rec)); //KPWT
                PSPD = Convert.ToInt32(main.GetDBValue(tableName, "PSPD", rec)); //SPWT
                PTHP = Convert.ToInt32(main.GetDBValue(tableName, "PTHP", rec)); //TPWT
                PBKT = Convert.ToInt32(main.GetDBValue(tableName, "PBTK", rec)); //BTWT
                PCTH = Convert.ToInt32(main.GetDBValue(tableName, "PCTH", rec)); //CTWT
                PSTR = Convert.ToInt32(main.GetDBValue(tableName, "PSTR", rec)); //STWT
                PJMP = Convert.ToInt32(main.GetDBValue(tableName, "PJMP", rec)); //JUWT
                PAWR = Convert.ToInt32(main.GetDBValue(tableName, "PAWR", rec)); //AWWT
            }

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

            return val;

        }

        public double CalcOVRIndividuals(int row, double val, int ppos)
        {
            double skillRating = (double)main.ConvertRating(Convert.ToInt32(val));

            //attribute rating - (PLDH + PLDL)/2 * wtPts/total Pts * (99 / (PLDH-PLDL)
            // row 20,   weight/row 21, row 22
            // 

            skillRating = (skillRating - POCIsimValues[ppos, 20]) * (POCIsimValues[ppos, row] / POCIsimValues[ppos, 21]) * POCIsimValues[ppos, 22];

            return skillRating;
        }
        #endregion



    }
}
