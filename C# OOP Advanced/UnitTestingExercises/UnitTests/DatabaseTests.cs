using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using _01.Database;

namespace UnitTests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        [TestCase(new int[] {1, 2, 3, 4, 5})]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] {  })]
        [TestCase(new int[] { -1, -2, -3, -4, 5 })]

        public void TestIfConstructorIsValid(int[] data)
        {
            Database db = new Database(data);

            FieldInfo field = GetFieldInfo(db, typeof(int[]));

            int[] actualValues = (int[])field.GetValue(db);
            int[] buffer = new int[actualValues.Length - data.Length];

            Assert.That(actualValues, Is.EquivalentTo(data.Concat(buffer)));
        }

        [Test]
        public void TestInvalidConstructor()
        {
            int[] data = new int[17];

            Assert.That(() => new Database(data), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(0)]
        [TestCase(100)]
        [TestCase(-100)]
        public void TestAddMethodValid(int value)
        {
            Database db = new Database();

            db.Add(value);

            FieldInfo valuesInfo = GetFieldInfo(db, typeof(int[]));

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));


            int firstValue = ((int[])valuesInfo.GetValue(db)).First();
            int valuesCount = (int) currentIndexInfo.GetValue(db);

            Assert.That(firstValue, Is.EqualTo(value));
            Assert.That(valuesCount, Is.EqualTo(1));
        }

        [Test]
        public void TestAddMethodInvalid()
        {
            int[] data = new int[16];
            Database db = new Database(data);

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(1), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 })]
        public void TestRemoveMethodValid(int[] data)
        {
            Database db = new Database(data);

            FieldInfo field = GetFieldInfo(db, typeof(int[]));
            field.SetValue(db, data);

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, data.Length);

            db.Remove();
             
            int[] actualValues = (int[])field.GetValue(db);
            int[] buffer = new int[actualValues.Length - (data.Length - 1)];
            data = data.Take(data.Length - 1).Concat(buffer).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(data));
        }

        [Test]
        public void TestRemoveMethodInvalid()
        {
            Database db = new Database();

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, 0);

            Assert.That(() => db.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 0 })]
        public void TestFetchMethodValid(int[] data)
        {
            Database db = new Database(data);

            var fetchedValues = db.Fetch();

            FieldInfo field = GetFieldInfo(db, typeof(int[]));

            int[] actualValues = (int[])field.GetValue(db);
            var dataToCompare = actualValues.Take(data.Length);

            Assert.That(fetchedValues, Is.EquivalentTo(dataToCompare));
        }

        private FieldInfo GetFieldInfo(object instance, Type fieldType)
        {
            FieldInfo fieldInfo = instance.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(fi => fi.FieldType == fieldType);

            return fieldInfo;
        }
    }
}
