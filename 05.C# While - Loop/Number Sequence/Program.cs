using System;

namespace Number_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int max = Int32.Parse(num);
            int min = Int32.Parse(num);
            while (num != "END")
            {
                if (Int32.Parse(num) > max)
                {
                    max = Int32.Parse(num);
                }
                if (Int32.Parse(num) < min)
                {
                    min = Int32.Parse(num);
                }
                num = Console.ReadLine();
            }
            Console.WriteLine("Max number: "+ max + "\n" + "Min number: "+ min);
        }
    }
}
