using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHours;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHours) 
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHours = workHours;
        }

        public decimal WeekSalary
        {
            get => this.weekSalary;
            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHours
        {
            get => this.workHours;
            protected set
            {
                if (value <= 1 || value >= 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workHours = value;
            }
        }
        
        private decimal CalculateSalaryPerHour()
        {
            decimal salaryPerHour = 0;
            decimal salaryPerDay = this.weekSalary / 5;

            salaryPerHour = salaryPerDay / (decimal)this.workHours;

            return salaryPerHour;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {base.FirstName}");
            sb.AppendLine($"Last Name: {base.LastName}");
            sb.AppendLine($"Week Salary: {this.weekSalary:f2}");
            sb.AppendLine($"Hours per day: {this.workHours:f2}");
            sb.Append($"Salary per hour: {CalculateSalaryPerHour():f2}");

            return sb.ToString();
        }
    }
}
