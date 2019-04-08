using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.FoodOrders = new List<IFood>();
            this.DrinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }

        public IReadOnlyCollection<IFood> FoodOrders
        {
            get => this.foodOrders;
            private set
            {
                this.foodOrders = new List<IFood>();
            }
        }

        public IReadOnlyCollection<IDrink> DrinkOrders
        {
            get => this.drinkOrders;
            private set
            {
                this.drinkOrders = new List<IDrink>();
            }
        }

        public int TableNumber { get; set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; set; }

        public bool IsReserved { get; set; }

        public decimal Price
        {
            get => this.NumberOfPeople * this.PricePerPerson;
            private set
            {

            }
        }

        public void Clear()
        {
            this.FoodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();
            this.IsReserved = false;
            this.NumberOfPeople = 1;
        }

        public decimal GetBill()
        {
            decimal bill = 0m;
            foreach (var foodOrder in foodOrders)
            {
                bill += foodOrder.Price;
            }

            foreach (var drink in drinkOrders)
            {
                bill += drink.Price;
            }

            bill += Price;

            return bill;
        }

        public virtual string GetFreeTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine("Type: {0}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        public virtual string GetOccupiedTableInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine("Type: {0}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            if (this.foodOrders.Count == 0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
            }

            foreach (var foodOrder in foodOrders)
            {
                sb.AppendLine(foodOrder.ToString());
            }

            if (this.drinkOrders.Count == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
            }

            foreach (var drink in drinkOrders)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
