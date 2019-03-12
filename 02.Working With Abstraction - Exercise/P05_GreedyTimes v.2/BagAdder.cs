using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class BagAdder
    {
        private string itemName;
        private string category;
        private long quantity;
        private long maxCapacity;
        private Bag bag;

        public BagAdder(string itemName, string category, long count, long maxCapacity, Bag bag)
        {
            this.itemName = itemName;
            this.category = category;
            this.quantity = count;
            this.maxCapacity = maxCapacity;
            this.bag = bag;
        }

        public void Add(Bag bag)
        {
            if (itemName.Length == 3)
            {
                category = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                category = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                category = "Gold";
            }

            if (category == "" || maxCapacity < bag.GetBagSum() + quantity)
            {
                return;
            }

            switch (category)
            {
                case "Gem":
                    if (!bag.Contains(category))
                    {
                        if (bag.Contains("Gold"))
                        {
                            if (quantity > bag.GetCategory("Gold").GetSum())
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (bag.GetCategory(category).GetSum() + quantity > bag.GetCategory("Gold").GetSum())
                    {
                        return;
                    }
                    break;
                case "Cash":
                    if (!bag.Contains(category))
                    {
                        if (bag.Contains("Gem"))
                        {
                            if (quantity > bag.GetCategory("Gem").GetSum())
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (bag.GetCategory(category).GetSum() + quantity > bag.GetCategory("Gem").GetSum())
                    {
                        return;
                    }
                    break;
            }

            if (!bag.Contains(category))
            {
                bag.Add(category);
            }

            if (!bag.GetCategory(category).Contains(itemName))
            {
                bag.GetCategory(category).AddItem(itemName);
                bag.GetCategory(category).GetItem(itemName).Quantity = 0;
            }

            bag.GetCategory(category).GetItem(itemName).Quantity += quantity;
        }
    }
}
