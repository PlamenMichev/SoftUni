using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Mergin_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> firstList = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();
            List<double> secList = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            int minCount = Math.Min(firstList.Count, secList.Count);
            List<double> result = new List<double>();
            for (int i = 0; i < minCount; i++)
            {
                result.Add(firstList[i]);
                result.Add(secList[i]);
            }
            if(firstList.Count > secList.Count)
            {
                for (int i = minCount; i < firstList.Count; i++)
                {
                    result.Add(firstList[i]);
                }
            }
            else
            {
                for (int i = minCount; i < secList.Count; i++)
                {
                    result.Add(secList[i]);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
