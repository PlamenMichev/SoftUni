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
                int bombRow = int.Parse(currentBomb[0]);
                int bombCol = int.Parse(currentBomb[1]);
                int damage = matrix[bombRow][bombCol];
                if(damage > 0)
                {
                    for (int row = bombRow - 1; row <= bombRow + 1; row++)
                    {
                        for (int col = bombCol - 1; col <= bombCol + 1; col++)
                        {
                            if (IsInside(matrix, row, col))
                            {
                                if (matrix[row][col] > 0)
                                {
                                    matrix[row][col] -= damage;
                                }
                            }
                        }
                    }
                    matrix[bombRow][bombCol] = 0;
                }             
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

        private static bool IsInside(int[][] matrix, int bombRow, int bombCol)
        {
            return bombRow >= 0 && bombRow < matrix.Length && bombCol >= 0 && bombCol < matrix[bombRow].Length;
        }

    }
}