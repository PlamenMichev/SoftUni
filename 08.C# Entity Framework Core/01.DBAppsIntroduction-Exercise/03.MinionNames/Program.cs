using System;
using System.Data.SqlClient;

namespace _03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            int villianId = int.Parse(Console.ReadLine());

            using (connection)
            {
                var villianNameCommand = new SqlCommand("SELECT Name FROM Villains WHERE Id = @villianId", connection);
                villianNameCommand.Parameters.AddWithValue("@villianId", villianId);
                var nameReader = villianNameCommand.ExecuteReader();

                using (nameReader)
                {
                    if (nameReader.Read() == false)
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Villain: {nameReader[0]}");
                    }
                }
            }

            var secondConnection = new SqlConnection(connectionString);
            secondConnection.Open();

            using (secondConnection)
            {
                var command = new SqlCommand("SELECT ROW_NUMBER() OVER (ORDER BY m.Name), m.Name, m.Age FROM Villains v JOIN MinionsVillains mv ON mv.VillainId = v.Id JOIN Minions m ON mv.MinionId = m.Id WHERE @villianId = v.Id ORDER BY m.Name", secondConnection);

                command.Parameters.AddWithValue("@villianId", villianId);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    if (reader.Read() == false)
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }
                    else if (reader.Read() == false)
                    {
                        Console.WriteLine($"(no minions)");
                        return;
                    } 
                    else
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (i == 0)
                            {
                                Console.Write(reader[i] + ". ");

                            }
                            else
                            {
                                Console.Write(reader[i] + " ");
                            }
                        }

                        Console.WriteLine();

                        while (reader.Read())
                        {

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                if (i == 0)
                                {
                                    Console.Write(reader[i] + ". ");

                                }
                                else
                                {
                                    Console.Write(reader[i] + " ");
                                }
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
