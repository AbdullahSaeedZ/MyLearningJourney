using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Game
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnFriendOption_Click(object sender, EventArgs e)
        {
            GameForm temp = new GameForm(((Button)sender).Tag.ToString());
            temp.Show();
            this.Hide();
            
        }
    }
}
