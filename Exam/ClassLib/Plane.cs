using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Plane
    {
        #region FIELDS
        public List<Dispatcher> dispatcherList;
        public event EventHandler Report; 
        #endregion

        #region PROPERTIES
        public int Speed { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// = true, если самолет набрал скорость 1000 км/ч
        /// </summary>
        public bool IsReachMaxSpeed { get; set; } 
        #endregion

        #region CTOR
        public Plane()
        {
            dispatcherList = new List<Dispatcher>();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Главный метод игры. Вначале идет проверка на количество диспетчеров. 
        /// Потом бесконечный цикл с вызывом события и его обработчиков.
        /// Если самолет уже набрал скорость 1000 и в данные момент высота и скорость равны 0, 
        /// то происходит выход из бесконечного цикла.
        /// </summary>
        public void Go()
        {
            if (dispatcherList.Count < 2) throw new Exception("Полет невозможен, т. к. диспетчеров меньше 2-х");
            Speed = 50;
            Height = 250;
            WriteFlightData();
            while (true)
            {
                OnReport();
                PressKey();
                WriteFlightData();
                if (IsReachMaxSpeed == true && Height == 0 && Speed == 0) break;
            }
        }
        /// <summary>
        /// Метод, генерирующий событие
        /// </summary>
        private void OnReport()
        {
            if (Report != null) Report(this, EventArgs.Empty);
        }
        /// <summary>
        /// Метод для управления самолетом, добавления (клавиша 5) и удаления (клавиша 7) диспетчеров.
        /// Метод состоит из бесконечного цикла, выход из которого осуществляется нажатием любой клавиши управления самолетом
        /// </summary>
        private void PressKey()
        {
            Console.WriteLine("Нажмите клавишу: ");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.UpArrow) { Height += 500; break; }
                if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.DownArrow) { Height -= 500; break; }
                if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.LeftArrow) { Speed -= 150; break; }
                if (keyInfo.Modifiers == ConsoleModifiers.Shift && keyInfo.Key == ConsoleKey.RightArrow) { Speed += 150; break; }
                if (keyInfo.Key == ConsoleKey.UpArrow) { Height += 250; break; }
                if (keyInfo.Key == ConsoleKey.DownArrow) { Height -= 250; break; }
                if (keyInfo.Key == ConsoleKey.LeftArrow) { Speed -= 50; break; }
                if (keyInfo.Key == ConsoleKey.RightArrow) { Speed += 50; break; }
                if (keyInfo.Key == ConsoleKey.D5 || keyInfo.Key == ConsoleKey.NumPad5) { AddDispatcher(); Console.WriteLine("Нажмите клавишу: "); }
                if (keyInfo.Key == ConsoleKey.D7 || keyInfo.Key == ConsoleKey.NumPad7) { DeleteDispatcher(); Console.WriteLine("Нажмите клавишу: "); }
                if (keyInfo.Key != ConsoleKey.UpArrow &&
                    keyInfo.Key != ConsoleKey.DownArrow &&
                    keyInfo.Key != ConsoleKey.LeftArrow &&
                    keyInfo.Key != ConsoleKey.RightArrow &&
                    keyInfo.Key != ConsoleKey.D5 &&
                    keyInfo.Key != ConsoleKey.NumPad5 &&
                    keyInfo.Key != ConsoleKey.D7 &&
                    keyInfo.Key != ConsoleKey.NumPad7) Console.WriteLine("Неверный ввод");
            }
        }
        /// <summary>
        /// Вывод на экран текущей скорости и высоты самолета
        /// </summary>
        public void WriteFlightData()
        {
            Console.WriteLine("\nСкорость = {0} км/ч, высота = {1} м", Speed, Height);
        }
        /// <summary>
        /// Метод для добавления диспетчера. Имя диспетчера вводится с клавиатуры. 
        /// Потом добавляется метод диспетчера (обработчик события) в список события и диспетчер добавляется в коллекцию диспетчеров самолета.
        /// </summary>
        public void AddDispatcher()
        {
            Console.Write("Введите имя {0}-го диспетчера: ", dispatcherList.Count + 1);
            Dispatcher disp = new Dispatcher(Console.ReadLine());
            Report += disp.Plane_Report;
            dispatcherList.Add(disp);
            Console.WriteLine("Диспетчер {0} добавлен", disp.Name);
        }
        /// <summary>
        /// Метод для отписки обработчика события диспетчера из события.
        /// Сам диспетчер из коллекции не удаляется, чтобы в конце подсчитать общее количество штрафных очков.
        /// Отписанный диспетчер помечается булевым значением IsDeleted.
        /// В начале метода проверяется количество подписанных на событие диспетчеров и если их только двое, метод завершается.
        /// </summary>
        private void DeleteDispatcher()
        {
            int counterOfActiveDispatcher = 0;
            foreach (var item in dispatcherList)
            {
                if (item.IsDeleted == false) counterOfActiveDispatcher++;
            }
            if (counterOfActiveDispatcher <= 2)
            {
                Console.WriteLine("Диспетчеров не может быть меньше двух");
            }
            else
            {
                Console.Write("Введите порядковый номер диспетчера: ");
                int result = 0;
                while (true)
                {
                    if (Int32.TryParse(Console.ReadLine(), out result) && result >= 1 && result <= dispatcherList.Count)
                    {
                        Report -= dispatcherList[result - 1].Plane_Report;
                        dispatcherList[result - 1].IsDeleted = true;
                        break;
                    }
                    else Console.WriteLine("Неверный ввод");
                }
                Console.WriteLine("Диспетчер {0} удален", dispatcherList[result - 1].Name);
            }
        }
        #endregion
    }
}
