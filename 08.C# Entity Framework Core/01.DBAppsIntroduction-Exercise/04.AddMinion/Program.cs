using System;
using System.Data.SqlClient;

namespace _04.AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string minionInput = Console.ReadLine();
            string minionName = minionInput.Split(" ")[1];
            int minionAge = int.Parse(minionInput.Split(" ")[2]);
            string townName = minionInput.Split(" ")[3];

            string villianInput = Console.ReadLine();
            string villianName = villianInput.Split(" ")[1];

            const string connectionString = "Server=DESKTOP-4PCJT2Q\\SQLEXPRESS;Database=MinionsDB;Integrated Security=True";

            var connection = new SqlConnection(connectionString);

            using (connection)
            {
                SqlTransaction transaction = null;

                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    using (var checkTown = new SqlCommand("SELECT * FROM Towns WHERE Name = @townName", connection, transaction))
                    {
                        checkTown.Parameters.AddWithValue("@townName", townName);

                        var value = checkTown.ExecuteScalar();
                        if (value == null)
                        {
                            using (var addTown = new SqlCommand("INSERT INTO Towns(Name) VALUES (@townName)", connection, transaction))
                            {
                                addTown.Parameters.AddWithValue("@townName", townName);

                                addTown.ExecuteNonQuery();
                                Console.WriteLine($"Town {townName} was added to the database.");
                            }
                        }
                    }


                    using (var checkVillian = new SqlCommand("SELECT * FROM Villains WHERE Name = @villianName", connection, transaction))
                    {
                        checkVillian.Parameters.AddWithValue("@villianName", villianName);

                        var value = checkVillian.ExecuteScalar();
                        if (value == null)
                        {
                            using (var addVillian = new SqlCommand("INSERT INTO Villains(Name, EvilnessFactorId) VALUES (@villianName, 4)", connection, transaction))
                            {
                                addVillian.Parameters.AddWithValue("@villianName", villianName);

                                addVillian.ExecuteNonQuery();
                                Console.WriteLine($"Villain {villianName} was added to the database.");
                            }
                        }
                    }

                    using (var getMinion = new SqlCommand("SELECT * FROM Minions WHERE Name = @minionName", connection, transaction))
                    {
                        getMinion.Parameters.AddWithValue("@minionName", minionName);
                        var value = getMinion.ExecuteScalar();
                        //Get villainId
                        var getVillainId = new SqlCommand("SELECT Id FROM Villains WHERE Name = @villainName", connection, transaction);
                        getVillainId.Parameters.AddWithValue("@villainName", villianName);
                        var villianIdValue = getVillainId.ExecuteScalar();
                        int villianId = int.Parse(villianIdValue.ToString());

                        //Get Minion Id
                        var getMinionId = new SqlCommand("SELECT Id FROM Minions WHERE Name = @minionName", connection, transaction);
                        getMinionId.Parameters.AddWithValue("@minionName", minionName);
                        var minionIdValue = getMinionId.ExecuteScalar();
                        int minionId = int.Parse(minionIdValue.ToString());
                        using (var addVillianAndMinion = new SqlCommand("INSERT INTO MinionsVillains(MinionId, VillainId) VALUES (@minionId, @villianId)", connection, transaction))
                        {
                            addVillianAndMinion.Parameters.AddWithValue("@villianId", villianId);
                            addVillianAndMinion.Parameters.AddWithValue("@minionId", minionId);

                            addVillianAndMinion.ExecuteNonQuery();
                            Console.WriteLine($"Successfully added {minionName} to be minion of {villianName}.");
                        }

                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Attempt to roll back the transaction.
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred
                        // on the server that would cause the rollback to fail, such as
                        // a closed connection.
                    }
                }
            }
        }
    }
}
