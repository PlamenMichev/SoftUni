using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Students
{
    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                Student currentStudent = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(currentStudent);
            }

            foreach (var student in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
}
