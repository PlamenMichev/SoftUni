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

            char[][] matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new char[cols];
                char[] input = Console.ReadLine().ToCharArray();
                matrix[row] = input;
            }

            string commands = Console.ReadLine();
            for (int i = 0; i < commands.Length; i++)
            {
                char direction = commands[i];

                if (direction == 'U')
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row][col] == 'P')
                            {
                                if (!IsInMatrix(matrix.Length, row - 1, col, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    AddBunnes(ref matrix, rows, cols);
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"won: {row} {col}");
                                    return;
                                }
                                if (!IsWin(matrix, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    matrix[row - 1][col] = 'P';
                                    AddBunnes(ref matrix, rows, cols);
                                }

                                if (IsWin(matrix, rows, cols))
                                {
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"dead: {row - 1} {col}");
                                    return;
                                }
                            }                           
                        }
                    }
                }

                if (direction == 'D')
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row][col] == 'P')
                            {
                                if (!IsInMatrix(matrix.Length, row + 1, col, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    AddBunnes(ref matrix, rows, cols);
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"won: {row} {col}");
                                    return;
                                }
                                if (!IsWin(matrix, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    matrix[row + 1][col] = 'P';
                                    AddBunnes(ref matrix, rows, cols);
                                }

                                if (IsWin(matrix, rows, cols))
                                {
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"dead: {row + 1} {col}");
                                    return;
                                }
                            }                           
                        }
                    }
                }

                if (direction == 'R')
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row][col] == 'P')
                            {
                                if (!IsInMatrix(matrix.Length, row, col + 1, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    AddBunnes(ref matrix, rows, cols);
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"won: {row} {col}");
                                    return;
                                }
                                if (!IsWin(matrix, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    matrix[row][col + 1] = 'P';
                                    AddBunnes(ref matrix, rows, cols);
                                }

                                if (IsWin(matrix, rows, cols))
                                {
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"dead: {row} {col + 1}");
                                    return;
                                }
                            }                            
                        }
                    }

                }

                if (direction == 'L')
                {
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row][col] == 'P')
                            {

                                if (!IsInMatrix(matrix.Length, row, col - 1, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    AddBunnes(ref matrix, rows, cols);
                                    PrintMatrix(matrix, rows, cols);                             
                                    Console.WriteLine($"won: {row} {col}");
                                    return;
                                }
                                if (!IsWin(matrix, rows, cols))
                                {
                                    matrix[row][col] = '.';
                                    matrix[row][col - 1] = 'P';
                                    AddBunnes(ref matrix, rows, cols);
                                }
                                
                                if(IsWin(matrix, rows, cols))
                                {
                                    PrintMatrix(matrix, rows, cols);
                                    Console.WriteLine($"dead: {row} {col - 1}");
                                    return;
                                }
                                
                            }
                        }
                    }
                }

            }           
        }

        private static bool IsWin(char[][] matrix, int rows, int cols)
        {
            bool isWin = true;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        isWin = false;
                    }
                }
            }

            return isWin;
        }

        public static char[][] AddBunnes(ref char[][] matrix, int rows, int cols)
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
                if (row + 1 < matrix.Length)
                {
                    matrix[row + 1][col] = 'B';
                }
                if (row - 1 >= 0)
                {
                    matrix[row - 1][col] = 'B';
                }
                if (col - 1 >= 0)
                {
                    matrix[row][col - 1] = 'B';
                }
                if (col + 1 < matrix[0].Length)
                {
                    matrix[row][col + 1] = 'B';
                }
            }

            return matrix;
        }
        public static bool IsInMatrix(int length, int row, int col, int rows, int cols)
            {
                return row >= 0 && row < rows && col >= 0 && col < cols;
            }

        public static void PrintMatrix(char[][] matrix, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
        }
    }
