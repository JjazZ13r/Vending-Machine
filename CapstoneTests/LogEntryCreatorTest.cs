using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class LogEntryCreatorTest
    {
        [TestMethod]
        public void FeedMoneyStringGenerator()
        {
            decimal deposit = .75M;
            decimal balance = .85M;

            string result = LogEntryCreator.FeedMoneyLog(deposit, balance);

            Assert.AreEqual(result, $"FEED MONEY: ${deposit} ${balance}");
        }

        [TestMethod]
        public void DispenseProductStringGenerator()
        {

            string variety = "Bleh";
            string code = "HX12";
            decimal price = .75M;
            decimal balance = .85M;

            string result = LogEntryCreator.DispenseProductLog(variety,code,price, balance);

            Assert.AreEqual(result, $"{variety} {code} ${price} ${balance}");
        }

        [TestMethod]
        public void ReturnChangeStringGenerator()
        {

            
            decimal change = .75M;
            decimal balance = 8.85M;

            string result = LogEntryCreator.ReturnMoneyLog(change, balance);

            Assert.AreEqual(result, $"GIVE CHANGE: ${change} ${balance}");
        }


    }
}
