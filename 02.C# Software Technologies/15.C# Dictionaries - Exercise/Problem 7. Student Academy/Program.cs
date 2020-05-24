using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();
            var grades = new List<double>();
            for (int i = 1; i <= length; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<double>());
                }
                students[studentName].Add(studentGrade);
            }

            var result = students
                .Where(kvp => kvp.Value.Average() >= 4.50)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            var averageResult = result.OrderByDescending(kvp => kvp.Value.Average());
            foreach (var student in averageResult)
            {
                double averageGrade = student.Value.Average();
                
                Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
            }

        }
    }
}
