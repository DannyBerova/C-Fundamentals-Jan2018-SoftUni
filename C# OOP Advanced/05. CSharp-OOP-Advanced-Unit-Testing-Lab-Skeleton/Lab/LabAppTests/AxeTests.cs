using System;
using NUnit.Framework;

namespace LabAppTests
{
    public class AxeTests
    {

        [Test]
        public void AxeLooseDurabilityAfterAttack()
        {
            int initAxeAttack = 10;
            int initAxeDurability = 10;
            int initDummyHealth = 10;
            int initDummyExpirience = 10;
            int expectedPoints = 9;

            Axe axe = new Axe(initAxeAttack, initAxeDurability);
            Dummy dummy = new Dummy(initDummyHealth, initDummyExpirience);

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe durability doesen't change after attack.");
        }

        [Test]
        public void AxeCantAttackWhenIsBrocken()
        {
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException
                    .With.Message.EqualTo("Axe is broken."));
        }
    }
}
