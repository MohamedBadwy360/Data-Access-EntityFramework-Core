using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteDeleteRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultString"));

            string sql = "DELETE FROM Wallets WHERE Id = @Id;";

            SqlParameter idParamter = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = 6
            };

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(idParamter);
            command.CommandType = CommandType.Text;

            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Deleted Successfully.");
            }
            else
            {
                Console.WriteLine($"Error.");
            }

            connection.Close();
        }
    }
}
