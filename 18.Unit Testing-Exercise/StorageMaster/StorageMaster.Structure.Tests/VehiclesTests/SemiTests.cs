namespace StorageMaster.Structure.Tests.VehiclesTests
{
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Vehicles;
    using System;

    [TestFixture]
    public class SemiTests
    {
        private Vehicle semi;

        [SetUp]
        public void SetUp()
        {
            this.semi = new Semi();
        }

        [Test]
        public void LoadProductMethodShouldThrowAnException()
        {
            Ram product = new Ram(12);

            for (int i = 0; i < 101; i++)
            {
                this.semi.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.semi.LoadProduct(product));
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product hardDrive = new HardDrive(12);

            for (int i = 0; i < 10; i++)
            {
                this.semi.LoadProduct(hardDrive);
            }

            bool result = semi.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.AreEqual(10, this.semi.Capacity);
        }
    }
}
