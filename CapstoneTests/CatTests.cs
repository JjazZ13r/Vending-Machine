using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void CatPropertiesPopulate()
        {
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Cat testCat = new Cat(code, variety, price, productName);


            Assert.AreEqual(code, testCat.Code);
            Assert.AreEqual(variety, testCat.Variety);
            Assert.AreEqual(price, testCat.Price);
            Assert.AreEqual(productName, testCat.ProductName);
        }

        [TestMethod]
        public void CatGoesNeigh()
        {
            string expectedNeigh = "Meow, Meow, Meow!";
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Cat testCat = new Cat(code, variety, price, productName);

            Assert.AreEqual(expectedNeigh, testCat.MakeSound());

        }




    }
}
