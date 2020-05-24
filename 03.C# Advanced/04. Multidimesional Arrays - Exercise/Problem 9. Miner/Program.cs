using System;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Problem_9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            char[][] matrix = new char[length][];
            for (int row = 0; row < length; row++)
            {
                matrix[row] = new char[length];
                string input = Console.ReadLine().Trim();
                char[] temp = input.Replace(" ", "").ToCharArray();
                matrix[row] = temp;
            }

            int startRow = 0;
            int startCol = 0;
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if (matrix[row][col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                        break;
                    }
                }
            }

            int count = 0;
            int currentRow = startRow;
            int currentCol = startCol;
            int coalCount = CountOfCoal(matrix);
            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];
                Controller(matrix, ref currentRow, ref currentCol, currentCommand);
                if(matrix[currentRow][currentCol] == 'c')
                {
                    matrix[currentRow][currentCol] = '*';
                    count++;
                    if (coalCount == count)
                    {
                        Console.WriteLine($"You collected all coals! ({currentRow}, {currentCol})");
                        return;
                    }
                }
                if (matrix[currentRow][currentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentRow}, {currentCol})");
                    return;
                }

            }

            Console.WriteLine($"{coalCount - count} coals left. ({currentRow}, {currentCol})");

        }

        public static char[][] Controller(char[][] matrix, ref int currentRow, ref int currentCol,
            string command)
        {
            if (command == "left")
            {
                if (IsInMatrix(matrix.Length, currentRow, currentCol - 1))
                {
                    currentCol--;
                }
            }
            if (command == "right")
            {
                if (IsInMatrix(matrix.Length, currentRow, currentCol + 1))
                {
                    currentCol++;
                }
            }
            if (command == "up")
            {
                if (IsInMatrix(matrix.Length, currentRow - 1, currentCol))
                {
                    currentRow--;
                }
            }
            if (command == "down")
            {
                if (IsInMatrix(matrix.Length, currentRow + 1, currentCol))
                {
                    currentRow++;
                }
            }

            return matrix;
        }
        public static bool IsInMatrix(int length, int row, int col)
        {
            return row >= 0 && row < length && col >= 0 && col < length;
        }

        public static int CountOfCoal(char[][] matrix)
        {
            int count = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix.Length; col++)
                {
                    if (matrix[row][col] == 'c')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
