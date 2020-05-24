using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>>  colorsAndClothes = new Dictionary<string, Dictionary<string, int>>();
            int length = int.Parse(Console.ReadLine());
            string itemToFind = "";
            for (int i = 0; i < length + 1; i++)
            {
                string input = Console.ReadLine();
                if (!input.Contains("->"))
                {
                    itemToFind = input;
                    break;
                }

                string[] tokens = input
                    .Trim()
                    .Split(" -> ");
                string color = tokens[0];
                List<string> clothes = tokens[1]
                    .Split(","
                        , StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (!colorsAndClothes.ContainsKey(color))
                {
                    colorsAndClothes[color] = new Dictionary<string, int>();
                }

                for (int j = 0; j < clothes.Count; j++)
                {
                    if (!colorsAndClothes[color].ContainsKey(clothes[j]))
                    {
                        colorsAndClothes[color][clothes[j]] = 0;
                    }
                    colorsAndClothes[color][clothes[j]]++;
                }
                


            }

            string[] findItem = itemToFind.Split();
            foreach (var kvp in colorsAndClothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var clothesKvp in kvp.Value)
                {
                    
                    if (findItem[0] == kvp.Key && findItem[1] == clothesKvp.Key)
                    {
                        Console.WriteLine($"* {clothesKvp.Key} - {clothesKvp.Value} (found!)");
                    }
                    else Console.WriteLine($"* {clothesKvp.Key} - {clothesKvp.Value}");
                    
                    
                }
            }
        }
    }
}
