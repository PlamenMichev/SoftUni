using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Trainer> trainers = new HashSet<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Tournament")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);
                var currentPokemon = new Pokemon(pokemonName, element, health);
                pokemons.Add(currentPokemon);
                if (trainers.Where(x => x.Name == trainerName).ToList().Count > 0)
                {
                    var trainer = trainers.First(x => x.Name == trainerName);
                    trainer.Pokemons.Add(currentPokemon);
                }
                else
                {
                    trainers.Add(new Trainer(trainerName, 0, currentPokemon));
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                if (input == "Water")
                {
                    trainers = ValidateElements(trainers, "Water");
                }

                if (input == "Fire")
                {
                    trainers = ValidateElements(trainers, "Fire");
                }

                if (input == "Electricity")
                {
                    trainers = ValidateElements(trainers, "Electricity");
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }

        }

        public static HashSet<Trainer> ValidateElements(HashSet<Trainer> trainers, string criteria)
        {
            foreach (var trainer in trainers)
            {
                bool isValid = false;
                List<Pokemon> currentPokemons = trainer
                    .Pokemons
                    .ToList();
                foreach (var pokemon in currentPokemons)
                {
                    if (pokemon.Element == criteria)
                    {
                        isValid = true;
                    }
                }

                if (isValid)
                {
                    trainer.NumberOfBadges++;
                }

                else
                {
                    foreach (var pokemon in currentPokemons)
                    {
                        pokemon.Health -= 10;
                        if (pokemon.Health <= 0)
                        {
                            trainer.Pokemons.RemoveAll(x => x.Name == pokemon.Name);
                        }
                    }
                }
            }

            return trainers;
        }
    }
}
