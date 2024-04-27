using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExecuteRawSqlDataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SqlConnection connection = new SqlConnection(configuration.GetConnectionString("DefaultString"));

            string sql = "SELECT * FROM Wallets;";
            
            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                Wallet wallet = new Wallet
                {
                    Id = Convert.ToInt32(row["Id"]),     // (int)reader["Id"]
                    Holder = Convert.ToString(row["Holder"]),
                    Balance = Convert.ToDecimal(row["Balance"])
                };

                Console.WriteLine(wallet);
            }
        }
    }
}
