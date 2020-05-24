using System;
using System.Dynamic;
using System.Linq;

namespace Problem_2._Backing_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            int initialEnergy = 100;
            int initialCoins = 100;
            int length = tokens.Length;
            bool sucessfulFinish = false;
            int currentRow = 0;
            while (currentRow <= length - 1)
            {
                string[] currentCommand = tokens[currentRow].Split('-');
                string command = currentCommand[0];
                int currentNum = int.Parse(currentCommand[1]);
                if (command == "rest")
                {
                    if (initialEnergy + currentNum > 100)
                    {
                        Console.WriteLine($"You gained {0} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");

                    }
                    else
                    {
                        initialEnergy += currentNum;
                        Console.WriteLine($"You gained {currentNum} energy.");
                        Console.WriteLine($"Current energy: {initialEnergy}.");

                    }
                }

                if (command == "order")
                {
                    if (initialEnergy - 30 >= 0)
                    {
                        initialEnergy -= 30;
                        initialCoins += currentNum;
                        Console.WriteLine($"You earned {currentNum} coins.");
                    }
                    else
                    {
                        initialEnergy += 50;
                        if (initialEnergy > 100)
                        {
                            initialEnergy -= 100;
                            initialEnergy += 100 - initialEnergy;
                        }
                        Console.WriteLine($"You had to rest!");
                    }
                }

                if (command != "rest" && command != "order")
                {
                    if (initialCoins - currentNum > 0)
                    {
                        initialCoins -= currentNum;
                        Console.WriteLine($"You bought {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"Closed! Cannot afford {command}.");
                        return;
                    }
                }
                currentRow++;
                if (currentRow == length)
                {
                    sucessfulFinish = true;
                }
            }

            if (sucessfulFinish)
            {
                Console.WriteLine($"Day completed!");
                Console.WriteLine($"Coins: {initialCoins}");
                Console.WriteLine($"Energy: {initialEnergy}");
            }
        }
    }
}
