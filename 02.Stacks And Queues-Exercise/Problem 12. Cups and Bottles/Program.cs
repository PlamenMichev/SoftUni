using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> cups = new Queue<int>(cupsCapacity);
            int[] filledBottles = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bottles = new Stack<int>(filledBottles);
            bool isEmpty = true;
            int wastedWater = 0;
            while (cups.Any() && bottles.Any())
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Dequeue();
                if (currentBottle - currentCup >= 0)
                {
                    wastedWater += currentBottle - currentCup;
                }
                if (currentBottle - currentCup < 0)
                {
                    while (currentBottle - currentCup < 0)
                    {
                        if (bottles.Any())
                        {
                            currentBottle += bottles.Pop();
                        }
                        else
                        {
                            isEmpty = false;
                            break;          
                        }
                    }

                    if (isEmpty == false)
                    {
                        break;
                    }
                    wastedWater += currentBottle - currentCup;
                }
            }
            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
