using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _69___ListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tbID.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbID.Text) || string.IsNullOrWhiteSpace(tbName.Text))
                return;

            // prepare the item before adding to the listView.
            // item is the ID, then name and other details are sub items
            ListViewItem item = new ListViewItem(tbID.Text.Trim());  // this is an item, and the details of this item are sub items.

            if (rbMale.Checked)
                item.ImageIndex = 0;
            else
                item.ImageIndex = 1;

            // adding subitems will show data on columns based on the adding order.
            item.SubItems.Add(tbName.Text.Trim());
            item.SubItems.Add(tbAge.Text.Trim());

            // now item is ready to be added to the listView
            listView1.Items.Add(item);

            //reset text boxes for new entry
            tbID.Clear();
            tbName.Clear();
            tbID.Focus(); // but curser focus on this text box.

            
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void btnFillRandom_Click(object sender, EventArgs e)
        {
            for (byte i = 1; i <= 10; i++)
            {

                ListViewItem item = new ListViewItem(i.ToString());
                if (i % 2 == 0)
                    item.ImageIndex = 0;
                else
                    item.ImageIndex = 1;

                item.SubItems.Add("random");

                listView1.Items.Add(item);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(listView1.SelectedItems[0].Text);
        }

        private void rbDetails_Click(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;

            switch (button.Tag.ToString())
            {
                case "Details": listView1.View = View.Details; break;
                case "Large": listView1.View = View.LargeIcon; break;
                case "Small": listView1.View = View.SmallIcon; break;
                case "List": listView1.View = View.List; break;
                case "Tile": listView1.View = View.Tile; break;
            }

            listView1.Refresh();
        }
    }
}
