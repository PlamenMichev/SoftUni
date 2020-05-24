using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private IProduct[] products;
        private const int initialSize = 4;

        public ProductStock()
        {
            this.products = new IProduct[initialSize];
        }

        public IProduct this[int index]
        {
            get
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                return this.products[index];
            }
            set
            {
                if (index > this.Count || index < 0)
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                this.products[index] = value;
            }
        }

        public int Count { get; set; }

        public int Capacity
            => this.products.Length;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new InvalidOperationException("Product cannot be null!");
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (products[i].CompareTo(product) == 0)
                {
                    products[i].Quantity += product.Quantity;
                    return;
                }
            }

            if (products.Length == this.Count)
            {
                this.Resize();
            }

            products[this.Count++] = product;
        }

        public bool Contains(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.products[i] == product)
                {
                    this.products[i] = null;
                    this.Reorder(i);
                    this.Count--;

                    if (this.Count == this.Capacity / 2)
                    {
                        this.Shrink();
                    }

                    return true;
                }
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private void Resize()
        {
            int newArrayCapacity = this.Capacity * 2;
            var tempArray = new IProduct[newArrayCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }

        private void Shrink()
        {
            int newArrayCapacity = this.Capacity / 2;
            var tempArray = new IProduct[newArrayCapacity];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }

        private void Reorder(int i)
        {
            for (int j = i; j < this.Count - 1; j++)
            {
                this.products[j] = this.products[j + 1];
            }
        }

    }
}
