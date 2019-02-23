using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Problem_7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[row];
                string input = Console.ReadLine();
                matrix[row] = input.ToCharArray();
            }

            int count = 0;
            while (true)
            {
                int knightRow = -1;
                int knightCol = -1;
                int maxAttacks = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < rows; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            int temp = CountAttacks(matrix, row, col);
                            if (temp > maxAttacks)
                            {
                                maxAttacks = temp;
                                knightRow = row;
                                knightCol = col;
                            }
                        }
                        
                    }
                }
                if (maxAttacks > 0)
                {
                    matrix[knightRow][knightCol] = '0';
                    count++;
                }
                else
                {
                    break;
                }
            }
            

            Console.WriteLine(count);
        }

        private static int CountAttacks(char[][] matrix, int row, int col)
        {
            int attacks = 0;
            if (IsInMatrix(row - 1, col - 2, matrix.Length) && matrix[row - 1][col - 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 1, col + 2, matrix.Length) && matrix[row - 1][col + 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 1, col + 2, matrix.Length) && matrix[row + 1][col + 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 1, col - 2, matrix.Length) && matrix[row + 1][col - 2] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 2, col - 1, matrix.Length) && matrix[row - 2][col - 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row - 2, col + 1, matrix.Length) && matrix[row - 2][col + 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 2, col + 1, matrix.Length) && matrix[row + 2][col + 1] == 'K')
            {
                attacks++;
            }
            if (IsInMatrix(row + 2, col - 1, matrix.Length) && matrix[row + 2][col - 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }
        private static bool IsInMatrix(int row, int col, int length)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }
    }
}
