namespace _53___First_Windows_Forms_App
{
    partial class Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MainTitle = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Form2Btn = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDialog = new System.Windows.Forms.Button();
            this.btnMessageBox = new System.Windows.Forms.Button();
            this.btnMsgBoxWIthPic = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(142, 468);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(363, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Click To Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 588);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(363, 55);
            this.button2.TabIndex = 2;
            this.button2.Text = "Enter Mouse To Copy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseEnter += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 141);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(354, 141);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(182, 20);
            this.textBox2.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(142, 408);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(363, 55);
            this.button3.TabIndex = 5;
            this.button3.Text = "Disable/Enable TextBox1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.MouseEnter += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(142, 528);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(363, 55);
            this.button4.TabIndex = 3;
            this.button4.Text = "Hide/Show All TextBoxes";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(142, 348);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(363, 55);
            this.button5.TabIndex = 6;
            this.button5.Text = "Hide/Show All Buttons";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(142, 288);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(363, 55);
            this.button6.TabIndex = 7;
            this.button6.Text = "Toggle TextBoxes Colors";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(142, 228);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(363, 55);
            this.button7.TabIndex = 8;
            this.button7.Text = "Toggle Background Color";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.FormBackColor);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(229, 169);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(196, 32);
            this.button8.TabIndex = 9;
            this.button8.Text = "Change Form Title (type in box1)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.ChangeFormTitle);
            this.button8.MouseEnter += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(106, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Text:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(351, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Enter Text:";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainTitle
            // 
            this.MainTitle.AutoSize = true;
            this.MainTitle.Font = new System.Drawing.Font("Castellar", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTitle.Location = new System.Drawing.Point(159, 7);
            this.MainTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(441, 57);
            this.MainTitle.TabIndex = 5;
            this.MainTitle.Text = "My First App !!!!";
            this.MainTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(229, 64);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(196, 32);
            this.button9.TabIndex = 10;
            this.button9.Text = "Change Main Title (type in box1)";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ChangeMainTitle);
            this.button9.MouseEnter += new System.EventHandler(this.button1_Click);
            // 
            // button10
            // 
            this.button10.FlatAppearance.BorderColor = System.Drawing.Color.DarkGoldenrod;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Location = new System.Drawing.Point(216, 753);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(164, 55);
            this.button10.TabIndex = 1;
            this.button10.TabStop = false;
            this.button10.Text = "flatAppearance property";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 922);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(683, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "colors: system option is using windows colors that set by system, when changing t" +
    "heme color of windows , app colors change";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 904);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(660, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "tab index, is the order of which controler is used when pressing tab, the goal is" +
    " to be able to use the app without a mouse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 886);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(313, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "tabStop, if false then it will be skipped when pressing tab";
            // 
            // Form2Btn
            // 
            this.Form2Btn.Location = new System.Drawing.Point(831, 860);
            this.Form2Btn.Name = "Form2Btn";
            this.Form2Btn.Size = new System.Drawing.Size(142, 59);
            this.Form2Btn.TabIndex = 13;
            this.Form2Btn.Text = "Show check and radio boxes form";
            this.Form2Btn.UseVisualStyleBackColor = true;
            this.Form2Btn.Click += new System.EventHandler(this.Form2Btn_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1277, 875);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 59);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 842);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(571, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "to change default form when running the app , change it in program.cs file in the" +
    " applicationRun method";
            // 
            // btnDialog
            // 
            this.btnDialog.Location = new System.Drawing.Point(1129, 875);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(142, 59);
            this.btnDialog.TabIndex = 13;
            this.btnDialog.Text = "Show Next Form as Dialog";
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.btnDialog_Click);
            // 
            // btnMessageBox
            // 
            this.btnMessageBox.Location = new System.Drawing.Point(1129, 810);
            this.btnMessageBox.Name = "btnMessageBox";
            this.btnMessageBox.Size = new System.Drawing.Size(142, 59);
            this.btnMessageBox.TabIndex = 13;
            this.btnMessageBox.Text = "Show Message box";
            this.btnMessageBox.UseVisualStyleBackColor = true;
            this.btnMessageBox.Click += new System.EventHandler(this.ShowMessageBox_Click);
            // 
            // btnMsgBoxWIthPic
            // 
            this.btnMsgBoxWIthPic.Location = new System.Drawing.Point(1277, 810);
            this.btnMsgBoxWIthPic.Name = "btnMsgBoxWIthPic";
            this.btnMsgBoxWIthPic.Size = new System.Drawing.Size(142, 59);
            this.btnMsgBoxWIthPic.TabIndex = 13;
            this.btnMsgBoxWIthPic.Text = "Show Message box with pic";
            this.btnMsgBoxWIthPic.UseVisualStyleBackColor = true;
            this.btnMsgBoxWIthPic.Click += new System.EventHandler(this.btnMsgBoxWIthPic_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1228, 762);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Message Box";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1431, 946);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnMsgBoxWIthPic);
            this.Controls.Add(this.btnMessageBox);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDialog);
            this.Controls.Add(this.Form2Btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.MainTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Main";
            this.Text = "Abdullah XD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label MainTitle;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Form2Btn;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDialog;
        private System.Windows.Forms.Button btnMessageBox;
        private System.Windows.Forms.Button btnMsgBoxWIthPic;
        private System.Windows.Forms.Label label7;
    }
}

