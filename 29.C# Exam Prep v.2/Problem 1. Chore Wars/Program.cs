using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem_1._Chore_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string dishesRegex = @"(?<=<)([a-z0-9]+)(?=\>)";
            int dishesTime = 0;
            string cleaningRegex = @"(?<=\[)([A-Z0-9]+)(?=])";
            int cleaningTime = 0;
            string laundryRegex = @"(?<={)(.+)(?=})";
            int laundryTime = 0;
            string numbersRegex = @"[0-9]";
            int totalTime = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "wife is happy")
                {
                    break;
                }

                Match currentMatch;
                currentMatch = Regex.Match(input, dishesRegex);
                if (currentMatch.Success)
                {
                    string match = currentMatch.Groups[0].Value;
                    MatchCollection numbers = Regex.Matches(match, numbersRegex);
                    foreach (Match number in numbers)
                    {
                        int currentNumber = int.Parse(number.ToString());
                        dishesTime += currentNumber;
                    }

                }
                else 
                {
                    currentMatch = Regex.Match(input, cleaningRegex);
                    if (currentMatch.Success)
                    {
                        string match = currentMatch.Groups[0].Value;
                        MatchCollection numbers = Regex.Matches(match, numbersRegex);
                        foreach (Match number in numbers)
                        {
                            int currentNumber = int.Parse(number.ToString());
                            cleaningTime += currentNumber;
                        }

                    }
                    else
                    {
                        currentMatch = Regex.Match(input, laundryRegex);
                        if (currentMatch.Success)
                        {
                            string match = currentMatch.Groups[0].Value;
                            MatchCollection numbers = Regex.Matches(match, numbersRegex);
                            foreach (Match number in numbers)
                            {
                                int currentNumber = int.Parse(number.ToString());
                                laundryTime += currentNumber;
                            }

                        }
                    }
                }
                

            }
            Console.WriteLine($"Doing the dishes - {dishesTime} min.");
            Console.WriteLine($"Cleaning the house - {cleaningTime} min.");
            Console.WriteLine($"Doing the laundry - {laundryTime} min.");
            Console.WriteLine($"Total - {dishesTime + cleaningTime + laundryTime} min. ");
        }
    }
}
