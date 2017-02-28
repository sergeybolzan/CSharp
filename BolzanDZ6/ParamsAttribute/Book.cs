using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsAttribute
{
    class Book
    {
        [TakeValueFromINIFile(NameOfINIFile = "propertyValue1.ini")]
        public string Name { get; set; }

        public string Author { get; set; }


        [TakeValueFromINIFile(NameOfINIFile = "propertyValue2.ini")]
        public string NumberOfPages { get; set; }


        [TakeValueFromINIFile(NameOfINIFile = "propertyValue3.ini")]
        public string Price { get; set; }


        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", Name, Author, NumberOfPages, Price);
        }
    }
}
