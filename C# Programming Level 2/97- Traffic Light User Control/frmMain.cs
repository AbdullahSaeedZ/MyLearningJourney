using _97__Traffic_Light_User_Control.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using static _97__Traffic_Light_User_Control.ctrlTrafficLight;

namespace _97__Traffic_Light_User_Control
{
    public partial class frmMain : Form
    {
        public int GreenLightTimer { get; set; } = 10;
        public int OrangeLightTimer { get; set; } = 3;
        
        public int RedLightTimer = 13;

        private int _carSpeed = 2; // how many pixles the car will move every tick + timer interval
        private int _TLNumber = 1; // to control which car will be moving

        public frmMain()
        {
            InitializeComponent();
            // one traffic red light waiting for the other 3 
            RedLightTimer = ( GreenLightTimer + OrangeLightTimer ) * 3;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            InitializeLights();
            InitializeCars();
        }

        private void InitializeLights()
        {
            ctrlTrafficLight[] lights = { ctrlTrafficLight1, ctrlTrafficLight2, ctrlTrafficLight3, ctrlTrafficLight4 };
            foreach (ctrlTrafficLight light in lights)
            {
                light.GreenCountdown = GreenLightTimer;
                light.OrangeCountdown = OrangeLightTimer;
                light.RedCountdown = RedLightTimer;
            }

            // because this is the beginning, red lights will wait less, cuz im starting green directly on traffic light 1 which makes TL2 waits 13s, and TL3 waits 26s ...
            int startingRedTime = GreenLightTimer + OrangeLightTimer;
            ctrlTrafficLight1.Initialize(enLight.Green, GreenLightTimer);
            ctrlTrafficLight2.Initialize(enLight.Red, startingRedTime);
            ctrlTrafficLight3.Initialize(enLight.Red, startingRedTime * 2);
            ctrlTrafficLight4.Initialize(enLight.Red, startingRedTime * 3);

            LightsTimer.Interval = 1000;
            LightsTimer.Start();
        }

        private void InitializeCars()
        {
            ctrlTrafficLight1.OnGreen += CtrlTrafficLight1_OnGreen;
            ctrlTrafficLight2.OnGreen += CtrlTrafficLight2_OnGreen;
            ctrlTrafficLight3.OnGreen += CtrlTrafficLight3_OnGreen;
            ctrlTrafficLight4.OnGreen += CtrlTrafficLight4_OnGreen;

            // initializing first car
            pbCarDown.Location = new Point(508, 7);
            pbCarDown.Visible = true;
            CarTimer.Interval = _carSpeed;
            CarTimer.Start();
        }





        private void LightsTimer_Tick(object sender, EventArgs e)
        {
            ctrlTrafficLight1.OnTick();
            ctrlTrafficLight2.OnTick();
            ctrlTrafficLight3.OnTick();
            ctrlTrafficLight4.OnTick();
        }
        // to move the car 
        private void CarTimer_Tick(object sender, EventArgs e)
        {
            switch (_TLNumber)
            {
                case 1:
                    pbCarDown.Top += _carSpeed;
                    if (pbCarDown.Top >= this.ClientSize.Height)
                    {
                        CarTimer.Stop();
                        pbCarDown.Visible = false;
                    }
                    break;
                case 2:
                    pbCarRight.Left += _carSpeed;
                    if (pbCarRight.Left >= this.ClientSize.Width)
                    {
                        CarTimer.Stop();
                        pbCarRight.Visible = false;
                    }
                    break;
                case 3:
                    pbCarUp.Top -= _carSpeed;
                    if (pbCarUp.Top >= this.ClientSize.Height)
                    {
                        CarTimer.Stop();
                        pbCarUp.Visible = false;
                    }
                    break;
                case 4:
                    pbCarLeft.Left -= _carSpeed;
                    if (pbCarLeft.Top >= this.ClientSize.Width)
                    {
                        CarTimer.Stop();
                        pbCarLeft.Visible = false;
                    }
                    break;
                default:
                    break;
            }
        }


        // to hide and unhide cars based on Tlight number
        private void CtrlTrafficLight4_OnGreen()
        {
            _TLNumber = 4;

            HideAllCars();
            pbCarLeft.Location = new Point(1125, 369);
            pbCarLeft.Visible = true;
            CarTimer.Start();
        }
        private void CtrlTrafficLight3_OnGreen()
        {
            _TLNumber = 3;

            HideAllCars();
            pbCarUp.Location = new Point(620, 840);
            pbCarUp.Visible = true;
            CarTimer.Start();

        }
        private void CtrlTrafficLight2_OnGreen()
        {
            _TLNumber = 2;

            HideAllCars();
            pbCarRight.Location = new Point(12, 468);
            pbCarRight.Visible = true;
            CarTimer.Start();
        }
        private void CtrlTrafficLight1_OnGreen()
        {
            _TLNumber = 1;

            HideAllCars();
            pbCarDown.Location = new Point(508, 7);
            pbCarDown.Visible = true;
            CarTimer.Start();
        }

        private void HideAllCars()
        {
            pbCarDown.Visible = false;
            pbCarUp.Visible = false;
            pbCarLeft.Visible = false;
            pbCarRight.Visible = false;
        }
    }
}