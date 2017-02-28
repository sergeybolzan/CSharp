using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherLibrary;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            INIManager manager = new INIManager("cities.ini");
            Dictionary<string, string> dictCityCode = manager.GetCityCodeFromINI("Cities");

            int helper = 1;
            Dictionary<int, string> dictNumberCity = new Dictionary<int, string>();
            foreach (var item in dictCityCode)
            {
                dictNumberCity.Add(helper++, item.Key);
            }

            foreach (var item in dictNumberCity)
            {
                Console.WriteLine("{0}. {1}", item.Key, item.Value);
            }
            Console.WriteLine("Выберите город, для которого хотите узнать погоду: ");

            if (Int32.TryParse(Console.ReadLine(), out helper) & helper >= 1 & helper <= dictNumberCity.Count)
            {
                Logic weather = new Logic(dictCityCode[dictNumberCity[helper]]);
                weather.WriteWeather();
            }
            else Console.WriteLine("Неверный ввод");

            Logic.FindTheWarmestWeather(dictCityCode);

            Console.ReadKey();
        }
    }
}
