namespace _2__User_Controls
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.simpleCalc1 = new _2__User_Controls.SimpleCalc();
            this.label4 = new System.Windows.Forms.Label();
            this.simpleCalc2 = new _2__User_Controls.SimpleCalc();
            this.simpleCalc3 = new _2__User_Controls.SimpleCalc();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "right click on the project  -> add -> userControl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(609, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "user control is like a groupBox that contains controls , it has default propertie" +
    "s inherited from usercontrol class";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(374, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "create a control , edit anytime in one place then all wil be udpated";
            // 
            // simpleCalc1
            // 
            this.simpleCalc1.Location = new System.Drawing.Point(78, 146);
            this.simpleCalc1.Name = "simpleCalc1";
            this.simpleCalc1.Size = new System.Drawing.Size(252, 200);
            this.simpleCalc1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(347, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "once created , build the projet then it will show up in toolbox";
            // 
            // simpleCalc2
            // 
            this.simpleCalc2.Location = new System.Drawing.Point(402, 146);
            this.simpleCalc2.Name = "simpleCalc2";
            this.simpleCalc2.Size = new System.Drawing.Size(252, 200);
            this.simpleCalc2.TabIndex = 1;
            // 
            // simpleCalc3
            // 
            this.simpleCalc3.Location = new System.Drawing.Point(732, 146);
            this.simpleCalc3.Name = "simpleCalc3";
            this.simpleCalc3.Size = new System.Drawing.Size(252, 200);
            this.simpleCalc3.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 370);
            this.Controls.Add(this.simpleCalc3);
            this.Controls.Add(this.simpleCalc2);
            this.Controls.Add(this.simpleCalc1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SimpleCalc simpleCalc1;
        private System.Windows.Forms.Label label4;
        private SimpleCalc simpleCalc2;
        private SimpleCalc simpleCalc3;
    }
}

