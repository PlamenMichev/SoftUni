using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Bson;
using NUnit.Framework;
using StorageMaster.Entities.Products;

namespace StorageMaster.Structure.Tests.Products
{
    [TestFixture]
    public class HardDriveTests
    {
        private Product hardDrive;

        [SetUp]
        public void SetUp()
        {
            this.hardDrive = new HardDrive(10);
        }

        [Test]
        public void ConstructorSetsWeightCorrectly()
        {
            Assert.AreEqual(1, this.hardDrive.Weight);
        }
    }
}
