using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamsAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    sealed class TakeValueFromINIFileAttribute : Attribute
    {
        public string NameOfINIFile { get; set; }
    }
}
