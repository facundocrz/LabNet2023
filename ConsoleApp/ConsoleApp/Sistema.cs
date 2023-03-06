using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Sistema
    {
        public Sistema() 
        {
            Transportes = new List<TransportePublico>();
        }

        private List<TransportePublico> Transportes { get; }

        public void Menu()
        {
            Console.WriteLine("Bienvenido al sistema de transportes");
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Opción 1: Comenzar la carga de transportes");
                Console.WriteLine("Opción 2: Simulador de transporte");
                Console.WriteLine("Opción 3: salir");
                int opcion = this.LeerNumero();
                switch(opcion)
                {
                    case 1: 
                        this.CargarTransportes();
                        break;
                    case 2:
                        this.SimularTransporte();
                        break;
                    case 3:
                        salir = true;
                        break;
                    default: 
                        Console.WriteLine("Elegí una opción entre 1 y 3");
                        break;
                }
            }
        }

        private void GenerarOmnibus(int cantPasajeros)
        {
            Transportes.Add(new Omnibus(cantPasajeros));
        }

        private void GenerarTaxi(int cantPasajeros)
        {
            Transportes.Add(new Taxi(cantPasajeros));
        }

        private void CargarTransportes()
        {
            if (Transportes.Count == 0)
            {
                int cantPasajeros;
                for (int i = 1; i < 6; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"Ingresa la cantidad de pasajeros para el omnibus {i} entre 20 y 100");
                    do
                    {
                        cantPasajeros = this.LeerNumero();
                    }
                    while ( cantPasajeros < 20 || cantPasajeros > 100 );
                    this.GenerarOmnibus(cantPasajeros);
                    Console.Clear();
                    Console.WriteLine($"Ingresa la cantidad de pasajeros para el taxi {i} entre 1 y 4");
                    do
                    {
                        cantPasajeros = this.LeerNumero();
                    }
                    while (cantPasajeros < 1 || cantPasajeros > 4 );
                    this.GenerarTaxi(cantPasajeros);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Los datos ya se encuentran cargados\nPresione una tecla para volver al menu");
                Console.ReadKey();
            }
        }

        private void SimularTransporte()
        {
            Console.Clear ();
            TransportePublico transporte = this.ElegirTransporte();
            if(transporte != null)
            {
                Console.Clear();
                Console.WriteLine($"{transporte.Soy()} {Transportes.IndexOf(transporte)}");
                bool salir = false;
                while (!salir)
                {
                    Console.WriteLine("Opción 1: Acelerar");
                    Console.WriteLine("Opción 2: Detenerse");
                    Console.WriteLine("Opción 3: Subir pasajero");
                    Console.WriteLine("Opción 4: salir");
                    int opcion = this.LeerNumero();
                    switch (opcion)
                    {
                        case 1:
                            transporte.Avanzar();
                            Console.WriteLine($"Velocidad: {transporte.Velocidad} kph");
                            break;
                        case 2:
                            transporte.Detenerse();
                            Console.WriteLine($"Velocidad: {transporte.Velocidad} kph");
                            break;
                        case 3:
                            Console.WriteLine(transporte.Ocupar());
                            break;
                        case 4:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elegí una opción entre 1 y 4");
                            break;
                    }
                }
            }

        }

        private TransportePublico ElegirTransporte()
        {
            if(Transportes.Count() == 0)
            {
                Console.WriteLine("Primero realice la carga de transportes");
                return null;
            }
            foreach (var transporte in Transportes) 
            {
                Console.WriteLine($"Opción {Transportes.IndexOf(transporte)}: {transporte.Soy()} con una {transporte.Capacidad()}");
            }
            int eleccion;
            do
            {
                eleccion = this.LeerNumero();
            }
            while (eleccion < 0 || eleccion > 9);
            return Transportes[eleccion];
        }

        private int LeerNumero()
        {
            int n;
            string num;
            bool esNum;
            do
            {
                Console.Write("Ingrese un número que corresponda: ");
                num = Console.ReadLine();
                esNum = int.TryParse(num, out n);
            }
            while (!esNum);
            return n;
        }

    }
}
