using System;
using System.Collections.Generic;

namespace Problem_5._Students
{
    class Program
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Hometown { get; set; }

            
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string town = tokens[3];
                Student currentStudent = new Student();
                if (!IsExisting(students, firstName, lastName))
                {
                    currentStudent = GetStudent(students, firstName, lastName);

                    currentStudent.FirstName = firstName;
                    currentStudent.LastName = lastName;
                    currentStudent.Age = age;
                    currentStudent.Hometown = town;

                }
                else
                {
                    currentStudent.FirstName = firstName;
                    currentStudent.LastName = lastName;
                    currentStudent.Age = age;
                    currentStudent.Hometown = town;

                    students.Add(currentStudent);

                }
                
                
            }

            string townToOutput = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.Hometown == townToOutput)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;
            foreach (var student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        static bool IsExisting(List<Student> students, string firtsName, string lastName)
        {
            foreach (var student in students)
            {
                if (student.FirstName == firtsName && student.LastName == lastName)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
