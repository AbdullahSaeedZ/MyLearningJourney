using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiards_Club_Management_System.SessionsHistory
{
    public partial class ctrlSessionsHistory : UserControl
    {
        public string DateTime { set { lblDateTime.Text = value; } }

        public ctrlSessionsHistory()
        {
            InitializeComponent();
        }

    }
}
