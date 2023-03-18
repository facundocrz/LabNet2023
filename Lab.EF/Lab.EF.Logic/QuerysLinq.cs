using Lab.EF.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class QuerysLinq : BaseLogic
    {
        public Customers Query1()
        {
            return _northwindContext.Customers.FirstOrDefault();
        }

        public List<Products> Query2()
        {
            var products = from p in _northwindContext.Products
                           where p.UnitsInStock == 0
                           select p;

            return products.ToList();
        }

        public List<Products> Query3()
        {
            return _northwindContext.Products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3).ToList();
        }

        public List<Customers> Query4()
        {
            var customers = from c in _northwindContext.Customers
                            where c.Region == "WA"
                            select c;
            return customers.ToList();
        }

        public Products Query5()
        {
            return _northwindContext.Products.FirstOrDefault(p => p.ProductID == 789);
        }

        public List<CustomersDTO> Query6()
        {
            var customersNames = from c in _northwindContext.Customers
                        select new CustomersDTO
                        {
                            NameLowerCase = c.CompanyName.ToLower(),
                            NameUpperCase = c.CompanyName.ToUpper(),
                        };
            return customersNames.ToList();
        }

        public List<CustomersDTO> Query7()
        {
            var query = from c in _northwindContext.Customers
                        join o in _northwindContext.Orders on c.CustomerID equals o.CustomerID
                        where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                        select new CustomersDTO
                        {
                            CustomerID = c.CustomerID,
                            CompanyName = c.CompanyName,
                            Region = c.Region,
                            OrderID = o.OrderID,
                            OrderDate = (DateTime)o.OrderDate
                        };
            return query.ToList();
            
        }

        public List<Customers> Query8()
        {
            return _northwindContext.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }

        public List<Products> Query9()
        {
            return _northwindContext.Products.OrderBy(p => p.ProductName).ToList();
        }

        public List<Products> Query10()
        {
            return _northwindContext.Products.OrderByDescending(p => p.UnitsInStock).ToList();
        }

        public List<string> Query11()
        {
            var categorias = (from c in _northwindContext.Categories
                             join p in _northwindContext.Products on c.CategoryID equals p.CategoryID
                             select c.CategoryName).Distinct();
            return categorias.ToList();
        }

        public Products Query12()
        {
            return _northwindContext.Products.First();
        }

        public List<CustomersDTO> Query13()
        {
            var query = from c in _northwindContext.Customers
                            join o in _northwindContext.Orders
                            on c.CustomerID equals o.CustomerID into customerOrders
                            select new CustomersDTO
                            {
                                CustomerID = c.CustomerID,
                                CompanyName = c.CompanyName,
                                CantidadOrdenesAsociadas = customerOrders.Count(),
                            };
            return query.ToList();
        }

    }
}
