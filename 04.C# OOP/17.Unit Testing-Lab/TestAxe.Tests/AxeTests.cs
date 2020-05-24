namespace TestAxe.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void Weapon_LosesDurabilityAfterAttack()
        {
            //Arrange
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void Weapon_CanAttackWhenBroken()
        {
            //Arrange
            Axe axe = new Axe(10, 1);
            Dummy dummy = new Dummy(10, 10);

            //Act
            axe.Attack(dummy);

            //Assert
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
