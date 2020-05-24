using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Products;

namespace StorageMaster.Structure.Tests.ProductsTests
{
    [TestFixture]
    public class SolidStateDriveTests
    {
        private Product ssd;

        [SetUp]
        public void SetUp()
        {
            this.ssd = new SolidStateDrive(10);
        }

        [Test]
        public void ConstructorSetsWeightCorrectly()
        {
            Assert.AreEqual(0.2, this.ssd.Weight);
        }
    }
}
