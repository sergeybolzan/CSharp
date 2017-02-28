using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    class Truck : Car
    {
        public Truck(string Name)
        {
            this.Name = Name;
            BaseSpeed = 40;
        }
    }
}
