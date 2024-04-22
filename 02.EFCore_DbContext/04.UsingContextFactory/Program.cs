using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _04.UsingContextFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            var services = new ServiceCollection();

            services.AddDbContextFactory<AppDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDbContext>>();


            using (var context = contextFactory!.CreateDbContext())
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
