using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DB_EDITOR
{
    partial class LeagueMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.CustomLeagueToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.importCustomLeagueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportCustomLeague = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabConf = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radio126 = new System.Windows.Forms.RadioButton();
            this.radio120 = new System.Windows.Forms.RadioButton();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.ClearLeagueButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.LeagueTeamsLabel = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown7 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown8 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown11 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown12 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AllTeamsListBox = new System.Windows.Forms.ListBox();
            this.confName12 = new System.Windows.Forms.TextBox();
            this.confName11 = new System.Windows.Forms.TextBox();
            this.confName10 = new System.Windows.Forms.TextBox();
            this.confName9 = new System.Windows.Forms.TextBox();
            this.confName8 = new System.Windows.Forms.TextBox();
            this.confName7 = new System.Windows.Forms.TextBox();
            this.confName6 = new System.Windows.Forms.TextBox();
            this.confName5 = new System.Windows.Forms.TextBox();
            this.confName4 = new System.Windows.Forms.TextBox();
            this.confName3 = new System.Windows.Forms.TextBox();
            this.confName2 = new System.Windows.Forms.TextBox();
            this.confName1 = new System.Windows.Forms.TextBox();
            this.labelTeamSelection = new System.Windows.Forms.Label();
            this.DeselectButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.TeamSelectionBox = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.TeamsPerConfBox = new System.Windows.Forms.ComboBox();
            this.RandomizeLeagueButton = new System.Windows.Forms.Button();
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.fieldsGridView = new System.Windows.Forms.DataGridView();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OGConfigRadio = new System.Windows.Forms.RadioButton();
            this.NextConfigRadio = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAnnuals = new System.Windows.Forms.TabPage();
            this.ClearAllButton = new System.Windows.Forms.Button();
            this.SaveSANNButton = new System.Windows.Forms.Button();
            this.DeleteGameButton = new System.Windows.Forms.Button();
            this.AnnualsGrid = new System.Windows.Forms.DataGridView();
            this.tabCChamps = new System.Windows.Forms.TabPage();
            this.label37 = new System.Windows.Forms.Label();
            this.SaveChamps = new System.Windows.Forms.Button();
            this.ChampGrid = new System.Windows.Forms.DataGridView();
            this.Conf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bowl = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabBowls = new System.Windows.Forms.TabPage();
            this.AtLargeButton = new System.Windows.Forms.Button();
            this.SaveBowlButton = new System.Windows.Forms.Button();
            this.DeleteBowlButton = new System.Windows.Forms.Button();
            this.BowlsGrid = new System.Windows.Forms.DataGridView();
            this.BIDX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BNME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BCI1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BCR1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BCI2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BCR2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SGID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BMON = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.BDAY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.radio136 = new System.Windows.Forms.RadioButton();
            this.mainMenu.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.fieldMenu.SuspendLayout();
            this.TablePropsgroupBox.SuspendLayout();
            this.FieldsPropsgroupBox.SuspendLayout();
            this.tabConf.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).BeginInit();
            this.tabHome.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAnnuals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AnnualsGrid)).BeginInit();
            this.tabCChamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChampGrid)).BeginInit();
            this.tabBowls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BowlsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.CSVMenuItem,
            this.optionsMenuItem,
            this.CustomLeagueToolStrip,
            this.aboutMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1190, 24);
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
            this.tableFieldOrderMenuItem});
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
            this.tableFieldOrderMenuItem.Size = new System.Drawing.Size(163, 22);
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
            // CustomLeagueToolStrip
            // 
            this.CustomLeagueToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCustomLeagueToolStripMenuItem,
            this.ExportCustomLeague});
            this.CustomLeagueToolStrip.Name = "CustomLeagueToolStrip";
            this.CustomLeagueToolStrip.Size = new System.Drawing.Size(102, 20);
            this.CustomLeagueToolStrip.Text = "Custom League";
            // 
            // importCustomLeagueToolStripMenuItem
            // 
            this.importCustomLeagueToolStripMenuItem.Name = "importCustomLeagueToolStripMenuItem";
            this.importCustomLeagueToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.importCustomLeagueToolStripMenuItem.Text = "Import Custom League";
            this.importCustomLeagueToolStripMenuItem.Click += new System.EventHandler(this.importCustomLeagueToolStripMenuItem_Click);
            // 
            // ExportCustomLeague
            // 
            this.ExportCustomLeague.Name = "ExportCustomLeague";
            this.ExportCustomLeague.Size = new System.Drawing.Size(196, 22);
            this.ExportCustomLeague.Text = "Export Custom League";
            this.ExportCustomLeague.Click += new System.EventHandler(this.ExportCustomLeague_Click);
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
            this.progressBar1.Location = new System.Drawing.Point(974, 932);
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
            this.TablePropsgroupBox.Location = new System.Drawing.Point(19, 925);
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
            this.FieldsPropsgroupBox.Location = new System.Drawing.Point(367, 925);
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
            // tabConf
            // 
            this.tabConf.AutoScroll = true;
            this.tabConf.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tabConf.Controls.Add(this.groupBox2);
            this.tabConf.Controls.Add(this.label31);
            this.tabConf.Controls.Add(this.label32);
            this.tabConf.Controls.Add(this.label33);
            this.tabConf.Controls.Add(this.label34);
            this.tabConf.Controls.Add(this.label35);
            this.tabConf.Controls.Add(this.label36);
            this.tabConf.Controls.Add(this.label30);
            this.tabConf.Controls.Add(this.label29);
            this.tabConf.Controls.Add(this.label28);
            this.tabConf.Controls.Add(this.label27);
            this.tabConf.Controls.Add(this.label26);
            this.tabConf.Controls.Add(this.label25);
            this.tabConf.Controls.Add(this.ClearLeagueButton);
            this.tabConf.Controls.Add(this.RemoveButton);
            this.tabConf.Controls.Add(this.LeagueTeamsLabel);
            this.tabConf.Controls.Add(this.AddButton);
            this.tabConf.Controls.Add(this.label19);
            this.tabConf.Controls.Add(this.label20);
            this.tabConf.Controls.Add(this.label21);
            this.tabConf.Controls.Add(this.label22);
            this.tabConf.Controls.Add(this.label23);
            this.tabConf.Controls.Add(this.label24);
            this.tabConf.Controls.Add(this.label17);
            this.tabConf.Controls.Add(this.label18);
            this.tabConf.Controls.Add(this.label15);
            this.tabConf.Controls.Add(this.label16);
            this.tabConf.Controls.Add(this.label14);
            this.tabConf.Controls.Add(this.label13);
            this.tabConf.Controls.Add(this.numericUpDown7);
            this.tabConf.Controls.Add(this.numericUpDown8);
            this.tabConf.Controls.Add(this.numericUpDown9);
            this.tabConf.Controls.Add(this.numericUpDown10);
            this.tabConf.Controls.Add(this.numericUpDown11);
            this.tabConf.Controls.Add(this.numericUpDown12);
            this.tabConf.Controls.Add(this.numericUpDown6);
            this.tabConf.Controls.Add(this.numericUpDown5);
            this.tabConf.Controls.Add(this.numericUpDown4);
            this.tabConf.Controls.Add(this.numericUpDown3);
            this.tabConf.Controls.Add(this.numericUpDown2);
            this.tabConf.Controls.Add(this.numericUpDown1);
            this.tabConf.Controls.Add(this.button7);
            this.tabConf.Controls.Add(this.button8);
            this.tabConf.Controls.Add(this.button9);
            this.tabConf.Controls.Add(this.button10);
            this.tabConf.Controls.Add(this.button11);
            this.tabConf.Controls.Add(this.button12);
            this.tabConf.Controls.Add(this.button6);
            this.tabConf.Controls.Add(this.button5);
            this.tabConf.Controls.Add(this.button4);
            this.tabConf.Controls.Add(this.button3);
            this.tabConf.Controls.Add(this.button2);
            this.tabConf.Controls.Add(this.button1);
            this.tabConf.Controls.Add(this.label8);
            this.tabConf.Controls.Add(this.label9);
            this.tabConf.Controls.Add(this.label10);
            this.tabConf.Controls.Add(this.label11);
            this.tabConf.Controls.Add(this.label12);
            this.tabConf.Controls.Add(this.label7);
            this.tabConf.Controls.Add(this.label6);
            this.tabConf.Controls.Add(this.label5);
            this.tabConf.Controls.Add(this.label4);
            this.tabConf.Controls.Add(this.label3);
            this.tabConf.Controls.Add(this.label2);
            this.tabConf.Controls.Add(this.label1);
            this.tabConf.Controls.Add(this.AllTeamsListBox);
            this.tabConf.Controls.Add(this.confName12);
            this.tabConf.Controls.Add(this.confName11);
            this.tabConf.Controls.Add(this.confName10);
            this.tabConf.Controls.Add(this.confName9);
            this.tabConf.Controls.Add(this.confName8);
            this.tabConf.Controls.Add(this.confName7);
            this.tabConf.Controls.Add(this.confName6);
            this.tabConf.Controls.Add(this.confName5);
            this.tabConf.Controls.Add(this.confName4);
            this.tabConf.Controls.Add(this.confName3);
            this.tabConf.Controls.Add(this.confName2);
            this.tabConf.Controls.Add(this.confName1);
            this.tabConf.Controls.Add(this.labelTeamSelection);
            this.tabConf.Controls.Add(this.DeselectButton);
            this.tabConf.Controls.Add(this.SaveButton);
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
            this.tabConf.Controls.Add(this.panel1);
            this.tabConf.Location = new System.Drawing.Point(4, 24);
            this.tabConf.Name = "tabConf";
            this.tabConf.Padding = new System.Windows.Forms.Padding(3);
            this.tabConf.Size = new System.Drawing.Size(1158, 1022);
            this.tabConf.TabIndex = 9;
            this.tabConf.Text = "Conferences";
            this.tabConf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radio136);
            this.groupBox2.Controls.Add(this.radio126);
            this.groupBox2.Controls.Add(this.radio120);
            this.groupBox2.Location = new System.Drawing.Point(642, 839);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 51);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "League Team Count";
            // 
            // radio126
            // 
            this.radio126.AutoSize = true;
            this.radio126.Location = new System.Drawing.Point(91, 19);
            this.radio126.Name = "radio126";
            this.radio126.Size = new System.Drawing.Size(78, 17);
            this.radio126.TabIndex = 1;
            this.radio126.Text = "126 Teams";
            this.radio126.UseVisualStyleBackColor = true;
            // 
            // radio120
            // 
            this.radio120.AutoSize = true;
            this.radio120.Checked = true;
            this.radio120.Location = new System.Drawing.Point(7, 20);
            this.radio120.Name = "radio120";
            this.radio120.Size = new System.Drawing.Size(78, 17);
            this.radio120.TabIndex = 0;
            this.radio120.TabStop = true;
            this.radio120.Text = "120 Teams";
            this.radio120.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.LightCoral;
            this.label31.Location = new System.Drawing.Point(21, 432);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(104, 13);
            this.label31.TabIndex = 108;
            this.label31.Text = "Count: XX  Valid: No";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.LightCoral;
            this.label32.Location = new System.Drawing.Point(177, 432);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(104, 13);
            this.label32.TabIndex = 107;
            this.label32.Text = "Count: XX  Valid: No";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.LightCoral;
            this.label33.Location = new System.Drawing.Point(331, 432);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(104, 13);
            this.label33.TabIndex = 106;
            this.label33.Text = "Count: XX  Valid: No";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.LightCoral;
            this.label34.Location = new System.Drawing.Point(487, 432);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(104, 13);
            this.label34.TabIndex = 105;
            this.label34.Text = "Count: XX  Valid: No";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.LightCoral;
            this.label35.Location = new System.Drawing.Point(645, 432);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(104, 13);
            this.label35.TabIndex = 104;
            this.label35.Text = "Count: XX  Valid: No";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.LightCoral;
            this.label36.Location = new System.Drawing.Point(801, 432);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(104, 13);
            this.label36.TabIndex = 103;
            this.label36.Text = "Count: XX  Valid: No";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.LightCoral;
            this.label30.Location = new System.Drawing.Point(802, 33);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(104, 13);
            this.label30.TabIndex = 102;
            this.label30.Text = "Count: XX  Valid: No";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.LightCoral;
            this.label29.Location = new System.Drawing.Point(646, 33);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(104, 13);
            this.label29.TabIndex = 101;
            this.label29.Text = "Count: XX  Valid: No";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.LightCoral;
            this.label28.Location = new System.Drawing.Point(488, 33);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(104, 13);
            this.label28.TabIndex = 100;
            this.label28.Text = "Count: XX  Valid: No";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.LightCoral;
            this.label27.Location = new System.Drawing.Point(332, 33);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(104, 13);
            this.label27.TabIndex = 99;
            this.label27.Text = "Count: XX  Valid: No";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.LightCoral;
            this.label26.Location = new System.Drawing.Point(176, 33);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(104, 13);
            this.label26.TabIndex = 98;
            this.label26.Text = "Count: XX  Valid: No";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.LightCoral;
            this.label25.Location = new System.Drawing.Point(19, 33);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(104, 13);
            this.label25.TabIndex = 97;
            this.label25.Text = "Count: XX  Valid: No";
            // 
            // ClearLeagueButton
            // 
            this.ClearLeagueButton.BackColor = System.Drawing.Color.SlateBlue;
            this.ClearLeagueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLeagueButton.ForeColor = System.Drawing.SystemColors.Control;
            this.ClearLeagueButton.Location = new System.Drawing.Point(975, 3);
            this.ClearLeagueButton.Name = "ClearLeagueButton";
            this.ClearLeagueButton.Size = new System.Drawing.Size(161, 25);
            this.ClearLeagueButton.TabIndex = 96;
            this.ClearLeagueButton.Text = "CLEAR LEAGUE";
            this.ClearLeagueButton.UseVisualStyleBackColor = false;
            this.ClearLeagueButton.Click += new System.EventHandler(this.ClearLeagueButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.BackColor = System.Drawing.Color.SlateBlue;
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.ForeColor = System.Drawing.SystemColors.Control;
            this.RemoveButton.Location = new System.Drawing.Point(975, 720);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(161, 37);
            this.RemoveButton.TabIndex = 95;
            this.RemoveButton.Text = "REMOVE TEAM";
            this.RemoveButton.UseVisualStyleBackColor = false;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // LeagueTeamsLabel
            // 
            this.LeagueTeamsLabel.AutoSize = true;
            this.LeagueTeamsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LeagueTeamsLabel.Location = new System.Drawing.Point(6, 3);
            this.LeagueTeamsLabel.Name = "LeagueTeamsLabel";
            this.LeagueTeamsLabel.Size = new System.Drawing.Size(118, 18);
            this.LeagueTeamsLabel.TabIndex = 94;
            this.LeagueTeamsLabel.Text = "League Teams";
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.SystemColors.Control;
            this.AddButton.Location = new System.Drawing.Point(975, 677);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(161, 37);
            this.AddButton.TabIndex = 93;
            this.AddButton.Text = "ADD TEAM";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(859, 797);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 13);
            this.label19.TabIndex = 92;
            this.label19.Text = "Prestige:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(701, 797);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 91;
            this.label20.Text = "Prestige:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(543, 797);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 90;
            this.label21.Text = "Prestige:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(387, 797);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(48, 13);
            this.label22.TabIndex = 89;
            this.label22.Text = "Prestige:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(233, 797);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 13);
            this.label23.TabIndex = 88;
            this.label23.Text = "Prestige:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(77, 797);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 13);
            this.label24.TabIndex = 87;
            this.label24.Text = "Prestige:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(861, 398);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 86;
            this.label17.Text = "Prestige:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(703, 398);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 13);
            this.label18.TabIndex = 85;
            this.label18.Text = "Prestige:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(545, 398);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 84;
            this.label15.Text = "Prestige:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(389, 398);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 83;
            this.label16.Text = "Prestige:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(235, 398);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 82;
            this.label14.Text = "Prestige:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(79, 398);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 81;
            this.label13.Text = "Prestige:";
            // 
            // numericUpDown7
            // 
            this.numericUpDown7.Location = new System.Drawing.Point(126, 794);
            this.numericUpDown7.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown7.Name = "numericUpDown7";
            this.numericUpDown7.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown7.TabIndex = 80;
            // 
            // numericUpDown8
            // 
            this.numericUpDown8.Location = new System.Drawing.Point(281, 794);
            this.numericUpDown8.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown8.Name = "numericUpDown8";
            this.numericUpDown8.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown8.TabIndex = 79;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Location = new System.Drawing.Point(438, 794);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown9.TabIndex = 78;
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Location = new System.Drawing.Point(592, 794);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown10.TabIndex = 77;
            // 
            // numericUpDown11
            // 
            this.numericUpDown11.Location = new System.Drawing.Point(748, 794);
            this.numericUpDown11.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown11.Name = "numericUpDown11";
            this.numericUpDown11.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown11.TabIndex = 76;
            // 
            // numericUpDown12
            // 
            this.numericUpDown12.Location = new System.Drawing.Point(907, 794);
            this.numericUpDown12.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown12.Name = "numericUpDown12";
            this.numericUpDown12.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown12.TabIndex = 75;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(911, 395);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown6.TabIndex = 74;
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(752, 395);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown5.TabIndex = 73;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(596, 395);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown4.TabIndex = 72;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(440, 395);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown3.TabIndex = 71;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(285, 395);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown2.TabIndex = 70;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(128, 395);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 69;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightBlue;
            this.button7.Location = new System.Drawing.Point(124, 457);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(43, 23);
            this.button7.TabIndex = 68;
            this.button7.Text = "FBS";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightBlue;
            this.button8.Location = new System.Drawing.Point(281, 457);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(43, 23);
            this.button8.TabIndex = 67;
            this.button8.Text = "FBS";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightBlue;
            this.button9.Location = new System.Drawing.Point(436, 457);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(43, 23);
            this.button9.TabIndex = 66;
            this.button9.Text = "FBS";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.LightBlue;
            this.button10.Location = new System.Drawing.Point(592, 457);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(43, 23);
            this.button10.TabIndex = 65;
            this.button10.Text = "FBS";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.LightBlue;
            this.button11.Location = new System.Drawing.Point(749, 457);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(43, 23);
            this.button11.TabIndex = 64;
            this.button11.Text = "FBS";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.LightBlue;
            this.button12.Location = new System.Drawing.Point(904, 457);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(43, 23);
            this.button12.TabIndex = 63;
            this.button12.Text = "FBS";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightBlue;
            this.button6.Location = new System.Drawing.Point(905, 59);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(43, 23);
            this.button6.TabIndex = 62;
            this.button6.Text = "FBS";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightBlue;
            this.button5.Location = new System.Drawing.Point(749, 59);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(43, 23);
            this.button5.TabIndex = 61;
            this.button5.Text = "FBS";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightBlue;
            this.button4.Location = new System.Drawing.Point(593, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 23);
            this.button4.TabIndex = 60;
            this.button4.Text = "FBS";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightBlue;
            this.button3.Location = new System.Drawing.Point(437, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 23);
            this.button3.TabIndex = 59;
            this.button3.Text = "FBS";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightBlue;
            this.button2.Location = new System.Drawing.Point(282, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 58;
            this.button2.Text = "FBS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(125, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 57;
            this.button1.Text = "FBS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.LeagueChange_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 796);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "cgid";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 796);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 55;
            this.label9.Text = "cgid";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(483, 796);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 54;
            this.label10.Text = "cgid";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(639, 796);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 53;
            this.label11.Text = "cgid";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(795, 796);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "cgid";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 796);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "cgid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(799, 397);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "cgid";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(643, 397);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "cgid";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 397);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "cgid";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 397);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "cgid";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "cgid";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "cgid";
            // 
            // AllTeamsListBox
            // 
            this.AllTeamsListBox.AllowDrop = true;
            this.AllTeamsListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.AllTeamsListBox.FormattingEnabled = true;
            this.AllTeamsListBox.Location = new System.Drawing.Point(975, 59);
            this.AllTeamsListBox.Name = "AllTeamsListBox";
            this.AllTeamsListBox.Size = new System.Drawing.Size(161, 615);
            this.AllTeamsListBox.TabIndex = 44;
            this.AllTeamsListBox.SelectedIndexChanged += new System.EventHandler(this.AllTeamsListBox_SelectedIndexChanged);
            this.AllTeamsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseClick_AddTeam);
            // 
            // confName12
            // 
            this.confName12.Location = new System.Drawing.Point(798, 460);
            this.confName12.MaxLength = 31;
            this.confName12.Name = "confName12";
            this.confName12.Size = new System.Drawing.Size(100, 20);
            this.confName12.TabIndex = 43;
            // 
            // confName11
            // 
            this.confName11.Location = new System.Drawing.Point(642, 460);
            this.confName11.MaxLength = 31;
            this.confName11.Name = "confName11";
            this.confName11.Size = new System.Drawing.Size(100, 20);
            this.confName11.TabIndex = 42;
            // 
            // confName10
            // 
            this.confName10.Location = new System.Drawing.Point(486, 460);
            this.confName10.MaxLength = 31;
            this.confName10.Name = "confName10";
            this.confName10.Size = new System.Drawing.Size(100, 20);
            this.confName10.TabIndex = 41;
            // 
            // confName9
            // 
            this.confName9.Location = new System.Drawing.Point(330, 460);
            this.confName9.MaxLength = 31;
            this.confName9.Name = "confName9";
            this.confName9.Size = new System.Drawing.Size(100, 20);
            this.confName9.TabIndex = 40;
            // 
            // confName8
            // 
            this.confName8.Location = new System.Drawing.Point(174, 460);
            this.confName8.MaxLength = 31;
            this.confName8.Name = "confName8";
            this.confName8.Size = new System.Drawing.Size(100, 20);
            this.confName8.TabIndex = 39;
            // 
            // confName7
            // 
            this.confName7.Location = new System.Drawing.Point(18, 460);
            this.confName7.MaxLength = 31;
            this.confName7.Name = "confName7";
            this.confName7.Size = new System.Drawing.Size(100, 20);
            this.confName7.TabIndex = 38;
            // 
            // confName6
            // 
            this.confName6.Location = new System.Drawing.Point(799, 59);
            this.confName6.MaxLength = 31;
            this.confName6.Name = "confName6";
            this.confName6.Size = new System.Drawing.Size(100, 20);
            this.confName6.TabIndex = 37;
            // 
            // confName5
            // 
            this.confName5.Location = new System.Drawing.Point(643, 59);
            this.confName5.MaxLength = 31;
            this.confName5.Name = "confName5";
            this.confName5.Size = new System.Drawing.Size(100, 20);
            this.confName5.TabIndex = 36;
            // 
            // confName4
            // 
            this.confName4.Location = new System.Drawing.Point(487, 59);
            this.confName4.MaxLength = 31;
            this.confName4.Name = "confName4";
            this.confName4.Size = new System.Drawing.Size(100, 20);
            this.confName4.TabIndex = 35;
            // 
            // confName3
            // 
            this.confName3.Location = new System.Drawing.Point(331, 59);
            this.confName3.MaxLength = 31;
            this.confName3.Name = "confName3";
            this.confName3.Size = new System.Drawing.Size(100, 20);
            this.confName3.TabIndex = 34;
            // 
            // confName2
            // 
            this.confName2.Location = new System.Drawing.Point(175, 59);
            this.confName2.MaxLength = 31;
            this.confName2.Name = "confName2";
            this.confName2.Size = new System.Drawing.Size(100, 20);
            this.confName2.TabIndex = 33;
            // 
            // confName1
            // 
            this.confName1.Location = new System.Drawing.Point(19, 59);
            this.confName1.MaxLength = 31;
            this.confName1.Name = "confName1";
            this.confName1.Size = new System.Drawing.Size(100, 20);
            this.confName1.TabIndex = 32;
            // 
            // labelTeamSelection
            // 
            this.labelTeamSelection.AllowDrop = true;
            this.labelTeamSelection.AutoSize = true;
            this.labelTeamSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTeamSelection.Location = new System.Drawing.Point(972, 40);
            this.labelTeamSelection.Name = "labelTeamSelection";
            this.labelTeamSelection.Size = new System.Drawing.Size(116, 16);
            this.labelTeamSelection.TabIndex = 30;
            this.labelTeamSelection.Text = "Team Selection";
            // 
            // DeselectButton
            // 
            this.DeselectButton.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.DeselectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeselectButton.Location = new System.Drawing.Point(975, 763);
            this.DeselectButton.Name = "DeselectButton";
            this.DeselectButton.Size = new System.Drawing.Size(161, 37);
            this.DeselectButton.TabIndex = 25;
            this.DeselectButton.Text = "DESELECT TEAM";
            this.DeselectButton.UseVisualStyleBackColor = false;
            this.DeselectButton.Click += new System.EventHandler(this.DeselectTeamsButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Crimson;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SaveButton.Location = new System.Drawing.Point(975, 808);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(161, 37);
            this.SaveButton.TabIndex = 24;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Cick);
            // 
            // conf12
            // 
            this.conf12.AllowDrop = true;
            this.conf12.BackColor = System.Drawing.Color.Gainsboro;
            this.conf12.CheckOnClick = true;
            this.conf12.FormattingEnabled = true;
            this.conf12.Location = new System.Drawing.Point(798, 486);
            this.conf12.Name = "conf12";
            this.conf12.Size = new System.Drawing.Size(150, 304);
            this.conf12.TabIndex = 11;
            this.conf12.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf12.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf11
            // 
            this.conf11.AllowDrop = true;
            this.conf11.BackColor = System.Drawing.Color.Gainsboro;
            this.conf11.CheckOnClick = true;
            this.conf11.FormattingEnabled = true;
            this.conf11.Location = new System.Drawing.Point(642, 486);
            this.conf11.Name = "conf11";
            this.conf11.Size = new System.Drawing.Size(150, 304);
            this.conf11.TabIndex = 10;
            this.conf11.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf11.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf10
            // 
            this.conf10.AllowDrop = true;
            this.conf10.BackColor = System.Drawing.Color.Gainsboro;
            this.conf10.CheckOnClick = true;
            this.conf10.FormattingEnabled = true;
            this.conf10.Location = new System.Drawing.Point(486, 486);
            this.conf10.Name = "conf10";
            this.conf10.Size = new System.Drawing.Size(150, 304);
            this.conf10.TabIndex = 9;
            this.conf10.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf10.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf10.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf9
            // 
            this.conf9.AllowDrop = true;
            this.conf9.BackColor = System.Drawing.Color.Gainsboro;
            this.conf9.CheckOnClick = true;
            this.conf9.FormattingEnabled = true;
            this.conf9.Location = new System.Drawing.Point(330, 486);
            this.conf9.Name = "conf9";
            this.conf9.Size = new System.Drawing.Size(150, 304);
            this.conf9.TabIndex = 8;
            this.conf9.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf9.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf8
            // 
            this.conf8.AllowDrop = true;
            this.conf8.BackColor = System.Drawing.Color.Gainsboro;
            this.conf8.CheckOnClick = true;
            this.conf8.FormattingEnabled = true;
            this.conf8.Location = new System.Drawing.Point(174, 486);
            this.conf8.Name = "conf8";
            this.conf8.Size = new System.Drawing.Size(150, 304);
            this.conf8.TabIndex = 7;
            this.conf8.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf8.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf7
            // 
            this.conf7.AllowDrop = true;
            this.conf7.BackColor = System.Drawing.Color.Gainsboro;
            this.conf7.CheckOnClick = true;
            this.conf7.FormattingEnabled = true;
            this.conf7.Location = new System.Drawing.Point(18, 486);
            this.conf7.Name = "conf7";
            this.conf7.Size = new System.Drawing.Size(150, 304);
            this.conf7.TabIndex = 6;
            this.conf7.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf7.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf6
            // 
            this.conf6.AllowDrop = true;
            this.conf6.BackColor = System.Drawing.Color.Gainsboro;
            this.conf6.CheckOnClick = true;
            this.conf6.FormattingEnabled = true;
            this.conf6.Location = new System.Drawing.Point(799, 85);
            this.conf6.Name = "conf6";
            this.conf6.Size = new System.Drawing.Size(150, 304);
            this.conf6.TabIndex = 5;
            this.conf6.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf5
            // 
            this.conf5.AllowDrop = true;
            this.conf5.BackColor = System.Drawing.Color.Gainsboro;
            this.conf5.CheckOnClick = true;
            this.conf5.FormattingEnabled = true;
            this.conf5.Location = new System.Drawing.Point(643, 85);
            this.conf5.Name = "conf5";
            this.conf5.Size = new System.Drawing.Size(150, 304);
            this.conf5.TabIndex = 4;
            this.conf5.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf4
            // 
            this.conf4.AllowDrop = true;
            this.conf4.BackColor = System.Drawing.Color.Gainsboro;
            this.conf4.CheckOnClick = true;
            this.conf4.FormattingEnabled = true;
            this.conf4.Location = new System.Drawing.Point(487, 85);
            this.conf4.Name = "conf4";
            this.conf4.Size = new System.Drawing.Size(150, 304);
            this.conf4.TabIndex = 3;
            this.conf4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf3
            // 
            this.conf3.AllowDrop = true;
            this.conf3.BackColor = System.Drawing.Color.Gainsboro;
            this.conf3.CheckOnClick = true;
            this.conf3.FormattingEnabled = true;
            this.conf3.Location = new System.Drawing.Point(331, 85);
            this.conf3.Name = "conf3";
            this.conf3.Size = new System.Drawing.Size(150, 304);
            this.conf3.TabIndex = 2;
            this.conf3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf2
            // 
            this.conf2.AllowDrop = true;
            this.conf2.BackColor = System.Drawing.Color.Gainsboro;
            this.conf2.CheckOnClick = true;
            this.conf2.FormattingEnabled = true;
            this.conf2.Location = new System.Drawing.Point(175, 85);
            this.conf2.Name = "conf2";
            this.conf2.Size = new System.Drawing.Size(150, 304);
            this.conf2.TabIndex = 1;
            this.conf2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // conf1
            // 
            this.conf1.AllowDrop = true;
            this.conf1.BackColor = System.Drawing.Color.Gainsboro;
            this.conf1.CheckOnClick = true;
            this.conf1.FormattingEnabled = true;
            this.conf1.Location = new System.Drawing.Point(19, 85);
            this.conf1.Name = "conf1";
            this.conf1.Size = new System.Drawing.Size(150, 304);
            this.conf1.TabIndex = 0;
            this.conf1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            this.conf1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.conf1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.panel1.Controls.Add(this.label39);
            this.panel1.Controls.Add(this.TeamSelectionBox);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.TeamsPerConfBox);
            this.panel1.Controls.Add(this.RandomizeLeagueButton);
            this.panel1.Location = new System.Drawing.Point(18, 841);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 59);
            this.panel1.TabIndex = 110;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(307, 12);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(81, 13);
            this.label39.TabIndex = 113;
            this.label39.Text = "Team Selection";
            // 
            // TeamSelectionBox
            // 
            this.TeamSelectionBox.FormattingEnabled = true;
            this.TeamSelectionBox.Items.AddRange(new object[] {
            "FBS Only",
            "FCS Only",
            "Any Team"});
            this.TeamSelectionBox.Location = new System.Drawing.Point(312, 28);
            this.TeamSelectionBox.Name = "TeamSelectionBox";
            this.TeamSelectionBox.Size = new System.Drawing.Size(121, 21);
            this.TeamSelectionBox.TabIndex = 112;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(198, 12);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(82, 13);
            this.label38.TabIndex = 111;
            this.label38.Text = "Teams per Conf";
            // 
            // TeamsPerConfBox
            // 
            this.TeamsPerConfBox.FormattingEnabled = true;
            this.TeamsPerConfBox.Items.AddRange(new object[] {
            "10",
            "12",
            "20"});
            this.TeamsPerConfBox.Location = new System.Drawing.Point(196, 28);
            this.TeamsPerConfBox.Name = "TeamsPerConfBox";
            this.TeamsPerConfBox.Size = new System.Drawing.Size(79, 21);
            this.TeamsPerConfBox.Sorted = true;
            this.TeamsPerConfBox.TabIndex = 110;
            // 
            // RandomizeLeagueButton
            // 
            this.RandomizeLeagueButton.BackColor = System.Drawing.Color.Navy;
            this.RandomizeLeagueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomizeLeagueButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.RandomizeLeagueButton.Location = new System.Drawing.Point(9, 11);
            this.RandomizeLeagueButton.Name = "RandomizeLeagueButton";
            this.RandomizeLeagueButton.Size = new System.Drawing.Size(161, 37);
            this.RandomizeLeagueButton.TabIndex = 109;
            this.RandomizeLeagueButton.Text = "Randomize League";
            this.RandomizeLeagueButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.RandomizeLeagueButton.UseVisualStyleBackColor = false;
            this.RandomizeLeagueButton.Click += new System.EventHandler(this.RandomizeLeagueButton_Click);
            // 
            // tabDB
            // 
            this.tabDB.BackColor = System.Drawing.SystemColors.Control;
            this.tabDB.Controls.Add(this.tableGridView);
            this.tabDB.Controls.Add(this.fieldsGridView);
            this.tabDB.Location = new System.Drawing.Point(4, 24);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(1158, 1022);
            this.tabDB.TabIndex = 0;
            this.tabDB.Text = "DB Editor";
            // 
            // tableGridView
            // 
            this.tableGridView.AllowUserToAddRows = false;
            this.tableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGridView.ContextMenuStrip = this.tableMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableGridView.GridColor = System.Drawing.SystemColors.Window;
            this.tableGridView.Location = new System.Drawing.Point(3, 6);
            this.tableGridView.Name = "tableGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableGridView.RowHeadersVisible = false;
            this.tableGridView.RowTemplate.Height = 18;
            this.tableGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGridView.Size = new System.Drawing.Size(107, 655);
            this.tableGridView.TabIndex = 2;
            this.tableGridView.SelectionChanged += new System.EventHandler(this.TableGridView_SelectionChanged);
            // 
            // fieldsGridView
            // 
            this.fieldsGridView.AllowDrop = true;
            this.fieldsGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.fieldsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fieldsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.fieldsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fieldsGridView.ContextMenuStrip = this.fieldMenu;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fieldsGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.fieldsGridView.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.fieldsGridView.Location = new System.Drawing.Point(116, 6);
            this.fieldsGridView.Name = "fieldsGridView";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fieldsGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.fieldsGridView.RowHeadersVisible = false;
            this.fieldsGridView.RowTemplate.Height = 18;
            this.fieldsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.fieldsGridView.Size = new System.Drawing.Size(1030, 655);
            this.fieldsGridView.TabIndex = 3;
            this.fieldsGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.FieldGridView_CellValueChanged);
            this.fieldsGridView.CurrentCellChanged += new System.EventHandler(this.FieldGridView_CurrentCellChanged);
            // 
            // tabHome
            // 
            this.tabHome.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.tabHome.Controls.Add(this.groupBox1);
            this.tabHome.Controls.Add(this.textBox1);
            this.tabHome.Controls.Add(this.pictureBox1);
            this.tabHome.Location = new System.Drawing.Point(4, 24);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1158, 1022);
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
            this.groupBox1.Location = new System.Drawing.Point(34, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 48);
            this.groupBox1.TabIndex = 144;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(618, 60);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(462, 550);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DB_EDITOR.Properties.Resources.ncaa_db_editor_TITLE;
            this.pictureBox1.Location = new System.Drawing.Point(34, 60);
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
            this.tabControl1.Controls.Add(this.tabConf);
            this.tabControl1.Controls.Add(this.tabAnnuals);
            this.tabControl1.Controls.Add(this.tabCChamps);
            this.tabControl1.Controls.Add(this.tabBowls);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(125, 20);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1166, 1050);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_IndexChange);
            // 
            // tabAnnuals
            // 
            this.tabAnnuals.Controls.Add(this.ClearAllButton);
            this.tabAnnuals.Controls.Add(this.SaveSANNButton);
            this.tabAnnuals.Controls.Add(this.DeleteGameButton);
            this.tabAnnuals.Controls.Add(this.AnnualsGrid);
            this.tabAnnuals.Location = new System.Drawing.Point(4, 24);
            this.tabAnnuals.Name = "tabAnnuals";
            this.tabAnnuals.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnnuals.Size = new System.Drawing.Size(1158, 1022);
            this.tabAnnuals.TabIndex = 10;
            this.tabAnnuals.Text = "Annuals";
            this.tabAnnuals.UseVisualStyleBackColor = true;
            // 
            // ClearAllButton
            // 
            this.ClearAllButton.BackColor = System.Drawing.Color.GhostWhite;
            this.ClearAllButton.Location = new System.Drawing.Point(430, 236);
            this.ClearAllButton.Name = "ClearAllButton";
            this.ClearAllButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClearAllButton.Size = new System.Drawing.Size(122, 54);
            this.ClearAllButton.TabIndex = 3;
            this.ClearAllButton.Text = "Clear All";
            this.ClearAllButton.UseVisualStyleBackColor = false;
            this.ClearAllButton.Click += new System.EventHandler(this.ClearAllButton_Click);
            // 
            // SaveSANNButton
            // 
            this.SaveSANNButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.SaveSANNButton.Location = new System.Drawing.Point(430, 132);
            this.SaveSANNButton.Name = "SaveSANNButton";
            this.SaveSANNButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveSANNButton.Size = new System.Drawing.Size(122, 54);
            this.SaveSANNButton.TabIndex = 2;
            this.SaveSANNButton.Text = "Save";
            this.SaveSANNButton.UseVisualStyleBackColor = false;
            this.SaveSANNButton.Click += new System.EventHandler(this.SaveSANNButton_Click);
            // 
            // DeleteGameButton
            // 
            this.DeleteGameButton.BackColor = System.Drawing.Color.LightPink;
            this.DeleteGameButton.Location = new System.Drawing.Point(430, 26);
            this.DeleteGameButton.Name = "DeleteGameButton";
            this.DeleteGameButton.Size = new System.Drawing.Size(122, 54);
            this.DeleteGameButton.TabIndex = 1;
            this.DeleteGameButton.Text = "Delete Game";
            this.DeleteGameButton.UseVisualStyleBackColor = false;
            this.DeleteGameButton.Click += new System.EventHandler(this.DeleteGameButton_Click);
            // 
            // AnnualsGrid
            // 
            this.AnnualsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.AnnualsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
            this.AnnualsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnnualsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.AnnualsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AnnualsGrid.DefaultCellStyle = dataGridViewCellStyle10;
            this.AnnualsGrid.Location = new System.Drawing.Point(12, 6);
            this.AnnualsGrid.Name = "AnnualsGrid";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AnnualsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.AnnualsGrid.Size = new System.Drawing.Size(400, 878);
            this.AnnualsGrid.TabIndex = 0;
            this.AnnualsGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.AnnualsGrid_DataError);
            // 
            // tabCChamps
            // 
            this.tabCChamps.Controls.Add(this.label37);
            this.tabCChamps.Controls.Add(this.SaveChamps);
            this.tabCChamps.Controls.Add(this.ChampGrid);
            this.tabCChamps.Location = new System.Drawing.Point(4, 24);
            this.tabCChamps.Name = "tabCChamps";
            this.tabCChamps.Padding = new System.Windows.Forms.Padding(3);
            this.tabCChamps.Size = new System.Drawing.Size(1158, 1022);
            this.tabCChamps.TabIndex = 12;
            this.tabCChamps.Text = "Conf Championships";
            this.tabCChamps.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(23, 23);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(346, 24);
            this.label37.TabIndex = 6;
            this.label37.Text = "Missing Conference Championships";
            // 
            // SaveChamps
            // 
            this.SaveChamps.BackColor = System.Drawing.Color.LightSkyBlue;
            this.SaveChamps.Location = new System.Drawing.Point(247, 427);
            this.SaveChamps.Name = "SaveChamps";
            this.SaveChamps.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SaveChamps.Size = new System.Drawing.Size(122, 54);
            this.SaveChamps.TabIndex = 5;
            this.SaveChamps.Text = "Save";
            this.SaveChamps.UseVisualStyleBackColor = false;
            this.SaveChamps.Click += new System.EventHandler(this.SaveChamps_Click);
            // 
            // ChampGrid
            // 
            this.ChampGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ChampGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.ChampGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChampGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.ChampGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChampGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Conf,
            this.Bowl});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ChampGrid.DefaultCellStyle = dataGridViewCellStyle14;
            this.ChampGrid.Location = new System.Drawing.Point(28, 51);
            this.ChampGrid.Name = "ChampGrid";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ChampGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.ChampGrid.Size = new System.Drawing.Size(352, 358);
            this.ChampGrid.TabIndex = 4;
            this.ChampGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ChampGrid_DataError);
            // 
            // Conf
            // 
            this.Conf.HeaderText = "Conference";
            this.Conf.Name = "Conf";
            // 
            // Bowl
            // 
            this.Bowl.HeaderText = "Bowl Selection";
            this.Bowl.Name = "Bowl";
            // 
            // tabBowls
            // 
            this.tabBowls.Controls.Add(this.AtLargeButton);
            this.tabBowls.Controls.Add(this.SaveBowlButton);
            this.tabBowls.Controls.Add(this.DeleteBowlButton);
            this.tabBowls.Controls.Add(this.BowlsGrid);
            this.tabBowls.Location = new System.Drawing.Point(4, 24);
            this.tabBowls.Name = "tabBowls";
            this.tabBowls.Padding = new System.Windows.Forms.Padding(3);
            this.tabBowls.Size = new System.Drawing.Size(1158, 1022);
            this.tabBowls.TabIndex = 11;
            this.tabBowls.Text = "Bowls";
            this.tabBowls.UseVisualStyleBackColor = true;
            // 
            // AtLargeButton
            // 
            this.AtLargeButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.AtLargeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AtLargeButton.Location = new System.Drawing.Point(896, 201);
            this.AtLargeButton.Name = "AtLargeButton";
            this.AtLargeButton.Size = new System.Drawing.Size(115, 51);
            this.AtLargeButton.TabIndex = 3;
            this.AtLargeButton.Text = "Set All to At-Large";
            this.AtLargeButton.UseVisualStyleBackColor = false;
            this.AtLargeButton.Click += new System.EventHandler(this.AtLargeButton_Click);
            // 
            // SaveBowlButton
            // 
            this.SaveBowlButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SaveBowlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBowlButton.Location = new System.Drawing.Point(896, 23);
            this.SaveBowlButton.Name = "SaveBowlButton";
            this.SaveBowlButton.Size = new System.Drawing.Size(115, 52);
            this.SaveBowlButton.TabIndex = 2;
            this.SaveBowlButton.Text = "Save";
            this.SaveBowlButton.UseVisualStyleBackColor = false;
            this.SaveBowlButton.Click += new System.EventHandler(this.SaveBowlButton_Click);
            // 
            // DeleteBowlButton
            // 
            this.DeleteBowlButton.BackColor = System.Drawing.Color.PaleVioletRed;
            this.DeleteBowlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBowlButton.Location = new System.Drawing.Point(896, 113);
            this.DeleteBowlButton.Name = "DeleteBowlButton";
            this.DeleteBowlButton.Size = new System.Drawing.Size(115, 52);
            this.DeleteBowlButton.TabIndex = 1;
            this.DeleteBowlButton.Text = "Delete Row";
            this.DeleteBowlButton.UseVisualStyleBackColor = false;
            this.DeleteBowlButton.Click += new System.EventHandler(this.DeleteBowlButton_Click);
            // 
            // BowlsGrid
            // 
            this.BowlsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.BowlsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.BowlsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BowlsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.BowlsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BowlsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BIDX,
            this.BNME,
            this.BCI1,
            this.BCR1,
            this.BCI2,
            this.BCR2,
            this.SGID,
            this.BMON,
            this.BDAY});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BowlsGrid.DefaultCellStyle = dataGridViewCellStyle18;
            this.BowlsGrid.Location = new System.Drawing.Point(38, 23);
            this.BowlsGrid.Name = "BowlsGrid";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BowlsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.BowlsGrid.Size = new System.Drawing.Size(816, 875);
            this.BowlsGrid.TabIndex = 0;
            this.BowlsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.BowlCellValueChanged);
            this.BowlsGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.BowlsGrid_DataError);
            // 
            // BIDX
            // 
            this.BIDX.FillWeight = 58.21476F;
            this.BIDX.HeaderText = "BIDX";
            this.BIDX.Name = "BIDX";
            this.BIDX.ReadOnly = true;
            // 
            // BNME
            // 
            this.BNME.FillWeight = 184.7952F;
            this.BNME.HeaderText = "Bowl Name";
            this.BNME.Name = "BNME";
            // 
            // BCI1
            // 
            this.BCI1.FillWeight = 113.5889F;
            this.BCI1.HeaderText = "Conf A";
            this.BCI1.Name = "BCI1";
            // 
            // BCR1
            // 
            this.BCR1.FillWeight = 56.59636F;
            this.BCR1.HeaderText = "Conf A Seed";
            this.BCR1.Name = "BCR1";
            // 
            // BCI2
            // 
            this.BCI2.FillWeight = 120.1694F;
            this.BCI2.HeaderText = "Conf B";
            this.BCI2.Name = "BCI2";
            // 
            // BCR2
            // 
            this.BCR2.FillWeight = 59.46095F;
            this.BCR2.HeaderText = "Conf B Seed";
            this.BCR2.Name = "BCR2";
            // 
            // SGID
            // 
            this.SGID.FillWeight = 188.292F;
            this.SGID.HeaderText = "Stadium";
            this.SGID.Name = "SGID";
            // 
            // BMON
            // 
            this.BMON.FillWeight = 57.73386F;
            this.BMON.HeaderText = "Month";
            this.BMON.Name = "BMON";
            // 
            // BDAY
            // 
            this.BDAY.FillWeight = 61.14862F;
            this.BDAY.HeaderText = "Date";
            this.BDAY.Name = "BDAY";
            // 
            // radio136
            // 
            this.radio136.AutoSize = true;
            this.radio136.Location = new System.Drawing.Point(175, 19);
            this.radio136.Name = "radio136";
            this.radio136.Size = new System.Drawing.Size(78, 17);
            this.radio136.TabIndex = 2;
            this.radio136.Text = "136 Teams";
            this.radio136.UseVisualStyleBackColor = true;
            // 
            // LeagueMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1190, 961);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.TablePropsgroupBox);
            this.Controls.Add(this.FieldsPropsgroupBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "LeagueMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "League Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserKeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserKeyPreview);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.tableMenu.ResumeLayout(false);
            this.fieldMenu.ResumeLayout(false);
            this.TablePropsgroupBox.ResumeLayout(false);
            this.TablePropsgroupBox.PerformLayout();
            this.FieldsPropsgroupBox.ResumeLayout(false);
            this.FieldsPropsgroupBox.PerformLayout();
            this.tabConf.ResumeLayout(false);
            this.tabConf.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).EndInit();
            this.tabHome.ResumeLayout(false);
            this.tabHome.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabAnnuals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AnnualsGrid)).EndInit();
            this.tabCChamps.ResumeLayout(false);
            this.tabCChamps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChampGrid)).EndInit();
            this.tabBowls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BowlsGrid)).EndInit();
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
        public System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem tableFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem defaultFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ascendingFieldOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem customOrderMenuItem;
        public System.Windows.Forms.ToolStripMenuItem descendingFieldOrderMenuItem;
        private ColorDialog colorDialog1;
        private TabPage tabConf;
        private Label labelTeamSelection;
        private System.Windows.Forms.Button DeselectButton;
        private System.Windows.Forms.Button SaveButton;
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
        public TabPage tabDB;
        public DataGridView tableGridView;
        public DataGridView fieldsGridView;
        private TabPage tabHome;
        private PictureBox pictureBox1;
        public TabControl tabControl1;
        private System.Windows.Forms.TextBox confName1;
        private System.Windows.Forms.TextBox confName12;
        private System.Windows.Forms.TextBox confName11;
        private System.Windows.Forms.TextBox confName10;
        private System.Windows.Forms.TextBox confName9;
        private System.Windows.Forms.TextBox confName8;
        private System.Windows.Forms.TextBox confName7;
        private System.Windows.Forms.TextBox confName6;
        private System.Windows.Forms.TextBox confName5;
        private System.Windows.Forms.TextBox confName4;
        private System.Windows.Forms.TextBox confName3;
        private System.Windows.Forms.TextBox confName2;
        private ListBox AllTeamsListBox;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label7;
        private NumericUpDown numericUpDown7;
        private NumericUpDown numericUpDown8;
        private NumericUpDown numericUpDown9;
        private NumericUpDown numericUpDown10;
        private NumericUpDown numericUpDown11;
        private NumericUpDown numericUpDown12;
        private NumericUpDown numericUpDown6;
        private NumericUpDown numericUpDown5;
        private NumericUpDown numericUpDown4;
        private NumericUpDown numericUpDown3;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label17;
        private Label label18;
        private Label label15;
        private Label label16;
        private Label label14;
        private Label label13;
        private System.Windows.Forms.Button AddButton;
        private Label LeagueTeamsLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ClearLeagueButton;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label25;
        private TabPage tabAnnuals;
        private TabPage tabBowls;
        private DataGridView AnnualsGrid;
        private System.Windows.Forms.Button SaveSANNButton;
        private System.Windows.Forms.Button DeleteGameButton;
        private System.Windows.Forms.Button ClearAllButton;
        private TabPage tabCChamps;
        private System.Windows.Forms.Button SaveChamps;
        private DataGridView ChampGrid;
        private Label label37;
        private DataGridViewTextBoxColumn Conf;
        private DataGridViewComboBoxColumn Bowl;
        private DataGridView BowlsGrid;
        private DataGridViewTextBoxColumn BIDX;
        private DataGridViewTextBoxColumn BNME;
        private DataGridViewComboBoxColumn BCI1;
        private DataGridViewComboBoxColumn BCR1;
        private DataGridViewComboBoxColumn BCI2;
        private DataGridViewComboBoxColumn BCR2;
        private DataGridViewComboBoxColumn SGID;
        private DataGridViewComboBoxColumn BMON;
        private DataGridViewComboBoxColumn BDAY;
        private System.Windows.Forms.Button DeleteBowlButton;
        private System.Windows.Forms.Button SaveBowlButton;
        private ToolStripMenuItem CustomLeagueToolStrip;
        private ToolStripMenuItem importCustomLeagueToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private ToolStripMenuItem ExportCustomLeague;
        private System.Windows.Forms.Button RandomizeLeagueButton;
        private Panel panel1;
        private Label label38;
        private System.Windows.Forms.ComboBox TeamsPerConfBox;
        private Label label39;
        private System.Windows.Forms.ComboBox TeamSelectionBox;
        private System.Windows.Forms.Button AtLargeButton;
        private GroupBox groupBox1;
        private RadioButton OGConfigRadio;
        private RadioButton NextConfigRadio;
        private GroupBox groupBox2;
        private RadioButton radio126;
        private RadioButton radio120;
        private RadioButton radio136;
    }
}

