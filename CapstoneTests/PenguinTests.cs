using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class PenguinTests
    {

        [TestMethod]
        public void PenguinPropertiesPopulate()
        {
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Penguin testPenguin = new Penguin(code, variety, price, productName);


            Assert.AreEqual(code, testPenguin.Code);
            Assert.AreEqual(variety, testPenguin.Variety);
            Assert.AreEqual(price, testPenguin.Price);
            Assert.AreEqual(productName, testPenguin.ProductName);
        }

        [TestMethod]
        public void PenguinGoesNeigh()
        {
            string expectedNeigh = "Squawk, Squawk, Whee!";
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Penguin testPenguin = new Penguin(code, variety, price, productName);

            Assert.AreEqual(expectedNeigh, testPenguin.MakeSound());

        }







    }
}
