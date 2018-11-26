using System;
using System.Numerics;

namespace Problem_8._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int snowSave = 0;
            int timeSave = 0;
            int qualitySave = 0;
            BigInteger maxValue = 0;
            for (int i=1; i<=num;i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger value= BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);                            
                if (value > maxValue)
                {
                    snowSave = snowballSnow;
                    timeSave = snowballTime;
                    qualitySave = snowballQuality;
                    maxValue = value;
                }
            }
            Console.WriteLine($"{snowSave} : {timeSave} = {maxValue} ({qualitySave})");
            
        }
    }
}
