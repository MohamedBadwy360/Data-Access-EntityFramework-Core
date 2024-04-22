using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data;

namespace _07.UsingContextPooling
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

            // Using context pooling
            services.AddDbContextPool<AppDbContext>(optionsBuilder =>
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
