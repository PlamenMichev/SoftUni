using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            var courses = new Dictionary<string, List<string>>();
            
            while (true)
            {
                string[] input = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "end")
                {
                    break;
                }

                string course = input[0];
                string student = input[1];
                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(student);
            }

            var result = courses
                .OrderByDescending(kvp => kvp.Value.Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            foreach (var kvp in result)
            {
                
                    var students = kvp.Value.OrderBy(x =>x);               
                    Console.WriteLine($"{kvp.Key}: {kvp.Value.Count} \n-- {string.Join("\n-- ", students)}");
            }
        }
    }
}
