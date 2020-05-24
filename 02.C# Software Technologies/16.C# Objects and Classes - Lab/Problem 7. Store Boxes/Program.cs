using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_7._Store_Boxes
{
    class Program
    {
        class  Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public double PriceBox { get; set; }
        }
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] tokens = input.Split();
                string serialNumber = tokens[0];
                string nameOfProduct = tokens[1];
                int quantity = int.Parse(tokens[2]);
                double price = double.Parse(tokens[3]);
                Box box = new Box();
                box.Item = new Item
                {
                    Name = nameOfProduct,
                    Price = price
                };
                box.SerialNumber = serialNumber;
                box.Quantity = quantity;
                box.PriceBox = price * quantity;
                boxes.Add(box);
            }

            foreach (var item in boxes.OrderByDescending(x=>x.PriceBox))
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"-- {item.Item.Name} - ${item.Item.Price:f2}: {item.Quantity}");
                Console.WriteLine($"-- ${item.PriceBox:f2}");
            }
        }
    }
}
