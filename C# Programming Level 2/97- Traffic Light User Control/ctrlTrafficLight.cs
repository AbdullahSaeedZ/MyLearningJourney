using System;
using System.Windows.Forms;
using _97__Traffic_Light_User_Control.Properties;

namespace _97__Traffic_Light_User_Control
{
    public partial class ctrlTrafficLight : UserControl
    {
        // had it on a single traffic light demo, keeping it in caase i need it later
        public event Action OnGreen;
        public event Action OnRed;

        public int RedCountdown { get; set; } = 39;
        public int GreenCountdown { get; set; } = 10;
        public int OrangeCountdown { get; set; } = 3;

        public enum enLight { Green, Orange, Red }
        public enLight CurrentLight { get; private set; } = enLight.Red;

        private int _countdown;

        public ctrlTrafficLight()
        {
            InitializeComponent();
        }

        public void Initialize(enLight startingLight, int countdown)
        {
            _countdown = countdown;
            SwitchLightTo(startingLight);
        }

        public void OnTick()
        {
            _countdown--;

            if (_countdown <= 0)
                RunNextLight();
            else
                UpdateCountdownUI();
        }

        private void RunNextLight()
        {
            switch (CurrentLight)
            {
                case enLight.Green:
                    _countdown = OrangeCountdown;
                    SwitchLightTo(enLight.Orange);
                    break;

                case enLight.Orange:
                    _countdown = RedCountdown; // Now uses the updated property from frmMain!
                    SwitchLightTo(enLight.Red);
                    break;

                case enLight.Red:
                    _countdown = GreenCountdown;
                    SwitchLightTo(enLight.Green);
                    break;
            }
        }

        private void SwitchLightTo(enLight newLight)
        {
            CurrentLight = newLight;

            switch (newLight)
            {
                case enLight.Green:
                    this.BackgroundImage = Resources.Green;
                    OnGreen?.Invoke();
                    break;

                case enLight.Orange:
                    this.BackgroundImage = Resources.Orange;
                    break;

                case enLight.Red:
                    this.BackgroundImage = Resources.Red;
                    OnRed?.Invoke();
                    break;
            }

            ToggleCounters();
        }

        private void ToggleCounters()
        {
            lblGreenTimer.Visible = ( CurrentLight == enLight.Green );
            lblRedTimer.Visible = ( CurrentLight == enLight.Red );
            UpdateCountdownUI();
        }

        private void UpdateCountdownUI()
        {
            if (CurrentLight == enLight.Green)
                lblGreenTimer.Text = _countdown.ToString();
            else if (CurrentLight == enLight.Red)
                lblRedTimer.Text = _countdown.ToString();
        }
    }
}