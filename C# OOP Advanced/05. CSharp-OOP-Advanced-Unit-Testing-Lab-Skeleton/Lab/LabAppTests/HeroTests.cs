using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace LabAppTests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            var experienceGained = 5;

            var axeMock = new Mock<IWeapon>();
            var dummyMock = new Mock<ITarget>();
            dummyMock.Setup(x => x.GiveExperience()).Returns(experienceGained);
            dummyMock.Setup(x => x.IsDead()).Returns(true);

            Hero hero = new Hero("Danny", axeMock.Object);

            hero.Attack(dummyMock.Object);
            axeMock.Verify(a => a.Attack(dummyMock.Object));

            Assert.That(hero.Experience, Is.EqualTo(experienceGained));

        }

        [Test]
        public void IfDummyAttackedButNotDieDontGiveExperience()
        {
            var experienceGained = 0;

            var axeMock = new Mock<IWeapon>();

            var dummyMock = new Mock<ITarget>();
            dummyMock.Setup(x => x.GiveExperience()).Returns(experienceGained);
            dummyMock.Setup(x => x.IsDead()).Returns(false);

            Hero hero = new Hero("Danny", axeMock.Object);

            hero.Attack(dummyMock.Object);
            axeMock.Verify(a => a.Attack(dummyMock.Object));

            Assert.That(hero.Experience, Is.EqualTo(experienceGained));
        }
    }
}
