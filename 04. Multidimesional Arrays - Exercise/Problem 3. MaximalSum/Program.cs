using System;
using System.Data.Common;
using System.Linq;

namespace Problem_3._MaximalSum
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
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[row];
                int[] temp = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = temp;
            }

            int sum = 0;
            int biggestRow = 0;
            int biggestCol = 0;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int currentSum = SumInMatrix(row, col, matrix);
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                        biggestRow = row;
                        biggestCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = " + sum);
            PrintSquareInMatrix(biggestRow, biggestCol, matrix);
        }

        static void PrintSquareInMatrix(int rows, int cols, int[][] matrix)
        {
            for (int row = rows; row < rows + 3; row++)
            {
                for (int col = cols; col < cols + 3; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
        static int SumInMatrix(int rows, int cols, int[][] matrix)
        {
            int sum = 0;
            for (int row = rows; row < rows + 3; row++)
            {
                for (int col = cols; col < cols + 3; col++)
                {
                    sum += matrix[row][col];
                }
            }

            return sum;
        }
    }
}
