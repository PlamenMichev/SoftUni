using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace _05.Rubick_s_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int rows = dimension[0];
            int cols = dimension[1];

            int[][] matrix = new int[rows][];
            GetMatrix(matrix, cols);

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                int rowColIndex = int.Parse(input[0]);
                string direction = input[1];
                int moves = int.Parse(input[2]);

                if (direction == "down")
                {
                    MoveDown(matrix, rowColIndex, moves % matrix.Length);
                }
                else if (direction == "left")
                {
                    MoveLeft(matrix, rowColIndex, moves % matrix[rows - 1].Length);
                }
                else if (direction == "right")
                {
                    MoveRight(matrix, rowColIndex, moves % matrix[rows - 1].Length);
                }
                else if (direction == "up")
                {
                    MoveUp(matrix, rowColIndex, moves % matrix.Length);
                }
            }

            int counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == counter)
                    {
                        Console.WriteLine($"No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearrange(matrix, row, col, counter);
                        counter++;
                    }
                }
            }
        }

        private static void Rearrange(int[][] matrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < matrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < matrix[targetRow].Length; targetCol++)
                {
                    if (matrix[targetRow][targetCol] == counter)
                    {
                        matrix[targetRow][targetCol] = matrix[row][col];
                        matrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveUp(int[][] matrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstNumber = matrix[0][col];
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][col] = matrix[row + 1][col];
                }

                matrix[matrix.Length - 1][col] = firstNumber;
            }
        }

        private static void MoveRight(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[row][matrix[row].Length - 1];
                for (int col = matrix.Length - 1; col > 0; col--)
                {
                    matrix[row][col] = matrix[row][col - 1];
                }

                matrix[row][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[row][0];
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    matrix[row][col] = matrix[row][col + 1];
                }

                matrix[row][matrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] matrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = matrix[matrix.Length - 1][col];
                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][col] = matrix[row - 1][col];
                }

                matrix[0][col] = lastElement;
            }
        }

        private static void Print(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static void GetMatrix(int[][] matrix, int cols)
        {
            int counter = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter++;
                }
            }
        }
    }
}
