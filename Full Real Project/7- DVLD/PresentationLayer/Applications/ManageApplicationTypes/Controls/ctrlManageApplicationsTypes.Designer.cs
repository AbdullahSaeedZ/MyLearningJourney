namespace PresentationLayer.Applications.ManageApplicationTypes.Controls
{
    partial class ctrlManageApplicationsTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMainServicesContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvApplicationTypes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editApplicationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMainServicesContainer.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainServicesContainer
            // 
            this.pnlMainServicesContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainServicesContainer.BorderRadius = 20;
            this.pnlMainServicesContainer.Controls.Add(this.guna2Panel2);
            this.pnlMainServicesContainer.Controls.Add(this.btnBack);
            this.pnlMainServicesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainServicesContainer.FillColor = System.Drawing.Color.White;
            this.pnlMainServicesContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainServicesContainer.Name = "pnlMainServicesContainer";
            this.pnlMainServicesContainer.ShadowDecoration.Parent = this.pnlMainServicesContainer;
            this.pnlMainServicesContainer.Size = new System.Drawing.Size(1441, 894);
            this.pnlMainServicesContainer.TabIndex = 3;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.BorderRadius = 15;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.dgvApplicationTypes);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(257, 75);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(911, 778);
            this.guna2Panel2.TabIndex = 10;
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.AllowUserToAddRows = false;
            this.dgvApplicationTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationTypes.AllowUserToOrderColumns = true;
            this.dgvApplicationTypes.AllowUserToResizeColumns = false;
            this.dgvApplicationTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvApplicationTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplicationTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicationTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApplicationTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvApplicationTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationTypes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvApplicationTypes.ColumnHeadersHeight = 40;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApplicationTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPersonID,
            this.colPhone,
            this.colEmail});
            this.dgvApplicationTypes.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvApplicationTypes.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvApplicationTypes.EnableHeadersVisualStyles = false;
            this.dgvApplicationTypes.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(102, 83);
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvApplicationTypes.RowHeadersVisible = false;
            this.dgvApplicationTypes.RowHeadersWidth = 45;
            this.dgvApplicationTypes.RowTemplate.DividerHeight = 1;
            this.dgvApplicationTypes.RowTemplate.Height = 50;
            this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(702, 674);
            this.dgvApplicationTypes.TabIndex = 7;
            this.dgvApplicationTypes.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvApplicationTypes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvApplicationTypes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvApplicationTypes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvApplicationTypes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvApplicationTypes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvApplicationTypes.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvApplicationTypes.ThemeStyle.ReadOnly = true;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.Height = 50;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.DarkGray;
            this.dgvApplicationTypes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.DoubleClick += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // colPersonID
            // 
            this.colPersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPersonID.DataPropertyName = "ApplicationTypeID";
            this.colPersonID.HeaderText = "ID";
            this.colPersonID.MinimumWidth = 6;
            this.colPersonID.Name = "colPersonID";
            this.colPersonID.ReadOnly = true;
            this.colPersonID.Width = 80;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPhone.DataPropertyName = "ApplicationTypeTitle";
            this.colPhone.HeaderText = "Title";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 500;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEmail.DataPropertyName = "ApplicationFees";
            this.colEmail.HeaderText = "Fees";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editApplicationTypeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 28);
            // 
            // editApplicationTypeToolStripMenuItem
            // 
            this.editApplicationTypeToolStripMenuItem.Image = global::PresentationLayer.Properties.Resources.editNoFill;
            this.editApplicationTypeToolStripMenuItem.Name = "editApplicationTypeToolStripMenuItem";
            this.editApplicationTypeToolStripMenuItem.Size = new System.Drawing.Size(200, 24);
            this.editApplicationTypeToolStripMenuItem.Text = "Edit Application Type";
            this.editApplicationTypeToolStripMenuItem.Click += new System.EventHandler(this.editApplicationTypeToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(98, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Records:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.Black;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(246, 31);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(22, 23);
            this.lblNumberOfRecords.TabIndex = 8;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderColor = System.Drawing.Color.DimGray;
            this.btnBack.BorderRadius = 10;
            this.btnBack.BorderThickness = 1;
            this.btnBack.CheckedState.Parent = this.btnBack;
            this.btnBack.CustomImages.Parent = this.btnBack;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.FillColor = System.Drawing.Color.Transparent;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnBack.ForeColor = System.Drawing.Color.DimGray;
            this.btnBack.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.btnBack.HoverState.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnBack.HoverState.Parent = this.btnBack;
            this.btnBack.Image = global::PresentationLayer.Properties.Resources.BackShortArrow;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Location = new System.Drawing.Point(18, 16);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.Parent = this.btnBack;
            this.btnBack.Size = new System.Drawing.Size(108, 37);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ctrlManageApplicationsTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pnlMainServicesContainer);
            this.Name = "ctrlManageApplicationsTypes";
            this.Size = new System.Drawing.Size(1441, 894);
            this.Load += new System.EventHandler(this.ctrlManageApplicationsTypes_Load);
            this.pnlMainServicesContainer.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMainServicesContainer;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2DataGridView dgvApplicationTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editApplicationTypeToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
    }
}
