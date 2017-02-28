using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeOfArray
{

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите нижнюю границу диапазона: ");
                int bottom = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите верхнюю границу диапазона: ");
                int top = int.Parse(Console.ReadLine());

                RangeOfArray myArray = new RangeOfArray(bottom, top);
                myArray[7] = 5;
                myArray[10] = 15;
                for (int i = myArray.BottomIndex; i <= myArray.TopIndex; i++) Console.WriteLine(myArray[i]);
            }

            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
