using System;
using System.Collections.Generic;
using System.Linq;

namespace Prolem_5._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var registeredCars = new Dictionary<string, string>();
            for (int i = 1; i <= length; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input
                    .Split()
                    .ToArray();
                string command = tokens[0];
                string username = tokens[1];
                if (command == "register")
                {
                    
                    string licensePlateNumber = tokens[2];
                    if (!registeredCars.ContainsKey(username))
                    {
                        registeredCars[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }
                else
                {
                    if(!registeredCars.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        registeredCars.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                }
            }

            foreach (var kvp in registeredCars)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}