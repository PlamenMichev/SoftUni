using System;
using System.Collections.Generic;
using System.Text;

namespace P05_PizzaCalories
{
    public class Dough
    {
        public const double DefaultCalories = 2.0;
        public const double White = 1.5;
        public const double Wholegrain = 1.0;
        public const double Crispy = 0.9;
        public const double Chewy = 1.1;
        public const double Homemade = 1.0;

        private string flourType;
        private string bakingTechnique;
        public double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        } 

        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (ValidateFlour(value))
                {
                    this.flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;
            private set
            {
                if (ValidateTechnique(value))
                {
                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public double Weight
        {
            get => this.weight;
            set
            {
                if (ValidateWeight(value))
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double CaloriesPerGram
        {
            get => this.CalculateCalories() / weight;
            private set
            {

            }
        }

        public double CalculateCalories()
        {
            double sum = 0;
            switch (this.flourType)
            {
                case "white":
                    {
                        sum = (DefaultCalories * this.weight) * White;
                        break;
                    }
                case "wholegrain":
                    {
                        sum = (DefaultCalories * this.weight) * Wholegrain;
                        break;
                    }

            }

            switch (this.bakingTechnique)
            {
                case "crispy":
                    {
                        sum *= Crispy;
                        break;
                    }
                case "chewy":
                    {
                        sum *= Chewy;
                        break;
                    }
                case "homemade":
                    {
                        sum *= Homemade;
                        break;
                    }
            }

            return sum;
        }

        public bool ValidateFlour(string name)
        {
            List<string> names = new List<string>();
            names.Add("white");
            names.Add("wholegrain");
            return names.Contains(name);
        }

        public bool ValidateTechnique(string name)
        {
            List<string> names = new List<string>();
            names.Add("crispy");
            names.Add("chewy");
            names.Add("homemade");

            return names.Contains(name);
        }

        public bool ValidateWeight(double weight)
        {
            return weight >= 1 && weight <= 200;
        }
    }
}
