using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    class PassengerCar : Car
    {
        public PassengerCar(string Name)
        {
            this.Name = Name;
            BaseSpeed = 60;
        }
    }
}
