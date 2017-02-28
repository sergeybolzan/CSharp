using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            double data = 565;
            Storage[] mass = { new Flash(16), new DVD("one-sided"), new HDD(250) };
            foreach (var item in mass)
            {
                item.GetDeviceInfo();
                item.CopyData(data);
                Console.WriteLine();
            }
        }
    }
}
