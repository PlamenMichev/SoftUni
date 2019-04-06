using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Storage;

namespace StorageMaster.Structure.Tests.StorageTests
{
    [TestFixture]
    public class AutomatedWarehouseTests
    {
        private Storage automatedWarehouse;

        [SetUp]
        public void SetUp()
        {
            this.automatedWarehouse = new AutomatedWarehouse("Sklad");
        }

        [Test]
        public void ConstructorSetsCapacityCorrectly()
        {
            Assert.AreEqual(1, automatedWarehouse.Capacity);
        }

        [Test]
        public void ConstructorSetsGarageSlotsCorrectly()
        {
            Assert.AreEqual(2, automatedWarehouse.GarageSlots);
        }
    }
}
