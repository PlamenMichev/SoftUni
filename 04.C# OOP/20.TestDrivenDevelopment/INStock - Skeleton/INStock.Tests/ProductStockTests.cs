using System.ComponentModel.DataAnnotations;
using INStock.Contracts;

namespace INStock.Tests
{
    using System;
    using NUnit.Framework;

    public class ProductStockTests
    {
        private IProductStock productStock;
        private IProduct dummyProduct;
        
        //bool Contains(IProduct product);
        //bool Remove(IProduct product);
        //IProduct Find(int index);

        [SetUp]
        public void SetUp()
        {
             this.productStock = new ProductStock();
             this.dummyProduct = new Product("SSD", 12.34m, 4);
        }

        [Test]
        public void Constructor_ShouldInitializeTheArray()
        {
            var expectedValue = 4;
            var actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddMethod_ShouldIncreaseQuantityForProductsWithSameLabel()
        {
            var label = "SSD";
            var price = 12.32m;
            int quantity = 2;

            var dummyProduct = new Product(label, price, quantity);
            var secDummyProduct = new Product(label, price, quantity);

            productStock.Add(dummyProduct);
            productStock.Add(secDummyProduct);

            var expectedValue = 1;
            var actualValue = productStock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddMethod_ShouldAddSuccessfully()
        {
            var label = "SSD";
            var price = 12.32m;
            int quantity = 2;

            var dummyProduct = new Product(label, price, quantity);

            productStock.Add(dummyProduct);

            var expectedValue = 1;
            var actualValue = productStock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddMethod_ShouldResizeWhenCountIsEqualToArrayLength()
        {
            var products = new[]
            {
                new Product("twst", 12, 12),
                new Product("12", 12, 12),
                new Product("plamen", 12, 12),
                new Product("hehe", 12, 12),
                new Product("da", 12, 12),
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            var expectedValue = 8;
            var actialValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actialValue);
        }

        [Test]
        public void AddMehtod_ShouldThrowInvalidOperationWhenNullIsPassed()
        {
            Assert.Throws<InvalidOperationException>(() => this.productStock.Add(null));
        }

        [Test]
        public void Set_InvalidIndex_ShouldReturnOutOfRangeException()
        {
            var product = new Product("Simo", 12, 12);

            Assert.Throws<IndexOutOfRangeException>(() 
                => this.productStock[this.productStock.Capacity + 2] = product);
        }

        [Test]
        public void Set_ValidIndex_ShouldSetSuccessfully()
        {
            var product = new Product("Simo", 12, 12);
            this.productStock[0] = product;

            var actualValue = productStock[0];

            Assert.AreSame(product, actualValue);
        }

        [Test]
        public void Get_InvalidIndex_ShouldThrowOutOfRangeException()
        {
            this.productStock.Add(this.dummyProduct);
            IProduct product = null;

            Assert.Throws<IndexOutOfRangeException>(() => product = this.productStock[2]);
        }

        [Test]
        public void Get_ValidIndex_ShouldReturnValue()
        {
            this.productStock.Add(this.dummyProduct);

            var actualValue = productStock[0];

            Assert.AreSame(dummyProduct, actualValue);
        }

        [Test]
        public void Remove_ShouldReturnFalseWhenElementIsNotFound()
        {
            this.productStock.Add(new Product("zoro", 12, 3));

            var actualResult = this.productStock.Remove(this.dummyProduct);
            var expectedResult = false;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Remove_ShouldShrinkWhenTheLengthIsHalfEmpty()
        {
            var products = new[]
            {
                new Product("Shkembe", 12, 12),
                new Product("12", 12, 12),
                new Product("FailedProduct", 12, 12),
                new Product("d", 12, 12),
                new Product("x", 12, 12),
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[3]);

            var expectedValue = 4;
            var actualValue = this.productStock.Capacity;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Remove_ShouldRemoveProdcutSuccessfully()
        {
            this.productStock.Add(this.dummyProduct);
            this.productStock.Remove(this.dummyProduct);

            var expectedValue = 0;
            var actualValue = this.productStock.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Remove_ShouldReorderTheArrayCorrectly()
        {
            var products = new[]
            {
                new Product("Shkembe", 12, 12),
                new Product("12", 12, 12),
                new Product("FailedProduct", 12, 12),
                new Product("d", 12, 12),
                new Product("x", 12, 12),
                new Product("xszx", 12, 12),
                new Product("xszx", 12, 12),
            };

            foreach (var product in products)
            {
                this.productStock.Add(product);
            }

            this.productStock.Remove(products[2]);

            for (int i = 2; i < this.productStock.Count; i++)
            {
                Assert.AreEqual(products[i + 1], this.productStock[i]);
            }
        }


    }
}
