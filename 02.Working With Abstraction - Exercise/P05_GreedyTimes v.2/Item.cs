using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Item
    {
        public Item(string name)
        {
            this.Name = name;
            this.Quantity = 0;
        }

        public long Quantity { get; set; }

        public string Name { get; set; }

        
    }
}
