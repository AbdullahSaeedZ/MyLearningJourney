namespace _71___TrackBar
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblR = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblB = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.lblG = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.lblForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(55, 544);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(485, 56);
            this.trackBar1.SmallChange = 5;
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "smallChange controlls movemnet by pressing right-left arrows";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "largeChange controlls movemnet by pressing up-down arrows";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(85, 525);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(24, 16);
            this.lblR.TabIndex = 2;
            this.lblR.Text = "r: 0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(88, 171);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 320);
            this.panel1.TabIndex = 6;
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(85, 587);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(28, 16);
            this.lblB.TabIndex = 8;
            this.lblB.Text = "b: 0";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 20;
            this.trackBar2.Location = new System.Drawing.Point(55, 606);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(485, 56);
            this.trackBar2.SmallChange = 5;
            this.trackBar2.TabIndex = 7;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // lblG
            // 
            this.lblG.AutoSize = true;
            this.lblG.Location = new System.Drawing.Point(85, 649);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(28, 16);
            this.lblG.TabIndex = 10;
            this.lblG.Text = "g: 0";
            // 
            // trackBar3
            // 
            this.trackBar3.LargeChange = 20;
            this.trackBar3.Location = new System.Drawing.Point(55, 668);
            this.trackBar3.Maximum = 255;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(485, 56);
            this.trackBar3.SmallChange = 5;
            this.trackBar3.TabIndex = 9;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar4
            // 
            this.trackBar4.LargeChange = 20;
            this.trackBar4.Location = new System.Drawing.Point(650, 343);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Minimum = 20;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(485, 56);
            this.trackBar4.SmallChange = 5;
            this.trackBar4.TabIndex = 11;
            this.trackBar4.Value = 20;
            this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(805, 281);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(88, 16);
            this.lblForm.TabIndex = 12;
            this.lblForm.Text = "Form opacity:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(1273, 836);
            this.Controls.Add(this.lblForm);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.lblG);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label lblForm;
    }
}

