namespace _97__Traffic_Light_User_Control
{
    partial class ctrlTrafficLight
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
            this.lblRedTimer = new System.Windows.Forms.Label();
            this.lblGreenTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblRedTimer
            // 
            this.lblRedTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRedTimer.AutoSize = true;
            this.lblRedTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedTimer.ForeColor = System.Drawing.Color.Black;
            this.lblRedTimer.Location = new System.Drawing.Point(73, 68);
            this.lblRedTimer.Name = "lblRedTimer";
            this.lblRedTimer.Size = new System.Drawing.Size(34, 37);
            this.lblRedTimer.TabIndex = 0;
            this.lblRedTimer.Text = "1";
            // 
            // lblGreenTimer
            // 
            this.lblGreenTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGreenTimer.AutoSize = true;
            this.lblGreenTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenTimer.ForeColor = System.Drawing.Color.Black;
            this.lblGreenTimer.Location = new System.Drawing.Point(73, 233);
            this.lblGreenTimer.Name = "lblGreenTimer";
            this.lblGreenTimer.Size = new System.Drawing.Size(34, 37);
            this.lblGreenTimer.TabIndex = 0;
            this.lblGreenTimer.Text = "1";
            // 
            // timer1
            // 
            this.timer1.Interval = 900;
            // 
            // ctrlTrafficLight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::_97__Traffic_Light_User_Control.Properties.Resources.Red;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblGreenTimer);
            this.Controls.Add(this.lblRedTimer);
            this.DoubleBuffered = true;
            this.Name = "ctrlTrafficLight";
            this.Size = new System.Drawing.Size(193, 344);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label lblRedTimer;
        public System.Windows.Forms.Label lblGreenTimer;
    }
}
