using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек. А это веселая птица-синица, Которая часто ворует пшеницу, Которая в темном чулане хранится В доме, Который построил Джек.";
            string[] array = str.Split(" ,.".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!dict.ContainsKey(array[i]))
                    dict.Add(array[i], 1);
                else dict[array[i]]++;
            }

            Console.WriteLine("{0, 19} {1, 10}", "Слово:", "Кол-во:");
            int y = 1;
            foreach (var item in dict)
            {
                Console.WriteLine("{0, 2}. {1, 15} {2, 10}", y++, item.Key, item.Value);
            }
            Console.WriteLine("Всего слов: {0}, из них уникальных: {1}", array.Length, dict.Count);
        }
    }
}
