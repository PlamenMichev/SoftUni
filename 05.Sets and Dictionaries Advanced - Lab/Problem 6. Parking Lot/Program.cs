using System;
using System.Collections.Generic;

namespace Problem_6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "IN")
                {
                    carNumbers.Add(tokens[1]);
                }
                else
                {
                    carNumbers.Remove(tokens[1]);
                }
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var carNumber in carNumbers)
            {
                Console.WriteLine(carNumber);
            }
        }
    }
}
