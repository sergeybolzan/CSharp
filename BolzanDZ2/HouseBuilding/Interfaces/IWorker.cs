using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    interface IWorker
    {
        string Name { get; set; }
        void Work(House house);
    }
}
