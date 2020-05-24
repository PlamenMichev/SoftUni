using System;
using System.Globalization;
using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController restaurantController = new RestaurantController();
            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string command = tokens[0];

                    switch (command)
                    {
                        case "AddFood":
                            {
                                string type = tokens[1];
                                string name = tokens[2];
                                decimal price = decimal.Parse(tokens[3]);

                                Console.WriteLine(restaurantController.AddFood(type, name, price));
                            }
                            break;
                        case "AddDrink":
                            {
                                string type = tokens[1];
                                string name = tokens[2];
                                int servingSize = int.Parse(tokens[3]);
                                string brand = tokens[4];

                                Console.WriteLine(restaurantController.AddDrink(type, name, servingSize, brand));
                            }
                            break;
                        case "AddTable":
                            {
                                string type = tokens[1];
                                int number = int.Parse(tokens[2]);
                                int capacity = int.Parse(tokens[3]);

                                Console.WriteLine(restaurantController.AddTable(type, number, capacity));
                            }
                            break;
                        case "ReserveTable":
                            {
                                int numberOfPeople = int.Parse(tokens[1]);

                                Console.WriteLine(restaurantController.ReserveTable(numberOfPeople));
                            }
                            break;
                        case "OrderFood":
                            {
                                int tableNumber = int.Parse(tokens[1]);
                                string foodName = tokens[2];

                                Console.WriteLine(restaurantController.OrderFood(tableNumber, foodName));
                            }
                            break;
                        case "OrderDrink":
                            {
                                int tableNumber = int.Parse(tokens[1]);
                                string drinkName = tokens[2];
                                string drinkBrand = tokens[3];

                                Console.WriteLine(restaurantController.OrderDrink(tableNumber, drinkName, drinkBrand));
                            }
                            break;
                        case "LeaveTable":
                            {
                                int tableNumber = int.Parse(tokens[1]);

                                Console.WriteLine(restaurantController.LeaveTable(tableNumber));
                            }
                            break;
                        case "GetFreeTablesInfo":
                            {
                                Console.WriteLine(restaurantController.GetFreeTablesInfo());
                            }
                            break;
                        case "GetOccupiedTablesInfo":
                            {
                                Console.WriteLine(restaurantController.GetOccupiedTablesInfo());
                            }
                            break;
                    }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.InnerException.Message);
                    }

                input = Console.ReadLine();
            }

            Console.WriteLine(restaurantController.GetSummary());
        }
    }
}
