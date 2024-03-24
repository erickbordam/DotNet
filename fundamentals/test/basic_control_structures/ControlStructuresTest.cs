using BasicControlStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicControlStructuresTests
{
    [TestFixture]
    public class ControlStructuresTest
    {
        private readonly ControlStructures controlStructures = new ControlStructures();

        [Test]
        public void CheckAgeGroupTest_Child()
        {
            Assert.AreEqual("Child", controlStructures.CheckAgeGroup(10), "Age group should be Child.");
        }

        [Test]
        public void CheckAgeGroupTest_Teenager()
        {
            Assert.AreEqual("Teenager", controlStructures.CheckAgeGroup(15), "Age group should be Teenager.");
        }

        [Test]
        public void GetDayNameTest_ValidDay()
        {
            Assert.AreEqual("Monday", controlStructures.GetDayName(2), "Day name should be Monday.");
        }

        [Test]
        public void GetDayNameTest_InvalidDay()
        {
            Assert.AreEqual("Invalid day number", controlStructures.GetDayName(8), "Day name should be Invalid day number.");
        }

        [Test]
        public void CalculateDiscountTest_PremiumCustomer()
        {
            Assert.AreEqual(80, controlStructures.CalculateDiscount(100, "premium"), 0.01, "Discounted price should be for premium customer.");
        }

        [Test]
        public void CalculateDiscountTest_RegularCustomer()
        {
            Assert.AreEqual(90, controlStructures.CalculateDiscount(100, "regular"), 0.01, "Discounted price should be for regular customer.");
        }
    }
}
