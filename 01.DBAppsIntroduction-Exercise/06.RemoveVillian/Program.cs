using System;
using System.Data.SqlClient;

namespace _06.RemoveVillian
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

            string villianId = Console.ReadLine();
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                var isInDb = new SqlCommand("SELECT Name FROM Villains WHERE Id = @id", connection);
                isInDb.Parameters.AddWithValue("@id", villianId);
                var isInBase = isInDb.ExecuteScalar();
                if (isInBase == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                var getVillainMinions = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @id", connection);
                getVillainMinions.Parameters.AddWithValue("@id", villianId);
                string count = getVillainMinions.ExecuteScalar().ToString();
                Console.WriteLine($"{isInBase} was deleted.");
                Console.WriteLine($"{count} minions were released.");


                var deleteVillainMinions = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @id", connection);
                deleteVillainMinions.Parameters.AddWithValue("@id", villianId);
                deleteVillainMinions.ExecuteNonQuery();

                var deleteVillain = new SqlCommand("DELETE FROM Villains WHERE Id = @id", connection);
                deleteVillain.Parameters.AddWithValue("@id", villianId);
                deleteVillain.ExecuteNonQuery();
            }
        }
    }
}
