namespace PresentationLayer.Dashboard
{
    partial class ctrlTodayAppointments
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
            this.pnlOuterBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox6 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnlOuterBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOuterBorder
            // 
            this.pnlOuterBorder.BackColor = System.Drawing.Color.White;
            this.pnlOuterBorder.BorderColor = System.Drawing.Color.LightGray;
            this.pnlOuterBorder.BorderRadius = 10;
            this.pnlOuterBorder.BorderThickness = 1;
            this.pnlOuterBorder.Controls.Add(this.guna2PictureBox6);
            this.pnlOuterBorder.Controls.Add(this.lblID);
            this.pnlOuterBorder.Controls.Add(this.lblStatus);
            this.pnlOuterBorder.Controls.Add(this.lblDate);
            this.pnlOuterBorder.FillColor = System.Drawing.Color.White;
            this.pnlOuterBorder.Location = new System.Drawing.Point(2, 1);
            this.pnlOuterBorder.Name = "pnlOuterBorder";
            this.pnlOuterBorder.ShadowDecoration.Parent = this.pnlOuterBorder;
            this.pnlOuterBorder.Size = new System.Drawing.Size(320, 46);
            this.pnlOuterBorder.TabIndex = 4;
            // 
            // guna2PictureBox6
            // 
            this.guna2PictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox6.Image = global::PresentationLayer.Properties.Resources.appointmentNoFill;
            this.guna2PictureBox6.Location = new System.Drawing.Point(15, 11);
            this.guna2PictureBox6.Name = "guna2PictureBox6";
            this.guna2PictureBox6.ShadowDecoration.Parent = this.guna2PictureBox6;
            this.guna2PictureBox6.Size = new System.Drawing.Size(24, 24);
            this.guna2PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox6.TabIndex = 3;
            this.guna2PictureBox6.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.DimGray;
            this.lblID.Location = new System.Drawing.Point(52, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(45, 18);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "ID 23";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStatus.Location = new System.Drawing.Point(246, 17);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 14);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Completed";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 8F);
            this.lblDate.ForeColor = System.Drawing.Color.DarkGray;
            this.lblDate.Location = new System.Drawing.Point(51, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(126, 14);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "monday, june, 2026  ";
            // 
            // ctrlTodayAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlOuterBorder);
            this.Name = "ctrlTodayAppointments";
            this.Size = new System.Drawing.Size(324, 49);
            this.pnlOuterBorder.ResumeLayout(false);
            this.pnlOuterBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlOuterBorder;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox6;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDate;
    }
}
