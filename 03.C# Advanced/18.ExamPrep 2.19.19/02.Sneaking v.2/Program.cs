using System;
using System.Linq;

namespace _02.Sneaking_v._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            char[][] room = new char[length][];

            int samRow = -1;
            int samCol = -1;

            for (int i = 0; i < length; i++)
            {
                room[i] = Console.ReadLine().ToCharArray();
                if (room[i].Contains('S'))
                {
                    int index = Array.IndexOf(room[i], 'S');
                    samRow = i;
                    samCol = index;
                    room[samRow][samCol] = '.';
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                MoveEnemies(room);

                if ((room[samRow].Contains('b') && Array.IndexOf(room[samRow], 'b') < samCol) 
                    || room[samRow].Contains('d') && Array.IndexOf(room[samRow], 'd') > samCol)
                {
                    room[samRow][samCol] = 'X';
                    Console.WriteLine($"Sam died at {samRow}, {samCol}");            
                    break;
                }

                switch (command)
                {
                    case 'U': samRow--;
                        break;
                    case 'D':
                        samRow++;
                        break;
                    case 'L':
                        samCol--;
                        break;
                    case 'R':
                        samCol++;
                        break;
                        default: break;
                }

                if (room[samRow][samCol] == 'b' || room[samRow][samCol] == 'd')
                {
                    room[samRow][samCol] = '.';
                }

                if (room[samRow].Contains('N'))
                {
                    int nikoladzeCol = Array.IndexOf(room[samRow], 'N');
                    room[samRow][nikoladzeCol] = 'X';
                    room[samRow][samCol] = 'S';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }

            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int rowLength = matrix[row].Length;
                if (matrix[row].Contains('b') && Array.IndexOf(matrix[row], 'b') < rowLength - 1)
                {
                    int index = Array.IndexOf(matrix[row], 'b');
                    matrix[row][index] = '.';
                    matrix[row][index + 1] = 'b';
                }
                else if (matrix[row].Contains('b') && Array.IndexOf(matrix[row], 'b') == rowLength - 1)
                {
                    matrix[row][rowLength - 1] = 'd';
                }
                else if (matrix[row].Contains('d') && Array.IndexOf(matrix[row], 'd') > 0)
                {
                    int index = Array.IndexOf(matrix[row], 'd');
                    matrix[row][index] = '.';
                    matrix[row][index - 1] = 'd';
                }
                else if (matrix[row].Contains('d') && Array.IndexOf(matrix[row], 'd') == 0)
                {
                    matrix[row][0] = 'b';
                }
            }
        }
    }
}
