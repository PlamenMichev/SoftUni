using System;
using System.Linq;

namespace Problem_1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
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

            int firstDialonalSum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (row == col)
                    {
                        firstDialonalSum += matrix[row][col];
                    }
                }
            }

            int secondDiagonalSum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = rows - 1; col >= 0; col--)
                {
                    if (row == rows - col - 1)
                    {
                        secondDiagonalSum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(secondDiagonalSum - firstDialonalSum));
        }
    }
}
