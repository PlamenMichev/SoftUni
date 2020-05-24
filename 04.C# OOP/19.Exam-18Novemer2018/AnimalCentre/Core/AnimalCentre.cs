using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotels;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        private IDictionary<string, List<IAnimal>> addoptedAnimals;
        private Hotel hotel;
        private Chip chip;
        private Vaccinate vaccinate;
        private Fitness fitness;
        private Play play;
        private DentalCare dentalCare;
        private NailTrim nailTrim;

        public AnimalCentre()
        {
            this.chip = new Chip();
            this.vaccinate = new Vaccinate();
            this.fitness = new Fitness();
            this.play = new Play();
            this.dentalCare = new DentalCare();
            this.nailTrim = new NailTrim();
            this.addoptedAnimals = new Dictionary<string, List<IAnimal>>();
            this.hotel = new Hotel();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal newAnimal = null;
            switch (type)
            {
                case "Lion":
                    newAnimal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    newAnimal = new Pig(name, energy, happiness, procedureTime);
                    break;
                case "Cat":
                    newAnimal = new Cat(name, energy, happiness, procedureTime);
                    break;
            }

            this.hotel.Accommodate(newAnimal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            chip.DoService(animal, procedureTime);

            return $"{name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            vaccinate.DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            fitness.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            play.DoService(animal, procedureTime);

            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            dentalCare.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animal = this.hotel
                .Animals
                .Values
                .First(x => x.Name == name);

            nailTrim.DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            var animal = this.hotel
                .Animals
                .Values
                .FirstOrDefault(x => x.Name == animalName);

            if (animal == null)
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            this.hotel.Adopt(animalName, owner);

            if (!addoptedAnimals.ContainsKey(owner))
            {
                this.addoptedAnimals[owner] = new List<IAnimal>();
            }

            this.addoptedAnimals[owner].Add(animal);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            IProcedure procedure = null;

            switch (type)
            {
                case "Chip":
                    procedure = chip; break;
                case "Vaccinate":
                    procedure = vaccinate; break;
                case "Fitness":
                    procedure = fitness; break;
                case "Play":
                    procedure = play; break;
                case "DentalCare":
                    procedure = dentalCare; break;
                case "NailTrim":
                    procedure = nailTrim; break;

            }

            return procedure.History();
        }

        public string ShowAdoptedAnimals()
        {
            var sb = new StringBuilder();

            foreach (var owner in addoptedAnimals.OrderBy(x => x.Key))
            {
                sb.AppendLine($"--Owner: {owner.Key}");
                sb.Append($"    - Adopted animals: ");
                foreach (var animal in owner.Value)
                {
                    sb.Append($"{animal.Name} ");
                }

                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
