using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _07.PrintAllMinionNames
{
    class Program
    {
        static void Main(string[] args)
        {
            //Writing basic code to try out ADO.NET
            string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("SELECT * FROM Minions", connection);
                var reader = command.ExecuteReader();
                var allNames = new List<string>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        allNames.Add(reader[1].ToString());
                    }
                }

                for (int i = 0; i < allNames.Count / 2; i++)
                {
                    Console.WriteLine(allNames[i]);
                    Console.WriteLine(allNames[allNames.Count - i - 1]);
                }
            }
        }
    }
}
