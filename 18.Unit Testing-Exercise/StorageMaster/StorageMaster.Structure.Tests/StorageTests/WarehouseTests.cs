using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;
using StorageMaster.Entities.Vehicles;

namespace StorageMaster.Structure.Tests.StorageTests
{
    [TestFixture]
    public class WarehouseTests
    {
        private Storage warehouse;

        [SetUp]
        public void SetUp()
        {
            this.warehouse = new Warehouse("Sklad");
        }

        [Test]
        public void ConstructorSetsNameCorrectly()
        {
            Assert.AreEqual("Sklad", warehouse.Name);
        }

        [Test]
        public void ConstructorSetsCapacityCorrectly()
        {
            Assert.AreEqual(10, warehouse.Capacity);
        }

        [Test]
        public void ConstructorSetsGarageSlotsCorrectly()
        {
            Assert.AreEqual(10, warehouse.GarageSlots);
        }

        [Test]
        public void ConstructorSetsProductsCorrectly()
        {
            Assert.AreEqual(new List<Product>(), this.warehouse.Products);
        }

        [Test]
        public void GarageMethodWorksCorrectly()
        {
            Assert.AreEqual(this.warehouse.Garage, this.warehouse.Garage);
        }

        [Test]
        public void GetVehicleThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(123));
        }

        [Test]
        public void GetVehicleThrowsInvalidOperationExceptionWhenNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.warehouse.GetVehicle(3));
        }

        [Test]
        public void GetVehicleReturnsVehicle()
        {
            Assert.AreEqual(this.warehouse.Garage.First(), this.warehouse.GetVehicle(0));
        }

        [Test]
        public void UnloadMethodRemovesCar()
        {
            Assert.AreEqual(0, this.warehouse.UnloadVehicle(1));
        }
    }
}
