using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> bullets = new Stack<int>(bulletsInput);
            int[] locsInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int count = bullets.Count;
            Queue<int> locks = new Queue<int>(locsInput);
            int money = int.Parse(Console.ReadLine());
            int counter = 0;
            while (true)
            {
                counter++;
                if (locks.Any() == false)
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${money - ((count - bullets.Count) * priceOfBullet)}");
                    return;
                }
                else
                {
                    if (bullets.Any() == false)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                        return;
                    }
                    else
                    {
                        int currentBullet = bullets.Pop();
                        int currentLocker = locks.Peek();



                        if (currentBullet <= currentLocker)
                        {
                            locks.Dequeue();
                            Console.WriteLine("Bang!");
                        }
                        else
                        {
                            Console.WriteLine("Ping!");
                        }

                        if (counter % sizeOfGunBarrel == 0 && bullets.Any())
                        {
                            Console.WriteLine("Reloading!");
                        }                        
                    }
                }
            }
        }
    }
}

