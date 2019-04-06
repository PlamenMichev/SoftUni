using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Products;

namespace StorageMaster.Structure.Tests.ProductsTests
{
    [TestFixture]
    public class RamTests
    {
        private Product ram;

        [SetUp]
        public void SetUp()
        {
            this.ram = new Ram(10);
        }

        [Test]
        public void ConstructorSetsWeightCorrectly()
        {
            Assert.AreEqual(0.1, this.ram.Weight);
        }
    }
}
