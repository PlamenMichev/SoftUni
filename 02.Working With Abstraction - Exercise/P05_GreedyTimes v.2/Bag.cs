using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Contains(string categoryType)
        {
            foreach (var item in Categories)
            {
                if (item.Name == categoryType)
                {
                    return true;
                }
            }

            return false;
        }

        public Category GetCategory(string name)
        {
            return Categories.FirstOrDefault(x => x.Name == name);
        }

        public void Add(string categoryName)
        {
            Categories.Add(new Category(categoryName));
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
