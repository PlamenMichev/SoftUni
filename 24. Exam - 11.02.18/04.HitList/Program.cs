using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, string>> people = new Dictionary<string, SortedDictionary<string, string>>();
            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "end transmissions")
            {
                string[] tokens = input.Split("=");
                string name = tokens[0];
                string[] kvps = tokens[1].Split(";");
                if (!people.ContainsKey(name))
                {
                    people[name] = new SortedDictionary<string, string>();
                }

                for (int i = 0; i < kvps.Length; i++)
                {
                    string[] kvp = kvps[i].Split(":");
                    string key = kvp[0];
                    string value = kvp[1];

                    if (!people[name].ContainsKey(key))
                    {
                        people[name][key] = "";
                    }
                    people[name][key] = value;
                }
                input = Console.ReadLine();
            }

            string[] personToKill = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string nameToKill = personToKill[1];
            int infoIndex = 0;
            Console.WriteLine($"Info on {nameToKill}:");
            foreach (var kvp in people[nameToKill])
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
                infoIndex += kvp.Key.Length + kvp.Value.Length;
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}
