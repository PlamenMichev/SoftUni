using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_12._Inferno_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            HashSet<int> indexesToRemove = new HashSet<int>();
            HashSet<int> temp = new HashSet<int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Forge")
                {
                    foreach (var i in temp)
                    {
                        indexesToRemove.Add(i);
                    }
                    foreach (var index in indexesToRemove.OrderByDescending(x => x))
                    {
                        numbers.RemoveAt(index);
                    }

                    Console.WriteLine(string.Join(" ", numbers));
                    break;
                }

                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                if (command != "Reverse")
                {
                    foreach (var i in temp)
                    {
                        indexesToRemove.Add(i);
                    }
                }
                else
                {
                    temp.Clear();
                    continue;
                }
                temp = new HashSet<int>();


                string filterType = tokens[1];
                int filterParameter = int.Parse(tokens[2]);
                string[] separatedType = filterType.Split();
                Func<int, int, bool> predicate;
                predicate = GetFunc(filterType, filterParameter);
                if (separatedType.Length == 3)
                {
                    if (numbers.Count == 2)
                    {
                        if (predicate(numbers[0], numbers[1]))
                        {
                            temp.Add(0);
                        }
                    }
                    if (numbers.Count == 1)
                    {
                        if (numbers[0] == filterParameter)
                        {
                            temp.Add(0);
                        }
                    }
                    for (int i = 1; i < numbers.Count; i++)
                    {   
                        if (i == 0)
                        {
                            if (numbers[i] + numbers[i + 1] == filterParameter)
                            {
                                temp.Add(i);
                            }
                        }
                        else if (i == numbers.Count - 1)
                        {
                            if (numbers[i] + numbers[i - 1] == filterParameter)
                            {
                                temp.Add(i);
                            }
                        }
                        else
                        {
                            if (numbers[i] + numbers[i - 1] + numbers[i + 1] == filterParameter)
                            {
                                temp.Add(i);
                            }
                        }
                    }
                }
                else
                {
                    
                    if (separatedType[1] == "Left")
                    {
                        for (int i = 0; i < numbers.Count - 1; i++)
                        {
                            if (i == 0)
                            {
                                if (predicate(numbers[i], 0))
                                {
                                    temp.Add(i);
                                }
                            }
                            else
                            {
                                if (predicate(numbers[i], numbers[i - 1]))
                                {
                                    temp.Add(i);
                                }
                            }
                        }
                    }
                    if (separatedType[1] == "Right")
                    {
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (i == numbers.Count - 1)
                            {
                                if (predicate(numbers[i], 0))
                                {
                                    temp.Add(i);
                                }
                            }
                            else
                            {
                                if (predicate(numbers[i], numbers[i + 1]))
                                {
                                    temp.Add(i);
                                }
                            }
                        }
                    }
                }
            }
        }
        static Func<int, int, bool> GetFunc(string filterCommand, int criteria)
        {
            return (x, y) => x + y == criteria;
        }
    }
}