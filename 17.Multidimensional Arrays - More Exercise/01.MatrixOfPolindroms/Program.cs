using System;
using System.Linq;
using System.Text;

namespace _01.MatrixOfPolindroms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            string[][] matrix = new string[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < cols; col++)
                {
                    StringBuilder sb = new StringBuilder();
                    char firstLetter = (char)(row + 97);
                    char midLetter = (char)(row + col + 97);
                    char lastLetter = (char)(row + 97);
                    sb.Append($"{firstLetter}{midLetter}{lastLetter}");
                    matrix[row][col] += sb;
                }

            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
