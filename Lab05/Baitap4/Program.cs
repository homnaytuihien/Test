using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitap4
{
    // 1. Tạo class TemperatureChangedEventArgs kế thừa EventArgs, có thuộc tính NewTemperature
    public class TemperatureChangedEventArgs : EventArgs
    {
        public double NewTemperature { get; }

        public TemperatureChangedEventArgs(double newTemperature)
        {
            NewTemperature = newTemperature;
        }
    }

    // 2. Tạo class Thermometer có event TemperatureChanged kiểu EventHandler<TemperatureChangedEventArgs>
    public class Thermometer
    {
        private double temperature;

        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        // 3. Khi nhiệt độ thay đổi, phát event
        public void SetTemperature(double t)
        {
            if (t != temperature)
            {
                temperature = t;
                OnTemperatureChanged(new TemperatureChangedEventArgs(t));
            }
        }

        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var thermometer = new Thermometer();

            // 4. Subscribe event, in nhiệt độ mới ra
            thermometer.TemperatureChanged += (sender, e) =>
            {
                Console.WriteLine($"Nhiệt độ mới: {e.NewTemperature}");
            };

            thermometer.SetTemperature(25.5);
            thermometer.SetTemperature(30.2);
            thermometer.SetTemperature(30.2); // không phát event vì không đổi
            thermometer.SetTemperature(22.0);

            // Kết quả mong đợi:
            // Nhiệt độ mới: 25.5
            // Nhiệt độ mới: 30.2
            // Nhiệt độ mới: 22.0
        }
    }
}
