using System;
using System.Collections.Generic;

namespace Problem_4._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersAppearences = new Dictionary<int, int>();
            for (int i = 0; i < length; i++)
            {
                int temp = int.Parse(Console.ReadLine());
                if (!numbersAppearences.ContainsKey(temp))
                {
                    numbersAppearences[temp] = 0;
                }
                numbersAppearences[temp]++;                
            }

            foreach (var kvp in numbersAppearences)
            {
                int temp = kvp.Key;
                int value = kvp.Value;
                if (value % 2 == 0)
                {
                    Console.WriteLine(temp);
                    return;
                }
            }
        }
    }
}
