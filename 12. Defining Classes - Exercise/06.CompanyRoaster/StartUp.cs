using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var currentEmployee = new Employee();
                if (input.Length == 6)
                {
                    string name = input[0];
                    decimal salary = decimal.Parse(input[1]);
                    string position = input[2];
                    string department = input[3];
                    string email = input[4];
                    int age = int.Parse(input[5]);

                    currentEmployee = new Employee(name, salary, position, department, email, age);
                }

                if (input.Length == 5)
                {
                    string name = input[0];
                    decimal salary = decimal.Parse(input[1]);
                    string position = input[2];
                    string department = input[3];


                    if (input[4].Contains('@'))
                    {
                        string email = input[4];
                        currentEmployee = new Employee(name, salary, position, department, email);
                    }
                    else
                    {
                        int age = int.Parse(input[4]);
                        currentEmployee = new Employee(name, salary, position, department, age);
                    }

                }

                if (input.Length == 4)
                {
                    string name = input[0];
                    decimal salary = decimal.Parse(input[1]);
                    string position = input[2];
                    string department = input[3];

                    currentEmployee = new Employee(name, salary, position, department);
                }

                employees.Add(currentEmployee);
            }

            string highestSalaryDev = BiggestAverage(employees);
            Console.WriteLine($"Highest Average Salary: {highestSalaryDev}");
            foreach (var employee in employees.Where(x => x.Department == highestSalaryDev).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
        public static string BiggestAverage(List<Employee> employees)
        {
            decimal biggestAvgSalary = 0;
            string biggestDev = "";
            Dictionary<string, List<decimal>> avgSalaries = new Dictionary<string, List<decimal>>();

            foreach (var employee in employees)
            {
                if (!avgSalaries.ContainsKey(employee.Department))
                {
                    avgSalaries[employee.Department] = new List<decimal>();
                }

                avgSalaries[employee.Department].Add(employee.Salary);
            }

            foreach (var kvp in avgSalaries)
            {
                var salaries = kvp.Value;

                decimal currentAvg = salaries.Average();
                if (currentAvg > biggestAvgSalary)
                {
                    biggestDev = kvp.Key;
                    biggestAvgSalary = currentAvg;
                }
            }

            return biggestDev;
        }
    }
}