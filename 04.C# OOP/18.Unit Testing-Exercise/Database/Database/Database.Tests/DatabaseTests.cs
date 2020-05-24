namespace _01.Databse.Tests
{
    using NUnit.Framework;
    using _01.Database;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database data;

        [SetUp]
        public void SetUp()
        {
            this.data = new Database(1, 2, 3, 4, 5, 6);
        }

        [Test]
        public void ConstructorSetsRightValue()
        {
            //Act
            int[] testCollection = new int[] { 12, 15, 3 };
            Database database = new Database(testCollection);

            //Assert
            Assert.AreEqual(testCollection, database.DatabaseElements, "Constructor doesn't " +
                                                                       "set right value");
        }

        [Test]
        [TestCase()]
        [TestCase(12, 15, 3, 12, 12,
            12, 15, 3, 12, 12, 12, 15,
            3, 12, 12, 12, 15, 3, 12, 12)]
        public void ConstructorThrowsExceptionWithInvalidValue(params int[] testCollection)
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(testCollection));
        }

        [Test]
        public void AddMethodShouldAddNumberWhenNotFull()
        {
            //Act
            for (int i = 0; i < 5; i++)
            {
                this.data.Add(i);
            }

            //Assert
            Assert.AreEqual(11, this.data.DatabaseElements.Length, "Add method " +
                                                                   "doesn't add num properly");
        }

        [Test]
        public void AddMethodThrowsExceptionWithInvalidParameter()
        {
            //Act
            for (int i = 0; i < 10; i++)
            {
                this.data.Add(i);
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => data.Add(12),
                "Add doesn't throw exception with invalid data");
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDatabase()
        {
            //Act
            for (int i = 0; i < 6; i++)
            {
                this.data.Remove();
            }

            //Assert
            Assert.Throws<InvalidOperationException>(() => data.Remove(), "Remove method doesn't" +
                                                                          "throw exception");
        }

        [Test]
        public void RemoveMethodShouldRemoveElementsWithFullCollection()
        {
            //Act
            for (int i = 0; i < 3; i++)
            {
                this.data.Remove();
            }

            //Assert
            Assert.AreEqual(3, this.data.DatabaseElements.Length, "Remove method" +
                                                                  "does'n remove nums");
        }

        [Test]
        public void RemoveMethodShouldRemoveTheCorrectElement()
        {
            //Arrange
            int[] testCollection = new[] { 1, 2, 3, 4, 5 };

            //Act
            this.data.Remove();

            //Assert
            Assert.AreEqual(this.data.DatabaseElements, testCollection);
        }

        [Test]
        public void PropertyDatabaseElemetsReturnsCorrectValue()
        {
            //Act
            int[] testCollection = new int[] { 1, 2, 3, 4, 5, 6 };


            //Assert
            Assert.AreEqual(testCollection, this.data.DatabaseElements);
        }

    }
}
