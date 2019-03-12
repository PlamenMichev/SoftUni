using System;
using System.Collections.Generic;
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

        public string Name { get; private set; }

        public List<Item> Items { get; private set; }

        public bool Contains(string itemName)
        {
            foreach (var item in Items)
            {
                if (item.Name == itemName)
                {
                    return true;
                }
            }

            return false;
        }

        public long GetSum()
        {
            long sum = 0;
            foreach (var item in Items)
            {
                sum += item.Quantity;
            }

            return sum;
        }

        public Item GetItem(string itemName)
        {
            foreach (var item in Items)
            {
                if (item.Name == itemName)
                {
                    return item;
                }
            }

            return null;
        }

        public void AddItem(string name) => this.Items.Add(new Item(name));
    }
}