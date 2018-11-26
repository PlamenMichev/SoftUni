using System;

namespace Problem_3._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double firstMoney = money;
            string game = Console.ReadLine();
            while(game!="Game Time")
            {
                
                if(game=="OutFall 4")
                {
                    money -= 39.99;
                    if (money<0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 39.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if (game == "CS:OG")
                {
                    money -= 15.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 15.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if (game == "Zplinter Zell")
                {
                    money -= 19.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 19.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if (game == "Honored 2")
                {
                    money -= 59.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 59.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch")
                {
                    money -= 29.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 29.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if (game == "RoverWatch Origins Edition")
                {
                    money -= 39.99;
                    if (money < 0)
                    {
                        Console.WriteLine("Too Expensive");
                        money += 39.99;
                    }
                    else Console.WriteLine($"Bought {game}");
                }
                else if(game != "OutFall 4" &&
                    game != "CS:OG" &&
                    game != "Zplinter Zell" &&
                    game != "Honored 2" &&
                    game != "RoverWatch" &&
                    game != "RoverWatch Origins Edition")
                {
                    Console.WriteLine("Not Found");
                }
                if(money<0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                game = Console.ReadLine();
            }
            if(money>=0.0)
            {
                Console.WriteLine($"Total spent: ${firstMoney-money}. Remaining: ${money:f2}");
            }
            
        }
    }
}
