using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Problem_6._Bomb_the_Basement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bombProps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bombRow = bombProps[0];
            int bombCol = bombProps[1];
            int power = bombProps[2];
            int rows = numbers[0];
            int cols = numbers[1];
            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            matrix[bombRow][bombCol] = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - bombRow, 2) + Math.Pow(col - bombCol, 2));
                    if (distance <= power)
                    {
                        matrix[row][col] = 1;
                    }
                }
            }
            int[][] secMatrix = new int[cols][];

            for (int row = 0; row < cols; row++)
            {
                secMatrix[row] = new int[rows];
                for (int col = 0; col < rows; col++)
                {
                    secMatrix[row][col] = matrix[col][row];
                }
                secMatrix[row] = secMatrix[row].OrderByDescending(x => x).ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row][col] = secMatrix[col][row];
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join("", r))));

        }
    }
}
