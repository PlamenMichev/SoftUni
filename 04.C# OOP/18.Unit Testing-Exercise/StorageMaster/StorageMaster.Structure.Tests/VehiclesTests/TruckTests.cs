namespace StorageMaster.Structure.Tests.VehiclesTests
{
    using StorageMaster.Entities.Vehicles;
    using NUnit.Framework;
    using StorageMaster.Entities.Products;
    using System;
    using System.Linq;

    [TestFixture]
    public class TruckTests
    {
        //The only difference between vehicles is their capacity so we add tests
        //only where capacity is different, otherwise we r going to repeat code.

        private Vehicle truck;

        [SetUp]
        public void SetUp()
        {
            this.truck = new Truck();
        }

        [Test]
        public void LoadProductMethodShouldThrowAnException()
        {
            Ram product = new Ram(12);

            for (int i = 0; i < 51; i++)
            {
                this.truck.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.truck.LoadProduct(product));
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product hardDrive = new HardDrive(12);

            for (int i = 0; i < 5; i++)
            {
                this.truck.LoadProduct(hardDrive);
            }

            bool result = truck.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.AreEqual(5, this.truck.Capacity);
        }
    }
}
