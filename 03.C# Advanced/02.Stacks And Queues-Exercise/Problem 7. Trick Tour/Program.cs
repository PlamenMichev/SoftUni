using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Problem_7._Trick_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Queue<int> difference = new Queue<int>();
            while (length != 0)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                difference.Enqueue(input[0] - input[1]);
                length--;
            }

            int index = 0;
            while (true)
            {
                Queue<int> copyOfDifference = new Queue<int>(difference);
                int fuel = -1;
                while (copyOfDifference.Any())
                {
                    if(copyOfDifference.Peek() > 0 && fuel == -1)
                    {
                        fuel = copyOfDifference.Dequeue();
                        difference.Enqueue(difference.Dequeue());
                    }
                    else if (copyOfDifference.Peek() < 0 && fuel == -1)
                    {
                        copyOfDifference.Enqueue(copyOfDifference.Dequeue());
                        difference.Enqueue(difference.Dequeue());
                        index++;
                    }
                    else
                    {
                        fuel += copyOfDifference.Dequeue();
                        if (fuel < 0)
                        {   
                            break;
                        }
                    }
                    
                }

                if (fuel >= 0)
                {
                    Console.WriteLine(index);
                    return;
                }
                index++;
            }
        }
    }
}