using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeserializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<PC> shop;
                using (FileStream file = new FileStream(@"D:\listSerial.txt", FileMode.Open))
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    shop = (List<PC>)binFormat.Deserialize(file);
                }

                foreach (var pc in shop) Console.WriteLine(pc);
                Console.WriteLine();

                DeserializeEachObjectFromSeparateFile();
                Console.WriteLine();

                DeserializeFromXML();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Функция чтения объектов из файлов и вывода на экран значений полей объектов.
        /// </summary>
        static void DeserializeEachObjectFromSeparateFile()
        {
            PC onePC;
            int i = 1;
            while (File.Exists(@"D:\объект" + i.ToString() + ".txt"))
            {
                using (FileStream file = new FileStream(@"D:\объект" + i.ToString() + ".txt", FileMode.Open))
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    onePC = (PC)binFormat.Deserialize(file);
                }
                Console.WriteLine(onePC);
                i++;
            }
        }
        /// <summary>
        /// Десериализация из XML
        /// </summary>
        static void DeserializeFromXML()
        {
            List<PC> shop;
            using (FileStream file = new FileStream(@"D:\listSerial.xml", FileMode.Open))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<PC>));
                shop = (List<PC>)xmlFormat.Deserialize(file);
            }
            foreach (var pc in shop) Console.WriteLine(pc);
        }
    }
}
