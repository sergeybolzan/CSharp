using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class HDD : Storage
    {
        public double Speed { get; set; } //до 30 Мбайт/с
        public double MemorySize { get; set; }
        private double freeMemory;
        public HDD(double DeviceSize = 250)
        {
            Name = "WD";
            Model = "Red";
            Speed = 30;
            MemorySize = DeviceSize;
            freeMemory = MemorySize;
        }
        public override double GetMemorySize()
        {
            return MemorySize;
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
                int flashAmount = filesAmount / (int)(MemorySize * 1000 / 780) + 1;
                Console.WriteLine("Для копирования {0} Гб необходимо {1} HDD объемом {2} Гб", data, flashAmount, MemorySize);
                Console.WriteLine("Копирование будет длиться {0} минут", (int)(data*1000/Speed/60 + 1));
                Console.WriteLine("Общий объем необходимых HDD - {0} Гб", flashAmount * MemorySize);
            }
        }
        public override double GetFreeMemory()
        {
            return freeMemory;
        }
        public override void GetDeviceInfo()
        {
            Console.WriteLine("{0} {1} - скорость: {2} Мб/с, объем памяти: {3} Гб, объем свободной памяти: {4} Гб", Name, Model, Speed, MemorySize, freeMemory);
        }
    }
}
