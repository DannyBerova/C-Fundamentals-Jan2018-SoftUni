using _03.IteratorProject;
using NUnit.Framework;
using System.Linq;

namespace UnitTests
{
    [TestFixture]
    public class ListyIteratorTests
    {
        [Test]
        public void TestConstructorWithParamsValid()
        {
            string[] testData = InitTestData();
            ListyIterator listy = new ListyIterator(testData);

            Assert.That(testData.ToList(), Is.EquivalentTo(listy.Data));
        }

        [Test]
        public void TestConstructorWithParamsInvalid()
        {
            string[] testData = new string[] { "one", null, "three" };

            Assert.That(() => new ListyIterator(testData), Throws.ArgumentNullException);
        }

        [Test]
        public void TestMethodHasNextTrue()
        {
            string[] testData = InitTestData();
            ListyIterator listy = new ListyIterator(testData);

            Assert.That(listy.HasNext, Is.EqualTo(true));
        }

        [Test]
        public void TestMethodHasNextFalse()
        {
            ListyIterator listy = new ListyIterator();

            Assert.That(listy.HasNext, Is.EqualTo(false));
        }

        [Test]
        public void TestMethodMoveTrue()
        {
            string[] testData = InitTestData();
            ListyIterator listy = new ListyIterator(testData);
            var moveTrue = listy.Move();

            Assert.That(moveTrue, Is.EqualTo(true));
        }

        [Test]
        public void TestMethodMoveFalse()
        {
            ListyIterator listy = new ListyIterator();
            var moveFalse = listy.Move();

            Assert.That(moveFalse, Is.EqualTo(false));
        }

        [Test]
        public void TestMethodPrintValid()
        {
            string[] testData = InitTestData();
            ListyIterator listy = new ListyIterator(testData);
            listy.Print();

            Assert.Pass();
        }

        [Test]
        public void TestMethodPrintInvalid()
        {
            ListyIterator listy = new ListyIterator();

            Assert.That(()=> listy.Print(), 
                Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
        }

        private static string[] InitTestData()
        {
            return new string[] { "one", "two", "three", "Danny" };
        }


    }
}