namespace _82___Context_Menu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2");
            this.cmsTxtFormat = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmChangeColor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeFont = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tsmClearTxtBox = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.cmsTreeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmsTxtFormat.SuspendLayout();
            this.cmsTreeMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsTxtFormat
            // 
            this.cmsTxtFormat.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTxtFormat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmChangeColor,
            this.tsmChangeFont,
            this.tsmClearTxtBox});
            this.cmsTxtFormat.Name = "contextMenuStrip1";
            this.cmsTxtFormat.Size = new System.Drawing.Size(169, 76);
            // 
            // tsmChangeColor
            // 
            this.tsmChangeColor.Name = "tsmChangeColor";
            this.tsmChangeColor.Size = new System.Drawing.Size(168, 24);
            this.tsmChangeColor.Text = "Change color";
            this.tsmChangeColor.Click += new System.EventHandler(this.tsmChangeColor_Click);
            // 
            // tsmChangeFont
            // 
            this.tsmChangeFont.Name = "tsmChangeFont";
            this.tsmChangeFont.Size = new System.Drawing.Size(168, 24);
            this.tsmChangeFont.Text = "Change Font";
            this.tsmChangeFont.Click += new System.EventHandler(this.tsmChangeFont_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "context menu is the menu that opens when we right click on the desktop for exampl" +
    "e , or right click on any place";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "the desktop we clicked on is the context, and then a menu related to that context" +
    " is opened";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "each context can have different menu";
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.cmsTxtFormat;
            this.textBox1.Location = new System.Drawing.Point(12, 162);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(275, 22);
            this.textBox1.TabIndex = 2;
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.cmsTreeMenu;
            this.treeView1.Location = new System.Drawing.Point(740, 413);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Node0";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Node4";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Node1";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(238, 233);
            this.treeView1.TabIndex = 3;
            // 
            // tsmClearTxtBox
            // 
            this.tsmClearTxtBox.Name = "tsmClearTxtBox";
            this.tsmClearTxtBox.Size = new System.Drawing.Size(168, 24);
            this.tsmClearTxtBox.Text = "clear text box";
            this.tsmClearTxtBox.Click += new System.EventHandler(this.tsmClearTxtBox_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(706, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "to link a control with a context menu strip, go to the control propery then look " +
    "for the context menu strip and assign it there";
            // 
            // cmsTreeMenu
            // 
            this.cmsTreeMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTreeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.cmsTreeMenu.Name = "cmsTreeMenu";
            this.cmsTreeMenu.Size = new System.Drawing.Size(171, 52);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 24);
            this.toolStripMenuItem1.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 24);
            this.toolStripMenuItem2.Text = "Transfer client";
            // 
            // textBox2
            // 
            this.textBox2.ContextMenuStrip = this.cmsTxtFormat;
            this.textBox2.Location = new System.Drawing.Point(16, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(275, 22);
            this.textBox2.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(808, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "we can link one cms with two controls but we use one click handler and sender obj" +
    "ect, or no need to link , do multiple cms for each control";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 690);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.cmsTxtFormat.ResumeLayout(false);
            this.cmsTreeMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsTxtFormat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeColor;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeFont;
        private System.Windows.Forms.ToolStripMenuItem tsmClearTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip cmsTreeMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
    }
}

