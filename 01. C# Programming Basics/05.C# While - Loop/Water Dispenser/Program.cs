using System;

namespace Water_Dispenser
{
    class Program
    {
        static void Main(string[] args)
        {
            double size = double.Parse(Console.ReadLine());
            int count = 0;
            int sum = 0;
            while(true)
            {
                string button = Console.ReadLine();
                switch(button)
                {
                    case "Easy":sum += 50;count++;break;
                    case "Medium":sum += 100;count++;break;
                    case "Hard":sum += 200;count++;break;
                }
                if(size==sum)
                {
                    Console.WriteLine($"The dispenser has been tapped {count} times.");
                    return;
                }
                if(size<sum)
                {
                    Console.WriteLine($"{sum-size}ml has been spilled.");
                    return;
                }
            }
        }
    }
}
