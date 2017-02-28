using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilding
{
    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team(10);
            House house = new House();
            team.workers[0].Work(house);
            team.workers[1].Work(house);
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine();
            team.workers[0].FinishBuildBasement(house.basement);
            team.workers[1].FinishBuildBasement(house.basement);
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                team.workers[i].Work(house);
            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                team.workers[i].FinishBuildWalls(house.walls);
            }
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine();
            for (int i = 4; i < 7; i++)
            {
                team.workers[i].Work(house);
            }
            Console.WriteLine();
            for (int i = 4; i < 7; i++)
            {
                team.workers[i].FinishBuildRoof(house.roof);
            }
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine();
            for (int i = 7; i < 10; i++)
            {
                team.workers[i].Work(house);
            }
            Console.WriteLine();
            for (int i = 7; i < 10; i++)
            {
                team.workers[i].FinishBuildDoor(house.door);
            }
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine();
            for (int i = 7; i < 10; i++)
            {
                team.workers[i].Work(house);
            }
            Console.WriteLine();
            for (int i = 7; i < 10; i++)
            {
                team.workers[i].FinishBuildWindows(house.windows);
            }
            Console.WriteLine();
            team.teamLeader.Work(house);
            Console.WriteLine(house.housePictrue);
        }
    }
}
