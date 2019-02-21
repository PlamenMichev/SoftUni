using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace Problem_1._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictOfContests = new Dictionary<string, string>();
            var contestWithPoInts = new Dictionary<string, int>();
            var usersWithContests = new Dictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }

                string[] tokens = input
                    .Split(":")
                    .ToArray();
                string contest = tokens[0];
                string passwordForTheContest = tokens[1];

                dictOfContests[contest] = passwordForTheContest;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }
                string[] tokens = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                
                if (dictOfContests.ContainsKey(contest) && (dictOfContests[contest] == password))
                {
                    if (!(usersWithContests.ContainsKey(username)))
                    {
                        contestWithPoInts[contest] = points;
                        usersWithContests[username] = new Dictionary<string, int>();
                        usersWithContests[username][contest] = points;
                    }
                    else if (!usersWithContests[username].ContainsKey(contest))
                    {
                        contestWithPoInts[contest] = points;
                        usersWithContests[username][contest] = points;
                    }
                    else
                    {
                        if (contestWithPoInts[contest] < points)
                        {
                            contestWithPoInts[contest] = points;
                            usersWithContests[username][contest] = points;
                        }
                    }
                }
            }
            var maxContest = new Dictionary<string, int>();
            foreach (var kvp in usersWithContests)
            {
                foreach (var Kvp in kvp.Value)
                {
                    if (!maxContest.ContainsKey(kvp.Key))
                    {
                        maxContest[kvp.Key] = 0;
                    }
                    maxContest[kvp.Key] += Kvp.Value;
                }
            }
            int maxNum = maxContest.Values.Max();
            maxContest = maxContest
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            string maxName = maxContest.First().Key;
            Console.WriteLine($"Best candidate is {maxName} with total {maxNum} points.");
            Console.WriteLine("Ranking: ");
            foreach (var kvp in usersWithContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(kvp.Key);
                foreach (var Kvp in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {Kvp.Key} -> {Kvp.Value}");
                }
            }
        }
    }
}
