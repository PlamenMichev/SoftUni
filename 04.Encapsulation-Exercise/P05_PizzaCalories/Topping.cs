using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    public class Topping
    {
        public const double DefaultCalories = 2.0;
        public const double Meat = 1.2;
        public const double Veggies = 0.8;
        public const double Cheese = 1.1;
        public const double Sauce = 0.9;

        private string type;
        private double weight;
        private string originalType;

        public Topping(string type, double weight, string originalType)
        {
            this.originalType = originalType;
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (!ValidateType(value))
                {
                    throw new ArgumentException($"Cannot place {this.originalType} on top of your pizza.");
                }
                else
                {
                    this.type = value;
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            private set
            {
                if (!ValidateWeight(value))
                {
                    throw new ArgumentException($"{this.originalType} weight should be in the range [1..50].");
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public bool ValidateWeight(double weight)
        {
            return weight >= 0 && weight <= 50;
        }

        public bool ValidateType(string type)
        {
            List<string> types = new List<string>();
            types.Add("meat");
            types.Add("veggies");
            types.Add("cheese");
            types.Add("sauce");

            return types.Contains(type);
        }

        public double CalculateCalories()
        {
            double sum = 0;

            switch (this.type)
            {
                case "meat":
                    {
                        sum = (DefaultCalories * this.weight) * Meat;
                        break;
                    }
                case "veggies":
                    {
                        sum = (DefaultCalories * this.weight) * Veggies;
                        break;
                    }
                case "cheese":
                    {
                        sum = (DefaultCalories * this.weight) * Cheese;
                        break;
                    }
                case "sauce":
                    {
                        sum = (DefaultCalories * this.weight) * Sauce;
                        break;
                    }
            }

            return sum;
        }
    }
}
