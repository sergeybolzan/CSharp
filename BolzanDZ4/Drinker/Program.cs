using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество игроков (2, 3, 4, 6): ");
            bool condition = true;
            string numberOfPlayers = null;
            while (condition)
            {
                numberOfPlayers = Console.ReadLine();
                switch (numberOfPlayers)
                {
                    case "2":
                    case "3":
                    case "4":
                    case "6":
                        condition = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод");
                        break;
                }
            }
            Game game = new Game(Int32.Parse(numberOfPlayers));
        }
    }
}
