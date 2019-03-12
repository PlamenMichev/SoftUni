using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Bag
    {
        public Bag()
        {
            this.Categories = new List<Category>();
        }

        public List<Category> Categories { get; private set; }

        public bool Contains(string categoryName)
        {
            foreach (var category in Categories)
            {
                if (category.Name == categoryName)
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(string categoryName) => this.Categories.Add(new Category(categoryName));

        public Category GetCategory(string categoryName)
        {
            foreach (var category in Categories)
            {
                if (category.Name == categoryName)
                {
                    return category;
                }
            }

            return null;
        }

        public long GetBagSum()
        {
            long sum = 0;
            foreach (var category in Categories)
            {
                sum += category.GetSum();
            }

            return sum;
        }
    }
}