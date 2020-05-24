using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int freeWindowSecs = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    Console.WriteLine($"Everyone is safe. \n{passedCars} total cars passed the crossroads.");
                    break;
                }
                int secondsLeft = seconds;
                int timeLeft = freeWindowSecs;
                if (input == "green")
                {
                    while (cars.Any() && secondsLeft > 0)
                    {
                        string car = cars.Dequeue();
                        if (car.Length <= secondsLeft)
                        {
                            passedCars++;
                            secondsLeft -= car.Length;
                        }
                        else
                        {
                            if (car.Length <= secondsLeft + timeLeft)
                            {
                                passedCars++;
                                secondsLeft = 0;
                            }
                            else
                            {
                                int remainingTime = secondsLeft + timeLeft;
                                for (int i = 0; i < car.Length; i++)
                                {
                                    remainingTime--;
                                    if (remainingTime < 0)
                                    {
                                        Console.WriteLine($"A crash happened! \n{car} was hit at {car[i]}.");
                                        return;
                                    }
                                }
                            }
                        }
                        
                    }                    
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }
}
