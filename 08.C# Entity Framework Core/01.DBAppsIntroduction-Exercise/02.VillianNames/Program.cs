using System;
using System.Data.SqlClient;

namespace _02.VillianNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("SELECT Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains v JOIN MinionsVillains mv ON v.Id = mv.VillainId GROUP BY v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(*) DESC", connection);

                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + " ");
                        }

                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
