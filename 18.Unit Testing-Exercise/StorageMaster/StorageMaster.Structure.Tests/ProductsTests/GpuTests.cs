using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using StorageMaster.Entities.Products;

namespace StorageMaster.Structure.Tests.Products
{
    [TestFixture]
    public class GpuTests
    {
        private Product gpu;

        [SetUp]
        public void SetUp()
        {
            this.gpu = new Gpu(10);
        }

        [Test]
        public void ConstructorSetsPriceCorrectly()
        {
            Assert.AreEqual(10, this.gpu.Price);
        }

        [Test]
        public void ConstructorSetsWeightCorrectly()
        {
            Assert.AreEqual(0.7, this.gpu.Weight);
        }

        [Test]
        public void PriceSetterThrowsAnException()
        {
            Assert.Throws<InvalidOperationException>(() => new Gpu(-2));
        }
    }
}
