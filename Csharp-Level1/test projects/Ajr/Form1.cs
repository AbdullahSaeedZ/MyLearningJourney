using System;
using System.Drawing;
using System.Windows.Forms;


namespace Ajr
{
    public partial class Form1 : Form
    {
        enum enPages { eMain = 1, eAbout = 2, eExit = 3};
        MainPage homePage;
        AboutPage aboutPage;
        
        // to drag the form since i removed the border
        private bool isDragging = false;
        private Point dragStartPoint;


        public Form1()
        {
            InitializeComponent();
            homePage = new MainPage(this);
            aboutPage = new AboutPage();

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
                    pnlPages.Controls.Add(aboutPage);
                    aboutPage.Dock = DockStyle.Fill;
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
                e.Cancel = true;             // to keep app running when closing the form
                this.Hide();                
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo{ FileName = "https://Abdullahsz.com",UseShellExecute = true} );
        }
        
        // dragging the form
        private void pnlDragForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);
            }
        }
        private void pnlDragForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left += e.X - dragStartPoint.X;
                this.Top += e.Y - dragStartPoint.Y;
            }
        }
        private void pnlDragForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
