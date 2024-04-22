using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Channels;

namespace _05.DbContextLifeTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            var optionsBuilder = new DbContextOptionsBuilder();

            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information);

            var options = optionsBuilder.Options;

            // The Life Time of DbContext Starts
            using (AppDbContext context = new AppDbContext(options))
            {
                Wallet w1 = new Wallet { Holder = "Saad", Balance = 1000m };

                // DbContext start tracking object w1
                context.Wallets.Add(w1);

                Wallet w2 = new Wallet { Holder = "Hesham", Balance = 2000m };

                // DbContext start tracking object w2
                context.Wallets.Add(w2);

                // Changes will be stored on database
                context.SaveChanges();

                // DbContext Life Time Ends
            }
        }
    }
}
