using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Problem_7._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int countPerGreenLight = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int carToPass = Math.Min(countPerGreenLight, cars.Count);
                    for (int i = 0; i < carToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}
