using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = { new SportCar("sportcar1"), 
                           new PassengerCar("passengercar1"), 
                           new Bus("bus1"), 
                           new Truck("truck1"),
                           new SportCar("sportcar2"), 
                           new PassengerCar("passengercar2"), 
                           new Bus("bus2"), 
                           new Truck("truck2") };
            Game.GoGame(cars);
        }
    }
}
