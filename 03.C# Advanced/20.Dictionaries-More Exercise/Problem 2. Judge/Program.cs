using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_2._Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "no more time")
                {
                    break;
                }

                string[] tokens = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string username = tokens[0];
                string contest = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests[contest] = new Dictionary<string, int>();
                }

                if (!contests[contest].ContainsKey(username))
                {
                    contests[contest][username] = 0;
                }

                if (contests[contest][username] < points)
                {
                    contests[contest][username] = points;
                }
            }

            foreach (var kvp in contests)
            {
                int count = kvp.Value.Count;
                Console.WriteLine($"{kvp.Key}: {count} participants");
                int i = 1;
                foreach (var Kvp in kvp.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{i}. {Kvp.Key} <::> {Kvp.Value}");
                    i++;
                }
            }
            var maxPoints = new Dictionary<string, int>();
            foreach (var kvp in contests)
            {
                foreach (var Kvp in kvp.Value)
                {
                    if (!maxPoints.ContainsKey(Kvp.Key))
                    {
                        maxPoints[Kvp.Key] = 0;
                    }
                    maxPoints[Kvp.Key] += Kvp.Value;
                }
            }
            
            Console.WriteLine($"Individual standings:");     
            int j = 1;
            foreach (var kvp in maxPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ThenBy(x => x))
            {
                    Console.WriteLine($"{j}. {kvp.Key} -> {kvp.Value}");
                    j++;
                
            }
        }
    }
}
