using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing
{
    class Bus : Car
    {
        public Bus(string Name)
        {
            this.Name = Name;
            BaseSpeed = 50;
        }
    }
}
