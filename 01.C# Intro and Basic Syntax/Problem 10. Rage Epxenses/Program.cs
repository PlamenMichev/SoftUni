using System;

namespace Problem_10._Rage_Epxenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int games = int.Parse(Console.ReadLine());
            double headPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int countHead = 0;
            int countMouse = 0;
            int countKey = 0;
            int countDisplay = 0;
            for (int i = 1; i <= games; i++)
            {
                if (i % 2 == 0)
                {
                    countHead++;
                }
                if (i % 3 == 0)
                {
                    countMouse++;
                }
                if (i % 3 == 0 && i % 2 == 0)
                {
                    countKey++;
                }
                if (countKey % 2 == 0 && i % 6 == 0)
                {
                    countDisplay++;
                }
            }
            double totalPrice = (countHead * headPrice) + (countMouse * mousePrice) + (countKey * keyPrice) + (countDisplay * displayPrice);
            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");
        }
    }
}
