using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public abstract class TransportePublico
    {
        public TransportePublico(int cantPasajeros)
        {
            Pasajeros = cantPasajeros;
            AsientosOcupados = 0;
            Velocidad = 0;
        }

        private int Pasajeros { get; }
        private int AsientosOcupados { get; set; }
        public int Velocidad { get; set; }

        public abstract void Avanzar();

        public abstract string Soy();

        public void Detenerse()
        {
           Velocidad = 0;
        }
        public string Capacidad()
        {
            return $"capacidad para {Pasajeros} pasajeros";
        }

        public string Ocupar()
        {
            if (Pasajeros != AsientosOcupados && Velocidad == 0)
            {
                this.AsientosOcupados++;
                return $"se ocupó el asiento número {AsientosOcupados}";
            } else
            {
                if (Velocidad != 0)
                {
                    return $"Detenga el vehículo para subir pasajeros, muchas gracias";
                }
            }
            return $"no se puede subir, estoy llenito";
        }
    }
}
