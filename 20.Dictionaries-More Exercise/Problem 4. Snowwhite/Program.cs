using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Snowwhite
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesColorAndPhysics = new Dictionary<string, Dictionary<string, int>>();

            //Dictionary<string, List<string>> namesAndHats = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Once upon a time")
                {
                    break;                   
                }

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string color = tokens[2];
                int physics = int.Parse(tokens[4]);

                if (!namesColorAndPhysics.ContainsKey(name))
                {
                    namesColorAndPhysics[name] = new Dictionary<string, int>();
                }

                if (!namesColorAndPhysics[name].ContainsKey(color))
                {
                    namesColorAndPhysics[name].Add(color, 0);
                }

                if (namesColorAndPhysics[name][color] < physics)
                {
                    namesColorAndPhysics[name].Remove(color);
                    namesColorAndPhysics[name].Add(color, physics);
                }

            }

            var result = namesColorAndPhysics
                .OrderByDescending(x => x.Value.Values.Sum())
                .ToDictionary(x => x.Key, x => x.Value);

            
            
            foreach (var kvp in result)
            {
                foreach (var secKvp in kvp.Value.OrderByDescending(x => x.Key))
                {
                    foreach (var thirdKvp in kvp.Value.OrderByDescending(x => x.Key))
                    {
                        Console.WriteLine($"({thirdKvp.Key}) {kvp.Key} <-> {secKvp.Value}");                       
                    }
                    break;
                }
            }
        }
    }
}
