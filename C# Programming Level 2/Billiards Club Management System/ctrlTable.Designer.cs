namespace Billiards_Club_Management_System
{
    partial class ctrlTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pbStatus = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbTimeProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnStartStop = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox12 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblFoodOrders = new System.Windows.Forms.Label();
            this.lblMonyAmount = new System.Windows.Forms.Label();
            this.pnlStatusColor = new Guna.UI2.WinForms.Guna2Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlSessionSummary = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCompleteSession = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSummaryTime = new System.Windows.Forms.Label();
            this.lblSummaryPayment = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDiscardSession = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.pnlSessionSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(95, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 21);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "FREE";
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblTableNumber.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblTableNumber.Location = new System.Drawing.Point(287, 13);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(58, 49);
            this.lblTableNumber.TabIndex = 0;
            this.lblTableNumber.Text = "01";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.pbStatus);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2Panel2.Location = new System.Drawing.Point(26, 69);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(49, 43);
            this.guna2Panel2.TabIndex = 33;
            // 
            // pbStatus
            // 
            this.pbStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.pbStatus.Image = global::Billiards_Club_Management_System.Properties.Resources.freeTablesDark512;
            this.pbStatus.Location = new System.Drawing.Point(9, 7);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.ShadowDecoration.Parent = this.pbStatus;
            this.pbStatus.Size = new System.Drawing.Size(30, 30);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 26;
            this.pbStatus.TabStop = false;
            this.pbStatus.UseTransparentBackground = true;
            // 
            // pbTimeProgress
            // 
            this.pbTimeProgress.BorderRadius = 5;
            this.pbTimeProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.pbTimeProgress.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pbTimeProgress.Location = new System.Drawing.Point(26, 206);
            this.pbTimeProgress.Maximum = 60;
            this.pbTimeProgress.Name = "pbTimeProgress";
            this.pbTimeProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(178)))), ((int)(((byte)(116)))));
            this.pbTimeProgress.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(100)))), ((int)(((byte)(46)))));
            this.pbTimeProgress.ShadowDecoration.Parent = this.pbTimeProgress;
            this.pbTimeProgress.Size = new System.Drawing.Size(317, 10);
            this.pbTimeProgress.TabIndex = 34;
            this.pbTimeProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.pnlSessionSummary);
            this.guna2Panel1.Controls.Add(this.btnStartStop);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox12);
            this.guna2Panel1.Controls.Add(this.pbTimeProgress);
            this.guna2Panel1.Controls.Add(this.guna2Panel4);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.lblTimer);
            this.guna2Panel1.Controls.Add(this.lblFoodOrders);
            this.guna2Panel1.Controls.Add(this.lblMonyAmount);
            this.guna2Panel1.Controls.Add(this.lblTableNumber);
            this.guna2Panel1.Controls.Add(this.lblStatus);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.guna2Panel1.Location = new System.Drawing.Point(3, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(376, 240);
            this.guna2Panel1.TabIndex = 30;
            // 
            // btnStartStop
            // 
            this.btnStartStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStartStop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnStartStop.BorderRadius = 8;
            this.btnStartStop.BorderThickness = 1;
            this.btnStartStop.CheckedState.Parent = this.btnStartStop;
            this.btnStartStop.CustomImages.Parent = this.btnStartStop;
            this.btnStartStop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnStartStop.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnStartStop.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnStartStop.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnStartStop.HoverState.Image = global::Billiards_Club_Management_System.Properties.Resources.start1White512;
            this.btnStartStop.HoverState.Parent = this.btnStartStop;
            this.btnStartStop.Image = global::Billiards_Club_Management_System.Properties.Resources.startDark512;
            this.btnStartStop.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartStop.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnStartStop.Location = new System.Drawing.Point(26, 23);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.ShadowDecoration.Parent = this.btnStartStop;
            this.btnStartStop.Size = new System.Drawing.Size(107, 35);
            this.btnStartStop.TabIndex = 37;
            this.btnStartStop.Text = "START";
            this.btnStartStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnStartStop.TextOffset = new System.Drawing.Point(10, 0);
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // guna2PictureBox12
            // 
            this.guna2PictureBox12.BorderRadius = 10;
            this.guna2PictureBox12.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox12.Image = global::Billiards_Club_Management_System.Properties.Resources.Saudi_Riyal_Symbol_1;
            this.guna2PictureBox12.Location = new System.Drawing.Point(265, 179);
            this.guna2PictureBox12.Name = "guna2PictureBox12";
            this.guna2PictureBox12.ShadowDecoration.Parent = this.guna2PictureBox12;
            this.guna2PictureBox12.Size = new System.Drawing.Size(22, 22);
            this.guna2PictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox12.TabIndex = 36;
            this.guna2PictureBox12.TabStop = false;
            this.guna2PictureBox12.UseTransparentBackground = true;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel4.BorderRadius = 10;
            this.guna2Panel4.BorderThickness = 1;
            this.guna2Panel4.Controls.Add(this.guna2PictureBox10);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2Panel4.Location = new System.Drawing.Point(26, 118);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(49, 43);
            this.guna2Panel4.TabIndex = 33;
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox10.Image = global::Billiards_Club_Management_System.Properties.Resources.foodDarkNoFIll512;
            this.guna2PictureBox10.Location = new System.Drawing.Point(9, 7);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.ShadowDecoration.Parent = this.guna2PictureBox10;
            this.guna2PictureBox10.Size = new System.Drawing.Size(30, 30);
            this.guna2PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox10.TabIndex = 37;
            this.guna2PictureBox10.TabStop = false;
            this.guna2PictureBox10.UseTransparentBackground = true;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.BackColor = System.Drawing.Color.Transparent;
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblTimer.Location = new System.Drawing.Point(20, 173);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(77, 33);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00";
            // 
            // lblFoodOrders
            // 
            this.lblFoodOrders.AutoSize = true;
            this.lblFoodOrders.BackColor = System.Drawing.Color.Transparent;
            this.lblFoodOrders.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodOrders.ForeColor = System.Drawing.Color.DimGray;
            this.lblFoodOrders.Location = new System.Drawing.Point(95, 129);
            this.lblFoodOrders.Name = "lblFoodOrders";
            this.lblFoodOrders.Size = new System.Drawing.Size(145, 21);
            this.lblFoodOrders.TabIndex = 0;
            this.lblFoodOrders.Text = "0 FOOD ORDER(S)";
            // 
            // lblMonyAmount
            // 
            this.lblMonyAmount.AutoSize = true;
            this.lblMonyAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblMonyAmount.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblMonyAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblMonyAmount.Location = new System.Drawing.Point(285, 172);
            this.lblMonyAmount.Name = "lblMonyAmount";
            this.lblMonyAmount.Size = new System.Drawing.Size(63, 33);
            this.lblMonyAmount.TabIndex = 0;
            this.lblMonyAmount.Text = "0.00";
            // 
            // pnlStatusColor
            // 
            this.pnlStatusColor.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlStatusColor.BorderRadius = 13;
            this.pnlStatusColor.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStatusColor.FillColor = System.Drawing.Color.DarkSeaGreen;
            this.pnlStatusColor.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusColor.Name = "pnlStatusColor";
            this.pnlStatusColor.ShadowDecoration.Parent = this.pnlStatusColor;
            this.pnlStatusColor.Size = new System.Drawing.Size(373, 240);
            this.pnlStatusColor.TabIndex = 36;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlSessionSummary
            // 
            this.pnlSessionSummary.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlSessionSummary.BorderRadius = 10;
            this.pnlSessionSummary.Controls.Add(this.btnDiscardSession);
            this.pnlSessionSummary.Controls.Add(this.btnCompleteSession);
            this.pnlSessionSummary.Controls.Add(this.guna2PictureBox1);
            this.pnlSessionSummary.Controls.Add(this.guna2Panel7);
            this.pnlSessionSummary.Controls.Add(this.lblSummaryTime);
            this.pnlSessionSummary.Controls.Add(this.lblSummaryPayment);
            this.pnlSessionSummary.Controls.Add(this.label4);
            this.pnlSessionSummary.Controls.Add(this.label2);
            this.pnlSessionSummary.Controls.Add(this.label5);
            this.pnlSessionSummary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.pnlSessionSummary.Location = new System.Drawing.Point(25, 54);
            this.pnlSessionSummary.Name = "pnlSessionSummary";
            this.pnlSessionSummary.ShadowDecoration.Parent = this.pnlSessionSummary;
            this.pnlSessionSummary.Size = new System.Drawing.Size(337, 171);
            this.pnlSessionSummary.TabIndex = 38;
            this.pnlSessionSummary.Visible = false;
            // 
            // btnCompleteSession
            // 
            this.btnCompleteSession.BackColor = System.Drawing.Color.Transparent;
            this.btnCompleteSession.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnCompleteSession.BorderRadius = 8;
            this.btnCompleteSession.BorderThickness = 1;
            this.btnCompleteSession.CheckedState.Parent = this.btnCompleteSession;
            this.btnCompleteSession.CustomImages.Parent = this.btnCompleteSession;
            this.btnCompleteSession.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnCompleteSession.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnCompleteSession.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnCompleteSession.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnCompleteSession.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnCompleteSession.HoverState.Parent = this.btnCompleteSession;
            this.btnCompleteSession.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCompleteSession.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnCompleteSession.Location = new System.Drawing.Point(158, 139);
            this.btnCompleteSession.Name = "btnCompleteSession";
            this.btnCompleteSession.ShadowDecoration.Parent = this.btnCompleteSession;
            this.btnCompleteSession.Size = new System.Drawing.Size(107, 29);
            this.btnCompleteSession.TabIndex = 37;
            this.btnCompleteSession.Text = "COMPLETE";
            this.btnCompleteSession.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCompleteSession.Click += new System.EventHandler(this.btnCompleteSession_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox1.Image = global::Billiards_Club_Management_System.Properties.Resources.Saudi_Riyal_Symbol_1;
            this.guna2PictureBox1.Location = new System.Drawing.Point(175, 94);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(22, 22);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 36;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel7.BorderRadius = 10;
            this.guna2Panel7.BorderThickness = 1;
            this.guna2Panel7.Controls.Add(this.guna2PictureBox3);
            this.guna2Panel7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2Panel7.Location = new System.Drawing.Point(23, 2);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.ShadowDecoration.Parent = this.guna2Panel7;
            this.guna2Panel7.Size = new System.Drawing.Size(49, 43);
            this.guna2Panel7.TabIndex = 33;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox3.Image = global::Billiards_Club_Management_System.Properties.Resources.freeTablesDark512;
            this.guna2PictureBox3.Location = new System.Drawing.Point(9, 7);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(30, 30);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 26;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // lblSummaryTime
            // 
            this.lblSummaryTime.AutoSize = true;
            this.lblSummaryTime.BackColor = System.Drawing.Color.Transparent;
            this.lblSummaryTime.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblSummaryTime.Location = new System.Drawing.Point(17, 83);
            this.lblSummaryTime.Name = "lblSummaryTime";
            this.lblSummaryTime.Size = new System.Drawing.Size(77, 33);
            this.lblSummaryTime.TabIndex = 0;
            this.lblSummaryTime.Text = "00:00";
            // 
            // lblSummaryPayment
            // 
            this.lblSummaryPayment.AutoSize = true;
            this.lblSummaryPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblSummaryPayment.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblSummaryPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblSummaryPayment.Location = new System.Drawing.Point(195, 87);
            this.lblSummaryPayment.Name = "lblSummaryPayment";
            this.lblSummaryPayment.Size = new System.Drawing.Size(63, 33);
            this.lblSummaryPayment.TabIndex = 0;
            this.lblSummaryPayment.Text = "0.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(90, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "SESSION SUMMARY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "SESSION TIME";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Display", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(171, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "SESSION PAYMENT";
            // 
            // btnDiscardSession
            // 
            this.btnDiscardSession.BackColor = System.Drawing.Color.Transparent;
            this.btnDiscardSession.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnDiscardSession.BorderRadius = 8;
            this.btnDiscardSession.BorderThickness = 1;
            this.btnDiscardSession.CheckedState.Parent = this.btnDiscardSession;
            this.btnDiscardSession.CustomImages.Parent = this.btnDiscardSession;
            this.btnDiscardSession.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnDiscardSession.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscardSession.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnDiscardSession.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnDiscardSession.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnDiscardSession.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(246)))));
            this.btnDiscardSession.HoverState.Parent = this.btnDiscardSession;
            this.btnDiscardSession.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDiscardSession.ImageOffset = new System.Drawing.Point(5, 0);
            this.btnDiscardSession.Location = new System.Drawing.Point(61, 139);
            this.btnDiscardSession.Name = "btnDiscardSession";
            this.btnDiscardSession.ShadowDecoration.Parent = this.btnDiscardSession;
            this.btnDiscardSession.Size = new System.Drawing.Size(84, 29);
            this.btnDiscardSession.TabIndex = 37;
            this.btnDiscardSession.Text = "DISCRD";
            this.btnDiscardSession.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDiscardSession.Click += new System.EventHandler(this.btnDiscardSession_Click);
            // 
            // ctrlTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.pnlStatusColor);
            this.Name = "ctrlTable";
            this.Size = new System.Drawing.Size(379, 240);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.pnlSessionSummary.ResumeLayout(false);
            this.pnlSessionSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTableNumber;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox pbStatus;
        private Guna.UI2.WinForms.Guna2ProgressBar pbTimeProgress;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel pnlStatusColor;
        private System.Windows.Forms.Label lblTimer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblFoodOrders;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox12;
        private System.Windows.Forms.Label lblMonyAmount;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2Button btnStartStop;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Panel pnlSessionSummary;
        private Guna.UI2.WinForms.Guna2Button btnCompleteSession;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private System.Windows.Forms.Label lblSummaryTime;
        private System.Windows.Forms.Label lblSummaryPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnDiscardSession;
    }
}
