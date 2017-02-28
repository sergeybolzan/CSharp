using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParamsAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book() { Name = "CLR via C#", Author = "Рихтер Дж.", NumberOfPages = "900 стр.", Price = "125 руб." };
            Console.WriteLine(book);
            SetValueToProperiesWithAttribute(book);
            Console.WriteLine(book);
            Console.ReadKey();
        }

        static void SetValueToProperiesWithAttribute(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var item in properties)
            {
                TakeValueFromINIFileAttribute attr = Attribute.GetCustomAttribute(item, typeof(TakeValueFromINIFileAttribute)) as TakeValueFromINIFileAttribute;
                if (attr != null)
                {
                    string pathToINI = Path.Combine(Environment.CurrentDirectory, attr.NameOfINIFile);
                    if (File.Exists(pathToINI))
                    {
                        StringBuilder buffer = new StringBuilder(1024);
                        GetPrivateProfileString("ProperyValues", "ProperyValue", null, buffer, 1024, pathToINI);
                        item.SetValue(obj, buffer.ToString());
                    }
                    else Console.WriteLine("Файла с именем {0} не существует", attr.NameOfINIFile);
                }
            }
        }
        /// <summary>
        /// Функция для чтения значений из ini файла
        /// </summary>
        /// <param name="section">Название секции в ini файле</param>
        /// <param name="key">Название ключа в ini файле</param>
        /// <param name="def">Возвращаемое значение, если правильное(допустимое) значение не может читаться</param>
        /// <param name="buffer">Строка фиксированной длины, получаемая при чтении любой строки файла или def</param>
        /// <param name="size">Длина в символах переменной buffer</param>
        /// <param name="path">Путь к ini файлу</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]        //Импорт функции GetPrivateProfileString (для чтения значений) из библиотеки kernel32.dll
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder buffer, int size, string path);
    }
}

