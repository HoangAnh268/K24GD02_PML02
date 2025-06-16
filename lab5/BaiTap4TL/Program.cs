using System;
using System.Text;
namespace BaiTap4TL
{
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double NewTemperature { get; set; }
        public TemperatureChangedEventArgs(double newTemperature)
        {
            NewTemperature = newTemperature;
        }
    }
    public class Thermometer
    {
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;


        private double temperature;
        public void SetTemperature(double t)
        {
            if (temperature != t)
            {
                temperature = t;
                //Phát event khi nhiệt độ thay đổi
                OnTemperatureChanged(new TemperatureChangedEventArgs(t));
            }
        }
        public virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thermometer thermometer = new Thermometer();

            //Subscribe event 
            thermometer.TemperatureChanged += Thermometer_TemperatureChanged;

            // Gọi SetTemperature để phát sự kiện
            thermometer.SetTemperature(37.5);
            thermometer.SetTemperature(38.4);
            thermometer.SetTemperature(38.4);//Khong co su thay doi vi khong phat event
            thermometer.SetTemperature(36.9);
        }
        private static void Thermometer_TemperatureChanged(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Nhiệt độ mới: {e.NewTemperature}°C");
        }
    }
}
