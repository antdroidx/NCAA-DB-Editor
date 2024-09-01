using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Windows.Forms;

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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabConf = new System.Windows.Forms.TabPage();
            this.label80 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SwapRosterBox = new System.Windows.Forms.ComboBox();
            this.FCSSwapListBox = new System.Windows.Forms.ComboBox();
            this.DeselectTeamsButton = new System.Windows.Forms.Button();
            this.SwapButton = new System.Windows.Forms.Button();
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
            this.tabDB = new System.Windows.Forms.TabPage();
            this.tableGridView = new System.Windows.Forms.DataGridView();
            this.fieldsGridView = new System.Windows.Forms.DataGridView();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.confName1 = new System.Windows.Forms.TextBox();
            this.confName2 = new System.Windows.Forms.TextBox();
            this.confName3 = new System.Windows.Forms.TextBox();
            this.confName4 = new System.Windows.Forms.TextBox();
            this.confName5 = new System.Windows.Forms.TextBox();
            this.confName6 = new System.Windows.Forms.TextBox();
            this.confName12 = new System.Windows.Forms.TextBox();
            this.confName11 = new System.Windows.Forms.TextBox();
            this.confName10 = new System.Windows.Forms.TextBox();
            this.confName9 = new System.Windows.Forms.TextBox();
            this.confName8 = new System.Windows.Forms.TextBox();
            this.confName7 = new System.Windows.Forms.TextBox();
            this.mainMenu.SuspendLayout();
            this.tableMenu.SuspendLayout();
            this.fieldMenu.SuspendLayout();
            this.TablePropsgroupBox.SuspendLayout();
            this.FieldsPropsgroupBox.SuspendLayout();
            this.tabConf.SuspendLayout();
            this.tabDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).BeginInit();
            this.tabHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
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
            this.mainMenu.Size = new System.Drawing.Size(1184, 24);
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
            this.progressBar1.Location = new System.Drawing.Point(968, 732);
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
            this.TablePropsgroupBox.Location = new System.Drawing.Point(19, 725);
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
            this.FieldsPropsgroupBox.Location = new System.Drawing.Point(367, 725);
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
            this.tabConf.BackColor = System.Drawing.SystemColors.ScrollBar;
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
            this.tabConf.Controls.Add(this.label80);
            this.tabConf.Controls.Add(this.label4);
            this.tabConf.Controls.Add(this.SwapRosterBox);
            this.tabConf.Controls.Add(this.FCSSwapListBox);
            this.tabConf.Controls.Add(this.DeselectTeamsButton);
            this.tabConf.Controls.Add(this.SwapButton);
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
            this.tabConf.Size = new System.Drawing.Size(1152, 665);
            this.tabConf.TabIndex = 9;
            this.tabConf.Text = "Conferences";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.Location = new System.Drawing.Point(1024, 32);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(112, 13);
            this.label80.TabIndex = 31;
            this.label80.Text = "FCS Roster Option";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1011, 128);
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
            this.SwapRosterBox.Location = new System.Drawing.Point(1024, 48);
            this.SwapRosterBox.Name = "SwapRosterBox";
            this.SwapRosterBox.Size = new System.Drawing.Size(109, 21);
            this.SwapRosterBox.TabIndex = 29;
            // 
            // FCSSwapListBox
            // 
            this.FCSSwapListBox.FormattingEnabled = true;
            this.FCSSwapListBox.Location = new System.Drawing.Point(996, 101);
            this.FCSSwapListBox.Name = "FCSSwapListBox";
            this.FCSSwapListBox.Size = new System.Drawing.Size(150, 21);
            this.FCSSwapListBox.TabIndex = 26;
            // 
            // DeselectTeamsButton
            // 
            this.DeselectTeamsButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.DeselectTeamsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeselectTeamsButton.ForeColor = System.Drawing.SystemColors.Control;
            this.DeselectTeamsButton.Location = new System.Drawing.Point(996, 569);
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
            this.SwapButton.Location = new System.Drawing.Point(996, 612);
            this.SwapButton.Name = "SwapButton";
            this.SwapButton.Size = new System.Drawing.Size(150, 37);
            this.SwapButton.TabIndex = 24;
            this.SwapButton.Text = "SWAP TEAMS";
            this.SwapButton.UseVisualStyleBackColor = false;
            this.SwapButton.Click += new System.EventHandler(this.SwapButton_Click);
            // 
            // conf12
            // 
            this.conf12.BackColor = System.Drawing.Color.Gainsboro;
            this.conf12.FormattingEnabled = true;
            this.conf12.Location = new System.Drawing.Point(801, 375);
            this.conf12.Name = "conf12";
            this.conf12.Size = new System.Drawing.Size(150, 274);
            this.conf12.TabIndex = 11;
            this.conf12.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf11
            // 
            this.conf11.BackColor = System.Drawing.Color.Gainsboro;
            this.conf11.FormattingEnabled = true;
            this.conf11.Location = new System.Drawing.Point(645, 375);
            this.conf11.Name = "conf11";
            this.conf11.Size = new System.Drawing.Size(150, 274);
            this.conf11.TabIndex = 10;
            this.conf11.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf10
            // 
            this.conf10.BackColor = System.Drawing.Color.Gainsboro;
            this.conf10.FormattingEnabled = true;
            this.conf10.Location = new System.Drawing.Point(489, 375);
            this.conf10.Name = "conf10";
            this.conf10.Size = new System.Drawing.Size(150, 274);
            this.conf10.TabIndex = 9;
            this.conf10.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf9
            // 
            this.conf9.BackColor = System.Drawing.Color.Gainsboro;
            this.conf9.FormattingEnabled = true;
            this.conf9.Location = new System.Drawing.Point(333, 375);
            this.conf9.Name = "conf9";
            this.conf9.Size = new System.Drawing.Size(150, 274);
            this.conf9.TabIndex = 8;
            this.conf9.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf8
            // 
            this.conf8.BackColor = System.Drawing.Color.Gainsboro;
            this.conf8.FormattingEnabled = true;
            this.conf8.Location = new System.Drawing.Point(177, 375);
            this.conf8.Name = "conf8";
            this.conf8.Size = new System.Drawing.Size(150, 274);
            this.conf8.TabIndex = 7;
            this.conf8.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf7
            // 
            this.conf7.BackColor = System.Drawing.Color.Gainsboro;
            this.conf7.FormattingEnabled = true;
            this.conf7.Location = new System.Drawing.Point(21, 375);
            this.conf7.Name = "conf7";
            this.conf7.Size = new System.Drawing.Size(150, 274);
            this.conf7.TabIndex = 6;
            this.conf7.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf6
            // 
            this.conf6.BackColor = System.Drawing.Color.Gainsboro;
            this.conf6.FormattingEnabled = true;
            this.conf6.Location = new System.Drawing.Point(801, 36);
            this.conf6.Name = "conf6";
            this.conf6.Size = new System.Drawing.Size(150, 274);
            this.conf6.TabIndex = 5;
            this.conf6.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf5
            // 
            this.conf5.BackColor = System.Drawing.Color.Gainsboro;
            this.conf5.FormattingEnabled = true;
            this.conf5.Location = new System.Drawing.Point(645, 36);
            this.conf5.Name = "conf5";
            this.conf5.Size = new System.Drawing.Size(150, 274);
            this.conf5.TabIndex = 4;
            this.conf5.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf4
            // 
            this.conf4.BackColor = System.Drawing.Color.Gainsboro;
            this.conf4.FormattingEnabled = true;
            this.conf4.Location = new System.Drawing.Point(489, 36);
            this.conf4.Name = "conf4";
            this.conf4.Size = new System.Drawing.Size(150, 274);
            this.conf4.TabIndex = 3;
            this.conf4.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf3
            // 
            this.conf3.BackColor = System.Drawing.Color.Gainsboro;
            this.conf3.FormattingEnabled = true;
            this.conf3.Location = new System.Drawing.Point(333, 36);
            this.conf3.Name = "conf3";
            this.conf3.Size = new System.Drawing.Size(150, 274);
            this.conf3.TabIndex = 2;
            this.conf3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf2
            // 
            this.conf2.BackColor = System.Drawing.Color.Gainsboro;
            this.conf2.FormattingEnabled = true;
            this.conf2.Location = new System.Drawing.Point(177, 36);
            this.conf2.Name = "conf2";
            this.conf2.Size = new System.Drawing.Size(150, 274);
            this.conf2.TabIndex = 1;
            this.conf2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // conf1
            // 
            this.conf1.BackColor = System.Drawing.Color.Gainsboro;
            this.conf1.FormattingEnabled = true;
            this.conf1.Location = new System.Drawing.Point(21, 36);
            this.conf1.Name = "conf1";
            this.conf1.Size = new System.Drawing.Size(150, 274);
            this.conf1.TabIndex = 0;
            this.conf1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.TeamChecked);
            // 
            // tabDB
            // 
            this.tabDB.BackColor = System.Drawing.SystemColors.Control;
            this.tabDB.Controls.Add(this.tableGridView);
            this.tabDB.Controls.Add(this.fieldsGridView);
            this.tabDB.Location = new System.Drawing.Point(4, 24);
            this.tabDB.Name = "tabDB";
            this.tabDB.Padding = new System.Windows.Forms.Padding(3);
            this.tabDB.Size = new System.Drawing.Size(1152, 665);
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
            this.tabHome.Controls.Add(this.pictureBox1);
            this.tabHome.Location = new System.Drawing.Point(4, 24);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(1152, 665);
            this.tabHome.TabIndex = 6;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabHome);
            this.tabControl1.Controls.Add(this.tabDB);
            this.tabControl1.Controls.Add(this.tabConf);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(75, 20);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1160, 693);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_IndexChange);
            // 
            // confName1
            // 
            this.confName1.Location = new System.Drawing.Point(21, 10);
            this.confName1.MaxLength = 31;
            this.confName1.Name = "confName1";
            this.confName1.Size = new System.Drawing.Size(100, 20);
            this.confName1.TabIndex = 32;
            // 
            // confName2
            // 
            this.confName2.Location = new System.Drawing.Point(177, 10);
            this.confName2.MaxLength = 31;
            this.confName2.Name = "confName2";
            this.confName2.Size = new System.Drawing.Size(100, 20);
            this.confName2.TabIndex = 33;
            // 
            // confName3
            // 
            this.confName3.Location = new System.Drawing.Point(333, 10);
            this.confName3.MaxLength = 31;
            this.confName3.Name = "confName3";
            this.confName3.Size = new System.Drawing.Size(100, 20);
            this.confName3.TabIndex = 34;
            // 
            // confName4
            // 
            this.confName4.Location = new System.Drawing.Point(489, 10);
            this.confName4.MaxLength = 31;
            this.confName4.Name = "confName4";
            this.confName4.Size = new System.Drawing.Size(100, 20);
            this.confName4.TabIndex = 35;
            // 
            // confName5
            // 
            this.confName5.Location = new System.Drawing.Point(645, 10);
            this.confName5.MaxLength = 31;
            this.confName5.Name = "confName5";
            this.confName5.Size = new System.Drawing.Size(100, 20);
            this.confName5.TabIndex = 36;
            // 
            // confName6
            // 
            this.confName6.Location = new System.Drawing.Point(801, 10);
            this.confName6.MaxLength = 31;
            this.confName6.Name = "confName6";
            this.confName6.Size = new System.Drawing.Size(100, 20);
            this.confName6.TabIndex = 37;
            // 
            // confName12
            // 
            this.confName12.Location = new System.Drawing.Point(801, 349);
            this.confName12.MaxLength = 31;
            this.confName12.Name = "confName12";
            this.confName12.Size = new System.Drawing.Size(100, 20);
            this.confName12.TabIndex = 43;
            // 
            // confName11
            // 
            this.confName11.Location = new System.Drawing.Point(645, 349);
            this.confName11.MaxLength = 31;
            this.confName11.Name = "confName11";
            this.confName11.Size = new System.Drawing.Size(100, 20);
            this.confName11.TabIndex = 42;
            // 
            // confName10
            // 
            this.confName10.Location = new System.Drawing.Point(489, 349);
            this.confName10.MaxLength = 31;
            this.confName10.Name = "confName10";
            this.confName10.Size = new System.Drawing.Size(100, 20);
            this.confName10.TabIndex = 41;
            // 
            // confName9
            // 
            this.confName9.Location = new System.Drawing.Point(333, 349);
            this.confName9.MaxLength = 31;
            this.confName9.Name = "confName9";
            this.confName9.Size = new System.Drawing.Size(100, 20);
            this.confName9.TabIndex = 40;
            // 
            // confName8
            // 
            this.confName8.Location = new System.Drawing.Point(177, 349);
            this.confName8.MaxLength = 31;
            this.confName8.Name = "confName8";
            this.confName8.Size = new System.Drawing.Size(100, 20);
            this.confName8.TabIndex = 39;
            // 
            // confName7
            // 
            this.confName7.Location = new System.Drawing.Point(21, 349);
            this.confName7.MaxLength = 31;
            this.confName7.Name = "confName7";
            this.confName7.Size = new System.Drawing.Size(100, 20);
            this.confName7.TabIndex = 38;
            // 
            // LeagueMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1184, 761);
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
            this.Text = "Schedule Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainEditor_FormClosing);
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
            this.tabDB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldsGridView)).EndInit();
            this.tabHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        public System.Windows.Forms.ToolStripMenuItem enableOffSeasonMenuItem;
        private ColorDialog colorDialog1;
        private TabPage tabConf;
        private Label label80;
        private Label label4;
        private System.Windows.Forms.ComboBox SwapRosterBox;
        private System.Windows.Forms.ComboBox FCSSwapListBox;
        private System.Windows.Forms.Button DeselectTeamsButton;
        private System.Windows.Forms.Button SwapButton;
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
    }
}

