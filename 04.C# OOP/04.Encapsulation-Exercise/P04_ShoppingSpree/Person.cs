using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> bag;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.Bag = new List<string>();
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

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (!ValidateMoney(value))
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public List<string> Bag
        {
            get => this.bag;
            private set => this.bag = value;
        }


        public bool CanBuy(Product product)
        {
            return this.money - product.Cost >= 0;
        }

        public void Buy(Product product)
        {
            this.money -= product.Cost;
            this.bag.Add(product.Name);
        }


        public bool ValidateName(string name)
        {
            return name != " " && name != null && name != string.Empty;
        }

        public bool ValidateMoney(decimal money)
        {
            return money >= 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.bag.Any() ? $"{this.name} - { string.Join(", ", this.bag)}" : $"{this.name} - Nothing bought");
            return sb.ToString();
        }
    }
}
