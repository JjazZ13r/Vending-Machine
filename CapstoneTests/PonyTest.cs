using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;
namespace CapstoneTests
{
    [TestClass]
    public class PonyTest
    {

        

        [TestMethod]
        public void PonyPropertiesPopulate()
        {
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Pony testPony = new Pony(code, variety, price, productName);


            Assert.AreEqual(code, testPony.Code);
            Assert.AreEqual(variety, testPony.Variety);
            Assert.AreEqual(price, testPony.Price);
            Assert.AreEqual(productName, testPony.ProductName);
        }

        [TestMethod]
        public void PonyGoesNeigh()
        {
            string expectedNeigh = "Neigh, Neigh, Yay!";
            string code = "test code";
            string variety = "test variety";
            decimal price = .30M;
            string productName = "test product name";
            Pony testPony = new Pony(code, variety, price, productName);

            Assert.AreEqual(expectedNeigh, testPony.MakeSound());

        }





    }
}
