using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Exam_Prep
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|')
                .ToArray();
            //Working on first Part
            string firstPart = input[0];
            string regex = @"((?<=#|\$|%|\*|&))[A-Z]+(\1)";
            Dictionary<int, int> saveLength = new Dictionary<int, int>();
            Match firstPartMatch = Regex.Match(firstPart, regex);
            string capitalLetters = firstPartMatch.Value;
            int length = capitalLetters.Length;
            string saveCapitalLetters = capitalLetters;
            //Working on second Part
            string secPart = input[1];
            string regexForSecPart = @"([0-9]{2}):([0-9]{2})";
            MatchCollection matchSecPart = Regex.Matches(secPart, regexForSecPart);
            foreach (Match match in matchSecPart)
            {
                int asciiCode = int.Parse(match.Groups[1].Value);
                int lengthOfWord = int.Parse(match.Groups[2].Value);
                bool isEqual = false;
                if (asciiCode < 65 || asciiCode > 90)
                {
                    continue;
                }
                else
                {
                    for (int i = 0; i < capitalLetters.Length; i++)
                    {
                        if (asciiCode == capitalLetters[i])
                        {
                            capitalLetters = capitalLetters.Remove(i, 1);
                            isEqual = true;
                            break;
                        }
                    }

                    if (isEqual)
                    {
                        if (!saveLength.ContainsKey(asciiCode))
                        {
                            saveLength[asciiCode] = 0;
                        }

                        saveLength[asciiCode] = lengthOfWord;
                    }
                }
            }
            //Working on third Part
            string[] thirdPart = input[2].Split();
            List<string> answer = new List<string>();
            for (int i = 0; i < thirdPart.Length; i++)
            {
                string currentWord = thirdPart[i];
                if (saveLength.ContainsKey(currentWord[0]) && currentWord.Length == saveLength[currentWord[0]] + 1 && currentWord[0] == saveCapitalLetters[0])
                {
                    List<char> temp = saveCapitalLetters.Skip(1).ToList();
                    saveCapitalLetters = "";
                    for (int j = 0; j < temp.Count; j++)
                    {
                        saveCapitalLetters += temp[j];
                    }
                    saveLength.Remove(currentWord[0]);
                    answer.Add(currentWord);
                }
            }
            Console.WriteLine(string.Join("\n", answer));
        }
    }
}