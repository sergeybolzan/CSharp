using ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializConsolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PC> shop = new List<PC>() {new PC("Asus", "PC2584", "UX501", 1000), 
                                            new PC("MSI", "RG3445", "GS60", 900),
                                            new PC("Dell", "LK4534", "XPS 15", 1200),
                                            new PC("Lenovo", "QW4433", "Y700", 800),
                                            new PC()};

            string path = @"D:\listSerial.txt";
            if (File.Exists(path)) Console.WriteLine("Файл с таким именем существует, он перезаписан");
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                binFormat.Serialize(file, shop);
            }

            SerializeEachObjectToSeparateFile(shop);

            SerializeToXML(shop);

            Console.ReadKey();
        }
        /// <summary>
        /// Функция сохранения каждого объекта коллекции  в отдельном  каталоге с именами («объект1.txt», «объект2. txt», «объект3. txt» …)
        /// </summary>
        /// <param name="shop"></param>
        static void SerializeEachObjectToSeparateFile(List<PC> shop)
        {
            int i = 1;
            foreach (var pc in shop)
            {
                using (FileStream file = new FileStream(@"D:\объект" + i++.ToString() + ".txt", FileMode.Create))
                {
                    BinaryFormatter binFormat = new BinaryFormatter();
                    binFormat.Serialize(file, pc);
                }
            }
        }
        /// <summary>
        /// Сериализация в XML файл
        /// </summary>
        /// <param name="shop"></param>
        static void SerializeToXML(List<PC> shop)
        {
            using (FileStream file = new FileStream(@"D:\listSerial.xml", FileMode.Create))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<PC>));
                xmlFormat.Serialize(file, shop);
            } 
        }
    }
}
