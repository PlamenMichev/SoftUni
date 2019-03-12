using System;
using System.Collections.Generic;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (!ValidateName(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                if (!ValidateMoney(value))
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.cost = value;
            }
        }

        public bool ValidateName(string name)
        {
            return name != string.Empty;
        }

        public bool ValidateMoney(decimal money)
        {
            return money >= 0;
        }
    }
}
