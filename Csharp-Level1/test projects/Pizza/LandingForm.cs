using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class LandingForm : Form
    {
        public LandingForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

        }

        private void btnOrderNow_Click(object sender, EventArgs e)
        {
            MenuForm temp = new MenuForm(this);
            temp.Show();
            this.Hide(); // if i use close method , the app will close, cuz form1 (landing form) is the one set as start form.
        }
    }
}
