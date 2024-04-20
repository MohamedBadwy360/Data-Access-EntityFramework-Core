using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteInsertStoredProcedure
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
                Holder = "Asmaa",
                Balance = 30000
            };


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

            SqlCommand command = new SqlCommand("AddWallet", connection);
            command.Parameters.Add(holderParamter);
            command.Parameters.Add(balanceParameter);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            
            if (command.ExecuteNonQuery() > 0)
            {
                Console.WriteLine($"Wallet for {walletToInsert.Holder} was inserted.");
            }
            else
            {
                Console.WriteLine($"Error => Wallet for {walletToInsert.Holder} was't inserted.");
            }
            
            connection.Close();
        }
    }
}
