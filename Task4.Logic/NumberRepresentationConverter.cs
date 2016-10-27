using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Logic
{
    public static class NumberRepresentationConverter
    {
        //public static const string NaN = ""
        public static string DoubleToBinaryString(this double x)
        {
            if (double.IsNaN(x))
                return "NaN";
            StringBuilder sb = new StringBuilder(64);

            return sb.ToString();
        }
    }
}
