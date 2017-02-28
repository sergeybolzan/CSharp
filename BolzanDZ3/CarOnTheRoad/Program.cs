using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarOnTheRoad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}", "Name", "Oil", "Fuel", "Temp");
            Car car = new Car("BMW");
            Console.WriteLine(car);
            car.StopCar += car_StopCar;
            car.Go(1, 10, 5);
        }

        static void car_StopCar(object sender, EventArgs e)
        {
            Car car = (Car)sender;
            CarEventArgs evArg = (CarEventArgs)e;
            Console.WriteLine(car.Name + " - " + evArg.Reason + ". Машина остановилась");
        }

    }
}
