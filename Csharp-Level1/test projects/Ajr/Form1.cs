using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ajr
{
    public partial class Form1 : Form
    {
        enum enPages { eMain = 1, eAbout = 2, eExit = 3};
        MainPage homePage = new MainPage();

        public Form1()
        {
            InitializeComponent();
            pnlPages.Controls.Add(homePage);
            homePage.Dock = DockStyle.Fill;
        }

        private void ResetBtnsColors()
        {
            btnHome.BackColor = Color.FromArgb(50, 49, 69);
            btnAbout.BackColor = Color.FromArgb(50, 49, 69);
            btnExit.BackColor = Color.FromArgb(50, 49, 69);
        }
        private void MoveIndicator(Control btn)
        {
            ResetBtnsColors();
            pnlIndicator.Top = btn.Top;
            pnlIndicator.Height = btn.Height;
            btn.BackColor = Color.FromArgb(44, 43, 60);
        }

        private void ShowPage(enPages page)
        {
            pnlPages.Controls.Clear();

            switch (page)
            {
                case enPages.eMain:
                    pnlPages.Controls.Add(homePage);
                    homePage.Dock = DockStyle.Fill;
                    break;

                case enPages.eAbout:
                    
                    break;

            }
        }

        private void btnHandler_Click(object sender, EventArgs e)
        {
            Control btn = (Control)sender;
            enPages page = (enPages)Convert.ToInt16(btn.Tag);

            if (page == enPages.eExit)
            {
                Application.Exit();
            }
            
            MoveIndicator(btn);
            ShowPage(page);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;             // نمنع الإغلاق
                this.Hide();                
            }

        }
    }
}
