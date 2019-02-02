using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var grades = new Dictionary<string, List<double>>();

            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                double grade = double.Parse(input[1]);
                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<double>();
                }
                grades[name].Add(grade);
            }
            foreach (var kvp in grades)
            {
                Console.Write($"{kvp.Key} ->");
                foreach (var value in kvp.Value)
                {
                    Console.Write($" {value:f2}");
                }

                Console.Write($" (avg: {kvp.Value.Average():f2})");
                Console.WriteLine();
            }
        }
    }
}
