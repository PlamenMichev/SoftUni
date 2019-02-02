using System;
using System.Linq;

namespace Problem_8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int[][] matrix = new int[length][];
            for (int i = 0; i < length; i++)
            {
                matrix[i] = new int[length];
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[i] = input;
            }

            string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < bombs.Length; i++)
            {
                string[] currentBomb = bombs[i].Split(",", StringSplitOptions.RemoveEmptyEntries);
                int currentRow = int.Parse(currentBomb[0]);
                int currentCol = int.Parse(currentBomb[1]);
                for (int row = 0; row < length; row++)
                {
                    for (int col = 0; col < length; col++)
                    {
                        if (IsHit(matrix, row, col, currentRow, currentCol))
                        {
                            matrix[row][col] -= matrix[currentRow][currentCol];
                        }
                    }
                }
                matrix[currentRow][currentCol] = 0;
            }

            int count = 0;
            int sum = 0;
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        count++;
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(x => string.Join(" ", x))));
        }

        public static bool IsHit(int[][] matrix, int row, int col, int bombRow, int bombCol)
        {
            return ((row == bombRow - 1 && col == bombCol)
                   || (row == bombRow && col == bombCol - 1)
                   || (row == bombRow + 1 && col == bombCol + 1)
                   || (row == bombRow - 1 && col == bombCol + 1)
                   || (row == bombRow + 1 && col == bombCol - 1)
                   || (row == bombRow - 1 && col == bombCol - 1)
                   || (row == bombRow && col == bombCol + 1)
                   || (row == bombRow + 1 && col == bombCol))
                    && (matrix[row][col] > 0);
        }
    }
}