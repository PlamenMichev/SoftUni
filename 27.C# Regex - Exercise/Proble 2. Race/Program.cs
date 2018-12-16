using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Proble_2._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var namesWithPoints = new Dictionary<string, int>();
            foreach (var name in names)
            {
                if (!namesWithPoints.ContainsKey(name))
                {
                    namesWithPoints[name] = 0;
                }
            }
            string letterRegex = @"(?<letters>[A-Za-z])";
            string numberRegex = @"[0-9]";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                string currentWord = "";
                MatchCollection letters = Regex.Matches(input, letterRegex);
                foreach (Match letter in letters)
                {
                    currentWord += letter;
                }
                if (namesWithPoints.ContainsKey(currentWord))
                {
                    int currentScore = 0;
                    MatchCollection numbers = Regex.Matches(input, numberRegex);
                    foreach (Match num in numbers)
                    {
                        currentScore += int.Parse(num.ToString());
                    }

                    namesWithPoints[currentWord] += currentScore;


                }
            }

            var result = namesWithPoints
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            int i = 1;
            foreach (var kvp in result)
            {
                if (i == 1)
                {
                    Console.WriteLine($"{i}st place: {kvp.Key}");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"{i}nd place: {kvp.Key}");
                }
                else
                {
                    Console.WriteLine($"{i}rd place: {kvp.Key}");
                    break;
                }
                i++;
            }
        }
    }
}
