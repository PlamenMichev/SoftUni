using System;
using System.Linq;

namespace Problem_8._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] saveArr = new int[numbers.Length];
            int length = numbers.Length;
            if(length==1)
            {
                Console.WriteLine($"{numbers[0]}");
                return;
            }
            while (length != 0)
            {
                for (int i = 0; i < length-1; i++)
                {
                    saveArr[i]=numbers[i]+numbers[i+1];
                }
                numbers = saveArr;
                length--;
            }

            
                Console.WriteLine(saveArr[0]); 

        }
    }
}
