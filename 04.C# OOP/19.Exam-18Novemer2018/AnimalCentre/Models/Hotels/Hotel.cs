using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Hotels
{
    public class Hotel : IHotel
    {
        private Dictionary<string, IAnimal> animals;
        private int capacity;

        public Hotel()
        {
            this.Capacity = 10;
            this.animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => this.animals;
        }

        public void Accommodate(IAnimal animal)
        {
            if (this.Capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (this.Animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
            this.Capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!this.Animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            IAnimal animal = Animals
                .Select(x => x.Value)
                .First(x => x.Name == animalName);

            animal.Owner = owner;
            animal.IsAdopt = true;
            this.animals.Remove(animalName);
        }
    }
}
