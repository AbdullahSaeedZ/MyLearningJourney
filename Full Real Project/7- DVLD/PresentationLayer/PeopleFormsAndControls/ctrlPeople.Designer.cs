namespace PresentationLayer.PeopleFormsAndControls
{
    partial class ctrlPeople
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvPeople = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.lblQuickSearch = new System.Windows.Forms.Label();
            this.tbSearchPerson = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbSearchBy = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.colPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNationalNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThirdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Controls.Add(this.dgvPeople);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 73);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            this.guna2Panel1.Size = new System.Drawing.Size(1441, 821);
            this.guna2Panel1.TabIndex = 0;
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AllowUserToOrderColumns = true;
            this.dgvPeople.AllowUserToResizeColumns = false;
            this.dgvPeople.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvPeople.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPeople.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeople.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPeople.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPeople.ColumnHeadersHeight = 40;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeople.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPic,
            this.colPersonID,
            this.colNationalNo,
            this.colFirstName,
            this.colSecondName,
            this.colThirdName,
            this.colLastName,
            this.colGender,
            this.colBirthDate,
            this.colCountryName,
            this.colPhone,
            this.colEmail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPeople.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPeople.EnableHeadersVisualStyles = false;
            this.dgvPeople.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeople.Location = new System.Drawing.Point(18, 19);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPeople.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPeople.RowHeadersVisible = false;
            this.dgvPeople.RowHeadersWidth = 45;
            this.dgvPeople.RowTemplate.DividerHeight = 5;
            this.dgvPeople.RowTemplate.Height = 50;
            this.dgvPeople.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeople.Size = new System.Drawing.Size(1405, 782);
            this.dgvPeople.TabIndex = 0;
            this.dgvPeople.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvPeople.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeople.ThemeStyle.GridColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPeople.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPeople.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvPeople.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.DimGray;
            this.dgvPeople.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPeople.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvPeople.ThemeStyle.ReadOnly = true;
            this.dgvPeople.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvPeople.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPeople.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgvPeople.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvPeople.ThemeStyle.RowsStyle.Height = 50;
            this.dgvPeople.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.DimGray;
            this.dgvPeople.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.Controls.Add(this.btnAddPerson);
            this.guna2Panel2.Controls.Add(this.lblQuickSearch);
            this.guna2Panel2.Controls.Add(this.tbSearchPerson);
            this.guna2Panel2.Controls.Add(this.cbSearchBy);
            this.guna2Panel2.Controls.Add(this.label3);
            this.guna2Panel2.Controls.Add(this.label2);
            this.guna2Panel2.Controls.Add(this.lblNumberOfRecords);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(1441, 73);
            this.guna2Panel2.TabIndex = 0;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BackColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddPerson.BorderRadius = 10;
            this.btnAddPerson.CheckedState.Parent = this.btnAddPerson;
            this.btnAddPerson.CustomImages.Parent = this.btnAddPerson;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAddPerson.ForeColor = System.Drawing.Color.DimGray;
            this.btnAddPerson.HoverState.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddPerson.HoverState.FillColor = System.Drawing.Color.White;
            this.btnAddPerson.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnAddPerson.HoverState.Image = global::PresentationLayer.Properties.Resources.addFill;
            this.btnAddPerson.HoverState.Parent = this.btnAddPerson;
            this.btnAddPerson.Image = global::PresentationLayer.Properties.Resources.addNoFill;
            this.btnAddPerson.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.Location = new System.Drawing.Point(1286, 31);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.ShadowDecoration.Parent = this.btnAddPerson;
            this.btnAddPerson.Size = new System.Drawing.Size(137, 37);
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // lblQuickSearch
            // 
            this.lblQuickSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuickSearch.BackColor = System.Drawing.Color.White;
            this.lblQuickSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblQuickSearch.Image = global::PresentationLayer.Properties.Resources.QuickSearch;
            this.lblQuickSearch.Location = new System.Drawing.Point(859, 37);
            this.lblQuickSearch.Name = "lblQuickSearch";
            this.lblQuickSearch.Size = new System.Drawing.Size(28, 23);
            this.lblQuickSearch.TabIndex = 6;
            // 
            // tbSearchPerson
            // 
            this.tbSearchPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchPerson.BackColor = System.Drawing.Color.Transparent;
            this.tbSearchPerson.BorderColor = System.Drawing.Color.Silver;
            this.tbSearchPerson.BorderRadius = 10;
            this.tbSearchPerson.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbSearchPerson.DefaultText = "";
            this.tbSearchPerson.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbSearchPerson.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbSearchPerson.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchPerson.DisabledState.Parent = this.tbSearchPerson;
            this.tbSearchPerson.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbSearchPerson.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchPerson.FocusedState.Parent = this.tbSearchPerson;
            this.tbSearchPerson.ForeColor = System.Drawing.Color.Black;
            this.tbSearchPerson.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbSearchPerson.HoverState.Parent = this.tbSearchPerson;
            this.tbSearchPerson.Location = new System.Drawing.Point(673, 31);
            this.tbSearchPerson.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbSearchPerson.Name = "tbSearchPerson";
            this.tbSearchPerson.PasswordChar = '\0';
            this.tbSearchPerson.PlaceholderText = "Search People";
            this.tbSearchPerson.SelectedText = "";
            this.tbSearchPerson.ShadowDecoration.Parent = this.tbSearchPerson;
            this.tbSearchPerson.Size = new System.Drawing.Size(225, 39);
            this.tbSearchPerson.TabIndex = 5;
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.BackColor = System.Drawing.Color.Transparent;
            this.cbSearchBy.BorderColor = System.Drawing.Color.Silver;
            this.cbSearchBy.BorderRadius = 10;
            this.cbSearchBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchBy.FocusedColor = System.Drawing.Color.Empty;
            this.cbSearchBy.FocusedState.Parent = this.cbSearchBy;
            this.cbSearchBy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSearchBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbSearchBy.FormattingEnabled = true;
            this.cbSearchBy.HoverState.Parent = this.cbSearchBy;
            this.cbSearchBy.ItemHeight = 30;
            this.cbSearchBy.ItemsAppearance.Parent = this.cbSearchBy;
            this.cbSearchBy.Location = new System.Drawing.Point(440, 32);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.ShadowDecoration.Parent = this.cbSearchBy;
            this.cbSearchBy.Size = new System.Drawing.Size(225, 36);
            this.cbSearchBy.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(323, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Search By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Records:";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold);
            this.lblNumberOfRecords.ForeColor = System.Drawing.Color.DimGray;
            this.lblNumberOfRecords.Location = new System.Drawing.Point(183, 41);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(22, 23);
            this.lblNumberOfRecords.TabIndex = 0;
            this.lblNumberOfRecords.Text = "0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // colPic
            // 
            this.colPic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPic.DataPropertyName = "Pic";
            this.colPic.HeaderText = "";
            this.colPic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colPic.MinimumWidth = 6;
            this.colPic.Name = "colPic";
            this.colPic.ReadOnly = true;
            this.colPic.Width = 60;
            // 
            // colPersonID
            // 
            this.colPersonID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPersonID.DataPropertyName = "PersonID";
            this.colPersonID.HeaderText = "PersonID";
            this.colPersonID.MinimumWidth = 6;
            this.colPersonID.Name = "colPersonID";
            this.colPersonID.ReadOnly = true;
            this.colPersonID.Width = 80;
            // 
            // colNationalNo
            // 
            this.colNationalNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colNationalNo.DataPropertyName = "NationalNo";
            this.colNationalNo.HeaderText = "NationalNo";
            this.colNationalNo.MinimumWidth = 6;
            this.colNationalNo.Name = "colNationalNo";
            this.colNationalNo.ReadOnly = true;
            // 
            // colFirstName
            // 
            this.colFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colFirstName.DataPropertyName = "FirstName";
            this.colFirstName.HeaderText = "FirstName";
            this.colFirstName.MinimumWidth = 6;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.ReadOnly = true;
            // 
            // colSecondName
            // 
            this.colSecondName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSecondName.DataPropertyName = "SecondName";
            this.colSecondName.HeaderText = "SecondName";
            this.colSecondName.MinimumWidth = 6;
            this.colSecondName.Name = "colSecondName";
            this.colSecondName.ReadOnly = true;
            // 
            // colThirdName
            // 
            this.colThirdName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colThirdName.DataPropertyName = "ThirdName";
            this.colThirdName.HeaderText = "ThirdName";
            this.colThirdName.MinimumWidth = 6;
            this.colThirdName.Name = "colThirdName";
            this.colThirdName.ReadOnly = true;
            // 
            // colLastName
            // 
            this.colLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colLastName.DataPropertyName = "LastName";
            this.colLastName.HeaderText = "LastName";
            this.colLastName.MinimumWidth = 6;
            this.colLastName.Name = "colLastName";
            this.colLastName.ReadOnly = true;
            // 
            // colGender
            // 
            this.colGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colGender.DataPropertyName = "GenderString";
            this.colGender.HeaderText = "Gender";
            this.colGender.MinimumWidth = 6;
            this.colGender.Name = "colGender";
            this.colGender.ReadOnly = true;
            this.colGender.Width = 70;
            // 
            // colBirthDate
            // 
            this.colBirthDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colBirthDate.DataPropertyName = "DateOfBirth";
            this.colBirthDate.HeaderText = "BirthDate";
            this.colBirthDate.MinimumWidth = 6;
            this.colBirthDate.Name = "colBirthDate";
            this.colBirthDate.ReadOnly = true;
            this.colBirthDate.Width = 150;
            // 
            // colCountryName
            // 
            this.colCountryName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colCountryName.DataPropertyName = "CountryName";
            this.colCountryName.HeaderText = "Country";
            this.colCountryName.MinimumWidth = 6;
            this.colCountryName.Name = "colCountryName";
            this.colCountryName.ReadOnly = true;
            this.colCountryName.Width = 120;
            // 
            // colPhone
            // 
            this.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPhone.DataPropertyName = "Phone";
            this.colPhone.HeaderText = "Phone";
            this.colPhone.MinimumWidth = 6;
            this.colPhone.Name = "colPhone";
            this.colPhone.ReadOnly = true;
            this.colPhone.Width = 130;
            // 
            // colEmail
            // 
            this.colEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 150;
            // 
            // ctrlPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "ctrlPeople";
            this.Size = new System.Drawing.Size(1441, 894);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2DataGridView dgvPeople;
        private Guna.UI2.WinForms.Guna2ComboBox cbSearchBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label lblQuickSearch;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchPerson;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewImageColumn colPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNationalNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecondName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThirdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCountryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
    }
}
