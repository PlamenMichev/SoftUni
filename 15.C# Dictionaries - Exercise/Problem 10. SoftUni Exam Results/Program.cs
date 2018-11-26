using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            var coursesNamesAndPoints = new Dictionary<string, Dictionary<string, int>>();
            var namesAndPoints = new Dictionary<string,int>();
            var countOfSubmitions = new Dictionary<string,  int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] tokens = input.Split('-');
                if (tokens[1] == "banned")
                {
                    string name = tokens[0];
                    string language = tokens[1];
                    namesAndPoints.Remove(name);
                }
                else
                {
                    string name = tokens[0];
                    string language = tokens[1];
                    int points = int.Parse(tokens[2]);
                    if (!namesAndPoints.ContainsKey(name))
                    {
                        namesAndPoints[name] = points;
                    }
                    if (coursesNamesAndPoints.ContainsKey(language) == false)
                    {
                        coursesNamesAndPoints[language] =  new Dictionary<string, int>();
                        coursesNamesAndPoints[language].Add(name, namesAndPoints[name]);
                    }
                    else
                    {     
                        if (namesAndPoints[name] <= points)
                        {
                            namesAndPoints[name] = points;
                        }
                        coursesNamesAndPoints[language].Remove(name);
                        coursesNamesAndPoints[language].Add(name, namesAndPoints[name]);
                    }
                    
                    if (!countOfSubmitions.ContainsKey(language))
                    {
                        countOfSubmitions[language] = 0;
                    }
                    countOfSubmitions[language]++;
                }
            }

            Console.WriteLine("Results:");
            var result = namesAndPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in result)
            {
               Console.WriteLine($"{kvp.Key} | {kvp.Value}");
     
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in countOfSubmitions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
