namespace P05_PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] pizzaInput = Console.ReadLine().Split();
            string[] inputDough = Console.ReadLine().Split();
            string[] inputTopping = Console.ReadLine().Split();
            try
            {
                string flourType = inputDough[1].ToLower();
                string bakingTechnique = inputDough[2].ToLower();
                double weight = double.Parse(inputDough[3]);
                var dough = new Dough(flourType, bakingTechnique, weight);

                string originalType = inputTopping[1];
                string type = inputTopping[1].ToLower();
                double toppingWeight = double.Parse(inputTopping[2]);
                var topping = new Topping(type, toppingWeight, originalType);

                string name = pizzaInput[1];
                var pizza = new Pizza(name, dough);
                pizza.AddTopping(topping);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] tokens = input.Split();
                    originalType = tokens[1];
                    type = tokens[1].ToLower();
                    toppingWeight = double.Parse(tokens[2]);
                    var currentTopping = new Topping(type, toppingWeight, originalType);
                    pizza.AddTopping(currentTopping);
                    input = Console.ReadLine();
                }
                double calories = pizza.CalculateCalories();
                Console.WriteLine($"{pizza.Name} - {calories:f2} Calories.".Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
