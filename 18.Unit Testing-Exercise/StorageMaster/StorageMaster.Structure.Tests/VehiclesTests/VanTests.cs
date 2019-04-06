using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProductMethodShouldAddNewProduct()
        {
            Ram product = new Ram(12);

            this.van.LoadProduct(product);

            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.van.Trunk.Count);
        }

        [Test]
        public void LoadProductMethodShouldThrowAnException()
        {
            Ram product = new Ram(12);

            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }

            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadMethodLastRemovesOneProduct()
        {
            this.van.LoadProduct(new Ram(12));
            this.van.LoadProduct(new Ram(13));
            this.van.LoadProduct(new Ram(14));
            this.van.LoadProduct(new Ram(15));

            this.van.Unload();

            Assert.AreEqual(3, this.van.Trunk.Count);
        }

        [Test]
        public void UnloadMethodLastRemovesACorrectProduct()
        {
            this.van.LoadProduct(new Ram(12));
            this.van.LoadProduct(new Ram(13));
            this.van.LoadProduct(new Ram(14));
            this.van.LoadProduct(new Ram(15));

            var expectedItem = this.van.Trunk.Last();

            Assert.AreEqual(expectedItem, this.van.Unload());
        }

        [Test]
        public void UnloadMethodShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void IsEmptyReturnsTrue()
        {
            var result = this.van.IsEmpty;
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmptyReturnsFalse()
        {
            this.van.LoadProduct(new Ram(2.35));

            var result = this.van.IsEmpty;
            Assert.IsFalse(result);
        }

        [Test]
        public void IsFullReturnsTrue()
        {
            Product hardDrive = new HardDrive(12);

            this.van.LoadProduct(hardDrive);
            this.van.LoadProduct(hardDrive);

            bool result = van.IsFull;

            Assert.IsTrue(result);
        }

        [Test]
        public void IsFullReturnsFalse()
        {
            Product hardDrive = new HardDrive(12);

            this.van.LoadProduct(hardDrive);

            bool result = van.IsFull;

            Assert.IsFalse(result);
        }

        [Test]
        public void CapacityIsSetCorrectly()
        {
            Assert.AreEqual(2, this.van.Capacity);
        }

        [Test]
        public void ProtertyTruckReturnsCorrectData()
        {
            Assert.AreEqual(0, this.van.Trunk.Count);
        }
    }
}