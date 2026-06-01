namespace Temperature_Change_Event_Example
{
    // custom eventArgs to be sent by fired event
    public class TempEventArgs : EventArgs
    {
        public int CurrentTemp { get; private set; } = 0;
        public int OldTemp { get; private set; } = 0;
        public int TempDifference { get; private set; } = 0;

        public TempEventArgs(int CurrentTemp, int OldTemp)
        {
            this.CurrentTemp = CurrentTemp;
            this.OldTemp = OldTemp;
            this.TempDifference = CurrentTemp - OldTemp;
        }
    }

    public class clsThermostat
    {
        public event Action<TempEventArgs> OnTempChanged;
        public int CurrentTemp { get; private set; } = 0;

        public void SetTemperature(int NewTemp)
        {
            if (NewTemp == this.CurrentTemp) return;

            OnTempChanged?.Invoke(new TempEventArgs(NewTemp, this.CurrentTemp));
            this.CurrentTemp = NewTemp;
        }

    }

    public class clsDisplay
    {
        public void Subscribe(clsThermostat Thermostat)
        {
            Thermostat.OnTempChanged += PrintTempInfo;
        }
        private void PrintTempInfo(TempEventArgs e)
        {
            Console.WriteLine("==================================");
            Console.WriteLine(DateTime.Now.ToString() + "\n");
            Console.WriteLine($"Current Temp: {e.CurrentTemp}C");
            Console.WriteLine($"Old Temp: {e.OldTemp}C");
            Console.WriteLine($"Temp Difference: {e.TempDifference}C");
            Console.WriteLine("==================================");
        }
    }

    public class clsAirConditioner
    {
        public void Subscribe(clsThermostat Thermostat)
        {
            Thermostat.OnTempChanged += StartAirConditioner;
        }
        private void StartAirConditioner(TempEventArgs e)
        {
            if (e.CurrentTemp >= 25)
                Console.WriteLine("Air Conditoiner is turned on\n\n");
            else
                Console.WriteLine("Air Conditoiner is turned off\n\n");
        }
    }





    internal class Program
    {
        static void Main(string[] args)
        {
            clsThermostat Thermostat1 = new clsThermostat();

            clsDisplay Display1 = new clsDisplay();
            clsAirConditioner AirConditioner1 = new clsAirConditioner();

            Display1.Subscribe(Thermostat1);
            AirConditioner1.Subscribe(Thermostat1);

            Thermostat1.SetTemperature(5);
            Thermostat1.SetTemperature(10);
            Thermostat1.SetTemperature(7);
            Thermostat1.SetTemperature(40);
            Thermostat1.SetTemperature(35);
            Thermostat1.SetTemperature(15);
        }
    }


}
