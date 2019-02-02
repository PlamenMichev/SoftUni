using System;
using System.Linq;

namespace Problem_4._Matrix_Shuffling
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
            string[][] matrix = new string[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new string[cols];
                string[] temp = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = temp;
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split();
                if (tokens[0] == "swap" && (tokens.Length == 5))
                {
                    int firstCoordinate = int.Parse(tokens[1]);
                    int secCoordinate = int.Parse(tokens[2]);
                    int thirdCoordinate = int.Parse(tokens[3]);
                    int fourthCoordinate = int.Parse(tokens[4]);
                    if ((firstCoordinate >= 0 && firstCoordinate < rows)
                        &&(thirdCoordinate >= 0 && thirdCoordinate < rows)
                        &&(secCoordinate >= 0 && secCoordinate < cols)
                        &&(fourthCoordinate >= 0 && fourthCoordinate < cols))
                    {
                        string temp = matrix[firstCoordinate][secCoordinate];
                        matrix[firstCoordinate][secCoordinate] = matrix[thirdCoordinate][fourthCoordinate];
                        matrix[thirdCoordinate][fourthCoordinate] = temp;
                        PrintMatrix(rows, cols, matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static void PrintMatrix(int rows, int cols, string[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
