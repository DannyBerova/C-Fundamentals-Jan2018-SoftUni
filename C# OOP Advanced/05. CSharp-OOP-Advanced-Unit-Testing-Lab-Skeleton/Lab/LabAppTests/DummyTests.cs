using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace LabAppTests
{
    public class DummyTests
    {
        [Test]
        public void DummyLoosesHealthAfterAttack()
        {
            int initHealth = 10;
            int initExpirience = 10;
            int expectedHealth = 5;

            Dummy dummy = new Dummy(initHealth, initExpirience);

            dummy.TakeAttack(5);
            Assert.That(dummy.Health, Is.EqualTo(expectedHealth));
        }

        [Test]
        public void DummyThrowsExceptionUponAttackIfItsDead()
        {
            int initHealth = 0;
            int initExpirience = 5;
            int attackPoints = 5;
            Dummy dummy = new Dummy(initHealth, initExpirience);

            Assert.That
                (() => dummy.TakeAttack(attackPoints), 
                Throws.InvalidOperationException.With
                    .Message.EqualTo("Dummy is dead."));

        }
    }
}
