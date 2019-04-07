using System;
using INStock.Contracts;

namespace INStock.Tests
{
    using NUnit.Framework;

    public class ProductTests
    {
        [Test]
        public void Constructor_ShouldInitializeCorrectValues()
        {
            string label = "Kartof";
            decimal price = 12.34m;
            int quantity = 3;

            IProduct product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }

        [Test]
        public void Constructor_InvalidLabel_ShouldThrowArgumentNullException()
        {
            string invalidLabel = null;
            decimal price = 1;
            int quantity = 1;

            Assert.Throws<ArgumentNullException>
                (() => new Product(invalidLabel, price, quantity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-123)]
        public void Constructor_InvalidPrice_ShouldThrowArgumentxception(decimal invalidPrice)
        {
            string label = "Kartof";
            int quantity = 1;

            Assert.Throws<ArgumentException>
                (() => new Product(label, invalidPrice, quantity));
        }

        [Test]
        public void Constructor_InvalidQuantity_ShouldThrowArgumentException()
        {
            string label = "Kartof";
            decimal price = 12;
            int invalidQuantity = -3;

            Assert.Throws<ArgumentException>
                (() => new Product(label, price, invalidQuantity));
        }

        [Test]
        public void CompareTo_ShouldReturnLabelWithGreaterASCIICode()
        {
            var greaterProductLabel = "Plamen";
            var greaterProductPrice = 12.3m;
            var greaterProductQuantity = 3;

            var smallerProductLabel = "Div";
            var smallerProductPrice = 12.3m;
            var smallerProductQuantity = 33;

            var greaterProduct = 
                new Product(greaterProductLabel, greaterProductPrice, greaterProductQuantity);
            var smallerProduct = 
                new Product(smallerProductLabel, smallerProductPrice, smallerProductQuantity);

            var actualResult = greaterProduct.CompareTo(smallerProduct);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}