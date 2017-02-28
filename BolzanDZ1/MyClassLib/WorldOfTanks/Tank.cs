using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WorldOfTanks
{
    public class Tank
    {
        #region FIELDS
        private string name;
        private int ammunition;
        private int armor;
        private int mobility;
        private static Random rnd = new Random();
        #endregion

        #region CTOR
        public Tank(string name)
        {
            try
            {
                if (name == String.Empty) throw new Exception("Name is empty");
                this.name = name;
                ammunition = rnd.Next(101);
                armor = rnd.Next(101);
                mobility = rnd.Next(101);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
        #endregion

        #region OVERLOAD
        public static string operator ^(Tank tank1, Tank tank2)
        {
            int result = 0;
            if (tank1.ammunition > tank2.ammunition) result++;
            else if   (tank1.ammunition < tank2.ammunition) result--;

            if (tank1.armor > tank2.armor) result++;
            else if (tank1.armor < tank2.armor) result--;

            if (tank1.mobility > tank2.mobility) result++;
            else if (tank1.mobility < tank2.mobility) result--;

            if (result > 0) return tank1.name + " победил!";
            else if (result < 0) return tank2.name + " победил!";
            else return "Ничья!";
        }
        #endregion

        #region METHOD
        public override string ToString()
        {
            return name + " - Ammunition = " + ammunition + ", Armor = " + armor + ", Mobility = " + mobility;
        }
        #endregion
    }
}
