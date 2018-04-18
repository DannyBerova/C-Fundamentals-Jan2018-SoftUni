using System;
using NUnit.Framework;
using _08.CustomLinkedList;

namespace UnitTests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<int> dynList;

        [SetUp]
        public void TestInit()
        {
            this.dynList = new DynamicList<int>();
            this.dynList.Add(10);
            this.dynList.Add(20);
            this.dynList.Add(30);
        }

        [Test]
        public void NewEmptyListCountIsZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.AreEqual(0, list.Count);
        }

        [Test]
        public void AddElementToList()
        {
            this.dynList.Add(100);

            Assert.AreEqual(4, this.dynList.Count);
        }

        [Test]
        public void GetElementAtIndex()
        {
            Assert.AreEqual(20, this.dynList[1]);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void RemoveElementAtIndex(int index)
        {
            int valueExpected = this.dynList[index];

            int returnedValue = this.dynList.RemoveAt(index);

            Assert.AreEqual(valueExpected, returnedValue);
        }

        [Test]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        public void RemoveAtInvalidIndexThrowsExc(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynList.RemoveAt(index));
        }

        [Test]
        public void RemoveExistingElementByValue()
        {
            Assert.AreEqual(1, this.dynList.Remove(20));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void RemoveNonExistantElementByValue(int value)
        {
            Assert.AreEqual(-1, this.dynList.Remove(value));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnCorrectIndexOfElement(int value)
        {
            int expectedIndex = value / 10 - 1;

            Assert.AreEqual(expectedIndex, this.dynList.IndexOf(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnNegativeIndexOfElementWhenValueDoesNotExists(int value)
        {
            Assert.AreEqual(-1, this.dynList.IndexOf(value));
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ReturnTrueForExistingElementsWhenSearchedByValue(int value)
        {
            Assert.IsTrue(this.dynList.Contains(value));
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void ReturnFalseForExistingElementsWhenSearchedByValue(int value)
        {
            Assert.IsFalse(this.dynList.Contains(value));
        }
    }
}
