using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            if(projection=="Premiere")
            {
                Console.WriteLine($"{(rows*columns)*12.00:f2} leva");
            }
            if (projection == "Normal")
            {
                Console.WriteLine($"{(rows * columns) * 7.50:f2} leva");
            }
            if (projection == "Discount")
            {
                Console.WriteLine($"{(rows * columns) * 5.00:f2} leva");
            }
        }
    }
}
