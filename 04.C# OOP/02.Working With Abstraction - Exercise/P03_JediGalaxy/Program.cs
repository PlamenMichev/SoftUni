using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                Position evilPosition = new Position(evilCoordinates[0], evilCoordinates[1]);

                while (evilPosition.X >= 0 && evilPosition.Y >= 0)
                {
                    if (evilPosition.X >= 0 && evilPosition.X < matrix.GetLength(0) && evilPosition.Y >= 0 && evilPosition.Y < matrix.GetLength(1))
                    {
                        matrix[evilPosition.X, evilPosition.Y] = 0;
                    }
                    evilPosition.X--;
                    evilPosition.Y--;
                }

                Position ivoPosition = new Position(ivoCoordinates[0], ivoCoordinates[1]);

                while (ivoPosition.X >= 0 && ivoPosition.Y < matrix.GetLength(1))
                {
                    if (ivoPosition.X >= 0 && ivoPosition.X < matrix.GetLength(0) && ivoPosition.Y >= 0 && ivoPosition.Y < matrix.GetLength(1))
                    {
                        sum += matrix[ivoPosition.X, ivoPosition.Y];
                    }

                    ivoPosition.Y++;
                    ivoPosition.X--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}
