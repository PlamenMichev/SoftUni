namespace MuOnline.Models.Inventories
{
    using Contracts;
    using Items.Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IInventory
    {
        private readonly List<IItem> items;

        public IReadOnlyCollection<IItem> Items =>
            this.items.AsReadOnly();

        public Inventory()
        {
            this.items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            items.Add(item);
        }

        public bool RemoveItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            bool isRemove = items.Remove(item);

            return isRemove;
        }

        public IItem GetItem(string item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            var targetItem = this.items
                .FirstOrDefault(i => i.GetType().Name == item);

            return targetItem;
        }
    }
}
