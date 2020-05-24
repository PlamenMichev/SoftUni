using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                var person = new Person("hambar");
                if (people.Any(x => x.Name == name))
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (people[i].Name == name)
                        {
                            person = people[i];
                            break;
                        }
                    }
                }
                else
                {
                    people.Add(new Person(name));
                }


                if (tokens.Length == 5)
                {
                    var currentCompany = new Company(tokens[2], tokens[3], double.Parse(tokens[4]));
                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Company = currentCompany;
                }

                if (tokens.Length == 4 && tokens[1] == "pokemon")
                {
                    string pokemonName = tokens[2];
                    string pokemonType = tokens[3];
                    var currentPokemon = new Pokemon(pokemonName, pokemonType);
                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Pokemons.Add(currentPokemon);
                }

                if (tokens.Length == 4 && tokens[1] == "parents")
                {
                    string parentName = tokens[2];
                    string parentBirthday = tokens[3];
                    var currentParent = new Parent(parentName, parentBirthday);
                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Parents.Add(currentParent);
                }

                if (tokens.Length == 4 && tokens[1] == "children")
                {
                    string childName = tokens[2];
                    string childBirthday = tokens[3];
                    var currentChild = new Child(childName, childBirthday);
                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Children.Add(currentChild);
                }

                if (tokens.Length == 4 && tokens[1] == "car")
                {
                    string carModel = tokens[2];
                    int carSpeed = int.Parse(tokens[3]);
                    var currentCar = new Car(carModel, carSpeed);
                    var currentPerson = people.First(x => x.Name == name);
                    currentPerson.Car = currentCar;
                }
            }

            string nameToOutput = Console.ReadLine();

            Console.WriteLine(string.Join(Environment.NewLine, people.First(x => x.Name == nameToOutput)));
        }
    }
}
