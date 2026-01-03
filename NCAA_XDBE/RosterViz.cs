using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DB_EDITOR
{
    public partial class RosterViz : Form
    {
        MainEditor main;
        Random rand = new Random();


        public RosterViz(MainEditor parent)
        {
            main = parent;
            InitializeComponent();
            BuildRosterChart();
        }

        private void BuildRosterChart()
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

            StartProgressBar(main.GetTableRecCount("PLAY"));
            // Collect ratings from PLAY table (convert to display rating)
            for (int i = 0; i < main.GetTableRecCount("PLAY"); i++)
            {
                int ppos = main.GetDBValueInt("PLAY", "PPOS", i);
                if (ppos < 0 || ppos >= positions.Length) continue; // guard
                int overall = main.ConvertRating(main.GetDBValueInt("PLAY", "POVR", i));
                ratingsData[ppos].Add(overall);
                ProgressBarStep();
            }
            EndProgressBar();

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
                int baseSize = 5;
                int size;
                if (count <= 1) size = baseSize;
                else size = Math.Min(40, baseSize + (int)Math.Round(Math.Log(count) * 6)); // logarithmic growth, capped

                pt.MarkerSize = size;

                // Keep interactive tooltip so users still see counts on hover.
                pt.ToolTip = $"Pos: {positions[x]}\nRating: {y}\nCount: {count}";
            }

            // Make it fill nicely
            rosterChart.Dock = DockStyle.Fill;
            area.AxisX.LabelStyle.Angle = -45; // optional, if labels get crowded
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

    }
}
