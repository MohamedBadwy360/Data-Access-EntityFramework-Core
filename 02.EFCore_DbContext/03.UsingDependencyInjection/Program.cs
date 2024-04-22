using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _03.UsingDependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configure DbContext Using Dependency Injection
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            using (AppDbContext context = serviceProvider.GetService<AppDbContext>()!)
            {
                foreach (var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
