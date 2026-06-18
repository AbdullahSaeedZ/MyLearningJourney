namespace PresentationLayer.Settings
{
    partial class frmLogHistory
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnCopy = new Guna.UI2.WinForms.Guna2Button();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.tbLogText = new System.Windows.Forms.TextBox();
            this.guna2ShadowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 85;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.HoverState.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1028, 18);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.ShadowDecoration.Parent = this.guna2ControlBox1;
            this.guna2ControlBox1.Size = new System.Drawing.Size(33, 31);
            this.guna2ControlBox1.TabIndex = 1;
            this.guna2ControlBox1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.tbLogText);
            this.guna2ShadowPanel1.Controls.Add(this.lblFormTitle);
            this.guna2ShadowPanel1.Controls.Add(this.btnCopy);
            this.guna2ShadowPanel1.Controls.Add(this.btnClose);
            this.guna2ShadowPanel1.Controls.Add(this.guna2ControlBox1);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 20;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 254;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(1078, 754);
            this.guna2ShadowPanel1.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FillColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(923, 701);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(125, 34);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnCopy.BorderColor = System.Drawing.Color.DimGray;
            this.btnCopy.BorderRadius = 10;
            this.btnCopy.BorderThickness = 1;
            this.btnCopy.CheckedState.Parent = this.btnCopy;
            this.btnCopy.CustomImages.Parent = this.btnCopy;
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopy.FillColor = System.Drawing.Color.White;
            this.btnCopy.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnCopy.ForeColor = System.Drawing.Color.DimGray;
            this.btnCopy.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.btnCopy.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnCopy.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnCopy.HoverState.Parent = this.btnCopy;
            this.btnCopy.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCopy.Location = new System.Drawing.Point(783, 701);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.ShadowDecoration.Parent = this.btnCopy;
            this.btnCopy.Size = new System.Drawing.Size(125, 34);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.Font = new System.Drawing.Font("Tahoma", 14.22642F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblFormTitle.Location = new System.Drawing.Point(437, 26);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(174, 23);
            this.lblFormTitle.TabIndex = 15;
            this.lblFormTitle.Text = "View Log History";
            // 
            // tbLogText
            // 
            this.tbLogText.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tbLogText.HideSelection = false;
            this.tbLogText.Location = new System.Drawing.Point(19, 76);
            this.tbLogText.Multiline = true;
            this.tbLogText.Name = "tbLogText";
            this.tbLogText.ReadOnly = true;
            this.tbLogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogText.Size = new System.Drawing.Size(1040, 609);
            this.tbLogText.TabIndex = 16;
            // 
            // frmLogHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 754);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogHistory";
            this.Load += new System.EventHandler(this.frmLogHistory_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Button btnCopy;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.TextBox tbLogText;
    }
}