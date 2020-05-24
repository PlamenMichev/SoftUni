using System;
using System.Linq;

namespace Problem_3._Primary_Diagonal
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
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = temp;
            }
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
