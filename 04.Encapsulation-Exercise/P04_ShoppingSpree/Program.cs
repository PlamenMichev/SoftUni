using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] customers = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productsAsString = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            var people = new List<Person>();
            var products = new List<Product>();
            try
            {
                foreach (var customer in customers)
                {
                    string[] currentCustomer = customer
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = currentCustomer[0];
                    decimal money = decimal.Parse(currentCustomer[1]);

                    var currentPerson = new Person(name, money);
                    people.Add(currentPerson);
                }

                foreach (var product in productsAsString)
                {
                    var currentProduct = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = currentProduct[0];
                    decimal price = decimal.Parse(currentProduct[1]);

                    var newProduct = new Product(name, price);
                    products.Add(newProduct);
                }

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] tokens = input.Split();
                    string name = tokens[0];
                    string product = tokens[1];
                    var currentPerson = people.FirstOrDefault(x => x.Name == name);
                    var currentProduct = products.FirstOrDefault(x => x.Name == product);

                    if (currentPerson.CanBuy(currentProduct))
                    {
                        currentPerson.Buy(currentProduct);
                        Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
                    }
                    else
                    {

                        Console.WriteLine($"{currentPerson.Name} can't afford {currentProduct.Name}");
                    }

                    input = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
