using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceAfterAttackIfTargetDies()
        {
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            fakeTarget.Setup(t => t.Health).Returns(0);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveExperience()).Returns(20);

            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Hero hero = new Hero("Pesho", fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);
            Assert.That(hero.Experience, Is.EqualTo(20));
        }
    }
}
