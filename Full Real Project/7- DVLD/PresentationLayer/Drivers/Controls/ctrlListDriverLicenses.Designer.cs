namespace PresentationLayer.Drivers.Controls
{
    partial class ctrlListDriverLicenses
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlOuterBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.pnlTabBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlDGVBorder = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvLocalLicenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLicenseTypeTitle = new System.Windows.Forms.Label();
            this.TestAppointmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnShowLocalLicenses = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowInternationalLicenses = new Guna.UI2.WinForms.Guna2Button();
            this.dgvInternationalLicenses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblNoLicensesIssued = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlOuterBorder.SuspendLayout();
            this.pnlTabBorder.SuspendLayout();
            this.pnlDGVBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOuterBorder
            // 
            this.pnlOuterBorder.BackColor = System.Drawing.Color.White;
            this.pnlOuterBorder.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlOuterBorder.BorderRadius = 15;
            this.pnlOuterBorder.BorderThickness = 1;
            this.pnlOuterBorder.Controls.Add(this.label2);
            this.pnlOuterBorder.Controls.Add(this.lblNumberOfRecords);
            this.pnlOuterBorder.Controls.Add(this.pnlTabBorder);
            this.pnlOuterBorder.Controls.Add(this.pnlDGVBorder);
            this.pnlOuterBorder.Controls.Add(this.label1);
            this.pnlOuterBorder.FillColor = System.Drawing.Color.White;
            this.pnlOuterBorder.Location = new System.Drawing.Point(3, 3);
            this.pnlOuterBorder.Name = "pnlOuterBorder";
            this.pnlOuterBorder.ShadowDecoration.Parent = this.pnlOuterBorder;
            this.pnlOuterBorder.Size = new System.Drawing.Size(1139, 386);
            this.pnlOuterBorder.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 353);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total Records:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(185, 353);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(22, 23);
            this.lblNumberOfRecords.TabIndex = 9;
            this.lblNumberOfRecords.Text = "0";
            // 
            // pnlTabBorder
            // 
            this.pnlTabBorder.BackColor = System.Drawing.Color.White;
            this.pnlTabBorder.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlTabBorder.BorderRadius = 15;
            this.pnlTabBorder.BorderThickness = 1;
            this.pnlTabBorder.Controls.Add(this.lblLicenseTypeTitle);
            this.pnlTabBorder.Controls.Add(this.btnShowLocalLicenses);
            this.pnlTabBorder.Controls.Add(this.btnShowInternationalLicenses);
            this.pnlTabBorder.FillColor = System.Drawing.Color.White;
            this.pnlTabBorder.Location = new System.Drawing.Point(21, 59);
            this.pnlTabBorder.Name = "pnlTabBorder";
            this.pnlTabBorder.ShadowDecoration.Parent = this.pnlTabBorder;
            this.pnlTabBorder.Size = new System.Drawing.Size(1095, 49);
            this.pnlTabBorder.TabIndex = 14;
            // 
            // pnlDGVBorder
            // 
            this.pnlDGVBorder.BackColor = System.Drawing.Color.White;
            this.pnlDGVBorder.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlDGVBorder.BorderRadius = 15;
            this.pnlDGVBorder.BorderThickness = 1;
            this.pnlDGVBorder.Controls.Add(this.lblNoLicensesIssued);
            this.pnlDGVBorder.Controls.Add(this.dgvInternationalLicenses);
            this.pnlDGVBorder.Controls.Add(this.dgvLocalLicenses);
            this.pnlDGVBorder.FillColor = System.Drawing.Color.White;
            this.pnlDGVBorder.Location = new System.Drawing.Point(21, 119);
            this.pnlDGVBorder.Name = "pnlDGVBorder";
            this.pnlDGVBorder.ShadowDecoration.Parent = this.pnlDGVBorder;
            this.pnlDGVBorder.Size = new System.Drawing.Size(1095, 231);
            this.pnlDGVBorder.TabIndex = 14;
            // 
            // dgvLocalLicenses
            // 
            this.dgvLocalLicenses.AllowUserToAddRows = false;
            this.dgvLocalLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalLicenses.AllowUserToResizeColumns = false;
            this.dgvLocalLicenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLocalLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLocalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLocalLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLocalLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLocalLicenses.ColumnHeadersHeight = 40;
            this.dgvLocalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLocalLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestAppointmentID,
            this.AppointmentDate,
            this.PaidFees,
            this.Column1,
            this.Column2,
            this.IsLocked});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLocalLicenses.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLocalLicenses.EnableHeadersVisualStyles = false;
            this.dgvLocalLicenses.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocalLicenses.Location = new System.Drawing.Point(7, 9);
            this.dgvLocalLicenses.Name = "dgvLocalLicenses";
            this.dgvLocalLicenses.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLocalLicenses.RowHeadersVisible = false;
            this.dgvLocalLicenses.RowHeadersWidth = 45;
            this.dgvLocalLicenses.RowTemplate.DividerHeight = 1;
            this.dgvLocalLicenses.RowTemplate.Height = 50;
            this.dgvLocalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicenses.Size = new System.Drawing.Size(1085, 214);
            this.dgvLocalLicenses.TabIndex = 0;
            this.dgvLocalLicenses.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvLocalLicenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLocalLicenses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLocalLicenses.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLocalLicenses.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvLocalLicenses.ThemeStyle.ReadOnly = true;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.Height = 50;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.DarkGray;
            this.dgvLocalLicenses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Driver Licenses";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLicenseTypeTitle
            // 
            this.lblLicenseTypeTitle.AutoSize = true;
            this.lblLicenseTypeTitle.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseTypeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseTypeTitle.Location = new System.Drawing.Point(11, 13);
            this.lblLicenseTypeTitle.Name = "lblLicenseTypeTitle";
            this.lblLicenseTypeTitle.Size = new System.Drawing.Size(197, 23);
            this.lblLicenseTypeTitle.TabIndex = 10;
            this.lblLicenseTypeTitle.Text = "Local Licenses History:";
            // 
            // TestAppointmentID
            // 
            this.TestAppointmentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TestAppointmentID.DataPropertyName = "TestAppointmentID";
            this.TestAppointmentID.HeaderText = "Lcl.License ID";
            this.TestAppointmentID.MinimumWidth = 6;
            this.TestAppointmentID.Name = "TestAppointmentID";
            this.TestAppointmentID.ReadOnly = true;
            this.TestAppointmentID.Width = 140;
            // 
            // AppointmentDate
            // 
            this.AppointmentDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.AppointmentDate.DataPropertyName = "AppointmentDate";
            this.AppointmentDate.HeaderText = "Application ID";
            this.AppointmentDate.MinimumWidth = 6;
            this.AppointmentDate.Name = "AppointmentDate";
            this.AppointmentDate.ReadOnly = true;
            this.AppointmentDate.Width = 140;
            // 
            // PaidFees
            // 
            this.PaidFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PaidFees.DataPropertyName = "PaidFees";
            this.PaidFees.HeaderText = "Class Name";
            this.PaidFees.MinimumWidth = 6;
            this.PaidFees.Name = "PaidFees";
            this.PaidFees.ReadOnly = true;
            this.PaidFees.Width = 330;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Issue Date";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 170;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "Expiration Date";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 170;
            // 
            // IsLocked
            // 
            this.IsLocked.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.IsLocked.DataPropertyName = "IsLocked";
            this.IsLocked.HeaderText = "Is Active";
            this.IsLocked.MinimumWidth = 6;
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.Width = 130;
            // 
            // btnShowLocalLicenses
            // 
            this.btnShowLocalLicenses.BackColor = System.Drawing.Color.Transparent;
            this.btnShowLocalLicenses.BorderColor = System.Drawing.Color.DimGray;
            this.btnShowLocalLicenses.BorderRadius = 10;
            this.btnShowLocalLicenses.CheckedState.Parent = this.btnShowLocalLicenses;
            this.btnShowLocalLicenses.CustomImages.Parent = this.btnShowLocalLicenses;
            this.btnShowLocalLicenses.FillColor = System.Drawing.Color.Transparent;
            this.btnShowLocalLicenses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnShowLocalLicenses.ForeColor = System.Drawing.Color.Black;
            this.btnShowLocalLicenses.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowLocalLicenses.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowLocalLicenses.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnShowLocalLicenses.HoverState.Image = global::PresentationLayer.Properties.Resources.localLicensesFill24;
            this.btnShowLocalLicenses.HoverState.Parent = this.btnShowLocalLicenses;
            this.btnShowLocalLicenses.Image = global::PresentationLayer.Properties.Resources.localLicensesNoFill24;
            this.btnShowLocalLicenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowLocalLicenses.Location = new System.Drawing.Point(870, 7);
            this.btnShowLocalLicenses.Name = "btnShowLocalLicenses";
            this.btnShowLocalLicenses.PressedColor = System.Drawing.Color.DimGray;
            this.btnShowLocalLicenses.ShadowDecoration.Parent = this.btnShowLocalLicenses;
            this.btnShowLocalLicenses.Size = new System.Drawing.Size(211, 35);
            this.btnShowLocalLicenses.TabIndex = 8;
            this.btnShowLocalLicenses.Text = "Show Local Licenses";
            this.btnShowLocalLicenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowLocalLicenses.Visible = false;
            // 
            // btnShowInternationalLicenses
            // 
            this.btnShowInternationalLicenses.BackColor = System.Drawing.Color.Transparent;
            this.btnShowInternationalLicenses.BorderColor = System.Drawing.Color.DimGray;
            this.btnShowInternationalLicenses.BorderRadius = 10;
            this.btnShowInternationalLicenses.CheckedState.Parent = this.btnShowInternationalLicenses;
            this.btnShowInternationalLicenses.CustomImages.Parent = this.btnShowInternationalLicenses;
            this.btnShowInternationalLicenses.FillColor = System.Drawing.Color.Transparent;
            this.btnShowInternationalLicenses.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnShowInternationalLicenses.ForeColor = System.Drawing.Color.Black;
            this.btnShowInternationalLicenses.HoverState.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowInternationalLicenses.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowInternationalLicenses.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnShowInternationalLicenses.HoverState.Image = global::PresentationLayer.Properties.Resources.internationalLicensesFill24;
            this.btnShowInternationalLicenses.HoverState.Parent = this.btnShowInternationalLicenses;
            this.btnShowInternationalLicenses.Image = global::PresentationLayer.Properties.Resources.internationalLicensesNoFill24;
            this.btnShowInternationalLicenses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShowInternationalLicenses.Location = new System.Drawing.Point(809, 7);
            this.btnShowInternationalLicenses.Name = "btnShowInternationalLicenses";
            this.btnShowInternationalLicenses.PressedColor = System.Drawing.Color.DimGray;
            this.btnShowInternationalLicenses.ShadowDecoration.Parent = this.btnShowInternationalLicenses;
            this.btnShowInternationalLicenses.Size = new System.Drawing.Size(272, 35);
            this.btnShowInternationalLicenses.TabIndex = 8;
            this.btnShowInternationalLicenses.Text = "Show International Licenses";
            this.btnShowInternationalLicenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dgvInternationalLicenses
            // 
            this.dgvInternationalLicenses.AllowUserToAddRows = false;
            this.dgvInternationalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalLicenses.AllowUserToResizeColumns = false;
            this.dgvInternationalLicenses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInternationalLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInternationalLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInternationalLicenses.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInternationalLicenses.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicenses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternationalLicenses.ColumnHeadersHeight = 40;
            this.dgvInternationalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInternationalLicenses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInternationalLicenses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvInternationalLicenses.EnableHeadersVisualStyles = false;
            this.dgvInternationalLicenses.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInternationalLicenses.Location = new System.Drawing.Point(7, 9);
            this.dgvInternationalLicenses.Name = "dgvInternationalLicenses";
            this.dgvInternationalLicenses.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternationalLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInternationalLicenses.RowHeadersVisible = false;
            this.dgvInternationalLicenses.RowHeadersWidth = 45;
            this.dgvInternationalLicenses.RowTemplate.DividerHeight = 1;
            this.dgvInternationalLicenses.RowTemplate.Height = 50;
            this.dgvInternationalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternationalLicenses.Size = new System.Drawing.Size(1085, 214);
            this.dgvInternationalLicenses.TabIndex = 1;
            this.dgvInternationalLicenses.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvInternationalLicenses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvInternationalLicenses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicenses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvInternationalLicenses.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvInternationalLicenses.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvInternationalLicenses.ThemeStyle.ReadOnly = true;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.Height = 50;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.DarkGray;
            this.dgvInternationalLicenses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvInternationalLicenses.Visible = false;
            // 
            // lblNoLicensesIssued
            // 
            this.lblNoLicensesIssued.AutoSize = true;
            this.lblNoLicensesIssued.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoLicensesIssued.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNoLicensesIssued.Location = new System.Drawing.Point(465, 94);
            this.lblNoLicensesIssued.Name = "lblNoLicensesIssued";
            this.lblNoLicensesIssued.Size = new System.Drawing.Size(214, 23);
            this.lblNoLicensesIssued.TabIndex = 10;
            this.lblNoLicensesIssued.Text = "No Licenses Issued Yet..";
            this.lblNoLicensesIssued.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TestAppointmentID";
            this.dataGridViewTextBoxColumn1.HeaderText = "International License ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 190;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AppointmentDate";
            this.dataGridViewTextBoxColumn2.HeaderText = "Application ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PaidFees";
            this.dataGridViewTextBoxColumn3.HeaderText = "Issued On Local License ID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 250;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.HeaderText = "Expiration Date";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsLocked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Is Active";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ctrlListDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlOuterBorder);
            this.Name = "ctrlListDriverLicenses";
            this.Size = new System.Drawing.Size(1145, 391);
            this.pnlOuterBorder.ResumeLayout(false);
            this.pnlOuterBorder.PerformLayout();
            this.pnlTabBorder.ResumeLayout(false);
            this.pnlTabBorder.PerformLayout();
            this.pnlDGVBorder.ResumeLayout(false);
            this.pnlDGVBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlOuterBorder;
        private Guna.UI2.WinForms.Guna2Panel pnlDGVBorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLocalLicenses;
        private Guna.UI2.WinForms.Guna2Button btnShowInternationalLicenses;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel pnlTabBorder;
        private System.Windows.Forms.Label lblLicenseTypeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestAppointmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
        private Guna.UI2.WinForms.Guna2Button btnShowLocalLicenses;
        private System.Windows.Forms.Label lblNoLicensesIssued;
        private Guna.UI2.WinForms.Guna2DataGridView dgvInternationalLicenses;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
    }
}
