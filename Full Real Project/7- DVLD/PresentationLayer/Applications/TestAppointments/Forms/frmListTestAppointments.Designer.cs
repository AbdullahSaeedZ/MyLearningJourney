namespace PresentationLayer.Applications.TestAppointments.Forms
{
    partial class frmListTestAppointments
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ControlBoxClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlLocalApplicationInfo1 = new PresentationLayer.Applications.ManageLocalApplications.Controls.ctrlLocalApplicationInfo();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvDrivers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNewAppointment = new Guna.UI2.WinForms.Guna2Button();
            this.DriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.guna2Panel3);
            this.guna2ShadowPanel1.Controls.Add(this.lblTitle);
            this.guna2ShadowPanel1.Controls.Add(this.ctrlLocalApplicationInfo1);
            this.guna2ShadowPanel1.Controls.Add(this.btnClose);
            this.guna2ShadowPanel1.Controls.Add(this.ControlBoxClose);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 240;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(928, 975);
            this.guna2ShadowPanel1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.BorderRadius = 10;
            this.btnClose.BorderThickness = 1;
            this.btnClose.CheckedState.Parent = this.btnClose;
            this.btnClose.CustomImages.Parent = this.btnClose;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnClose.HoverState.Parent = this.btnClose;
            this.btnClose.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Location = new System.Drawing.Point(784, 919);
            this.btnClose.Name = "btnClose";
            this.btnClose.ShadowDecoration.Parent = this.btnClose;
            this.btnClose.Size = new System.Drawing.Size(119, 37);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            // 
            // ControlBoxClose
            // 
            this.ControlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBoxClose.BackColor = System.Drawing.Color.Transparent;
            this.ControlBoxClose.FillColor = System.Drawing.Color.Transparent;
            this.ControlBoxClose.HoverState.Parent = this.ControlBoxClose;
            this.ControlBoxClose.IconColor = System.Drawing.Color.Gray;
            this.ControlBoxClose.Location = new System.Drawing.Point(868, 12);
            this.ControlBoxClose.Name = "ControlBoxClose";
            this.ControlBoxClose.ShadowDecoration.Parent = this.ControlBoxClose;
            this.ControlBoxClose.Size = new System.Drawing.Size(45, 29);
            this.ControlBoxClose.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18.33962F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Location = new System.Drawing.Point(283, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 33);
            this.lblTitle.TabIndex = 12;
            this.lblTitle.Text = "Test Appointments";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlLocalApplicationInfo1
            // 
            this.ctrlLocalApplicationInfo1.BackColor = System.Drawing.Color.White;
            this.ctrlLocalApplicationInfo1.BasicApplicationBorderColor = System.Drawing.Color.Gainsboro;
            this.ctrlLocalApplicationInfo1.BasicApplicationBorderThickness = 1;
            this.ctrlLocalApplicationInfo1.DrivingLicenseApplicationBorderColor = System.Drawing.Color.Gainsboro;
            this.ctrlLocalApplicationInfo1.DrivingLicenseApplicationBorderThickness = 1;
            this.ctrlLocalApplicationInfo1.Location = new System.Drawing.Point(13, 71);
            this.ctrlLocalApplicationInfo1.Name = "ctrlLocalApplicationInfo1";
            this.ctrlLocalApplicationInfo1.Size = new System.Drawing.Size(901, 487);
            this.ctrlLocalApplicationInfo1.TabIndex = 11;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel3.BorderRadius = 15;
            this.guna2Panel3.BorderThickness = 1;
            this.guna2Panel3.Controls.Add(this.btnNewAppointment);
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Controls.Add(this.dgvDrivers);
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(13, 564);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            this.guna2Panel3.Size = new System.Drawing.Size(901, 349);
            this.guna2Panel3.TabIndex = 13;
            // 
            // dgvDrivers
            // 
            this.dgvDrivers.AllowUserToAddRows = false;
            this.dgvDrivers.AllowUserToDeleteRows = false;
            this.dgvDrivers.AllowUserToOrderColumns = true;
            this.dgvDrivers.AllowUserToResizeColumns = false;
            this.dgvDrivers.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvDrivers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDrivers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDrivers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDrivers.BackgroundColor = System.Drawing.Color.White;
            this.dgvDrivers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDrivers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDrivers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrivers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDrivers.ColumnHeadersHeight = 40;
            this.dgvDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DriverID,
            this.ApplointmentDate,
            this.PaidFees,
            this.IsLocked});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDrivers.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDrivers.EnableHeadersVisualStyles = false;
            this.dgvDrivers.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDrivers.Location = new System.Drawing.Point(95, 95);
            this.dgvDrivers.Name = "dgvDrivers";
            this.dgvDrivers.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDrivers.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDrivers.RowHeadersVisible = false;
            this.dgvDrivers.RowHeadersWidth = 45;
            this.dgvDrivers.RowTemplate.DividerHeight = 1;
            this.dgvDrivers.RowTemplate.Height = 50;
            this.dgvDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrivers.Size = new System.Drawing.Size(724, 227);
            this.dgvDrivers.TabIndex = 0;
            this.dgvDrivers.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvDrivers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDrivers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvDrivers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvDrivers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvDrivers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvDrivers.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvDrivers.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDrivers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvDrivers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvDrivers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDrivers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvDrivers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDrivers.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvDrivers.ThemeStyle.ReadOnly = true;
            this.dgvDrivers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvDrivers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDrivers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvDrivers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvDrivers.ThemeStyle.RowsStyle.Height = 50;
            this.dgvDrivers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.DarkGray;
            this.dgvDrivers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Appointments";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnNewAppointment
            // 
            this.btnNewAppointment.BackColor = System.Drawing.Color.Transparent;
            this.btnNewAppointment.BorderColor = System.Drawing.Color.DimGray;
            this.btnNewAppointment.BorderRadius = 10;
            this.btnNewAppointment.CheckedState.Parent = this.btnNewAppointment;
            this.btnNewAppointment.CustomImages.Parent = this.btnNewAppointment;
            this.btnNewAppointment.FillColor = System.Drawing.Color.Transparent;
            this.btnNewAppointment.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnNewAppointment.ForeColor = System.Drawing.Color.Black;
            this.btnNewAppointment.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewAppointment.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnNewAppointment.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnNewAppointment.HoverState.Image = global::PresentationLayer.Properties.Resources.addFill;
            this.btnNewAppointment.HoverState.Parent = this.btnNewAppointment;
            this.btnNewAppointment.Image = global::PresentationLayer.Properties.Resources.addNoFill;
            this.btnNewAppointment.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNewAppointment.Location = new System.Drawing.Point(627, 52);
            this.btnNewAppointment.Name = "btnNewAppointment";
            this.btnNewAppointment.PressedColor = System.Drawing.Color.DimGray;
            this.btnNewAppointment.ShadowDecoration.Parent = this.btnNewAppointment;
            this.btnNewAppointment.Size = new System.Drawing.Size(192, 37);
            this.btnNewAppointment.TabIndex = 8;
            this.btnNewAppointment.Text = "New Appointment";
            this.btnNewAppointment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // DriverID
            // 
            this.DriverID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DriverID.DataPropertyName = "TestAppointmentID";
            this.DriverID.HeaderText = "Appointment ID";
            this.DriverID.MinimumWidth = 6;
            this.DriverID.Name = "DriverID";
            this.DriverID.ReadOnly = true;
            this.DriverID.Width = 200;
            // 
            // ApplointmentDate
            // 
            this.ApplointmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApplointmentDate.DataPropertyName = "ApplointmentDate";
            this.ApplointmentDate.HeaderText = "Applointment Date";
            this.ApplointmentDate.MinimumWidth = 6;
            this.ApplointmentDate.Name = "ApplointmentDate";
            this.ApplointmentDate.ReadOnly = true;
            this.ApplointmentDate.Width = 260;
            // 
            // PaidFees
            // 
            this.PaidFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PaidFees.DataPropertyName = "PaidFees";
            this.PaidFees.HeaderText = "Paid Fees";
            this.PaidFees.MinimumWidth = 6;
            this.PaidFees.Name = "PaidFees";
            this.PaidFees.ReadOnly = true;
            this.PaidFees.Width = 130;
            // 
            // IsLocked
            // 
            this.IsLocked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsLocked.DataPropertyName = "IsLocked";
            this.IsLocked.HeaderText = "Is Locked";
            this.IsLocked.MinimumWidth = 6;
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.Width = 130;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 975);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListTestAppointments";
            this.Text = "frmListTestAppointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private ManageLocalApplications.Controls.ctrlLocalApplicationInfo ctrlLocalApplicationInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2ControlBox ControlBoxClose;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDrivers;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnNewAppointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidFees;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
    }
}