using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    class BagAdder
    {
        private string itemName;

        private long quantity;

        private string categoryType;

        private long maxCapacity;

        private Bag bag;

        public BagAdder(string itemName, long quantity, string categoryType, long maxCapacity, Bag bag)
        {
            this.itemName = itemName;
            this.quantity = quantity;
            this.categoryType = categoryType;
            this.maxCapacity = maxCapacity;
            this.bag = bag;
        }

        public void Add(Bag bag)
        {
            if (itemName.Length == 3)
            {
                categoryType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                categoryType = "Gem";
            }
            else if (itemName.ToLower() == "gold")
            {
                categoryType = "Gold";
            }

            if (categoryType == "" || maxCapacity < bag.GetBagSum() + quantity)
            {
                return;
            }

            switch (categoryType)
            {
                case "Gem":
                    if (!bag.Contains(categoryType))
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
                    else if (bag.GetCategory(categoryType).GetSum() + quantity > bag.GetCategory("Gold").GetSum())
                    {
                        return;
                    }
                    break;
                case "Cash":
                    if (!bag.Contains(categoryType))
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
                    else if (bag.GetCategory(categoryType).GetSum() + quantity > bag.GetCategory("Gem").GetSum())
                    {
                        return;
                    }
                    break;
            }

            if (!bag.Contains(categoryType))
            {
                bag.Add(categoryType);
            }
            if (!bag.GetCategory(categoryType).Contains(itemName))
            {
                bag.GetCategory(categoryType).AddItem(itemName);
                bag.GetCategory(categoryType).GetItem(itemName).Quantity = 0;
            }

            bag.GetCategory(categoryType).GetItem(itemName).Quantity += quantity;
        }
    }
}