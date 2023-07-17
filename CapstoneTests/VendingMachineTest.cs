using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;
using System.IO;
using System.Xml.XPath;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        VendingMachine classUnderTest;
        [TestInitialize]
        public void Init()
        {
            classUnderTest = new VendingMachine();
        }

        [TestMethod]
        public void CheckInventoryIsTrueWhen5()
        {
            string code = "A1";
            classUnderTest.MachineInvetory.AvailableInventory[code] = 5;

            bool result = classUnderTest.CheckInventory(code);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckInventoryIsFalseWhen0()
        {
            string code = "A1";
            classUnderTest.MachineInvetory.AvailableInventory[code] = 0;

            bool result = classUnderTest.CheckInventory(code);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckInventoryIsFalseWhenNegative()
        {
            string code = "A1";
            classUnderTest.MachineInvetory.AvailableInventory[code] = -5;

            bool result = classUnderTest.CheckInventory(code);

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void InventoryUpdatesWhenSelected()
        {
            Duck item = new Duck("A1", "Yellow Duck", .90M, "Duck");
            classUnderTest.UpdateInventory(item);
            int result = classUnderTest.MachineInvetory.AvailableInventory[item.Code];

            Assert.AreEqual(classUnderTest.MachineInvetory.AvailableInventory[item.Code], result);
        }

        [TestMethod]
        public void BalanceReducesBasedOnSelection()
        {
            classUnderTest.Balance = 10.00M;
            Duck item = new Duck("A1", "Yellow Duck", .90M, "Duck");
            classUnderTest.DispenseAndUpdateBalance(item);
            decimal result = classUnderTest.Balance;

            Assert.AreEqual(9.10M, result);
        }



        



    }
}
