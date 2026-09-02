namespace YouTube_Downloader
{
    partial class Form1
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
            if (disposing && ( components != null ))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.tbURL = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.prgbarLoadingInfo = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.lblDownloadsLimitReached = new System.Windows.Forms.Label();
            this.btnGetVidInfo = new Guna.UI2.WinForms.Guna2Button();
            this.dgvDownloads = new Guna.UI2.WinForms.Guna2DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsVidItemOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ControlBoxClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.label34 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoDownloadsYet = new System.Windows.Forms.Label();
            this.pnlVidInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCloseVidInfo = new Guna.UI2.WinForms.Guna2Button();
            this.lblChannelName = new System.Windows.Forms.Label();
            this.lblVidSize = new System.Windows.Forms.Label();
            this.pnlVidDuration = new Guna.UI2.WinForms.Guna2Panel();
            this.lblVidDuration = new System.Windows.Forms.Label();
            this.lblVidDescription = new System.Windows.Forms.Label();
            this.pbVidThumbnail = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cbQualities = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVidTitle = new System.Windows.Forms.Label();
            this.btnDownload = new Guna.UI2.WinForms.Guna2Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.guna2Panel1.SuspendLayout();
            this.prgbarLoadingInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).BeginInit();
            this.cmsVidItemOptions.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.pnlVidInfo.SuspendLayout();
            this.pnlVidDuration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVidThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 10;
            this.guna2Elipse1.TargetControl = this;
            // 
            // tbURL
            // 
            this.tbURL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbURL.Animated = true;
            this.tbURL.BackColor = System.Drawing.Color.Transparent;
            this.tbURL.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.tbURL.BorderRadius = 10;
            this.tbURL.BorderThickness = 0;
            this.tbURL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbURL.DefaultText = "";
            this.tbURL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbURL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbURL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.DisabledState.Parent = this.tbURL;
            this.tbURL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbURL.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.tbURL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.FocusedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.FocusedState.Parent = this.tbURL;
            this.tbURL.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.tbURL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.HoverState.BorderColor = System.Drawing.Color.Transparent;
            this.tbURL.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.HoverState.Parent = this.tbURL;
            this.tbURL.HoverState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.Location = new System.Drawing.Point(15, 10);
            this.tbURL.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.tbURL.Name = "tbURL";
            this.tbURL.PasswordChar = '\0';
            this.tbURL.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.tbURL.PlaceholderText = "Enter URL here";
            this.tbURL.SelectedText = "";
            this.tbURL.ShadowDecoration.Parent = this.tbURL;
            this.tbURL.Size = new System.Drawing.Size(845, 43);
            this.tbURL.TabIndex = 0;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.prgbarLoadingInfo);
            this.guna2Panel1.Controls.Add(this.btnGetVidInfo);
            this.guna2Panel1.Controls.Add(this.tbURL);
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.guna2Panel1.Location = new System.Drawing.Point(213, 324);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2Panel1.ShadowDecoration.Depth = 140;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(979, 64);
            this.guna2Panel1.TabIndex = 1;
            // 
            // prgbarLoadingInfo
            // 
            this.prgbarLoadingInfo.Animated = true;
            this.prgbarLoadingInfo.AnimationSpeed = 1.5F;
            this.prgbarLoadingInfo.BackColor = System.Drawing.Color.Transparent;
            this.prgbarLoadingInfo.Controls.Add(this.lblDownloadsLimitReached);
            this.prgbarLoadingInfo.Enabled = false;
            this.prgbarLoadingInfo.FillColor = System.Drawing.Color.Transparent;
            this.prgbarLoadingInfo.FillThickness = 5;
            this.prgbarLoadingInfo.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.prgbarLoadingInfo.Location = new System.Drawing.Point(453, 8);
            this.prgbarLoadingInfo.Maximum = 75;
            this.prgbarLoadingInfo.Minimum = 1;
            this.prgbarLoadingInfo.Name = "prgbarLoadingInfo";
            this.prgbarLoadingInfo.ProgressColor = System.Drawing.Color.Red;
            this.prgbarLoadingInfo.ProgressColor2 = System.Drawing.Color.Transparent;
            this.prgbarLoadingInfo.ProgressThickness = 5;
            this.prgbarLoadingInfo.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.prgbarLoadingInfo.ShadowDecoration.Parent = this.prgbarLoadingInfo;
            this.prgbarLoadingInfo.Size = new System.Drawing.Size(48, 47);
            this.prgbarLoadingInfo.TabIndex = 9;
            this.prgbarLoadingInfo.Value = 74;
            this.prgbarLoadingInfo.Visible = false;
            // 
            // lblDownloadsLimitReached
            // 
            this.lblDownloadsLimitReached.AutoSize = true;
            this.lblDownloadsLimitReached.BackColor = System.Drawing.Color.Transparent;
            this.lblDownloadsLimitReached.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloadsLimitReached.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.lblDownloadsLimitReached.Location = new System.Drawing.Point(-177, 9);
            this.lblDownloadsLimitReached.Name = "lblDownloadsLimitReached";
            this.lblDownloadsLimitReached.Size = new System.Drawing.Size(396, 28);
            this.lblDownloadsLimitReached.TabIndex = 4;
            this.lblDownloadsLimitReached.Text = "Only 5 simultaneous downloads allowed";
            this.lblDownloadsLimitReached.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDownloadsLimitReached.Visible = false;
            // 
            // btnGetVidInfo
            // 
            this.btnGetVidInfo.BorderRadius = 7;
            this.btnGetVidInfo.CheckedState.Parent = this.btnGetVidInfo;
            this.btnGetVidInfo.CustomImages.Parent = this.btnGetVidInfo;
            this.btnGetVidInfo.FillColor = System.Drawing.Color.DarkRed;
            this.btnGetVidInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetVidInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnGetVidInfo.HoverState.Parent = this.btnGetVidInfo;
            this.btnGetVidInfo.Location = new System.Drawing.Point(858, 8);
            this.btnGetVidInfo.Name = "btnGetVidInfo";
            this.btnGetVidInfo.ShadowDecoration.Parent = this.btnGetVidInfo;
            this.btnGetVidInfo.Size = new System.Drawing.Size(107, 47);
            this.btnGetVidInfo.TabIndex = 1;
            this.btnGetVidInfo.Text = "Get Info";
            this.btnGetVidInfo.Click += new System.EventHandler(this.btnGetVidInfo_Click);
            // 
            // dgvDownloads
            // 
            this.dgvDownloads.AllowUserToAddRows = false;
            this.dgvDownloads.AllowUserToDeleteRows = false;
            this.dgvDownloads.AllowUserToResizeColumns = false;
            this.dgvDownloads.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvDownloads.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDownloads.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDownloads.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDownloads.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.dgvDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDownloads.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDownloads.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDownloads.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDownloads.ColumnHeadersHeight = 60;
            this.dgvDownloads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDownloads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5});
            this.dgvDownloads.ContextMenuStrip = this.cmsVidItemOptions;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDownloads.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDownloads.EnableHeadersVisualStyles = false;
            this.dgvDownloads.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.dgvDownloads.Location = new System.Drawing.Point(4, 4);
            this.dgvDownloads.Name = "dgvDownloads";
            this.dgvDownloads.ReadOnly = true;
            this.dgvDownloads.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.dgvDownloads.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDownloads.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.dgvDownloads.RowTemplate.DividerHeight = 1;
            this.dgvDownloads.RowTemplate.Height = 40;
            this.dgvDownloads.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDownloads.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDownloads.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDownloads.Size = new System.Drawing.Size(1027, 411);
            this.dgvDownloads.TabIndex = 2;
            this.dgvDownloads.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            this.dgvDownloads.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(48)))), ((int)(((byte)(52)))));
            this.dgvDownloads.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDownloads.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDownloads.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDownloads.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDownloads.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.dgvDownloads.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.dgvDownloads.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(30)))));
            this.dgvDownloads.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDownloads.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDownloads.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.dgvDownloads.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDownloads.ThemeStyle.HeaderStyle.Height = 60;
            this.dgvDownloads.ThemeStyle.ReadOnly = true;
            this.dgvDownloads.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.dgvDownloads.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDownloads.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDownloads.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDownloads.ThemeStyle.RowsStyle.Height = 40;
            this.dgvDownloads.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(117)))), ((int)(((byte)(119)))));
            this.dgvDownloads.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // col1
            // 
            this.col1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col1.DataPropertyName = "Title";
            this.col1.FillWeight = 36.31561F;
            this.col1.HeaderText = "FILE NAME";
            this.col1.Name = "col1";
            this.col1.ReadOnly = true;
            this.col1.Width = 525;
            // 
            // col2
            // 
            this.col2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col2.DataPropertyName = "Status";
            this.col2.FillWeight = 40.61155F;
            this.col2.HeaderText = "STATUS";
            this.col2.Name = "col2";
            this.col2.ReadOnly = true;
            this.col2.Width = 150;
            // 
            // col3
            // 
            this.col3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col3.DataPropertyName = "Progress";
            this.col3.FillWeight = 81.42152F;
            this.col3.HeaderText = "PROGRESS";
            this.col3.Name = "col3";
            this.col3.ReadOnly = true;
            this.col3.Width = 130;
            // 
            // col4
            // 
            this.col4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col4.DataPropertyName = "Size";
            this.col4.FillWeight = 87.84423F;
            this.col4.HeaderText = "SIZE";
            this.col4.Name = "col4";
            this.col4.ReadOnly = true;
            this.col4.Width = 99;
            // 
            // col5
            // 
            this.col5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.col5.DataPropertyName = "Date";
            this.col5.FillWeight = 253.8071F;
            this.col5.HeaderText = "DATE";
            this.col5.Name = "col5";
            this.col5.ReadOnly = true;
            this.col5.Width = 122;
            // 
            // cmsVidItemOptions
            // 
            this.cmsVidItemOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCancel,
            this.tsmDelete,
            this.tsmOpenFolder});
            this.cmsVidItemOptions.Name = "cmsVidItemOptions";
            this.cmsVidItemOptions.Size = new System.Drawing.Size(140, 70);
            this.cmsVidItemOptions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsVidItemOptions_Opening);
            // 
            // tsmCancel
            // 
            this.tsmCancel.Name = "tsmCancel";
            this.tsmCancel.Size = new System.Drawing.Size(139, 22);
            this.tsmCancel.Text = "Cancel";
            this.tsmCancel.Click += new System.EventHandler(this.tsmCancel_Click);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(139, 22);
            this.tsmDelete.Text = "Delete";
            this.tsmDelete.Click += new System.EventHandler(this.tsmDelete_Click);
            // 
            // tsmOpenFolder
            // 
            this.tsmOpenFolder.Name = "tsmOpenFolder";
            this.tsmOpenFolder.Size = new System.Drawing.Size(139, 22);
            this.tsmOpenFolder.Text = "Open Folder";
            this.tsmOpenFolder.Click += new System.EventHandler(this.tsmOpenFolder_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.Controls.Add(this.guna2ControlBox2);
            this.guna2Panel2.Controls.Add(this.ControlBoxClose);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.guna2ControlBox3);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1395, 70);
            this.guna2Panel2.TabIndex = 3;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Gainsboro;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1305, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(39, 27);
            this.guna2ControlBox2.TabIndex = 1;
            // 
            // ControlBoxClose
            // 
            this.ControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBoxClose.FillColor = System.Drawing.Color.Transparent;
            this.ControlBoxClose.HoverState.Parent = this.ControlBoxClose;
            this.ControlBoxClose.IconColor = System.Drawing.Color.Gainsboro;
            this.ControlBoxClose.Location = new System.Drawing.Point(1344, 12);
            this.ControlBoxClose.Name = "ControlBoxClose";
            this.ControlBoxClose.ShadowDecoration.Parent = this.ControlBoxClose;
            this.ControlBoxClose.Size = new System.Drawing.Size(39, 27);
            this.ControlBoxClose.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Variable Display", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.label3.Location = new System.Drawing.Point(25, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "YouTube Downloader";
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Gainsboro;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1265, 12);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShadowDecoration.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.Size = new System.Drawing.Size(39, 27);
            this.guna2ControlBox3.TabIndex = 3;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.guna2Panel2;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Segoe UI Variable Display", 20F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.label34.Location = new System.Drawing.Point(191, 447);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(155, 36);
            this.label34.TabIndex = 4;
            this.label34.Text = "Downloads";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Display", 30F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.label1.Location = new System.Drawing.Point(381, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 53);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download YouTube videos easily";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.label2.Location = new System.Drawing.Point(381, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(631, 47);
            this.label2.TabIndex = 4;
            this.label2.Text = "Paste your YouTube link below to start the downloading process";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 68);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1395, 20);
            this.guna2Separator1.TabIndex = 5;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.guna2Panel3.BorderRadius = 10;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.lblNoDownloadsYet);
            this.guna2Panel3.Controls.Add(this.dgvDownloads);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.guna2Panel3.Location = new System.Drawing.Point(187, 493);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Padding = new System.Windows.Forms.Padding(4);
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.guna2Panel3.ShadowDecoration.Depth = 140;
            this.guna2Panel3.ShadowDecoration.Enabled = true;
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(1035, 419);
            this.guna2Panel3.TabIndex = 6;
            // 
            // lblNoDownloadsYet
            // 
            this.lblNoDownloadsYet.AutoSize = true;
            this.lblNoDownloadsYet.BackColor = System.Drawing.Color.Transparent;
            this.lblNoDownloadsYet.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 12.75F, System.Drawing.FontStyle.Bold);
            this.lblNoDownloadsYet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.lblNoDownloadsYet.Location = new System.Drawing.Point(423, 198);
            this.lblNoDownloadsYet.Name = "lblNoDownloadsYet";
            this.lblNoDownloadsYet.Size = new System.Drawing.Size(151, 22);
            this.lblNoDownloadsYet.TabIndex = 5;
            this.lblNoDownloadsYet.Text = "No Downloads Yet";
            this.lblNoDownloadsYet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVidInfo
            // 
            this.pnlVidInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnlVidInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.pnlVidInfo.BorderRadius = 10;
            this.pnlVidInfo.BorderThickness = 1;
            this.pnlVidInfo.Controls.Add(this.btnCloseVidInfo);
            this.pnlVidInfo.Controls.Add(this.lblChannelName);
            this.pnlVidInfo.Controls.Add(this.lblVidSize);
            this.pnlVidInfo.Controls.Add(this.pnlVidDuration);
            this.pnlVidInfo.Controls.Add(this.lblVidDescription);
            this.pnlVidInfo.Controls.Add(this.pbVidThumbnail);
            this.pnlVidInfo.Controls.Add(this.cbQualities);
            this.pnlVidInfo.Controls.Add(this.lblVidTitle);
            this.pnlVidInfo.Controls.Add(this.btnDownload);
            this.pnlVidInfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.pnlVidInfo.Location = new System.Drawing.Point(213, 260);
            this.pnlVidInfo.Name = "pnlVidInfo";
            this.pnlVidInfo.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.pnlVidInfo.ShadowDecoration.Depth = 140;
            this.pnlVidInfo.ShadowDecoration.Enabled = true;
            this.pnlVidInfo.ShadowDecoration.Parent = this.pnlVidInfo;
            this.pnlVidInfo.Size = new System.Drawing.Size(979, 154);
            this.pnlVidInfo.TabIndex = 7;
            this.pnlVidInfo.Visible = false;
            // 
            // btnCloseVidInfo
            // 
            this.btnCloseVidInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseVidInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloseVidInfo.BorderRadius = 7;
            this.btnCloseVidInfo.CheckedState.Parent = this.btnCloseVidInfo;
            this.btnCloseVidInfo.CustomImages.Parent = this.btnCloseVidInfo;
            this.btnCloseVidInfo.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseVidInfo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseVidInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCloseVidInfo.HoverState.Parent = this.btnCloseVidInfo;
            this.btnCloseVidInfo.Image = global::YouTube_Downloader.Properties.Resources.close1;
            this.btnCloseVidInfo.Location = new System.Drawing.Point(939, 6);
            this.btnCloseVidInfo.Name = "btnCloseVidInfo";
            this.btnCloseVidInfo.ShadowDecoration.Parent = this.btnCloseVidInfo;
            this.btnCloseVidInfo.Size = new System.Drawing.Size(32, 26);
            this.btnCloseVidInfo.TabIndex = 10;
            this.btnCloseVidInfo.Click += new System.EventHandler(this.btnCloseVidInfo_Click);
            // 
            // lblChannelName
            // 
            this.lblChannelName.BackColor = System.Drawing.Color.Transparent;
            this.lblChannelName.Font = new System.Drawing.Font("Segoe UI Variable Text", 12.75F);
            this.lblChannelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.lblChannelName.Location = new System.Drawing.Point(555, 109);
            this.lblChannelName.Name = "lblChannelName";
            this.lblChannelName.Size = new System.Drawing.Size(213, 27);
            this.lblChannelName.TabIndex = 9;
            this.lblChannelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVidSize
            // 
            this.lblVidSize.BackColor = System.Drawing.Color.Transparent;
            this.lblVidSize.Font = new System.Drawing.Font("Segoe UI Variable Text", 12.75F);
            this.lblVidSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.lblVidSize.Location = new System.Drawing.Point(449, 109);
            this.lblVidSize.Name = "lblVidSize";
            this.lblVidSize.Size = new System.Drawing.Size(87, 27);
            this.lblVidSize.TabIndex = 9;
            this.lblVidSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlVidDuration
            // 
            this.pnlVidDuration.BackColor = System.Drawing.Color.Transparent;
            this.pnlVidDuration.Controls.Add(this.lblVidDuration);
            this.pnlVidDuration.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlVidDuration.ForeColor = System.Drawing.Color.Transparent;
            this.pnlVidDuration.Location = new System.Drawing.Point(162, 112);
            this.pnlVidDuration.Name = "pnlVidDuration";
            this.pnlVidDuration.ShadowDecoration.Parent = this.pnlVidDuration;
            this.pnlVidDuration.Size = new System.Drawing.Size(67, 24);
            this.pnlVidDuration.TabIndex = 8;
            // 
            // lblVidDuration
            // 
            this.lblVidDuration.BackColor = System.Drawing.Color.Transparent;
            this.lblVidDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVidDuration.Font = new System.Drawing.Font("Segoe UI Variable Display", 10F, System.Drawing.FontStyle.Bold);
            this.lblVidDuration.ForeColor = System.Drawing.Color.Transparent;
            this.lblVidDuration.Location = new System.Drawing.Point(0, 0);
            this.lblVidDuration.Name = "lblVidDuration";
            this.lblVidDuration.Size = new System.Drawing.Size(67, 24);
            this.lblVidDuration.TabIndex = 6;
            this.lblVidDuration.Text = "00:04:12";
            this.lblVidDuration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVidDescription
            // 
            this.lblVidDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblVidDescription.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 10.75F, System.Drawing.FontStyle.Bold);
            this.lblVidDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(123)))), ((int)(((byte)(119)))));
            this.lblVidDescription.Location = new System.Drawing.Point(244, 57);
            this.lblVidDescription.Name = "lblVidDescription";
            this.lblVidDescription.Size = new System.Drawing.Size(721, 43);
            this.lblVidDescription.TabIndex = 4;
            this.lblVidDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbVidThumbnail
            // 
            this.pbVidThumbnail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbVidThumbnail.BorderRadius = 7;
            this.pbVidThumbnail.Location = new System.Drawing.Point(17, 19);
            this.pbVidThumbnail.Name = "pbVidThumbnail";
            this.pbVidThumbnail.ShadowDecoration.Parent = this.pbVidThumbnail;
            this.pbVidThumbnail.Size = new System.Drawing.Size(219, 122);
            this.pbVidThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVidThumbnail.TabIndex = 7;
            this.pbVidThumbnail.TabStop = false;
            // 
            // cbQualities
            // 
            this.cbQualities.Animated = true;
            this.cbQualities.BackColor = System.Drawing.Color.Transparent;
            this.cbQualities.BorderColor = System.Drawing.Color.DimGray;
            this.cbQualities.BorderRadius = 5;
            this.cbQualities.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbQualities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQualities.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(28)))), ((int)(((byte)(29)))));
            this.cbQualities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbQualities.FocusedColor = System.Drawing.Color.DimGray;
            this.cbQualities.FocusedState.BorderColor = System.Drawing.Color.DimGray;
            this.cbQualities.FocusedState.Parent = this.cbQualities;
            this.cbQualities.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbQualities.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.cbQualities.FormattingEnabled = true;
            this.cbQualities.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.cbQualities.HoverState.Parent = this.cbQualities;
            this.cbQualities.ItemHeight = 30;
            this.cbQualities.ItemsAppearance.Parent = this.cbQualities;
            this.cbQualities.Location = new System.Drawing.Point(248, 105);
            this.cbQualities.Name = "cbQualities";
            this.cbQualities.ShadowDecoration.Parent = this.cbQualities;
            this.cbQualities.Size = new System.Drawing.Size(154, 36);
            this.cbQualities.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cbQualities.TabIndex = 6;
            this.cbQualities.SelectedIndexChanged += new System.EventHandler(this.cbQualities_SelectedIndexChanged);
            // 
            // lblVidTitle
            // 
            this.lblVidTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblVidTitle.Font = new System.Drawing.Font("Segoe UI Variable Display", 16F, System.Drawing.FontStyle.Bold);
            this.lblVidTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(219)))), ((int)(((byte)(219)))));
            this.lblVidTitle.Location = new System.Drawing.Point(243, 19);
            this.lblVidTitle.Name = "lblVidTitle";
            this.lblVidTitle.Size = new System.Drawing.Size(722, 30);
            this.lblVidTitle.TabIndex = 5;
            this.lblVidTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDownload
            // 
            this.btnDownload.BorderRadius = 7;
            this.btnDownload.CheckedState.Parent = this.btnDownload;
            this.btnDownload.CustomImages.Parent = this.btnDownload;
            this.btnDownload.FillColor = System.Drawing.Color.DarkRed;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnDownload.HoverState.Parent = this.btnDownload;
            this.btnDownload.Location = new System.Drawing.Point(856, 105);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.ShadowDecoration.Parent = this.btnDownload;
            this.btnDownload.Size = new System.Drawing.Size(109, 36);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = global::YouTube_Downloader.Properties.Resources.Template_24;
            this.ClientSize = new System.Drawing.Size(1395, 972);
            this.Controls.Add(this.pnlVidInfo);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Separator1);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.prgbarLoadingInfo.ResumeLayout(false);
            this.prgbarLoadingInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownloads)).EndInit();
            this.cmsVidItemOptions.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.pnlVidInfo.ResumeLayout(false);
            this.pnlVidDuration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVidThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox tbURL;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnGetVidInfo;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDownloads;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox ControlBoxClose;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label34;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2Panel pnlVidInfo;
        private Guna.UI2.WinForms.Guna2Button btnDownload;
        private System.Windows.Forms.Label lblVidTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cbQualities;
        private Guna.UI2.WinForms.Guna2PictureBox pbVidThumbnail;
        private Guna.UI2.WinForms.Guna2Panel pnlVidDuration;
        private System.Windows.Forms.Label lblVidDuration;
        private System.Windows.Forms.Label lblVidSize;
        private System.Windows.Forms.Label lblVidDescription;
        private System.Windows.Forms.Label lblChannelName;
        private Guna.UI2.WinForms.Guna2CircleProgressBar prgbarLoadingInfo;
        private Guna.UI2.WinForms.Guna2Button btnCloseVidInfo;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cmsVidItemOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmCancel;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem tsmDelete;
        private System.Windows.Forms.Label lblDownloadsLimitReached;
        private System.Windows.Forms.Label lblNoDownloadsYet;
        private System.Windows.Forms.DataGridViewTextBoxColumn col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col4;
        private System.Windows.Forms.DataGridViewTextBoxColumn col5;
    }
}

