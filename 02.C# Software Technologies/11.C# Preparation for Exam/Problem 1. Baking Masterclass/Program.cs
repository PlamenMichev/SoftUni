using System;

namespace Problem_1._Baking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            short students = short.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());
            double totalSum = 0;
            int countOfFree = students / 5;
            totalSum += priceOfApron * (students + Math.Ceiling(0.2 * students));
            totalSum += priceOfEgg * 10 * (students);
            totalSum += priceOfFlour * (students - countOfFree);


            if (totalSum <= budget)
            {
                Console.WriteLine($"Items purchased for {totalSum:f2}$.");
            }
            else Console.WriteLine($"{totalSum-budget:f2}$ more needed.");
        }
    }
}
