using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOnTheRoad
{
    class Car
    {
        public string Name { get; private set; }
        private double oil;
        private double fuel;
        private double temp;
        private bool IsStop;

        public Car() : this("NoName") { }
        public Car(string Name)
        {
            this.Name = Name;
            oil = 100;
            fuel = 100;
            temp = 0;
        }

        public event EventHandler StopCar;
        private void OnStopCar(string Message)
        {
            IsStop = true;
            if(StopCar!=null)
                StopCar(this, new CarEventArgs() {Reason = Message});
        }

        public void Go(double oilDiff, double fuelDiff, double tempDiff)
        {
            for (int i = 0; i < 100; i++)
			{
                oil -= oilDiff;
                fuel -= fuelDiff;
                temp += tempDiff;
                Console.WriteLine(this);
                ProcessOil();
                ProcessFuel();
                ProcessTemp();
                if (IsStop == true) break;
            }
        }

        private void ProcessOil()
        {
            if(this.oil <= 0)
            {
                OnStopCar("Масло закончилось");
            }
        }
        private void ProcessFuel()
        {
            if (this.fuel <= 0)
            {
                OnStopCar("Топливо закончилось");
            }
        }
        private void ProcessTemp()
        {
            if (this.temp >= 120)
            {
                OnStopCar("Перегрев");
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-10}{1,-10}{2,-10}{3,-10}", Name, oil, fuel, temp);
        }
    }
}
