using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Channels;

namespace DbContextAndConcurrency
{
    internal class Program
    {
        static AppDbContext context;
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(connectionString));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            context = serviceProvider.GetRequiredService<AppDbContext>();

            var tasks = new[]
            {
                Task.Factory.StartNew(() => Job1()),
                Task.Factory.StartNew(() => Job2())
            };

            Task.WhenAll(tasks).ContinueWith(t => {
                Console.WriteLine("Job1 & Job2 are completed.");
            });

            Console.ReadLine();
        }

        static async Task Job1()
        {
            var wallet = new Wallet { Holder = "Badwy", Balance = 60000m };

            context.Wallets.Add(wallet);

            await context.SaveChangesAsync();
        }

        static async Task Job2()
        {
            var wallet = new Wallet { Holder = "Amina", Balance = 6000m };

            context.Wallets.Add(wallet);

            await context.SaveChangesAsync();
        }

        //static void Job1()
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    string connectionString = configuration.GetConnectionString("DefaultString")!;

        //    var services = new ServiceCollection();

        //    services.AddDbContext<AppDbContext>(optionsBuilder =>
        //        optionsBuilder.UseSqlServer(connectionString));

        //    IServiceProvider serviceProvider = services.BuildServiceProvider();

        //    using (var context = serviceProvider.GetRequiredService<AppDbContext>())
        //    {
        //        var wallet = new Wallet { Holder = "Mahasen", Balance = 20000m };

        //        context.Wallets.Add(wallet);

        //        context.SaveChanges();
        //    }
        //}

        //static void Job2()
        //{
        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    string connectionString = configuration.GetConnectionString("DefaultString")!;

        //    var services = new ServiceCollection();

        //    services.AddDbContext<AppDbContext>(optionsBuilder =>
        //        optionsBuilder.UseSqlServer(connectionString));

        //    IServiceProvider serviceProvider = services.BuildServiceProvider();

        //    using (var context = serviceProvider.GetRequiredService<AppDbContext>())
        //    {
        //        var wallet = new Wallet { Holder = "Hanem", Balance = 40000m };

        //        context.Wallets.Add(wallet);

        //        context.SaveChanges();
        //    }
        //}
    }
}
