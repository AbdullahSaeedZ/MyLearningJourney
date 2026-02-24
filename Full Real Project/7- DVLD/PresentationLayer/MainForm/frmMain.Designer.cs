namespace PresentationLayer.MainForm
{
    partial class frmMain
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTopbar = new Guna.UI2.WinForms.Guna2Panel();
            this.tbQuickSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.ControlBoxClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlSideBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlProfiileSection = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfileUsername = new System.Windows.Forms.Label();
            this.lblProfilePersonName = new System.Windows.Forms.Label();
            this.pnlControlsContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new Guna.UI2.WinForms.Guna2Button();
            this.pbProfilePic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnDrivers = new Guna.UI2.WinForms.Guna2Button();
            this.btnPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnApplications = new Guna.UI2.WinForms.Guna2Button();
            this.btnOverview = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlTopbar.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            this.pnlProfiileSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.TargetControl = this.pnlTopbar;
            // 
            // pnlTopbar
            // 
            this.pnlTopbar.Controls.Add(this.lblQuickSearch);
            this.pnlTopbar.Controls.Add(this.tbQuickSearch);
            this.pnlTopbar.Controls.Add(this.guna2ControlBox3);
            this.pnlTopbar.Controls.Add(this.label2);
            this.pnlTopbar.Controls.Add(this.label1);
            this.pnlTopbar.Controls.Add(this.guna2ControlBox2);
            this.pnlTopbar.Controls.Add(this.ControlBoxClose);
            this.pnlTopbar.CustomBorderColor = System.Drawing.Color.Gray;
            this.pnlTopbar.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopbar.Location = new System.Drawing.Point(267, 0);
            this.pnlTopbar.Name = "pnlTopbar";
            this.pnlTopbar.ShadowDecoration.Parent = this.pnlTopbar;
            this.pnlTopbar.Size = new System.Drawing.Size(1283, 55);
            this.pnlTopbar.TabIndex = 1;
            // 
            // tbQuickSearch
            // 
            this.tbQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbQuickSearch.BorderRadius = 10;
            this.tbQuickSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbQuickSearch.DefaultText = "";
            this.tbQuickSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbQuickSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbQuickSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbQuickSearch.DisabledState.Parent = this.tbQuickSearch;
            this.tbQuickSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbQuickSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbQuickSearch.FocusedState.Parent = this.tbQuickSearch;
            this.tbQuickSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbQuickSearch.HoverState.Parent = this.tbQuickSearch;
            this.tbQuickSearch.Location = new System.Drawing.Point(849, 7);
            this.tbQuickSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbQuickSearch.Name = "tbQuickSearch";
            this.tbQuickSearch.PasswordChar = '\0';
            this.tbQuickSearch.PlaceholderText = "Person ID Quick Serach";
            this.tbQuickSearch.SelectedText = "";
            this.tbQuickSearch.ShadowDecoration.Parent = this.tbQuickSearch;
            this.tbQuickSearch.Size = new System.Drawing.Size(225, 39);
            this.tbQuickSearch.TabIndex = 1;
            this.tbQuickSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbQuickSearch_KeyDown);
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox3.HoverState.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1142, 3);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.ShadowDecoration.Parent = this.guna2ControlBox3;
            this.guna2ControlBox3.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(52, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Overview";
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.HoverState.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.Gray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(1188, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.ShadowDecoration.Parent = this.guna2ControlBox2;
            this.guna2ControlBox2.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox2.TabIndex = 0;
            // 
            // ControlBoxClose
            // 
            this.ControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBoxClose.FillColor = System.Drawing.Color.Transparent;
            this.ControlBoxClose.HoverState.Parent = this.ControlBoxClose;
            this.ControlBoxClose.IconColor = System.Drawing.Color.Gray;
            this.ControlBoxClose.Location = new System.Drawing.Point(1234, 3);
            this.ControlBoxClose.Name = "ControlBoxClose";
            this.ControlBoxClose.ShadowDecoration.Parent = this.ControlBoxClose;
            this.ControlBoxClose.Size = new System.Drawing.Size(45, 29);
            this.ControlBoxClose.TabIndex = 0;
            this.ControlBoxClose.Click += new System.EventHandler(this.ControlBoxClose_Click);
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.White;
            this.pnlSideBar.Controls.Add(this.pnlProfiileSection);
            this.pnlSideBar.Controls.Add(this.btnUsers);
            this.pnlSideBar.Controls.Add(this.btnDrivers);
            this.pnlSideBar.Controls.Add(this.btnPeople);
            this.pnlSideBar.Controls.Add(this.btnApplications);
            this.pnlSideBar.Controls.Add(this.btnOverview);
            this.pnlSideBar.Controls.Add(this.guna2PictureBox1);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.FillColor = System.Drawing.Color.White;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.ShadowDecoration.Parent = this.pnlSideBar;
            this.pnlSideBar.Size = new System.Drawing.Size(267, 870);
            this.pnlSideBar.TabIndex = 1;
            // 
            // pnlProfiileSection
            // 
            this.pnlProfiileSection.Controls.Add(this.guna2Separator1);
            this.pnlProfiileSection.Controls.Add(this.btnSettings);
            this.pnlProfiileSection.Controls.Add(this.lblProfileUsername);
            this.pnlProfiileSection.Controls.Add(this.lblProfilePersonName);
            this.pnlProfiileSection.Controls.Add(this.pbProfilePic);
            this.pnlProfiileSection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProfiileSection.Location = new System.Drawing.Point(0, 801);
            this.pnlProfiileSection.Name = "pnlProfiileSection";
            this.pnlProfiileSection.ShadowDecoration.Parent = this.pnlProfiileSection;
            this.pnlProfiileSection.Size = new System.Drawing.Size(267, 69);
            this.pnlProfiileSection.TabIndex = 2;
            // 
            // lblProfileUsername
            // 
            this.lblProfileUsername.AutoSize = true;
            this.lblProfileUsername.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileUsername.ForeColor = System.Drawing.Color.Gray;
            this.lblProfileUsername.Location = new System.Drawing.Point(66, 36);
            this.lblProfileUsername.Name = "lblProfileUsername";
            this.lblProfileUsername.Size = new System.Drawing.Size(47, 16);
            this.lblProfileUsername.TabIndex = 1;
            this.lblProfileUsername.Text = "Admin";
            // 
            // lblProfilePersonName
            // 
            this.lblProfilePersonName.AutoSize = true;
            this.lblProfilePersonName.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfilePersonName.Location = new System.Drawing.Point(66, 16);
            this.lblProfilePersonName.Name = "lblProfilePersonName";
            this.lblProfilePersonName.Size = new System.Drawing.Size(128, 16);
            this.lblProfilePersonName.TabIndex = 1;
            this.lblProfilePersonName.Text = "Abdullah Alzahrani";
            // 
            // pnlControlsContainer
            // 
            this.pnlControlsContainer.Location = new System.Drawing.Point(267, 55);
            this.pnlControlsContainer.Name = "pnlControlsContainer";
            this.pnlControlsContainer.ShadowDecoration.Parent = this.pnlControlsContainer;
            this.pnlControlsContainer.Size = new System.Drawing.Size(1283, 815);
            this.pnlControlsContainer.TabIndex = 2;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Location = new System.Drawing.Point(31, -3);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(200, 10);
            this.guna2Separator1.TabIndex = 0;
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuickSearch.BackColor = System.Drawing.Color.White;
            this.lblQuickSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuickSearch.Image = global::PresentationLayer.Properties.Resources.QuickSearch;
            this.lblQuickSearch.Location = new System.Drawing.Point(1038, 13);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(28, 23);
            this.lblQuickSearch.TabIndex = 4;
            this.lblQuickSearch.Click += new System.EventHandler(this.lblQuickSearch_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Image = global::PresentationLayer.Properties.Resources.settingsBig;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 26);
            this.label2.TabIndex = 1;
            // 
            // btnSettings
            // 
            this.btnSettings.BorderRadius = 10;
            this.btnSettings.CheckedState.Parent = this.btnSettings;
            this.btnSettings.CustomImages.Parent = this.btnSettings;
            this.btnSettings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.HoverState.BorderColor = System.Drawing.Color.Navy;
            this.btnSettings.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(83)))), ((int)(((byte)(251)))));
            this.btnSettings.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSettings.HoverState.Image = global::PresentationLayer.Properties.Resources.settingNoFill;
            this.btnSettings.HoverState.Parent = this.btnSettings;
            this.btnSettings.Image = global::PresentationLayer.Properties.Resources.settingsFill;
            this.btnSettings.Location = new System.Drawing.Point(221, 16);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.ShadowDecoration.Parent = this.btnSettings;
            this.btnSettings.Size = new System.Drawing.Size(33, 32);
            this.btnSettings.TabIndex = 3;
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Image = global::PresentationLayer.Properties.Resources.ProfileTest;
            this.pbProfilePic.Location = new System.Drawing.Point(16, 13);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pbProfilePic.ShadowDecoration.Parent = this.pbProfilePic;
            this.pbProfilePic.Size = new System.Drawing.Size(40, 40);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePic.TabIndex = 0;
            this.pbProfilePic.TabStop = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BorderRadius = 10;
            this.btnUsers.CheckedState.Parent = this.btnUsers;
            this.btnUsers.CustomImages.Parent = this.btnUsers;
            this.btnUsers.FillColor = System.Drawing.Color.Transparent;
            this.btnUsers.Font = new System.Drawing.Font("Bahnschrift", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnUsers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnUsers.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnUsers.HoverState.Image = global::PresentationLayer.Properties.Resources.usersNoFillBold;
            this.btnUsers.HoverState.Parent = this.btnUsers;
            this.btnUsers.Image = global::PresentationLayer.Properties.Resources.usersFill;
            this.btnUsers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUsers.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnUsers.Location = new System.Drawing.Point(12, 349);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.PressedColor = System.Drawing.Color.Blue;
            this.btnUsers.ShadowDecoration.Parent = this.btnUsers;
            this.btnUsers.Size = new System.Drawing.Size(241, 45);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "Users";
            // 
            // btnDrivers
            // 
            this.btnDrivers.BorderRadius = 10;
            this.btnDrivers.CheckedState.Parent = this.btnDrivers;
            this.btnDrivers.CustomImages.Parent = this.btnDrivers;
            this.btnDrivers.FillColor = System.Drawing.Color.Transparent;
            this.btnDrivers.Font = new System.Drawing.Font("Bahnschrift", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDrivers.ForeColor = System.Drawing.Color.Black;
            this.btnDrivers.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnDrivers.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnDrivers.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnDrivers.HoverState.Image = global::PresentationLayer.Properties.Resources.DriversNoFill;
            this.btnDrivers.HoverState.Parent = this.btnDrivers;
            this.btnDrivers.Image = global::PresentationLayer.Properties.Resources.DriversFill;
            this.btnDrivers.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDrivers.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnDrivers.Location = new System.Drawing.Point(12, 298);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.PressedColor = System.Drawing.Color.Blue;
            this.btnDrivers.ShadowDecoration.Parent = this.btnDrivers;
            this.btnDrivers.Size = new System.Drawing.Size(241, 45);
            this.btnDrivers.TabIndex = 1;
            this.btnDrivers.Text = "Drivers";
            // 
            // btnPeople
            // 
            this.btnPeople.BorderRadius = 10;
            this.btnPeople.CheckedState.Parent = this.btnPeople;
            this.btnPeople.CustomImages.Parent = this.btnPeople;
            this.btnPeople.FillColor = System.Drawing.Color.Transparent;
            this.btnPeople.Font = new System.Drawing.Font("Bahnschrift", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeople.ForeColor = System.Drawing.Color.Black;
            this.btnPeople.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnPeople.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnPeople.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnPeople.HoverState.Image = global::PresentationLayer.Properties.Resources.peopleNoFill;
            this.btnPeople.HoverState.Parent = this.btnPeople;
            this.btnPeople.Image = global::PresentationLayer.Properties.Resources.peopleFill;
            this.btnPeople.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPeople.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnPeople.Location = new System.Drawing.Point(12, 247);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.PressedColor = System.Drawing.Color.Blue;
            this.btnPeople.ShadowDecoration.Parent = this.btnPeople;
            this.btnPeople.Size = new System.Drawing.Size(241, 45);
            this.btnPeople.TabIndex = 1;
            this.btnPeople.Text = "People";
            // 
            // btnApplications
            // 
            this.btnApplications.BorderRadius = 10;
            this.btnApplications.CheckedState.Parent = this.btnApplications;
            this.btnApplications.CustomImages.Parent = this.btnApplications;
            this.btnApplications.FillColor = System.Drawing.Color.Transparent;
            this.btnApplications.Font = new System.Drawing.Font("Bahnschrift", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplications.ForeColor = System.Drawing.Color.Black;
            this.btnApplications.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnApplications.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnApplications.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnApplications.HoverState.Image = global::PresentationLayer.Properties.Resources.applicationsNoFill;
            this.btnApplications.HoverState.Parent = this.btnApplications;
            this.btnApplications.Image = global::PresentationLayer.Properties.Resources.applications;
            this.btnApplications.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnApplications.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnApplications.Location = new System.Drawing.Point(12, 196);
            this.btnApplications.Name = "btnApplications";
            this.btnApplications.PressedColor = System.Drawing.Color.Blue;
            this.btnApplications.ShadowDecoration.Parent = this.btnApplications;
            this.btnApplications.Size = new System.Drawing.Size(241, 45);
            this.btnApplications.TabIndex = 1;
            this.btnApplications.Text = "Applications";
            // 
            // btnOverview
            // 
            this.btnOverview.BorderRadius = 10;
            this.btnOverview.CheckedState.Parent = this.btnOverview;
            this.btnOverview.CustomImages.Parent = this.btnOverview;
            this.btnOverview.FillColor = System.Drawing.Color.Transparent;
            this.btnOverview.Font = new System.Drawing.Font("Bahnschrift", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOverview.ForeColor = System.Drawing.Color.Black;
            this.btnOverview.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnOverview.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.btnOverview.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnOverview.HoverState.Image = global::PresentationLayer.Properties.Resources.DashboardNoFill;
            this.btnOverview.HoverState.Parent = this.btnOverview;
            this.btnOverview.Image = global::PresentationLayer.Properties.Resources.DashboardFill;
            this.btnOverview.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOverview.ImageOffset = new System.Drawing.Point(10, 0);
            this.btnOverview.Location = new System.Drawing.Point(12, 145);
            this.btnOverview.Name = "btnOverview";
            this.btnOverview.PressedColor = System.Drawing.Color.Blue;
            this.btnOverview.ShadowDecoration.Parent = this.btnOverview;
            this.btnOverview.Size = new System.Drawing.Size(241, 45);
            this.btnOverview.TabIndex = 1;
            this.btnOverview.Text = "Overview";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.BackgroundImage = global::PresentationLayer.Properties.Resources.logoSmall;
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2PictureBox1.Location = new System.Drawing.Point(31, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(183, 107);
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1550, 870);
            this.Controls.Add(this.pnlControlsContainer);
            this.Controls.Add(this.pnlTopbar);
            this.Controls.Add(this.pnlSideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.pnlTopbar.ResumeLayout(false);
            this.pnlTopbar.PerformLayout();
            this.pnlSideBar.ResumeLayout(false);
            this.pnlProfiileSection.ResumeLayout(false);
            this.pnlProfiileSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ControlBox ControlBoxClose;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Panel pnlTopbar;
        private Guna.UI2.WinForms.Guna2Panel pnlSideBar;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2TextBox tbQuickSearch;
        private System.Windows.Forms.Label lblQuickSearch;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlProfiileSection;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnDrivers;
        private Guna.UI2.WinForms.Guna2Button btnPeople;
        private Guna.UI2.WinForms.Guna2Button btnApplications;
        private Guna.UI2.WinForms.Guna2Button btnOverview;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pbProfilePic;
        private System.Windows.Forms.Label lblProfileUsername;
        private System.Windows.Forms.Label lblProfilePersonName;
        private Guna.UI2.WinForms.Guna2Button btnSettings;
        private Guna.UI2.WinForms.Guna2Panel pnlControlsContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}