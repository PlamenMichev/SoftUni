using System;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"(?<=\s)(?<user>[A-Za-z0-9]+[\.\-_]?[A-Za-z0-9]+)@(?<host>[A-Za-z0-9\-]+[\.][A-Za-z0-9\-]+[\.]?[A-Za-z0-9]+)";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, regex);
            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
