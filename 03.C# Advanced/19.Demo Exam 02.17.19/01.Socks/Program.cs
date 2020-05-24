using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> leftSocks = new Stack<int>(leftInput);

            int[] rightInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> rightSocks = new Queue<int>(rightInput);
            Queue<int> pairs = new Queue<int>();
    
            while (leftSocks.Count != 0 && rightSocks.Count != 0)
            {
                int leftNum = leftSocks.Peek();
                int rightNum = rightSocks.Peek();

                if (leftNum > rightNum)
                {
                    int pair = leftNum + rightNum;
                    pairs.Enqueue(pair);
                    leftSocks.Pop();
                    rightSocks.Dequeue();
                }
                else if (leftNum == rightNum)
                {
                    leftNum++;
                    leftSocks.Pop();
                    leftSocks.Push(leftNum);
                    rightSocks.Dequeue();
                }
                else if (leftNum < rightNum)
                {
                    leftSocks.Pop();
                }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(string.Join(" ", pairs));
        }
    }
}
