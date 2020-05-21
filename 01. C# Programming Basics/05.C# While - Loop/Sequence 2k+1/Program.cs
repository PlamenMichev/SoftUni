using System;

namespace Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int otherNum = 1;
            while(otherNum<=num)
            {
                Console.WriteLine(otherNum);
                otherNum = otherNum * 2 + 1;

            }

        }
    }
}
