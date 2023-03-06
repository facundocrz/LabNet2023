using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Taxi : TransportePublico
    {
        public Taxi(int cantPasajeros) : base(cantPasajeros)
        {
        }

        public override void Avanzar()
        {
            if (Velocidad < 160)
            {
                Velocidad += 20;
            }
        }

        public override string Soy()
        {
            return "Taxi";
        }
    }
}
