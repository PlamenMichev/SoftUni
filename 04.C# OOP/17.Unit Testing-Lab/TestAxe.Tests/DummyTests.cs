namespace TestAxe.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {

        [Test]
        public void Dummy_LosesHealth_IfAttacked()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.AreEqual(5, dummy.Health, "Dummy doesn't lose health");
        }

        [Test]
        public void Dummy_ThrowsAnException_WhenDead()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(10);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1),
                "Dummy doesn't throw an exception when dies");
        }

        [Test]
        public void Dummy_GivesXP_WhenDead()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(11);
            int xp = dummy.GiveExperience();

            //Assert
            Assert.AreEqual(10, xp);
        }

        [Test]
        public void Dummy_DoesntGiveXP_WhenAlive()
        {
            //Arrange
            Dummy dummy = new Dummy(10, 10);

            //Act
            dummy.TakeAttack(5);

            //Assert
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
