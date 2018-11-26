using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<string> validUsernames = new List<string>();
            for (int i = 0; i < usernames.Length; i++)
            {
                bool isValid = true;
                foreach (var letter in usernames[i])
                {
                    if (Char.IsDigit(letter) == false
                        && Char.IsLetter(letter) == false
                        && letter != '-'
                        && letter != '_')
                    {
                        isValid = false;
                        break;
                    }
                }
                if (!(usernames[i].Length >= 3 && usernames[i].Length <= 16))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    validUsernames.Add(usernames[i]);
                }

            }

            foreach (var username in validUsernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
