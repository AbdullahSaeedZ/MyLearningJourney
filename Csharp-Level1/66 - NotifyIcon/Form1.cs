using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _66___NotifyIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = SystemIcons.Application; //chose the icon on top of the notification
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Error; //chose the big icon next to the title and message, we can customize it also
            notifyIcon1.BalloonTipTitle = "this is the title"; 
            notifyIcon1.BalloonTipText = "this is the message";
            notifyIcon1.ShowBalloonTip(1000);

            // or in one line 
           // notifyIcon1.ShowBalloonTip(5, "Important Info", "This notyfication will end after 5 seconds", ToolTipIcon.Warning);
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            MessageBox.Show("balloontip clicked !!");
        }
    }
}
