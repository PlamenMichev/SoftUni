using System;
using System.Collections.Generic;

namespace Problem_5._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfTeams = int.Parse(Console.ReadLine());
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of assignment")
                {
                    break;
                }

                if (input.Contains("-"))
                {
                    string[] tokens = input.Split("-");
                    string team = tokens[1];
                    string user = tokens[0];
                    
                }
            }
        }
    }
}
