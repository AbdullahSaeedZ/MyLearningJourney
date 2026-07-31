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
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbTimeProgress = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnStartStop = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox12 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox10 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblFoodOrders = new System.Windows.Forms.Label();
            this.lblMonyAmount = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).BeginInit();
            this.guna2Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(127, 98);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(86, 27);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "STATUS";
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblTableNumber.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblTableNumber.Location = new System.Drawing.Point(383, 16);
            this.lblTableNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(72, 63);
            this.lblTableNumber.TabIndex = 0;
            this.lblTableNumber.Text = "01";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.guna2PictureBox3);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2Panel2.Location = new System.Drawing.Point(35, 85);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(65, 53);
            this.guna2Panel2.TabIndex = 33;
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox3.Image = global::Billiards_Club_Management_System.Properties.Resources.freeTablesDark512;
            this.guna2PictureBox3.Location = new System.Drawing.Point(12, 9);
            this.guna2PictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(40, 37);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 26;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // pbTimeProgress
            // 
            this.pbTimeProgress.BorderRadius = 5;
            this.pbTimeProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.pbTimeProgress.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pbTimeProgress.Location = new System.Drawing.Point(35, 254);
            this.pbTimeProgress.Margin = new System.Windows.Forms.Padding(4);
            this.pbTimeProgress.Maximum = 60;
            this.pbTimeProgress.Name = "pbTimeProgress";
            this.pbTimeProgress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(178)))), ((int)(((byte)(116)))));
            this.pbTimeProgress.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(100)))), ((int)(((byte)(46)))));
            this.pbTimeProgress.ShadowDecoration.Parent = this.pbTimeProgress;
            this.pbTimeProgress.Size = new System.Drawing.Size(423, 12);
            this.pbTimeProgress.TabIndex = 34;
            this.pbTimeProgress.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.pbTimeProgress.Value = 40;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
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
            this.guna2Panel1.Location = new System.Drawing.Point(4, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(501, 295);
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
            this.btnStartStop.Location = new System.Drawing.Point(35, 28);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.ShadowDecoration.Parent = this.btnStartStop;
            this.btnStartStop.Size = new System.Drawing.Size(143, 43);
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
            this.guna2PictureBox12.Location = new System.Drawing.Point(373, 222);
            this.guna2PictureBox12.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox12.Name = "guna2PictureBox12";
            this.guna2PictureBox12.ShadowDecoration.Parent = this.guna2PictureBox12;
            this.guna2PictureBox12.Size = new System.Drawing.Size(29, 27);
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
            this.guna2Panel4.Location = new System.Drawing.Point(35, 145);
            this.guna2Panel4.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(65, 53);
            this.guna2Panel4.TabIndex = 33;
            // 
            // guna2PictureBox10
            // 
            this.guna2PictureBox10.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(229)))));
            this.guna2PictureBox10.Image = global::Billiards_Club_Management_System.Properties.Resources.foodDarkNoFIll512;
            this.guna2PictureBox10.Location = new System.Drawing.Point(12, 9);
            this.guna2PictureBox10.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox10.Name = "guna2PictureBox10";
            this.guna2PictureBox10.ShadowDecoration.Parent = this.guna2PictureBox10;
            this.guna2PictureBox10.Size = new System.Drawing.Size(40, 37);
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
            this.lblTimer.Location = new System.Drawing.Point(27, 213);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(99, 43);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00";
            // 
            // lblFoodOrders
            // 
            this.lblFoodOrders.AutoSize = true;
            this.lblFoodOrders.BackColor = System.Drawing.Color.Transparent;
            this.lblFoodOrders.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoodOrders.ForeColor = System.Drawing.Color.DimGray;
            this.lblFoodOrders.Location = new System.Drawing.Point(127, 159);
            this.lblFoodOrders.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFoodOrders.Name = "lblFoodOrders";
            this.lblFoodOrders.Size = new System.Drawing.Size(150, 27);
            this.lblFoodOrders.TabIndex = 0;
            this.lblFoodOrders.Text = "FOOD ORDERS";
            // 
            // lblMonyAmount
            // 
            this.lblMonyAmount.AutoSize = true;
            this.lblMonyAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblMonyAmount.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.lblMonyAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.lblMonyAmount.Location = new System.Drawing.Point(400, 213);
            this.lblMonyAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonyAmount.Name = "lblMonyAmount";
            this.lblMonyAmount.Size = new System.Drawing.Size(55, 43);
            this.lblMonyAmount.TabIndex = 0;
            this.lblMonyAmount.Text = "60";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel3.BorderRadius = 13;
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel3.FillColor = System.Drawing.Color.DarkSeaGreen;
            this.guna2Panel3.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(497, 295);
            this.guna2Panel3.TabIndex = 36;
            // 
            // ctrlTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlTable";
            this.Size = new System.Drawing.Size(505, 295);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox12)).EndInit();
            this.guna2Panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTableNumber;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2ProgressBar pbTimeProgress;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblTimer;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblFoodOrders;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox12;
        private System.Windows.Forms.Label lblMonyAmount;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox10;
        private Guna.UI2.WinForms.Guna2Button btnStartStop;
        private System.Windows.Forms.Timer timer1;
    }
}
