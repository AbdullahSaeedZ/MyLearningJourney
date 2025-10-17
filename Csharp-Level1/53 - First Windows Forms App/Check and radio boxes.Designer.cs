namespace _53___First_Windows_Forms_App
{
    partial class NewForm
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
            this.BackBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.btnShowGb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gb1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(1121, 642);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(87, 39);
            this.BackBtn.TabIndex = 0;
            this.BackBtn.Text = "Show Main Form";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(195, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Agree on terms and conditions";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(25, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "button on off with check box";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(334, 45);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 19);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "small size";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(334, 70);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 19);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "mid size";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(334, 95);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(81, 19);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "large size";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 49);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(19, 48);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(53, 19);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "thick";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(19, 22);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(48, 19);
            this.radioButton5.TabIndex = 9;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "thin";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.radioButton5);
            this.gb1.Controls.Add(this.radioButton4);
            this.gb1.Location = new System.Drawing.Point(619, 22);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(344, 117);
            this.gb1.TabIndex = 10;
            this.gb1.TabStop = false;
            this.gb1.Text = "to isolate other radio buttons or other controlers";
            // 
            // btnShowGb
            // 
            this.btnShowGb.Location = new System.Drawing.Point(717, 145);
            this.btnShowGb.Name = "btnShowGb";
            this.btnShowGb.Size = new System.Drawing.Size(153, 49);
            this.btnShowGb.TabIndex = 7;
            this.btnShowGb.Text = "Click to Show/Hide Group Buttons";
            this.btnShowGb.UseVisualStyleBackColor = true;
            this.btnShowGb.Click += new System.EventHandler(this.btnShowgb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 602);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1152, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "tag property: is a variable that is inside all controls (objects) its type is obj" +
    "ect, used to store any kind of data , and then cast it to the needed type";
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 693);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gb1);
            this.Controls.Add(this.btnShowGb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BackBtn);
            this.Name = "NewForm";
            this.Text = "Check and radio boxes form";
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Button btnShowGb;
        private System.Windows.Forms.Label label2;
    }
}