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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CSVMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.definitionFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NCAANext25Config = new System.Windows.Forms.ToolStripMenuItem();
            this.LeagueMakerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScheduleGenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DB2Button = new System.Windows.Forms.RadioButton();
            this.DB1Button = new System.Windows.Forms.RadioButton();
            this.tabDepthCharts = new System.Windows.Forms.TabPage();
            this.DCHTAutoSet = new System.Windows.Forms.Button();
            this.DCHTClear = new System.Windows.Forms.Button();
            this.UpdateDCHT = new System.Windows.Forms.Button();
            this.DCHTTeam = new System.Windows.Forms.ComboBox();
            this.label152 = new System.Windows.Forms.Label();
            this.DCHTGrid = new System.Windows.Forms.DataGridView();
            this.DCHTPPOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCHT0 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DCHT1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DCHT2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DCHT3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DCHT4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DCHT5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPlaybook = new System.Windows.Forms.TabPage();
            this.PlayNameRatio = new System.Windows.Forms.Label();
            this.SetPlayNameValueButton = new System.Windows.Forms.Button();
            this.label114 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.PlayNameBox = new System.Windows.Forms.ComboBox();
            this.PlayNameValue = new System.Windows.Forms.NumericUpDown();
            this.ProjTypeRatio = new System.Windows.Forms.Label();
            this.ProjPassRatio = new System.Windows.Forms.Label();
            this.RunCounter = new System.Windows.Forms.Label();
            this.PassCounter = new System.Windows.Forms.Label();
            this.ImportPlaybookCSV = new System.Windows.Forms.Button();
            this.pcrtValueButton = new System.Windows.Forms.Button();
            this.label112 = new System.Windows.Forms.Label();
            this.label111 = new System.Windows.Forms.Label();
            this.PlayTypeBox = new System.Windows.Forms.ComboBox();
            this.pcrtNumBox = new System.Windows.Forms.NumericUpDown();
            this.label110 = new System.Windows.Forms.Label();
            this.aigrFilterBox = new System.Windows.Forms.ComboBox();
            this.AIGRNameButton = new System.Windows.Forms.Button();
            this.savePBDataButton = new System.Windows.Forms.Button();
            this.ExportPBData = new System.Windows.Forms.Button();
            this.PlaybookGrid = new System.Windows.Forms.DataGridView();
            this.PBRec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBPL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AIGRVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AIGRname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLYL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLYTVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLYT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabConf = new System.Windows.Forms.TabPage();
            this.label80 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SwapRosterBox = new System.Windows.Forms.ComboBox();
            this.EnableFCSSwapBox = new System.Windows.Forms.CheckBox();
            this.FCSSwapListBox = new System.Windows.Forms.ComboBox();
            this.DeselectTeamsButton = new System.Windows.Forms.Button();
            this.SwapButton = new System.Windows.Forms.Button();
            this.ConfName12 = new System.Windows.Forms.Label();
            this.ConfName11 = new System.Windows.Forms.Label();
            this.ConfName10 = new System.Windows.Forms.Label();
            this.ConfName9 = new System.Windows.Forms.Label();
            this.ConfName8 = new System.Windows.Forms.Label();
            this.ConfName7 = new System.Windows.Forms.Label();
            this.ConfName6 = new System.Windows.Forms.Label();
            this.ConfName5 = new System.Windows.Forms.Label();
            this.ConfName4 = new System.Windows.Forms.Label();
            this.ConfName3 = new System.Windows.Forms.Label();
            this.ConfName2 = new System.Windows.Forms.Label();
            this.ConfName1 = new System.Windows.Forms.Label();
            this.conf12 = new System.Windows.Forms.CheckedListBox();
            this.conf11 = new System.Windows.Forms.CheckedListBox();
            this.conf10 = new System.Windows.Forms.CheckedListBox();
            this.conf9 = new System.Windows.Forms.CheckedListBox();
            this.conf8 = new System.Windows.Forms.CheckedListBox();
            this.conf7 = new System.Windows.Forms.CheckedListBox();
            this.conf6 = new System.Windows.Forms.CheckedListBox();
            this.conf5 = new System.Windows.Forms.CheckedListBox();
            this.conf4 = new System.Windows.Forms.CheckedListBox();
            this.conf3 = new System.Windows.Forms.CheckedListBox();
            this.conf2 = new System.Windows.Forms.CheckedListBox();
            this.conf1 = new System.Windows.Forms.CheckedListBox();
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
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.DevCalcTeamRatingsButton = new System.Windows.Forms.Button();
            this.DevDepthChartButton = new System.Windows.Forms.Button();
            this.DevRandomizeFaceButton = new System.Windows.Forms.Button();
            this.DevCalcOVRButton = new System.Windows.Forms.Button();
            this.DevFillRosterButton = new System.Windows.Forms.Button();
            this.CreateTransfersCSVButton = new System.Windows.Forms.Button();
            this.ImportRecruitsButton = new System.Windows.Forms.Button();
            this.GraduateButton = new System.Windows.Forms.Button();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.FantasyCoachesButton = new System.Windows.Forms.Button();
            this.SyncPBButton = new System.Windows.Forms.Button();
            this.label109 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.MaxAttPosBox = new System.Windows.Forms.ComboBox();
            this.MinAttPosBox = new System.Windows.Forms.ComboBox();
            this.GlobalAttPosBox = new System.Windows.Forms.ComboBox();
            this.MaxAttButton = new System.Windows.Forms.Button();
            this.MinAttButton = new System.Windows.Forms.Button();
            this.GlobalAttButton = new System.Windows.Forms.Button();
            this.MaxAttRating = new System.Windows.Forms.TextBox();
            this.MinAttRating = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.MaxAttNum = new System.Windows.Forms.NumericUpDown();
            this.label106 = new System.Windows.Forms.Label();
            this.MaxAttBox = new System.Windows.Forms.ComboBox();
            this.MinAttNum = new System.Windows.Forms.NumericUpDown();
            this.label100 = new System.Windows.Forms.Label();
            this.MinAttBox = new System.Windows.Forms.ComboBox();
            this.GlobalAttCheck = new System.Windows.Forms.CheckBox();
            this.GlobalAttNum = new System.Windows.Forms.NumericUpDown();
            this.label99 = new System.Windows.Forms.Label();
            this.GlobalAttBox = new System.Windows.Forms.ComboBox();
            this.ReorderPGIDButton = new System.Windows.Forms.Button();
            this.TORDButton = new System.Windows.Forms.Button();
            this.CFUSAexportButton = new System.Windows.Forms.Button();
            this.RandomizeHeadButton = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.FillRosterPCT = new System.Windows.Forms.NumericUpDown();
            this.buttonFillRosters = new System.Windows.Forms.Button();
            this.buttonAutoDepthChart = new System.Windows.Forms.Button();
            this.buttonFantasyRoster = new System.Windows.Forms.Button();
            this.buttonImpactPlayers = new System.Windows.Forms.Button();
            this.TYDNButton = new System.Windows.Forms.Button();
            this.buttonCalcOverall = new System.Windows.Forms.Button();
            this.buttonRandPotential = new System.Windows.Forms.Button();
            this.bodyFix = new System.Windows.Forms.Button();
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
            this.tabSeason = new System.Windows.Forms.TabPage();
            this.CoachPrestigeButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.numberPlayerCoach = new System.Windows.Forms.NumericUpDown();
            this.buttonPlayerCoach = new System.Windows.Forms.Button();
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
            this.tabCoaches = new System.Windows.Forms.TabPage();
            this.NewCoachButton = new System.Windows.Forms.Button();
            this.CoachShowTeamBox = new System.Windows.Forms.CheckBox();
            this.CoachTeamList = new System.Windows.Forms.ComboBox();
            this.label98 = new System.Windows.Forms.Label();
            this.CFUCBox = new System.Windows.Forms.CheckBox();
            this.label96 = new System.Windows.Forms.Label();
            this.COHTBox = new System.Windows.Forms.ComboBox();
            this.label97 = new System.Windows.Forms.Label();
            this.CTgwBox = new System.Windows.Forms.ComboBox();
            this.label95 = new System.Windows.Forms.Label();
            this.CoachFilter = new System.Windows.Forms.ComboBox();
            this.CoachPlaybookBox = new System.Windows.Forms.ComboBox();
            this.CoachDefTypeBox = new System.Windows.Forms.ComboBox();
            this.CoachOffTypeBox = new System.Windows.Forms.ComboBox();
            this.label131 = new System.Windows.Forms.Label();
            this.CoachCDTSBox = new System.Windows.Forms.NumericUpDown();
            this.label132 = new System.Windows.Forms.Label();
            this.CoachCDTABox = new System.Windows.Forms.NumericUpDown();
            this.CoachCDTRBox = new System.Windows.Forms.NumericUpDown();
            this.label133 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.CoachCOTSBox = new System.Windows.Forms.NumericUpDown();
            this.label135 = new System.Windows.Forms.Label();
            this.CoachCOTABox = new System.Windows.Forms.NumericUpDown();
            this.CoachCOTRBox = new System.Windows.Forms.NumericUpDown();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.CoachCCPONum = new System.Windows.Forms.NumericUpDown();
            this.label141 = new System.Windows.Forms.Label();
            this.HCPrestigeNum = new System.Windows.Forms.NumericUpDown();
            this.CoachRecruitingBox = new System.Windows.Forms.NumericUpDown();
            this.CoachTrainingBox = new System.Windows.Forms.NumericUpDown();
            this.label142 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label145 = new System.Windows.Forms.Label();
            this.CoachDisciplineBox = new System.Windows.Forms.TextBox();
            this.CCIDBox = new System.Windows.Forms.TextBox();
            this.CoachLastNameBox = new System.Windows.Forms.TextBox();
            this.CoachFirstNameBox = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label101 = new System.Windows.Forms.Label();
            this.CTHGBox = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.CHARBox = new System.Windows.Forms.ComboBox();
            this.label103 = new System.Windows.Forms.Label();
            this.CFEXBox = new System.Windows.Forms.ComboBox();
            this.label104 = new System.Windows.Forms.Label();
            this.CBSZBox = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.CSKIBox = new System.Windows.Forms.ComboBox();
            this.CoachListBox = new System.Windows.Forms.ListBox();
            this.label129 = new System.Windows.Forms.Label();
            this.label130 = new System.Windows.Forms.Label();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.label167 = new System.Windows.Forms.Label();
            this.playerTeamBox = new System.Windows.Forms.TextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.PRST = new System.Windows.Forms.TextBox();
            this.PGIDbox = new System.Windows.Forms.TextBox();
            this.PKACtext = new System.Windows.Forms.TextBox();
            this.PKPRtext = new System.Windows.Forms.TextBox();
            this.PTAKtext = new System.Windows.Forms.TextBox();
            this.PPBKtext = new System.Windows.Forms.TextBox();
            this.PTHAtext = new System.Windows.Forms.TextBox();
            this.PCARtext = new System.Windows.Forms.TextBox();
            this.PCTHtext = new System.Windows.Forms.TextBox();
            this.PJMPtext = new System.Windows.Forms.TextBox();
            this.PAGItext = new System.Windows.Forms.TextBox();
            this.PAWRtext = new System.Windows.Forms.TextBox();
            this.PPOEtext = new System.Windows.Forms.TextBox();
            this.PRBKtext = new System.Windows.Forms.TextBox();
            this.PTHPtext = new System.Windows.Forms.TextBox();
            this.PBTKtext = new System.Windows.Forms.TextBox();
            this.PSTRtext = new System.Windows.Forms.TextBox();
            this.PACCtext = new System.Windows.Forms.TextBox();
            this.PSPDtext = new System.Windows.Forms.TextBox();
            this.PINJtext = new System.Windows.Forms.TextBox();
            this.PIMPtext = new System.Windows.Forms.TextBox();
            this.POVRbox = new System.Windows.Forms.TextBox();
            this.PLNAtextBox = new System.Windows.Forms.TextBox();
            this.PFNAtextBox = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.RightShoe = new System.Windows.Forms.ComboBox();
            this.label150 = new System.Windows.Forms.Label();
            this.Helmet = new System.Windows.Forms.ComboBox();
            this.label149 = new System.Windows.Forms.Label();
            this.label148 = new System.Windows.Forms.Label();
            this.label127 = new System.Windows.Forms.Label();
            this.RightElbow = new System.Windows.Forms.ComboBox();
            this.label128 = new System.Windows.Forms.Label();
            this.RightWrist = new System.Windows.Forms.ComboBox();
            this.label147 = new System.Windows.Forms.Label();
            this.RightHand = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.NeckPad = new System.Windows.Forms.ComboBox();
            this.label123 = new System.Windows.Forms.Label();
            this.NasalStrip = new System.Windows.Forms.ComboBox();
            this.label124 = new System.Windows.Forms.Label();
            this.Visor = new System.Windows.Forms.ComboBox();
            this.label122 = new System.Windows.Forms.Label();
            this.EyeBlack = new System.Windows.Forms.ComboBox();
            this.SleeveColor = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.Sleeves = new System.Windows.Forms.ComboBox();
            this.LeftElbow = new System.Windows.Forms.ComboBox();
            this.label119 = new System.Windows.Forms.Label();
            this.Facemask = new System.Windows.Forms.ComboBox();
            this.label118 = new System.Windows.Forms.Label();
            this.LeftWrist = new System.Windows.Forms.ComboBox();
            this.label117 = new System.Windows.Forms.Label();
            this.LeftHand = new System.Windows.Forms.ComboBox();
            this.label116 = new System.Windows.Forms.Label();
            this.LeftShoe = new System.Windows.Forms.ComboBox();
            this.label113 = new System.Windows.Forms.Label();
            this.PJEN = new System.Windows.Forms.NumericUpDown();
            this.PlayerSetDepthChartButton = new System.Windows.Forms.Button();
            this.PGIDLabel = new System.Windows.Forms.Label();
            this.ShowPOSGBox = new System.Windows.Forms.CheckBox();
            this.ShowRatingCheckbox = new System.Windows.Forms.CheckBox();
            this.ShowPosCheckBox = new System.Windows.Forms.CheckBox();
            this.label93 = new System.Windows.Forms.Label();
            this.PTYPBox = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.PRSDBox = new System.Windows.Forms.ComboBox();
            this.label91 = new System.Windows.Forms.Label();
            this.PYERBox = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.PWGTBox = new System.Windows.Forms.NumericUpDown();
            this.label90 = new System.Windows.Forms.Label();
            this.PHGTBox = new System.Windows.Forms.NumericUpDown();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.PHEDBox = new System.Windows.Forms.ComboBox();
            this.label86 = new System.Windows.Forms.Label();
            this.PHCLBox = new System.Windows.Forms.ComboBox();
            this.label85 = new System.Windows.Forms.Label();
            this.PFMPBox = new System.Windows.Forms.ComboBox();
            this.label84 = new System.Windows.Forms.Label();
            this.PFGMBox = new System.Windows.Forms.ComboBox();
            this.label83 = new System.Windows.Forms.Label();
            this.PSKIBox = new System.Windows.Forms.ComboBox();
            this.label79 = new System.Windows.Forms.Label();
            this.PKACBox = new System.Windows.Forms.NumericUpDown();
            this.label81 = new System.Windows.Forms.Label();
            this.PKPRBox = new System.Windows.Forms.NumericUpDown();
            this.label82 = new System.Windows.Forms.Label();
            this.PTAKBox = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.PPBKBox = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.PTHABox = new System.Windows.Forms.NumericUpDown();
            this.label73 = new System.Windows.Forms.Label();
            this.PCARBox = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.PCTHBox = new System.Windows.Forms.NumericUpDown();
            this.label75 = new System.Windows.Forms.Label();
            this.PJMPBox = new System.Windows.Forms.NumericUpDown();
            this.label76 = new System.Windows.Forms.Label();
            this.PAGIBox = new System.Windows.Forms.NumericUpDown();
            this.label77 = new System.Windows.Forms.Label();
            this.PAWRBox = new System.Windows.Forms.NumericUpDown();
            this.label78 = new System.Windows.Forms.Label();
            this.PPOEBox = new System.Windows.Forms.NumericUpDown();
            this.label67 = new System.Windows.Forms.Label();
            this.PRBKBox = new System.Windows.Forms.NumericUpDown();
            this.label68 = new System.Windows.Forms.Label();
            this.PTHPBox = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.PBTKBox = new System.Windows.Forms.NumericUpDown();
            this.label70 = new System.Windows.Forms.Label();
            this.PSTRBox = new System.Windows.Forms.NumericUpDown();
            this.label66 = new System.Windows.Forms.Label();
            this.PACCBox = new System.Windows.Forms.NumericUpDown();
            this.label65 = new System.Windows.Forms.Label();
            this.PSPDBox = new System.Windows.Forms.NumericUpDown();
            this.label64 = new System.Windows.Forms.Label();
            this.PINJBox = new System.Windows.Forms.NumericUpDown();
            this.label63 = new System.Windows.Forms.Label();
            this.PIMPBox = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.PPOSBox = new System.Windows.Forms.ComboBox();
            this.label61 = new System.Windows.Forms.Label();
            this.RosterSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TGIDplayerBox = new System.Windows.Forms.ComboBox();
            this.PGIDlistBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label120 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.TeamSetDepthChart = new System.Windows.Forms.Button();
            this.GenerateNewRosterButton = new System.Windows.Forms.Button();
            this.DeathPenaltyButton = new System.Windows.Forms.Button();
            this.TeamRosterSizeLabel = new System.Windows.Forms.Label();
            this.CheerleaderBox = new System.Windows.Forms.ComboBox();
            this.CrowdBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ImpactTSI2Select = new System.Windows.Forms.ComboBox();
            this.ImpactTSI1Select = new System.Windows.Forms.ComboBox();
            this.ImpactTPIDSelect = new System.Windows.Forms.ComboBox();
            this.ImpactTPIOSelect = new System.Windows.Forms.ComboBox();
            this.ResetImpactPlayersButton = new System.Windows.Forms.Button();
            this.CaptainDefSelectBox = new System.Windows.Forms.ComboBox();
            this.CaptainOffSelectBox = new System.Windows.Forms.ComboBox();
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
            this.stadiumNameBox = new System.Windows.Forms.TextBox();
            this.TeamCDPCBox = new System.Windows.Forms.TextBox();
            this.HCLastNameBox = new System.Windows.Forms.TextBox();
            this.HCFirstNameBox = new System.Windows.Forms.TextBox();
            this.CoachPollBox = new System.Windows.Forms.TextBox();
            this.SeasonRecordBox = new System.Windows.Forms.TextBox();
            this.APPollBox = new System.Windows.Forms.TextBox();
            this.ConfRecordBox = new System.Windows.Forms.TextBox();
            this.LeagueBox = new System.Windows.Forms.TextBox();
            this.TSNAtextBox = new System.Windows.Forms.TextBox();
            this.TeamDivisionBox = new System.Windows.Forms.TextBox();
            this.TeamConferenceBox = new System.Windows.Forms.TextBox();
            this.TeamOVRtextbox = new System.Windows.Forms.TextBox();
            this.TGIDtextBox = new System.Windows.Forms.TextBox();
            this.TMNAtextBox = new System.Windows.Forms.TextBox();
            this.TDNAtextBox = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
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
            this.label38 = new System.Windows.Forms.Label();
            this.TeamColor2Button = new System.Windows.Forms.Button();
            this.TeamColor1Button = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.TGIDlistBox = new System.Windows.Forms.ListBox();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.fieldsGridView = new System.Windows.Forms.DataGridView();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OGConfigRadio = new System.Windows.Forms.RadioButton();
            this.NextConfigRadio = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRecruits = new System.Windows.Forms.TabPage();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label154 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label155 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label156 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label157 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label158 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label159 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label160 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label162 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label163 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label164 = new System.Windows.Forms.Label();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            qbTend = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.fieldMenu.SuspendLayout();
            this.TablePropsgroupBox.SuspendLayout();
            this.FieldsPropsgroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDepthCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCHTGrid)).BeginInit();
            this.tabPlaybook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayNameValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrtNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaybookGrid)).BeginInit();
            this.tabConf.SuspendLayout();
            this.tabDev.SuspendLayout();
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAttNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAttNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalAttNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).BeginInit();
            this.tabOffSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polyNamesPCT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).BeginInit();
            this.tabSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).BeginInit();
            this.tabCoaches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCCPONum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HCPrestigeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachRecruitingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachTrainingBox)).BeginInit();
            this.tabPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PJEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PWGTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHGTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKACBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKPRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTAKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCARBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCTHBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJMPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGIBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAWRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPOEBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PACCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSPDBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINJBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIMPBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).BeginInit();
            this.tabHome.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabRecruits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // qbTend
            // 
            qbTend.BackColor = System.Drawing.SystemColors.MenuHighlight;
            qbTend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qbTend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            qbTend.Location = new System.Drawing.Point(143, 111);
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
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.CSVMenu,
            this.optionsMenuItem,
            this.LeagueMakerToolStripMenuItem,
            this.aboutMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1184, 25);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.saveMenuItem,
            this.closeMenuItem,
            this.toolStripSeparator7,
            this.exitMenuItem});
            this.fileMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::DB_EDITOR.Properties.Resources.open2;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(157, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::DB_EDITOR.Properties.Resources.save3;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(157, 22);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Image = global::DB_EDITOR.Properties.Resources.close;
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeMenuItem.Size = new System.Drawing.Size(157, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(154, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Image = global::DB_EDITOR.Properties.Resources.exit;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitToolItem_Click);
            // 
            // CSVMenu
            // 
            this.CSVMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolItem,
            this.importMenuItem,
            this.toolStripSeparator2,
            this.exportAllMenuItem,
            this.toolStripSeparator9,
            this.tabDelimitedMenuItem});
            this.CSVMenu.Name = "CSVMenu";
            this.CSVMenu.Size = new System.Drawing.Size(43, 21);
            this.CSVMenu.Text = "CSV";
            // 
            // exportToolItem
            // 
            this.exportToolItem.Name = "exportToolItem";
            this.exportToolItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportToolItem.Size = new System.Drawing.Size(193, 22);
            this.exportToolItem.Text = "Export Table";
            this.exportToolItem.Click += new System.EventHandler(this.exportMenuItem_Click);
            // 
            // importMenuItem
            // 
            this.importMenuItem.Name = "importMenuItem";
            this.importMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importMenuItem.Size = new System.Drawing.Size(193, 22);
            this.importMenuItem.Text = "Import Table";
            this.importMenuItem.Click += new System.EventHandler(this.importMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // exportAllMenuItem
            // 
            this.exportAllMenuItem.Name = "exportAllMenuItem";
            this.exportAllMenuItem.ShowShortcutKeys = false;
            this.exportAllMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exportAllMenuItem.Text = "Export All";
            this.exportAllMenuItem.Click += new System.EventHandler(this.exportAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(190, 6);
            // 
            // tabDelimitedMenuItem
            // 
            this.tabDelimitedMenuItem.Name = "tabDelimitedMenuItem";
            this.tabDelimitedMenuItem.Size = new System.Drawing.Size(193, 22);
            this.tabDelimitedMenuItem.Text = "Tab Delimited";
            this.tabDelimitedMenuItem.Click += new System.EventHandler(this.tabDelimitedMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableFieldOrderMenuItem,
            this.definitionFileMenuItem,
            this.NCAANext25Config});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(66, 21);
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
            this.tableFieldOrderMenuItem.Size = new System.Drawing.Size(232, 22);
            this.tableFieldOrderMenuItem.Text = "Table Field Order";
            // 
            // defaultFieldOrderMenuItem
            // 
            this.defaultFieldOrderMenuItem.Checked = true;
            this.defaultFieldOrderMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultFieldOrderMenuItem.Name = "defaultFieldOrderMenuItem";
            this.defaultFieldOrderMenuItem.Size = new System.Drawing.Size(144, 22);
            this.defaultFieldOrderMenuItem.Text = "Default";
            this.defaultFieldOrderMenuItem.Click += new System.EventHandler(this.defaultMenuItem_Click);
            // 
            // ascendingFieldOrderMenuItem
            // 
            this.ascendingFieldOrderMenuItem.Name = "ascendingFieldOrderMenuItem";
            this.ascendingFieldOrderMenuItem.Size = new System.Drawing.Size(144, 22);
            this.ascendingFieldOrderMenuItem.Text = "Ascending";
            this.ascendingFieldOrderMenuItem.Click += new System.EventHandler(this.ascendingMenuItem_Click);
            // 
            // descendingFieldOrderMenuItem
            // 
            this.descendingFieldOrderMenuItem.Name = "descendingFieldOrderMenuItem";
            this.descendingFieldOrderMenuItem.Size = new System.Drawing.Size(144, 22);
            this.descendingFieldOrderMenuItem.Text = "Descending";
            this.descendingFieldOrderMenuItem.Click += new System.EventHandler(this.descendingMenuItem_Click);
            // 
            // customOrderMenuItem
            // 
            this.customOrderMenuItem.Name = "customOrderMenuItem";
            this.customOrderMenuItem.Size = new System.Drawing.Size(144, 22);
            this.customOrderMenuItem.Text = "Custom";
            this.customOrderMenuItem.Click += new System.EventHandler(this.customMenuItem_Click);
            // 
            // definitionFileMenuItem
            // 
            this.definitionFileMenuItem.Image = global::DB_EDITOR.Properties.Resources.def_file;
            this.definitionFileMenuItem.Name = "definitionFileMenuItem";
            this.definitionFileMenuItem.Size = new System.Drawing.Size(232, 22);
            this.definitionFileMenuItem.Text = "Definition File";
            this.definitionFileMenuItem.Click += new System.EventHandler(this.DefinitionFileMenuItem_Click);
            // 
            // NCAANext25Config
            // 
            this.NCAANext25Config.Name = "NCAANext25Config";
            this.NCAANext25Config.Size = new System.Drawing.Size(232, 22);
            this.NCAANext25Config.Text = "Use NCAA NEXT 25 Config";
            this.NCAANext25Config.Click += new System.EventHandler(this.NCAANext25Config_Click);
            // 
            // LeagueMakerToolStripMenuItem
            // 
            this.LeagueMakerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScheduleGenMenuItem});
            this.LeagueMakerToolStripMenuItem.Name = "LeagueMakerToolStripMenuItem";
            this.LeagueMakerToolStripMenuItem.Size = new System.Drawing.Size(101, 21);
            this.LeagueMakerToolStripMenuItem.Text = "League Editor";
            // 
            // ScheduleGenMenuItem
            // 
            this.ScheduleGenMenuItem.Name = "ScheduleGenMenuItem";
            this.ScheduleGenMenuItem.Size = new System.Drawing.Size(193, 22);
            this.ScheduleGenMenuItem.Text = "Open League Editor";
            this.ScheduleGenMenuItem.Click += new System.EventHandler(this.ScheduleGenMenuItem_Click);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(55, 21);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(881, 682);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(287, 23);
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
            this.TablePropsgroupBox.Location = new System.Drawing.Point(19, 675);
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
            this.FieldsPropsgroupBox.Location = new System.Drawing.Point(367, 675);
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
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.DB2Button);
            this.groupBox2.Controls.Add(this.DB1Button);
            this.groupBox2.Location = new System.Drawing.Point(718, 675);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 31);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database";
            // 
            // DB2Button
            // 
            this.DB2Button.AutoSize = true;
            this.DB2Button.Location = new System.Drawing.Point(108, 10);
            this.DB2Button.Name = "DB2Button";
            this.DB2Button.Size = new System.Drawing.Size(46, 17);
            this.DB2Button.TabIndex = 1;
            this.DB2Button.Text = "DB2";
            this.DB2Button.UseVisualStyleBackColor = true;
            this.DB2Button.CheckedChanged += new System.EventHandler(this.DB2Button_CheckedChanged);
            // 
            // DB1Button
            // 
            this.DB1Button.AutoSize = true;
            this.DB1Button.Checked = true;
            this.DB1Button.Location = new System.Drawing.Point(59, 10);
            this.DB1Button.Name = "DB1Button";
            this.DB1Button.Size = new System.Drawing.Size(46, 17);
            this.DB1Button.TabIndex = 0;
            this.DB1Button.TabStop = true;
            this.DB1Button.Text = "DB1";
            this.DB1Button.UseVisualStyleBackColor = true;
            this.DB1Button.CheckedChanged += new System.EventHandler(this.DB1Button_CheckedChanged);
            // 
            // tabDepthCharts
            // 
            this.tabDepthCharts.Controls.Add(this.DCHTAutoSet);
            this.tabDepthCharts.Controls.Add(this.DCHTClear);
            this.tabDepthCharts.Controls.Add(this.UpdateDCHT);
            this.tabDepthCharts.Controls.Add(this.DCHTTeam);
            this.tabDepthCharts.Controls.Add(this.label152);
            this.tabDepthCharts.Controls.Add(this.DCHTGrid);
            this.tabDepthCharts.Location = new System.Drawing.Point(4, 24);
            this.tabDepthCharts.Name = "tabDepthCharts";
            this.tabDepthCharts.Padding = new System.Windows.Forms.Padding(3);
            this.tabDepthCharts.Size = new System.Drawing.Size(1152, 615);
            this.tabDepthCharts.TabIndex = 11;
            this.tabDepthCharts.Text = "Depth Charts";
            this.tabDepthCharts.UseVisualStyleBackColor = true;
            // 
            // DCHTAutoSet
            // 
            this.DCHTAutoSet.BackColor = System.Drawing.Color.Gold;
            this.DCHTAutoSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DCHTAutoSet.Location = new System.Drawing.Point(15, 267);
            this.DCHTAutoSet.Name = "DCHTAutoSet";
            this.DCHTAutoSet.Size = new System.Drawing.Size(138, 43);
            this.DCHTAutoSet.TabIndex = 5;
            this.DCHTAutoSet.Text = "Auto Set\r\nDepth Chart";
            this.DCHTAutoSet.UseVisualStyleBackColor = false;
            this.DCHTAutoSet.Click += new System.EventHandler(this.DCHTAutoSet_Click);
            // 
            // DCHTClear
            // 
            this.DCHTClear.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.DCHTClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DCHTClear.Location = new System.Drawing.Point(15, 192);
            this.DCHTClear.Name = "DCHTClear";
            this.DCHTClear.Size = new System.Drawing.Size(138, 43);
            this.DCHTClear.TabIndex = 4;
            this.DCHTClear.Text = "Reset Table";
            this.DCHTClear.UseVisualStyleBackColor = false;
            this.DCHTClear.Click += new System.EventHandler(this.DCHTClear_Click);
            // 
            // UpdateDCHT
            // 
            this.UpdateDCHT.BackColor = System.Drawing.Color.IndianRed;
            this.UpdateDCHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateDCHT.Location = new System.Drawing.Point(15, 117);
            this.UpdateDCHT.Name = "UpdateDCHT";
            this.UpdateDCHT.Size = new System.Drawing.Size(138, 43);
            this.UpdateDCHT.TabIndex = 3;
            this.UpdateDCHT.Text = "Update Database";
            this.UpdateDCHT.UseVisualStyleBackColor = false;
            this.UpdateDCHT.Click += new System.EventHandler(this.UpdateDCHT_Click);
            // 
            // DCHTTeam
            // 
            this.DCHTTeam.FormattingEnabled = true;
            this.DCHTTeam.Location = new System.Drawing.Point(15, 63);
            this.DCHTTeam.Name = "DCHTTeam";
            this.DCHTTeam.Size = new System.Drawing.Size(138, 21);
            this.DCHTTeam.TabIndex = 2;
            this.DCHTTeam.SelectedIndexChanged += new System.EventHandler(this.DCHTTeam_SelectedIndexChanged);
            // 
            // label152
            // 
            this.label152.AutoSize = true;
            this.label152.Location = new System.Drawing.Point(12, 46);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(67, 13);
            this.label152.TabIndex = 1;
            this.label152.Text = "Select Team";
            // 
            // DCHTGrid
            // 
            this.DCHTGrid.AllowUserToAddRows = false;
            this.DCHTGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DCHTGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DCHTGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DCHTGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.DCHTGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DCHTGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DCHTGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DCHTGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DCHTPPOS,
            this.DCHT0,
            this.DCHT1,
            this.DCHT2,
            this.DCHT3,
            this.DCHT4,
            this.DCHT5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DCHTGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.DCHTGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DCHTGrid.Location = new System.Drawing.Point(159, 6);
            this.DCHTGrid.MultiSelect = false;
            this.DCHTGrid.Name = "DCHTGrid";
            this.DCHTGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DCHTGrid.Size = new System.Drawing.Size(974, 585);
            this.DCHTGrid.TabIndex = 0;
            this.DCHTGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DCHT_CellEnter);
            this.DCHTGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DCHTGrid_DataError);
            // 
            // DCHTPPOS
            // 
            this.DCHTPPOS.FillWeight = 30F;
            this.DCHTPPOS.HeaderText = "Position";
            this.DCHTPPOS.Name = "DCHTPPOS";
            this.DCHTPPOS.ReadOnly = true;
            // 
            // DCHT0
            // 
            this.DCHT0.FillWeight = 67.44775F;
            this.DCHT0.HeaderText = "Starter";
            this.DCHT0.Name = "DCHT0";
            // 
            // DCHT1
            // 
            this.DCHT1.FillWeight = 67.44775F;
            this.DCHT1.HeaderText = "Backup";
            this.DCHT1.Name = "DCHT1";
            this.DCHT1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DCHT1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DCHT2
            // 
            this.DCHT2.FillWeight = 67.44775F;
            this.DCHT2.HeaderText = "3rd String";
            this.DCHT2.Name = "DCHT2";
            // 
            // DCHT3
            // 
            this.DCHT3.FillWeight = 67.44775F;
            this.DCHT3.HeaderText = "4th String";
            this.DCHT3.Name = "DCHT3";
            // 
            // DCHT4
            // 
            this.DCHT4.FillWeight = 67.44775F;
            this.DCHT4.HeaderText = "5th String";
            this.DCHT4.Name = "DCHT4";
            // 
            // DCHT5
            // 
            this.DCHT5.FillWeight = 67.44775F;
            this.DCHT5.HeaderText = "6th String";
            this.DCHT5.Name = "DCHT5";
            // 
            // tabPlaybook
            // 
            this.tabPlaybook.Controls.Add(this.PlayNameRatio);
            this.tabPlaybook.Controls.Add(this.SetPlayNameValueButton);
            this.tabPlaybook.Controls.Add(this.label114);
            this.tabPlaybook.Controls.Add(this.label115);
            this.tabPlaybook.Controls.Add(this.PlayNameBox);
            this.tabPlaybook.Controls.Add(this.PlayNameValue);
            this.tabPlaybook.Controls.Add(this.ProjTypeRatio);
            this.tabPlaybook.Controls.Add(this.ProjPassRatio);
            this.tabPlaybook.Controls.Add(this.RunCounter);
            this.tabPlaybook.Controls.Add(this.PassCounter);
            this.tabPlaybook.Controls.Add(this.ImportPlaybookCSV);
            this.tabPlaybook.Controls.Add(this.pcrtValueButton);
            this.tabPlaybook.Controls.Add(this.label112);
            this.tabPlaybook.Controls.Add(this.label111);
            this.tabPlaybook.Controls.Add(this.PlayTypeBox);
            this.tabPlaybook.Controls.Add(this.pcrtNumBox);
            this.tabPlaybook.Controls.Add(this.label110);
            this.tabPlaybook.Controls.Add(this.aigrFilterBox);
            this.tabPlaybook.Controls.Add(this.AIGRNameButton);
            this.tabPlaybook.Controls.Add(this.savePBDataButton);
            this.tabPlaybook.Controls.Add(this.ExportPBData);
            this.tabPlaybook.Controls.Add(this.PlaybookGrid);
            this.tabPlaybook.Location = new System.Drawing.Point(4, 24);
            this.tabPlaybook.Name = "tabPlaybook";
            this.tabPlaybook.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaybook.Size = new System.Drawing.Size(1152, 615);
            this.tabPlaybook.TabIndex = 10;
            this.tabPlaybook.Text = "Playbook";
            this.tabPlaybook.UseVisualStyleBackColor = true;
            // 
            // PlayNameRatio
            // 
            this.PlayNameRatio.AutoSize = true;
            this.PlayNameRatio.Location = new System.Drawing.Point(814, 414);
            this.PlayNameRatio.Name = "PlayNameRatio";
            this.PlayNameRatio.Size = new System.Drawing.Size(76, 13);
            this.PlayNameRatio.TabIndex = 21;
            this.PlayNameRatio.Text = "Proj Play Ratio";
            this.PlayNameRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SetPlayNameValueButton
            // 
            this.SetPlayNameValueButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.SetPlayNameValueButton.Location = new System.Drawing.Point(817, 435);
            this.SetPlayNameValueButton.Name = "SetPlayNameValueButton";
            this.SetPlayNameValueButton.Size = new System.Drawing.Size(129, 35);
            this.SetPlayNameValueButton.TabIndex = 20;
            this.SetPlayNameValueButton.Text = "Set Value";
            this.SetPlayNameValueButton.UseVisualStyleBackColor = false;
            this.SetPlayNameValueButton.Click += new System.EventHandler(this.SetPlayNameValueButton_Click);
            // 
            // label114
            // 
            this.label114.AutoSize = true;
            this.label114.Location = new System.Drawing.Point(817, 335);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(58, 13);
            this.label114.TabIndex = 19;
            this.label114.Text = "Play Name";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Location = new System.Drawing.Point(814, 388);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(44, 13);
            this.label115.TabIndex = 18;
            this.label115.Text = "Set prct";
            // 
            // PlayNameBox
            // 
            this.PlayNameBox.FormattingEnabled = true;
            this.PlayNameBox.Location = new System.Drawing.Point(817, 354);
            this.PlayNameBox.Name = "PlayNameBox";
            this.PlayNameBox.Size = new System.Drawing.Size(129, 21);
            this.PlayNameBox.TabIndex = 17;
            this.PlayNameBox.SelectedIndexChanged += new System.EventHandler(this.PlayNameBox_SelectedIndexChanged);
            // 
            // PlayNameValue
            // 
            this.PlayNameValue.Location = new System.Drawing.Point(864, 386);
            this.PlayNameValue.Name = "PlayNameValue";
            this.PlayNameValue.Size = new System.Drawing.Size(82, 20);
            this.PlayNameValue.TabIndex = 16;
            this.PlayNameValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ProjTypeRatio
            // 
            this.ProjTypeRatio.AutoSize = true;
            this.ProjTypeRatio.Location = new System.Drawing.Point(814, 247);
            this.ProjTypeRatio.Name = "ProjTypeRatio";
            this.ProjTypeRatio.Size = new System.Drawing.Size(79, 13);
            this.ProjTypeRatio.TabIndex = 15;
            this.ProjTypeRatio.Text = "Proj Pass Ratio";
            this.ProjTypeRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProjPassRatio
            // 
            this.ProjPassRatio.AutoSize = true;
            this.ProjPassRatio.Location = new System.Drawing.Point(814, 123);
            this.ProjPassRatio.Name = "ProjPassRatio";
            this.ProjPassRatio.Size = new System.Drawing.Size(79, 13);
            this.ProjPassRatio.TabIndex = 14;
            this.ProjPassRatio.Text = "Proj Pass Ratio";
            this.ProjPassRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunCounter
            // 
            this.RunCounter.AutoSize = true;
            this.RunCounter.Location = new System.Drawing.Point(814, 99);
            this.RunCounter.Name = "RunCounter";
            this.RunCounter.Size = new System.Drawing.Size(90, 13);
            this.RunCounter.TabIndex = 13;
            this.RunCounter.Text = "Run  Counter: XX";
            this.RunCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PassCounter
            // 
            this.PassCounter.AutoSize = true;
            this.PassCounter.Location = new System.Drawing.Point(814, 74);
            this.PassCounter.Name = "PassCounter";
            this.PassCounter.Size = new System.Drawing.Size(90, 13);
            this.PassCounter.TabIndex = 12;
            this.PassCounter.Text = "Pass Counter: XX";
            this.PassCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImportPlaybookCSV
            // 
            this.ImportPlaybookCSV.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ImportPlaybookCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportPlaybookCSV.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ImportPlaybookCSV.Location = new System.Drawing.Point(979, 221);
            this.ImportPlaybookCSV.Name = "ImportPlaybookCSV";
            this.ImportPlaybookCSV.Size = new System.Drawing.Size(113, 64);
            this.ImportPlaybookCSV.TabIndex = 11;
            this.ImportPlaybookCSV.Text = "Import CSV";
            this.ImportPlaybookCSV.UseVisualStyleBackColor = false;
            this.ImportPlaybookCSV.Click += new System.EventHandler(this.ImportPlaybookCSV_Click);
            // 
            // pcrtValueButton
            // 
            this.pcrtValueButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pcrtValueButton.Location = new System.Drawing.Point(817, 268);
            this.pcrtValueButton.Name = "pcrtValueButton";
            this.pcrtValueButton.Size = new System.Drawing.Size(129, 35);
            this.pcrtValueButton.TabIndex = 10;
            this.pcrtValueButton.Text = "Set Value";
            this.pcrtValueButton.UseVisualStyleBackColor = false;
            this.pcrtValueButton.Click += new System.EventHandler(this.pcrtValueButton_Click);
            // 
            // label112
            // 
            this.label112.AutoSize = true;
            this.label112.Location = new System.Drawing.Point(817, 168);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(54, 13);
            this.label112.TabIndex = 9;
            this.label112.Text = "Play Type";
            // 
            // label111
            // 
            this.label111.AutoSize = true;
            this.label111.Location = new System.Drawing.Point(814, 221);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(44, 13);
            this.label111.TabIndex = 8;
            this.label111.Text = "Set prct";
            // 
            // PlayTypeBox
            // 
            this.PlayTypeBox.FormattingEnabled = true;
            this.PlayTypeBox.Location = new System.Drawing.Point(817, 187);
            this.PlayTypeBox.Name = "PlayTypeBox";
            this.PlayTypeBox.Size = new System.Drawing.Size(129, 21);
            this.PlayTypeBox.TabIndex = 7;
            this.PlayTypeBox.SelectedIndexChanged += new System.EventHandler(this.PlayTypeBox_SelectedIndexChanged);
            // 
            // pcrtNumBox
            // 
            this.pcrtNumBox.Location = new System.Drawing.Point(864, 219);
            this.pcrtNumBox.Name = "pcrtNumBox";
            this.pcrtNumBox.Size = new System.Drawing.Size(82, 20);
            this.pcrtNumBox.TabIndex = 6;
            this.pcrtNumBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label110
            // 
            this.label110.AutoSize = true;
            this.label110.Location = new System.Drawing.Point(817, 23);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(58, 13);
            this.label110.TabIndex = 5;
            this.label110.Text = "AIGR Filter";
            // 
            // aigrFilterBox
            // 
            this.aigrFilterBox.FormattingEnabled = true;
            this.aigrFilterBox.Location = new System.Drawing.Point(817, 40);
            this.aigrFilterBox.Name = "aigrFilterBox";
            this.aigrFilterBox.Size = new System.Drawing.Size(129, 21);
            this.aigrFilterBox.TabIndex = 4;
            this.aigrFilterBox.SelectedIndexChanged += new System.EventHandler(this.aigrFilterBox_SelectedIndexChanged);
            // 
            // AIGRNameButton
            // 
            this.AIGRNameButton.BackColor = System.Drawing.SystemColors.Info;
            this.AIGRNameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AIGRNameButton.Location = new System.Drawing.Point(979, 23);
            this.AIGRNameButton.Name = "AIGRNameButton";
            this.AIGRNameButton.Size = new System.Drawing.Size(113, 64);
            this.AIGRNameButton.TabIndex = 3;
            this.AIGRNameButton.Text = "Change to \r\nDefense AIGR";
            this.AIGRNameButton.UseVisualStyleBackColor = false;
            this.AIGRNameButton.Click += new System.EventHandler(this.AIGRNameButton_Click);
            // 
            // savePBDataButton
            // 
            this.savePBDataButton.BackColor = System.Drawing.Color.Crimson;
            this.savePBDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePBDataButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.savePBDataButton.Location = new System.Drawing.Point(979, 318);
            this.savePBDataButton.Name = "savePBDataButton";
            this.savePBDataButton.Size = new System.Drawing.Size(113, 64);
            this.savePBDataButton.TabIndex = 2;
            this.savePBDataButton.Text = "Update Database";
            this.savePBDataButton.UseVisualStyleBackColor = false;
            this.savePBDataButton.Click += new System.EventHandler(this.savePBDataButton_Click);
            // 
            // ExportPBData
            // 
            this.ExportPBData.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ExportPBData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportPBData.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ExportPBData.Location = new System.Drawing.Point(979, 123);
            this.ExportPBData.Name = "ExportPBData";
            this.ExportPBData.Size = new System.Drawing.Size(113, 64);
            this.ExportPBData.TabIndex = 1;
            this.ExportPBData.Text = "Export to CSV";
            this.ExportPBData.UseVisualStyleBackColor = false;
            this.ExportPBData.Click += new System.EventHandler(this.ExportPBData_Click);
            // 
            // PlaybookGrid
            // 
            this.PlaybookGrid.AllowUserToAddRows = false;
            this.PlaybookGrid.AllowUserToDeleteRows = false;
            this.PlaybookGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PlaybookGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.PlaybookGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaybookGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.PlaybookGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlaybookGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PBRec,
            this.PBPL,
            this.AIGRVal,
            this.AIGRname,
            this.prct,
            this.PLYL,
            this.PlayName,
            this.PLYTVal,
            this.PLYT});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PlaybookGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.PlaybookGrid.EnableHeadersVisualStyles = false;
            this.PlaybookGrid.Location = new System.Drawing.Point(12, 3);
            this.PlaybookGrid.Name = "PlaybookGrid";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaybookGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.PlaybookGrid.Size = new System.Drawing.Size(746, 606);
            this.PlaybookGrid.TabIndex = 0;
            // 
            // PBRec
            // 
            this.PBRec.FillWeight = 64.01138F;
            this.PBRec.HeaderText = "RecNo";
            this.PBRec.Name = "PBRec";
            this.PBRec.ReadOnly = true;
            // 
            // PBPL
            // 
            this.PBPL.FillWeight = 66.49709F;
            this.PBPL.HeaderText = "PBPL";
            this.PBPL.Name = "PBPL";
            this.PBPL.ReadOnly = true;
            // 
            // AIGRVal
            // 
            this.AIGRVal.FillWeight = 68.806F;
            this.AIGRVal.HeaderText = "AIGR";
            this.AIGRVal.Name = "AIGRVal";
            this.AIGRVal.ReadOnly = true;
            // 
            // AIGRname
            // 
            this.AIGRname.FillWeight = 141.9014F;
            this.AIGRname.HeaderText = "AIGR Name";
            this.AIGRname.Name = "AIGRname";
            this.AIGRname.ReadOnly = true;
            // 
            // prct
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            this.prct.DefaultCellStyle = dataGridViewCellStyle6;
            this.prct.FillWeight = 81.47587F;
            this.prct.HeaderText = "PRCT ";
            this.prct.Name = "prct";
            // 
            // PLYL
            // 
            this.PLYL.FillWeight = 69.14011F;
            this.PLYL.HeaderText = "PLYL";
            this.PLYL.Name = "PLYL";
            this.PLYL.ReadOnly = true;
            // 
            // PlayName
            // 
            this.PlayName.FillWeight = 213.7831F;
            this.PlayName.HeaderText = "Play Name";
            this.PlayName.Name = "PlayName";
            this.PlayName.ReadOnly = true;
            // 
            // PLYTVal
            // 
            this.PLYTVal.FillWeight = 63.09442F;
            this.PLYTVal.HeaderText = "PLYT";
            this.PLYTVal.Name = "PLYTVal";
            this.PLYTVal.ReadOnly = true;
            // 
            // PLYT
            // 
            this.PLYT.FillWeight = 131.2907F;
            this.PLYT.HeaderText = "Type";
            this.PLYT.Name = "PLYT";
            this.PLYT.ReadOnly = true;
            // 
            // tabConf
            // 
            this.tabConf.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tabConf.Controls.Add(this.label80);
            this.tabConf.Controls.Add(this.label4);
            this.tabConf.Controls.Add(this.SwapRosterBox);
            this.tabConf.Controls.Add(this.EnableFCSSwapBox);
            this.tabConf.Controls.Add(this.FCSSwapListBox);
            this.tabConf.Controls.Add(this.DeselectTeamsButton);
            this.tabConf.Controls.Add(this.SwapButton);
            this.tabConf.Controls.Add(this.ConfName12);
            this.tabConf.Controls.Add(this.ConfName11);
            this.tabConf.Controls.Add(this.ConfName10);
            this.tabConf.Controls.Add(this.ConfName9);
            this.tabConf.Controls.Add(this.ConfName8);
            this.tabConf.Controls.Add(this.ConfName7);
            this.tabConf.Controls.Add(this.ConfName6);
            this.tabConf.Controls.Add(this.ConfName5);
            this.tabConf.Controls.Add(this.ConfName4);
            this.tabConf.Controls.Add(this.ConfName3);
            this.tabConf.Controls.Add(this.ConfName2);
            this.tabConf.Controls.Add(this.ConfName1);
            this.tabConf.Controls.Add(this.conf12);
            this.tabConf.Controls.Add(this.conf11);
            this.tabConf.Controls.Add(this.conf10);
            this.tabConf.Controls.Add(this.conf9);
            this.tabConf.Controls.Add(this.conf8);
            this.tabConf.Controls.Add(this.conf7);
            this.tabConf.Controls.Add(this.conf6);
            this.tabConf.Controls.Add(this.conf5);
            this.tabConf.Controls.Add(this.conf4);
            this.tabConf.Controls.Add(this.conf3);
            this.tabConf.Controls.Add(this.conf2);
            this.tabConf.Controls.Add(this.conf1);
            this.tabConf.Location = new System.Drawing.Point(4, 24);
            this.tabConf.Name = "tabConf";
            this.tabConf.Padding = new System.Windows.Forms.Padding(3);
            this.tabConf.Size = new System.Drawing.Size(1152, 615);
            this.tabConf.TabIndex = 9;
            this.tabConf.Text = "Conferences";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(1019, 99);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(112, 13);
            this.label80.TabIndex = 31;
            this.label80.Text = "FCS Roster Option";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(989, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "FCS Team Selection";
            // 
            // SwapRosterBox
            // 
            this.SwapRosterBox.FormattingEnabled = true;
            this.SwapRosterBox.Items.AddRange(new object[] {
            "Transfer Roster",
            "Fantasy Roster",
            "No Roster"});
            this.SwapRosterBox.Location = new System.Drawing.Point(1022, 115);
            this.SwapRosterBox.Name = "SwapRosterBox";
            this.SwapRosterBox.Size = new System.Drawing.Size(109, 21);
            this.SwapRosterBox.TabIndex = 29;
            // 
            // EnableFCSSwapBox
            // 
            this.EnableFCSSwapBox.AutoSize = true;
            this.EnableFCSSwapBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableFCSSwapBox.Location = new System.Drawing.Point(966, 6);
            this.EnableFCSSwapBox.Name = "EnableFCSSwapBox";
            this.EnableFCSSwapBox.Size = new System.Drawing.Size(180, 20);
            this.EnableFCSSwapBox.TabIndex = 28;
            this.EnableFCSSwapBox.Text = "Enable FCS Swapping";
            this.EnableFCSSwapBox.UseVisualStyleBackColor = true;
            this.EnableFCSSwapBox.CheckedChanged += new System.EventHandler(this.EnableFCSSwapBox_CheckedChanged);
            // 
            // FCSSwapListBox
            // 
            this.FCSSwapListBox.FormattingEnabled = true;
            this.FCSSwapListBox.Location = new System.Drawing.Point(981, 65);
            this.FCSSwapListBox.Name = "FCSSwapListBox";
            this.FCSSwapListBox.Size = new System.Drawing.Size(150, 21);
            this.FCSSwapListBox.TabIndex = 26;
            // 
            // DeselectTeamsButton
            // 
            this.DeselectTeamsButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.DeselectTeamsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectTeamsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeselectTeamsButton.Location = new System.Drawing.Point(981, 168);
            this.DeselectTeamsButton.Name = "DeselectTeamsButton";
            this.DeselectTeamsButton.Size = new System.Drawing.Size(150, 37);
            this.DeselectTeamsButton.TabIndex = 25;
            this.DeselectTeamsButton.Text = "DESELECT TEAMS";
            this.DeselectTeamsButton.UseVisualStyleBackColor = false;
            this.DeselectTeamsButton.Click += new System.EventHandler(this.DeselectTeamsButton_Click);
            // 
            // SwapButton
            // 
            this.SwapButton.BackColor = System.Drawing.Color.Crimson;
            this.SwapButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwapButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SwapButton.Location = new System.Drawing.Point(981, 236);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(150, 37);
            this.SwapButton.TabIndex = 24;
            this.SwapButton.Text = "SWAP TEAMS";
            this.SwapButton.UseVisualStyleBackColor = false;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            // 
            // ConfName12
            // 
            this.ConfName12.AutoSize = true;
            this.ConfName12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName12.Location = new System.Drawing.Point(792, 319);
            this.ConfName12.Name = "ConfName12";
            this.ConfName12.Size = new System.Drawing.Size(80, 15);
            this.ConfName12.TabIndex = 23;
            this.ConfName12.Text = "Conference";
            // 
            // ConfName11
            // 
            this.ConfName11.AutoSize = true;
            this.ConfName11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName11.Location = new System.Drawing.Point(636, 319);
            this.ConfName11.Name = "ConfName11";
            this.ConfName11.Size = new System.Drawing.Size(80, 15);
            this.ConfName11.TabIndex = 22;
            this.ConfName11.Text = "Conference";
            // 
            // ConfName10
            // 
            this.ConfName10.AutoSize = true;
            this.ConfName10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName10.Location = new System.Drawing.Point(480, 319);
            this.ConfName10.Name = "ConfName10";
            this.ConfName10.Size = new System.Drawing.Size(80, 15);
            this.ConfName10.TabIndex = 21;
            this.ConfName10.Text = "Conference";
            // 
            // ConfName9
            // 
            this.ConfName9.AutoSize = true;
            this.ConfName9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName9.Location = new System.Drawing.Point(324, 319);
            this.ConfName9.Name = "ConfName9";
            this.ConfName9.Size = new System.Drawing.Size(80, 15);
            this.ConfName9.TabIndex = 20;
            this.ConfName9.Text = "Conference";
            // 
            // ConfName8
            // 
            this.ConfName8.AutoSize = true;
            this.ConfName8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName8.Location = new System.Drawing.Point(168, 319);
            this.ConfName8.Name = "ConfName8";
            this.ConfName8.Size = new System.Drawing.Size(80, 15);
            this.ConfName8.TabIndex = 19;
            this.ConfName8.Text = "Conference";
            // 
            // ConfName7
            // 
            this.ConfName7.AutoSize = true;
            this.ConfName7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName7.Location = new System.Drawing.Point(12, 319);
            this.ConfName7.Name = "ConfName7";
            this.ConfName7.Size = new System.Drawing.Size(80, 15);
            this.ConfName7.TabIndex = 18;
            this.ConfName7.Text = "Conference";
            // 
            // ConfName6
            // 
            this.ConfName6.AutoSize = true;
            this.ConfName6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName6.Location = new System.Drawing.Point(792, 9);
            this.ConfName6.Name = "ConfName6";
            this.ConfName6.Size = new System.Drawing.Size(80, 15);
            this.ConfName6.TabIndex = 17;
            this.ConfName6.Text = "Conference";
            // 
            // ConfName5
            // 
            this.ConfName5.AutoSize = true;
            this.ConfName5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName5.Location = new System.Drawing.Point(636, 9);
            this.ConfName5.Name = "ConfName5";
            this.ConfName5.Size = new System.Drawing.Size(80, 15);
            this.ConfName5.TabIndex = 16;
            this.ConfName5.Text = "Conference";
            // 
            // ConfName4
            // 
            this.ConfName4.AutoSize = true;
            this.ConfName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName4.Location = new System.Drawing.Point(480, 9);
            this.ConfName4.Name = "ConfName4";
            this.ConfName4.Size = new System.Drawing.Size(80, 15);
            this.ConfName4.TabIndex = 15;
            this.ConfName4.Text = "Conference";
            // 
            // ConfName3
            // 
            this.ConfName3.AutoSize = true;
            this.ConfName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName3.Location = new System.Drawing.Point(324, 9);
            this.ConfName3.Name = "ConfName3";
            this.ConfName3.Size = new System.Drawing.Size(80, 15);
            this.ConfName3.TabIndex = 14;
            this.ConfName3.Text = "Conference";
            // 
            // ConfName2
            // 
            this.ConfName2.AutoSize = true;
            this.ConfName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName2.Location = new System.Drawing.Point(168, 9);
            this.ConfName2.Name = "ConfName2";
            this.ConfName2.Size = new System.Drawing.Size(80, 15);
            this.ConfName2.TabIndex = 13;
            this.ConfName2.Text = "Conference";
            // 
            // ConfName1
            // 
            this.ConfName1.AutoSize = true;
            this.ConfName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfName1.Location = new System.Drawing.Point(12, 9);
            this.ConfName1.Name = "ConfName1";
            this.ConfName1.Size = new System.Drawing.Size(80, 15);
            this.ConfName1.TabIndex = 12;
            this.ConfName1.Text = "Conference";
            // 
            // conf12
            // 
            this.conf12.BackColor = System.Drawing.Color.Gainsboro;
            this.conf12.CheckOnClick = true;
            this.conf12.FormattingEnabled = true;
            this.conf12.Location = new System.Drawing.Point(792, 335);
            this.conf12.Name = "conf12";
            this.conf12.Size = new System.Drawing.Size(150, 274);
            this.conf12.TabIndex = 11;
            this.conf12.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf11
            // 
            this.conf11.BackColor = System.Drawing.Color.Gainsboro;
            this.conf11.CheckOnClick = true;
            this.conf11.FormattingEnabled = true;
            this.conf11.Location = new System.Drawing.Point(636, 335);
            this.conf11.Name = "conf11";
            this.conf11.Size = new System.Drawing.Size(150, 274);
            this.conf11.TabIndex = 10;
            this.conf11.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf10
            // 
            this.conf10.BackColor = System.Drawing.Color.Gainsboro;
            this.conf10.CheckOnClick = true;
            this.conf10.FormattingEnabled = true;
            this.conf10.Location = new System.Drawing.Point(480, 335);
            this.conf10.Name = "conf10";
            this.conf10.Size = new System.Drawing.Size(150, 274);
            this.conf10.TabIndex = 9;
            this.conf10.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf9
            // 
            this.conf9.BackColor = System.Drawing.Color.Gainsboro;
            this.conf9.CheckOnClick = true;
            this.conf9.FormattingEnabled = true;
            this.conf9.Location = new System.Drawing.Point(324, 335);
            this.conf9.Name = "conf9";
            this.conf9.Size = new System.Drawing.Size(150, 274);
            this.conf9.TabIndex = 8;
            this.conf9.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf8
            // 
            this.conf8.BackColor = System.Drawing.Color.Gainsboro;
            this.conf8.CheckOnClick = true;
            this.conf8.FormattingEnabled = true;
            this.conf8.Location = new System.Drawing.Point(168, 335);
            this.conf8.Name = "conf8";
            this.conf8.Size = new System.Drawing.Size(150, 274);
            this.conf8.TabIndex = 7;
            this.conf8.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf7
            // 
            this.conf7.BackColor = System.Drawing.Color.Gainsboro;
            this.conf7.CheckOnClick = true;
            this.conf7.FormattingEnabled = true;
            this.conf7.Location = new System.Drawing.Point(12, 335);
            this.conf7.Name = "conf7";
            this.conf7.Size = new System.Drawing.Size(150, 274);
            this.conf7.TabIndex = 6;
            this.conf7.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf6
            // 
            this.conf6.BackColor = System.Drawing.Color.Gainsboro;
            this.conf6.CheckOnClick = true;
            this.conf6.FormattingEnabled = true;
            this.conf6.Location = new System.Drawing.Point(792, 27);
            this.conf6.Name = "conf6";
            this.conf6.Size = new System.Drawing.Size(150, 274);
            this.conf6.TabIndex = 5;
            this.conf6.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf5
            // 
            this.conf5.BackColor = System.Drawing.Color.Gainsboro;
            this.conf5.CheckOnClick = true;
            this.conf5.FormattingEnabled = true;
            this.conf5.Location = new System.Drawing.Point(636, 27);
            this.conf5.Name = "conf5";
            this.conf5.Size = new System.Drawing.Size(150, 274);
            this.conf5.TabIndex = 4;
            this.conf5.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf4
            // 
            this.conf4.BackColor = System.Drawing.Color.Gainsboro;
            this.conf4.CheckOnClick = true;
            this.conf4.FormattingEnabled = true;
            this.conf4.Location = new System.Drawing.Point(480, 27);
            this.conf4.Name = "conf4";
            this.conf4.Size = new System.Drawing.Size(150, 274);
            this.conf4.TabIndex = 3;
            this.conf4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf3
            // 
            this.conf3.BackColor = System.Drawing.Color.Gainsboro;
            this.conf3.CheckOnClick = true;
            this.conf3.FormattingEnabled = true;
            this.conf3.Location = new System.Drawing.Point(324, 27);
            this.conf3.Name = "conf3";
            this.conf3.Size = new System.Drawing.Size(150, 274);
            this.conf3.TabIndex = 2;
            this.conf3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf2
            // 
            this.conf2.BackColor = System.Drawing.Color.Gainsboro;
            this.conf2.CheckOnClick = true;
            this.conf2.FormattingEnabled = true;
            this.conf2.Location = new System.Drawing.Point(168, 27);
            this.conf2.Name = "conf2";
            this.conf2.Size = new System.Drawing.Size(150, 274);
            this.conf2.TabIndex = 1;
            this.conf2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf1
            // 
            this.conf1.BackColor = System.Drawing.Color.Gainsboro;
            this.conf1.CheckOnClick = true;
            this.conf1.FormattingEnabled = true;
            this.conf1.Location = new System.Drawing.Point(12, 27);
            this.conf1.Name = "conf1";
            this.conf1.Size = new System.Drawing.Size(150, 274);
            this.conf1.TabIndex = 0;
            this.conf1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
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
            this.tabDev.Controls.Add(this.textBox6);
            this.tabDev.Controls.Add(this.DevCalcTeamRatingsButton);
            this.tabDev.Controls.Add(this.DevDepthChartButton);
            this.tabDev.Controls.Add(this.DevRandomizeFaceButton);
            this.tabDev.Controls.Add(this.DevCalcOVRButton);
            this.tabDev.Controls.Add(this.DevFillRosterButton);
            this.tabDev.Controls.Add(this.CreateTransfersCSVButton);
            this.tabDev.Controls.Add(this.ImportRecruitsButton);
            this.tabDev.Controls.Add(this.GraduateButton);
            this.tabDev.Location = new System.Drawing.Point(4, 24);
            this.tabDev.Name = "tabDev";
            this.tabDev.Padding = new System.Windows.Forms.Padding(3);
            this.tabDev.Size = new System.Drawing.Size(1152, 615);
            this.tabDev.TabIndex = 8;
            this.tabDev.Text = "Dev";
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBox20.Enabled = false;
            this.textBox20.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.Location = new System.Drawing.Point(499, 535);
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
            this.textBox19.Location = new System.Drawing.Point(499, 417);
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
            this.textBox18.Location = new System.Drawing.Point(499, 305);
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
            this.textBox16.Location = new System.Drawing.Point(15, 535);
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
            this.textBox15.Location = new System.Drawing.Point(15, 417);
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
            this.textBox14.Location = new System.Drawing.Point(15, 306);
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
            this.textBox12.Location = new System.Drawing.Point(702, 519);
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
            this.textBox11.Location = new System.Drawing.Point(702, 401);
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
            this.textBox10.Location = new System.Drawing.Point(702, 289);
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
            this.textBox8.Location = new System.Drawing.Point(218, 519);
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
            this.textBox7.Location = new System.Drawing.Point(218, 289);
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
            this.textBox5.Location = new System.Drawing.Point(218, 399);
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
            // DevCalcTeamRatingsButton
            // 
            this.DevCalcTeamRatingsButton.BackColor = System.Drawing.Color.DarkGray;
            this.DevCalcTeamRatingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevCalcTeamRatingsButton.Location = new System.Drawing.Point(554, 519);
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
            this.DevDepthChartButton.Location = new System.Drawing.Point(554, 401);
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
            this.DevRandomizeFaceButton.Location = new System.Drawing.Point(554, 289);
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
            this.DevCalcOVRButton.Location = new System.Drawing.Point(76, 519);
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
            this.CreateTransfersCSVButton.Location = new System.Drawing.Point(76, 289);
            this.CreateTransfersCSVButton.Name = "CreateTransfersCSVButton";
            this.CreateTransfersCSVButton.Size = new System.Drawing.Size(110, 80);
            this.CreateTransfersCSVButton.TabIndex = 28;
            this.CreateTransfersCSVButton.Text = "Import Transfers";
            this.CreateTransfersCSVButton.UseVisualStyleBackColor = false;
            this.CreateTransfersCSVButton.Click += new System.EventHandler(this.CreateTransfersCSVButton_Click);
            // 
            // ImportRecruitsButton
            // 
            this.ImportRecruitsButton.BackColor = System.Drawing.Color.DarkGray;
            this.ImportRecruitsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportRecruitsButton.Location = new System.Drawing.Point(76, 399);
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
            // tabTools
            // 
            this.tabTools.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabTools.Controls.Add(this.FantasyCoachesButton);
            this.tabTools.Controls.Add(this.SyncPBButton);
            this.tabTools.Controls.Add(this.label109);
            this.tabTools.Controls.Add(this.label108);
            this.tabTools.Controls.Add(this.label107);
            this.tabTools.Controls.Add(this.MaxAttPosBox);
            this.tabTools.Controls.Add(this.MinAttPosBox);
            this.tabTools.Controls.Add(this.GlobalAttPosBox);
            this.tabTools.Controls.Add(this.MaxAttButton);
            this.tabTools.Controls.Add(this.MinAttButton);
            this.tabTools.Controls.Add(this.GlobalAttButton);
            this.tabTools.Controls.Add(this.MaxAttRating);
            this.tabTools.Controls.Add(this.MinAttRating);
            this.tabTools.Controls.Add(this.textBox3);
            this.tabTools.Controls.Add(this.textBox2);
            this.tabTools.Controls.Add(this.MaxAttNum);
            this.tabTools.Controls.Add(this.label106);
            this.tabTools.Controls.Add(this.MaxAttBox);
            this.tabTools.Controls.Add(this.MinAttNum);
            this.tabTools.Controls.Add(this.label100);
            this.tabTools.Controls.Add(this.MinAttBox);
            this.tabTools.Controls.Add(this.GlobalAttCheck);
            this.tabTools.Controls.Add(this.GlobalAttNum);
            this.tabTools.Controls.Add(this.label99);
            this.tabTools.Controls.Add(this.GlobalAttBox);
            this.tabTools.Controls.Add(this.ReorderPGIDButton);
            this.tabTools.Controls.Add(this.TORDButton);
            this.tabTools.Controls.Add(this.CFUSAexportButton);
            this.tabTools.Controls.Add(this.RandomizeHeadButton);
            this.tabTools.Controls.Add(this.label58);
            this.tabTools.Controls.Add(this.FillRosterPCT);
            this.tabTools.Controls.Add(this.buttonFillRosters);
            this.tabTools.Controls.Add(this.buttonAutoDepthChart);
            this.tabTools.Controls.Add(this.buttonFantasyRoster);
            this.tabTools.Controls.Add(this.buttonImpactPlayers);
            this.tabTools.Controls.Add(this.TYDNButton);
            this.tabTools.Controls.Add(this.buttonCalcOverall);
            this.tabTools.Controls.Add(this.buttonRandPotential);
            this.tabTools.Controls.Add(qbTend);
            this.tabTools.Controls.Add(this.bodyFix);
            this.tabTools.Location = new System.Drawing.Point(4, 24);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(1152, 615);
            this.tabTools.TabIndex = 5;
            this.tabTools.Text = "dbTools";
            // 
            // FantasyCoachesButton
            // 
            this.FantasyCoachesButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.FantasyCoachesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FantasyCoachesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FantasyCoachesButton.Location = new System.Drawing.Point(274, 500);
            this.FantasyCoachesButton.Name = "FantasyCoachesButton";
            this.FantasyCoachesButton.Size = new System.Drawing.Size(239, 80);
            this.FantasyCoachesButton.TabIndex = 53;
            this.FantasyCoachesButton.Text = "Generate Fantasy Coaches";
            this.FantasyCoachesButton.UseVisualStyleBackColor = false;
            this.FantasyCoachesButton.Click += new System.EventHandler(this.FantasyCoachesButton_Click);
            // 
            // SyncPBButton
            // 
            this.SyncPBButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SyncPBButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncPBButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SyncPBButton.Location = new System.Drawing.Point(143, 519);
            this.SyncPBButton.Name = "SyncPBButton";
            this.SyncPBButton.Size = new System.Drawing.Size(110, 80);
            this.SyncPBButton.TabIndex = 52;
            this.SyncPBButton.Text = "Sync Team and Coach Playbooks";
            this.SyncPBButton.UseVisualStyleBackColor = false;
            this.SyncPBButton.Click += new System.EventHandler(this.SyncPBButton_Click);
            // 
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(278, 306);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(44, 13);
            this.label109.TabIndex = 51;
            this.label109.Text = "Position";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(279, 197);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(44, 13);
            this.label108.TabIndex = 50;
            this.label108.Text = "Position";
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(279, 82);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(44, 13);
            this.label107.TabIndex = 49;
            this.label107.Text = "Position";
            // 
            // MaxAttPosBox
            // 
            this.MaxAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttPosBox.FormattingEnabled = true;
            this.MaxAttPosBox.Location = new System.Drawing.Point(281, 321);
            this.MaxAttPosBox.Name = "MaxAttPosBox";
            this.MaxAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.MaxAttPosBox.TabIndex = 48;
            // 
            // MinAttPosBox
            // 
            this.MinAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttPosBox.FormattingEnabled = true;
            this.MinAttPosBox.Location = new System.Drawing.Point(282, 211);
            this.MinAttPosBox.Name = "MinAttPosBox";
            this.MinAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.MinAttPosBox.TabIndex = 47;
            // 
            // GlobalAttPosBox
            // 
            this.GlobalAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttPosBox.FormattingEnabled = true;
            this.GlobalAttPosBox.Location = new System.Drawing.Point(282, 98);
            this.GlobalAttPosBox.Name = "GlobalAttPosBox";
            this.GlobalAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.GlobalAttPosBox.TabIndex = 46;
            // 
            // MaxAttButton
            // 
            this.MaxAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MaxAttButton.Location = new System.Drawing.Point(524, 348);
            this.MaxAttButton.Name = "MaxAttButton";
            this.MaxAttButton.Size = new System.Drawing.Size(75, 23);
            this.MaxAttButton.TabIndex = 45;
            this.MaxAttButton.Text = "Update";
            this.MaxAttButton.UseVisualStyleBackColor = false;
            this.MaxAttButton.Click += new System.EventHandler(this.MaxAttButton_Click);
            // 
            // MinAttButton
            // 
            this.MinAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MinAttButton.Location = new System.Drawing.Point(525, 240);
            this.MinAttButton.Name = "MinAttButton";
            this.MinAttButton.Size = new System.Drawing.Size(75, 23);
            this.MinAttButton.TabIndex = 44;
            this.MinAttButton.Text = "Update";
            this.MinAttButton.UseVisualStyleBackColor = false;
            this.MinAttButton.Click += new System.EventHandler(this.MinAttButton_Click);
            // 
            // GlobalAttButton
            // 
            this.GlobalAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GlobalAttButton.Location = new System.Drawing.Point(525, 126);
            this.GlobalAttButton.Name = "GlobalAttButton";
            this.GlobalAttButton.Size = new System.Drawing.Size(75, 23);
            this.GlobalAttButton.TabIndex = 43;
            this.GlobalAttButton.Text = "Update";
            this.GlobalAttButton.UseVisualStyleBackColor = false;
            this.GlobalAttButton.Click += new System.EventHandler(this.GlobalAttButton_Click);
            // 
            // MaxAttRating
            // 
            this.MaxAttRating.BackColor = System.Drawing.SystemColors.Info;
            this.MaxAttRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttRating.Location = new System.Drawing.Point(599, 320);
            this.MaxAttRating.Name = "MaxAttRating";
            this.MaxAttRating.ReadOnly = true;
            this.MaxAttRating.Size = new System.Drawing.Size(39, 21);
            this.MaxAttRating.TabIndex = 42;
            this.MaxAttRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinAttRating
            // 
            this.MinAttRating.BackColor = System.Drawing.SystemColors.Info;
            this.MinAttRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttRating.Location = new System.Drawing.Point(600, 213);
            this.MinAttRating.Name = "MinAttRating";
            this.MinAttRating.ReadOnly = true;
            this.MinAttRating.Size = new System.Drawing.Size(39, 21);
            this.MinAttRating.TabIndex = 41;
            this.MinAttRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(282, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(355, 33);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "NCAA Football Modding Toolkit";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(723, 36);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(395, 544);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // MaxAttNum
            // 
            this.MaxAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttNum.Location = new System.Drawing.Point(525, 322);
            this.MaxAttNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.MaxAttNum.Name = "MaxAttNum";
            this.MaxAttNum.Size = new System.Drawing.Size(68, 21);
            this.MaxAttNum.TabIndex = 39;
            this.MaxAttNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxAttNum.ValueChanged += new System.EventHandler(this.MaxAttNum_ValueChanged);
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(349, 289);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(191, 20);
            this.label106.TabIndex = 38;
            this.label106.Text = "Set Maximum Attribute";
            // 
            // MaxAttBox
            // 
            this.MaxAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttBox.FormattingEnabled = true;
            this.MaxAttBox.Location = new System.Drawing.Point(353, 320);
            this.MaxAttBox.Name = "MaxAttBox";
            this.MaxAttBox.Size = new System.Drawing.Size(150, 23);
            this.MaxAttBox.TabIndex = 37;
            // 
            // MinAttNum
            // 
            this.MinAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttNum.Location = new System.Drawing.Point(525, 213);
            this.MinAttNum.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.MinAttNum.Name = "MinAttNum";
            this.MinAttNum.Size = new System.Drawing.Size(68, 21);
            this.MinAttNum.TabIndex = 35;
            this.MinAttNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MinAttNum.ValueChanged += new System.EventHandler(this.MinAttNum_ValueChanged);
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(349, 180);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(187, 20);
            this.label100.TabIndex = 34;
            this.label100.Text = "Set Minimum Attribute";
            // 
            // MinAttBox
            // 
            this.MinAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttBox.FormattingEnabled = true;
            this.MinAttBox.Location = new System.Drawing.Point(353, 211);
            this.MinAttBox.Name = "MinAttBox";
            this.MinAttBox.Size = new System.Drawing.Size(150, 23);
            this.MinAttBox.TabIndex = 33;
            // 
            // GlobalAttCheck
            // 
            this.GlobalAttCheck.AutoSize = true;
            this.GlobalAttCheck.Location = new System.Drawing.Point(353, 130);
            this.GlobalAttCheck.Name = "GlobalAttCheck";
            this.GlobalAttCheck.Size = new System.Drawing.Size(137, 17);
            this.GlobalAttCheck.TabIndex = 32;
            this.GlobalAttCheck.Text = "Prestige Based Change";
            this.GlobalAttCheck.UseVisualStyleBackColor = true;
            // 
            // GlobalAttNum
            // 
            this.GlobalAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttNum.Location = new System.Drawing.Point(525, 100);
            this.GlobalAttNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.GlobalAttNum.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.GlobalAttNum.Name = "GlobalAttNum";
            this.GlobalAttNum.Size = new System.Drawing.Size(68, 21);
            this.GlobalAttNum.TabIndex = 31;
            this.GlobalAttNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.Location = new System.Drawing.Point(349, 67);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(189, 20);
            this.label99.TabIndex = 30;
            this.label99.Text = "Global Attribute Editor";
            // 
            // GlobalAttBox
            // 
            this.GlobalAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttBox.FormattingEnabled = true;
            this.GlobalAttBox.Location = new System.Drawing.Point(353, 98);
            this.GlobalAttBox.Name = "GlobalAttBox";
            this.GlobalAttBox.Size = new System.Drawing.Size(150, 23);
            this.GlobalAttBox.TabIndex = 29;
            // 
            // ReorderPGIDButton
            // 
            this.ReorderPGIDButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ReorderPGIDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReorderPGIDButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReorderPGIDButton.Location = new System.Drawing.Point(16, 421);
            this.ReorderPGIDButton.Name = "ReorderPGIDButton";
            this.ReorderPGIDButton.Size = new System.Drawing.Size(110, 80);
            this.ReorderPGIDButton.TabIndex = 28;
            this.ReorderPGIDButton.Text = "Reorder PLAY Table (by PGID)";
            this.ReorderPGIDButton.UseVisualStyleBackColor = false;
            this.ReorderPGIDButton.Click += new System.EventHandler(this.ReorderPGIDButton_Click);
            // 
            // TORDButton
            // 
            this.TORDButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TORDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TORDButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TORDButton.Location = new System.Drawing.Point(143, 421);
            this.TORDButton.Name = "TORDButton";
            this.TORDButton.Size = new System.Drawing.Size(110, 80);
            this.TORDButton.TabIndex = 26;
            this.TORDButton.Text = "Reorder Teams (Dynasty)";
            this.TORDButton.UseVisualStyleBackColor = false;
            this.TORDButton.Click += new System.EventHandler(this.TORDButton_Click);
            // 
            // CFUSAexportButton
            // 
            this.CFUSAexportButton.BackColor = System.Drawing.Color.Pink;
            this.CFUSAexportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFUSAexportButton.Location = new System.Drawing.Point(16, 519);
            this.CFUSAexportButton.Name = "CFUSAexportButton";
            this.CFUSAexportButton.Size = new System.Drawing.Size(110, 80);
            this.CFUSAexportButton.TabIndex = 25;
            this.CFUSAexportButton.Text = "Export to CFB USA 97";
            this.CFUSAexportButton.UseVisualStyleBackColor = false;
            this.CFUSAexportButton.Click += new System.EventHandler(this.CFUSAexportButton_Click);
            // 
            // RandomizeHeadButton
            // 
            this.RandomizeHeadButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.RandomizeHeadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomizeHeadButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RandomizeHeadButton.Location = new System.Drawing.Point(16, 211);
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
            this.label58.Location = new System.Drawing.Point(545, 591);
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
            this.FillRosterPCT.Location = new System.Drawing.Point(628, 589);
            this.FillRosterPCT.Name = "FillRosterPCT";
            this.FillRosterPCT.Size = new System.Drawing.Size(42, 20);
            this.FillRosterPCT.TabIndex = 22;
            this.FillRosterPCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FillRosterPCT.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // buttonFillRosters
            // 
            this.buttonFillRosters.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFillRosters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFillRosters.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFillRosters.Location = new System.Drawing.Point(525, 500);
            this.buttonFillRosters.Name = "buttonFillRosters";
            this.buttonFillRosters.Size = new System.Drawing.Size(145, 80);
            this.buttonFillRosters.TabIndex = 20;
            this.buttonFillRosters.Text = "Fill Rosters";
            this.buttonFillRosters.UseVisualStyleBackColor = false;
            this.buttonFillRosters.Click += new System.EventHandler(this.buttonFillRosters_Click);
            // 
            // buttonAutoDepthChart
            // 
            this.buttonAutoDepthChart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonAutoDepthChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAutoDepthChart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAutoDepthChart.Location = new System.Drawing.Point(525, 402);
            this.buttonAutoDepthChart.Name = "buttonAutoDepthChart";
            this.buttonAutoDepthChart.Size = new System.Drawing.Size(145, 80);
            this.buttonAutoDepthChart.TabIndex = 19;
            this.buttonAutoDepthChart.Text = "Auto-Set Depth Chart";
            this.buttonAutoDepthChart.UseVisualStyleBackColor = false;
            this.buttonAutoDepthChart.Click += new System.EventHandler(this.buttonAutoDepthChart_Click);
            // 
            // buttonFantasyRoster
            // 
            this.buttonFantasyRoster.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFantasyRoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFantasyRoster.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFantasyRoster.Location = new System.Drawing.Point(274, 402);
            this.buttonFantasyRoster.Name = "buttonFantasyRoster";
            this.buttonFantasyRoster.Size = new System.Drawing.Size(239, 80);
            this.buttonFantasyRoster.TabIndex = 18;
            this.buttonFantasyRoster.Text = "Generate Fantasy Roster";
            this.buttonFantasyRoster.UseVisualStyleBackColor = false;
            this.buttonFantasyRoster.Click += new System.EventHandler(this.buttonFantasyRoster_Click);
            // 
            // buttonImpactPlayers
            // 
            this.buttonImpactPlayers.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonImpactPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImpactPlayers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonImpactPlayers.Location = new System.Drawing.Point(16, 310);
            this.buttonImpactPlayers.Name = "buttonImpactPlayers";
            this.buttonImpactPlayers.Size = new System.Drawing.Size(110, 80);
            this.buttonImpactPlayers.TabIndex = 17;
            this.buttonImpactPlayers.Text = "Determine Impact Players";
            this.buttonImpactPlayers.UseVisualStyleBackColor = false;
            this.buttonImpactPlayers.Click += new System.EventHandler(this.buttonImpactPlayers_Click);
            // 
            // TYDNButton
            // 
            this.TYDNButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TYDNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TYDNButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TYDNButton.Location = new System.Drawing.Point(143, 14);
            this.TYDNButton.Name = "TYDNButton";
            this.TYDNButton.Size = new System.Drawing.Size(110, 80);
            this.TYDNButton.TabIndex = 16;
            this.TYDNButton.Text = "Recalculate Team Ratings";
            this.TYDNButton.UseVisualStyleBackColor = false;
            this.TYDNButton.Click += new System.EventHandler(this.TYDNButton_Click);
            // 
            // buttonCalcOverall
            // 
            this.buttonCalcOverall.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonCalcOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcOverall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCalcOverall.Location = new System.Drawing.Point(16, 15);
            this.buttonCalcOverall.Name = "buttonCalcOverall";
            this.buttonCalcOverall.Size = new System.Drawing.Size(110, 80);
            this.buttonCalcOverall.TabIndex = 15;
            this.buttonCalcOverall.Text = "Recalculate Player Overall";
            this.buttonCalcOverall.UseVisualStyleBackColor = false;
            this.buttonCalcOverall.Click += new System.EventHandler(this.buttonCalcOverall_Click);
            // 
            // buttonRandPotential
            // 
            this.buttonRandPotential.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRandPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandPotential.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRandPotential.Location = new System.Drawing.Point(143, 211);
            this.buttonRandPotential.Name = "buttonRandPotential";
            this.buttonRandPotential.Size = new System.Drawing.Size(110, 80);
            this.buttonRandPotential.TabIndex = 12;
            this.buttonRandPotential.Text = "Randomize Player Potential";
            this.buttonRandPotential.UseVisualStyleBackColor = false;
            this.buttonRandPotential.Click += new System.EventHandler(this.ButtonRandPotential_Click);
            // 
            // bodyFix
            // 
            this.bodyFix.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bodyFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyFix.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bodyFix.Location = new System.Drawing.Point(16, 111);
            this.bodyFix.Name = "bodyFix";
            this.bodyFix.Size = new System.Drawing.Size(110, 80);
            this.bodyFix.TabIndex = 9;
            this.bodyFix.Text = "Body Size Fixer";
            this.bodyFix.UseVisualStyleBackColor = false;
            this.bodyFix.Click += new System.EventHandler(this.BodyFix_Click);
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
            this.tabOffSeason.Location = new System.Drawing.Point(4, 24);
            this.tabOffSeason.Name = "tabOffSeason";
            this.tabOffSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffSeason.Size = new System.Drawing.Size(1152, 615);
            this.tabOffSeason.TabIndex = 4;
            this.tabOffSeason.Text = "Recruiting";
            // 
            // buttonRandomizeFaceShape
            // 
            this.buttonRandomizeFaceShape.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandomizeFaceShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomizeFaceShape.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandomizeFaceShape.Location = new System.Drawing.Point(26, 327);
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
            this.labelPolyNamesPCT.Location = new System.Drawing.Point(142, 560);
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
            this.polyNamesPCT.Location = new System.Drawing.Point(156, 537);
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
            this.polyNames.BackColor = System.Drawing.SystemColors.Highlight;
            this.polyNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.polyNames.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.polyNames.Location = new System.Drawing.Point(26, 510);
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
            this.textBoxOffSeason.Location = new System.Drawing.Point(259, 57);
            this.textBoxOffSeason.Multiline = true;
            this.textBoxOffSeason.Name = "textBoxOffSeason";
            this.textBoxOffSeason.Size = new System.Drawing.Size(526, 523);
            this.textBoxOffSeason.TabIndex = 16;
            this.textBoxOffSeason.Text = resources.GetString("textBoxOffSeason.Text");
            // 
            // textBoxOffSeasonTitle
            // 
            this.textBoxOffSeasonTitle.Enabled = false;
            this.textBoxOffSeasonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffSeasonTitle.Location = new System.Drawing.Point(259, 20);
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
            this.labelIntTeams.Location = new System.Drawing.Point(154, 181);
            this.labelIntTeams.Name = "labelIntTeams";
            this.labelIntTeams.Size = new System.Drawing.Size(55, 16);
            this.labelIntTeams.TabIndex = 14;
            this.labelIntTeams.Text = "Teams";
            this.labelIntTeams.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // removeInterestTeams
            // 
            this.removeInterestTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeInterestTeams.Location = new System.Drawing.Point(156, 156);
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
            this.buttonInterestedTeams.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonInterestedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInterestedTeams.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonInterestedTeams.Location = new System.Drawing.Point(26, 123);
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
            this.label12.Location = new System.Drawing.Point(145, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Min TRPA";
            // 
            // minTRPA
            // 
            this.minTRPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTRPA.Location = new System.Drawing.Point(157, 23);
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
            this.labelMinRecPts.Location = new System.Drawing.Point(142, 104);
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
            this.minRecPts.Location = new System.Drawing.Point(157, 79);
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
            this.labelRecruit.Location = new System.Drawing.Point(143, 283);
            this.labelRecruit.Name = "labelRecruit";
            this.labelRecruit.Size = new System.Drawing.Size(78, 16);
            this.labelRecruit.TabIndex = 7;
            this.labelRecruit.Text = "Tolerance";
            this.labelRecruit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // recruitTolerance
            // 
            this.recruitTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recruitTolerance.Location = new System.Drawing.Point(157, 258);
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
            this.wkonLabel.Location = new System.Drawing.Point(142, 471);
            this.wkonLabel.Name = "wkonLabel";
            this.wkonLabel.Size = new System.Drawing.Size(78, 16);
            this.wkonLabel.TabIndex = 5;
            this.wkonLabel.Text = "Tolerance";
            this.wkonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toleranceWalkOn
            // 
            this.toleranceWalkOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toleranceWalkOn.Location = new System.Drawing.Point(156, 446);
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
            this.buttonRandRecruits.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandRecruits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandRecruits.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandRecruits.Location = new System.Drawing.Point(26, 232);
            this.buttonRandRecruits.Name = "buttonRandRecruits";
            this.buttonRandRecruits.Size = new System.Drawing.Size(110, 80);
            this.buttonRandRecruits.TabIndex = 3;
            this.buttonRandRecruits.Text = "Randomize Recruits";
            this.buttonRandRecruits.UseVisualStyleBackColor = false;
            this.buttonRandRecruits.Click += new System.EventHandler(this.ButtonRandRecruits_Click);
            // 
            // buttonRandWalkOns
            // 
            this.buttonRandWalkOns.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandWalkOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandWalkOns.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandWalkOns.Location = new System.Drawing.Point(26, 413);
            this.buttonRandWalkOns.Name = "buttonRandWalkOns";
            this.buttonRandWalkOns.Size = new System.Drawing.Size(110, 80);
            this.buttonRandWalkOns.TabIndex = 2;
            this.buttonRandWalkOns.Text = "Randomize Walk-Ons";
            this.buttonRandWalkOns.UseVisualStyleBackColor = false;
            this.buttonRandWalkOns.Click += new System.EventHandler(this.ButtonRandWalkOns_Click);
            // 
            // buttonMinRecruitingPts
            // 
            this.buttonMinRecruitingPts.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonMinRecruitingPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinRecruitingPts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMinRecruitingPts.Location = new System.Drawing.Point(26, 18);
            this.buttonMinRecruitingPts.Name = "buttonMinRecruitingPts";
            this.buttonMinRecruitingPts.Size = new System.Drawing.Size(110, 80);
            this.buttonMinRecruitingPts.TabIndex = 1;
            this.buttonMinRecruitingPts.Text = "Raise Minimum Recruiting Points";
            this.buttonMinRecruitingPts.UseVisualStyleBackColor = false;
            this.buttonMinRecruitingPts.Click += new System.EventHandler(this.ButtonMinRecruitingPts_Click);
            // 
            // tabSeason
            // 
            this.tabSeason.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabSeason.Controls.Add(this.CoachPrestigeButton);
            this.tabSeason.Controls.Add(this.label14);
            this.tabSeason.Controls.Add(this.numberPlayerCoach);
            this.tabSeason.Controls.Add(this.buttonPlayerCoach);
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
            this.tabSeason.Location = new System.Drawing.Point(4, 24);
            this.tabSeason.Name = "tabSeason";
            this.tabSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeason.Size = new System.Drawing.Size(1152, 615);
            this.tabSeason.TabIndex = 3;
            this.tabSeason.Text = "Dynasty";
            // 
            // CoachPrestigeButton
            // 
            this.CoachPrestigeButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CoachPrestigeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachPrestigeButton.Location = new System.Drawing.Point(166, 322);
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
            this.label14.Location = new System.Drawing.Point(24, 587);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Number of Players";
            // 
            // numberPlayerCoach
            // 
            this.numberPlayerCoach.Location = new System.Drawing.Point(27, 564);
            this.numberPlayerCoach.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberPlayerCoach.Name = "numberPlayerCoach";
            this.numberPlayerCoach.Size = new System.Drawing.Size(72, 20);
            this.numberPlayerCoach.TabIndex = 31;
            // 
            // buttonPlayerCoach
            // 
            this.buttonPlayerCoach.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPlayerCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerCoach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPlayerCoach.Location = new System.Drawing.Point(24, 478);
            this.buttonPlayerCoach.Name = "buttonPlayerCoach";
            this.buttonPlayerCoach.Size = new System.Drawing.Size(110, 80);
            this.buttonPlayerCoach.TabIndex = 30;
            this.buttonPlayerCoach.Text = "Players to Coach";
            this.buttonPlayerCoach.UseVisualStyleBackColor = false;
            this.buttonPlayerCoach.Click += new System.EventHandler(this.buttonPlayerCoach_Click);
            // 
            // buttonRealignment
            // 
            this.buttonRealignment.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRealignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRealignment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRealignment.Location = new System.Drawing.Point(304, 59);
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
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(24, 460);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(359, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "NCAA NEXT USERS - Perform At Players Leaving Stage";
            // 
            // labelMaxTransfers
            // 
            this.labelMaxTransfers.AutoSize = true;
            this.labelMaxTransfers.Location = new System.Drawing.Point(388, 543);
            this.labelMaxTransfers.Name = "labelMaxTransfers";
            this.labelMaxTransfers.Size = new System.Drawing.Size(74, 13);
            this.labelMaxTransfers.TabIndex = 26;
            this.labelMaxTransfers.Text = "Max Transfers";
            // 
            // maxFiredTransfers
            // 
            this.maxFiredTransfers.Location = new System.Drawing.Point(391, 520);
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
            this.checkBoxFiredTransfers.Location = new System.Drawing.Point(391, 486);
            this.checkBoxFiredTransfers.Name = "checkBoxFiredTransfers";
            this.checkBoxFiredTransfers.Size = new System.Drawing.Size(98, 17);
            this.checkBoxFiredTransfers.TabIndex = 24;
            this.checkBoxFiredTransfers.Text = "Transfer Chaos";
            this.checkBoxFiredTransfers.UseVisualStyleBackColor = true;
            // 
            // buttonChaosTransfers
            // 
            this.buttonChaosTransfers.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonChaosTransfers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChaosTransfers.Location = new System.Drawing.Point(304, 195);
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
            this.labelMaxSkilDrop_PS.Location = new System.Drawing.Point(187, 117);
            this.labelMaxSkilDrop_PS.Name = "labelMaxSkilDrop_PS";
            this.labelMaxSkilDrop_PS.Size = new System.Drawing.Size(75, 13);
            this.labelMaxSkilDrop_PS.TabIndex = 22;
            this.labelMaxSkilDrop_PS.Text = "Max Skill Drop";
            // 
            // MaxSkillDropPS
            // 
            this.MaxSkillDropPS.Location = new System.Drawing.Point(139, 115);
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
            this.labelPSInjuries.Location = new System.Drawing.Point(136, 88);
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
            this.numInjuries.Location = new System.Drawing.Point(139, 65);
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
            this.buttonPSInjuries.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonPSInjuries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPSInjuries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPSInjuries.Location = new System.Drawing.Point(24, 59);
            this.buttonPSInjuries.Name = "buttonPSInjuries";
            this.buttonPSInjuries.Size = new System.Drawing.Size(110, 80);
            this.buttonPSInjuries.TabIndex = 18;
            this.buttonPSInjuries.Text = "Pre-Season Injuries";
            this.buttonPSInjuries.UseVisualStyleBackColor = false;
            this.buttonPSInjuries.Click += new System.EventHandler(this.ButtonPSInjuries_Click);
            // 
            // labelPoaching
            // 
            this.labelPoaching.AutoSize = true;
            this.labelPoaching.Location = new System.Drawing.Point(298, 543);
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
            this.poachValue.Location = new System.Drawing.Point(302, 523);
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
            this.labelJobSecurity.Location = new System.Drawing.Point(301, 506);
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
            this.jobSecurityValue.Location = new System.Drawing.Point(301, 483);
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
            this.buttonCarousel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonCarousel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarousel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCarousel.Location = new System.Drawing.Point(166, 478);
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
            this.labelSkillDrop.Location = new System.Drawing.Point(188, 243);
            this.labelSkillDrop.Name = "labelSkillDrop";
            this.labelSkillDrop.Size = new System.Drawing.Size(75, 13);
            this.labelSkillDrop.TabIndex = 11;
            this.labelSkillDrop.Text = "Max Skill Drop";
            // 
            // skillDrop
            // 
            this.skillDrop.Location = new System.Drawing.Point(140, 241);
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
            this.checkBoxInjuryRatings.Location = new System.Drawing.Point(139, 210);
            this.checkBoxInjuryRatings.Name = "checkBoxInjuryRatings";
            this.checkBoxInjuryRatings.Size = new System.Drawing.Size(103, 17);
            this.checkBoxInjuryRatings.TabIndex = 9;
            this.checkBoxInjuryRatings.Text = "Reduce Ratings";
            this.checkBoxInjuryRatings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxInjuryRatings.UseVisualStyleBackColor = true;
            // 
            // buttonRandomBudgets
            // 
            this.buttonRandomBudgets.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRandomBudgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomBudgets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRandomBudgets.Location = new System.Drawing.Point(27, 322);
            this.buttonRandomBudgets.Name = "buttonRandomBudgets";
            this.buttonRandomBudgets.Size = new System.Drawing.Size(110, 80);
            this.buttonRandomBudgets.TabIndex = 7;
            this.buttonRandomBudgets.Text = "Randomize Coaching Budgets";
            this.buttonRandomBudgets.UseVisualStyleBackColor = false;
            this.buttonRandomBudgets.Click += new System.EventHandler(this.ButtonRandomBudgets_Click);
            // 
            // dbToolsInfo
            // 
            this.dbToolsInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dbToolsInfo.Enabled = false;
            this.dbToolsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbToolsInfo.Location = new System.Drawing.Point(599, 20);
            this.dbToolsInfo.Multiline = true;
            this.dbToolsInfo.Name = "dbToolsInfo";
            this.dbToolsInfo.Size = new System.Drawing.Size(528, 580);
            this.dbToolsInfo.TabIndex = 3;
            this.dbToolsInfo.Text = resources.GetString("dbToolsInfo.Text");
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(8, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 33);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "NCAA Football Dynasty Toolkit";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // coachProg
            // 
            this.coachProg.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.coachProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coachProg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.coachProg.Location = new System.Drawing.Point(301, 322);
            this.coachProg.Name = "coachProg";
            this.coachProg.Size = new System.Drawing.Size(110, 80);
            this.coachProg.TabIndex = 1;
            this.coachProg.Text = "Coach Progression";
            this.coachProg.UseVisualStyleBackColor = false;
            this.coachProg.Click += new System.EventHandler(this.CoachProg_Click);
            // 
            // medRS
            // 
            this.medRS.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.medRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medRS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.medRS.Location = new System.Drawing.Point(24, 196);
            this.medRS.Name = "medRS";
            this.medRS.Size = new System.Drawing.Size(110, 80);
            this.medRS.TabIndex = 0;
            this.medRS.Text = "Medical Redshirt";
            this.medRS.UseVisualStyleBackColor = false;
            this.medRS.Click += new System.EventHandler(this.MedRS_Click);
            // 
            // tabCoaches
            // 
            this.tabCoaches.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabCoaches.Controls.Add(this.NewCoachButton);
            this.tabCoaches.Controls.Add(this.CoachShowTeamBox);
            this.tabCoaches.Controls.Add(this.CoachTeamList);
            this.tabCoaches.Controls.Add(this.label98);
            this.tabCoaches.Controls.Add(this.CFUCBox);
            this.tabCoaches.Controls.Add(this.label96);
            this.tabCoaches.Controls.Add(this.COHTBox);
            this.tabCoaches.Controls.Add(this.label97);
            this.tabCoaches.Controls.Add(this.CTgwBox);
            this.tabCoaches.Controls.Add(this.label95);
            this.tabCoaches.Controls.Add(this.CoachFilter);
            this.tabCoaches.Controls.Add(this.CoachPlaybookBox);
            this.tabCoaches.Controls.Add(this.CoachDefTypeBox);
            this.tabCoaches.Controls.Add(this.CoachOffTypeBox);
            this.tabCoaches.Controls.Add(this.label131);
            this.tabCoaches.Controls.Add(this.CoachCDTSBox);
            this.tabCoaches.Controls.Add(this.label132);
            this.tabCoaches.Controls.Add(this.CoachCDTABox);
            this.tabCoaches.Controls.Add(this.CoachCDTRBox);
            this.tabCoaches.Controls.Add(this.label133);
            this.tabCoaches.Controls.Add(this.label134);
            this.tabCoaches.Controls.Add(this.CoachCOTSBox);
            this.tabCoaches.Controls.Add(this.label135);
            this.tabCoaches.Controls.Add(this.CoachCOTABox);
            this.tabCoaches.Controls.Add(this.CoachCOTRBox);
            this.tabCoaches.Controls.Add(this.label136);
            this.tabCoaches.Controls.Add(this.label137);
            this.tabCoaches.Controls.Add(this.label138);
            this.tabCoaches.Controls.Add(this.label139);
            this.tabCoaches.Controls.Add(this.label140);
            this.tabCoaches.Controls.Add(this.CoachCCPONum);
            this.tabCoaches.Controls.Add(this.label141);
            this.tabCoaches.Controls.Add(this.HCPrestigeNum);
            this.tabCoaches.Controls.Add(this.CoachRecruitingBox);
            this.tabCoaches.Controls.Add(this.CoachTrainingBox);
            this.tabCoaches.Controls.Add(this.label142);
            this.tabCoaches.Controls.Add(this.label143);
            this.tabCoaches.Controls.Add(this.label144);
            this.tabCoaches.Controls.Add(this.label145);
            this.tabCoaches.Controls.Add(this.CoachDisciplineBox);
            this.tabCoaches.Controls.Add(this.CCIDBox);
            this.tabCoaches.Controls.Add(this.CoachLastNameBox);
            this.tabCoaches.Controls.Add(this.CoachFirstNameBox);
            this.tabCoaches.Controls.Add(this.label146);
            this.tabCoaches.Controls.Add(this.label94);
            this.tabCoaches.Controls.Add(this.label101);
            this.tabCoaches.Controls.Add(this.CTHGBox);
            this.tabCoaches.Controls.Add(this.label102);
            this.tabCoaches.Controls.Add(this.CHARBox);
            this.tabCoaches.Controls.Add(this.label103);
            this.tabCoaches.Controls.Add(this.CFEXBox);
            this.tabCoaches.Controls.Add(this.label104);
            this.tabCoaches.Controls.Add(this.CBSZBox);
            this.tabCoaches.Controls.Add(this.label105);
            this.tabCoaches.Controls.Add(this.CSKIBox);
            this.tabCoaches.Controls.Add(this.CoachListBox);
            this.tabCoaches.Controls.Add(this.label129);
            this.tabCoaches.Controls.Add(this.label130);
            this.tabCoaches.Location = new System.Drawing.Point(4, 24);
            this.tabCoaches.Name = "tabCoaches";
            this.tabCoaches.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoaches.Size = new System.Drawing.Size(1152, 615);
            this.tabCoaches.TabIndex = 7;
            this.tabCoaches.Text = "Coaches";
            // 
            // NewCoachButton
            // 
            this.NewCoachButton.BackColor = System.Drawing.Color.PaleGreen;
            this.NewCoachButton.Location = new System.Drawing.Point(669, 125);
            this.NewCoachButton.Name = "NewCoachButton";
            this.NewCoachButton.Size = new System.Drawing.Size(138, 44);
            this.NewCoachButton.TabIndex = 238;
            this.NewCoachButton.Text = "Generate New Coach";
            this.NewCoachButton.UseVisualStyleBackColor = false;
            this.NewCoachButton.Click += new System.EventHandler(this.NewCoachButton_Click);
            // 
            // CoachShowTeamBox
            // 
            this.CoachShowTeamBox.AutoSize = true;
            this.CoachShowTeamBox.Location = new System.Drawing.Point(12, 592);
            this.CoachShowTeamBox.Name = "CoachShowTeamBox";
            this.CoachShowTeamBox.Size = new System.Drawing.Size(83, 17);
            this.CoachShowTeamBox.TabIndex = 237;
            this.CoachShowTeamBox.Text = "Show Team";
            this.CoachShowTeamBox.UseVisualStyleBackColor = true;
            this.CoachShowTeamBox.CheckedChanged += new System.EventHandler(this.CoachShowTeamBox_CheckedChanged);
            // 
            // CoachTeamList
            // 
            this.CoachTeamList.FormattingEnabled = true;
            this.CoachTeamList.Location = new System.Drawing.Point(669, 87);
            this.CoachTeamList.MaxLength = 2;
            this.CoachTeamList.Name = "CoachTeamList";
            this.CoachTeamList.Size = new System.Drawing.Size(138, 21);
            this.CoachTeamList.TabIndex = 236;
            this.CoachTeamList.Tag = "x";
            this.CoachTeamList.SelectedIndexChanged += new System.EventHandler(this.CoachTeamList_SelectedIndexChanged);
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.Location = new System.Drawing.Point(666, 69);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(38, 13);
            this.label98.TabIndex = 235;
            this.label98.Text = "Team";
            // 
            // CFUCBox
            // 
            this.CFUCBox.AutoSize = true;
            this.CFUCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFUCBox.Location = new System.Drawing.Point(281, 25);
            this.CFUCBox.Name = "CFUCBox";
            this.CFUCBox.Size = new System.Drawing.Size(122, 24);
            this.CFUCBox.TabIndex = 234;
            this.CFUCBox.Text = "User Coach";
            this.CFUCBox.UseVisualStyleBackColor = true;
            this.CFUCBox.CheckedChanged += new System.EventHandler(this.CFUCBox_CheckedChanged);
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(529, 180);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(62, 13);
            this.label96.TabIndex = 233;
            this.label96.Text = "Head Wear";
            // 
            // COHTBox
            // 
            this.COHTBox.FormattingEnabled = true;
            this.COHTBox.Location = new System.Drawing.Point(513, 196);
            this.COHTBox.Name = "COHTBox";
            this.COHTBox.Size = new System.Drawing.Size(121, 21);
            this.COHTBox.TabIndex = 232;
            this.COHTBox.SelectedIndexChanged += new System.EventHandler(this.COHTBox_SelectedIndexChanged);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(423, 179);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(44, 13);
            this.label97.TabIndex = 231;
            this.label97.Text = "Glasses";
            // 
            // CTgwBox
            // 
            this.CTgwBox.FormattingEnabled = true;
            this.CTgwBox.Location = new System.Drawing.Point(426, 195);
            this.CTgwBox.Name = "CTgwBox";
            this.CTgwBox.Size = new System.Drawing.Size(81, 21);
            this.CTgwBox.TabIndex = 230;
            this.CTgwBox.SelectedIndexChanged += new System.EventHandler(this.CTgwBox_SelectedIndexChanged);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(12, 9);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(63, 13);
            this.label95.TabIndex = 227;
            this.label95.Text = "Coach Filter";
            // 
            // CoachFilter
            // 
            this.CoachFilter.FormattingEnabled = true;
            this.CoachFilter.Location = new System.Drawing.Point(12, 25);
            this.CoachFilter.Name = "CoachFilter";
            this.CoachFilter.Size = new System.Drawing.Size(175, 21);
            this.CoachFilter.TabIndex = 226;
            this.CoachFilter.SelectedIndexChanged += new System.EventHandler(this.CoachFilter_SelectedIndexChanged);
            // 
            // CoachPlaybookBox
            // 
            this.CoachPlaybookBox.FormattingEnabled = true;
            this.CoachPlaybookBox.Location = new System.Drawing.Point(374, 321);
            this.CoachPlaybookBox.MaxLength = 2;
            this.CoachPlaybookBox.Name = "CoachPlaybookBox";
            this.CoachPlaybookBox.Size = new System.Drawing.Size(138, 21);
            this.CoachPlaybookBox.TabIndex = 225;
            this.CoachPlaybookBox.Tag = "x";
            this.CoachPlaybookBox.SelectedIndexChanged += new System.EventHandler(this.CoachPlaybookBox_SelectedIndexChanged);
            // 
            // CoachDefTypeBox
            // 
            this.CoachDefTypeBox.FormattingEnabled = true;
            this.CoachDefTypeBox.Location = new System.Drawing.Point(478, 372);
            this.CoachDefTypeBox.MaxLength = 2;
            this.CoachDefTypeBox.Name = "CoachDefTypeBox";
            this.CoachDefTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CoachDefTypeBox.Size = new System.Drawing.Size(138, 21);
            this.CoachDefTypeBox.TabIndex = 224;
            this.CoachDefTypeBox.Tag = "x";
            this.CoachDefTypeBox.SelectedIndexChanged += new System.EventHandler(this.CoachDefTypeBox_SelectedIndexChanged);
            // 
            // CoachOffTypeBox
            // 
            this.CoachOffTypeBox.FormattingEnabled = true;
            this.CoachOffTypeBox.Location = new System.Drawing.Point(286, 372);
            this.CoachOffTypeBox.MaxLength = 2;
            this.CoachOffTypeBox.Name = "CoachOffTypeBox";
            this.CoachOffTypeBox.Size = new System.Drawing.Size(138, 21);
            this.CoachOffTypeBox.TabIndex = 223;
            this.CoachOffTypeBox.Tag = "x";
            this.CoachOffTypeBox.SelectedIndexChanged += new System.EventHandler(this.CoachOffTypeBox_SelectedIndexChanged);
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label131.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(493, 25);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(141, 25);
            this.label131.TabIndex = 222;
            this.label131.Text = "Head Coach";
            // 
            // CoachCDTSBox
            // 
            this.CoachCDTSBox.Location = new System.Drawing.Point(478, 493);
            this.CoachCDTSBox.Name = "CoachCDTSBox";
            this.CoachCDTSBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTSBox.TabIndex = 221;
            this.CoachCDTSBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTSBox.ValueChanged += new System.EventHandler(this.CoachCDTSBox_ValueChanged);
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(531, 498);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(31, 13);
            this.label132.TabIndex = 220;
            this.label132.Text = "Subs";
            // 
            // CoachCDTABox
            // 
            this.CoachCDTABox.Location = new System.Drawing.Point(478, 458);
            this.CoachCDTABox.Name = "CoachCDTABox";
            this.CoachCDTABox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTABox.TabIndex = 219;
            this.CoachCDTABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTABox.ValueChanged += new System.EventHandler(this.CoachCDTABox_ValueChanged);
            // 
            // CoachCDTRBox
            // 
            this.CoachCDTRBox.Location = new System.Drawing.Point(478, 417);
            this.CoachCDTRBox.Name = "CoachCDTRBox";
            this.CoachCDTRBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTRBox.TabIndex = 218;
            this.CoachCDTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTRBox.ValueChanged += new System.EventHandler(this.CoachCDTRBox_ValueChanged);
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(530, 460);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(81, 13);
            this.label133.TabIndex = 217;
            this.label133.Text = "Aggressiveness";
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(530, 417);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(63, 13);
            this.label134.TabIndex = 216;
            this.label134.Text = "Passing Pct";
            // 
            // CoachCOTSBox
            // 
            this.CoachCOTSBox.Location = new System.Drawing.Point(374, 491);
            this.CoachCOTSBox.Name = "CoachCOTSBox";
            this.CoachCOTSBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTSBox.TabIndex = 215;
            this.CoachCOTSBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTSBox.ValueChanged += new System.EventHandler(this.CoachCOTSBox_ValueChanged);
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(332, 493);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(31, 13);
            this.label135.TabIndex = 214;
            this.label135.Text = "Subs";
            // 
            // CoachCOTABox
            // 
            this.CoachCOTABox.Location = new System.Drawing.Point(374, 456);
            this.CoachCOTABox.Name = "CoachCOTABox";
            this.CoachCOTABox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTABox.TabIndex = 213;
            this.CoachCOTABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTABox.ValueChanged += new System.EventHandler(this.CoachCOTABox_ValueChanged);
            // 
            // CoachCOTRBox
            // 
            this.CoachCOTRBox.Location = new System.Drawing.Point(374, 417);
            this.CoachCOTRBox.Name = "CoachCOTRBox";
            this.CoachCOTRBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTRBox.TabIndex = 212;
            this.CoachCOTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTRBox.ValueChanged += new System.EventHandler(this.CoachCOTRBox_ValueChanged);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(290, 458);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(81, 13);
            this.label136.TabIndex = 211;
            this.label136.Text = "Aggressiveness";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(300, 419);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(63, 13);
            this.label137.TabIndex = 210;
            this.label137.Text = "Passing Pct";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(414, 305);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(59, 13);
            this.label138.TabIndex = 209;
            this.label138.Text = "Playbook";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(292, 356);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(71, 13);
            this.label139.TabIndex = 208;
            this.label139.Text = "Offense Type";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(488, 356);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(74, 13);
            this.label140.TabIndex = 207;
            this.label140.Text = "Base Defense";
            // 
            // CoachCCPONum
            // 
            this.CoachCCPONum.Location = new System.Drawing.Point(354, 246);
            this.CoachCCPONum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CoachCCPONum.Name = "CoachCCPONum";
            this.CoachCCPONum.Size = new System.Drawing.Size(50, 20);
            this.CoachCCPONum.TabIndex = 206;
            this.CoachCCPONum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCCPONum.ValueChanged += new System.EventHandler(this.CoachCCPONum_ValueChanged);
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(350, 231);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(67, 13);
            this.label141.TabIndex = 205;
            this.label141.Text = "Performance";
            // 
            // HCPrestigeNum
            // 
            this.HCPrestigeNum.Location = new System.Drawing.Point(286, 246);
            this.HCPrestigeNum.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.HCPrestigeNum.Name = "HCPrestigeNum";
            this.HCPrestigeNum.Size = new System.Drawing.Size(50, 20);
            this.HCPrestigeNum.TabIndex = 204;
            this.HCPrestigeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCPrestigeNum.ValueChanged += new System.EventHandler(this.HCPrestigeNum_ValueChanged);
            // 
            // CoachRecruitingBox
            // 
            this.CoachRecruitingBox.Location = new System.Drawing.Point(776, 284);
            this.CoachRecruitingBox.Name = "CoachRecruitingBox";
            this.CoachRecruitingBox.Size = new System.Drawing.Size(50, 20);
            this.CoachRecruitingBox.TabIndex = 203;
            this.CoachRecruitingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachRecruitingBox.ValueChanged += new System.EventHandler(this.CoachRecruitingBox_ValueChanged);
            // 
            // CoachTrainingBox
            // 
            this.CoachTrainingBox.Location = new System.Drawing.Point(707, 283);
            this.CoachTrainingBox.Name = "CoachTrainingBox";
            this.CoachTrainingBox.Size = new System.Drawing.Size(50, 20);
            this.CoachTrainingBox.TabIndex = 202;
            this.CoachTrainingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachTrainingBox.ValueChanged += new System.EventHandler(this.CoachTrainingBox_ValueChanged);
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(672, 251);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(114, 13);
            this.label142.TabIndex = 201;
            this.label142.Text = "Off-Season Budget";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(773, 267);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(55, 13);
            this.label143.TabIndex = 200;
            this.label143.Text = "Recruiting";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(712, 267);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(45, 13);
            this.label144.TabIndex = 199;
            this.label144.Text = "Training";
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(637, 267);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(60, 13);
            this.label145.TabIndex = 198;
            this.label145.Text = "Disciplining";
            // 
            // CoachDisciplineBox
            // 
            this.CoachDisciplineBox.Location = new System.Drawing.Point(640, 283);
            this.CoachDisciplineBox.Name = "CoachDisciplineBox";
            this.CoachDisciplineBox.ReadOnly = true;
            this.CoachDisciplineBox.Size = new System.Drawing.Size(50, 20);
            this.CoachDisciplineBox.TabIndex = 197;
            this.CoachDisciplineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CCIDBox
            // 
            this.CCIDBox.BackColor = System.Drawing.SystemColors.Info;
            this.CCIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCIDBox.Location = new System.Drawing.Point(544, 87);
            this.CCIDBox.Name = "CCIDBox";
            this.CCIDBox.ReadOnly = true;
            this.CCIDBox.Size = new System.Drawing.Size(53, 22);
            this.CCIDBox.TabIndex = 191;
            this.CCIDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoachLastNameBox
            // 
            this.CoachLastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachLastNameBox.Location = new System.Drawing.Point(408, 87);
            this.CoachLastNameBox.Name = "CoachLastNameBox";
            this.CoachLastNameBox.Size = new System.Drawing.Size(111, 22);
            this.CoachLastNameBox.TabIndex = 100;
            this.CoachLastNameBox.Leave += new System.EventHandler(this.CoachLastNameBox_TextChanged);
            // 
            // CoachFirstNameBox
            // 
            this.CoachFirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachFirstNameBox.Location = new System.Drawing.Point(286, 87);
            this.CoachFirstNameBox.Name = "CoachFirstNameBox";
            this.CoachFirstNameBox.Size = new System.Drawing.Size(116, 22);
            this.CoachFirstNameBox.TabIndex = 99;
            this.CoachFirstNameBox.Leave += new System.EventHandler(this.CoachFirstNameBox_TextChanged);
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(283, 230);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(63, 13);
            this.label146.TabIndex = 195;
            this.label146.Text = "HC Prestige";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(536, 68);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(70, 16);
            this.label94.TabIndex = 192;
            this.label94.Text = "Coach ID";
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(541, 132);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(52, 13);
            this.label101.TabIndex = 177;
            this.label101.Text = "Hair Style";
            // 
            // CTHGBox
            // 
            this.CTHGBox.FormattingEnabled = true;
            this.CTHGBox.Location = new System.Drawing.Point(544, 148);
            this.CTHGBox.Name = "CTHGBox";
            this.CTHGBox.Size = new System.Drawing.Size(90, 21);
            this.CTHGBox.TabIndex = 176;
            this.CTHGBox.SelectedIndexChanged += new System.EventHandler(this.CTHGBox_SelectedIndexChanged);
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(441, 132);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(53, 13);
            this.label102.TabIndex = 175;
            this.label102.Text = "Hair Color";
            // 
            // CHARBox
            // 
            this.CHARBox.FormattingEnabled = true;
            this.CHARBox.Location = new System.Drawing.Point(444, 148);
            this.CHARBox.Name = "CHARBox";
            this.CHARBox.Size = new System.Drawing.Size(94, 21);
            this.CHARBox.TabIndex = 174;
            this.CHARBox.SelectedIndexChanged += new System.EventHandler(this.CHARBox_SelectedIndexChanged);
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(287, 179);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(31, 13);
            this.label103.TabIndex = 173;
            this.label103.Text = "Face";
            // 
            // CFEXBox
            // 
            this.CFEXBox.FormattingEnabled = true;
            this.CFEXBox.Location = new System.Drawing.Point(286, 195);
            this.CFEXBox.Name = "CFEXBox";
            this.CFEXBox.Size = new System.Drawing.Size(91, 21);
            this.CFEXBox.TabIndex = 172;
            this.CFEXBox.SelectedIndexChanged += new System.EventHandler(this.CFEXBox_SelectedIndexChanged);
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(356, 131);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(31, 13);
            this.label104.TabIndex = 171;
            this.label104.Text = "Body";
            // 
            // CBSZBox
            // 
            this.CBSZBox.FormattingEnabled = true;
            this.CBSZBox.Location = new System.Drawing.Point(359, 148);
            this.CBSZBox.Name = "CBSZBox";
            this.CBSZBox.Size = new System.Drawing.Size(68, 21);
            this.CBSZBox.TabIndex = 170;
            this.CBSZBox.SelectedIndexChanged += new System.EventHandler(this.CBSZBox_SelectedIndexChanged);
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(287, 131);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(56, 13);
            this.label105.TabIndex = 169;
            this.label105.Text = "Skin Tone";
            // 
            // CSKIBox
            // 
            this.CSKIBox.FormattingEnabled = true;
            this.CSKIBox.Location = new System.Drawing.Point(286, 148);
            this.CSKIBox.Name = "CSKIBox";
            this.CSKIBox.Size = new System.Drawing.Size(67, 21);
            this.CSKIBox.TabIndex = 168;
            this.CSKIBox.SelectedIndexChanged += new System.EventHandler(this.CSKIBox_SelectedIndexChanged);
            // 
            // CoachListBox
            // 
            this.CoachListBox.BackColor = System.Drawing.Color.White;
            this.CoachListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CoachListBox.FormattingEnabled = true;
            this.CoachListBox.Location = new System.Drawing.Point(12, 52);
            this.CoachListBox.Name = "CoachListBox";
            this.CoachListBox.Size = new System.Drawing.Size(175, 537);
            this.CoachListBox.TabIndex = 103;
            this.CoachListBox.SelectedIndexChanged += new System.EventHandler(this.CoachListBox_SelectedIndexChanged);
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(405, 67);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(81, 16);
            this.label129.TabIndex = 102;
            this.label129.Text = "Last Name";
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(286, 67);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(82, 16);
            this.label130.TabIndex = 101;
            this.label130.Text = "First Name";
            // 
            // tabPlayers
            // 
            this.tabPlayers.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPlayers.Controls.Add(this.label167);
            this.tabPlayers.Controls.Add(this.playerTeamBox);
            this.tabPlayers.Controls.Add(this.label151);
            this.tabPlayers.Controls.Add(this.PRST);
            this.tabPlayers.Controls.Add(this.PGIDbox);
            this.tabPlayers.Controls.Add(this.PKACtext);
            this.tabPlayers.Controls.Add(this.PKPRtext);
            this.tabPlayers.Controls.Add(this.PTAKtext);
            this.tabPlayers.Controls.Add(this.PPBKtext);
            this.tabPlayers.Controls.Add(this.PTHAtext);
            this.tabPlayers.Controls.Add(this.PCARtext);
            this.tabPlayers.Controls.Add(this.PCTHtext);
            this.tabPlayers.Controls.Add(this.PJMPtext);
            this.tabPlayers.Controls.Add(this.PAGItext);
            this.tabPlayers.Controls.Add(this.PAWRtext);
            this.tabPlayers.Controls.Add(this.PPOEtext);
            this.tabPlayers.Controls.Add(this.PRBKtext);
            this.tabPlayers.Controls.Add(this.PTHPtext);
            this.tabPlayers.Controls.Add(this.PBTKtext);
            this.tabPlayers.Controls.Add(this.PSTRtext);
            this.tabPlayers.Controls.Add(this.PACCtext);
            this.tabPlayers.Controls.Add(this.PSPDtext);
            this.tabPlayers.Controls.Add(this.PINJtext);
            this.tabPlayers.Controls.Add(this.PIMPtext);
            this.tabPlayers.Controls.Add(this.POVRbox);
            this.tabPlayers.Controls.Add(this.PLNAtextBox);
            this.tabPlayers.Controls.Add(this.PFNAtextBox);
            this.tabPlayers.Controls.Add(this.label126);
            this.tabPlayers.Controls.Add(this.RightShoe);
            this.tabPlayers.Controls.Add(this.label150);
            this.tabPlayers.Controls.Add(this.Helmet);
            this.tabPlayers.Controls.Add(this.label149);
            this.tabPlayers.Controls.Add(this.label148);
            this.tabPlayers.Controls.Add(this.label127);
            this.tabPlayers.Controls.Add(this.RightElbow);
            this.tabPlayers.Controls.Add(this.label128);
            this.tabPlayers.Controls.Add(this.RightWrist);
            this.tabPlayers.Controls.Add(this.label147);
            this.tabPlayers.Controls.Add(this.RightHand);
            this.tabPlayers.Controls.Add(this.label125);
            this.tabPlayers.Controls.Add(this.NeckPad);
            this.tabPlayers.Controls.Add(this.label123);
            this.tabPlayers.Controls.Add(this.NasalStrip);
            this.tabPlayers.Controls.Add(this.label124);
            this.tabPlayers.Controls.Add(this.Visor);
            this.tabPlayers.Controls.Add(this.label122);
            this.tabPlayers.Controls.Add(this.EyeBlack);
            this.tabPlayers.Controls.Add(this.SleeveColor);
            this.tabPlayers.Controls.Add(this.label121);
            this.tabPlayers.Controls.Add(this.Sleeves);
            this.tabPlayers.Controls.Add(this.LeftElbow);
            this.tabPlayers.Controls.Add(this.label119);
            this.tabPlayers.Controls.Add(this.Facemask);
            this.tabPlayers.Controls.Add(this.label118);
            this.tabPlayers.Controls.Add(this.LeftWrist);
            this.tabPlayers.Controls.Add(this.label117);
            this.tabPlayers.Controls.Add(this.LeftHand);
            this.tabPlayers.Controls.Add(this.label116);
            this.tabPlayers.Controls.Add(this.LeftShoe);
            this.tabPlayers.Controls.Add(this.label113);
            this.tabPlayers.Controls.Add(this.PJEN);
            this.tabPlayers.Controls.Add(this.PlayerSetDepthChartButton);
            this.tabPlayers.Controls.Add(this.PGIDLabel);
            this.tabPlayers.Controls.Add(this.ShowPOSGBox);
            this.tabPlayers.Controls.Add(this.ShowRatingCheckbox);
            this.tabPlayers.Controls.Add(this.ShowPosCheckBox);
            this.tabPlayers.Controls.Add(this.label93);
            this.tabPlayers.Controls.Add(this.PTYPBox);
            this.tabPlayers.Controls.Add(this.label92);
            this.tabPlayers.Controls.Add(this.PRSDBox);
            this.tabPlayers.Controls.Add(this.label91);
            this.tabPlayers.Controls.Add(this.PYERBox);
            this.tabPlayers.Controls.Add(this.label89);
            this.tabPlayers.Controls.Add(this.PWGTBox);
            this.tabPlayers.Controls.Add(this.label90);
            this.tabPlayers.Controls.Add(this.PHGTBox);
            this.tabPlayers.Controls.Add(this.label88);
            this.tabPlayers.Controls.Add(this.label87);
            this.tabPlayers.Controls.Add(this.PHEDBox);
            this.tabPlayers.Controls.Add(this.label86);
            this.tabPlayers.Controls.Add(this.PHCLBox);
            this.tabPlayers.Controls.Add(this.label85);
            this.tabPlayers.Controls.Add(this.PFMPBox);
            this.tabPlayers.Controls.Add(this.label84);
            this.tabPlayers.Controls.Add(this.PFGMBox);
            this.tabPlayers.Controls.Add(this.label83);
            this.tabPlayers.Controls.Add(this.PSKIBox);
            this.tabPlayers.Controls.Add(this.label79);
            this.tabPlayers.Controls.Add(this.PKACBox);
            this.tabPlayers.Controls.Add(this.label81);
            this.tabPlayers.Controls.Add(this.PKPRBox);
            this.tabPlayers.Controls.Add(this.label82);
            this.tabPlayers.Controls.Add(this.PTAKBox);
            this.tabPlayers.Controls.Add(this.label71);
            this.tabPlayers.Controls.Add(this.PPBKBox);
            this.tabPlayers.Controls.Add(this.label72);
            this.tabPlayers.Controls.Add(this.PTHABox);
            this.tabPlayers.Controls.Add(this.label73);
            this.tabPlayers.Controls.Add(this.PCARBox);
            this.tabPlayers.Controls.Add(this.label74);
            this.tabPlayers.Controls.Add(this.PCTHBox);
            this.tabPlayers.Controls.Add(this.label75);
            this.tabPlayers.Controls.Add(this.PJMPBox);
            this.tabPlayers.Controls.Add(this.label76);
            this.tabPlayers.Controls.Add(this.PAGIBox);
            this.tabPlayers.Controls.Add(this.label77);
            this.tabPlayers.Controls.Add(this.PAWRBox);
            this.tabPlayers.Controls.Add(this.label78);
            this.tabPlayers.Controls.Add(this.PPOEBox);
            this.tabPlayers.Controls.Add(this.label67);
            this.tabPlayers.Controls.Add(this.PRBKBox);
            this.tabPlayers.Controls.Add(this.label68);
            this.tabPlayers.Controls.Add(this.PTHPBox);
            this.tabPlayers.Controls.Add(this.label69);
            this.tabPlayers.Controls.Add(this.PBTKBox);
            this.tabPlayers.Controls.Add(this.label70);
            this.tabPlayers.Controls.Add(this.PSTRBox);
            this.tabPlayers.Controls.Add(this.label66);
            this.tabPlayers.Controls.Add(this.PACCBox);
            this.tabPlayers.Controls.Add(this.label65);
            this.tabPlayers.Controls.Add(this.PSPDBox);
            this.tabPlayers.Controls.Add(this.label64);
            this.tabPlayers.Controls.Add(this.PINJBox);
            this.tabPlayers.Controls.Add(this.label63);
            this.tabPlayers.Controls.Add(this.PIMPBox);
            this.tabPlayers.Controls.Add(this.label62);
            this.tabPlayers.Controls.Add(this.PPOSBox);
            this.tabPlayers.Controls.Add(this.label61);
            this.tabPlayers.Controls.Add(this.RosterSizeLabel);
            this.tabPlayers.Controls.Add(this.label3);
            this.tabPlayers.Controls.Add(this.TGIDplayerBox);
            this.tabPlayers.Controls.Add(this.PGIDlistBox);
            this.tabPlayers.Controls.Add(this.label2);
            this.tabPlayers.Controls.Add(this.label1);
            this.tabPlayers.Controls.Add(this.groupBox3);
            this.tabPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPlayers.Location = new System.Drawing.Point(4, 24);
            this.tabPlayers.Name = "tabPlayers";
            this.tabPlayers.Size = new System.Drawing.Size(1152, 615);
            this.tabPlayers.TabIndex = 2;
            this.tabPlayers.Text = "Players";
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Location = new System.Drawing.Point(439, 181);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(34, 13);
            this.label167.TabIndex = 143;
            this.label167.Text = "Team";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playerTeamBox
            // 
            this.playerTeamBox.BackColor = System.Drawing.SystemColors.Info;
            this.playerTeamBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTeamBox.Location = new System.Drawing.Point(479, 175);
            this.playerTeamBox.Name = "playerTeamBox";
            this.playerTeamBox.ReadOnly = true;
            this.playerTeamBox.Size = new System.Drawing.Size(102, 20);
            this.playerTeamBox.TabIndex = 142;
            this.playerTeamBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(418, 581);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(104, 16);
            this.label151.TabIndex = 140;
            this.label151.Text = "Pride Stickers";
            // 
            // PRST
            // 
            this.PRST.BackColor = System.Drawing.SystemColors.Info;
            this.PRST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRST.Location = new System.Drawing.Point(528, 578);
            this.PRST.Name = "PRST";
            this.PRST.ReadOnly = true;
            this.PRST.Size = new System.Drawing.Size(53, 22);
            this.PRST.TabIndex = 139;
            this.PRST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PGIDbox
            // 
            this.PGIDbox.BackColor = System.Drawing.SystemColors.Info;
            this.PGIDbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGIDbox.Location = new System.Drawing.Point(528, 543);
            this.PGIDbox.Name = "PGIDbox";
            this.PGIDbox.ReadOnly = true;
            this.PGIDbox.Size = new System.Drawing.Size(53, 22);
            this.PGIDbox.TabIndex = 97;
            this.PGIDbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PKACtext
            // 
            this.PKACtext.BackColor = System.Drawing.SystemColors.Info;
            this.PKACtext.Location = new System.Drawing.Point(480, 500);
            this.PKACtext.Name = "PKACtext";
            this.PKACtext.ReadOnly = true;
            this.PKACtext.Size = new System.Drawing.Size(39, 20);
            this.PKACtext.TabIndex = 71;
            this.PKACtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PKPRtext
            // 
            this.PKPRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PKPRtext.Location = new System.Drawing.Point(280, 501);
            this.PKPRtext.Name = "PKPRtext";
            this.PKPRtext.ReadOnly = true;
            this.PKPRtext.Size = new System.Drawing.Size(39, 20);
            this.PKPRtext.TabIndex = 65;
            this.PKPRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PTAKtext
            // 
            this.PTAKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTAKtext.Location = new System.Drawing.Point(479, 467);
            this.PTAKtext.Name = "PTAKtext";
            this.PTAKtext.ReadOnly = true;
            this.PTAKtext.Size = new System.Drawing.Size(39, 20);
            this.PTAKtext.TabIndex = 62;
            this.PTAKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PPBKtext
            // 
            this.PPBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PPBKtext.Location = new System.Drawing.Point(480, 430);
            this.PPBKtext.Name = "PPBKtext";
            this.PPBKtext.ReadOnly = true;
            this.PPBKtext.Size = new System.Drawing.Size(39, 20);
            this.PPBKtext.TabIndex = 59;
            this.PPBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PTHAtext
            // 
            this.PTHAtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTHAtext.Location = new System.Drawing.Point(480, 359);
            this.PTHAtext.Name = "PTHAtext";
            this.PTHAtext.ReadOnly = true;
            this.PTHAtext.Size = new System.Drawing.Size(39, 20);
            this.PTHAtext.TabIndex = 56;
            this.PTHAtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PCARtext
            // 
            this.PCARtext.BackColor = System.Drawing.SystemColors.Info;
            this.PCARtext.Location = new System.Drawing.Point(480, 394);
            this.PCARtext.Name = "PCARtext";
            this.PCARtext.ReadOnly = true;
            this.PCARtext.Size = new System.Drawing.Size(39, 20);
            this.PCARtext.TabIndex = 53;
            this.PCARtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PCTHtext
            // 
            this.PCTHtext.BackColor = System.Drawing.SystemColors.Info;
            this.PCTHtext.Location = new System.Drawing.Point(279, 465);
            this.PCTHtext.Name = "PCTHtext";
            this.PCTHtext.ReadOnly = true;
            this.PCTHtext.Size = new System.Drawing.Size(39, 20);
            this.PCTHtext.TabIndex = 50;
            this.PCTHtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PJMPtext
            // 
            this.PJMPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PJMPtext.Location = new System.Drawing.Point(479, 321);
            this.PJMPtext.Name = "PJMPtext";
            this.PJMPtext.ReadOnly = true;
            this.PJMPtext.Size = new System.Drawing.Size(39, 20);
            this.PJMPtext.TabIndex = 47;
            this.PJMPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PAGItext
            // 
            this.PAGItext.BackColor = System.Drawing.SystemColors.Info;
            this.PAGItext.Location = new System.Drawing.Point(479, 286);
            this.PAGItext.Name = "PAGItext";
            this.PAGItext.ReadOnly = true;
            this.PAGItext.Size = new System.Drawing.Size(39, 20);
            this.PAGItext.TabIndex = 44;
            this.PAGItext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PAWRtext
            // 
            this.PAWRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PAWRtext.Location = new System.Drawing.Point(479, 249);
            this.PAWRtext.Name = "PAWRtext";
            this.PAWRtext.ReadOnly = true;
            this.PAWRtext.Size = new System.Drawing.Size(39, 20);
            this.PAWRtext.TabIndex = 41;
            this.PAWRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PPOEtext
            // 
            this.PPOEtext.BackColor = System.Drawing.SystemColors.Info;
            this.PPOEtext.Location = new System.Drawing.Point(479, 213);
            this.PPOEtext.Name = "PPOEtext";
            this.PPOEtext.ReadOnly = true;
            this.PPOEtext.Size = new System.Drawing.Size(39, 20);
            this.PPOEtext.TabIndex = 38;
            this.PPOEtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PRBKtext
            // 
            this.PRBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PRBKtext.Location = new System.Drawing.Point(280, 431);
            this.PRBKtext.Name = "PRBKtext";
            this.PRBKtext.ReadOnly = true;
            this.PRBKtext.Size = new System.Drawing.Size(39, 20);
            this.PRBKtext.TabIndex = 35;
            this.PRBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PTHPtext
            // 
            this.PTHPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTHPtext.Location = new System.Drawing.Point(280, 360);
            this.PTHPtext.Name = "PTHPtext";
            this.PTHPtext.ReadOnly = true;
            this.PTHPtext.Size = new System.Drawing.Size(39, 20);
            this.PTHPtext.TabIndex = 32;
            this.PTHPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PBTKtext
            // 
            this.PBTKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PBTKtext.Location = new System.Drawing.Point(280, 395);
            this.PBTKtext.Name = "PBTKtext";
            this.PBTKtext.ReadOnly = true;
            this.PBTKtext.Size = new System.Drawing.Size(39, 20);
            this.PBTKtext.TabIndex = 29;
            this.PBTKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PSTRtext
            // 
            this.PSTRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PSTRtext.Location = new System.Drawing.Point(280, 323);
            this.PSTRtext.Name = "PSTRtext";
            this.PSTRtext.ReadOnly = true;
            this.PSTRtext.Size = new System.Drawing.Size(39, 20);
            this.PSTRtext.TabIndex = 26;
            this.PSTRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PACCtext
            // 
            this.PACCtext.BackColor = System.Drawing.SystemColors.Info;
            this.PACCtext.Location = new System.Drawing.Point(280, 286);
            this.PACCtext.Name = "PACCtext";
            this.PACCtext.ReadOnly = true;
            this.PACCtext.Size = new System.Drawing.Size(39, 20);
            this.PACCtext.TabIndex = 23;
            this.PACCtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PSPDtext
            // 
            this.PSPDtext.BackColor = System.Drawing.SystemColors.Info;
            this.PSPDtext.Location = new System.Drawing.Point(280, 251);
            this.PSPDtext.Name = "PSPDtext";
            this.PSPDtext.ReadOnly = true;
            this.PSPDtext.Size = new System.Drawing.Size(39, 20);
            this.PSPDtext.TabIndex = 20;
            this.PSPDtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PINJtext
            // 
            this.PINJtext.BackColor = System.Drawing.SystemColors.Info;
            this.PINJtext.Location = new System.Drawing.Point(280, 214);
            this.PINJtext.Name = "PINJtext";
            this.PINJtext.ReadOnly = true;
            this.PINJtext.Size = new System.Drawing.Size(39, 20);
            this.PINJtext.TabIndex = 17;
            this.PINJtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PIMPtext
            // 
            this.PIMPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PIMPtext.Location = new System.Drawing.Point(280, 178);
            this.PIMPtext.Name = "PIMPtext";
            this.PIMPtext.ReadOnly = true;
            this.PIMPtext.Size = new System.Drawing.Size(39, 20);
            this.PIMPtext.TabIndex = 14;
            this.PIMPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // POVRbox
            // 
            this.POVRbox.BackColor = System.Drawing.SystemColors.Info;
            this.POVRbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POVRbox.Location = new System.Drawing.Point(524, 27);
            this.POVRbox.Name = "POVRbox";
            this.POVRbox.ReadOnly = true;
            this.POVRbox.Size = new System.Drawing.Size(53, 22);
            this.POVRbox.TabIndex = 8;
            this.POVRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PLNAtextBox
            // 
            this.PLNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLNAtextBox.Location = new System.Drawing.Point(325, 27);
            this.PLNAtextBox.Name = "PLNAtextBox";
            this.PLNAtextBox.Size = new System.Drawing.Size(111, 22);
            this.PLNAtextBox.TabIndex = 1;
            this.PLNAtextBox.TextChanged += new System.EventHandler(this.PLNAtextBox_TextChanged);
            this.PLNAtextBox.Leave += new System.EventHandler(this.PLNA_Leave);
            // 
            // PFNAtextBox
            // 
            this.PFNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PFNAtextBox.Location = new System.Drawing.Point(203, 27);
            this.PFNAtextBox.Name = "PFNAtextBox";
            this.PFNAtextBox.Size = new System.Drawing.Size(116, 22);
            this.PFNAtextBox.TabIndex = 0;
            this.PFNAtextBox.TextChanged += new System.EventHandler(this.PFNAtextBox_TextChanged);
            this.PFNAtextBox.Leave += new System.EventHandler(this.PFNA_Leave);
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(983, 532);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(37, 13);
            this.label126.TabIndex = 138;
            this.label126.Text = "Shoes";
            // 
            // RightShoe
            // 
            this.RightShoe.FormattingEnabled = true;
            this.RightShoe.Items.AddRange(new object[] {
            "Normal",
            "White Tape",
            "Black Tape",
            "TC Tape"});
            this.RightShoe.Location = new System.Drawing.Point(983, 548);
            this.RightShoe.Name = "RightShoe";
            this.RightShoe.Size = new System.Drawing.Size(103, 21);
            this.RightShoe.TabIndex = 137;
            this.RightShoe.SelectedIndexChanged += new System.EventHandler(this.RightShoe_SelectedIndexChanged);
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(722, 45);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(40, 13);
            this.label150.TabIndex = 136;
            this.label150.Text = "Helmet";
            // 
            // Helmet
            // 
            this.Helmet.FormattingEnabled = true;
            this.Helmet.Items.AddRange(new object[] {
            "Normal",
            "Adams",
            "Schutt",
            "Revolution"});
            this.Helmet.Location = new System.Drawing.Point(725, 60);
            this.Helmet.Name = "Helmet";
            this.Helmet.Size = new System.Drawing.Size(103, 21);
            this.Helmet.TabIndex = 135;
            this.Helmet.SelectedIndexChanged += new System.EventHandler(this.Helmet_SelectedIndexChanged);
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(658, 231);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(85, 15);
            this.label149.TabIndex = 134;
            this.label149.Text = "RIGHT SIDE";
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(1019, 226);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(76, 15);
            this.label148.TabIndex = 133;
            this.label148.Text = "LEFT SIDE";
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(1019, 253);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(41, 13);
            this.label127.TabIndex = 129;
            this.label127.Text = "Elbows";
            // 
            // RightElbow
            // 
            this.RightElbow.FormattingEnabled = true;
            this.RightElbow.Items.AddRange(new object[] {
            "Normal",
            "Rubber Pad",
            "Black Pad",
            "White Pad",
            "Bk TC Pad",
            "Wt TC Pad",
            "Bk Med Band",
            "Wt Med Band",
            "TC Med Band",
            "Bk Thin Band",
            "Wt Thin Band",
            "TC Thin Band"});
            this.RightElbow.Location = new System.Drawing.Point(1022, 268);
            this.RightElbow.Name = "RightElbow";
            this.RightElbow.Size = new System.Drawing.Size(103, 21);
            this.RightElbow.TabIndex = 128;
            this.RightElbow.SelectedIndexChanged += new System.EventHandler(this.RightElbow_SelectedIndexChanged);
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(1022, 309);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(36, 13);
            this.label128.TabIndex = 127;
            this.label128.Text = "Wrists";
            // 
            // RightWrist
            // 
            this.RightWrist.FormattingEnabled = true;
            this.RightWrist.Items.AddRange(new object[] {
            "Normal",
            "Wt QB Wrist",
            "BK QB Wrist",
            "TC QB Wrist",
            "Bk Wrist",
            "Wt Wrist",
            "TC Wrist",
            "Armpad",
            "Wt Half Sleeve",
            "Bk Half Sleeve",
            "TC Half Sleeve",
            "Taped"});
            this.RightWrist.Location = new System.Drawing.Point(1022, 325);
            this.RightWrist.Name = "RightWrist";
            this.RightWrist.Size = new System.Drawing.Size(103, 21);
            this.RightWrist.TabIndex = 126;
            this.RightWrist.SelectedIndexChanged += new System.EventHandler(this.RightWrist_SelectedIndexChanged);
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(1022, 350);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(38, 13);
            this.label147.TabIndex = 125;
            this.label147.Text = "Hands";
            // 
            // RightHand
            // 
            this.RightHand.FormattingEnabled = true;
            this.RightHand.Items.AddRange(new object[] {
            "Bare",
            "Taped",
            "Gloves"});
            this.RightHand.Location = new System.Drawing.Point(1022, 366);
            this.RightHand.Name = "RightHand";
            this.RightHand.Size = new System.Drawing.Size(103, 21);
            this.RightHand.TabIndex = 124;
            this.RightHand.SelectedIndexChanged += new System.EventHandler(this.RightHand_SelectedIndexChanged);
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(989, 146);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(55, 13);
            this.label125.TabIndex = 123;
            this.label125.Text = "Neck Pad";
            // 
            // NeckPad
            // 
            this.NeckPad.FormattingEnabled = true;
            this.NeckPad.Items.AddRange(new object[] {
            "None",
            "Neck Roll",
            "Extended"});
            this.NeckPad.Location = new System.Drawing.Point(992, 161);
            this.NeckPad.Name = "NeckPad";
            this.NeckPad.Size = new System.Drawing.Size(103, 21);
            this.NeckPad.TabIndex = 122;
            this.NeckPad.SelectedIndexChanged += new System.EventHandler(this.NeckPad_SelectedIndexChanged);
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(924, 106);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(58, 13);
            this.label123.TabIndex = 121;
            this.label123.Text = "Nasal Strip";
            // 
            // NasalStrip
            // 
            this.NasalStrip.FormattingEnabled = true;
            this.NasalStrip.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.NasalStrip.Location = new System.Drawing.Point(927, 121);
            this.NasalStrip.Name = "NasalStrip";
            this.NasalStrip.Size = new System.Drawing.Size(103, 21);
            this.NasalStrip.TabIndex = 120;
            this.NasalStrip.SelectedIndexChanged += new System.EventHandler(this.NasalStrip_SelectedIndexChanged);
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(965, 44);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(30, 13);
            this.label124.TabIndex = 119;
            this.label124.Text = "Visor";
            // 
            // Visor
            // 
            this.Visor.FormattingEnabled = true;
            this.Visor.Items.AddRange(new object[] {
            "None",
            "Clear",
            "Dark",
            "Orange"});
            this.Visor.Location = new System.Drawing.Point(968, 59);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(103, 21);
            this.Visor.TabIndex = 118;
            this.Visor.SelectedIndexChanged += new System.EventHandler(this.Visor_SelectedIndexChanged);
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(709, 121);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(55, 13);
            this.label122.TabIndex = 117;
            this.label122.Text = "Eye Black";
            // 
            // EyeBlack
            // 
            this.EyeBlack.FormattingEnabled = true;
            this.EyeBlack.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.EyeBlack.Location = new System.Drawing.Point(712, 136);
            this.EyeBlack.Name = "EyeBlack";
            this.EyeBlack.Size = new System.Drawing.Size(103, 21);
            this.EyeBlack.TabIndex = 116;
            this.EyeBlack.SelectedIndexChanged += new System.EventHandler(this.EyeBlack_SelectedIndexChanged);
            // 
            // SleeveColor
            // 
            this.SleeveColor.FormattingEnabled = true;
            this.SleeveColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Team Color"});
            this.SleeveColor.Location = new System.Drawing.Point(647, 203);
            this.SleeveColor.Name = "SleeveColor";
            this.SleeveColor.Size = new System.Drawing.Size(103, 21);
            this.SleeveColor.TabIndex = 115;
            this.SleeveColor.SelectedIndexChanged += new System.EventHandler(this.SleeveColor_SelectedIndexChanged);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(644, 163);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(80, 13);
            this.label121.TabIndex = 114;
            this.label121.Text = "Sleeves / Color";
            // 
            // Sleeves
            // 
            this.Sleeves.FormattingEnabled = true;
            this.Sleeves.Items.AddRange(new object[] {
            "Cold Only",
            "Always",
            "None"});
            this.Sleeves.Location = new System.Drawing.Point(647, 178);
            this.Sleeves.Name = "Sleeves";
            this.Sleeves.Size = new System.Drawing.Size(103, 21);
            this.Sleeves.TabIndex = 113;
            this.Sleeves.SelectedIndexChanged += new System.EventHandler(this.Sleeves_SelectedIndexChanged);
            // 
            // LeftElbow
            // 
            this.LeftElbow.FormattingEnabled = true;
            this.LeftElbow.Items.AddRange(new object[] {
            "Normal",
            "Rubber Pad",
            "Black Pad",
            "White Pad",
            "Bk TC Pad",
            "Wt TC Pad",
            "Bk Med Band",
            "Wt Med Band",
            "TC Med Band",
            "Bk Thin Band",
            "Wt Thin Band",
            "TC Thin Band"});
            this.LeftElbow.Location = new System.Drawing.Point(621, 268);
            this.LeftElbow.Name = "LeftElbow";
            this.LeftElbow.Size = new System.Drawing.Size(103, 21);
            this.LeftElbow.TabIndex = 111;
            this.LeftElbow.SelectedIndexChanged += new System.EventHandler(this.LeftElbow_SelectedIndexChanged);
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(845, 44);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(60, 13);
            this.label119.TabIndex = 110;
            this.label119.Text = "Face Mask";
            // 
            // Facemask
            // 
            this.Facemask.FormattingEnabled = true;
            this.Facemask.Items.AddRange(new object[] {
            "2-Bar",
            "2-Bar",
            "3-Bar",
            "Half-Cage",
            "Full-Cage 1",
            "*",
            "*",
            "2-Bar RB",
            "3-Bar QB",
            "3-Bar RB 1",
            "Full Cage 2",
            "3-Bar RB 2"});
            this.Facemask.Location = new System.Drawing.Point(848, 59);
            this.Facemask.Name = "Facemask";
            this.Facemask.Size = new System.Drawing.Size(103, 21);
            this.Facemask.TabIndex = 109;
            this.Facemask.SelectedIndexChanged += new System.EventHandler(this.Facemask_SelectedIndexChanged);
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(617, 297);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(36, 13);
            this.label118.TabIndex = 108;
            this.label118.Text = "Wrists";
            // 
            // LeftWrist
            // 
            this.LeftWrist.FormattingEnabled = true;
            this.LeftWrist.Items.AddRange(new object[] {
            "Normal",
            "Wt QB Wrist",
            "BK QB Wrist",
            "TC QB Wrist",
            "Bk Wrist",
            "Wt Wrist",
            "TC Wrist",
            "Armpad",
            "Wt Half Sleeve",
            "Bk Half Sleeve",
            "TC Half Sleeve",
            "Taped"});
            this.LeftWrist.Location = new System.Drawing.Point(621, 313);
            this.LeftWrist.Name = "LeftWrist";
            this.LeftWrist.Size = new System.Drawing.Size(103, 21);
            this.LeftWrist.TabIndex = 107;
            this.LeftWrist.SelectedIndexChanged += new System.EventHandler(this.LeftWrist_SelectedIndexChanged);
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(617, 338);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(38, 13);
            this.label117.TabIndex = 106;
            this.label117.Text = "Hands";
            // 
            // LeftHand
            // 
            this.LeftHand.FormattingEnabled = true;
            this.LeftHand.Items.AddRange(new object[] {
            "Bare",
            "Taped",
            "Gloves"});
            this.LeftHand.Location = new System.Drawing.Point(621, 354);
            this.LeftHand.Name = "LeftHand";
            this.LeftHand.Size = new System.Drawing.Size(103, 21);
            this.LeftHand.TabIndex = 105;
            this.LeftHand.SelectedIndexChanged += new System.EventHandler(this.LeftHand_SelectedIndexChanged);
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(675, 532);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(37, 13);
            this.label116.TabIndex = 104;
            this.label116.Text = "Shoes";
            // 
            // LeftShoe
            // 
            this.LeftShoe.FormattingEnabled = true;
            this.LeftShoe.Items.AddRange(new object[] {
            "Normal",
            "White Tape",
            "Black Tape",
            "TC Tape"});
            this.LeftShoe.Location = new System.Drawing.Point(675, 548);
            this.LeftShoe.Name = "LeftShoe";
            this.LeftShoe.Size = new System.Drawing.Size(103, 21);
            this.LeftShoe.TabIndex = 103;
            this.LeftShoe.SelectedIndexChanged += new System.EventHandler(this.LeftShoe_SelectedIndexChanged);
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(389, 61);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(37, 13);
            this.label113.TabIndex = 101;
            this.label113.Text = "Jersey";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PJEN
            // 
            this.PJEN.Location = new System.Drawing.Point(389, 76);
            this.PJEN.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.PJEN.Name = "PJEN";
            this.PJEN.Size = new System.Drawing.Size(53, 20);
            this.PJEN.TabIndex = 100;
            this.PJEN.ValueChanged += new System.EventHandler(this.PJEN_ValueChanged);
            // 
            // PlayerSetDepthChartButton
            // 
            this.PlayerSetDepthChartButton.Location = new System.Drawing.Point(206, 572);
            this.PlayerSetDepthChartButton.Name = "PlayerSetDepthChartButton";
            this.PlayerSetDepthChartButton.Size = new System.Drawing.Size(150, 36);
            this.PlayerSetDepthChartButton.TabIndex = 99;
            this.PlayerSetDepthChartButton.Text = "Auto-Set Team Depth Chart";
            this.PlayerSetDepthChartButton.UseVisualStyleBackColor = true;
            this.PlayerSetDepthChartButton.Click += new System.EventHandler(this.PlayerSetDepthChartButton_Click);
            // 
            // PGIDLabel
            // 
            this.PGIDLabel.AutoSize = true;
            this.PGIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGIDLabel.Location = new System.Drawing.Point(479, 546);
            this.PGIDLabel.Name = "PGIDLabel";
            this.PGIDLabel.Size = new System.Drawing.Size(43, 16);
            this.PGIDLabel.TabIndex = 98;
            this.PGIDLabel.Text = "PGID";
            // 
            // ShowPOSGBox
            // 
            this.ShowPOSGBox.AutoSize = true;
            this.ShowPOSGBox.Location = new System.Drawing.Point(12, 589);
            this.ShowPOSGBox.Name = "ShowPOSGBox";
            this.ShowPOSGBox.Size = new System.Drawing.Size(125, 17);
            this.ShowPOSGBox.TabIndex = 96;
            this.ShowPOSGBox.Text = "Show Position Group";
            this.ShowPOSGBox.UseVisualStyleBackColor = true;
            this.ShowPOSGBox.CheckedChanged += new System.EventHandler(this.ShowPOSGBox_CheckedChanged);
            // 
            // ShowRatingCheckbox
            // 
            this.ShowRatingCheckbox.AutoSize = true;
            this.ShowRatingCheckbox.Location = new System.Drawing.Point(110, 565);
            this.ShowRatingCheckbox.Name = "ShowRatingCheckbox";
            this.ShowRatingCheckbox.Size = new System.Drawing.Size(87, 17);
            this.ShowRatingCheckbox.TabIndex = 95;
            this.ShowRatingCheckbox.Text = "Show Rating";
            this.ShowRatingCheckbox.UseVisualStyleBackColor = true;
            this.ShowRatingCheckbox.CheckedChanged += new System.EventHandler(this.ShowRatingCheckbox_CheckedChanged);
            // 
            // ShowPosCheckBox
            // 
            this.ShowPosCheckBox.AutoSize = true;
            this.ShowPosCheckBox.Location = new System.Drawing.Point(12, 565);
            this.ShowPosCheckBox.Name = "ShowPosCheckBox";
            this.ShowPosCheckBox.Size = new System.Drawing.Size(93, 17);
            this.ShowPosCheckBox.TabIndex = 94;
            this.ShowPosCheckBox.Text = "Show Position";
            this.ShowPosCheckBox.UseVisualStyleBackColor = true;
            this.ShowPosCheckBox.CheckedChanged += new System.EventHandler(this.ShowPosCheckBox_CheckedChanged);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(205, 530);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(87, 13);
            this.label93.TabIndex = 93;
            this.label93.Text = "Off-Season Type";
            // 
            // PTYPBox
            // 
            this.PTYPBox.DropDownWidth = 150;
            this.PTYPBox.FormattingEnabled = true;
            this.PTYPBox.Location = new System.Drawing.Point(206, 545);
            this.PTYPBox.Name = "PTYPBox";
            this.PTYPBox.Size = new System.Drawing.Size(150, 21);
            this.PTYPBox.TabIndex = 92;
            this.PTYPBox.SelectedIndexChanged += new System.EventHandler(this.PTYPBox_SelectedIndexChanged);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(293, 60);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(46, 13);
            this.label92.TabIndex = 91;
            this.label92.Text = "Redshirt";
            // 
            // PRSDBox
            // 
            this.PRSDBox.FormattingEnabled = true;
            this.PRSDBox.Location = new System.Drawing.Point(296, 76);
            this.PRSDBox.Name = "PRSDBox";
            this.PRSDBox.Size = new System.Drawing.Size(79, 21);
            this.PRSDBox.TabIndex = 90;
            this.PRSDBox.SelectedIndexChanged += new System.EventHandler(this.PRSDBox_SelectedIndexChanged);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(210, 61);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(29, 13);
            this.label91.TabIndex = 89;
            this.label91.Text = "Year";
            // 
            // PYERBox
            // 
            this.PYERBox.FormattingEnabled = true;
            this.PYERBox.Location = new System.Drawing.Point(211, 76);
            this.PYERBox.Name = "PYERBox";
            this.PYERBox.Size = new System.Drawing.Size(79, 21);
            this.PYERBox.TabIndex = 88;
            this.PYERBox.SelectedIndexChanged += new System.EventHandler(this.PYERBox_SelectedIndexChanged);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(519, 61);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(63, 13);
            this.label89.TabIndex = 87;
            this.label89.Text = "Weight (lbs)";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PWGTBox
            // 
            this.PWGTBox.Location = new System.Drawing.Point(518, 76);
            this.PWGTBox.Maximum = new decimal(new int[] {
            415,
            0,
            0,
            0});
            this.PWGTBox.Minimum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.PWGTBox.Name = "PWGTBox";
            this.PWGTBox.Size = new System.Drawing.Size(57, 20);
            this.PWGTBox.TabIndex = 86;
            this.PWGTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PWGTBox.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.PWGTBox.ValueChanged += new System.EventHandler(this.PWGTBox_ValueChanged);
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(452, 61);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(55, 13);
            this.label90.TabIndex = 84;
            this.label90.Text = "Height (in)";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PHGTBox
            // 
            this.PHGTBox.Location = new System.Drawing.Point(455, 76);
            this.PHGTBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.PHGTBox.Name = "PHGTBox";
            this.PHGTBox.Size = new System.Drawing.Size(57, 20);
            this.PHGTBox.TabIndex = 83;
            this.PHGTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PHGTBox.ValueChanged += new System.EventHandler(this.PHGTBox_ValueChanged);
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(208, 149);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(121, 16);
            this.label88.TabIndex = 82;
            this.label88.Text = "Player Attributes";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(489, 102);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(52, 13);
            this.label87.TabIndex = 81;
            this.label87.Text = "Hair Style";
            // 
            // PHEDBox
            // 
            this.PHEDBox.FormattingEnabled = true;
            this.PHEDBox.Location = new System.Drawing.Point(492, 118);
            this.PHEDBox.Name = "PHEDBox";
            this.PHEDBox.Size = new System.Drawing.Size(90, 21);
            this.PHEDBox.TabIndex = 80;
            this.PHEDBox.SelectedIndexChanged += new System.EventHandler(this.PHEDBox_SelectedIndexChanged);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(389, 102);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(53, 13);
            this.label86.TabIndex = 79;
            this.label86.Text = "Hair Color";
            // 
            // PHCLBox
            // 
            this.PHCLBox.FormattingEnabled = true;
            this.PHCLBox.Location = new System.Drawing.Point(392, 118);
            this.PHCLBox.Name = "PHCLBox";
            this.PHCLBox.Size = new System.Drawing.Size(94, 21);
            this.PHCLBox.TabIndex = 78;
            this.PHCLBox.SelectedIndexChanged += new System.EventHandler(this.PHCLBox_SelectedIndexChanged);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(332, 101);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(31, 13);
            this.label85.TabIndex = 77;
            this.label85.Text = "Face";
            // 
            // PFMPBox
            // 
            this.PFMPBox.FormattingEnabled = true;
            this.PFMPBox.Location = new System.Drawing.Point(335, 118);
            this.PFMPBox.Name = "PFMPBox";
            this.PFMPBox.Size = new System.Drawing.Size(51, 21);
            this.PFMPBox.TabIndex = 76;
            this.PFMPBox.SelectedIndexChanged += new System.EventHandler(this.PFMPBox_SelectedIndexChanged);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(281, 101);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(38, 13);
            this.label84.TabIndex = 75;
            this.label84.Text = "Shape";
            // 
            // PFGMBox
            // 
            this.PFGMBox.FormattingEnabled = true;
            this.PFGMBox.Location = new System.Drawing.Point(284, 118);
            this.PFGMBox.Name = "PFGMBox";
            this.PFGMBox.Size = new System.Drawing.Size(45, 21);
            this.PFGMBox.TabIndex = 74;
            this.PFGMBox.SelectedIndexChanged += new System.EventHandler(this.PFGMBox_SelectedIndexChanged);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(212, 101);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(56, 13);
            this.label83.TabIndex = 73;
            this.label83.Text = "Skin Tone";
            // 
            // PSKIBox
            // 
            this.PSKIBox.FormattingEnabled = true;
            this.PSKIBox.Location = new System.Drawing.Point(211, 118);
            this.PSKIBox.Name = "PSKIBox";
            this.PSKIBox.Size = new System.Drawing.Size(67, 21);
            this.PSKIBox.TabIndex = 72;
            this.PSKIBox.SelectedIndexChanged += new System.EventHandler(this.PSKIBox_SelectedIndexChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(400, 504);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(76, 13);
            this.label79.TabIndex = 70;
            this.label79.Text = "Kick Accuracy";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKACBox
            // 
            this.PKACBox.Location = new System.Drawing.Point(525, 500);
            this.PKACBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PKACBox.Name = "PKACBox";
            this.PKACBox.Size = new System.Drawing.Size(57, 20);
            this.PKACBox.TabIndex = 69;
            this.PKACBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PKACBox.ValueChanged += new System.EventHandler(this.PKACBox_ValueChanged);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(217, 504);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(61, 13);
            this.label81.TabIndex = 64;
            this.label81.Text = "Kick Power";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKPRBox
            // 
            this.PKPRBox.Location = new System.Drawing.Point(325, 501);
            this.PKPRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PKPRBox.Name = "PKPRBox";
            this.PKPRBox.Size = new System.Drawing.Size(57, 20);
            this.PKPRBox.TabIndex = 63;
            this.PKPRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PKPRBox.ValueChanged += new System.EventHandler(this.PKPRBox_ValueChanged);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(429, 467);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(48, 13);
            this.label82.TabIndex = 61;
            this.label82.Text = "Tackling";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTAKBox
            // 
            this.PTAKBox.Location = new System.Drawing.Point(524, 467);
            this.PTAKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PTAKBox.Name = "PTAKBox";
            this.PTAKBox.Size = new System.Drawing.Size(57, 20);
            this.PTAKBox.TabIndex = 60;
            this.PTAKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PTAKBox.ValueChanged += new System.EventHandler(this.PTAKBox_ValueChanged);
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(405, 434);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(74, 13);
            this.label71.TabIndex = 58;
            this.label71.Text = "Pass Blocking";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PPBKBox
            // 
            this.PPBKBox.Location = new System.Drawing.Point(525, 430);
            this.PPBKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PPBKBox.Name = "PPBKBox";
            this.PPBKBox.Size = new System.Drawing.Size(57, 20);
            this.PPBKBox.TabIndex = 57;
            this.PPBKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PPBKBox.ValueChanged += new System.EventHandler(this.PPBKBox_ValueChanged);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(395, 364);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(85, 13);
            this.label72.TabIndex = 55;
            this.label72.Text = "Throw Accuracy";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHABox
            // 
            this.PTHABox.Location = new System.Drawing.Point(525, 359);
            this.PTHABox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PTHABox.Name = "PTHABox";
            this.PTHABox.Size = new System.Drawing.Size(57, 20);
            this.PTHABox.TabIndex = 54;
            this.PTHABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PTHABox.ValueChanged += new System.EventHandler(this.PTHABox_ValueChanged);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(410, 399);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 13);
            this.label73.TabIndex = 52;
            this.label73.Text = "Ball Carrying";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PCARBox
            // 
            this.PCARBox.Location = new System.Drawing.Point(525, 394);
            this.PCARBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PCARBox.Name = "PCARBox";
            this.PCARBox.Size = new System.Drawing.Size(57, 20);
            this.PCARBox.TabIndex = 51;
            this.PCARBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PCARBox.ValueChanged += new System.EventHandler(this.PCARBox_ValueChanged);
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(225, 467);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(49, 13);
            this.label74.TabIndex = 49;
            this.label74.Text = "Catching";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PCTHBox
            // 
            this.PCTHBox.Location = new System.Drawing.Point(324, 465);
            this.PCTHBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PCTHBox.Name = "PCTHBox";
            this.PCTHBox.Size = new System.Drawing.Size(57, 20);
            this.PCTHBox.TabIndex = 48;
            this.PCTHBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PCTHBox.ValueChanged += new System.EventHandler(this.PCTHBox_ValueChanged);
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(428, 326);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(46, 13);
            this.label75.TabIndex = 46;
            this.label75.Text = "Jumping";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PJMPBox
            // 
            this.PJMPBox.Location = new System.Drawing.Point(524, 321);
            this.PJMPBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PJMPBox.Name = "PJMPBox";
            this.PJMPBox.Size = new System.Drawing.Size(57, 20);
            this.PJMPBox.TabIndex = 45;
            this.PJMPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PJMPBox.ValueChanged += new System.EventHandler(this.PJMPBox_ValueChanged);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(440, 291);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(34, 13);
            this.label76.TabIndex = 43;
            this.label76.Text = "Agility";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PAGIBox
            // 
            this.PAGIBox.Location = new System.Drawing.Point(524, 286);
            this.PAGIBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PAGIBox.Name = "PAGIBox";
            this.PAGIBox.Size = new System.Drawing.Size(57, 20);
            this.PAGIBox.TabIndex = 42;
            this.PAGIBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PAGIBox.ValueChanged += new System.EventHandler(this.PAGIBox_ValueChanged);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(415, 253);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(59, 13);
            this.label77.TabIndex = 40;
            this.label77.Text = "Awareness";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PAWRBox
            // 
            this.PAWRBox.Location = new System.Drawing.Point(524, 249);
            this.PAWRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PAWRBox.Name = "PAWRBox";
            this.PAWRBox.Size = new System.Drawing.Size(57, 20);
            this.PAWRBox.TabIndex = 39;
            this.PAWRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PAWRBox.ValueChanged += new System.EventHandler(this.PAWRBox_ValueChanged);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(427, 218);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(48, 13);
            this.label78.TabIndex = 37;
            this.label78.Text = "Potential";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PPOEBox
            // 
            this.PPOEBox.Location = new System.Drawing.Point(524, 213);
            this.PPOEBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PPOEBox.Name = "PPOEBox";
            this.PPOEBox.Size = new System.Drawing.Size(57, 20);
            this.PPOEBox.TabIndex = 36;
            this.PPOEBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PPOEBox.ValueChanged += new System.EventHandler(this.PPOEBox_ValueChanged);
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(208, 433);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(71, 13);
            this.label67.TabIndex = 34;
            this.label67.Text = "Run Blocking";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PRBKBox
            // 
            this.PRBKBox.Location = new System.Drawing.Point(325, 431);
            this.PRBKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PRBKBox.Name = "PRBKBox";
            this.PRBKBox.Size = new System.Drawing.Size(57, 20);
            this.PRBKBox.TabIndex = 33;
            this.PRBKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PRBKBox.ValueChanged += new System.EventHandler(this.PRBKBox_ValueChanged);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(208, 362);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(70, 13);
            this.label68.TabIndex = 31;
            this.label68.Text = "Throw Power";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHPBox
            // 
            this.PTHPBox.Location = new System.Drawing.Point(325, 360);
            this.PTHPBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PTHPBox.Name = "PTHPBox";
            this.PTHPBox.Size = new System.Drawing.Size(57, 20);
            this.PTHPBox.TabIndex = 30;
            this.PTHPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PTHPBox.ValueChanged += new System.EventHandler(this.PTHPBox_ValueChanged);
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(208, 397);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(71, 13);
            this.label69.TabIndex = 28;
            this.label69.Text = "Break Tackle";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PBTKBox
            // 
            this.PBTKBox.Location = new System.Drawing.Point(325, 395);
            this.PBTKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PBTKBox.Name = "PBTKBox";
            this.PBTKBox.Size = new System.Drawing.Size(57, 20);
            this.PBTKBox.TabIndex = 27;
            this.PBTKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PBTKBox.ValueChanged += new System.EventHandler(this.PBTKBox_ValueChanged);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(231, 325);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(47, 13);
            this.label70.TabIndex = 25;
            this.label70.Text = "Strength";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PSTRBox
            // 
            this.PSTRBox.Location = new System.Drawing.Point(325, 323);
            this.PSTRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PSTRBox.Name = "PSTRBox";
            this.PSTRBox.Size = new System.Drawing.Size(57, 20);
            this.PSTRBox.TabIndex = 24;
            this.PSTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PSTRBox.ValueChanged += new System.EventHandler(this.PSTRBox_ValueChanged);
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(212, 288);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(66, 13);
            this.label66.TabIndex = 22;
            this.label66.Text = "Acceleration";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PACCBox
            // 
            this.PACCBox.Location = new System.Drawing.Point(325, 286);
            this.PACCBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PACCBox.Name = "PACCBox";
            this.PACCBox.Size = new System.Drawing.Size(57, 20);
            this.PACCBox.TabIndex = 21;
            this.PACCBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PACCBox.ValueChanged += new System.EventHandler(this.PACCBox_ValueChanged);
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(240, 254);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(38, 13);
            this.label65.TabIndex = 19;
            this.label65.Text = "Speed";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PSPDBox
            // 
            this.PSPDBox.Location = new System.Drawing.Point(325, 251);
            this.PSPDBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PSPDBox.Name = "PSPDBox";
            this.PSPDBox.Size = new System.Drawing.Size(57, 20);
            this.PSPDBox.TabIndex = 18;
            this.PSPDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PSPDBox.ValueChanged += new System.EventHandler(this.PSPDBox_ValueChanged);
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(215, 216);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(63, 13);
            this.label64.TabIndex = 16;
            this.label64.Text = "Injury Prone";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PINJBox
            // 
            this.PINJBox.Location = new System.Drawing.Point(325, 214);
            this.PINJBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PINJBox.Name = "PINJBox";
            this.PINJBox.Size = new System.Drawing.Size(57, 20);
            this.PINJBox.TabIndex = 15;
            this.PINJBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PINJBox.ValueChanged += new System.EventHandler(this.PINJBox_ValueChanged);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(218, 180);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(60, 13);
            this.label63.TabIndex = 13;
            this.label63.Text = "Importance";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PIMPBox
            // 
            this.PIMPBox.Location = new System.Drawing.Point(325, 178);
            this.PIMPBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.PIMPBox.Name = "PIMPBox";
            this.PIMPBox.Size = new System.Drawing.Size(57, 20);
            this.PIMPBox.TabIndex = 12;
            this.PIMPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PIMPBox.ValueChanged += new System.EventHandler(this.PIMPBox_ValueChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(442, 7);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(63, 16);
            this.label62.TabIndex = 11;
            this.label62.Text = "Position";
            // 
            // PPOSBox
            // 
            this.PPOSBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPOSBox.FormattingEnabled = true;
            this.PPOSBox.Location = new System.Drawing.Point(445, 25);
            this.PPOSBox.Name = "PPOSBox";
            this.PPOSBox.Size = new System.Drawing.Size(71, 24);
            this.PPOSBox.TabIndex = 10;
            this.PPOSBox.SelectedIndexChanged += new System.EventHandler(this.PPOSBox_SelectedIndexChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(521, 7);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(57, 16);
            this.label61.TabIndex = 9;
            this.label61.Text = "Overall";
            // 
            // RosterSizeLabel
            // 
            this.RosterSizeLabel.AutoSize = true;
            this.RosterSizeLabel.Location = new System.Drawing.Point(84, 5);
            this.RosterSizeLabel.Name = "RosterSizeLabel";
            this.RosterSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.RosterSizeLabel.TabIndex = 7;
            this.RosterSizeLabel.Text = "Roster Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Team";
            // 
            // TGIDplayerBox
            // 
            this.TGIDplayerBox.FormattingEnabled = true;
            this.TGIDplayerBox.Location = new System.Drawing.Point(9, 21);
            this.TGIDplayerBox.Name = "TGIDplayerBox";
            this.TGIDplayerBox.Size = new System.Drawing.Size(175, 21);
            this.TGIDplayerBox.TabIndex = 5;
            this.TGIDplayerBox.SelectedIndexChanged += new System.EventHandler(this.TGIDplayerBox_SelectedIndexChanged);
            // 
            // PGIDlistBox
            // 
            this.PGIDlistBox.BackColor = System.Drawing.Color.White;
            this.PGIDlistBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PGIDlistBox.FormattingEnabled = true;
            this.PGIDlistBox.Location = new System.Drawing.Point(9, 48);
            this.PGIDlistBox.Name = "PGIDlistBox";
            this.PGIDlistBox.Size = new System.Drawing.Size(175, 511);
            this.PGIDlistBox.TabIndex = 4;
            this.PGIDlistBox.SelectedIndexChanged += new System.EventHandler(this.PGIDlistBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(322, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(203, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label120);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Location = new System.Drawing.Point(608, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 605);
            this.groupBox3.TabIndex = 141;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gear Editor";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(10, 251);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(41, 13);
            this.label120.TabIndex = 112;
            this.label120.Text = "Elbows";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(117, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(343, 516);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabTeams.Controls.Add(this.TeamSetDepthChart);
            this.tabTeams.Controls.Add(this.GenerateNewRosterButton);
            this.tabTeams.Controls.Add(this.DeathPenaltyButton);
            this.tabTeams.Controls.Add(this.TeamRosterSizeLabel);
            this.tabTeams.Controls.Add(this.CheerleaderBox);
            this.tabTeams.Controls.Add(this.CrowdBox);
            this.tabTeams.Controls.Add(this.label5);
            this.tabTeams.Controls.Add(this.label8);
            this.tabTeams.Controls.Add(this.ImpactTSI2Select);
            this.tabTeams.Controls.Add(this.ImpactTSI1Select);
            this.tabTeams.Controls.Add(this.ImpactTPIDSelect);
            this.tabTeams.Controls.Add(this.ImpactTPIOSelect);
            this.tabTeams.Controls.Add(this.ResetImpactPlayersButton);
            this.tabTeams.Controls.Add(this.CaptainDefSelectBox);
            this.tabTeams.Controls.Add(this.CaptainOffSelectBox);
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
            this.tabTeams.Controls.Add(this.stadiumNameBox);
            this.tabTeams.Controls.Add(this.TeamCDPCBox);
            this.tabTeams.Controls.Add(this.HCLastNameBox);
            this.tabTeams.Controls.Add(this.HCFirstNameBox);
            this.tabTeams.Controls.Add(this.CoachPollBox);
            this.tabTeams.Controls.Add(this.SeasonRecordBox);
            this.tabTeams.Controls.Add(this.APPollBox);
            this.tabTeams.Controls.Add(this.ConfRecordBox);
            this.tabTeams.Controls.Add(this.LeagueBox);
            this.tabTeams.Controls.Add(this.TSNAtextBox);
            this.tabTeams.Controls.Add(this.TeamDivisionBox);
            this.tabTeams.Controls.Add(this.TeamConferenceBox);
            this.tabTeams.Controls.Add(this.TeamOVRtextbox);
            this.tabTeams.Controls.Add(this.TGIDtextBox);
            this.tabTeams.Controls.Add(this.TMNAtextBox);
            this.tabTeams.Controls.Add(this.TDNAtextBox);
            this.tabTeams.Controls.Add(this.label55);
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
            this.tabTeams.Controls.Add(this.label38);
            this.tabTeams.Controls.Add(this.TeamColor2Button);
            this.tabTeams.Controls.Add(this.TeamColor1Button);
            this.tabTeams.Controls.Add(this.label37);
            this.tabTeams.Controls.Add(this.label36);
            this.tabTeams.Controls.Add(this.label34);
            this.tabTeams.Controls.Add(this.label35);
            this.tabTeams.Controls.Add(this.label33);
            this.tabTeams.Controls.Add(this.label32);
            this.tabTeams.Controls.Add(this.label31);
            this.tabTeams.Controls.Add(this.label30);
            this.tabTeams.Controls.Add(this.label28);
            this.tabTeams.Controls.Add(this.label29);
            this.tabTeams.Controls.Add(this.label27);
            this.tabTeams.Controls.Add(this.label26);
            this.tabTeams.Controls.Add(this.label25);
            this.tabTeams.Controls.Add(this.label24);
            this.tabTeams.Controls.Add(this.label22);
            this.tabTeams.Controls.Add(this.label23);
            this.tabTeams.Controls.Add(this.label21);
            this.tabTeams.Controls.Add(this.label20);
            this.tabTeams.Controls.Add(this.label19);
            this.tabTeams.Controls.Add(this.label18);
            this.tabTeams.Controls.Add(this.label17);
            this.tabTeams.Controls.Add(this.label16);
            this.tabTeams.Controls.Add(this.label15);
            this.tabTeams.Controls.Add(this.label11);
            this.tabTeams.Controls.Add(this.label10);
            this.tabTeams.Controls.Add(this.label9);
            this.tabTeams.Controls.Add(this.label7);
            this.tabTeams.Controls.Add(this.CGIDcomboBox);
            this.tabTeams.Controls.Add(this.label6);
            this.tabTeams.Controls.Add(this.LGIDcomboBox);
            this.tabTeams.Controls.Add(this.TGIDlistBox);
            this.tabTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTeams.Location = new System.Drawing.Point(4, 24);
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.Size = new System.Drawing.Size(1152, 615);
            this.tabTeams.TabIndex = 1;
            this.tabTeams.Text = "Teams";
            this.tabTeams.Click += new System.EventHandler(this.tabTeams_Click);
            // 
            // TeamSetDepthChart
            // 
            this.TeamSetDepthChart.Location = new System.Drawing.Point(17, 558);
            this.TeamSetDepthChart.Name = "TeamSetDepthChart";
            this.TeamSetDepthChart.Size = new System.Drawing.Size(154, 43);
            this.TeamSetDepthChart.TabIndex = 141;
            this.TeamSetDepthChart.Text = "Auto-Set Depth Chart";
            this.TeamSetDepthChart.UseVisualStyleBackColor = true;
            this.TeamSetDepthChart.Click += new System.EventHandler(this.TeamSetDepthChart_Click);
            // 
            // GenerateNewRosterButton
            // 
            this.GenerateNewRosterButton.BackColor = System.Drawing.Color.LightCoral;
            this.GenerateNewRosterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateNewRosterButton.Location = new System.Drawing.Point(950, 547);
            this.GenerateNewRosterButton.Name = "GenerateNewRosterButton";
            this.GenerateNewRosterButton.Size = new System.Drawing.Size(120, 43);
            this.GenerateNewRosterButton.TabIndex = 140;
            this.GenerateNewRosterButton.Text = "GENERATE NEW ROSTER";
            this.GenerateNewRosterButton.UseVisualStyleBackColor = false;
            this.GenerateNewRosterButton.Click += new System.EventHandler(this.TeamEditorGenRoster_Click);
            // 
            // DeathPenaltyButton
            // 
            this.DeathPenaltyButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.DeathPenaltyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeathPenaltyButton.Location = new System.Drawing.Point(444, 193);
            this.DeathPenaltyButton.Name = "DeathPenaltyButton";
            this.DeathPenaltyButton.Size = new System.Drawing.Size(73, 43);
            this.DeathPenaltyButton.TabIndex = 139;
            this.DeathPenaltyButton.Text = "Death Penalty";
            this.DeathPenaltyButton.UseVisualStyleBackColor = false;
            this.DeathPenaltyButton.Click += new System.EventHandler(this.DeathPenaltyButton_Click);
            // 
            // TeamRosterSizeLabel
            // 
            this.TeamRosterSizeLabel.AutoSize = true;
            this.TeamRosterSizeLabel.Location = new System.Drawing.Point(554, 95);
            this.TeamRosterSizeLabel.Name = "TeamRosterSizeLabel";
            this.TeamRosterSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.TeamRosterSizeLabel.TabIndex = 138;
            this.TeamRosterSizeLabel.Text = "Roster Size:";
            // 
            // CheerleaderBox
            // 
            this.CheerleaderBox.FormattingEnabled = true;
            this.CheerleaderBox.Location = new System.Drawing.Point(379, 456);
            this.CheerleaderBox.MaxLength = 2;
            this.CheerleaderBox.Name = "CheerleaderBox";
            this.CheerleaderBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheerleaderBox.Size = new System.Drawing.Size(138, 21);
            this.CheerleaderBox.TabIndex = 137;
            this.CheerleaderBox.Tag = "x";
            this.CheerleaderBox.SelectedIndexChanged += new System.EventHandler(this.CheerleaderBox_SelectedIndexChanged);
            // 
            // CrowdBox
            // 
            this.CrowdBox.FormattingEnabled = true;
            this.CrowdBox.Location = new System.Drawing.Point(238, 456);
            this.CrowdBox.MaxLength = 2;
            this.CrowdBox.Name = "CrowdBox";
            this.CrowdBox.Size = new System.Drawing.Size(138, 21);
            this.CrowdBox.TabIndex = 136;
            this.CrowdBox.Tag = "x";
            this.CrowdBox.SelectedIndexChanged += new System.EventHandler(this.CrowdBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Crowd Color Palette";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(389, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Cheerleader Color Palette";
            // 
            // ImpactTSI2Select
            // 
            this.ImpactTSI2Select.FormattingEnabled = true;
            this.ImpactTSI2Select.Location = new System.Drawing.Point(902, 141);
            this.ImpactTSI2Select.MaxDropDownItems = 20;
            this.ImpactTSI2Select.MaxLength = 2;
            this.ImpactTSI2Select.Name = "ImpactTSI2Select";
            this.ImpactTSI2Select.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImpactTSI2Select.Size = new System.Drawing.Size(168, 21);
            this.ImpactTSI2Select.TabIndex = 133;
            this.ImpactTSI2Select.Tag = "x";
            this.ImpactTSI2Select.SelectedIndexChanged += new System.EventHandler(this.ImpactTSI2Select_SelectedIndexChanged);
            // 
            // ImpactTSI1Select
            // 
            this.ImpactTSI1Select.FormattingEnabled = true;
            this.ImpactTSI1Select.Location = new System.Drawing.Point(702, 141);
            this.ImpactTSI1Select.MaxDropDownItems = 20;
            this.ImpactTSI1Select.MaxLength = 2;
            this.ImpactTSI1Select.Name = "ImpactTSI1Select";
            this.ImpactTSI1Select.Size = new System.Drawing.Size(168, 21);
            this.ImpactTSI1Select.TabIndex = 132;
            this.ImpactTSI1Select.Tag = "x";
            this.ImpactTSI1Select.SelectedIndexChanged += new System.EventHandler(this.ImpactTSI1Select_SelectedIndexChanged);
            // 
            // ImpactTPIDSelect
            // 
            this.ImpactTPIDSelect.FormattingEnabled = true;
            this.ImpactTPIDSelect.Location = new System.Drawing.Point(902, 97);
            this.ImpactTPIDSelect.MaxDropDownItems = 20;
            this.ImpactTPIDSelect.MaxLength = 2;
            this.ImpactTPIDSelect.Name = "ImpactTPIDSelect";
            this.ImpactTPIDSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImpactTPIDSelect.Size = new System.Drawing.Size(168, 21);
            this.ImpactTPIDSelect.TabIndex = 131;
            this.ImpactTPIDSelect.Tag = "x";
            this.ImpactTPIDSelect.SelectedIndexChanged += new System.EventHandler(this.ImpactTPIDSelect_SelectedIndexChanged);
            // 
            // ImpactTPIOSelect
            // 
            this.ImpactTPIOSelect.FormattingEnabled = true;
            this.ImpactTPIOSelect.Location = new System.Drawing.Point(702, 97);
            this.ImpactTPIOSelect.MaxDropDownItems = 20;
            this.ImpactTPIOSelect.MaxLength = 2;
            this.ImpactTPIOSelect.Name = "ImpactTPIOSelect";
            this.ImpactTPIOSelect.Size = new System.Drawing.Size(168, 21);
            this.ImpactTPIOSelect.TabIndex = 130;
            this.ImpactTPIOSelect.Tag = "x";
            this.ImpactTPIOSelect.SelectedIndexChanged += new System.EventHandler(this.ImpactTPIOSelect_SelectedIndexChanged);
            // 
            // ResetImpactPlayersButton
            // 
            this.ResetImpactPlayersButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.ResetImpactPlayersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetImpactPlayersButton.Location = new System.Drawing.Point(851, 168);
            this.ResetImpactPlayersButton.Name = "ResetImpactPlayersButton";
            this.ResetImpactPlayersButton.Size = new System.Drawing.Size(73, 31);
            this.ResetImpactPlayersButton.TabIndex = 129;
            this.ResetImpactPlayersButton.Text = "Reset";
            this.ResetImpactPlayersButton.UseVisualStyleBackColor = false;
            this.ResetImpactPlayersButton.Click += new System.EventHandler(this.ResetImpactPlayers_Click);
            // 
            // CaptainDefSelectBox
            // 
            this.CaptainDefSelectBox.FormattingEnabled = true;
            this.CaptainDefSelectBox.Location = new System.Drawing.Point(902, 52);
            this.CaptainDefSelectBox.MaxDropDownItems = 20;
            this.CaptainDefSelectBox.MaxLength = 2;
            this.CaptainDefSelectBox.Name = "CaptainDefSelectBox";
            this.CaptainDefSelectBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaptainDefSelectBox.Size = new System.Drawing.Size(168, 21);
            this.CaptainDefSelectBox.TabIndex = 128;
            this.CaptainDefSelectBox.Tag = "x";
            this.CaptainDefSelectBox.SelectedIndexChanged += new System.EventHandler(this.CaptainDefSelectBox_SelectedIndexChanged);
            // 
            // CaptainOffSelectBox
            // 
            this.CaptainOffSelectBox.FormattingEnabled = true;
            this.CaptainOffSelectBox.Location = new System.Drawing.Point(702, 52);
            this.CaptainOffSelectBox.MaxDropDownItems = 20;
            this.CaptainOffSelectBox.MaxLength = 2;
            this.CaptainOffSelectBox.Name = "CaptainOffSelectBox";
            this.CaptainOffSelectBox.Size = new System.Drawing.Size(168, 21);
            this.CaptainOffSelectBox.TabIndex = 127;
            this.CaptainOffSelectBox.Tag = "x";
            this.CaptainOffSelectBox.SelectedIndexChanged += new System.EventHandler(this.CaptainOffSelectBox_SelectedIndexChanged);
            // 
            // PlaybookSelectBox
            // 
            this.PlaybookSelectBox.FormattingEnabled = true;
            this.PlaybookSelectBox.Location = new System.Drawing.Point(823, 414);
            this.PlaybookSelectBox.MaxLength = 2;
            this.PlaybookSelectBox.Name = "PlaybookSelectBox";
            this.PlaybookSelectBox.Size = new System.Drawing.Size(138, 21);
            this.PlaybookSelectBox.TabIndex = 126;
            this.PlaybookSelectBox.Tag = "x";
            this.PlaybookSelectBox.SelectedIndexChanged += new System.EventHandler(this.PlaybookSelectBox_SelectedIndexChanged);
            // 
            // DefTypeSelectBox
            // 
            this.DefTypeSelectBox.FormattingEnabled = true;
            this.DefTypeSelectBox.Location = new System.Drawing.Point(922, 452);
            this.DefTypeSelectBox.MaxLength = 2;
            this.DefTypeSelectBox.Name = "DefTypeSelectBox";
            this.DefTypeSelectBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DefTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.DefTypeSelectBox.TabIndex = 125;
            this.DefTypeSelectBox.Tag = "x";
            this.DefTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.DefTypeSelectBox_SelectedIndexChanged);
            // 
            // OffTypeSelectBox
            // 
            this.OffTypeSelectBox.FormattingEnabled = true;
            this.OffTypeSelectBox.Location = new System.Drawing.Point(730, 452);
            this.OffTypeSelectBox.MaxLength = 2;
            this.OffTypeSelectBox.Name = "OffTypeSelectBox";
            this.OffTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.OffTypeSelectBox.TabIndex = 124;
            this.OffTypeSelectBox.Tag = "x";
            this.OffTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.OffTypeSelectBox_SelectedIndexChanged);
            // 
            // CapacityNumbox
            // 
            this.CapacityNumbox.Location = new System.Drawing.Point(345, 581);
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
            this.AttendanceNumBox.Location = new System.Drawing.Point(235, 581);
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
            this.label59.Location = new System.Drawing.Point(346, 565);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(48, 13);
            this.label59.TabIndex = 121;
            this.label59.Text = "Capacity";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(236, 565);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(62, 13);
            this.label60.TabIndex = 120;
            this.label60.Text = "Attendance";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(472, 522);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(32, 13);
            this.label57.TabIndex = 119;
            this.label57.Text = "State";
            // 
            // StateBox
            // 
            this.StateBox.FormattingEnabled = true;
            this.StateBox.Location = new System.Drawing.Point(472, 537);
            this.StateBox.MaxLength = 2;
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(44, 21);
            this.StateBox.TabIndex = 118;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(375, 522);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(24, 13);
            this.label56.TabIndex = 117;
            this.label56.Text = "City";
            // 
            // CityNameBox
            // 
            this.CityNameBox.Location = new System.Drawing.Point(369, 538);
            this.CityNameBox.Name = "CityNameBox";
            this.CityNameBox.Size = new System.Drawing.Size(95, 20);
            this.CityNameBox.TabIndex = 116;
            this.CityNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CityNameBox.Leave += new System.EventHandler(this.CityNameBox_Leave);
            // 
            // stadiumNameBox
            // 
            this.stadiumNameBox.Location = new System.Drawing.Point(235, 538);
            this.stadiumNameBox.Name = "stadiumNameBox";
            this.stadiumNameBox.Size = new System.Drawing.Size(127, 20);
            this.stadiumNameBox.TabIndex = 114;
            this.stadiumNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stadiumNameBox.Leave += new System.EventHandler(this.stadiumNameBox_Leave);
            // 
            // TeamCDPCBox
            // 
            this.TeamCDPCBox.Location = new System.Drawing.Point(804, 365);
            this.TeamCDPCBox.Name = "TeamCDPCBox";
            this.TeamCDPCBox.ReadOnly = true;
            this.TeamCDPCBox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDPCBox.TabIndex = 72;
            this.TeamCDPCBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HCLastNameBox
            // 
            this.HCLastNameBox.Location = new System.Drawing.Point(835, 296);
            this.HCLastNameBox.Name = "HCLastNameBox";
            this.HCLastNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCLastNameBox.TabIndex = 68;
            this.HCLastNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCLastNameBox.TextChanged += new System.EventHandler(this.HCLastNameBox_TextChanged);
            // 
            // HCFirstNameBox
            // 
            this.HCFirstNameBox.Location = new System.Drawing.Point(734, 296);
            this.HCFirstNameBox.Name = "HCFirstNameBox";
            this.HCFirstNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCFirstNameBox.TabIndex = 56;
            this.HCFirstNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCFirstNameBox.TextChanged += new System.EventHandler(this.HCFirstNameBox_TextChanged);
            // 
            // CoachPollBox
            // 
            this.CoachPollBox.Location = new System.Drawing.Point(295, 154);
            this.CoachPollBox.Name = "CoachPollBox";
            this.CoachPollBox.ReadOnly = true;
            this.CoachPollBox.Size = new System.Drawing.Size(42, 20);
            this.CoachPollBox.TabIndex = 54;
            this.CoachPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SeasonRecordBox
            // 
            this.SeasonRecordBox.Location = new System.Drawing.Point(367, 154);
            this.SeasonRecordBox.Name = "SeasonRecordBox";
            this.SeasonRecordBox.ReadOnly = true;
            this.SeasonRecordBox.Size = new System.Drawing.Size(65, 20);
            this.SeasonRecordBox.TabIndex = 52;
            this.SeasonRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // APPollBox
            // 
            this.APPollBox.Location = new System.Drawing.Point(237, 154);
            this.APPollBox.Name = "APPollBox";
            this.APPollBox.ReadOnly = true;
            this.APPollBox.Size = new System.Drawing.Size(42, 20);
            this.APPollBox.TabIndex = 50;
            this.APPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfRecordBox
            // 
            this.ConfRecordBox.Location = new System.Drawing.Point(446, 154);
            this.ConfRecordBox.Name = "ConfRecordBox";
            this.ConfRecordBox.ReadOnly = true;
            this.ConfRecordBox.Size = new System.Drawing.Size(62, 20);
            this.ConfRecordBox.TabIndex = 48;
            this.ConfRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LeagueBox
            // 
            this.LeagueBox.Location = new System.Drawing.Point(306, 95);
            this.LeagueBox.Name = "LeagueBox";
            this.LeagueBox.ReadOnly = true;
            this.LeagueBox.Size = new System.Drawing.Size(42, 20);
            this.LeagueBox.TabIndex = 46;
            this.LeagueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TSNAtextBox
            // 
            this.TSNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSNAtextBox.Location = new System.Drawing.Point(561, 48);
            this.TSNAtextBox.MaxLength = 7;
            this.TSNAtextBox.Name = "TSNAtextBox";
            this.TSNAtextBox.Size = new System.Drawing.Size(78, 24);
            this.TSNAtextBox.TabIndex = 44;
            this.TSNAtextBox.Leave += new System.EventHandler(this.TSNAtextBox_Leave);
            // 
            // TeamDivisionBox
            // 
            this.TeamDivisionBox.Location = new System.Drawing.Point(449, 95);
            this.TeamDivisionBox.Name = "TeamDivisionBox";
            this.TeamDivisionBox.ReadOnly = true;
            this.TeamDivisionBox.Size = new System.Drawing.Size(88, 20);
            this.TeamDivisionBox.TabIndex = 42;
            this.TeamDivisionBox.Text = "Division";
            this.TeamDivisionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TeamConferenceBox
            // 
            this.TeamConferenceBox.Location = new System.Drawing.Point(355, 95);
            this.TeamConferenceBox.Name = "TeamConferenceBox";
            this.TeamConferenceBox.ReadOnly = true;
            this.TeamConferenceBox.Size = new System.Drawing.Size(88, 20);
            this.TeamConferenceBox.TabIndex = 40;
            this.TeamConferenceBox.Text = "Conference";
            this.TeamConferenceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TeamOVRtextbox
            // 
            this.TeamOVRtextbox.Location = new System.Drawing.Point(258, 95);
            this.TeamOVRtextbox.Name = "TeamOVRtextbox";
            this.TeamOVRtextbox.ReadOnly = true;
            this.TeamOVRtextbox.Size = new System.Drawing.Size(42, 20);
            this.TeamOVRtextbox.TabIndex = 30;
            this.TeamOVRtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TGIDtextBox
            // 
            this.TGIDtextBox.Location = new System.Drawing.Point(208, 95);
            this.TGIDtextBox.Name = "TGIDtextBox";
            this.TGIDtextBox.ReadOnly = true;
            this.TGIDtextBox.Size = new System.Drawing.Size(44, 20);
            this.TGIDtextBox.TabIndex = 16;
            this.TGIDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TMNAtextBox
            // 
            this.TMNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMNAtextBox.Location = new System.Drawing.Point(384, 48);
            this.TMNAtextBox.MaxLength = 32;
            this.TMNAtextBox.Name = "TMNAtextBox";
            this.TMNAtextBox.Size = new System.Drawing.Size(162, 24);
            this.TMNAtextBox.TabIndex = 14;
            this.TMNAtextBox.Leave += new System.EventHandler(this.TMNAtextBox_Leave);
            // 
            // TDNAtextBox
            // 
            this.TDNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDNAtextBox.Location = new System.Drawing.Point(206, 48);
            this.TDNAtextBox.MaxLength = 32;
            this.TDNAtextBox.Name = "TDNAtextBox";
            this.TDNAtextBox.Size = new System.Drawing.Size(162, 24);
            this.TDNAtextBox.TabIndex = 12;
            this.TDNAtextBox.Leave += new System.EventHandler(this.TDNAtextBox_Leave);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(236, 522);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(76, 13);
            this.label55.TabIndex = 115;
            this.label55.Text = "Stadium Name";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(313, 497);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(143, 25);
            this.label54.TabIndex = 113;
            this.label54.Text = "Stadium Info";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(818, 237);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(141, 25);
            this.label53.TabIndex = 112;
            this.label53.Text = "Head Coach";
            // 
            // UserCoachCheckBox
            // 
            this.UserCoachCheckBox.AutoSize = true;
            this.UserCoachCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCoachCheckBox.Location = new System.Drawing.Point(1003, 240);
            this.UserCoachCheckBox.Name = "UserCoachCheckBox";
            this.UserCoachCheckBox.Size = new System.Drawing.Size(122, 24);
            this.UserCoachCheckBox.TabIndex = 111;
            this.UserCoachCheckBox.Text = "User Coach";
            this.UserCoachCheckBox.UseVisualStyleBackColor = true;
            this.UserCoachCheckBox.CheckedChanged += new System.EventHandler(this.UserCoachCheckBox_CheckedChanged);
            // 
            // FireCoachButton
            // 
            this.FireCoachButton.BackColor = System.Drawing.Color.LightCoral;
            this.FireCoachButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FireCoachButton.Location = new System.Drawing.Point(840, 548);
            this.FireCoachButton.Name = "FireCoachButton";
            this.FireCoachButton.Size = new System.Drawing.Size(100, 43);
            this.FireCoachButton.TabIndex = 110;
            this.FireCoachButton.Text = "Fire Coach";
            this.FireCoachButton.UseVisualStyleBackColor = false;
            this.FireCoachButton.Click += new System.EventHandler(this.FireCoachButton_Click);
            // 
            // ResetSecondaryColorButton
            // 
            this.ResetSecondaryColorButton.Location = new System.Drawing.Point(415, 389);
            this.ResetSecondaryColorButton.Name = "ResetSecondaryColorButton";
            this.ResetSecondaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetSecondaryColorButton.TabIndex = 109;
            this.ResetSecondaryColorButton.Text = "Reset Color";
            this.ResetSecondaryColorButton.UseVisualStyleBackColor = true;
            this.ResetSecondaryColorButton.Click += new System.EventHandler(this.ResetSecondaryColorButton_Click);
            // 
            // ResetPrimaryColorButton
            // 
            this.ResetPrimaryColorButton.Location = new System.Drawing.Point(262, 389);
            this.ResetPrimaryColorButton.Name = "ResetPrimaryColorButton";
            this.ResetPrimaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetPrimaryColorButton.TabIndex = 108;
            this.ResetPrimaryColorButton.Text = "Reset Color";
            this.ResetPrimaryColorButton.UseVisualStyleBackColor = true;
            this.ResetPrimaryColorButton.Click += new System.EventHandler(this.ResetPrimaryColorButton_Click);
            // 
            // TeamCDTSbox
            // 
            this.TeamCDTSbox.Location = new System.Drawing.Point(1023, 497);
            this.TeamCDTSbox.Name = "TeamCDTSbox";
            this.TeamCDTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTSbox.TabIndex = 107;
            this.TeamCDTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTSbox.ValueChanged += new System.EventHandler(this.TeamCDTSbox_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(1029, 481);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(31, 13);
            this.label50.TabIndex = 106;
            this.label50.Text = "Subs";
            // 
            // TeamCDTAbox
            // 
            this.TeamCDTAbox.Location = new System.Drawing.Point(967, 497);
            this.TeamCDTAbox.Name = "TeamCDTAbox";
            this.TeamCDTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTAbox.TabIndex = 105;
            this.TeamCDTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTAbox.ValueChanged += new System.EventHandler(this.TeamCDTAbox_ValueChanged);
            // 
            // TeamCDTRbox
            // 
            this.TeamCDTRbox.Location = new System.Drawing.Point(911, 497);
            this.TeamCDTRbox.Name = "TeamCDTRbox";
            this.TeamCDTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTRbox.TabIndex = 104;
            this.TeamCDTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTRbox.ValueChanged += new System.EventHandler(this.TeamCDTRbox_ValueChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(952, 520);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(81, 13);
            this.label51.TabIndex = 103;
            this.label51.Text = "Aggressiveness";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(903, 481);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 102;
            this.label52.Text = "Passing Pct";
            // 
            // TeamCOTSbox
            // 
            this.TeamCOTSbox.Location = new System.Drawing.Point(831, 497);
            this.TeamCOTSbox.Name = "TeamCOTSbox";
            this.TeamCOTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTSbox.TabIndex = 101;
            this.TeamCOTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTSbox.ValueChanged += new System.EventHandler(this.TeamCOTSbox_ValueChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(837, 481);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 100;
            this.label49.Text = "Subs";
            // 
            // TeamCOTAbox
            // 
            this.TeamCOTAbox.Location = new System.Drawing.Point(775, 497);
            this.TeamCOTAbox.Name = "TeamCOTAbox";
            this.TeamCOTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTAbox.TabIndex = 99;
            this.TeamCOTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTAbox.ValueChanged += new System.EventHandler(this.TeamCOTAbox_ValueChanged);
            // 
            // TeamCOTRbox
            // 
            this.TeamCOTRbox.Location = new System.Drawing.Point(719, 497);
            this.TeamCOTRbox.Name = "TeamCOTRbox";
            this.TeamCOTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTRbox.TabIndex = 98;
            this.TeamCOTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTRbox.ValueChanged += new System.EventHandler(this.TeamCOTRbox_ValueChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(758, 520);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(81, 13);
            this.label47.TabIndex = 97;
            this.label47.Text = "Aggressiveness";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(710, 481);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 13);
            this.label48.TabIndex = 96;
            this.label48.Text = "Passing Pct";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(863, 398);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 94;
            this.label46.Text = "Playbook";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(736, 436);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(71, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Offense Type";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(932, 436);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(74, 13);
            this.label45.TabIndex = 90;
            this.label45.Text = "Base Defense";
            // 
            // TeamCCPONumBox
            // 
            this.TeamCCPONumBox.Location = new System.Drawing.Point(1003, 297);
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
            this.label43.Location = new System.Drawing.Point(1000, 281);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 88;
            this.label43.Text = "Performance";
            // 
            // SDURnumbox
            // 
            this.SDURnumbox.Location = new System.Drawing.Point(466, 262);
            this.SDURnumbox.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.SDURnumbox.Name = "SDURnumbox";
            this.SDURnumbox.Size = new System.Drawing.Size(50, 20);
            this.SDURnumbox.TabIndex = 87;
            this.SDURnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SDURnumbox.ValueChanged += new System.EventHandler(this.SDURnumbox_ValueChanged);
            // 
            // SNCTnumbox
            // 
            this.SNCTnumbox.Location = new System.Drawing.Point(401, 262);
            this.SNCTnumbox.Maximum = new decimal(new int[] {
            7,
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
            this.NCDPnumbox.Location = new System.Drawing.Point(318, 262);
            this.NCDPnumbox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NCDPnumbox.Name = "NCDPnumbox";
            this.NCDPnumbox.Size = new System.Drawing.Size(50, 20);
            this.NCDPnumbox.TabIndex = 85;
            this.NCDPnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NCDPnumbox.ValueChanged += new System.EventHandler(this.NCDPnumbox_ValueChanged);
            // 
            // INPOnumbox
            // 
            this.INPOnumbox.Location = new System.Drawing.Point(238, 262);
            this.INPOnumbox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.INPOnumbox.Name = "INPOnumbox";
            this.INPOnumbox.Size = new System.Drawing.Size(50, 20);
            this.INPOnumbox.TabIndex = 84;
            this.INPOnumbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.INPOnumbox.ValueChanged += new System.EventHandler(this.INPOnumbox_ValueChanged);
            // 
            // TeamHCPrestigeNumBox
            // 
            this.TeamHCPrestigeNumBox.Location = new System.Drawing.Point(936, 296);
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
            this.TMARNumBox.Location = new System.Drawing.Point(318, 209);
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
            this.TMPRNumBox.Location = new System.Drawing.Point(238, 209);
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
            this.TeamCRPCNumber.Location = new System.Drawing.Point(940, 366);
            this.TeamCRPCNumber.Name = "TeamCRPCNumber";
            this.TeamCRPCNumber.Size = new System.Drawing.Size(50, 20);
            this.TeamCRPCNumber.TabIndex = 80;
            this.TeamCRPCNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCRPCNumber.ValueChanged += new System.EventHandler(this.TeamCRPCNumber_ValueChanged);
            // 
            // TeamCTPCNumber
            // 
            this.TeamCTPCNumber.Location = new System.Drawing.Point(871, 365);
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
            this.label42.Location = new System.Drawing.Point(836, 333);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 13);
            this.label42.TabIndex = 78;
            this.label42.Text = "Off-Season Budget";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(937, 349);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 13);
            this.label39.TabIndex = 77;
            this.label39.Text = "Recruiting";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(876, 349);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(45, 13);
            this.label40.TabIndex = 75;
            this.label40.Text = "Training";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(801, 349);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 73;
            this.label41.Text = "Disciplining";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(323, 315);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(109, 20);
            this.label38.TabIndex = 71;
            this.label38.Text = "Team Colors";
            // 
            // TeamColor2Button
            // 
            this.TeamColor2Button.Location = new System.Drawing.Point(391, 338);
            this.TeamColor2Button.Name = "TeamColor2Button";
            this.TeamColor2Button.Size = new System.Drawing.Size(125, 50);
            this.TeamColor2Button.TabIndex = 70;
            this.TeamColor2Button.UseVisualStyleBackColor = true;
            this.TeamColor2Button.Click += new System.EventHandler(this.TeamColor2Button_Click);
            // 
            // TeamColor1Button
            // 
            this.TeamColor1Button.Location = new System.Drawing.Point(237, 338);
            this.TeamColor1Button.Name = "TeamColor1Button";
            this.TeamColor1Button.Size = new System.Drawing.Size(125, 50);
            this.TeamColor1Button.TabIndex = 69;
            this.TeamColor1Button.UseVisualStyleBackColor = true;
            this.TeamColor1Button.Click += new System.EventHandler(this.TeamColor1Button_Click);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(463, 246);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 13);
            this.label37.TabIndex = 67;
            this.label37.Text = "Duration";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(402, 246);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 13);
            this.label36.TabIndex = 65;
            this.label36.Text = "Sanction";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(315, 246);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 63;
            this.label34.Text = "Discipline Points";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(235, 246);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 13);
            this.label35.TabIndex = 61;
            this.label35.Text = "NCAA Interest";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(933, 280);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 59;
            this.label33.Text = "HC Prestige";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(735, 280);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 13);
            this.label32.TabIndex = 57;
            this.label32.Text = "Head Coach";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(296, 138);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 13);
            this.label31.TabIndex = 55;
            this.label31.Text = "Coach Poll";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(372, 138);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 53;
            this.label30.Text = "Record";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(238, 138);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 51;
            this.label28.Text = "AP Poll";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(446, 138);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 13);
            this.label29.TabIndex = 49;
            this.label29.Text = "Conf";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(307, 79);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = "League";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(558, 32);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 45;
            this.label26.Text = "Abbr Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(471, 78);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "Division";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(368, 78);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Conference";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(902, 36);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Team Captain - Defense";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(702, 37);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 36;
            this.label23.Text = "Team Captain - Offense";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(315, 193);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Academic Prestige";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(235, 193);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Team Prestige";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(262, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Rating";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(902, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Impact Player";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(702, 126);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Impact Player";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(902, 82);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Impact Player - Defense";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(702, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Impact Player - Offense";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(207, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Team ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(386, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Team Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "College Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Conference";
            // 
            // CGIDcomboBox
            // 
            this.CGIDcomboBox.FormattingEnabled = true;
            this.CGIDcomboBox.Location = new System.Drawing.Point(69, 24);
            this.CGIDcomboBox.Name = "CGIDcomboBox";
            this.CGIDcomboBox.Size = new System.Drawing.Size(102, 21);
            this.CGIDcomboBox.TabIndex = 8;
            this.CGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.CGIDcomboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "League";
            // 
            // LGIDcomboBox
            // 
            this.LGIDcomboBox.FormattingEnabled = true;
            this.LGIDcomboBox.Location = new System.Drawing.Point(12, 24);
            this.LGIDcomboBox.Name = "LGIDcomboBox";
            this.LGIDcomboBox.Size = new System.Drawing.Size(51, 21);
            this.LGIDcomboBox.TabIndex = 6;
            this.LGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.LGIDcomboBox_SelectedIndexChanged);
            // 
            // TGIDlistBox
            // 
            this.TGIDlistBox.FormattingEnabled = true;
            this.TGIDlistBox.Location = new System.Drawing.Point(12, 51);
            this.TGIDlistBox.Name = "TGIDlistBox";
            this.TGIDlistBox.Size = new System.Drawing.Size(159, 498);
            this.TGIDlistBox.TabIndex = 0;
            this.TGIDlistBox.SelectedIndexChanged += new System.EventHandler(this.TGIDlistBox_SelectedIndexChanged);
            // 
            // tabDB
            // 
            this.tabDB.BackColor = System.Drawing.SystemColors.Control;
            this.tabDB.Controls.Add(this.tableGridView);
            this.tabDB.Controls.Add(this.fieldsGridView);
            this.tabDB.Location = new System.Drawing.Point(4, 24);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(1152, 615);
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
            this.tableGridView.Size = new System.Drawing.Size(107, 605);
            this.tableGridView.TabIndex = 2;
            this.tableGridView.SelectionChanged += new System.EventHandler(this.TableGridView_SelectionChanged);
            // 
            // fieldsGridView
            // 
            this.fieldsGridView.AllowDrop = true;
            this.fieldsGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
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
            this.fieldsGridView.Size = new System.Drawing.Size(1030, 605);
            this.fieldsGridView.TabIndex = 3;
            this.fieldsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FieldGridView_CellValueChanged);
            this.fieldsGridView.CurrentCellChanged += new System.EventHandler(this.FieldGridView_CurrentCellChanged);
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabHome.Controls.Add(this.groupBox1);
            this.tabHome.Controls.Add(this.pictureBox1);
            this.tabHome.Location = new System.Drawing.Point(4, 24);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1152, 615);
            this.tabHome.TabIndex = 6;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.OGConfigRadio);
            this.groupBox1.Controls.Add(this.NextConfigRadio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 48);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // OGConfigRadio
            // 
            this.OGConfigRadio.AutoSize = true;
            this.OGConfigRadio.Checked = true;
            this.OGConfigRadio.Location = new System.Drawing.Point(23, 21);
            this.OGConfigRadio.Name = "OGConfigRadio";
            this.OGConfigRadio.Size = new System.Drawing.Size(144, 20);
            this.OGConfigRadio.TabIndex = 1;
            this.OGConfigRadio.TabStop = true;
            this.OGConfigRadio.Text = "NCAA 06 Original";
            this.OGConfigRadio.UseVisualStyleBackColor = true;
            this.OGConfigRadio.CheckedChanged += new System.EventHandler(this.OGConfigRadio_CheckedChanged);
            // 
            // NextConfigRadio
            // 
            this.NextConfigRadio.AutoSize = true;
            this.NextConfigRadio.Location = new System.Drawing.Point(201, 21);
            this.NextConfigRadio.Name = "NextConfigRadio";
            this.NextConfigRadio.Size = new System.Drawing.Size(163, 20);
            this.NextConfigRadio.TabIndex = 0;
            this.NextConfigRadio.Text = "NCAA Next 25+ Mod";
            this.NextConfigRadio.UseVisualStyleBackColor = true;
            this.NextConfigRadio.CheckedChanged += new System.EventHandler(this.NextConfigRadio_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_EDITOR.Properties.Resources.ncaa_db_editor_TITLE;
            this.pictureBox1.Location = new System.Drawing.Point(12, 56);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(550, 550);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(550, 550);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            this.tabControl1.Controls.Add(this.tabConf);
            this.tabControl1.Controls.Add(this.tabPlaybook);
            this.tabControl1.Controls.Add(this.tabDepthCharts);
            this.tabControl1.Controls.Add(this.tabRecruits);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 20);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 643);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_IndexChange);
            // 
            // tabRecruits
            // 
            this.tabRecruits.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabRecruits.Controls.Add(this.textBox21);
            this.tabRecruits.Controls.Add(this.textBox22);
            this.tabRecruits.Controls.Add(this.textBox23);
            this.tabRecruits.Controls.Add(this.label153);
            this.tabRecruits.Controls.Add(this.numericUpDown1);
            this.tabRecruits.Controls.Add(this.label154);
            this.tabRecruits.Controls.Add(this.comboBox1);
            this.tabRecruits.Controls.Add(this.label155);
            this.tabRecruits.Controls.Add(this.comboBox2);
            this.tabRecruits.Controls.Add(this.label156);
            this.tabRecruits.Controls.Add(this.numericUpDown2);
            this.tabRecruits.Controls.Add(this.label157);
            this.tabRecruits.Controls.Add(this.numericUpDown3);
            this.tabRecruits.Controls.Add(this.label158);
            this.tabRecruits.Controls.Add(this.comboBox3);
            this.tabRecruits.Controls.Add(this.label159);
            this.tabRecruits.Controls.Add(this.comboBox4);
            this.tabRecruits.Controls.Add(this.label160);
            this.tabRecruits.Controls.Add(this.comboBox5);
            this.tabRecruits.Controls.Add(this.label161);
            this.tabRecruits.Controls.Add(this.comboBox6);
            this.tabRecruits.Controls.Add(this.label162);
            this.tabRecruits.Controls.Add(this.comboBox7);
            this.tabRecruits.Controls.Add(this.label163);
            this.tabRecruits.Controls.Add(this.comboBox8);
            this.tabRecruits.Controls.Add(this.label164);
            this.tabRecruits.Controls.Add(this.label165);
            this.tabRecruits.Controls.Add(this.label166);
            this.tabRecruits.Location = new System.Drawing.Point(4, 24);
            this.tabRecruits.Name = "tabRecruits";
            this.tabRecruits.Size = new System.Drawing.Size(1152, 615);
            this.tabRecruits.TabIndex = 12;
            this.tabRecruits.Text = "Recruits";
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.Info;
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(1030, 62);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(53, 22);
            this.textBox21.TabIndex = 106;
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox22
            // 
            this.textBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.Location = new System.Drawing.Point(833, 62);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(111, 22);
            this.textBox22.TabIndex = 103;
            // 
            // textBox23
            // 
            this.textBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.Location = new System.Drawing.Point(711, 62);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(116, 22);
            this.textBox23.TabIndex = 102;
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(897, 96);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(37, 13);
            this.label153.TabIndex = 129;
            this.label153.Text = "Jersey";
            this.label153.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(897, 111);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 128;
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(801, 95);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(46, 13);
            this.label154.TabIndex = 127;
            this.label154.Text = "Redshirt";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(804, 111);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 21);
            this.comboBox1.TabIndex = 126;
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(718, 96);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(29, 13);
            this.label155.TabIndex = 125;
            this.label155.Text = "Year";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(719, 111);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(79, 21);
            this.comboBox2.TabIndex = 124;
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(1027, 96);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(63, 13);
            this.label156.TabIndex = 123;
            this.label156.Text = "Weight (lbs)";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(1026, 111);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            415,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 122;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(960, 96);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(55, 13);
            this.label157.TabIndex = 121;
            this.label157.Text = "Height (in)";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(963, 111);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown3.TabIndex = 120;
            this.numericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(997, 137);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(52, 13);
            this.label158.TabIndex = 119;
            this.label158.Text = "Hair Style";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(1000, 153);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(90, 21);
            this.comboBox3.TabIndex = 118;
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(897, 137);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(53, 13);
            this.label159.TabIndex = 117;
            this.label159.Text = "Hair Color";
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(900, 153);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(94, 21);
            this.comboBox4.TabIndex = 116;
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(840, 136);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(31, 13);
            this.label160.TabIndex = 115;
            this.label160.Text = "Face";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(843, 153);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(51, 21);
            this.comboBox5.TabIndex = 114;
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(789, 136);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(38, 13);
            this.label161.TabIndex = 113;
            this.label161.Text = "Shape";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(792, 153);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(45, 21);
            this.comboBox6.TabIndex = 112;
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(720, 136);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(56, 13);
            this.label162.TabIndex = 111;
            this.label162.Text = "Skin Tone";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(719, 153);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(67, 21);
            this.comboBox7.TabIndex = 110;
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label163.Location = new System.Drawing.Point(950, 42);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(63, 16);
            this.label163.TabIndex = 109;
            this.label163.Text = "Position";
            // 
            // comboBox8
            // 
            this.comboBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(953, 60);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(60, 24);
            this.comboBox8.TabIndex = 108;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label164.Location = new System.Drawing.Point(1027, 42);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(57, 16);
            this.label164.TabIndex = 107;
            this.label164.Text = "Overall";
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label165.Location = new System.Drawing.Point(830, 42);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(81, 16);
            this.label165.TabIndex = 105;
            this.label165.Text = "Last Name";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.Location = new System.Drawing.Point(711, 42);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(82, 16);
            this.label166.TabIndex = 104;
            this.label166.Text = "First Name";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MainEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabDepthCharts.ResumeLayout(false);
            this.tabDepthCharts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCHTGrid)).EndInit();
            this.tabPlaybook.ResumeLayout(false);
            this.tabPlaybook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayNameValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrtNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaybookGrid)).EndInit();
            this.tabConf.ResumeLayout(false);
            this.tabConf.PerformLayout();
            this.tabDev.ResumeLayout(false);
            this.tabDev.PerformLayout();
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAttNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAttNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalAttNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).EndInit();
            this.tabOffSeason.ResumeLayout(false);
            this.tabOffSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polyNamesPCT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).EndInit();
            this.tabSeason.ResumeLayout(false);
            this.tabSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).EndInit();
            this.tabCoaches.ResumeLayout(false);
            this.tabCoaches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCCPONum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HCPrestigeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachRecruitingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachTrainingBox)).EndInit();
            this.tabPlayers.ResumeLayout(false);
            this.tabPlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PJEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PWGTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHGTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKACBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKPRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTAKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCARBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCTHBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJMPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGIBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAWRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPOEBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PACCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSPDBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINJBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIMPBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
            this.tabDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).EndInit();
            this.tabHome.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabRecruits.ResumeLayout(false);
            this.tabRecruits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        public System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.ToolStripMenuItem CSVMenu;
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
        public System.Windows.Forms.OpenFileDialog openFileDialog2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripMenuItem tabDelimitedMenuItem;
        public System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem tableFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem defaultFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ascendingFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem customOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem descendingFieldOrderMenuItem;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem LeagueMakerToolStripMenuItem;
        private ToolStripMenuItem ScheduleGenMenuItem;
        private ToolStripMenuItem NCAANext25Config;
        private GroupBox groupBox2;
        private RadioButton DB2Button;
        private RadioButton DB1Button;
        public ToolStripMenuItem definitionFileMenuItem;
        private TabPage tabDepthCharts;
        private System.Windows.Forms.Button DCHTAutoSet;
        private System.Windows.Forms.Button DCHTClear;
        private System.Windows.Forms.Button UpdateDCHT;
        private System.Windows.Forms.ComboBox DCHTTeam;
        private Label label152;
        private DataGridView DCHTGrid;
        private DataGridViewTextBoxColumn DCHTPPOS;
        private DataGridViewComboBoxColumn DCHT0;
        private DataGridViewComboBoxColumn DCHT1;
        private DataGridViewComboBoxColumn DCHT2;
        private DataGridViewComboBoxColumn DCHT3;
        private DataGridViewComboBoxColumn DCHT4;
        private DataGridViewComboBoxColumn DCHT5;
        private TabPage tabPlaybook;
        private Label PlayNameRatio;
        private System.Windows.Forms.Button SetPlayNameValueButton;
        private Label label114;
        private Label label115;
        private System.Windows.Forms.ComboBox PlayNameBox;
        private NumericUpDown PlayNameValue;
        private Label ProjTypeRatio;
        private Label ProjPassRatio;
        private Label RunCounter;
        private Label PassCounter;
        private System.Windows.Forms.Button ImportPlaybookCSV;
        private System.Windows.Forms.Button pcrtValueButton;
        private Label label112;
        private Label label111;
        private System.Windows.Forms.ComboBox PlayTypeBox;
        private NumericUpDown pcrtNumBox;
        private Label label110;
        private System.Windows.Forms.ComboBox aigrFilterBox;
        private System.Windows.Forms.Button AIGRNameButton;
        private System.Windows.Forms.Button savePBDataButton;
        private System.Windows.Forms.Button ExportPBData;
        private DataGridView PlaybookGrid;
        private DataGridViewTextBoxColumn PBRec;
        private DataGridViewTextBoxColumn PBPL;
        private DataGridViewTextBoxColumn AIGRVal;
        private DataGridViewTextBoxColumn AIGRname;
        private DataGridViewTextBoxColumn prct;
        private DataGridViewTextBoxColumn PLYL;
        private DataGridViewTextBoxColumn PlayName;
        private DataGridViewTextBoxColumn PLYTVal;
        private DataGridViewTextBoxColumn PLYT;
        private TabPage tabConf;
        private Label label80;
        private Label label4;
        private System.Windows.Forms.ComboBox SwapRosterBox;
        private CheckBox EnableFCSSwapBox;
        private System.Windows.Forms.ComboBox FCSSwapListBox;
        private System.Windows.Forms.Button DeselectTeamsButton;
        private System.Windows.Forms.Button SwapButton;
        private Label ConfName12;
        private Label ConfName11;
        private Label ConfName10;
        private Label ConfName9;
        private Label ConfName8;
        private Label ConfName7;
        private Label ConfName6;
        private Label ConfName5;
        private Label ConfName4;
        private Label ConfName3;
        private Label ConfName2;
        private Label ConfName1;
        private CheckedListBox conf12;
        private CheckedListBox conf11;
        private CheckedListBox conf10;
        private CheckedListBox conf9;
        private CheckedListBox conf8;
        private CheckedListBox conf7;
        private CheckedListBox conf6;
        private CheckedListBox conf5;
        private CheckedListBox conf4;
        private CheckedListBox conf3;
        private CheckedListBox conf2;
        private CheckedListBox conf1;
        private TabPage tabDev;
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
        public System.Windows.Forms.TextBox textBox10;
        public System.Windows.Forms.TextBox textBox9;
        public System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.TextBox textBox7;
        public System.Windows.Forms.TextBox textBox5;
        public System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox6;
        public System.Windows.Forms.Button DevCalcTeamRatingsButton;
        public System.Windows.Forms.Button DevDepthChartButton;
        public System.Windows.Forms.Button DevRandomizeFaceButton;
        public System.Windows.Forms.Button DevCalcOVRButton;
        public System.Windows.Forms.Button DevFillRosterButton;
        public System.Windows.Forms.Button CreateTransfersCSVButton;
        public System.Windows.Forms.Button ImportRecruitsButton;
        public System.Windows.Forms.Button GraduateButton;
        private TabPage tabTools;
        public System.Windows.Forms.Button FantasyCoachesButton;
        public System.Windows.Forms.Button SyncPBButton;
        private Label label109;
        private Label label108;
        private Label label107;
        private System.Windows.Forms.ComboBox MaxAttPosBox;
        private System.Windows.Forms.ComboBox MinAttPosBox;
        private System.Windows.Forms.ComboBox GlobalAttPosBox;
        private System.Windows.Forms.Button MaxAttButton;
        private System.Windows.Forms.Button MinAttButton;
        private System.Windows.Forms.Button GlobalAttButton;
        private System.Windows.Forms.TextBox MaxAttRating;
        private System.Windows.Forms.TextBox MinAttRating;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        private NumericUpDown MaxAttNum;
        private Label label106;
        private System.Windows.Forms.ComboBox MaxAttBox;
        private NumericUpDown MinAttNum;
        private Label label100;
        private System.Windows.Forms.ComboBox MinAttBox;
        private CheckBox GlobalAttCheck;
        private NumericUpDown GlobalAttNum;
        private Label label99;
        private System.Windows.Forms.ComboBox GlobalAttBox;
        public System.Windows.Forms.Button ReorderPGIDButton;
        public System.Windows.Forms.Button TORDButton;
        public System.Windows.Forms.Button CFUSAexportButton;
        public System.Windows.Forms.Button RandomizeHeadButton;
        private Label label58;
        private NumericUpDown FillRosterPCT;
        public System.Windows.Forms.Button buttonFillRosters;
        public System.Windows.Forms.Button buttonAutoDepthChart;
        public System.Windows.Forms.Button buttonFantasyRoster;
        public System.Windows.Forms.Button buttonImpactPlayers;
        public System.Windows.Forms.Button TYDNButton;
        public System.Windows.Forms.Button buttonCalcOverall;
        public System.Windows.Forms.Button buttonRandPotential;
        public System.Windows.Forms.Button bodyFix;
        public TabPage tabOffSeason;
        public System.Windows.Forms.Button buttonRandomizeFaceShape;
        public Label labelPolyNamesPCT;
        public NumericUpDown polyNamesPCT;
        public System.Windows.Forms.Button polyNames;
        public System.Windows.Forms.TextBox textBoxOffSeason;
        public System.Windows.Forms.TextBox textBoxOffSeasonTitle;
        public Label labelIntTeams;
        public NumericUpDown removeInterestTeams;
        public System.Windows.Forms.Button buttonInterestedTeams;
        public Label label12;
        public NumericUpDown minTRPA;
        public Label labelMinRecPts;
        public NumericUpDown minRecPts;
        public Label labelRecruit;
        public NumericUpDown recruitTolerance;
        public Label wkonLabel;
        public NumericUpDown toleranceWalkOn;
        public System.Windows.Forms.Button buttonRandRecruits;
        public System.Windows.Forms.Button buttonRandWalkOns;
        public System.Windows.Forms.Button buttonMinRecruitingPts;
        public TabPage tabSeason;
        public System.Windows.Forms.Button CoachPrestigeButton;
        private Label label14;
        private NumericUpDown numberPlayerCoach;
        private System.Windows.Forms.Button buttonPlayerCoach;
        private System.Windows.Forms.Button buttonRealignment;
        private Label label13;
        public Label labelMaxTransfers;
        public NumericUpDown maxFiredTransfers;
        private CheckBox checkBoxFiredTransfers;
        private System.Windows.Forms.Button buttonChaosTransfers;
        public Label labelMaxSkilDrop_PS;
        public NumericUpDown MaxSkillDropPS;
        private Label labelPSInjuries;
        private NumericUpDown numInjuries;
        public System.Windows.Forms.Button buttonPSInjuries;
        public Label labelPoaching;
        public NumericUpDown poachValue;
        public Label labelJobSecurity;
        public NumericUpDown jobSecurityValue;
        public System.Windows.Forms.Button buttonCarousel;
        public Label labelSkillDrop;
        public NumericUpDown skillDrop;
        public CheckBox checkBoxInjuryRatings;
        public System.Windows.Forms.Button buttonRandomBudgets;
        public System.Windows.Forms.TextBox dbToolsInfo;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button coachProg;
        public System.Windows.Forms.Button medRS;
        private TabPage tabCoaches;
        private System.Windows.Forms.Button NewCoachButton;
        private CheckBox CoachShowTeamBox;
        private System.Windows.Forms.ComboBox CoachTeamList;
        public Label label98;
        private CheckBox CFUCBox;
        public Label label96;
        private System.Windows.Forms.ComboBox COHTBox;
        public Label label97;
        private System.Windows.Forms.ComboBox CTgwBox;
        public Label label95;
        public System.Windows.Forms.ComboBox CoachFilter;
        private System.Windows.Forms.ComboBox CoachPlaybookBox;
        private System.Windows.Forms.ComboBox CoachDefTypeBox;
        private System.Windows.Forms.ComboBox CoachOffTypeBox;
        private Label label131;
        private NumericUpDown CoachCDTSBox;
        public Label label132;
        private NumericUpDown CoachCDTABox;
        private NumericUpDown CoachCDTRBox;
        public Label label133;
        public Label label134;
        private NumericUpDown CoachCOTSBox;
        public Label label135;
        private NumericUpDown CoachCOTABox;
        private NumericUpDown CoachCOTRBox;
        public Label label136;
        public Label label137;
        public Label label138;
        public Label label139;
        public Label label140;
        private NumericUpDown CoachCCPONum;
        public Label label141;
        private NumericUpDown HCPrestigeNum;
        private NumericUpDown CoachRecruitingBox;
        private NumericUpDown CoachTrainingBox;
        public Label label142;
        public Label label143;
        public Label label144;
        public Label label145;
        public System.Windows.Forms.TextBox CoachDisciplineBox;
        public System.Windows.Forms.TextBox CCIDBox;
        public System.Windows.Forms.TextBox CoachLastNameBox;
        public System.Windows.Forms.TextBox CoachFirstNameBox;
        public Label label146;
        public Label label94;
        public Label label101;
        private System.Windows.Forms.ComboBox CTHGBox;
        public Label label102;
        private System.Windows.Forms.ComboBox CHARBox;
        public Label label103;
        private System.Windows.Forms.ComboBox CFEXBox;
        public Label label104;
        private System.Windows.Forms.ComboBox CBSZBox;
        public Label label105;
        private System.Windows.Forms.ComboBox CSKIBox;
        public ListBox CoachListBox;
        public Label label129;
        public Label label130;
        public TabPage tabPlayers;
        public Label label151;
        public System.Windows.Forms.TextBox PRST;
        public System.Windows.Forms.TextBox PGIDbox;
        private System.Windows.Forms.TextBox PKACtext;
        private System.Windows.Forms.TextBox PKPRtext;
        private System.Windows.Forms.TextBox PTAKtext;
        private System.Windows.Forms.TextBox PPBKtext;
        private System.Windows.Forms.TextBox PTHAtext;
        private System.Windows.Forms.TextBox PCARtext;
        private System.Windows.Forms.TextBox PCTHtext;
        private System.Windows.Forms.TextBox PJMPtext;
        private System.Windows.Forms.TextBox PAGItext;
        private System.Windows.Forms.TextBox PAWRtext;
        private System.Windows.Forms.TextBox PPOEtext;
        private System.Windows.Forms.TextBox PRBKtext;
        private System.Windows.Forms.TextBox PTHPtext;
        private System.Windows.Forms.TextBox PBTKtext;
        private System.Windows.Forms.TextBox PSTRtext;
        private System.Windows.Forms.TextBox PACCtext;
        private System.Windows.Forms.TextBox PSPDtext;
        private System.Windows.Forms.TextBox PINJtext;
        private System.Windows.Forms.TextBox PIMPtext;
        public System.Windows.Forms.TextBox POVRbox;
        public System.Windows.Forms.TextBox PLNAtextBox;
        public System.Windows.Forms.TextBox PFNAtextBox;
        private Label label126;
        private System.Windows.Forms.ComboBox RightShoe;
        private Label label150;
        private System.Windows.Forms.ComboBox Helmet;
        private Label label149;
        private Label label148;
        private Label label127;
        private System.Windows.Forms.ComboBox RightElbow;
        private Label label128;
        private System.Windows.Forms.ComboBox RightWrist;
        private Label label147;
        private System.Windows.Forms.ComboBox RightHand;
        private Label label125;
        private System.Windows.Forms.ComboBox NeckPad;
        private Label label123;
        private System.Windows.Forms.ComboBox NasalStrip;
        private Label label124;
        private System.Windows.Forms.ComboBox Visor;
        private Label label122;
        private System.Windows.Forms.ComboBox EyeBlack;
        private System.Windows.Forms.ComboBox SleeveColor;
        private Label label121;
        private System.Windows.Forms.ComboBox Sleeves;
        private Label label120;
        private System.Windows.Forms.ComboBox LeftElbow;
        private Label label119;
        private System.Windows.Forms.ComboBox Facemask;
        private Label label118;
        private System.Windows.Forms.ComboBox LeftWrist;
        private Label label117;
        private System.Windows.Forms.ComboBox LeftHand;
        private Label label116;
        private System.Windows.Forms.ComboBox LeftShoe;
        private Label label113;
        private NumericUpDown PJEN;
        private System.Windows.Forms.Button PlayerSetDepthChartButton;
        public Label PGIDLabel;
        private CheckBox ShowPOSGBox;
        private CheckBox ShowRatingCheckbox;
        private CheckBox ShowPosCheckBox;
        public Label label93;
        private System.Windows.Forms.ComboBox PTYPBox;
        public Label label92;
        private System.Windows.Forms.ComboBox PRSDBox;
        public Label label91;
        private System.Windows.Forms.ComboBox PYERBox;
        private Label label89;
        private NumericUpDown PWGTBox;
        private Label label90;
        private NumericUpDown PHGTBox;
        public Label label88;
        public Label label87;
        private System.Windows.Forms.ComboBox PHEDBox;
        public Label label86;
        private System.Windows.Forms.ComboBox PHCLBox;
        public Label label85;
        private System.Windows.Forms.ComboBox PFMPBox;
        public Label label84;
        private System.Windows.Forms.ComboBox PFGMBox;
        public Label label83;
        private System.Windows.Forms.ComboBox PSKIBox;
        private Label label79;
        private NumericUpDown PKACBox;
        private Label label81;
        private NumericUpDown PKPRBox;
        private Label label82;
        private NumericUpDown PTAKBox;
        private Label label71;
        private NumericUpDown PPBKBox;
        private Label label72;
        private NumericUpDown PTHABox;
        private Label label73;
        private NumericUpDown PCARBox;
        private Label label74;
        private NumericUpDown PCTHBox;
        private Label label75;
        private NumericUpDown PJMPBox;
        private Label label76;
        private NumericUpDown PAGIBox;
        private Label label77;
        private NumericUpDown PAWRBox;
        private Label label78;
        private NumericUpDown PPOEBox;
        private Label label67;
        private NumericUpDown PRBKBox;
        private Label label68;
        private NumericUpDown PTHPBox;
        private Label label69;
        private NumericUpDown PBTKBox;
        private Label label70;
        private NumericUpDown PSTRBox;
        private Label label66;
        private NumericUpDown PACCBox;
        private Label label65;
        private NumericUpDown PSPDBox;
        private Label label64;
        private NumericUpDown PINJBox;
        private Label label63;
        private NumericUpDown PIMPBox;
        public Label label62;
        private System.Windows.Forms.ComboBox PPOSBox;
        public Label label61;
        public Label RosterSizeLabel;
        public Label label3;
        public System.Windows.Forms.ComboBox TGIDplayerBox;
        public ListBox PGIDlistBox;
        public Label label2;
        public Label label1;
        private PictureBox pictureBox2;
        public TabPage tabTeams;
        private System.Windows.Forms.Button TeamSetDepthChart;
        private System.Windows.Forms.Button GenerateNewRosterButton;
        private System.Windows.Forms.Button DeathPenaltyButton;
        public Label TeamRosterSizeLabel;
        private System.Windows.Forms.ComboBox CheerleaderBox;
        private System.Windows.Forms.ComboBox CrowdBox;
        public Label label5;
        public Label label8;
        private System.Windows.Forms.ComboBox ImpactTSI2Select;
        private System.Windows.Forms.ComboBox ImpactTSI1Select;
        private System.Windows.Forms.ComboBox ImpactTPIDSelect;
        private System.Windows.Forms.ComboBox ImpactTPIOSelect;
        private System.Windows.Forms.Button ResetImpactPlayersButton;
        private System.Windows.Forms.ComboBox CaptainDefSelectBox;
        private System.Windows.Forms.ComboBox CaptainOffSelectBox;
        private System.Windows.Forms.ComboBox PlaybookSelectBox;
        private System.Windows.Forms.ComboBox DefTypeSelectBox;
        private System.Windows.Forms.ComboBox OffTypeSelectBox;
        private NumericUpDown CapacityNumbox;
        private NumericUpDown AttendanceNumBox;
        public Label label59;
        public Label label60;
        public Label label57;
        private System.Windows.Forms.ComboBox StateBox;
        public Label label56;
        public System.Windows.Forms.TextBox CityNameBox;
        public System.Windows.Forms.TextBox stadiumNameBox;
        public System.Windows.Forms.TextBox TeamCDPCBox;
        public System.Windows.Forms.TextBox HCLastNameBox;
        public System.Windows.Forms.TextBox HCFirstNameBox;
        public System.Windows.Forms.TextBox CoachPollBox;
        public System.Windows.Forms.TextBox SeasonRecordBox;
        public System.Windows.Forms.TextBox APPollBox;
        public System.Windows.Forms.TextBox ConfRecordBox;
        public System.Windows.Forms.TextBox LeagueBox;
        public System.Windows.Forms.TextBox TSNAtextBox;
        public System.Windows.Forms.TextBox TeamDivisionBox;
        public System.Windows.Forms.TextBox TeamConferenceBox;
        public System.Windows.Forms.TextBox TeamOVRtextbox;
        public System.Windows.Forms.TextBox TGIDtextBox;
        public System.Windows.Forms.TextBox TMNAtextBox;
        public System.Windows.Forms.TextBox TDNAtextBox;
        public Label label55;
        private Label label54;
        private Label label53;
        private CheckBox UserCoachCheckBox;
        private System.Windows.Forms.Button FireCoachButton;
        private System.Windows.Forms.Button ResetSecondaryColorButton;
        private System.Windows.Forms.Button ResetPrimaryColorButton;
        private NumericUpDown TeamCDTSbox;
        public Label label50;
        private NumericUpDown TeamCDTAbox;
        private NumericUpDown TeamCDTRbox;
        public Label label51;
        public Label label52;
        private NumericUpDown TeamCOTSbox;
        public Label label49;
        private NumericUpDown TeamCOTAbox;
        private NumericUpDown TeamCOTRbox;
        public Label label47;
        public Label label48;
        public Label label46;
        public Label label44;
        public Label label45;
        private NumericUpDown TeamCCPONumBox;
        public Label label43;
        private NumericUpDown SDURnumbox;
        private NumericUpDown SNCTnumbox;
        private NumericUpDown NCDPnumbox;
        private NumericUpDown INPOnumbox;
        private NumericUpDown TeamHCPrestigeNumBox;
        private NumericUpDown TMARNumBox;
        private NumericUpDown TMPRNumBox;
        private NumericUpDown TeamCRPCNumber;
        private NumericUpDown TeamCTPCNumber;
        public Label label42;
        public Label label39;
        public Label label40;
        public Label label41;
        public Label label38;
        private System.Windows.Forms.Button TeamColor2Button;
        private System.Windows.Forms.Button TeamColor1Button;
        public Label label37;
        public Label label36;
        public Label label34;
        public Label label35;
        public Label label33;
        public Label label32;
        public Label label31;
        public Label label30;
        public Label label28;
        public Label label29;
        public Label label27;
        public Label label26;
        public Label label25;
        public Label label24;
        public Label label22;
        public Label label23;
        public Label label21;
        public Label label20;
        public Label label19;
        public Label label18;
        public Label label17;
        public Label label16;
        public Label label15;
        public Label label11;
        public Label label10;
        public Label label9;
        public Label label7;
        public System.Windows.Forms.ComboBox CGIDcomboBox;
        public Label label6;
        public System.Windows.Forms.ComboBox LGIDcomboBox;
        public ListBox TGIDlistBox;
        public TabPage tabDB;
        public DataGridView tableGridView;
        public DataGridView fieldsGridView;
        private TabPage tabHome;
        private GroupBox groupBox1;
        private RadioButton OGConfigRadio;
        private RadioButton NextConfigRadio;
        private PictureBox pictureBox1;
        public TabControl tabControl1;
        private GroupBox groupBox3;
        private TabPage tabRecruits;
        public System.Windows.Forms.TextBox textBox21;
        public System.Windows.Forms.TextBox textBox22;
        public System.Windows.Forms.TextBox textBox23;
        private Label label153;
        private NumericUpDown numericUpDown1;
        public Label label154;
        private System.Windows.Forms.ComboBox comboBox1;
        public Label label155;
        private System.Windows.Forms.ComboBox comboBox2;
        private Label label156;
        private NumericUpDown numericUpDown2;
        private Label label157;
        private NumericUpDown numericUpDown3;
        public Label label158;
        private System.Windows.Forms.ComboBox comboBox3;
        public Label label159;
        private System.Windows.Forms.ComboBox comboBox4;
        public Label label160;
        private System.Windows.Forms.ComboBox comboBox5;
        public Label label161;
        private System.Windows.Forms.ComboBox comboBox6;
        public Label label162;
        private System.Windows.Forms.ComboBox comboBox7;
        public Label label163;
        private System.Windows.Forms.ComboBox comboBox8;
        public Label label164;
        public Label label165;
        public Label label166;
        private NotifyIcon notifyIcon1;
        public System.Windows.Forms.TextBox playerTeamBox;
        private Label label167;
    }
}

