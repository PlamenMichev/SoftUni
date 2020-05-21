using System;

namespace Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if(figure=="square")
            {
                double side = double.Parse(Console.ReadLine());
                Console.WriteLine(side*side);
            }
            if(figure=="rectangle")
            {
                double sideA = double.Parse(Console.ReadLine());
                double sideB = double.Parse(Console.ReadLine());
                Console.WriteLine(sideA*sideB);
            }
            if(figure=="circle")
            {
                double radius = double.Parse(Console.ReadLine());
                Console.WriteLine(Math.PI*radius*radius);
            }
            if(figure=="triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Console.WriteLine((side*height)/2);
            }

        }
    }
}
