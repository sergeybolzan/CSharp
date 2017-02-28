using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanePilotTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа «Тренажер пилота самолета»\n\nСкорость - изменяется клавишами-стрелками Left и Right:\n(Right: + 50км/ч, Left: -50км/ч, Shift- Right : +150 км/ч, Shift- Left: -150 км/ч).\nВысота -  изменяется клавишами-стрелками Up и Down:\n(Up: +250м, Down: -250м, Shift- Up: +500м, Shift- Down: -500м).\nДля добавления диспетчера нажмите 5. Для удаления диспетчера нажмите 7\n");
            Plane plane = new Plane();
            plane.AddDispatcher();
            plane.AddDispatcher();
            try
            {
                plane.Go();
                int sumPenalties = 0;
                foreach (var item in plane.dispatcherList) // Подсчет штрафных очков
                {
                    sumPenalties += item.Penalties;
                }
                Console.WriteLine("\nСамолет успешно приземлился\nСумма штрафных очков: {0}", sumPenalties);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
