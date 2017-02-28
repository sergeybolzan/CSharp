using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeOfArray
{
    class RangeOfArray
    {
        private int[] array;
        public int BottomIndex { get; private set; }
        public int TopIndex { get; private set; }
        public RangeOfArray(int bottom, int top)
        {
            if (top <= bottom) throw new IndexOutOfRangeException("Неверный диапазон!");
            else
            {
                BottomIndex = bottom;
                TopIndex = top;
                array = new int[top - bottom + 1];
            }
        }


        public int this[int index]
        {
            get
            {
                if (index >= BottomIndex && index <= TopIndex)
                {
                    return array[index - BottomIndex];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                array[index - BottomIndex] = value;
            }
        }
    }
}
