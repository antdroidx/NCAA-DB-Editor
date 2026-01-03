namespace DB_EDITOR
{
    partial class RosterViz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            UpdateRosterVizBtn = new Button();
            progressBar1 = new ProgressBar();
            rosterChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)rosterChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // UpdateRosterVizBtn
            // 
            UpdateRosterVizBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            UpdateRosterVizBtn.BackColor = Color.PaleTurquoise;
            UpdateRosterVizBtn.Location = new Point(12, 10);
            UpdateRosterVizBtn.Name = "UpdateRosterVizBtn";
            UpdateRosterVizBtn.Size = new Size(75, 28);
            UpdateRosterVizBtn.TabIndex = 1;
            UpdateRosterVizBtn.Text = "Update";
            UpdateRosterVizBtn.UseVisualStyleBackColor = false;
            UpdateRosterVizBtn.Click += UpdateRosterVizBtn_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            progressBar1.Location = new Point(97, 9);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(718, 28);
            progressBar1.TabIndex = 2;
            // 
            // rosterChart
            // 
            rosterChart.BackColor = Color.Gainsboro;
            chartArea1.Name = "ChartArea1";
            rosterChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            rosterChart.Legends.Add(legend1);
            rosterChart.Location = new Point(12, 12);
            rosterChart.Name = "rosterChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            rosterChart.Series.Add(series1);
            rosterChart.Size = new Size(1160, 649);
            rosterChart.TabIndex = 0;
            rosterChart.Text = "chart1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(rosterChart);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(progressBar1);
            splitContainer1.Panel2.Controls.Add(UpdateRosterVizBtn);
            splitContainer1.Size = new Size(1184, 711);
            splitContainer1.SplitterDistance = 664;
            splitContainer1.TabIndex = 3;
            // 
            // RosterViz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 711);
            Controls.Add(splitContainer1);
            Name = "RosterViz";
            Text = "Roster Visualizer";
            ((System.ComponentModel.ISupportInitialize)rosterChart).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button UpdateRosterVizBtn;
        private ProgressBar progressBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart rosterChart;
        private SplitContainer splitContainer1;
    }
}