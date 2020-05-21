using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string steps = Console.ReadLine();
            int sum = 0;
            while (steps != "Going home")
            {
                sum += int.Parse(steps);
                if (sum >= 10000)
                {
                    Console.WriteLine("Goal reached! Good job!");
                    return;
                }
                else steps = Console.ReadLine();
            }
            int stepsToHome = int.Parse(Console.ReadLine());
            sum += stepsToHome;
            if (sum >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else Console.WriteLine($"{10000 - sum} more steps to reach goal.");
        }
    }
}
