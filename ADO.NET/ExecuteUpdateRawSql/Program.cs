using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteUpdateRawSql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultString"));

            Wallet walletToUpdate = new Wallet
            {
                Id = 1,
                Holder = "Ahmed",
                Balance = 9000
            };

            string sql = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance WHERE Id = @Id;";
            SqlParameter idParamater = new SqlParameter
            {
                ParameterName = "@Id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Input,
                Value = walletToUpdate.Id
            };

            SqlParameter holderParamter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = walletToUpdate.Holder
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = walletToUpdate.Balance
            };

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(idParamater);
            command.Parameters.Add(holderParamter);
            command.Parameters.Add(balanceParameter);
            command.CommandType = CommandType.Text;

            connection.Open();

            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Wallet for {walletToUpdate.Holder} was updated.");
            }
            else
            {
                Console.WriteLine($"Error => Wallet for {walletToUpdate.Holder} was't updated.");
            }

            connection.Close();
        }
    }
}
