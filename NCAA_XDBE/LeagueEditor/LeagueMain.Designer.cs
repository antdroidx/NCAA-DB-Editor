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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeagueMain));
            mainMenu = new MenuStrip();
            fileMenuItem = new ToolStripMenuItem();
            openMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            saveAsMenuItem = new ToolStripMenuItem();
            closeMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            definitionFileMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            CSVMenuItem = new ToolStripMenuItem();
            exportToolItem = new ToolStripMenuItem();
            importMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exportAllMenuItem = new ToolStripMenuItem();
            toolStripSeparator9 = new ToolStripSeparator();
            tabDelimitedMenuItem = new ToolStripMenuItem();
            optionsMenuItem = new ToolStripMenuItem();
            tableFieldOrderMenuItem = new ToolStripMenuItem();
            defaultFieldOrderMenuItem = new ToolStripMenuItem();
            ascendingFieldOrderMenuItem = new ToolStripMenuItem();
            descendingFieldOrderMenuItem = new ToolStripMenuItem();
            customOrderMenuItem = new ToolStripMenuItem();
            CustomLeagueToolStrip = new ToolStripMenuItem();
            importCustomLeagueToolStripMenuItem = new ToolStripMenuItem();
            ExportCustomLeague = new ToolStripMenuItem();
            aboutMenuItem = new ToolStripMenuItem();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            tableMenu = new ContextMenuStrip(components);
            exportTableMenuItem = new ToolStripMenuItem();
            importTableMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            exportAllTableMenuItem = new ToolStripMenuItem();
            fieldMenu = new ContextMenuStrip(components);
            copyRecordsMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            addRecordsMenuItem = new ToolStripMenuItem();
            deleteRecordsMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exportRecordsMenuItem = new ToolStripMenuItem();
            importRecordsMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            addendumMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            TablePropsLabel = new Label();
            FieldsPropsLabel = new Label();
            TablePropsgroupBox = new GroupBox();
            FieldsPropsgroupBox = new GroupBox();
            openFileDialog2 = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            tabConf = new TabPage();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            ClearLeagueButton = new System.Windows.Forms.Button();
            RemoveButton = new System.Windows.Forms.Button();
            LeagueTeamsLabel = new Label();
            AddButton = new System.Windows.Forms.Button();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label17 = new Label();
            label18 = new Label();
            label15 = new Label();
            label16 = new Label();
            label14 = new Label();
            label13 = new Label();
            numericUpDown7 = new NumericUpDown();
            numericUpDown8 = new NumericUpDown();
            numericUpDown9 = new NumericUpDown();
            numericUpDown10 = new NumericUpDown();
            numericUpDown11 = new NumericUpDown();
            numericUpDown12 = new NumericUpDown();
            numericUpDown6 = new NumericUpDown();
            numericUpDown5 = new NumericUpDown();
            numericUpDown4 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown1 = new NumericUpDown();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button10 = new System.Windows.Forms.Button();
            button11 = new System.Windows.Forms.Button();
            button12 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            AllTeamsListBox = new ListBox();
            confName12 = new System.Windows.Forms.TextBox();
            confName11 = new System.Windows.Forms.TextBox();
            confName10 = new System.Windows.Forms.TextBox();
            confName9 = new System.Windows.Forms.TextBox();
            confName8 = new System.Windows.Forms.TextBox();
            confName7 = new System.Windows.Forms.TextBox();
            confName6 = new System.Windows.Forms.TextBox();
            confName5 = new System.Windows.Forms.TextBox();
            confName4 = new System.Windows.Forms.TextBox();
            confName3 = new System.Windows.Forms.TextBox();
            confName2 = new System.Windows.Forms.TextBox();
            confName1 = new System.Windows.Forms.TextBox();
            labelTeamSelection = new Label();
            DeselectButton = new System.Windows.Forms.Button();
            SaveButton = new System.Windows.Forms.Button();
            conf12 = new CheckedListBox();
            conf11 = new CheckedListBox();
            conf10 = new CheckedListBox();
            conf9 = new CheckedListBox();
            conf8 = new CheckedListBox();
            conf7 = new CheckedListBox();
            conf6 = new CheckedListBox();
            conf5 = new CheckedListBox();
            conf4 = new CheckedListBox();
            conf3 = new CheckedListBox();
            conf2 = new CheckedListBox();
            conf1 = new CheckedListBox();
            panel1 = new Panel();
            label39 = new Label();
            TeamSelectionBox = new System.Windows.Forms.ComboBox();
            label38 = new Label();
            TeamsPerConfBox = new System.Windows.Forms.ComboBox();
            RandomizeLeagueButton = new System.Windows.Forms.Button();
            tabDB = new TabPage();
            groupBox2 = new GroupBox();
            lblTableProps = new Label();
            groupBox3 = new GroupBox();
            lblFieldProps = new Label();
            tableGridView = new DataGridView();
            fieldsGridView = new DataGridView();
            tabHome = new TabPage();
            groupBox1 = new GroupBox();
            Next26Config = new RadioButton();
            OGConfigRadio = new RadioButton();
            NextConfigRadio = new RadioButton();
            tabControl1 = new TabControl();
            tabAnnuals = new TabPage();
            ClearAllButton = new System.Windows.Forms.Button();
            SaveSANNButton = new System.Windows.Forms.Button();
            DeleteGameButton = new System.Windows.Forms.Button();
            AnnualsGrid = new DataGridView();
            tabCChamps = new TabPage();
            label37 = new Label();
            SaveChamps = new System.Windows.Forms.Button();
            ChampGrid = new DataGridView();
            Conf = new DataGridViewTextBoxColumn();
            Bowl = new DataGridViewComboBoxColumn();
            tabBowls = new TabPage();
            AtLargeButton = new System.Windows.Forms.Button();
            SaveBowlButton = new System.Windows.Forms.Button();
            DeleteBowlButton = new System.Windows.Forms.Button();
            BowlsGrid = new DataGridView();
            BIDX = new DataGridViewTextBoxColumn();
            BNME = new DataGridViewTextBoxColumn();
            BCI1 = new DataGridViewComboBoxColumn();
            BCR1 = new DataGridViewTextBoxColumn();
            BCI2 = new DataGridViewComboBoxColumn();
            BCR2 = new DataGridViewTextBoxColumn();
            SGID = new DataGridViewComboBoxColumn();
            BMON = new DataGridViewComboBoxColumn();
            BDAY = new DataGridViewComboBoxColumn();
            IndieCheckBox = new CheckBox();
            mainMenu.SuspendLayout();
            tableMenu.SuspendLayout();
            fieldMenu.SuspendLayout();
            TablePropsgroupBox.SuspendLayout();
            FieldsPropsgroupBox.SuspendLayout();
            tabConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel1.SuspendLayout();
            tabDB.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tableGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldsGridView).BeginInit();
            tabHome.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabAnnuals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AnnualsGrid).BeginInit();
            tabCChamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ChampGrid).BeginInit();
            tabBowls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BowlsGrid).BeginInit();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.BackColor = SystemColors.Control;
            mainMenu.Items.AddRange(new ToolStripItem[] { fileMenuItem, CSVMenuItem, optionsMenuItem, CustomLeagueToolStrip, aboutMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(1190, 24);
            mainMenu.TabIndex = 0;
            mainMenu.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openMenuItem, saveMenuItem, saveAsMenuItem, closeMenuItem, toolStripSeparator1, definitionFileMenuItem, toolStripSeparator7, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(37, 20);
            fileMenuItem.Text = "File";
            // 
            // openMenuItem
            // 
            openMenuItem.Image = Properties.Resources.open2;
            openMenuItem.Name = "openMenuItem";
            openMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openMenuItem.Size = new Size(148, 22);
            openMenuItem.Text = "Open";
            openMenuItem.Click += OpenMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Image = Properties.Resources.save3;
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMenuItem.Size = new Size(148, 22);
            saveMenuItem.Text = "Save";
            saveMenuItem.Click += SaveMenuItem_Click;
            // 
            // saveAsMenuItem
            // 
            saveAsMenuItem.Name = "saveAsMenuItem";
            saveAsMenuItem.Size = new Size(148, 22);
            saveAsMenuItem.Text = "Save As...";
            saveAsMenuItem.Click += SaveAsMenuItem_Click;
            // 
            // closeMenuItem
            // 
            closeMenuItem.Image = Properties.Resources.close;
            closeMenuItem.Name = "closeMenuItem";
            closeMenuItem.ShortcutKeys = Keys.Control | Keys.W;
            closeMenuItem.Size = new Size(148, 22);
            closeMenuItem.Text = "Close";
            closeMenuItem.Click += CloseMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(145, 6);
            // 
            // definitionFileMenuItem
            // 
            definitionFileMenuItem.Image = Properties.Resources.def_file;
            definitionFileMenuItem.Name = "definitionFileMenuItem";
            definitionFileMenuItem.Size = new Size(148, 22);
            definitionFileMenuItem.Text = "Definition File";
            definitionFileMenuItem.Click += DefinitionFileMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(145, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Image = Properties.Resources.exit;
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitMenuItem.Size = new Size(148, 22);
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += ExitToolItem_Click;
            // 
            // CSVMenuItem
            // 
            CSVMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolItem, importMenuItem, toolStripSeparator2, exportAllMenuItem, toolStripSeparator9, tabDelimitedMenuItem });
            CSVMenuItem.Name = "CSVMenuItem";
            CSVMenuItem.Size = new Size(40, 20);
            CSVMenuItem.Text = "CSV";
            // 
            // exportToolItem
            // 
            exportToolItem.Name = "exportToolItem";
            exportToolItem.ShortcutKeys = Keys.Control | Keys.E;
            exportToolItem.Size = new Size(180, 22);
            exportToolItem.Text = "Export Table";
            exportToolItem.Click += exportMenuItem_Click;
            // 
            // importMenuItem
            // 
            importMenuItem.Name = "importMenuItem";
            importMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            importMenuItem.Size = new Size(180, 22);
            importMenuItem.Text = "Import Table";
            importMenuItem.Click += importMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // exportAllMenuItem
            // 
            exportAllMenuItem.Name = "exportAllMenuItem";
            exportAllMenuItem.ShowShortcutKeys = false;
            exportAllMenuItem.Size = new Size(180, 22);
            exportAllMenuItem.Text = "Export All";
            exportAllMenuItem.Click += exportAllMenuItem_Click;
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(177, 6);
            // 
            // tabDelimitedMenuItem
            // 
            tabDelimitedMenuItem.Name = "tabDelimitedMenuItem";
            tabDelimitedMenuItem.Size = new Size(180, 22);
            tabDelimitedMenuItem.Text = "Tab Delimited";
            tabDelimitedMenuItem.Click += tabDelimitedMenuItem_Click;
            // 
            // optionsMenuItem
            // 
            optionsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tableFieldOrderMenuItem });
            optionsMenuItem.Name = "optionsMenuItem";
            optionsMenuItem.Size = new Size(61, 20);
            optionsMenuItem.Text = "Options";
            // 
            // tableFieldOrderMenuItem
            // 
            tableFieldOrderMenuItem.DropDownItems.AddRange(new ToolStripItem[] { defaultFieldOrderMenuItem, ascendingFieldOrderMenuItem, descendingFieldOrderMenuItem, customOrderMenuItem });
            tableFieldOrderMenuItem.Name = "tableFieldOrderMenuItem";
            tableFieldOrderMenuItem.Size = new Size(180, 22);
            tableFieldOrderMenuItem.Text = "Table Field Order";
            // 
            // defaultFieldOrderMenuItem
            // 
            defaultFieldOrderMenuItem.Checked = true;
            defaultFieldOrderMenuItem.CheckState = CheckState.Checked;
            defaultFieldOrderMenuItem.Name = "defaultFieldOrderMenuItem";
            defaultFieldOrderMenuItem.Size = new Size(180, 22);
            defaultFieldOrderMenuItem.Text = "Default";
            defaultFieldOrderMenuItem.Click += defaultMenuItem_Click;
            // 
            // ascendingFieldOrderMenuItem
            // 
            ascendingFieldOrderMenuItem.Name = "ascendingFieldOrderMenuItem";
            ascendingFieldOrderMenuItem.Size = new Size(180, 22);
            ascendingFieldOrderMenuItem.Text = "Ascending";
            ascendingFieldOrderMenuItem.Click += ascendingMenuItem_Click;
            // 
            // descendingFieldOrderMenuItem
            // 
            descendingFieldOrderMenuItem.Name = "descendingFieldOrderMenuItem";
            descendingFieldOrderMenuItem.Size = new Size(180, 22);
            descendingFieldOrderMenuItem.Text = "Descending";
            descendingFieldOrderMenuItem.Click += descendingMenuItem_Click;
            // 
            // customOrderMenuItem
            // 
            customOrderMenuItem.Name = "customOrderMenuItem";
            customOrderMenuItem.Size = new Size(180, 22);
            customOrderMenuItem.Text = "Custom";
            customOrderMenuItem.Click += customMenuItem_Click;
            // 
            // CustomLeagueToolStrip
            // 
            CustomLeagueToolStrip.DropDownItems.AddRange(new ToolStripItem[] { importCustomLeagueToolStripMenuItem, ExportCustomLeague });
            CustomLeagueToolStrip.Name = "CustomLeagueToolStrip";
            CustomLeagueToolStrip.Size = new Size(102, 20);
            CustomLeagueToolStrip.Text = "Custom League";
            // 
            // importCustomLeagueToolStripMenuItem
            // 
            importCustomLeagueToolStripMenuItem.Name = "importCustomLeagueToolStripMenuItem";
            importCustomLeagueToolStripMenuItem.Size = new Size(196, 22);
            importCustomLeagueToolStripMenuItem.Text = "Import Custom League";
            importCustomLeagueToolStripMenuItem.Click += importCustomLeagueToolStripMenuItem_Click;
            // 
            // ExportCustomLeague
            // 
            ExportCustomLeague.Name = "ExportCustomLeague";
            ExportCustomLeague.Size = new Size(196, 22);
            ExportCustomLeague.Text = "Export Custom League";
            ExportCustomLeague.Click += ExportCustomLeague_Click;
            // 
            // aboutMenuItem
            // 
            aboutMenuItem.Name = "aboutMenuItem";
            aboutMenuItem.Size = new Size(52, 20);
            aboutMenuItem.Text = "About";
            aboutMenuItem.Click += AboutMenuItem_Click;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            progressBar1.BackColor = SystemColors.Control;
            progressBar1.Location = new Point(974, 912);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(200, 23);
            progressBar1.TabIndex = 1;
            // 
            // tableMenu
            // 
            tableMenu.Items.AddRange(new ToolStripItem[] { exportTableMenuItem, importTableMenuItem, toolStripSeparator3, exportAllTableMenuItem });
            tableMenu.Name = "tableMenu";
            tableMenu.Size = new Size(142, 76);
            // 
            // exportTableMenuItem
            // 
            exportTableMenuItem.Name = "exportTableMenuItem";
            exportTableMenuItem.Size = new Size(141, 22);
            exportTableMenuItem.Text = "Export Table";
            exportTableMenuItem.Click += exportTableMenuItem_Click;
            // 
            // importTableMenuItem
            // 
            importTableMenuItem.Name = "importTableMenuItem";
            importTableMenuItem.Size = new Size(141, 22);
            importTableMenuItem.Text = "Import Table";
            importTableMenuItem.Click += importTableMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(138, 6);
            // 
            // exportAllTableMenuItem
            // 
            exportAllTableMenuItem.Name = "exportAllTableMenuItem";
            exportAllTableMenuItem.Size = new Size(141, 22);
            exportAllTableMenuItem.Text = "Export All";
            exportAllTableMenuItem.Click += exportAllTableMenuItem_Click;
            // 
            // fieldMenu
            // 
            fieldMenu.Items.AddRange(new ToolStripItem[] { copyRecordsMenuItem, toolStripSeparator4, addRecordsMenuItem, deleteRecordsMenuItem, toolStripSeparator5, exportRecordsMenuItem, importRecordsMenuItem, toolStripSeparator6, addendumMenuItem });
            fieldMenu.Name = "contextMenuStrip2";
            fieldMenu.Size = new Size(164, 154);
            // 
            // copyRecordsMenuItem
            // 
            copyRecordsMenuItem.Name = "copyRecordsMenuItem";
            copyRecordsMenuItem.Size = new Size(163, 22);
            copyRecordsMenuItem.Text = "Copy Record(s)";
            copyRecordsMenuItem.Click += copyRecordsMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(160, 6);
            // 
            // addRecordsMenuItem
            // 
            addRecordsMenuItem.Name = "addRecordsMenuItem";
            addRecordsMenuItem.Size = new Size(163, 22);
            addRecordsMenuItem.Text = "Add Record(s)";
            addRecordsMenuItem.Click += addRecordsMenuItem_Click;
            // 
            // deleteRecordsMenuItem
            // 
            deleteRecordsMenuItem.Name = "deleteRecordsMenuItem";
            deleteRecordsMenuItem.Size = new Size(163, 22);
            deleteRecordsMenuItem.Text = "Delete Record(s)";
            deleteRecordsMenuItem.Click += deleteRecordsMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(160, 6);
            // 
            // exportRecordsMenuItem
            // 
            exportRecordsMenuItem.Name = "exportRecordsMenuItem";
            exportRecordsMenuItem.Size = new Size(163, 22);
            exportRecordsMenuItem.Text = "Export Record(s)";
            exportRecordsMenuItem.Click += exportRecordsMenuItem_Click;
            // 
            // importRecordsMenuItem
            // 
            importRecordsMenuItem.Name = "importRecordsMenuItem";
            importRecordsMenuItem.Size = new Size(163, 22);
            importRecordsMenuItem.Text = "Import Record(s)";
            importRecordsMenuItem.Click += importRecordsMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(160, 6);
            // 
            // addendumMenuItem
            // 
            addendumMenuItem.Name = "addendumMenuItem";
            addendumMenuItem.Size = new Size(163, 22);
            addendumMenuItem.Text = "Addendum";
            addendumMenuItem.Click += addendumMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Title = "Open File";
            // 
            // TablePropsLabel
            // 
            TablePropsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TablePropsLabel.AutoSize = true;
            TablePropsLabel.ForeColor = SystemColors.ControlText;
            TablePropsLabel.Location = new Point(6, 13);
            TablePropsLabel.Name = "TablePropsLabel";
            TablePropsLabel.Size = new Size(87, 13);
            TablePropsLabel.TabIndex = 5;
            TablePropsLabel.Text = "TablePropsLabel";
            // 
            // FieldsPropsLabel
            // 
            FieldsPropsLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FieldsPropsLabel.AutoSize = true;
            FieldsPropsLabel.ForeColor = SystemColors.ControlText;
            FieldsPropsLabel.Location = new Point(6, 12);
            FieldsPropsLabel.Name = "FieldsPropsLabel";
            FieldsPropsLabel.Size = new Size(87, 13);
            FieldsPropsLabel.TabIndex = 6;
            FieldsPropsLabel.Text = "FieldsPropsLabel";
            // 
            // TablePropsgroupBox
            // 
            TablePropsgroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TablePropsgroupBox.Controls.Add(TablePropsLabel);
            TablePropsgroupBox.ForeColor = SystemColors.ScrollBar;
            TablePropsgroupBox.Location = new Point(19, 905);
            TablePropsgroupBox.Name = "TablePropsgroupBox";
            TablePropsgroupBox.Size = new Size(345, 31);
            TablePropsgroupBox.TabIndex = 7;
            TablePropsgroupBox.TabStop = false;
            TablePropsgroupBox.Text = "Table Properties";
            // 
            // FieldsPropsgroupBox
            // 
            FieldsPropsgroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FieldsPropsgroupBox.Controls.Add(FieldsPropsLabel);
            FieldsPropsgroupBox.ForeColor = SystemColors.ScrollBar;
            FieldsPropsgroupBox.Location = new Point(367, 905);
            FieldsPropsgroupBox.Name = "FieldsPropsgroupBox";
            FieldsPropsgroupBox.Size = new Size(345, 31);
            FieldsPropsgroupBox.TabIndex = 4;
            FieldsPropsgroupBox.TabStop = false;
            FieldsPropsgroupBox.Text = "Field Properties";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // tabConf
            // 
            tabConf.AutoScroll = true;
            tabConf.BackColor = SystemColors.ScrollBar;
            tabConf.Controls.Add(IndieCheckBox);
            tabConf.Controls.Add(label31);
            tabConf.Controls.Add(label32);
            tabConf.Controls.Add(label33);
            tabConf.Controls.Add(label34);
            tabConf.Controls.Add(label35);
            tabConf.Controls.Add(label36);
            tabConf.Controls.Add(label30);
            tabConf.Controls.Add(label29);
            tabConf.Controls.Add(label28);
            tabConf.Controls.Add(label27);
            tabConf.Controls.Add(label26);
            tabConf.Controls.Add(label25);
            tabConf.Controls.Add(ClearLeagueButton);
            tabConf.Controls.Add(RemoveButton);
            tabConf.Controls.Add(LeagueTeamsLabel);
            tabConf.Controls.Add(AddButton);
            tabConf.Controls.Add(label19);
            tabConf.Controls.Add(label20);
            tabConf.Controls.Add(label21);
            tabConf.Controls.Add(label22);
            tabConf.Controls.Add(label23);
            tabConf.Controls.Add(label24);
            tabConf.Controls.Add(label17);
            tabConf.Controls.Add(label18);
            tabConf.Controls.Add(label15);
            tabConf.Controls.Add(label16);
            tabConf.Controls.Add(label14);
            tabConf.Controls.Add(label13);
            tabConf.Controls.Add(numericUpDown7);
            tabConf.Controls.Add(numericUpDown8);
            tabConf.Controls.Add(numericUpDown9);
            tabConf.Controls.Add(numericUpDown10);
            tabConf.Controls.Add(numericUpDown11);
            tabConf.Controls.Add(numericUpDown12);
            tabConf.Controls.Add(numericUpDown6);
            tabConf.Controls.Add(numericUpDown5);
            tabConf.Controls.Add(numericUpDown4);
            tabConf.Controls.Add(numericUpDown3);
            tabConf.Controls.Add(numericUpDown2);
            tabConf.Controls.Add(numericUpDown1);
            tabConf.Controls.Add(button7);
            tabConf.Controls.Add(button8);
            tabConf.Controls.Add(button9);
            tabConf.Controls.Add(button10);
            tabConf.Controls.Add(button11);
            tabConf.Controls.Add(button12);
            tabConf.Controls.Add(button6);
            tabConf.Controls.Add(button5);
            tabConf.Controls.Add(button4);
            tabConf.Controls.Add(button3);
            tabConf.Controls.Add(button2);
            tabConf.Controls.Add(button1);
            tabConf.Controls.Add(label8);
            tabConf.Controls.Add(label9);
            tabConf.Controls.Add(label10);
            tabConf.Controls.Add(label11);
            tabConf.Controls.Add(label12);
            tabConf.Controls.Add(label7);
            tabConf.Controls.Add(label6);
            tabConf.Controls.Add(label5);
            tabConf.Controls.Add(label4);
            tabConf.Controls.Add(label3);
            tabConf.Controls.Add(label2);
            tabConf.Controls.Add(label1);
            tabConf.Controls.Add(AllTeamsListBox);
            tabConf.Controls.Add(confName12);
            tabConf.Controls.Add(confName11);
            tabConf.Controls.Add(confName10);
            tabConf.Controls.Add(confName9);
            tabConf.Controls.Add(confName8);
            tabConf.Controls.Add(confName7);
            tabConf.Controls.Add(confName6);
            tabConf.Controls.Add(confName5);
            tabConf.Controls.Add(confName4);
            tabConf.Controls.Add(confName3);
            tabConf.Controls.Add(confName2);
            tabConf.Controls.Add(confName1);
            tabConf.Controls.Add(labelTeamSelection);
            tabConf.Controls.Add(DeselectButton);
            tabConf.Controls.Add(SaveButton);
            tabConf.Controls.Add(conf12);
            tabConf.Controls.Add(conf11);
            tabConf.Controls.Add(conf10);
            tabConf.Controls.Add(conf9);
            tabConf.Controls.Add(conf8);
            tabConf.Controls.Add(conf7);
            tabConf.Controls.Add(conf6);
            tabConf.Controls.Add(conf5);
            tabConf.Controls.Add(conf4);
            tabConf.Controls.Add(conf3);
            tabConf.Controls.Add(conf2);
            tabConf.Controls.Add(conf1);
            tabConf.Controls.Add(panel1);
            tabConf.Location = new Point(4, 24);
            tabConf.Name = "tabConf";
            tabConf.Padding = new Padding(3);
            tabConf.Size = new Size(1158, 1002);
            tabConf.TabIndex = 9;
            tabConf.Text = "Conferences";
            tabConf.MouseDown += MouseDown_Click;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.BackColor = Color.LightCoral;
            label31.Location = new Point(21, 419);
            label31.Name = "label31";
            label31.Size = new Size(104, 13);
            label31.TabIndex = 108;
            label31.Text = "Count: XX  Valid: No";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.BackColor = Color.LightCoral;
            label32.Location = new Point(177, 419);
            label32.Name = "label32";
            label32.Size = new Size(104, 13);
            label32.TabIndex = 107;
            label32.Text = "Count: XX  Valid: No";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.BackColor = Color.LightCoral;
            label33.Location = new Point(331, 419);
            label33.Name = "label33";
            label33.Size = new Size(104, 13);
            label33.TabIndex = 106;
            label33.Text = "Count: XX  Valid: No";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.BackColor = Color.LightCoral;
            label34.Location = new Point(487, 419);
            label34.Name = "label34";
            label34.Size = new Size(104, 13);
            label34.TabIndex = 105;
            label34.Text = "Count: XX  Valid: No";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.BackColor = Color.LightCoral;
            label35.Location = new Point(645, 419);
            label35.Name = "label35";
            label35.Size = new Size(104, 13);
            label35.TabIndex = 104;
            label35.Text = "Count: XX  Valid: No";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.BackColor = Color.LightCoral;
            label36.Location = new Point(801, 419);
            label36.Name = "label36";
            label36.Size = new Size(104, 13);
            label36.TabIndex = 103;
            label36.Text = "Count: XX  Valid: No";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.BackColor = Color.LightCoral;
            label30.Location = new Point(802, 27);
            label30.Name = "label30";
            label30.Size = new Size(104, 13);
            label30.TabIndex = 102;
            label30.Text = "Count: XX  Valid: No";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.BackColor = Color.LightCoral;
            label29.Location = new Point(646, 27);
            label29.Name = "label29";
            label29.Size = new Size(104, 13);
            label29.TabIndex = 101;
            label29.Text = "Count: XX  Valid: No";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = Color.LightCoral;
            label28.Location = new Point(488, 27);
            label28.Name = "label28";
            label28.Size = new Size(104, 13);
            label28.TabIndex = 100;
            label28.Text = "Count: XX  Valid: No";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.BackColor = Color.LightCoral;
            label27.Location = new Point(332, 27);
            label27.Name = "label27";
            label27.Size = new Size(104, 13);
            label27.TabIndex = 99;
            label27.Text = "Count: XX  Valid: No";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = Color.LightCoral;
            label26.Location = new Point(176, 27);
            label26.Name = "label26";
            label26.Size = new Size(104, 13);
            label26.TabIndex = 98;
            label26.Text = "Count: XX  Valid: No";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.LightCoral;
            label25.Location = new Point(19, 27);
            label25.Name = "label25";
            label25.Size = new Size(104, 13);
            label25.TabIndex = 97;
            label25.Text = "Count: XX  Valid: No";
            // 
            // ClearLeagueButton
            // 
            ClearLeagueButton.BackColor = Color.SlateBlue;
            ClearLeagueButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClearLeagueButton.ForeColor = SystemColors.Control;
            ClearLeagueButton.Location = new Point(975, 6);
            ClearLeagueButton.Name = "ClearLeagueButton";
            ClearLeagueButton.Size = new Size(161, 25);
            ClearLeagueButton.TabIndex = 96;
            ClearLeagueButton.Text = "CLEAR LEAGUE";
            ClearLeagueButton.UseVisualStyleBackColor = false;
            ClearLeagueButton.Click += ClearLeagueButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.BackColor = Color.SlateBlue;
            RemoveButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RemoveButton.ForeColor = SystemColors.Control;
            RemoveButton.Location = new Point(972, 606);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(161, 37);
            RemoveButton.TabIndex = 95;
            RemoveButton.Text = "REMOVE TEAM";
            RemoveButton.UseVisualStyleBackColor = false;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // LeagueTeamsLabel
            // 
            LeagueTeamsLabel.AutoSize = true;
            LeagueTeamsLabel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LeagueTeamsLabel.Location = new Point(6, 3);
            LeagueTeamsLabel.Name = "LeagueTeamsLabel";
            LeagueTeamsLabel.Size = new Size(156, 18);
            LeagueTeamsLabel.TabIndex = 94;
            LeagueTeamsLabel.Text = "League Teams XXX";
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.RoyalBlue;
            AddButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddButton.ForeColor = SystemColors.Control;
            AddButton.Location = new Point(972, 563);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(161, 37);
            AddButton.TabIndex = 93;
            AddButton.Text = "ADD TEAM";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(859, 785);
            label19.Name = "label19";
            label19.Size = new Size(48, 13);
            label19.TabIndex = 92;
            label19.Text = "Prestige:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(701, 785);
            label20.Name = "label20";
            label20.Size = new Size(48, 13);
            label20.TabIndex = 91;
            label20.Text = "Prestige:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(543, 785);
            label21.Name = "label21";
            label21.Size = new Size(48, 13);
            label21.TabIndex = 90;
            label21.Text = "Prestige:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(387, 785);
            label22.Name = "label22";
            label22.Size = new Size(48, 13);
            label22.TabIndex = 89;
            label22.Text = "Prestige:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(233, 785);
            label23.Name = "label23";
            label23.Size = new Size(48, 13);
            label23.TabIndex = 88;
            label23.Text = "Prestige:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(77, 785);
            label24.Name = "label24";
            label24.Size = new Size(48, 13);
            label24.TabIndex = 87;
            label24.Text = "Prestige:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(861, 393);
            label17.Name = "label17";
            label17.Size = new Size(48, 13);
            label17.TabIndex = 86;
            label17.Text = "Prestige:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(703, 393);
            label18.Name = "label18";
            label18.Size = new Size(48, 13);
            label18.TabIndex = 85;
            label18.Text = "Prestige:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(545, 393);
            label15.Name = "label15";
            label15.Size = new Size(48, 13);
            label15.TabIndex = 84;
            label15.Text = "Prestige:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(389, 393);
            label16.Name = "label16";
            label16.Size = new Size(48, 13);
            label16.TabIndex = 83;
            label16.Text = "Prestige:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(235, 393);
            label14.Name = "label14";
            label14.Size = new Size(48, 13);
            label14.TabIndex = 82;
            label14.Text = "Prestige:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(79, 393);
            label13.Name = "label13";
            label13.Size = new Size(48, 13);
            label13.TabIndex = 81;
            label13.Text = "Prestige:";
            // 
            // numericUpDown7
            // 
            numericUpDown7.Location = new Point(126, 782);
            numericUpDown7.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown7.Name = "numericUpDown7";
            numericUpDown7.Size = new Size(41, 20);
            numericUpDown7.TabIndex = 80;
            // 
            // numericUpDown8
            // 
            numericUpDown8.Location = new Point(281, 782);
            numericUpDown8.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown8.Name = "numericUpDown8";
            numericUpDown8.Size = new Size(41, 20);
            numericUpDown8.TabIndex = 79;
            // 
            // numericUpDown9
            // 
            numericUpDown9.Location = new Point(438, 782);
            numericUpDown9.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown9.Name = "numericUpDown9";
            numericUpDown9.Size = new Size(41, 20);
            numericUpDown9.TabIndex = 78;
            // 
            // numericUpDown10
            // 
            numericUpDown10.Location = new Point(592, 782);
            numericUpDown10.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown10.Name = "numericUpDown10";
            numericUpDown10.Size = new Size(41, 20);
            numericUpDown10.TabIndex = 77;
            // 
            // numericUpDown11
            // 
            numericUpDown11.Location = new Point(748, 782);
            numericUpDown11.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown11.Name = "numericUpDown11";
            numericUpDown11.Size = new Size(41, 20);
            numericUpDown11.TabIndex = 76;
            // 
            // numericUpDown12
            // 
            numericUpDown12.Location = new Point(907, 782);
            numericUpDown12.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown12.Name = "numericUpDown12";
            numericUpDown12.Size = new Size(41, 20);
            numericUpDown12.TabIndex = 75;
            // 
            // numericUpDown6
            // 
            numericUpDown6.Location = new Point(911, 390);
            numericUpDown6.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown6.Name = "numericUpDown6";
            numericUpDown6.Size = new Size(41, 20);
            numericUpDown6.TabIndex = 74;
            // 
            // numericUpDown5
            // 
            numericUpDown5.Location = new Point(752, 390);
            numericUpDown5.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown5.Name = "numericUpDown5";
            numericUpDown5.Size = new Size(41, 20);
            numericUpDown5.TabIndex = 73;
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(596, 390);
            numericUpDown4.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(41, 20);
            numericUpDown4.TabIndex = 72;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(440, 390);
            numericUpDown3.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(41, 20);
            numericUpDown3.TabIndex = 71;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(285, 390);
            numericUpDown2.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(41, 20);
            numericUpDown2.TabIndex = 70;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(128, 390);
            numericUpDown1.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(41, 20);
            numericUpDown1.TabIndex = 69;
            // 
            // button7
            // 
            button7.BackColor = Color.LightBlue;
            button7.Location = new Point(124, 445);
            button7.Name = "button7";
            button7.Size = new Size(43, 23);
            button7.TabIndex = 68;
            button7.Text = "FBS";
            button7.UseVisualStyleBackColor = false;
            button7.Click += LeagueChange_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.LightBlue;
            button8.Location = new Point(281, 445);
            button8.Name = "button8";
            button8.Size = new Size(43, 23);
            button8.TabIndex = 67;
            button8.Text = "FBS";
            button8.UseVisualStyleBackColor = false;
            button8.Click += LeagueChange_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.LightBlue;
            button9.Location = new Point(436, 445);
            button9.Name = "button9";
            button9.Size = new Size(43, 23);
            button9.TabIndex = 66;
            button9.Text = "FBS";
            button9.UseVisualStyleBackColor = false;
            button9.Click += LeagueChange_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.LightBlue;
            button10.Location = new Point(592, 445);
            button10.Name = "button10";
            button10.Size = new Size(43, 23);
            button10.TabIndex = 65;
            button10.Text = "FBS";
            button10.UseVisualStyleBackColor = false;
            button10.Click += LeagueChange_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.LightBlue;
            button11.Location = new Point(749, 445);
            button11.Name = "button11";
            button11.Size = new Size(43, 23);
            button11.TabIndex = 64;
            button11.Text = "FBS";
            button11.UseVisualStyleBackColor = false;
            button11.Click += LeagueChange_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.LightBlue;
            button12.Location = new Point(904, 445);
            button12.Name = "button12";
            button12.Size = new Size(43, 23);
            button12.TabIndex = 63;
            button12.Text = "FBS";
            button12.UseVisualStyleBackColor = false;
            button12.Click += LeagueChange_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.LightBlue;
            button6.Location = new Point(905, 54);
            button6.Name = "button6";
            button6.Size = new Size(43, 23);
            button6.TabIndex = 62;
            button6.Text = "FBS";
            button6.UseVisualStyleBackColor = false;
            button6.Click += LeagueChange_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightBlue;
            button5.Location = new Point(749, 54);
            button5.Name = "button5";
            button5.Size = new Size(43, 23);
            button5.TabIndex = 61;
            button5.Text = "FBS";
            button5.UseVisualStyleBackColor = false;
            button5.Click += LeagueChange_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.Location = new Point(593, 54);
            button4.Name = "button4";
            button4.Size = new Size(43, 23);
            button4.TabIndex = 60;
            button4.Text = "FBS";
            button4.UseVisualStyleBackColor = false;
            button4.Click += LeagueChange_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.LightBlue;
            button3.Location = new Point(437, 54);
            button3.Name = "button3";
            button3.Size = new Size(43, 23);
            button3.TabIndex = 59;
            button3.Text = "FBS";
            button3.UseVisualStyleBackColor = false;
            button3.Click += LeagueChange_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Location = new Point(282, 54);
            button2.Name = "button2";
            button2.Size = new Size(43, 23);
            button2.TabIndex = 58;
            button2.Text = "FBS";
            button2.UseVisualStyleBackColor = false;
            button2.Click += LeagueChange_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.Location = new Point(125, 54);
            button1.Name = "button1";
            button1.Size = new Size(43, 23);
            button1.TabIndex = 57;
            button1.Text = "FBS";
            button1.UseVisualStyleBackColor = false;
            button1.Click += LeagueChange_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(171, 784);
            label8.Name = "label8";
            label8.Size = new Size(27, 13);
            label8.TabIndex = 56;
            label8.Text = "cgid";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(328, 784);
            label9.Name = "label9";
            label9.Size = new Size(27, 13);
            label9.TabIndex = 55;
            label9.Text = "cgid";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(483, 784);
            label10.Name = "label10";
            label10.Size = new Size(27, 13);
            label10.TabIndex = 54;
            label10.Text = "cgid";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(639, 784);
            label11.Name = "label11";
            label11.Size = new Size(27, 13);
            label11.TabIndex = 53;
            label11.Text = "cgid";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(795, 784);
            label12.Name = "label12";
            label12.Size = new Size(27, 13);
            label12.TabIndex = 52;
            label12.Text = "cgid";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 784);
            label7.Name = "label7";
            label7.Size = new Size(27, 13);
            label7.TabIndex = 51;
            label7.Text = "cgid";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(799, 392);
            label6.Name = "label6";
            label6.Size = new Size(27, 13);
            label6.TabIndex = 50;
            label6.Text = "cgid";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(643, 392);
            label5.Name = "label5";
            label5.Size = new Size(27, 13);
            label5.TabIndex = 49;
            label5.Text = "cgid";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(487, 392);
            label4.Name = "label4";
            label4.Size = new Size(27, 13);
            label4.TabIndex = 48;
            label4.Text = "cgid";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(331, 392);
            label3.Name = "label3";
            label3.Size = new Size(27, 13);
            label3.TabIndex = 47;
            label3.Text = "cgid";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 392);
            label2.Name = "label2";
            label2.Size = new Size(27, 13);
            label2.TabIndex = 46;
            label2.Text = "cgid";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 392);
            label1.Name = "label1";
            label1.Size = new Size(27, 13);
            label1.TabIndex = 45;
            label1.Text = "cgid";
            // 
            // AllTeamsListBox
            // 
            AllTeamsListBox.AllowDrop = true;
            AllTeamsListBox.BackColor = SystemColors.ControlLight;
            AllTeamsListBox.FormattingEnabled = true;
            AllTeamsListBox.ItemHeight = 13;
            AllTeamsListBox.Location = new Point(975, 77);
            AllTeamsListBox.Name = "AllTeamsListBox";
            AllTeamsListBox.Size = new Size(161, 472);
            AllTeamsListBox.TabIndex = 44;
            AllTeamsListBox.SelectedIndexChanged += AllTeamsListBox_SelectedIndexChanged;
            AllTeamsListBox.MouseDown += MouseClick_AddTeam;
            // 
            // confName12
            // 
            confName12.Location = new Point(798, 448);
            confName12.MaxLength = 31;
            confName12.Name = "confName12";
            confName12.Size = new Size(100, 20);
            confName12.TabIndex = 43;
            // 
            // confName11
            // 
            confName11.Location = new Point(642, 448);
            confName11.MaxLength = 31;
            confName11.Name = "confName11";
            confName11.Size = new Size(100, 20);
            confName11.TabIndex = 42;
            // 
            // confName10
            // 
            confName10.Location = new Point(486, 448);
            confName10.MaxLength = 31;
            confName10.Name = "confName10";
            confName10.Size = new Size(100, 20);
            confName10.TabIndex = 41;
            // 
            // confName9
            // 
            confName9.Location = new Point(330, 448);
            confName9.MaxLength = 31;
            confName9.Name = "confName9";
            confName9.Size = new Size(100, 20);
            confName9.TabIndex = 40;
            // 
            // confName8
            // 
            confName8.Location = new Point(174, 448);
            confName8.MaxLength = 31;
            confName8.Name = "confName8";
            confName8.Size = new Size(100, 20);
            confName8.TabIndex = 39;
            // 
            // confName7
            // 
            confName7.Location = new Point(18, 448);
            confName7.MaxLength = 31;
            confName7.Name = "confName7";
            confName7.Size = new Size(100, 20);
            confName7.TabIndex = 38;
            // 
            // confName6
            // 
            confName6.Location = new Point(799, 54);
            confName6.MaxLength = 31;
            confName6.Name = "confName6";
            confName6.Size = new Size(100, 20);
            confName6.TabIndex = 37;
            // 
            // confName5
            // 
            confName5.Location = new Point(643, 54);
            confName5.MaxLength = 31;
            confName5.Name = "confName5";
            confName5.Size = new Size(100, 20);
            confName5.TabIndex = 36;
            // 
            // confName4
            // 
            confName4.Location = new Point(487, 54);
            confName4.MaxLength = 31;
            confName4.Name = "confName4";
            confName4.Size = new Size(100, 20);
            confName4.TabIndex = 35;
            // 
            // confName3
            // 
            confName3.Location = new Point(331, 54);
            confName3.MaxLength = 31;
            confName3.Name = "confName3";
            confName3.Size = new Size(100, 20);
            confName3.TabIndex = 34;
            // 
            // confName2
            // 
            confName2.Location = new Point(175, 54);
            confName2.MaxLength = 31;
            confName2.Name = "confName2";
            confName2.Size = new Size(100, 20);
            confName2.TabIndex = 33;
            // 
            // confName1
            // 
            confName1.Location = new Point(19, 54);
            confName1.MaxLength = 31;
            confName1.Name = "confName1";
            confName1.Size = new Size(100, 20);
            confName1.TabIndex = 32;
            // 
            // labelTeamSelection
            // 
            labelTeamSelection.AllowDrop = true;
            labelTeamSelection.AutoSize = true;
            labelTeamSelection.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTeamSelection.Location = new Point(972, 58);
            labelTeamSelection.Name = "labelTeamSelection";
            labelTeamSelection.Size = new Size(116, 16);
            labelTeamSelection.TabIndex = 30;
            labelTeamSelection.Text = "Team Selection";
            // 
            // DeselectButton
            // 
            DeselectButton.BackColor = Color.DarkSlateBlue;
            DeselectButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeselectButton.ForeColor = SystemColors.Control;
            DeselectButton.Location = new Point(972, 649);
            DeselectButton.Name = "DeselectButton";
            DeselectButton.Size = new Size(161, 37);
            DeselectButton.TabIndex = 25;
            DeselectButton.Text = "DESELECT TEAM";
            DeselectButton.UseVisualStyleBackColor = false;
            DeselectButton.Click += DeselectTeamsButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.BackColor = Color.Crimson;
            SaveButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveButton.ForeColor = SystemColors.ButtonFace;
            SaveButton.Location = new Point(972, 694);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(161, 37);
            SaveButton.TabIndex = 24;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = false;
            SaveButton.Click += SaveButton_Cick;
            // 
            // conf12
            // 
            conf12.AllowDrop = true;
            conf12.BackColor = Color.Gainsboro;
            conf12.CheckOnClick = true;
            conf12.FormattingEnabled = true;
            conf12.Location = new Point(798, 474);
            conf12.Name = "conf12";
            conf12.Size = new Size(150, 304);
            conf12.TabIndex = 11;
            conf12.ItemCheck += TeamChecked;
            conf12.KeyDown += UserKeyDown;
            conf12.PreviewKeyDown += UserKeyPreview;
            // 
            // conf11
            // 
            conf11.AllowDrop = true;
            conf11.BackColor = Color.Gainsboro;
            conf11.CheckOnClick = true;
            conf11.FormattingEnabled = true;
            conf11.Location = new Point(642, 474);
            conf11.Name = "conf11";
            conf11.Size = new Size(150, 304);
            conf11.TabIndex = 10;
            conf11.ItemCheck += TeamChecked;
            conf11.KeyDown += UserKeyDown;
            conf11.PreviewKeyDown += UserKeyPreview;
            // 
            // conf10
            // 
            conf10.AllowDrop = true;
            conf10.BackColor = Color.Gainsboro;
            conf10.CheckOnClick = true;
            conf10.FormattingEnabled = true;
            conf10.Location = new Point(486, 474);
            conf10.Name = "conf10";
            conf10.Size = new Size(150, 304);
            conf10.TabIndex = 9;
            conf10.ItemCheck += TeamChecked;
            conf10.KeyDown += UserKeyDown;
            conf10.PreviewKeyDown += UserKeyPreview;
            // 
            // conf9
            // 
            conf9.AllowDrop = true;
            conf9.BackColor = Color.Gainsboro;
            conf9.CheckOnClick = true;
            conf9.FormattingEnabled = true;
            conf9.Location = new Point(330, 474);
            conf9.Name = "conf9";
            conf9.Size = new Size(150, 304);
            conf9.TabIndex = 8;
            conf9.ItemCheck += TeamChecked;
            conf9.KeyDown += UserKeyDown;
            conf9.PreviewKeyDown += UserKeyPreview;
            // 
            // conf8
            // 
            conf8.AllowDrop = true;
            conf8.BackColor = Color.Gainsboro;
            conf8.CheckOnClick = true;
            conf8.FormattingEnabled = true;
            conf8.Location = new Point(174, 474);
            conf8.Name = "conf8";
            conf8.Size = new Size(150, 304);
            conf8.TabIndex = 7;
            conf8.ItemCheck += TeamChecked;
            conf8.KeyDown += UserKeyDown;
            conf8.PreviewKeyDown += UserKeyPreview;
            // 
            // conf7
            // 
            conf7.AllowDrop = true;
            conf7.BackColor = Color.Gainsboro;
            conf7.CheckOnClick = true;
            conf7.FormattingEnabled = true;
            conf7.Location = new Point(18, 474);
            conf7.Name = "conf7";
            conf7.Size = new Size(150, 304);
            conf7.TabIndex = 6;
            conf7.ItemCheck += TeamChecked;
            conf7.KeyDown += UserKeyDown;
            conf7.PreviewKeyDown += UserKeyPreview;
            // 
            // conf6
            // 
            conf6.AllowDrop = true;
            conf6.BackColor = Color.WhiteSmoke;
            conf6.CheckOnClick = true;
            conf6.FormattingEnabled = true;
            conf6.Location = new Point(799, 80);
            conf6.Name = "conf6";
            conf6.Size = new Size(150, 304);
            conf6.TabIndex = 5;
            conf6.ItemCheck += TeamChecked;
            conf6.KeyDown += UserKeyDown;
            conf6.PreviewKeyDown += UserKeyPreview;
            // 
            // conf5
            // 
            conf5.AllowDrop = true;
            conf5.BackColor = Color.Gainsboro;
            conf5.CheckOnClick = true;
            conf5.FormattingEnabled = true;
            conf5.Location = new Point(643, 80);
            conf5.Name = "conf5";
            conf5.Size = new Size(150, 304);
            conf5.TabIndex = 4;
            conf5.ItemCheck += TeamChecked;
            conf5.KeyDown += UserKeyDown;
            conf5.PreviewKeyDown += UserKeyPreview;
            // 
            // conf4
            // 
            conf4.AllowDrop = true;
            conf4.BackColor = Color.Gainsboro;
            conf4.CheckOnClick = true;
            conf4.FormattingEnabled = true;
            conf4.Location = new Point(487, 80);
            conf4.Name = "conf4";
            conf4.Size = new Size(150, 304);
            conf4.TabIndex = 3;
            conf4.ItemCheck += TeamChecked;
            conf4.KeyDown += UserKeyDown;
            conf4.PreviewKeyDown += UserKeyPreview;
            // 
            // conf3
            // 
            conf3.AllowDrop = true;
            conf3.BackColor = Color.Gainsboro;
            conf3.CheckOnClick = true;
            conf3.FormattingEnabled = true;
            conf3.Location = new Point(331, 80);
            conf3.Name = "conf3";
            conf3.Size = new Size(150, 304);
            conf3.TabIndex = 2;
            conf3.ItemCheck += TeamChecked;
            conf3.KeyDown += UserKeyDown;
            conf3.PreviewKeyDown += UserKeyPreview;
            // 
            // conf2
            // 
            conf2.AllowDrop = true;
            conf2.BackColor = Color.Gainsboro;
            conf2.CheckOnClick = true;
            conf2.FormattingEnabled = true;
            conf2.Location = new Point(175, 80);
            conf2.Name = "conf2";
            conf2.Size = new Size(150, 304);
            conf2.TabIndex = 1;
            conf2.ItemCheck += TeamChecked;
            conf2.KeyDown += UserKeyDown;
            conf2.PreviewKeyDown += UserKeyPreview;
            // 
            // conf1
            // 
            conf1.AllowDrop = true;
            conf1.BackColor = Color.Gainsboro;
            conf1.CheckOnClick = true;
            conf1.FormattingEnabled = true;
            conf1.Location = new Point(19, 80);
            conf1.Name = "conf1";
            conf1.Size = new Size(150, 304);
            conf1.TabIndex = 0;
            conf1.ItemCheck += TeamChecked;
            conf1.KeyDown += UserKeyDown;
            conf1.PreviewKeyDown += UserKeyPreview;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuBar;
            panel1.Controls.Add(label39);
            panel1.Controls.Add(TeamSelectionBox);
            panel1.Controls.Add(label38);
            panel1.Controls.Add(TeamsPerConfBox);
            panel1.Controls.Add(RandomizeLeagueButton);
            panel1.Location = new Point(18, 816);
            panel1.Name = "panel1";
            panel1.Size = new Size(461, 59);
            panel1.TabIndex = 110;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(307, 12);
            label39.Name = "label39";
            label39.Size = new Size(81, 13);
            label39.TabIndex = 113;
            label39.Text = "Team Selection";
            // 
            // TeamSelectionBox
            // 
            TeamSelectionBox.FormattingEnabled = true;
            TeamSelectionBox.Items.AddRange(new object[] { "FBS Only", "FCS Only", "Any Team" });
            TeamSelectionBox.Location = new Point(312, 28);
            TeamSelectionBox.Name = "TeamSelectionBox";
            TeamSelectionBox.Size = new Size(121, 21);
            TeamSelectionBox.TabIndex = 112;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(198, 12);
            label38.Name = "label38";
            label38.Size = new Size(82, 13);
            label38.TabIndex = 111;
            label38.Text = "Teams per Conf";
            // 
            // TeamsPerConfBox
            // 
            TeamsPerConfBox.FormattingEnabled = true;
            TeamsPerConfBox.Items.AddRange(new object[] { "10", "12", "20" });
            TeamsPerConfBox.Location = new Point(196, 28);
            TeamsPerConfBox.Name = "TeamsPerConfBox";
            TeamsPerConfBox.Size = new Size(79, 21);
            TeamsPerConfBox.Sorted = true;
            TeamsPerConfBox.TabIndex = 110;
            // 
            // RandomizeLeagueButton
            // 
            RandomizeLeagueButton.BackColor = Color.Navy;
            RandomizeLeagueButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RandomizeLeagueButton.ForeColor = SystemColors.ButtonFace;
            RandomizeLeagueButton.Location = new Point(9, 11);
            RandomizeLeagueButton.Name = "RandomizeLeagueButton";
            RandomizeLeagueButton.Size = new Size(161, 37);
            RandomizeLeagueButton.TabIndex = 109;
            RandomizeLeagueButton.Text = "Randomize League";
            RandomizeLeagueButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            RandomizeLeagueButton.UseVisualStyleBackColor = false;
            RandomizeLeagueButton.Click += RandomizeLeagueButton_Click;
            // 
            // tabDB
            // 
            tabDB.BackColor = SystemColors.Control;
            tabDB.Controls.Add(groupBox2);
            tabDB.Controls.Add(groupBox3);
            tabDB.Controls.Add(tableGridView);
            tabDB.Controls.Add(fieldsGridView);
            tabDB.Location = new Point(4, 24);
            tabDB.Name = "tabDB";
            tabDB.Padding = new Padding(3);
            tabDB.Size = new Size(1158, 1002);
            tabDB.TabIndex = 0;
            tabDB.Text = "DB Editor";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox2.Controls.Add(lblTableProps);
            groupBox2.ForeColor = SystemColors.ControlText;
            groupBox2.Location = new Point(9, 839);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(375, 46);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Table Properties";
            // 
            // lblTableProps
            // 
            lblTableProps.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTableProps.ForeColor = SystemColors.ControlText;
            lblTableProps.Location = new Point(6, 15);
            lblTableProps.Name = "lblTableProps";
            lblTableProps.Size = new Size(363, 19);
            lblTableProps.TabIndex = 5;
            lblTableProps.Text = "TableProps";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBox3.Controls.Add(lblFieldProps);
            groupBox3.ForeColor = SystemColors.ControlText;
            groupBox3.Location = new Point(400, 839);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(345, 46);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Field Properties";
            // 
            // lblFieldProps
            // 
            lblFieldProps.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblFieldProps.ForeColor = SystemColors.ControlText;
            lblFieldProps.Location = new Point(6, 19);
            lblFieldProps.Name = "lblFieldProps";
            lblFieldProps.Size = new Size(333, 21);
            lblFieldProps.TabIndex = 6;
            lblFieldProps.Text = "FieldsPropsLabel";
            // 
            // tableGridView
            // 
            tableGridView.AllowUserToAddRows = false;
            tableGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            tableGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tableGridView.BackgroundColor = SystemColors.Control;
            tableGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableGridView.ContextMenuStrip = tableMenu;
            tableGridView.GridColor = SystemColors.Window;
            tableGridView.Location = new Point(3, 6);
            tableGridView.Name = "tableGridView";
            tableGridView.RowHeadersVisible = false;
            tableGridView.RowTemplate.Height = 18;
            tableGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGridView.Size = new Size(107, 827);
            tableGridView.TabIndex = 2;
            tableGridView.SelectionChanged += TableGridView_SelectionChanged;
            // 
            // fieldsGridView
            // 
            fieldsGridView.AllowDrop = true;
            fieldsGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            fieldsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            fieldsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fieldsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            fieldsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            fieldsGridView.BackgroundColor = SystemColors.Control;
            fieldsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            fieldsGridView.ContextMenuStrip = fieldMenu;
            fieldsGridView.GridColor = SystemColors.ScrollBar;
            fieldsGridView.Location = new Point(116, 6);
            fieldsGridView.Name = "fieldsGridView";
            fieldsGridView.RowHeadersVisible = false;
            fieldsGridView.RowTemplate.Height = 18;
            fieldsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            fieldsGridView.Size = new Size(1030, 827);
            fieldsGridView.TabIndex = 3;
            fieldsGridView.CellValueChanged += FieldGridView_CellValueChanged;
            fieldsGridView.CurrentCellChanged += FieldGridView_CurrentCellChanged;
            // 
            // tabHome
            // 
            tabHome.BackColor = Color.DarkSlateBlue;
            tabHome.Controls.Add(groupBox1);
            tabHome.Location = new Point(4, 24);
            tabHome.Name = "tabHome";
            tabHome.Padding = new Padding(3);
            tabHome.Size = new Size(1158, 1002);
            tabHome.TabIndex = 6;
            tabHome.Text = "Home";
            tabHome.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Next26Config);
            groupBox1.Controls.Add(OGConfigRadio);
            groupBox1.Controls.Add(NextConfigRadio);
            groupBox1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Control;
            groupBox1.Location = new Point(34, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 318);
            groupBox1.TabIndex = 144;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // Next26Config
            // 
            Next26Config.AutoSize = true;
            Next26Config.Location = new Point(23, 120);
            Next26Config.Name = "Next26Config";
            Next26Config.Size = new Size(163, 20);
            Next26Config.TabIndex = 2;
            Next26Config.Text = "NCAA Next 26+ Mod";
            Next26Config.UseVisualStyleBackColor = true;
            Next26Config.CheckedChanged += Next26Config_CheckedChanged;
            // 
            // OGConfigRadio
            // 
            OGConfigRadio.AutoSize = true;
            OGConfigRadio.Checked = true;
            OGConfigRadio.Location = new Point(23, 21);
            OGConfigRadio.Name = "OGConfigRadio";
            OGConfigRadio.Size = new Size(144, 20);
            OGConfigRadio.TabIndex = 1;
            OGConfigRadio.TabStop = true;
            OGConfigRadio.Text = "NCAA 06 Original";
            OGConfigRadio.UseVisualStyleBackColor = true;
            OGConfigRadio.CheckedChanged += OGConfigRadio_CheckedChanged;
            // 
            // NextConfigRadio
            // 
            NextConfigRadio.AutoSize = true;
            NextConfigRadio.Location = new Point(23, 68);
            NextConfigRadio.Name = "NextConfigRadio";
            NextConfigRadio.Size = new Size(121, 20);
            NextConfigRadio.TabIndex = 0;
            NextConfigRadio.Text = "NCAA Next 25";
            NextConfigRadio.UseVisualStyleBackColor = true;
            NextConfigRadio.CheckedChanged += NextConfigRadio_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.Controls.Add(tabHome);
            tabControl1.Controls.Add(tabDB);
            tabControl1.Controls.Add(tabConf);
            tabControl1.Controls.Add(tabAnnuals);
            tabControl1.Controls.Add(tabCChamps);
            tabControl1.Controls.Add(tabBowls);
            tabControl1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabControl1.ItemSize = new Size(125, 20);
            tabControl1.Location = new Point(12, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1166, 1030);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 4;
            tabControl1.Visible = false;
            tabControl1.SelectedIndexChanged += TabControl1_IndexChange;
            // 
            // tabAnnuals
            // 
            tabAnnuals.Controls.Add(ClearAllButton);
            tabAnnuals.Controls.Add(SaveSANNButton);
            tabAnnuals.Controls.Add(DeleteGameButton);
            tabAnnuals.Controls.Add(AnnualsGrid);
            tabAnnuals.Location = new Point(4, 24);
            tabAnnuals.Name = "tabAnnuals";
            tabAnnuals.Padding = new Padding(3);
            tabAnnuals.Size = new Size(1158, 1002);
            tabAnnuals.TabIndex = 10;
            tabAnnuals.Text = "Annuals";
            tabAnnuals.UseVisualStyleBackColor = true;
            // 
            // ClearAllButton
            // 
            ClearAllButton.BackColor = Color.GhostWhite;
            ClearAllButton.Location = new Point(430, 236);
            ClearAllButton.Name = "ClearAllButton";
            ClearAllButton.RightToLeft = RightToLeft.No;
            ClearAllButton.Size = new Size(122, 54);
            ClearAllButton.TabIndex = 3;
            ClearAllButton.Text = "Clear All";
            ClearAllButton.UseVisualStyleBackColor = false;
            ClearAllButton.Click += ClearAllButton_Click;
            // 
            // SaveSANNButton
            // 
            SaveSANNButton.BackColor = Color.Crimson;
            SaveSANNButton.Location = new Point(430, 130);
            SaveSANNButton.Name = "SaveSANNButton";
            SaveSANNButton.RightToLeft = RightToLeft.No;
            SaveSANNButton.Size = new Size(122, 54);
            SaveSANNButton.TabIndex = 2;
            SaveSANNButton.Text = "Save";
            SaveSANNButton.UseVisualStyleBackColor = false;
            SaveSANNButton.Click += SaveSANNButton_Click;
            // 
            // DeleteGameButton
            // 
            DeleteGameButton.BackColor = Color.LightPink;
            DeleteGameButton.Location = new Point(430, 26);
            DeleteGameButton.Name = "DeleteGameButton";
            DeleteGameButton.Size = new Size(122, 54);
            DeleteGameButton.TabIndex = 1;
            DeleteGameButton.Text = "Delete Game";
            DeleteGameButton.UseVisualStyleBackColor = false;
            DeleteGameButton.Click += DeleteGameButton_Click;
            // 
            // AnnualsGrid
            // 
            AnnualsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            AnnualsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            AnnualsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            AnnualsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            AnnualsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            AnnualsGrid.DefaultCellStyle = dataGridViewCellStyle4;
            AnnualsGrid.Location = new Point(12, 6);
            AnnualsGrid.Name = "AnnualsGrid";
            AnnualsGrid.Size = new Size(400, 878);
            AnnualsGrid.TabIndex = 0;
            AnnualsGrid.DataError += AnnualsGrid_DataError;
            // 
            // tabCChamps
            // 
            tabCChamps.Controls.Add(label37);
            tabCChamps.Controls.Add(SaveChamps);
            tabCChamps.Controls.Add(ChampGrid);
            tabCChamps.Location = new Point(4, 24);
            tabCChamps.Name = "tabCChamps";
            tabCChamps.Padding = new Padding(3);
            tabCChamps.Size = new Size(1158, 1002);
            tabCChamps.TabIndex = 12;
            tabCChamps.Text = "Conf Championships";
            tabCChamps.UseVisualStyleBackColor = true;
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label37.Location = new Point(23, 23);
            label37.Name = "label37";
            label37.Size = new Size(346, 24);
            label37.TabIndex = 6;
            label37.Text = "Missing Conference Championships";
            // 
            // SaveChamps
            // 
            SaveChamps.BackColor = Color.Crimson;
            SaveChamps.Location = new Point(420, 51);
            SaveChamps.Name = "SaveChamps";
            SaveChamps.RightToLeft = RightToLeft.No;
            SaveChamps.Size = new Size(122, 54);
            SaveChamps.TabIndex = 5;
            SaveChamps.Text = "Save";
            SaveChamps.UseVisualStyleBackColor = false;
            SaveChamps.Click += SaveChamps_Click;
            // 
            // ChampGrid
            // 
            ChampGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(224, 224, 224);
            ChampGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            ChampGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChampGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ChampGrid.Columns.AddRange(new DataGridViewColumn[] { Conf, Bowl });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            ChampGrid.DefaultCellStyle = dataGridViewCellStyle6;
            ChampGrid.Location = new Point(28, 51);
            ChampGrid.Name = "ChampGrid";
            ChampGrid.RowHeadersVisible = false;
            ChampGrid.Size = new Size(352, 358);
            ChampGrid.TabIndex = 4;
            ChampGrid.DataError += ChampGrid_DataError;
            // 
            // Conf
            // 
            Conf.HeaderText = "Conference";
            Conf.Name = "Conf";
            // 
            // Bowl
            // 
            Bowl.HeaderText = "Bowl Selection";
            Bowl.Name = "Bowl";
            // 
            // tabBowls
            // 
            tabBowls.Controls.Add(AtLargeButton);
            tabBowls.Controls.Add(SaveBowlButton);
            tabBowls.Controls.Add(DeleteBowlButton);
            tabBowls.Controls.Add(BowlsGrid);
            tabBowls.Location = new Point(4, 24);
            tabBowls.Name = "tabBowls";
            tabBowls.Padding = new Padding(3);
            tabBowls.Size = new Size(1158, 1002);
            tabBowls.TabIndex = 11;
            tabBowls.Text = "Bowls";
            tabBowls.UseVisualStyleBackColor = true;
            // 
            // AtLargeButton
            // 
            AtLargeButton.BackColor = SystemColors.ActiveCaption;
            AtLargeButton.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AtLargeButton.Location = new Point(896, 201);
            AtLargeButton.Name = "AtLargeButton";
            AtLargeButton.Size = new Size(115, 51);
            AtLargeButton.TabIndex = 3;
            AtLargeButton.Text = "Set All to At-Large";
            AtLargeButton.UseVisualStyleBackColor = false;
            AtLargeButton.Click += AtLargeButton_Click;
            // 
            // SaveBowlButton
            // 
            SaveBowlButton.BackColor = Color.Crimson;
            SaveBowlButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveBowlButton.Location = new Point(896, 23);
            SaveBowlButton.Name = "SaveBowlButton";
            SaveBowlButton.Size = new Size(115, 52);
            SaveBowlButton.TabIndex = 2;
            SaveBowlButton.Text = "Save";
            SaveBowlButton.UseVisualStyleBackColor = false;
            SaveBowlButton.Click += SaveBowlButton_Click;
            // 
            // DeleteBowlButton
            // 
            DeleteBowlButton.BackColor = Color.PaleVioletRed;
            DeleteBowlButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteBowlButton.Location = new Point(896, 113);
            DeleteBowlButton.Name = "DeleteBowlButton";
            DeleteBowlButton.Size = new Size(115, 52);
            DeleteBowlButton.TabIndex = 1;
            DeleteBowlButton.Text = "Delete Row";
            DeleteBowlButton.UseVisualStyleBackColor = false;
            DeleteBowlButton.Click += DeleteBowlButton_Click;
            // 
            // BowlsGrid
            // 
            BowlsGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            BowlsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            BowlsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BowlsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BowlsGrid.Columns.AddRange(new DataGridViewColumn[] { BIDX, BNME, BCI1, BCR1, BCI2, BCR2, SGID, BMON, BDAY });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            BowlsGrid.DefaultCellStyle = dataGridViewCellStyle8;
            BowlsGrid.Location = new Point(38, 23);
            BowlsGrid.Name = "BowlsGrid";
            BowlsGrid.Size = new Size(816, 875);
            BowlsGrid.TabIndex = 0;
            BowlsGrid.CellValueChanged += BowlCellValueChanged;
            BowlsGrid.DataError += BowlsGrid_DataError;
            // 
            // BIDX
            // 
            BIDX.FillWeight = 58.21476F;
            BIDX.HeaderText = "BIDX";
            BIDX.Name = "BIDX";
            BIDX.ReadOnly = true;
            // 
            // BNME
            // 
            BNME.FillWeight = 184.7952F;
            BNME.HeaderText = "Bowl Name";
            BNME.Name = "BNME";
            // 
            // BCI1
            // 
            BCI1.FillWeight = 113.5889F;
            BCI1.HeaderText = "Conf A";
            BCI1.Name = "BCI1";
            // 
            // BCR1
            // 
            BCR1.FillWeight = 56.59636F;
            BCR1.HeaderText = "Conf A Seed";
            BCR1.Name = "BCR1";
            BCR1.Resizable = DataGridViewTriState.True;
            BCR1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // BCI2
            // 
            BCI2.FillWeight = 120.1694F;
            BCI2.HeaderText = "Conf B";
            BCI2.Name = "BCI2";
            // 
            // BCR2
            // 
            BCR2.FillWeight = 59.46095F;
            BCR2.HeaderText = "Conf B Seed";
            BCR2.Name = "BCR2";
            BCR2.Resizable = DataGridViewTriState.True;
            BCR2.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // SGID
            // 
            SGID.FillWeight = 188.292F;
            SGID.HeaderText = "Stadium";
            SGID.Name = "SGID";
            // 
            // BMON
            // 
            BMON.FillWeight = 57.73386F;
            BMON.HeaderText = "Month";
            BMON.Name = "BMON";
            // 
            // BDAY
            // 
            BDAY.FillWeight = 61.14862F;
            BDAY.HeaderText = "Date";
            BDAY.Name = "BDAY";
            // 
            // IndieCheckBox
            // 
            IndieCheckBox.AutoSize = true;
            IndieCheckBox.Checked = true;
            IndieCheckBox.CheckState = CheckState.Checked;
            IndieCheckBox.Enabled = false;
            IndieCheckBox.Location = new Point(802, 6);
            IndieCheckBox.Name = "IndieCheckBox";
            IndieCheckBox.Size = new Size(86, 17);
            IndieCheckBox.TabIndex = 111;
            IndieCheckBox.Text = "Independent";
            IndieCheckBox.UseVisualStyleBackColor = true;
            // 
            // LeagueMain
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1190, 941);
            Controls.Add(tabControl1);
            Controls.Add(progressBar1);
            Controls.Add(mainMenu);
            Controls.Add(TablePropsgroupBox);
            Controls.Add(FieldsPropsgroupBox);
            DoubleBuffered = true;
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenu;
            Name = "LeagueMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "League Editor";
            FormClosing += MainEditor_FormClosing;
            KeyDown += UserKeyDown;
            PreviewKeyDown += UserKeyPreview;
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            tableMenu.ResumeLayout(false);
            fieldMenu.ResumeLayout(false);
            TablePropsgroupBox.ResumeLayout(false);
            TablePropsgroupBox.PerformLayout();
            FieldsPropsgroupBox.ResumeLayout(false);
            FieldsPropsgroupBox.PerformLayout();
            tabConf.ResumeLayout(false);
            tabConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown7).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown8).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown9).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown10).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown11).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown12).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown6).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown5).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabDB.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tableGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)fieldsGridView).EndInit();
            tabHome.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabAnnuals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AnnualsGrid).EndInit();
            tabCChamps.ResumeLayout(false);
            tabCChamps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ChampGrid).EndInit();
            tabBowls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BowlsGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Button DeleteBowlButton;
        private System.Windows.Forms.Button SaveBowlButton;
        private ToolStripMenuItem CustomLeagueToolStrip;
        private ToolStripMenuItem importCustomLeagueToolStripMenuItem;
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
        private RadioButton Next26Config;
        private DataGridViewTextBoxColumn BIDX;
        private DataGridViewTextBoxColumn BNME;
        private DataGridViewComboBoxColumn BCI1;
        private DataGridViewTextBoxColumn BCR1;
        private DataGridViewComboBoxColumn BCI2;
        private DataGridViewTextBoxColumn BCR2;
        private DataGridViewComboBoxColumn SGID;
        private DataGridViewComboBoxColumn BMON;
        private DataGridViewComboBoxColumn BDAY;
        public GroupBox groupBox2;
        public Label lblTableProps;
        public GroupBox groupBox3;
        public Label lblFieldProps;
        private CheckBox IndieCheckBox;
    }
}

