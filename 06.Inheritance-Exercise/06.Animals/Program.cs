using System;
using System.Collections.Generic;

namespace _06.Animals
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Animal> animals = new List<Animal>();
            while (input != "Beast!")
            {
                try
                {
                    string typeOfAnimal = input;
                    string[] animalTokens = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (animalTokens.Length != 3)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string name = animalTokens[0];

                    if (!int.TryParse(animalTokens[1], out int age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    string gender = animalTokens[2];

                    var animal = GetAnimalType(name, age, gender, typeOfAnimal);
                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
                Console.WriteLine(animal.ProduceSound());
            }
        }

        public static Animal GetAnimalType(string name, int age, string gender, string type)
        {
            switch (type)
            {
                case "Cat": return new Cat(name, age, gender, type);
                case "Dog": return new Dog(name, age, gender, type);
                case "Frog": return new Frog(name, age, gender, type);
                case "Kitten": return new Kitten(name, age, gender, type);
                case "Tomcat": return new Tomcat(name, age, gender, type);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }
}
