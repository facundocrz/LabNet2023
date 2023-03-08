using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    [TestClass()]
    public class DivisionTests
    {

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirTest()
        {
            int num1 = 2;
            int num2 = 2;
            int num3 = 0;
            int resultadoObtenido;
            int resultadoEsperado = 1;
            Division division = new Division();
            resultadoObtenido = division.Dividir(num1, num2);

            Assert.AreEqual(resultadoEsperado, resultadoObtenido);

            division.Dividir(num1, num3);
        }

        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPor0Test()
        {
            int num = 2;
            Division division = new Division();
            division.DividirPor0(num);
        }
    }
}