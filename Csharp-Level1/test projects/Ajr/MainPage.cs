using Microsoft.Win32;
using System.IO;
using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Ajr
{
    public partial class MainPage : UserControl
    {
        Form1 Frm1; // to pass reference of form1 to this user control
        private AppSettings settings; // to load settings from the Json file
        private Dictionary<string, List<string>> categories; // to load the categories from its class
        private int timerInterval = 0;
        private bool eventsEnabled = true; // to prevent any methods from running during settings loading
        private bool isBalloonVisible = false;



        public MainPage(Form1 frm1)
        {
            InitializeComponent();

            Frm1 = frm1;

            settings = AppSettings.loadFromJson(); // to save any changes to the json
            categories = categoriesData.getCategories();

            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            
            prepareUserSettings();
        }
        private void prepareUserSettings()
        {
            eventsEnabled = false;

            rbNotifyOn.Checked = settings.isNotifyOn;
            rbNotifyOff.Checked = !settings.isNotifyOn;

            rbStartupOn.Checked = settings.isRunOnStartupOn;
            rbStartupOff.Checked = !settings.isRunOnStartupOn;

            cbPeriodBetweenNotification.SelectedIndex = settings.timerIntervalIndex;
            cbNotificationType.SelectedIndex = settings.selectedCategoryIndex;

            eventsEnabled = true;

            updateSettings(); // to update notifications timer once app is started
        }

        // udpating methods
        private int convertChosenIndexToInterval()
        {
            switch (cbPeriodBetweenNotification.SelectedIndex)
            {
                case 0: return 5 * 60 * 1000;
                case 1: return 10 * 60 * 1000;
                case 2: return 15 * 60 * 1000;
                case 3: return 30 * 60 * 1000;
                case 4: return 60 * 60 * 1000;
                case 5: return 120 * 60 * 1000;
                case 6: return 180 * 60 * 1000;
                case 7: return 240 * 60 * 1000;
                case 8: return 300 * 60 * 1000;
                default: return 5 * 60 * 1000;
            }
        }
        private void updateStartup(bool enable)
        {
            string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            string shortcutPath = Path.Combine(startupPath, "Ajr.lnk");

            if (enable)
            {
                var shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                shortcut.Save();
            }
            else
            {
                if (System.IO.File.Exists(shortcutPath))
                    System.IO.File.Delete(shortcutPath);

            }
        }




        private void updateBalloonTip()
        {
            string selectedCategory = cbNotificationType.SelectedItem.ToString();
            if (!categories.ContainsKey(selectedCategory) || categories[selectedCategory].Count == 0)
                return;

            Random rnd = new Random();
            int rndElement;

            if (cbNotificationType.SelectedIndex == 3)
            {
                bool isAM = (DateTime.Now.Hour < 12);
                rndElement = isAM ? rnd.Next(0, 8) : rnd.Next(9, categories[selectedCategory].Count);
            }
            else
            {
                rndElement = rnd.Next(0, categories[selectedCategory].Count);
            }

            notifyIcon1.BalloonTipTitle = selectedCategory;
            notifyIcon1.BalloonTipText = categories[selectedCategory].ElementAt(rndElement);
            
        }
        private void updateTimer()
        {
            timerInterval = convertChosenIndexToInterval();
            timerBalloon.Interval = timerInterval;
            timerBalloon.Enabled = rbNotifyOn.Checked;
        }
        private void updateSettings()
        {
            updateStartup(rbStartupOn.Checked);
            updateTimer();
            updateBalloonTip();
            settings.saveToJson();
            
        }

        // combo boxes and buttons
        private void cbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.selectedCategoryIndex = ((ComboBox)sender).SelectedIndex;
            updateSettings();
        }
        private void cbPeriodBetweenNotification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.timerIntervalIndex = ((ComboBox)sender).SelectedIndex;
            updateSettings();
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.isNotifyOn = rbNotifyOn.Checked;
            settings.isRunOnStartupOn = rbStartupOn.Checked;

            updateSettings();

        }
        private void btnTestNotify_Click(object sender, EventArgs e)
        {
            if (isBalloonVisible)
                return;

            updateBalloonTip();
            notifyIcon1.ShowBalloonTip(10000);
        }

        // balloon and timer
        private void timerBalloon_Tick(object sender, EventArgs e)
        {
            if (rbNotifyOff.Checked)
                return;

            updateSettings();
            notifyIcon1.ShowBalloonTip(10000);
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Frm1.Show();
            Frm1.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            Frm1.Activate();
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Frm1.Show();
            Frm1.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            Frm1.Activate();
        }

        // to prevent repeated balloons when mutliple clicks on test button
        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            isBalloonVisible = true;
        }
        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            isBalloonVisible = false;
        }


        // context menu strips
        private void tsmShow_Click(object sender, EventArgs e)
        {
            Frm1.Show();
            Frm1.WindowState = FormWindowState.Normal;
        }
        private void tsmClose_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }
    }
}
