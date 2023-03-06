using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int cantPasajeros) : base(cantPasajeros) 
        { 
        }

        public override void Avanzar()
        {
            if (Velocidad < 100)
            {
                Velocidad += 5;
            }
        }

        public override string Soy()
        {
            return "Omnibus";
        }
    }
}
