using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class PC
    {
        #region FIELDS
        private string brand;
        private string serialNumber;
        private string model;
        private int price;
        private Memory memory;
        #endregion

        #region PROPERTIES
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public Memory Memory
        {
            set { memory = value; }
            get { return memory; }
        }

        #endregion

        #region CTORS
        public PC() : this("testBrand", "testSerialNumber", "testModel", 0) { }
        public PC(string brand, string serialNumber, string model, int price)
        {
            this.brand = brand;
            this.serialNumber = serialNumber;
            this.model = model;
            this.price = price;
            this.memory = new Memory();
        }
        #endregion

        #region METHODS
        public void TurnOn()
        {
            Console.WriteLine("Компьютер включился");
        }
        public void TurnOff()
        {
            Console.WriteLine("Компьютер выключился");
        }
        public void Reboot()
        {
            Console.WriteLine("Компьютер перезагрузился");
        }
        public override string ToString()
        {
            return String.Format("{0} {1}, S/N {2}, Price - {3}", brand, model, serialNumber, price);
        }
        #endregion
    }
}
