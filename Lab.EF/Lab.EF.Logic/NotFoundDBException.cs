using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class NotFoundDBException : Exception
    {
        public NotFoundDBException() : base("No se encontró lo que estabas buscando en la base de datos")
        {

        }
    }
}
