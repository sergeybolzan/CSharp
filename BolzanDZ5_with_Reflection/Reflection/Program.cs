using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("ComplexLib");
                Console.WriteLine("Сборка ComplexLib - успешно загружена.\n");
                Type[] types = assembly.GetTypes();
                foreach (var item in types)
                {
                    Console.WriteLine("Тип: {0}", item);
                    MemberInfo[] members = item.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (var element in members)
                        Console.WriteLine("{0,-15}: {1}", element.MemberType, element);
                    Console.WriteLine();
                }
                Type type1 = assembly.GetType("ComplexLib.SpeciallyForYOUR.YoungNETdevelopers.SuperSecretClass1");
                object instance1 = Activator.CreateInstance(type1);



                Console.WriteLine(new string ('-', 80));
                assembly = Assembly.Load("InitializerLib");
                Console.WriteLine("Сборка InitializerLib - успешно загружена.\n");

                types = assembly.GetTypes();
                foreach (var item in types)
                {
                    Console.WriteLine("Тип: {0}", item);
                    MemberInfo[] members = item.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (var element in members)
                        Console.WriteLine("{0,-15}: {1}", element.MemberType, element);
                    Console.WriteLine();
                }
                Console.WriteLine(new string('-', 80));



                Type type2 = assembly.GetType("InitializerLib.Initializer");

                dynamic reflectOb = Activator.CreateInstance(type2, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { 1, 2 }, null);
                MethodInfo method1 = type1.GetMethod("Initialize", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                method1.Invoke(instance1, new object[] { reflectOb });

                reflectOb = Activator.CreateInstance(type2, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { 1000, 2 }, null);
                method1.Invoke(instance1, new object[] { reflectOb });



                MethodInfo method2 = type1.GetMethod("MainMetod", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                method2.Invoke(instance1, null);

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ReadKey();
            
        }   
    }
}
