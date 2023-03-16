using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteExceptionTest()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            categoriesLogic.Delete(0);
        }
    }
}