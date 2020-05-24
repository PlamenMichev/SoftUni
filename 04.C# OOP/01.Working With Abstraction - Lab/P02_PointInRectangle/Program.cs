using System;
using System.Linq;

namespace P02_PointInRectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var topLeft = new Point(coordinates[0], coordinates[1]);
            var botRoght = new Point(coordinates[2], coordinates[3]);

            var rectanle = new Rectangle(topLeft, botRoght);

            int length = int.Parse(Console.ReadLine());
            for (int i = 0; i < length; i++)
            {
                int[] currentCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                var currentPoint = new Point(currentCoordinates[0], currentCoordinates[1]);

                if (rectanle.Contains(currentPoint))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}
