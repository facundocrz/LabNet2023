using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CustomersDTO
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string NameLowerCase { get; set; }
        public string NameUpperCase { get; set; }

        public string Region { get; set; }

        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public int CantidadOrdenesAsociadas { get; set; }
    }
}
