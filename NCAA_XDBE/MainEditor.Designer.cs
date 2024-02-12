using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;

namespace DB_EDITOR
{
    partial class MainEditor
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button qbTend;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.definitionFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CSVMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tabDelimitedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableFieldOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultFieldOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingFieldOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingFieldOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableOffSeasonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tableMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exportTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAllTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exportRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRecordsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.addendumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TablePropsLabel = new System.Windows.Forms.Label();
            this.FieldsPropsLabel = new System.Windows.Forms.Label();
            this.TablePropsgroupBox = new System.Windows.Forms.GroupBox();
            this.FieldsPropsgroupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.fieldsGridView = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.TGIDtextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TDNAtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TLNAtextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.LocationcheckBox = new System.Windows.Forms.CheckBox();
            this.MascotcheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TTYPcomboBox = new System.Windows.Forms.ComboBox();
            this.TGIDlistBox = new System.Windows.Forms.ListBox();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TGIDplayerBox = new System.Windows.Forms.ComboBox();
            this.PGIDlistBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PLNAtextBox = new System.Windows.Forms.TextBox();
            this.PFNAtextBox = new System.Windows.Forms.TextBox();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.checkBoxMedRSNEXT = new System.Windows.Forms.CheckBox();
            this.labelPoaching = new System.Windows.Forms.Label();
            this.poachValue = new System.Windows.Forms.NumericUpDown();
            this.labelJobSecurity = new System.Windows.Forms.Label();
            this.jobSecurityValue = new System.Windows.Forms.NumericUpDown();
            this.buttonCarousel = new System.Windows.Forms.Button();
            this.labelSkillDrop = new System.Windows.Forms.Label();
            this.skillDrop = new System.Windows.Forms.NumericUpDown();
            this.checkBoxInjuryRatings = new System.Windows.Forms.CheckBox();
            this.buttonRandPotential = new System.Windows.Forms.Button();
            this.buttonRandomBudgets = new System.Windows.Forms.Button();
            this.increaseSpeed = new System.Windows.Forms.Button();
            this.bodyFix = new System.Windows.Forms.Button();
            this.dbToolsInfo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.coachProg = new System.Windows.Forms.Button();
            this.medRS = new System.Windows.Forms.Button();
            this.tabOffSeason = new System.Windows.Forms.TabPage();
            this.labelPolyNamesPCT = new System.Windows.Forms.Label();
            this.polyNamesPCT = new System.Windows.Forms.NumericUpDown();
            this.polyNames = new System.Windows.Forms.Button();
            this.textBoxOffSeason = new System.Windows.Forms.TextBox();
            this.textBoxOffSeasonTitle = new System.Windows.Forms.TextBox();
            this.labelIntTeams = new System.Windows.Forms.Label();
            this.removeInterestTeams = new System.Windows.Forms.NumericUpDown();
            this.buttonInterestedTeams = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.minTRPA = new System.Windows.Forms.NumericUpDown();
            this.labelMinRecPts = new System.Windows.Forms.Label();
            this.minRecPts = new System.Windows.Forms.NumericUpDown();
            this.labelRecruit = new System.Windows.Forms.Label();
            this.recruitTolerance = new System.Windows.Forms.NumericUpDown();
            this.wkonLabel = new System.Windows.Forms.Label();
            this.toleranceWalkOn = new System.Windows.Forms.NumericUpDown();
            this.buttonRandRecruits = new System.Windows.Forms.Button();
            this.buttonRandWalkOns = new System.Windows.Forms.Button();
            this.buttonMinRecruitingPts = new System.Windows.Forms.Button();
            qbTend = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.fieldMenu.SuspendLayout();
            this.TablePropsgroupBox.SuspendLayout();
            this.FieldsPropsgroupBox.SuspendLayout();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabTeams.SuspendLayout();
            this.tabPlayers.SuspendLayout();
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).BeginInit();
            this.tabOffSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polyNamesPCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).BeginInit();
            this.SuspendLayout();
            // 
            // qbTend
            // 
            qbTend.BackColor = System.Drawing.Color.SaddleBrown;
            qbTend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qbTend.ForeColor = System.Drawing.SystemColors.Control;
            qbTend.Location = new System.Drawing.Point(28, 528);
            qbTend.Name = "qbTend";
            qbTend.Size = new System.Drawing.Size(110, 80);
            qbTend.TabIndex = 6;
            qbTend.Text = "Calculate QB Tendencies";
            qbTend.UseVisualStyleBackColor = false;
            qbTend.Click += new System.EventHandler(this.qbTend_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.CSVMenuItem,
            this.optionsMenuItem,
            this.aboutMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1008, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem,
            this.closeMenuItem,
            this.toolStripSeparator1,
            this.definitionFileMenuItem,
            this.toolStripSeparator7,
            this.exitMenuItem});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::DB_EDITOR.Properties.Resources.open2;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::DB_EDITOR.Properties.Resources.save3;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveAsMenuItem.Text = "Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.saveAsMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Image = global::DB_EDITOR.Properties.Resources.close;
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.closeMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // definitionFileMenuItem
            // 
            this.definitionFileMenuItem.Image = global::DB_EDITOR.Properties.Resources.def_file;
            this.definitionFileMenuItem.Name = "definitionFileMenuItem";
            this.definitionFileMenuItem.Size = new System.Drawing.Size(148, 22);
            this.definitionFileMenuItem.Text = "Definition File";
            this.definitionFileMenuItem.Click += new System.EventHandler(this.definitionFileMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(145, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::DB_EDITOR.Properties.Resources.exit;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitToolItem_Click);
            // 
            // CSVMenuItem
            // 
            this.CSVMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolItem,
            this.importMenuItem,
            this.toolStripSeparator2,
            this.exportAllMenuItem,
            this.toolStripSeparator9,
            this.tabDelimitedMenuItem});
            this.CSVMenuItem.Name = "CSVMenuItem";
            this.CSVMenuItem.Size = new System.Drawing.Size(40, 20);
            this.CSVMenuItem.Text = "CSV";
            // 
            // exportToolItem
            // 
            this.exportToolItem.Name = "exportToolItem";
            this.exportToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolItem.Size = new System.Drawing.Size(178, 22);
            this.exportToolItem.Text = "Export Table";
            this.exportToolItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importMenuItem.Size = new System.Drawing.Size(178, 22);
            this.importMenuItem.Text = "Import Table";
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // exportAllMenuItem
            // 
            this.exportAllMenuItem.Name = "exportAllMenuItem";
            this.exportAllMenuItem.ShowShortcutKeys = false;
            this.exportAllMenuItem.Size = new System.Drawing.Size(178, 22);
            this.exportAllMenuItem.Text = "Export All";
            this.exportAllMenuItem.Click += new System.EventHandler(this.exportAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(175, 6);
            // 
            // tabDelimitedMenuItem
            // 
            this.tabDelimitedMenuItem.Name = "tabDelimitedMenuItem";
            this.tabDelimitedMenuItem.Size = new System.Drawing.Size(178, 22);
            this.tabDelimitedMenuItem.Text = "Tab Delimited";
            this.tabDelimitedMenuItem.Click += new System.EventHandler(this.tabDelimitedMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableFieldOrderMenuItem,
            this.enableOffSeasonMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "Options";
            // 
            // tableFieldOrderMenuItem
            // 
            this.tableFieldOrderMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultFieldOrderMenuItem,
            this.ascendingFieldOrderMenuItem,
            this.descendingFieldOrderMenuItem,
            this.customOrderMenuItem});
            this.tableFieldOrderMenuItem.Name = "tableFieldOrderMenuItem";
            this.tableFieldOrderMenuItem.Size = new System.Drawing.Size(189, 22);
            this.tableFieldOrderMenuItem.Text = "Table Field Order";
            // 
            // defaultFieldOrderMenuItem
            // 
            this.defaultFieldOrderMenuItem.Checked = true;
            this.defaultFieldOrderMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultFieldOrderMenuItem.Name = "defaultFieldOrderMenuItem";
            this.defaultFieldOrderMenuItem.Size = new System.Drawing.Size(136, 22);
            this.defaultFieldOrderMenuItem.Text = "Default";
            this.defaultFieldOrderMenuItem.Click += new System.EventHandler(this.defaultMenuItem_Click);
            // 
            // ascendingFieldOrderMenuItem
            // 
            this.ascendingFieldOrderMenuItem.Name = "ascendingFieldOrderMenuItem";
            this.ascendingFieldOrderMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ascendingFieldOrderMenuItem.Text = "Ascending";
            this.ascendingFieldOrderMenuItem.Click += new System.EventHandler(this.ascendingMenuItem_Click);
            // 
            // descendingFieldOrderMenuItem
            // 
            this.descendingFieldOrderMenuItem.Name = "descendingFieldOrderMenuItem";
            this.descendingFieldOrderMenuItem.Size = new System.Drawing.Size(136, 22);
            this.descendingFieldOrderMenuItem.Text = "Descending";
            this.descendingFieldOrderMenuItem.Click += new System.EventHandler(this.descendingMenuItem_Click);
            // 
            // customOrderMenuItem
            // 
            this.customOrderMenuItem.Name = "customOrderMenuItem";
            this.customOrderMenuItem.Size = new System.Drawing.Size(136, 22);
            this.customOrderMenuItem.Text = "Custom";
            this.customOrderMenuItem.Click += new System.EventHandler(this.customMenuItem_Click);
            // 
            // enableOffSeasonMenuItem
            // 
            this.enableOffSeasonMenuItem.Name = "enableOffSeasonMenuItem";
            this.enableOffSeasonMenuItem.Size = new System.Drawing.Size(189, 22);
            this.enableOffSeasonMenuItem.Text = "Enable Off-Season DB";
            this.enableOffSeasonMenuItem.Click += new System.EventHandler(this.enableOffSeasonDBMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.Info;
            this.progressBar1.Location = new System.Drawing.Point(792, 700);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // tableMenu
            // 
            this.tableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTableMenuItem,
            this.importTableMenuItem,
            this.toolStripSeparator3,
            this.exportAllTableMenuItem});
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.Size = new System.Drawing.Size(141, 76);
            // 
            // exportTableMenuItem
            // 
            this.exportTableMenuItem.Name = "exportTableMenuItem";
            this.exportTableMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exportTableMenuItem.Text = "Export Table";
            this.exportTableMenuItem.Click += new System.EventHandler(this.exportTableMenuItem_Click);
            // 
            // importTableMenuItem
            // 
            this.importTableMenuItem.Name = "importTableMenuItem";
            this.importTableMenuItem.Size = new System.Drawing.Size(140, 22);
            this.importTableMenuItem.Text = "Import Table";
            this.importTableMenuItem.Click += new System.EventHandler(this.importTableMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // exportAllTableMenuItem
            // 
            this.exportAllTableMenuItem.Name = "exportAllTableMenuItem";
            this.exportAllTableMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exportAllTableMenuItem.Text = "Export All";
            this.exportAllTableMenuItem.Click += new System.EventHandler(this.exportAllTableMenuItem_Click);
            // 
            // fieldMenu
            // 
            this.fieldMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyRecordsMenuItem,
            this.toolStripSeparator4,
            this.addRecordsMenuItem,
            this.deleteRecordsMenuItem,
            this.toolStripSeparator5,
            this.exportRecordsMenuItem,
            this.importRecordsMenuItem,
            this.toolStripSeparator6,
            this.addendumMenuItem});
            this.fieldMenu.Name = "contextMenuStrip2";
            this.fieldMenu.Size = new System.Drawing.Size(164, 154);
            // 
            // copyRecordsMenuItem
            // 
            this.copyRecordsMenuItem.Name = "copyRecordsMenuItem";
            this.copyRecordsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.copyRecordsMenuItem.Text = "Copy Record(s)";
            this.copyRecordsMenuItem.Click += new System.EventHandler(this.copyRecordsMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(160, 6);
            // 
            // addRecordsMenuItem
            // 
            this.addRecordsMenuItem.Name = "addRecordsMenuItem";
            this.addRecordsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addRecordsMenuItem.Text = "Add Record(s)";
            this.addRecordsMenuItem.Click += new System.EventHandler(this.addRecordsMenuItem_Click);
            // 
            // deleteRecordsMenuItem
            // 
            this.deleteRecordsMenuItem.Name = "deleteRecordsMenuItem";
            this.deleteRecordsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteRecordsMenuItem.Text = "Delete Record(s)";
            this.deleteRecordsMenuItem.Click += new System.EventHandler(this.deleteRecordsMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(160, 6);
            // 
            // exportRecordsMenuItem
            // 
            this.exportRecordsMenuItem.Name = "exportRecordsMenuItem";
            this.exportRecordsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exportRecordsMenuItem.Text = "Export Record(s)";
            this.exportRecordsMenuItem.Click += new System.EventHandler(this.exportRecordsMenuItem_Click);
            // 
            // importRecordsMenuItem
            // 
            this.importRecordsMenuItem.Name = "importRecordsMenuItem";
            this.importRecordsMenuItem.Size = new System.Drawing.Size(163, 22);
            this.importRecordsMenuItem.Text = "Import Record(s)";
            this.importRecordsMenuItem.Click += new System.EventHandler(this.importRecordsMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(160, 6);
            // 
            // addendumMenuItem
            // 
            this.addendumMenuItem.Name = "addendumMenuItem";
            this.addendumMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addendumMenuItem.Text = "Addendum";
            this.addendumMenuItem.Click += new System.EventHandler(this.addendumMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Open File";
            // 
            // TablePropsLabel
            // 
            this.TablePropsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TablePropsLabel.AutoSize = true;
            this.TablePropsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TablePropsLabel.Location = new System.Drawing.Point(6, 13);
            this.TablePropsLabel.Name = "TablePropsLabel";
            this.TablePropsLabel.Size = new System.Drawing.Size(87, 13);
            this.TablePropsLabel.TabIndex = 5;
            this.TablePropsLabel.Text = "TablePropsLabel";
            // 
            // FieldsPropsLabel
            // 
            this.FieldsPropsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FieldsPropsLabel.AutoSize = true;
            this.FieldsPropsLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FieldsPropsLabel.Location = new System.Drawing.Point(6, 12);
            this.FieldsPropsLabel.Name = "FieldsPropsLabel";
            this.FieldsPropsLabel.Size = new System.Drawing.Size(87, 13);
            this.FieldsPropsLabel.TabIndex = 6;
            this.FieldsPropsLabel.Text = "FieldsPropsLabel";
            // 
            // TablePropsgroupBox
            // 
            this.TablePropsgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TablePropsgroupBox.Controls.Add(this.TablePropsLabel);
            this.TablePropsgroupBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.TablePropsgroupBox.Location = new System.Drawing.Point(19, 693);
            this.TablePropsgroupBox.Name = "TablePropsgroupBox";
            this.TablePropsgroupBox.Size = new System.Drawing.Size(345, 31);
            this.TablePropsgroupBox.TabIndex = 7;
            this.TablePropsgroupBox.TabStop = false;
            this.TablePropsgroupBox.Text = "Table Properties";
            // 
            // FieldsPropsgroupBox
            // 
            this.FieldsPropsgroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FieldsPropsgroupBox.Controls.Add(this.FieldsPropsLabel);
            this.FieldsPropsgroupBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.FieldsPropsgroupBox.Location = new System.Drawing.Point(367, 693);
            this.FieldsPropsgroupBox.Name = "FieldsPropsgroupBox";
            this.FieldsPropsgroupBox.Size = new System.Drawing.Size(345, 31);
            this.FieldsPropsgroupBox.TabIndex = 4;
            this.FieldsPropsgroupBox.TabStop = false;
            this.FieldsPropsgroupBox.Text = "Field Properties";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabDB
            // 
            this.tabDB.BackColor = System.Drawing.SystemColors.Control;
            this.tabDB.Controls.Add(this.tableGridView);
            this.tabDB.Controls.Add(this.fieldsGridView);
            this.tabDB.Location = new System.Drawing.Point(4, 25);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(976, 632);
            this.tabDB.TabIndex = 0;
            this.tabDB.Text = "DB Editor";
            // 
            // tableGridView
            // 
            this.tableGridView.AllowUserToAddRows = false;
            this.tableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGridView.ContextMenuStrip = this.tableMenu;
            this.tableGridView.GridColor = System.Drawing.SystemColors.Window;
            this.tableGridView.Location = new System.Drawing.Point(3, 6);
            this.tableGridView.Name = "tableGridView";
            this.tableGridView.RowHeadersVisible = false;
            this.tableGridView.RowTemplate.Height = 18;
            this.tableGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGridView.Size = new System.Drawing.Size(107, 623);
            this.tableGridView.TabIndex = 2;
            this.tableGridView.SelectionChanged += new System.EventHandler(this.TableGridView_SelectionChanged);
            // 
            // fieldsGridView
            // 
            this.fieldsGridView.AllowDrop = true;
            this.fieldsGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.fieldsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldsGridView.ContextMenuStrip = this.fieldMenu;
            this.fieldsGridView.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.fieldsGridView.Location = new System.Drawing.Point(116, 6);
            this.fieldsGridView.Name = "fieldsGridView";
            this.fieldsGridView.RowHeadersVisible = false;
            this.fieldsGridView.RowTemplate.Height = 18;
            this.fieldsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fieldsGridView.Size = new System.Drawing.Size(854, 623);
            this.fieldsGridView.TabIndex = 3;
            this.fieldsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FieldGridView_CellValueChanged);
            this.fieldsGridView.CurrentCellChanged += new System.EventHandler(this.FieldGridView_CurrentCellChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabDB);
            this.tabControl1.Controls.Add(this.tabTeams);
            this.tabControl1.Controls.Add(this.tabPlayers);
            this.tabControl1.Controls.Add(this.tabTools);
            this.tabControl1.Controls.Add(this.tabOffSeason);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 661);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_IndexChange);
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.Control;
            this.tabTeams.Controls.Add(this.label11);
            this.tabTeams.Controls.Add(this.TGIDtextBox);
            this.tabTeams.Controls.Add(this.label10);
            this.tabTeams.Controls.Add(this.TDNAtextBox);
            this.tabTeams.Controls.Add(this.label9);
            this.tabTeams.Controls.Add(this.TLNAtextBox);
            this.tabTeams.Controls.Add(this.label8);
            this.tabTeams.Controls.Add(this.DGIDcomboBox);
            this.tabTeams.Controls.Add(this.label7);
            this.tabTeams.Controls.Add(this.CGIDcomboBox);
            this.tabTeams.Controls.Add(this.label6);
            this.tabTeams.Controls.Add(this.LGIDcomboBox);
            this.tabTeams.Controls.Add(this.LocationcheckBox);
            this.tabTeams.Controls.Add(this.MascotcheckBox);
            this.tabTeams.Controls.Add(this.label5);
            this.tabTeams.Controls.Add(this.TTYPcomboBox);
            this.tabTeams.Controls.Add(this.TGIDlistBox);
            this.tabTeams.Location = new System.Drawing.Point(4, 25);
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.Size = new System.Drawing.Size(976, 632);
            this.tabTeams.TabIndex = 1;
            this.tabTeams.Text = "Teams";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "ID";
            // 
            // TGIDtextBox
            // 
            this.TGIDtextBox.Location = new System.Drawing.Point(205, 75);
            this.TGIDtextBox.Name = "TGIDtextBox";
            this.TGIDtextBox.Size = new System.Drawing.Size(33, 20);
            this.TGIDtextBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Mascot";
            // 
            // TDNAtextBox
            // 
            this.TDNAtextBox.Location = new System.Drawing.Point(311, 115);
            this.TDNAtextBox.Name = "TDNAtextBox";
            this.TDNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.TDNAtextBox.TabIndex = 14;
            this.TDNAtextBox.TextChanged += new System.EventHandler(this.TDNAtextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 99);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Location";
            // 
            // TLNAtextBox
            // 
            this.TLNAtextBox.Location = new System.Drawing.Point(205, 115);
            this.TLNAtextBox.Name = "TLNAtextBox";
            this.TLNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.TLNAtextBox.TabIndex = 12;
            this.TLNAtextBox.TextChanged += new System.EventHandler(this.TLNAtextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Division";
            // 
            // DGIDcomboBox
            // 
            this.DGIDcomboBox.FormattingEnabled = true;
            this.DGIDcomboBox.Location = new System.Drawing.Point(139, 74);
            this.DGIDcomboBox.Name = "DGIDcomboBox";
            this.DGIDcomboBox.Size = new System.Drawing.Size(60, 21);
            this.DGIDcomboBox.TabIndex = 10;
            this.DGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.DGIDcomboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Conference";
            // 
            // CGIDcomboBox
            // 
            this.CGIDcomboBox.FormattingEnabled = true;
            this.CGIDcomboBox.Location = new System.Drawing.Point(73, 74);
            this.CGIDcomboBox.Name = "CGIDcomboBox";
            this.CGIDcomboBox.Size = new System.Drawing.Size(60, 21);
            this.CGIDcomboBox.TabIndex = 8;
            this.CGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.CGIDcomboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "League";
            // 
            // LGIDcomboBox
            // 
            this.LGIDcomboBox.FormattingEnabled = true;
            this.LGIDcomboBox.Location = new System.Drawing.Point(7, 74);
            this.LGIDcomboBox.Name = "LGIDcomboBox";
            this.LGIDcomboBox.Size = new System.Drawing.Size(60, 21);
            this.LGIDcomboBox.TabIndex = 6;
            this.LGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.LGIDcomboBox_SelectedIndexChanged);
            // 
            // LocationcheckBox
            // 
            this.LocationcheckBox.AutoSize = true;
            this.LocationcheckBox.Location = new System.Drawing.Point(12, 606);
            this.LocationcheckBox.Name = "LocationcheckBox";
            this.LocationcheckBox.Size = new System.Drawing.Size(67, 17);
            this.LocationcheckBox.TabIndex = 5;
            this.LocationcheckBox.Text = "Location";
            this.LocationcheckBox.UseVisualStyleBackColor = true;
            this.LocationcheckBox.CheckedChanged += new System.EventHandler(this.LocationcheckBox_CheckedChanged);
            // 
            // MascotcheckBox
            // 
            this.MascotcheckBox.AutoSize = true;
            this.MascotcheckBox.Location = new System.Drawing.Point(126, 606);
            this.MascotcheckBox.Name = "MascotcheckBox";
            this.MascotcheckBox.Size = new System.Drawing.Size(61, 17);
            this.MascotcheckBox.TabIndex = 4;
            this.MascotcheckBox.Text = "Mascot";
            this.MascotcheckBox.UseVisualStyleBackColor = true;
            this.MascotcheckBox.CheckedChanged += new System.EventHandler(this.MascotcheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Type";
            // 
            // TTYPcomboBox
            // 
            this.TTYPcomboBox.FormattingEnabled = true;
            this.TTYPcomboBox.Location = new System.Drawing.Point(139, 114);
            this.TTYPcomboBox.Name = "TTYPcomboBox";
            this.TTYPcomboBox.Size = new System.Drawing.Size(60, 21);
            this.TTYPcomboBox.TabIndex = 1;
            this.TTYPcomboBox.SelectedIndexChanged += new System.EventHandler(this.TTYPcomboBox_SelectedIndexChanged);
            // 
            // TGIDlistBox
            // 
            this.TGIDlistBox.FormattingEnabled = true;
            this.TGIDlistBox.Location = new System.Drawing.Point(7, 141);
            this.TGIDlistBox.Name = "TGIDlistBox";
            this.TGIDlistBox.Size = new System.Drawing.Size(192, 459);
            this.TGIDlistBox.TabIndex = 0;
            this.TGIDlistBox.SelectedIndexChanged += new System.EventHandler(this.TGIDlistBox_SelectedIndexChanged);
            // 
            // tabPlayers
            // 
            this.tabPlayers.BackColor = System.Drawing.Color.LightGray;
            this.tabPlayers.Controls.Add(this.label4);
            this.tabPlayers.Controls.Add(this.label3);
            this.tabPlayers.Controls.Add(this.TGIDplayerBox);
            this.tabPlayers.Controls.Add(this.PGIDlistBox);
            this.tabPlayers.Controls.Add(this.label2);
            this.tabPlayers.Controls.Add(this.label1);
            this.tabPlayers.Controls.Add(this.PLNAtextBox);
            this.tabPlayers.Controls.Add(this.PFNAtextBox);
            this.tabPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPlayers.Location = new System.Drawing.Point(4, 25);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Size = new System.Drawing.Size(976, 632);
            this.tabPlayers.TabIndex = 2;
            this.tabPlayers.Text = "Players";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Roster Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Team";
            // 
            // TGIDplayerBox
            // 
            this.TGIDplayerBox.FormattingEnabled = true;
            this.TGIDplayerBox.Location = new System.Drawing.Point(7, 114);
            this.TGIDplayerBox.Name = "TGIDplayerBox";
            this.TGIDplayerBox.Size = new System.Drawing.Size(192, 21);
            this.TGIDplayerBox.TabIndex = 5;
            this.TGIDplayerBox.SelectedIndexChanged += new System.EventHandler(this.TGIDplayerBox_SelectedIndexChanged);
            // 
            // PGIDlistBox
            // 
            this.PGIDlistBox.BackColor = System.Drawing.Color.White;
            this.PGIDlistBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PGIDlistBox.FormattingEnabled = true;
            this.PGIDlistBox.Location = new System.Drawing.Point(7, 141);
            this.PGIDlistBox.Name = "PGIDlistBox";
            this.PGIDlistBox.Size = new System.Drawing.Size(192, 459);
            this.PGIDlistBox.TabIndex = 4;
            this.PGIDlistBox.SelectedIndexChanged += new System.EventHandler(this.PGIDlistBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // PLNAtextBox
            // 
            this.PLNAtextBox.Location = new System.Drawing.Point(311, 115);
            this.PLNAtextBox.Name = "PLNAtextBox";
            this.PLNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.PLNAtextBox.TabIndex = 1;
            this.PLNAtextBox.TextChanged += new System.EventHandler(this.PLNAtextBox_TextChanged);
            // 
            // PFNAtextBox
            // 
            this.PFNAtextBox.Location = new System.Drawing.Point(205, 115);
            this.PFNAtextBox.Name = "PFNAtextBox";
            this.PFNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.PFNAtextBox.TabIndex = 0;
            this.PFNAtextBox.TextChanged += new System.EventHandler(this.PFNAtextBox_TextChanged);
            // 
            // tabTools
            // 
            this.tabTools.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabTools.Controls.Add(this.checkBoxMedRSNEXT);
            this.tabTools.Controls.Add(this.labelPoaching);
            this.tabTools.Controls.Add(this.poachValue);
            this.tabTools.Controls.Add(this.labelJobSecurity);
            this.tabTools.Controls.Add(this.jobSecurityValue);
            this.tabTools.Controls.Add(this.buttonCarousel);
            this.tabTools.Controls.Add(this.labelSkillDrop);
            this.tabTools.Controls.Add(this.skillDrop);
            this.tabTools.Controls.Add(this.checkBoxInjuryRatings);
            this.tabTools.Controls.Add(this.buttonRandPotential);
            this.tabTools.Controls.Add(this.buttonRandomBudgets);
            this.tabTools.Controls.Add(qbTend);
            this.tabTools.Controls.Add(this.increaseSpeed);
            this.tabTools.Controls.Add(this.bodyFix);
            this.tabTools.Controls.Add(this.dbToolsInfo);
            this.tabTools.Controls.Add(this.textBox1);
            this.tabTools.Controls.Add(this.coachProg);
            this.tabTools.Controls.Add(this.medRS);
            this.tabTools.Location = new System.Drawing.Point(4, 25);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(976, 632);
            this.tabTools.TabIndex = 3;
            this.tabTools.Text = "dbTools";
            // 
            // checkBoxMedRSNEXT
            // 
            this.checkBoxMedRSNEXT.AutoSize = true;
            this.checkBoxMedRSNEXT.Checked = true;
            this.checkBoxMedRSNEXT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMedRSNEXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMedRSNEXT.Location = new System.Drawing.Point(143, 150);
            this.checkBoxMedRSNEXT.Name = "checkBoxMedRSNEXT";
            this.checkBoxMedRSNEXT.Size = new System.Drawing.Size(104, 17);
            this.checkBoxMedRSNEXT.TabIndex = 17;
            this.checkBoxMedRSNEXT.Text = "NCAA Next Mod";
            this.checkBoxMedRSNEXT.UseVisualStyleBackColor = true;
            // 
            // labelPoaching
            // 
            this.labelPoaching.AutoSize = true;
            this.labelPoaching.Location = new System.Drawing.Point(386, 291);
            this.labelPoaching.Name = "labelPoaching";
            this.labelPoaching.Size = new System.Drawing.Size(78, 13);
            this.labelPoaching.TabIndex = 16;
            this.labelPoaching.Text = "Poach Chance";
            // 
            // poachValue
            // 
            this.poachValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.poachValue.Location = new System.Drawing.Point(390, 268);
            this.poachValue.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.poachValue.Name = "poachValue";
            this.poachValue.Size = new System.Drawing.Size(51, 20);
            this.poachValue.TabIndex = 15;
            this.poachValue.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // labelJobSecurity
            // 
            this.labelJobSecurity.AutoSize = true;
            this.labelJobSecurity.Location = new System.Drawing.Point(389, 251);
            this.labelJobSecurity.Name = "labelJobSecurity";
            this.labelJobSecurity.Size = new System.Drawing.Size(65, 13);
            this.labelJobSecurity.TabIndex = 14;
            this.labelJobSecurity.Text = "Job Security";
            // 
            // jobSecurityValue
            // 
            this.jobSecurityValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.jobSecurityValue.Location = new System.Drawing.Point(389, 228);
            this.jobSecurityValue.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.jobSecurityValue.Name = "jobSecurityValue";
            this.jobSecurityValue.Size = new System.Drawing.Size(52, 20);
            this.jobSecurityValue.TabIndex = 13;
            this.jobSecurityValue.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // buttonCarousel
            // 
            this.buttonCarousel.BackColor = System.Drawing.Color.HotPink;
            this.buttonCarousel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarousel.Location = new System.Drawing.Point(273, 219);
            this.buttonCarousel.Name = "buttonCarousel";
            this.buttonCarousel.Size = new System.Drawing.Size(110, 80);
            this.buttonCarousel.TabIndex = 12;
            this.buttonCarousel.Text = "Coaching Carousel";
            this.buttonCarousel.UseVisualStyleBackColor = false;
            this.buttonCarousel.Click += new System.EventHandler(this.buttonCarousel_Click);
            // 
            // labelSkillDrop
            // 
            this.labelSkillDrop.AutoSize = true;
            this.labelSkillDrop.Location = new System.Drawing.Point(192, 120);
            this.labelSkillDrop.Name = "labelSkillDrop";
            this.labelSkillDrop.Size = new System.Drawing.Size(75, 13);
            this.labelSkillDrop.TabIndex = 11;
            this.labelSkillDrop.Text = "Max Skill Drop";
            // 
            // skillDrop
            // 
            this.skillDrop.Location = new System.Drawing.Point(144, 118);
            this.skillDrop.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.skillDrop.Name = "skillDrop";
            this.skillDrop.Size = new System.Drawing.Size(44, 20);
            this.skillDrop.TabIndex = 10;
            this.skillDrop.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // checkBoxInjuryRatings
            // 
            this.checkBoxInjuryRatings.AutoSize = true;
            this.checkBoxInjuryRatings.Location = new System.Drawing.Point(143, 87);
            this.checkBoxInjuryRatings.Name = "checkBoxInjuryRatings";
            this.checkBoxInjuryRatings.Size = new System.Drawing.Size(103, 17);
            this.checkBoxInjuryRatings.TabIndex = 9;
            this.checkBoxInjuryRatings.Text = "Reduce Ratings";
            this.checkBoxInjuryRatings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxInjuryRatings.UseVisualStyleBackColor = true;
            // 
            // buttonRandPotential
            // 
            this.buttonRandPotential.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonRandPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandPotential.Location = new System.Drawing.Point(273, 528);
            this.buttonRandPotential.Name = "buttonRandPotential";
            this.buttonRandPotential.Size = new System.Drawing.Size(110, 80);
            this.buttonRandPotential.TabIndex = 8;
            this.buttonRandPotential.Text = "Randomize Player Potential";
            this.buttonRandPotential.UseVisualStyleBackColor = false;
            this.buttonRandPotential.Click += new System.EventHandler(this.buttonRandPotential_Click);
            // 
            // buttonRandomBudgets
            // 
            this.buttonRandomBudgets.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonRandomBudgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomBudgets.Location = new System.Drawing.Point(273, 87);
            this.buttonRandomBudgets.Name = "buttonRandomBudgets";
            this.buttonRandomBudgets.Size = new System.Drawing.Size(110, 80);
            this.buttonRandomBudgets.TabIndex = 7;
            this.buttonRandomBudgets.Text = "Randomize Coaching Budgets";
            this.buttonRandomBudgets.UseVisualStyleBackColor = false;
            this.buttonRandomBudgets.Click += new System.EventHandler(this.buttonRandomBudgets_Click);
            // 
            // increaseSpeed
            // 
            this.increaseSpeed.BackColor = System.Drawing.Color.MediumAquamarine;
            this.increaseSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increaseSpeed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.increaseSpeed.Location = new System.Drawing.Point(273, 423);
            this.increaseSpeed.Name = "increaseSpeed";
            this.increaseSpeed.Size = new System.Drawing.Size(110, 80);
            this.increaseSpeed.TabIndex = 5;
            this.increaseSpeed.Text = "Increase Minimum Skill Position Speed";
            this.increaseSpeed.UseVisualStyleBackColor = false;
            this.increaseSpeed.Click += new System.EventHandler(this.increaseSpeed_Click);
            // 
            // bodyFix
            // 
            this.bodyFix.BackColor = System.Drawing.Color.Gold;
            this.bodyFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyFix.Location = new System.Drawing.Point(28, 423);
            this.bodyFix.Name = "bodyFix";
            this.bodyFix.Size = new System.Drawing.Size(110, 80);
            this.bodyFix.TabIndex = 4;
            this.bodyFix.Text = "Body Size Fixer";
            this.bodyFix.UseVisualStyleBackColor = false;
            this.bodyFix.Click += new System.EventHandler(this.bodyFix_Click);
            // 
            // dbToolsInfo
            // 
            this.dbToolsInfo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.dbToolsInfo.Enabled = false;
            this.dbToolsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbToolsInfo.Location = new System.Drawing.Point(527, 19);
            this.dbToolsInfo.Multiline = true;
            this.dbToolsInfo.Name = "dbToolsInfo";
            this.dbToolsInfo.Size = new System.Drawing.Size(430, 579);
            this.dbToolsInfo.TabIndex = 3;
            this.dbToolsInfo.Text = resources.GetString("dbToolsInfo.Text");
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 33);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "NCAA Football Modding Toolkit";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // coachProg
            // 
            this.coachProg.BackColor = System.Drawing.Color.DodgerBlue;
            this.coachProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coachProg.ForeColor = System.Drawing.SystemColors.Control;
            this.coachProg.Location = new System.Drawing.Point(28, 219);
            this.coachProg.Name = "coachProg";
            this.coachProg.Size = new System.Drawing.Size(110, 80);
            this.coachProg.TabIndex = 1;
            this.coachProg.Text = "Coach Progression";
            this.coachProg.UseVisualStyleBackColor = false;
            this.coachProg.Click += new System.EventHandler(this.coachProg_Click);
            // 
            // medRS
            // 
            this.medRS.BackColor = System.Drawing.Color.Crimson;
            this.medRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medRS.ForeColor = System.Drawing.SystemColors.Control;
            this.medRS.Location = new System.Drawing.Point(28, 87);
            this.medRS.Name = "medRS";
            this.medRS.Size = new System.Drawing.Size(110, 80);
            this.medRS.TabIndex = 0;
            this.medRS.Text = "Medical Redshirt";
            this.medRS.UseVisualStyleBackColor = false;
            this.medRS.Click += new System.EventHandler(this.medRS_Click);
            // 
            // tabOffSeason
            // 
            this.tabOffSeason.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOffSeason.Controls.Add(this.labelPolyNamesPCT);
            this.tabOffSeason.Controls.Add(this.polyNamesPCT);
            this.tabOffSeason.Controls.Add(this.polyNames);
            this.tabOffSeason.Controls.Add(this.textBoxOffSeason);
            this.tabOffSeason.Controls.Add(this.textBoxOffSeasonTitle);
            this.tabOffSeason.Controls.Add(this.labelIntTeams);
            this.tabOffSeason.Controls.Add(this.removeInterestTeams);
            this.tabOffSeason.Controls.Add(this.buttonInterestedTeams);
            this.tabOffSeason.Controls.Add(this.label12);
            this.tabOffSeason.Controls.Add(this.minTRPA);
            this.tabOffSeason.Controls.Add(this.labelMinRecPts);
            this.tabOffSeason.Controls.Add(this.minRecPts);
            this.tabOffSeason.Controls.Add(this.labelRecruit);
            this.tabOffSeason.Controls.Add(this.recruitTolerance);
            this.tabOffSeason.Controls.Add(this.wkonLabel);
            this.tabOffSeason.Controls.Add(this.toleranceWalkOn);
            this.tabOffSeason.Controls.Add(this.buttonRandRecruits);
            this.tabOffSeason.Controls.Add(this.buttonRandWalkOns);
            this.tabOffSeason.Controls.Add(this.buttonMinRecruitingPts);
            this.tabOffSeason.Location = new System.Drawing.Point(4, 25);
            this.tabOffSeason.Name = "tabOffSeason";
            this.tabOffSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffSeason.Size = new System.Drawing.Size(976, 632);
            this.tabOffSeason.TabIndex = 4;
            this.tabOffSeason.Text = "Recruiting";
            // 
            // labelPolyNamesPCT
            // 
            this.labelPolyNamesPCT.AutoSize = true;
            this.labelPolyNamesPCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolyNamesPCT.Location = new System.Drawing.Point(59, 582);
            this.labelPolyNamesPCT.Name = "labelPolyNamesPCT";
            this.labelPolyNamesPCT.Size = new System.Drawing.Size(76, 16);
            this.labelPolyNamesPCT.TabIndex = 19;
            this.labelPolyNamesPCT.Text = "% Chance";
            // 
            // polyNamesPCT
            // 
            this.polyNamesPCT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.polyNamesPCT.Location = new System.Drawing.Point(73, 559);
            this.polyNamesPCT.Name = "polyNamesPCT";
            this.polyNamesPCT.Size = new System.Drawing.Size(52, 20);
            this.polyNamesPCT.TabIndex = 18;
            this.polyNamesPCT.Value = new decimal(new int[] {
            85,
            0,
            0,
            0});
            // 
            // polyNames
            // 
            this.polyNames.BackColor = System.Drawing.Color.LightGreen;
            this.polyNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.polyNames.Location = new System.Drawing.Point(144, 537);
            this.polyNames.Name = "polyNames";
            this.polyNames.Size = new System.Drawing.Size(110, 70);
            this.polyNames.TabIndex = 17;
            this.polyNames.Text = "Polynesian Last Name Generator";
            this.polyNames.UseVisualStyleBackColor = false;
            this.polyNames.Click += new System.EventHandler(this.polyNames_Click);
            // 
            // textBoxOffSeason
            // 
            this.textBoxOffSeason.Enabled = false;
            this.textBoxOffSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffSeason.Location = new System.Drawing.Point(360, 77);
            this.textBoxOffSeason.Multiline = true;
            this.textBoxOffSeason.Name = "textBoxOffSeason";
            this.textBoxOffSeason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOffSeason.Size = new System.Drawing.Size(526, 600);
            this.textBoxOffSeason.TabIndex = 16;
            this.textBoxOffSeason.Text = resources.GetString("textBoxOffSeason.Text");
            // 
            // textBoxOffSeasonTitle
            // 
            this.textBoxOffSeasonTitle.Enabled = false;
            this.textBoxOffSeasonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffSeasonTitle.Location = new System.Drawing.Point(360, 23);
            this.textBoxOffSeasonTitle.Name = "textBoxOffSeasonTitle";
            this.textBoxOffSeasonTitle.Size = new System.Drawing.Size(526, 31);
            this.textBoxOffSeasonTitle.TabIndex = 15;
            this.textBoxOffSeasonTitle.Text = "Off-Season Recruiting Tools";
            this.textBoxOffSeasonTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelIntTeams
            // 
            this.labelIntTeams.AutoSize = true;
            this.labelIntTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntTeams.Location = new System.Drawing.Point(71, 212);
            this.labelIntTeams.Name = "labelIntTeams";
            this.labelIntTeams.Size = new System.Drawing.Size(55, 16);
            this.labelIntTeams.TabIndex = 14;
            this.labelIntTeams.Text = "Teams";
            this.labelIntTeams.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // removeInterestTeams
            // 
            this.removeInterestTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeInterestTeams.Location = new System.Drawing.Point(73, 187);
            this.removeInterestTeams.Maximum = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.removeInterestTeams.Name = "removeInterestTeams";
            this.removeInterestTeams.Size = new System.Drawing.Size(56, 22);
            this.removeInterestTeams.TabIndex = 13;
            this.removeInterestTeams.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // buttonInterestedTeams
            // 
            this.buttonInterestedTeams.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonInterestedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInterestedTeams.Location = new System.Drawing.Point(144, 159);
            this.buttonInterestedTeams.Name = "buttonInterestedTeams";
            this.buttonInterestedTeams.Size = new System.Drawing.Size(110, 80);
            this.buttonInterestedTeams.TabIndex = 12;
            this.buttonInterestedTeams.Text = "Modify Recruiting Interested Teams";
            this.buttonInterestedTeams.UseVisualStyleBackColor = false;
            this.buttonInterestedTeams.Click += new System.EventHandler(this.buttonInterestedTeams_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(62, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Min TRPA";
            // 
            // minTRPA
            // 
            this.minTRPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTRPA.Location = new System.Drawing.Point(74, 54);
            this.minTRPA.Maximum = new decimal(new int[] {
            17,
            0,
            0,
            0});
            this.minTRPA.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.minTRPA.Name = "minTRPA";
            this.minTRPA.Size = new System.Drawing.Size(52, 22);
            this.minTRPA.TabIndex = 10;
            this.minTRPA.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // labelMinRecPts
            // 
            this.labelMinRecPts.AutoSize = true;
            this.labelMinRecPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinRecPts.Location = new System.Drawing.Point(59, 135);
            this.labelMinRecPts.Name = "labelMinRecPts";
            this.labelMinRecPts.Size = new System.Drawing.Size(78, 16);
            this.labelMinRecPts.TabIndex = 9;
            this.labelMinRecPts.Text = "Min Points";
            this.labelMinRecPts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // minRecPts
            // 
            this.minRecPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minRecPts.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.minRecPts.Location = new System.Drawing.Point(74, 110);
            this.minRecPts.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.minRecPts.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.minRecPts.Name = "minRecPts";
            this.minRecPts.Size = new System.Drawing.Size(52, 22);
            this.minRecPts.TabIndex = 8;
            this.minRecPts.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // labelRecruit
            // 
            this.labelRecruit.AutoSize = true;
            this.labelRecruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecruit.Location = new System.Drawing.Point(59, 343);
            this.labelRecruit.Name = "labelRecruit";
            this.labelRecruit.Size = new System.Drawing.Size(78, 16);
            this.labelRecruit.TabIndex = 7;
            this.labelRecruit.Text = "Tolerance";
            this.labelRecruit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // recruitTolerance
            // 
            this.recruitTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recruitTolerance.Location = new System.Drawing.Point(73, 318);
            this.recruitTolerance.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.recruitTolerance.Name = "recruitTolerance";
            this.recruitTolerance.Size = new System.Drawing.Size(52, 22);
            this.recruitTolerance.TabIndex = 6;
            this.recruitTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // wkonLabel
            // 
            this.wkonLabel.AutoSize = true;
            this.wkonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wkonLabel.Location = new System.Drawing.Point(59, 477);
            this.wkonLabel.Name = "wkonLabel";
            this.wkonLabel.Size = new System.Drawing.Size(78, 16);
            this.wkonLabel.TabIndex = 5;
            this.wkonLabel.Text = "Tolerance";
            this.wkonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toleranceWalkOn
            // 
            this.toleranceWalkOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toleranceWalkOn.Location = new System.Drawing.Point(73, 452);
            this.toleranceWalkOn.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.toleranceWalkOn.Name = "toleranceWalkOn";
            this.toleranceWalkOn.Size = new System.Drawing.Size(52, 22);
            this.toleranceWalkOn.TabIndex = 4;
            this.toleranceWalkOn.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonRandRecruits
            // 
            this.buttonRandRecruits.BackColor = System.Drawing.Color.Moccasin;
            this.buttonRandRecruits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandRecruits.Location = new System.Drawing.Point(144, 290);
            this.buttonRandRecruits.Name = "buttonRandRecruits";
            this.buttonRandRecruits.Size = new System.Drawing.Size(110, 80);
            this.buttonRandRecruits.TabIndex = 3;
            this.buttonRandRecruits.Text = "Randomize Recruits";
            this.buttonRandRecruits.UseVisualStyleBackColor = false;
            this.buttonRandRecruits.Click += new System.EventHandler(this.buttonRandRecruits_Click);
            // 
            // buttonRandWalkOns
            // 
            this.buttonRandWalkOns.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonRandWalkOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandWalkOns.Location = new System.Drawing.Point(144, 424);
            this.buttonRandWalkOns.Name = "buttonRandWalkOns";
            this.buttonRandWalkOns.Size = new System.Drawing.Size(110, 80);
            this.buttonRandWalkOns.TabIndex = 2;
            this.buttonRandWalkOns.Text = "Randomize Walk-Ons";
            this.buttonRandWalkOns.UseVisualStyleBackColor = false;
            this.buttonRandWalkOns.Click += new System.EventHandler(this.buttonRandWalkOns_Click);
            // 
            // buttonMinRecruitingPts
            // 
            this.buttonMinRecruitingPts.BackColor = System.Drawing.Color.LightSalmon;
            this.buttonMinRecruitingPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinRecruitingPts.Location = new System.Drawing.Point(144, 54);
            this.buttonMinRecruitingPts.Name = "buttonMinRecruitingPts";
            this.buttonMinRecruitingPts.Size = new System.Drawing.Size(110, 80);
            this.buttonMinRecruitingPts.TabIndex = 1;
            this.buttonMinRecruitingPts.Text = "Raise Minimum Recruiting Points";
            this.buttonMinRecruitingPts.UseVisualStyleBackColor = false;
            this.buttonMinRecruitingPts.Click += new System.EventHandler(this.buttonMinRecruitingPts_Click);
            // 
            // MainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.TablePropsgroupBox);
            this.Controls.Add(this.FieldsPropsgroupBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCAA Xtreme Database Editor";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tableMenu.ResumeLayout(false);
            this.fieldMenu.ResumeLayout(false);
            this.TablePropsgroupBox.ResumeLayout(false);
            this.TablePropsgroupBox.PerformLayout();
            this.FieldsPropsgroupBox.ResumeLayout(false);
            this.FieldsPropsgroupBox.PerformLayout();
            this.tabDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabTeams.ResumeLayout(false);
            this.tabTeams.PerformLayout();
            this.tabPlayers.ResumeLayout(false);
            this.tabPlayers.PerformLayout();
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).EndInit();
            this.tabOffSeason.ResumeLayout(false);
            this.tabOffSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polyNamesPCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainEditor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.closeMainEditor_Click();
            //throw new NotImplementedException();
        }

        #endregion

        public System.Windows.Forms.MenuStrip mainMenu;
        public System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        public System.Windows.Forms.ToolStripMenuItem openMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ToolStripMenuItem CSVMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exportToolItem;
        public System.Windows.Forms.ToolStripMenuItem importMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem exportAllMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Label TablePropsLabel;
        public System.Windows.Forms.Label FieldsPropsLabel;
        public System.Windows.Forms.GroupBox TablePropsgroupBox;
        public System.Windows.Forms.GroupBox FieldsPropsgroupBox;
        public System.Windows.Forms.ContextMenuStrip tableMenu;
        public System.Windows.Forms.ToolStripMenuItem exportTableMenuItem;
        public System.Windows.Forms.ToolStripMenuItem importTableMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripMenuItem exportAllTableMenuItem;
        public System.Windows.Forms.ContextMenuStrip fieldMenu;
        public System.Windows.Forms.ToolStripMenuItem copyRecordsMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripMenuItem addRecordsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem deleteRecordsMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripMenuItem exportRecordsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem importRecordsMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        public System.Windows.Forms.ToolStripMenuItem addendumMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        public System.Windows.Forms.ToolStripMenuItem definitionFileMenuItem;
        public System.Windows.Forms.OpenFileDialog openFileDialog2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripMenuItem tabDelimitedMenuItem;
        public System.Windows.Forms.TabPage tabDB;
        public System.Windows.Forms.DataGridView tableGridView;
        public System.Windows.Forms.DataGridView fieldsGridView;
        public System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem tableFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem defaultFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ascendingFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem customOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem descendingFieldOrderMenuItem;
        public System.Windows.Forms.TabPage tabTeams;
        public System.Windows.Forms.TabPage tabPlayers;
        public System.Windows.Forms.ListBox PGIDlistBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox PLNAtextBox;
        public System.Windows.Forms.TextBox PFNAtextBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TGIDplayerBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ListBox TGIDlistBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox TTYPcomboBox;
        public System.Windows.Forms.CheckBox MascotcheckBox;
        public System.Windows.Forms.CheckBox LocationcheckBox;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox DGIDcomboBox;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox CGIDcomboBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox LGIDcomboBox;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox TDNAtextBox;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox TLNAtextBox;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox TGIDtextBox;
        public System.Windows.Forms.TabPage tabTools;
        public System.Windows.Forms.Button medRS;
        public System.Windows.Forms.Button coachProg;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox dbToolsInfo;
        public System.Windows.Forms.Button bodyFix;
        public System.Windows.Forms.Button increaseSpeed;
        public System.Windows.Forms.ToolStripMenuItem enableOffSeasonMenuItem;
        public System.Windows.Forms.TabPage tabOffSeason;
        public System.Windows.Forms.Button buttonMinRecruitingPts;
        public System.Windows.Forms.Button buttonRandomBudgets;
        public System.Windows.Forms.Button buttonRandRecruits;
        public System.Windows.Forms.Button buttonRandWalkOns;
        public System.Windows.Forms.NumericUpDown toleranceWalkOn;
        public System.Windows.Forms.Label wkonLabel;
        public System.Windows.Forms.Label labelMinRecPts;
        public System.Windows.Forms.NumericUpDown minRecPts;
        public System.Windows.Forms.Label labelRecruit;
        public System.Windows.Forms.NumericUpDown recruitTolerance;
        public System.Windows.Forms.NumericUpDown minTRPA;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Button buttonInterestedTeams;
        public System.Windows.Forms.NumericUpDown removeInterestTeams;
        public System.Windows.Forms.Label labelIntTeams;
        public System.Windows.Forms.TextBox textBoxOffSeasonTitle;
        public System.Windows.Forms.TextBox textBoxOffSeason;
        public System.Windows.Forms.Button polyNames;
        public System.Windows.Forms.NumericUpDown polyNamesPCT;
        public System.Windows.Forms.Label labelPolyNamesPCT;
        public System.Windows.Forms.Button buttonRandPotential;
        public System.Windows.Forms.CheckBox checkBoxInjuryRatings;
        public System.Windows.Forms.Label labelSkillDrop;
        public System.Windows.Forms.NumericUpDown skillDrop;
        public System.Windows.Forms.Button buttonCarousel;
        public System.Windows.Forms.Label labelPoaching;
        public System.Windows.Forms.NumericUpDown poachValue;
        public System.Windows.Forms.Label labelJobSecurity;
        public System.Windows.Forms.NumericUpDown jobSecurityValue;
        public System.Windows.Forms.CheckBox checkBoxMedRSNEXT;
        public System.Windows.Forms.TabControl tabControl1;
    }
}

