using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.RobotCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string regex = @"[_,][A-Za-z]+\d";
            while (input != "Report")
            {
                MatchCollection matches = Regex.Matches(input, regex);
                string result = "";
                foreach (var match in matches)
                {
                    string text = match.ToString();                   
                    if(text[0] == ',')
                    {
                        char lastElement = text[text.Length - 1];
                        int numToAdd = int.Parse(lastElement.ToString());
                        for (int i = 1; i < text.Length - 1; i++)
                        {
                            char element = text[i];
                            int value = (int)element;
                            value += numToAdd;
                            result += (char)value;
                        }
                    }
                    else if (text[0] == '_')
                    {
                        char lastElement = text[text.Length - 1];
                        int numToAdd = int.Parse(lastElement.ToString());
                        for(int i = 1; i < text.Length - 1; i++)
                        {
                            char element = text[i];
                            int value = (int)element;
                            value -= numToAdd;
                            result += (char)value;
                        }
                    }

                    result += " ";
                }
                if (matches.Count > 0)
                {
                    Console.WriteLine(result);
                }
                input = Console.ReadLine();
            }
        }
    }
}
