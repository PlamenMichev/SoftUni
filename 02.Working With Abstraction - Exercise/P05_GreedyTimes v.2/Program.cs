using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long maxCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag();

            for (int i = 0; i < items.Length; i += 2)
            {
                string name = items[i];
                long count = long.Parse(items[i + 1]);
                string category = string.Empty;

                var bagAdder = new BagAdder(name, category, count, maxCapacity, bag);
                bagAdder.Add(bag);
            }

            var outputProccessor = new OutputProccessor();
            Console.WriteLine(outputProccessor.Output(bag));
        }
    }
}