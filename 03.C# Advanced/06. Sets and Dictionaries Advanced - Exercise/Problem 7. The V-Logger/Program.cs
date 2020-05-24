using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_7._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            Dictionary<string, HashSet<string>> followers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> following = new Dictionary<string, HashSet<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string command = tokens[1];
                if (command == "joined")
                {
                    if (usernames.Contains(username) == false)
                    {
                        usernames.Add(username);
                        followers.Add(username, new HashSet<string>());
                        following[username] = new HashSet<string>();
                    }
                    
                }
                if (command == "followed")
                {
                    string userToFollow = tokens[2];
                    if (usernames.Contains(username) && usernames.Contains(userToFollow))
                    {
                        if (username != userToFollow)
                        {
                            followers[userToFollow].Add(username);
                            following[username].Add(userToFollow);
                        }

                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {usernames.Count} vloggers in its logs.");

            var topUser = followers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => following[x.Key].Count)
                .FirstOrDefault();

            Console.WriteLine($"1. { topUser.Key} : { topUser.Value.Count} followers, {following[topUser.Key].Count} following");
            foreach (var username in topUser.Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {username}");
            }

            int i = 2;
            foreach (var kvp in followers
                .Where(x => x.Key != topUser.Key)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => following[x.Key].Count))
            {

                Console.WriteLine($"{i}. {kvp.Key} : {followers[kvp.Key].Count} followers, {following[kvp.Key].Count} following");

                i++;
            }
        }
    }
}
