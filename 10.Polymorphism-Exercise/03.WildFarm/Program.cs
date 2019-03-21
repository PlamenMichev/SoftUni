using _03.WildFarm.Factories;
using _03.WildFarm.Food_Hierarchy;
using _03.WildFarm.Models.Animal_Hierarchy;
using _03.WildFarm.Models.Animal_Hierarchy.Mammals.Felines;
using System;
using System.Collections.Generic;

namespace _03.WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            FoodFactory foodFactory = new FoodFactory();
            AnimalFactory animalFactory = new AnimalFactory();
            List<Animal> animals = new List<Animal>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] animalArgs = input
                    .Split();

                string[] foodArgs = Console.ReadLine()
                    .Split();

                string foodType = foodArgs[0];
                int foodWeight = int.Parse(foodArgs[1]);

                Food food = foodFactory.Create(foodType, foodWeight);
                Animal animal = animalFactory.Create(animalArgs);

                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(foodType, foodWeight);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);
                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
