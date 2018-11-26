using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            var junk = new Dictionary<string, int>();
            var keyMaterial = new Dictionary<string, int>();
            keyMaterial["shards"] = 0;
            keyMaterial["fragments"] = 0;
            keyMaterial["motes"] = 0;
            bool haveEnoughMoney = false;
            while (!haveEnoughMoney)
            {
                string input = Console.ReadLine();
                string[] tokens = input
                    .Split(' ')
                    .ToArray();
                int length = tokens.Length;
                for (int i = 0; i < length - 1; i += 2)
                {
                    string command = tokens[i + 1];
                    command = command.ToLower();
                    int quantity = int.Parse(tokens[i]);
                    if (command == "shards" || command == "fragments" || command == "motes")
                    {
                        if (command == "shards")
                        {
                            keyMaterial["shards"] += quantity;
                            if (keyMaterial["shards"] >= 250)
                            {
                                Console.WriteLine($"Shadowmourne obtained!");
                                haveEnoughMoney = true;
                                keyMaterial["shards"] -= 250;
                                break;
                            }
                        }

                        if (command == "fragments")
                        {
                            keyMaterial["fragments"] += quantity;
                            if (keyMaterial["fragments"] >= 250)
                            {
                                Console.WriteLine($"Valanyr obtained!");
                                haveEnoughMoney = true;
                                keyMaterial["fragments"] -= 250;
                                break;
                            }
                        }

                        if (command == "motes")
                        {
                            keyMaterial["motes"] += quantity;
                            if (keyMaterial["motes"] >= 250)
                            {
                                Console.WriteLine($"Dragonwrath obtained!");
                                haveEnoughMoney = true;
                                keyMaterial["motes"] -= 250;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!junk.ContainsKey(command))
                        {
                            junk[command] = 0;
                        }

                        junk[command] += quantity;
                    }
                }


            }

            var resultMaterials = keyMaterial
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            foreach (var kvp in resultMaterials)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            var resultJunk = junk
                .OrderBy(kvp => kvp.Key);
            foreach (var kvp in resultJunk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}