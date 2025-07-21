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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.NCAANextConfig = new System.Windows.Forms.ToolStripMenuItem();
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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.DB1Button = new System.Windows.Forms.RadioButton();
            this.DB2Button = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabDev = new System.Windows.Forms.TabPage();
            this.CFUSAexportButton = new System.Windows.Forms.Button();
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
            this.tabUniforms = new System.Windows.Forms.TabPage();
            this.ImportTeamUNIF = new System.Windows.Forms.Button();
            this.ExportTeamUNIF = new System.Windows.Forms.Button();
            this.label172 = new System.Windows.Forms.Label();
            this.UpdateUNIFButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label170 = new System.Windows.Forms.Label();
            this.GlobalAltCheck = new System.Windows.Forms.CheckBox();
            this.GlobalPrimaryCheck = new System.Windows.Forms.CheckBox();
            this.GlobalUniFilter = new System.Windows.Forms.ComboBox();
            this.label171 = new System.Windows.Forms.Label();
            this.UniformGrid = new System.Windows.Forms.DataGridView();
            this.UniformActivation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnifTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TUNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ULTF = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ShoulderNums = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SleeveNums = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SleeveDecal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HelmetNums = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.HelmetSideNum = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.UniformsActivated = new System.Windows.Forms.Label();
            this.label169 = new System.Windows.Forms.Label();
            this.TeamAltUniCheck = new System.Windows.Forms.CheckBox();
            this.TeamPrimaryUniCheck = new System.Windows.Forms.CheckBox();
            this.TeamUniformSelectBox = new System.Windows.Forms.ComboBox();
            this.label168 = new System.Windows.Forms.Label();
            this.tabPlaybook = new System.Windows.Forms.TabPage();
            this.textBox24 = new System.Windows.Forms.TextBox();
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
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.DefaultPlaysRadio = new System.Windows.Forms.RadioButton();
            this.CustomPlaysRadio = new System.Windows.Forms.RadioButton();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.FixHometownButton = new System.Windows.Forms.Button();
            this.ReRankTeamsAP = new System.Windows.Forms.CheckBox();
            this.ResetDynYear = new System.Windows.Forms.Button();
            this.groupBox38 = new System.Windows.Forms.GroupBox();
            this.FantastyRosterLeague = new System.Windows.Forms.Panel();
            this.label263 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.FBSroster = new System.Windows.Forms.RadioButton();
            this.DepthChartSize = new System.Windows.Forms.GroupBox();
            this.DC77 = new System.Windows.Forms.RadioButton();
            this.DC88 = new System.Windows.Forms.RadioButton();
            this.MaxFantasyPlayers = new System.Windows.Forms.NumericUpDown();
            this.label262 = new System.Windows.Forms.Label();
            this.buttonAutoDepthChart = new System.Windows.Forms.Button();
            this.ClearExpiredStats = new System.Windows.Forms.Button();
            this.buttonFantasyRoster = new System.Windows.Forms.Button();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.FantasyCSV = new System.Windows.Forms.RadioButton();
            this.FantasyTeamDB = new System.Windows.Forms.RadioButton();
            this.buttonFillRosters = new System.Windows.Forms.Button();
            this.FillRosterPCT = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.FantasyCoachesButton = new System.Windows.Forms.Button();
            this.buttonRandPotential = new System.Windows.Forms.Button();
            this.RandomizeHeadButton = new System.Windows.Forms.Button();
            this.bodyFix = new System.Windows.Forms.Button();
            this.buttonCalcOverall = new System.Windows.Forms.Button();
            this.ReRankTeams = new System.Windows.Forms.CheckBox();
            this.FixHCBugsButton = new System.Windows.Forms.Button();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.MaxBodyValue = new System.Windows.Forms.NumericUpDown();
            this.label264 = new System.Windows.Forms.Label();
            this.label265 = new System.Windows.Forms.Label();
            this.MinBodyType = new System.Windows.Forms.ComboBox();
            this.label266 = new System.Windows.Forms.Label();
            this.MaxBodyPos = new System.Windows.Forms.ComboBox();
            this.MinBodyValue = new System.Windows.Forms.NumericUpDown();
            this.MinBodyPos = new System.Windows.Forms.ComboBox();
            this.MaxBodyType = new System.Windows.Forms.ComboBox();
            this.label267 = new System.Windows.Forms.Label();
            this.UpdateMaxBody = new System.Windows.Forms.Button();
            this.UpdateMinBody = new System.Windows.Forms.Button();
            this.MaxAttNum = new System.Windows.Forms.NumericUpDown();
            this.GlobalAttBox = new System.Windows.Forms.ComboBox();
            this.label99 = new System.Windows.Forms.Label();
            this.GlobalAttNum = new System.Windows.Forms.NumericUpDown();
            this.label109 = new System.Windows.Forms.Label();
            this.GlobalAttCheck = new System.Windows.Forms.CheckBox();
            this.label108 = new System.Windows.Forms.Label();
            this.MinAttBox = new System.Windows.Forms.ComboBox();
            this.label107 = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.MaxAttPosBox = new System.Windows.Forms.ComboBox();
            this.MinAttNum = new System.Windows.Forms.NumericUpDown();
            this.MinAttPosBox = new System.Windows.Forms.ComboBox();
            this.MaxAttBox = new System.Windows.Forms.ComboBox();
            this.GlobalAttPosBox = new System.Windows.Forms.ComboBox();
            this.label106 = new System.Windows.Forms.Label();
            this.MaxAttButton = new System.Windows.Forms.Button();
            this.MinAttRating = new System.Windows.Forms.TextBox();
            this.MinAttButton = new System.Windows.Forms.Button();
            this.MaxAttRating = new System.Windows.Forms.TextBox();
            this.GlobalAttButton = new System.Windows.Forms.Button();
            this.UniquePlayerButton = new System.Windows.Forms.Button();
            this.SyncPBButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ReorderPGIDButton = new System.Windows.Forms.Button();
            this.TORDButton = new System.Windows.Forms.Button();
            this.TYDNButton = new System.Windows.Forms.Button();
            this.tabOffSeason = new System.Windows.Forms.TabPage();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.removeInterestTeams = new System.Windows.Forms.NumericUpDown();
            this.buttonMinRecruitingPts = new System.Windows.Forms.Button();
            this.minRecPts = new System.Windows.Forms.NumericUpDown();
            this.labelMinRecPts = new System.Windows.Forms.Label();
            this.labelIntTeams = new System.Windows.Forms.Label();
            this.minTRPA = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonInterestedTeams = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.RecalculateStarRankingsButton = new System.Windows.Forms.Button();
            this.DetermineAthleteButton = new System.Windows.Forms.Button();
            this.buttonRandWalkOns = new System.Windows.Forms.Button();
            this.buttonRandRecruits = new System.Windows.Forms.Button();
            this.RandomizeRecruitNamesButton = new System.Windows.Forms.Button();
            this.toleranceWalkOn = new System.Windows.Forms.NumericUpDown();
            this.buttonRandomizeFaceShape = new System.Windows.Forms.Button();
            this.wkonLabel = new System.Windows.Forms.Label();
            this.polyNames = new System.Windows.Forms.Button();
            this.recruitTolerance = new System.Windows.Forms.NumericUpDown();
            this.labelRecruit = new System.Windows.Forms.Label();
            this.textBoxOffSeason = new System.Windows.Forms.TextBox();
            this.textBoxOffSeasonTitle = new System.Windows.Forms.TextBox();
            this.tabRecruits = new System.Windows.Forms.TabPage();
            this.groupBox39 = new System.Windows.Forms.GroupBox();
            this.GTransferRecruitable = new System.Windows.Forms.RadioButton();
            this.GTransferCommitted = new System.Windows.Forms.RadioButton();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.GTransferNew = new System.Windows.Forms.ComboBox();
            this.label261 = new System.Windows.Forms.Label();
            this.GTransferOG = new System.Windows.Forms.ComboBox();
            this.label260 = new System.Windows.Forms.Label();
            this.GlobalTransferInterest = new System.Windows.Forms.Button();
            this.TransferTeam = new System.Windows.Forms.Label();
            this.RecruitPitch = new System.Windows.Forms.Label();
            this.UpdateRecruitOffers = new System.Windows.Forms.Button();
            this.label207 = new System.Windows.Forms.Label();
            this.RecruitDataGrid = new System.Windows.Forms.DataGridView();
            this.RCNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RCTeam = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RCTScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label184 = new System.Windows.Forms.Label();
            this.RDIS = new System.Windows.Forms.NumericUpDown();
            this.PosRanking = new System.Windows.Forms.Label();
            this.CommitStatus = new System.Windows.Forms.CheckBox();
            this.RecruitCounter = new System.Windows.Forms.Label();
            this.label205 = new System.Windows.Forms.Label();
            this.label204 = new System.Windows.Forms.Label();
            this.Label19084 = new System.Windows.Forms.Label();
            this.RecruitPosFilter = new System.Windows.Forms.ComboBox();
            this.RecruitStateFilter = new System.Windows.Forms.ComboBox();
            this.RecruitTypeFilter = new System.Windows.Forms.ComboBox();
            this.RCHTBox = new System.Windows.Forms.Label();
            this.RHometownBox = new System.Windows.Forms.ComboBox();
            this.RecruitStarsText = new System.Windows.Forms.Label();
            this.AthleteBox = new System.Windows.Forms.CheckBox();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.RTENBox = new System.Windows.Forms.TextBox();
            this.label183 = new System.Windows.Forms.Label();
            this.RTHAtext = new System.Windows.Forms.TextBox();
            this.RINJBox = new System.Windows.Forms.NumericUpDown();
            this.label185 = new System.Windows.Forms.Label();
            this.RKACtext = new System.Windows.Forms.TextBox();
            this.RSPDBox = new System.Windows.Forms.NumericUpDown();
            this.RKPRtext = new System.Windows.Forms.TextBox();
            this.label186 = new System.Windows.Forms.Label();
            this.RTAKtext = new System.Windows.Forms.TextBox();
            this.RACCBox = new System.Windows.Forms.NumericUpDown();
            this.RPBKtext = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.RSTRBox = new System.Windows.Forms.NumericUpDown();
            this.ROVR = new System.Windows.Forms.TextBox();
            this.RCARtext = new System.Windows.Forms.TextBox();
            this.label188 = new System.Windows.Forms.Label();
            this.RCTHtext = new System.Windows.Forms.TextBox();
            this.RBTKBox = new System.Windows.Forms.NumericUpDown();
            this.RJMPtext = new System.Windows.Forms.TextBox();
            this.label189 = new System.Windows.Forms.Label();
            this.RTHPBox = new System.Windows.Forms.NumericUpDown();
            this.label190 = new System.Windows.Forms.Label();
            this.RAGItext = new System.Windows.Forms.TextBox();
            this.RRBKBox = new System.Windows.Forms.NumericUpDown();
            this.RAWRtext = new System.Windows.Forms.TextBox();
            this.label191 = new System.Windows.Forms.Label();
            this.RPOEtext = new System.Windows.Forms.TextBox();
            this.RPOEBox = new System.Windows.Forms.NumericUpDown();
            this.RRBKtext = new System.Windows.Forms.TextBox();
            this.label192 = new System.Windows.Forms.Label();
            this.RTHPtext = new System.Windows.Forms.TextBox();
            this.RAWRBox = new System.Windows.Forms.NumericUpDown();
            this.RBTKtext = new System.Windows.Forms.TextBox();
            this.label193 = new System.Windows.Forms.Label();
            this.RSTRtext = new System.Windows.Forms.TextBox();
            this.RAGIBox = new System.Windows.Forms.NumericUpDown();
            this.RACCtext = new System.Windows.Forms.TextBox();
            this.label194 = new System.Windows.Forms.Label();
            this.label164 = new System.Windows.Forms.Label();
            this.RSPDtext = new System.Windows.Forms.TextBox();
            this.RJMPBox = new System.Windows.Forms.NumericUpDown();
            this.RINJtext = new System.Windows.Forms.TextBox();
            this.label195 = new System.Windows.Forms.Label();
            this.RCTHBox = new System.Windows.Forms.NumericUpDown();
            this.label196 = new System.Windows.Forms.Label();
            this.RCARBox = new System.Windows.Forms.NumericUpDown();
            this.label197 = new System.Windows.Forms.Label();
            this.RTHABox = new System.Windows.Forms.NumericUpDown();
            this.label198 = new System.Windows.Forms.Label();
            this.RPBKBox = new System.Windows.Forms.NumericUpDown();
            this.label199 = new System.Windows.Forms.Label();
            this.RTAKBox = new System.Windows.Forms.NumericUpDown();
            this.label200 = new System.Windows.Forms.Label();
            this.RKPRBox = new System.Windows.Forms.NumericUpDown();
            this.label201 = new System.Windows.Forms.Label();
            this.RKACBox = new System.Windows.Forms.NumericUpDown();
            this.label202 = new System.Windows.Forms.Label();
            this.PRIDBox = new System.Windows.Forms.TextBox();
            this.PLNABox = new System.Windows.Forms.TextBox();
            this.PFNABox = new System.Windows.Forms.TextBox();
            this.label182 = new System.Windows.Forms.Label();
            this.RecruitListBox = new System.Windows.Forms.ListBox();
            this.label154 = new System.Windows.Forms.Label();
            this.RStateBox = new System.Windows.Forms.ComboBox();
            this.label155 = new System.Windows.Forms.Label();
            this.RYER = new System.Windows.Forms.ComboBox();
            this.label156 = new System.Windows.Forms.Label();
            this.RWGTBox = new System.Windows.Forms.NumericUpDown();
            this.label157 = new System.Windows.Forms.Label();
            this.RHGTBox = new System.Windows.Forms.NumericUpDown();
            this.label158 = new System.Windows.Forms.Label();
            this.RHEDBox = new System.Windows.Forms.ComboBox();
            this.label159 = new System.Windows.Forms.Label();
            this.RHCLBox = new System.Windows.Forms.ComboBox();
            this.label160 = new System.Windows.Forms.Label();
            this.RFMPBox = new System.Windows.Forms.ComboBox();
            this.label161 = new System.Windows.Forms.Label();
            this.RFGMBox = new System.Windows.Forms.ComboBox();
            this.label162 = new System.Windows.Forms.Label();
            this.RSKIBox = new System.Windows.Forms.ComboBox();
            this.label163 = new System.Windows.Forms.Label();
            this.RPPOSBox = new System.Windows.Forms.ComboBox();
            this.label165 = new System.Windows.Forms.Label();
            this.label166 = new System.Windows.Forms.Label();
            this.tabStats = new System.Windows.Forms.TabPage();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.label221 = new System.Windows.Forms.Label();
            this.SacksLeadersBox = new System.Windows.Forms.ListBox();
            this.IntLeadersBox = new System.Windows.Forms.ListBox();
            this.label223 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.TacklesLeadersBox = new System.Windows.Forms.ListBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label220 = new System.Windows.Forms.Label();
            this.ReceivingLeadersBox = new System.Windows.Forms.ListBox();
            this.label219 = new System.Windows.Forms.Label();
            this.RushingLeadersBox = new System.Windows.Forms.ListBox();
            this.label218 = new System.Windows.Forms.Label();
            this.PassingLeadersBox = new System.Windows.Forms.ListBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label217 = new System.Windows.Forms.Label();
            this.label216 = new System.Windows.Forms.Label();
            this.label215 = new System.Windows.Forms.Label();
            this.label214 = new System.Windows.Forms.Label();
            this.TopTeamDefBox = new System.Windows.Forms.ListBox();
            this.TopTeamOffBox = new System.Windows.Forms.ListBox();
            this.TopTeamRatingsBox = new System.Windows.Forms.ListBox();
            this.CoachPollListBox = new System.Windows.Forms.ListBox();
            this.tabStadiums = new System.Windows.Forms.TabPage();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.GrassToTurf = new System.Windows.Forms.Button();
            this.GlobalWeather = new System.Windows.Forms.Button();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.label241 = new System.Windows.Forms.Label();
            this.STtvBox = new System.Windows.Forms.NumericUpDown();
            this.label235 = new System.Windows.Forms.Label();
            this.SWSPBox = new System.Windows.Forms.NumericUpDown();
            this.label236 = new System.Windows.Forms.Label();
            this.SWRPBox = new System.Windows.Forms.NumericUpDown();
            this.label233 = new System.Windows.Forms.Label();
            this.SWWPBox = new System.Windows.Forms.NumericUpDown();
            this.label234 = new System.Windows.Forms.Label();
            this.SWFPBox = new System.Windows.Forms.NumericUpDown();
            this.label231 = new System.Windows.Forms.Label();
            this.STfwBox = new System.Windows.Forms.NumericUpDown();
            this.label232 = new System.Windows.Forms.Label();
            this.STwpBox = new System.Windows.Forms.NumericUpDown();
            this.label230 = new System.Windows.Forms.Label();
            this.STjtBox = new System.Windows.Forms.NumericUpDown();
            this.label229 = new System.Windows.Forms.Label();
            this.STtsBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.label239 = new System.Windows.Forms.Label();
            this.STADSFTYBox = new System.Windows.Forms.ComboBox();
            this.STADState = new System.Windows.Forms.ComboBox();
            this.STADCity = new System.Windows.Forms.TextBox();
            this.label237 = new System.Windows.Forms.Label();
            this.label238 = new System.Windows.Forms.Label();
            this.label240 = new System.Windows.Forms.Label();
            this.STADCap = new System.Windows.Forms.NumericUpDown();
            this.STADNickBox = new System.Windows.Forms.TextBox();
            this.STADNameBox = new System.Windows.Forms.TextBox();
            this.labelstadnickname = new System.Windows.Forms.Label();
            this.labelstadname = new System.Windows.Forms.Label();
            this.STADrank = new System.Windows.Forms.Label();
            this.STADSTDR = new System.Windows.Forms.TextBox();
            this.STADTDNA = new System.Windows.Forms.TextBox();
            this.STADResBox = new System.Windows.Forms.TextBox();
            this.STADsgidBox = new System.Windows.Forms.TextBox();
            this.label228 = new System.Windows.Forms.Label();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.STADType = new System.Windows.Forms.CheckBox();
            this.STADCannon = new System.Windows.Forms.CheckBox();
            this.STADVisbility = new System.Windows.Forms.CheckBox();
            this.STADcat = new System.Windows.Forms.CheckBox();
            this.label227 = new System.Windows.Forms.Label();
            this.label226 = new System.Windows.Forms.Label();
            this.label225 = new System.Windows.Forms.Label();
            this.StadiumListBox = new System.Windows.Forms.ListBox();
            this.tabBowls = new System.Windows.Forms.TabPage();
            this.SaveBowlButton = new System.Windows.Forms.Button();
            this.BowlsGrid = new System.Windows.Forms.DataGridView();
            this.ActiveBowl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BIDX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BNME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamA = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ScoreA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TeamB = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SGID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BMON = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BDAY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SEWN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabConf = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.ConfDisplayRanking = new System.Windows.Forms.RadioButton();
            this.ConfDisplayRating = new System.Windows.Forms.RadioButton();
            this.ConfDisplayPrestige = new System.Windows.Forms.RadioButton();
            this.ConfDisplayTeam = new System.Windows.Forms.RadioButton();
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
            this.tabDepthCharts = new System.Windows.Forms.TabPage();
            this.groupBox40 = new System.Windows.Forms.GroupBox();
            this.DC136 = new System.Windows.Forms.RadioButton();
            this.DC120 = new System.Windows.Forms.RadioButton();
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
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.label213 = new System.Windows.Forms.Label();
            this.MatchView = new System.Windows.Forms.DataGridView();
            this.RatingCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchHomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchAwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDrecord = new System.Windows.Forms.Label();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.RescheduleOOC = new System.Windows.Forms.Button();
            this.label212 = new System.Windows.Forms.Label();
            this.SchdTeamName = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.SCHDTeamBox = new System.Windows.Forms.ListBox();
            this.ScheduleView = new System.Windows.Forms.DataGridView();
            this.SCHDWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDHOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDScoreH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDVS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDAWAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCHDScoreA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSeason = new System.Windows.Forms.TabPage();
            this.groupBox36 = new System.Windows.Forms.GroupBox();
            this.medRS = new System.Windows.Forms.Button();
            this.skillDrop = new System.Windows.Forms.NumericUpDown();
            this.checkBoxInjuryRatings = new System.Windows.Forms.CheckBox();
            this.labelSkillDrop = new System.Windows.Forms.Label();
            this.groupBox35 = new System.Windows.Forms.GroupBox();
            this.buttonPSInjuries = new System.Windows.Forms.Button();
            this.labelMaxSkilDrop_PS = new System.Windows.Forms.Label();
            this.numInjuries = new System.Windows.Forms.NumericUpDown();
            this.labelPSInjuries = new System.Windows.Forms.Label();
            this.MaxSkillDropPS = new System.Windows.Forms.NumericUpDown();
            this.TransferPortalStats = new System.Windows.Forms.Button();
            this.RemoveBadTransfers = new System.Windows.Forms.Button();
            this.RemoveSanctionsButton = new System.Windows.Forms.Button();
            this.label180 = new System.Windows.Forms.Label();
            this.ImpactPlayerMin = new System.Windows.Forms.NumericUpDown();
            this.buttonImpactPlayers = new System.Windows.Forms.Button();
            this.BodyProgressionButton = new System.Windows.Forms.Button();
            this.buttonRealignment = new System.Windows.Forms.Button();
            this.dbToolsInfo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox37 = new System.Windows.Forms.GroupBox();
            this.CoachFiringsCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.CarouselDataGrid = new System.Windows.Forms.DataGridView();
            this.CCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCTmPrestige = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCPrestige = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCarousel = new System.Windows.Forms.Button();
            this.maxFiredTransfers = new System.Windows.Forms.NumericUpDown();
            this.labelMaxTransfers = new System.Windows.Forms.Label();
            this.poachValue = new System.Windows.Forms.NumericUpDown();
            this.jobSecurityValue = new System.Windows.Forms.NumericUpDown();
            this.labelJobSecurity = new System.Windows.Forms.Label();
            this.labelPoaching = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxFiredTransfers = new System.Windows.Forms.CheckBox();
            this.numberPlayerCoach = new System.Windows.Forms.NumericUpDown();
            this.buttonPlayerCoach = new System.Windows.Forms.Button();
            this.tabCoaches = new System.Windows.Forms.TabPage();
            this.CoachPerfCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label179 = new System.Windows.Forms.Label();
            this.YearsWithTeam = new System.Windows.Forms.Label();
            this.label177 = new System.Windows.Forms.Label();
            this.ConfTitles = new System.Windows.Forms.Label();
            this.LabelNT = new System.Windows.Forms.Label();
            this.NationalTitles = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.ContractInfo = new System.Windows.Forms.Label();
            this.label175 = new System.Windows.Forms.Label();
            this.CoachTeamPrestige = new System.Windows.Forms.Label();
            this.label174 = new System.Windows.Forms.Label();
            this.Top25Record = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.WinningSeasons = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.BowlRecord = new System.Windows.Forms.Label();
            this.label131 = new System.Windows.Forms.Label();
            this.YearsCoached = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.CareerRecord = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.SeasonRecord = new System.Windows.Forms.Label();
            this.CoachCCPONum = new System.Windows.Forms.NumericUpDown();
            this.label141 = new System.Windows.Forms.Label();
            this.HCPrestigeNum = new System.Windows.Forms.NumericUpDown();
            this.label146 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.AutoAdjustBudgetsButton = new System.Windows.Forms.Button();
            this.label178 = new System.Windows.Forms.Label();
            this.coachProg = new System.Windows.Forms.Button();
            this.CoachPrestigeButton = new System.Windows.Forms.Button();
            this.buttonRandomBudgets = new System.Windows.Forms.Button();
            this.SetMaxCoachCCPO = new System.Windows.Forms.Button();
            this.MaxCCPOVal = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.DisciplineAssistanceBox = new System.Windows.Forms.CheckBox();
            this.RecruitAssistanceBox = new System.Windows.Forms.CheckBox();
            this.NewCoachButton = new System.Windows.Forms.Button();
            this.label130 = new System.Windows.Forms.Label();
            this.label129 = new System.Windows.Forms.Label();
            this.CoachTeamList = new System.Windows.Forms.ComboBox();
            this.CSKIBox = new System.Windows.Forms.ComboBox();
            this.label98 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.CFUCBox = new System.Windows.Forms.CheckBox();
            this.CBSZBox = new System.Windows.Forms.ComboBox();
            this.label96 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.COHTBox = new System.Windows.Forms.ComboBox();
            this.CFEXBox = new System.Windows.Forms.ComboBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.CTgwBox = new System.Windows.Forms.ComboBox();
            this.CHARBox = new System.Windows.Forms.ComboBox();
            this.label102 = new System.Windows.Forms.Label();
            this.CTHGBox = new System.Windows.Forms.ComboBox();
            this.CoachPlaybookBox = new System.Windows.Forms.ComboBox();
            this.label101 = new System.Windows.Forms.Label();
            this.CoachDefTypeBox = new System.Windows.Forms.ComboBox();
            this.label94 = new System.Windows.Forms.Label();
            this.CoachOffTypeBox = new System.Windows.Forms.ComboBox();
            this.CoachFirstNameBox = new System.Windows.Forms.TextBox();
            this.CoachCDTSBox = new System.Windows.Forms.NumericUpDown();
            this.CoachLastNameBox = new System.Windows.Forms.TextBox();
            this.label132 = new System.Windows.Forms.Label();
            this.CCIDBox = new System.Windows.Forms.TextBox();
            this.CoachCDTABox = new System.Windows.Forms.NumericUpDown();
            this.CoachDisciplineBox = new System.Windows.Forms.TextBox();
            this.CoachCDTRBox = new System.Windows.Forms.NumericUpDown();
            this.label145 = new System.Windows.Forms.Label();
            this.label133 = new System.Windows.Forms.Label();
            this.label144 = new System.Windows.Forms.Label();
            this.label134 = new System.Windows.Forms.Label();
            this.label143 = new System.Windows.Forms.Label();
            this.CoachCOTSBox = new System.Windows.Forms.NumericUpDown();
            this.label142 = new System.Windows.Forms.Label();
            this.label135 = new System.Windows.Forms.Label();
            this.CoachTrainingBox = new System.Windows.Forms.NumericUpDown();
            this.CoachCOTABox = new System.Windows.Forms.NumericUpDown();
            this.CoachRecruitingBox = new System.Windows.Forms.NumericUpDown();
            this.CoachCOTRBox = new System.Windows.Forms.NumericUpDown();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.label138 = new System.Windows.Forms.Label();
            this.label140 = new System.Windows.Forms.Label();
            this.label139 = new System.Windows.Forms.Label();
            this.CoachShowTeamBox = new System.Windows.Forms.CheckBox();
            this.label95 = new System.Windows.Forms.Label();
            this.CoachFilter = new System.Windows.Forms.ComboBox();
            this.CoachListBox = new System.Windows.Forms.ListBox();
            this.tabPlayers = new System.Windows.Forms.TabPage();
            this.label206 = new System.Windows.Forms.Label();
            this.PDIS = new System.Windows.Forms.NumericUpDown();
            this.label153 = new System.Windows.Forms.Label();
            this.PHometownBox = new System.Windows.Forms.ComboBox();
            this.label203 = new System.Windows.Forms.Label();
            this.PStateBox = new System.Windows.Forms.ComboBox();
            this.ResetPlayerPOSbutton = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.PTEN = new System.Windows.Forms.TextBox();
            this.label173 = new System.Windows.Forms.Label();
            this.PTHAtext = new System.Windows.Forms.TextBox();
            this.PIMPBox = new System.Windows.Forms.NumericUpDown();
            this.label63 = new System.Windows.Forms.Label();
            this.PINJBox = new System.Windows.Forms.NumericUpDown();
            this.label64 = new System.Windows.Forms.Label();
            this.PKACtext = new System.Windows.Forms.TextBox();
            this.PSPDBox = new System.Windows.Forms.NumericUpDown();
            this.PKPRtext = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.PTAKtext = new System.Windows.Forms.TextBox();
            this.PACCBox = new System.Windows.Forms.NumericUpDown();
            this.PPBKtext = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.PSTRBox = new System.Windows.Forms.NumericUpDown();
            this.PCARtext = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.PCTHtext = new System.Windows.Forms.TextBox();
            this.PBTKBox = new System.Windows.Forms.NumericUpDown();
            this.PJMPtext = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.PTHPBox = new System.Windows.Forms.NumericUpDown();
            this.label68 = new System.Windows.Forms.Label();
            this.PAGItext = new System.Windows.Forms.TextBox();
            this.PRBKBox = new System.Windows.Forms.NumericUpDown();
            this.PAWRtext = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.PPOEtext = new System.Windows.Forms.TextBox();
            this.PPOEBox = new System.Windows.Forms.NumericUpDown();
            this.PRBKtext = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.PTHPtext = new System.Windows.Forms.TextBox();
            this.PAWRBox = new System.Windows.Forms.NumericUpDown();
            this.PBTKtext = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.PSTRtext = new System.Windows.Forms.TextBox();
            this.PAGIBox = new System.Windows.Forms.NumericUpDown();
            this.PACCtext = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.PSPDtext = new System.Windows.Forms.TextBox();
            this.PJMPBox = new System.Windows.Forms.NumericUpDown();
            this.PINJtext = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.PIMPtext = new System.Windows.Forms.TextBox();
            this.PCTHBox = new System.Windows.Forms.NumericUpDown();
            this.label74 = new System.Windows.Forms.Label();
            this.PCARBox = new System.Windows.Forms.NumericUpDown();
            this.label73 = new System.Windows.Forms.Label();
            this.PTHABox = new System.Windows.Forms.NumericUpDown();
            this.label72 = new System.Windows.Forms.Label();
            this.PPBKBox = new System.Windows.Forms.NumericUpDown();
            this.label71 = new System.Windows.Forms.Label();
            this.PTAKBox = new System.Windows.Forms.NumericUpDown();
            this.label82 = new System.Windows.Forms.Label();
            this.PKPRBox = new System.Windows.Forms.NumericUpDown();
            this.label81 = new System.Windows.Forms.Label();
            this.PKACBox = new System.Windows.Forms.NumericUpDown();
            this.label79 = new System.Windows.Forms.Label();
            this.ImportPlayerTeam = new System.Windows.Forms.Button();
            this.AWHRBox = new System.Windows.Forms.CheckBox();
            this.PlayerTransferButton = new System.Windows.Forms.Button();
            this.ExportPlayerTeam = new System.Windows.Forms.Button();
            this.label167 = new System.Windows.Forms.Label();
            this.playerTeamBox = new System.Windows.Forms.TextBox();
            this.PRST = new System.Windows.Forms.TextBox();
            this.PGIDbox = new System.Windows.Forms.TextBox();
            this.POVRbox = new System.Windows.Forms.TextBox();
            this.PLNAtextBox = new System.Windows.Forms.TextBox();
            this.PFNAtextBox = new System.Windows.Forms.TextBox();
            this.PPOSBox = new System.Windows.Forms.ComboBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label151 = new System.Windows.Forms.Label();
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
            this.label61 = new System.Windows.Forms.Label();
            this.RosterSizeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TGIDplayerBox = new System.Windows.Forms.ComboBox();
            this.PGIDlistBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label120 = new System.Windows.Forms.Label();
            this.LeftWrist = new System.Windows.Forms.ComboBox();
            this.LeftHand = new System.Windows.Forms.ComboBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.LeftElbow = new System.Windows.Forms.ComboBox();
            this.RightShoe = new System.Windows.Forms.ComboBox();
            this.label126 = new System.Windows.Forms.Label();
            this.LeftShoe = new System.Windows.Forms.ComboBox();
            this.label116 = new System.Windows.Forms.Label();
            this.NasalStrip = new System.Windows.Forms.ComboBox();
            this.label150 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.Helmet = new System.Windows.Forms.ComboBox();
            this.label149 = new System.Windows.Forms.Label();
            this.Sleeves = new System.Windows.Forms.ComboBox();
            this.label148 = new System.Windows.Forms.Label();
            this.Facemask = new System.Windows.Forms.ComboBox();
            this.label127 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.RightElbow = new System.Windows.Forms.ComboBox();
            this.label121 = new System.Windows.Forms.Label();
            this.label128 = new System.Windows.Forms.Label();
            this.SleeveColor = new System.Windows.Forms.ComboBox();
            this.RightWrist = new System.Windows.Forms.ComboBox();
            this.EyeBlack = new System.Windows.Forms.ComboBox();
            this.label147 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.RightHand = new System.Windows.Forms.ComboBox();
            this.Visor = new System.Windows.Forms.ComboBox();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.NeckPad = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabTeams = new System.Windows.Forms.TabPage();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.TeamShowNormal = new System.Windows.Forms.RadioButton();
            this.TeamShowRanking = new System.Windows.Forms.RadioButton();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.GenerateNewRosterButton = new System.Windows.Forms.Button();
            this.DeathPenaltyButton = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.TeamSTRating = new System.Windows.Forms.TextBox();
            this.label210 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.TeamDefRating = new System.Windows.Forms.TextBox();
            this.SDURnumbox = new System.Windows.Forms.NumericUpDown();
            this.label209 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.TeamOffRating = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label208 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.CoachPollBox = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.SeasonRecordBox = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.APPollBox = new System.Windows.Forms.TextBox();
            this.TMPRNumBox = new System.Windows.Forms.NumericUpDown();
            this.ConfRecordBox = new System.Windows.Forms.TextBox();
            this.TMARNumBox = new System.Windows.Forms.NumericUpDown();
            this.INPOnumbox = new System.Windows.Forms.NumericUpDown();
            this.TeamOVRtextbox = new System.Windows.Forms.TextBox();
            this.NCDPnumbox = new System.Windows.Forms.NumericUpDown();
            this.SNCTnumbox = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.TeamColor2Button = new System.Windows.Forms.Button();
            this.TeamColor1Button = new System.Windows.Forms.Button();
            this.ResetPrimaryColorButton = new System.Windows.Forms.Button();
            this.ResetSecondaryColorButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.CheerleaderBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CrowdBox = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label224 = new System.Windows.Forms.Label();
            this.TeamStadRank = new System.Windows.Forms.TextBox();
            this.StateBox = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.stadiumNameBox = new System.Windows.Forms.TextBox();
            this.CityNameBox = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.AttendanceNumBox = new System.Windows.Forms.NumericUpDown();
            this.CapacityNumbox = new System.Windows.Forms.NumericUpDown();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.TeamAutoImpact = new System.Windows.Forms.Button();
            this.ImpactTSI1Select = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CaptainOffSelectBox = new System.Windows.Forms.ComboBox();
            this.CaptainDefSelectBox = new System.Windows.Forms.ComboBox();
            this.ImpactTSI2Select = new System.Windows.Forms.ComboBox();
            this.ResetImpactPlayersButton = new System.Windows.Forms.Button();
            this.ImpactTPIOSelect = new System.Windows.Forms.ComboBox();
            this.TeamRosterSizeLabel = new System.Windows.Forms.Label();
            this.ImpactTPIDSelect = new System.Windows.Forms.ComboBox();
            this.TeamSetDepthChart = new System.Windows.Forms.Button();
            this.LeagueBox = new System.Windows.Forms.TextBox();
            this.TSNAtextBox = new System.Windows.Forms.TextBox();
            this.TeamDivisionBox = new System.Windows.Forms.TextBox();
            this.TeamConferenceBox = new System.Windows.Forms.TextBox();
            this.TGIDtextBox = new System.Windows.Forms.TextBox();
            this.TMNAtextBox = new System.Windows.Forms.TextBox();
            this.TDNAtextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LGIDcomboBox = new System.Windows.Forms.ComboBox();
            this.TGIDlistBox = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.UserCoachCheckBox = new System.Windows.Forms.CheckBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.TeamCTPCNumber = new System.Windows.Forms.NumericUpDown();
            this.TeamCRPCNumber = new System.Windows.Forms.NumericUpDown();
            this.TeamHCPrestigeNumBox = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
            this.TeamCCPONumBox = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.PlaybookSelectBox = new System.Windows.Forms.ComboBox();
            this.label48 = new System.Windows.Forms.Label();
            this.DefTypeSelectBox = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            this.OffTypeSelectBox = new System.Windows.Forms.ComboBox();
            this.TeamCOTRbox = new System.Windows.Forms.NumericUpDown();
            this.TeamCOTAbox = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.TeamCOTSbox = new System.Windows.Forms.NumericUpDown();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.TeamCDTRbox = new System.Windows.Forms.NumericUpDown();
            this.TeamCDTAbox = new System.Windows.Forms.NumericUpDown();
            this.label50 = new System.Windows.Forms.Label();
            this.TeamCDTSbox = new System.Windows.Forms.NumericUpDown();
            this.TeamCDPCBox = new System.Windows.Forms.TextBox();
            this.FireCoachButton = new System.Windows.Forms.Button();
            this.HCLastNameBox = new System.Windows.Forms.TextBox();
            this.HCFirstNameBox = new System.Windows.Forms.TextBox();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.fieldsGridView = new System.Windows.Forms.DataGridView();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OGConfigRadio = new System.Windows.Forms.RadioButton();
            this.NextConfigRadio = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPortal = new System.Windows.Forms.TabPage();
            this.PortalRatingBoost = new System.Windows.Forms.CheckBox();
            this.TransferEligible = new System.Windows.Forms.CheckBox();
            this.TotalTransfersCount = new System.Windows.Forms.Label();
            this.PortalData = new System.Windows.Forms.DataGridView();
            this.PortalPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortalTransferName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortalClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortalRating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortalNewSchool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PortalPrvTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PortalTransfers = new System.Windows.Forms.CheckBox();
            this.portalChance = new System.Windows.Forms.NumericUpDown();
            this.label259 = new System.Windows.Forms.Label();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.largePortal = new System.Windows.Forms.RadioButton();
            this.smallPortal = new System.Windows.Forms.RadioButton();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.PortalK = new System.Windows.Forms.NumericUpDown();
            this.label258 = new System.Windows.Forms.Label();
            this.PortalP = new System.Windows.Forms.NumericUpDown();
            this.label250 = new System.Windows.Forms.Label();
            this.PortalSS = new System.Windows.Forms.NumericUpDown();
            this.label251 = new System.Windows.Forms.Label();
            this.PortalFS = new System.Windows.Forms.NumericUpDown();
            this.label252 = new System.Windows.Forms.Label();
            this.PortalCB = new System.Windows.Forms.NumericUpDown();
            this.label253 = new System.Windows.Forms.Label();
            this.PortalMLB = new System.Windows.Forms.NumericUpDown();
            this.label254 = new System.Windows.Forms.Label();
            this.PortalOLB = new System.Windows.Forms.NumericUpDown();
            this.label255 = new System.Windows.Forms.Label();
            this.PortalDT = new System.Windows.Forms.NumericUpDown();
            this.label256 = new System.Windows.Forms.Label();
            this.PortalDE = new System.Windows.Forms.NumericUpDown();
            this.label257 = new System.Windows.Forms.Label();
            this.PortalOC = new System.Windows.Forms.NumericUpDown();
            this.label249 = new System.Windows.Forms.Label();
            this.PortalOG = new System.Windows.Forms.NumericUpDown();
            this.label248 = new System.Windows.Forms.Label();
            this.PortalOT = new System.Windows.Forms.NumericUpDown();
            this.label247 = new System.Windows.Forms.Label();
            this.PortalTE = new System.Windows.Forms.NumericUpDown();
            this.label246 = new System.Windows.Forms.Label();
            this.PortalWR = new System.Windows.Forms.NumericUpDown();
            this.label245 = new System.Windows.Forms.Label();
            this.PortalFB = new System.Windows.Forms.NumericUpDown();
            this.label244 = new System.Windows.Forms.Label();
            this.PortalHB = new System.Windows.Forms.NumericUpDown();
            this.label243 = new System.Windows.Forms.Label();
            this.PortalQB = new System.Windows.Forms.NumericUpDown();
            this.label242 = new System.Windows.Forms.Label();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.PortalSnake = new System.Windows.Forms.RadioButton();
            this.PortalRandom = new System.Windows.Forms.RadioButton();
            this.PortalFirst = new System.Windows.Forms.RadioButton();
            this.PortalReverse = new System.Windows.Forms.RadioButton();
            this.SpringPortalButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            qbTend = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.fieldMenu.SuspendLayout();
            this.TablePropsgroupBox.SuspendLayout();
            this.FieldsPropsgroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDev.SuspendLayout();
            this.tabUniforms.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UniformGrid)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPlaybook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayNameValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrtNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaybookGrid)).BeginInit();
            this.groupBox19.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.groupBox38.SuspendLayout();
            this.FantastyRosterLeague.SuspendLayout();
            this.DepthChartSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFantasyPlayers)).BeginInit();
            this.groupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).BeginInit();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBodyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBodyValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAttNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalAttNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAttNum)).BeginInit();
            this.tabOffSeason.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).BeginInit();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).BeginInit();
            this.tabRecruits.SuspendLayout();
            this.groupBox39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecruitDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDIS)).BeginInit();
            this.groupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RINJBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSPDBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RACCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBTKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTHPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPOEBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAWRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAGIBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RJMPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RCTHBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RCARBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTHABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTAKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RKPRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RKACBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RWGTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHGTBox)).BeginInit();
            this.tabStats.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.tabStadiums.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STtvBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWSPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWRPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWWPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWFPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STfwBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STwpBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STjtBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STtsBox)).BeginInit();
            this.groupBox28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STADCap)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.tabBowls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BowlsGrid)).BeginInit();
            this.tabConf.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.tabDepthCharts.SuspendLayout();
            this.groupBox40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCHTGrid)).BeginInit();
            this.tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchView)).BeginInit();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleView)).BeginInit();
            this.tabSeason.SuspendLayout();
            this.groupBox36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).BeginInit();
            this.groupBox35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpactPlayerMin)).BeginInit();
            this.groupBox37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarouselDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).BeginInit();
            this.tabCoaches.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCCPONum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HCPrestigeNum)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCCPOVal)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTSBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachTrainingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachRecruitingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTRBox)).BeginInit();
            this.tabPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDIS)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIMPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINJBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSPDBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PACCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSTRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPOEBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAWRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGIBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJMPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCTHBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCARBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHABox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTAKBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKPRBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKACBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PWGTBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHGTBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabTeams.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SDURnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMPRNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMARNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.INPOnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCDPnumbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNCTnumbox)).BeginInit();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNumbox)).BeginInit();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCTPCNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCRPCNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamHCPrestigeNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCCPONumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTRbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTAbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTSbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTRbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTAbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTSbox)).BeginInit();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).BeginInit();
            this.tabHome.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPortal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portalChance)).BeginInit();
            this.groupBox33.SuspendLayout();
            this.groupBox32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortalK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalSS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalFS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalMLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOLB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalTE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalWR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalFB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalHB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalQB)).BeginInit();
            this.groupBox31.SuspendLayout();
            this.SuspendLayout();
            // 
            // qbTend
            // 
            qbTend.BackColor = System.Drawing.SystemColors.MenuHighlight;
            qbTend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            qbTend.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            qbTend.Location = new System.Drawing.Point(259, 392);
            qbTend.Name = "qbTend";
            qbTend.Size = new System.Drawing.Size(145, 80);
            qbTend.TabIndex = 11;
            qbTend.Text = "Calculate QB Tendencies";
            qbTend.UseVisualStyleBackColor = false;
            qbTend.Click += new System.EventHandler(this.QB_Tend_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
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
            this.NCAANextConfig});
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
            this.tableFieldOrderMenuItem.Size = new System.Drawing.Size(226, 34);
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
            this.definitionFileMenuItem.Size = new System.Drawing.Size(226, 34);
            this.definitionFileMenuItem.Text = "Definition File";
            this.definitionFileMenuItem.Click += new System.EventHandler(this.DefinitionFileMenuItem_Click);
            // 
            // NCAANextConfig
            // 
            this.NCAANextConfig.Name = "NCAANextConfig";
            this.NCAANextConfig.Size = new System.Drawing.Size(226, 34);
            this.NCAANextConfig.Text = "Use NCAA NEXT Config";
            this.NCAANextConfig.Click += new System.EventHandler(this.NCAANext25Config_Click);
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
            this.tableMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.tableMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportTableMenuItem,
            this.importTableMenuItem,
            this.toolStripSeparator3,
            this.exportAllTableMenuItem});
            this.tableMenu.Name = "tableMenu";
            this.tableMenu.Size = new System.Drawing.Size(142, 76);
            // 
            // exportTableMenuItem
            // 
            this.exportTableMenuItem.Name = "exportTableMenuItem";
            this.exportTableMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exportTableMenuItem.Text = "Export Table";
            this.exportTableMenuItem.Click += new System.EventHandler(this.exportTableMenuItem_Click);
            // 
            // importTableMenuItem
            // 
            this.importTableMenuItem.Name = "importTableMenuItem";
            this.importTableMenuItem.Size = new System.Drawing.Size(141, 22);
            this.importTableMenuItem.Text = "Import Table";
            this.importTableMenuItem.Click += new System.EventHandler(this.importTableMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(138, 6);
            // 
            // exportAllTableMenuItem
            // 
            this.exportAllTableMenuItem.Name = "exportAllTableMenuItem";
            this.exportAllTableMenuItem.Size = new System.Drawing.Size(141, 22);
            this.exportAllTableMenuItem.Text = "Export All";
            this.exportAllTableMenuItem.Click += new System.EventHandler(this.exportAllTableMenuItem_Click);
            // 
            // fieldMenu
            // 
            this.fieldMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
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
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
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
            // tabDev
            // 
            this.tabDev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabDev.Controls.Add(this.CFUSAexportButton);
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
            // CFUSAexportButton
            // 
            this.CFUSAexportButton.BackColor = System.Drawing.Color.Pink;
            this.CFUSAexportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFUSAexportButton.Location = new System.Drawing.Point(1003, 196);
            this.CFUSAexportButton.Name = "CFUSAexportButton";
            this.CFUSAexportButton.Size = new System.Drawing.Size(110, 80);
            this.CFUSAexportButton.TabIndex = 50;
            this.CFUSAexportButton.Text = "Export to CFB USA 97";
            this.CFUSAexportButton.UseVisualStyleBackColor = false;
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
            // tabUniforms
            // 
            this.tabUniforms.Controls.Add(this.ImportTeamUNIF);
            this.tabUniforms.Controls.Add(this.ExportTeamUNIF);
            this.tabUniforms.Controls.Add(this.label172);
            this.tabUniforms.Controls.Add(this.UpdateUNIFButton);
            this.tabUniforms.Controls.Add(this.groupBox5);
            this.tabUniforms.Controls.Add(this.UniformGrid);
            this.tabUniforms.Controls.Add(this.groupBox4);
            this.tabUniforms.Location = new System.Drawing.Point(4, 24);
            this.tabUniforms.Name = "tabUniforms";
            this.tabUniforms.Padding = new System.Windows.Forms.Padding(3);
            this.tabUniforms.Size = new System.Drawing.Size(1152, 615);
            this.tabUniforms.TabIndex = 13;
            this.tabUniforms.Text = "Uniforms";
            this.tabUniforms.UseVisualStyleBackColor = true;
            // 
            // ImportTeamUNIF
            // 
            this.ImportTeamUNIF.BackColor = System.Drawing.SystemColors.Info;
            this.ImportTeamUNIF.Location = new System.Drawing.Point(1014, 232);
            this.ImportTeamUNIF.Name = "ImportTeamUNIF";
            this.ImportTeamUNIF.Size = new System.Drawing.Size(125, 50);
            this.ImportTeamUNIF.TabIndex = 10;
            this.ImportTeamUNIF.Text = "Import Team";
            this.ImportTeamUNIF.UseVisualStyleBackColor = false;
            this.ImportTeamUNIF.Click += new System.EventHandler(this.ImportTeamUNIF_Click);
            // 
            // ExportTeamUNIF
            // 
            this.ExportTeamUNIF.BackColor = System.Drawing.SystemColors.Info;
            this.ExportTeamUNIF.Location = new System.Drawing.Point(848, 232);
            this.ExportTeamUNIF.Name = "ExportTeamUNIF";
            this.ExportTeamUNIF.Size = new System.Drawing.Size(125, 50);
            this.ExportTeamUNIF.TabIndex = 9;
            this.ExportTeamUNIF.Text = "Export Team";
            this.ExportTeamUNIF.UseVisualStyleBackColor = false;
            this.ExportTeamUNIF.Click += new System.EventHandler(this.ExportTeamUNIF_Click);
            // 
            // label172
            // 
            this.label172.AutoSize = true;
            this.label172.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label172.Location = new System.Drawing.Point(872, 15);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(248, 24);
            this.label172.TabIndex = 8;
            this.label172.Text = "Uniform Expansion Editor";
            // 
            // UpdateUNIFButton
            // 
            this.UpdateUNIFButton.BackColor = System.Drawing.Color.Crimson;
            this.UpdateUNIFButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateUNIFButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.UpdateUNIFButton.Location = new System.Drawing.Point(846, 342);
            this.UpdateUNIFButton.Name = "UpdateUNIFButton";
            this.UpdateUNIFButton.Size = new System.Drawing.Size(293, 67);
            this.UpdateUNIFButton.TabIndex = 6;
            this.UpdateUNIFButton.Text = "Update Database";
            this.UpdateUNIFButton.UseVisualStyleBackColor = false;
            this.UpdateUNIFButton.Click += new System.EventHandler(this.UpdateUNIFButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label170);
            this.groupBox5.Controls.Add(this.GlobalAltCheck);
            this.groupBox5.Controls.Add(this.GlobalPrimaryCheck);
            this.groupBox5.Controls.Add(this.GlobalUniFilter);
            this.groupBox5.Controls.Add(this.label171);
            this.groupBox5.Location = new System.Drawing.Point(846, 451);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(293, 148);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Global Editor";
            // 
            // label170
            // 
            this.label170.AutoSize = true;
            this.label170.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label170.Location = new System.Drawing.Point(36, 69);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(109, 15);
            this.label170.TabIndex = 5;
            this.label170.Text = "Quick Functions";
            // 
            // GlobalAltCheck
            // 
            this.GlobalAltCheck.AutoSize = true;
            this.GlobalAltCheck.Location = new System.Drawing.Point(56, 110);
            this.GlobalAltCheck.Name = "GlobalAltCheck";
            this.GlobalAltCheck.Size = new System.Drawing.Size(162, 17);
            this.GlobalAltCheck.TabIndex = 4;
            this.GlobalAltCheck.Text = "Enable All Alternate Uniforms";
            this.GlobalAltCheck.UseVisualStyleBackColor = true;
            this.GlobalAltCheck.CheckedChanged += new System.EventHandler(this.GlobalAltCheck_CheckedChanged);
            // 
            // GlobalPrimaryCheck
            // 
            this.GlobalPrimaryCheck.AutoSize = true;
            this.GlobalPrimaryCheck.Location = new System.Drawing.Point(56, 87);
            this.GlobalPrimaryCheck.Name = "GlobalPrimaryCheck";
            this.GlobalPrimaryCheck.Size = new System.Drawing.Size(165, 17);
            this.GlobalPrimaryCheck.TabIndex = 3;
            this.GlobalPrimaryCheck.Text = "Enable Home/Away Uniforms";
            this.GlobalPrimaryCheck.UseVisualStyleBackColor = true;
            this.GlobalPrimaryCheck.CheckedChanged += new System.EventHandler(this.GlobalPrimaryCheck_CheckedChanged);
            // 
            // GlobalUniFilter
            // 
            this.GlobalUniFilter.FormattingEnabled = true;
            this.GlobalUniFilter.Location = new System.Drawing.Point(56, 31);
            this.GlobalUniFilter.Name = "GlobalUniFilter";
            this.GlobalUniFilter.Size = new System.Drawing.Size(174, 21);
            this.GlobalUniFilter.TabIndex = 1;
            this.GlobalUniFilter.Visible = false;
            // 
            // label171
            // 
            this.label171.AutoSize = true;
            this.label171.Location = new System.Drawing.Point(168, 15);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(62, 13);
            this.label171.TabIndex = 2;
            this.label171.Text = "Global Filter";
            this.label171.Visible = false;
            // 
            // UniformGrid
            // 
            this.UniformGrid.AllowUserToAddRows = false;
            this.UniformGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.LightGray;
            this.UniformGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.UniformGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.MenuBar;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UniformGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.UniformGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UniformGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UniformActivation,
            this.UFID,
            this.UnifTeam,
            this.TUNI,
            this.ULTF,
            this.ShoulderNums,
            this.SleeveNums,
            this.SleeveDecal,
            this.HelmetNums,
            this.HelmetSideNum});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.NullValue = "N/A";
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UniformGrid.DefaultCellStyle = dataGridViewCellStyle35;
            this.UniformGrid.EnableHeadersVisualStyles = false;
            this.UniformGrid.Location = new System.Drawing.Point(32, 15);
            this.UniformGrid.Name = "UniformGrid";
            this.UniformGrid.RowHeadersVisible = false;
            this.UniformGrid.Size = new System.Drawing.Size(803, 584);
            this.UniformGrid.TabIndex = 0;
            this.UniformGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UniformGrid_CellContentClick);
            this.UniformGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.UniformGrid_DataError);
            // 
            // UniformActivation
            // 
            this.UniformActivation.FillWeight = 79.95358F;
            this.UniformActivation.HeaderText = "Activate";
            this.UniformActivation.Name = "UniformActivation";
            // 
            // UFID
            // 
            this.UFID.FillWeight = 81.70174F;
            this.UFID.HeaderText = "Uniform ID";
            this.UFID.Name = "UFID";
            this.UFID.ReadOnly = true;
            // 
            // UnifTeam
            // 
            this.UnifTeam.FillWeight = 190.7116F;
            this.UnifTeam.HeaderText = "Team Name";
            this.UnifTeam.Name = "UnifTeam";
            this.UnifTeam.ReadOnly = true;
            // 
            // TUNI
            // 
            this.TUNI.FillWeight = 78.89952F;
            this.TUNI.HeaderText = "Uniform Slot";
            this.TUNI.Name = "TUNI";
            this.TUNI.ReadOnly = true;
            // 
            // ULTF
            // 
            this.ULTF.FillWeight = 132.1599F;
            this.ULTF.HeaderText = "Uniform Color";
            this.ULTF.Name = "ULTF";
            this.ULTF.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ShoulderNums
            // 
            this.ShoulderNums.FillWeight = 78.79823F;
            this.ShoulderNums.HeaderText = "Shoulder Numbers";
            this.ShoulderNums.Name = "ShoulderNums";
            // 
            // SleeveNums
            // 
            this.SleeveNums.FillWeight = 78.0737F;
            this.SleeveNums.HeaderText = "Sleeve Numbers";
            this.SleeveNums.Name = "SleeveNums";
            this.SleeveNums.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SleeveDecal
            // 
            this.SleeveDecal.FillWeight = 77.25506F;
            this.SleeveDecal.HeaderText = "Sleeve Decal";
            this.SleeveDecal.Name = "SleeveDecal";
            // 
            // HelmetNums
            // 
            this.HelmetNums.FillWeight = 139.5939F;
            this.HelmetNums.HeaderText = "Helmet Numbers";
            this.HelmetNums.Name = "HelmetNums";
            // 
            // HelmetSideNum
            // 
            this.HelmetSideNum.FillWeight = 82.41927F;
            this.HelmetSideNum.HeaderText = "Helmet Side Numbers";
            this.HelmetSideNum.Name = "HelmetSideNum";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.UniformsActivated);
            this.groupBox4.Controls.Add(this.label169);
            this.groupBox4.Controls.Add(this.TeamAltUniCheck);
            this.groupBox4.Controls.Add(this.TeamPrimaryUniCheck);
            this.groupBox4.Controls.Add(this.TeamUniformSelectBox);
            this.groupBox4.Controls.Add(this.label168);
            this.groupBox4.Location = new System.Drawing.Point(848, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 160);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Team Editor";
            // 
            // UniformsActivated
            // 
            this.UniformsActivated.AutoSize = true;
            this.UniformsActivated.Location = new System.Drawing.Point(53, 133);
            this.UniformsActivated.Name = "UniformsActivated";
            this.UniformsActivated.Size = new System.Drawing.Size(116, 13);
            this.UniformsActivated.TabIndex = 6;
            this.UniformsActivated.Text = "Uniforms Activated: XX";
            // 
            // label169
            // 
            this.label169.AutoSize = true;
            this.label169.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label169.Location = new System.Drawing.Point(36, 69);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(109, 15);
            this.label169.TabIndex = 5;
            this.label169.Text = "Quick Functions";
            // 
            // TeamAltUniCheck
            // 
            this.TeamAltUniCheck.AutoSize = true;
            this.TeamAltUniCheck.Location = new System.Drawing.Point(56, 110);
            this.TeamAltUniCheck.Name = "TeamAltUniCheck";
            this.TeamAltUniCheck.Size = new System.Drawing.Size(162, 17);
            this.TeamAltUniCheck.TabIndex = 4;
            this.TeamAltUniCheck.Text = "Enable All Alternate Uniforms";
            this.TeamAltUniCheck.UseVisualStyleBackColor = true;
            this.TeamAltUniCheck.CheckedChanged += new System.EventHandler(this.TeamAltUniCheck_CheckedChanged);
            // 
            // TeamPrimaryUniCheck
            // 
            this.TeamPrimaryUniCheck.AutoSize = true;
            this.TeamPrimaryUniCheck.Location = new System.Drawing.Point(56, 87);
            this.TeamPrimaryUniCheck.Name = "TeamPrimaryUniCheck";
            this.TeamPrimaryUniCheck.Size = new System.Drawing.Size(165, 17);
            this.TeamPrimaryUniCheck.TabIndex = 3;
            this.TeamPrimaryUniCheck.Text = "Enable Home/Away Uniforms";
            this.TeamPrimaryUniCheck.UseVisualStyleBackColor = true;
            this.TeamPrimaryUniCheck.CheckedChanged += new System.EventHandler(this.TeamPrimaryUniCheck_CheckedChanged);
            // 
            // TeamUniformSelectBox
            // 
            this.TeamUniformSelectBox.FormattingEnabled = true;
            this.TeamUniformSelectBox.Location = new System.Drawing.Point(56, 31);
            this.TeamUniformSelectBox.Name = "TeamUniformSelectBox";
            this.TeamUniformSelectBox.Size = new System.Drawing.Size(174, 21);
            this.TeamUniformSelectBox.TabIndex = 1;
            this.TeamUniformSelectBox.SelectedIndexChanged += new System.EventHandler(this.TeamUniformSelectBox_SelectedIndexChanged);
            // 
            // label168
            // 
            this.label168.AutoSize = true;
            this.label168.Location = new System.Drawing.Point(149, 15);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(81, 13);
            this.label168.TabIndex = 2;
            this.label168.Text = "Team Selection";
            // 
            // tabPlaybook
            // 
            this.tabPlaybook.Controls.Add(this.textBox24);
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
            this.tabPlaybook.Controls.Add(this.groupBox19);
            this.tabPlaybook.Location = new System.Drawing.Point(4, 24);
            this.tabPlaybook.Name = "tabPlaybook";
            this.tabPlaybook.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaybook.Size = new System.Drawing.Size(1152, 615);
            this.tabPlaybook.TabIndex = 10;
            this.tabPlaybook.Text = "Playbook";
            this.tabPlaybook.UseVisualStyleBackColor = true;
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(820, 493);
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(311, 60);
            this.textBox24.TabIndex = 22;
            this.textBox24.Text = "Custom Playbook Names can be exported from the PLYL table from your custom Master" +
    " Playbook and placed in the \"resources\\playbooks\" folder under the filename PLYL" +
    "-Custom.csv";
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
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PlaybookGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle36;
            this.PlaybookGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaybookGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle37;
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
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PlaybookGrid.DefaultCellStyle = dataGridViewCellStyle39;
            this.PlaybookGrid.EnableHeadersVisualStyles = false;
            this.PlaybookGrid.Location = new System.Drawing.Point(12, 3);
            this.PlaybookGrid.Name = "PlaybookGrid";
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PlaybookGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.PlaybookGrid.RowHeadersVisible = false;
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
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info;
            this.prct.DefaultCellStyle = dataGridViewCellStyle38;
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
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.DefaultPlaysRadio);
            this.groupBox19.Controls.Add(this.CustomPlaysRadio);
            this.groupBox19.Location = new System.Drawing.Point(979, 401);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(152, 69);
            this.groupBox19.TabIndex = 25;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Play Names";
            // 
            // DefaultPlaysRadio
            // 
            this.DefaultPlaysRadio.AutoSize = true;
            this.DefaultPlaysRadio.Checked = true;
            this.DefaultPlaysRadio.Location = new System.Drawing.Point(5, 19);
            this.DefaultPlaysRadio.Name = "DefaultPlaysRadio";
            this.DefaultPlaysRadio.Size = new System.Drawing.Size(128, 17);
            this.DefaultPlaysRadio.TabIndex = 23;
            this.DefaultPlaysRadio.TabStop = true;
            this.DefaultPlaysRadio.Text = "NCAA 06 Play Names";
            this.DefaultPlaysRadio.UseVisualStyleBackColor = true;
            this.DefaultPlaysRadio.CheckedChanged += new System.EventHandler(this.DefaultPlaysRadio_CheckedChanged);
            // 
            // CustomPlaysRadio
            // 
            this.CustomPlaysRadio.AutoSize = true;
            this.CustomPlaysRadio.Location = new System.Drawing.Point(5, 42);
            this.CustomPlaysRadio.Name = "CustomPlaysRadio";
            this.CustomPlaysRadio.Size = new System.Drawing.Size(119, 17);
            this.CustomPlaysRadio.TabIndex = 24;
            this.CustomPlaysRadio.Text = "Custom Play Names";
            this.CustomPlaysRadio.UseVisualStyleBackColor = true;
            this.CustomPlaysRadio.CheckedChanged += new System.EventHandler(this.CustomPlaysRadio_CheckedChanged);
            // 
            // tabTools
            // 
            this.tabTools.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabTools.Controls.Add(this.FixHometownButton);
            this.tabTools.Controls.Add(this.ReRankTeamsAP);
            this.tabTools.Controls.Add(this.ResetDynYear);
            this.tabTools.Controls.Add(this.groupBox38);
            this.tabTools.Controls.Add(this.ReRankTeams);
            this.tabTools.Controls.Add(this.FixHCBugsButton);
            this.tabTools.Controls.Add(this.groupBox18);
            this.tabTools.Controls.Add(this.UniquePlayerButton);
            this.tabTools.Controls.Add(this.SyncPBButton);
            this.tabTools.Controls.Add(this.textBox3);
            this.tabTools.Controls.Add(this.ReorderPGIDButton);
            this.tabTools.Controls.Add(this.TORDButton);
            this.tabTools.Controls.Add(this.TYDNButton);
            this.tabTools.Location = new System.Drawing.Point(4, 24);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(1152, 615);
            this.tabTools.TabIndex = 5;
            this.tabTools.Text = "dbTools";
            // 
            // FixHometownButton
            // 
            this.FixHometownButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.FixHometownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixHometownButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FixHometownButton.Location = new System.Drawing.Point(141, 349);
            this.FixHometownButton.Name = "FixHometownButton";
            this.FixHometownButton.Size = new System.Drawing.Size(110, 80);
            this.FixHometownButton.TabIndex = 63;
            this.FixHometownButton.Text = "Fix Hometowns\r\n";
            this.FixHometownButton.UseVisualStyleBackColor = false;
            this.FixHometownButton.Click += new System.EventHandler(this.FixHometownButton_Click);
            // 
            // ReRankTeamsAP
            // 
            this.ReRankTeamsAP.AutoSize = true;
            this.ReRankTeamsAP.Location = new System.Drawing.Point(22, 197);
            this.ReRankTeamsAP.Name = "ReRankTeamsAP";
            this.ReRankTeamsAP.Size = new System.Drawing.Size(205, 17);
            this.ReRankTeamsAP.TabIndex = 62;
            this.ReRankTeamsAP.Text = "Re-Rank Media Poll Based on Overall";
            this.ReRankTeamsAP.UseVisualStyleBackColor = true;
            // 
            // ResetDynYear
            // 
            this.ResetDynYear.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ResetDynYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetDynYear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ResetDynYear.Location = new System.Drawing.Point(11, 248);
            this.ResetDynYear.Name = "ResetDynYear";
            this.ResetDynYear.Size = new System.Drawing.Size(110, 80);
            this.ResetDynYear.TabIndex = 61;
            this.ResetDynYear.Text = "Reset Dynasty Seasons";
            this.ResetDynYear.UseVisualStyleBackColor = false;
            this.ResetDynYear.Click += new System.EventHandler(this.ResetDynYear_Click);
            // 
            // groupBox38
            // 
            this.groupBox38.Controls.Add(this.FantastyRosterLeague);
            this.groupBox38.Controls.Add(this.DepthChartSize);
            this.groupBox38.Controls.Add(this.MaxFantasyPlayers);
            this.groupBox38.Controls.Add(this.label262);
            this.groupBox38.Controls.Add(this.buttonAutoDepthChart);
            this.groupBox38.Controls.Add(this.ClearExpiredStats);
            this.groupBox38.Controls.Add(this.buttonFantasyRoster);
            this.groupBox38.Controls.Add(this.groupBox22);
            this.groupBox38.Controls.Add(this.buttonFillRosters);
            this.groupBox38.Controls.Add(this.FillRosterPCT);
            this.groupBox38.Controls.Add(this.label58);
            this.groupBox38.Controls.Add(this.FantasyCoachesButton);
            this.groupBox38.Controls.Add(this.buttonRandPotential);
            this.groupBox38.Controls.Add(this.RandomizeHeadButton);
            this.groupBox38.Controls.Add(this.bodyFix);
            this.groupBox38.Controls.Add(qbTend);
            this.groupBox38.Controls.Add(this.buttonCalcOverall);
            this.groupBox38.Location = new System.Drawing.Point(272, 28);
            this.groupBox38.Name = "groupBox38";
            this.groupBox38.Size = new System.Drawing.Size(410, 576);
            this.groupBox38.TabIndex = 60;
            this.groupBox38.TabStop = false;
            this.groupBox38.Text = "Roster Tools";
            // 
            // FantastyRosterLeague
            // 
            this.FantastyRosterLeague.Controls.Add(this.label263);
            this.FantastyRosterLeague.Controls.Add(this.radioButton1);
            this.FantastyRosterLeague.Controls.Add(this.FBSroster);
            this.FantastyRosterLeague.Location = new System.Drawing.Point(8, 101);
            this.FantastyRosterLeague.Name = "FantastyRosterLeague";
            this.FantastyRosterLeague.Size = new System.Drawing.Size(239, 26);
            this.FantastyRosterLeague.TabIndex = 62;
            // 
            // label263
            // 
            this.label263.AutoSize = true;
            this.label263.Location = new System.Drawing.Point(8, 7);
            this.label263.Name = "label263";
            this.label263.Size = new System.Drawing.Size(93, 13);
            this.label263.TabIndex = 2;
            this.label263.Text = "League Generator";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(167, 5);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Text = "FCS";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FBSroster
            // 
            this.FBSroster.AutoSize = true;
            this.FBSroster.Checked = true;
            this.FBSroster.Location = new System.Drawing.Point(116, 5);
            this.FBSroster.Name = "FBSroster";
            this.FBSroster.Size = new System.Drawing.Size(45, 17);
            this.FBSroster.TabIndex = 0;
            this.FBSroster.TabStop = true;
            this.FBSroster.Text = "FBS";
            this.FBSroster.UseVisualStyleBackColor = true;
            // 
            // DepthChartSize
            // 
            this.DepthChartSize.Controls.Add(this.DC77);
            this.DepthChartSize.Controls.Add(this.DC88);
            this.DepthChartSize.Location = new System.Drawing.Point(253, 14);
            this.DepthChartSize.Name = "DepthChartSize";
            this.DepthChartSize.Size = new System.Drawing.Size(151, 63);
            this.DepthChartSize.TabIndex = 63;
            this.DepthChartSize.TabStop = false;
            this.DepthChartSize.Text = "League Size [SET FIRST]";
            // 
            // DC77
            // 
            this.DC77.AutoSize = true;
            this.DC77.Location = new System.Drawing.Point(5, 41);
            this.DC77.Name = "DC77";
            this.DC77.Size = new System.Drawing.Size(134, 17);
            this.DC77.TabIndex = 2;
            this.DC77.Text = "136-Teams [NEXT26+]";
            this.DC77.UseVisualStyleBackColor = true;
            this.DC77.CheckedChanged += new System.EventHandler(this.DC77_CheckedChanged);
            // 
            // DC88
            // 
            this.DC88.AutoSize = true;
            this.DC88.Checked = true;
            this.DC88.Location = new System.Drawing.Point(5, 18);
            this.DC88.Name = "DC88";
            this.DC88.Size = new System.Drawing.Size(144, 17);
            this.DC88.TabIndex = 0;
            this.DC88.TabStop = true;
            this.DC88.Text = "119/120 Teams [Default]";
            this.DC88.UseVisualStyleBackColor = true;
            this.DC88.CheckedChanged += new System.EventHandler(this.DC88_CheckedChanged);
            // 
            // MaxFantasyPlayers
            // 
            this.MaxFantasyPlayers.Location = new System.Drawing.Point(175, 19);
            this.MaxFantasyPlayers.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.MaxFantasyPlayers.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.MaxFantasyPlayers.Name = "MaxFantasyPlayers";
            this.MaxFantasyPlayers.Size = new System.Drawing.Size(42, 20);
            this.MaxFantasyPlayers.TabIndex = 60;
            this.MaxFantasyPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxFantasyPlayers.Value = new decimal(new int[] {
            69,
            0,
            0,
            0});
            // 
            // label262
            // 
            this.label262.AutoSize = true;
            this.label262.Location = new System.Drawing.Point(16, 24);
            this.label262.Name = "label262";
            this.label262.Size = new System.Drawing.Size(153, 13);
            this.label262.TabIndex = 61;
            this.label262.Text = "Max Fantasy Players Per Team";
            // 
            // buttonAutoDepthChart
            // 
            this.buttonAutoDepthChart.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonAutoDepthChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAutoDepthChart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAutoDepthChart.Location = new System.Drawing.Point(259, 86);
            this.buttonAutoDepthChart.Name = "buttonAutoDepthChart";
            this.buttonAutoDepthChart.Size = new System.Drawing.Size(145, 80);
            this.buttonAutoDepthChart.TabIndex = 19;
            this.buttonAutoDepthChart.Text = "Auto-Set Depth Chart";
            this.buttonAutoDepthChart.UseVisualStyleBackColor = false;
            this.buttonAutoDepthChart.Click += new System.EventHandler(this.buttonAutoDepthChart_Click);
            // 
            // ClearExpiredStats
            // 
            this.ClearExpiredStats.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClearExpiredStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearExpiredStats.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClearExpiredStats.Location = new System.Drawing.Point(259, 482);
            this.ClearExpiredStats.Name = "ClearExpiredStats";
            this.ClearExpiredStats.Size = new System.Drawing.Size(145, 80);
            this.ClearExpiredStats.TabIndex = 59;
            this.ClearExpiredStats.Text = "Clear Expired Stats Data";
            this.ClearExpiredStats.UseVisualStyleBackColor = false;
            this.ClearExpiredStats.Click += new System.EventHandler(this.ClearExpiredStats_Click);
            // 
            // buttonFantasyRoster
            // 
            this.buttonFantasyRoster.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFantasyRoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFantasyRoster.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFantasyRoster.Location = new System.Drawing.Point(8, 130);
            this.buttonFantasyRoster.Name = "buttonFantasyRoster";
            this.buttonFantasyRoster.Size = new System.Drawing.Size(239, 80);
            this.buttonFantasyRoster.TabIndex = 18;
            this.buttonFantasyRoster.Text = "Generate Fantasy Roster";
            this.buttonFantasyRoster.UseVisualStyleBackColor = false;
            this.buttonFantasyRoster.Click += new System.EventHandler(this.buttonFantasyRoster_Click);
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.FantasyCSV);
            this.groupBox22.Controls.Add(this.FantasyTeamDB);
            this.groupBox22.Location = new System.Drawing.Point(8, 50);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(239, 45);
            this.groupBox22.TabIndex = 58;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Team Prestige Location";
            // 
            // FantasyCSV
            // 
            this.FantasyCSV.AutoSize = true;
            this.FantasyCSV.Location = new System.Drawing.Point(139, 19);
            this.FantasyCSV.Name = "FantasyCSV";
            this.FantasyCSV.Size = new System.Drawing.Size(87, 17);
            this.FantasyCSV.TabIndex = 1;
            this.FantasyCSV.TabStop = true;
            this.FantasyCSV.Text = "External CSV";
            this.FantasyCSV.UseVisualStyleBackColor = true;
            // 
            // FantasyTeamDB
            // 
            this.FantasyTeamDB.AutoSize = true;
            this.FantasyTeamDB.Location = new System.Drawing.Point(17, 19);
            this.FantasyTeamDB.Name = "FantasyTeamDB";
            this.FantasyTeamDB.Size = new System.Drawing.Size(101, 17);
            this.FantasyTeamDB.TabIndex = 0;
            this.FantasyTeamDB.TabStop = true;
            this.FantasyTeamDB.Text = "Team Database";
            this.FantasyTeamDB.UseVisualStyleBackColor = true;
            // 
            // buttonFillRosters
            // 
            this.buttonFillRosters.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonFillRosters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFillRosters.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonFillRosters.Location = new System.Drawing.Point(259, 181);
            this.buttonFillRosters.Name = "buttonFillRosters";
            this.buttonFillRosters.Size = new System.Drawing.Size(145, 80);
            this.buttonFillRosters.TabIndex = 20;
            this.buttonFillRosters.Text = "Fill Rosters";
            this.buttonFillRosters.UseVisualStyleBackColor = false;
            this.buttonFillRosters.Click += new System.EventHandler(this.buttonFillRosters_Click);
            // 
            // FillRosterPCT
            // 
            this.FillRosterPCT.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FillRosterPCT.Location = new System.Drawing.Point(312, 280);
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
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(270, 264);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(126, 13);
            this.label58.TabIndex = 23;
            this.label58.Text = "Fill Roster Freshman PCT";
            // 
            // FantasyCoachesButton
            // 
            this.FantasyCoachesButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.FantasyCoachesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FantasyCoachesButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FantasyCoachesButton.Location = new System.Drawing.Point(8, 216);
            this.FantasyCoachesButton.Name = "FantasyCoachesButton";
            this.FantasyCoachesButton.Size = new System.Drawing.Size(239, 80);
            this.FantasyCoachesButton.TabIndex = 53;
            this.FantasyCoachesButton.Text = "Generate Fantasy Coaches";
            this.FantasyCoachesButton.UseVisualStyleBackColor = false;
            this.FantasyCoachesButton.Click += new System.EventHandler(this.FantasyCoachesButton_Click);
            // 
            // buttonRandPotential
            // 
            this.buttonRandPotential.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonRandPotential.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandPotential.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRandPotential.Location = new System.Drawing.Point(259, 305);
            this.buttonRandPotential.Name = "buttonRandPotential";
            this.buttonRandPotential.Size = new System.Drawing.Size(145, 74);
            this.buttonRandPotential.TabIndex = 12;
            this.buttonRandPotential.Text = "Randomize Player Potential";
            this.buttonRandPotential.UseVisualStyleBackColor = false;
            this.buttonRandPotential.Click += new System.EventHandler(this.ButtonRandPotential_Click);
            // 
            // RandomizeHeadButton
            // 
            this.RandomizeHeadButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.RandomizeHeadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomizeHeadButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RandomizeHeadButton.Location = new System.Drawing.Point(8, 302);
            this.RandomizeHeadButton.Name = "RandomizeHeadButton";
            this.RandomizeHeadButton.Size = new System.Drawing.Size(239, 77);
            this.RandomizeHeadButton.TabIndex = 24;
            this.RandomizeHeadButton.Text = "Randomize Player Head/Face";
            this.RandomizeHeadButton.UseVisualStyleBackColor = false;
            this.RandomizeHeadButton.Click += new System.EventHandler(this.RandomizeHeadButton_Click);
            // 
            // bodyFix
            // 
            this.bodyFix.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bodyFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bodyFix.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bodyFix.Location = new System.Drawing.Point(8, 391);
            this.bodyFix.Name = "bodyFix";
            this.bodyFix.Size = new System.Drawing.Size(239, 80);
            this.bodyFix.TabIndex = 9;
            this.bodyFix.Text = "Body Size Fixer";
            this.bodyFix.UseVisualStyleBackColor = false;
            this.bodyFix.Click += new System.EventHandler(this.BodyFix_Click);
            // 
            // buttonCalcOverall
            // 
            this.buttonCalcOverall.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonCalcOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalcOverall.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCalcOverall.Location = new System.Drawing.Point(8, 482);
            this.buttonCalcOverall.Name = "buttonCalcOverall";
            this.buttonCalcOverall.Size = new System.Drawing.Size(239, 80);
            this.buttonCalcOverall.TabIndex = 15;
            this.buttonCalcOverall.Text = "Recalculate Player Overall";
            this.buttonCalcOverall.UseVisualStyleBackColor = false;
            this.buttonCalcOverall.Click += new System.EventHandler(this.buttonCalcOverall_Click);
            // 
            // ReRankTeams
            // 
            this.ReRankTeams.AutoSize = true;
            this.ReRankTeams.Location = new System.Drawing.Point(22, 177);
            this.ReRankTeams.Name = "ReRankTeams";
            this.ReRankTeams.Size = new System.Drawing.Size(207, 17);
            this.ReRankTeams.TabIndex = 57;
            this.ReRankTeams.Text = "Re-Rank Coach Poll Based on Overall";
            this.ReRankTeams.UseVisualStyleBackColor = true;
            // 
            // FixHCBugsButton
            // 
            this.FixHCBugsButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.FixHCBugsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FixHCBugsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FixHCBugsButton.Location = new System.Drawing.Point(142, 247);
            this.FixHCBugsButton.Name = "FixHCBugsButton";
            this.FixHCBugsButton.Size = new System.Drawing.Size(110, 80);
            this.FixHCBugsButton.TabIndex = 56;
            this.FixHCBugsButton.Text = "Fix Coach Head/Face Bugs";
            this.FixHCBugsButton.UseVisualStyleBackColor = false;
            this.FixHCBugsButton.Click += new System.EventHandler(this.FixHCBugsButton_Click);
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.MaxBodyValue);
            this.groupBox18.Controls.Add(this.label264);
            this.groupBox18.Controls.Add(this.label265);
            this.groupBox18.Controls.Add(this.MinBodyType);
            this.groupBox18.Controls.Add(this.label266);
            this.groupBox18.Controls.Add(this.MaxBodyPos);
            this.groupBox18.Controls.Add(this.MinBodyValue);
            this.groupBox18.Controls.Add(this.MinBodyPos);
            this.groupBox18.Controls.Add(this.MaxBodyType);
            this.groupBox18.Controls.Add(this.label267);
            this.groupBox18.Controls.Add(this.UpdateMaxBody);
            this.groupBox18.Controls.Add(this.UpdateMinBody);
            this.groupBox18.Controls.Add(this.MaxAttNum);
            this.groupBox18.Controls.Add(this.GlobalAttBox);
            this.groupBox18.Controls.Add(this.label99);
            this.groupBox18.Controls.Add(this.GlobalAttNum);
            this.groupBox18.Controls.Add(this.label109);
            this.groupBox18.Controls.Add(this.GlobalAttCheck);
            this.groupBox18.Controls.Add(this.label108);
            this.groupBox18.Controls.Add(this.MinAttBox);
            this.groupBox18.Controls.Add(this.label107);
            this.groupBox18.Controls.Add(this.label100);
            this.groupBox18.Controls.Add(this.MaxAttPosBox);
            this.groupBox18.Controls.Add(this.MinAttNum);
            this.groupBox18.Controls.Add(this.MinAttPosBox);
            this.groupBox18.Controls.Add(this.MaxAttBox);
            this.groupBox18.Controls.Add(this.GlobalAttPosBox);
            this.groupBox18.Controls.Add(this.label106);
            this.groupBox18.Controls.Add(this.MaxAttButton);
            this.groupBox18.Controls.Add(this.MinAttRating);
            this.groupBox18.Controls.Add(this.MinAttButton);
            this.groupBox18.Controls.Add(this.MaxAttRating);
            this.groupBox18.Controls.Add(this.GlobalAttButton);
            this.groupBox18.Location = new System.Drawing.Point(702, 28);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(425, 576);
            this.groupBox18.TabIndex = 55;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Global Player Editor";
            // 
            // MaxBodyValue
            // 
            this.MaxBodyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxBodyValue.Location = new System.Drawing.Point(264, 502);
            this.MaxBodyValue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.MaxBodyValue.Name = "MaxBodyValue";
            this.MaxBodyValue.Size = new System.Drawing.Size(68, 21);
            this.MaxBodyValue.TabIndex = 57;
            this.MaxBodyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label264
            // 
            this.label264.AutoSize = true;
            this.label264.Location = new System.Drawing.Point(17, 486);
            this.label264.Name = "label264";
            this.label264.Size = new System.Drawing.Size(44, 13);
            this.label264.TabIndex = 65;
            this.label264.Text = "Position";
            // 
            // label265
            // 
            this.label265.AutoSize = true;
            this.label265.Location = new System.Drawing.Point(18, 377);
            this.label265.Name = "label265";
            this.label265.Size = new System.Drawing.Size(44, 13);
            this.label265.TabIndex = 64;
            this.label265.Text = "Position";
            // 
            // MinBodyType
            // 
            this.MinBodyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinBodyType.FormattingEnabled = true;
            this.MinBodyType.Items.AddRange(new object[] {
            "Height (in)",
            "Weight (lbs)"});
            this.MinBodyType.Location = new System.Drawing.Point(92, 391);
            this.MinBodyType.Name = "MinBodyType";
            this.MinBodyType.Size = new System.Drawing.Size(150, 23);
            this.MinBodyType.TabIndex = 52;
            this.MinBodyType.SelectedIndexChanged += new System.EventHandler(this.MinBodyType_SelectedIndexChanged);
            // 
            // label266
            // 
            this.label266.AutoSize = true;
            this.label266.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label266.Location = new System.Drawing.Point(88, 360);
            this.label266.Name = "label266";
            this.label266.Size = new System.Drawing.Size(197, 20);
            this.label266.TabIndex = 53;
            this.label266.Text = "Set Minimum Body Size";
            // 
            // MaxBodyPos
            // 
            this.MaxBodyPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxBodyPos.FormattingEnabled = true;
            this.MaxBodyPos.Location = new System.Drawing.Point(20, 501);
            this.MaxBodyPos.Name = "MaxBodyPos";
            this.MaxBodyPos.Size = new System.Drawing.Size(65, 23);
            this.MaxBodyPos.TabIndex = 63;
            // 
            // MinBodyValue
            // 
            this.MinBodyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinBodyValue.Location = new System.Drawing.Point(264, 393);
            this.MinBodyValue.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.MinBodyValue.Name = "MinBodyValue";
            this.MinBodyValue.Size = new System.Drawing.Size(68, 21);
            this.MinBodyValue.TabIndex = 54;
            this.MinBodyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinBodyPos
            // 
            this.MinBodyPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinBodyPos.FormattingEnabled = true;
            this.MinBodyPos.Location = new System.Drawing.Point(21, 391);
            this.MinBodyPos.Name = "MinBodyPos";
            this.MinBodyPos.Size = new System.Drawing.Size(65, 23);
            this.MinBodyPos.TabIndex = 62;
            // 
            // MaxBodyType
            // 
            this.MaxBodyType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxBodyType.FormattingEnabled = true;
            this.MaxBodyType.Items.AddRange(new object[] {
            "Height (in)",
            "Weight (lbs)"});
            this.MaxBodyType.Location = new System.Drawing.Point(92, 500);
            this.MaxBodyType.Name = "MaxBodyType";
            this.MaxBodyType.Size = new System.Drawing.Size(150, 23);
            this.MaxBodyType.TabIndex = 55;
            this.MaxBodyType.SelectedIndexChanged += new System.EventHandler(this.MaxBodyType_SelectedIndexChanged);
            // 
            // label267
            // 
            this.label267.AutoSize = true;
            this.label267.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label267.Location = new System.Drawing.Point(88, 469);
            this.label267.Name = "label267";
            this.label267.Size = new System.Drawing.Size(201, 20);
            this.label267.TabIndex = 56;
            this.label267.Text = "Set Maximum Body Size";
            // 
            // UpdateMaxBody
            // 
            this.UpdateMaxBody.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UpdateMaxBody.Location = new System.Drawing.Point(263, 528);
            this.UpdateMaxBody.Name = "UpdateMaxBody";
            this.UpdateMaxBody.Size = new System.Drawing.Size(75, 23);
            this.UpdateMaxBody.TabIndex = 61;
            this.UpdateMaxBody.Text = "Update";
            this.UpdateMaxBody.UseVisualStyleBackColor = false;
            this.UpdateMaxBody.Click += new System.EventHandler(this.UpdateMaxBody_Click);
            // 
            // UpdateMinBody
            // 
            this.UpdateMinBody.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UpdateMinBody.Location = new System.Drawing.Point(264, 420);
            this.UpdateMinBody.Name = "UpdateMinBody";
            this.UpdateMinBody.Size = new System.Drawing.Size(75, 23);
            this.UpdateMinBody.TabIndex = 60;
            this.UpdateMinBody.Text = "Update";
            this.UpdateMinBody.UseVisualStyleBackColor = false;
            this.UpdateMinBody.Click += new System.EventHandler(this.UpdateMinBody_Click);
            // 
            // MaxAttNum
            // 
            this.MaxAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttNum.Location = new System.Drawing.Point(264, 278);
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
            // GlobalAttBox
            // 
            this.GlobalAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttBox.FormattingEnabled = true;
            this.GlobalAttBox.Location = new System.Drawing.Point(92, 54);
            this.GlobalAttBox.Name = "GlobalAttBox";
            this.GlobalAttBox.Size = new System.Drawing.Size(150, 23);
            this.GlobalAttBox.TabIndex = 29;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.Location = new System.Drawing.Point(88, 23);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(189, 20);
            this.label99.TabIndex = 30;
            this.label99.Text = "Global Attribute Editor";
            // 
            // GlobalAttNum
            // 
            this.GlobalAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttNum.Location = new System.Drawing.Point(264, 56);
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
            // label109
            // 
            this.label109.AutoSize = true;
            this.label109.Location = new System.Drawing.Point(17, 262);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(44, 13);
            this.label109.TabIndex = 51;
            this.label109.Text = "Position";
            // 
            // GlobalAttCheck
            // 
            this.GlobalAttCheck.AutoSize = true;
            this.GlobalAttCheck.Location = new System.Drawing.Point(92, 86);
            this.GlobalAttCheck.Name = "GlobalAttCheck";
            this.GlobalAttCheck.Size = new System.Drawing.Size(137, 17);
            this.GlobalAttCheck.TabIndex = 32;
            this.GlobalAttCheck.Text = "Prestige Based Change";
            this.GlobalAttCheck.UseVisualStyleBackColor = true;
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(18, 153);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(44, 13);
            this.label108.TabIndex = 50;
            this.label108.Text = "Position";
            // 
            // MinAttBox
            // 
            this.MinAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttBox.FormattingEnabled = true;
            this.MinAttBox.Location = new System.Drawing.Point(92, 167);
            this.MinAttBox.Name = "MinAttBox";
            this.MinAttBox.Size = new System.Drawing.Size(150, 23);
            this.MinAttBox.TabIndex = 33;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(18, 38);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(44, 13);
            this.label107.TabIndex = 49;
            this.label107.Text = "Position";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label100.Location = new System.Drawing.Point(88, 136);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(187, 20);
            this.label100.TabIndex = 34;
            this.label100.Text = "Set Minimum Attribute";
            // 
            // MaxAttPosBox
            // 
            this.MaxAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttPosBox.FormattingEnabled = true;
            this.MaxAttPosBox.Location = new System.Drawing.Point(20, 277);
            this.MaxAttPosBox.Name = "MaxAttPosBox";
            this.MaxAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.MaxAttPosBox.TabIndex = 48;
            // 
            // MinAttNum
            // 
            this.MinAttNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttNum.Location = new System.Drawing.Point(264, 169);
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
            // MinAttPosBox
            // 
            this.MinAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttPosBox.FormattingEnabled = true;
            this.MinAttPosBox.Location = new System.Drawing.Point(21, 167);
            this.MinAttPosBox.Name = "MinAttPosBox";
            this.MinAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.MinAttPosBox.TabIndex = 47;
            // 
            // MaxAttBox
            // 
            this.MaxAttBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttBox.FormattingEnabled = true;
            this.MaxAttBox.Location = new System.Drawing.Point(92, 276);
            this.MaxAttBox.Name = "MaxAttBox";
            this.MaxAttBox.Size = new System.Drawing.Size(150, 23);
            this.MaxAttBox.TabIndex = 37;
            // 
            // GlobalAttPosBox
            // 
            this.GlobalAttPosBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GlobalAttPosBox.FormattingEnabled = true;
            this.GlobalAttPosBox.Location = new System.Drawing.Point(21, 54);
            this.GlobalAttPosBox.Name = "GlobalAttPosBox";
            this.GlobalAttPosBox.Size = new System.Drawing.Size(65, 23);
            this.GlobalAttPosBox.TabIndex = 46;
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(88, 245);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(191, 20);
            this.label106.TabIndex = 38;
            this.label106.Text = "Set Maximum Attribute";
            // 
            // MaxAttButton
            // 
            this.MaxAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MaxAttButton.Location = new System.Drawing.Point(263, 304);
            this.MaxAttButton.Name = "MaxAttButton";
            this.MaxAttButton.Size = new System.Drawing.Size(75, 23);
            this.MaxAttButton.TabIndex = 45;
            this.MaxAttButton.Text = "Update";
            this.MaxAttButton.UseVisualStyleBackColor = false;
            this.MaxAttButton.Click += new System.EventHandler(this.MaxAttButton_Click);
            // 
            // MinAttRating
            // 
            this.MinAttRating.BackColor = System.Drawing.SystemColors.Info;
            this.MinAttRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinAttRating.Location = new System.Drawing.Point(339, 169);
            this.MinAttRating.Name = "MinAttRating";
            this.MinAttRating.ReadOnly = true;
            this.MinAttRating.Size = new System.Drawing.Size(39, 21);
            this.MinAttRating.TabIndex = 41;
            this.MinAttRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinAttButton
            // 
            this.MinAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MinAttButton.Location = new System.Drawing.Point(264, 196);
            this.MinAttButton.Name = "MinAttButton";
            this.MinAttButton.Size = new System.Drawing.Size(75, 23);
            this.MinAttButton.TabIndex = 44;
            this.MinAttButton.Text = "Update";
            this.MinAttButton.UseVisualStyleBackColor = false;
            this.MinAttButton.Click += new System.EventHandler(this.MinAttButton_Click);
            // 
            // MaxAttRating
            // 
            this.MaxAttRating.BackColor = System.Drawing.SystemColors.Info;
            this.MaxAttRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxAttRating.Location = new System.Drawing.Point(338, 276);
            this.MaxAttRating.Name = "MaxAttRating";
            this.MaxAttRating.ReadOnly = true;
            this.MaxAttRating.Size = new System.Drawing.Size(39, 21);
            this.MaxAttRating.TabIndex = 42;
            this.MaxAttRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GlobalAttButton
            // 
            this.GlobalAttButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.GlobalAttButton.Location = new System.Drawing.Point(264, 82);
            this.GlobalAttButton.Name = "GlobalAttButton";
            this.GlobalAttButton.Size = new System.Drawing.Size(75, 23);
            this.GlobalAttButton.TabIndex = 43;
            this.GlobalAttButton.Text = "Update";
            this.GlobalAttButton.UseVisualStyleBackColor = false;
            this.GlobalAttButton.Click += new System.EventHandler(this.GlobalAttButton_Click);
            // 
            // UniquePlayerButton
            // 
            this.UniquePlayerButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.UniquePlayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UniquePlayerButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.UniquePlayerButton.Location = new System.Drawing.Point(11, 349);
            this.UniquePlayerButton.Name = "UniquePlayerButton";
            this.UniquePlayerButton.Size = new System.Drawing.Size(110, 80);
            this.UniquePlayerButton.TabIndex = 54;
            this.UniquePlayerButton.Text = "Texture Modding: Unique Players";
            this.UniquePlayerButton.UseVisualStyleBackColor = false;
            this.UniquePlayerButton.Click += new System.EventHandler(this.UniquePlayer_Click);
            // 
            // SyncPBButton
            // 
            this.SyncPBButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SyncPBButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncPBButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SyncPBButton.Location = new System.Drawing.Point(141, 529);
            this.SyncPBButton.Name = "SyncPBButton";
            this.SyncPBButton.Size = new System.Drawing.Size(110, 80);
            this.SyncPBButton.TabIndex = 52;
            this.SyncPBButton.Text = "Sync Team and Coach Playbooks";
            this.SyncPBButton.UseVisualStyleBackColor = false;
            this.SyncPBButton.Click += new System.EventHandler(this.SyncPBButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Info;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(16, 18);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(237, 61);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "NCAA Football\r\nModding Toolkit";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReorderPGIDButton
            // 
            this.ReorderPGIDButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ReorderPGIDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReorderPGIDButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ReorderPGIDButton.Location = new System.Drawing.Point(14, 529);
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
            this.TORDButton.Location = new System.Drawing.Point(76, 443);
            this.TORDButton.Name = "TORDButton";
            this.TORDButton.Size = new System.Drawing.Size(110, 80);
            this.TORDButton.TabIndex = 26;
            this.TORDButton.Text = "Reorder Teams (Dynasty)";
            this.TORDButton.UseVisualStyleBackColor = false;
            this.TORDButton.Click += new System.EventHandler(this.TORDButton_Click);
            // 
            // TYDNButton
            // 
            this.TYDNButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.TYDNButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TYDNButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TYDNButton.Location = new System.Drawing.Point(16, 94);
            this.TYDNButton.Name = "TYDNButton";
            this.TYDNButton.Size = new System.Drawing.Size(236, 80);
            this.TYDNButton.TabIndex = 16;
            this.TYDNButton.Text = "Recalculate Team Ratings";
            this.TYDNButton.UseVisualStyleBackColor = false;
            this.TYDNButton.Click += new System.EventHandler(this.TYDNButton_Click);
            // 
            // tabOffSeason
            // 
            this.tabOffSeason.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabOffSeason.Controls.Add(this.groupBox17);
            this.tabOffSeason.Controls.Add(this.groupBox16);
            this.tabOffSeason.Controls.Add(this.textBoxOffSeason);
            this.tabOffSeason.Controls.Add(this.textBoxOffSeasonTitle);
            this.tabOffSeason.Location = new System.Drawing.Point(4, 24);
            this.tabOffSeason.Name = "tabOffSeason";
            this.tabOffSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabOffSeason.Size = new System.Drawing.Size(1152, 615);
            this.tabOffSeason.TabIndex = 4;
            this.tabOffSeason.Text = "Recruiting";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.removeInterestTeams);
            this.groupBox17.Controls.Add(this.buttonMinRecruitingPts);
            this.groupBox17.Controls.Add(this.minRecPts);
            this.groupBox17.Controls.Add(this.labelMinRecPts);
            this.groupBox17.Controls.Add(this.labelIntTeams);
            this.groupBox17.Controls.Add(this.minTRPA);
            this.groupBox17.Controls.Add(this.label12);
            this.groupBox17.Controls.Add(this.buttonInterestedTeams);
            this.groupBox17.Location = new System.Drawing.Point(12, 6);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(477, 190);
            this.groupBox17.TabIndex = 25;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Recruiting Tools";
            // 
            // removeInterestTeams
            // 
            this.removeInterestTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeInterestTeams.Location = new System.Drawing.Point(310, 124);
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
            // buttonMinRecruitingPts
            // 
            this.buttonMinRecruitingPts.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonMinRecruitingPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMinRecruitingPts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonMinRecruitingPts.Location = new System.Drawing.Point(31, 34);
            this.buttonMinRecruitingPts.Name = "buttonMinRecruitingPts";
            this.buttonMinRecruitingPts.Size = new System.Drawing.Size(180, 80);
            this.buttonMinRecruitingPts.TabIndex = 1;
            this.buttonMinRecruitingPts.Text = "Raise Minimum Recruiting Points";
            this.buttonMinRecruitingPts.UseVisualStyleBackColor = false;
            this.buttonMinRecruitingPts.Click += new System.EventHandler(this.ButtonMinRecruitingPts_Click);
            // 
            // minRecPts
            // 
            this.minRecPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minRecPts.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.minRecPts.Location = new System.Drawing.Point(148, 120);
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
            // labelMinRecPts
            // 
            this.labelMinRecPts.AutoSize = true;
            this.labelMinRecPts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinRecPts.Location = new System.Drawing.Point(131, 148);
            this.labelMinRecPts.Name = "labelMinRecPts";
            this.labelMinRecPts.Size = new System.Drawing.Size(78, 16);
            this.labelMinRecPts.TabIndex = 9;
            this.labelMinRecPts.Text = "Min Points";
            this.labelMinRecPts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelIntTeams
            // 
            this.labelIntTeams.AutoSize = true;
            this.labelIntTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIntTeams.Location = new System.Drawing.Point(249, 126);
            this.labelIntTeams.Name = "labelIntTeams";
            this.labelIntTeams.Size = new System.Drawing.Size(55, 16);
            this.labelIntTeams.TabIndex = 14;
            this.labelIntTeams.Text = "Teams";
            this.labelIntTeams.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // minTRPA
            // 
            this.minTRPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minTRPA.Location = new System.Drawing.Point(43, 120);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(28, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 16);
            this.label12.TabIndex = 11;
            this.label12.Text = "Min TRPA";
            // 
            // buttonInterestedTeams
            // 
            this.buttonInterestedTeams.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonInterestedTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInterestedTeams.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonInterestedTeams.Location = new System.Drawing.Point(252, 34);
            this.buttonInterestedTeams.Name = "buttonInterestedTeams";
            this.buttonInterestedTeams.Size = new System.Drawing.Size(180, 80);
            this.buttonInterestedTeams.TabIndex = 12;
            this.buttonInterestedTeams.Text = "Modify Recruiting Interested Teams";
            this.buttonInterestedTeams.UseVisualStyleBackColor = false;
            this.buttonInterestedTeams.Click += new System.EventHandler(this.ButtonInterestedTeams_Click);
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.RecalculateStarRankingsButton);
            this.groupBox16.Controls.Add(this.DetermineAthleteButton);
            this.groupBox16.Controls.Add(this.buttonRandWalkOns);
            this.groupBox16.Controls.Add(this.buttonRandRecruits);
            this.groupBox16.Controls.Add(this.RandomizeRecruitNamesButton);
            this.groupBox16.Controls.Add(this.toleranceWalkOn);
            this.groupBox16.Controls.Add(this.buttonRandomizeFaceShape);
            this.groupBox16.Controls.Add(this.wkonLabel);
            this.groupBox16.Controls.Add(this.polyNames);
            this.groupBox16.Controls.Add(this.recruitTolerance);
            this.groupBox16.Controls.Add(this.labelRecruit);
            this.groupBox16.Location = new System.Drawing.Point(12, 202);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(477, 404);
            this.groupBox16.TabIndex = 24;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Recruiting Pool";
            // 
            // RecalculateStarRankingsButton
            // 
            this.RecalculateStarRankingsButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RecalculateStarRankingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecalculateStarRankingsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RecalculateStarRankingsButton.Location = new System.Drawing.Point(27, 308);
            this.RecalculateStarRankingsButton.Name = "RecalculateStarRankingsButton";
            this.RecalculateStarRankingsButton.Size = new System.Drawing.Size(356, 80);
            this.RecalculateStarRankingsButton.TabIndex = 22;
            this.RecalculateStarRankingsButton.Text = "Recalculate Recruit and Transfers Star Ranking";
            this.RecalculateStarRankingsButton.UseVisualStyleBackColor = false;
            this.RecalculateStarRankingsButton.Click += new System.EventHandler(this.RecalculateStarRankingsButton_Click);
            // 
            // DetermineAthleteButton
            // 
            this.DetermineAthleteButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.DetermineAthleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetermineAthleteButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.DetermineAthleteButton.Location = new System.Drawing.Point(26, 217);
            this.DetermineAthleteButton.Name = "DetermineAthleteButton";
            this.DetermineAthleteButton.Size = new System.Drawing.Size(357, 80);
            this.DetermineAthleteButton.TabIndex = 23;
            this.DetermineAthleteButton.Text = "Determine Athlete Best Position";
            this.DetermineAthleteButton.UseVisualStyleBackColor = false;
            this.DetermineAthleteButton.Click += new System.EventHandler(this.DetermineAthleteButton_Click);
            // 
            // buttonRandWalkOns
            // 
            this.buttonRandWalkOns.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandWalkOns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandWalkOns.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandWalkOns.Location = new System.Drawing.Point(273, 23);
            this.buttonRandWalkOns.Name = "buttonRandWalkOns";
            this.buttonRandWalkOns.Size = new System.Drawing.Size(110, 80);
            this.buttonRandWalkOns.TabIndex = 2;
            this.buttonRandWalkOns.Text = "Randomize Walk-Ons";
            this.buttonRandWalkOns.UseVisualStyleBackColor = false;
            this.buttonRandWalkOns.Click += new System.EventHandler(this.ButtonRandWalkOns_Click);
            // 
            // buttonRandRecruits
            // 
            this.buttonRandRecruits.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandRecruits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandRecruits.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandRecruits.Location = new System.Drawing.Point(26, 23);
            this.buttonRandRecruits.Name = "buttonRandRecruits";
            this.buttonRandRecruits.Size = new System.Drawing.Size(110, 80);
            this.buttonRandRecruits.TabIndex = 3;
            this.buttonRandRecruits.Text = "Randomize Recruits";
            this.buttonRandRecruits.UseVisualStyleBackColor = false;
            this.buttonRandRecruits.Click += new System.EventHandler(this.ButtonRandRecruits_Click);
            // 
            // RandomizeRecruitNamesButton
            // 
            this.RandomizeRecruitNamesButton.BackColor = System.Drawing.SystemColors.Highlight;
            this.RandomizeRecruitNamesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomizeRecruitNamesButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RandomizeRecruitNamesButton.Location = new System.Drawing.Point(148, 118);
            this.RandomizeRecruitNamesButton.Name = "RandomizeRecruitNamesButton";
            this.RandomizeRecruitNamesButton.Size = new System.Drawing.Size(110, 80);
            this.RandomizeRecruitNamesButton.TabIndex = 21;
            this.RandomizeRecruitNamesButton.Text = "Randomize Recruits Names";
            this.RandomizeRecruitNamesButton.UseVisualStyleBackColor = false;
            this.RandomizeRecruitNamesButton.Click += new System.EventHandler(this.RandomizeRecruitNamesButton_Click);
            // 
            // toleranceWalkOn
            // 
            this.toleranceWalkOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toleranceWalkOn.Location = new System.Drawing.Point(404, 49);
            this.toleranceWalkOn.Maximum = new decimal(new int[] {
            10,
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
            // buttonRandomizeFaceShape
            // 
            this.buttonRandomizeFaceShape.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonRandomizeFaceShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomizeFaceShape.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandomizeFaceShape.Location = new System.Drawing.Point(26, 118);
            this.buttonRandomizeFaceShape.Name = "buttonRandomizeFaceShape";
            this.buttonRandomizeFaceShape.Size = new System.Drawing.Size(110, 80);
            this.buttonRandomizeFaceShape.TabIndex = 20;
            this.buttonRandomizeFaceShape.Text = "Randomize Recruits Face/Skin";
            this.buttonRandomizeFaceShape.UseVisualStyleBackColor = false;
            this.buttonRandomizeFaceShape.Click += new System.EventHandler(this.buttonRandomizeFaceSkin_Click);
            // 
            // wkonLabel
            // 
            this.wkonLabel.AutoSize = true;
            this.wkonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wkonLabel.Location = new System.Drawing.Point(390, 74);
            this.wkonLabel.Name = "wkonLabel";
            this.wkonLabel.Size = new System.Drawing.Size(78, 16);
            this.wkonLabel.TabIndex = 5;
            this.wkonLabel.Text = "Tolerance";
            this.wkonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // polyNames
            // 
            this.polyNames.BackColor = System.Drawing.SystemColors.Highlight;
            this.polyNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.polyNames.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.polyNames.Location = new System.Drawing.Point(273, 118);
            this.polyNames.Name = "polyNames";
            this.polyNames.Size = new System.Drawing.Size(110, 82);
            this.polyNames.TabIndex = 17;
            this.polyNames.Text = "Polynesian Player/Name Generator";
            this.polyNames.UseVisualStyleBackColor = false;
            this.polyNames.Click += new System.EventHandler(this.PolyNames_Click);
            // 
            // recruitTolerance
            // 
            this.recruitTolerance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recruitTolerance.Location = new System.Drawing.Point(157, 49);
            this.recruitTolerance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.recruitTolerance.Name = "recruitTolerance";
            this.recruitTolerance.Size = new System.Drawing.Size(52, 22);
            this.recruitTolerance.TabIndex = 6;
            this.recruitTolerance.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelRecruit
            // 
            this.labelRecruit.AutoSize = true;
            this.labelRecruit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecruit.Location = new System.Drawing.Point(143, 74);
            this.labelRecruit.Name = "labelRecruit";
            this.labelRecruit.Size = new System.Drawing.Size(78, 16);
            this.labelRecruit.TabIndex = 7;
            this.labelRecruit.Text = "Tolerance";
            this.labelRecruit.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxOffSeason
            // 
            this.textBoxOffSeason.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxOffSeason.Enabled = false;
            this.textBoxOffSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffSeason.Location = new System.Drawing.Point(511, 40);
            this.textBoxOffSeason.Multiline = true;
            this.textBoxOffSeason.Name = "textBoxOffSeason";
            this.textBoxOffSeason.Size = new System.Drawing.Size(615, 569);
            this.textBoxOffSeason.TabIndex = 16;
            this.textBoxOffSeason.Text = resources.GetString("textBoxOffSeason.Text");
            // 
            // textBoxOffSeasonTitle
            // 
            this.textBoxOffSeasonTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxOffSeasonTitle.Enabled = false;
            this.textBoxOffSeasonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOffSeasonTitle.Location = new System.Drawing.Point(511, 6);
            this.textBoxOffSeasonTitle.Name = "textBoxOffSeasonTitle";
            this.textBoxOffSeasonTitle.Size = new System.Drawing.Size(615, 31);
            this.textBoxOffSeasonTitle.TabIndex = 15;
            this.textBoxOffSeasonTitle.Text = "Off-Season Recruiting Tools";
            this.textBoxOffSeasonTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabRecruits
            // 
            this.tabRecruits.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabRecruits.Controls.Add(this.groupBox39);
            this.tabRecruits.Controls.Add(this.TransferTeam);
            this.tabRecruits.Controls.Add(this.RecruitPitch);
            this.tabRecruits.Controls.Add(this.UpdateRecruitOffers);
            this.tabRecruits.Controls.Add(this.label207);
            this.tabRecruits.Controls.Add(this.RecruitDataGrid);
            this.tabRecruits.Controls.Add(this.label184);
            this.tabRecruits.Controls.Add(this.RDIS);
            this.tabRecruits.Controls.Add(this.PosRanking);
            this.tabRecruits.Controls.Add(this.CommitStatus);
            this.tabRecruits.Controls.Add(this.RecruitCounter);
            this.tabRecruits.Controls.Add(this.label205);
            this.tabRecruits.Controls.Add(this.label204);
            this.tabRecruits.Controls.Add(this.Label19084);
            this.tabRecruits.Controls.Add(this.RecruitPosFilter);
            this.tabRecruits.Controls.Add(this.RecruitStateFilter);
            this.tabRecruits.Controls.Add(this.RecruitTypeFilter);
            this.tabRecruits.Controls.Add(this.RCHTBox);
            this.tabRecruits.Controls.Add(this.RHometownBox);
            this.tabRecruits.Controls.Add(this.RecruitStarsText);
            this.tabRecruits.Controls.Add(this.AthleteBox);
            this.tabRecruits.Controls.Add(this.groupBox20);
            this.tabRecruits.Controls.Add(this.PRIDBox);
            this.tabRecruits.Controls.Add(this.PLNABox);
            this.tabRecruits.Controls.Add(this.PFNABox);
            this.tabRecruits.Controls.Add(this.label182);
            this.tabRecruits.Controls.Add(this.RecruitListBox);
            this.tabRecruits.Controls.Add(this.label154);
            this.tabRecruits.Controls.Add(this.RStateBox);
            this.tabRecruits.Controls.Add(this.label155);
            this.tabRecruits.Controls.Add(this.RYER);
            this.tabRecruits.Controls.Add(this.label156);
            this.tabRecruits.Controls.Add(this.RWGTBox);
            this.tabRecruits.Controls.Add(this.label157);
            this.tabRecruits.Controls.Add(this.RHGTBox);
            this.tabRecruits.Controls.Add(this.label158);
            this.tabRecruits.Controls.Add(this.RHEDBox);
            this.tabRecruits.Controls.Add(this.label159);
            this.tabRecruits.Controls.Add(this.RHCLBox);
            this.tabRecruits.Controls.Add(this.label160);
            this.tabRecruits.Controls.Add(this.RFMPBox);
            this.tabRecruits.Controls.Add(this.label161);
            this.tabRecruits.Controls.Add(this.RFGMBox);
            this.tabRecruits.Controls.Add(this.label162);
            this.tabRecruits.Controls.Add(this.RSKIBox);
            this.tabRecruits.Controls.Add(this.label163);
            this.tabRecruits.Controls.Add(this.RPPOSBox);
            this.tabRecruits.Controls.Add(this.label165);
            this.tabRecruits.Controls.Add(this.label166);
            this.tabRecruits.Location = new System.Drawing.Point(4, 24);
            this.tabRecruits.Name = "tabRecruits";
            this.tabRecruits.Size = new System.Drawing.Size(1152, 615);
            this.tabRecruits.TabIndex = 12;
            this.tabRecruits.Text = "Recruits";
            // 
            // groupBox39
            // 
            this.groupBox39.Controls.Add(this.GTransferRecruitable);
            this.groupBox39.Controls.Add(this.GTransferCommitted);
            this.groupBox39.Controls.Add(this.textBox21);
            this.groupBox39.Controls.Add(this.GTransferNew);
            this.groupBox39.Controls.Add(this.label261);
            this.groupBox39.Controls.Add(this.GTransferOG);
            this.groupBox39.Controls.Add(this.label260);
            this.groupBox39.Controls.Add(this.GlobalTransferInterest);
            this.groupBox39.Location = new System.Drawing.Point(719, 376);
            this.groupBox39.Name = "groupBox39";
            this.groupBox39.Size = new System.Drawing.Size(371, 209);
            this.groupBox39.TabIndex = 171;
            this.groupBox39.TabStop = false;
            this.groupBox39.Text = "Global Transfers Interest Editor";
            // 
            // GTransferRecruitable
            // 
            this.GTransferRecruitable.AutoSize = true;
            this.GTransferRecruitable.Checked = true;
            this.GTransferRecruitable.Location = new System.Drawing.Point(101, 179);
            this.GTransferRecruitable.Name = "GTransferRecruitable";
            this.GTransferRecruitable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GTransferRecruitable.Size = new System.Drawing.Size(79, 17);
            this.GTransferRecruitable.TabIndex = 7;
            this.GTransferRecruitable.TabStop = true;
            this.GTransferRecruitable.Text = "Recruitable";
            this.GTransferRecruitable.UseVisualStyleBackColor = true;
            // 
            // GTransferCommitted
            // 
            this.GTransferCommitted.AutoSize = true;
            this.GTransferCommitted.Location = new System.Drawing.Point(186, 179);
            this.GTransferCommitted.Name = "GTransferCommitted";
            this.GTransferCommitted.Size = new System.Drawing.Size(74, 17);
            this.GTransferCommitted.TabIndex = 6;
            this.GTransferCommitted.TabStop = true;
            this.GTransferCommitted.Text = "Committed";
            this.GTransferCommitted.UseVisualStyleBackColor = true;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.Location = new System.Drawing.Point(17, 21);
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(337, 54);
            this.textBox21.TabIndex = 5;
            this.textBox21.Text = "This allows users to force transfer portal players to have high interest from a s" +
    "pecfic team. Useful for forcing players to follow coach to a new team.\r\n";
            // 
            // GTransferNew
            // 
            this.GTransferNew.FormattingEnabled = true;
            this.GTransferNew.Location = new System.Drawing.Point(204, 104);
            this.GTransferNew.Name = "GTransferNew";
            this.GTransferNew.Size = new System.Drawing.Size(150, 21);
            this.GTransferNew.TabIndex = 4;
            // 
            // label261
            // 
            this.label261.AutoSize = true;
            this.label261.Location = new System.Drawing.Point(201, 88);
            this.label261.Name = "label261";
            this.label261.Size = new System.Drawing.Size(59, 13);
            this.label261.TabIndex = 3;
            this.label261.Text = "New Team";
            // 
            // GTransferOG
            // 
            this.GTransferOG.FormattingEnabled = true;
            this.GTransferOG.Location = new System.Drawing.Point(17, 105);
            this.GTransferOG.Name = "GTransferOG";
            this.GTransferOG.Size = new System.Drawing.Size(150, 21);
            this.GTransferOG.TabIndex = 2;
            // 
            // label260
            // 
            this.label260.AutoSize = true;
            this.label260.Location = new System.Drawing.Point(17, 88);
            this.label260.Name = "label260";
            this.label260.Size = new System.Drawing.Size(72, 13);
            this.label260.TabIndex = 1;
            this.label260.Text = "Original Team";
            // 
            // GlobalTransferInterest
            // 
            this.GlobalTransferInterest.BackColor = System.Drawing.SystemColors.Info;
            this.GlobalTransferInterest.Location = new System.Drawing.Point(110, 137);
            this.GlobalTransferInterest.Name = "GlobalTransferInterest";
            this.GlobalTransferInterest.Size = new System.Drawing.Size(140, 36);
            this.GlobalTransferInterest.TabIndex = 0;
            this.GlobalTransferInterest.Text = "Update Transfer Interests";
            this.GlobalTransferInterest.UseVisualStyleBackColor = false;
            this.GlobalTransferInterest.Click += new System.EventHandler(this.GlobalTransferInterest_Click);
            // 
            // TransferTeam
            // 
            this.TransferTeam.AutoSize = true;
            this.TransferTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferTeam.Location = new System.Drawing.Point(232, 590);
            this.TransferTeam.Name = "TransferTeam";
            this.TransferTeam.Size = new System.Drawing.Size(222, 18);
            this.TransferTeam.TabIndex = 170;
            this.TransferTeam.Text = "Current Team: Arizona State";
            // 
            // RecruitPitch
            // 
            this.RecruitPitch.AutoSize = true;
            this.RecruitPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecruitPitch.Location = new System.Drawing.Point(746, 334);
            this.RecruitPitch.Name = "RecruitPitch";
            this.RecruitPitch.Size = new System.Drawing.Size(193, 20);
            this.RecruitPitch.TabIndex = 169;
            this.RecruitPitch.Text = "Favorite Pitch: xxxxxxxx";
            // 
            // UpdateRecruitOffers
            // 
            this.UpdateRecruitOffers.Location = new System.Drawing.Point(969, 33);
            this.UpdateRecruitOffers.Name = "UpdateRecruitOffers";
            this.UpdateRecruitOffers.Size = new System.Drawing.Size(75, 23);
            this.UpdateRecruitOffers.TabIndex = 168;
            this.UpdateRecruitOffers.Text = "Update DB";
            this.UpdateRecruitOffers.UseVisualStyleBackColor = true;
            this.UpdateRecruitOffers.Click += new System.EventHandler(this.UpdateRecruitOffers_Click);
            // 
            // label207
            // 
            this.label207.AutoSize = true;
            this.label207.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label207.Location = new System.Drawing.Point(746, 33);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(184, 20);
            this.label207.TabIndex = 167;
            this.label207.Text = "Recruit Team Interest";
            // 
            // RecruitDataGrid
            // 
            this.RecruitDataGrid.AllowUserToAddRows = false;
            this.RecruitDataGrid.AllowUserToDeleteRows = false;
            this.RecruitDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RecruitDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle41;
            this.RecruitDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecruitDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RCNo,
            this.RCTeam,
            this.RCTScore});
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RecruitDataGrid.DefaultCellStyle = dataGridViewCellStyle42;
            this.RecruitDataGrid.Location = new System.Drawing.Point(750, 60);
            this.RecruitDataGrid.Name = "RecruitDataGrid";
            this.RecruitDataGrid.RowHeadersVisible = false;
            this.RecruitDataGrid.Size = new System.Drawing.Size(294, 249);
            this.RecruitDataGrid.TabIndex = 166;
            // 
            // RCNo
            // 
            this.RCNo.FillWeight = 20F;
            this.RCNo.HeaderText = "Rank";
            this.RCNo.Name = "RCNo";
            this.RCNo.ReadOnly = true;
            // 
            // RCTeam
            // 
            this.RCTeam.FillWeight = 50F;
            this.RCTeam.HeaderText = "Team";
            this.RCTeam.Name = "RCTeam";
            this.RCTeam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // RCTScore
            // 
            this.RCTScore.FillWeight = 35F;
            this.RCTScore.HeaderText = "Score";
            this.RCTScore.Name = "RCTScore";
            // 
            // label184
            // 
            this.label184.AutoSize = true;
            this.label184.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label184.Location = new System.Drawing.Point(551, 60);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(76, 16);
            this.label184.TabIndex = 165;
            this.label184.Text = "Discipline";
            this.label184.UseMnemonic = false;
            // 
            // RDIS
            // 
            this.RDIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDIS.Location = new System.Drawing.Point(554, 78);
            this.RDIS.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.RDIS.Name = "RDIS";
            this.RDIS.Size = new System.Drawing.Size(57, 22);
            this.RDIS.TabIndex = 149;
            this.RDIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RDIS.ValueChanged += new System.EventHandler(this.RDIS_ValueChanged);
            // 
            // PosRanking
            // 
            this.PosRanking.AutoSize = true;
            this.PosRanking.Location = new System.Drawing.Point(382, 37);
            this.PosRanking.Name = "PosRanking";
            this.PosRanking.Size = new System.Drawing.Size(108, 13);
            this.PosRanking.TabIndex = 164;
            this.PosRanking.Text = "Position Ranking: xxx";
            // 
            // CommitStatus
            // 
            this.CommitStatus.AutoSize = true;
            this.CommitStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitStatus.ForeColor = System.Drawing.Color.IndianRed;
            this.CommitStatus.Location = new System.Drawing.Point(530, 37);
            this.CommitStatus.Name = "CommitStatus";
            this.CommitStatus.Size = new System.Drawing.Size(157, 20);
            this.CommitStatus.TabIndex = 163;
            this.CommitStatus.Text = "Commitment Status";
            this.CommitStatus.UseVisualStyleBackColor = true;
            // 
            // RecruitCounter
            // 
            this.RecruitCounter.AutoSize = true;
            this.RecruitCounter.Location = new System.Drawing.Point(15, 595);
            this.RecruitCounter.Name = "RecruitCounter";
            this.RecruitCounter.Size = new System.Drawing.Size(78, 13);
            this.RecruitCounter.TabIndex = 162;
            this.RecruitCounter.Text = "Recruit Count: ";
            // 
            // label205
            // 
            this.label205.AutoSize = true;
            this.label205.Location = new System.Drawing.Point(159, 20);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(44, 13);
            this.label205.TabIndex = 161;
            this.label205.Text = "Position";
            // 
            // label204
            // 
            this.label204.AutoSize = true;
            this.label204.Location = new System.Drawing.Point(89, 18);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(32, 13);
            this.label204.TabIndex = 160;
            this.label204.Text = "State";
            // 
            // Label19084
            // 
            this.Label19084.AutoSize = true;
            this.Label19084.Location = new System.Drawing.Point(12, 20);
            this.Label19084.Name = "Label19084";
            this.Label19084.Size = new System.Drawing.Size(31, 13);
            this.Label19084.TabIndex = 159;
            this.Label19084.Text = "Type";
            // 
            // RecruitPosFilter
            // 
            this.RecruitPosFilter.FormattingEnabled = true;
            this.RecruitPosFilter.Location = new System.Drawing.Point(162, 37);
            this.RecruitPosFilter.Name = "RecruitPosFilter";
            this.RecruitPosFilter.Size = new System.Drawing.Size(54, 21);
            this.RecruitPosFilter.TabIndex = 158;
            this.RecruitPosFilter.SelectedIndexChanged += new System.EventHandler(this.RecruitPosFilter_SelectedIndexChanged);
            // 
            // RecruitStateFilter
            // 
            this.RecruitStateFilter.FormattingEnabled = true;
            this.RecruitStateFilter.Location = new System.Drawing.Point(92, 37);
            this.RecruitStateFilter.Name = "RecruitStateFilter";
            this.RecruitStateFilter.Size = new System.Drawing.Size(64, 21);
            this.RecruitStateFilter.TabIndex = 157;
            this.RecruitStateFilter.SelectedIndexChanged += new System.EventHandler(this.RecruitStateFilter_SelectedIndexChanged);
            // 
            // RecruitTypeFilter
            // 
            this.RecruitTypeFilter.FormattingEnabled = true;
            this.RecruitTypeFilter.Location = new System.Drawing.Point(12, 37);
            this.RecruitTypeFilter.Name = "RecruitTypeFilter";
            this.RecruitTypeFilter.Size = new System.Drawing.Size(74, 21);
            this.RecruitTypeFilter.TabIndex = 156;
            this.RecruitTypeFilter.SelectedIndexChanged += new System.EventHandler(this.RecruitTypeFilter_SelectedIndexChanged);
            // 
            // RCHTBox
            // 
            this.RCHTBox.AutoSize = true;
            this.RCHTBox.Location = new System.Drawing.Point(378, 112);
            this.RCHTBox.Name = "RCHTBox";
            this.RCHTBox.Size = new System.Drawing.Size(58, 13);
            this.RCHTBox.TabIndex = 155;
            this.RCHTBox.Text = "Hometown";
            // 
            // RHometownBox
            // 
            this.RHometownBox.FormattingEnabled = true;
            this.RHometownBox.Location = new System.Drawing.Point(376, 128);
            this.RHometownBox.Name = "RHometownBox";
            this.RHometownBox.Size = new System.Drawing.Size(102, 21);
            this.RHometownBox.TabIndex = 154;
            this.RHometownBox.SelectedIndexChanged += new System.EventHandler(this.RHometownBox_SelectedIndexChanged);
            // 
            // RecruitStarsText
            // 
            this.RecruitStarsText.AutoSize = true;
            this.RecruitStarsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecruitStarsText.Location = new System.Drawing.Point(378, 19);
            this.RecruitStarsText.Name = "RecruitStarsText";
            this.RecruitStarsText.Size = new System.Drawing.Size(113, 18);
            this.RecruitStarsText.TabIndex = 153;
            this.RecruitStarsText.Text = "5-Star Recruit";
            // 
            // AthleteBox
            // 
            this.AthleteBox.AutoSize = true;
            this.AthleteBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AthleteBox.Location = new System.Drawing.Point(530, 11);
            this.AthleteBox.Name = "AthleteBox";
            this.AthleteBox.Size = new System.Drawing.Size(74, 20);
            this.AthleteBox.TabIndex = 152;
            this.AthleteBox.Text = "Athlete";
            this.AthleteBox.UseVisualStyleBackColor = true;
            this.AthleteBox.CheckedChanged += new System.EventHandler(this.AthleteBox_CheckedChanged);
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.RTENBox);
            this.groupBox20.Controls.Add(this.label183);
            this.groupBox20.Controls.Add(this.RTHAtext);
            this.groupBox20.Controls.Add(this.RINJBox);
            this.groupBox20.Controls.Add(this.label185);
            this.groupBox20.Controls.Add(this.RKACtext);
            this.groupBox20.Controls.Add(this.RSPDBox);
            this.groupBox20.Controls.Add(this.RKPRtext);
            this.groupBox20.Controls.Add(this.label186);
            this.groupBox20.Controls.Add(this.RTAKtext);
            this.groupBox20.Controls.Add(this.RACCBox);
            this.groupBox20.Controls.Add(this.RPBKtext);
            this.groupBox20.Controls.Add(this.label187);
            this.groupBox20.Controls.Add(this.RSTRBox);
            this.groupBox20.Controls.Add(this.ROVR);
            this.groupBox20.Controls.Add(this.RCARtext);
            this.groupBox20.Controls.Add(this.label188);
            this.groupBox20.Controls.Add(this.RCTHtext);
            this.groupBox20.Controls.Add(this.RBTKBox);
            this.groupBox20.Controls.Add(this.RJMPtext);
            this.groupBox20.Controls.Add(this.label189);
            this.groupBox20.Controls.Add(this.RTHPBox);
            this.groupBox20.Controls.Add(this.label190);
            this.groupBox20.Controls.Add(this.RAGItext);
            this.groupBox20.Controls.Add(this.RRBKBox);
            this.groupBox20.Controls.Add(this.RAWRtext);
            this.groupBox20.Controls.Add(this.label191);
            this.groupBox20.Controls.Add(this.RPOEtext);
            this.groupBox20.Controls.Add(this.RPOEBox);
            this.groupBox20.Controls.Add(this.RRBKtext);
            this.groupBox20.Controls.Add(this.label192);
            this.groupBox20.Controls.Add(this.RTHPtext);
            this.groupBox20.Controls.Add(this.RAWRBox);
            this.groupBox20.Controls.Add(this.RBTKtext);
            this.groupBox20.Controls.Add(this.label193);
            this.groupBox20.Controls.Add(this.RSTRtext);
            this.groupBox20.Controls.Add(this.RAGIBox);
            this.groupBox20.Controls.Add(this.RACCtext);
            this.groupBox20.Controls.Add(this.label194);
            this.groupBox20.Controls.Add(this.label164);
            this.groupBox20.Controls.Add(this.RSPDtext);
            this.groupBox20.Controls.Add(this.RJMPBox);
            this.groupBox20.Controls.Add(this.RINJtext);
            this.groupBox20.Controls.Add(this.label195);
            this.groupBox20.Controls.Add(this.RCTHBox);
            this.groupBox20.Controls.Add(this.label196);
            this.groupBox20.Controls.Add(this.RCARBox);
            this.groupBox20.Controls.Add(this.label197);
            this.groupBox20.Controls.Add(this.RTHABox);
            this.groupBox20.Controls.Add(this.label198);
            this.groupBox20.Controls.Add(this.RPBKBox);
            this.groupBox20.Controls.Add(this.label199);
            this.groupBox20.Controls.Add(this.RTAKBox);
            this.groupBox20.Controls.Add(this.label200);
            this.groupBox20.Controls.Add(this.RKPRBox);
            this.groupBox20.Controls.Add(this.label201);
            this.groupBox20.Controls.Add(this.RKACBox);
            this.groupBox20.Controls.Add(this.label202);
            this.groupBox20.Location = new System.Drawing.Point(232, 211);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(400, 374);
            this.groupBox20.TabIndex = 151;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Attributes";
            // 
            // RTENBox
            // 
            this.RTENBox.BackColor = System.Drawing.SystemColors.Info;
            this.RTENBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTENBox.Location = new System.Drawing.Point(289, 19);
            this.RTENBox.Name = "RTENBox";
            this.RTENBox.ReadOnly = true;
            this.RTENBox.Size = new System.Drawing.Size(102, 20);
            this.RTENBox.TabIndex = 147;
            this.RTENBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label183
            // 
            this.label183.AutoSize = true;
            this.label183.Location = new System.Drawing.Point(198, 22);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(87, 13);
            this.label183.TabIndex = 148;
            this.label183.Text = "Player Archetype";
            this.label183.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTHAtext
            // 
            this.RTHAtext.BackColor = System.Drawing.SystemColors.Info;
            this.RTHAtext.Location = new System.Drawing.Point(277, 203);
            this.RTHAtext.Name = "RTHAtext";
            this.RTHAtext.ReadOnly = true;
            this.RTHAtext.Size = new System.Drawing.Size(39, 20);
            this.RTHAtext.TabIndex = 56;
            this.RTHAtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RINJBox
            // 
            this.RINJBox.Location = new System.Drawing.Point(122, 58);
            this.RINJBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RINJBox.Name = "RINJBox";
            this.RINJBox.Size = new System.Drawing.Size(57, 20);
            this.RINJBox.TabIndex = 15;
            this.RINJBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RINJBox.ValueChanged += new System.EventHandler(this.RINJBox_ValueChanged);
            // 
            // label185
            // 
            this.label185.AutoSize = true;
            this.label185.Location = new System.Drawing.Point(12, 60);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(63, 13);
            this.label185.TabIndex = 16;
            this.label185.Text = "Injury Prone";
            this.label185.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RKACtext
            // 
            this.RKACtext.BackColor = System.Drawing.SystemColors.Info;
            this.RKACtext.Location = new System.Drawing.Point(277, 344);
            this.RKACtext.Name = "RKACtext";
            this.RKACtext.ReadOnly = true;
            this.RKACtext.Size = new System.Drawing.Size(39, 20);
            this.RKACtext.TabIndex = 71;
            this.RKACtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RSPDBox
            // 
            this.RSPDBox.Location = new System.Drawing.Point(122, 95);
            this.RSPDBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RSPDBox.Name = "RSPDBox";
            this.RSPDBox.Size = new System.Drawing.Size(57, 20);
            this.RSPDBox.TabIndex = 18;
            this.RSPDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RSPDBox.ValueChanged += new System.EventHandler(this.RSPDBox_ValueChanged);
            // 
            // RKPRtext
            // 
            this.RKPRtext.BackColor = System.Drawing.SystemColors.Info;
            this.RKPRtext.Location = new System.Drawing.Point(77, 345);
            this.RKPRtext.Name = "RKPRtext";
            this.RKPRtext.ReadOnly = true;
            this.RKPRtext.Size = new System.Drawing.Size(39, 20);
            this.RKPRtext.TabIndex = 65;
            this.RKPRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label186
            // 
            this.label186.AutoSize = true;
            this.label186.Location = new System.Drawing.Point(37, 98);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(38, 13);
            this.label186.TabIndex = 19;
            this.label186.Text = "Speed";
            this.label186.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTAKtext
            // 
            this.RTAKtext.BackColor = System.Drawing.SystemColors.Info;
            this.RTAKtext.Location = new System.Drawing.Point(276, 311);
            this.RTAKtext.Name = "RTAKtext";
            this.RTAKtext.ReadOnly = true;
            this.RTAKtext.Size = new System.Drawing.Size(39, 20);
            this.RTAKtext.TabIndex = 62;
            this.RTAKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RACCBox
            // 
            this.RACCBox.Location = new System.Drawing.Point(122, 130);
            this.RACCBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RACCBox.Name = "RACCBox";
            this.RACCBox.Size = new System.Drawing.Size(57, 20);
            this.RACCBox.TabIndex = 21;
            this.RACCBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RACCBox.ValueChanged += new System.EventHandler(this.RACCBox_ValueChanged);
            // 
            // RPBKtext
            // 
            this.RPBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.RPBKtext.Location = new System.Drawing.Point(277, 274);
            this.RPBKtext.Name = "RPBKtext";
            this.RPBKtext.ReadOnly = true;
            this.RPBKtext.Size = new System.Drawing.Size(39, 20);
            this.RPBKtext.TabIndex = 59;
            this.RPBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label187
            // 
            this.label187.AutoSize = true;
            this.label187.Location = new System.Drawing.Point(9, 132);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(66, 13);
            this.label187.TabIndex = 22;
            this.label187.Text = "Acceleration";
            this.label187.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RSTRBox
            // 
            this.RSTRBox.Location = new System.Drawing.Point(122, 167);
            this.RSTRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RSTRBox.Name = "RSTRBox";
            this.RSTRBox.Size = new System.Drawing.Size(57, 20);
            this.RSTRBox.TabIndex = 24;
            this.RSTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RSTRBox.ValueChanged += new System.EventHandler(this.RSTRBox_ValueChanged);
            // 
            // ROVR
            // 
            this.ROVR.BackColor = System.Drawing.SystemColors.Info;
            this.ROVR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ROVR.Location = new System.Drawing.Point(100, 17);
            this.ROVR.Name = "ROVR";
            this.ROVR.ReadOnly = true;
            this.ROVR.Size = new System.Drawing.Size(53, 22);
            this.ROVR.TabIndex = 106;
            this.ROVR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RCARtext
            // 
            this.RCARtext.BackColor = System.Drawing.SystemColors.Info;
            this.RCARtext.Location = new System.Drawing.Point(277, 238);
            this.RCARtext.Name = "RCARtext";
            this.RCARtext.ReadOnly = true;
            this.RCARtext.Size = new System.Drawing.Size(39, 20);
            this.RCARtext.TabIndex = 53;
            this.RCARtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label188
            // 
            this.label188.AutoSize = true;
            this.label188.Location = new System.Drawing.Point(28, 169);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(47, 13);
            this.label188.TabIndex = 25;
            this.label188.Text = "Strength";
            this.label188.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RCTHtext
            // 
            this.RCTHtext.BackColor = System.Drawing.SystemColors.Info;
            this.RCTHtext.Location = new System.Drawing.Point(76, 309);
            this.RCTHtext.Name = "RCTHtext";
            this.RCTHtext.ReadOnly = true;
            this.RCTHtext.Size = new System.Drawing.Size(39, 20);
            this.RCTHtext.TabIndex = 50;
            this.RCTHtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RBTKBox
            // 
            this.RBTKBox.Location = new System.Drawing.Point(122, 239);
            this.RBTKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RBTKBox.Name = "RBTKBox";
            this.RBTKBox.Size = new System.Drawing.Size(57, 20);
            this.RBTKBox.TabIndex = 27;
            this.RBTKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RBTKBox.ValueChanged += new System.EventHandler(this.RBTKBox_ValueChanged);
            // 
            // RJMPtext
            // 
            this.RJMPtext.BackColor = System.Drawing.SystemColors.Info;
            this.RJMPtext.Location = new System.Drawing.Point(276, 165);
            this.RJMPtext.Name = "RJMPtext";
            this.RJMPtext.ReadOnly = true;
            this.RJMPtext.Size = new System.Drawing.Size(39, 20);
            this.RJMPtext.TabIndex = 47;
            this.RJMPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label189
            // 
            this.label189.AutoSize = true;
            this.label189.Location = new System.Drawing.Point(5, 241);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(71, 13);
            this.label189.TabIndex = 28;
            this.label189.Text = "Break Tackle";
            this.label189.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTHPBox
            // 
            this.RTHPBox.Location = new System.Drawing.Point(122, 204);
            this.RTHPBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RTHPBox.Name = "RTHPBox";
            this.RTHPBox.Size = new System.Drawing.Size(57, 20);
            this.RTHPBox.TabIndex = 30;
            this.RTHPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RTHPBox.ValueChanged += new System.EventHandler(this.RTHPBox_ValueChanged);
            // 
            // label190
            // 
            this.label190.AutoSize = true;
            this.label190.Location = new System.Drawing.Point(5, 206);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(70, 13);
            this.label190.TabIndex = 31;
            this.label190.Text = "Throw Power";
            this.label190.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RAGItext
            // 
            this.RAGItext.BackColor = System.Drawing.SystemColors.Info;
            this.RAGItext.Location = new System.Drawing.Point(276, 130);
            this.RAGItext.Name = "RAGItext";
            this.RAGItext.ReadOnly = true;
            this.RAGItext.Size = new System.Drawing.Size(39, 20);
            this.RAGItext.TabIndex = 44;
            this.RAGItext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RRBKBox
            // 
            this.RRBKBox.Location = new System.Drawing.Point(122, 275);
            this.RRBKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RRBKBox.Name = "RRBKBox";
            this.RRBKBox.Size = new System.Drawing.Size(57, 20);
            this.RRBKBox.TabIndex = 33;
            this.RRBKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RRBKBox.ValueChanged += new System.EventHandler(this.RRBKBox_ValueChanged);
            // 
            // RAWRtext
            // 
            this.RAWRtext.BackColor = System.Drawing.SystemColors.Info;
            this.RAWRtext.Location = new System.Drawing.Point(276, 93);
            this.RAWRtext.Name = "RAWRtext";
            this.RAWRtext.ReadOnly = true;
            this.RAWRtext.Size = new System.Drawing.Size(39, 20);
            this.RAWRtext.TabIndex = 41;
            this.RAWRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label191
            // 
            this.label191.AutoSize = true;
            this.label191.Location = new System.Drawing.Point(5, 277);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(71, 13);
            this.label191.TabIndex = 34;
            this.label191.Text = "Run Blocking";
            this.label191.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RPOEtext
            // 
            this.RPOEtext.BackColor = System.Drawing.SystemColors.Info;
            this.RPOEtext.Location = new System.Drawing.Point(276, 57);
            this.RPOEtext.Name = "RPOEtext";
            this.RPOEtext.ReadOnly = true;
            this.RPOEtext.Size = new System.Drawing.Size(39, 20);
            this.RPOEtext.TabIndex = 38;
            this.RPOEtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RPOEBox
            // 
            this.RPOEBox.Location = new System.Drawing.Point(321, 57);
            this.RPOEBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RPOEBox.Name = "RPOEBox";
            this.RPOEBox.Size = new System.Drawing.Size(57, 20);
            this.RPOEBox.TabIndex = 36;
            this.RPOEBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RPOEBox.ValueChanged += new System.EventHandler(this.RPOEBox_ValueChanged);
            // 
            // RRBKtext
            // 
            this.RRBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.RRBKtext.Location = new System.Drawing.Point(77, 275);
            this.RRBKtext.Name = "RRBKtext";
            this.RRBKtext.ReadOnly = true;
            this.RRBKtext.Size = new System.Drawing.Size(39, 20);
            this.RRBKtext.TabIndex = 35;
            this.RRBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label192
            // 
            this.label192.AutoSize = true;
            this.label192.Location = new System.Drawing.Point(224, 62);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(48, 13);
            this.label192.TabIndex = 37;
            this.label192.Text = "Potential";
            this.label192.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTHPtext
            // 
            this.RTHPtext.BackColor = System.Drawing.SystemColors.Info;
            this.RTHPtext.Location = new System.Drawing.Point(77, 204);
            this.RTHPtext.Name = "RTHPtext";
            this.RTHPtext.ReadOnly = true;
            this.RTHPtext.Size = new System.Drawing.Size(39, 20);
            this.RTHPtext.TabIndex = 32;
            this.RTHPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RAWRBox
            // 
            this.RAWRBox.Location = new System.Drawing.Point(321, 93);
            this.RAWRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RAWRBox.Name = "RAWRBox";
            this.RAWRBox.Size = new System.Drawing.Size(57, 20);
            this.RAWRBox.TabIndex = 39;
            this.RAWRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RAWRBox.ValueChanged += new System.EventHandler(this.RAWRBox_ValueChanged);
            // 
            // RBTKtext
            // 
            this.RBTKtext.BackColor = System.Drawing.SystemColors.Info;
            this.RBTKtext.Location = new System.Drawing.Point(77, 239);
            this.RBTKtext.Name = "RBTKtext";
            this.RBTKtext.ReadOnly = true;
            this.RBTKtext.Size = new System.Drawing.Size(39, 20);
            this.RBTKtext.TabIndex = 29;
            this.RBTKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label193
            // 
            this.label193.AutoSize = true;
            this.label193.Location = new System.Drawing.Point(212, 97);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(59, 13);
            this.label193.TabIndex = 40;
            this.label193.Text = "Awareness";
            this.label193.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RSTRtext
            // 
            this.RSTRtext.BackColor = System.Drawing.SystemColors.Info;
            this.RSTRtext.Location = new System.Drawing.Point(77, 167);
            this.RSTRtext.Name = "RSTRtext";
            this.RSTRtext.ReadOnly = true;
            this.RSTRtext.Size = new System.Drawing.Size(39, 20);
            this.RSTRtext.TabIndex = 26;
            this.RSTRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RAGIBox
            // 
            this.RAGIBox.Location = new System.Drawing.Point(321, 130);
            this.RAGIBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RAGIBox.Name = "RAGIBox";
            this.RAGIBox.Size = new System.Drawing.Size(57, 20);
            this.RAGIBox.TabIndex = 42;
            this.RAGIBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RAGIBox.ValueChanged += new System.EventHandler(this.RAGIBox_ValueChanged);
            // 
            // RACCtext
            // 
            this.RACCtext.BackColor = System.Drawing.SystemColors.Info;
            this.RACCtext.Location = new System.Drawing.Point(77, 130);
            this.RACCtext.Name = "RACCtext";
            this.RACCtext.ReadOnly = true;
            this.RACCtext.Size = new System.Drawing.Size(39, 20);
            this.RACCtext.TabIndex = 23;
            this.RACCtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label194
            // 
            this.label194.AutoSize = true;
            this.label194.Location = new System.Drawing.Point(237, 135);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(34, 13);
            this.label194.TabIndex = 43;
            this.label194.Text = "Agility";
            this.label194.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label164
            // 
            this.label164.AutoSize = true;
            this.label164.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label164.Location = new System.Drawing.Point(37, 22);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(57, 16);
            this.label164.TabIndex = 107;
            this.label164.Text = "Overall";
            // 
            // RSPDtext
            // 
            this.RSPDtext.BackColor = System.Drawing.SystemColors.Info;
            this.RSPDtext.Location = new System.Drawing.Point(77, 95);
            this.RSPDtext.Name = "RSPDtext";
            this.RSPDtext.ReadOnly = true;
            this.RSPDtext.Size = new System.Drawing.Size(39, 20);
            this.RSPDtext.TabIndex = 20;
            this.RSPDtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RJMPBox
            // 
            this.RJMPBox.Location = new System.Drawing.Point(321, 165);
            this.RJMPBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RJMPBox.Name = "RJMPBox";
            this.RJMPBox.Size = new System.Drawing.Size(57, 20);
            this.RJMPBox.TabIndex = 45;
            this.RJMPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RJMPBox.ValueChanged += new System.EventHandler(this.RJMPBox_ValueChanged);
            // 
            // RINJtext
            // 
            this.RINJtext.BackColor = System.Drawing.SystemColors.Info;
            this.RINJtext.Location = new System.Drawing.Point(77, 58);
            this.RINJtext.Name = "RINJtext";
            this.RINJtext.ReadOnly = true;
            this.RINJtext.Size = new System.Drawing.Size(39, 20);
            this.RINJtext.TabIndex = 17;
            this.RINJtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label195
            // 
            this.label195.AutoSize = true;
            this.label195.Location = new System.Drawing.Point(225, 170);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(46, 13);
            this.label195.TabIndex = 46;
            this.label195.Text = "Jumping";
            this.label195.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RCTHBox
            // 
            this.RCTHBox.Location = new System.Drawing.Point(121, 309);
            this.RCTHBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RCTHBox.Name = "RCTHBox";
            this.RCTHBox.Size = new System.Drawing.Size(57, 20);
            this.RCTHBox.TabIndex = 48;
            this.RCTHBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RCTHBox.ValueChanged += new System.EventHandler(this.RCTHBox_ValueChanged);
            // 
            // label196
            // 
            this.label196.AutoSize = true;
            this.label196.Location = new System.Drawing.Point(22, 311);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(49, 13);
            this.label196.TabIndex = 49;
            this.label196.Text = "Catching";
            this.label196.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RCARBox
            // 
            this.RCARBox.Location = new System.Drawing.Point(322, 238);
            this.RCARBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RCARBox.Name = "RCARBox";
            this.RCARBox.Size = new System.Drawing.Size(57, 20);
            this.RCARBox.TabIndex = 51;
            this.RCARBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RCARBox.ValueChanged += new System.EventHandler(this.RCARBox_ValueChanged);
            // 
            // label197
            // 
            this.label197.AutoSize = true;
            this.label197.Location = new System.Drawing.Point(207, 243);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(65, 13);
            this.label197.TabIndex = 52;
            this.label197.Text = "Ball Carrying";
            this.label197.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTHABox
            // 
            this.RTHABox.Location = new System.Drawing.Point(322, 203);
            this.RTHABox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RTHABox.Name = "RTHABox";
            this.RTHABox.Size = new System.Drawing.Size(57, 20);
            this.RTHABox.TabIndex = 54;
            this.RTHABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RTHABox.ValueChanged += new System.EventHandler(this.RTHABox_ValueChanged);
            // 
            // label198
            // 
            this.label198.AutoSize = true;
            this.label198.Location = new System.Drawing.Point(192, 208);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(85, 13);
            this.label198.TabIndex = 55;
            this.label198.Text = "Throw Accuracy";
            this.label198.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RPBKBox
            // 
            this.RPBKBox.Location = new System.Drawing.Point(322, 274);
            this.RPBKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RPBKBox.Name = "RPBKBox";
            this.RPBKBox.Size = new System.Drawing.Size(57, 20);
            this.RPBKBox.TabIndex = 57;
            this.RPBKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RPBKBox.ValueChanged += new System.EventHandler(this.RPBKBox_ValueChanged);
            // 
            // label199
            // 
            this.label199.AutoSize = true;
            this.label199.Location = new System.Drawing.Point(202, 278);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(74, 13);
            this.label199.TabIndex = 58;
            this.label199.Text = "Pass Blocking";
            this.label199.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RTAKBox
            // 
            this.RTAKBox.Location = new System.Drawing.Point(321, 311);
            this.RTAKBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RTAKBox.Name = "RTAKBox";
            this.RTAKBox.Size = new System.Drawing.Size(57, 20);
            this.RTAKBox.TabIndex = 60;
            this.RTAKBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RTAKBox.ValueChanged += new System.EventHandler(this.RTAKBox_ValueChanged);
            // 
            // label200
            // 
            this.label200.AutoSize = true;
            this.label200.Location = new System.Drawing.Point(226, 311);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(48, 13);
            this.label200.TabIndex = 61;
            this.label200.Text = "Tackling";
            this.label200.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RKPRBox
            // 
            this.RKPRBox.Location = new System.Drawing.Point(122, 345);
            this.RKPRBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RKPRBox.Name = "RKPRBox";
            this.RKPRBox.Size = new System.Drawing.Size(57, 20);
            this.RKPRBox.TabIndex = 63;
            this.RKPRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RKPRBox.ValueChanged += new System.EventHandler(this.RKPRBox_ValueChanged);
            // 
            // label201
            // 
            this.label201.AutoSize = true;
            this.label201.Location = new System.Drawing.Point(14, 348);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(61, 13);
            this.label201.TabIndex = 64;
            this.label201.Text = "Kick Power";
            this.label201.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RKACBox
            // 
            this.RKACBox.Location = new System.Drawing.Point(322, 344);
            this.RKACBox.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.RKACBox.Name = "RKACBox";
            this.RKACBox.Size = new System.Drawing.Size(57, 20);
            this.RKACBox.TabIndex = 69;
            this.RKACBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RKACBox.ValueChanged += new System.EventHandler(this.RKACBox_ValueChanged);
            // 
            // label202
            // 
            this.label202.AutoSize = true;
            this.label202.Location = new System.Drawing.Point(197, 348);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(76, 13);
            this.label202.TabIndex = 70;
            this.label202.Text = "Kick Accuracy";
            this.label202.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PRIDBox
            // 
            this.PRIDBox.BackColor = System.Drawing.SystemColors.Info;
            this.PRIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRIDBox.Location = new System.Drawing.Point(305, 22);
            this.PRIDBox.Name = "PRIDBox";
            this.PRIDBox.ReadOnly = true;
            this.PRIDBox.Size = new System.Drawing.Size(53, 22);
            this.PRIDBox.TabIndex = 131;
            this.PRIDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PLNABox
            // 
            this.PLNABox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLNABox.Location = new System.Drawing.Point(354, 80);
            this.PLNABox.Name = "PLNABox";
            this.PLNABox.Size = new System.Drawing.Size(111, 22);
            this.PLNABox.TabIndex = 103;
            this.PLNABox.Leave += new System.EventHandler(this.PLNABox_Leave);
            // 
            // PFNABox
            // 
            this.PFNABox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PFNABox.Location = new System.Drawing.Point(232, 80);
            this.PFNABox.Name = "PFNABox";
            this.PFNABox.Size = new System.Drawing.Size(116, 22);
            this.PFNABox.TabIndex = 102;
            this.PFNABox.Leave += new System.EventHandler(this.PFNABox_Leave);
            // 
            // label182
            // 
            this.label182.AutoSize = true;
            this.label182.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label182.Location = new System.Drawing.Point(229, 25);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(75, 16);
            this.label182.TabIndex = 132;
            this.label182.Text = "Recruit ID";
            // 
            // RecruitListBox
            // 
            this.RecruitListBox.BackColor = System.Drawing.Color.White;
            this.RecruitListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RecruitListBox.FormattingEnabled = true;
            this.RecruitListBox.Location = new System.Drawing.Point(12, 64);
            this.RecruitListBox.Name = "RecruitListBox";
            this.RecruitListBox.Size = new System.Drawing.Size(203, 524);
            this.RecruitListBox.TabIndex = 130;
            this.RecruitListBox.SelectedIndexChanged += new System.EventHandler(this.RecruitListBox_SelectedIndexChanged);
            // 
            // label154
            // 
            this.label154.AutoSize = true;
            this.label154.Location = new System.Drawing.Point(314, 112);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(32, 13);
            this.label154.TabIndex = 127;
            this.label154.Text = "State";
            // 
            // RStateBox
            // 
            this.RStateBox.FormattingEnabled = true;
            this.RStateBox.Location = new System.Drawing.Point(317, 128);
            this.RStateBox.Name = "RStateBox";
            this.RStateBox.Size = new System.Drawing.Size(53, 21);
            this.RStateBox.TabIndex = 126;
            this.RStateBox.SelectedIndexChanged += new System.EventHandler(this.RStateBox_SelectedIndexChanged);
            // 
            // label155
            // 
            this.label155.AutoSize = true;
            this.label155.Location = new System.Drawing.Point(231, 113);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(29, 13);
            this.label155.TabIndex = 125;
            this.label155.Text = "Year";
            // 
            // RYER
            // 
            this.RYER.FormattingEnabled = true;
            this.RYER.Location = new System.Drawing.Point(232, 128);
            this.RYER.Name = "RYER";
            this.RYER.Size = new System.Drawing.Size(79, 21);
            this.RYER.TabIndex = 124;
            this.RYER.SelectedIndexChanged += new System.EventHandler(this.RYER_SelectedIndexChanged);
            // 
            // label156
            // 
            this.label156.AutoSize = true;
            this.label156.Location = new System.Drawing.Point(548, 114);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(63, 13);
            this.label156.TabIndex = 123;
            this.label156.Text = "Weight (lbs)";
            this.label156.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RWGTBox
            // 
            this.RWGTBox.Location = new System.Drawing.Point(547, 129);
            this.RWGTBox.Maximum = new decimal(new int[] {
            415,
            0,
            0,
            0});
            this.RWGTBox.Minimum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.RWGTBox.Name = "RWGTBox";
            this.RWGTBox.Size = new System.Drawing.Size(57, 20);
            this.RWGTBox.TabIndex = 122;
            this.RWGTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RWGTBox.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.RWGTBox.ValueChanged += new System.EventHandler(this.RWGTBox_ValueChanged);
            // 
            // label157
            // 
            this.label157.AutoSize = true;
            this.label157.Location = new System.Drawing.Point(481, 114);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(55, 13);
            this.label157.TabIndex = 121;
            this.label157.Text = "Height (in)";
            this.label157.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RHGTBox
            // 
            this.RHGTBox.Location = new System.Drawing.Point(484, 129);
            this.RHGTBox.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.RHGTBox.Name = "RHGTBox";
            this.RHGTBox.Size = new System.Drawing.Size(57, 20);
            this.RHGTBox.TabIndex = 120;
            this.RHGTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RHGTBox.ValueChanged += new System.EventHandler(this.RHGTBox_ValueChanged);
            // 
            // label158
            // 
            this.label158.AutoSize = true;
            this.label158.Location = new System.Drawing.Point(518, 155);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(52, 13);
            this.label158.TabIndex = 119;
            this.label158.Text = "Hair Style";
            // 
            // RHEDBox
            // 
            this.RHEDBox.FormattingEnabled = true;
            this.RHEDBox.Location = new System.Drawing.Point(521, 171);
            this.RHEDBox.Name = "RHEDBox";
            this.RHEDBox.Size = new System.Drawing.Size(90, 21);
            this.RHEDBox.TabIndex = 118;
            this.RHEDBox.SelectedIndexChanged += new System.EventHandler(this.RHEDBox_SelectedIndexChanged);
            // 
            // label159
            // 
            this.label159.AutoSize = true;
            this.label159.Location = new System.Drawing.Point(418, 155);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(53, 13);
            this.label159.TabIndex = 117;
            this.label159.Text = "Hair Color";
            // 
            // RHCLBox
            // 
            this.RHCLBox.FormattingEnabled = true;
            this.RHCLBox.Location = new System.Drawing.Point(421, 171);
            this.RHCLBox.Name = "RHCLBox";
            this.RHCLBox.Size = new System.Drawing.Size(94, 21);
            this.RHCLBox.TabIndex = 116;
            this.RHCLBox.SelectedIndexChanged += new System.EventHandler(this.RHCLBox_SelectedIndexChanged);
            // 
            // label160
            // 
            this.label160.AutoSize = true;
            this.label160.Location = new System.Drawing.Point(361, 154);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(31, 13);
            this.label160.TabIndex = 115;
            this.label160.Text = "Face";
            // 
            // RFMPBox
            // 
            this.RFMPBox.FormattingEnabled = true;
            this.RFMPBox.Location = new System.Drawing.Point(364, 171);
            this.RFMPBox.Name = "RFMPBox";
            this.RFMPBox.Size = new System.Drawing.Size(51, 21);
            this.RFMPBox.TabIndex = 114;
            this.RFMPBox.SelectedIndexChanged += new System.EventHandler(this.RFMPBox_SelectedIndexChanged);
            // 
            // label161
            // 
            this.label161.AutoSize = true;
            this.label161.Location = new System.Drawing.Point(310, 154);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(38, 13);
            this.label161.TabIndex = 113;
            this.label161.Text = "Shape";
            // 
            // RFGMBox
            // 
            this.RFGMBox.FormattingEnabled = true;
            this.RFGMBox.Location = new System.Drawing.Point(313, 171);
            this.RFGMBox.Name = "RFGMBox";
            this.RFGMBox.Size = new System.Drawing.Size(45, 21);
            this.RFGMBox.TabIndex = 112;
            this.RFGMBox.SelectedIndexChanged += new System.EventHandler(this.RFGMBox_SelectedIndexChanged);
            // 
            // label162
            // 
            this.label162.AutoSize = true;
            this.label162.Location = new System.Drawing.Point(241, 154);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(56, 13);
            this.label162.TabIndex = 111;
            this.label162.Text = "Skin Tone";
            // 
            // RSKIBox
            // 
            this.RSKIBox.FormattingEnabled = true;
            this.RSKIBox.Location = new System.Drawing.Point(240, 171);
            this.RSKIBox.Name = "RSKIBox";
            this.RSKIBox.Size = new System.Drawing.Size(67, 21);
            this.RSKIBox.TabIndex = 110;
            this.RSKIBox.SelectedIndexChanged += new System.EventHandler(this.RSKIBox_SelectedIndexChanged);
            // 
            // label163
            // 
            this.label163.AutoSize = true;
            this.label163.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label163.Location = new System.Drawing.Point(471, 60);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(63, 16);
            this.label163.TabIndex = 109;
            this.label163.Text = "Position";
            // 
            // RPPOSBox
            // 
            this.RPPOSBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RPPOSBox.FormattingEnabled = true;
            this.RPPOSBox.Location = new System.Drawing.Point(474, 78);
            this.RPPOSBox.Name = "RPPOSBox";
            this.RPPOSBox.Size = new System.Drawing.Size(71, 24);
            this.RPPOSBox.TabIndex = 108;
            this.RPPOSBox.SelectedIndexChanged += new System.EventHandler(this.RPPOSBox_SelectedIndexChanged);
            // 
            // label165
            // 
            this.label165.AutoSize = true;
            this.label165.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label165.Location = new System.Drawing.Point(351, 60);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(81, 16);
            this.label165.TabIndex = 105;
            this.label165.Text = "Last Name";
            // 
            // label166
            // 
            this.label166.AutoSize = true;
            this.label166.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label166.Location = new System.Drawing.Point(232, 60);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(82, 16);
            this.label166.TabIndex = 104;
            this.label166.Text = "First Name";
            // 
            // tabStats
            // 
            this.tabStats.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabStats.Controls.Add(this.groupBox26);
            this.tabStats.Controls.Add(this.groupBox25);
            this.tabStats.Controls.Add(this.groupBox24);
            this.tabStats.Location = new System.Drawing.Point(4, 24);
            this.tabStats.Name = "tabStats";
            this.tabStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabStats.Size = new System.Drawing.Size(1152, 615);
            this.tabStats.TabIndex = 15;
            this.tabStats.Text = "Stats";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.label221);
            this.groupBox26.Controls.Add(this.SacksLeadersBox);
            this.groupBox26.Controls.Add(this.IntLeadersBox);
            this.groupBox26.Controls.Add(this.label223);
            this.groupBox26.Controls.Add(this.label222);
            this.groupBox26.Controls.Add(this.TacklesLeadersBox);
            this.groupBox26.Location = new System.Drawing.Point(832, 24);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(280, 572);
            this.groupBox26.TabIndex = 2;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Defense Leaders";
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(194, 377);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(68, 13);
            this.label221.TabIndex = 19;
            this.label221.Text = "Interceptions";
            // 
            // SacksLeadersBox
            // 
            this.SacksLeadersBox.FormattingEnabled = true;
            this.SacksLeadersBox.Location = new System.Drawing.Point(19, 29);
            this.SacksLeadersBox.Name = "SacksLeadersBox";
            this.SacksLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.SacksLeadersBox.TabIndex = 14;
            // 
            // IntLeadersBox
            // 
            this.IntLeadersBox.FormattingEnabled = true;
            this.IntLeadersBox.Location = new System.Drawing.Point(20, 393);
            this.IntLeadersBox.Name = "IntLeadersBox";
            this.IntLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.IntLeadersBox.TabIndex = 18;
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Location = new System.Drawing.Point(225, 13);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(37, 13);
            this.label223.TabIndex = 15;
            this.label223.Text = "Sacks";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(217, 198);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(45, 13);
            this.label222.TabIndex = 17;
            this.label222.Text = "Tackles";
            // 
            // TacklesLeadersBox
            // 
            this.TacklesLeadersBox.FormattingEnabled = true;
            this.TacklesLeadersBox.Location = new System.Drawing.Point(22, 214);
            this.TacklesLeadersBox.Name = "TacklesLeadersBox";
            this.TacklesLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.TacklesLeadersBox.TabIndex = 16;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label220);
            this.groupBox25.Controls.Add(this.ReceivingLeadersBox);
            this.groupBox25.Controls.Add(this.label219);
            this.groupBox25.Controls.Add(this.RushingLeadersBox);
            this.groupBox25.Controls.Add(this.label218);
            this.groupBox25.Controls.Add(this.PassingLeadersBox);
            this.groupBox25.Location = new System.Drawing.Point(513, 24);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(280, 572);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Offense Leaders";
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(175, 377);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(85, 13);
            this.label220.TabIndex = 13;
            this.label220.Text = "Receiving Yards";
            // 
            // ReceivingLeadersBox
            // 
            this.ReceivingLeadersBox.FormattingEnabled = true;
            this.ReceivingLeadersBox.Location = new System.Drawing.Point(17, 393);
            this.ReceivingLeadersBox.Name = "ReceivingLeadersBox";
            this.ReceivingLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.ReceivingLeadersBox.TabIndex = 12;
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(187, 198);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(76, 13);
            this.label219.TabIndex = 11;
            this.label219.Text = "Rushing Yards";
            // 
            // RushingLeadersBox
            // 
            this.RushingLeadersBox.FormattingEnabled = true;
            this.RushingLeadersBox.Location = new System.Drawing.Point(19, 214);
            this.RushingLeadersBox.Name = "RushingLeadersBox";
            this.RushingLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.RushingLeadersBox.TabIndex = 10;
            // 
            // label218
            // 
            this.label218.AutoSize = true;
            this.label218.Location = new System.Drawing.Point(185, 13);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(74, 13);
            this.label218.TabIndex = 9;
            this.label218.Text = "Passing Yards";
            // 
            // PassingLeadersBox
            // 
            this.PassingLeadersBox.FormattingEnabled = true;
            this.PassingLeadersBox.Location = new System.Drawing.Point(16, 29);
            this.PassingLeadersBox.Name = "PassingLeadersBox";
            this.PassingLeadersBox.Size = new System.Drawing.Size(243, 160);
            this.PassingLeadersBox.TabIndex = 8;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.label217);
            this.groupBox24.Controls.Add(this.label216);
            this.groupBox24.Controls.Add(this.label215);
            this.groupBox24.Controls.Add(this.label214);
            this.groupBox24.Controls.Add(this.TopTeamDefBox);
            this.groupBox24.Controls.Add(this.TopTeamOffBox);
            this.groupBox24.Controls.Add(this.TopTeamRatingsBox);
            this.groupBox24.Controls.Add(this.CoachPollListBox);
            this.groupBox24.Location = new System.Drawing.Point(29, 24);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(423, 572);
            this.groupBox24.TabIndex = 0;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Rankings";
            // 
            // label217
            // 
            this.label217.AutoSize = true;
            this.label217.Location = new System.Drawing.Point(339, 378);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(74, 13);
            this.label217.TabIndex = 7;
            this.label217.Text = "Total Defense";
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(131, 378);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(71, 13);
            this.label216.TabIndex = 6;
            this.label216.Text = "Total Offense";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(339, 13);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(74, 13);
            this.label215.TabIndex = 5;
            this.label215.Text = "Overall Rating";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(141, 13);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(61, 13);
            this.label214.TabIndex = 4;
            this.label214.Text = "Top 25 Poll";
            // 
            // TopTeamDefBox
            // 
            this.TopTeamDefBox.FormattingEnabled = true;
            this.TopTeamDefBox.Location = new System.Drawing.Point(222, 394);
            this.TopTeamDefBox.Name = "TopTeamDefBox";
            this.TopTeamDefBox.Size = new System.Drawing.Size(191, 160);
            this.TopTeamDefBox.TabIndex = 3;
            // 
            // TopTeamOffBox
            // 
            this.TopTeamOffBox.FormattingEnabled = true;
            this.TopTeamOffBox.Location = new System.Drawing.Point(11, 394);
            this.TopTeamOffBox.Name = "TopTeamOffBox";
            this.TopTeamOffBox.Size = new System.Drawing.Size(191, 160);
            this.TopTeamOffBox.TabIndex = 2;
            // 
            // TopTeamRatingsBox
            // 
            this.TopTeamRatingsBox.FormattingEnabled = true;
            this.TopTeamRatingsBox.Location = new System.Drawing.Point(222, 29);
            this.TopTeamRatingsBox.Name = "TopTeamRatingsBox";
            this.TopTeamRatingsBox.Size = new System.Drawing.Size(191, 329);
            this.TopTeamRatingsBox.TabIndex = 1;
            // 
            // CoachPollListBox
            // 
            this.CoachPollListBox.FormattingEnabled = true;
            this.CoachPollListBox.Location = new System.Drawing.Point(11, 29);
            this.CoachPollListBox.Name = "CoachPollListBox";
            this.CoachPollListBox.Size = new System.Drawing.Size(191, 329);
            this.CoachPollListBox.TabIndex = 0;
            // 
            // tabStadiums
            // 
            this.tabStadiums.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabStadiums.Controls.Add(this.groupBox30);
            this.tabStadiums.Controls.Add(this.groupBox29);
            this.tabStadiums.Controls.Add(this.groupBox28);
            this.tabStadiums.Controls.Add(this.STADrank);
            this.tabStadiums.Controls.Add(this.STADSTDR);
            this.tabStadiums.Controls.Add(this.STADTDNA);
            this.tabStadiums.Controls.Add(this.STADResBox);
            this.tabStadiums.Controls.Add(this.STADsgidBox);
            this.tabStadiums.Controls.Add(this.label228);
            this.tabStadiums.Controls.Add(this.groupBox27);
            this.tabStadiums.Controls.Add(this.label227);
            this.tabStadiums.Controls.Add(this.label226);
            this.tabStadiums.Controls.Add(this.label225);
            this.tabStadiums.Controls.Add(this.StadiumListBox);
            this.tabStadiums.Location = new System.Drawing.Point(4, 24);
            this.tabStadiums.Name = "tabStadiums";
            this.tabStadiums.Padding = new System.Windows.Forms.Padding(3);
            this.tabStadiums.Size = new System.Drawing.Size(1152, 615);
            this.tabStadiums.TabIndex = 17;
            this.tabStadiums.Text = "Stadiums";
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.GrassToTurf);
            this.groupBox30.Controls.Add(this.GlobalWeather);
            this.groupBox30.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox30.Location = new System.Drawing.Point(702, 436);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(398, 128);
            this.groupBox30.TabIndex = 18;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Global Editor";
            // 
            // GrassToTurf
            // 
            this.GrassToTurf.Location = new System.Drawing.Point(215, 31);
            this.GrassToTurf.Name = "GrassToTurf";
            this.GrassToTurf.Size = new System.Drawing.Size(128, 76);
            this.GrassToTurf.TabIndex = 18;
            this.GrassToTurf.Text = "Change All Natural Grass to Grassy Turf";
            this.GrassToTurf.UseVisualStyleBackColor = true;
            this.GrassToTurf.Click += new System.EventHandler(this.GrassToTurf_Click);
            // 
            // GlobalWeather
            // 
            this.GlobalWeather.Location = new System.Drawing.Point(40, 32);
            this.GlobalWeather.Name = "GlobalWeather";
            this.GlobalWeather.Size = new System.Drawing.Size(128, 76);
            this.GlobalWeather.TabIndex = 17;
            this.GlobalWeather.Text = "Global Weather Data Importer";
            this.GlobalWeather.UseVisualStyleBackColor = true;
            this.GlobalWeather.Click += new System.EventHandler(this.GlobalWeather_Click);
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.label241);
            this.groupBox29.Controls.Add(this.STtvBox);
            this.groupBox29.Controls.Add(this.label235);
            this.groupBox29.Controls.Add(this.SWSPBox);
            this.groupBox29.Controls.Add(this.label236);
            this.groupBox29.Controls.Add(this.SWRPBox);
            this.groupBox29.Controls.Add(this.label233);
            this.groupBox29.Controls.Add(this.SWWPBox);
            this.groupBox29.Controls.Add(this.label234);
            this.groupBox29.Controls.Add(this.SWFPBox);
            this.groupBox29.Controls.Add(this.label231);
            this.groupBox29.Controls.Add(this.STfwBox);
            this.groupBox29.Controls.Add(this.label232);
            this.groupBox29.Controls.Add(this.STwpBox);
            this.groupBox29.Controls.Add(this.label230);
            this.groupBox29.Controls.Add(this.STjtBox);
            this.groupBox29.Controls.Add(this.label229);
            this.groupBox29.Controls.Add(this.STtsBox);
            this.groupBox29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox29.Location = new System.Drawing.Point(231, 328);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(412, 240);
            this.groupBox29.TabIndex = 16;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "Weather Settings";
            // 
            // label241
            // 
            this.label241.AutoSize = true;
            this.label241.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label241.Location = new System.Drawing.Point(270, 58);
            this.label241.Name = "label241";
            this.label241.Size = new System.Drawing.Size(129, 15);
            this.label241.TabIndex = 17;
            this.label241.Text = "Temperature Variation";
            // 
            // STtvBox
            // 
            this.STtvBox.Location = new System.Drawing.Point(202, 53);
            this.STtvBox.Name = "STtvBox";
            this.STtvBox.Size = new System.Drawing.Size(62, 21);
            this.STtvBox.TabIndex = 16;
            this.STtvBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STtvBox.ValueChanged += new System.EventHandler(this.STtvBox_ValueChanged);
            // 
            // label235
            // 
            this.label235.AutoSize = true;
            this.label235.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label235.Location = new System.Drawing.Point(270, 208);
            this.label235.Name = "label235";
            this.label235.Size = new System.Drawing.Size(67, 15);
            this.label235.TabIndex = 15;
            this.label235.Text = "Snow, PCT";
            // 
            // SWSPBox
            // 
            this.SWSPBox.Location = new System.Drawing.Point(202, 203);
            this.SWSPBox.Name = "SWSPBox";
            this.SWSPBox.Size = new System.Drawing.Size(62, 21);
            this.SWSPBox.TabIndex = 14;
            this.SWSPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWSPBox.ValueChanged += new System.EventHandler(this.SWSPBox_ValueChanged);
            // 
            // label236
            // 
            this.label236.AutoSize = true;
            this.label236.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label236.Location = new System.Drawing.Point(80, 208);
            this.label236.Name = "label236";
            this.label236.Size = new System.Drawing.Size(62, 15);
            this.label236.TabIndex = 13;
            this.label236.Text = "Rain, PCT";
            // 
            // SWRPBox
            // 
            this.SWRPBox.Location = new System.Drawing.Point(12, 203);
            this.SWRPBox.Name = "SWRPBox";
            this.SWRPBox.Size = new System.Drawing.Size(62, 21);
            this.SWRPBox.TabIndex = 12;
            this.SWRPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWRPBox.ValueChanged += new System.EventHandler(this.SWRPBox_ValueChanged);
            // 
            // label233
            // 
            this.label233.AutoSize = true;
            this.label233.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label233.Location = new System.Drawing.Point(270, 172);
            this.label233.Name = "label233";
            this.label233.Size = new System.Drawing.Size(64, 15);
            this.label233.TabIndex = 11;
            this.label233.Text = "Wind, PCT";
            // 
            // SWWPBox
            // 
            this.SWWPBox.Location = new System.Drawing.Point(202, 167);
            this.SWWPBox.Name = "SWWPBox";
            this.SWWPBox.Size = new System.Drawing.Size(62, 21);
            this.SWWPBox.TabIndex = 10;
            this.SWWPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWWPBox.ValueChanged += new System.EventHandler(this.SWWPBox_ValueChanged);
            // 
            // label234
            // 
            this.label234.AutoSize = true;
            this.label234.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label234.Location = new System.Drawing.Point(80, 172);
            this.label234.Name = "label234";
            this.label234.Size = new System.Drawing.Size(106, 15);
            this.label234.TabIndex = 9;
            this.label234.Text = "Fair Weather, PCT";
            // 
            // SWFPBox
            // 
            this.SWFPBox.Location = new System.Drawing.Point(12, 167);
            this.SWFPBox.Name = "SWFPBox";
            this.SWFPBox.Size = new System.Drawing.Size(62, 21);
            this.SWFPBox.TabIndex = 8;
            this.SWFPBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWFPBox.ValueChanged += new System.EventHandler(this.SWFPBox_ValueChanged);
            // 
            // label231
            // 
            this.label231.AutoSize = true;
            this.label231.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label231.Location = new System.Drawing.Point(80, 133);
            this.label231.Name = "label231";
            this.label231.Size = new System.Drawing.Size(116, 15);
            this.label231.TabIndex = 7;
            this.label231.Text = "Fall Variation (STfw)";
            // 
            // STfwBox
            // 
            this.STfwBox.Location = new System.Drawing.Point(12, 128);
            this.STfwBox.Name = "STfwBox";
            this.STfwBox.Size = new System.Drawing.Size(62, 21);
            this.STfwBox.TabIndex = 6;
            this.STfwBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STfwBox.ValueChanged += new System.EventHandler(this.STfwBox_ValueChanged);
            // 
            // label232
            // 
            this.label232.AutoSize = true;
            this.label232.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label232.Location = new System.Drawing.Point(270, 133);
            this.label232.Name = "label232";
            this.label232.Size = new System.Drawing.Size(135, 15);
            this.label232.TabIndex = 5;
            this.label232.Text = "Winter Variation (STwp)";
            // 
            // STwpBox
            // 
            this.STwpBox.Location = new System.Drawing.Point(202, 128);
            this.STwpBox.Name = "STwpBox";
            this.STwpBox.Size = new System.Drawing.Size(62, 21);
            this.STwpBox.TabIndex = 4;
            this.STwpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STwpBox.ValueChanged += new System.EventHandler(this.STwpBox_ValueChanged);
            // 
            // label230
            // 
            this.label230.AutoSize = true;
            this.label230.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label230.Location = new System.Drawing.Point(80, 77);
            this.label230.Name = "label230";
            this.label230.Size = new System.Drawing.Size(104, 15);
            this.label230.TabIndex = 3;
            this.label230.Text = "Temperature, Jan";
            // 
            // STjtBox
            // 
            this.STjtBox.Location = new System.Drawing.Point(12, 72);
            this.STjtBox.Name = "STjtBox";
            this.STjtBox.Size = new System.Drawing.Size(62, 21);
            this.STjtBox.TabIndex = 2;
            this.STjtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STjtBox.ValueChanged += new System.EventHandler(this.STjtBox_ValueChanged);
            // 
            // label229
            // 
            this.label229.AutoSize = true;
            this.label229.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label229.Location = new System.Drawing.Point(80, 37);
            this.label229.Name = "label229";
            this.label229.Size = new System.Drawing.Size(109, 15);
            this.label229.TabIndex = 1;
            this.label229.Text = "Temperature, Sept";
            // 
            // STtsBox
            // 
            this.STtsBox.Location = new System.Drawing.Point(12, 32);
            this.STtsBox.Name = "STtsBox";
            this.STtsBox.Size = new System.Drawing.Size(62, 21);
            this.STtsBox.TabIndex = 0;
            this.STtsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STtsBox.ValueChanged += new System.EventHandler(this.STtsBox_ValueChanged);
            // 
            // groupBox28
            // 
            this.groupBox28.Controls.Add(this.label239);
            this.groupBox28.Controls.Add(this.STADSFTYBox);
            this.groupBox28.Controls.Add(this.STADState);
            this.groupBox28.Controls.Add(this.STADCity);
            this.groupBox28.Controls.Add(this.label237);
            this.groupBox28.Controls.Add(this.label238);
            this.groupBox28.Controls.Add(this.label240);
            this.groupBox28.Controls.Add(this.STADCap);
            this.groupBox28.Controls.Add(this.STADNickBox);
            this.groupBox28.Controls.Add(this.STADNameBox);
            this.groupBox28.Controls.Add(this.labelstadnickname);
            this.groupBox28.Controls.Add(this.labelstadname);
            this.groupBox28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox28.Location = new System.Drawing.Point(231, 106);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(412, 186);
            this.groupBox28.TabIndex = 15;
            this.groupBox28.TabStop = false;
            this.groupBox28.Text = "Stadium Info";
            // 
            // label239
            // 
            this.label239.AutoSize = true;
            this.label239.Location = new System.Drawing.Point(250, 100);
            this.label239.Name = "label239";
            this.label239.Size = new System.Drawing.Size(66, 15);
            this.label239.TabIndex = 133;
            this.label239.Text = "Turf Type";
            // 
            // STADSFTYBox
            // 
            this.STADSFTYBox.FormattingEnabled = true;
            this.STADSFTYBox.Location = new System.Drawing.Point(253, 114);
            this.STADSFTYBox.Name = "STADSFTYBox";
            this.STADSFTYBox.Size = new System.Drawing.Size(121, 23);
            this.STADSFTYBox.TabIndex = 132;
            this.STADSFTYBox.SelectedIndexChanged += new System.EventHandler(this.STADSFTYBox_SelectedIndexChanged);
            // 
            // STADState
            // 
            this.STADState.FormattingEnabled = true;
            this.STADState.Location = new System.Drawing.Point(152, 114);
            this.STADState.MaxLength = 2;
            this.STADState.Name = "STADState";
            this.STADState.Size = new System.Drawing.Size(44, 23);
            this.STADState.TabIndex = 126;
            this.STADState.SelectedIndexChanged += new System.EventHandler(this.STADState_SelectedIndexChanged);
            // 
            // STADCity
            // 
            this.STADCity.Location = new System.Drawing.Point(22, 115);
            this.STADCity.Name = "STADCity";
            this.STADCity.Size = new System.Drawing.Size(111, 21);
            this.STADCity.TabIndex = 124;
            this.STADCity.Leave += new System.EventHandler(this.STADCity_Leave);
            // 
            // label237
            // 
            this.label237.AutoSize = true;
            this.label237.Location = new System.Drawing.Point(19, 99);
            this.label237.Name = "label237";
            this.label237.Size = new System.Drawing.Size(30, 15);
            this.label237.TabIndex = 125;
            this.label237.Text = "City";
            // 
            // label238
            // 
            this.label238.AutoSize = true;
            this.label238.Location = new System.Drawing.Point(151, 99);
            this.label238.Name = "label238";
            this.label238.Size = new System.Drawing.Size(40, 15);
            this.label238.TabIndex = 127;
            this.label238.Text = "State";
            // 
            // label240
            // 
            this.label240.AutoSize = true;
            this.label240.Location = new System.Drawing.Point(19, 143);
            this.label240.Name = "label240";
            this.label240.Size = new System.Drawing.Size(61, 15);
            this.label240.TabIndex = 129;
            this.label240.Text = "Capacity";
            // 
            // STADCap
            // 
            this.STADCap.Location = new System.Drawing.Point(22, 159);
            this.STADCap.Maximum = new decimal(new int[] {
            150000,
            0,
            0,
            0});
            this.STADCap.Name = "STADCap";
            this.STADCap.Size = new System.Drawing.Size(100, 21);
            this.STADCap.TabIndex = 131;
            this.STADCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STADCap.ValueChanged += new System.EventHandler(this.STADCap_ValueChanged);
            // 
            // STADNickBox
            // 
            this.STADNickBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADNickBox.Location = new System.Drawing.Point(116, 58);
            this.STADNickBox.Name = "STADNickBox";
            this.STADNickBox.Size = new System.Drawing.Size(283, 22);
            this.STADNickBox.TabIndex = 13;
            this.STADNickBox.Leave += new System.EventHandler(this.STADNickBox_Leave);
            // 
            // STADNameBox
            // 
            this.STADNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADNameBox.Location = new System.Drawing.Point(116, 19);
            this.STADNameBox.Name = "STADNameBox";
            this.STADNameBox.Size = new System.Drawing.Size(283, 22);
            this.STADNameBox.TabIndex = 9;
            this.STADNameBox.Leave += new System.EventHandler(this.STADNameBox_Leave);
            // 
            // labelstadnickname
            // 
            this.labelstadnickname.AutoSize = true;
            this.labelstadnickname.Location = new System.Drawing.Point(30, 66);
            this.labelstadnickname.Name = "labelstadnickname";
            this.labelstadnickname.Size = new System.Drawing.Size(71, 15);
            this.labelstadnickname.TabIndex = 14;
            this.labelstadnickname.Text = "Nickname";
            this.labelstadnickname.UseMnemonic = false;
            // 
            // labelstadname
            // 
            this.labelstadname.AutoSize = true;
            this.labelstadname.Location = new System.Drawing.Point(9, 24);
            this.labelstadname.Name = "labelstadname";
            this.labelstadname.Size = new System.Drawing.Size(102, 15);
            this.labelstadname.TabIndex = 10;
            this.labelstadname.Text = "Stadium Name";
            // 
            // STADrank
            // 
            this.STADrank.AutoSize = true;
            this.STADrank.Location = new System.Drawing.Point(561, 26);
            this.STADrank.Name = "STADrank";
            this.STADrank.Size = new System.Drawing.Size(74, 13);
            this.STADrank.TabIndex = 12;
            this.STADrank.Text = "Stadium Rank";
            // 
            // STADSTDR
            // 
            this.STADSTDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADSTDR.Location = new System.Drawing.Point(564, 44);
            this.STADSTDR.Name = "STADSTDR";
            this.STADSTDR.ReadOnly = true;
            this.STADSTDR.Size = new System.Drawing.Size(67, 21);
            this.STADSTDR.TabIndex = 11;
            this.STADSTDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // STADTDNA
            // 
            this.STADTDNA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADTDNA.Location = new System.Drawing.Point(414, 44);
            this.STADTDNA.Name = "STADTDNA";
            this.STADTDNA.ReadOnly = true;
            this.STADTDNA.Size = new System.Drawing.Size(130, 21);
            this.STADTDNA.TabIndex = 7;
            this.STADTDNA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // STADResBox
            // 
            this.STADResBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADResBox.Location = new System.Drawing.Point(328, 44);
            this.STADResBox.Name = "STADResBox";
            this.STADResBox.ReadOnly = true;
            this.STADResBox.Size = new System.Drawing.Size(67, 21);
            this.STADResBox.TabIndex = 4;
            this.STADResBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // STADsgidBox
            // 
            this.STADsgidBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STADsgidBox.Location = new System.Drawing.Point(231, 44);
            this.STADsgidBox.Name = "STADsgidBox";
            this.STADsgidBox.ReadOnly = true;
            this.STADsgidBox.Size = new System.Drawing.Size(74, 21);
            this.STADsgidBox.TabIndex = 2;
            this.STADsgidBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label228
            // 
            this.label228.AutoSize = true;
            this.label228.Location = new System.Drawing.Point(411, 26);
            this.label228.Name = "label228";
            this.label228.Size = new System.Drawing.Size(79, 13);
            this.label228.TabIndex = 8;
            this.label228.Text = "Stadium Owner";
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.STADType);
            this.groupBox27.Controls.Add(this.STADCannon);
            this.groupBox27.Controls.Add(this.STADVisbility);
            this.groupBox27.Controls.Add(this.STADcat);
            this.groupBox27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox27.Location = new System.Drawing.Point(702, 106);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(221, 135);
            this.groupBox27.TabIndex = 6;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Stadium Options";
            // 
            // STADType
            // 
            this.STADType.AutoSize = true;
            this.STADType.Location = new System.Drawing.Point(20, 104);
            this.STADType.Name = "STADType";
            this.STADType.Size = new System.Drawing.Size(124, 19);
            this.STADType.TabIndex = 3;
            this.STADType.Text = "Indoor Stadium";
            this.STADType.UseVisualStyleBackColor = true;
            this.STADType.CheckedChanged += new System.EventHandler(this.STADType_CheckedChanged);
            // 
            // STADCannon
            // 
            this.STADCannon.AutoSize = true;
            this.STADCannon.Location = new System.Drawing.Point(20, 81);
            this.STADCannon.Name = "STADCannon";
            this.STADCannon.Size = new System.Drawing.Size(132, 19);
            this.STADCannon.TabIndex = 2;
            this.STADCannon.Text = "Stadium Cannon";
            this.STADCannon.UseVisualStyleBackColor = true;
            this.STADCannon.CheckedChanged += new System.EventHandler(this.STADCannon_CheckedChanged);
            // 
            // STADVisbility
            // 
            this.STADVisbility.AutoSize = true;
            this.STADVisbility.Location = new System.Drawing.Point(20, 35);
            this.STADVisbility.Name = "STADVisbility";
            this.STADVisbility.Size = new System.Drawing.Size(119, 19);
            this.STADVisbility.TabIndex = 1;
            this.STADVisbility.Text = "Menu Visibility";
            this.STADVisbility.UseVisualStyleBackColor = true;
            this.STADVisbility.CheckedChanged += new System.EventHandler(this.STADVisbility_CheckedChanged);
            // 
            // STADcat
            // 
            this.STADcat.AutoSize = true;
            this.STADcat.Enabled = false;
            this.STADcat.Location = new System.Drawing.Point(20, 58);
            this.STADcat.Name = "STADcat";
            this.STADcat.Size = new System.Drawing.Size(179, 19);
            this.STADcat.TabIndex = 0;
            this.STADcat.Text = "Create-A-Team Stadium";
            this.STADcat.UseVisualStyleBackColor = true;
            // 
            // label227
            // 
            this.label227.AutoSize = true;
            this.label227.Location = new System.Drawing.Point(328, 25);
            this.label227.Name = "label227";
            this.label227.Size = new System.Drawing.Size(67, 13);
            this.label227.TabIndex = 5;
            this.label227.Text = "Resource ID";
            // 
            // label226
            // 
            this.label226.AutoSize = true;
            this.label226.Location = new System.Drawing.Point(231, 25);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(59, 13);
            this.label226.TabIndex = 3;
            this.label226.Text = "Stadium ID";
            // 
            // label225
            // 
            this.label225.AutoSize = true;
            this.label225.Location = new System.Drawing.Point(21, 25);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(78, 13);
            this.label225.TabIndex = 1;
            this.label225.Text = "Select Stadium";
            // 
            // StadiumListBox
            // 
            this.StadiumListBox.Location = new System.Drawing.Point(21, 44);
            this.StadiumListBox.Name = "StadiumListBox";
            this.StadiumListBox.Size = new System.Drawing.Size(174, 524);
            this.StadiumListBox.TabIndex = 0;
            this.StadiumListBox.SelectedIndexChanged += new System.EventHandler(this.StadiumListBox_SelectedIndexChanged);
            // 
            // tabBowls
            // 
            this.tabBowls.Controls.Add(this.SaveBowlButton);
            this.tabBowls.Controls.Add(this.BowlsGrid);
            this.tabBowls.Location = new System.Drawing.Point(4, 24);
            this.tabBowls.Name = "tabBowls";
            this.tabBowls.Padding = new System.Windows.Forms.Padding(3);
            this.tabBowls.Size = new System.Drawing.Size(1152, 615);
            this.tabBowls.TabIndex = 14;
            this.tabBowls.Text = "Bowls";
            this.tabBowls.UseVisualStyleBackColor = true;
            // 
            // SaveBowlButton
            // 
            this.SaveBowlButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SaveBowlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBowlButton.Location = new System.Drawing.Point(962, 19);
            this.SaveBowlButton.Name = "SaveBowlButton";
            this.SaveBowlButton.Size = new System.Drawing.Size(171, 52);
            this.SaveBowlButton.TabIndex = 6;
            this.SaveBowlButton.Text = "Update Database";
            this.SaveBowlButton.UseVisualStyleBackColor = false;
            this.SaveBowlButton.Click += new System.EventHandler(this.SaveBowlButton_Click);
            // 
            // BowlsGrid
            // 
            this.BowlsGrid.AllowUserToAddRows = false;
            this.BowlsGrid.AllowUserToDeleteRows = false;
            this.BowlsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.BowlsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle43;
            this.BowlsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BowlsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle44;
            this.BowlsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BowlsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActiveBowl,
            this.BIDX,
            this.BNME,
            this.TeamA,
            this.ScoreA,
            this.vs,
            this.ScoreB,
            this.TeamB,
            this.SGID,
            this.BMON,
            this.BDAY,
            this.SEWN});
            dataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BowlsGrid.DefaultCellStyle = dataGridViewCellStyle45;
            this.BowlsGrid.Location = new System.Drawing.Point(6, 6);
            this.BowlsGrid.Name = "BowlsGrid";
            this.BowlsGrid.RowHeadersVisible = false;
            this.BowlsGrid.Size = new System.Drawing.Size(950, 603);
            this.BowlsGrid.TabIndex = 4;
            this.BowlsGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.BowlsGrid_DataError);
            // 
            // ActiveBowl
            // 
            this.ActiveBowl.FillWeight = 7F;
            this.ActiveBowl.HeaderText = "Active";
            this.ActiveBowl.Name = "ActiveBowl";
            // 
            // BIDX
            // 
            this.BIDX.FillWeight = 8F;
            this.BIDX.HeaderText = "BIDX";
            this.BIDX.Name = "BIDX";
            this.BIDX.ReadOnly = true;
            this.BIDX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // BNME
            // 
            this.BNME.FillWeight = 25F;
            this.BNME.HeaderText = "Bowl Name";
            this.BNME.Name = "BNME";
            this.BNME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TeamA
            // 
            this.TeamA.FillWeight = 20F;
            this.TeamA.HeaderText = "Team";
            this.TeamA.Name = "TeamA";
            // 
            // ScoreA
            // 
            this.ScoreA.FillWeight = 7F;
            this.ScoreA.HeaderText = "Score";
            this.ScoreA.Name = "ScoreA";
            this.ScoreA.ReadOnly = true;
            this.ScoreA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vs
            // 
            this.vs.FillWeight = 4F;
            this.vs.HeaderText = "vs";
            this.vs.Name = "vs";
            this.vs.ReadOnly = true;
            this.vs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ScoreB
            // 
            this.ScoreB.FillWeight = 7F;
            this.ScoreB.HeaderText = "Score";
            this.ScoreB.Name = "ScoreB";
            this.ScoreB.ReadOnly = true;
            this.ScoreB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TeamB
            // 
            this.TeamB.FillWeight = 20F;
            this.TeamB.HeaderText = "Team";
            this.TeamB.Name = "TeamB";
            // 
            // SGID
            // 
            this.SGID.FillWeight = 25F;
            this.SGID.HeaderText = "Stadium";
            this.SGID.Name = "SGID";
            // 
            // BMON
            // 
            this.BMON.FillWeight = 8F;
            this.BMON.HeaderText = "Month";
            this.BMON.Name = "BMON";
            // 
            // BDAY
            // 
            this.BDAY.FillWeight = 8F;
            this.BDAY.HeaderText = "Date";
            this.BDAY.Name = "BDAY";
            // 
            // SEWN
            // 
            this.SEWN.FillWeight = 6F;
            this.SEWN.HeaderText = "Week";
            this.SEWN.Name = "SEWN";
            this.SEWN.ReadOnly = true;
            // 
            // tabConf
            // 
            this.tabConf.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabConf.Controls.Add(this.groupBox23);
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
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.ConfDisplayRanking);
            this.groupBox23.Controls.Add(this.ConfDisplayRating);
            this.groupBox23.Controls.Add(this.ConfDisplayPrestige);
            this.groupBox23.Controls.Add(this.ConfDisplayTeam);
            this.groupBox23.Location = new System.Drawing.Point(981, 348);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(150, 119);
            this.groupBox23.TabIndex = 32;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Display Options";
            // 
            // ConfDisplayRanking
            // 
            this.ConfDisplayRanking.AutoSize = true;
            this.ConfDisplayRanking.Location = new System.Drawing.Point(11, 91);
            this.ConfDisplayRanking.Name = "ConfDisplayRanking";
            this.ConfDisplayRanking.Size = new System.Drawing.Size(95, 17);
            this.ConfDisplayRanking.TabIndex = 3;
            this.ConfDisplayRanking.TabStop = true;
            this.ConfDisplayRanking.Text = "Team Ranking";
            this.ConfDisplayRanking.UseVisualStyleBackColor = true;
            this.ConfDisplayRanking.CheckedChanged += new System.EventHandler(this.ConfDisplayRanking_CheckedChanged);
            // 
            // ConfDisplayRating
            // 
            this.ConfDisplayRating.AutoSize = true;
            this.ConfDisplayRating.Location = new System.Drawing.Point(11, 68);
            this.ConfDisplayRating.Name = "ConfDisplayRating";
            this.ConfDisplayRating.Size = new System.Drawing.Size(86, 17);
            this.ConfDisplayRating.TabIndex = 2;
            this.ConfDisplayRating.TabStop = true;
            this.ConfDisplayRating.Text = "Team Rating";
            this.ConfDisplayRating.UseVisualStyleBackColor = true;
            this.ConfDisplayRating.CheckedChanged += new System.EventHandler(this.ConfDisplayRating_CheckedChanged);
            // 
            // ConfDisplayPrestige
            // 
            this.ConfDisplayPrestige.AutoSize = true;
            this.ConfDisplayPrestige.Location = new System.Drawing.Point(11, 45);
            this.ConfDisplayPrestige.Name = "ConfDisplayPrestige";
            this.ConfDisplayPrestige.Size = new System.Drawing.Size(93, 17);
            this.ConfDisplayPrestige.TabIndex = 1;
            this.ConfDisplayPrestige.TabStop = true;
            this.ConfDisplayPrestige.Text = "Team Prestige";
            this.ConfDisplayPrestige.UseVisualStyleBackColor = true;
            this.ConfDisplayPrestige.CheckedChanged += new System.EventHandler(this.ConfDisplayPrestige_CheckedChanged);
            // 
            // ConfDisplayTeam
            // 
            this.ConfDisplayTeam.AutoSize = true;
            this.ConfDisplayTeam.Location = new System.Drawing.Point(11, 22);
            this.ConfDisplayTeam.Name = "ConfDisplayTeam";
            this.ConfDisplayTeam.Size = new System.Drawing.Size(76, 17);
            this.ConfDisplayTeam.TabIndex = 0;
            this.ConfDisplayTeam.TabStop = true;
            this.ConfDisplayTeam.Text = "Team Only";
            this.ConfDisplayTeam.UseVisualStyleBackColor = true;
            this.ConfDisplayTeam.CheckedChanged += new System.EventHandler(this.ConfDisplayTeam_CheckedChanged);
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
            // tabDepthCharts
            // 
            this.tabDepthCharts.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabDepthCharts.Controls.Add(this.groupBox40);
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
            // 
            // groupBox40
            // 
            this.groupBox40.Controls.Add(this.DC136);
            this.groupBox40.Controls.Add(this.DC120);
            this.groupBox40.Location = new System.Drawing.Point(4, 533);
            this.groupBox40.Name = "groupBox40";
            this.groupBox40.Size = new System.Drawing.Size(152, 63);
            this.groupBox40.TabIndex = 64;
            this.groupBox40.TabStop = false;
            this.groupBox40.Text = "League Size [SET FIRST]";
            // 
            // DC136
            // 
            this.DC136.AutoSize = true;
            this.DC136.Location = new System.Drawing.Point(4, 41);
            this.DC136.Name = "DC136";
            this.DC136.Size = new System.Drawing.Size(134, 17);
            this.DC136.TabIndex = 2;
            this.DC136.Text = "136 Teams [NEXT26+]";
            this.DC136.UseVisualStyleBackColor = true;
            // 
            // DC120
            // 
            this.DC120.AutoSize = true;
            this.DC120.Checked = true;
            this.DC120.Location = new System.Drawing.Point(3, 18);
            this.DC120.Name = "DC120";
            this.DC120.Size = new System.Drawing.Size(144, 17);
            this.DC120.TabIndex = 0;
            this.DC120.TabStop = true;
            this.DC120.Text = "119/120 Teams [Default]";
            this.DC120.UseVisualStyleBackColor = true;
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
            dataGridViewCellStyle46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DCHTGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.DCHTGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DCHTGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DCHTGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.DCHTGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DCHTGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DCHTPPOS,
            this.DCHT0,
            this.DCHT1,
            this.DCHT2,
            this.DCHT3,
            this.DCHT4,
            this.DCHT5});
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DCHTGrid.DefaultCellStyle = dataGridViewCellStyle48;
            this.DCHTGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DCHTGrid.GridColor = System.Drawing.SystemColors.Control;
            this.DCHTGrid.Location = new System.Drawing.Point(159, 6);
            this.DCHTGrid.MultiSelect = false;
            this.DCHTGrid.Name = "DCHTGrid";
            this.DCHTGrid.RowHeadersVisible = false;
            this.DCHTGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DCHTGrid.Size = new System.Drawing.Size(974, 590);
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
            // tabSchedule
            // 
            this.tabSchedule.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabSchedule.Controls.Add(this.label213);
            this.tabSchedule.Controls.Add(this.MatchView);
            this.tabSchedule.Controls.Add(this.SCHDrecord);
            this.tabSchedule.Controls.Add(this.groupBox21);
            this.tabSchedule.Controls.Add(this.label212);
            this.tabSchedule.Controls.Add(this.SchdTeamName);
            this.tabSchedule.Controls.Add(this.label211);
            this.tabSchedule.Controls.Add(this.SCHDTeamBox);
            this.tabSchedule.Controls.Add(this.ScheduleView);
            this.tabSchedule.Location = new System.Drawing.Point(4, 24);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedule.Size = new System.Drawing.Size(1152, 615);
            this.tabSchedule.TabIndex = 16;
            this.tabSchedule.Text = "Schedule";
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label213.Location = new System.Drawing.Point(735, 32);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(203, 24);
            this.label213.TabIndex = 9;
            this.label213.Text = "MATCH-UP VIEWER";
            // 
            // MatchView
            // 
            this.MatchView.AllowUserToAddRows = false;
            this.MatchView.AllowUserToDeleteRows = false;
            this.MatchView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MatchView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle49;
            this.MatchView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MatchView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle50;
            this.MatchView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RatingCat,
            this.MatchHomeTeam,
            this.MatchAwayTeam});
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MatchView.DefaultCellStyle = dataGridViewCellStyle51;
            this.MatchView.Location = new System.Drawing.Point(721, 61);
            this.MatchView.Name = "MatchView";
            this.MatchView.ReadOnly = true;
            this.MatchView.RowHeadersVisible = false;
            this.MatchView.Size = new System.Drawing.Size(409, 385);
            this.MatchView.TabIndex = 8;
            // 
            // RatingCat
            // 
            this.RatingCat.HeaderText = "Rating";
            this.RatingCat.Name = "RatingCat";
            this.RatingCat.ReadOnly = true;
            // 
            // MatchHomeTeam
            // 
            this.MatchHomeTeam.HeaderText = "Home Team";
            this.MatchHomeTeam.Name = "MatchHomeTeam";
            this.MatchHomeTeam.ReadOnly = true;
            // 
            // MatchAwayTeam
            // 
            this.MatchAwayTeam.HeaderText = "Away Team";
            this.MatchAwayTeam.Name = "MatchAwayTeam";
            this.MatchAwayTeam.ReadOnly = true;
            // 
            // SCHDrecord
            // 
            this.SCHDrecord.AutoSize = true;
            this.SCHDrecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCHDrecord.Location = new System.Drawing.Point(974, 40);
            this.SCHDrecord.Name = "SCHDrecord";
            this.SCHDrecord.Size = new System.Drawing.Size(156, 16);
            this.SCHDrecord.TabIndex = 7;
            this.SCHDrecord.Text = "Season Record: xx-xx";
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.RescheduleOOC);
            this.groupBox21.Location = new System.Drawing.Point(721, 482);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(409, 107);
            this.groupBox21.TabIndex = 6;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Schedule Tools";
            // 
            // RescheduleOOC
            // 
            this.RescheduleOOC.Location = new System.Drawing.Point(22, 34);
            this.RescheduleOOC.Name = "RescheduleOOC";
            this.RescheduleOOC.Size = new System.Drawing.Size(111, 55);
            this.RescheduleOOC.TabIndex = 5;
            this.RescheduleOOC.Text = "Re-Schedule Out of Conference Games";
            this.RescheduleOOC.UseVisualStyleBackColor = true;
            this.RescheduleOOC.Click += new System.EventHandler(this.RescheduleOOC_Click);
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label212.Location = new System.Drawing.Point(23, 33);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(107, 15);
            this.label212.TabIndex = 4;
            this.label212.Text = "Team Selection";
            // 
            // SchdTeamName
            // 
            this.SchdTeamName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SchdTeamName.AutoSize = true;
            this.SchdTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SchdTeamName.Location = new System.Drawing.Point(562, 9);
            this.SchdTeamName.Name = "SchdTeamName";
            this.SchdTeamName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SchdTeamName.Size = new System.Drawing.Size(92, 16);
            this.SchdTeamName.TabIndex = 3;
            this.SchdTeamName.Text = "Team Name";
            this.SchdTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label211.Location = new System.Drawing.Point(197, 3);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(205, 24);
            this.label211.TabIndex = 2;
            this.label211.Text = "SCHEDULE VIEWER";
            // 
            // SCHDTeamBox
            // 
            this.SCHDTeamBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SCHDTeamBox.FormattingEnabled = true;
            this.SCHDTeamBox.Location = new System.Drawing.Point(23, 52);
            this.SCHDTeamBox.Name = "SCHDTeamBox";
            this.SCHDTeamBox.Size = new System.Drawing.Size(142, 537);
            this.SCHDTeamBox.TabIndex = 1;
            this.SCHDTeamBox.SelectedIndexChanged += new System.EventHandler(this.SCHDTeamBox_SelectedIndexChanged);
            // 
            // ScheduleView
            // 
            this.ScheduleView.AllowUserToAddRows = false;
            this.ScheduleView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle52.Padding = new System.Windows.Forms.Padding(2);
            this.ScheduleView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle52;
            this.ScheduleView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ScheduleView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScheduleView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle53;
            this.ScheduleView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ScheduleView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SCHDWeek,
            this.SCHDHOME,
            this.SCHDScoreH,
            this.SCHDVS,
            this.SCHDAWAY,
            this.SCHDScoreA});
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ScheduleView.DefaultCellStyle = dataGridViewCellStyle54;
            this.ScheduleView.Location = new System.Drawing.Point(201, 29);
            this.ScheduleView.Margin = new System.Windows.Forms.Padding(2);
            this.ScheduleView.Name = "ScheduleView";
            this.ScheduleView.ReadOnly = true;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ScheduleView.RowHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.ScheduleView.RowHeadersVisible = false;
            this.ScheduleView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ScheduleView.RowsDefaultCellStyle = dataGridViewCellStyle56;
            this.ScheduleView.Size = new System.Drawing.Size(495, 581);
            this.ScheduleView.TabIndex = 0;
            this.ScheduleView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ScheduleView_RowEnter);
            // 
            // SCHDWeek
            // 
            this.SCHDWeek.FillWeight = 40F;
            this.SCHDWeek.HeaderText = "Week";
            this.SCHDWeek.Name = "SCHDWeek";
            this.SCHDWeek.ReadOnly = true;
            // 
            // SCHDHOME
            // 
            this.SCHDHOME.HeaderText = "Home";
            this.SCHDHOME.Name = "SCHDHOME";
            this.SCHDHOME.ReadOnly = true;
            // 
            // SCHDScoreH
            // 
            this.SCHDScoreH.FillWeight = 50F;
            this.SCHDScoreH.HeaderText = "Score";
            this.SCHDScoreH.Name = "SCHDScoreH";
            this.SCHDScoreH.ReadOnly = true;
            // 
            // SCHDVS
            // 
            this.SCHDVS.FillWeight = 25F;
            this.SCHDVS.HeaderText = "vs";
            this.SCHDVS.Name = "SCHDVS";
            this.SCHDVS.ReadOnly = true;
            // 
            // SCHDAWAY
            // 
            this.SCHDAWAY.HeaderText = "Away";
            this.SCHDAWAY.Name = "SCHDAWAY";
            this.SCHDAWAY.ReadOnly = true;
            // 
            // SCHDScoreA
            // 
            this.SCHDScoreA.FillWeight = 50F;
            this.SCHDScoreA.HeaderText = "Score";
            this.SCHDScoreA.Name = "SCHDScoreA";
            this.SCHDScoreA.ReadOnly = true;
            // 
            // tabSeason
            // 
            this.tabSeason.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabSeason.Controls.Add(this.groupBox36);
            this.tabSeason.Controls.Add(this.groupBox35);
            this.tabSeason.Controls.Add(this.TransferPortalStats);
            this.tabSeason.Controls.Add(this.RemoveBadTransfers);
            this.tabSeason.Controls.Add(this.RemoveSanctionsButton);
            this.tabSeason.Controls.Add(this.label180);
            this.tabSeason.Controls.Add(this.ImpactPlayerMin);
            this.tabSeason.Controls.Add(this.buttonImpactPlayers);
            this.tabSeason.Controls.Add(this.BodyProgressionButton);
            this.tabSeason.Controls.Add(this.buttonRealignment);
            this.tabSeason.Controls.Add(this.dbToolsInfo);
            this.tabSeason.Controls.Add(this.textBox1);
            this.tabSeason.Controls.Add(this.groupBox37);
            this.tabSeason.Location = new System.Drawing.Point(4, 24);
            this.tabSeason.Name = "tabSeason";
            this.tabSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeason.Size = new System.Drawing.Size(1152, 615);
            this.tabSeason.TabIndex = 3;
            this.tabSeason.Text = "Dynasty";
            // 
            // groupBox36
            // 
            this.groupBox36.Controls.Add(this.medRS);
            this.groupBox36.Controls.Add(this.skillDrop);
            this.groupBox36.Controls.Add(this.checkBoxInjuryRatings);
            this.groupBox36.Controls.Add(this.labelSkillDrop);
            this.groupBox36.Location = new System.Drawing.Point(263, 55);
            this.groupBox36.Name = "groupBox36";
            this.groupBox36.Size = new System.Drawing.Size(242, 117);
            this.groupBox36.TabIndex = 45;
            this.groupBox36.TabStop = false;
            this.groupBox36.Text = "Medical Redshirt";
            // 
            // medRS
            // 
            this.medRS.BackColor = System.Drawing.SystemColors.Control;
            this.medRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.medRS.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.medRS.Location = new System.Drawing.Point(135, 21);
            this.medRS.Name = "medRS";
            this.medRS.Size = new System.Drawing.Size(96, 72);
            this.medRS.TabIndex = 0;
            this.medRS.Text = "Medical Redshirt";
            this.medRS.UseVisualStyleBackColor = false;
            this.medRS.Click += new System.EventHandler(this.MedRS_Click);
            // 
            // skillDrop
            // 
            this.skillDrop.Location = new System.Drawing.Point(6, 61);
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
            this.checkBoxInjuryRatings.Location = new System.Drawing.Point(5, 30);
            this.checkBoxInjuryRatings.Name = "checkBoxInjuryRatings";
            this.checkBoxInjuryRatings.Size = new System.Drawing.Size(103, 17);
            this.checkBoxInjuryRatings.TabIndex = 9;
            this.checkBoxInjuryRatings.Text = "Reduce Ratings";
            this.checkBoxInjuryRatings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxInjuryRatings.UseVisualStyleBackColor = true;
            // 
            // labelSkillDrop
            // 
            this.labelSkillDrop.AutoSize = true;
            this.labelSkillDrop.Location = new System.Drawing.Point(54, 63);
            this.labelSkillDrop.Name = "labelSkillDrop";
            this.labelSkillDrop.Size = new System.Drawing.Size(75, 13);
            this.labelSkillDrop.TabIndex = 11;
            this.labelSkillDrop.Text = "Max Skill Drop";
            // 
            // groupBox35
            // 
            this.groupBox35.Controls.Add(this.buttonPSInjuries);
            this.groupBox35.Controls.Add(this.labelMaxSkilDrop_PS);
            this.groupBox35.Controls.Add(this.numInjuries);
            this.groupBox35.Controls.Add(this.labelPSInjuries);
            this.groupBox35.Controls.Add(this.MaxSkillDropPS);
            this.groupBox35.Location = new System.Drawing.Point(6, 55);
            this.groupBox35.Name = "groupBox35";
            this.groupBox35.Size = new System.Drawing.Size(251, 117);
            this.groupBox35.TabIndex = 44;
            this.groupBox35.TabStop = false;
            this.groupBox35.Text = "Injuries";
            // 
            // buttonPSInjuries
            // 
            this.buttonPSInjuries.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPSInjuries.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPSInjuries.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPSInjuries.Location = new System.Drawing.Point(6, 23);
            this.buttonPSInjuries.Name = "buttonPSInjuries";
            this.buttonPSInjuries.Size = new System.Drawing.Size(106, 74);
            this.buttonPSInjuries.TabIndex = 18;
            this.buttonPSInjuries.Text = "Pre-Season Injuries";
            this.buttonPSInjuries.UseVisualStyleBackColor = false;
            this.buttonPSInjuries.Click += new System.EventHandler(this.ButtonPSInjuries_Click);
            // 
            // labelMaxSkilDrop_PS
            // 
            this.labelMaxSkilDrop_PS.AutoSize = true;
            this.labelMaxSkilDrop_PS.Location = new System.Drawing.Point(166, 75);
            this.labelMaxSkilDrop_PS.Name = "labelMaxSkilDrop_PS";
            this.labelMaxSkilDrop_PS.Size = new System.Drawing.Size(75, 13);
            this.labelMaxSkilDrop_PS.TabIndex = 22;
            this.labelMaxSkilDrop_PS.Text = "Max Skill Drop";
            // 
            // numInjuries
            // 
            this.numInjuries.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numInjuries.Location = new System.Drawing.Point(118, 23);
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
            // labelPSInjuries
            // 
            this.labelPSInjuries.AutoSize = true;
            this.labelPSInjuries.Location = new System.Drawing.Point(115, 46);
            this.labelPSInjuries.Name = "labelPSInjuries";
            this.labelPSInjuries.Size = new System.Drawing.Size(93, 13);
            this.labelPSInjuries.TabIndex = 20;
            this.labelPSInjuries.Text = "Number of Players";
            // 
            // MaxSkillDropPS
            // 
            this.MaxSkillDropPS.Location = new System.Drawing.Point(118, 73);
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
            // TransferPortalStats
            // 
            this.TransferPortalStats.BackColor = System.Drawing.SystemColors.Control;
            this.TransferPortalStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransferPortalStats.Location = new System.Drawing.Point(357, 364);
            this.TransferPortalStats.Name = "TransferPortalStats";
            this.TransferPortalStats.Size = new System.Drawing.Size(125, 75);
            this.TransferPortalStats.TabIndex = 43;
            this.TransferPortalStats.Text = "[NEXT24+] Retain Transfer Portal Player Stats";
            this.TransferPortalStats.UseVisualStyleBackColor = false;
            this.TransferPortalStats.Click += new System.EventHandler(this.TransferPortalStats_Click);
            // 
            // RemoveBadTransfers
            // 
            this.RemoveBadTransfers.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveBadTransfers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveBadTransfers.Location = new System.Drawing.Point(198, 364);
            this.RemoveBadTransfers.Name = "RemoveBadTransfers";
            this.RemoveBadTransfers.Size = new System.Drawing.Size(125, 75);
            this.RemoveBadTransfers.TabIndex = 42;
            this.RemoveBadTransfers.Text = "[NEXT24+] Remove Low OVR Transfers";
            this.RemoveBadTransfers.UseVisualStyleBackColor = false;
            this.RemoveBadTransfers.Click += new System.EventHandler(this.RemoveBadTransfers_Click);
            // 
            // RemoveSanctionsButton
            // 
            this.RemoveSanctionsButton.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveSanctionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSanctionsButton.Location = new System.Drawing.Point(360, 200);
            this.RemoveSanctionsButton.Name = "RemoveSanctionsButton";
            this.RemoveSanctionsButton.Size = new System.Drawing.Size(125, 75);
            this.RemoveSanctionsButton.TabIndex = 40;
            this.RemoveSanctionsButton.Text = "Remove All Sanctions";
            this.RemoveSanctionsButton.UseVisualStyleBackColor = false;
            this.RemoveSanctionsButton.Click += new System.EventHandler(this.RemoveSanctionsButton_Click);
            // 
            // label180
            // 
            this.label180.AutoSize = true;
            this.label180.Location = new System.Drawing.Point(47, 278);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(58, 13);
            this.label180.TabIndex = 39;
            this.label180.Text = "Min Rating";
            // 
            // ImpactPlayerMin
            // 
            this.ImpactPlayerMin.Location = new System.Drawing.Point(109, 276);
            this.ImpactPlayerMin.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.ImpactPlayerMin.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.ImpactPlayerMin.Name = "ImpactPlayerMin";
            this.ImpactPlayerMin.Size = new System.Drawing.Size(44, 20);
            this.ImpactPlayerMin.TabIndex = 38;
            this.ImpactPlayerMin.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // buttonImpactPlayers
            // 
            this.buttonImpactPlayers.BackColor = System.Drawing.SystemColors.Control;
            this.buttonImpactPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImpactPlayers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonImpactPlayers.Location = new System.Drawing.Point(39, 200);
            this.buttonImpactPlayers.Name = "buttonImpactPlayers";
            this.buttonImpactPlayers.Size = new System.Drawing.Size(125, 75);
            this.buttonImpactPlayers.TabIndex = 35;
            this.buttonImpactPlayers.Text = "Determine Impact Players";
            this.buttonImpactPlayers.UseVisualStyleBackColor = false;
            this.buttonImpactPlayers.Click += new System.EventHandler(this.buttonImpactPlayers_Click);
            // 
            // BodyProgressionButton
            // 
            this.BodyProgressionButton.BackColor = System.Drawing.SystemColors.Control;
            this.BodyProgressionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BodyProgressionButton.Location = new System.Drawing.Point(201, 200);
            this.BodyProgressionButton.Name = "BodyProgressionButton";
            this.BodyProgressionButton.Size = new System.Drawing.Size(125, 75);
            this.BodyProgressionButton.TabIndex = 34;
            this.BodyProgressionButton.Text = "Body Size Progression";
            this.BodyProgressionButton.UseVisualStyleBackColor = false;
            this.BodyProgressionButton.Click += new System.EventHandler(this.BodyProgressionButton_Click);
            // 
            // buttonRealignment
            // 
            this.buttonRealignment.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRealignment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRealignment.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRealignment.Location = new System.Drawing.Point(39, 364);
            this.buttonRealignment.Name = "buttonRealignment";
            this.buttonRealignment.Size = new System.Drawing.Size(125, 75);
            this.buttonRealignment.TabIndex = 28;
            this.buttonRealignment.Text = "Automated Conference Realignment";
            this.buttonRealignment.UseVisualStyleBackColor = false;
            this.buttonRealignment.Click += new System.EventHandler(this.buttonRealignment_Click);
            // 
            // dbToolsInfo
            // 
            this.dbToolsInfo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dbToolsInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbToolsInfo.Location = new System.Drawing.Point(24, 457);
            this.dbToolsInfo.Multiline = true;
            this.dbToolsInfo.Name = "dbToolsInfo";
            this.dbToolsInfo.ReadOnly = true;
            this.dbToolsInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbToolsInfo.Size = new System.Drawing.Size(461, 142);
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
            // groupBox37
            // 
            this.groupBox37.Controls.Add(this.CoachFiringsCount);
            this.groupBox37.Controls.Add(this.label13);
            this.groupBox37.Controls.Add(this.CarouselDataGrid);
            this.groupBox37.Controls.Add(this.buttonCarousel);
            this.groupBox37.Controls.Add(this.maxFiredTransfers);
            this.groupBox37.Controls.Add(this.labelMaxTransfers);
            this.groupBox37.Controls.Add(this.poachValue);
            this.groupBox37.Controls.Add(this.jobSecurityValue);
            this.groupBox37.Controls.Add(this.labelJobSecurity);
            this.groupBox37.Controls.Add(this.labelPoaching);
            this.groupBox37.Controls.Add(this.label14);
            this.groupBox37.Controls.Add(this.checkBoxFiredTransfers);
            this.groupBox37.Controls.Add(this.numberPlayerCoach);
            this.groupBox37.Controls.Add(this.buttonPlayerCoach);
            this.groupBox37.Location = new System.Drawing.Point(512, 23);
            this.groupBox37.Name = "groupBox37";
            this.groupBox37.Size = new System.Drawing.Size(634, 589);
            this.groupBox37.TabIndex = 47;
            this.groupBox37.TabStop = false;
            this.groupBox37.Text = "Coaching Carousel";
            // 
            // CoachFiringsCount
            // 
            this.CoachFiringsCount.AutoSize = true;
            this.CoachFiringsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachFiringsCount.Location = new System.Drawing.Point(524, 168);
            this.CoachFiringsCount.Name = "CoachFiringsCount";
            this.CoachFiringsCount.Size = new System.Drawing.Size(104, 13);
            this.CoachFiringsCount.TabIndex = 47;
            this.CoachFiringsCount.Text = "XX Coach Firings";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(259, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(359, 30);
            this.label13.TabIndex = 27;
            this.label13.Text = "NCAA NEXT USERS - Perform At Players Leaving Stage\r\nVanilla Users - Perform at Co" +
    "aching Budgets Stage";
            // 
            // CarouselDataGrid
            // 
            this.CarouselDataGrid.AllowUserToAddRows = false;
            this.CarouselDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CarouselDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle57;
            this.CarouselDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.CarouselDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CarouselDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle58;
            this.CarouselDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarouselDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCName,
            this.CCStatus,
            this.CCTeam,
            this.CCTmPrestige,
            this.CCPrestige,
            this.CCRecord});
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle59.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CarouselDataGrid.DefaultCellStyle = dataGridViewCellStyle59;
            this.CarouselDataGrid.Location = new System.Drawing.Point(8, 184);
            this.CarouselDataGrid.Name = "CarouselDataGrid";
            this.CarouselDataGrid.ReadOnly = true;
            this.CarouselDataGrid.RowHeadersVisible = false;
            this.CarouselDataGrid.RowTemplate.Height = 31;
            this.CarouselDataGrid.Size = new System.Drawing.Size(620, 399);
            this.CarouselDataGrid.TabIndex = 46;
            // 
            // CCName
            // 
            this.CCName.FillWeight = 30F;
            this.CCName.HeaderText = "Coach Name";
            this.CCName.Name = "CCName";
            this.CCName.ReadOnly = true;
            this.CCName.Width = 87;
            // 
            // CCStatus
            // 
            this.CCStatus.FillWeight = 10F;
            this.CCStatus.HeaderText = "Status";
            this.CCStatus.Name = "CCStatus";
            this.CCStatus.ReadOnly = true;
            this.CCStatus.Width = 62;
            // 
            // CCTeam
            // 
            this.CCTeam.FillWeight = 30F;
            this.CCTeam.HeaderText = "Team";
            this.CCTeam.Name = "CCTeam";
            this.CCTeam.ReadOnly = true;
            this.CCTeam.Width = 59;
            // 
            // CCTmPrestige
            // 
            this.CCTmPrestige.FillWeight = 10F;
            this.CCTmPrestige.HeaderText = "Team Prestige";
            this.CCTmPrestige.Name = "CCTmPrestige";
            this.CCTmPrestige.ReadOnly = true;
            this.CCTmPrestige.Width = 92;
            // 
            // CCPrestige
            // 
            this.CCPrestige.FillWeight = 10F;
            this.CCPrestige.HeaderText = "Coach Prestige";
            this.CCPrestige.Name = "CCPrestige";
            this.CCPrestige.ReadOnly = true;
            this.CCPrestige.Width = 96;
            // 
            // CCRecord
            // 
            this.CCRecord.FillWeight = 10F;
            this.CCRecord.HeaderText = "Coach Record";
            this.CCRecord.Name = "CCRecord";
            this.CCRecord.ReadOnly = true;
            this.CCRecord.Width = 93;
            // 
            // buttonCarousel
            // 
            this.buttonCarousel.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCarousel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCarousel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonCarousel.Location = new System.Drawing.Point(18, 29);
            this.buttonCarousel.Name = "buttonCarousel";
            this.buttonCarousel.Size = new System.Drawing.Size(204, 65);
            this.buttonCarousel.TabIndex = 12;
            this.buttonCarousel.Text = "Coaching Carousel";
            this.buttonCarousel.UseVisualStyleBackColor = false;
            this.buttonCarousel.Click += new System.EventHandler(this.ButtonCarousel_Click);
            // 
            // maxFiredTransfers
            // 
            this.maxFiredTransfers.Location = new System.Drawing.Point(18, 155);
            this.maxFiredTransfers.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxFiredTransfers.Name = "maxFiredTransfers";
            this.maxFiredTransfers.Size = new System.Drawing.Size(52, 20);
            this.maxFiredTransfers.TabIndex = 25;
            this.maxFiredTransfers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelMaxTransfers
            // 
            this.labelMaxTransfers.AutoSize = true;
            this.labelMaxTransfers.Location = new System.Drawing.Point(76, 157);
            this.labelMaxTransfers.Name = "labelMaxTransfers";
            this.labelMaxTransfers.Size = new System.Drawing.Size(74, 13);
            this.labelMaxTransfers.TabIndex = 26;
            this.labelMaxTransfers.Text = "Max Transfers";
            // 
            // poachValue
            // 
            this.poachValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.poachValue.Location = new System.Drawing.Point(18, 129);
            this.poachValue.Maximum = new decimal(new int[] {
            85,
            0,
            0,
            0});
            this.poachValue.Name = "poachValue";
            this.poachValue.Size = new System.Drawing.Size(51, 20);
            this.poachValue.TabIndex = 15;
            this.poachValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // jobSecurityValue
            // 
            this.jobSecurityValue.Location = new System.Drawing.Point(18, 103);
            this.jobSecurityValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.jobSecurityValue.Name = "jobSecurityValue";
            this.jobSecurityValue.Size = new System.Drawing.Size(52, 20);
            this.jobSecurityValue.TabIndex = 13;
            this.jobSecurityValue.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // labelJobSecurity
            // 
            this.labelJobSecurity.AutoSize = true;
            this.labelJobSecurity.Location = new System.Drawing.Point(74, 108);
            this.labelJobSecurity.Name = "labelJobSecurity";
            this.labelJobSecurity.Size = new System.Drawing.Size(266, 13);
            this.labelJobSecurity.TabIndex = 14;
            this.labelJobSecurity.Text = "Job Security Value To Fire Coach (Set to 60 for Vanilla)";
            // 
            // labelPoaching
            // 
            this.labelPoaching.AutoSize = true;
            this.labelPoaching.Location = new System.Drawing.Point(74, 131);
            this.labelPoaching.Name = "labelPoaching";
            this.labelPoaching.Size = new System.Drawing.Size(192, 13);
            this.labelPoaching.TabIndex = 16;
            this.labelPoaching.Text = "% Chance Active Coach Can Get Hired";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(447, 142);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Number of Players";
            // 
            // checkBoxFiredTransfers
            // 
            this.checkBoxFiredTransfers.AutoSize = true;
            this.checkBoxFiredTransfers.Location = new System.Drawing.Point(156, 157);
            this.checkBoxFiredTransfers.Name = "checkBoxFiredTransfers";
            this.checkBoxFiredTransfers.Size = new System.Drawing.Size(180, 17);
            this.checkBoxFiredTransfers.TabIndex = 24;
            this.checkBoxFiredTransfers.Text = "Players can enter Transfer Portal";
            this.checkBoxFiredTransfers.UseVisualStyleBackColor = true;
            // 
            // numberPlayerCoach
            // 
            this.numberPlayerCoach.Location = new System.Drawing.Point(546, 138);
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
            this.buttonPlayerCoach.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPlayerCoach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPlayerCoach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonPlayerCoach.Location = new System.Drawing.Point(422, 71);
            this.buttonPlayerCoach.Name = "buttonPlayerCoach";
            this.buttonPlayerCoach.Size = new System.Drawing.Size(206, 65);
            this.buttonPlayerCoach.TabIndex = 30;
            this.buttonPlayerCoach.Text = "Promote Players to Coaching";
            this.buttonPlayerCoach.UseVisualStyleBackColor = false;
            this.buttonPlayerCoach.Click += new System.EventHandler(this.buttonPlayerCoach_Click);
            // 
            // tabCoaches
            // 
            this.tabCoaches.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabCoaches.Controls.Add(this.CoachPerfCheckBox);
            this.tabCoaches.Controls.Add(this.groupBox9);
            this.tabCoaches.Controls.Add(this.groupBox8);
            this.tabCoaches.Controls.Add(this.groupBox7);
            this.tabCoaches.Controls.Add(this.CoachShowTeamBox);
            this.tabCoaches.Controls.Add(this.label95);
            this.tabCoaches.Controls.Add(this.CoachFilter);
            this.tabCoaches.Controls.Add(this.CoachListBox);
            this.tabCoaches.Location = new System.Drawing.Point(4, 24);
            this.tabCoaches.Name = "tabCoaches";
            this.tabCoaches.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoaches.Size = new System.Drawing.Size(1152, 615);
            this.tabCoaches.TabIndex = 7;
            this.tabCoaches.Text = "Coaches";
            // 
            // CoachPerfCheckBox
            // 
            this.CoachPerfCheckBox.AutoSize = true;
            this.CoachPerfCheckBox.Location = new System.Drawing.Point(101, 592);
            this.CoachPerfCheckBox.Name = "CoachPerfCheckBox";
            this.CoachPerfCheckBox.Size = new System.Drawing.Size(86, 17);
            this.CoachPerfCheckBox.TabIndex = 242;
            this.CoachPerfCheckBox.Text = "Performance";
            this.CoachPerfCheckBox.UseVisualStyleBackColor = true;
            this.CoachPerfCheckBox.CheckedChanged += new System.EventHandler(this.CoachPerfCheckBox_CheckedChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label179);
            this.groupBox9.Controls.Add(this.YearsWithTeam);
            this.groupBox9.Controls.Add(this.label177);
            this.groupBox9.Controls.Add(this.ConfTitles);
            this.groupBox9.Controls.Add(this.LabelNT);
            this.groupBox9.Controls.Add(this.NationalTitles);
            this.groupBox9.Controls.Add(this.label176);
            this.groupBox9.Controls.Add(this.ContractInfo);
            this.groupBox9.Controls.Add(this.label175);
            this.groupBox9.Controls.Add(this.CoachTeamPrestige);
            this.groupBox9.Controls.Add(this.label174);
            this.groupBox9.Controls.Add(this.Top25Record);
            this.groupBox9.Controls.Add(this.label88);
            this.groupBox9.Controls.Add(this.WinningSeasons);
            this.groupBox9.Controls.Add(this.label38);
            this.groupBox9.Controls.Add(this.BowlRecord);
            this.groupBox9.Controls.Add(this.label131);
            this.groupBox9.Controls.Add(this.YearsCoached);
            this.groupBox9.Controls.Add(this.label54);
            this.groupBox9.Controls.Add(this.CareerRecord);
            this.groupBox9.Controls.Add(this.label53);
            this.groupBox9.Controls.Add(this.SeasonRecord);
            this.groupBox9.Controls.Add(this.CoachCCPONum);
            this.groupBox9.Controls.Add(this.label141);
            this.groupBox9.Controls.Add(this.HCPrestigeNum);
            this.groupBox9.Controls.Add(this.label146);
            this.groupBox9.Location = new System.Drawing.Point(687, 9);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(443, 320);
            this.groupBox9.TabIndex = 241;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Coach History";
            // 
            // label179
            // 
            this.label179.AutoSize = true;
            this.label179.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label179.Location = new System.Drawing.Point(290, 205);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(86, 13);
            this.label179.TabIndex = 21;
            this.label179.Text = "Years with Team";
            // 
            // YearsWithTeam
            // 
            this.YearsWithTeam.AutoSize = true;
            this.YearsWithTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearsWithTeam.Location = new System.Drawing.Point(290, 224);
            this.YearsWithTeam.Name = "YearsWithTeam";
            this.YearsWithTeam.Size = new System.Drawing.Size(70, 16);
            this.YearsWithTeam.TabIndex = 20;
            this.YearsWithTeam.Text = "XX Years";
            // 
            // label177
            // 
            this.label177.AutoSize = true;
            this.label177.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label177.Location = new System.Drawing.Point(150, 261);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(90, 13);
            this.label177.TabIndex = 19;
            this.label177.Text = "Conference Titles";
            // 
            // ConfTitles
            // 
            this.ConfTitles.AutoSize = true;
            this.ConfTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConfTitles.Location = new System.Drawing.Point(150, 280);
            this.ConfTitles.Name = "ConfTitles";
            this.ConfTitles.Size = new System.Drawing.Size(38, 16);
            this.ConfTitles.TabIndex = 18;
            this.ConfTitles.Text = "X / X";
            // 
            // LabelNT
            // 
            this.LabelNT.AutoSize = true;
            this.LabelNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNT.Location = new System.Drawing.Point(18, 261);
            this.LabelNT.Name = "LabelNT";
            this.LabelNT.Size = new System.Drawing.Size(74, 13);
            this.LabelNT.TabIndex = 17;
            this.LabelNT.Text = "National Titles";
            // 
            // NationalTitles
            // 
            this.NationalTitles.AutoSize = true;
            this.NationalTitles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NationalTitles.Location = new System.Drawing.Point(18, 280);
            this.NationalTitles.Name = "NationalTitles";
            this.NationalTitles.Size = new System.Drawing.Size(38, 16);
            this.NationalTitles.TabIndex = 16;
            this.NationalTitles.Text = "X / X";
            // 
            // label176
            // 
            this.label176.AutoSize = true;
            this.label176.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label176.Location = new System.Drawing.Point(218, 79);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(68, 13);
            this.label176.TabIndex = 15;
            this.label176.Text = "Contract Info";
            // 
            // ContractInfo
            // 
            this.ContractInfo.AutoSize = true;
            this.ContractInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContractInfo.Location = new System.Drawing.Point(218, 98);
            this.ContractInfo.Name = "ContractInfo";
            this.ContractInfo.Size = new System.Drawing.Size(161, 16);
            this.ContractInfo.TabIndex = 14;
            this.ContractInfo.Text = "X / X Years Remaining";
            // 
            // label175
            // 
            this.label175.AutoSize = true;
            this.label175.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label175.Location = new System.Drawing.Point(18, 78);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(75, 13);
            this.label175.TabIndex = 13;
            this.label175.Text = "Team Prestige";
            // 
            // CoachTeamPrestige
            // 
            this.CoachTeamPrestige.AutoSize = true;
            this.CoachTeamPrestige.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachTeamPrestige.Location = new System.Drawing.Point(18, 97);
            this.CoachTeamPrestige.Name = "CoachTeamPrestige";
            this.CoachTeamPrestige.Size = new System.Drawing.Size(178, 16);
            this.CoachTeamPrestige.TabIndex = 12;
            this.CoachTeamPrestige.Text = "Current: XX || Original: XX";
            // 
            // label174
            // 
            this.label174.AutoSize = true;
            this.label174.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label174.Location = new System.Drawing.Point(150, 206);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(79, 13);
            this.label174.TabIndex = 11;
            this.label174.Text = "Top 25 Record";
            // 
            // Top25Record
            // 
            this.Top25Record.AutoSize = true;
            this.Top25Record.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Top25Record.Location = new System.Drawing.Point(150, 225);
            this.Top25Record.Name = "Top25Record";
            this.Top25Record.Size = new System.Drawing.Size(64, 16);
            this.Top25Record.TabIndex = 10;
            this.Top25Record.Text = "WW - LL";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(290, 261);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(90, 13);
            this.label88.TabIndex = 9;
            this.label88.Text = "Winning Seasons";
            // 
            // WinningSeasons
            // 
            this.WinningSeasons.AutoSize = true;
            this.WinningSeasons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WinningSeasons.Location = new System.Drawing.Point(290, 280);
            this.WinningSeasons.Name = "WinningSeasons";
            this.WinningSeasons.Size = new System.Drawing.Size(34, 16);
            this.WinningSeasons.TabIndex = 8;
            this.WinningSeasons.Text = "XXX";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(150, 145);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(68, 13);
            this.label38.TabIndex = 7;
            this.label38.Text = "Bowl Record";
            // 
            // BowlRecord
            // 
            this.BowlRecord.AutoSize = true;
            this.BowlRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BowlRecord.Location = new System.Drawing.Point(150, 164);
            this.BowlRecord.Name = "BowlRecord";
            this.BowlRecord.Size = new System.Drawing.Size(64, 16);
            this.BowlRecord.TabIndex = 6;
            this.BowlRecord.Text = "WW - LL";
            // 
            // label131
            // 
            this.label131.AutoSize = true;
            this.label131.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label131.Location = new System.Drawing.Point(332, 16);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(80, 13);
            this.label131.TabIndex = 5;
            this.label131.Text = "Years Coached";
            // 
            // YearsCoached
            // 
            this.YearsCoached.AutoSize = true;
            this.YearsCoached.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YearsCoached.Location = new System.Drawing.Point(332, 35);
            this.YearsCoached.Name = "YearsCoached";
            this.YearsCoached.Size = new System.Drawing.Size(34, 16);
            this.YearsCoached.TabIndex = 4;
            this.YearsCoached.Text = "XXX";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(18, 205);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(76, 13);
            this.label54.TabIndex = 3;
            this.label54.Text = "Career Record";
            // 
            // CareerRecord
            // 
            this.CareerRecord.AutoSize = true;
            this.CareerRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CareerRecord.Location = new System.Drawing.Point(18, 224);
            this.CareerRecord.Name = "CareerRecord";
            this.CareerRecord.Size = new System.Drawing.Size(64, 16);
            this.CareerRecord.TabIndex = 2;
            this.CareerRecord.Text = "WW - LL";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(18, 145);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(81, 13);
            this.label53.TabIndex = 1;
            this.label53.Text = "Season Record";
            // 
            // SeasonRecord
            // 
            this.SeasonRecord.AutoSize = true;
            this.SeasonRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeasonRecord.Location = new System.Drawing.Point(18, 164);
            this.SeasonRecord.Name = "SeasonRecord";
            this.SeasonRecord.Size = new System.Drawing.Size(64, 16);
            this.SeasonRecord.TabIndex = 0;
            this.SeasonRecord.Text = "WW - LL";
            // 
            // CoachCCPONum
            // 
            this.CoachCCPONum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachCCPONum.Location = new System.Drawing.Point(224, 33);
            this.CoachCCPONum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.CoachCCPONum.Name = "CoachCCPONum";
            this.CoachCCPONum.Size = new System.Drawing.Size(50, 22);
            this.CoachCCPONum.TabIndex = 206;
            this.CoachCCPONum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCCPONum.ValueChanged += new System.EventHandler(this.CoachCCPONum_ValueChanged);
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Location = new System.Drawing.Point(151, 38);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(67, 13);
            this.label141.TabIndex = 205;
            this.label141.Text = "Performance";
            // 
            // HCPrestigeNum
            // 
            this.HCPrestigeNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HCPrestigeNum.Location = new System.Drawing.Point(86, 33);
            this.HCPrestigeNum.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.HCPrestigeNum.Name = "HCPrestigeNum";
            this.HCPrestigeNum.Size = new System.Drawing.Size(50, 22);
            this.HCPrestigeNum.TabIndex = 204;
            this.HCPrestigeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCPrestigeNum.ValueChanged += new System.EventHandler(this.HCPrestigeNum_ValueChanged);
            // 
            // label146
            // 
            this.label146.AutoSize = true;
            this.label146.Location = new System.Drawing.Point(19, 37);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(63, 13);
            this.label146.TabIndex = 195;
            this.label146.Text = "HC Prestige";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.AutoAdjustBudgetsButton);
            this.groupBox8.Controls.Add(this.label178);
            this.groupBox8.Controls.Add(this.coachProg);
            this.groupBox8.Controls.Add(this.CoachPrestigeButton);
            this.groupBox8.Controls.Add(this.buttonRandomBudgets);
            this.groupBox8.Controls.Add(this.SetMaxCoachCCPO);
            this.groupBox8.Controls.Add(this.MaxCCPOVal);
            this.groupBox8.Location = new System.Drawing.Point(687, 361);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(443, 236);
            this.groupBox8.TabIndex = 240;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Global Coach Editor";
            // 
            // AutoAdjustBudgetsButton
            // 
            this.AutoAdjustBudgetsButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.AutoAdjustBudgetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoAdjustBudgetsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AutoAdjustBudgetsButton.Location = new System.Drawing.Point(166, 31);
            this.AutoAdjustBudgetsButton.Name = "AutoAdjustBudgetsButton";
            this.AutoAdjustBudgetsButton.Size = new System.Drawing.Size(120, 66);
            this.AutoAdjustBudgetsButton.TabIndex = 39;
            this.AutoAdjustBudgetsButton.Text = "Auto-Adjust Coaching Budgets";
            this.AutoAdjustBudgetsButton.UseVisualStyleBackColor = false;
            this.AutoAdjustBudgetsButton.Click += new System.EventHandler(this.AutoAdjustBudgetsButton_Click);
            // 
            // label178
            // 
            this.label178.AutoSize = true;
            this.label178.Location = new System.Drawing.Point(17, 95);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(131, 13);
            this.label178.TabIndex = 38;
            this.label178.Text = "Do Not Use For NEXT25+";
            // 
            // coachProg
            // 
            this.coachProg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.coachProg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coachProg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.coachProg.Location = new System.Drawing.Point(22, 31);
            this.coachProg.Name = "coachProg";
            this.coachProg.Size = new System.Drawing.Size(118, 61);
            this.coachProg.TabIndex = 37;
            this.coachProg.Text = "Coach Prestige Progression";
            this.coachProg.UseVisualStyleBackColor = false;
            this.coachProg.Click += new System.EventHandler(this.coachProg_Click);
            // 
            // CoachPrestigeButton
            // 
            this.CoachPrestigeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CoachPrestigeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachPrestigeButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CoachPrestigeButton.Location = new System.Drawing.Point(307, 121);
            this.CoachPrestigeButton.Name = "CoachPrestigeButton";
            this.CoachPrestigeButton.Size = new System.Drawing.Size(120, 66);
            this.CoachPrestigeButton.TabIndex = 35;
            this.CoachPrestigeButton.Text = "Randomized Free Agent Coach Prestige";
            this.CoachPrestigeButton.UseVisualStyleBackColor = false;
            this.CoachPrestigeButton.Click += new System.EventHandler(this.CoachPrestigeButton_Click);
            // 
            // buttonRandomBudgets
            // 
            this.buttonRandomBudgets.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRandomBudgets.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRandomBudgets.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonRandomBudgets.Location = new System.Drawing.Point(166, 121);
            this.buttonRandomBudgets.Name = "buttonRandomBudgets";
            this.buttonRandomBudgets.Size = new System.Drawing.Size(120, 66);
            this.buttonRandomBudgets.TabIndex = 34;
            this.buttonRandomBudgets.Text = "Randomize Coaching Budgets";
            this.buttonRandomBudgets.UseVisualStyleBackColor = false;
            this.buttonRandomBudgets.Click += new System.EventHandler(this.buttonRandomBudgets_Click);
            // 
            // SetMaxCoachCCPO
            // 
            this.SetMaxCoachCCPO.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SetMaxCoachCCPO.Location = new System.Drawing.Point(22, 121);
            this.SetMaxCoachCCPO.Name = "SetMaxCoachCCPO";
            this.SetMaxCoachCCPO.Size = new System.Drawing.Size(118, 66);
            this.SetMaxCoachCCPO.TabIndex = 1;
            this.SetMaxCoachCCPO.Text = "Set Max Coach Performance Value";
            this.SetMaxCoachCCPO.UseVisualStyleBackColor = false;
            this.SetMaxCoachCCPO.Click += new System.EventHandler(this.SetMaxCoachCCPO_Click);
            // 
            // MaxCCPOVal
            // 
            this.MaxCCPOVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxCCPOVal.Location = new System.Drawing.Point(20, 197);
            this.MaxCCPOVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.MaxCCPOVal.Name = "MaxCCPOVal";
            this.MaxCCPOVal.Size = new System.Drawing.Size(120, 22);
            this.MaxCCPOVal.TabIndex = 0;
            this.MaxCCPOVal.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.DisciplineAssistanceBox);
            this.groupBox7.Controls.Add(this.RecruitAssistanceBox);
            this.groupBox7.Controls.Add(this.NewCoachButton);
            this.groupBox7.Controls.Add(this.label130);
            this.groupBox7.Controls.Add(this.label129);
            this.groupBox7.Controls.Add(this.CoachTeamList);
            this.groupBox7.Controls.Add(this.CSKIBox);
            this.groupBox7.Controls.Add(this.label98);
            this.groupBox7.Controls.Add(this.label105);
            this.groupBox7.Controls.Add(this.CFUCBox);
            this.groupBox7.Controls.Add(this.CBSZBox);
            this.groupBox7.Controls.Add(this.label96);
            this.groupBox7.Controls.Add(this.label104);
            this.groupBox7.Controls.Add(this.COHTBox);
            this.groupBox7.Controls.Add(this.CFEXBox);
            this.groupBox7.Controls.Add(this.label97);
            this.groupBox7.Controls.Add(this.label103);
            this.groupBox7.Controls.Add(this.CTgwBox);
            this.groupBox7.Controls.Add(this.CHARBox);
            this.groupBox7.Controls.Add(this.label102);
            this.groupBox7.Controls.Add(this.CTHGBox);
            this.groupBox7.Controls.Add(this.CoachPlaybookBox);
            this.groupBox7.Controls.Add(this.label101);
            this.groupBox7.Controls.Add(this.CoachDefTypeBox);
            this.groupBox7.Controls.Add(this.label94);
            this.groupBox7.Controls.Add(this.CoachOffTypeBox);
            this.groupBox7.Controls.Add(this.CoachFirstNameBox);
            this.groupBox7.Controls.Add(this.CoachCDTSBox);
            this.groupBox7.Controls.Add(this.CoachLastNameBox);
            this.groupBox7.Controls.Add(this.label132);
            this.groupBox7.Controls.Add(this.CCIDBox);
            this.groupBox7.Controls.Add(this.CoachCDTABox);
            this.groupBox7.Controls.Add(this.CoachDisciplineBox);
            this.groupBox7.Controls.Add(this.CoachCDTRBox);
            this.groupBox7.Controls.Add(this.label145);
            this.groupBox7.Controls.Add(this.label133);
            this.groupBox7.Controls.Add(this.label144);
            this.groupBox7.Controls.Add(this.label134);
            this.groupBox7.Controls.Add(this.label143);
            this.groupBox7.Controls.Add(this.CoachCOTSBox);
            this.groupBox7.Controls.Add(this.label142);
            this.groupBox7.Controls.Add(this.label135);
            this.groupBox7.Controls.Add(this.CoachTrainingBox);
            this.groupBox7.Controls.Add(this.CoachCOTABox);
            this.groupBox7.Controls.Add(this.CoachRecruitingBox);
            this.groupBox7.Controls.Add(this.CoachCOTRBox);
            this.groupBox7.Controls.Add(this.label136);
            this.groupBox7.Controls.Add(this.label137);
            this.groupBox7.Controls.Add(this.label138);
            this.groupBox7.Controls.Add(this.label140);
            this.groupBox7.Controls.Add(this.label139);
            this.groupBox7.Location = new System.Drawing.Point(241, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(419, 588);
            this.groupBox7.TabIndex = 239;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Coach Editor";
            // 
            // DisciplineAssistanceBox
            // 
            this.DisciplineAssistanceBox.AutoSize = true;
            this.DisciplineAssistanceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DisciplineAssistanceBox.Location = new System.Drawing.Point(15, 564);
            this.DisciplineAssistanceBox.Name = "DisciplineAssistanceBox";
            this.DisciplineAssistanceBox.Size = new System.Drawing.Size(162, 19);
            this.DisciplineAssistanceBox.TabIndex = 240;
            this.DisciplineAssistanceBox.Text = "Discipline Assistance";
            this.DisciplineAssistanceBox.UseVisualStyleBackColor = true;
            this.DisciplineAssistanceBox.CheckedChanged += new System.EventHandler(this.DisciplineAssistanceBox_CheckedChanged);
            // 
            // RecruitAssistanceBox
            // 
            this.RecruitAssistanceBox.AutoSize = true;
            this.RecruitAssistanceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecruitAssistanceBox.Location = new System.Drawing.Point(15, 538);
            this.RecruitAssistanceBox.Name = "RecruitAssistanceBox";
            this.RecruitAssistanceBox.Size = new System.Drawing.Size(144, 19);
            this.RecruitAssistanceBox.TabIndex = 239;
            this.RecruitAssistanceBox.Text = "Recruit Assistance";
            this.RecruitAssistanceBox.UseVisualStyleBackColor = true;
            this.RecruitAssistanceBox.CheckedChanged += new System.EventHandler(this.RecruitAssistanceBox_CheckedChanged);
            // 
            // NewCoachButton
            // 
            this.NewCoachButton.BackColor = System.Drawing.Color.PaleGreen;
            this.NewCoachButton.Location = new System.Drawing.Point(275, 538);
            this.NewCoachButton.Name = "NewCoachButton";
            this.NewCoachButton.Size = new System.Drawing.Size(138, 44);
            this.NewCoachButton.TabIndex = 238;
            this.NewCoachButton.Text = "Generate New Coach";
            this.NewCoachButton.UseVisualStyleBackColor = false;
            this.NewCoachButton.Click += new System.EventHandler(this.NewCoachButton_Click);
            // 
            // label130
            // 
            this.label130.AutoSize = true;
            this.label130.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label130.Location = new System.Drawing.Point(24, 69);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(82, 16);
            this.label130.TabIndex = 101;
            this.label130.Text = "First Name";
            // 
            // label129
            // 
            this.label129.AutoSize = true;
            this.label129.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label129.Location = new System.Drawing.Point(203, 69);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(81, 16);
            this.label129.TabIndex = 102;
            this.label129.Text = "Last Name";
            // 
            // CoachTeamList
            // 
            this.CoachTeamList.FormattingEnabled = true;
            this.CoachTeamList.Location = new System.Drawing.Point(236, 33);
            this.CoachTeamList.MaxLength = 2;
            this.CoachTeamList.Name = "CoachTeamList";
            this.CoachTeamList.Size = new System.Drawing.Size(138, 21);
            this.CoachTeamList.TabIndex = 236;
            this.CoachTeamList.Tag = "x";
            this.CoachTeamList.SelectedIndexChanged += new System.EventHandler(this.CoachTeamList_SelectedIndexChanged);
            // 
            // CSKIBox
            // 
            this.CSKIBox.FormattingEnabled = true;
            this.CSKIBox.Location = new System.Drawing.Point(24, 150);
            this.CSKIBox.Name = "CSKIBox";
            this.CSKIBox.Size = new System.Drawing.Size(67, 21);
            this.CSKIBox.TabIndex = 168;
            this.CSKIBox.SelectedIndexChanged += new System.EventHandler(this.CSKIBox_SelectedIndexChanged);
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label98.Location = new System.Drawing.Point(231, 13);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(47, 16);
            this.label98.TabIndex = 235;
            this.label98.Text = "Team";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Location = new System.Drawing.Point(25, 133);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(56, 13);
            this.label105.TabIndex = 169;
            this.label105.Text = "Skin Tone";
            // 
            // CFUCBox
            // 
            this.CFUCBox.AutoSize = true;
            this.CFUCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CFUCBox.Location = new System.Drawing.Point(19, 27);
            this.CFUCBox.Name = "CFUCBox";
            this.CFUCBox.Size = new System.Drawing.Size(122, 24);
            this.CFUCBox.TabIndex = 234;
            this.CFUCBox.Text = "User Coach";
            this.CFUCBox.UseVisualStyleBackColor = true;
            this.CFUCBox.CheckedChanged += new System.EventHandler(this.CFUCBox_CheckedChanged);
            // 
            // CBSZBox
            // 
            this.CBSZBox.FormattingEnabled = true;
            this.CBSZBox.Location = new System.Drawing.Point(97, 150);
            this.CBSZBox.Name = "CBSZBox";
            this.CBSZBox.Size = new System.Drawing.Size(68, 21);
            this.CBSZBox.TabIndex = 170;
            this.CBSZBox.SelectedIndexChanged += new System.EventHandler(this.CBSZBox_SelectedIndexChanged);
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(284, 181);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(62, 13);
            this.label96.TabIndex = 233;
            this.label96.Text = "Head Wear";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(94, 133);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(31, 13);
            this.label104.TabIndex = 171;
            this.label104.Text = "Body";
            // 
            // COHTBox
            // 
            this.COHTBox.FormattingEnabled = true;
            this.COHTBox.Location = new System.Drawing.Point(268, 197);
            this.COHTBox.Name = "COHTBox";
            this.COHTBox.Size = new System.Drawing.Size(121, 21);
            this.COHTBox.TabIndex = 232;
            this.COHTBox.SelectedIndexChanged += new System.EventHandler(this.COHTBox_SelectedIndexChanged);
            // 
            // CFEXBox
            // 
            this.CFEXBox.FormattingEnabled = true;
            this.CFEXBox.Location = new System.Drawing.Point(24, 197);
            this.CFEXBox.Name = "CFEXBox";
            this.CFEXBox.Size = new System.Drawing.Size(101, 21);
            this.CFEXBox.TabIndex = 172;
            this.CFEXBox.SelectedIndexChanged += new System.EventHandler(this.CFEXBox_SelectedIndexChanged);
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(169, 181);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(44, 13);
            this.label97.TabIndex = 231;
            this.label97.Text = "Glasses";
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(25, 181);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(31, 13);
            this.label103.TabIndex = 173;
            this.label103.Text = "Face";
            // 
            // CTgwBox
            // 
            this.CTgwBox.FormattingEnabled = true;
            this.CTgwBox.Location = new System.Drawing.Point(172, 197);
            this.CTgwBox.Name = "CTgwBox";
            this.CTgwBox.Size = new System.Drawing.Size(81, 21);
            this.CTgwBox.TabIndex = 230;
            this.CTgwBox.SelectedIndexChanged += new System.EventHandler(this.CTgwBox_SelectedIndexChanged);
            // 
            // CHARBox
            // 
            this.CHARBox.FormattingEnabled = true;
            this.CHARBox.Location = new System.Drawing.Point(172, 150);
            this.CHARBox.Name = "CHARBox";
            this.CHARBox.Size = new System.Drawing.Size(94, 21);
            this.CHARBox.TabIndex = 174;
            this.CHARBox.SelectedIndexChanged += new System.EventHandler(this.CHARBox_SelectedIndexChanged);
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(169, 134);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(53, 13);
            this.label102.TabIndex = 175;
            this.label102.Text = "Hair Color";
            // 
            // CTHGBox
            // 
            this.CTHGBox.FormattingEnabled = true;
            this.CTHGBox.Location = new System.Drawing.Point(276, 150);
            this.CTHGBox.Name = "CTHGBox";
            this.CTHGBox.Size = new System.Drawing.Size(113, 21);
            this.CTHGBox.TabIndex = 176;
            this.CTHGBox.SelectedIndexChanged += new System.EventHandler(this.CTHGBox_SelectedIndexChanged);
            // 
            // CoachPlaybookBox
            // 
            this.CoachPlaybookBox.FormattingEnabled = true;
            this.CoachPlaybookBox.Location = new System.Drawing.Point(112, 323);
            this.CoachPlaybookBox.MaxLength = 2;
            this.CoachPlaybookBox.Name = "CoachPlaybookBox";
            this.CoachPlaybookBox.Size = new System.Drawing.Size(138, 21);
            this.CoachPlaybookBox.TabIndex = 225;
            this.CoachPlaybookBox.Tag = "x";
            this.CoachPlaybookBox.SelectedIndexChanged += new System.EventHandler(this.CoachPlaybookBox_SelectedIndexChanged);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(273, 134);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(52, 13);
            this.label101.TabIndex = 177;
            this.label101.Text = "Hair Style";
            // 
            // CoachDefTypeBox
            // 
            this.CoachDefTypeBox.FormattingEnabled = true;
            this.CoachDefTypeBox.Location = new System.Drawing.Point(216, 374);
            this.CoachDefTypeBox.MaxLength = 2;
            this.CoachDefTypeBox.Name = "CoachDefTypeBox";
            this.CoachDefTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CoachDefTypeBox.Size = new System.Drawing.Size(138, 21);
            this.CoachDefTypeBox.TabIndex = 224;
            this.CoachDefTypeBox.Tag = "x";
            this.CoachDefTypeBox.SelectedIndexChanged += new System.EventHandler(this.CoachDefTypeBox_SelectedIndexChanged);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label94.Location = new System.Drawing.Point(147, 13);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(70, 16);
            this.label94.TabIndex = 192;
            this.label94.Text = "Coach ID";
            // 
            // CoachOffTypeBox
            // 
            this.CoachOffTypeBox.FormattingEnabled = true;
            this.CoachOffTypeBox.Location = new System.Drawing.Point(24, 374);
            this.CoachOffTypeBox.MaxLength = 2;
            this.CoachOffTypeBox.Name = "CoachOffTypeBox";
            this.CoachOffTypeBox.Size = new System.Drawing.Size(138, 21);
            this.CoachOffTypeBox.TabIndex = 223;
            this.CoachOffTypeBox.Tag = "x";
            this.CoachOffTypeBox.SelectedIndexChanged += new System.EventHandler(this.CoachOffTypeBox_SelectedIndexChanged);
            // 
            // CoachFirstNameBox
            // 
            this.CoachFirstNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachFirstNameBox.Location = new System.Drawing.Point(24, 89);
            this.CoachFirstNameBox.Name = "CoachFirstNameBox";
            this.CoachFirstNameBox.Size = new System.Drawing.Size(162, 22);
            this.CoachFirstNameBox.TabIndex = 99;
            this.CoachFirstNameBox.Leave += new System.EventHandler(this.CoachFirstNameBox_TextChanged);
            // 
            // CoachCDTSBox
            // 
            this.CoachCDTSBox.Location = new System.Drawing.Point(216, 495);
            this.CoachCDTSBox.Name = "CoachCDTSBox";
            this.CoachCDTSBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTSBox.TabIndex = 221;
            this.CoachCDTSBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTSBox.ValueChanged += new System.EventHandler(this.CoachCDTSBox_ValueChanged);
            // 
            // CoachLastNameBox
            // 
            this.CoachLastNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoachLastNameBox.Location = new System.Drawing.Point(206, 89);
            this.CoachLastNameBox.Name = "CoachLastNameBox";
            this.CoachLastNameBox.Size = new System.Drawing.Size(168, 22);
            this.CoachLastNameBox.TabIndex = 100;
            this.CoachLastNameBox.Leave += new System.EventHandler(this.CoachLastNameBox_TextChanged);
            // 
            // label132
            // 
            this.label132.AutoSize = true;
            this.label132.Location = new System.Drawing.Point(269, 500);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(31, 13);
            this.label132.TabIndex = 220;
            this.label132.Text = "Subs";
            // 
            // CCIDBox
            // 
            this.CCIDBox.BackColor = System.Drawing.SystemColors.Info;
            this.CCIDBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CCIDBox.Location = new System.Drawing.Point(155, 32);
            this.CCIDBox.Name = "CCIDBox";
            this.CCIDBox.ReadOnly = true;
            this.CCIDBox.Size = new System.Drawing.Size(53, 22);
            this.CCIDBox.TabIndex = 191;
            this.CCIDBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoachCDTABox
            // 
            this.CoachCDTABox.Location = new System.Drawing.Point(216, 460);
            this.CoachCDTABox.Name = "CoachCDTABox";
            this.CoachCDTABox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTABox.TabIndex = 219;
            this.CoachCDTABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTABox.ValueChanged += new System.EventHandler(this.CoachCDTABox_ValueChanged);
            // 
            // CoachDisciplineBox
            // 
            this.CoachDisciplineBox.Location = new System.Drawing.Point(92, 272);
            this.CoachDisciplineBox.Name = "CoachDisciplineBox";
            this.CoachDisciplineBox.ReadOnly = true;
            this.CoachDisciplineBox.Size = new System.Drawing.Size(50, 20);
            this.CoachDisciplineBox.TabIndex = 197;
            this.CoachDisciplineBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CoachCDTRBox
            // 
            this.CoachCDTRBox.Location = new System.Drawing.Point(216, 419);
            this.CoachCDTRBox.Name = "CoachCDTRBox";
            this.CoachCDTRBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCDTRBox.TabIndex = 218;
            this.CoachCDTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCDTRBox.ValueChanged += new System.EventHandler(this.CoachCDTRBox_ValueChanged);
            // 
            // label145
            // 
            this.label145.AutoSize = true;
            this.label145.Location = new System.Drawing.Point(89, 256);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(60, 13);
            this.label145.TabIndex = 198;
            this.label145.Text = "Disciplining";
            // 
            // label133
            // 
            this.label133.AutoSize = true;
            this.label133.Location = new System.Drawing.Point(268, 462);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(81, 13);
            this.label133.TabIndex = 217;
            this.label133.Text = "Aggressiveness";
            // 
            // label144
            // 
            this.label144.AutoSize = true;
            this.label144.Location = new System.Drawing.Point(164, 256);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(45, 13);
            this.label144.TabIndex = 199;
            this.label144.Text = "Training";
            // 
            // label134
            // 
            this.label134.AutoSize = true;
            this.label134.Location = new System.Drawing.Point(268, 419);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(63, 13);
            this.label134.TabIndex = 216;
            this.label134.Text = "Passing Pct";
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Location = new System.Drawing.Point(225, 256);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(55, 13);
            this.label143.TabIndex = 200;
            this.label143.Text = "Recruiting";
            // 
            // CoachCOTSBox
            // 
            this.CoachCOTSBox.Location = new System.Drawing.Point(112, 493);
            this.CoachCOTSBox.Name = "CoachCOTSBox";
            this.CoachCOTSBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTSBox.TabIndex = 215;
            this.CoachCOTSBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTSBox.ValueChanged += new System.EventHandler(this.CoachCOTSBox_ValueChanged);
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(124, 240);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(114, 13);
            this.label142.TabIndex = 201;
            this.label142.Text = "Off-Season Budget";
            // 
            // label135
            // 
            this.label135.AutoSize = true;
            this.label135.Location = new System.Drawing.Point(70, 495);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(31, 13);
            this.label135.TabIndex = 214;
            this.label135.Text = "Subs";
            // 
            // CoachTrainingBox
            // 
            this.CoachTrainingBox.Location = new System.Drawing.Point(159, 272);
            this.CoachTrainingBox.Name = "CoachTrainingBox";
            this.CoachTrainingBox.Size = new System.Drawing.Size(50, 20);
            this.CoachTrainingBox.TabIndex = 202;
            this.CoachTrainingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachTrainingBox.ValueChanged += new System.EventHandler(this.CoachTrainingBox_ValueChanged);
            // 
            // CoachCOTABox
            // 
            this.CoachCOTABox.Location = new System.Drawing.Point(112, 458);
            this.CoachCOTABox.Name = "CoachCOTABox";
            this.CoachCOTABox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTABox.TabIndex = 213;
            this.CoachCOTABox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTABox.ValueChanged += new System.EventHandler(this.CoachCOTABox_ValueChanged);
            // 
            // CoachRecruitingBox
            // 
            this.CoachRecruitingBox.Location = new System.Drawing.Point(228, 273);
            this.CoachRecruitingBox.Name = "CoachRecruitingBox";
            this.CoachRecruitingBox.Size = new System.Drawing.Size(50, 20);
            this.CoachRecruitingBox.TabIndex = 203;
            this.CoachRecruitingBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachRecruitingBox.ValueChanged += new System.EventHandler(this.CoachRecruitingBox_ValueChanged);
            // 
            // CoachCOTRBox
            // 
            this.CoachCOTRBox.Location = new System.Drawing.Point(112, 419);
            this.CoachCOTRBox.Name = "CoachCOTRBox";
            this.CoachCOTRBox.Size = new System.Drawing.Size(50, 20);
            this.CoachCOTRBox.TabIndex = 212;
            this.CoachCOTRBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CoachCOTRBox.ValueChanged += new System.EventHandler(this.CoachCOTRBox_ValueChanged);
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Location = new System.Drawing.Point(24, 460);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(81, 13);
            this.label136.TabIndex = 211;
            this.label136.Text = "Aggressiveness";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Location = new System.Drawing.Point(43, 421);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(63, 13);
            this.label137.TabIndex = 210;
            this.label137.Text = "Passing Pct";
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(152, 307);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(59, 13);
            this.label138.TabIndex = 209;
            this.label138.Text = "Playbook";
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Location = new System.Drawing.Point(226, 358);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(74, 13);
            this.label140.TabIndex = 207;
            this.label140.Text = "Base Defense";
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Location = new System.Drawing.Point(30, 358);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(71, 13);
            this.label139.TabIndex = 208;
            this.label139.Text = "Offense Type";
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
            this.CoachFilter.Size = new System.Drawing.Size(213, 21);
            this.CoachFilter.TabIndex = 226;
            this.CoachFilter.SelectedIndexChanged += new System.EventHandler(this.CoachFilter_SelectedIndexChanged);
            // 
            // CoachListBox
            // 
            this.CoachListBox.BackColor = System.Drawing.Color.White;
            this.CoachListBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CoachListBox.FormattingEnabled = true;
            this.CoachListBox.Location = new System.Drawing.Point(12, 52);
            this.CoachListBox.Name = "CoachListBox";
            this.CoachListBox.Size = new System.Drawing.Size(213, 537);
            this.CoachListBox.TabIndex = 103;
            this.CoachListBox.SelectedIndexChanged += new System.EventHandler(this.CoachListBox_SelectedIndexChanged);
            // 
            // tabPlayers
            // 
            this.tabPlayers.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPlayers.Controls.Add(this.label206);
            this.tabPlayers.Controls.Add(this.PDIS);
            this.tabPlayers.Controls.Add(this.label153);
            this.tabPlayers.Controls.Add(this.PHometownBox);
            this.tabPlayers.Controls.Add(this.label203);
            this.tabPlayers.Controls.Add(this.PStateBox);
            this.tabPlayers.Controls.Add(this.ResetPlayerPOSbutton);
            this.tabPlayers.Controls.Add(this.groupBox6);
            this.tabPlayers.Controls.Add(this.ImportPlayerTeam);
            this.tabPlayers.Controls.Add(this.AWHRBox);
            this.tabPlayers.Controls.Add(this.PlayerTransferButton);
            this.tabPlayers.Controls.Add(this.ExportPlayerTeam);
            this.tabPlayers.Controls.Add(this.label167);
            this.tabPlayers.Controls.Add(this.playerTeamBox);
            this.tabPlayers.Controls.Add(this.PRST);
            this.tabPlayers.Controls.Add(this.PGIDbox);
            this.tabPlayers.Controls.Add(this.POVRbox);
            this.tabPlayers.Controls.Add(this.PLNAtextBox);
            this.tabPlayers.Controls.Add(this.PFNAtextBox);
            this.tabPlayers.Controls.Add(this.PPOSBox);
            this.tabPlayers.Controls.Add(this.label62);
            this.tabPlayers.Controls.Add(this.label151);
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
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(386, 53);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(52, 13);
            this.label206.TabIndex = 160;
            this.label206.Text = "Discipline";
            // 
            // PDIS
            // 
            this.PDIS.Location = new System.Drawing.Point(389, 69);
            this.PDIS.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PDIS.Name = "PDIS";
            this.PDIS.Size = new System.Drawing.Size(57, 20);
            this.PDIS.TabIndex = 149;
            this.PDIS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PDIS.ValueChanged += new System.EventHandler(this.PDIS_ValueChanged);
            // 
            // label153
            // 
            this.label153.AutoSize = true;
            this.label153.Location = new System.Drawing.Point(272, 53);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(58, 13);
            this.label153.TabIndex = 159;
            this.label153.Text = "Hometown";
            // 
            // PHometownBox
            // 
            this.PHometownBox.FormattingEnabled = true;
            this.PHometownBox.Location = new System.Drawing.Point(270, 69);
            this.PHometownBox.Name = "PHometownBox";
            this.PHometownBox.Size = new System.Drawing.Size(116, 21);
            this.PHometownBox.TabIndex = 158;
            this.PHometownBox.SelectedIndexChanged += new System.EventHandler(this.PHometownBox_SelectedIndexChanged);
            // 
            // label203
            // 
            this.label203.AutoSize = true;
            this.label203.Location = new System.Drawing.Point(208, 53);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(32, 13);
            this.label203.TabIndex = 157;
            this.label203.Text = "State";
            // 
            // PStateBox
            // 
            this.PStateBox.FormattingEnabled = true;
            this.PStateBox.Location = new System.Drawing.Point(211, 69);
            this.PStateBox.Name = "PStateBox";
            this.PStateBox.Size = new System.Drawing.Size(53, 21);
            this.PStateBox.TabIndex = 156;
            this.PStateBox.SelectedIndexChanged += new System.EventHandler(this.PStateBox_SelectedIndexChanged);
            // 
            // ResetPlayerPOSbutton
            // 
            this.ResetPlayerPOSbutton.Location = new System.Drawing.Point(455, 69);
            this.ResetPlayerPOSbutton.Name = "ResetPlayerPOSbutton";
            this.ResetPlayerPOSbutton.Size = new System.Drawing.Size(101, 23);
            this.ResetPlayerPOSbutton.TabIndex = 151;
            this.ResetPlayerPOSbutton.Text = "Reset Position";
            this.ResetPlayerPOSbutton.UseVisualStyleBackColor = true;
            this.ResetPlayerPOSbutton.Click += new System.EventHandler(this.ResetPlayerPOSbutton_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.PTEN);
            this.groupBox6.Controls.Add(this.label173);
            this.groupBox6.Controls.Add(this.PTHAtext);
            this.groupBox6.Controls.Add(this.PIMPBox);
            this.groupBox6.Controls.Add(this.label63);
            this.groupBox6.Controls.Add(this.PINJBox);
            this.groupBox6.Controls.Add(this.label64);
            this.groupBox6.Controls.Add(this.PKACtext);
            this.groupBox6.Controls.Add(this.PSPDBox);
            this.groupBox6.Controls.Add(this.PKPRtext);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.PTAKtext);
            this.groupBox6.Controls.Add(this.PACCBox);
            this.groupBox6.Controls.Add(this.PPBKtext);
            this.groupBox6.Controls.Add(this.label66);
            this.groupBox6.Controls.Add(this.PSTRBox);
            this.groupBox6.Controls.Add(this.PCARtext);
            this.groupBox6.Controls.Add(this.label70);
            this.groupBox6.Controls.Add(this.PCTHtext);
            this.groupBox6.Controls.Add(this.PBTKBox);
            this.groupBox6.Controls.Add(this.PJMPtext);
            this.groupBox6.Controls.Add(this.label69);
            this.groupBox6.Controls.Add(this.PTHPBox);
            this.groupBox6.Controls.Add(this.label68);
            this.groupBox6.Controls.Add(this.PAGItext);
            this.groupBox6.Controls.Add(this.PRBKBox);
            this.groupBox6.Controls.Add(this.PAWRtext);
            this.groupBox6.Controls.Add(this.label67);
            this.groupBox6.Controls.Add(this.PPOEtext);
            this.groupBox6.Controls.Add(this.PPOEBox);
            this.groupBox6.Controls.Add(this.PRBKtext);
            this.groupBox6.Controls.Add(this.label78);
            this.groupBox6.Controls.Add(this.PTHPtext);
            this.groupBox6.Controls.Add(this.PAWRBox);
            this.groupBox6.Controls.Add(this.PBTKtext);
            this.groupBox6.Controls.Add(this.label77);
            this.groupBox6.Controls.Add(this.PSTRtext);
            this.groupBox6.Controls.Add(this.PAGIBox);
            this.groupBox6.Controls.Add(this.PACCtext);
            this.groupBox6.Controls.Add(this.label76);
            this.groupBox6.Controls.Add(this.PSPDtext);
            this.groupBox6.Controls.Add(this.PJMPBox);
            this.groupBox6.Controls.Add(this.PINJtext);
            this.groupBox6.Controls.Add(this.label75);
            this.groupBox6.Controls.Add(this.PIMPtext);
            this.groupBox6.Controls.Add(this.PCTHBox);
            this.groupBox6.Controls.Add(this.label74);
            this.groupBox6.Controls.Add(this.PCARBox);
            this.groupBox6.Controls.Add(this.label73);
            this.groupBox6.Controls.Add(this.PTHABox);
            this.groupBox6.Controls.Add(this.label72);
            this.groupBox6.Controls.Add(this.PPBKBox);
            this.groupBox6.Controls.Add(this.label71);
            this.groupBox6.Controls.Add(this.PTAKBox);
            this.groupBox6.Controls.Add(this.label82);
            this.groupBox6.Controls.Add(this.PKPRBox);
            this.groupBox6.Controls.Add(this.label81);
            this.groupBox6.Controls.Add(this.PKACBox);
            this.groupBox6.Controls.Add(this.label79);
            this.groupBox6.Location = new System.Drawing.Point(203, 185);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(400, 374);
            this.groupBox6.TabIndex = 150;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Attributes";
            // 
            // PTEN
            // 
            this.PTEN.BackColor = System.Drawing.SystemColors.Info;
            this.PTEN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PTEN.Location = new System.Drawing.Point(277, 23);
            this.PTEN.Name = "PTEN";
            this.PTEN.ReadOnly = true;
            this.PTEN.Size = new System.Drawing.Size(102, 20);
            this.PTEN.TabIndex = 147;
            this.PTEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label173
            // 
            this.label173.AutoSize = true;
            this.label173.Location = new System.Drawing.Point(186, 26);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(87, 13);
            this.label173.TabIndex = 148;
            this.label173.Text = "Player Archetype";
            this.label173.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHAtext
            // 
            this.PTHAtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTHAtext.Location = new System.Drawing.Point(277, 203);
            this.PTHAtext.Name = "PTHAtext";
            this.PTHAtext.ReadOnly = true;
            this.PTHAtext.Size = new System.Drawing.Size(39, 20);
            this.PTHAtext.TabIndex = 56;
            this.PTHAtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PIMPBox
            // 
            this.PIMPBox.Location = new System.Drawing.Point(122, 22);
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
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(15, 24);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(60, 13);
            this.label63.TabIndex = 13;
            this.label63.Text = "Importance";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PINJBox
            // 
            this.PINJBox.Location = new System.Drawing.Point(122, 58);
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
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(12, 60);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(63, 13);
            this.label64.TabIndex = 16;
            this.label64.Text = "Injury Prone";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKACtext
            // 
            this.PKACtext.BackColor = System.Drawing.SystemColors.Info;
            this.PKACtext.Location = new System.Drawing.Point(277, 344);
            this.PKACtext.Name = "PKACtext";
            this.PKACtext.ReadOnly = true;
            this.PKACtext.Size = new System.Drawing.Size(39, 20);
            this.PKACtext.TabIndex = 71;
            this.PKACtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PSPDBox
            // 
            this.PSPDBox.Location = new System.Drawing.Point(122, 95);
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
            // PKPRtext
            // 
            this.PKPRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PKPRtext.Location = new System.Drawing.Point(77, 345);
            this.PKPRtext.Name = "PKPRtext";
            this.PKPRtext.ReadOnly = true;
            this.PKPRtext.Size = new System.Drawing.Size(39, 20);
            this.PKPRtext.TabIndex = 65;
            this.PKPRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(37, 98);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(38, 13);
            this.label65.TabIndex = 19;
            this.label65.Text = "Speed";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTAKtext
            // 
            this.PTAKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTAKtext.Location = new System.Drawing.Point(276, 311);
            this.PTAKtext.Name = "PTAKtext";
            this.PTAKtext.ReadOnly = true;
            this.PTAKtext.Size = new System.Drawing.Size(39, 20);
            this.PTAKtext.TabIndex = 62;
            this.PTAKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PACCBox
            // 
            this.PACCBox.Location = new System.Drawing.Point(122, 130);
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
            // PPBKtext
            // 
            this.PPBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PPBKtext.Location = new System.Drawing.Point(277, 274);
            this.PPBKtext.Name = "PPBKtext";
            this.PPBKtext.ReadOnly = true;
            this.PPBKtext.Size = new System.Drawing.Size(39, 20);
            this.PPBKtext.TabIndex = 59;
            this.PPBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(9, 132);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(66, 13);
            this.label66.TabIndex = 22;
            this.label66.Text = "Acceleration";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PSTRBox
            // 
            this.PSTRBox.Location = new System.Drawing.Point(122, 167);
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
            // PCARtext
            // 
            this.PCARtext.BackColor = System.Drawing.SystemColors.Info;
            this.PCARtext.Location = new System.Drawing.Point(277, 238);
            this.PCARtext.Name = "PCARtext";
            this.PCARtext.ReadOnly = true;
            this.PCARtext.Size = new System.Drawing.Size(39, 20);
            this.PCARtext.TabIndex = 53;
            this.PCARtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(28, 169);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(47, 13);
            this.label70.TabIndex = 25;
            this.label70.Text = "Strength";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PCTHtext
            // 
            this.PCTHtext.BackColor = System.Drawing.SystemColors.Info;
            this.PCTHtext.Location = new System.Drawing.Point(76, 309);
            this.PCTHtext.Name = "PCTHtext";
            this.PCTHtext.ReadOnly = true;
            this.PCTHtext.Size = new System.Drawing.Size(39, 20);
            this.PCTHtext.TabIndex = 50;
            this.PCTHtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PBTKBox
            // 
            this.PBTKBox.Location = new System.Drawing.Point(122, 239);
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
            // PJMPtext
            // 
            this.PJMPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PJMPtext.Location = new System.Drawing.Point(276, 165);
            this.PJMPtext.Name = "PJMPtext";
            this.PJMPtext.ReadOnly = true;
            this.PJMPtext.Size = new System.Drawing.Size(39, 20);
            this.PJMPtext.TabIndex = 47;
            this.PJMPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(5, 241);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(71, 13);
            this.label69.TabIndex = 28;
            this.label69.Text = "Break Tackle";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHPBox
            // 
            this.PTHPBox.Location = new System.Drawing.Point(122, 204);
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
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(5, 206);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(70, 13);
            this.label68.TabIndex = 31;
            this.label68.Text = "Throw Power";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PAGItext
            // 
            this.PAGItext.BackColor = System.Drawing.SystemColors.Info;
            this.PAGItext.Location = new System.Drawing.Point(276, 130);
            this.PAGItext.Name = "PAGItext";
            this.PAGItext.ReadOnly = true;
            this.PAGItext.Size = new System.Drawing.Size(39, 20);
            this.PAGItext.TabIndex = 44;
            this.PAGItext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PRBKBox
            // 
            this.PRBKBox.Location = new System.Drawing.Point(122, 275);
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
            // PAWRtext
            // 
            this.PAWRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PAWRtext.Location = new System.Drawing.Point(276, 93);
            this.PAWRtext.Name = "PAWRtext";
            this.PAWRtext.ReadOnly = true;
            this.PAWRtext.Size = new System.Drawing.Size(39, 20);
            this.PAWRtext.TabIndex = 41;
            this.PAWRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(5, 277);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(71, 13);
            this.label67.TabIndex = 34;
            this.label67.Text = "Run Blocking";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PPOEtext
            // 
            this.PPOEtext.BackColor = System.Drawing.SystemColors.Info;
            this.PPOEtext.Location = new System.Drawing.Point(276, 57);
            this.PPOEtext.Name = "PPOEtext";
            this.PPOEtext.ReadOnly = true;
            this.PPOEtext.Size = new System.Drawing.Size(39, 20);
            this.PPOEtext.TabIndex = 38;
            this.PPOEtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PPOEBox
            // 
            this.PPOEBox.Location = new System.Drawing.Point(321, 57);
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
            // PRBKtext
            // 
            this.PRBKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PRBKtext.Location = new System.Drawing.Point(77, 275);
            this.PRBKtext.Name = "PRBKtext";
            this.PRBKtext.ReadOnly = true;
            this.PRBKtext.Size = new System.Drawing.Size(39, 20);
            this.PRBKtext.TabIndex = 35;
            this.PRBKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(224, 62);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(48, 13);
            this.label78.TabIndex = 37;
            this.label78.Text = "Potential";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHPtext
            // 
            this.PTHPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PTHPtext.Location = new System.Drawing.Point(77, 204);
            this.PTHPtext.Name = "PTHPtext";
            this.PTHPtext.ReadOnly = true;
            this.PTHPtext.Size = new System.Drawing.Size(39, 20);
            this.PTHPtext.TabIndex = 32;
            this.PTHPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PAWRBox
            // 
            this.PAWRBox.Location = new System.Drawing.Point(321, 93);
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
            // PBTKtext
            // 
            this.PBTKtext.BackColor = System.Drawing.SystemColors.Info;
            this.PBTKtext.Location = new System.Drawing.Point(77, 239);
            this.PBTKtext.Name = "PBTKtext";
            this.PBTKtext.ReadOnly = true;
            this.PBTKtext.Size = new System.Drawing.Size(39, 20);
            this.PBTKtext.TabIndex = 29;
            this.PBTKtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(212, 97);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(59, 13);
            this.label77.TabIndex = 40;
            this.label77.Text = "Awareness";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PSTRtext
            // 
            this.PSTRtext.BackColor = System.Drawing.SystemColors.Info;
            this.PSTRtext.Location = new System.Drawing.Point(77, 167);
            this.PSTRtext.Name = "PSTRtext";
            this.PSTRtext.ReadOnly = true;
            this.PSTRtext.Size = new System.Drawing.Size(39, 20);
            this.PSTRtext.TabIndex = 26;
            this.PSTRtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PAGIBox
            // 
            this.PAGIBox.Location = new System.Drawing.Point(321, 130);
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
            // PACCtext
            // 
            this.PACCtext.BackColor = System.Drawing.SystemColors.Info;
            this.PACCtext.Location = new System.Drawing.Point(77, 130);
            this.PACCtext.Name = "PACCtext";
            this.PACCtext.ReadOnly = true;
            this.PACCtext.Size = new System.Drawing.Size(39, 20);
            this.PACCtext.TabIndex = 23;
            this.PACCtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(237, 135);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(34, 13);
            this.label76.TabIndex = 43;
            this.label76.Text = "Agility";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PSPDtext
            // 
            this.PSPDtext.BackColor = System.Drawing.SystemColors.Info;
            this.PSPDtext.Location = new System.Drawing.Point(77, 95);
            this.PSPDtext.Name = "PSPDtext";
            this.PSPDtext.ReadOnly = true;
            this.PSPDtext.Size = new System.Drawing.Size(39, 20);
            this.PSPDtext.TabIndex = 20;
            this.PSPDtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PJMPBox
            // 
            this.PJMPBox.Location = new System.Drawing.Point(321, 165);
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
            // PINJtext
            // 
            this.PINJtext.BackColor = System.Drawing.SystemColors.Info;
            this.PINJtext.Location = new System.Drawing.Point(77, 58);
            this.PINJtext.Name = "PINJtext";
            this.PINJtext.ReadOnly = true;
            this.PINJtext.Size = new System.Drawing.Size(39, 20);
            this.PINJtext.TabIndex = 17;
            this.PINJtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(225, 170);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(46, 13);
            this.label75.TabIndex = 46;
            this.label75.Text = "Jumping";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PIMPtext
            // 
            this.PIMPtext.BackColor = System.Drawing.SystemColors.Info;
            this.PIMPtext.Location = new System.Drawing.Point(77, 22);
            this.PIMPtext.Name = "PIMPtext";
            this.PIMPtext.ReadOnly = true;
            this.PIMPtext.Size = new System.Drawing.Size(39, 20);
            this.PIMPtext.TabIndex = 14;
            this.PIMPtext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PCTHBox
            // 
            this.PCTHBox.Location = new System.Drawing.Point(121, 309);
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
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(22, 311);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(49, 13);
            this.label74.TabIndex = 49;
            this.label74.Text = "Catching";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PCARBox
            // 
            this.PCARBox.Location = new System.Drawing.Point(322, 238);
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
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(207, 243);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(65, 13);
            this.label73.TabIndex = 52;
            this.label73.Text = "Ball Carrying";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTHABox
            // 
            this.PTHABox.Location = new System.Drawing.Point(322, 203);
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
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(192, 208);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(85, 13);
            this.label72.TabIndex = 55;
            this.label72.Text = "Throw Accuracy";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PPBKBox
            // 
            this.PPBKBox.Location = new System.Drawing.Point(322, 274);
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
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(202, 278);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(74, 13);
            this.label71.TabIndex = 58;
            this.label71.Text = "Pass Blocking";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PTAKBox
            // 
            this.PTAKBox.Location = new System.Drawing.Point(321, 311);
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
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(226, 311);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(48, 13);
            this.label82.TabIndex = 61;
            this.label82.Text = "Tackling";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKPRBox
            // 
            this.PKPRBox.Location = new System.Drawing.Point(122, 345);
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
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(14, 348);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(61, 13);
            this.label81.TabIndex = 64;
            this.label81.Text = "Kick Power";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PKACBox
            // 
            this.PKACBox.Location = new System.Drawing.Point(322, 344);
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
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(197, 348);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(76, 13);
            this.label79.TabIndex = 70;
            this.label79.Text = "Kick Accuracy";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ImportPlayerTeam
            // 
            this.ImportPlayerTeam.Location = new System.Drawing.Point(989, 3);
            this.ImportPlayerTeam.Name = "ImportPlayerTeam";
            this.ImportPlayerTeam.Size = new System.Drawing.Size(75, 23);
            this.ImportPlayerTeam.TabIndex = 145;
            this.ImportPlayerTeam.Text = "Import Team";
            this.ImportPlayerTeam.UseVisualStyleBackColor = true;
            this.ImportPlayerTeam.Visible = false;
            this.ImportPlayerTeam.Click += new System.EventHandler(this.ImportPlayerTeam_Click);
            // 
            // AWHRBox
            // 
            this.AWHRBox.AutoSize = true;
            this.AWHRBox.Location = new System.Drawing.Point(455, 49);
            this.AWHRBox.Name = "AWHRBox";
            this.AWHRBox.Size = new System.Drawing.Size(148, 17);
            this.AWHRBox.TabIndex = 149;
            this.AWHRBox.Text = "Position Change AWR Hit";
            this.AWHRBox.UseVisualStyleBackColor = true;
            // 
            // PlayerTransferButton
            // 
            this.PlayerTransferButton.Location = new System.Drawing.Point(499, 573);
            this.PlayerTransferButton.Name = "PlayerTransferButton";
            this.PlayerTransferButton.Size = new System.Drawing.Size(91, 34);
            this.PlayerTransferButton.TabIndex = 146;
            this.PlayerTransferButton.Text = "Send to Transfer Portal";
            this.PlayerTransferButton.UseVisualStyleBackColor = true;
            this.PlayerTransferButton.Click += new System.EventHandler(this.PlayerTransferButton_Click);
            // 
            // ExportPlayerTeam
            // 
            this.ExportPlayerTeam.Location = new System.Drawing.Point(1074, 3);
            this.ExportPlayerTeam.Name = "ExportPlayerTeam";
            this.ExportPlayerTeam.Size = new System.Drawing.Size(75, 23);
            this.ExportPlayerTeam.TabIndex = 144;
            this.ExportPlayerTeam.Text = "Export Team";
            this.ExportPlayerTeam.UseVisualStyleBackColor = true;
            this.ExportPlayerTeam.Visible = false;
            this.ExportPlayerTeam.Click += new System.EventHandler(this.ExportPlayerTeam_Click);
            // 
            // label167
            // 
            this.label167.AutoSize = true;
            this.label167.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label167.Location = new System.Drawing.Point(10, 7);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(47, 16);
            this.label167.TabIndex = 143;
            this.label167.Text = "Team";
            this.label167.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playerTeamBox
            // 
            this.playerTeamBox.BackColor = System.Drawing.SystemColors.Info;
            this.playerTeamBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTeamBox.Location = new System.Drawing.Point(9, 26);
            this.playerTeamBox.Name = "playerTeamBox";
            this.playerTeamBox.ReadOnly = true;
            this.playerTeamBox.Size = new System.Drawing.Size(118, 22);
            this.playerTeamBox.TabIndex = 142;
            this.playerTeamBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PRST
            // 
            this.PRST.BackColor = System.Drawing.SystemColors.Info;
            this.PRST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRST.Location = new System.Drawing.Point(584, 25);
            this.PRST.Name = "PRST";
            this.PRST.ReadOnly = true;
            this.PRST.Size = new System.Drawing.Size(82, 22);
            this.PRST.TabIndex = 139;
            this.PRST.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PGIDbox
            // 
            this.PGIDbox.BackColor = System.Drawing.SystemColors.Info;
            this.PGIDbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGIDbox.Location = new System.Drawing.Point(133, 25);
            this.PGIDbox.Name = "PGIDbox";
            this.PGIDbox.ReadOnly = true;
            this.PGIDbox.Size = new System.Drawing.Size(53, 22);
            this.PGIDbox.TabIndex = 97;
            this.PGIDbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // POVRbox
            // 
            this.POVRbox.BackColor = System.Drawing.SystemColors.Info;
            this.POVRbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.POVRbox.Location = new System.Drawing.Point(522, 25);
            this.POVRbox.Name = "POVRbox";
            this.POVRbox.ReadOnly = true;
            this.POVRbox.Size = new System.Drawing.Size(53, 22);
            this.POVRbox.TabIndex = 8;
            this.POVRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PLNAtextBox
            // 
            this.PLNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PLNAtextBox.Location = new System.Drawing.Point(325, 25);
            this.PLNAtextBox.Name = "PLNAtextBox";
            this.PLNAtextBox.Size = new System.Drawing.Size(111, 22);
            this.PLNAtextBox.TabIndex = 1;
            this.PLNAtextBox.TextChanged += new System.EventHandler(this.PLNAtextBox_TextChanged);
            this.PLNAtextBox.Leave += new System.EventHandler(this.PLNA_Leave);
            // 
            // PFNAtextBox
            // 
            this.PFNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PFNAtextBox.Location = new System.Drawing.Point(203, 25);
            this.PFNAtextBox.Name = "PFNAtextBox";
            this.PFNAtextBox.Size = new System.Drawing.Size(116, 22);
            this.PFNAtextBox.TabIndex = 0;
            this.PFNAtextBox.TextChanged += new System.EventHandler(this.PFNAtextBox_TextChanged);
            this.PFNAtextBox.Leave += new System.EventHandler(this.PFNA_Leave);
            // 
            // PPOSBox
            // 
            this.PPOSBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPOSBox.FormattingEnabled = true;
            this.PPOSBox.Location = new System.Drawing.Point(442, 23);
            this.PPOSBox.Name = "PPOSBox";
            this.PPOSBox.Size = new System.Drawing.Size(71, 24);
            this.PPOSBox.TabIndex = 10;
            this.PPOSBox.SelectedIndexChanged += new System.EventHandler(this.PPOSBox_SelectedIndexChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.Location = new System.Drawing.Point(439, 7);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(63, 16);
            this.label62.TabIndex = 11;
            this.label62.Text = "Position";
            // 
            // label151
            // 
            this.label151.AutoSize = true;
            this.label151.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label151.Location = new System.Drawing.Point(584, 7);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(86, 13);
            this.label151.TabIndex = 140;
            this.label151.Text = "Pride Stickers";
            // 
            // label113
            // 
            this.label113.AutoSize = true;
            this.label113.Location = new System.Drawing.Point(389, 99);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(37, 13);
            this.label113.TabIndex = 101;
            this.label113.Text = "Jersey";
            this.label113.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PJEN
            // 
            this.PJEN.Location = new System.Drawing.Point(389, 114);
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
            this.PlayerSetDepthChartButton.Size = new System.Drawing.Size(133, 36);
            this.PlayerSetDepthChartButton.TabIndex = 99;
            this.PlayerSetDepthChartButton.Text = "Auto-Set Team Depth Chart";
            this.PlayerSetDepthChartButton.UseVisualStyleBackColor = true;
            this.PlayerSetDepthChartButton.Click += new System.EventHandler(this.PlayerSetDepthChartButton_Click);
            // 
            // PGIDLabel
            // 
            this.PGIDLabel.AutoSize = true;
            this.PGIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PGIDLabel.Location = new System.Drawing.Point(133, 7);
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
            this.label93.Location = new System.Drawing.Point(350, 570);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(87, 13);
            this.label93.TabIndex = 93;
            this.label93.Text = "Off-Season Type";
            // 
            // PTYPBox
            // 
            this.PTYPBox.DropDownWidth = 150;
            this.PTYPBox.FormattingEnabled = true;
            this.PTYPBox.Location = new System.Drawing.Point(351, 585);
            this.PTYPBox.Name = "PTYPBox";
            this.PTYPBox.Size = new System.Drawing.Size(133, 21);
            this.PTYPBox.TabIndex = 92;
            this.PTYPBox.SelectedIndexChanged += new System.EventHandler(this.PTYPBox_SelectedIndexChanged);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(293, 98);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(46, 13);
            this.label92.TabIndex = 91;
            this.label92.Text = "Redshirt";
            // 
            // PRSDBox
            // 
            this.PRSDBox.FormattingEnabled = true;
            this.PRSDBox.Location = new System.Drawing.Point(296, 114);
            this.PRSDBox.Name = "PRSDBox";
            this.PRSDBox.Size = new System.Drawing.Size(79, 21);
            this.PRSDBox.TabIndex = 90;
            this.PRSDBox.SelectedIndexChanged += new System.EventHandler(this.PRSDBox_SelectedIndexChanged);
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(210, 99);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(29, 13);
            this.label91.TabIndex = 89;
            this.label91.Text = "Year";
            // 
            // PYERBox
            // 
            this.PYERBox.FormattingEnabled = true;
            this.PYERBox.Location = new System.Drawing.Point(211, 114);
            this.PYERBox.Name = "PYERBox";
            this.PYERBox.Size = new System.Drawing.Size(79, 21);
            this.PYERBox.TabIndex = 88;
            this.PYERBox.SelectedIndexChanged += new System.EventHandler(this.PYERBox_SelectedIndexChanged);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(519, 99);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(63, 13);
            this.label89.TabIndex = 87;
            this.label89.Text = "Weight (lbs)";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PWGTBox
            // 
            this.PWGTBox.Location = new System.Drawing.Point(518, 114);
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
            this.label90.Location = new System.Drawing.Point(452, 99);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(55, 13);
            this.label90.TabIndex = 84;
            this.label90.Text = "Height (in)";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PHGTBox
            // 
            this.PHGTBox.Location = new System.Drawing.Point(455, 114);
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
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(489, 140);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(52, 13);
            this.label87.TabIndex = 81;
            this.label87.Text = "Hair Style";
            // 
            // PHEDBox
            // 
            this.PHEDBox.FormattingEnabled = true;
            this.PHEDBox.Location = new System.Drawing.Point(492, 156);
            this.PHEDBox.Name = "PHEDBox";
            this.PHEDBox.Size = new System.Drawing.Size(90, 21);
            this.PHEDBox.TabIndex = 80;
            this.PHEDBox.SelectedIndexChanged += new System.EventHandler(this.PHEDBox_SelectedIndexChanged);
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(389, 140);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(53, 13);
            this.label86.TabIndex = 79;
            this.label86.Text = "Hair Color";
            // 
            // PHCLBox
            // 
            this.PHCLBox.FormattingEnabled = true;
            this.PHCLBox.Location = new System.Drawing.Point(392, 156);
            this.PHCLBox.Name = "PHCLBox";
            this.PHCLBox.Size = new System.Drawing.Size(94, 21);
            this.PHCLBox.TabIndex = 78;
            this.PHCLBox.SelectedIndexChanged += new System.EventHandler(this.PHCLBox_SelectedIndexChanged);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(332, 139);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(31, 13);
            this.label85.TabIndex = 77;
            this.label85.Text = "Face";
            // 
            // PFMPBox
            // 
            this.PFMPBox.FormattingEnabled = true;
            this.PFMPBox.Location = new System.Drawing.Point(335, 156);
            this.PFMPBox.Name = "PFMPBox";
            this.PFMPBox.Size = new System.Drawing.Size(51, 21);
            this.PFMPBox.TabIndex = 76;
            this.PFMPBox.SelectedIndexChanged += new System.EventHandler(this.PFMPBox_SelectedIndexChanged);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(281, 139);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(38, 13);
            this.label84.TabIndex = 75;
            this.label84.Text = "Shape";
            // 
            // PFGMBox
            // 
            this.PFGMBox.FormattingEnabled = true;
            this.PFGMBox.Location = new System.Drawing.Point(284, 156);
            this.PFGMBox.Name = "PFGMBox";
            this.PFGMBox.Size = new System.Drawing.Size(45, 21);
            this.PFGMBox.TabIndex = 74;
            this.PFGMBox.SelectedIndexChanged += new System.EventHandler(this.PFGMBox_SelectedIndexChanged);
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(212, 139);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(56, 13);
            this.label83.TabIndex = 73;
            this.label83.Text = "Skin Tone";
            // 
            // PSKIBox
            // 
            this.PSKIBox.FormattingEnabled = true;
            this.PSKIBox.Location = new System.Drawing.Point(211, 156);
            this.PSKIBox.Name = "PSKIBox";
            this.PSKIBox.Size = new System.Drawing.Size(67, 21);
            this.PSKIBox.TabIndex = 72;
            this.PSKIBox.SelectedIndexChanged += new System.EventHandler(this.PSKIBox_SelectedIndexChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.Location = new System.Drawing.Point(519, 7);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(57, 16);
            this.label61.TabIndex = 9;
            this.label61.Text = "Overall";
            // 
            // RosterSizeLabel
            // 
            this.RosterSizeLabel.AutoSize = true;
            this.RosterSizeLabel.Location = new System.Drawing.Point(85, 60);
            this.RosterSizeLabel.Name = "RosterSizeLabel";
            this.RosterSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.RosterSizeLabel.TabIndex = 7;
            this.RosterSizeLabel.Text = "Roster Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Team";
            // 
            // TGIDplayerBox
            // 
            this.TGIDplayerBox.FormattingEnabled = true;
            this.TGIDplayerBox.Location = new System.Drawing.Point(9, 75);
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
            this.PGIDlistBox.Location = new System.Drawing.Point(9, 100);
            this.PGIDlistBox.Name = "PGIDlistBox";
            this.PGIDlistBox.Size = new System.Drawing.Size(175, 459);
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
            this.groupBox3.Controls.Add(this.LeftWrist);
            this.groupBox3.Controls.Add(this.LeftHand);
            this.groupBox3.Controls.Add(this.label117);
            this.groupBox3.Controls.Add(this.label118);
            this.groupBox3.Controls.Add(this.LeftElbow);
            this.groupBox3.Controls.Add(this.RightShoe);
            this.groupBox3.Controls.Add(this.label126);
            this.groupBox3.Controls.Add(this.LeftShoe);
            this.groupBox3.Controls.Add(this.label116);
            this.groupBox3.Controls.Add(this.NasalStrip);
            this.groupBox3.Controls.Add(this.label150);
            this.groupBox3.Controls.Add(this.label123);
            this.groupBox3.Controls.Add(this.Helmet);
            this.groupBox3.Controls.Add(this.label149);
            this.groupBox3.Controls.Add(this.Sleeves);
            this.groupBox3.Controls.Add(this.label148);
            this.groupBox3.Controls.Add(this.Facemask);
            this.groupBox3.Controls.Add(this.label127);
            this.groupBox3.Controls.Add(this.label119);
            this.groupBox3.Controls.Add(this.RightElbow);
            this.groupBox3.Controls.Add(this.label121);
            this.groupBox3.Controls.Add(this.label128);
            this.groupBox3.Controls.Add(this.SleeveColor);
            this.groupBox3.Controls.Add(this.RightWrist);
            this.groupBox3.Controls.Add(this.EyeBlack);
            this.groupBox3.Controls.Add(this.label147);
            this.groupBox3.Controls.Add(this.label122);
            this.groupBox3.Controls.Add(this.RightHand);
            this.groupBox3.Controls.Add(this.Visor);
            this.groupBox3.Controls.Add(this.label125);
            this.groupBox3.Controls.Add(this.label124);
            this.groupBox3.Controls.Add(this.NeckPad);
            this.groupBox3.Controls.Add(this.pictureBox2);
            this.groupBox3.Location = new System.Drawing.Point(672, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 583);
            this.groupBox3.TabIndex = 141;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gear Editor";
            // 
            // label120
            // 
            this.label120.AutoSize = true;
            this.label120.Location = new System.Drawing.Point(41, 259);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(41, 13);
            this.label120.TabIndex = 112;
            this.label120.Text = "Elbows";
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
            this.LeftWrist.Location = new System.Drawing.Point(44, 321);
            this.LeftWrist.Name = "LeftWrist";
            this.LeftWrist.Size = new System.Drawing.Size(103, 21);
            this.LeftWrist.TabIndex = 107;
            this.LeftWrist.SelectedIndexChanged += new System.EventHandler(this.LeftWrist_SelectedIndexChanged);
            // 
            // LeftHand
            // 
            this.LeftHand.FormattingEnabled = true;
            this.LeftHand.Items.AddRange(new object[] {
            "Bare",
            "Taped",
            "Gloves"});
            this.LeftHand.Location = new System.Drawing.Point(44, 362);
            this.LeftHand.Name = "LeftHand";
            this.LeftHand.Size = new System.Drawing.Size(103, 21);
            this.LeftHand.TabIndex = 105;
            this.LeftHand.SelectedIndexChanged += new System.EventHandler(this.LeftHand_SelectedIndexChanged);
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(40, 346);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(38, 13);
            this.label117.TabIndex = 106;
            this.label117.Text = "Hands";
            // 
            // label118
            // 
            this.label118.AutoSize = true;
            this.label118.Location = new System.Drawing.Point(40, 305);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(36, 13);
            this.label118.TabIndex = 108;
            this.label118.Text = "Wrists";
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
            this.LeftElbow.Location = new System.Drawing.Point(44, 276);
            this.LeftElbow.Name = "LeftElbow";
            this.LeftElbow.Size = new System.Drawing.Size(103, 21);
            this.LeftElbow.TabIndex = 111;
            this.LeftElbow.SelectedIndexChanged += new System.EventHandler(this.LeftElbow_SelectedIndexChanged);
            // 
            // RightShoe
            // 
            this.RightShoe.FormattingEnabled = true;
            this.RightShoe.Items.AddRange(new object[] {
            "Normal",
            "White Tape",
            "Black Tape",
            "TC Tape"});
            this.RightShoe.Location = new System.Drawing.Point(330, 527);
            this.RightShoe.Name = "RightShoe";
            this.RightShoe.Size = new System.Drawing.Size(103, 21);
            this.RightShoe.TabIndex = 137;
            this.RightShoe.SelectedIndexChanged += new System.EventHandler(this.RightShoe_SelectedIndexChanged);
            // 
            // label126
            // 
            this.label126.AutoSize = true;
            this.label126.Location = new System.Drawing.Point(330, 511);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(37, 13);
            this.label126.TabIndex = 138;
            this.label126.Text = "Shoes";
            // 
            // LeftShoe
            // 
            this.LeftShoe.FormattingEnabled = true;
            this.LeftShoe.Items.AddRange(new object[] {
            "Normal",
            "White Tape",
            "Black Tape",
            "TC Tape"});
            this.LeftShoe.Location = new System.Drawing.Point(87, 527);
            this.LeftShoe.Name = "LeftShoe";
            this.LeftShoe.Size = new System.Drawing.Size(103, 21);
            this.LeftShoe.TabIndex = 103;
            this.LeftShoe.SelectedIndexChanged += new System.EventHandler(this.LeftShoe_SelectedIndexChanged);
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(87, 511);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(37, 13);
            this.label116.TabIndex = 104;
            this.label116.Text = "Shoes";
            // 
            // NasalStrip
            // 
            this.NasalStrip.FormattingEnabled = true;
            this.NasalStrip.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.NasalStrip.Location = new System.Drawing.Point(288, 108);
            this.NasalStrip.Name = "NasalStrip";
            this.NasalStrip.Size = new System.Drawing.Size(103, 21);
            this.NasalStrip.TabIndex = 120;
            this.NasalStrip.SelectedIndexChanged += new System.EventHandler(this.NasalStrip_SelectedIndexChanged);
            // 
            // label150
            // 
            this.label150.AutoSize = true;
            this.label150.Location = new System.Drawing.Point(84, 35);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(40, 13);
            this.label150.TabIndex = 136;
            this.label150.Text = "Helmet";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(285, 93);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(58, 13);
            this.label123.TabIndex = 121;
            this.label123.Text = "Nasal Strip";
            // 
            // Helmet
            // 
            this.Helmet.FormattingEnabled = true;
            this.Helmet.Items.AddRange(new object[] {
            "Normal",
            "Adams",
            "Schutt",
            "Revolution"});
            this.Helmet.Location = new System.Drawing.Point(87, 50);
            this.Helmet.Name = "Helmet";
            this.Helmet.Size = new System.Drawing.Size(103, 21);
            this.Helmet.TabIndex = 135;
            this.Helmet.SelectedIndexChanged += new System.EventHandler(this.Helmet_SelectedIndexChanged);
            // 
            // label149
            // 
            this.label149.AutoSize = true;
            this.label149.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label149.Location = new System.Drawing.Point(50, 212);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(85, 15);
            this.label149.TabIndex = 134;
            this.label149.Text = "RIGHT SIDE";
            // 
            // Sleeves
            // 
            this.Sleeves.FormattingEnabled = true;
            this.Sleeves.Items.AddRange(new object[] {
            "Cold Only",
            "Always",
            "None"});
            this.Sleeves.Location = new System.Drawing.Point(53, 156);
            this.Sleeves.Name = "Sleeves";
            this.Sleeves.Size = new System.Drawing.Size(103, 21);
            this.Sleeves.TabIndex = 113;
            this.Sleeves.SelectedIndexChanged += new System.EventHandler(this.Sleeves_SelectedIndexChanged);
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label148.Location = new System.Drawing.Point(357, 212);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(76, 15);
            this.label148.TabIndex = 133;
            this.label148.Text = "LEFT SIDE";
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
            this.Facemask.Location = new System.Drawing.Point(210, 49);
            this.Facemask.Name = "Facemask";
            this.Facemask.Size = new System.Drawing.Size(103, 21);
            this.Facemask.TabIndex = 109;
            this.Facemask.SelectedIndexChanged += new System.EventHandler(this.Facemask_SelectedIndexChanged);
            // 
            // label127
            // 
            this.label127.AutoSize = true;
            this.label127.Location = new System.Drawing.Point(347, 261);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(41, 13);
            this.label127.TabIndex = 129;
            this.label127.Text = "Elbows";
            // 
            // label119
            // 
            this.label119.AutoSize = true;
            this.label119.Location = new System.Drawing.Point(207, 34);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(60, 13);
            this.label119.TabIndex = 110;
            this.label119.Text = "Face Mask";
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
            this.RightElbow.Location = new System.Drawing.Point(350, 276);
            this.RightElbow.Name = "RightElbow";
            this.RightElbow.Size = new System.Drawing.Size(103, 21);
            this.RightElbow.TabIndex = 128;
            this.RightElbow.SelectedIndexChanged += new System.EventHandler(this.RightElbow_SelectedIndexChanged);
            // 
            // label121
            // 
            this.label121.AutoSize = true;
            this.label121.Location = new System.Drawing.Point(50, 141);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(80, 13);
            this.label121.TabIndex = 114;
            this.label121.Text = "Sleeves / Color";
            // 
            // label128
            // 
            this.label128.AutoSize = true;
            this.label128.Location = new System.Drawing.Point(350, 305);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(36, 13);
            this.label128.TabIndex = 127;
            this.label128.Text = "Wrists";
            // 
            // SleeveColor
            // 
            this.SleeveColor.FormattingEnabled = true;
            this.SleeveColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Team Color"});
            this.SleeveColor.Location = new System.Drawing.Point(53, 181);
            this.SleeveColor.Name = "SleeveColor";
            this.SleeveColor.Size = new System.Drawing.Size(103, 21);
            this.SleeveColor.TabIndex = 115;
            this.SleeveColor.SelectedIndexChanged += new System.EventHandler(this.SleeveColor_SelectedIndexChanged);
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
            this.RightWrist.Location = new System.Drawing.Point(350, 321);
            this.RightWrist.Name = "RightWrist";
            this.RightWrist.Size = new System.Drawing.Size(103, 21);
            this.RightWrist.TabIndex = 126;
            this.RightWrist.SelectedIndexChanged += new System.EventHandler(this.RightWrist_SelectedIndexChanged);
            // 
            // EyeBlack
            // 
            this.EyeBlack.FormattingEnabled = true;
            this.EyeBlack.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.EyeBlack.Location = new System.Drawing.Point(81, 108);
            this.EyeBlack.Name = "EyeBlack";
            this.EyeBlack.Size = new System.Drawing.Size(103, 21);
            this.EyeBlack.TabIndex = 116;
            this.EyeBlack.SelectedIndexChanged += new System.EventHandler(this.EyeBlack_SelectedIndexChanged);
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.Location = new System.Drawing.Point(350, 346);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(38, 13);
            this.label147.TabIndex = 125;
            this.label147.Text = "Hands";
            // 
            // label122
            // 
            this.label122.AutoSize = true;
            this.label122.Location = new System.Drawing.Point(78, 93);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(55, 13);
            this.label122.TabIndex = 117;
            this.label122.Text = "Eye Black";
            // 
            // RightHand
            // 
            this.RightHand.FormattingEnabled = true;
            this.RightHand.Items.AddRange(new object[] {
            "Bare",
            "Taped",
            "Gloves"});
            this.RightHand.Location = new System.Drawing.Point(350, 362);
            this.RightHand.Name = "RightHand";
            this.RightHand.Size = new System.Drawing.Size(103, 21);
            this.RightHand.TabIndex = 124;
            this.RightHand.SelectedIndexChanged += new System.EventHandler(this.RightHand_SelectedIndexChanged);
            // 
            // Visor
            // 
            this.Visor.FormattingEnabled = true;
            this.Visor.Items.AddRange(new object[] {
            "None",
            "Clear",
            "Dark",
            "Orange"});
            this.Visor.Location = new System.Drawing.Point(330, 49);
            this.Visor.Name = "Visor";
            this.Visor.Size = new System.Drawing.Size(103, 21);
            this.Visor.TabIndex = 118;
            this.Visor.SelectedIndexChanged += new System.EventHandler(this.Visor_SelectedIndexChanged);
            // 
            // label125
            // 
            this.label125.AutoSize = true;
            this.label125.Location = new System.Drawing.Point(347, 141);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(55, 13);
            this.label125.TabIndex = 123;
            this.label125.Text = "Neck Pad";
            // 
            // label124
            // 
            this.label124.AutoSize = true;
            this.label124.Location = new System.Drawing.Point(327, 34);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(30, 13);
            this.label124.TabIndex = 119;
            this.label124.Text = "Visor";
            // 
            // NeckPad
            // 
            this.NeckPad.FormattingEnabled = true;
            this.NeckPad.Items.AddRange(new object[] {
            "None",
            "Neck Roll",
            "Extended"});
            this.NeckPad.Location = new System.Drawing.Point(350, 156);
            this.NeckPad.Name = "NeckPad";
            this.NeckPad.Size = new System.Drawing.Size(103, 21);
            this.NeckPad.TabIndex = 122;
            this.NeckPad.SelectedIndexChanged += new System.EventHandler(this.NeckPad_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(131, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(251, 472);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 102;
            this.pictureBox2.TabStop = false;
            // 
            // tabTeams
            // 
            this.tabTeams.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabTeams.Controls.Add(this.groupBox34);
            this.tabTeams.Controls.Add(this.groupBox15);
            this.tabTeams.Controls.Add(this.groupBox14);
            this.tabTeams.Controls.Add(this.groupBox13);
            this.tabTeams.Controls.Add(this.groupBox12);
            this.tabTeams.Controls.Add(this.groupBox11);
            this.tabTeams.Controls.Add(this.TeamSetDepthChart);
            this.tabTeams.Controls.Add(this.LeagueBox);
            this.tabTeams.Controls.Add(this.TSNAtextBox);
            this.tabTeams.Controls.Add(this.TeamDivisionBox);
            this.tabTeams.Controls.Add(this.TeamConferenceBox);
            this.tabTeams.Controls.Add(this.TGIDtextBox);
            this.tabTeams.Controls.Add(this.TMNAtextBox);
            this.tabTeams.Controls.Add(this.TDNAtextBox);
            this.tabTeams.Controls.Add(this.label27);
            this.tabTeams.Controls.Add(this.label26);
            this.tabTeams.Controls.Add(this.label25);
            this.tabTeams.Controls.Add(this.label24);
            this.tabTeams.Controls.Add(this.label11);
            this.tabTeams.Controls.Add(this.label10);
            this.tabTeams.Controls.Add(this.label9);
            this.tabTeams.Controls.Add(this.label7);
            this.tabTeams.Controls.Add(this.CGIDcomboBox);
            this.tabTeams.Controls.Add(this.label6);
            this.tabTeams.Controls.Add(this.LGIDcomboBox);
            this.tabTeams.Controls.Add(this.TGIDlistBox);
            this.tabTeams.Controls.Add(this.groupBox10);
            this.tabTeams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTeams.Location = new System.Drawing.Point(4, 24);
            this.tabTeams.Name = "tabTeams";
            this.tabTeams.Size = new System.Drawing.Size(1152, 615);
            this.tabTeams.TabIndex = 1;
            this.tabTeams.Text = "Teams";
            this.tabTeams.Click += new System.EventHandler(this.tabTeams_Click);
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.TeamShowNormal);
            this.groupBox34.Controls.Add(this.TeamShowRanking);
            this.groupBox34.Location = new System.Drawing.Point(12, 552);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(172, 49);
            this.groupBox34.TabIndex = 148;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Display Option";
            // 
            // TeamShowNormal
            // 
            this.TeamShowNormal.AutoSize = true;
            this.TeamShowNormal.Checked = true;
            this.TeamShowNormal.Location = new System.Drawing.Point(6, 19);
            this.TeamShowNormal.Name = "TeamShowNormal";
            this.TeamShowNormal.Size = new System.Drawing.Size(58, 17);
            this.TeamShowNormal.TabIndex = 1;
            this.TeamShowNormal.TabStop = true;
            this.TeamShowNormal.Text = "Normal";
            this.TeamShowNormal.UseVisualStyleBackColor = true;
            this.TeamShowNormal.CheckedChanged += new System.EventHandler(this.TeamShowNormal_CheckedChanged);
            // 
            // TeamShowRanking
            // 
            this.TeamShowRanking.AutoSize = true;
            this.TeamShowRanking.Location = new System.Drawing.Point(70, 19);
            this.TeamShowRanking.Name = "TeamShowRanking";
            this.TeamShowRanking.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.TeamShowRanking.Size = new System.Drawing.Size(95, 17);
            this.TeamShowRanking.TabIndex = 0;
            this.TeamShowRanking.Text = "Show Ranking";
            this.TeamShowRanking.UseVisualStyleBackColor = true;
            this.TeamShowRanking.CheckedChanged += new System.EventHandler(this.TeamShowRanking_CheckedChanged);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.GenerateNewRosterButton);
            this.groupBox15.Controls.Add(this.DeathPenaltyButton);
            this.groupBox15.Location = new System.Drawing.Point(562, 457);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(130, 141);
            this.groupBox15.TabIndex = 147;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Fantasy";
            // 
            // GenerateNewRosterButton
            // 
            this.GenerateNewRosterButton.BackColor = System.Drawing.Color.LightCoral;
            this.GenerateNewRosterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateNewRosterButton.Location = new System.Drawing.Point(4, 88);
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
            this.DeathPenaltyButton.Location = new System.Drawing.Point(4, 26);
            this.DeathPenaltyButton.Name = "DeathPenaltyButton";
            this.DeathPenaltyButton.Size = new System.Drawing.Size(120, 43);
            this.DeathPenaltyButton.TabIndex = 139;
            this.DeathPenaltyButton.Text = "Death Penalty";
            this.DeathPenaltyButton.UseVisualStyleBackColor = false;
            this.DeathPenaltyButton.Click += new System.EventHandler(this.DeathPenaltyButton_Click);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.TeamSTRating);
            this.groupBox14.Controls.Add(this.label210);
            this.groupBox14.Controls.Add(this.label181);
            this.groupBox14.Controls.Add(this.TeamDefRating);
            this.groupBox14.Controls.Add(this.SDURnumbox);
            this.groupBox14.Controls.Add(this.label209);
            this.groupBox14.Controls.Add(this.label20);
            this.groupBox14.Controls.Add(this.TeamOffRating);
            this.groupBox14.Controls.Add(this.label21);
            this.groupBox14.Controls.Add(this.label208);
            this.groupBox14.Controls.Add(this.label35);
            this.groupBox14.Controls.Add(this.label34);
            this.groupBox14.Controls.Add(this.CoachPollBox);
            this.groupBox14.Controls.Add(this.label36);
            this.groupBox14.Controls.Add(this.SeasonRecordBox);
            this.groupBox14.Controls.Add(this.label37);
            this.groupBox14.Controls.Add(this.APPollBox);
            this.groupBox14.Controls.Add(this.TMPRNumBox);
            this.groupBox14.Controls.Add(this.ConfRecordBox);
            this.groupBox14.Controls.Add(this.TMARNumBox);
            this.groupBox14.Controls.Add(this.INPOnumbox);
            this.groupBox14.Controls.Add(this.TeamOVRtextbox);
            this.groupBox14.Controls.Add(this.NCDPnumbox);
            this.groupBox14.Controls.Add(this.SNCTnumbox);
            this.groupBox14.Controls.Add(this.label29);
            this.groupBox14.Controls.Add(this.label28);
            this.groupBox14.Controls.Add(this.label30);
            this.groupBox14.Controls.Add(this.label31);
            this.groupBox14.Controls.Add(this.label19);
            this.groupBox14.Location = new System.Drawing.Point(230, 75);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(321, 220);
            this.groupBox14.TabIndex = 146;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Team Performance";
            // 
            // TeamSTRating
            // 
            this.TeamSTRating.Location = new System.Drawing.Point(232, 46);
            this.TeamSTRating.Name = "TeamSTRating";
            this.TeamSTRating.ReadOnly = true;
            this.TeamSTRating.Size = new System.Drawing.Size(42, 20);
            this.TeamSTRating.TabIndex = 152;
            this.TeamSTRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.Location = new System.Drawing.Point(217, 30);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(77, 13);
            this.label210.TabIndex = 153;
            this.label210.Text = "Special Teams";
            // 
            // label181
            // 
            this.label181.AutoSize = true;
            this.label181.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label181.Location = new System.Drawing.Point(24, 137);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(83, 16);
            this.label181.TabIndex = 88;
            this.label181.Text = "PRESTIGE";
            // 
            // TeamDefRating
            // 
            this.TeamDefRating.Location = new System.Drawing.Point(162, 46);
            this.TeamDefRating.Name = "TeamDefRating";
            this.TeamDefRating.ReadOnly = true;
            this.TeamDefRating.Size = new System.Drawing.Size(42, 20);
            this.TeamDefRating.TabIndex = 150;
            this.TeamDefRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SDURnumbox
            // 
            this.SDURnumbox.Location = new System.Drawing.Point(251, 191);
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
            // label209
            // 
            this.label209.AutoSize = true;
            this.label209.Location = new System.Drawing.Point(160, 30);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(47, 13);
            this.label209.TabIndex = 151;
            this.label209.Text = "Defense";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(135, 122);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(34, 13);
            this.label20.TabIndex = 33;
            this.label20.Text = "Team";
            // 
            // TeamOffRating
            // 
            this.TeamOffRating.Location = new System.Drawing.Point(92, 46);
            this.TeamOffRating.Name = "TeamOffRating";
            this.TeamOffRating.ReadOnly = true;
            this.TeamOffRating.Size = new System.Drawing.Size(42, 20);
            this.TeamOffRating.TabIndex = 148;
            this.TeamOffRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(207, 122);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Academic";
            // 
            // label208
            // 
            this.label208.AutoSize = true;
            this.label208.Location = new System.Drawing.Point(92, 30);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(44, 13);
            this.label208.TabIndex = 149;
            this.label208.Text = "Offense";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(20, 175);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(74, 13);
            this.label35.TabIndex = 61;
            this.label35.Text = "NCAA Interest";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(100, 175);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(84, 13);
            this.label34.TabIndex = 63;
            this.label34.Text = "Discipline Points";
            // 
            // CoachPollBox
            // 
            this.CoachPollBox.Location = new System.Drawing.Point(81, 94);
            this.CoachPollBox.Name = "CoachPollBox";
            this.CoachPollBox.ReadOnly = true;
            this.CoachPollBox.Size = new System.Drawing.Size(42, 20);
            this.CoachPollBox.TabIndex = 54;
            this.CoachPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(187, 175);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(49, 13);
            this.label36.TabIndex = 65;
            this.label36.Text = "Sanction";
            // 
            // SeasonRecordBox
            // 
            this.SeasonRecordBox.Location = new System.Drawing.Point(153, 94);
            this.SeasonRecordBox.Name = "SeasonRecordBox";
            this.SeasonRecordBox.ReadOnly = true;
            this.SeasonRecordBox.Size = new System.Drawing.Size(65, 20);
            this.SeasonRecordBox.TabIndex = 52;
            this.SeasonRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(248, 175);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(47, 13);
            this.label37.TabIndex = 67;
            this.label37.Text = "Duration";
            // 
            // APPollBox
            // 
            this.APPollBox.Location = new System.Drawing.Point(23, 94);
            this.APPollBox.Name = "APPollBox";
            this.APPollBox.ReadOnly = true;
            this.APPollBox.Size = new System.Drawing.Size(42, 20);
            this.APPollBox.TabIndex = 50;
            this.APPollBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TMPRNumBox
            // 
            this.TMPRNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMPRNumBox.Location = new System.Drawing.Point(134, 135);
            this.TMPRNumBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TMPRNumBox.Name = "TMPRNumBox";
            this.TMPRNumBox.Size = new System.Drawing.Size(50, 22);
            this.TMPRNumBox.TabIndex = 81;
            this.TMPRNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TMPRNumBox.ValueChanged += new System.EventHandler(this.TMPRNumBox_ValueChanged);
            // 
            // ConfRecordBox
            // 
            this.ConfRecordBox.Location = new System.Drawing.Point(232, 94);
            this.ConfRecordBox.Name = "ConfRecordBox";
            this.ConfRecordBox.ReadOnly = true;
            this.ConfRecordBox.Size = new System.Drawing.Size(62, 20);
            this.ConfRecordBox.TabIndex = 48;
            this.ConfRecordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TMARNumBox
            // 
            this.TMARNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMARNumBox.Location = new System.Drawing.Point(209, 135);
            this.TMARNumBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.TMARNumBox.Name = "TMARNumBox";
            this.TMARNumBox.Size = new System.Drawing.Size(50, 22);
            this.TMARNumBox.TabIndex = 82;
            this.TMARNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TMARNumBox.ValueChanged += new System.EventHandler(this.TMARNumBox_ValueChanged);
            // 
            // INPOnumbox
            // 
            this.INPOnumbox.Location = new System.Drawing.Point(23, 191);
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
            // TeamOVRtextbox
            // 
            this.TeamOVRtextbox.Location = new System.Drawing.Point(23, 46);
            this.TeamOVRtextbox.Name = "TeamOVRtextbox";
            this.TeamOVRtextbox.ReadOnly = true;
            this.TeamOVRtextbox.Size = new System.Drawing.Size(42, 20);
            this.TeamOVRtextbox.TabIndex = 30;
            this.TeamOVRtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NCDPnumbox
            // 
            this.NCDPnumbox.Location = new System.Drawing.Point(103, 191);
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
            // SNCTnumbox
            // 
            this.SNCTnumbox.Location = new System.Drawing.Point(186, 191);
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
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(232, 78);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 13);
            this.label29.TabIndex = 49;
            this.label29.Text = "Conf";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(24, 78);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(41, 13);
            this.label28.TabIndex = 51;
            this.label28.Text = "AP Poll";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(158, 78);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(42, 13);
            this.label30.TabIndex = 53;
            this.label30.Text = "Record";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(82, 78);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(58, 13);
            this.label31.TabIndex = 55;
            this.label31.Text = "Coach Poll";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(27, 30);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Rating";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.TeamColor2Button);
            this.groupBox13.Controls.Add(this.TeamColor1Button);
            this.groupBox13.Controls.Add(this.ResetPrimaryColorButton);
            this.groupBox13.Controls.Add(this.ResetSecondaryColorButton);
            this.groupBox13.Controls.Add(this.label8);
            this.groupBox13.Controls.Add(this.CheerleaderBox);
            this.groupBox13.Controls.Add(this.label5);
            this.groupBox13.Controls.Add(this.CrowdBox);
            this.groupBox13.Location = new System.Drawing.Point(230, 301);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(321, 176);
            this.groupBox13.TabIndex = 145;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Team Colors";
            // 
            // TeamColor2Button
            // 
            this.TeamColor2Button.Location = new System.Drawing.Point(176, 21);
            this.TeamColor2Button.Name = "TeamColor2Button";
            this.TeamColor2Button.Size = new System.Drawing.Size(125, 67);
            this.TeamColor2Button.TabIndex = 70;
            this.TeamColor2Button.UseVisualStyleBackColor = true;
            this.TeamColor2Button.Click += new System.EventHandler(this.TeamColor2Button_Click);
            // 
            // TeamColor1Button
            // 
            this.TeamColor1Button.Location = new System.Drawing.Point(22, 21);
            this.TeamColor1Button.Name = "TeamColor1Button";
            this.TeamColor1Button.Size = new System.Drawing.Size(125, 67);
            this.TeamColor1Button.TabIndex = 69;
            this.TeamColor1Button.UseVisualStyleBackColor = true;
            this.TeamColor1Button.Click += new System.EventHandler(this.TeamColor1Button_Click);
            // 
            // ResetPrimaryColorButton
            // 
            this.ResetPrimaryColorButton.Location = new System.Drawing.Point(46, 94);
            this.ResetPrimaryColorButton.Name = "ResetPrimaryColorButton";
            this.ResetPrimaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetPrimaryColorButton.TabIndex = 108;
            this.ResetPrimaryColorButton.Text = "Reset Color";
            this.ResetPrimaryColorButton.UseVisualStyleBackColor = true;
            this.ResetPrimaryColorButton.Click += new System.EventHandler(this.ResetPrimaryColorButton_Click);
            // 
            // ResetSecondaryColorButton
            // 
            this.ResetSecondaryColorButton.Location = new System.Drawing.Point(199, 94);
            this.ResetSecondaryColorButton.Name = "ResetSecondaryColorButton";
            this.ResetSecondaryColorButton.Size = new System.Drawing.Size(75, 23);
            this.ResetSecondaryColorButton.TabIndex = 109;
            this.ResetSecondaryColorButton.Text = "Reset Color";
            this.ResetSecondaryColorButton.UseVisualStyleBackColor = true;
            this.ResetSecondaryColorButton.Click += new System.EventHandler(this.ResetSecondaryColorButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(174, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 13);
            this.label8.TabIndex = 134;
            this.label8.Text = "Cheerleader Color Palette";
            // 
            // CheerleaderBox
            // 
            this.CheerleaderBox.FormattingEnabled = true;
            this.CheerleaderBox.Location = new System.Drawing.Point(164, 139);
            this.CheerleaderBox.MaxLength = 2;
            this.CheerleaderBox.Name = "CheerleaderBox";
            this.CheerleaderBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CheerleaderBox.Size = new System.Drawing.Size(138, 21);
            this.CheerleaderBox.TabIndex = 137;
            this.CheerleaderBox.Tag = "x";
            this.CheerleaderBox.SelectedIndexChanged += new System.EventHandler(this.CheerleaderBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 135;
            this.label5.Text = "Crowd Color Palette";
            // 
            // CrowdBox
            // 
            this.CrowdBox.FormattingEnabled = true;
            this.CrowdBox.Location = new System.Drawing.Point(23, 139);
            this.CrowdBox.MaxLength = 2;
            this.CrowdBox.Name = "CrowdBox";
            this.CrowdBox.Size = new System.Drawing.Size(138, 21);
            this.CrowdBox.TabIndex = 136;
            this.CrowdBox.Tag = "x";
            this.CrowdBox.SelectedIndexChanged += new System.EventHandler(this.CrowdBox_SelectedIndexChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label224);
            this.groupBox12.Controls.Add(this.TeamStadRank);
            this.groupBox12.Controls.Add(this.StateBox);
            this.groupBox12.Controls.Add(this.label55);
            this.groupBox12.Controls.Add(this.stadiumNameBox);
            this.groupBox12.Controls.Add(this.CityNameBox);
            this.groupBox12.Controls.Add(this.label56);
            this.groupBox12.Controls.Add(this.label57);
            this.groupBox12.Controls.Add(this.label60);
            this.groupBox12.Controls.Add(this.label59);
            this.groupBox12.Controls.Add(this.AttendanceNumBox);
            this.groupBox12.Controls.Add(this.CapacityNumbox);
            this.groupBox12.Location = new System.Drawing.Point(230, 483);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(321, 115);
            this.groupBox12.TabIndex = 144;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Stadium";
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Location = new System.Drawing.Point(262, 69);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(33, 13);
            this.label224.TabIndex = 155;
            this.label224.Text = "Rank";
            // 
            // TeamStadRank
            // 
            this.TeamStadRank.Location = new System.Drawing.Point(259, 85);
            this.TeamStadRank.Name = "TeamStadRank";
            this.TeamStadRank.ReadOnly = true;
            this.TeamStadRank.Size = new System.Drawing.Size(42, 20);
            this.TeamStadRank.TabIndex = 154;
            this.TeamStadRank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StateBox
            // 
            this.StateBox.FormattingEnabled = true;
            this.StateBox.Location = new System.Drawing.Point(258, 42);
            this.StateBox.MaxLength = 2;
            this.StateBox.Name = "StateBox";
            this.StateBox.Size = new System.Drawing.Size(44, 21);
            this.StateBox.TabIndex = 118;
            this.StateBox.SelectedIndexChanged += new System.EventHandler(this.StateBox_SelectedIndexChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(22, 27);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(76, 13);
            this.label55.TabIndex = 115;
            this.label55.Text = "Stadium Name";
            // 
            // stadiumNameBox
            // 
            this.stadiumNameBox.Location = new System.Drawing.Point(21, 43);
            this.stadiumNameBox.Name = "stadiumNameBox";
            this.stadiumNameBox.Size = new System.Drawing.Size(127, 20);
            this.stadiumNameBox.TabIndex = 114;
            this.stadiumNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stadiumNameBox.Leave += new System.EventHandler(this.stadiumNameBox_Leave);
            // 
            // CityNameBox
            // 
            this.CityNameBox.Location = new System.Drawing.Point(155, 43);
            this.CityNameBox.Name = "CityNameBox";
            this.CityNameBox.Size = new System.Drawing.Size(95, 20);
            this.CityNameBox.TabIndex = 116;
            this.CityNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CityNameBox.Leave += new System.EventHandler(this.CityNameBox_Leave);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(161, 27);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(24, 13);
            this.label56.TabIndex = 117;
            this.label56.Text = "City";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(258, 27);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(32, 13);
            this.label57.TabIndex = 119;
            this.label57.Text = "State";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(22, 70);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(62, 13);
            this.label60.TabIndex = 120;
            this.label60.Text = "Attendance";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(132, 70);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(48, 13);
            this.label59.TabIndex = 121;
            this.label59.Text = "Capacity";
            // 
            // AttendanceNumBox
            // 
            this.AttendanceNumBox.Location = new System.Drawing.Point(21, 86);
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
            // CapacityNumbox
            // 
            this.CapacityNumbox.Location = new System.Drawing.Point(131, 86);
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
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.TeamAutoImpact);
            this.groupBox11.Controls.Add(this.ImpactTSI1Select);
            this.groupBox11.Controls.Add(this.label15);
            this.groupBox11.Controls.Add(this.label16);
            this.groupBox11.Controls.Add(this.label17);
            this.groupBox11.Controls.Add(this.label18);
            this.groupBox11.Controls.Add(this.label23);
            this.groupBox11.Controls.Add(this.label22);
            this.groupBox11.Controls.Add(this.CaptainOffSelectBox);
            this.groupBox11.Controls.Add(this.CaptainDefSelectBox);
            this.groupBox11.Controls.Add(this.ImpactTSI2Select);
            this.groupBox11.Controls.Add(this.ResetImpactPlayersButton);
            this.groupBox11.Controls.Add(this.ImpactTPIOSelect);
            this.groupBox11.Controls.Add(this.TeamRosterSizeLabel);
            this.groupBox11.Controls.Add(this.ImpactTPIDSelect);
            this.groupBox11.Location = new System.Drawing.Point(704, 18);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(399, 208);
            this.groupBox11.TabIndex = 143;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Team Leadership";
            // 
            // TeamAutoImpact
            // 
            this.TeamAutoImpact.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TeamAutoImpact.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TeamAutoImpact.Location = new System.Drawing.Point(140, 155);
            this.TeamAutoImpact.Name = "TeamAutoImpact";
            this.TeamAutoImpact.Size = new System.Drawing.Size(126, 35);
            this.TeamAutoImpact.TabIndex = 139;
            this.TeamAutoImpact.Text = "Auto-Determine Team Impact Players";
            this.TeamAutoImpact.UseVisualStyleBackColor = false;
            this.TeamAutoImpact.Click += new System.EventHandler(this.TeamAutoImpact_Click);
            // 
            // ImpactTSI1Select
            // 
            this.ImpactTSI1Select.FormattingEnabled = true;
            this.ImpactTSI1Select.Location = new System.Drawing.Point(23, 125);
            this.ImpactTSI1Select.MaxDropDownItems = 20;
            this.ImpactTSI1Select.MaxLength = 2;
            this.ImpactTSI1Select.Name = "ImpactTSI1Select";
            this.ImpactTSI1Select.Size = new System.Drawing.Size(168, 21);
            this.ImpactTSI1Select.TabIndex = 132;
            this.ImpactTSI1Select.Tag = "x";
            this.ImpactTSI1Select.SelectedIndexChanged += new System.EventHandler(this.ImpactTSI1Select_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "Impact Player - Offense";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(223, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Impact Player - Defense";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Impact Player";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(223, 110);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Impact Player";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(23, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(119, 13);
            this.label23.TabIndex = 36;
            this.label23.Text = "Team Captain - Offense";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(223, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(122, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Team Captain - Defense";
            // 
            // CaptainOffSelectBox
            // 
            this.CaptainOffSelectBox.FormattingEnabled = true;
            this.CaptainOffSelectBox.Location = new System.Drawing.Point(23, 36);
            this.CaptainOffSelectBox.MaxDropDownItems = 20;
            this.CaptainOffSelectBox.MaxLength = 2;
            this.CaptainOffSelectBox.Name = "CaptainOffSelectBox";
            this.CaptainOffSelectBox.Size = new System.Drawing.Size(168, 21);
            this.CaptainOffSelectBox.TabIndex = 127;
            this.CaptainOffSelectBox.Tag = "x";
            this.CaptainOffSelectBox.SelectedIndexChanged += new System.EventHandler(this.CaptainOffSelectBox_SelectedIndexChanged);
            // 
            // CaptainDefSelectBox
            // 
            this.CaptainDefSelectBox.FormattingEnabled = true;
            this.CaptainDefSelectBox.Location = new System.Drawing.Point(223, 36);
            this.CaptainDefSelectBox.MaxDropDownItems = 20;
            this.CaptainDefSelectBox.MaxLength = 2;
            this.CaptainDefSelectBox.Name = "CaptainDefSelectBox";
            this.CaptainDefSelectBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CaptainDefSelectBox.Size = new System.Drawing.Size(168, 21);
            this.CaptainDefSelectBox.TabIndex = 128;
            this.CaptainDefSelectBox.Tag = "x";
            this.CaptainDefSelectBox.SelectedIndexChanged += new System.EventHandler(this.CaptainDefSelectBox_SelectedIndexChanged);
            // 
            // ImpactTSI2Select
            // 
            this.ImpactTSI2Select.FormattingEnabled = true;
            this.ImpactTSI2Select.Location = new System.Drawing.Point(223, 125);
            this.ImpactTSI2Select.MaxDropDownItems = 20;
            this.ImpactTSI2Select.MaxLength = 2;
            this.ImpactTSI2Select.Name = "ImpactTSI2Select";
            this.ImpactTSI2Select.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImpactTSI2Select.Size = new System.Drawing.Size(168, 21);
            this.ImpactTSI2Select.TabIndex = 133;
            this.ImpactTSI2Select.Tag = "x";
            this.ImpactTSI2Select.SelectedIndexChanged += new System.EventHandler(this.ImpactTSI2Select_SelectedIndexChanged);
            // 
            // ResetImpactPlayersButton
            // 
            this.ResetImpactPlayersButton.BackColor = System.Drawing.Color.NavajoWhite;
            this.ResetImpactPlayersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetImpactPlayersButton.Location = new System.Drawing.Point(312, 167);
            this.ResetImpactPlayersButton.Name = "ResetImpactPlayersButton";
            this.ResetImpactPlayersButton.Size = new System.Drawing.Size(81, 35);
            this.ResetImpactPlayersButton.TabIndex = 129;
            this.ResetImpactPlayersButton.Text = "Reset";
            this.ResetImpactPlayersButton.UseVisualStyleBackColor = false;
            this.ResetImpactPlayersButton.Click += new System.EventHandler(this.ResetImpactPlayers_Click);
            // 
            // ImpactTPIOSelect
            // 
            this.ImpactTPIOSelect.FormattingEnabled = true;
            this.ImpactTPIOSelect.Location = new System.Drawing.Point(23, 81);
            this.ImpactTPIOSelect.MaxDropDownItems = 20;
            this.ImpactTPIOSelect.MaxLength = 2;
            this.ImpactTPIOSelect.Name = "ImpactTPIOSelect";
            this.ImpactTPIOSelect.Size = new System.Drawing.Size(168, 21);
            this.ImpactTPIOSelect.TabIndex = 130;
            this.ImpactTPIOSelect.Tag = "x";
            this.ImpactTPIOSelect.SelectedIndexChanged += new System.EventHandler(this.ImpactTPIOSelect_SelectedIndexChanged);
            // 
            // TeamRosterSizeLabel
            // 
            this.TeamRosterSizeLabel.AutoSize = true;
            this.TeamRosterSizeLabel.Location = new System.Drawing.Point(5, 188);
            this.TeamRosterSizeLabel.Name = "TeamRosterSizeLabel";
            this.TeamRosterSizeLabel.Size = new System.Drawing.Size(64, 13);
            this.TeamRosterSizeLabel.TabIndex = 138;
            this.TeamRosterSizeLabel.Text = "Roster Size:";
            // 
            // ImpactTPIDSelect
            // 
            this.ImpactTPIDSelect.FormattingEnabled = true;
            this.ImpactTPIDSelect.Location = new System.Drawing.Point(223, 81);
            this.ImpactTPIDSelect.MaxDropDownItems = 20;
            this.ImpactTPIDSelect.MaxLength = 2;
            this.ImpactTPIDSelect.Name = "ImpactTPIDSelect";
            this.ImpactTPIDSelect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImpactTPIDSelect.Size = new System.Drawing.Size(168, 21);
            this.ImpactTPIDSelect.TabIndex = 131;
            this.ImpactTPIDSelect.Tag = "x";
            this.ImpactTPIDSelect.SelectedIndexChanged += new System.EventHandler(this.ImpactTPIDSelect_SelectedIndexChanged);
            // 
            // TeamSetDepthChart
            // 
            this.TeamSetDepthChart.Location = new System.Drawing.Point(568, 395);
            this.TeamSetDepthChart.Name = "TeamSetDepthChart";
            this.TeamSetDepthChart.Size = new System.Drawing.Size(118, 47);
            this.TeamSetDepthChart.TabIndex = 141;
            this.TeamSetDepthChart.Text = "Auto-Set Depth Chart";
            this.TeamSetDepthChart.UseVisualStyleBackColor = true;
            this.TeamSetDepthChart.Click += new System.EventHandler(this.TeamSetDepthChart_Click);
            // 
            // LeagueBox
            // 
            this.LeagueBox.Location = new System.Drawing.Point(608, 99);
            this.LeagueBox.Name = "LeagueBox";
            this.LeagueBox.ReadOnly = true;
            this.LeagueBox.Size = new System.Drawing.Size(42, 20);
            this.LeagueBox.TabIndex = 46;
            this.LeagueBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TSNAtextBox
            // 
            this.TSNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSNAtextBox.Location = new System.Drawing.Point(583, 45);
            this.TSNAtextBox.MaxLength = 7;
            this.TSNAtextBox.Name = "TSNAtextBox";
            this.TSNAtextBox.Size = new System.Drawing.Size(78, 24);
            this.TSNAtextBox.TabIndex = 44;
            this.TSNAtextBox.Leave += new System.EventHandler(this.TSNAtextBox_Leave);
            // 
            // TeamDivisionBox
            // 
            this.TeamDivisionBox.Location = new System.Drawing.Point(583, 188);
            this.TeamDivisionBox.Name = "TeamDivisionBox";
            this.TeamDivisionBox.ReadOnly = true;
            this.TeamDivisionBox.Size = new System.Drawing.Size(88, 20);
            this.TeamDivisionBox.TabIndex = 42;
            this.TeamDivisionBox.Text = "Division";
            this.TeamDivisionBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TeamConferenceBox
            // 
            this.TeamConferenceBox.Location = new System.Drawing.Point(583, 143);
            this.TeamConferenceBox.Name = "TeamConferenceBox";
            this.TeamConferenceBox.ReadOnly = true;
            this.TeamConferenceBox.Size = new System.Drawing.Size(88, 20);
            this.TeamConferenceBox.TabIndex = 40;
            this.TeamConferenceBox.Text = "Conference";
            this.TeamConferenceBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TGIDtextBox
            // 
            this.TGIDtextBox.Location = new System.Drawing.Point(277, 5);
            this.TGIDtextBox.Name = "TGIDtextBox";
            this.TGIDtextBox.ReadOnly = true;
            this.TGIDtextBox.Size = new System.Drawing.Size(44, 20);
            this.TGIDtextBox.TabIndex = 16;
            this.TGIDtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TMNAtextBox
            // 
            this.TMNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TMNAtextBox.Location = new System.Drawing.Point(406, 45);
            this.TMNAtextBox.MaxLength = 32;
            this.TMNAtextBox.Name = "TMNAtextBox";
            this.TMNAtextBox.Size = new System.Drawing.Size(162, 24);
            this.TMNAtextBox.TabIndex = 14;
            this.TMNAtextBox.Leave += new System.EventHandler(this.TMNAtextBox_Leave);
            // 
            // TDNAtextBox
            // 
            this.TDNAtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TDNAtextBox.Location = new System.Drawing.Point(228, 45);
            this.TDNAtextBox.MaxLength = 32;
            this.TDNAtextBox.Name = "TDNAtextBox";
            this.TDNAtextBox.Size = new System.Drawing.Size(162, 24);
            this.TDNAtextBox.TabIndex = 12;
            this.TDNAtextBox.Leave += new System.EventHandler(this.TDNAtextBox_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(609, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 47;
            this.label27.Text = "League";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(580, 29);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 45;
            this.label26.Text = "Abbr Name";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(605, 171);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(44, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "Division";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(596, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Conference";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(227, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Team ID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Team Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "College Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Conference";
            // 
            // CGIDcomboBox
            // 
            this.CGIDcomboBox.FormattingEnabled = true;
            this.CGIDcomboBox.Location = new System.Drawing.Point(82, 24);
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
            this.LGIDcomboBox.Size = new System.Drawing.Size(64, 21);
            this.LGIDcomboBox.TabIndex = 6;
            this.LGIDcomboBox.SelectedIndexChanged += new System.EventHandler(this.LGIDcomboBox_SelectedIndexChanged);
            // 
            // TGIDlistBox
            // 
            this.TGIDlistBox.FormattingEnabled = true;
            this.TGIDlistBox.Location = new System.Drawing.Point(12, 51);
            this.TGIDlistBox.Name = "TGIDlistBox";
            this.TGIDlistBox.Size = new System.Drawing.Size(172, 485);
            this.TGIDlistBox.TabIndex = 0;
            this.TGIDlistBox.SelectedIndexChanged += new System.EventHandler(this.TGIDlistBox_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.UserCoachCheckBox);
            this.groupBox10.Controls.Add(this.label32);
            this.groupBox10.Controls.Add(this.label33);
            this.groupBox10.Controls.Add(this.label41);
            this.groupBox10.Controls.Add(this.label40);
            this.groupBox10.Controls.Add(this.label39);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.TeamCTPCNumber);
            this.groupBox10.Controls.Add(this.TeamCRPCNumber);
            this.groupBox10.Controls.Add(this.TeamHCPrestigeNumBox);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.TeamCCPONumBox);
            this.groupBox10.Controls.Add(this.label45);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.label46);
            this.groupBox10.Controls.Add(this.PlaybookSelectBox);
            this.groupBox10.Controls.Add(this.label48);
            this.groupBox10.Controls.Add(this.DefTypeSelectBox);
            this.groupBox10.Controls.Add(this.label47);
            this.groupBox10.Controls.Add(this.OffTypeSelectBox);
            this.groupBox10.Controls.Add(this.TeamCOTRbox);
            this.groupBox10.Controls.Add(this.TeamCOTAbox);
            this.groupBox10.Controls.Add(this.label49);
            this.groupBox10.Controls.Add(this.TeamCOTSbox);
            this.groupBox10.Controls.Add(this.label52);
            this.groupBox10.Controls.Add(this.label51);
            this.groupBox10.Controls.Add(this.TeamCDTRbox);
            this.groupBox10.Controls.Add(this.TeamCDTAbox);
            this.groupBox10.Controls.Add(this.label50);
            this.groupBox10.Controls.Add(this.TeamCDTSbox);
            this.groupBox10.Controls.Add(this.TeamCDPCBox);
            this.groupBox10.Controls.Add(this.FireCoachButton);
            this.groupBox10.Controls.Add(this.HCLastNameBox);
            this.groupBox10.Controls.Add(this.HCFirstNameBox);
            this.groupBox10.Location = new System.Drawing.Point(704, 235);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(399, 363);
            this.groupBox10.TabIndex = 142;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Head Coach";
            // 
            // UserCoachCheckBox
            // 
            this.UserCoachCheckBox.AutoSize = true;
            this.UserCoachCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserCoachCheckBox.Location = new System.Drawing.Point(13, 329);
            this.UserCoachCheckBox.Name = "UserCoachCheckBox";
            this.UserCoachCheckBox.Size = new System.Drawing.Size(122, 24);
            this.UserCoachCheckBox.TabIndex = 111;
            this.UserCoachCheckBox.Text = "User Coach";
            this.UserCoachCheckBox.UseVisualStyleBackColor = true;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(35, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 13);
            this.label32.TabIndex = 57;
            this.label32.Text = "Head Coach";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(233, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(63, 13);
            this.label33.TabIndex = 59;
            this.label33.Text = "HC Prestige";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(101, 107);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(60, 13);
            this.label41.TabIndex = 73;
            this.label41.Text = "Disciplining";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(176, 107);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(45, 13);
            this.label40.TabIndex = 75;
            this.label40.Text = "Training";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(237, 107);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(55, 13);
            this.label39.TabIndex = 77;
            this.label39.Text = "Recruiting";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(136, 91);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 13);
            this.label42.TabIndex = 78;
            this.label42.Text = "Off-Season Budget";
            // 
            // TeamCTPCNumber
            // 
            this.TeamCTPCNumber.Location = new System.Drawing.Point(171, 123);
            this.TeamCTPCNumber.Name = "TeamCTPCNumber";
            this.TeamCTPCNumber.Size = new System.Drawing.Size(50, 20);
            this.TeamCTPCNumber.TabIndex = 79;
            this.TeamCTPCNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCTPCNumber.ValueChanged += new System.EventHandler(this.TeamCTPCNumber_ValueChanged);
            // 
            // TeamCRPCNumber
            // 
            this.TeamCRPCNumber.Location = new System.Drawing.Point(240, 124);
            this.TeamCRPCNumber.Name = "TeamCRPCNumber";
            this.TeamCRPCNumber.Size = new System.Drawing.Size(50, 20);
            this.TeamCRPCNumber.TabIndex = 80;
            this.TeamCRPCNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCRPCNumber.ValueChanged += new System.EventHandler(this.TeamCRPCNumber_ValueChanged);
            // 
            // TeamHCPrestigeNumBox
            // 
            this.TeamHCPrestigeNumBox.Location = new System.Drawing.Point(236, 54);
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
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(300, 39);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 13);
            this.label43.TabIndex = 88;
            this.label43.Text = "Performance";
            // 
            // TeamCCPONumBox
            // 
            this.TeamCCPONumBox.Location = new System.Drawing.Point(303, 55);
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
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(232, 194);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(74, 13);
            this.label45.TabIndex = 90;
            this.label45.Text = "Base Defense";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(36, 194);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(71, 13);
            this.label44.TabIndex = 92;
            this.label44.Text = "Offense Type";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(163, 156);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(59, 13);
            this.label46.TabIndex = 94;
            this.label46.Text = "Playbook";
            // 
            // PlaybookSelectBox
            // 
            this.PlaybookSelectBox.FormattingEnabled = true;
            this.PlaybookSelectBox.Location = new System.Drawing.Point(123, 172);
            this.PlaybookSelectBox.MaxLength = 2;
            this.PlaybookSelectBox.Name = "PlaybookSelectBox";
            this.PlaybookSelectBox.Size = new System.Drawing.Size(138, 21);
            this.PlaybookSelectBox.TabIndex = 126;
            this.PlaybookSelectBox.Tag = "x";
            this.PlaybookSelectBox.SelectedIndexChanged += new System.EventHandler(this.PlaybookSelectBox_SelectedIndexChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(10, 239);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(63, 13);
            this.label48.TabIndex = 96;
            this.label48.Text = "Passing Pct";
            // 
            // DefTypeSelectBox
            // 
            this.DefTypeSelectBox.FormattingEnabled = true;
            this.DefTypeSelectBox.Location = new System.Drawing.Point(222, 210);
            this.DefTypeSelectBox.MaxLength = 2;
            this.DefTypeSelectBox.Name = "DefTypeSelectBox";
            this.DefTypeSelectBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DefTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.DefTypeSelectBox.TabIndex = 125;
            this.DefTypeSelectBox.Tag = "x";
            this.DefTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.DefTypeSelectBox_SelectedIndexChanged);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(58, 278);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(81, 13);
            this.label47.TabIndex = 97;
            this.label47.Text = "Aggressiveness";
            // 
            // OffTypeSelectBox
            // 
            this.OffTypeSelectBox.FormattingEnabled = true;
            this.OffTypeSelectBox.Location = new System.Drawing.Point(30, 210);
            this.OffTypeSelectBox.MaxLength = 2;
            this.OffTypeSelectBox.Name = "OffTypeSelectBox";
            this.OffTypeSelectBox.Size = new System.Drawing.Size(138, 21);
            this.OffTypeSelectBox.TabIndex = 124;
            this.OffTypeSelectBox.Tag = "x";
            this.OffTypeSelectBox.SelectedIndexChanged += new System.EventHandler(this.OffTypeSelectBox_SelectedIndexChanged);
            // 
            // TeamCOTRbox
            // 
            this.TeamCOTRbox.Location = new System.Drawing.Point(19, 255);
            this.TeamCOTRbox.Name = "TeamCOTRbox";
            this.TeamCOTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTRbox.TabIndex = 98;
            this.TeamCOTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTRbox.ValueChanged += new System.EventHandler(this.TeamCOTRbox_ValueChanged);
            // 
            // TeamCOTAbox
            // 
            this.TeamCOTAbox.Location = new System.Drawing.Point(75, 255);
            this.TeamCOTAbox.Name = "TeamCOTAbox";
            this.TeamCOTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTAbox.TabIndex = 99;
            this.TeamCOTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTAbox.ValueChanged += new System.EventHandler(this.TeamCOTAbox_ValueChanged);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(137, 239);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(31, 13);
            this.label49.TabIndex = 100;
            this.label49.Text = "Subs";
            // 
            // TeamCOTSbox
            // 
            this.TeamCOTSbox.Location = new System.Drawing.Point(131, 255);
            this.TeamCOTSbox.Name = "TeamCOTSbox";
            this.TeamCOTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCOTSbox.TabIndex = 101;
            this.TeamCOTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCOTSbox.ValueChanged += new System.EventHandler(this.TeamCOTSbox_ValueChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(203, 239);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(63, 13);
            this.label52.TabIndex = 102;
            this.label52.Text = "Passing Pct";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(252, 278);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(81, 13);
            this.label51.TabIndex = 103;
            this.label51.Text = "Aggressiveness";
            // 
            // TeamCDTRbox
            // 
            this.TeamCDTRbox.Location = new System.Drawing.Point(211, 255);
            this.TeamCDTRbox.Name = "TeamCDTRbox";
            this.TeamCDTRbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTRbox.TabIndex = 104;
            this.TeamCDTRbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTRbox.ValueChanged += new System.EventHandler(this.TeamCDTRbox_ValueChanged);
            // 
            // TeamCDTAbox
            // 
            this.TeamCDTAbox.Location = new System.Drawing.Point(267, 255);
            this.TeamCDTAbox.Name = "TeamCDTAbox";
            this.TeamCDTAbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTAbox.TabIndex = 105;
            this.TeamCDTAbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTAbox.ValueChanged += new System.EventHandler(this.TeamCDTAbox_ValueChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(329, 239);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(31, 13);
            this.label50.TabIndex = 106;
            this.label50.Text = "Subs";
            // 
            // TeamCDTSbox
            // 
            this.TeamCDTSbox.Location = new System.Drawing.Point(323, 255);
            this.TeamCDTSbox.Name = "TeamCDTSbox";
            this.TeamCDTSbox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDTSbox.TabIndex = 107;
            this.TeamCDTSbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TeamCDTSbox.ValueChanged += new System.EventHandler(this.TeamCDTSbox_ValueChanged);
            // 
            // TeamCDPCBox
            // 
            this.TeamCDPCBox.Location = new System.Drawing.Point(104, 123);
            this.TeamCDPCBox.Name = "TeamCDPCBox";
            this.TeamCDPCBox.ReadOnly = true;
            this.TeamCDPCBox.Size = new System.Drawing.Size(50, 20);
            this.TeamCDPCBox.TabIndex = 72;
            this.TeamCDPCBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FireCoachButton
            // 
            this.FireCoachButton.BackColor = System.Drawing.Color.LightCoral;
            this.FireCoachButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FireCoachButton.Location = new System.Drawing.Point(291, 314);
            this.FireCoachButton.Name = "FireCoachButton";
            this.FireCoachButton.Size = new System.Drawing.Size(100, 43);
            this.FireCoachButton.TabIndex = 110;
            this.FireCoachButton.Text = "Fire Coach";
            this.FireCoachButton.UseVisualStyleBackColor = false;
            this.FireCoachButton.Click += new System.EventHandler(this.FireCoachButton_Click);
            // 
            // HCLastNameBox
            // 
            this.HCLastNameBox.Location = new System.Drawing.Point(135, 54);
            this.HCLastNameBox.Name = "HCLastNameBox";
            this.HCLastNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCLastNameBox.TabIndex = 68;
            this.HCLastNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCLastNameBox.TextChanged += new System.EventHandler(this.HCLastNameBox_TextChanged);
            // 
            // HCFirstNameBox
            // 
            this.HCFirstNameBox.Location = new System.Drawing.Point(34, 54);
            this.HCFirstNameBox.Name = "HCFirstNameBox";
            this.HCFirstNameBox.Size = new System.Drawing.Size(95, 20);
            this.HCFirstNameBox.TabIndex = 56;
            this.HCFirstNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HCFirstNameBox.TextChanged += new System.EventHandler(this.HCFirstNameBox_TextChanged);
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
            dataGridViewCellStyle60.BackColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle60;
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
            this.groupBox1.Size = new System.Drawing.Size(277, 48);
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
            this.NextConfigRadio.Location = new System.Drawing.Point(173, 21);
            this.NextConfigRadio.Name = "NextConfigRadio";
            this.NextConfigRadio.Size = new System.Drawing.Size(90, 20);
            this.NextConfigRadio.TabIndex = 0;
            this.NextConfigRadio.Text = "Next Mod";
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
            this.tabControl1.Controls.Add(this.tabSchedule);
            this.tabControl1.Controls.Add(this.tabDepthCharts);
            this.tabControl1.Controls.Add(this.tabConf);
            this.tabControl1.Controls.Add(this.tabBowls);
            this.tabControl1.Controls.Add(this.tabStadiums);
            this.tabControl1.Controls.Add(this.tabStats);
            this.tabControl1.Controls.Add(this.tabRecruits);
            this.tabControl1.Controls.Add(this.tabOffSeason);
            this.tabControl1.Controls.Add(this.tabPortal);
            this.tabControl1.Controls.Add(this.tabTools);
            this.tabControl1.Controls.Add(this.tabPlaybook);
            this.tabControl1.Controls.Add(this.tabUniforms);
            this.tabControl1.Controls.Add(this.tabDev);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(65, 20);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(5, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 643);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_IndexChange);
            // 
            // tabPortal
            // 
            this.tabPortal.BackColor = System.Drawing.Color.Tan;
            this.tabPortal.Controls.Add(this.PortalRatingBoost);
            this.tabPortal.Controls.Add(this.TransferEligible);
            this.tabPortal.Controls.Add(this.TotalTransfersCount);
            this.tabPortal.Controls.Add(this.PortalData);
            this.tabPortal.Controls.Add(this.richTextBox3);
            this.tabPortal.Controls.Add(this.richTextBox2);
            this.tabPortal.Controls.Add(this.richTextBox1);
            this.tabPortal.Controls.Add(this.PortalTransfers);
            this.tabPortal.Controls.Add(this.portalChance);
            this.tabPortal.Controls.Add(this.label259);
            this.tabPortal.Controls.Add(this.groupBox33);
            this.tabPortal.Controls.Add(this.groupBox32);
            this.tabPortal.Controls.Add(this.groupBox31);
            this.tabPortal.Controls.Add(this.SpringPortalButton);
            this.tabPortal.Location = new System.Drawing.Point(4, 24);
            this.tabPortal.Name = "tabPortal";
            this.tabPortal.Size = new System.Drawing.Size(1152, 615);
            this.tabPortal.TabIndex = 18;
            this.tabPortal.Text = "Portal";
            // 
            // PortalRatingBoost
            // 
            this.PortalRatingBoost.AutoSize = true;
            this.PortalRatingBoost.Location = new System.Drawing.Point(21, 356);
            this.PortalRatingBoost.Name = "PortalRatingBoost";
            this.PortalRatingBoost.Size = new System.Drawing.Size(212, 17);
            this.PortalRatingBoost.TabIndex = 43;
            this.PortalRatingBoost.Text = "Evaluate with JR/SR Rating Reduction";
            this.PortalRatingBoost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.PortalRatingBoost, "This evalutes the roster and portal feature with a rating reduction of -1 and -2 " +
        "for juniors and seniors, respectively. This is to allow underclassmen more oppor" +
        "tunity.\r\n");
            this.PortalRatingBoost.UseVisualStyleBackColor = true;
            // 
            // TransferEligible
            // 
            this.TransferEligible.AutoSize = true;
            this.TransferEligible.Location = new System.Drawing.Point(21, 333);
            this.TransferEligible.Name = "TransferEligible";
            this.TransferEligible.Size = new System.Drawing.Size(217, 17);
            this.TransferEligible.TabIndex = 42;
            this.TransferEligible.Text = "Immediate Eligibility Waiver (Vanilla Only)";
            this.toolTip1.SetToolTip(this.TransferEligible, "This is for non-NEXT mod users only. It will remove the Transfer 1 year wait peri" +
        "od.");
            this.TransferEligible.UseVisualStyleBackColor = true;
            // 
            // TotalTransfersCount
            // 
            this.TotalTransfersCount.AutoSize = true;
            this.TotalTransfersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTransfersCount.Location = new System.Drawing.Point(770, 588);
            this.TotalTransfersCount.Name = "TotalTransfersCount";
            this.TotalTransfersCount.Size = new System.Drawing.Size(129, 16);
            this.TotalTransfersCount.TabIndex = 41;
            this.TotalTransfersCount.Text = "Total Transfers: 0";
            // 
            // PortalData
            // 
            this.PortalData.AllowUserToAddRows = false;
            this.PortalData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PortalData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
            this.PortalData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PortalData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.PortalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PortalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PortalPosition,
            this.PortalTransferName,
            this.PortalClass,
            this.PortalRating,
            this.PortalNewSchool,
            this.PortalPrvTeam});
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle62.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle62.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle62.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle62.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle62.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PortalData.DefaultCellStyle = dataGridViewCellStyle62;
            this.PortalData.Location = new System.Drawing.Point(238, 25);
            this.PortalData.Name = "PortalData";
            this.PortalData.ReadOnly = true;
            this.PortalData.RowHeadersVisible = false;
            dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle63.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PortalData.RowsDefaultCellStyle = dataGridViewCellStyle63;
            this.PortalData.RowTemplate.Height = 31;
            this.PortalData.Size = new System.Drawing.Size(525, 576);
            this.PortalData.TabIndex = 40;
            // 
            // PortalPosition
            // 
            this.PortalPosition.FillWeight = 8F;
            this.PortalPosition.HeaderText = "Pos";
            this.PortalPosition.Name = "PortalPosition";
            this.PortalPosition.ReadOnly = true;
            // 
            // PortalTransferName
            // 
            this.PortalTransferName.FillWeight = 35F;
            this.PortalTransferName.HeaderText = "Player Name";
            this.PortalTransferName.Name = "PortalTransferName";
            this.PortalTransferName.ReadOnly = true;
            // 
            // PortalClass
            // 
            this.PortalClass.FillWeight = 13F;
            this.PortalClass.HeaderText = "Year";
            this.PortalClass.Name = "PortalClass";
            this.PortalClass.ReadOnly = true;
            // 
            // PortalRating
            // 
            this.PortalRating.FillWeight = 7F;
            this.PortalRating.HeaderText = "OVR";
            this.PortalRating.Name = "PortalRating";
            this.PortalRating.ReadOnly = true;
            // 
            // PortalNewSchool
            // 
            this.PortalNewSchool.FillWeight = 25F;
            this.PortalNewSchool.HeaderText = "To";
            this.PortalNewSchool.Name = "PortalNewSchool";
            this.PortalNewSchool.ReadOnly = true;
            // 
            // PortalPrvTeam
            // 
            this.PortalPrvTeam.FillWeight = 25F;
            this.PortalPrvTeam.HeaderText = "From";
            this.PortalPrvTeam.Name = "PortalPrvTeam";
            this.PortalPrvTeam.ReadOnly = true;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.Location = new System.Drawing.Point(773, 507);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(361, 52);
            this.richTextBox3.TabIndex = 39;
            this.richTextBox3.Text = "The Spring Portal will only work after Spring Training Camp is over and before Te" +
    "am Cuts are performed.";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(12, 411);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(209, 190);
            this.richTextBox2.TabIndex = 38;
            this.richTextBox2.Text = resources.GetString("richTextBox2.Text");
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(773, 388);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(361, 97);
            this.richTextBox1.TabIndex = 37;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // PortalTransfers
            // 
            this.PortalTransfers.AutoSize = true;
            this.PortalTransfers.Location = new System.Drawing.Point(21, 310);
            this.PortalTransfers.Name = "PortalTransfers";
            this.PortalTransfers.Size = new System.Drawing.Size(189, 17);
            this.PortalTransfers.TabIndex = 36;
            this.PortalTransfers.Text = "Allow Winter Transfers to Re-Enter";
            this.toolTip1.SetToolTip(this.PortalTransfers, "This lets players who transferred in the previous portal to be available in this " +
        "portal.");
            this.PortalTransfers.UseVisualStyleBackColor = true;
            // 
            // portalChance
            // 
            this.portalChance.Location = new System.Drawing.Point(176, 385);
            this.portalChance.Name = "portalChance";
            this.portalChance.Size = new System.Drawing.Size(45, 20);
            this.portalChance.TabIndex = 35;
            this.portalChance.Value = new decimal(new int[] {
            67,
            0,
            0,
            0});
            // 
            // label259
            // 
            this.label259.AutoSize = true;
            this.label259.Location = new System.Drawing.Point(23, 388);
            this.label259.Name = "label259";
            this.label259.Size = new System.Drawing.Size(150, 13);
            this.label259.TabIndex = 34;
            this.label259.Text = "Transfer Chance Percentage: ";
            this.toolTip1.SetToolTip(this.label259, "This is the likelihood a player will join the portal if they meet the pre-reqs.");
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.largePortal);
            this.groupBox33.Controls.Add(this.smallPortal);
            this.groupBox33.Location = new System.Drawing.Point(21, 225);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(200, 79);
            this.groupBox33.TabIndex = 31;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "Portal Size";
            this.toolTip1.SetToolTip(this.groupBox33, resources.GetString("groupBox33.ToolTip"));
            // 
            // largePortal
            // 
            this.largePortal.AutoSize = true;
            this.largePortal.Location = new System.Drawing.Point(18, 48);
            this.largePortal.Name = "largePortal";
            this.largePortal.Size = new System.Drawing.Size(82, 17);
            this.largePortal.TabIndex = 1;
            this.largePortal.Text = "Large Portal";
            this.largePortal.UseVisualStyleBackColor = true;
            // 
            // smallPortal
            // 
            this.smallPortal.AutoSize = true;
            this.smallPortal.Checked = true;
            this.smallPortal.Location = new System.Drawing.Point(18, 23);
            this.smallPortal.Name = "smallPortal";
            this.smallPortal.Size = new System.Drawing.Size(80, 17);
            this.smallPortal.TabIndex = 0;
            this.smallPortal.TabStop = true;
            this.smallPortal.Text = "Small Portal";
            this.smallPortal.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.PortalK);
            this.groupBox32.Controls.Add(this.label258);
            this.groupBox32.Controls.Add(this.PortalP);
            this.groupBox32.Controls.Add(this.label250);
            this.groupBox32.Controls.Add(this.PortalSS);
            this.groupBox32.Controls.Add(this.label251);
            this.groupBox32.Controls.Add(this.PortalFS);
            this.groupBox32.Controls.Add(this.label252);
            this.groupBox32.Controls.Add(this.PortalCB);
            this.groupBox32.Controls.Add(this.label253);
            this.groupBox32.Controls.Add(this.PortalMLB);
            this.groupBox32.Controls.Add(this.label254);
            this.groupBox32.Controls.Add(this.PortalOLB);
            this.groupBox32.Controls.Add(this.label255);
            this.groupBox32.Controls.Add(this.PortalDT);
            this.groupBox32.Controls.Add(this.label256);
            this.groupBox32.Controls.Add(this.PortalDE);
            this.groupBox32.Controls.Add(this.label257);
            this.groupBox32.Controls.Add(this.PortalOC);
            this.groupBox32.Controls.Add(this.label249);
            this.groupBox32.Controls.Add(this.PortalOG);
            this.groupBox32.Controls.Add(this.label248);
            this.groupBox32.Controls.Add(this.PortalOT);
            this.groupBox32.Controls.Add(this.label247);
            this.groupBox32.Controls.Add(this.PortalTE);
            this.groupBox32.Controls.Add(this.label246);
            this.groupBox32.Controls.Add(this.PortalWR);
            this.groupBox32.Controls.Add(this.label245);
            this.groupBox32.Controls.Add(this.PortalFB);
            this.groupBox32.Controls.Add(this.label244);
            this.groupBox32.Controls.Add(this.PortalHB);
            this.groupBox32.Controls.Add(this.label243);
            this.groupBox32.Controls.Add(this.PortalQB);
            this.groupBox32.Controls.Add(this.label242);
            this.groupBox32.Location = new System.Drawing.Point(773, 28);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(361, 345);
            this.groupBox32.TabIndex = 30;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Roster Depth Option";
            // 
            // PortalK
            // 
            this.PortalK.Location = new System.Drawing.Point(277, 42);
            this.PortalK.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortalK.Name = "PortalK";
            this.PortalK.Size = new System.Drawing.Size(44, 20);
            this.PortalK.TabIndex = 33;
            this.PortalK.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label258
            // 
            this.label258.AutoSize = true;
            this.label258.Location = new System.Drawing.Point(249, 44);
            this.label258.Name = "label258";
            this.label258.Size = new System.Drawing.Size(14, 13);
            this.label258.TabIndex = 32;
            this.label258.Text = "K";
            // 
            // PortalP
            // 
            this.PortalP.Location = new System.Drawing.Point(277, 75);
            this.PortalP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PortalP.Name = "PortalP";
            this.PortalP.Size = new System.Drawing.Size(44, 20);
            this.PortalP.TabIndex = 31;
            this.PortalP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label250
            // 
            this.label250.AutoSize = true;
            this.label250.Location = new System.Drawing.Point(249, 77);
            this.label250.Name = "label250";
            this.label250.Size = new System.Drawing.Size(14, 13);
            this.label250.TabIndex = 30;
            this.label250.Text = "P";
            // 
            // PortalSS
            // 
            this.PortalSS.Location = new System.Drawing.Point(165, 264);
            this.PortalSS.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalSS.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PortalSS.Name = "PortalSS";
            this.PortalSS.Size = new System.Drawing.Size(44, 20);
            this.PortalSS.TabIndex = 29;
            this.PortalSS.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label251
            // 
            this.label251.AutoSize = true;
            this.label251.Location = new System.Drawing.Point(137, 266);
            this.label251.Name = "label251";
            this.label251.Size = new System.Drawing.Size(21, 13);
            this.label251.TabIndex = 28;
            this.label251.Text = "SS";
            // 
            // PortalFS
            // 
            this.PortalFS.Location = new System.Drawing.Point(165, 226);
            this.PortalFS.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalFS.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PortalFS.Name = "PortalFS";
            this.PortalFS.Size = new System.Drawing.Size(44, 20);
            this.PortalFS.TabIndex = 27;
            this.PortalFS.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label252
            // 
            this.label252.AutoSize = true;
            this.label252.Location = new System.Drawing.Point(137, 228);
            this.label252.Name = "label252";
            this.label252.Size = new System.Drawing.Size(20, 13);
            this.label252.TabIndex = 26;
            this.label252.Text = "FS";
            // 
            // PortalCB
            // 
            this.PortalCB.Location = new System.Drawing.Point(165, 189);
            this.PortalCB.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PortalCB.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PortalCB.Name = "PortalCB";
            this.PortalCB.Size = new System.Drawing.Size(44, 20);
            this.PortalCB.TabIndex = 25;
            this.PortalCB.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label253
            // 
            this.label253.AutoSize = true;
            this.label253.Location = new System.Drawing.Point(137, 191);
            this.label253.Name = "label253";
            this.label253.Size = new System.Drawing.Size(21, 13);
            this.label253.TabIndex = 24;
            this.label253.Text = "CB";
            // 
            // PortalMLB
            // 
            this.PortalMLB.Location = new System.Drawing.Point(165, 151);
            this.PortalMLB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalMLB.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.PortalMLB.Name = "PortalMLB";
            this.PortalMLB.Size = new System.Drawing.Size(44, 20);
            this.PortalMLB.TabIndex = 23;
            this.PortalMLB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label254
            // 
            this.label254.AutoSize = true;
            this.label254.Location = new System.Drawing.Point(137, 153);
            this.label254.Name = "label254";
            this.label254.Size = new System.Drawing.Size(29, 13);
            this.label254.TabIndex = 22;
            this.label254.Text = "MLB";
            // 
            // PortalOLB
            // 
            this.PortalOLB.Location = new System.Drawing.Point(165, 115);
            this.PortalOLB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalOLB.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.PortalOLB.Name = "PortalOLB";
            this.PortalOLB.Size = new System.Drawing.Size(44, 20);
            this.PortalOLB.TabIndex = 21;
            this.PortalOLB.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label255
            // 
            this.label255.AutoSize = true;
            this.label255.Location = new System.Drawing.Point(137, 117);
            this.label255.Name = "label255";
            this.label255.Size = new System.Drawing.Size(28, 13);
            this.label255.TabIndex = 20;
            this.label255.Text = "OLB";
            // 
            // PortalDT
            // 
            this.PortalDT.Location = new System.Drawing.Point(165, 75);
            this.PortalDT.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PortalDT.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.PortalDT.Name = "PortalDT";
            this.PortalDT.Size = new System.Drawing.Size(44, 20);
            this.PortalDT.TabIndex = 19;
            this.PortalDT.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label256
            // 
            this.label256.AutoSize = true;
            this.label256.Location = new System.Drawing.Point(137, 77);
            this.label256.Name = "label256";
            this.label256.Size = new System.Drawing.Size(22, 13);
            this.label256.TabIndex = 18;
            this.label256.Text = "DT";
            // 
            // PortalDE
            // 
            this.PortalDE.Location = new System.Drawing.Point(165, 40);
            this.PortalDE.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PortalDE.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.PortalDE.Name = "PortalDE";
            this.PortalDE.Size = new System.Drawing.Size(44, 20);
            this.PortalDE.TabIndex = 17;
            this.PortalDE.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label257
            // 
            this.label257.AutoSize = true;
            this.label257.Location = new System.Drawing.Point(137, 42);
            this.label257.Name = "label257";
            this.label257.Size = new System.Drawing.Size(22, 13);
            this.label257.TabIndex = 16;
            this.label257.Text = "DE";
            // 
            // PortalOC
            // 
            this.PortalOC.Location = new System.Drawing.Point(47, 303);
            this.PortalOC.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalOC.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PortalOC.Name = "PortalOC";
            this.PortalOC.Size = new System.Drawing.Size(44, 20);
            this.PortalOC.TabIndex = 15;
            this.PortalOC.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label249
            // 
            this.label249.AutoSize = true;
            this.label249.Location = new System.Drawing.Point(19, 305);
            this.label249.Name = "label249";
            this.label249.Size = new System.Drawing.Size(22, 13);
            this.label249.TabIndex = 14;
            this.label249.Text = "OC";
            // 
            // PortalOG
            // 
            this.PortalOG.Location = new System.Drawing.Point(47, 264);
            this.PortalOG.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PortalOG.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PortalOG.Name = "PortalOG";
            this.PortalOG.Size = new System.Drawing.Size(44, 20);
            this.PortalOG.TabIndex = 13;
            this.PortalOG.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label248
            // 
            this.label248.AutoSize = true;
            this.label248.Location = new System.Drawing.Point(19, 266);
            this.label248.Name = "label248";
            this.label248.Size = new System.Drawing.Size(23, 13);
            this.label248.TabIndex = 12;
            this.label248.Text = "OG";
            // 
            // PortalOT
            // 
            this.PortalOT.Location = new System.Drawing.Point(47, 226);
            this.PortalOT.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalOT.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PortalOT.Name = "PortalOT";
            this.PortalOT.Size = new System.Drawing.Size(44, 20);
            this.PortalOT.TabIndex = 11;
            this.PortalOT.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label247
            // 
            this.label247.AutoSize = true;
            this.label247.Location = new System.Drawing.Point(19, 228);
            this.label247.Name = "label247";
            this.label247.Size = new System.Drawing.Size(22, 13);
            this.label247.TabIndex = 10;
            this.label247.Text = "OT";
            // 
            // PortalTE
            // 
            this.PortalTE.Location = new System.Drawing.Point(47, 189);
            this.PortalTE.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalTE.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PortalTE.Name = "PortalTE";
            this.PortalTE.Size = new System.Drawing.Size(44, 20);
            this.PortalTE.TabIndex = 9;
            this.PortalTE.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label246
            // 
            this.label246.AutoSize = true;
            this.label246.Location = new System.Drawing.Point(19, 191);
            this.label246.Name = "label246";
            this.label246.Size = new System.Drawing.Size(21, 13);
            this.label246.TabIndex = 8;
            this.label246.Text = "TE";
            // 
            // PortalWR
            // 
            this.PortalWR.Location = new System.Drawing.Point(47, 151);
            this.PortalWR.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalWR.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PortalWR.Name = "PortalWR";
            this.PortalWR.Size = new System.Drawing.Size(44, 20);
            this.PortalWR.TabIndex = 7;
            this.PortalWR.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label245
            // 
            this.label245.AutoSize = true;
            this.label245.Location = new System.Drawing.Point(19, 153);
            this.label245.Name = "label245";
            this.label245.Size = new System.Drawing.Size(26, 13);
            this.label245.TabIndex = 6;
            this.label245.Text = "WR";
            // 
            // PortalFB
            // 
            this.PortalFB.Location = new System.Drawing.Point(47, 115);
            this.PortalFB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalFB.Name = "PortalFB";
            this.PortalFB.Size = new System.Drawing.Size(44, 20);
            this.PortalFB.TabIndex = 5;
            this.PortalFB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label244
            // 
            this.label244.AutoSize = true;
            this.label244.Location = new System.Drawing.Point(19, 117);
            this.label244.Name = "label244";
            this.label244.Size = new System.Drawing.Size(20, 13);
            this.label244.TabIndex = 4;
            this.label244.Text = "FB";
            // 
            // PortalHB
            // 
            this.PortalHB.Location = new System.Drawing.Point(47, 75);
            this.PortalHB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalHB.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.PortalHB.Name = "PortalHB";
            this.PortalHB.Size = new System.Drawing.Size(44, 20);
            this.PortalHB.TabIndex = 3;
            this.PortalHB.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label243
            // 
            this.label243.AutoSize = true;
            this.label243.Location = new System.Drawing.Point(19, 77);
            this.label243.Name = "label243";
            this.label243.Size = new System.Drawing.Size(22, 13);
            this.label243.TabIndex = 2;
            this.label243.Text = "HB";
            // 
            // PortalQB
            // 
            this.PortalQB.Location = new System.Drawing.Point(47, 40);
            this.PortalQB.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PortalQB.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PortalQB.Name = "PortalQB";
            this.PortalQB.Size = new System.Drawing.Size(44, 20);
            this.PortalQB.TabIndex = 1;
            this.PortalQB.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label242
            // 
            this.label242.AutoSize = true;
            this.label242.Location = new System.Drawing.Point(19, 42);
            this.label242.Name = "label242";
            this.label242.Size = new System.Drawing.Size(22, 13);
            this.label242.TabIndex = 0;
            this.label242.Text = "QB";
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.PortalSnake);
            this.groupBox31.Controls.Add(this.PortalRandom);
            this.groupBox31.Controls.Add(this.PortalFirst);
            this.groupBox31.Controls.Add(this.PortalReverse);
            this.groupBox31.Location = new System.Drawing.Point(21, 100);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(200, 119);
            this.groupBox31.TabIndex = 29;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Portal Priority";
            this.toolTip1.SetToolTip(this.groupBox31, "This determines the order in which teams select players. It will go through posit" +
        "ion by position.");
            // 
            // PortalSnake
            // 
            this.PortalSnake.AutoSize = true;
            this.PortalSnake.Location = new System.Drawing.Point(7, 66);
            this.PortalSnake.Name = "PortalSnake";
            this.PortalSnake.Size = new System.Drawing.Size(85, 17);
            this.PortalSnake.TabIndex = 3;
            this.PortalSnake.Text = "Snake Order";
            this.PortalSnake.UseVisualStyleBackColor = true;
            // 
            // PortalRandom
            // 
            this.PortalRandom.AutoSize = true;
            this.PortalRandom.Location = new System.Drawing.Point(7, 89);
            this.PortalRandom.Name = "PortalRandom";
            this.PortalRandom.Size = new System.Drawing.Size(94, 17);
            this.PortalRandom.TabIndex = 2;
            this.PortalRandom.Text = "Random Order";
            this.PortalRandom.UseVisualStyleBackColor = true;
            // 
            // PortalFirst
            // 
            this.PortalFirst.AutoSize = true;
            this.PortalFirst.Location = new System.Drawing.Point(7, 43);
            this.PortalFirst.Name = "PortalFirst";
            this.PortalFirst.Size = new System.Drawing.Size(165, 17);
            this.PortalFirst.TabIndex = 1;
            this.PortalFirst.Text = "Ranking Order (First to Worst)";
            this.PortalFirst.UseVisualStyleBackColor = true;
            // 
            // PortalReverse
            // 
            this.PortalReverse.AutoSize = true;
            this.PortalReverse.Checked = true;
            this.PortalReverse.Location = new System.Drawing.Point(7, 20);
            this.PortalReverse.Name = "PortalReverse";
            this.PortalReverse.Size = new System.Drawing.Size(165, 17);
            this.PortalReverse.TabIndex = 0;
            this.PortalReverse.TabStop = true;
            this.PortalReverse.Text = "Reverse Order (Worst to First)";
            this.PortalReverse.UseVisualStyleBackColor = true;
            // 
            // SpringPortalButton
            // 
            this.SpringPortalButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpringPortalButton.Location = new System.Drawing.Point(21, 25);
            this.SpringPortalButton.Name = "SpringPortalButton";
            this.SpringPortalButton.Size = new System.Drawing.Size(200, 56);
            this.SpringPortalButton.TabIndex = 27;
            this.SpringPortalButton.Text = "Spring Portal";
            this.SpringPortalButton.UseVisualStyleBackColor = true;
            this.SpringPortalButton.Click += new System.EventHandler(this.SpringPortalButton_Click);
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
            this.tabDev.ResumeLayout(false);
            this.tabDev.PerformLayout();
            this.tabUniforms.ResumeLayout(false);
            this.tabUniforms.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UniformGrid)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPlaybook.ResumeLayout(false);
            this.tabPlaybook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayNameValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcrtNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaybookGrid)).EndInit();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            this.groupBox38.ResumeLayout(false);
            this.groupBox38.PerformLayout();
            this.FantastyRosterLeague.ResumeLayout(false);
            this.FantastyRosterLeague.PerformLayout();
            this.DepthChartSize.ResumeLayout(false);
            this.DepthChartSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFantasyPlayers)).EndInit();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FillRosterPCT)).EndInit();
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBodyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinBodyValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxAttNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GlobalAttNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinAttNum)).EndInit();
            this.tabOffSeason.ResumeLayout(false);
            this.tabOffSeason.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.removeInterestTeams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minRecPts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTRPA)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toleranceWalkOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recruitTolerance)).EndInit();
            this.tabRecruits.ResumeLayout(false);
            this.tabRecruits.PerformLayout();
            this.groupBox39.ResumeLayout(false);
            this.groupBox39.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecruitDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RDIS)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RINJBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSPDBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RACCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RSTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RBTKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTHPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RRBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPOEBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAWRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAGIBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RJMPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RCTHBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RCARBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTHABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RPBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RTAKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RKPRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RKACBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RWGTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHGTBox)).EndInit();
            this.tabStats.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.tabStadiums.ResumeLayout(false);
            this.tabStadiums.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STtvBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWSPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWRPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWWPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWFPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STfwBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STwpBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STjtBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STtsBox)).EndInit();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.STADCap)).EndInit();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.tabBowls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BowlsGrid)).EndInit();
            this.tabConf.ResumeLayout(false);
            this.tabConf.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.tabDepthCharts.ResumeLayout(false);
            this.tabDepthCharts.PerformLayout();
            this.groupBox40.ResumeLayout(false);
            this.groupBox40.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DCHTGrid)).EndInit();
            this.tabSchedule.ResumeLayout(false);
            this.tabSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchView)).EndInit();
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ScheduleView)).EndInit();
            this.tabSeason.ResumeLayout(false);
            this.tabSeason.PerformLayout();
            this.groupBox36.ResumeLayout(false);
            this.groupBox36.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillDrop)).EndInit();
            this.groupBox35.ResumeLayout(false);
            this.groupBox35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInjuries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSkillDropPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImpactPlayerMin)).EndInit();
            this.groupBox37.ResumeLayout(false);
            this.groupBox37.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarouselDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFiredTransfers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.poachValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobSecurityValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberPlayerCoach)).EndInit();
            this.tabCoaches.ResumeLayout(false);
            this.tabCoaches.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCCPONum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HCPrestigeNum)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxCCPOVal)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCDTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTSBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachTrainingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachRecruitingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CoachCOTRBox)).EndInit();
            this.tabPlayers.ResumeLayout(false);
            this.tabPlayers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDIS)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PIMPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PINJBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSPDBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PACCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSTRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBTKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PRBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPOEBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAWRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PAGIBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJMPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCTHBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCARBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTHABox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PPBKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTAKBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKPRBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PKACBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PJEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PWGTBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PHGTBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabTeams.ResumeLayout(false);
            this.tabTeams.PerformLayout();
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SDURnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMPRNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TMARNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.INPOnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NCDPnumbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SNCTnumbox)).EndInit();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttendanceNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityNumbox)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCTPCNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCRPCNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamHCPrestigeNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCCPONumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTRbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTAbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCOTSbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTRbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTAbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamCDTSbox)).EndInit();
            this.tabDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).EndInit();
            this.tabHome.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPortal.ResumeLayout(false);
            this.tabPortal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portalChance)).EndInit();
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortalK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalSS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalFS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalMLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOLB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalOT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalTE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalWR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalFB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalHB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PortalQB)).EndInit();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
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
        private ToolStripMenuItem NCAANextConfig;
        public ToolStripMenuItem definitionFileMenuItem;
        private NotifyIcon notifyIcon1;
        private RadioButton DB1Button;
        private RadioButton DB2Button;
        private GroupBox groupBox2;
        private TabPage tabDev;
        public System.Windows.Forms.Button CFUSAexportButton;
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
        private TabPage tabUniforms;
        private System.Windows.Forms.Button ImportTeamUNIF;
        private System.Windows.Forms.Button ExportTeamUNIF;
        private Label label172;
        private System.Windows.Forms.Button UpdateUNIFButton;
        private GroupBox groupBox5;
        private Label label170;
        private CheckBox GlobalAltCheck;
        private CheckBox GlobalPrimaryCheck;
        private System.Windows.Forms.ComboBox GlobalUniFilter;
        private Label label171;
        private DataGridView UniformGrid;
        private DataGridViewCheckBoxColumn UniformActivation;
        private DataGridViewTextBoxColumn UFID;
        private DataGridViewTextBoxColumn UnifTeam;
        private DataGridViewTextBoxColumn TUNI;
        private DataGridViewComboBoxColumn ULTF;
        private DataGridViewCheckBoxColumn ShoulderNums;
        private DataGridViewCheckBoxColumn SleeveNums;
        private DataGridViewCheckBoxColumn SleeveDecal;
        private DataGridViewComboBoxColumn HelmetNums;
        private DataGridViewCheckBoxColumn HelmetSideNum;
        private GroupBox groupBox4;
        private Label UniformsActivated;
        private Label label169;
        private CheckBox TeamAltUniCheck;
        private CheckBox TeamPrimaryUniCheck;
        private System.Windows.Forms.ComboBox TeamUniformSelectBox;
        private Label label168;
        private TabPage tabPlaybook;
        private System.Windows.Forms.TextBox textBox24;
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
        private GroupBox groupBox19;
        private RadioButton DefaultPlaysRadio;
        private RadioButton CustomPlaysRadio;
        private TabPage tabTools;
        private CheckBox ReRankTeams;
        public System.Windows.Forms.Button FixHCBugsButton;
        private GroupBox groupBox18;
        private NumericUpDown MaxAttNum;
        private System.Windows.Forms.ComboBox GlobalAttBox;
        private Label label99;
        private NumericUpDown GlobalAttNum;
        private Label label109;
        private CheckBox GlobalAttCheck;
        private Label label108;
        private System.Windows.Forms.ComboBox MinAttBox;
        private Label label107;
        private Label label100;
        private System.Windows.Forms.ComboBox MaxAttPosBox;
        private NumericUpDown MinAttNum;
        private System.Windows.Forms.ComboBox MinAttPosBox;
        private System.Windows.Forms.ComboBox MaxAttBox;
        private System.Windows.Forms.ComboBox GlobalAttPosBox;
        private Label label106;
        private System.Windows.Forms.Button MaxAttButton;
        private System.Windows.Forms.TextBox MinAttRating;
        private System.Windows.Forms.Button MinAttButton;
        private System.Windows.Forms.TextBox MaxAttRating;
        private System.Windows.Forms.Button GlobalAttButton;
        public System.Windows.Forms.Button UniquePlayerButton;
        public System.Windows.Forms.Button SyncPBButton;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Button ReorderPGIDButton;
        public System.Windows.Forms.Button TORDButton;
        public System.Windows.Forms.Button TYDNButton;
        public TabPage tabOffSeason;
        private GroupBox groupBox17;
        public NumericUpDown removeInterestTeams;
        public System.Windows.Forms.Button buttonMinRecruitingPts;
        public NumericUpDown minRecPts;
        public Label labelMinRecPts;
        public Label labelIntTeams;
        public NumericUpDown minTRPA;
        public Label label12;
        public System.Windows.Forms.Button buttonInterestedTeams;
        private GroupBox groupBox16;
        public System.Windows.Forms.Button RecalculateStarRankingsButton;
        public System.Windows.Forms.Button DetermineAthleteButton;
        public System.Windows.Forms.Button buttonRandWalkOns;
        public System.Windows.Forms.Button buttonRandRecruits;
        public System.Windows.Forms.Button RandomizeRecruitNamesButton;
        public NumericUpDown toleranceWalkOn;
        public System.Windows.Forms.Button buttonRandomizeFaceShape;
        public Label wkonLabel;
        public System.Windows.Forms.Button polyNames;
        public NumericUpDown recruitTolerance;
        public Label labelRecruit;
        public System.Windows.Forms.TextBox textBoxOffSeason;
        public System.Windows.Forms.TextBox textBoxOffSeasonTitle;
        private TabPage tabRecruits;
        private Label TransferTeam;
        private Label RecruitPitch;
        private System.Windows.Forms.Button UpdateRecruitOffers;
        private Label label207;
        private DataGridView RecruitDataGrid;
        private DataGridViewTextBoxColumn RCNo;
        private DataGridViewComboBoxColumn RCTeam;
        private DataGridViewTextBoxColumn RCTScore;
        public Label label184;
        private NumericUpDown RDIS;
        private Label PosRanking;
        private CheckBox CommitStatus;
        private Label RecruitCounter;
        private Label label205;
        private Label label204;
        private Label Label19084;
        private System.Windows.Forms.ComboBox RecruitPosFilter;
        private System.Windows.Forms.ComboBox RecruitStateFilter;
        private System.Windows.Forms.ComboBox RecruitTypeFilter;
        public Label RCHTBox;
        private System.Windows.Forms.ComboBox RHometownBox;
        private Label RecruitStarsText;
        private CheckBox AthleteBox;
        private GroupBox groupBox20;
        public System.Windows.Forms.TextBox RTENBox;
        private Label label183;
        private System.Windows.Forms.TextBox RTHAtext;
        private NumericUpDown RINJBox;
        private Label label185;
        private System.Windows.Forms.TextBox RKACtext;
        private NumericUpDown RSPDBox;
        private System.Windows.Forms.TextBox RKPRtext;
        private Label label186;
        private System.Windows.Forms.TextBox RTAKtext;
        private NumericUpDown RACCBox;
        private System.Windows.Forms.TextBox RPBKtext;
        private Label label187;
        private NumericUpDown RSTRBox;
        public System.Windows.Forms.TextBox ROVR;
        private System.Windows.Forms.TextBox RCARtext;
        private Label label188;
        private System.Windows.Forms.TextBox RCTHtext;
        private NumericUpDown RBTKBox;
        private System.Windows.Forms.TextBox RJMPtext;
        private Label label189;
        private NumericUpDown RTHPBox;
        private Label label190;
        private System.Windows.Forms.TextBox RAGItext;
        private NumericUpDown RRBKBox;
        private System.Windows.Forms.TextBox RAWRtext;
        private Label label191;
        private System.Windows.Forms.TextBox RPOEtext;
        private NumericUpDown RPOEBox;
        private System.Windows.Forms.TextBox RRBKtext;
        private Label label192;
        private System.Windows.Forms.TextBox RTHPtext;
        private NumericUpDown RAWRBox;
        private System.Windows.Forms.TextBox RBTKtext;
        private Label label193;
        private System.Windows.Forms.TextBox RSTRtext;
        private NumericUpDown RAGIBox;
        private System.Windows.Forms.TextBox RACCtext;
        private Label label194;
        public Label label164;
        private System.Windows.Forms.TextBox RSPDtext;
        private NumericUpDown RJMPBox;
        private System.Windows.Forms.TextBox RINJtext;
        private Label label195;
        private NumericUpDown RCTHBox;
        private Label label196;
        private NumericUpDown RCARBox;
        private Label label197;
        private NumericUpDown RTHABox;
        private Label label198;
        private NumericUpDown RPBKBox;
        private Label label199;
        private NumericUpDown RTAKBox;
        private Label label200;
        private NumericUpDown RKPRBox;
        private Label label201;
        private NumericUpDown RKACBox;
        private Label label202;
        public System.Windows.Forms.TextBox PRIDBox;
        public System.Windows.Forms.TextBox PLNABox;
        public System.Windows.Forms.TextBox PFNABox;
        public Label label182;
        public ListBox RecruitListBox;
        public Label label154;
        private System.Windows.Forms.ComboBox RStateBox;
        public Label label155;
        private System.Windows.Forms.ComboBox RYER;
        private Label label156;
        private NumericUpDown RWGTBox;
        private Label label157;
        private NumericUpDown RHGTBox;
        public Label label158;
        private System.Windows.Forms.ComboBox RHEDBox;
        public Label label159;
        private System.Windows.Forms.ComboBox RHCLBox;
        public Label label160;
        private System.Windows.Forms.ComboBox RFMPBox;
        public Label label161;
        private System.Windows.Forms.ComboBox RFGMBox;
        public Label label162;
        private System.Windows.Forms.ComboBox RSKIBox;
        public Label label163;
        private System.Windows.Forms.ComboBox RPPOSBox;
        public Label label165;
        public Label label166;
        private TabPage tabStats;
        private GroupBox groupBox26;
        private Label label221;
        private ListBox SacksLeadersBox;
        private ListBox IntLeadersBox;
        private Label label223;
        private Label label222;
        private ListBox TacklesLeadersBox;
        private GroupBox groupBox25;
        private Label label220;
        private ListBox ReceivingLeadersBox;
        private Label label219;
        private ListBox RushingLeadersBox;
        private Label label218;
        private ListBox PassingLeadersBox;
        private GroupBox groupBox24;
        private Label label217;
        private Label label216;
        private Label label215;
        private Label label214;
        private ListBox TopTeamDefBox;
        private ListBox TopTeamOffBox;
        private ListBox TopTeamRatingsBox;
        private ListBox CoachPollListBox;
        private TabPage tabStadiums;
        private GroupBox groupBox30;
        private System.Windows.Forms.Button GlobalWeather;
        private GroupBox groupBox29;
        private Label label241;
        private NumericUpDown STtvBox;
        private Label label235;
        private NumericUpDown SWSPBox;
        private Label label236;
        private NumericUpDown SWRPBox;
        private Label label233;
        private NumericUpDown SWWPBox;
        private Label label234;
        private NumericUpDown SWFPBox;
        private Label label231;
        private NumericUpDown STfwBox;
        private Label label232;
        private NumericUpDown STwpBox;
        private Label label230;
        private NumericUpDown STjtBox;
        private Label label229;
        private NumericUpDown STtsBox;
        private GroupBox groupBox28;
        public Label label239;
        private System.Windows.Forms.ComboBox STADSFTYBox;
        private System.Windows.Forms.ComboBox STADState;
        public System.Windows.Forms.TextBox STADCity;
        public Label label237;
        public Label label238;
        public Label label240;
        private NumericUpDown STADCap;
        private System.Windows.Forms.TextBox STADNickBox;
        private System.Windows.Forms.TextBox STADNameBox;
        private Label labelstadnickname;
        private Label labelstadname;
        private Label STADrank;
        private System.Windows.Forms.TextBox STADSTDR;
        private System.Windows.Forms.TextBox STADTDNA;
        private System.Windows.Forms.TextBox STADResBox;
        private System.Windows.Forms.TextBox STADsgidBox;
        private Label label228;
        private GroupBox groupBox27;
        private CheckBox STADType;
        private CheckBox STADCannon;
        private CheckBox STADVisbility;
        private CheckBox STADcat;
        private Label label227;
        private Label label226;
        private Label label225;
        private ListBox StadiumListBox;
        private TabPage tabBowls;
        private System.Windows.Forms.Button SaveBowlButton;
        private DataGridView BowlsGrid;
        private DataGridViewCheckBoxColumn ActiveBowl;
        private DataGridViewTextBoxColumn BIDX;
        private DataGridViewTextBoxColumn BNME;
        private DataGridViewComboBoxColumn TeamA;
        private DataGridViewTextBoxColumn ScoreA;
        private DataGridViewTextBoxColumn vs;
        private DataGridViewTextBoxColumn ScoreB;
        private DataGridViewComboBoxColumn TeamB;
        private DataGridViewComboBoxColumn SGID;
        private DataGridViewComboBoxColumn BMON;
        private DataGridViewComboBoxColumn BDAY;
        private DataGridViewTextBoxColumn SEWN;
        private TabPage tabConf;
        private GroupBox groupBox23;
        private RadioButton ConfDisplayRanking;
        private RadioButton ConfDisplayRating;
        private RadioButton ConfDisplayPrestige;
        private RadioButton ConfDisplayTeam;
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
        private TabPage tabSchedule;
        private Label label213;
        private DataGridView MatchView;
        private DataGridViewTextBoxColumn RatingCat;
        private DataGridViewTextBoxColumn MatchHomeTeam;
        private DataGridViewTextBoxColumn MatchAwayTeam;
        private Label SCHDrecord;
        private GroupBox groupBox21;
        private System.Windows.Forms.Button RescheduleOOC;
        private Label label212;
        private Label SchdTeamName;
        private Label label211;
        public ListBox SCHDTeamBox;
        private DataGridView ScheduleView;
        public TabPage tabSeason;
        private System.Windows.Forms.Button RemoveBadTransfers;
        private System.Windows.Forms.Button RemoveSanctionsButton;
        private Label label180;
        private NumericUpDown ImpactPlayerMin;
        public System.Windows.Forms.Button buttonImpactPlayers;
        private System.Windows.Forms.Button BodyProgressionButton;
        private Label label14;
        private NumericUpDown numberPlayerCoach;
        private System.Windows.Forms.Button buttonPlayerCoach;
        private System.Windows.Forms.Button buttonRealignment;
        private Label label13;
        public Label labelMaxTransfers;
        public NumericUpDown maxFiredTransfers;
        private CheckBox checkBoxFiredTransfers;
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
        public System.Windows.Forms.TextBox dbToolsInfo;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button medRS;
        private TabPage tabCoaches;
        private CheckBox CoachPerfCheckBox;
        private GroupBox groupBox9;
        private Label label179;
        private Label YearsWithTeam;
        private Label label177;
        private Label ConfTitles;
        private Label LabelNT;
        private Label NationalTitles;
        private Label label176;
        private Label ContractInfo;
        private Label label175;
        private Label CoachTeamPrestige;
        private Label label174;
        private Label Top25Record;
        private Label label88;
        private Label WinningSeasons;
        private Label label38;
        private Label BowlRecord;
        private Label label131;
        private Label YearsCoached;
        private Label label54;
        private Label CareerRecord;
        private Label label53;
        private Label SeasonRecord;
        private NumericUpDown CoachCCPONum;
        public Label label141;
        private NumericUpDown HCPrestigeNum;
        public Label label146;
        private GroupBox groupBox8;
        public System.Windows.Forms.Button AutoAdjustBudgetsButton;
        private Label label178;
        public System.Windows.Forms.Button coachProg;
        public System.Windows.Forms.Button CoachPrestigeButton;
        public System.Windows.Forms.Button buttonRandomBudgets;
        private System.Windows.Forms.Button SetMaxCoachCCPO;
        private NumericUpDown MaxCCPOVal;
        private GroupBox groupBox7;
        private CheckBox DisciplineAssistanceBox;
        private CheckBox RecruitAssistanceBox;
        private System.Windows.Forms.Button NewCoachButton;
        public Label label130;
        public Label label129;
        private System.Windows.Forms.ComboBox CoachTeamList;
        private System.Windows.Forms.ComboBox CSKIBox;
        public Label label98;
        public Label label105;
        private CheckBox CFUCBox;
        private System.Windows.Forms.ComboBox CBSZBox;
        public Label label96;
        public Label label104;
        private System.Windows.Forms.ComboBox COHTBox;
        private System.Windows.Forms.ComboBox CFEXBox;
        public Label label97;
        public Label label103;
        private System.Windows.Forms.ComboBox CTgwBox;
        private System.Windows.Forms.ComboBox CHARBox;
        public Label label102;
        private System.Windows.Forms.ComboBox CTHGBox;
        private System.Windows.Forms.ComboBox CoachPlaybookBox;
        public Label label101;
        private System.Windows.Forms.ComboBox CoachDefTypeBox;
        public Label label94;
        private System.Windows.Forms.ComboBox CoachOffTypeBox;
        public System.Windows.Forms.TextBox CoachFirstNameBox;
        private NumericUpDown CoachCDTSBox;
        public System.Windows.Forms.TextBox CoachLastNameBox;
        public Label label132;
        public System.Windows.Forms.TextBox CCIDBox;
        private NumericUpDown CoachCDTABox;
        public System.Windows.Forms.TextBox CoachDisciplineBox;
        private NumericUpDown CoachCDTRBox;
        public Label label145;
        public Label label133;
        public Label label144;
        public Label label134;
        public Label label143;
        private NumericUpDown CoachCOTSBox;
        public Label label142;
        public Label label135;
        private NumericUpDown CoachTrainingBox;
        private NumericUpDown CoachCOTABox;
        private NumericUpDown CoachRecruitingBox;
        private NumericUpDown CoachCOTRBox;
        public Label label136;
        public Label label137;
        public Label label138;
        public Label label140;
        public Label label139;
        private CheckBox CoachShowTeamBox;
        public Label label95;
        public System.Windows.Forms.ComboBox CoachFilter;
        public ListBox CoachListBox;
        public TabPage tabPlayers;
        public Label label206;
        private NumericUpDown PDIS;
        public Label label153;
        private System.Windows.Forms.ComboBox PHometownBox;
        public Label label203;
        private System.Windows.Forms.ComboBox PStateBox;
        private System.Windows.Forms.Button ResetPlayerPOSbutton;
        private GroupBox groupBox6;
        public System.Windows.Forms.TextBox PTEN;
        private Label label173;
        private System.Windows.Forms.TextBox PTHAtext;
        private NumericUpDown PIMPBox;
        private Label label63;
        private NumericUpDown PINJBox;
        private Label label64;
        private System.Windows.Forms.TextBox PKACtext;
        private NumericUpDown PSPDBox;
        private System.Windows.Forms.TextBox PKPRtext;
        private Label label65;
        private System.Windows.Forms.TextBox PTAKtext;
        private NumericUpDown PACCBox;
        private System.Windows.Forms.TextBox PPBKtext;
        private Label label66;
        private NumericUpDown PSTRBox;
        private System.Windows.Forms.TextBox PCARtext;
        private Label label70;
        private System.Windows.Forms.TextBox PCTHtext;
        private NumericUpDown PBTKBox;
        private System.Windows.Forms.TextBox PJMPtext;
        private Label label69;
        private NumericUpDown PTHPBox;
        private Label label68;
        private System.Windows.Forms.TextBox PAGItext;
        private NumericUpDown PRBKBox;
        private System.Windows.Forms.TextBox PAWRtext;
        private Label label67;
        private System.Windows.Forms.TextBox PPOEtext;
        private NumericUpDown PPOEBox;
        private System.Windows.Forms.TextBox PRBKtext;
        private Label label78;
        private System.Windows.Forms.TextBox PTHPtext;
        private NumericUpDown PAWRBox;
        private System.Windows.Forms.TextBox PBTKtext;
        private Label label77;
        private System.Windows.Forms.TextBox PSTRtext;
        private NumericUpDown PAGIBox;
        private System.Windows.Forms.TextBox PACCtext;
        private Label label76;
        private System.Windows.Forms.TextBox PSPDtext;
        private NumericUpDown PJMPBox;
        private System.Windows.Forms.TextBox PINJtext;
        private Label label75;
        private System.Windows.Forms.TextBox PIMPtext;
        private NumericUpDown PCTHBox;
        private Label label74;
        private NumericUpDown PCARBox;
        private Label label73;
        private NumericUpDown PTHABox;
        private Label label72;
        private NumericUpDown PPBKBox;
        private Label label71;
        private NumericUpDown PTAKBox;
        private Label label82;
        private NumericUpDown PKPRBox;
        private Label label81;
        private NumericUpDown PKACBox;
        private Label label79;
        private System.Windows.Forms.Button ImportPlayerTeam;
        private CheckBox AWHRBox;
        private System.Windows.Forms.Button PlayerTransferButton;
        private System.Windows.Forms.Button ExportPlayerTeam;
        private Label label167;
        public System.Windows.Forms.TextBox playerTeamBox;
        public System.Windows.Forms.TextBox PRST;
        public System.Windows.Forms.TextBox PGIDbox;
        public System.Windows.Forms.TextBox POVRbox;
        public System.Windows.Forms.TextBox PLNAtextBox;
        public System.Windows.Forms.TextBox PFNAtextBox;
        private System.Windows.Forms.ComboBox PPOSBox;
        public Label label62;
        public Label label151;
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
        public Label label61;
        public Label RosterSizeLabel;
        public Label label3;
        public System.Windows.Forms.ComboBox TGIDplayerBox;
        public ListBox PGIDlistBox;
        public Label label2;
        public Label label1;
        private GroupBox groupBox3;
        private Label label120;
        private System.Windows.Forms.ComboBox LeftWrist;
        private System.Windows.Forms.ComboBox LeftHand;
        private Label label117;
        private Label label118;
        private System.Windows.Forms.ComboBox LeftElbow;
        private System.Windows.Forms.ComboBox RightShoe;
        private Label label126;
        private System.Windows.Forms.ComboBox LeftShoe;
        private Label label116;
        private System.Windows.Forms.ComboBox NasalStrip;
        private Label label150;
        private Label label123;
        private System.Windows.Forms.ComboBox Helmet;
        private Label label149;
        private System.Windows.Forms.ComboBox Sleeves;
        private Label label148;
        private System.Windows.Forms.ComboBox Facemask;
        private Label label127;
        private Label label119;
        private System.Windows.Forms.ComboBox RightElbow;
        private Label label121;
        private Label label128;
        private System.Windows.Forms.ComboBox SleeveColor;
        private System.Windows.Forms.ComboBox RightWrist;
        private System.Windows.Forms.ComboBox EyeBlack;
        private Label label147;
        private Label label122;
        private System.Windows.Forms.ComboBox RightHand;
        private System.Windows.Forms.ComboBox Visor;
        private Label label125;
        private Label label124;
        private System.Windows.Forms.ComboBox NeckPad;
        private PictureBox pictureBox2;
        public TabPage tabTeams;
        private GroupBox groupBox15;
        private System.Windows.Forms.Button GenerateNewRosterButton;
        private System.Windows.Forms.Button DeathPenaltyButton;
        private GroupBox groupBox14;
        public System.Windows.Forms.TextBox TeamSTRating;
        public Label label210;
        private Label label181;
        public System.Windows.Forms.TextBox TeamDefRating;
        private NumericUpDown SDURnumbox;
        public Label label209;
        public Label label20;
        public System.Windows.Forms.TextBox TeamOffRating;
        public Label label21;
        public Label label208;
        public Label label35;
        public Label label34;
        public System.Windows.Forms.TextBox CoachPollBox;
        public Label label36;
        public System.Windows.Forms.TextBox SeasonRecordBox;
        public Label label37;
        public System.Windows.Forms.TextBox APPollBox;
        private NumericUpDown TMPRNumBox;
        public System.Windows.Forms.TextBox ConfRecordBox;
        private NumericUpDown TMARNumBox;
        private NumericUpDown INPOnumbox;
        public System.Windows.Forms.TextBox TeamOVRtextbox;
        private NumericUpDown NCDPnumbox;
        private NumericUpDown SNCTnumbox;
        public Label label29;
        public Label label28;
        public Label label30;
        public Label label31;
        public Label label19;
        private GroupBox groupBox13;
        private System.Windows.Forms.Button TeamColor2Button;
        private System.Windows.Forms.Button TeamColor1Button;
        private System.Windows.Forms.Button ResetPrimaryColorButton;
        private System.Windows.Forms.Button ResetSecondaryColorButton;
        public Label label8;
        private System.Windows.Forms.ComboBox CheerleaderBox;
        public Label label5;
        private System.Windows.Forms.ComboBox CrowdBox;
        private GroupBox groupBox12;
        public Label label224;
        public System.Windows.Forms.TextBox TeamStadRank;
        private System.Windows.Forms.ComboBox StateBox;
        public Label label55;
        public System.Windows.Forms.TextBox stadiumNameBox;
        public System.Windows.Forms.TextBox CityNameBox;
        public Label label56;
        public Label label57;
        public Label label60;
        public Label label59;
        private NumericUpDown AttendanceNumBox;
        private NumericUpDown CapacityNumbox;
        private GroupBox groupBox11;
        private System.Windows.Forms.Button TeamAutoImpact;
        private System.Windows.Forms.ComboBox ImpactTSI1Select;
        public Label label15;
        public Label label16;
        public Label label17;
        public Label label18;
        public Label label23;
        public Label label22;
        private System.Windows.Forms.ComboBox CaptainOffSelectBox;
        private System.Windows.Forms.ComboBox CaptainDefSelectBox;
        private System.Windows.Forms.ComboBox ImpactTSI2Select;
        private System.Windows.Forms.Button ResetImpactPlayersButton;
        private System.Windows.Forms.ComboBox ImpactTPIOSelect;
        public Label TeamRosterSizeLabel;
        private System.Windows.Forms.ComboBox ImpactTPIDSelect;
        private System.Windows.Forms.Button TeamSetDepthChart;
        public System.Windows.Forms.TextBox LeagueBox;
        public System.Windows.Forms.TextBox TSNAtextBox;
        public System.Windows.Forms.TextBox TeamDivisionBox;
        public System.Windows.Forms.TextBox TeamConferenceBox;
        public System.Windows.Forms.TextBox TGIDtextBox;
        public System.Windows.Forms.TextBox TMNAtextBox;
        public System.Windows.Forms.TextBox TDNAtextBox;
        public Label label27;
        public Label label26;
        public Label label25;
        public Label label24;
        public Label label11;
        public Label label10;
        public Label label9;
        public Label label7;
        public System.Windows.Forms.ComboBox CGIDcomboBox;
        public Label label6;
        public System.Windows.Forms.ComboBox LGIDcomboBox;
        public ListBox TGIDlistBox;
        private GroupBox groupBox10;
        private CheckBox UserCoachCheckBox;
        public Label label32;
        public Label label33;
        public Label label41;
        public Label label40;
        public Label label39;
        public Label label42;
        private NumericUpDown TeamCTPCNumber;
        private NumericUpDown TeamCRPCNumber;
        private NumericUpDown TeamHCPrestigeNumBox;
        public Label label43;
        private NumericUpDown TeamCCPONumBox;
        public Label label45;
        public Label label44;
        public Label label46;
        private System.Windows.Forms.ComboBox PlaybookSelectBox;
        public Label label48;
        private System.Windows.Forms.ComboBox DefTypeSelectBox;
        public Label label47;
        private System.Windows.Forms.ComboBox OffTypeSelectBox;
        private NumericUpDown TeamCOTRbox;
        private NumericUpDown TeamCOTAbox;
        public Label label49;
        private NumericUpDown TeamCOTSbox;
        public Label label52;
        public Label label51;
        private NumericUpDown TeamCDTRbox;
        private NumericUpDown TeamCDTAbox;
        public Label label50;
        private NumericUpDown TeamCDTSbox;
        public System.Windows.Forms.TextBox TeamCDPCBox;
        private System.Windows.Forms.Button FireCoachButton;
        public System.Windows.Forms.TextBox HCLastNameBox;
        public System.Windows.Forms.TextBox HCFirstNameBox;
        public TabPage tabDB;
        public DataGridView tableGridView;
        public DataGridView fieldsGridView;
        private TabPage tabHome;
        private GroupBox groupBox1;
        private RadioButton OGConfigRadio;
        private RadioButton NextConfigRadio;
        private PictureBox pictureBox1;
        public TabControl tabControl1;
        private TabPage tabPortal;
        private System.Windows.Forms.Button SpringPortalButton;
        private GroupBox groupBox31;
        private RadioButton PortalRandom;
        private RadioButton PortalFirst;
        private RadioButton PortalReverse;
        private GroupBox groupBox32;
        private NumericUpDown PortalOT;
        private Label label247;
        private NumericUpDown PortalTE;
        private Label label246;
        private NumericUpDown PortalWR;
        private Label label245;
        private NumericUpDown PortalFB;
        private Label label244;
        private NumericUpDown PortalHB;
        private Label label243;
        private NumericUpDown PortalQB;
        private Label label242;
        private NumericUpDown PortalK;
        private Label label258;
        private NumericUpDown PortalP;
        private Label label250;
        private NumericUpDown PortalSS;
        private Label label251;
        private NumericUpDown PortalFS;
        private Label label252;
        private NumericUpDown PortalCB;
        private Label label253;
        private NumericUpDown PortalMLB;
        private Label label254;
        private NumericUpDown PortalOLB;
        private Label label255;
        private NumericUpDown PortalDT;
        private Label label256;
        private NumericUpDown PortalDE;
        private Label label257;
        private NumericUpDown PortalOC;
        private Label label249;
        private NumericUpDown PortalOG;
        private Label label248;
        private RadioButton PortalSnake;
        private GroupBox groupBox33;
        private RadioButton largePortal;
        private RadioButton smallPortal;
        private Label label259;
        private NumericUpDown portalChance;
        private CheckBox PortalTransfers;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox3;
        private DataGridView PortalData;
        private Label TotalTransfersCount;
        private System.Windows.Forms.Button TransferPortalStats;
        private GroupBox groupBox34;
        private RadioButton TeamShowRanking;
        private RadioButton TeamShowNormal;
        private GroupBox groupBox35;
        private GroupBox groupBox36;
        private DataGridView CarouselDataGrid;
        private DataGridViewTextBoxColumn CCName;
        private DataGridViewTextBoxColumn CCStatus;
        private DataGridViewTextBoxColumn CCTeam;
        private DataGridViewTextBoxColumn CCTmPrestige;
        private DataGridViewTextBoxColumn CCPrestige;
        private DataGridViewTextBoxColumn CCRecord;
        private GroupBox groupBox37;
        public System.Windows.Forms.Button ResetDynYear;
        private CheckBox ReRankTeamsAP;
        private GroupBox groupBox39;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.ComboBox GTransferNew;
        private Label label261;
        private System.Windows.Forms.ComboBox GTransferOG;
        private Label label260;
        private System.Windows.Forms.Button GlobalTransferInterest;
        private RadioButton GTransferRecruitable;
        private RadioButton GTransferCommitted;
        private Label CoachFiringsCount;
        private CheckBox TransferEligible;
        private CheckBox PortalRatingBoost;
        private System.Windows.Forms.ToolTip toolTip1;
        private DataGridViewTextBoxColumn PortalPosition;
        private DataGridViewTextBoxColumn PortalTransferName;
        private DataGridViewTextBoxColumn PortalClass;
        private DataGridViewTextBoxColumn PortalRating;
        private DataGridViewTextBoxColumn PortalNewSchool;
        private DataGridViewTextBoxColumn PortalPrvTeam;
        private DataGridViewTextBoxColumn SCHDWeek;
        private DataGridViewTextBoxColumn SCHDHOME;
        private DataGridViewTextBoxColumn SCHDScoreH;
        private DataGridViewTextBoxColumn SCHDVS;
        private DataGridViewTextBoxColumn SCHDAWAY;
        private DataGridViewTextBoxColumn SCHDScoreA;
        public System.Windows.Forms.Button FixHometownButton;
        private GroupBox groupBox38;
        private NumericUpDown MaxFantasyPlayers;
        private Label label262;
        public System.Windows.Forms.Button buttonAutoDepthChart;
        public System.Windows.Forms.Button ClearExpiredStats;
        public System.Windows.Forms.Button buttonFantasyRoster;
        private GroupBox groupBox22;
        private RadioButton FantasyCSV;
        private RadioButton FantasyTeamDB;
        public System.Windows.Forms.Button buttonFillRosters;
        private NumericUpDown FillRosterPCT;
        private Label label58;
        public System.Windows.Forms.Button FantasyCoachesButton;
        public System.Windows.Forms.Button buttonRandPotential;
        public System.Windows.Forms.Button RandomizeHeadButton;
        public System.Windows.Forms.Button bodyFix;
        public System.Windows.Forms.Button buttonCalcOverall;
        private RadioButton FBSroster;
        private RadioButton radioButton1;
        private GroupBox DepthChartSize;
        private RadioButton DC88;
        private RadioButton DC77;
        private Panel FantastyRosterLeague;
        private Label label263;
        private GroupBox groupBox40;
        private RadioButton DC136;
        private RadioButton DC120;
        private System.Windows.Forms.Button GrassToTurf;
        private NumericUpDown MaxBodyValue;
        private Label label264;
        private Label label265;
        private System.Windows.Forms.ComboBox MinBodyType;
        private Label label266;
        private System.Windows.Forms.ComboBox MaxBodyPos;
        private NumericUpDown MinBodyValue;
        private System.Windows.Forms.ComboBox MinBodyPos;
        private System.Windows.Forms.ComboBox MaxBodyType;
        private Label label267;
        private System.Windows.Forms.Button UpdateMaxBody;
        private System.Windows.Forms.Button UpdateMinBody;
    }
}

