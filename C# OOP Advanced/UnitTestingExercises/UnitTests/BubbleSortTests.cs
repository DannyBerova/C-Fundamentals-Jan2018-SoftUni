using System;
using BubbleSort;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    class BubbleSortTests
    {
        [Test]
        [TestCase( new int[] {1, 5, 100, -1})]
        [TestCase(new int[] { 1, 1, 1 })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { })]
        public void TestMethodBubbleSortValid(int[] testData)
        {
            var bubbleList = new Bubble<int>(testData);
            Array.Sort(testData);
            
            var expected = bubbleList.BubbleSort();

            Assert.That(expected, Is.EquivalentTo(testData));
        }
    }
}
