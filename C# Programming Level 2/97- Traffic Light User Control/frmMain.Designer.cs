namespace _97__Traffic_Light_User_Control
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.LightsTimer = new System.Windows.Forms.Timer(this.components);
            this.CarTimer = new System.Windows.Forms.Timer(this.components);
            this.pbCarDown = new System.Windows.Forms.PictureBox();
            this.ctrlTrafficLight4 = new _97__Traffic_Light_User_Control.ctrlTrafficLight();
            this.ctrlTrafficLight3 = new _97__Traffic_Light_User_Control.ctrlTrafficLight();
            this.ctrlTrafficLight2 = new _97__Traffic_Light_User_Control.ctrlTrafficLight();
            this.ctrlTrafficLight1 = new _97__Traffic_Light_User_Control.ctrlTrafficLight();
            this.pbCarRight = new System.Windows.Forms.PictureBox();
            this.pbCarUp = new System.Windows.Forms.PictureBox();
            this.pbCarLeft = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // LightsTimer
            // 
            this.LightsTimer.Interval = 900;
            this.LightsTimer.Tick += new System.EventHandler(this.LightsTimer_Tick);
            // 
            // CarTimer
            // 
            this.CarTimer.Interval = 900;
            this.CarTimer.Tick += new System.EventHandler(this.CarTimer_Tick);
            // 
            // pbCarDown
            // 
            this.pbCarDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCarDown.BackColor = System.Drawing.Color.Transparent;
            this.pbCarDown.BackgroundImage = global::_97__Traffic_Light_User_Control.Properties.Resources.carDown;
            this.pbCarDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarDown.Location = new System.Drawing.Point(512, 1);
            this.pbCarDown.Name = "pbCarDown";
            this.pbCarDown.Size = new System.Drawing.Size(96, 79);
            this.pbCarDown.TabIndex = 1;
            this.pbCarDown.TabStop = false;
            // 
            // ctrlTrafficLight4
            // 
            this.ctrlTrafficLight4.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTrafficLight4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlTrafficLight4.BackgroundImage")));
            this.ctrlTrafficLight4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlTrafficLight4.GreenCountdown = 10;
            this.ctrlTrafficLight4.Location = new System.Drawing.Point(742, 12);
            this.ctrlTrafficLight4.Name = "ctrlTrafficLight4";
            this.ctrlTrafficLight4.OrangeCountdown = 3;
            this.ctrlTrafficLight4.RedCountdown = 39;
            this.ctrlTrafficLight4.Size = new System.Drawing.Size(193, 344);
            this.ctrlTrafficLight4.TabIndex = 0;
            // 
            // ctrlTrafficLight3
            // 
            this.ctrlTrafficLight3.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTrafficLight3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlTrafficLight3.BackgroundImage")));
            this.ctrlTrafficLight3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlTrafficLight3.GreenCountdown = 10;
            this.ctrlTrafficLight3.Location = new System.Drawing.Point(742, 575);
            this.ctrlTrafficLight3.Name = "ctrlTrafficLight3";
            this.ctrlTrafficLight3.OrangeCountdown = 3;
            this.ctrlTrafficLight3.RedCountdown = 39;
            this.ctrlTrafficLight3.Size = new System.Drawing.Size(193, 344);
            this.ctrlTrafficLight3.TabIndex = 0;
            // 
            // ctrlTrafficLight2
            // 
            this.ctrlTrafficLight2.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTrafficLight2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlTrafficLight2.BackgroundImage")));
            this.ctrlTrafficLight2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlTrafficLight2.GreenCountdown = 10;
            this.ctrlTrafficLight2.Location = new System.Drawing.Point(304, 575);
            this.ctrlTrafficLight2.Name = "ctrlTrafficLight2";
            this.ctrlTrafficLight2.OrangeCountdown = 3;
            this.ctrlTrafficLight2.RedCountdown = 39;
            this.ctrlTrafficLight2.Size = new System.Drawing.Size(193, 344);
            this.ctrlTrafficLight2.TabIndex = 0;
            // 
            // ctrlTrafficLight1
            // 
            this.ctrlTrafficLight1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTrafficLight1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ctrlTrafficLight1.BackgroundImage")));
            this.ctrlTrafficLight1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ctrlTrafficLight1.GreenCountdown = 10;
            this.ctrlTrafficLight1.Location = new System.Drawing.Point(304, 12);
            this.ctrlTrafficLight1.Name = "ctrlTrafficLight1";
            this.ctrlTrafficLight1.OrangeCountdown = 3;
            this.ctrlTrafficLight1.RedCountdown = 39;
            this.ctrlTrafficLight1.Size = new System.Drawing.Size(193, 344);
            this.ctrlTrafficLight1.TabIndex = 0;
            // 
            // pbCarRight
            // 
            this.pbCarRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCarRight.BackColor = System.Drawing.Color.Transparent;
            this.pbCarRight.BackgroundImage = global::_97__Traffic_Light_User_Control.Properties.Resources.carRight;
            this.pbCarRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarRight.Location = new System.Drawing.Point(2, 465);
            this.pbCarRight.Name = "pbCarRight";
            this.pbCarRight.Size = new System.Drawing.Size(96, 79);
            this.pbCarRight.TabIndex = 1;
            this.pbCarRight.TabStop = false;
            this.pbCarRight.Visible = false;
            // 
            // pbCarUp
            // 
            this.pbCarUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCarUp.BackColor = System.Drawing.Color.Transparent;
            this.pbCarUp.BackgroundImage = global::_97__Traffic_Light_User_Control.Properties.Resources.car;
            this.pbCarUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarUp.Location = new System.Drawing.Point(621, 840);
            this.pbCarUp.Name = "pbCarUp";
            this.pbCarUp.Size = new System.Drawing.Size(96, 79);
            this.pbCarUp.TabIndex = 1;
            this.pbCarUp.TabStop = false;
            this.pbCarUp.Visible = false;
            // 
            // pbCarLeft
            // 
            this.pbCarLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCarLeft.BackColor = System.Drawing.Color.Transparent;
            this.pbCarLeft.BackgroundImage = global::_97__Traffic_Light_User_Control.Properties.Resources.carLeft;
            this.pbCarLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCarLeft.Location = new System.Drawing.Point(1126, 370);
            this.pbCarLeft.Name = "pbCarLeft";
            this.pbCarLeft.Size = new System.Drawing.Size(96, 79);
            this.pbCarLeft.TabIndex = 1;
            this.pbCarLeft.TabStop = false;
            this.pbCarLeft.Visible = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1224, 922);
            this.Controls.Add(this.pbCarLeft);
            this.Controls.Add(this.pbCarUp);
            this.Controls.Add(this.pbCarRight);
            this.Controls.Add(this.pbCarDown);
            this.Controls.Add(this.ctrlTrafficLight4);
            this.Controls.Add(this.ctrlTrafficLight3);
            this.Controls.Add(this.ctrlTrafficLight2);
            this.Controls.Add(this.ctrlTrafficLight1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic Lights";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCarDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCarLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlTrafficLight ctrlTrafficLight1;
        private ctrlTrafficLight ctrlTrafficLight2;
        private ctrlTrafficLight ctrlTrafficLight3;
        private ctrlTrafficLight ctrlTrafficLight4;
        private System.Windows.Forms.Timer LightsTimer;
        private System.Windows.Forms.Timer CarTimer;
        private System.Windows.Forms.PictureBox pbCarDown;
        private System.Windows.Forms.PictureBox pbCarRight;
        private System.Windows.Forms.PictureBox pbCarUp;
        private System.Windows.Forms.PictureBox pbCarLeft;
    }
}

