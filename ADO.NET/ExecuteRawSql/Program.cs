using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //Console.WriteLine(configuration.GetSection("ConnectionStrings:DefaultString").Value);
            //Console.WriteLine(configuration.GetConnectionString("DefaultString"));
            //Console.WriteLine(configuration.GetSection("ConnectionStrings")["DefaultString"]);

            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultString"));

            string sql = "SELECT * FROM Wallets;";

            SqlCommand command = new SqlCommand(sql, connection);
            command.CommandType = CommandType.Text;

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Wallet wallet = new Wallet
                {
                    Id = reader.GetInt32("Id"),     // (int)reader["Id"]
                    Holder = reader.GetString("Holder"),
                    Balance = reader.GetDecimal("Balance")
                };

                Console.WriteLine(wallet);
            }

            connection.Close();
        }
    }
}
