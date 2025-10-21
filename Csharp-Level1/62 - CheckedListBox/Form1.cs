using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _62___CheckedListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 6; i++)
            {
                checkedListBox1.Items.Add("Item Number " + i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            //{
            //    //CheckedItems is basically an array
            //    MessageBox.Show(checkedListBox1.CheckedItems[i].ToString());
            //}

            foreach (var checkedItem in checkedListBox1.CheckedItems)
            {
                MessageBox.Show(checkedItem.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.RemoveAt(2);
        }
    }
}
