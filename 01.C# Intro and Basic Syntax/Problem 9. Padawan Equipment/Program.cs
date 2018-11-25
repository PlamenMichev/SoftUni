using System;

namespace Problem_9._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            int freeBelts = 0;
            for(int i=1;i<=students;i++)
            {
                if (i % 6 == 0) 
                {
                    freeBelts += 1;
                }
            }
            double boughtSabers = (students + Math.Ceiling(0.1 * students)) * lightPrice;
            double boughtRobe = robePrice * students;
            double boughtBelts = beltPrice * (students - freeBelts);
            double price = boughtBelts + boughtRobe + boughtSabers;
            if(price<=money)
            {
                Console.WriteLine($"The money is enough - it would cost {price:f2}lv.");
            }
            else Console.WriteLine($"Ivan Cho will need {price-money:f2}lv more.");
        }
    }
}
