using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Windows.Forms;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tabHome = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.PlaybookSelectBox = new System.Windows.Forms.ComboBox();
            this.DefTypeSelectBox = new System.Windows.Forms.ComboBox();
            this.OffTypeSelectBox = new System.Windows.Forms.ComboBox();
            this.CapacityNumbox = new System.Windows.Forms.NumericUpDown();
            this.AttendanceNumBox = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.StateBox = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.CityNameBox = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.stadiumNameBox = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.UserCoachCheckBox = new System.Windows.Forms.CheckBox();
            this.FireCoachButton = new System.Windows.Forms.Button();
            this.ResetSecondaryColorButton = new System.Windows.Forms.Button();
            this.ResetPrimaryColorButton = new System.Windows.Forms.Button();
            this.TeamCDTSbox = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.TeamCDTAbox = new System.Windows.Forms.NumericUpDown();
            this.TeamCDTRbox = new System.Windows.Forms.NumericUpDown();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.TeamCOTSbox = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.TeamCOTAbox = new System.Windows.Forms.NumericUpDown();
            this.TeamCOTRbox = new System.Windows.Forms.NumericUpDown();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.TeamCCPONumBox = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.SDURnumbox = new System.Windows.Forms.NumericUpDown();
            this.SNCTnumbox = new System.Windows.Forms.NumericUpDown();
            this.NCDPnumbox = new System.Windows.Forms.NumericUpDown();
            this.INPOnumbox = new System.Windows.Forms.NumericUpDown();
            this.TeamHCPrestigeNumBox = new System.Windows.Forms.NumericUpDown();
            this.TMARNumBox = new System.Windows.Forms.NumericUpDown();
            this.TMPRNumBox = new System.Windows.Forms.NumericUpDown();
            this.TeamCRPCNumber = new System.Windows.Forms.NumericUpDown();
            this.TeamCTPCNumber = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.TeamCDPCBox = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.TeamColor2Button = new System.Windows.Forms.Button();
            this.TeamColor1Button = new System.Windows.Forms.Button();
            this.HCLastNameBox = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.HCFirstNameBox = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.CoachPollBox = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.SeasonRecordBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.APPollBox = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.ConfRecordBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.LeagueBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.TSNAtextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.TeamDivisionBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.TeamConferenceBox = new System.Windows.Forms.TextBox();
            this.TeamCaptain2box = new System.Windows.Forms.TextBox();
            this.TeamCaptain1box = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.TeamOVRtextbox = new System.Windows.Forms.TextBox();
            this.TSI1textbox = new System.Windows.Forms.TextBox();
            this.TSI2textbox = new System.Windows.Forms.TextBox();
            this.TPIDtextbox = new System.Windows.Forms.TextBox();
            this.TPIOtextbox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TGIDtextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TMNAtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TDNAtextBox = new System.Windows.Forms.TextBox();
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
            this.tabCoaches = new System.Windows.Forms.TabPage();
            this.tabSeason = new System.Windows.Forms.TabPage();
            this.CoachPrestigeButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numberPlayerCoach = new System.Windows.Forms.NumericUpDown();
            this.buttonPlayerCoach = new System.Windows.Forms.Button();
            this.buttonScheduleGen = new System.Windows.Forms.Button();
            this.buttonRealignment = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.labelMaxTransfers = new System.Windows.Forms.Label();
            this.maxFiredTransfers = new System.Windows.Forms.NumericUpDown();
            this.checkBoxFiredTransfers = new System.Windows.Forms.CheckBox();
            this.buttonChaosTransfers = new System.Windows.Forms.Button();
            this.labelMaxSkilDrop_PS = new System.Windows.Forms.Label();
            this.MaxSkillDropPS = new System.Windows.Forms.NumericUpDown();
            this.labelPSInjuries = new System.Windows.Forms.Label();
            this.numInjuries = new System.Windows.Forms.NumericUpDown();
            this.buttonPSInjuries = new System.Windows.Forms.Button();
            this.checkBoxMedRSNEXT = new System.Windows.Forms.CheckBox();
            this.labelPoaching = new System.Windows.Forms.Label();
            this.poachValue = new System.Windows.Forms.NumericUpDown();
            this.labelJobSecurity = new System.Windows.Forms.Label();
            this.jobSecurityValue = new System.Windows.Forms.NumericUpDown();
            this.buttonCarousel = new System.Windows.Forms.Button();
            this.labelSkillDrop = new System.Windows.Forms.Label();
            this.skillDrop = new System.Windows.Forms.NumericUpDown();
            this.checkBoxInjuryRatings = new System.Windows.Forms.CheckBox();
            this.buttonRandomBudgets = new System.Windows.Forms.Button();
            this.dbToolsInfo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.coachProg = new System.Windows.Forms.Button();
            this.medRS = new System.Windows.Forms.Button();
            this.tabOffSeason = new System.Windows.Forms.TabPage();
            this.buttonRandomizeFaceShape = new System.Windows.Forms.Button();
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
            this.tabTools = new System.Windows.Forms.TabPage();
            this.RandomizeHeadButton = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.FillRosterPCT = new System.Windows.Forms.NumericUpDown();
            this.buttonFillRosters = new System.Windows.Forms.Button();
            this.buttonAutoDepthChart = new System.Windows.Forms.Button();
            this.buttonFantasyRoster = new System.Windows.Forms.Button();
            this.buttonImpactPlayers = new System.Windows.Forms.Button();
            this.TYDNButton = new System.Windows.Forms.Button();
            this.buttonCalcOverall = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonRandPotential = new System.Windows.Forms.Button();
            this.increaseSpeed = new System.Windows.Forms.Button();
            this.bodyFix = new System.Windows.Forms.Button();
            this.tabDev = new System.Windows.Forms.TabPage();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.DevCalcTeamRatingsButton = new System.Windows.Forms.Button();
            this.DevDepthChartButton = new System.Windows.Forms.Button();
            this.DevRandomizeFaceButton = new System.Windows.Forms.Button();
            this.DevCalcOVRButton = new System.Windows.Forms.Button();
            this.DevFillRosterButton = new System.Windows.Forms.Button();
            this.CreateTransfersCSVButton = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.ImportRecruitsButton = new System.Windows.Forms.Button();
            this.GraduateButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
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
            this.tabHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabTeams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTSbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTAbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTRbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTSbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTAbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTRbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCCPONumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDURnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNCTnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCDPnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.INPOnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamHCPrestigeNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMARNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMPRNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCRPCNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCTPCNumber)).BeginInit();
            this.tabPlayers.SuspendLayout();
            this.tabSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).BeginInit();
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
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).BeginInit();
            this.tabDev.SuspendLayout();
            this.SuspendLayout();
            // 
            // qbTend
            // 
            qbTend.BackColor = System.Drawing.Color.SaddleBrown;
            qbTend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qbTend.ForeColor = System.Drawing.SystemColors.Control;
            qbTend.Location = new System.Drawing.Point(45, 140);
            qbTend.Name = "qbTend";
            qbTend.Size = new System.Drawing.Size(110, 80);
            qbTend.TabIndex = 11;
            qbTend.Text = "Calculate QB Tendencies";
            qbTend.UseVisualStyleBackColor = false;
            qbTend.Click += new System.EventHandler(this.QB_Tend_Click);
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
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::DB_EDITOR.Properties.Resources.save3;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveAsMenuItem.Text = "Save As...";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Image = global::DB_EDITOR.Properties.Resources.close;
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeMenuItem.Size = new System.Drawing.Size(148, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
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
            this.definitionFileMenuItem.Click += new System.EventHandler(this.DefinitionFileMenuItem_Click);
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
            this.exitMenuItem.Click += new System.EventHandler(this.ExitToolItem_Click);
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
            this.enableOffSeasonMenuItem.Click += new System.EventHandler(this.EnableOffSeasonDBMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabDB);
            this.tabControl1.Controls.Add(this.tabTeams);
            this.tabControl1.Controls.Add(this.tabPlayers);
            this.tabControl1.Controls.Add(this.tabCoaches);
            this.tabControl1.Controls.Add(this.tabSeason);
            this.tabControl1.Controls.Add(this.tabOffSeason);
            this.tabControl1.Controls.Add(this.tabTools);
            this.tabControl1.Controls.Add(this.tabDev);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 661);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_IndexChange);
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabHome.Controls.Add(this.pictureBox1);
            this.tabHome.Location = new System.Drawing.Point(4, 25);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(976, 632);
            this.tabHome.TabIndex = 6;
            this.tabHome.Text = "Home";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_EDITOR.Properties.Resources.ncaa_db_editor_TITLE;
            this.pictureBox1.Location = new System.Drawing.Point(200, 45);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(550, 550);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 550);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.Control;
            this.tabTeams.Controls.Add(this.PlaybookSelectBox);
            this.tabTeams.Controls.Add(this.DefTypeSelectBox);
            this.tabTeams.Controls.Add(this.OffTypeSelectBox);
            this.tabTeams.Controls.Add(this.CapacityNumbox);
            this.tabTeams.Controls.Add(this.AttendanceNumBox);
            this.tabTeams.Controls.Add(this.label59);
            this.tabTeams.Controls.Add(this.label60);
            this.tabTeams.Controls.Add(this.label57);
            this.tabTeams.Controls.Add(this.StateBox);
            this.tabTeams.Controls.Add(this.label56);
            this.tabTeams.Controls.Add(this.CityNameBox);
            this.tabTeams.Controls.Add(this.label55);
            this.tabTeams.Controls.Add(this.stadiumNameBox);
            this.tabTeams.Controls.Add(this.label54);
            this.tabTeams.Controls.Add(this.label53);
            this.tabTeams.Controls.Add(this.UserCoachCheckBox);
            this.tabTeams.Controls.Add(this.FireCoachButton);
            this.tabTeams.Controls.Add(this.ResetSecondaryColorButton);
            this.tabTeams.Controls.Add(this.ResetPrimaryColorButton);
            this.tabTeams.Controls.Add(this.TeamCDTSbox);
            this.tabTeams.Controls.Add(this.label50);
            this.tabTeams.Controls.Add(this.TeamCDTAbox);
            this.tabTeams.Controls.Add(this.TeamCDTRbox);
            this.tabTeams.Controls.Add(this.label51);
            this.tabTeams.Controls.Add(this.label52);
            this.tabTeams.Controls.Add(this.TeamCOTSbox);
            this.tabTeams.Controls.Add(this.label49);
            this.tabTeams.Controls.Add(this.TeamCOTAbox);
            this.tabTeams.Controls.Add(this.TeamCOTRbox);
            this.tabTeams.Controls.Add(this.label47);
            this.tabTeams.Controls.Add(this.label48);
            this.tabTeams.Controls.Add(this.label46);
            this.tabTeams.Controls.Add(this.label44);
            this.tabTeams.Controls.Add(this.label45);
            this.tabTeams.Controls.Add(this.TeamCCPONumBox);
            this.tabTeams.Controls.Add(this.label43);
            this.tabTeams.Controls.Add(this.SDURnumbox);
            this.tabTeams.Controls.Add(this.SNCTnumbox);
            this.tabTeams.Controls.Add(this.NCDPnumbox);
            this.tabTeams.Controls.Add(this.INPOnumbox);
            this.tabTeams.Controls.Add(this.TeamHCPrestigeNumBox);
            this.tabTeams.Controls.Add(this.TMARNumBox);
            this.tabTeams.Controls.Add(this.TMPRNumBox);
            this.tabTeams.Controls.Add(this.TeamCRPCNumber);
            this.tabTeams.Controls.Add(this.TeamCTPCNumber);
            this.tabTeams.Controls.Add(this.label42);
            this.tabTeams.Controls.Add(this.label39);
            this.tabTeams.Controls.Add(this.label40);
            this.tabTeams.Controls.Add(this.label41);
            this.tabTeams.Controls.Add(this.TeamCDPCBox);
            this.tabTeams.Controls.Add(this.label38);
            this.tabTeams.Controls.Add(this.TeamColor2Button);
            this.tabTeams.Controls.Add(this.TeamColor1Button);
            this.tabTeams.Controls.Add(this.HCLastNameBox);
            this.tabTeams.Controls.Add(this.label37);
            this.tabTeams.Controls.Add(this.label36);
            this.tabTeams.Controls.Add(this.label34);
            this.tabTeams.Controls.Add(this.label35);
            this.tabTeams.Controls.Add(this.label33);
            this.tabTeams.Controls.Add(this.label32);
            this.tabTeams.Controls.Add(this.HCFirstNameBox);
            this.tabTeams.Controls.Add(this.label31);
            this.tabTeams.Controls.Add(this.CoachPollBox);
            this.tabTeams.Controls.Add(this.label30);
            this.tabTeams.Controls.Add(this.SeasonRecordBox);
            this.tabTeams.Controls.Add(this.label28);
            this.tabTeams.Controls.Add(this.APPollBox);
            this.tabTeams.Controls.Add(this.label29);
            this.tabTeams.Controls.Add(this.ConfRecordBox);
            this.tabTeams.Controls.Add(this.label27);
            this.tabTeams.Controls.Add(this.LeagueBox);
            this.tabTeams.Controls.Add(this.label26);
            this.tabTeams.Controls.Add(this.TSNAtextBox);
            this.tabTeams.Controls.Add(this.label25);
            this.tabTeams.Controls.Add(this.TeamDivisionBox);
            this.tabTeams.Controls.Add(this.label24);
            this.tabTeams.Controls.Add(this.TeamConferenceBox);
            this.tabTeams.Controls.Add(this.TeamCaptain2box);
            this.tabTeams.Controls.Add(this.TeamCaptain1box);
            this.tabTeams.Controls.Add(this.label22);
            this.tabTeams.Controls.Add(this.label23);
            this.tabTeams.Controls.Add(this.label21);
            this.tabTeams.Controls.Add(this.label20);
            this.tabTeams.Controls.Add(this.label19);
            this.tabTeams.Controls.Add(this.TeamOVRtextbox);
            this.tabTeams.Controls.Add(this.TSI1textbox);
            this.tabTeams.Controls.Add(this.TSI2textbox);
            this.tabTeams.Controls.Add(this.TPIDtextbox);
            this.tabTeams.Controls.Add(this.TPIOtextbox);
            this.tabTeams.Controls.Add(this.label18);
            this.tabTeams.Controls.Add(this.label17);
            this.tabTeams.Controls.Add(this.label16);
            this.tabTeams.Controls.Add(this.label15);
            this.tabTeams.Controls.Add(this.label11);
            this.tabTeams.Controls.Add(this.TGIDtextBox);
            this.tabTeams.Controls.Add(this.label10);
            this.tabTeams.Controls.Add(this.TMNAtextBox);
            this.tabTeams.Controls.Add(this.label9);
            this.tabTeams.Controls.Add(this.TDNAtextBox);
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
            // PlaybookSelectBox
            // 
            this.PlaybookSelectBox.FormattingEnabled = true;
            this.PlaybookSelectBox.Location = new System.Drawing.Point(674, 407);
            this.PlaybookSelectBox.MaxLength = 2;
            this.PlaybookSelectBox.Name = "PlaybookSelectBox";
            this.PlaybookSelectBox.Size = new System.Drawing.Size(138, 21);
            this.PlaybookSelectBox.TabIndex = 126;
            this.PlaybookSelectBox.SelectedIndexChanged += new System.EventHandler(this.PlaybookSelectBox_SelectedIndexChanged);
            // 
            // DefTypeSelectBox
            // 
            this.DefTypeSelectBox.FormattingEnabled = true;
            this.DefTypeSelectBox.Location = new System.Drawing.Point(773, 445);
            this.DefTypeSelectBox.MaxLength = 2;
            this.DefTypeSelectBox.Name = "DefTypeSelectBox";
            this.DefTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.DefTypeSelectBox.TabIndex = 125;
            this.DefTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.DefTypeSelectBox_SelectedIndexChanged);
            // 
            // OffTypeSelectBox
            // 
            this.OffTypeSelectBox.FormattingEnabled = true;
            this.OffTypeSelectBox.Location = new System.Drawing.Point(581, 445);
            this.OffTypeSelectBox.MaxLength = 2;
            this.OffTypeSelectBox.Name = "OffTypeSelectBox";
            this.OffTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.OffTypeSelectBox.TabIndex = 124;
            this.OffTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.OffTypeSelectBox_SelectedIndexChanged);
            // 
            // CapacityNumbox
            // 
            this.CapacityNumbox.Location = new System.Drawing.Point(323, 532);
            this.CapacityNumbox.Maximum = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            this.CapacityNumbox.Name = "CapacityNumbox";
            this.CapacityNumbox.Size = new System.Drawing.Size(100, 20);
            this.CapacityNumbox.TabIndex = 123;
            this.CapacityNumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CapacityNumbox.ValueChanged += new System.EventHandler(this.CapacityNumbox_ValueChanged);
            // 
            // AttendanceNumBox
            // 
            this.AttendanceNumBox.Location = new System.Drawing.Point(213, 532);
            this.AttendanceNumBox.Maximum = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            this.AttendanceNumBox.Name = "AttendanceNumBox";
            this.AttendanceNumBox.Size = new System.Drawing.Size(100, 20);
            this.AttendanceNumBox.TabIndex = 122;
            this.AttendanceNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AttendanceNumBox.ValueChanged += new System.EventHandler(this.AttendanceNumBox_ValueChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(324, 516);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(48, 13);
            this.label59.TabIndex = 121;
            this.label59.Text = "Capacity";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(214, 516);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(62, 13);
            this.label60.TabIndex = 120;
            this.label60.Text = "Attendance";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(450, 473);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(32, 13);
            this.label57.TabIndex = 119;
            this.label57.Text = "State";
            // 
            // StateBox
            // 
            this.StateBox.FormattingEnabled = true;
            this.StateBox.Location = new System.Drawing.Point(450, 488);
            this.StateBox.MaxLength = 2;
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(44, 21);
            this.StateBox.TabIndex = 118;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(353, 473);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(24, 13);
            this.label56.TabIndex = 117;
            this.label56.Text = "City";
            // 
            // CityNameBox
            // 
            this.CityNameBox.Location = new System.Drawing.Point(347, 489);
            this.CityNameBox.Name = "CityNameBox";
            this.CityNameBox.Size = new System.Drawing.Size(95, 20);
            this.CityNameBox.TabIndex = 116;
            this.CityNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(214, 473);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(76, 13);
            this.label55.TabIndex = 115;
            this.label55.Text = "Stadium Name";
            // 
            // stadiumNameBox
            // 
            this.stadiumNameBox.Location = new System.Drawing.Point(213, 489);
            this.stadiumNameBox.Name = "stadiumNameBox";
            this.stadiumNameBox.Size = new System.Drawing.Size(127, 20);
            this.stadiumNameBox.TabIndex = 114;
            this.stadiumNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.SystemColors.Control;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(285, 439);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(143, 25);
            this.label54.TabIndex = 113;
            this.label54.Text = "Stadium Info";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.SystemColors.Control;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(669, 230);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(141, 25);
            this.label53.TabIndex = 112;
            this.label53.Text = "Head Coach";
            // 
            // UserCoachCheckBox
            // 
            this.UserCoachCheckBox.AutoSize = true;
            this.UserCoachCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCoachCheckBox.Location = new System.Drawing.Point(845, 11);
            this.UserCoachCheckBox.Name = "UserCoachCheckBox";
            this.UserCoachCheckBox.Size = new System.Drawing.Size(122, 24);
            this.UserCoachCheckBox.TabIndex = 111;
            this.UserCoachCheckBox.Text = "User Coach";
            this.UserCoachCheckBox.UseVisualStyleBackColor = true;
            this.UserCoachCheckBox.CheckedChanged += new System.EventHandler(this.UserCoachCheckBox_CheckedChanged);
            // 
            // FireCoachButton
            // 
            this.FireCoachButton.BackColor = System.Drawing.Color.RosyBrown;
            this.FireCoachButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FireCoachButton.Location = new System.Drawing.Point(829, 559);
            this.FireCoachButton.Name = "FireCoachButton";
            this.FireCoachButton.Size = new System.Drawing.Size(95, 41);
            this.FireCoachButton.TabIndex = 110;
            this.FireCoachButton.Text = "Fire Coach";
            this.FireCoachButton.UseVisualStyleBackColor = false;
            this.FireCoachButton.Click += new System.EventHandler(this.FireCoachButton_Click);
            // 
            // ResetSecondaryColorButton
            // 
            this.ResetSecondaryColorButton.Location = new System.Drawing.Point(387, 399);
            this.ResetSecondaryColorButton.Name = "ResetSecondaryColorButton";
            this.ResetSecondaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetSecondaryColorButton.TabIndex = 109;
            this.ResetSecondaryColorButton.Text = "Reset Color";
            this.ResetSecondaryColorButton.UseVisualStyleBackColor = true;
            this.ResetSecondaryColorButton.Click += new System.EventHandler(this.ResetSecondaryColorButton_Click);
            // 
            // ResetPrimaryColorButton
            // 
            this.ResetPrimaryColorButton.Location = new System.Drawing.Point(234, 399);
            this.ResetPrimaryColorButton.Name = "ResetPrimaryColorButton";
            this.ResetPrimaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetPrimaryColorButton.TabIndex = 108;
            this.ResetPrimaryColorButton.Text = "Reset Color";
            this.ResetPrimaryColorButton.UseVisualStyleBackColor = true;
            this.ResetPrimaryColorButton.Click += new System.EventHandler(this.ResetPrimaryColorButton_Click);
            // 
            // TeamCDTSbox
            // 
            this.TeamCDTSbox.Location = new System.Drawing.Point(874, 490);
            this.TeamCDTSbox.Name = "TeamCDTSbox";
            this.TeamCDTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTSbox.TabIndex = 107;
            this.TeamCDTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTSbox.ValueChanged += new System.EventHandler(this.TeamCDTSbox_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(880, 474);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(31, 13);
            this.label50.TabIndex = 106;
            this.label50.Text = "Subs";
            // 
            // TeamCDTAbox
            // 
            this.TeamCDTAbox.Location = new System.Drawing.Point(818, 490);
            this.TeamCDTAbox.Name = "TeamCDTAbox";
            this.TeamCDTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTAbox.TabIndex = 105;
            this.TeamCDTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTAbox.ValueChanged += new System.EventHandler(this.TeamCDTAbox_ValueChanged);
            // 
            // TeamCDTRbox
            // 
            this.TeamCDTRbox.Location = new System.Drawing.Point(762, 490);
            this.TeamCDTRbox.Name = "TeamCDTRbox";
            this.TeamCDTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTRbox.TabIndex = 104;
            this.TeamCDTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTRbox.ValueChanged += new System.EventHandler(this.TeamCDTRbox_ValueChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(803, 513);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(81, 13);
            this.label51.TabIndex = 103;
            this.label51.Text = "Aggressiveness";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(754, 474);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 102;
            this.label52.Text = "Passing Pct";
            // 
            // TeamCOTSbox
            // 
            this.TeamCOTSbox.Location = new System.Drawing.Point(682, 490);
            this.TeamCOTSbox.Name = "TeamCOTSbox";
            this.TeamCOTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTSbox.TabIndex = 101;
            this.TeamCOTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTSbox.ValueChanged += new System.EventHandler(this.TeamCOTSbox_ValueChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(688, 474);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 100;
            this.label49.Text = "Subs";
            // 
            // TeamCOTAbox
            // 
            this.TeamCOTAbox.Location = new System.Drawing.Point(626, 490);
            this.TeamCOTAbox.Name = "TeamCOTAbox";
            this.TeamCOTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTAbox.TabIndex = 99;
            this.TeamCOTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTAbox.ValueChanged += new System.EventHandler(this.TeamCOTAbox_ValueChanged);
            // 
            // TeamCOTRbox
            // 
            this.TeamCOTRbox.Location = new System.Drawing.Point(570, 490);
            this.TeamCOTRbox.Name = "TeamCOTRbox";
            this.TeamCOTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTRbox.TabIndex = 98;
            this.TeamCOTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTRbox.ValueChanged += new System.EventHandler(this.TeamCOTRbox_ValueChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(609, 513);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(81, 13);
            this.label47.TabIndex = 97;
            this.label47.Text = "Aggressiveness";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(561, 474);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 13);
            this.label48.TabIndex = 96;
            this.label48.Text = "Passing Pct";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(714, 391);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 94;
            this.label46.Text = "Playbook";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(587, 429);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(71, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Offense Type";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(783, 429);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(74, 13);
            this.label45.TabIndex = 90;
            this.label45.Text = "Base Defense";
            // 
            // TeamCCPONumBox
            // 
            this.TeamCCPONumBox.Location = new System.Drawing.Point(854, 290);
            this.TeamCCPONumBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TeamCCPONumBox.Name = "TeamCCPONumBox";
            this.TeamCCPONumBox.Size = new System.Drawing.Size(50, 20);
            this.TeamCCPONumBox.TabIndex = 89;
            this.TeamCCPONumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCCPONumBox.ValueChanged += new System.EventHandler(this.TeamCCPONumBox_ValueChanged);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(851, 274);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 88;
            this.label43.Text = "Performance";
            // 
            // SDURnumbox
            // 
            this.SDURnumbox.Location = new System.Drawing.Point(438, 289);
            this.SDURnumbox.Name = "SDURnumbox";
            this.SDURnumbox.Size = new System.Drawing.Size(50, 20);
            this.SDURnumbox.TabIndex = 87;
            this.SDURnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SDURnumbox.ValueChanged += new System.EventHandler(this.SDURnumbox_ValueChanged);
            // 
            // SNCTnumbox
            // 
            this.SNCTnumbox.Location = new System.Drawing.Point(378, 289);
            this.SNCTnumbox.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SNCTnumbox.Name = "SNCTnumbox";
            this.SNCTnumbox.Size = new System.Drawing.Size(50, 20);
            this.SNCTnumbox.TabIndex = 86;
            this.SNCTnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SNCTnumbox.ValueChanged += new System.EventHandler(this.SNCTnumbox_ValueChanged);
            // 
            // NCDPnumbox
            // 
            this.NCDPnumbox.Location = new System.Drawing.Point(290, 289);
            this.NCDPnumbox.Name = "NCDPnumbox";
            this.NCDPnumbox.Size = new System.Drawing.Size(50, 20);
            this.NCDPnumbox.TabIndex = 85;
            this.NCDPnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NCDPnumbox.ValueChanged += new System.EventHandler(this.NCDPnumbox_ValueChanged);
            // 
            // INPOnumbox
            // 
            this.INPOnumbox.Location = new System.Drawing.Point(210, 289);
            this.INPOnumbox.Name = "INPOnumbox";
            this.INPOnumbox.Size = new System.Drawing.Size(50, 20);
            this.INPOnumbox.TabIndex = 84;
            this.INPOnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.INPOnumbox.ValueChanged += new System.EventHandler(this.INPOnumbox_ValueChanged);
            // 
            // TeamHCPrestigeNumBox
            // 
            this.TeamHCPrestigeNumBox.Location = new System.Drawing.Point(787, 289);
            this.TeamHCPrestigeNumBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TeamHCPrestigeNumBox.Name = "TeamHCPrestigeNumBox";
            this.TeamHCPrestigeNumBox.Size = new System.Drawing.Size(50, 20);
            this.TeamHCPrestigeNumBox.TabIndex = 83;
            this.TeamHCPrestigeNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamHCPrestigeNumBox.ValueChanged += new System.EventHandler(this.TeamHCPrestigeNumBox_ValueChanged);
            // 
            // TMARNumBox
            // 
            this.TMARNumBox.Location = new System.Drawing.Point(297, 237);
            this.TMARNumBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TMARNumBox.Name = "TMARNumBox";
            this.TMARNumBox.Size = new System.Drawing.Size(50, 20);
            this.TMARNumBox.TabIndex = 82;
            this.TMARNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TMARNumBox.ValueChanged += new System.EventHandler(this.TMARNumBox_ValueChanged);
            // 
            // TMPRNumBox
            // 
            this.TMPRNumBox.Location = new System.Drawing.Point(210, 237);
            this.TMPRNumBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TMPRNumBox.Name = "TMPRNumBox";
            this.TMPRNumBox.Size = new System.Drawing.Size(50, 20);
            this.TMPRNumBox.TabIndex = 81;
            this.TMPRNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TMPRNumBox.ValueChanged += new System.EventHandler(this.TMPRNumBox_ValueChanged);
            // 
            // TeamCRPCNumber
            // 
            this.TeamCRPCNumber.Location = new System.Drawing.Point(791, 359);
            this.TeamCRPCNumber.Name = "TeamCRPCNumber";
            this.TeamCRPCNumber.Size = new System.Drawing.Size(50, 20);
            this.TeamCRPCNumber.TabIndex = 80;
            this.TeamCRPCNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCRPCNumber.ValueChanged += new System.EventHandler(this.TeamCRPCNumber_ValueChanged);
            // 
            // TeamCTPCNumber
            // 
            this.TeamCTPCNumber.Location = new System.Drawing.Point(722, 358);
            this.TeamCTPCNumber.Name = "TeamCTPCNumber";
            this.TeamCTPCNumber.Size = new System.Drawing.Size(50, 20);
            this.TeamCTPCNumber.TabIndex = 79;
            this.TeamCTPCNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCTPCNumber.ValueChanged += new System.EventHandler(this.TeamCTPCNumber_ValueChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(687, 326);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 13);
            this.label42.TabIndex = 78;
            this.label42.Text = "Off-Season Budget";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(788, 342);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 13);
            this.label39.TabIndex = 77;
            this.label39.Text = "Recruiting";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(727, 342);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(45, 13);
            this.label40.TabIndex = 75;
            this.label40.Text = "Training";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(652, 342);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 73;
            this.label41.Text = "Disciplining";
            // 
            // TeamCDPCBox
            // 
            this.TeamCDPCBox.Location = new System.Drawing.Point(655, 358);
            this.TeamCDPCBox.Name = "TeamCDPCBox";
            this.TeamCDPCBox.ReadOnly = true;
            this.TeamCDPCBox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDPCBox.TabIndex = 72;
            this.TeamCDPCBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(300, 322);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(109, 20);
            this.label38.TabIndex = 71;
            this.label38.Text = "Team Colors";
            // 
            // TeamColor2Button
            // 
            this.TeamColor2Button.Location = new System.Drawing.Point(363, 348);
            this.TeamColor2Button.Name = "TeamColor2Button";
            this.TeamColor2Button.Size = new System.Drawing.Size(125, 50);
            this.TeamColor2Button.TabIndex = 70;
            this.TeamColor2Button.UseVisualStyleBackColor = true;
            this.TeamColor2Button.Click += new System.EventHandler(this.TeamColor2Button_Click);
            // 
            // TeamColor1Button
            // 
            this.TeamColor1Button.Location = new System.Drawing.Point(209, 348);
            this.TeamColor1Button.Name = "TeamColor1Button";
            this.TeamColor1Button.Size = new System.Drawing.Size(125, 50);
            this.TeamColor1Button.TabIndex = 69;
            this.TeamColor1Button.UseVisualStyleBackColor = true;
            this.TeamColor1Button.Click += new System.EventHandler(this.TeamColor1Button_Click);
            // 
            // HCLastNameBox
            // 
            this.HCLastNameBox.Location = new System.Drawing.Point(686, 289);
            this.HCLastNameBox.Name = "HCLastNameBox";
            this.HCLastNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCLastNameBox.TabIndex = 68;
            this.HCLastNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCLastNameBox.TextChanged += new System.EventHandler(this.HCLastNameBox_TextChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(435, 273);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 13);
            this.label37.TabIndex = 67;
            this.label37.Text = "Duration";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(379, 273);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 13);
            this.label36.TabIndex = 65;
            this.label36.Text = "Sanction";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(287, 273);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 63;
            this.label34.Text = "Discipline Points";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(207, 273);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 13);
            this.label35.TabIndex = 61;
            this.label35.Text = "NCAA Interest";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(784, 273);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 59;
            this.label33.Text = "HC Prestige";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(586, 273);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 13);
            this.label32.TabIndex = 57;
            this.label32.Text = "Head Coach";
            // 
            // HCFirstNameBox
            // 
            this.HCFirstNameBox.Location = new System.Drawing.Point(585, 289);
            this.HCFirstNameBox.Name = "HCFirstNameBox";
            this.HCFirstNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCFirstNameBox.TabIndex = 56;
            this.HCFirstNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCFirstNameBox.TextChanged += new System.EventHandler(this.HCFirstNameBox_TextChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(265, 165);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 13);
            this.label31.TabIndex = 55;
            this.label31.Text = "Coach Poll";
            // 
            // CoachPollBox
            // 
            this.CoachPollBox.Location = new System.Drawing.Point(267, 181);
            this.CoachPollBox.Name = "CoachPollBox";
            this.CoachPollBox.ReadOnly = true;
            this.CoachPollBox.Size = new System.Drawing.Size(42, 20);
            this.CoachPollBox.TabIndex = 54;
            this.CoachPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(341, 165);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 53;
            this.label30.Text = "Record";
            // 
            // SeasonRecordBox
            // 
            this.SeasonRecordBox.Location = new System.Drawing.Point(339, 181);
            this.SeasonRecordBox.Name = "SeasonRecordBox";
            this.SeasonRecordBox.ReadOnly = true;
            this.SeasonRecordBox.Size = new System.Drawing.Size(65, 20);
            this.SeasonRecordBox.TabIndex = 52;
            this.SeasonRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(207, 165);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 51;
            this.label28.Text = "AP Poll";
            // 
            // APPollBox
            // 
            this.APPollBox.Location = new System.Drawing.Point(209, 181);
            this.APPollBox.Name = "APPollBox";
            this.APPollBox.ReadOnly = true;
            this.APPollBox.Size = new System.Drawing.Size(42, 20);
            this.APPollBox.TabIndex = 50;
            this.APPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(415, 165);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 13);
            this.label29.TabIndex = 49;
            this.label29.Text = "Conf";
            // 
            // ConfRecordBox
            // 
            this.ConfRecordBox.Location = new System.Drawing.Point(418, 181);
            this.ConfRecordBox.Name = "ConfRecordBox";
            this.ConfRecordBox.ReadOnly = true;
            this.ConfRecordBox.Size = new System.Drawing.Size(62, 20);
            this.ConfRecordBox.TabIndex = 48;
            this.ConfRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(305, 76);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = "League";
            // 
            // LeagueBox
            // 
            this.LeagueBox.Location = new System.Drawing.Point(304, 92);
            this.LeagueBox.Name = "LeagueBox";
            this.LeagueBox.ReadOnly = true;
            this.LeagueBox.Size = new System.Drawing.Size(42, 20);
            this.LeagueBox.TabIndex = 46;
            this.LeagueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(437, 121);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 45;
            this.label26.Text = "Abbr Name";
            // 
            // TSNAtextBox
            // 
            this.TSNAtextBox.Location = new System.Drawing.Point(440, 137);
            this.TSNAtextBox.Name = "TSNAtextBox";
            this.TSNAtextBox.Size = new System.Drawing.Size(46, 20);
            this.TSNAtextBox.TabIndex = 44;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(469, 75);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "Division";
            // 
            // TeamDivisionBox
            // 
            this.TeamDivisionBox.Location = new System.Drawing.Point(447, 92);
            this.TeamDivisionBox.Name = "TeamDivisionBox";
            this.TeamDivisionBox.ReadOnly = true;
            this.TeamDivisionBox.Size = new System.Drawing.Size(88, 20);
            this.TeamDivisionBox.TabIndex = 42;
            this.TeamDivisionBox.Text = "Division";
            this.TeamDivisionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(366, 75);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Conference";
            // 
            // TeamConferenceBox
            // 
            this.TeamConferenceBox.Location = new System.Drawing.Point(353, 92);
            this.TeamConferenceBox.Name = "TeamConferenceBox";
            this.TeamConferenceBox.ReadOnly = true;
            this.TeamConferenceBox.Size = new System.Drawing.Size(88, 20);
            this.TeamConferenceBox.TabIndex = 40;
            this.TeamConferenceBox.Text = "Conference";
            this.TeamConferenceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TeamCaptain2box
            // 
            this.TeamCaptain2box.Location = new System.Drawing.Point(776, 92);
            this.TeamCaptain2box.Name = "TeamCaptain2box";
            this.TeamCaptain2box.ReadOnly = true;
            this.TeamCaptain2box.Size = new System.Drawing.Size(138, 20);
            this.TeamCaptain2box.TabIndex = 39;
            // 
            // TeamCaptain1box
            // 
            this.TeamCaptain1box.Location = new System.Drawing.Point(576, 92);
            this.TeamCaptain1box.Name = "TeamCaptain1box";
            this.TeamCaptain1box.ReadOnly = true;
            this.TeamCaptain1box.Size = new System.Drawing.Size(138, 20);
            this.TeamCaptain1box.TabIndex = 38;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(773, 75);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Team Captain - Defense";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(573, 76);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 36;
            this.label23.Text = "Team Captain - Offense";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(294, 221);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Academic Prestige";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(207, 221);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Team Prestige";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(260, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Rating";
            // 
            // TeamOVRtextbox
            // 
            this.TeamOVRtextbox.Location = new System.Drawing.Point(256, 92);
            this.TeamOVRtextbox.Name = "TeamOVRtextbox";
            this.TeamOVRtextbox.ReadOnly = true;
            this.TeamOVRtextbox.Size = new System.Drawing.Size(42, 20);
            this.TeamOVRtextbox.TabIndex = 30;
            this.TeamOVRtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TSI1textbox
            // 
            this.TSI1textbox.Location = new System.Drawing.Point(576, 181);
            this.TSI1textbox.Name = "TSI1textbox";
            this.TSI1textbox.ReadOnly = true;
            this.TSI1textbox.Size = new System.Drawing.Size(138, 20);
            this.TSI1textbox.TabIndex = 29;
            // 
            // TSI2textbox
            // 
            this.TSI2textbox.Location = new System.Drawing.Point(776, 181);
            this.TSI2textbox.Name = "TSI2textbox";
            this.TSI2textbox.ReadOnly = true;
            this.TSI2textbox.Size = new System.Drawing.Size(138, 20);
            this.TSI2textbox.TabIndex = 28;
            // 
            // TPIDtextbox
            // 
            this.TPIDtextbox.Location = new System.Drawing.Point(776, 137);
            this.TPIDtextbox.Name = "TPIDtextbox";
            this.TPIDtextbox.ReadOnly = true;
            this.TPIDtextbox.Size = new System.Drawing.Size(138, 20);
            this.TPIDtextbox.TabIndex = 27;
            // 
            // TPIOtextbox
            // 
            this.TPIOtextbox.Location = new System.Drawing.Point(576, 137);
            this.TPIOtextbox.Name = "TPIOtextbox";
            this.TPIOtextbox.ReadOnly = true;
            this.TPIOtextbox.Size = new System.Drawing.Size(138, 20);
            this.TPIOtextbox.TabIndex = 26;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(773, 165);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Impact Player";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(573, 165);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Impact Player";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(773, 121);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Impact Player - Defense";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(573, 121);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Impact Player - Offense";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(205, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Team ID";
            // 
            // TGIDtextBox
            // 
            this.TGIDtextBox.Location = new System.Drawing.Point(206, 92);
            this.TGIDtextBox.Name = "TGIDtextBox";
            this.TGIDtextBox.ReadOnly = true;
            this.TGIDtextBox.Size = new System.Drawing.Size(44, 20);
            this.TGIDtextBox.TabIndex = 16;
            this.TGIDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(320, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Team Name";
            // 
            // TMNAtextBox
            // 
            this.TMNAtextBox.Location = new System.Drawing.Point(323, 137);
            this.TMNAtextBox.Name = "TMNAtextBox";
            this.TMNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.TMNAtextBox.TabIndex = 14;
            this.TMNAtextBox.TextChanged += new System.EventHandler(this.TMNAtextBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(206, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "College Name";
            // 
            // TDNAtextBox
            // 
            this.TDNAtextBox.Location = new System.Drawing.Point(209, 137);
            this.TDNAtextBox.Name = "TDNAtextBox";
            this.TDNAtextBox.Size = new System.Drawing.Size(100, 20);
            this.TDNAtextBox.TabIndex = 12;
            this.TDNAtextBox.TextChanged += new System.EventHandler(this.TDNAtextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(141, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Division";
            // 
            // DGIDcomboBox
            // 
            this.DGIDcomboBox.FormattingEnabled = true;
            this.DGIDcomboBox.Location = new System.Drawing.Point(138, 27);
            this.DGIDcomboBox.Name = "DGIDcomboBox";
            this.DGIDcomboBox.Size = new System.Drawing.Size(60, 21);
            this.DGIDcomboBox.TabIndex = 10;
            this.DGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.DGIDcomboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Conference";
            // 
            // CGIDcomboBox
            // 
            this.CGIDcomboBox.FormattingEnabled = true;
            this.CGIDcomboBox.Location = new System.Drawing.Point(72, 27);
            this.CGIDcomboBox.Name = "CGIDcomboBox";
            this.CGIDcomboBox.Size = new System.Drawing.Size(60, 21);
            this.CGIDcomboBox.TabIndex = 8;
            this.CGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.CGIDcomboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "League";
            // 
            // LGIDcomboBox
            // 
            this.LGIDcomboBox.FormattingEnabled = true;
            this.LGIDcomboBox.Location = new System.Drawing.Point(6, 27);
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
            this.LocationcheckBox.Size = new System.Drawing.Size(92, 17);
            this.LocationcheckBox.TabIndex = 5;
            this.LocationcheckBox.Text = "College Name";
            this.LocationcheckBox.UseVisualStyleBackColor = true;
            this.LocationcheckBox.CheckedChanged += new System.EventHandler(this.LocationcheckBox_CheckedChanged);
            // 
            // MascotcheckBox
            // 
            this.MascotcheckBox.AutoSize = true;
            this.MascotcheckBox.Location = new System.Drawing.Point(126, 606);
            this.MascotcheckBox.Name = "MascotcheckBox";
            this.MascotcheckBox.Size = new System.Drawing.Size(84, 17);
            this.MascotcheckBox.TabIndex = 4;
            this.MascotcheckBox.Text = "Team Name";
            this.MascotcheckBox.UseVisualStyleBackColor = true;
            this.MascotcheckBox.CheckedChanged += new System.EventHandler(this.MascotcheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(219, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Type";
            // 
            // TTYPcomboBox
            // 
            this.TTYPcomboBox.FormattingEnabled = true;
            this.TTYPcomboBox.Location = new System.Drawing.Point(204, 27);
            this.TTYPcomboBox.Name = "TTYPcomboBox";
            this.TTYPcomboBox.Size = new System.Drawing.Size(60, 21);
            this.TTYPcomboBox.TabIndex = 1;
            // 
            // TGIDlistBox
            // 
            this.TGIDlistBox.FormattingEnabled = true;
            this.TGIDlistBox.Location = new System.Drawing.Point(7, 76);
            this.TGIDlistBox.Name = "TGIDlistBox";
            this.TGIDlistBox.Size = new System.Drawing.Size(192, 524);
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
            // tabCoaches
            // 
            this.tabCoaches.Location = new System.Drawing.Point(4, 25);
            this.tabCoaches.Name = "tabCoaches";
            this.tabCoaches.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoaches.Size = new System.Drawing.Size(976, 632);
            this.tabCoaches.TabIndex = 7;
            this.tabCoaches.Text = "Coaches";
            this.tabCoaches.UseVisualStyleBackColor = true;
            // 
            // tabSeason
            // 
            this.tabSeason.BackColor = System.Drawing.Color.AntiqueWhite;
            this.tabSeason.Controls.Add(this.CoachPrestigeButton);
            this.tabSeason.Controls.Add(this.label14);
            this.tabSeason.Controls.Add(this.numberPlayerCoach);
            this.tabSeason.Controls.Add(this.buttonPlayerCoach);
            this.tabSeason.Controls.Add(this.buttonScheduleGen);
            this.tabSeason.Controls.Add(this.buttonRealignment);
            this.tabSeason.Controls.Add(this.label13);
            this.tabSeason.Controls.Add(this.labelMaxTransfers);
            this.tabSeason.Controls.Add(this.maxFiredTransfers);
            this.tabSeason.Controls.Add(this.checkBoxFiredTransfers);
            this.tabSeason.Controls.Add(this.buttonChaosTransfers);
            this.tabSeason.Controls.Add(this.labelMaxSkilDrop_PS);
            this.tabSeason.Controls.Add(this.MaxSkillDropPS);
            this.tabSeason.Controls.Add(this.labelPSInjuries);
            this.tabSeason.Controls.Add(this.numInjuries);
            this.tabSeason.Controls.Add(this.buttonPSInjuries);
            this.tabSeason.Controls.Add(this.checkBoxMedRSNEXT);
            this.tabSeason.Controls.Add(this.labelPoaching);
            this.tabSeason.Controls.Add(this.poachValue);
            this.tabSeason.Controls.Add(this.labelJobSecurity);
            this.tabSeason.Controls.Add(this.jobSecurityValue);
            this.tabSeason.Controls.Add(this.buttonCarousel);
            this.tabSeason.Controls.Add(this.labelSkillDrop);
            this.tabSeason.Controls.Add(this.skillDrop);
            this.tabSeason.Controls.Add(this.checkBoxInjuryRatings);
            this.tabSeason.Controls.Add(this.buttonRandomBudgets);
            this.tabSeason.Controls.Add(this.dbToolsInfo);
            this.tabSeason.Controls.Add(this.textBox1);
            this.tabSeason.Controls.Add(this.coachProg);
            this.tabSeason.Controls.Add(this.medRS);
            this.tabSeason.Location = new System.Drawing.Point(4, 25);
            this.tabSeason.Name = "tabSeason";
            this.tabSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeason.Size = new System.Drawing.Size(976, 632);
            this.tabSeason.TabIndex = 3;
            this.tabSeason.Text = "Dynasty";
            // 
            // CoachPrestigeButton
            // 
            this.CoachPrestigeButton.BackColor = System.Drawing.Color.Pink;
            this.CoachPrestigeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachPrestigeButton.Location = new System.Drawing.Point(315, 219);
            this.CoachPrestigeButton.Name = "CoachPrestigeButton";
            this.CoachPrestigeButton.Size = new System.Drawing.Size(110, 80);
            this.CoachPrestigeButton.TabIndex = 33;
            this.CoachPrestigeButton.Text = "Randomized Free Agent Coach Prestige";
            this.CoachPrestigeButton.UseVisualStyleBackColor = false;
            this.CoachPrestigeButton.Click += new System.EventHandler(this.CoachPrestigeButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(431, 601);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Number of Players";
            // 
            // numberPlayerCoach
            // 
            this.numberPlayerCoach.Location = new System.Drawing.Point(424, 578);
            this.numberPlayerCoach.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberPlayerCoach.Name = "numberPlayerCoach";
            this.numberPlayerCoach.Size = new System.Drawing.Size(120, 20);
            this.numberPlayerCoach.TabIndex = 31;
            // 
            // buttonPlayerCoach
            // 
            this.buttonPlayerCoach.BackColor = System.Drawing.Color.LightBlue;
            this.buttonPlayerCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerCoach.Location = new System.Drawing.Point(424, 495);
            this.buttonPlayerCoach.Name = "buttonPlayerCoach";
            this.buttonPlayerCoach.Size = new System.Drawing.Size(110, 80);
            this.buttonPlayerCoach.TabIndex = 30;
            this.buttonPlayerCoach.Text = "Players to Coach";
            this.buttonPlayerCoach.UseVisualStyleBackColor = false;
            this.buttonPlayerCoach.Click += new System.EventHandler(this.buttonPlayerCoach_Click);
            // 
            // buttonScheduleGen
            // 
            this.buttonScheduleGen.BackColor = System.Drawing.Color.DarkOrange;
            this.buttonScheduleGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonScheduleGen.Location = new System.Drawing.Point(315, 82);
            this.buttonScheduleGen.Name = "buttonScheduleGen";
            this.buttonScheduleGen.Size = new System.Drawing.Size(110, 80);
            this.buttonScheduleGen.TabIndex = 29;
            this.buttonScheduleGen.Text = "Quick n Dirty Schedule Generator";
            this.buttonScheduleGen.UseVisualStyleBackColor = false;
            this.buttonScheduleGen.Visible = false;
            this.buttonScheduleGen.Click += new System.EventHandler(this.buttonScheduleGen_Click);
            // 
            // buttonRealignment
            // 
            this.buttonRealignment.BackColor = System.Drawing.Color.CornflowerBlue;
            this.buttonRealignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRealignment.Location = new System.Drawing.Point(288, 495);
            this.buttonRealignment.Name = "buttonRealignment";
            this.buttonRealignment.Size = new System.Drawing.Size(110, 80);
            this.buttonRealignment.TabIndex = 28;
            this.buttonRealignment.Text = "Auto Realignment";
            this.buttonRealignment.UseVisualStyleBackColor = false;
            this.buttonRealignment.Click += new System.EventHandler(this.buttonRealignment_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(433, 375);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "NCAA NEXT 24 ONLY";
            // 
            // labelMaxTransfers
            // 
            this.labelMaxTransfers.AutoSize = true;
            this.labelMaxTransfers.Location = new System.Drawing.Point(447, 437);
            this.labelMaxTransfers.Name = "labelMaxTransfers";
            this.labelMaxTransfers.Size = new System.Drawing.Size(74, 13);
            this.labelMaxTransfers.TabIndex = 26;
            this.labelMaxTransfers.Text = "Max Transfers";
            // 
            // maxFiredTransfers
            // 
            this.maxFiredTransfers.Location = new System.Drawing.Point(450, 414);
            this.maxFiredTransfers.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.maxFiredTransfers.Name = "maxFiredTransfers";
            this.maxFiredTransfers.Size = new System.Drawing.Size(52, 20);
            this.maxFiredTransfers.TabIndex = 25;
            // 
            // checkBoxFiredTransfers
            // 
            this.checkBoxFiredTransfers.AutoSize = true;
            this.checkBoxFiredTransfers.Location = new System.Drawing.Point(450, 391);
            this.checkBoxFiredTransfers.Name = "checkBoxFiredTransfers";
            this.checkBoxFiredTransfers.Size = new System.Drawing.Size(98, 17);
            this.checkBoxFiredTransfers.TabIndex = 24;
            this.checkBoxFiredTransfers.Text = "Transfer Chaos";
            this.checkBoxFiredTransfers.UseVisualStyleBackColor = true;
            // 
            // buttonChaosTransfers
            // 
            this.buttonChaosTransfers.BackColor = System.Drawing.Color.LightGray;
            this.buttonChaosTransfers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChaosTransfers.Location = new System.Drawing.Point(157, 495);
            this.buttonChaosTransfers.Name = "buttonChaosTransfers";
            this.buttonChaosTransfers.Size = new System.Drawing.Size(110, 80);
            this.buttonChaosTransfers.TabIndex = 23;
            this.buttonChaosTransfers.Text = "Transfer Chaos";
            this.buttonChaosTransfers.UseVisualStyleBackColor = false;
            this.buttonChaosTransfers.Visible = false;
            this.buttonChaosTransfers.Click += new System.EventHandler(this.buttonChaosTransfers_Click);
            // 
            // labelMaxSkilDrop_PS
            // 
            this.labelMaxSkilDrop_PS.AutoSize = true;
            this.labelMaxSkilDrop_PS.Location = new System.Drawing.Point(191, 140);
            this.labelMaxSkilDrop_PS.Name = "labelMaxSkilDrop_PS";
            this.labelMaxSkilDrop_PS.Size = new System.Drawing.Size(75, 13);
            this.labelMaxSkilDrop_PS.TabIndex = 22;
            this.labelMaxSkilDrop_PS.Text = "Max Skill Drop";
            // 
            // MaxSkillDropPS
            // 
            this.MaxSkillDropPS.Location = new System.Drawing.Point(143, 138);
            this.MaxSkillDropPS.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxSkillDropPS.Name = "MaxSkillDropPS";
            this.MaxSkillDropPS.Size = new System.Drawing.Size(44, 20);
            this.MaxSkillDropPS.TabIndex = 21;
            this.MaxSkillDropPS.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelPSInjuries
            // 
            this.labelPSInjuries.AutoSize = true;
            this.labelPSInjuries.Location = new System.Drawing.Point(140, 111);
            this.labelPSInjuries.Name = "labelPSInjuries";
            this.labelPSInjuries.Size = new System.Drawing.Size(93, 13);
            this.labelPSInjuries.TabIndex = 20;
            this.labelPSInjuries.Text = "Number of Players";
            // 
            // numInjuries
            // 
            this.numInjuries.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numInjuries.Location = new System.Drawing.Point(143, 88);
            this.numInjuries.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numInjuries.Name = "numInjuries";
            this.numInjuries.Size = new System.Drawing.Size(60, 20);
            this.numInjuries.TabIndex = 19;
            this.numInjuries.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // buttonPSInjuries
            // 
            this.buttonPSInjuries.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonPSInjuries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPSInjuries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPSInjuries.Location = new System.Drawing.Point(28, 82);
            this.buttonPSInjuries.Name = "buttonPSInjuries";
            this.buttonPSInjuries.Size = new System.Drawing.Size(110, 80);
            this.buttonPSInjuries.TabIndex = 18;
            this.buttonPSInjuries.Text = "Pre-Season Injuries";
            this.buttonPSInjuries.UseVisualStyleBackColor = false;
            this.buttonPSInjuries.Click += new System.EventHandler(this.ButtonPSInjuries_Click);
            // 
            // checkBoxMedRSNEXT
            // 
            this.checkBoxMedRSNEXT.AutoSize = true;
            this.checkBoxMedRSNEXT.Checked = true;
            this.checkBoxMedRSNEXT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMedRSNEXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMedRSNEXT.Location = new System.Drawing.Point(143, 282);
            this.checkBoxMedRSNEXT.Name = "checkBoxMedRSNEXT";
            this.checkBoxMedRSNEXT.Size = new System.Drawing.Size(104, 17);
            this.checkBoxMedRSNEXT.TabIndex = 17;
            this.checkBoxMedRSNEXT.Text = "NCAA Next Mod";
            this.checkBoxMedRSNEXT.UseVisualStyleBackColor = true;
            // 
            // labelPoaching
            // 
            this.labelPoaching.AutoSize = true;
            this.labelPoaching.Location = new System.Drawing.Point(357, 437);
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
            this.poachValue.Location = new System.Drawing.Point(361, 417);
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
            this.labelJobSecurity.Location = new System.Drawing.Point(360, 400);
            this.labelJobSecurity.Name = "labelJobSecurity";
            this.labelJobSecurity.Size = new System.Drawing.Size(65, 13);
            this.labelJobSecurity.TabIndex = 14;
            this.labelJobSecurity.Text = "Job Security";
            // 
            // jobSecurityValue
            // 
            this.jobSecurityValue.Increment = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.jobSecurityValue.Location = new System.Drawing.Point(360, 377);
            this.jobSecurityValue.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.jobSecurityValue.Name = "jobSecurityValue";
            this.jobSecurityValue.Size = new System.Drawing.Size(52, 20);
            this.jobSecurityValue.TabIndex = 13;
            // 
            // buttonCarousel
            // 
            this.buttonCarousel.BackColor = System.Drawing.Color.HotPink;
            this.buttonCarousel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarousel.Location = new System.Drawing.Point(245, 372);
            this.buttonCarousel.Name = "buttonCarousel";
            this.buttonCarousel.Size = new System.Drawing.Size(110, 80);
            this.buttonCarousel.TabIndex = 12;
            this.buttonCarousel.Text = "Coaching Carousel";
            this.buttonCarousel.UseVisualStyleBackColor = false;
            this.buttonCarousel.Click += new System.EventHandler(this.ButtonCarousel_Click);
            // 
            // labelSkillDrop
            // 
            this.labelSkillDrop.AutoSize = true;
            this.labelSkillDrop.Location = new System.Drawing.Point(192, 252);
            this.labelSkillDrop.Name = "labelSkillDrop";
            this.labelSkillDrop.Size = new System.Drawing.Size(75, 13);
            this.labelSkillDrop.TabIndex = 11;
            this.labelSkillDrop.Text = "Max Skill Drop";
            // 
            // skillDrop
            // 
            this.skillDrop.Location = new System.Drawing.Point(144, 250);
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
            this.checkBoxInjuryRatings.Location = new System.Drawing.Point(143, 219);
            this.checkBoxInjuryRatings.Name = "checkBoxInjuryRatings";
            this.checkBoxInjuryRatings.Size = new System.Drawing.Size(103, 17);
            this.checkBoxInjuryRatings.TabIndex = 9;
            this.checkBoxInjuryRatings.Text = "Reduce Ratings";
            this.checkBoxInjuryRatings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxInjuryRatings.UseVisualStyleBackColor = true;
            // 
            // buttonRandomBudgets
            // 
            this.buttonRandomBudgets.BackColor = System.Drawing.Color.SandyBrown;
            this.buttonRandomBudgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomBudgets.Location = new System.Drawing.Point(28, 495);
            this.buttonRandomBudgets.Name = "buttonRandomBudgets";
            this.buttonRandomBudgets.Size = new System.Drawing.Size(110, 80);
            this.buttonRandomBudgets.TabIndex = 7;
            this.buttonRandomBudgets.Text = "Randomize Coaching Budgets";
            this.buttonRandomBudgets.UseVisualStyleBackColor = false;
            this.buttonRandomBudgets.Click += new System.EventHandler(this.ButtonRandomBudgets_Click);
            // 
            // dbToolsInfo
            // 
            this.dbToolsInfo.BackColor = System.Drawing.Color.AntiqueWhite;
            this.dbToolsInfo.Enabled = false;
            this.dbToolsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbToolsInfo.Location = new System.Drawing.Point(566, 6);
            this.dbToolsInfo.Multiline = true;
            this.dbToolsInfo.Name = "dbToolsInfo";
            this.dbToolsInfo.Size = new System.Drawing.Size(407, 620);
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
            this.textBox1.Text = "NCAA Football Dynasty Toolkit";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // coachProg
            // 
            this.coachProg.BackColor = System.Drawing.Color.DodgerBlue;
            this.coachProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coachProg.ForeColor = System.Drawing.SystemColors.Control;
            this.coachProg.Location = new System.Drawing.Point(28, 370);
            this.coachProg.Name = "coachProg";
            this.coachProg.Size = new System.Drawing.Size(110, 80);
            this.coachProg.TabIndex = 1;
            this.coachProg.Text = "Coach Progression";
            this.coachProg.UseVisualStyleBackColor = false;
            this.coachProg.Click += new System.EventHandler(this.CoachProg_Click);
            // 
            // medRS
            // 
            this.medRS.BackColor = System.Drawing.Color.Crimson;
            this.medRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medRS.ForeColor = System.Drawing.SystemColors.Control;
            this.medRS.Location = new System.Drawing.Point(28, 219);
            this.medRS.Name = "medRS";
            this.medRS.Size = new System.Drawing.Size(110, 80);
            this.medRS.TabIndex = 0;
            this.medRS.Text = "Medical Redshirt";
            this.medRS.UseVisualStyleBackColor = false;
            this.medRS.Click += new System.EventHandler(this.MedRS_Click);
            // 
            // tabOffSeason
            // 
            this.tabOffSeason.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOffSeason.Controls.Add(this.buttonRandomizeFaceShape);
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
            // buttonRandomizeFaceShape
            // 
            this.buttonRandomizeFaceShape.BackColor = System.Drawing.Color.Moccasin;
            this.buttonRandomizeFaceShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomizeFaceShape.Location = new System.Drawing.Point(144, 363);
            this.buttonRandomizeFaceShape.Name = "buttonRandomizeFaceShape";
            this.buttonRandomizeFaceShape.Size = new System.Drawing.Size(110, 80);
            this.buttonRandomizeFaceShape.TabIndex = 20;
            this.buttonRandomizeFaceShape.Text = "Randomize Recruits Face/Skin";
            this.buttonRandomizeFaceShape.UseVisualStyleBackColor = false;
            this.buttonRandomizeFaceShape.Click += new System.EventHandler(this.buttonRandomizeFaceSkin_Click);
            // 
            // labelPolyNamesPCT
            // 
            this.labelPolyNamesPCT.AutoSize = true;
            this.labelPolyNamesPCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPolyNamesPCT.Location = new System.Drawing.Point(59, 591);
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
            this.polyNamesPCT.Location = new System.Drawing.Point(73, 568);
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
            this.polyNames.Location = new System.Drawing.Point(144, 546);
            this.polyNames.Name = "polyNames";
            this.polyNames.Size = new System.Drawing.Size(110, 70);
            this.polyNames.TabIndex = 17;
            this.polyNames.Text = "Polynesian Last Name Generator";
            this.polyNames.UseVisualStyleBackColor = false;
            this.polyNames.Click += new System.EventHandler(this.PolyNames_Click);
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
            this.buttonInterestedTeams.Click += new System.EventHandler(this.ButtonInterestedTeams_Click);
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
            this.labelRecruit.Location = new System.Drawing.Point(60, 314);
            this.labelRecruit.Name = "labelRecruit";
            this.labelRecruit.Size = new System.Drawing.Size(78, 16);
            this.labelRecruit.TabIndex = 7;
            this.labelRecruit.Text = "Tolerance";
            this.labelRecruit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // recruitTolerance
            // 
            this.recruitTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recruitTolerance.Location = new System.Drawing.Point(74, 289);
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
            this.wkonLabel.Location = new System.Drawing.Point(59, 502);
            this.wkonLabel.Name = "wkonLabel";
            this.wkonLabel.Size = new System.Drawing.Size(78, 16);
            this.wkonLabel.TabIndex = 5;
            this.wkonLabel.Text = "Tolerance";
            this.wkonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toleranceWalkOn
            // 
            this.toleranceWalkOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toleranceWalkOn.Location = new System.Drawing.Point(73, 477);
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
            this.buttonRandRecruits.Location = new System.Drawing.Point(144, 268);
            this.buttonRandRecruits.Name = "buttonRandRecruits";
            this.buttonRandRecruits.Size = new System.Drawing.Size(110, 80);
            this.buttonRandRecruits.TabIndex = 3;
            this.buttonRandRecruits.Text = "Randomize Recruits";
            this.buttonRandRecruits.UseVisualStyleBackColor = false;
            this.buttonRandRecruits.Click += new System.EventHandler(this.ButtonRandRecruits_Click);
            // 
            // buttonRandWalkOns
            // 
            this.buttonRandWalkOns.BackColor = System.Drawing.Color.BurlyWood;
            this.buttonRandWalkOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandWalkOns.Location = new System.Drawing.Point(144, 449);
            this.buttonRandWalkOns.Name = "buttonRandWalkOns";
            this.buttonRandWalkOns.Size = new System.Drawing.Size(110, 80);
            this.buttonRandWalkOns.TabIndex = 2;
            this.buttonRandWalkOns.Text = "Randomize Walk-Ons";
            this.buttonRandWalkOns.UseVisualStyleBackColor = false;
            this.buttonRandWalkOns.Click += new System.EventHandler(this.ButtonRandWalkOns_Click);
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
            this.buttonMinRecruitingPts.Click += new System.EventHandler(this.ButtonMinRecruitingPts_Click);
            // 
            // tabTools
            // 
            this.tabTools.BackColor = System.Drawing.Color.PeachPuff;
            this.tabTools.Controls.Add(this.RandomizeHeadButton);
            this.tabTools.Controls.Add(this.label58);
            this.tabTools.Controls.Add(this.FillRosterPCT);
            this.tabTools.Controls.Add(this.buttonFillRosters);
            this.tabTools.Controls.Add(this.buttonAutoDepthChart);
            this.tabTools.Controls.Add(this.buttonFantasyRoster);
            this.tabTools.Controls.Add(this.buttonImpactPlayers);
            this.tabTools.Controls.Add(this.TYDNButton);
            this.tabTools.Controls.Add(this.buttonCalcOverall);
            this.tabTools.Controls.Add(this.textBox3);
            this.tabTools.Controls.Add(this.textBox2);
            this.tabTools.Controls.Add(this.buttonRandPotential);
            this.tabTools.Controls.Add(qbTend);
            this.tabTools.Controls.Add(this.increaseSpeed);
            this.tabTools.Controls.Add(this.bodyFix);
            this.tabTools.Location = new System.Drawing.Point(4, 25);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(976, 632);
            this.tabTools.TabIndex = 5;
            this.tabTools.Text = "dbTools";
            // 
            // RandomizeHeadButton
            // 
            this.RandomizeHeadButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.RandomizeHeadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomizeHeadButton.Location = new System.Drawing.Point(166, 35);
            this.RandomizeHeadButton.Name = "RandomizeHeadButton";
            this.RandomizeHeadButton.Size = new System.Drawing.Size(110, 80);
            this.RandomizeHeadButton.TabIndex = 24;
            this.RandomizeHeadButton.Text = "Randomize Player Head/Face";
            this.RandomizeHeadButton.UseVisualStyleBackColor = false;
            this.RandomizeHeadButton.Click += new System.EventHandler(this.RandomizeHeadButton_Click);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(63, 599);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(77, 13);
            this.label58.TabIndex = 23;
            this.label58.Text = "PCT Freshman";
            // 
            // FillRosterPCT
            // 
            this.FillRosterPCT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FillRosterPCT.Location = new System.Drawing.Point(79, 576);
            this.FillRosterPCT.Name = "FillRosterPCT";
            this.FillRosterPCT.Size = new System.Drawing.Size(42, 20);
            this.FillRosterPCT.TabIndex = 22;
            this.FillRosterPCT.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // buttonFillRosters
            // 
            this.buttonFillRosters.BackColor = System.Drawing.Color.DarkGray;
            this.buttonFillRosters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFillRosters.Location = new System.Drawing.Point(45, 490);
            this.buttonFillRosters.Name = "buttonFillRosters";
            this.buttonFillRosters.Size = new System.Drawing.Size(110, 80);
            this.buttonFillRosters.TabIndex = 20;
            this.buttonFillRosters.Text = "Fill Rosters";
            this.buttonFillRosters.UseVisualStyleBackColor = false;
            this.buttonFillRosters.Click += new System.EventHandler(this.buttonFillRosters_Click);
            // 
            // buttonAutoDepthChart
            // 
            this.buttonAutoDepthChart.BackColor = System.Drawing.Color.DarkGray;
            this.buttonAutoDepthChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAutoDepthChart.Location = new System.Drawing.Point(166, 390);
            this.buttonAutoDepthChart.Name = "buttonAutoDepthChart";
            this.buttonAutoDepthChart.Size = new System.Drawing.Size(110, 80);
            this.buttonAutoDepthChart.TabIndex = 19;
            this.buttonAutoDepthChart.Text = "Auto-Set Depth Chart";
            this.buttonAutoDepthChart.UseVisualStyleBackColor = false;
            this.buttonAutoDepthChart.Click += new System.EventHandler(this.buttonAutoDepthChart_Click);
            // 
            // buttonFantasyRoster
            // 
            this.buttonFantasyRoster.BackColor = System.Drawing.Color.DarkGray;
            this.buttonFantasyRoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFantasyRoster.Location = new System.Drawing.Point(166, 490);
            this.buttonFantasyRoster.Name = "buttonFantasyRoster";
            this.buttonFantasyRoster.Size = new System.Drawing.Size(110, 80);
            this.buttonFantasyRoster.TabIndex = 18;
            this.buttonFantasyRoster.Text = "Generate Fantasy Roster";
            this.buttonFantasyRoster.UseVisualStyleBackColor = false;
            this.buttonFantasyRoster.Click += new System.EventHandler(this.buttonFantasyRoster_Click);
            // 
            // buttonImpactPlayers
            // 
            this.buttonImpactPlayers.BackColor = System.Drawing.Color.DarkGray;
            this.buttonImpactPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImpactPlayers.Location = new System.Drawing.Point(45, 390);
            this.buttonImpactPlayers.Name = "buttonImpactPlayers";
            this.buttonImpactPlayers.Size = new System.Drawing.Size(110, 80);
            this.buttonImpactPlayers.TabIndex = 17;
            this.buttonImpactPlayers.Text = "Determine Impact Players";
            this.buttonImpactPlayers.UseVisualStyleBackColor = false;
            this.buttonImpactPlayers.Click += new System.EventHandler(this.buttonImpactPlayers_Click);
            // 
            // TYDNButton
            // 
            this.TYDNButton.BackColor = System.Drawing.Color.DarkGray;
            this.TYDNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TYDNButton.Location = new System.Drawing.Point(166, 290);
            this.TYDNButton.Name = "TYDNButton";
            this.TYDNButton.Size = new System.Drawing.Size(110, 80);
            this.TYDNButton.TabIndex = 16;
            this.TYDNButton.Text = "Recalculate Team Ratings";
            this.TYDNButton.UseVisualStyleBackColor = false;
            this.TYDNButton.Click += new System.EventHandler(this.TYDNButton_Click);
            // 
            // buttonCalcOverall
            // 
            this.buttonCalcOverall.BackColor = System.Drawing.Color.DarkGray;
            this.buttonCalcOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcOverall.Location = new System.Drawing.Point(45, 290);
            this.buttonCalcOverall.Name = "buttonCalcOverall";
            this.buttonCalcOverall.Size = new System.Drawing.Size(110, 80);
            this.buttonCalcOverall.TabIndex = 15;
            this.buttonCalcOverall.Text = "Recalculate Player Overall";
            this.buttonCalcOverall.UseVisualStyleBackColor = false;
            this.buttonCalcOverall.Click += new System.EventHandler(this.buttonCalcOverall_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(45, 236);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(355, 33);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "NCAA Football Modding Toolkit";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(535, 25);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(407, 589);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // buttonRandPotential
            // 
            this.buttonRandPotential.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonRandPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandPotential.Location = new System.Drawing.Point(290, 140);
            this.buttonRandPotential.Name = "buttonRandPotential";
            this.buttonRandPotential.Size = new System.Drawing.Size(110, 80);
            this.buttonRandPotential.TabIndex = 12;
            this.buttonRandPotential.Text = "Randomize Player Potential";
            this.buttonRandPotential.UseVisualStyleBackColor = false;
            this.buttonRandPotential.Click += new System.EventHandler(this.ButtonRandPotential_Click);
            // 
            // increaseSpeed
            // 
            this.increaseSpeed.BackColor = System.Drawing.Color.MediumAquamarine;
            this.increaseSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.increaseSpeed.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.increaseSpeed.Location = new System.Drawing.Point(290, 35);
            this.increaseSpeed.Name = "increaseSpeed";
            this.increaseSpeed.Size = new System.Drawing.Size(110, 80);
            this.increaseSpeed.TabIndex = 10;
            this.increaseSpeed.Text = "Increase Minimum Skill Position Speed";
            this.increaseSpeed.UseVisualStyleBackColor = false;
            this.increaseSpeed.Click += new System.EventHandler(this.IncreaseSpeed_Click);
            // 
            // bodyFix
            // 
            this.bodyFix.BackColor = System.Drawing.Color.Gold;
            this.bodyFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyFix.Location = new System.Drawing.Point(45, 35);
            this.bodyFix.Name = "bodyFix";
            this.bodyFix.Size = new System.Drawing.Size(110, 80);
            this.bodyFix.TabIndex = 9;
            this.bodyFix.Text = "Body Size Fixer";
            this.bodyFix.UseVisualStyleBackColor = false;
            this.bodyFix.Click += new System.EventHandler(this.BodyFix_Click);
            // 
            // tabDev
            // 
            this.tabDev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabDev.Controls.Add(this.textBox20);
            this.tabDev.Controls.Add(this.textBox19);
            this.tabDev.Controls.Add(this.textBox18);
            this.tabDev.Controls.Add(this.textBox17);
            this.tabDev.Controls.Add(this.textBox16);
            this.tabDev.Controls.Add(this.textBox15);
            this.tabDev.Controls.Add(this.textBox14);
            this.tabDev.Controls.Add(this.textBox13);
            this.tabDev.Controls.Add(this.textBox12);
            this.tabDev.Controls.Add(this.textBox11);
            this.tabDev.Controls.Add(this.textBox10);
            this.tabDev.Controls.Add(this.textBox9);
            this.tabDev.Controls.Add(this.textBox8);
            this.tabDev.Controls.Add(this.textBox7);
            this.tabDev.Controls.Add(this.textBox5);
            this.tabDev.Controls.Add(this.textBox4);
            this.tabDev.Controls.Add(this.DevCalcTeamRatingsButton);
            this.tabDev.Controls.Add(this.DevDepthChartButton);
            this.tabDev.Controls.Add(this.DevRandomizeFaceButton);
            this.tabDev.Controls.Add(this.DevCalcOVRButton);
            this.tabDev.Controls.Add(this.DevFillRosterButton);
            this.tabDev.Controls.Add(this.CreateTransfersCSVButton);
            this.tabDev.Controls.Add(this.textBox6);
            this.tabDev.Controls.Add(this.ImportRecruitsButton);
            this.tabDev.Controls.Add(this.GraduateButton);
            this.tabDev.Location = new System.Drawing.Point(4, 25);
            this.tabDev.Name = "tabDev";
            this.tabDev.Padding = new System.Windows.Forms.Padding(3);
            this.tabDev.Size = new System.Drawing.Size(976, 632);
            this.tabDev.TabIndex = 8;
            this.tabDev.Text = "Dev";
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox20.Enabled = false;
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(500, 562);
            this.textBox20.Multiline = true;
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(49, 41);
            this.textBox20.TabIndex = 49;
            this.textBox20.Text = "8";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox19.Enabled = false;
            this.textBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.Location = new System.Drawing.Point(500, 444);
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(49, 41);
            this.textBox19.TabIndex = 48;
            this.textBox19.Text = "7";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox18.Enabled = false;
            this.textBox18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.Location = new System.Drawing.Point(500, 332);
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(49, 41);
            this.textBox18.TabIndex = 47;
            this.textBox18.Text = "6";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox17.Enabled = false;
            this.textBox17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(500, 212);
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(49, 41);
            this.textBox17.TabIndex = 46;
            this.textBox17.Text = "5";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox16.Enabled = false;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(16, 562);
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(49, 41);
            this.textBox16.TabIndex = 45;
            this.textBox16.Text = "4";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox15.Enabled = false;
            this.textBox15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.Location = new System.Drawing.Point(16, 444);
            this.textBox15.Multiline = true;
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(49, 41);
            this.textBox15.TabIndex = 44;
            this.textBox15.Text = "3";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox14.Enabled = false;
            this.textBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.Location = new System.Drawing.Point(16, 333);
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(49, 41);
            this.textBox14.TabIndex = 43;
            this.textBox14.Text = "2";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox13.Enabled = false;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(16, 212);
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(49, 41);
            this.textBox13.TabIndex = 42;
            this.textBox13.Text = "1";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox12.Enabled = false;
            this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.Location = new System.Drawing.Point(703, 546);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(247, 80);
            this.textBox12.TabIndex = 41;
            this.textBox12.Text = "Calculates Team Ratings";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox11.Enabled = false;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(703, 428);
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(247, 80);
            this.textBox11.TabIndex = 40;
            this.textBox11.Text = "Sets Depth Charts";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.Location = new System.Drawing.Point(703, 316);
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(247, 80);
            this.textBox10.TabIndex = 39;
            this.textBox10.Text = "Randomizes all player faces/heads";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox9.Enabled = false;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(703, 196);
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(247, 80);
            this.textBox9.TabIndex = 38;
            this.textBox9.Text = "Fills Rosters with Randomly Generated Players \r\nand Checks for Position Depth";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox8.Enabled = false;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(219, 546);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(247, 80);
            this.textBox8.TabIndex = 37;
            this.textBox8.Text = "Calculate Overall Ratings";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.Location = new System.Drawing.Point(219, 426);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(247, 80);
            this.textBox7.TabIndex = 36;
            this.textBox7.Text = "Create Transfers - Creates Transfer based on transfers-gen.csv file  \r\n(first nam" +
    "e, last name, position id, team id)";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(219, 316);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(247, 80);
            this.textBox5.TabIndex = 35;
            this.textBox5.Text = "Import Recruits - Creates Recruits based on recruits.csv file  \r\n(first name, las" +
    "t name, position id, team id, height in inches, weight - 160)";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(219, 196);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(247, 80);
            this.textBox4.TabIndex = 34;
            this.textBox4.Text = "Graduate Players - Removes Players marked with PTYP = 3 and Transfer Players Mark" +
    "ed PTYP =1 and relocates them per transfers.csv file. \r\nTransfer CSV colums:  Pl" +
    "ayer Name, new TGID, PGID, 0";
            // 
            // DevCalcTeamRatingsButton
            // 
            this.DevCalcTeamRatingsButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevCalcTeamRatingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevCalcTeamRatingsButton.Location = new System.Drawing.Point(555, 546);
            this.DevCalcTeamRatingsButton.Name = "DevCalcTeamRatingsButton";
            this.DevCalcTeamRatingsButton.Size = new System.Drawing.Size(110, 80);
            this.DevCalcTeamRatingsButton.TabIndex = 33;
            this.DevCalcTeamRatingsButton.Text = "Calculate Team Ratings";
            this.DevCalcTeamRatingsButton.UseVisualStyleBackColor = false;
            this.DevCalcTeamRatingsButton.Click += new System.EventHandler(this.DevCalcTeamRatingsButton_Click);
            // 
            // DevDepthChartButton
            // 
            this.DevDepthChartButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevDepthChartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevDepthChartButton.Location = new System.Drawing.Point(555, 428);
            this.DevDepthChartButton.Name = "DevDepthChartButton";
            this.DevDepthChartButton.Size = new System.Drawing.Size(110, 80);
            this.DevDepthChartButton.TabIndex = 32;
            this.DevDepthChartButton.Text = "Set Depth Charts";
            this.DevDepthChartButton.UseVisualStyleBackColor = false;
            this.DevDepthChartButton.Click += new System.EventHandler(this.DevDepthChartButton_Click);
            // 
            // DevRandomizeFaceButton
            // 
            this.DevRandomizeFaceButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevRandomizeFaceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevRandomizeFaceButton.Location = new System.Drawing.Point(555, 316);
            this.DevRandomizeFaceButton.Name = "DevRandomizeFaceButton";
            this.DevRandomizeFaceButton.Size = new System.Drawing.Size(110, 80);
            this.DevRandomizeFaceButton.TabIndex = 31;
            this.DevRandomizeFaceButton.Text = "Randomize Faces";
            this.DevRandomizeFaceButton.UseVisualStyleBackColor = false;
            this.DevRandomizeFaceButton.Click += new System.EventHandler(this.DevRandomizeFaceButton_Click);
            // 
            // DevCalcOVRButton
            // 
            this.DevCalcOVRButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevCalcOVRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevCalcOVRButton.Location = new System.Drawing.Point(77, 546);
            this.DevCalcOVRButton.Name = "DevCalcOVRButton";
            this.DevCalcOVRButton.Size = new System.Drawing.Size(110, 80);
            this.DevCalcOVRButton.TabIndex = 30;
            this.DevCalcOVRButton.Text = "Calculate Overalls";
            this.DevCalcOVRButton.UseVisualStyleBackColor = false;
            this.DevCalcOVRButton.Click += new System.EventHandler(this.DevCalcOVRButton_Click);
            // 
            // DevFillRosterButton
            // 
            this.DevFillRosterButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevFillRosterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevFillRosterButton.Location = new System.Drawing.Point(555, 196);
            this.DevFillRosterButton.Name = "DevFillRosterButton";
            this.DevFillRosterButton.Size = new System.Drawing.Size(110, 80);
            this.DevFillRosterButton.TabIndex = 29;
            this.DevFillRosterButton.Text = "Fill Rosters";
            this.DevFillRosterButton.UseVisualStyleBackColor = false;
            this.DevFillRosterButton.Click += new System.EventHandler(this.DevFillRosterButton_Click);
            // 
            // CreateTransfersCSVButton
            // 
            this.CreateTransfersCSVButton.BackColor = System.Drawing.Color.DarkGray;
            this.CreateTransfersCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateTransfersCSVButton.Location = new System.Drawing.Point(77, 316);
            this.CreateTransfersCSVButton.Name = "CreateTransfersCSVButton";
            this.CreateTransfersCSVButton.Size = new System.Drawing.Size(110, 80);
            this.CreateTransfersCSVButton.TabIndex = 28;
            this.CreateTransfersCSVButton.Text = "Import Transfers";
            this.CreateTransfersCSVButton.UseVisualStyleBackColor = false;
            this.CreateTransfersCSVButton.Click += new System.EventHandler(this.CreateTransfersCSVButton_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.Honeydew;
            this.textBox6.Enabled = false;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(16, 6);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(934, 167);
            this.textBox6.TabIndex = 27;
            this.textBox6.Text = resources.GetString("textBox6.Text");
            // 
            // ImportRecruitsButton
            // 
            this.ImportRecruitsButton.BackColor = System.Drawing.Color.DarkGray;
            this.ImportRecruitsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportRecruitsButton.Location = new System.Drawing.Point(77, 426);
            this.ImportRecruitsButton.Name = "ImportRecruitsButton";
            this.ImportRecruitsButton.Size = new System.Drawing.Size(110, 80);
            this.ImportRecruitsButton.TabIndex = 26;
            this.ImportRecruitsButton.Text = "Import Recruits";
            this.ImportRecruitsButton.UseVisualStyleBackColor = false;
            this.ImportRecruitsButton.Click += new System.EventHandler(this.ImportRecruitsButton_Click);
            // 
            // GraduateButton
            // 
            this.GraduateButton.BackColor = System.Drawing.Color.DarkGray;
            this.GraduateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraduateButton.Location = new System.Drawing.Point(77, 196);
            this.GraduateButton.Name = "GraduateButton";
            this.GraduateButton.Size = new System.Drawing.Size(110, 80);
            this.GraduateButton.TabIndex = 25;
            this.GraduateButton.Text = "Graduate Players";
            this.GraduateButton.UseVisualStyleBackColor = false;
            this.GraduateButton.Click += new System.EventHandler(this.GraduateButton_Click);
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
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCAA Xtreme Database Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
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
            this.tabHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabTeams.ResumeLayout(false);
            this.tabTeams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTSbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTAbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTRbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTSbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTAbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTRbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCCPONumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDURnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNCTnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCDPnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.INPOnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamHCPrestigeNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMARNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMPRNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCRPCNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCTPCNumber)).EndInit();
            this.tabPlayers.ResumeLayout(false);
            this.tabPlayers.PerformLayout();
            this.tabSeason.ResumeLayout(false);
            this.tabSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).EndInit();
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
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).EndInit();
            this.tabDev.ResumeLayout(false);
            this.tabDev.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MainEditor_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.CloseMainEditor_Click();
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
        public System.Windows.Forms.TabPage tabPlayers;
        public System.Windows.Forms.ListBox PGIDlistBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox PLNAtextBox;
        public System.Windows.Forms.TextBox PFNAtextBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TGIDplayerBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.TabPage tabSeason;
        public System.Windows.Forms.Button medRS;
        public System.Windows.Forms.Button coachProg;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox dbToolsInfo;
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
        public System.Windows.Forms.Button buttonPSInjuries;
        private System.Windows.Forms.NumericUpDown numInjuries;
        private System.Windows.Forms.Label labelPSInjuries;
        public System.Windows.Forms.Label labelMaxSkilDrop_PS;
        public System.Windows.Forms.NumericUpDown MaxSkillDropPS;
        private System.Windows.Forms.Button buttonChaosTransfers;
        private System.Windows.Forms.CheckBox checkBoxFiredTransfers;
        public System.Windows.Forms.Label labelMaxTransfers;
        public System.Windows.Forms.NumericUpDown maxFiredTransfers;
        private System.Windows.Forms.TabPage tabTools;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Button buttonRandPotential;
        public System.Windows.Forms.Button increaseSpeed;
        public System.Windows.Forms.Button bodyFix;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button buttonRealignment;
        private System.Windows.Forms.Button buttonScheduleGen;
        public System.Windows.Forms.Button buttonCalcOverall;
        private NumericUpDown numberPlayerCoach;
        private System.Windows.Forms.Button buttonPlayerCoach;
        private Label label14;
        public System.Windows.Forms.Button TYDNButton;
        public System.Windows.Forms.Button buttonImpactPlayers;
        public System.Windows.Forms.Button buttonRandomizeFaceShape;
        public System.Windows.Forms.Button buttonFantasyRoster;
        private TabPage tabHome;
        public System.Windows.Forms.Button buttonAutoDepthChart;
        private PictureBox pictureBox1;
        public System.Windows.Forms.Button buttonFillRosters;
        public TabPage tabTeams;
        public Label label20;
        public Label label19;
        public System.Windows.Forms.TextBox TeamOVRtextbox;
        public System.Windows.Forms.TextBox TSI1textbox;
        public System.Windows.Forms.TextBox TSI2textbox;
        public System.Windows.Forms.TextBox TPIDtextbox;
        public System.Windows.Forms.TextBox TPIOtextbox;
        public Label label18;
        public Label label17;
        public Label label16;
        public Label label15;
        public Label label11;
        public System.Windows.Forms.TextBox TGIDtextBox;
        public Label label10;
        public System.Windows.Forms.TextBox TMNAtextBox;
        public Label label9;
        public System.Windows.Forms.TextBox TDNAtextBox;
        public Label label8;
        public System.Windows.Forms.ComboBox DGIDcomboBox;
        public Label label7;
        public System.Windows.Forms.ComboBox CGIDcomboBox;
        public Label label6;
        public System.Windows.Forms.ComboBox LGIDcomboBox;
        public CheckBox LocationcheckBox;
        public CheckBox MascotcheckBox;
        public Label label5;
        public System.Windows.Forms.ComboBox TTYPcomboBox;
        public ListBox TGIDlistBox;
        public Label label21;
        public System.Windows.Forms.TextBox TeamCaptain2box;
        public System.Windows.Forms.TextBox TeamCaptain1box;
        public Label label22;
        public Label label23;
        public Label label25;
        public System.Windows.Forms.TextBox TeamDivisionBox;
        public Label label24;
        public System.Windows.Forms.TextBox TeamConferenceBox;
        public Label label26;
        public System.Windows.Forms.TextBox TSNAtextBox;
        private TabPage tabCoaches;
        public Label label27;
        public System.Windows.Forms.TextBox LeagueBox;
        public Label label30;
        public System.Windows.Forms.TextBox SeasonRecordBox;
        public Label label28;
        public System.Windows.Forms.TextBox APPollBox;
        public Label label29;
        public System.Windows.Forms.TextBox ConfRecordBox;
        public Label label31;
        public System.Windows.Forms.TextBox CoachPollBox;
        public Label label33;
        public Label label32;
        public System.Windows.Forms.TextBox HCFirstNameBox;
        public Label label37;
        public Label label36;
        public Label label34;
        public Label label35;
        public System.Windows.Forms.TextBox HCLastNameBox;
        public Label label38;
        private System.Windows.Forms.Button TeamColor2Button;
        private System.Windows.Forms.Button TeamColor1Button;
        private ColorDialog colorDialog1;
        public Label label42;
        public Label label39;
        public Label label40;
        public Label label41;
        public System.Windows.Forms.TextBox TeamCDPCBox;
        private NumericUpDown TeamCTPCNumber;
        private NumericUpDown TeamCRPCNumber;
        private NumericUpDown TMARNumBox;
        private NumericUpDown TMPRNumBox;
        private NumericUpDown TeamHCPrestigeNumBox;
        private NumericUpDown SDURnumbox;
        private NumericUpDown SNCTnumbox;
        private NumericUpDown NCDPnumbox;
        private NumericUpDown INPOnumbox;
        public Label label46;
        public Label label44;
        public Label label45;
        private NumericUpDown TeamCCPONumBox;
        public Label label43;
        private NumericUpDown TeamCOTSbox;
        public Label label49;
        private NumericUpDown TeamCOTAbox;
        private NumericUpDown TeamCOTRbox;
        public Label label47;
        public Label label48;
        private NumericUpDown TeamCDTSbox;
        public Label label50;
        private NumericUpDown TeamCDTAbox;
        private NumericUpDown TeamCDTRbox;
        public Label label51;
        public Label label52;
        private System.Windows.Forms.Button ResetSecondaryColorButton;
        private System.Windows.Forms.Button ResetPrimaryColorButton;
        private CheckBox UserCoachCheckBox;
        private System.Windows.Forms.Button FireCoachButton;
        private Label label53;
        private Label label54;
        public Label label56;
        public System.Windows.Forms.TextBox CityNameBox;
        public Label label55;
        public System.Windows.Forms.TextBox stadiumNameBox;
        public Label label57;
        private System.Windows.Forms.ComboBox StateBox;
        private Label label58;
        private NumericUpDown FillRosterPCT;
        private TabPage tabDev;
        public System.Windows.Forms.Button ImportRecruitsButton;
        public System.Windows.Forms.Button GraduateButton;
        public System.Windows.Forms.Button RandomizeHeadButton;
        public System.Windows.Forms.TextBox textBox6;
        private NumericUpDown CapacityNumbox;
        private NumericUpDown AttendanceNumBox;
        public Label label59;
        public Label label60;
        public System.Windows.Forms.Button CreateTransfersCSVButton;
        public System.Windows.Forms.Button CoachPrestigeButton;
        public System.Windows.Forms.Button DevRandomizeFaceButton;
        public System.Windows.Forms.Button DevCalcOVRButton;
        public System.Windows.Forms.Button DevFillRosterButton;
        public System.Windows.Forms.Button DevCalcTeamRatingsButton;
        public System.Windows.Forms.Button DevDepthChartButton;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox textBox20;
        public System.Windows.Forms.TextBox textBox19;
        public System.Windows.Forms.TextBox textBox18;
        public System.Windows.Forms.TextBox textBox17;
        public System.Windows.Forms.TextBox textBox16;
        public System.Windows.Forms.TextBox textBox15;
        public System.Windows.Forms.TextBox textBox14;
        public System.Windows.Forms.TextBox textBox13;
        public System.Windows.Forms.TextBox textBox12;
        public System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.ComboBox DefTypeSelectBox;
        private System.Windows.Forms.ComboBox OffTypeSelectBox;
        private System.Windows.Forms.ComboBox PlaybookSelectBox;
    }
}

