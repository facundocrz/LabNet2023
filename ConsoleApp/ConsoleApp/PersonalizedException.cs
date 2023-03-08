using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class PersonalizedException : Exception
    {
        public PersonalizedException(string message) : base("mirá vos el error que venis a cometer: " + message)
        {

        }
    }
}
