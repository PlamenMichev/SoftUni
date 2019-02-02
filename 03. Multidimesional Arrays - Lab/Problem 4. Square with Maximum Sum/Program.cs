using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_4._Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];

                }
            }

            int maxRowIndex = 0;
            int maxColIndex = 0;
            int sum = int.MinValue;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var currentSum = matrix[row, col]
                                     + matrix[row, col + 1]
                                     + matrix[row + 1, col]
                                     + matrix[row + 1, col + 1];
                    
                    if (currentSum > sum)
                    {
                        maxRowIndex = row;
                        maxColIndex = col;
                        sum = currentSum;
                    }

                }
            }

            
            Console.WriteLine($"{matrix[maxRowIndex, maxColIndex]} {matrix[maxRowIndex, maxColIndex + 1]}");
            Console.WriteLine($"{matrix[maxRowIndex + 1, maxColIndex]} {matrix[maxRowIndex + 1, maxColIndex + 1]}");
            Console.WriteLine(sum);
        }
    }
}
