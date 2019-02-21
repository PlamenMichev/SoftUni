using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.RectangleIntersection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                            
            List<Rectangle> rectangles = new List<Rectangle>();
            for (int i = 0; i < nums[0]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double row = double.Parse(input[3]);
                double col = double.Parse(input[4]);

                var currentRectangle = new Rectangle
                {
                    Id = id,
                    Width = width,
                    Height = height,
                    Row = row,
                    Col = col
                };
                rectangles.Add(currentRectangle);
            }

            for (int i = 0; i < nums[1]; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == input[0]);
                Rectangle secRectangle = rectangles.FirstOrDefault(x => x.Id == input[1]);

                Console.WriteLine(firstRectangle.AreIntersected(secRectangle).ToString().ToLower());
            }
        }
    }
}
