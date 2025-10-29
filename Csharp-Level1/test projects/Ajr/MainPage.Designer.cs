namespace Ajr
{
    partial class MainPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTestNotify = new ReaLTaiizor.Controls.LostButton();
            this.cbNotificationType = new System.Windows.Forms.ComboBox();
            this.cbPeriodBetweenNotification = new System.Windows.Forms.ComboBox();
            this.timerBalloon = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.rbStartupOn = new System.Windows.Forms.RadioButton();
            this.rbStartupOff = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbNotifyOff = new System.Windows.Forms.RadioButton();
            this.rbNotifyOn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(362, 83);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(125, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "نوع الاشعارات:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(355, 136);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "تكرار الاشعارات:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(362, 190);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "حالة الاشعارات:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(122, 329);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(273, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "صوت الاشعارات يتم التحكم به من قبل النظام";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(297, 248);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(194, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "تشغيل البرنامج التلقائي:";
            // 
            // btnTestNotify
            // 
            this.btnTestNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnTestNotify.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestNotify.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTestNotify.ForeColor = System.Drawing.Color.White;
            this.btnTestNotify.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnTestNotify.Image = null;
            this.btnTestNotify.Location = new System.Drawing.Point(154, 385);
            this.btnTestNotify.Name = "btnTestNotify";
            this.btnTestNotify.Size = new System.Drawing.Size(212, 35);
            this.btnTestNotify.TabIndex = 9;
            this.btnTestNotify.Tag = "Main";
            this.btnTestNotify.Text = "تجربة الاشعار";
            this.btnTestNotify.Click += new System.EventHandler(this.btnTestNotify_Click);
            // 
            // cbNotificationType
            // 
            this.cbNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationType.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbNotificationType.FormattingEnabled = true;
            this.cbNotificationType.Items.AddRange(new object[] {
            "ادعية",
            "استغفار و تسبيح",
            "صلاة على النبي",
            "اذكار الصباح و المساء",
            "تذكير متنوع"});
            this.cbNotificationType.Location = new System.Drawing.Point(60, 83);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(183, 25);
            this.cbNotificationType.TabIndex = 3;
            this.cbNotificationType.SelectedIndexChanged += new System.EventHandler(this.cbNotificationType_SelectedIndexChanged);
            // 
            // cbPeriodBetweenNotification
            // 
            this.cbPeriodBetweenNotification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPeriodBetweenNotification.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.cbPeriodBetweenNotification.FormattingEnabled = true;
            this.cbPeriodBetweenNotification.Items.AddRange(new object[] {
            "كل خمس دقائق",
            "كل عشر دقائق",
            "كل ربع ساعه",
            "كل نصف ساعه",
            "كل ساعه",
            "كل ساعتين",
            "كل ثلاثة ساعات",
            "كل اربعة ساعات",
            "كل خمسة ساعات"});
            this.cbPeriodBetweenNotification.Location = new System.Drawing.Point(60, 136);
            this.cbPeriodBetweenNotification.Name = "cbPeriodBetweenNotification";
            this.cbPeriodBetweenNotification.Size = new System.Drawing.Size(183, 25);
            this.cbPeriodBetweenNotification.TabIndex = 4;
            this.cbPeriodBetweenNotification.SelectedIndexChanged += new System.EventHandler(this.cbPeriodBetweenNotification_SelectedIndexChanged);
            // 
            // timerBalloon
            // 
            this.timerBalloon.Tick += new System.EventHandler(this.timerBalloon_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "Ajr";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            this.notifyIcon1.BalloonTipShown += new System.EventHandler(this.notifyIcon1_BalloonTipShown);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShow,
            this.tsmClose});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 52);
            // 
            // tsmShow
            // 
            this.tsmShow.Name = "tsmShow";
            this.tsmShow.Size = new System.Drawing.Size(112, 24);
            this.tsmShow.Text = "عرض";
            this.tsmShow.Click += new System.EventHandler(this.tsmShow_Click);
            // 
            // tsmClose
            // 
            this.tsmClose.Name = "tsmClose";
            this.tsmClose.Size = new System.Drawing.Size(112, 24);
            this.tsmClose.Text = "اغلاق";
            this.tsmClose.Click += new System.EventHandler(this.tsmClose_Click);
            // 
            // rbStartupOn
            // 
            this.rbStartupOn.AutoSize = true;
            this.rbStartupOn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbStartupOn.ForeColor = System.Drawing.Color.White;
            this.rbStartupOn.Location = new System.Drawing.Point(100, 3);
            this.rbStartupOn.Name = "rbStartupOn";
            this.rbStartupOn.Size = new System.Drawing.Size(85, 29);
            this.rbStartupOn.TabIndex = 7;
            this.rbStartupOn.TabStop = true;
            this.rbStartupOn.Text = "تشغيل";
            this.rbStartupOn.UseVisualStyleBackColor = true;
            this.rbStartupOn.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbStartupOff
            // 
            this.rbStartupOff.AutoSize = true;
            this.rbStartupOff.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbStartupOff.ForeColor = System.Drawing.Color.White;
            this.rbStartupOff.Location = new System.Drawing.Point(5, 3);
            this.rbStartupOff.Name = "rbStartupOff";
            this.rbStartupOff.Size = new System.Drawing.Size(78, 29);
            this.rbStartupOff.TabIndex = 8;
            this.rbStartupOff.TabStop = true;
            this.rbStartupOff.Text = "ايقاف";
            this.rbStartupOff.UseVisualStyleBackColor = true;
            this.rbStartupOff.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbStartupOff);
            this.panel3.Controls.Add(this.rbStartupOn);
            this.panel3.Location = new System.Drawing.Point(54, 245);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 41);
            this.panel3.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbNotifyOff);
            this.panel2.Controls.Add(this.rbNotifyOn);
            this.panel2.Location = new System.Drawing.Point(54, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 41);
            this.panel2.TabIndex = 36;
            // 
            // rbNotifyOff
            // 
            this.rbNotifyOff.AutoSize = true;
            this.rbNotifyOff.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbNotifyOff.ForeColor = System.Drawing.Color.White;
            this.rbNotifyOff.Location = new System.Drawing.Point(5, 3);
            this.rbNotifyOff.Name = "rbNotifyOff";
            this.rbNotifyOff.Size = new System.Drawing.Size(78, 29);
            this.rbNotifyOff.TabIndex = 6;
            this.rbNotifyOff.TabStop = true;
            this.rbNotifyOff.Text = "ايقاف";
            this.rbNotifyOff.UseVisualStyleBackColor = true;
            this.rbNotifyOff.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbNotifyOn
            // 
            this.rbNotifyOn.AutoSize = true;
            this.rbNotifyOn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbNotifyOn.ForeColor = System.Drawing.Color.White;
            this.rbNotifyOn.Location = new System.Drawing.Point(100, 3);
            this.rbNotifyOn.Name = "rbNotifyOn";
            this.rbNotifyOn.Size = new System.Drawing.Size(85, 29);
            this.rbNotifyOn.TabIndex = 5;
            this.rbNotifyOn.TabStop = true;
            this.rbNotifyOn.Text = "تشغيل";
            this.rbNotifyOn.UseVisualStyleBackColor = true;
            this.rbNotifyOn.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbNotificationType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbPeriodBetweenNotification);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnTestNotify);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 525);
            this.panel1.TabIndex = 37;
            // 
            // MainPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(548, 525);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private ReaLTaiizor.Controls.LostButton btnTestNotify;
        private System.Windows.Forms.ComboBox cbNotificationType;
        private System.Windows.Forms.ComboBox cbPeriodBetweenNotification;
        private System.Windows.Forms.Timer timerBalloon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbNotifyOff;
        private System.Windows.Forms.RadioButton rbNotifyOn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbStartupOff;
        private System.Windows.Forms.RadioButton rbStartupOn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShow;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}
