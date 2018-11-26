using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Order
{
    class Program
    {
        static void Main(string[] args)
        {
            var productWithPrice = new Dictionary<string, double>();
            var quantity = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                string[] tokens = input
                    .Split()
                    .ToArray();
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                int currentQuantity = int.Parse(tokens[2]);
                if (!productWithPrice.ContainsKey(product))
                {
                    productWithPrice[product] = 0;
                }
                productWithPrice[product] = price;
                if (!quantity.ContainsKey(product))
                {
                    quantity[product] = 0;
                }
                quantity[product] += currentQuantity;
            }
            var finalPrices = new Dictionary<string, double>();
            foreach (var kvp in productWithPrice)
            {
                finalPrices[kvp.Key] = kvp.Value * quantity[kvp.Key];
            }

            foreach (var kvp in finalPrices)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");

            }
        }
    }
}