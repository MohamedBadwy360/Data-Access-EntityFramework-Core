using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteInsertExecuteScalar
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

            Wallet walletToInsert = new Wallet
            {
                Holder = "Elsaid",
                Balance = 20000
            };

            string sql = "INSERT INTO Wallets (Holder, Balance) VALUES (@Holder, @Balance);" +
                "SELECT CAST(scope_identity() AS INT);";

            SqlParameter holderParamter = new SqlParameter
            {
                ParameterName = "@Holder",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Holder
            };

            SqlParameter balanceParameter = new SqlParameter
            {
                ParameterName = "@Balance",
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.Input,
                Value = walletToInsert.Balance
            };

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.Add(holderParamter);
            command.Parameters.Add(balanceParameter);
            command.CommandType = CommandType.Text;

            connection.Open();

            walletToInsert.Id = (int)command.ExecuteScalar();

            Console.WriteLine(walletToInsert);

            connection.Close();
        }
    }
}
