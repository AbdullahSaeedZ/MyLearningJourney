namespace _3__User_Controls_Expose_Property
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
            this.simpleCalc2 = new _3__User_Controls_Expose_Property.SimpleCalc();
            this.simpleCalc1 = new _3__User_Controls_Expose_Property.SimpleCalc();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "result of control1 accessed by form: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "result of control2 accessed by form: ";
            // 
            // simpleCalc2
            // 
            this.simpleCalc2.Location = new System.Drawing.Point(507, 62);
            this.simpleCalc2.Name = "simpleCalc2";
            this.simpleCalc2.Size = new System.Drawing.Size(207, 190);
            this.simpleCalc2.TabIndex = 0;
            // 
            // simpleCalc1
            // 
            this.simpleCalc1.Location = new System.Drawing.Point(94, 62);
            this.simpleCalc1.Name = "simpleCalc1";
            this.simpleCalc1.Size = new System.Drawing.Size(207, 190);
            this.simpleCalc1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Show Controls results";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 333);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simpleCalc2);
            this.Controls.Add(this.simpleCalc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimpleCalc simpleCalc1;
        private SimpleCalc simpleCalc2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

