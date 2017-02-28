using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace nbrb
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xdocument = XDocument.Load("http://www.nbrb.by/Services/XmlExRates.aspx");
            //IEnumerable<XElement> employees = xdocument.Elements(); // получение структуры всего документа 
            //foreach (XElement employee in employees) 
            //{ 
            //    Console.WriteLine(employee); 
            //}
            XElement rootEmployee = xdocument.Element("DailyExRates");
            Console.WriteLine("Курсы валют на {0}:", rootEmployee.Attribute("Date").Value);
            foreach (XElement itemEmpl in rootEmployee.Elements()) 
            {
                Console.WriteLine("{0,-6} {1, -37} = {2,-6} {3}", itemEmpl.Element("Scale").Value, itemEmpl.Element("Name").Value, itemEmpl.Element("Rate").Value, "BYN");
            }
            Console.ReadKey();
        }
    }
}
