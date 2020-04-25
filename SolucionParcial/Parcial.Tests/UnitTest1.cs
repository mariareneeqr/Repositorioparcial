using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcial.Controllers;
using Parcial.Models;

namespace Parcial.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGetQuispes()
        {
            //arrange
            QuispesController quispecontroller = new QuispesController();
            //act
            var quispes = quispecontroller.GetQuispes();

            //assert
            Assert.IsNotNull(quispes);
        }
        [TestMethod]
        public void TestMethodPostQuispes()
        {
            //arrange
            QuispesController quispecontroller = new QuispesController();
            Quispe quispe = new Quispe();
            quispe.Name = "Maria";
            quispe.Email = "a2017115908@estiantes.upsa.edu.bo";
            quispe.Brithdate = "14/12/98";
            //act
            var quispes = quispecontroller.PostQuispe(quispe);

            //assert
            Assert.IsNotNull(quispes);
        }
    }
}
