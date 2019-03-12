using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
            this.dough = dough;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (!ValidateName(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public int CountOfToppings
        {
            get => this.toppings.Count();
            private set
            {
            }
        }

        public double Calories
        {
            get
            {
                return CalculateCalories();
            }
            private set
            {

            }
        }

        public double CalculateCalories()
        {
            double sum = 0;
            foreach (var topping in toppings)
            {
                sum += topping.CalculateCalories();
            }

            sum += this.dough.CalculateCalories();

            return sum;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            else
            {
                toppings.Add(topping);
            }
        }

        public bool ValidateName(string name)
        {
            return name.Length >= 1 && name.Length <= 15;
        }
    }
}
