﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Person
{
    public class Person
    {
        private string name;
        private int age;

       public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        protected string Name
        {
            get => this.name;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!");
                }

                this.name = value;
            }
        }

        protected virtual int Age
        {
            get => this.age;
            set
            {
                if (!ValidateAge(value))
                {
                    throw new ArgumentException("Age must be positive!");
                }

                this.age = value;
            }
        }

        public bool ValidateAge(int age)
        {
            return age > 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();

        }
    }
}
