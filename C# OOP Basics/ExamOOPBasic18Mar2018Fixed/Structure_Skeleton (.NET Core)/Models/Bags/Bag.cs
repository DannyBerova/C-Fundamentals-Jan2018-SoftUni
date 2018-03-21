using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private int capacity;
        private readonly List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items => items.AsReadOnly();

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public void AddItem(Item item)
        {
            if ((this.items.Sum(i => i.Weight) + item.Weight) > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.Add(item);
        }

        public Item GetItem(string itemName)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var searchedItem = this.Items.FirstOrDefault(i => i.Name == itemName);
            if (searchedItem == null)
            {
                throw new ArgumentException($"No item with name {itemName} in bag!");
            }

            this.items.Remove(searchedItem);
            return searchedItem;
        }
    }
}
