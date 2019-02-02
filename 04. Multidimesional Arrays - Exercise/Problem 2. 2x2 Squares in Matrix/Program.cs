using System;
using System.Linq;

namespace Problem_2._2x2_Squares_in_Matrix
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
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                //string[] input = Console.ReadLine().Split(" ");
                char[] temp = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                matrix[row] = temp;
            }

            int count = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (matrix[row][col] == matrix[row + 1][col]
                        && matrix[row][col] == matrix[row][col + 1]
                        && matrix[row][col] == matrix[row + 1][col + 1])
                    {
                        count++;
                    }              
                }
            }

            Console.WriteLine(count);
        }
    }
}
