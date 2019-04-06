using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private StorageMaster.Core.StorageMaster storageMaster;

        [SetUp]
        public void Setup()
        {
            this.storageMaster = new StorageMaster.Core.StorageMaster();
        }

        [Test]
        public void AddProductMethodWorksCorrectly()
        {
            Assert.AreEqual("Added Ram to pool", this.storageMaster.AddProduct("Ram", 10));
        }

        [Test]
        public void RegisterStorageMethodWorksCorrectly()
        {
            Assert.AreEqual("Registered Kartof", this.storageMaster.RegisterStorage("Warehouse", "Kartof"));
        }

        [Test]
        public void SelectVehicleMethodWorksCorrectly()
        {
            this.storageMaster.RegisterStorage("Warehouse", "Kartof");
            Assert.AreEqual("Selected Semi", this.storageMaster.SelectVehicle("Kartof", 0));
        }


    }
}