using _01.DBTransactions.Entities;
using C01.DBTransactions.Data;
using C01.DBTransactions.Entities;

namespace C01.DBTransactions.Helpers
{
    public static class DatabaseHelper
    {
        public static void RecreateCleanDatabase()
        {
            using var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void PopulateDatabase()
        {
            using (var context = new AppDbContext())
            {
                context.BankAccounts.AddRange(new BankAccount[]
                {
                    new BankAccount
                    {
                        AccountId = "1",
                        AccountHolder = "Ahmed Ali",
                        CurrentBalance = 10000m
                    },
                    new BankAccount
                    {
                        AccountId = "2",
                        AccountHolder = "Sameh Ahmed",
                        CurrentBalance = 14000m
                    },
                    new BankAccount
                    {
                        AccountId = "3",
                        AccountHolder = "Rana Salem",
                        CurrentBalance = 14000m
                    }
                });
                    
                context.SaveChanges();
            }
        }
    }
}
