using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    class Worker : IWorker
    {
        public string Name { get; set; }
        public Worker(string name)
        {
            Name = name;
        }
        public void Work(House house)
        {
            if (house.basement.IsBuilt)
                if (house.wallsIsBuilt())
                    if (house.roof.IsBuilt)
                        if (house.door.IsBuilt)
                            if (house.windowsIsBuilt()) Console.WriteLine("The house building is finished");
                            else BuildWindows();
                        else BuildDoor();
                    else BuildRoof();
                else BuildWalls();
            else BuildBasement();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuildBasement()
        {
            Console.WriteLine("{0} build the basement", Name);
        }
        public void FinishBuildBasement(Basement basement)
        {
            basement.IsBuilt = true;
            Console.WriteLine("{0} built the basement", Name);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuildWalls()
        {
            Console.WriteLine("{0} build the walls", Name);
        }
        public void FinishBuildWalls(Wall[] walls)
        {
            foreach (var item in walls)
            {
                item.IsBuilt = true;
            }
            Console.WriteLine("{0} built the walls", Name);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuildRoof()
        {
            Console.WriteLine("{0} build the roof", Name);
        }
        public void FinishBuildRoof(Roof roof)
        {
            roof.IsBuilt = true;
            Console.WriteLine("{0} built the roof", Name);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuildDoor()
        {
            Console.WriteLine("{0} build the door", Name);
        }
        public void FinishBuildDoor(Door door)
        {
            door.IsBuilt = true;
            Console.WriteLine("{0} built the door", Name);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void BuildWindows()
        {
            Console.WriteLine("{0} build the windows", Name);
        }
        public void FinishBuildWindows(Window[] windows)
        {
            foreach (var item in windows)
            {
                item.IsBuilt = true;
            }
            Console.WriteLine("{0} built the windows", Name);
        }
    }
}
