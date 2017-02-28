using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace WeatherLibrary
{
    public class Logic
    {
        private static XDocument xdoc;
        public Logic(string code)
        {
            string reference = "http://informer.gismeteo.by/rss/" + code + ".xml";
            xdoc = XDocument.Load(reference);
        }
        public void WriteWeather()
        {
            XElement elem = xdoc.Element("rss").Element("channel");
            Console.WriteLine(elem.Element("item").Element("title").Value.Substring(0, elem.Element("item").Element("title").Value.IndexOf(':') + 1));
            foreach (XElement item in elem.Elements("item"))
            {
                Console.WriteLine("{0} - {1}", item.Element("title").Value.Substring(item.Element("title").Value.IndexOf(':') + 2), item.Element("description").Value);
            }
            Console.WriteLine();
        }
        public static void FindTheWarmestWeather(Dictionary<string, string> dict)
        {
            int maxTemperature = -100;
            string text = null;
            foreach (var dictItem in dict)
            {
                xdoc = XDocument.Load("http://informer.gismeteo.by/rss/" + dictItem.Value + ".xml");
                XElement elem = xdoc.Element("rss").Element("channel");
                foreach (XElement item in elem.Elements("item"))
                {
                    Match match1 = Regex.Match(item.Element("description").Value, @"[-+]?\d+");
                    Match match2 = match1.NextMatch();
                    int avgTemp = (Int32.Parse(match1.ToString()) + Int32.Parse(match2.ToString())) / 2;
                    if (maxTemperature < avgTemp)
                    {
                        maxTemperature = avgTemp;
                        text = dictItem.Key + " - " + item.Element("description").Value;
                    }
                }
                WriteXMLToFile(xdoc, dictItem.Key);
            }
            Console.WriteLine("Самая теплая погода в городе " + text);
        }
        public static void WriteXMLToFile(XDocument xdocum, string name)
        {
            DateTime dateNow = DateTime.Now;
            string nameDay = String.Format("{0}", dateNow.ToString("yyyy-MM-dd"));
            string pathDir = Path.Combine(Environment.CurrentDirectory, nameDay);
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);

            string filePath = Path.Combine(pathDir, name + ".xml");

            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.OmitXmlDeclaration = true;
                settings.Indent = true;
                using (var writer = XmlWriter.Create(file, settings))
                {
                    xdocum.Save(writer);
                }
            }
        }
    }
}
