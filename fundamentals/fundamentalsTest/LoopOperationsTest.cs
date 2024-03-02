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
    class LoopOperationsTest
    {
        private readonly LoopOperations loopExamples = new LoopOperations();

        [TestMethod]
        public void CountDownWhile_ReturnsZero()
        {
            Assert.AreEqual(0, loopExamples.CountDownWhile(10));
        }

        [TestMethod]
        public void DoWhileExample_ReturnsZero()
        {
            Assert.AreEqual(0, loopExamples.DoWhileExample(10));
        }

        [TestMethod]
        public void ForLoopSum_CalculatesSum()
        {
            Assert.AreEqual(55, loopExamples.ForLoopSum(1, 10)); // Sum of 1 to 10
        }

        [TestMethod]
        public void ForEachSum_CalculatesSum()
        {
            Assert.AreEqual(6, loopExamples.ForEachSum(new int[] { 1, 2, 3 }));
        }

        [TestMethod]
        public void FindFirstPositiveReturn_FindsPositive()
        {
            Assert.AreEqual(5, loopExamples.FindFirstPositiveReturn(new int[] { -1, -2, 5, 6 }));
        }
    }
}
