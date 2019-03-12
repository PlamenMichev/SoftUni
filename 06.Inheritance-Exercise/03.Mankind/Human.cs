using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                if (value[0] < 'A' || value[0] > 'Z')
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                else if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                if (value[0] < 'A' || value[0] > 'Z')
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                else if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                this.lastName = value;
            }
        }
    }
}
