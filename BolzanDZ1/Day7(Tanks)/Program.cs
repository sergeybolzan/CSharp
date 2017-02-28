using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib.WorldOfTanks;

namespace Day7_Tanks_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tank[] t34 = new Tank[5];
                for (int i = 0; i < t34.Length; i++) t34[i] = new Tank("T34");

                Tank[] pantera = new Tank[5];
                for (int i = 0; i < pantera.Length; i++) pantera[i] = new Tank("Pantera");

                for (int i = 0; i < 5; i++) Console.WriteLine("Бой {0}:\n{1}     VS     {2}\n{3}\n", i + 1, t34[i], pantera[i], t34[i] ^ pantera[i]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
