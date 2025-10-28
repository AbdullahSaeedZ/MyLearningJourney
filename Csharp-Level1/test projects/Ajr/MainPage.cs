using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Ajr
{
    public partial class MainPage : UserControl
    {

        private AppSettings settings;
        private Dictionary<string, List<string>> categories;
        private int timerInterval = 0;
        private int balloonShowTime = 0;
        private bool eventsEnabled = true;


        private void prepareUserSettings()
        {
            eventsEnabled = false;

            rbNotifyOn.Checked = settings.isNotifyOn;
            rbNotifyOff.Checked = !settings.isNotifyOn;

            rbNotifySoundOn.Checked = settings.isNotifySoundOn;
            rbNotifySoundOff.Checked = !settings.isNotifySoundOn;

            rbStartupOn.Checked = settings.isRunOnStartupOn;
            rbStartupOff.Checked = !settings.isRunOnStartupOn;

            cbPeriodBetweenNotification.SelectedIndex = settings.timerIntervalIndex;
            nudNotificationShowTime.Value = settings.balloonShowTime;
            cbNotificationType.SelectedIndex = settings.selectedCategoryIndex;

            eventsEnabled = true;
        }


        public MainPage()
        {
            InitializeComponent();

            settings = AppSettings.loadFromJson(); // to save any changes to the json
            categories = categoriesData.GetCategories();

            notifyIcon1.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            
            prepareUserSettings();
        }


        private void setStartup(bool enable)
        {
            string appName = Application.ProductName;
            string exePath = Application.ExecutablePath;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            if (enable)
            {
                key.SetValue(appName, exePath); 
            }
            else
            {
                key.DeleteValue(appName, false); 
            }
        }
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
        private void updateBalloonTip()
        {

            string selectedCategory = cbNotificationType.SelectedItem.ToString();
            if (!categories.ContainsKey(selectedCategory) || categories[selectedCategory].Count == 0)
                return;

            Random rnd = new Random();
            int rndElement = rnd.Next(0, categories[selectedCategory].Count);

            balloonShowTime = Convert.ToInt32(nudNotificationShowTime.Value) * 1000; // to ms
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
            setStartup(rbStartupOn.Checked);
            updateTimer();
            updateBalloonTip();
            settings.saveToJson();
            
        }


        private void cbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.selectedCategoryIndex = ((ComboBox)sender).SelectedIndex;
            updateSettings();
        }
        private void nudNotificationShowTime_ValueChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.balloonShowTime = Convert.ToInt32(((NumericUpDown)sender).Value);
            updateSettings();
        }
        private void cbPeriodBetweenNotification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.timerIntervalIndex = ((ComboBox)sender).SelectedIndex;
            updateSettings();
        }

      
        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            updateSettings();
            notifyIcon1.ShowBalloonTip(balloonShowTime);
        }

        private void timerBalloon_Tick(object sender, EventArgs e)
        {
            if (rbNotifyOff.Checked)
                return;

            if (rbNotifySoundOn.Checked)
                SystemSounds.Asterisk.Play();

            notifyIcon1.ShowBalloonTip(balloonShowTime);
        }
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
        }
        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (!eventsEnabled)
                return;

            settings.isNotifyOn = rbNotifyOn.Checked;
            settings.isNotifySoundOn = rbNotifySoundOn.Checked;
            settings.isRunOnStartupOn = rbStartupOn.Checked;

            updateSettings();

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ParentForm.Show();
            this.ParentForm.WindowState = FormWindowState.Normal;
            this.ParentForm.BringToFront();
        }

        private void tsmShow_Click(object sender, EventArgs e)
        {
            this.ParentForm.Show();
            this.ParentForm.WindowState = FormWindowState.Normal;
        }

        private void tsmClose_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }
    }
}



