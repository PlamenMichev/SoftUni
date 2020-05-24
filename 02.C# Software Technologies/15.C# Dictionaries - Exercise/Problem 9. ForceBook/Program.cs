using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersInfo = new Dictionary<string, string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Lumpawaroo")
                {
                    break;
                }

                string[] tokens = new string[0];
                
                if (input.Contains("|"))
                {
                    tokens = input.Split(" | ");
                    string user = tokens[1];
                    string side = tokens[0];
                    if (!usersInfo.ContainsKey(user))
                    {
                        usersInfo[user] = side; 
                    }    
                }
                else
                {
                    tokens = input.Split(" -> ");
                    string user = tokens[0];
                    string side = tokens[1];
                   
                    if (!usersInfo.ContainsKey(user))
                    {
                        usersInfo[user] = side;
                    }
                    else
                    {
                        usersInfo[user] = side;
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var filteredInfo = usersInfo 
                .GroupBy(x => x.Value) 
                .OrderByDescending(x => x.Count())
                .ThenBy(x=>x.Key);
            foreach (var kvp in filteredInfo)
            {
                string side = kvp.Key;
                var sideAsDict = kvp;
                Console.WriteLine($"Side: {side}, Members: {sideAsDict.Count()}");
                foreach (var kvpValue in sideAsDict.OrderBy(x=>x.Key))
                {
                    string name = kvpValue.Key;
                    string secSide = kvpValue.Value;
                    Console.WriteLine($"! {name}");
                }
            }
             
        }
    }
}
