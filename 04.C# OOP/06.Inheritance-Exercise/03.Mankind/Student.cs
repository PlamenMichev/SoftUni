using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => this.facultyNumber;
            private set
            {
                if ((value.Length <= 5 || value.Length >= 10) || !CheckFacultyNumber(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public bool CheckFacultyNumber(string number)
        {
            foreach (var item in number)
            {
                if (!(char.IsDigit(item) || char.IsLetter(item)))
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {base.FirstName}");
            sb.AppendLine($"Last Name: {base.LastName}");
            sb.Append($"Faculty number: {this.facultyNumber}");

            return sb.ToString();
        }
    }
}
