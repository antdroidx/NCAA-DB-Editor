namespace DB_EDITOR
{
    partial class PortalBox
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            portalDraftView = new DataGridView();
            btnOffer = new Button();
            btnDecline = new Button();
            label1 = new Label();
            lblPositionName = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            currentRosterView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)portalDraftView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentRosterView).BeginInit();
            SuspendLayout();
            // 
            // portalDraftView
            // 
            portalDraftView.AllowUserToAddRows = false;
            portalDraftView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.ControlLightLight;
            portalDraftView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            portalDraftView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            portalDraftView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            portalDraftView.Columns.AddRange(new DataGridViewColumn[] { Column1, Column7, Column2, Column3, Column4, Column5, Column6 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            portalDraftView.DefaultCellStyle = dataGridViewCellStyle2;
            portalDraftView.Location = new Point(12, 37);
            portalDraftView.MultiSelect = false;
            portalDraftView.Name = "portalDraftView";
            portalDraftView.ReadOnly = true;
            portalDraftView.RowHeadersVisible = false;
            portalDraftView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            portalDraftView.Size = new Size(582, 205);
            portalDraftView.TabIndex = 0;
            // 
            // btnOffer
            // 
            btnOffer.BackColor = Color.PaleTurquoise;
            btnOffer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOffer.Location = new Point(616, 181);
            btnOffer.Name = "btnOffer";
            btnOffer.Size = new Size(111, 61);
            btnOffer.TabIndex = 1;
            btnOffer.Text = "Offer Scholarship";
            btnOffer.UseVisualStyleBackColor = false;
            btnOffer.Click += btnOffer_Click;
            // 
            // btnDecline
            // 
            btnDecline.BackColor = Color.IndianRed;
            btnDecline.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDecline.Location = new Point(616, 377);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(111, 61);
            btnDecline.TabIndex = 2;
            btnDecline.Text = "Decline Position Selection";
            btnDecline.UseVisualStyleBackColor = false;
            btnDecline.Click += btnDecline_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(310, 21);
            label1.TabIndex = 3;
            label1.Text = "Spring Portal - Transfer Portal Selection";
            // 
            // lblPositionName
            // 
            lblPositionName.AutoSize = true;
            lblPositionName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPositionName.Location = new Point(616, 9);
            lblPositionName.Name = "lblPositionName";
            lblPositionName.Size = new Size(81, 21);
            lblPositionName.TabIndex = 4;
            lblPositionName.Text = "Position: ";
            // 
            // Column1
            // 
            Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column1.HeaderText = "Player Name";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.HeaderText = "Team";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 61;
            // 
            // Column2
            // 
            Column2.HeaderText = "Year";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 54;
            // 
            // Column3
            // 
            Column3.HeaderText = "Rating";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 66;
            // 
            // Column4
            // 
            Column4.HeaderText = "Height";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 68;
            // 
            // Column5
            // 
            Column5.HeaderText = "Weight";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 70;
            // 
            // Column6
            // 
            Column6.HeaderText = "Pos";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 51;
            // 
            // currentRosterView
            // 
            currentRosterView.AllowUserToAddRows = false;
            currentRosterView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = SystemColors.ControlLightLight;
            currentRosterView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            currentRosterView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            currentRosterView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currentRosterView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            currentRosterView.DefaultCellStyle = dataGridViewCellStyle4;
            currentRosterView.Location = new Point(12, 271);
            currentRosterView.MultiSelect = false;
            currentRosterView.Name = "currentRosterView";
            currentRosterView.ReadOnly = true;
            currentRosterView.RowHeadersVisible = false;
            currentRosterView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            currentRosterView.Size = new Size(582, 167);
            currentRosterView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.HeaderText = "Player Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Team";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 61;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Year";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 54;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Rating";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 66;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Height";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 68;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Weight";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 70;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Pos";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 51;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 247);
            label2.Name = "label2";
            label2.Size = new Size(205, 21);
            label2.TabIndex = 6;
            label2.Text = "Current Roster @ Position";
            // 
            // PortalBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(741, 450);
            Controls.Add(label2);
            Controls.Add(currentRosterView);
            Controls.Add(lblPositionName);
            Controls.Add(label1);
            Controls.Add(btnDecline);
            Controls.Add(btnOffer);
            Controls.Add(portalDraftView);
            Name = "PortalBox";
            Text = "Spring Portal - Transfer Proposals";
            ((System.ComponentModel.ISupportInitialize)portalDraftView).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentRosterView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView portalDraftView;
        private Button btnOffer;
        private Button btnDecline;
        private Label label1;
        private Label lblPositionName;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridView currentRosterView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private Label label2;
    }
}