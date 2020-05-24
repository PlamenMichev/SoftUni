using System;
using System.Linq;

namespace Problem_10._Lady_Bugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            long[] indexes = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();
            int[] fieldArr = new int[fieldSize];
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] >= 0 && indexes[i] <= fieldSize - 1)
                {
                    fieldArr[indexes[i]] = 1;
                }

            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                long position = 0;
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .ToArray();
                bool check = false;
                for (int i = 0; i < fieldArr.Length; i++)
                {
                    if (i == int.Parse(command[0]) && fieldArr[i] == 1)
                    {
                        check = true;
                        position = i;
                        break;
                    }
                }
                if (check)
                {
                    int stepsToFly = (int.Parse(command[2]));
                    int ladyBugIndex = int.Parse(command[0]);
                    if (ladyBugIndex < 0 || ladyBugIndex >= fieldArr.Length)
                    {
                        continue;
                    }
                    bool isFree = false;
                    long finalPosition = 0;
                    if (command[1] == "right")
                    {

                        if (position + stepsToFly >= fieldArr.Length)
                        {
                            fieldArr[ladyBugIndex] = 0;
                            continue;
                        }
                        else if (position + stepsToFly < fieldArr.Length)
                        {
                            position += stepsToFly;
                        }
                        if (fieldArr[position] == 0)
                        {
                            fieldArr[stepsToFly + ladyBugIndex] = fieldArr[ladyBugIndex];
                            fieldArr[ladyBugIndex] = 0;

                        }
                        else if (fieldArr[position] == 1)
                        {
                            for (long i = position+1; i < fieldArr.Length; i++)
                            {
                                if (fieldArr[i] == 0)
                                {
                                    isFree = true;
                                    finalPosition = i;
                                    break;
                                }
                            }
                            if (isFree)
                            {
                                fieldArr[finalPosition] = fieldArr[ladyBugIndex];
                                fieldArr[ladyBugIndex] = 0;
                            }
                            else fieldArr[ladyBugIndex] = 0;
                        }
                    }
                    else if (command[1] == "left")
                    {
                        
                        if (position - stepsToFly < 0)
                        {
                            fieldArr[ladyBugIndex] = 0;
                            continue;
                        }
                        else if (position - stepsToFly >= 0 && position-stepsToFly<fieldArr.Length)
                        {
                            position -= stepsToFly;
                        }
                        if (fieldArr[position] == 0)
                        {
                            fieldArr[ladyBugIndex - stepsToFly] = fieldArr[ladyBugIndex];
                            fieldArr[ladyBugIndex] = 0;

                        }
                        else if (fieldArr[position] == 1)
                        {
                            for (long i = position-1; i >= 0; i--)
                            {
                                if (fieldArr[i] == 0)
                                {
                                    isFree = true;
                                    finalPosition = i;
                                    break;
                                }
                            }
                            if (isFree)
                            {
                                fieldArr[finalPosition] = fieldArr[ladyBugIndex];
                                fieldArr[ladyBugIndex] = 0;
                            }
                            else fieldArr[ladyBugIndex] = 0;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", fieldArr));
        }
    }
}