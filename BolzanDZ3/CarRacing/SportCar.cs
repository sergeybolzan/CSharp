using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    class SportCar : Car
    {
        public SportCar(string Name)
        {
            this.Name = Name;
            BaseSpeed = 70;
        }
    }
}
