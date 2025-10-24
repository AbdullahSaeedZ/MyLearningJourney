namespace _67___TreeView_and_ImageList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Camry");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Corola");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Toyota", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("City");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Accord");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Honda", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "boy.png");
            this.imageList1.Images.SetKeyName(1, "girl.png");
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(45, 40);
            this.treeView1.Name = "treeView1";
            treeNode13.Name = "Node2";
            treeNode13.Text = "Node2";
            treeNode14.Name = "Node3";
            treeNode14.Text = "Node3";
            treeNode15.Name = "Node0";
            treeNode15.Text = "Node0";
            treeNode16.Name = "Node4";
            treeNode16.Text = "Node4";
            treeNode17.Name = "Node5";
            treeNode17.Text = "Node5";
            treeNode18.ImageKey = "girl.png";
            treeNode18.Name = "Node1";
            treeNode18.SelectedImageIndex = 0;
            treeNode18.Text = "Node1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode18});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(348, 273);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 522);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(487, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "imageList is group of indexed pics that can be used in treeView and other control" +
    "s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 538);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "in treeView, first there is a root then nodes branching from it ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 563);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(465, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "in the imageList property of the treeView, we select the imageList we prepared";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 579);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(431, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "then control each node property from the Nodes property in the treeView";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(299, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "showing nodes name using mouseDblClick event";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 703);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(992, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "A TreeView control represents a hierarchical data structure that allows a root no" +
    "de to have multiple sub-branches (child nodes) used to display data in a tree-li" +
    "ke format.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(472, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "using recursive function call to check or un check childs of a parent in one even" +
    "t";
            // 
            // treeView2
            // 
            this.treeView2.CheckBoxes = true;
            this.treeView2.ImageIndex = 0;
            this.treeView2.ImageList = this.imageList1;
            this.treeView2.Location = new System.Drawing.Point(501, 40);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Camry";
            treeNode2.Name = "Node3";
            treeNode2.Text = "Corola";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Toyota";
            treeNode4.Name = "Node4";
            treeNode4.Text = "City";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Accord";
            treeNode6.ImageKey = "girl.png";
            treeNode6.Name = "Node1";
            treeNode6.SelectedImageIndex = 0;
            treeNode6.Text = "Honda";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            this.treeView2.SelectedImageIndex = 0;
            this.treeView2.Size = new System.Drawing.Size(348, 273);
            this.treeView2.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 775);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView treeView2;
    }
}

