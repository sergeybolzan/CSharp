using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    abstract class Car
    {
        public string Name { get; set; }
        protected int BaseSpeed { get; set; }
        public int Speed { get; set; }
        public int SumSpeed { get; set; }
        public double AverageSpeed { get; set; }
        private double rate;
        public double Distance { get; set; }
        public static bool isFinish;
        public event EventHandler FinishCar;
        private static Random rnd = new Random();
        public Car ()
	    {
            rate = 0.01;
	    }
        private void OnFinishCar()
        {
            isFinish = true;
            if (FinishCar != null) FinishCar(this, EventArgs.Empty);
        }
        public void Go()
        {
            Speed = BaseSpeed + rnd.Next(0, 60);
            Distance += Speed * rate;
            if (Distance >= 100)
            {
                OnFinishCar();
            }
        }
    }
}
