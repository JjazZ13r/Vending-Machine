using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class DuckTest
    {
        [TestMethod]
        public void DuckPropertiesPopulate()
        {
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Duck testDuck = new Duck(code, variety, price, productName);


            Assert.AreEqual(code, testDuck.Code);
            Assert.AreEqual(variety, testDuck.Variety);
            Assert.AreEqual(price, testDuck.Price);
            Assert.AreEqual(productName, testDuck.ProductName);
        }

        [TestMethod]
        public void DuckGoesNeigh()
        {
            string expectedNeigh = "Quack, Quack, Splash!";
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Duck testDuck = new Duck(code, variety, price, productName);

            Assert.AreEqual(expectedNeigh, testDuck.MakeSound());

        }


    }
}
