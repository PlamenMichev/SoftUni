using System;

namespace Problem_7._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = 0;
            string product;
            while (true)
            {
                product = Console.ReadLine();
                if (product == "Start")
                {
                    break;
                }
                decimal num = Convert.ToDecimal(product);
                if (num ==  0.1m || num == 0.2m || num == 0.5m || num == 1 || num == 2)
                {
                    money += num;
                }
                else Console.WriteLine($"Cannot accept {num}");
            }
            product = Console.ReadLine();
            decimal price = 0;
            while (product != "End")
            {
                if (product == "Coke")
                {
                    price += 1.0m;
                }
                if (product == "Nuts")
                {
                    price += 2.0m;
                }
                if (product == "Water")
                {
                    price += 0.7m;
                }
                if (product == "Crisps")
                {
                    price += 1.5m;
                }
                if (product == "Soda")
                {
                    price += 0.8m;
                }
                if (product != "Coke" && product != "Nuts" && product != "Water" && product != "Crisps" && product != "Soda")
                {
                    Console.WriteLine("Invalid product");
                }
                else if (money >= price)
                {
                    string productToLower = product.ToLower();
                    Console.WriteLine($"Purchased {productToLower}");
                    money -= price;
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                product = Console.ReadLine();
                price = 0;
            }
            Console.WriteLine($"Change: {(money - price):f2}");

        }
    }
}