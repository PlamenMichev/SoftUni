using System;
using System.Collections.Generic;

namespace Problem_5._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            int unpaidCount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                
                if (input == "Paid")
                {
                    int length = customers.Count;
                        for (int i = 0; i < length; i++)
                        {
                            Console.WriteLine(customers.Dequeue());
                        }
                    unpaidCount = 0;
                }
                else
                {
                    customers.Enqueue(input);
                    unpaidCount++;
                }
                
            }
            
            Console.WriteLine($"{unpaidCount} people remaining.");
        }
    }
}
