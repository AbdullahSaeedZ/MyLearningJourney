using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _67___TreeView_and_ImageList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(treeView1.SelectedNode.Text);
        }



        private void CheckTreeViewNode(TreeNode parentNodeSender, Boolean isChecked)
        {
            // the node that triggered the event has child nodes also, we want to loop through those child nodes.
            foreach (TreeNode childNode in parentNodeSender.Nodes)
            {
                childNode.Checked = isChecked;// this will trigger the AfterCheck function as recursive untill we reach last child node. 

            }

                
        }

        // goal is that when checking a parent node, all childs will be checked also
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) // one of many events of treeView, this is when a node is checked
        {
            // the sender is the treeView controller , so we use e to get more details of the event itself.
            CheckTreeViewNode(e.Node, e.Node.Checked);

        }
    }
}
