using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.UpdateData
{
    /*  
        A DbContext instance represents a session with the database and can be used to
        query and save instances of your entities. DbContext is a combination of the
        Unit Of Work and Repository patterns. 
    */

    public class AppDbContext : DbContext
    {
        // Represent the collection of all entities
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
