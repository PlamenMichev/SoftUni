using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] ordersAsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(ordersAsInput);
            int max = orders.Max();
            while (orders.Any())
            {
                if (foodQuantity - orders.Peek() >= 0)
                {
                    foodQuantity = foodQuantity - orders.Dequeue();
                }
                else
                {
                    Console.WriteLine(max);
                    int length = orders.Count;
                    Console.Write("Orders left: ");
                    for (int i = 0; i < length; i++)
                    {
                        if (i == length - 1)
                        {
                            Console.WriteLine($"{orders.Dequeue()}");
                        }
                        else Console.Write($"{orders.Dequeue()} ");
                    }
                    
                    return;
                }
                
            }

            Console.WriteLine(max);
            Console.WriteLine($"Orders complete");
        }
    }
}
