using fundamentals.basic_control_structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fundamentalsTest
{
    [TestClass]
    public class ControlStructuresTest
    {
        private readonly ControlStructures controlStructures = new ControlStructures();

        [TestMethod]
        public void CheckAgeGroupTest_Child()
        {
            Assert.AreEqual("Child", controlStructures.CheckAgeGroup(10), "Age group should be Child.");
        }

        [TestMethod]
        public void CheckAgeGroupTest_Teenager()
        {
            Assert.AreEqual("Teenager", controlStructures.CheckAgeGroup(15), "Age group should be Teenager.");
        }

        [TestMethod]
        public void GetDayNameTest_ValidDay()
        {
            Assert.AreEqual("Monday", controlStructures.GetDayName(2), "Day name should be Monday.");
        }

        [TestMethod]
        public void GetDayNameTest_InvalidDay()
        {
            Assert.AreEqual("Invalid day number", controlStructures.GetDayName(8), "Day name should be Invalid day number.");
        }

        [TestMethod]
        public void CalculateDiscountTest_PremiumCustomer()
        {
            Assert.AreEqual(80, controlStructures.CalculateDiscount(100, "premium"), 0.01, "Discounted price should be for premium customer.");
        }

        [TestMethod]
        public void CalculateDiscountTest_RegularCustomer()
        {
            Assert.AreEqual(90, controlStructures.CalculateDiscount(100, "regular"), 0.01, "Discounted price should be for regular customer.");
        }
    }
}
