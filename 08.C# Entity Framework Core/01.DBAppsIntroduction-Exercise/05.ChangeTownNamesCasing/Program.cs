using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

            string country = Console.ReadLine();
            var connection = new SqlConnection(connectionString);
            connection.Open();
            using (connection)
            {
                var findCountry = new SqlCommand("SELECT Id FROM Countries WHERE Name = @country", connection);
                findCountry.Parameters.AddWithValue("@country", country);
                var isInDb = findCountry.ExecuteScalar().ToString();

                if (isInDb == null)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }
                else
                {
                    int id = int.Parse(isInDb);
                    var command = new SqlCommand("SELECT Name FROM Towns WHERE CountryCode = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    var containsTowns = command.ExecuteScalar();
                    if (containsTowns == null)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }
                    var reader = command.ExecuteReader();

                    var updatedNames = new List<string>();
                    using (reader)
                    {
                        while(reader.Read())
                        {
                            updatedNames.Add(reader[0].ToString().ToUpper());
                        }
                    }

                    Console.WriteLine($"{updatedNames.Count} town names were affected.");
                    Console.WriteLine("[" + String.Join(", ", updatedNames) + "]");
                    for (int i = 0; i < updatedNames.Count; i++)
                    {
                        using (var updTowns = new SqlCommand("UPDATE Towns SET Name = @townName WHERE LOWER(Name) = LOWER(@townName)", connection))
                        {
                            updTowns.Parameters.AddWithValue("@townName", updatedNames[i]);

                            updTowns.ExecuteNonQuery();
                        }
                    }
                    
                }
            }
        }
    }
}
