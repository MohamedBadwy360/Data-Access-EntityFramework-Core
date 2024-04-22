using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var configuration = new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    string connectionString = configuration.GetConnectionString("DefaultString")!;

        //    optionsBuilder.UseSqlServer(connectionString);
        //}
    }
}
