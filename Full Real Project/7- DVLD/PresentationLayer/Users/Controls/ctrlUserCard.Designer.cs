namespace PresentationLayer.Users.Controls
{
    partial class ctrlUserCard
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
            this.ctrlPersonCard1 = new PresentationLayer.PeopleFormsAndControls.ctrlPersonCard();
            this.pnlPersonCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLoginInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserID = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.pnlPersonCard.SuspendLayout();
            this.pnlLoginInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.BackColor = System.Drawing.Color.White;
            this.ctrlPersonCard1.BorderColor = System.Drawing.Color.Empty;
            this.ctrlPersonCard1.BorderThickness = 0;
            this.ctrlPersonCard1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(844, 337);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // pnlPersonCard
            // 
            this.pnlPersonCard.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPersonCard.BorderRadius = 20;
            this.pnlPersonCard.BorderThickness = 1;
            this.pnlPersonCard.Controls.Add(this.ctrlPersonCard1);
            this.pnlPersonCard.Location = new System.Drawing.Point(3, 3);
            this.pnlPersonCard.Name = "pnlPersonCard";
            this.pnlPersonCard.ShadowDecoration.Parent = this.pnlPersonCard;
            this.pnlPersonCard.Size = new System.Drawing.Size(851, 343);
            this.pnlPersonCard.TabIndex = 1;
            // 
            // pnlLoginInfo
            // 
            this.pnlLoginInfo.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlLoginInfo.BorderRadius = 20;
            this.pnlLoginInfo.BorderThickness = 1;
            this.pnlLoginInfo.Controls.Add(this.label4);
            this.pnlLoginInfo.Controls.Add(this.label3);
            this.pnlLoginInfo.Controls.Add(this.lblIsActive);
            this.pnlLoginInfo.Controls.Add(this.lblUsername);
            this.pnlLoginInfo.Controls.Add(this.lblUserID);
            this.pnlLoginInfo.Controls.Add(this.label2);
            this.pnlLoginInfo.Controls.Add(this.label1);
            this.pnlLoginInfo.Location = new System.Drawing.Point(3, 352);
            this.pnlLoginInfo.Name = "pnlLoginInfo";
            this.pnlLoginInfo.ShadowDecoration.Parent = this.pnlLoginInfo;
            this.pnlLoginInfo.Size = new System.Drawing.Size(851, 94);
            this.pnlLoginInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(52, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "User ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(286, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(585, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Is Active:";
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.DimGray;
            this.lblUserID.Location = new System.Drawing.Point(137, 48);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(27, 18);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "NA";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsername.Location = new System.Drawing.Point(392, 48);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(27, 18);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "NA";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.ForeColor = System.Drawing.Color.DimGray;
            this.lblIsActive.Location = new System.Drawing.Point(684, 48);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(27, 18);
            this.lblIsActive.TabIndex = 0;
            this.lblIsActive.Text = "NA";
            // 
            // ctrlUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlLoginInfo);
            this.Controls.Add(this.pnlPersonCard);
            this.Name = "ctrlUserCard";
            this.Size = new System.Drawing.Size(857, 449);
            this.pnlPersonCard.ResumeLayout(false);
            this.pnlLoginInfo.ResumeLayout(false);
            this.pnlLoginInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PeopleFormsAndControls.ctrlPersonCard ctrlPersonCard1;
        private Guna.UI2.WinForms.Guna2Panel pnlPersonCard;
        private Guna.UI2.WinForms.Guna2Panel pnlLoginInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
