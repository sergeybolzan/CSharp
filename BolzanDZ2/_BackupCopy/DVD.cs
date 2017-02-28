using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class DVD : Storage
    {
        public double Speed { get; set; } //21,12 Мбайт/с
        public string Type { get; set; }
        private double freeMemory;
        private double size;
        public DVD(string type = "two-sided")
        {
            Name = "Verbatim";
            Model = "DV100";
            Speed = 21.12;
            Type = type;
            if (type == "one-sided") size = 4.7;
            else size = 9;
            freeMemory = size;
        }
        public override double GetMemorySize()
        {
            return size;
        }
        public override void CopyData(double data)
        {
            if (freeMemory >= data)
            {
                freeMemory -= data;
                Console.WriteLine("Осталось свободной памяти - {0} Гб", freeMemory);
            }
            else
            {
                int filesAmount = (int)(data * 1000 / 780);
                int flashAmount = filesAmount / (int)(size * 1000 / 780) + 1;
                Console.WriteLine("Для копирования {0} Гб необходимо {1} DVD-дисков объемом {2} Гб", data, flashAmount, size);
                Console.WriteLine("Копирование будет длиться {0} минут", (int)(data * 1000 / Speed / 60 + 1));
                Console.WriteLine("Общий объем необходимых DVD-дисков - {0} Гб", flashAmount * size);
            }
        }
        public override double GetFreeMemory()
        {
            return freeMemory;
        }
        public override void GetDeviceInfo()
        {
            Console.WriteLine("{0} {1} - скорость: {2} Мб/с, объем памяти: {3} Гб, объем свободной памяти: {4} Гб", Name, Model, Speed, size, freeMemory);
        }
    }
}
