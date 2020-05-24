namespace Tests
{
    using _02.ExtendedDatabase;
    using NUnit.Framework;
    
    public class PersonTests
    {
        [Test]
        public void PersonConstructorSouldSetName()
        {
            //Arrange
            Person person = new Person("Plamen", 12);

            //Assert
            Assert.AreEqual("Plamen", person.Name);
        }

        [Test]
        public void PersonConstructorSouldSetId()
        {
            //Arrange
            Person person = new Person("Plamen", 12);

            //Assert
            Assert.AreEqual(12, person.Id);
        }
    }
}
