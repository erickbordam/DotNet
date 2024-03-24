using BasicControlStructures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicControlStructuresTest
{
    [TestFixture]
    class LoopOperationsTest
    {
        private readonly LoopOperations loopExamples = new LoopOperations();

        [Test]
        public void CountDownWhile_ReturnsZero()
        {
            Assert.AreEqual(0, loopExamples.CountDownWhile(10));
        }

        [Test]
        public void DoWhileExample_ReturnsZero()
        {
            Assert.AreEqual(0, loopExamples.DoWhileExample(10));
        }

        [Test]
        public void ForLoopSum_CalculatesSum()
        {
            Assert.AreEqual(55, loopExamples.ForLoopSum(1, 10)); // Sum of 1 to 10
        }

        [Test]
        public void ForEachSum_CalculatesSum()
        {
            Assert.AreEqual(6, loopExamples.ForEachSum(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void FindFirstPositiveReturn_FindsPositive()
        {
            Assert.AreEqual(5, loopExamples.FindFirstPositiveReturn(new int[] { -1, -2, 5, 6 }));
        }
    }
}
