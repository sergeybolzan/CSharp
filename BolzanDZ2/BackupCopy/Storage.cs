using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupCopy
{
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public abstract double GetMemorySize();
        public abstract void CopyData(double size);
        public abstract double GetFreeMemory();
        public abstract void GetDeviceInfo();
    }
}
