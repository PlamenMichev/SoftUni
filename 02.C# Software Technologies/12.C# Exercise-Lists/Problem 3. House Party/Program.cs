using System;
using System.Collections.Generic;

namespace Problem_3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int count = int.Parse(Console.ReadLine());
            while (count != 0)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                string command = input[2];
                if(command == "going!")
                {
                    bool nameExists = names.Contains(name);
                    if (nameExists)
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        names.Add(name);
                    }                  
                }
                else if(command == "not")
                {
                    bool nameExists = names.Contains(name);
                    if(nameExists)
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }

                }
                count--;
            }
                Console.WriteLine(string.Join("\n", names));
        }
    }
}
