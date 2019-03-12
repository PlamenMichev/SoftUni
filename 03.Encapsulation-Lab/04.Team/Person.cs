using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;

        private string lastName;

        private int age;

        private decimal salary;

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += Salary * percentage / 100;
            }
            else
            {
                this.Salary += Salary * percentage / 200;
            }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (ValidateName(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException($"First name cannot contain fewer than 3 symbols!");
                }
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if (ValidateName(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException($"Last name cannot contain fewer than 3 symbols!”");
                }
            }
        }
        public int Age
        {
            get => this.age;
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentException($"Age cannot be zero or a negative integer!");
                }
            }
        }

        public decimal Salary
        {
            get => this.salary;
            set
            {
                if (value >= 460.00m)
                {
                    this.salary = value;
                }
                else
                {
                    throw new ArgumentException($"Salary cannot be less than 460 leva!");
                }
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }

        public bool ValidateName(string name)
        {
            return name.Length >= 3;
        }
    }
}