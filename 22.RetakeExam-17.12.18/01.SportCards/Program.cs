using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SportCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, decimal>> cardsSportsAndPrices = new Dictionary<string, Dictionary<string, decimal>>();
            string input = Console.ReadLine();
            while(input != "end")
            {
                if (input.Contains('-'))
                {
                    string[] tokens = input
                        .Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                    string card = tokens[0];
                    string sport = tokens[1];
                    decimal price = decimal.Parse(tokens[2]);
                    if (!cardsSportsAndPrices.ContainsKey(card))
                    {
                        cardsSportsAndPrices[card] = new Dictionary<string, decimal>();
                    }
                    if (!cardsSportsAndPrices[card].ContainsKey(sport))
                    {
                        cardsSportsAndPrices[card][sport] = 0m;
                    }

                    cardsSportsAndPrices[card][sport] = price;
                }
                else
                {
                    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0] == "check")
                    {
                        string card = tokens[1];
                        if (cardsSportsAndPrices.ContainsKey(card))
                        {
                            Console.WriteLine($"{card} is available!");
                        }
                        else
                        {
                            Console.WriteLine($"{card} is not available!");
                        }
                    }                 
                }
                input = Console.ReadLine();
            }

            foreach(var kvp  in cardsSportsAndPrices.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach(var secKvp in kvp.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"  -{secKvp.Key} - {secKvp.Value:f2}");
                }
            }
        }
    }
}
