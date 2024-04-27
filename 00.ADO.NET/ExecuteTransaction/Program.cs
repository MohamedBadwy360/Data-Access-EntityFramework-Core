using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteTransaction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultString"));

            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;

            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "UPDATE Wallets SET Balance = Balance - 1000 WHERE Id = 2;";
                command.ExecuteNonQuery();

                command.CommandText = "UPDATE Wallets SET Balance = Balance + 1000 WHERE Id = 1;";
                command.ExecuteNonQuery();

                transaction.Commit();

                Console.WriteLine("Transaction completed Successfully.");
            }
            catch
            {
                try
                {
                    transaction.Rollback();

                    Console.WriteLine("Transaction failed.");
                }
                catch
                {
                    // log
                }
            }
            finally
            {
                try
                {
                    connection.Close();
                }
                catch
                {
                    // log
                }
            }
        }
    }
}
