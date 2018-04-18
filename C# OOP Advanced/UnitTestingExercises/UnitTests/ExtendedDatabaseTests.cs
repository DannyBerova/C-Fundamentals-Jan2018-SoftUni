using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using _02.ExtendedDatabase;

namespace UnitTests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void TestDatabaseIPersonConstructorIsValid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            IDatabase<IPerson> db = new Database(testPersons);

            FieldInfo field = GetFieldInfo(db, typeof(IPerson[]));

            IPerson[] actualValues = (IPerson[])field.GetValue(db);
            IPerson[] buffer = new IPerson[actualValues.Length - testPersons.Length];

            Assert.That(actualValues, Is.EquivalentTo(testPersons.Concat(buffer)));
        }

        [Test]
        public void TestDatabaseIPersonInvalidConstructor()
        {
            IPerson[] data = new IPerson[17];

            Assert.That(() => new Database(data), Throws.InvalidOperationException);
        }

        [Test]
        public void TestDatabaseIPersonAddMethodValid()
        {
            var person = new Person(1, "I");
            Database db = new Database();

            db.Add(person);

            FieldInfo valuesInfo = GetFieldInfo(db, typeof(IPerson[]));

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));


            IPerson firstValue = ((IPerson[])valuesInfo.GetValue(db)).First();
            int valuesCount = (int)currentIndexInfo.GetValue(db);

            Assert.That(firstValue, Is.EqualTo(person));
            Assert.That(valuesCount, Is.EqualTo(1));
        }

        [Test]
        public void TestDatabaseIPersonAddMethodInvalid()
        {
            IPerson[] data = new IPerson[16];
            Database db = new Database(data);

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, 16);

            Assert.That(() => db.Add(new Person(1, "I")), Throws.InvalidOperationException);
        }

        [Test]
        public void TestDatabaseIPersonAddMethodSamePersonInvalid()
        {
            IPerson[] data = new IPerson[] {new Person(1, "I") };
            Database db = new Database(data);

            Assert.That(() => db.Add(new Person(1, "I")), Throws.InvalidOperationException);
        }

        [Test]
        public void TestDatabaseIPersonRemoveMethodValid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database();


            FieldInfo field = GetFieldInfo(db, typeof(IPerson[]));
            field.SetValue(db, testPersons);

            FieldInfo currentIndexInfo = GetFieldInfo(db, typeof(int));
            currentIndexInfo.SetValue(db, testPersons.Length);

            db.Remove();

            IPerson[] actualValues = (IPerson[])field.GetValue(db);
            IPerson[] buffer = new IPerson[actualValues.Length - (testPersons.Length - 1)];
            testPersons = testPersons.Take(testPersons.Length - 1).Concat(buffer).ToArray();

            Assert.That(actualValues, Is.EquivalentTo(testPersons));
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
        public void TestFetchDatabaseIPersonMethodValid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            var fetchedValues = db.Fetch();

            FieldInfo field = GetFieldInfo(db, typeof(IPerson[]));

            IPerson[] actualValues = (IPerson[])field.GetValue(db);
            var dataToCompare = actualValues.Take(testPersons.Length);

            Assert.That(fetchedValues, Is.EquivalentTo(dataToCompare));
        }

        [Test]
        public void TestMethodFindByUsernameValid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            Assert.That(() => db.FindByUsername("I"), Is.EqualTo(new Person(1, "I")));
        }

        [Test]
        [TestCase("She")]
        [TestCase("i")]
        public void TestMethodFindByUsernameInvalid(string name)
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            Assert.That(() => db.FindByUsername(name), Throws.InvalidOperationException);
        }

        [Test]
        public void TestMethodFindByIdValid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            Assert.That(() => db.FindById(1), Is.EqualTo(new Person(1, "I")));
        }

        [Test]
        public void TestMethodFindByIdMissingUserInvalid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            Assert.That(() => db.FindById(5), Throws.InvalidOperationException);
        }

        [Test]
        public void TestMethodFindByIdInvalid()
        {
            IPerson[] testPersons = InitializeTestPersons();
            Database db = new Database(testPersons);

            Assert.That(() => db.FindById(-1), Throws.Exception);
        }

        private static IPerson[] InitializeTestPersons()
        {
            return new IPerson[] { new Person(1, "I"), new Person(1, "You"), new Person(1, "He"), new Person(1, "They") };
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
