using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Division
    {
        public int DividirPor0(int num)
        {
            try
            {
                return num.DividirPor0();
            }
            catch (DivideByZeroException ex) 
            {
                throw ex;
            }
        }

        public int Dividir(int num1, int num2)
        {
            try
            {
                return num1.Dividir(num2);
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
    }
}
