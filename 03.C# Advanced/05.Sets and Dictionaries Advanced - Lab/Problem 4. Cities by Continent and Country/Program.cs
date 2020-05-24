using System;
using System.Collections.Generic;

namespace Problem_4._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = input[0];
                string country = input[1];
                string city = input[2];
                if (!continents.ContainsKey(continent))
                {
                    continents[continent] = new Dictionary<string, List<string>>();
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent][country] = new List<string>();
                }
                continents[continent][country].Add(city);
            }

            foreach (var kvp in continents)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var countries in kvp.Value)
                {
                    Console.WriteLine($"{countries.Key} -> {string.Join(", ", countries.Value)}");
                }
            }
        }
    }
}
