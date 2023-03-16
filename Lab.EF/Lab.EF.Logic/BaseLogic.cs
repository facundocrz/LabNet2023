using Lab.EF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public abstract class BaseLogic
    {
        protected readonly NorthwindContext _northwindContext;

        public BaseLogic()
        {
            _northwindContext = new NorthwindContext();
        }
    }

}
