using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_5._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = numbers[0];
            int cols = numbers[1];
            string input = Console.ReadLine();
            char[][] matrix = new char[rows][];
            Queue<char> snake = new Queue<char>(input);
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                var temp = snake;
                for (int col = 0; col < cols; col++)
                {
                    char currentSymbol = temp.Dequeue();
                    Console.Write(currentSymbol);
                    temp.Enqueue(currentSymbol);
                }

                Console.WriteLine();
            }
        }
    }
}
