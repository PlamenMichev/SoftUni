using System;

namespace Problem_10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int power = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int count = 0;
            int savePower = power;
            while(power>=distance)
            {
                power -= distance;
                count++;
                if(power==savePower*0.5)
                {
                    if(exhaustionFactor>0)
                    {
                        power /= exhaustionFactor;
                    }
                }  
            }
            Console.WriteLine(power+"\n"+count);
        }
    }
}
