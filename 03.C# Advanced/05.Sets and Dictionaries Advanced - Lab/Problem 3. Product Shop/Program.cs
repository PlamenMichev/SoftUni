using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = new Dictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Revision")
                {
                    break;
                }

                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);
                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                shops[shop][product] = price;
            }

            foreach (var kvp in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}->");
                foreach (var secKvp in kvp.Value)
                {
                    Console.WriteLine($"Product: { secKvp.Key}, Price: { secKvp.Value}");
                }
            }
        }
    }
}
