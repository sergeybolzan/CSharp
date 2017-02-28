using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    class TeamLeader : IWorker
    {
        public string Name { get; set; }
        public TeamLeader(string name)
        {
            Name = name;
        }
        public void Work(House house)
        {
            Console.WriteLine("Leader report:");
            if (house.basement.IsBuilt) Console.WriteLine("- the basement is built");
            if (house.wallsIsBuilt()) Console.WriteLine("- the walls is built");
            if (house.roof.IsBuilt) Console.WriteLine("- the roof is built");
            if (house.door.IsBuilt) Console.WriteLine("- the door is built");
            if (house.windowsIsBuilt()) Console.WriteLine("- the windows is built");
            if (!house.basement.IsBuilt & !house.wallsIsBuilt() & !house.roof.IsBuilt & !house.door.IsBuilt & !house.windowsIsBuilt()) Console.WriteLine("Nothing is built");
            if (house.basement.IsBuilt & house.wallsIsBuilt() & house.roof.IsBuilt & house.door.IsBuilt & house.windowsIsBuilt()) Console.WriteLine("The house building is finished");
        }
    }
}
