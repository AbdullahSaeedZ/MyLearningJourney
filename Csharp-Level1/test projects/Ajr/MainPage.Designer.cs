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
            this.label7 = new System.Windows.Forms.Label();
            this.btnDefaultSettings = new ReaLTaiizor.Controls.LostButton();
            this.cbNotificationType = new System.Windows.Forms.ComboBox();
            this.cbPeriodBetweenNotification = new System.Windows.Forms.ComboBox();
            this.nudNotificationShowTime = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.timerBalloon = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClose = new System.Windows.Forms.ToolStripMenuItem();
            this.rbStartupOn = new System.Windows.Forms.RadioButton();
            this.rbStartupOff = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbNotifySoundOff = new System.Windows.Forms.RadioButton();
            this.rbNotifySoundOn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbNotifyOff = new System.Windows.Forms.RadioButton();
            this.rbNotifyOn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudNotificationShowTime)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(270, 78);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 20;
            this.label1.Text = "نوع الاشعارات:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(239, 131);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(145, 25);
            this.label3.TabIndex = 20;
            this.label3.Text = "المدة بين الاشعارات:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(266, 237);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "حالة الاشعارات:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(255, 290);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(129, 25);
            this.label5.TabIndex = 20;
            this.label5.Text = "صوت الاشعارات:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(221, 343);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(163, 25);
            this.label6.TabIndex = 20;
            this.label6.Text = "تشغيل البرنامج التلقائي:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(230, 184);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(154, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "مدة ظهور الاشعارات:";
            // 
            // btnDefaultSettings
            // 
            this.btnDefaultSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnDefaultSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefaultSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDefaultSettings.ForeColor = System.Drawing.Color.White;
            this.btnDefaultSettings.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.btnDefaultSettings.Image = null;
            this.btnDefaultSettings.Location = new System.Drawing.Point(91, 417);
            this.btnDefaultSettings.Name = "btnDefaultSettings";
            this.btnDefaultSettings.Size = new System.Drawing.Size(212, 35);
            this.btnDefaultSettings.TabIndex = 21;
            this.btnDefaultSettings.Tag = "Main";
            this.btnDefaultSettings.Text = "تطبيق اعدادات افتراضيه";
            this.btnDefaultSettings.Click += new System.EventHandler(this.btnDefaultSettings_Click);
            // 
            // cbNotificationType
            // 
            this.cbNotificationType.FormattingEnabled = true;
            this.cbNotificationType.Items.AddRange(new object[] {
            "ادعية",
            "تسبيح و استغفار",
            "صلاة على النبي",
            "اذكار الصباح و المساء",
            "تذكير متنوع"});
            this.cbNotificationType.Location = new System.Drawing.Point(36, 79);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(167, 24);
            this.cbNotificationType.TabIndex = 22;
            this.cbNotificationType.SelectedIndexChanged += new System.EventHandler(this.cbNotificationType_SelectedIndexChanged);
            // 
            // cbPeriodBetweenNotification
            // 
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
            this.cbPeriodBetweenNotification.Location = new System.Drawing.Point(36, 132);
            this.cbPeriodBetweenNotification.Name = "cbPeriodBetweenNotification";
            this.cbPeriodBetweenNotification.Size = new System.Drawing.Size(167, 24);
            this.cbPeriodBetweenNotification.TabIndex = 22;
            this.cbPeriodBetweenNotification.SelectedIndexChanged += new System.EventHandler(this.cbPeriodBetweenNotification_SelectedIndexChanged);
            // 
            // nudNotificationShowTime
            // 
            this.nudNotificationShowTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNotificationShowTime.Location = new System.Drawing.Point(82, 181);
            this.nudNotificationShowTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudNotificationShowTime.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNotificationShowTime.Name = "nudNotificationShowTime";
            this.nudNotificationShowTime.Size = new System.Drawing.Size(79, 28);
            this.nudNotificationShowTime.TabIndex = 29;
            this.nudNotificationShowTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudNotificationShowTime.ValueChanged += new System.EventHandler(this.nudNotificationShowTime_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(36, 184);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(46, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "ثواني";
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
            this.rbStartupOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbStartupOn.ForeColor = System.Drawing.Color.White;
            this.rbStartupOn.Location = new System.Drawing.Point(100, 3);
            this.rbStartupOn.Name = "rbStartupOn";
            this.rbStartupOn.Size = new System.Drawing.Size(72, 29);
            this.rbStartupOn.TabIndex = 30;
            this.rbStartupOn.TabStop = true;
            this.rbStartupOn.Text = "تشغيل";
            this.rbStartupOn.UseVisualStyleBackColor = true;
            this.rbStartupOn.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbStartupOff
            // 
            this.rbStartupOff.AutoSize = true;
            this.rbStartupOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbStartupOff.ForeColor = System.Drawing.Color.White;
            this.rbStartupOff.Location = new System.Drawing.Point(5, 3);
            this.rbStartupOff.Name = "rbStartupOff";
            this.rbStartupOff.Size = new System.Drawing.Size(68, 29);
            this.rbStartupOff.TabIndex = 31;
            this.rbStartupOff.TabStop = true;
            this.rbStartupOff.Text = "ايقاف";
            this.rbStartupOff.UseVisualStyleBackColor = true;
            this.rbStartupOff.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbStartupOff);
            this.panel3.Controls.Add(this.rbStartupOn);
            this.panel3.Location = new System.Drawing.Point(30, 337);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(189, 41);
            this.panel3.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbNotifySoundOff);
            this.panel1.Controls.Add(this.rbNotifySoundOn);
            this.panel1.Location = new System.Drawing.Point(29, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 41);
            this.panel1.TabIndex = 35;
            // 
            // rbNotifySoundOff
            // 
            this.rbNotifySoundOff.AutoSize = true;
            this.rbNotifySoundOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbNotifySoundOff.ForeColor = System.Drawing.Color.White;
            this.rbNotifySoundOff.Location = new System.Drawing.Point(5, 3);
            this.rbNotifySoundOff.Name = "rbNotifySoundOff";
            this.rbNotifySoundOff.Size = new System.Drawing.Size(68, 29);
            this.rbNotifySoundOff.TabIndex = 31;
            this.rbNotifySoundOff.TabStop = true;
            this.rbNotifySoundOff.Text = "ايقاف";
            this.rbNotifySoundOff.UseVisualStyleBackColor = true;
            this.rbNotifySoundOff.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbNotifySoundOn
            // 
            this.rbNotifySoundOn.AutoSize = true;
            this.rbNotifySoundOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbNotifySoundOn.ForeColor = System.Drawing.Color.White;
            this.rbNotifySoundOn.Location = new System.Drawing.Point(100, 3);
            this.rbNotifySoundOn.Name = "rbNotifySoundOn";
            this.rbNotifySoundOn.Size = new System.Drawing.Size(72, 29);
            this.rbNotifySoundOn.TabIndex = 30;
            this.rbNotifySoundOn.TabStop = true;
            this.rbNotifySoundOn.Text = "تشغيل";
            this.rbNotifySoundOn.UseVisualStyleBackColor = true;
            this.rbNotifySoundOn.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbNotifyOff);
            this.panel2.Controls.Add(this.rbNotifyOn);
            this.panel2.Location = new System.Drawing.Point(30, 232);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 41);
            this.panel2.TabIndex = 36;
            // 
            // rbNotifyOff
            // 
            this.rbNotifyOff.AutoSize = true;
            this.rbNotifyOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbNotifyOff.ForeColor = System.Drawing.Color.White;
            this.rbNotifyOff.Location = new System.Drawing.Point(5, 3);
            this.rbNotifyOff.Name = "rbNotifyOff";
            this.rbNotifyOff.Size = new System.Drawing.Size(68, 29);
            this.rbNotifyOff.TabIndex = 31;
            this.rbNotifyOff.TabStop = true;
            this.rbNotifyOff.Text = "ايقاف";
            this.rbNotifyOff.UseVisualStyleBackColor = true;
            this.rbNotifyOff.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // rbNotifyOn
            // 
            this.rbNotifyOn.AutoSize = true;
            this.rbNotifyOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rbNotifyOn.ForeColor = System.Drawing.Color.White;
            this.rbNotifyOn.Location = new System.Drawing.Point(100, 3);
            this.rbNotifyOn.Name = "rbNotifyOn";
            this.rbNotifyOn.Size = new System.Drawing.Size(72, 29);
            this.rbNotifyOn.TabIndex = 30;
            this.rbNotifyOn.TabStop = true;
            this.rbNotifyOn.Text = "تشغيل";
            this.rbNotifyOn.UseVisualStyleBackColor = true;
            this.rbNotifyOn.CheckedChanged += new System.EventHandler(this.radioButtons_CheckedChanged);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.nudNotificationShowTime);
            this.Controls.Add(this.cbPeriodBetweenNotification);
            this.Controls.Add(this.cbNotificationType);
            this.Controls.Add(this.btnDefaultSettings);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Name = "MainPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(425, 548);
            ((System.ComponentModel.ISupportInitialize)(this.nudNotificationShowTime)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ReaLTaiizor.Controls.LostButton btnDefaultSettings;
        private System.Windows.Forms.ComboBox cbNotificationType;
        private System.Windows.Forms.ComboBox cbPeriodBetweenNotification;
        private System.Windows.Forms.NumericUpDown nudNotificationShowTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timerBalloon;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbNotifyOff;
        private System.Windows.Forms.RadioButton rbNotifyOn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbNotifySoundOff;
        private System.Windows.Forms.RadioButton rbNotifySoundOn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rbStartupOff;
        private System.Windows.Forms.RadioButton rbStartupOn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmShow;
        private System.Windows.Forms.ToolStripMenuItem tsmClose;
    }
}
