using System;
using System.Data.SqlClient;

namespace _01.Initial_Setup
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

                using (reader)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine(reader[1]);
                    }
                }
            }
        }
    }
}
