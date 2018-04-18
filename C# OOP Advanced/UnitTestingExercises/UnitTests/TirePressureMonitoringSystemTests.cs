using _10.TirePressureMonitoringSystem;
using Moq;
using NUnit.Framework;
using System;
using System.Reflection;

namespace UnitTests
{
    [TestFixture]
    public class TirePressureMonitoringSystemTests
    {
        [Test]
        [TestCase(-1000)]
        [TestCase(22)]
        [TestCase(16)]
        public void TestAlarmCheckMethodWithOutOfRangeValuesReturnsAlarmOn(double oorValue)
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(oorValue);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

            sensor.SetValue(classInstance, mockSensor.Object);
            classInstance.Check();

            Assert.That(classInstance.AlarmOn, Is.True);
        }

        [Test]
        [TestCase(17)]
        [TestCase(21)]
        public void TestAlarmCheckMethodWithValidValuesReturnsAlarmOff(double valValue)
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();
            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(valValue);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);

            sensor.SetValue(classInstance, mockSensor.Object);
            classInstance.Check();

            Assert.That(classInstance.AlarmOn, Is.False);
        }
    }
}
