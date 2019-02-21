using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> usersTagsAndLikes = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = new string[4];
                if (input.Contains("->"))
                {
                    tokens = input
                        .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                }
                else
                {
                    tokens = input
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                }
                if (tokens[0] == "ban")
                {
                    string name = tokens[1];

                    if (usersTagsAndLikes.ContainsKey(name))
                    {
                        usersTagsAndLikes.Remove(name);
                    }
                }
                else
                {
                    string user = tokens[0];
                    string tag = tokens[1];
                    int likes = int.Parse(tokens[2]);

                    if (!usersTagsAndLikes.ContainsKey(user))
                    {
                        usersTagsAndLikes[user] = new Dictionary<string, int>();
                    }

                    if (!usersTagsAndLikes[user].ContainsKey(tag))
                    {
                        usersTagsAndLikes[user][tag] = 0;
                    }

                    usersTagsAndLikes[user][tag] += likes;
                }
            }

            foreach (var kvp in usersTagsAndLikes.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var tagKvp in kvp.Value)
                {
                    Console.WriteLine($"- {tagKvp.Key}: {tagKvp.Value}");
                }
            }
        }
    }
}
