namespace PresentationLayer.Users.Controls
{
    partial class ctrlAddEditUserPermissions
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
            this.pnlPermissions = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlAllCheckBoxes = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chbDeletePeople = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chbDeleteUsers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.chbUpdatePeople = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.chbUpdateUsers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbListUsers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbAddNewPeople = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbListPeople = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbAddNewUsers = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbNone = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chbAllPermissions = new Guna.UI2.WinForms.Guna2CheckBox();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlPermissions.SuspendLayout();
            this.pnlAllCheckBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPermissions
            // 
            this.pnlPermissions.BackColor = System.Drawing.Color.White;
            this.pnlPermissions.BorderColor = System.Drawing.Color.Gainsboro;
            this.pnlPermissions.BorderRadius = 20;
            this.pnlPermissions.BorderThickness = 1;
            this.pnlPermissions.Controls.Add(this.pnlAllCheckBoxes);
            this.pnlPermissions.Controls.Add(this.chbNone);
            this.pnlPermissions.Controls.Add(this.chbAllPermissions);
            this.pnlPermissions.Controls.Add(this.guna2Separator1);
            this.pnlPermissions.Controls.Add(this.lblTitle);
            this.pnlPermissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPermissions.Location = new System.Drawing.Point(0, 0);
            this.pnlPermissions.Name = "pnlPermissions";
            this.pnlPermissions.ShadowDecoration.Parent = this.pnlPermissions;
            this.pnlPermissions.Size = new System.Drawing.Size(838, 243);
            this.pnlPermissions.TabIndex = 17;
            // 
            // pnlAllCheckBoxes
            // 
            this.pnlAllCheckBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAllCheckBoxes.Controls.Add(this.label2);
            this.pnlAllCheckBoxes.Controls.Add(this.chbDeletePeople);
            this.pnlAllCheckBoxes.Controls.Add(this.label1);
            this.pnlAllCheckBoxes.Controls.Add(this.chbDeleteUsers);
            this.pnlAllCheckBoxes.Controls.Add(this.guna2Separator2);
            this.pnlAllCheckBoxes.Controls.Add(this.chbUpdatePeople);
            this.pnlAllCheckBoxes.Controls.Add(this.guna2Separator3);
            this.pnlAllCheckBoxes.Controls.Add(this.chbUpdateUsers);
            this.pnlAllCheckBoxes.Controls.Add(this.chbListUsers);
            this.pnlAllCheckBoxes.Controls.Add(this.chbAddNewPeople);
            this.pnlAllCheckBoxes.Controls.Add(this.chbListPeople);
            this.pnlAllCheckBoxes.Controls.Add(this.chbAddNewUsers);
            this.pnlAllCheckBoxes.Location = new System.Drawing.Point(108, 65);
            this.pnlAllCheckBoxes.Name = "pnlAllCheckBoxes";
            this.pnlAllCheckBoxes.ShadowDecoration.Parent = this.pnlAllCheckBoxes;
            this.pnlAllCheckBoxes.Size = new System.Drawing.Size(588, 165);
            this.pnlAllCheckBoxes.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(32, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Users";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbDeletePeople
            // 
            this.chbDeletePeople.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbDeletePeople.AutoSize = true;
            this.chbDeletePeople.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbDeletePeople.CheckedState.BorderRadius = 2;
            this.chbDeletePeople.CheckedState.BorderThickness = 0;
            this.chbDeletePeople.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbDeletePeople.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDeletePeople.Location = new System.Drawing.Point(450, 127);
            this.chbDeletePeople.Name = "chbDeletePeople";
            this.chbDeletePeople.Size = new System.Drawing.Size(115, 22);
            this.chbDeletePeople.TabIndex = 19;
            this.chbDeletePeople.Text = "Delete People";
            this.chbDeletePeople.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbDeletePeople.UncheckedState.BorderRadius = 2;
            this.chbDeletePeople.UncheckedState.BorderThickness = 0;
            this.chbDeletePeople.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbDeletePeople.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(32, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "People";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbDeleteUsers
            // 
            this.chbDeleteUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbDeleteUsers.AutoSize = true;
            this.chbDeleteUsers.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbDeleteUsers.CheckedState.BorderRadius = 2;
            this.chbDeleteUsers.CheckedState.BorderThickness = 0;
            this.chbDeleteUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbDeleteUsers.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbDeleteUsers.Location = new System.Drawing.Point(450, 47);
            this.chbDeleteUsers.Name = "chbDeleteUsers";
            this.chbDeleteUsers.Size = new System.Drawing.Size(110, 22);
            this.chbDeleteUsers.TabIndex = 19;
            this.chbDeleteUsers.Text = "Delete Users";
            this.chbDeleteUsers.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbDeleteUsers.UncheckedState.BorderRadius = 2;
            this.chbDeleteUsers.UncheckedState.BorderThickness = 0;
            this.chbDeleteUsers.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbDeleteUsers.UseVisualStyleBackColor = true;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Separator2.Location = new System.Drawing.Point(36, 36);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(525, 10);
            this.guna2Separator2.TabIndex = 18;
            // 
            // chbUpdatePeople
            // 
            this.chbUpdatePeople.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbUpdatePeople.AutoSize = true;
            this.chbUpdatePeople.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbUpdatePeople.CheckedState.BorderRadius = 2;
            this.chbUpdatePeople.CheckedState.BorderThickness = 0;
            this.chbUpdatePeople.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbUpdatePeople.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUpdatePeople.Location = new System.Drawing.Point(313, 127);
            this.chbUpdatePeople.Name = "chbUpdatePeople";
            this.chbUpdatePeople.Size = new System.Drawing.Size(121, 22);
            this.chbUpdatePeople.TabIndex = 19;
            this.chbUpdatePeople.Text = "Update People";
            this.chbUpdatePeople.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbUpdatePeople.UncheckedState.BorderRadius = 2;
            this.chbUpdatePeople.UncheckedState.BorderThickness = 0;
            this.chbUpdatePeople.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbUpdatePeople.UseVisualStyleBackColor = true;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Separator3.Location = new System.Drawing.Point(35, 116);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(529, 10);
            this.guna2Separator3.TabIndex = 18;
            // 
            // chbUpdateUsers
            // 
            this.chbUpdateUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbUpdateUsers.AutoSize = true;
            this.chbUpdateUsers.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbUpdateUsers.CheckedState.BorderRadius = 2;
            this.chbUpdateUsers.CheckedState.BorderThickness = 0;
            this.chbUpdateUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbUpdateUsers.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbUpdateUsers.Location = new System.Drawing.Point(313, 47);
            this.chbUpdateUsers.Name = "chbUpdateUsers";
            this.chbUpdateUsers.Size = new System.Drawing.Size(116, 22);
            this.chbUpdateUsers.TabIndex = 19;
            this.chbUpdateUsers.Text = "Update Users";
            this.chbUpdateUsers.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbUpdateUsers.UncheckedState.BorderRadius = 2;
            this.chbUpdateUsers.UncheckedState.BorderThickness = 0;
            this.chbUpdateUsers.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbUpdateUsers.UseVisualStyleBackColor = true;
            // 
            // chbListUsers
            // 
            this.chbListUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbListUsers.AutoSize = true;
            this.chbListUsers.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbListUsers.CheckedState.BorderRadius = 2;
            this.chbListUsers.CheckedState.BorderThickness = 0;
            this.chbListUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbListUsers.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbListUsers.Location = new System.Drawing.Point(54, 47);
            this.chbListUsers.Name = "chbListUsers";
            this.chbListUsers.Size = new System.Drawing.Size(90, 22);
            this.chbListUsers.TabIndex = 19;
            this.chbListUsers.Text = "List Users";
            this.chbListUsers.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbListUsers.UncheckedState.BorderRadius = 2;
            this.chbListUsers.UncheckedState.BorderThickness = 0;
            this.chbListUsers.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbListUsers.UseVisualStyleBackColor = true;
            // 
            // chbAddNewPeople
            // 
            this.chbAddNewPeople.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbAddNewPeople.AutoSize = true;
            this.chbAddNewPeople.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAddNewPeople.CheckedState.BorderRadius = 2;
            this.chbAddNewPeople.CheckedState.BorderThickness = 0;
            this.chbAddNewPeople.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAddNewPeople.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAddNewPeople.Location = new System.Drawing.Point(165, 127);
            this.chbAddNewPeople.Name = "chbAddNewPeople";
            this.chbAddNewPeople.Size = new System.Drawing.Size(132, 22);
            this.chbAddNewPeople.TabIndex = 19;
            this.chbAddNewPeople.Text = "Add New People";
            this.chbAddNewPeople.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAddNewPeople.UncheckedState.BorderRadius = 2;
            this.chbAddNewPeople.UncheckedState.BorderThickness = 0;
            this.chbAddNewPeople.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAddNewPeople.UseVisualStyleBackColor = true;
            // 
            // chbListPeople
            // 
            this.chbListPeople.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbListPeople.AutoSize = true;
            this.chbListPeople.Checked = true;
            this.chbListPeople.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbListPeople.CheckedState.BorderRadius = 2;
            this.chbListPeople.CheckedState.BorderThickness = 0;
            this.chbListPeople.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbListPeople.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbListPeople.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbListPeople.Location = new System.Drawing.Point(54, 127);
            this.chbListPeople.Name = "chbListPeople";
            this.chbListPeople.Size = new System.Drawing.Size(95, 22);
            this.chbListPeople.TabIndex = 19;
            this.chbListPeople.Text = "List People";
            this.chbListPeople.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbListPeople.UncheckedState.BorderRadius = 2;
            this.chbListPeople.UncheckedState.BorderThickness = 0;
            this.chbListPeople.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbListPeople.UseVisualStyleBackColor = true;
            // 
            // chbAddNewUsers
            // 
            this.chbAddNewUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbAddNewUsers.AutoSize = true;
            this.chbAddNewUsers.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAddNewUsers.CheckedState.BorderRadius = 2;
            this.chbAddNewUsers.CheckedState.BorderThickness = 0;
            this.chbAddNewUsers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAddNewUsers.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAddNewUsers.Location = new System.Drawing.Point(165, 47);
            this.chbAddNewUsers.Name = "chbAddNewUsers";
            this.chbAddNewUsers.Size = new System.Drawing.Size(127, 22);
            this.chbAddNewUsers.TabIndex = 19;
            this.chbAddNewUsers.Text = "Add New Users";
            this.chbAddNewUsers.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAddNewUsers.UncheckedState.BorderRadius = 2;
            this.chbAddNewUsers.UncheckedState.BorderThickness = 0;
            this.chbAddNewUsers.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAddNewUsers.UseVisualStyleBackColor = true;
            // 
            // chbNone
            // 
            this.chbNone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbNone.AutoSize = true;
            this.chbNone.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbNone.CheckedState.BorderRadius = 2;
            this.chbNone.CheckedState.BorderThickness = 0;
            this.chbNone.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbNone.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNone.Location = new System.Drawing.Point(558, 37);
            this.chbNone.Name = "chbNone";
            this.chbNone.Size = new System.Drawing.Size(61, 22);
            this.chbNone.TabIndex = 19;
            this.chbNone.Text = "None";
            this.chbNone.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbNone.UncheckedState.BorderRadius = 2;
            this.chbNone.UncheckedState.BorderThickness = 0;
            this.chbNone.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbNone.UseVisualStyleBackColor = true;
            this.chbNone.CheckedChanged += new System.EventHandler(this.chbNone_CheckedChanged);
            // 
            // chbAllPermissions
            // 
            this.chbAllPermissions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chbAllPermissions.AutoSize = true;
            this.chbAllPermissions.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAllPermissions.CheckedState.BorderRadius = 2;
            this.chbAllPermissions.CheckedState.BorderThickness = 0;
            this.chbAllPermissions.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.chbAllPermissions.Font = new System.Drawing.Font("Tahoma", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbAllPermissions.Location = new System.Drawing.Point(421, 37);
            this.chbAllPermissions.Name = "chbAllPermissions";
            this.chbAllPermissions.Size = new System.Drawing.Size(120, 22);
            this.chbAllPermissions.TabIndex = 19;
            this.chbAllPermissions.Text = "All Permissions";
            this.chbAllPermissions.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAllPermissions.UncheckedState.BorderRadius = 2;
            this.chbAllPermissions.UncheckedState.BorderThickness = 0;
            this.chbAllPermissions.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chbAllPermissions.UseVisualStyleBackColor = true;
            this.chbAllPermissions.CheckedChanged += new System.EventHandler(this.chbAllPermissions_CheckedChanged);
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(412, 60);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(207, 10);
            this.guna2Separator1.TabIndex = 18;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitle.Location = new System.Drawing.Point(20, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Permissions";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlAddEditUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlPermissions);
            this.Name = "ctrlAddEditUserPermissions";
            this.Size = new System.Drawing.Size(838, 243);
            this.pnlPermissions.ResumeLayout(false);
            this.pnlPermissions.PerformLayout();
            this.pnlAllCheckBoxes.ResumeLayout(false);
            this.pnlAllCheckBoxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlPermissions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2CheckBox chbNone;
        private Guna.UI2.WinForms.Guna2CheckBox chbAllPermissions;
        private Guna.UI2.WinForms.Guna2CheckBox chbDeleteUsers;
        private Guna.UI2.WinForms.Guna2CheckBox chbUpdateUsers;
        private Guna.UI2.WinForms.Guna2CheckBox chbAddNewUsers;
        private Guna.UI2.WinForms.Guna2CheckBox chbListUsers;
        private Guna.UI2.WinForms.Guna2CheckBox chbDeletePeople;
        private Guna.UI2.WinForms.Guna2CheckBox chbUpdatePeople;
        private Guna.UI2.WinForms.Guna2CheckBox chbAddNewPeople;
        private Guna.UI2.WinForms.Guna2CheckBox chbListPeople;
        private Guna.UI2.WinForms.Guna2Panel pnlAllCheckBoxes;
    }
}
