using Moq;
using _01.TestAxe.Contracts;

namespace TestAxe.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void Hero_GainsXP_WhenKills()
        {
            //Arrange 
            Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
            Mock<ITarget> fakeTarget = new Mock<ITarget>();
            Hero hero = new Hero("Plamen", fakeWeapon.Object);

            

            //Act
            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            fakeTarget.Setup(p => p.GiveExperience())
                .Returns(10);
            hero.Attack(fakeTarget.Object);
            var exp = fakeTarget.Object.GiveExperience();

            //Assert
            Assert.AreEqual(10, hero.Experience);
        }

    }
}
