using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loger
{
    public static class Logger
    {
        private static string pattern;
        //todo: проверка на чтение из ini
        static Logger()
        {
            pattern = @"[Data] [Time] [Message]";
            if(File.Exists("logger.ini"))
            {
                pattern = File.ReadAllText("logger.ini");
            }
        }
        public static void Write(string methodName, TypeMessage typeMessage)//(string userName, string message, string methodName, TypeMessage typeMessage)
        {
            DateTime dateNow = DateTime.Now;
            string nameMonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateNow.Month);
            string pathDir = Path.Combine(Environment.CurrentDirectory, nameMonth);
            if (!Directory.Exists(pathDir)) Directory.CreateDirectory(pathDir);

            string fileName = String.Format("{0}.log", dateNow.ToString("dd-MM-yyyy"));
            string filePath = Path.Combine(pathDir, fileName);

            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate | FileMode.Append))
            {
                using(StreamWriter sw = new StreamWriter(file, Encoding.Default))
                {
                    sw.WriteLine(DateTime.Now.ToString() + " Method " + methodName + " " + typeMessage.ToString());
                }
            }
        }
    }
}
