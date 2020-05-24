using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Storage;

namespace StorageMaster.Structure.Tests.StorageTests
{
    [TestFixture]
    public class DistributionCenterTests
    {
        private Storage distributionCentre;

        [SetUp]
        public void SetUp()
        {
            this.distributionCentre = new DistributionCenter("Sklad");
        }

        [Test]
        public void ConstructorSetsCapacityCorrectly()
        {
            Assert.AreEqual(2, distributionCentre.Capacity);
        }

        [Test]
        public void ConstructorSetsGarageSlotsCorrectly()
        {
            Assert.AreEqual(5, distributionCentre.GarageSlots);
        }
    }
}
