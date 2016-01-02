namespace SmashAttacks
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLine = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opnDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.tbpgAttributes = new System.Windows.Forms.TabPage();
            this.dtgrdAttributes = new System.Windows.Forms.DataGridView();
            this.AttributeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showAsFloatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAsIntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblAttributeDescription = new System.Windows.Forms.Label();
            this.tbpgActions = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblEventListOffset = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCopyText = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnNOP = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnCopyEvent = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnPasteEvent = new System.Windows.Forms.Button();
            this.lblEventDescription = new System.Windows.Forms.Label();
            this.tbctrlActionEvents = new System.Windows.Forms.TabControl();
            this.tbpgSpecials = new System.Windows.Forms.TabPage();
            this.cboAction = new System.Windows.Forms.ComboBox();
            this.lblName5 = new System.Windows.Forms.Label();
            this.tbpgSubActionEvents = new System.Windows.Forms.TabPage();
            this.btnAnimationFlags = new System.Windows.Forms.Button();
            this.lblName3 = new System.Windows.Forms.Label();
            this.txtAnimationName = new System.Windows.Forms.TextBox();
            this.cboEventList = new System.Windows.Forms.ComboBox();
            this.lblName1 = new System.Windows.Forms.Label();
            this.cboSubAction = new System.Windows.Forms.ComboBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.tbSubRoutines = new System.Windows.Forms.TabPage();
            this.btnCreateSubRoutine = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbctrlMain = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hexViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuStrip.SuspendLayout();
            this.tbpgAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdAttributes)).BeginInit();
            this.AttributeContextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tbpgActions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tbctrlActionEvents.SuspendLayout();
            this.tbpgSpecials.SuspendLayout();
            this.tbpgSubActionEvents.SuspendLayout();
            this.tbSubRoutines.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbctrlMain.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuStrip
            // 
            this.mnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp,
            this.testToolStripMenuItem});
            this.mnuStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuStrip.Name = "mnuStrip";
            this.mnuStrip.Size = new System.Drawing.Size(378, 24);
            this.mnuStrip.TabIndex = 0;
            this.mnuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.mnuLine,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(113, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Enabled = false;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(113, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Enabled = false;
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(113, 22);
            this.mnuSaveAs.Text = "Save As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // mnuLine
            // 
            this.mnuLine.Name = "mnuLine";
            this.mnuLine.Size = new System.Drawing.Size(110, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(113, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(103, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // opnDlg
            // 
            this.opnDlg.Filter = "Pac Files|*.pac|All files|*.*";
            // 
            // saveDlg
            // 
            this.saveDlg.DefaultExt = "pac";
            this.saveDlg.Filter = "Pac Files|*.pac|All files|*.*";
            // 
            // tbpgAttributes
            // 
            this.tbpgAttributes.Controls.Add(this.lblAttributeDescription);
            this.tbpgAttributes.Controls.Add(this.dtgrdAttributes);
            this.tbpgAttributes.Controls.Add(this.groupBox2);
            this.tbpgAttributes.Location = new System.Drawing.Point(4, 22);
            this.tbpgAttributes.Name = "tbpgAttributes";
            this.tbpgAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgAttributes.Size = new System.Drawing.Size(370, 461);
            this.tbpgAttributes.TabIndex = 1;
            this.tbpgAttributes.Text = "Attributes";
            this.tbpgAttributes.UseVisualStyleBackColor = true;
            // 
            // dtgrdAttributes
            // 
            this.dtgrdAttributes.AllowUserToAddRows = false;
            this.dtgrdAttributes.AllowUserToDeleteRows = false;
            this.dtgrdAttributes.AllowUserToResizeRows = false;
            this.dtgrdAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrdAttributes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dtgrdAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgrdAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrdAttributes.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgrdAttributes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgrdAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgrdAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dtgrdAttributes.EnableHeadersVisualStyles = false;
            this.dtgrdAttributes.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dtgrdAttributes.Location = new System.Drawing.Point(3, 43);
            this.dtgrdAttributes.MultiSelect = false;
            this.dtgrdAttributes.Name = "dtgrdAttributes";
            this.dtgrdAttributes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgrdAttributes.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgrdAttributes.RowHeadersWidth = 8;
            this.dtgrdAttributes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgrdAttributes.RowTemplate.ContextMenuStrip = this.AttributeContextMenu;
            this.dtgrdAttributes.RowTemplate.Height = 16;
            this.dtgrdAttributes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgrdAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrdAttributes.Size = new System.Drawing.Size(364, 415);
            this.dtgrdAttributes.TabIndex = 4;
            this.dtgrdAttributes.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrdAttributes_CellEndEdit);
            this.dtgrdAttributes.CurrentCellChanged += new System.EventHandler(this.dtgrdAttributes_CurrentCellChanged);
            // 
            // AttributeContextMenu
            // 
            this.AttributeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAsFloatToolStripMenuItem,
            this.showAsIntToolStripMenuItem});
            this.AttributeContextMenu.Name = "AttributeContextMenu";
            this.AttributeContextMenu.Size = new System.Drawing.Size(140, 48);
            // 
            // showAsFloatToolStripMenuItem
            // 
            this.showAsFloatToolStripMenuItem.Name = "showAsFloatToolStripMenuItem";
            this.showAsFloatToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.showAsFloatToolStripMenuItem.Text = "Show as float";
            this.showAsFloatToolStripMenuItem.Click += new System.EventHandler(this.showAsFloatToolStripMenuItem_Click);
            // 
            // showAsIntToolStripMenuItem
            // 
            this.showAsIntToolStripMenuItem.Name = "showAsIntToolStripMenuItem";
            this.showAsIntToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.showAsIntToolStripMenuItem.Text = "Show as int";
            this.showAsIntToolStripMenuItem.Click += new System.EventHandler(this.showAsIntToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 40);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Value List";
            // 
            // comboBox2
            // 
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 16);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(358, 21);
            this.comboBox2.TabIndex = 0;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lblAttributeDescription
            // 
            this.lblAttributeDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblAttributeDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAttributeDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAttributeDescription.Location = new System.Drawing.Point(3, 416);
            this.lblAttributeDescription.Name = "lblAttributeDescription";
            this.lblAttributeDescription.Size = new System.Drawing.Size(364, 42);
            this.lblAttributeDescription.TabIndex = 3;
            // 
            // tbpgActions
            // 
            this.tbpgActions.Controls.Add(this.panel1);
            this.tbpgActions.Controls.Add(this.tbctrlActionEvents);
            this.tbpgActions.Controls.Add(this.groupBox1);
            this.tbpgActions.Location = new System.Drawing.Point(4, 22);
            this.tbpgActions.Name = "tbpgActions";
            this.tbpgActions.Size = new System.Drawing.Size(370, 461);
            this.tbpgActions.TabIndex = 2;
            this.tbpgActions.Text = "Action Events";
            this.tbpgActions.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstEvents);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblEventDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 127);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(370, 334);
            this.panel1.TabIndex = 21;
            // 
            // lstEvents
            // 
            this.lstEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.HorizontalScrollbar = true;
            this.lstEvents.Location = new System.Drawing.Point(3, 22);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstEvents.Size = new System.Drawing.Size(364, 205);
            this.lstEvents.TabIndex = 5;
            this.lstEvents.SelectedIndexChanged += new System.EventHandler(this.lstEvents_SelectedIndexChanged);
            this.lstEvents.DoubleClick += new System.EventHandler(this.lstEvents_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblEventListOffset);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(364, 19);
            this.panel3.TabIndex = 22;
            // 
            // lblEventListOffset
            // 
            this.lblEventListOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEventListOffset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEventListOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEventListOffset.Location = new System.Drawing.Point(67, 0);
            this.lblEventListOffset.Name = "lblEventListOffset";
            this.lblEventListOffset.Size = new System.Drawing.Size(297, 18);
            this.lblEventListOffset.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "Offset";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCopyText);
            this.panel2.Controls.Add(this.btnUp);
            this.panel2.Controls.Add(this.btnNOP);
            this.panel2.Controls.Add(this.btnDown);
            this.panel2.Controls.Add(this.btnCopyEvent);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnModify);
            this.panel2.Controls.Add(this.btnPasteEvent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 227);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 50);
            this.panel2.TabIndex = 21;
            // 
            // btnCopyText
            // 
            this.btnCopyText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyText.Enabled = false;
            this.btnCopyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyText.Location = new System.Drawing.Point(219, 3);
            this.btnCopyText.Name = "btnCopyText";
            this.btnCopyText.Size = new System.Drawing.Size(80, 21);
            this.btnCopyText.TabIndex = 20;
            this.btnCopyText.Text = "Copy Text";
            this.btnCopyText.UseVisualStyleBackColor = true;
            this.btnCopyText.Click += new System.EventHandler(this.btnCopyEventText_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUp.Enabled = false;
            this.btnUp.Location = new System.Drawing.Point(219, 24);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(40, 24);
            this.btnUp.TabIndex = 15;
            this.btnUp.Text = "▲";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnNOP
            // 
            this.btnNOP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNOP.Enabled = false;
            this.btnNOP.Location = new System.Drawing.Point(147, 9);
            this.btnNOP.Name = "btnNOP";
            this.btnNOP.Size = new System.Drawing.Size(64, 36);
            this.btnNOP.TabIndex = 14;
            this.btnNOP.Text = "Nop Selected";
            this.btnNOP.UseVisualStyleBackColor = true;
            this.btnNOP.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Enabled = false;
            this.btnDown.Location = new System.Drawing.Point(259, 24);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(40, 24);
            this.btnDown.TabIndex = 16;
            this.btnDown.Text = "▼";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnCopyEvent
            // 
            this.btnCopyEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyEvent.Enabled = false;
            this.btnCopyEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyEvent.Location = new System.Drawing.Point(318, 3);
            this.btnCopyEvent.Name = "btnCopyEvent";
            this.btnCopyEvent.Size = new System.Drawing.Size(37, 21);
            this.btnCopyEvent.TabIndex = 19;
            this.btnCopyEvent.Text = "Copy";
            this.btnCopyEvent.UseVisualStyleBackColor = true;
            this.btnCopyEvent.Click += new System.EventHandler(this.btnCopyEvent_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(3, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(64, 36);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModify.Enabled = false;
            this.btnModify.Location = new System.Drawing.Point(75, 9);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(64, 36);
            this.btnModify.TabIndex = 17;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnPasteEvent
            // 
            this.btnPasteEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPasteEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasteEvent.Location = new System.Drawing.Point(318, 24);
            this.btnPasteEvent.Name = "btnPasteEvent";
            this.btnPasteEvent.Size = new System.Drawing.Size(37, 22);
            this.btnPasteEvent.TabIndex = 18;
            this.btnPasteEvent.Text = "Paste";
            this.btnPasteEvent.UseVisualStyleBackColor = true;
            this.btnPasteEvent.Click += new System.EventHandler(this.btnPasteEvent_Click);
            // 
            // lblEventDescription
            // 
            this.lblEventDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblEventDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEventDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEventDescription.Location = new System.Drawing.Point(3, 277);
            this.lblEventDescription.Name = "lblEventDescription";
            this.lblEventDescription.Size = new System.Drawing.Size(364, 54);
            this.lblEventDescription.TabIndex = 4;
            // 
            // tbctrlActionEvents
            // 
            this.tbctrlActionEvents.Controls.Add(this.tbpgSpecials);
            this.tbctrlActionEvents.Controls.Add(this.tbpgSubActionEvents);
            this.tbctrlActionEvents.Controls.Add(this.tbSubRoutines);
            this.tbctrlActionEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbctrlActionEvents.Location = new System.Drawing.Point(0, 41);
            this.tbctrlActionEvents.Name = "tbctrlActionEvents";
            this.tbctrlActionEvents.SelectedIndex = 0;
            this.tbctrlActionEvents.Size = new System.Drawing.Size(370, 86);
            this.tbctrlActionEvents.TabIndex = 12;
            this.tbctrlActionEvents.SelectedIndexChanged += new System.EventHandler(this.tbctrlActionEvents_SelectedIndexChanged);
            // 
            // tbpgSpecials
            // 
            this.tbpgSpecials.Controls.Add(this.cboAction);
            this.tbpgSpecials.Controls.Add(this.lblName5);
            this.tbpgSpecials.Location = new System.Drawing.Point(4, 22);
            this.tbpgSpecials.Name = "tbpgSpecials";
            this.tbpgSpecials.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSpecials.Size = new System.Drawing.Size(362, 60);
            this.tbpgSpecials.TabIndex = 1;
            this.tbpgSpecials.Text = "Specials";
            this.tbpgSpecials.UseVisualStyleBackColor = true;
            // 
            // cboAction
            // 
            this.cboAction.FormattingEnabled = true;
            this.cboAction.Location = new System.Drawing.Point(8, 30);
            this.cboAction.Name = "cboAction";
            this.cboAction.Size = new System.Drawing.Size(152, 21);
            this.cboAction.TabIndex = 12;
            this.cboAction.SelectedIndexChanged += new System.EventHandler(this.cboAction_SelectedIndexChanged);
            // 
            // lblName5
            // 
            this.lblName5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName5.Location = new System.Drawing.Point(8, 8);
            this.lblName5.Name = "lblName5";
            this.lblName5.Size = new System.Drawing.Size(152, 21);
            this.lblName5.TabIndex = 11;
            this.lblName5.Text = "Action";
            // 
            // tbpgSubActionEvents
            // 
            this.tbpgSubActionEvents.Controls.Add(this.btnAnimationFlags);
            this.tbpgSubActionEvents.Controls.Add(this.lblName3);
            this.tbpgSubActionEvents.Controls.Add(this.txtAnimationName);
            this.tbpgSubActionEvents.Controls.Add(this.cboEventList);
            this.tbpgSubActionEvents.Controls.Add(this.lblName1);
            this.tbpgSubActionEvents.Controls.Add(this.cboSubAction);
            this.tbpgSubActionEvents.Controls.Add(this.lblName2);
            this.tbpgSubActionEvents.Location = new System.Drawing.Point(4, 22);
            this.tbpgSubActionEvents.Name = "tbpgSubActionEvents";
            this.tbpgSubActionEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tbpgSubActionEvents.Size = new System.Drawing.Size(362, 60);
            this.tbpgSubActionEvents.TabIndex = 0;
            this.tbpgSubActionEvents.Text = "Sub Actions";
            this.tbpgSubActionEvents.UseVisualStyleBackColor = true;
            // 
            // btnAnimationFlags
            // 
            this.btnAnimationFlags.Location = new System.Drawing.Point(128, 32);
            this.btnAnimationFlags.Name = "btnAnimationFlags";
            this.btnAnimationFlags.Size = new System.Drawing.Size(200, 22);
            this.btnAnimationFlags.TabIndex = 16;
            this.btnAnimationFlags.Text = "Animation Flags";
            this.btnAnimationFlags.UseVisualStyleBackColor = true;
            this.btnAnimationFlags.Click += new System.EventHandler(this.btnAnimationFlags_Click);
            // 
            // lblName3
            // 
            this.lblName3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName3.Location = new System.Drawing.Point(128, 8);
            this.lblName3.Name = "lblName3";
            this.lblName3.Size = new System.Drawing.Size(64, 20);
            this.lblName3.TabIndex = 15;
            this.lblName3.Text = "Animation";
            // 
            // txtAnimationName
            // 
            this.txtAnimationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnimationName.Location = new System.Drawing.Point(192, 8);
            this.txtAnimationName.MaxLength = 64;
            this.txtAnimationName.Name = "txtAnimationName";
            this.txtAnimationName.Size = new System.Drawing.Size(389, 20);
            this.txtAnimationName.TabIndex = 14;
            this.txtAnimationName.TextChanged += new System.EventHandler(this.txtAnimationName_TextChanged);
            // 
            // cboEventList
            // 
            this.cboEventList.FormattingEnabled = true;
            this.cboEventList.Items.AddRange(new object[] {
            "Main",
            "GFX",
            "SFX",
            "Other"});
            this.cboEventList.Location = new System.Drawing.Point(72, 32);
            this.cboEventList.Name = "cboEventList";
            this.cboEventList.Size = new System.Drawing.Size(48, 21);
            this.cboEventList.TabIndex = 13;
            this.cboEventList.SelectedIndexChanged += new System.EventHandler(this.cboSubAction_SelectedIndexChanged);
            // 
            // lblName1
            // 
            this.lblName1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName1.Location = new System.Drawing.Point(8, 32);
            this.lblName1.Name = "lblName1";
            this.lblName1.Size = new System.Drawing.Size(64, 21);
            this.lblName1.TabIndex = 12;
            this.lblName1.Text = "Event List";
            // 
            // cboSubAction
            // 
            this.cboSubAction.FormattingEnabled = true;
            this.cboSubAction.Location = new System.Drawing.Point(72, 8);
            this.cboSubAction.Name = "cboSubAction";
            this.cboSubAction.Size = new System.Drawing.Size(48, 21);
            this.cboSubAction.TabIndex = 11;
            this.cboSubAction.SelectedIndexChanged += new System.EventHandler(this.cboSubAction_SelectedIndexChanged);
            // 
            // lblName2
            // 
            this.lblName2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblName2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblName2.Location = new System.Drawing.Point(8, 8);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(64, 21);
            this.lblName2.TabIndex = 10;
            this.lblName2.Text = "Sub Action";
            // 
            // tbSubRoutines
            // 
            this.tbSubRoutines.Controls.Add(this.btnCreateSubRoutine);
            this.tbSubRoutines.Controls.Add(this.btnGo);
            this.tbSubRoutines.Controls.Add(this.txtOffset);
            this.tbSubRoutines.Controls.Add(this.label2);
            this.tbSubRoutines.Location = new System.Drawing.Point(4, 22);
            this.tbSubRoutines.Name = "tbSubRoutines";
            this.tbSubRoutines.Size = new System.Drawing.Size(362, 60);
            this.tbSubRoutines.TabIndex = 2;
            this.tbSubRoutines.Text = "Sub Routines";
            this.tbSubRoutines.UseVisualStyleBackColor = true;
            // 
            // btnCreateSubRoutine
            // 
            this.btnCreateSubRoutine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSubRoutine.Location = new System.Drawing.Point(507, 8);
            this.btnCreateSubRoutine.Name = "btnCreateSubRoutine";
            this.btnCreateSubRoutine.Size = new System.Drawing.Size(72, 24);
            this.btnCreateSubRoutine.TabIndex = 17;
            this.btnCreateSubRoutine.Text = "Create New";
            this.btnCreateSubRoutine.UseVisualStyleBackColor = true;
            this.btnCreateSubRoutine.Click += new System.EventHandler(this.btnCreateSubRoutine_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(112, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(48, 22);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(48, 8);
            this.txtOffset.MaxLength = 64;
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(64, 20);
            this.txtOffset.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Offset";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 41);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Object";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(364, 21);
            this.comboBox1.TabIndex = 22;
            // 
            // tbctrlMain
            // 
            this.tbctrlMain.Controls.Add(this.tbpgActions);
            this.tbctrlMain.Controls.Add(this.tbpgAttributes);
            this.tbctrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbctrlMain.Enabled = false;
            this.tbctrlMain.Location = new System.Drawing.Point(0, 24);
            this.tbctrlMain.Name = "tbctrlMain";
            this.tbctrlMain.SelectedIndex = 0;
            this.tbctrlMain.Size = new System.Drawing.Size(378, 487);
            this.tbctrlMain.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hexViewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(68, 26);
            // 
            // hexViewToolStripMenuItem
            // 
            this.hexViewToolStripMenuItem.Name = "hexViewToolStripMenuItem";
            this.hexViewToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 511);
            this.Controls.Add(this.tbctrlMain);
            this.Controls.Add(this.mnuStrip);
            this.MainMenuStrip = this.mnuStrip;
            this.MinimumSize = new System.Drawing.Size(385, 538);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Smash Attacks!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.mnuStrip.ResumeLayout(false);
            this.mnuStrip.PerformLayout();
            this.tbpgAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrdAttributes)).EndInit();
            this.AttributeContextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tbpgActions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tbctrlActionEvents.ResumeLayout(false);
            this.tbpgSpecials.ResumeLayout(false);
            this.tbpgSubActionEvents.ResumeLayout(false);
            this.tbpgSubActionEvents.PerformLayout();
            this.tbSubRoutines.ResumeLayout(false);
            this.tbSubRoutines.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tbctrlMain.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator mnuLine;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.OpenFileDialog opnDlg;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.SaveFileDialog saveDlg;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.TabPage tbpgAttributes;
        private System.Windows.Forms.DataGridView dtgrdAttributes;
        private System.Windows.Forms.Label lblAttributeDescription;
        private System.Windows.Forms.TabPage tbpgActions;
        private System.Windows.Forms.Button btnCopyEvent;
        private System.Windows.Forms.Button btnPasteEvent;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnNOP;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tbctrlActionEvents;
        private System.Windows.Forms.TabPage tbpgSpecials;
        private System.Windows.Forms.ComboBox cboAction;
        private System.Windows.Forms.Label lblName5;
        private System.Windows.Forms.TabPage tbpgSubActionEvents;
        private System.Windows.Forms.Button btnAnimationFlags;
        private System.Windows.Forms.Label lblName3;
        private System.Windows.Forms.TextBox txtAnimationName;
        private System.Windows.Forms.ComboBox cboEventList;
        private System.Windows.Forms.Label lblName1;
        private System.Windows.Forms.ComboBox cboSubAction;
        private System.Windows.Forms.Label lblName2;
        private System.Windows.Forms.TabPage tbSubRoutines;
        private System.Windows.Forms.Button btnCreateSubRoutine;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblEventDescription;
        private System.Windows.Forms.TabControl tbctrlMain;
        private System.Windows.Forms.ContextMenuStrip AttributeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem showAsFloatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAsIntToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hexViewToolStripMenuItem;
        private System.Windows.Forms.Button btnCopyText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblEventListOffset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}

