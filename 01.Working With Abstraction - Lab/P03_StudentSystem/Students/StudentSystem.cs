namespace P03_StudentSystem.Students
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        private Dictionary<string, Student> students;
        public StudentSystem()
        {
            this.students = new Dictionary<string, Student>();
        }

        public void Add(string name, int age, double grade)
        {
            if (!this.students.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.students[name] = student;
            }
        }

        public Student Get(string name)
        {
            if (!students.ContainsKey(name))
            {
                throw new InvalidOperationException($"Student with name: '{name}' does not exist!");
            }

            var student = students[name];
            return student;
        }

        public void ParseCommand()
        {
            var commandTokens = Console.ReadLine().Split();
            var commandName = commandTokens[0];

            if (commandName == "Create")
            {
                var name = commandTokens[1];
                var age = int.Parse(commandTokens[2]);
                var grade = double.Parse(commandTokens[3]);

                if (!this.students.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    this.students[name] = student;
                }
            }
            else if (commandName == "Show")
            {
                var name = commandTokens[1];
                if (students.ContainsKey(name))
                {
                    var student = students[name];
                    Console.WriteLine(student);
                }

            }
            else if (commandName == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
