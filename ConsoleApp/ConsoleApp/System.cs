using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class System
    {
        public System()
        {
            Division= new Division();
            Logic = new Logic();
        }

        private Division Division { get;}
        private Logic Logic { get;}
        public void Menu()
        {
            Console.WriteLine("Bienvenido al sistema de excepciones");
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Opción 1: Dividir un número por 0");
                Console.WriteLine("Opción 2: Dividir 2 números");
                Console.WriteLine("Opción 3: Excepción de Logic");
                Console.WriteLine("Opción 4: Excepción de Logic personalizada");
                Console.WriteLine("Opción 5: Salir");
                int opcion = this.LeerNumero();
                switch (opcion)
                {
                    case 1:
                        this.Ejercicio1();
                        break;
                    case 2:
                        this.Ejercicio2();
                        break;
                    case 3:
                        this.Ejercicio3();
                        break;
                    case 4:
                        this.Ejercicio4();
                        break;
                    case 5:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elegí una opción entre 1 y 5");
                        break;
                }
            }
        }

        private void Ejercicio1()
        {
            Console.Clear();
            Console.WriteLine("Dividir un número por 0");
            int num = this.LeerNumero();
            string resultado = "error";
            try
            {
                resultado = $"{Division.DividirPor0(num)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Resultado: {resultado}");
                Console.WriteLine("Finalizó la operación, presione una tecla para volver al menú");
                Console.ReadKey();
            }
        }
        
        private void Ejercicio2()
        {
            Console.Clear();
            Console.WriteLine("Dividir 2 numeros");
            Console.WriteLine("Primer número:");
            int num1 = this.LeerNumero();
            Console.WriteLine("Segundo número:");
            int num2 = this.LeerNumero();
            string resultado = "error";
            try
            {
                resultado = $"{Division.Dividir(num1,num2)}";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Resultado: {resultado}");
                Console.WriteLine("Finalizó la operación, presione una tecla para volver al menú");
                Console.ReadKey();
            }
        }
        private void Ejercicio3()
        {
            try
            {
                Logic.Excepcion();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"El tipo de la excepción es: { ex.GetType()}");
                Console.WriteLine($"y el mensaje: {ex.Message}");

            }
            finally
            {
                Console.WriteLine("Presione una tecla para volver al menú");
                Console.ReadKey();
            }
        }
        private void Ejercicio4()
        {
            try
            {
                Logic.ExcepcionPersonalizada();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"El tipo de la excepción es: {ex.GetType()}");
                Console.WriteLine($"y el mensaje: {ex.Message}");

            }
            finally
            {
                Console.WriteLine("Presione una tecla para volver al menú");
                Console.ReadKey();
            }
        }

        private int LeerNumero()
        {
            int num;
            while(true)
            {
                try
                {
                    Console.Write("Ingrese un número entero: ");
                    num = int.Parse(Console.ReadLine());
                    return num;
                }
                catch (Exception)
                {
                    Console.WriteLine("Seguro ingresó una letra o no ingreso nada!");
                }
            }
        }


    }
}
