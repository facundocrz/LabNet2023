using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Logic
    {
        public void Excepcion()
        {
            throw new OutOfMemoryException();
        }

        public void ExcepcionPersonalizada()
        {
            throw new PersonalizedException("es el peor! ahorrar en pesos!");
        }
    }
}
