using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals
{
    public abstract class Animal
    {
        private string type;
        private string name;
        private int age;
        private string gender;

        public Animal(string name, int age, string gender, string type)
        {
            this.Name = name;
            this.Age = age;
            this.gender = gender;
            this.type = type;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.name = value;
            }
        }

        protected int Age
        {
            get => this.age;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            }
        }

        protected string Gender
        {
            get => this.gender;
            set
            {
                if (value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }

        public string Type
        {
            get => this.type;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.type}" + Environment.NewLine + $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
