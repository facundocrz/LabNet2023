using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.EF.UI
{
    public class System
    {
        private QuerysLinq _querysLinq = new QuerysLinq();
        public void Inicio()
        {
            Console.WriteLine("Bienvenido al sistema");
            Console.WriteLine("Se mostraran las querys resueltas de a una");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            this.Query1();
            this.Query2();
            this.Query3();
            this.Query4();
            this.Query5();
            this.Query6();
            this.Query7();
            this.Query8();
            this.Query9();
            this.Query10();
            this.Query11();
            this.Query12();
            this.Query13();
        }

        private void Continuar()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        private void Query1()
        {
            Console.WriteLine("1 - Query para devolver objeto customer: ");
            Console.WriteLine();
            Customers customer = _querysLinq.Query1();
            Console.WriteLine($"ID: {customer.CustomerID} Company name: {customer.ContactName} address:{customer.Address}");
            this.Continuar();
        }

        private void Query2()
        {
            Console.WriteLine("2 - Query para devolver todos los productos sin stock: ");
            Console.WriteLine();
            foreach (var product in _querysLinq.Query2())
            {
                Console.WriteLine($"ID: {product.ProductID} name: {product.ProductName}, stock: {product.UnitsInStock}");
            }
            this.Continuar();
        }

        private void Query3()
        {
            Console.WriteLine("3 - Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
            Console.WriteLine();
            foreach (var product in _querysLinq.Query3())
            {
                Console.WriteLine($"ID: {product.ProductID} name: {product.ProductName}, stock: {product.UnitsInStock} price: ${product.UnitPrice}") ;
            }
            this.Continuar();
        }

        private void Query4()
        {
            Console.WriteLine("4 - Query para devolver todos los customers de la Región WA");
            Console.WriteLine();
            foreach(var customer in _querysLinq.Query4())
            {
                Console.WriteLine($"ID: {customer.CustomerID}Company name:{customer.CompanyName}, region: {customer.Region}") ;
            }
            this.Continuar();
        }

        private void Query5()
        {
            Console.WriteLine("5 - Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            Console.WriteLine();
            Products product = _querysLinq.Query5();
            if ( product != null )
            {
                Console.WriteLine($"ID: {product.ProductID} name: {product.ProductName}");
            }
            else { 
                Console.WriteLine("null");
            }
            this.Continuar();
        }

        private void Query6()
        {
            Console.WriteLine("6 - Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
            Console.WriteLine();
            foreach (var customerName in _querysLinq.Query6())
            {
                Console.WriteLine($"{customerName.NameUpperCase} - {customerName.NameLowerCase}");
            }
            this.Continuar();
        }

        private void Query7()
        {
            Console.WriteLine("7 - Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997.");
            Console.WriteLine();
            foreach(var customerDTO  in _querysLinq.Query7())
            {
                Console.WriteLine($"CustomerID: {customerDTO.CustomerID} Company name: {customerDTO.CompanyName}, region: {customerDTO.Region} OrderID:{customerDTO.OrderID} date: {customerDTO.OrderDate.ToShortDateString()}");
            }
            this.Continuar();
        }

        private void Query8()
        {
            Console.WriteLine("8 - Query para devolver los primeros 3 Customers de la Región WA");
            Console.WriteLine();
            foreach (var customer in _querysLinq.Query8())
            {
                Console.WriteLine($"ID: {customer.CustomerID} Company name: {customer.CompanyName} region: {customer.Region}");
            }
            this.Continuar();
        }

        private void Query9()
        {
            Console.WriteLine("9 - Query para devolver lista de productos ordenados por nombre");
            Console.WriteLine();
            foreach (var product in _querysLinq.Query9())
            {
                Console.WriteLine($"ID: {product.ProductID} name: {product.ProductName}price: {product.UnitPrice}");
            }
            this.Continuar();
        }

        private void Query10()
        {
            Console.WriteLine("10 - Query para devolver lista de productos ordenados por unit in stock de mayor a menor.");
            Console.WriteLine();
            foreach (var product in _querysLinq.Query10())
            {
                Console.WriteLine($"ID: {product.ProductID} name: {product.ProductName} stock: {product.UnitsInStock}");
            }
            this.Continuar();
        }

        private void Query11()
        {
            Console.WriteLine("11 - Query para devolver las distintas categorías asociadas a los productos");
            Console.WriteLine();
            foreach (var categoryName in _querysLinq.Query11())
            {
                Console.WriteLine($"Category Name: {categoryName}");
            }
            this.Continuar();
        }

        private void Query12()
        {
            Console.WriteLine("12 - Query para devolver el primer elemento de una lista de productos");
            Console.WriteLine();
            var product = _querysLinq.Query12();
            Console.WriteLine($"Primer producto: ID: {product.ProductID} name: {product.ProductName} price: {product.UnitPrice}");
            this.Continuar();
        }

        private void Query13() 
        {
            Console.WriteLine("13 - Query para devolver los customer con la cantidad de ordenes asociadas");
            Console.WriteLine();
            foreach (var customerDTO in _querysLinq.Query13())
            {
                Console.WriteLine($"ID:{customerDTO.CustomerID} Company name: {customerDTO.CompanyName}, cantidad de ordenes asociadas: {customerDTO.CantidadOrdenesAsociadas}");
            }
            this.Continuar();
        }
    }
}
