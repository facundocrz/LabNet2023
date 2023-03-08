using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    static class ExtensionMethods
    {
        public static int DividirPor0(this int value)
        {
            return value / 0;
        }
        
        public static int Dividir(this int value, int divisor)
        {
            return value / divisor;
        }
    }
}
