using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace _12.Google
{
    public class Person
    {
        public string Name { get; set; }

        public Car Car { get; set; }

        public Company Company { get; set; }

        private List<Parent> parents = new List<Parent>();

        private List<Child> children = new List<Child>();

        public List<Pokemon> pokemons = new List<Pokemon>();

        public List<Parent> Parents
        {
            get => this.parents;
            set => this.parents = value;
        }

        public List<Child> Children
        {
            get => this.children;
            set => this.children = value;
        }

        public List<Pokemon> Pokemons
        {
            get => this.pokemons;
            set => this.pokemons = value;
        }

        public Person(string name, Car car, Parent parent, Child child, Pokemon pokemon, Company company)
        {
            this.Name = name;
            this.Car = car;
            this.Parents.Add(parent);
            this.Children.Add(child);
            this.Pokemons.Add(pokemon);
            this.Company = company;
        }

        public Person(string name) 
            : this(name, new Car(), new Parent(), new Child(), new Pokemon(), new Company())
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}");
            sb.AppendLine(this.Company.Name == ""
                ? $"Company:"
                : $"Company: {this.Company}");
            sb.AppendLine($"Car: {this.Car}");
            sb.AppendLine($"Pokemon: {string.Join("", this.Pokemons)}");
            sb.AppendLine($"Parents: {string.Join("", this.Parents)}");
            sb.Append($"Children:{string.Join("", this.Children)}");

            return sb.ToString().Trim();
        }
    }
}
