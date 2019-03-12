using System;

namespace P01.ClassBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {box.SurfaceArea(length, width, height):f2}");
            Console.WriteLine($"Lateral Surface Area - {box.LiteralSurfaceArea(length, width, height):f2}");
            Console.WriteLine($"Volume - {box.Volume(length, width, height):f2}");
        }
    }
}
