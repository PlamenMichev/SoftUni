using System;
using System.Collections.Generic;

namespace Problem_7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY")
                {
                    break;
                }
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else guests.Add(input);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (vipGuests.Contains(input))
                {
                    vipGuests.Remove(input);
                }
                else if (guests.Contains(input))
                {
                    guests.Remove(input);
                }
            }

            Console.WriteLine(guests.Count + vipGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
