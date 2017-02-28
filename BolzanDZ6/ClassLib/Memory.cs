using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    [Serializable]
    public class Memory
    {
        #region FIELDS
        private string model;
        private int size;
        #endregion

        #region PROPERTIES
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        #endregion

        #region CTORS
        public Memory() : this("testMemory", 0) { }
        public Memory(string model, int size)
        {
            this.model = model;
            this.size = size;
        }
        #endregion

        #region METHODS
        public override string ToString()
        {
            return String.Format("{0}, {1}", model, size);
        }
        #endregion
    }
}
