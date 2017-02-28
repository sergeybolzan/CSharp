using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Dispatcher
    {
        #region FIELDS
        private static Random rand;
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Имя диспетчера
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// Корректировка погодных условий
        /// </summary>
        public int Correction { get; set; } 
        /// <summary>
        /// Количество штрафных очков
        /// </summary>
        public int Penalties { get; set; } // Количество штрафных очков
        /// <summary>
        /// Значение для того, чтобы пометить удаленного диспетчера (отписанного от события)
        /// </summary>
        public bool IsDeleted { get; set; }
        #endregion

        #region CTOR
        public Dispatcher(string name)
        {
            this.Name = name;
            Correction = rand.Next(-200, 201);
        }
        static Dispatcher()
        {
            rand = new Random();
        }
        #endregion

        #region METHODS
        /// <summary>
        /// Обработчик события самолета.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Plane_Report(object sender, EventArgs e)
        {
            Plane plane = (Plane)sender;
            int RecommendedHeight = 7 * plane.Speed - Correction;
            int differenceHeight = Math.Abs(RecommendedHeight - plane.Height);
            if (differenceHeight >= 300 && differenceHeight <= 600) Penalties += 25;
            if (differenceHeight > 600 && differenceHeight <= 1000) Penalties += 50;
            if (plane.Speed > 1000)
            {
                Penalties += 100;
                Console.WriteLine("Диспетчер {0}: Немедленно снизьте скорость!!!", Name);
            }
            Console.WriteLine("Диспетчер {0}: Рекомендуемая высота = {1} м. Количество штрафных очков = {2}", Name, RecommendedHeight, Penalties);
            if (differenceHeight > 1000) throw new Exception("Самолет разбился (Разница между рекомендуемой высотой и высотой самолета больше 1000)");
            if (Penalties >= 1000) throw new Exception("Непригоден к полетам (Набрано более 1000 штрафных отчков)");
            if (plane.Speed >= 1000) plane.IsReachMaxSpeed = true;
            if (plane.IsReachMaxSpeed == false)
            {
                if (plane.Height <= 0 || plane.Speed <= 0) throw new Exception("Самолет разбился (Высота или скорость <= 0)");
            }
            else
            {
                if (plane.Height < 0 || plane.Speed < 0) throw new Exception("Самолет разбился (Высота или скорость < 0)");
            }
        }
        #endregion
    }
}
