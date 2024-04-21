using Microsoft.Extensions.Configuration;

namespace _01.SetupEFCoreModel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            //string connectionString = configuration.GetSection("ConnectionStrings:DefaultString").Value;
            //string connectionString = configuration.GetConnectionString("DefaultString");
            string connectionString = configuration.GetSection("ConnectionStrings")["DefaultString"];

            Console.WriteLine(connectionString);
        }
    }
}
