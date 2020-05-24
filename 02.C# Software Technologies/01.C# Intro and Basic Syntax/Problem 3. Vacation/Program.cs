using System;

namespace Problem_3._Vacation
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            double sum = 0;
            if(typeOfGroup=="Students")
            {
                if(day=="Friday")
                {
                    sum += 8.45 * count;
                }
                if(day=="Saturday")
                {
                    sum += 9.80 * count;
                }
                if(day=="Sunday")
                {
                    sum += 10.46 * count;
                }
                if(count>=30)
                {
                    sum -= 0.15 * sum;
                }
            }
            if (typeOfGroup == "Business")
            {
                if (count >= 100)
                {
                    count -= 10;
                }
                if (day == "Friday")
                {
                    sum += 10.90 * count;
                }
                if (day == "Saturday")
                {
                    sum += 15.60 * count;
                }
                if (day == "Sunday")
                {
                    sum += 16.00 * count;
                }       
            }
            if (typeOfGroup == "Regular")
            {
                if (day == "Friday")
                {
                    sum += 15 * count;
                }
                if (day == "Saturday")
                {
                    sum += 20 * count;
                }
                if (day == "Sunday")
                {
                    sum += 22.50 * count;
                }
                if (count >= 10 && count<=20)
                {
                    sum -= 0.05 * sum;
                }
            }
            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
