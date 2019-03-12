using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
            this.Items = new List<Item>();
        }

        public string Name { get; set; }

        public List<Item> Items { get; set; }

        public long GetSum()
        {
            long sum = 0;
            foreach (var item in Items)
            {
                sum += item.Quantity;
            }

            return sum;
        }

        public bool Contains(string name)
        {
            foreach (var item in Items)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddItem(string name)
        {
            this.Items.Add(new Item(name));
        }

        public Item GetItem(string itemName)
        {
            return this.Items.FirstOrDefault(x => x.Name == itemName);
        }
    }
}
