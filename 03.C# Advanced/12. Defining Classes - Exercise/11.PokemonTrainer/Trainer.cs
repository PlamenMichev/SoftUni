using System;
using System.Collections.Generic;
using System.Text;

namespace _11.PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        private List<Pokemon> pokemons = new List<Pokemon>();

        public List<Pokemon> Pokemons
        {
            get => this.pokemons;
            set => this.pokemons = value;
        }

        public Trainer()
        {
        }

        public Trainer(string name, int numberOfBadges, Pokemon pokemon)
        {
            this.Name = name;
            this.NumberOfBadges = numberOfBadges;
            this.Pokemons.Add(pokemon);
        }
    }
}
