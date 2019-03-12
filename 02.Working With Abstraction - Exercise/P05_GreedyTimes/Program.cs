
using System;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            long maxCapacity = long.Parse(Console.ReadLine());
            string[] items = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Bag();

            for (int i = 0; i < items.Length; i += 2)
            {
                string itemName = items[i];
                long quantity = long.Parse(items[i + 1]);
                string categoryType = string.Empty;
                var bagAdder = new BagAdder(itemName, quantity, categoryType, maxCapacity, bag);
                bagAdder.Add(bag);
            }

            var outputProccessor = new OutputProccessor();
            Console.WriteLine(outputProccessor.Output(bag));
        }
    }
}