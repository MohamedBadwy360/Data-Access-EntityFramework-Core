using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _02.ExternalConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // External Configuration 
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            var optionsBuilder = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString);

            var options = optionsBuilder.Options; 

            using (AppDbContext context = new AppDbContext(options))
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
