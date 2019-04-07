using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine
    {
        private AnimalCentre animalCentre = new AnimalCentre();

        public void Run()
        {
            string input = Console.ReadLine();


            while (input != "End")
            {
                try
                {
                    string[] tokens = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = tokens[0];

                    if (command == "RegisterAnimal")
                    {
                        string type = tokens[1];
                        string name = tokens[2];
                        int energy = int.Parse(tokens[3]);
                        int happiness = int.Parse(tokens[4]);
                        int procedureTime = int.Parse(tokens[5]);

                        Console.WriteLine(animalCentre.RegisterAnimal(type, name, energy, happiness, procedureTime));
                    }
                    else if (command == "History")
                    {
                        string type = tokens[1];

                        Console.WriteLine(animalCentre.History(type));
                    }
                    else if (command == "Adopt")
                    {
                        string animalName = tokens[1];
                        string owner = tokens[2];

                        Console.WriteLine(animalCentre.Adopt(animalName, owner));
                    }
                    else
                    {
                        string name = tokens[1];
                        int time = int.Parse(tokens[2]);

                        if (command == "Vaccinate")
                        {
                            Console.WriteLine(animalCentre.Vaccinate(name, time));
                        }
                        else if (command == "Fitness")
                        {
                            Console.WriteLine(animalCentre.Fitness(name, time));

                        }
                        else if (command == "Play")
                        {
                            Console.WriteLine(animalCentre.Play(name, time));
                        }
                        else if (command == "DentalCare")
                        {
                            Console.WriteLine(animalCentre.DentalCare(name, time));

                        }
                        else if (command == "NailTrim")
                        {
                            Console.WriteLine(animalCentre.NailTrim(name, time));
                        }
                        else if (command == "Chip")
                        {
                            Console.WriteLine(animalCentre.Chip(name, time));
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(animalCentre.ShowAdoptedAnimals());
        }

    }
}

