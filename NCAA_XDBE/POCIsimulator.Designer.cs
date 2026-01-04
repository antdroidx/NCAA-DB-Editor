namespace DB_EDITOR
{
    partial class POCIsimulator
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            label296 = new Label();
            POCIGridView = new DataGridView();
            PPOS = new DataGridViewTextBoxColumn();
            PLDH = new DataGridViewTextBoxColumn();
            PLDL = new DataGridViewTextBoxColumn();
            AWWT = new DataGridViewTextBoxColumn();
            SPWT = new DataGridViewTextBoxColumn();
            AGWT = new DataGridViewTextBoxColumn();
            ACWT = new DataGridViewTextBoxColumn();
            JUWT = new DataGridViewTextBoxColumn();
            STWT = new DataGridViewTextBoxColumn();
            TAWT = new DataGridViewTextBoxColumn();
            TPWT = new DataGridViewTextBoxColumn();
            CAWT = new DataGridViewTextBoxColumn();
            BTWT = new DataGridViewTextBoxColumn();
            CTWT = new DataGridViewTextBoxColumn();
            PBWT = new DataGridViewTextBoxColumn();
            RBWT = new DataGridViewTextBoxColumn();
            TKWT = new DataGridViewTextBoxColumn();
            KAWT = new DataGridViewTextBoxColumn();
            KPWT = new DataGridViewTextBoxColumn();
            POCI_Total = new DataGridViewTextBoxColumn();
            POCIsimUpdatebtn = new Button();
            ((System.ComponentModel.ISupportInitialize)POCIGridView).BeginInit();
            SuspendLayout();
            // 
            // label296
            // 
            label296.AutoSize = true;
            label296.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label296.Location = new Point(9, 12);
            label296.Name = "label296";
            label296.Size = new Size(355, 20);
            label296.TabIndex = 91;
            label296.Text = "Player Overall Rating Weight Edit Simulator";
            // 
            // POCIGridView
            // 
            POCIGridView.AllowUserToAddRows = false;
            POCIGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(224, 224, 224);
            POCIGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            POCIGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.LightSkyBlue;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            POCIGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            POCIGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            POCIGridView.Columns.AddRange(new DataGridViewColumn[] { PPOS, PLDH, PLDL, AWWT, SPWT, AGWT, ACWT, JUWT, STWT, TAWT, TPWT, CAWT, BTWT, CTWT, PBWT, RBWT, TKWT, KAWT, KPWT, POCI_Total });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            POCIGridView.DefaultCellStyle = dataGridViewCellStyle8;
            POCIGridView.EnableHeadersVisualStyles = false;
            POCIGridView.Location = new Point(12, 38);
            POCIGridView.Name = "POCIGridView";
            POCIGridView.RowHeadersVisible = false;
            POCIGridView.ScrollBars = ScrollBars.Vertical;
            POCIGridView.Size = new Size(1136, 573);
            POCIGridView.TabIndex = 90;
            POCIGridView.CellValueChanged += POCIGridView_CellValueChanged_1;
            // 
            // PPOS
            // 
            PPOS.HeaderText = "Position";
            PPOS.Name = "PPOS";
            PPOS.ReadOnly = true;
            // 
            // PLDH
            // 
            PLDH.HeaderText = "Desired High";
            PLDH.Name = "PLDH";
            // 
            // PLDL
            // 
            PLDL.HeaderText = "Desired Low";
            PLDL.Name = "PLDL";
            // 
            // AWWT
            // 
            AWWT.HeaderText = "Awareness";
            AWWT.Name = "AWWT";
            // 
            // SPWT
            // 
            SPWT.HeaderText = "Speed";
            SPWT.Name = "SPWT";
            // 
            // AGWT
            // 
            AGWT.HeaderText = "Agility";
            AGWT.Name = "AGWT";
            // 
            // ACWT
            // 
            ACWT.HeaderText = "Acceleration";
            ACWT.Name = "ACWT";
            // 
            // JUWT
            // 
            JUWT.HeaderText = "Jumping";
            JUWT.Name = "JUWT";
            // 
            // STWT
            // 
            STWT.HeaderText = "Strength";
            STWT.Name = "STWT";
            // 
            // TAWT
            // 
            TAWT.HeaderText = "Throw Accuracy";
            TAWT.Name = "TAWT";
            // 
            // TPWT
            // 
            TPWT.HeaderText = "Throw Power";
            TPWT.Name = "TPWT";
            // 
            // CAWT
            // 
            CAWT.HeaderText = "Ball Carry";
            CAWT.Name = "CAWT";
            // 
            // BTWT
            // 
            BTWT.HeaderText = "Break Tackles";
            BTWT.Name = "BTWT";
            // 
            // CTWT
            // 
            CTWT.HeaderText = "Catching";
            CTWT.Name = "CTWT";
            // 
            // PBWT
            // 
            PBWT.HeaderText = "Pass Block";
            PBWT.Name = "PBWT";
            // 
            // RBWT
            // 
            RBWT.HeaderText = "Run Block";
            RBWT.Name = "RBWT";
            // 
            // TKWT
            // 
            TKWT.HeaderText = "Tackling";
            TKWT.Name = "TKWT";
            // 
            // KAWT
            // 
            KAWT.HeaderText = "Kick Accuracy";
            KAWT.Name = "KAWT";
            // 
            // KPWT
            // 
            KPWT.HeaderText = "Kick Power";
            KPWT.Name = "KPWT";
            // 
            // POCI_Total
            // 
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(64, 64, 64);
            POCI_Total.DefaultCellStyle = dataGridViewCellStyle7;
            POCI_Total.HeaderText = "Total Weight Value";
            POCI_Total.Name = "POCI_Total";
            POCI_Total.ReadOnly = true;
            // 
            // POCIsimUpdatebtn
            // 
            POCIsimUpdatebtn.BackColor = Color.IndianRed;
            POCIsimUpdatebtn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            POCIsimUpdatebtn.ForeColor = SystemColors.Control;
            POCIsimUpdatebtn.Location = new Point(1059, 4);
            POCIsimUpdatebtn.Name = "POCIsimUpdatebtn";
            POCIsimUpdatebtn.Size = new Size(86, 28);
            POCIsimUpdatebtn.TabIndex = 89;
            POCIsimUpdatebtn.Text = "Test DB";
            POCIsimUpdatebtn.UseVisualStyleBackColor = false;
            POCIsimUpdatebtn.Click += POCIsimUpdatebtn_Click;
            // 
            // POCIsimulator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 624);
            Controls.Add(label296);
            Controls.Add(POCIGridView);
            Controls.Add(POCIsimUpdatebtn);
            Name = "POCIsimulator";
            Text = "POCI Simulator";
            ((System.ComponentModel.ISupportInitialize)POCIGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label296;
        private DataGridView POCIGridView;
        private DataGridViewTextBoxColumn PPOS;
        private DataGridViewTextBoxColumn PLDH;
        private DataGridViewTextBoxColumn PLDL;
        private DataGridViewTextBoxColumn AWWT;
        private DataGridViewTextBoxColumn SPWT;
        private DataGridViewTextBoxColumn AGWT;
        private DataGridViewTextBoxColumn ACWT;
        private DataGridViewTextBoxColumn JUWT;
        private DataGridViewTextBoxColumn STWT;
        private DataGridViewTextBoxColumn TAWT;
        private DataGridViewTextBoxColumn TPWT;
        private DataGridViewTextBoxColumn CAWT;
        private DataGridViewTextBoxColumn BTWT;
        private DataGridViewTextBoxColumn CTWT;
        private DataGridViewTextBoxColumn PBWT;
        private DataGridViewTextBoxColumn RBWT;
        private DataGridViewTextBoxColumn TKWT;
        private DataGridViewTextBoxColumn KAWT;
        private DataGridViewTextBoxColumn KPWT;
        private DataGridViewTextBoxColumn POCI_Total;
        private Button POCIsimUpdatebtn;
    }
}