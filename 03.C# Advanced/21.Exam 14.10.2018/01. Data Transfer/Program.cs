using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Data_Transfer
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Regex regex = new Regex("s:.[^;]+;r:.[^;]+;m--\"[A-Za-z ]+\"");
            int sumOfData = 0;
            for (int i = 0; i < length; i++)
            {
                string input = Console.ReadLine();
                Match match = regex.Match(input);
                string senderName = "";
                string reciverName = "";
                string messege = "";
                if (match.Success)
                {
                    for (int j = 0; j < input.Length; j++)
                    {
                        var letter = input[j];
                        if (letter == ':' && input[j - 1] == 's')
                        {
                            while (letter != ';')
                            {
                                if (char.IsLetter(letter) || letter == ' ')
                                {
                                    senderName += letter;
                                }

                                if (char.IsDigit(letter))
                                {
                                    sumOfData += int.Parse(letter.ToString());
                                }
                                letter = input[j + 1];
                                j++;
                            }
                        }

                        if (letter == ':' && input[j - 1] == 'r')
                        {
                            while (letter != ';')
                            {
                                if (char.IsLetter(letter) || letter == ' ')
                                {
                                    reciverName += letter;
                                }

                                if (char.IsDigit(letter))
                                {
                                    sumOfData += int.Parse(letter.ToString());
                                }
                                letter = input[j + 1];
                                j++;
                            }
                        }

                        if (letter == '-' && input[j - 1] == 'm')
                        {
                            letter = input[j + 3];
                            j += 3;
                            while (letter != '"')
                            {
                                if (char.IsLetter(letter) || letter == ' ')
                                {
                                    messege += letter;
                                }

                                if (char.IsDigit(letter))
                                {
                                    sumOfData += int.Parse(letter.ToString());
                                }
                                letter = input[j + 1];
                                j++;
                            }
                        }
                    }

                    string textToAdd = $"{senderName} says \"{messege}\" to {reciverName}";
                    Console.WriteLine(textToAdd);
                }

                

            }
            Console.WriteLine($"Total data transferred: {sumOfData}MB");
        }

        public static int SumOfLetters(string word)
        {
            int sum = 0;
            foreach (var letter in word)
            {
                sum += (int)letter;
            }

            return sum;
        }
    }
}
