using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    delegate void OperationsDelegate();
    class Game
    {
        private static OperationsDelegate del;
        public static void GoGame(Car[] cars)
        {
            Console.WriteLine("\t\t\t\t{0,-20}{1,-20}{2,-20}", "Name", "Average Speed", "Distance");
            foreach (var item in cars)
            {
                item.FinishCar += FinishCar;
                del += item.Go;
            }
            for (int i = 0; i < 200; i++)
            {
                foreach (var item in cars)
                {
                    item.SumSpeed += item.Speed;
                    item.AverageSpeed = item.SumSpeed / (i + 1);
                }
                if (i % 20 == 0 && i != 0)
                {
                    Console.WriteLine("Временная отметка № {0}:", i / 20);
                    foreach (var item in cars)
                    {
                        Console.WriteLine("\t\t\t\t{0,-20}{1,-20}{2,-20:0.0}", item.Name, item.AverageSpeed, item.Distance);
                    }
                }
                del();
                if (Car.isFinish == true) break;
            }
        }
        private static void FinishCar(object sender, EventArgs e)
        {
            Car car = (Car)sender;
            Console.WriteLine(car.Name + " finish ");
        }
    }
}
