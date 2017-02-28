using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Weather
{
    class INIManager
    {
        private const int SIZE = 1024; //Максимальный размер (для чтения значения из файла)
        private string pathToINI = null; //Для хранения пути к INI-файлу

        public INIManager(string aPath)        //Конструктор, принимающий путь к INI-файлу
        {
            pathToINI = Path.Combine(Environment.CurrentDirectory, aPath); ;
            
        }
        public string GetCodeFromINI(string aSection, string aKey)        //Возвращает значение из INI-файла (по указанным секции и ключу) 
        {
            StringBuilder buffer = new StringBuilder(SIZE);            //Для получения значения
            GetPrivateProfileString(aSection, aKey, null, buffer, SIZE, pathToINI);            //Получить значение в buffer
            return buffer.ToString();            //Вернуть полученное значение
        }
        public void WriteStringToINI(string aSection, string aKey, string aValue)        //Пишет значение в INI-файл (по указанным секции и ключу) 
        {
            WritePrivateProfileString(aSection, aKey, aValue, pathToINI);            //Записать значение в INI-файл
        }
        public Dictionary<string, string> GetCityCodeFromINI(string aSection)
        {
            byte[] buffer = new byte[SIZE];

            GetPrivateProfileSection(aSection, buffer, SIZE, pathToINI);
            String[] tmp = Encoding.Unicode.GetString(buffer).Trim('\0').Split('\0');

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (String entry in tmp)
            {
                result.Add(entry.Substring(0, entry.IndexOf("=")), entry.Substring(entry.IndexOf("=") + 1));
            }

            return result;
        }

        [DllImport("kernel32.dll")]        //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder buffer, int size, string path);

        [DllImport("kernel32.dll")]        //Импорт функции WritePrivateProfileString (для записи значений) из библиотеки kernel32.dll
        private static extern int WritePrivateProfileString(string section, string key, string str, string path);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]      //Импорт функции GetPrivateProfileSection (для записи значений) из библиотеки kernel32.dll
        private static extern int GetPrivateProfileSection(string section, byte[] lpszReturnBuffer, int size, string path);

    }
}

