using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowAndCol = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = rowAndCol[0];
            int cols = rowAndCol[1];
            int playerRow = -1;
            int playerCol = -1;

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
                if (matrix[row].Contains('P'))
                {
                    int col = Array.IndexOf(matrix[row], 'P');
                    playerRow = row;
                    playerCol = col;
                    matrix[playerRow][playerCol] = '.';
                }
            }

            string commands = Console.ReadLine();
            string result = string.Empty;
            bool isGameOver = false;
            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];
                if (isGameOver)
                {
                    break;
                }
                switch (direction)
                {
                    case 'U': playerRow--; break;
                    case 'D': playerRow++; break;
                    case 'L': playerCol--; break;
                    case 'R': playerCol++; break;
                }

                if (matrix[playerRow][playerCol] == 'B')
                {
                    result = $"dead: {playerRow} {playerCol}";
                    isGameOver = true;
                }

                if (!IsInMatrix(playerRow, playerCol, rows, cols))
                {
                    switch (direction)
                    {
                        case 'U': playerRow++; break;
                        case 'D': playerRow--; break;
                        case 'L': playerCol++; break;
                        case 'R': playerCol--; break;
                    }

                    result = $"won: {playerRow} {playerCol}";
                    isGameOver = true;
                }

                

                AddBunnes(matrix, rows, cols);

                if (matrix[playerRow][playerCol] == 'B')
                {
                    result = $"dead: {playerRow} {playerCol}";
                    isGameOver = true;
                }
            }
            
            PrintMatrix(matrix);
            Console.WriteLine(result);
        }

        public static char[][] AddBunnes(char[][] matrix, int rows, int cols)
        {
            List<string> bunniesCoordinates = new List<string>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        bunniesCoordinates.Add($"{row} {col}");
                    }
                }
            }

            foreach (var cor in bunniesCoordinates)
            {
                int[] cors = cor
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                int row = cors[0];
                int col = cors[1];
                if (IsInMatrix(row, col + 1, rows, cols))
                {
                    matrix[row][col + 1] = 'B';
                }
                if (IsInMatrix(row, col - 1, rows, cols))
                {
                    matrix[row][col - 1] = 'B';
                }
                if (IsInMatrix(row + 1, col, rows, cols))
                {
                    matrix[row + 1][col] = 'B';
                }
                if (IsInMatrix(row - 1, col, rows, cols))
                {
                    matrix[row - 1][col] = 'B';
                }

            }

            return matrix;
        }
        public static bool IsInMatrix(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        public static void PrintMatrix(char[][] matrix)
        {
            foreach(var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
