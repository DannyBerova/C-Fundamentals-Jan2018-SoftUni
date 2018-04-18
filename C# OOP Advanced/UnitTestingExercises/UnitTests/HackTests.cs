using System;
using Moq;
using NUnit.Framework;
using _07.Hack;

namespace UnitTests
{
    [TestFixture]
    public class HackTests
    {
        [Test]
        [TestCase(-100)]
        [TestCase(100)]
        [TestCase(0)]
        public void TestMathAbsValid(double value)
        {
            //vers 1 - mock with interface
            Mock<IMathAbs> intMock = new Mock<IMathAbs>();
            intMock.Setup(x => x.MathAbs(value)).Returns(Math.Abs(value));
            var expected = Math.Abs(value);
            var actual = intMock.Object.MathAbs(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(-100)]
        [TestCase(100)]
        [TestCase(0)]
        public void TestMathAbsValidWithClass(double value)
        {
            //vers 2 - mock with class - both versions worked
            Mock<MathInt> intMock = new Mock<MathInt>();
            var actual = intMock.Object.MathAbs(value);
            var expected = Math.Abs(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(66.6)]
        [TestCase(35.35353535)]
        [TestCase(0)]
        [TestCase(-66.6)]
        [TestCase(-35.35353535)]
        public void TestMathFloorValid(double value)
        {
            Mock<MathInt> intMock = new Mock<MathInt>();

            var actual = intMock.Object.MathFloor(value);
            var expected = Math.Floor(value);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
