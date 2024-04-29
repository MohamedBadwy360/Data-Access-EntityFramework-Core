
using _01.DBTransactions.Entities;
using C01.DBTransactions.Data;
using C01.DBTransactions.Helpers;

namespace _01.DBTransactions
{
    internal class Program
    {
        private static Random rendom = new Random();
        static void Main(string[] args)
        {
            //Run_Initial_Transfer_WalkThrough();

            //Run_Changes_Within_Multiple_SaveChanges();

            //Run_Changes_Within_Single_SaveChanges();

            //Run_Changes_Within_Multiple_SaveChanges_In_DbTransaction();

            Run_Changes_Within_Multiple_SaveChanges_In_DbTransaction_BestPractices();
        }


        private static void Run_Initial_Transfer_WalkThrough()
        {
            var account1 = new BankAccount
            {
                AccountId = "1",
                AccountHolder = "Ahmed Salem",
                CurrentBalance = 1000m
            };

            var account2 = new BankAccount
            {
                AccountId = "2",
                AccountHolder = "Rana Salem",
                CurrentBalance = 400m
            };

            decimal amountToTransfer = 100m;

            account1.Withdraw(amountToTransfer);

            account2.Deposit(amountToTransfer);
        }

        private static void Run_Changes_Within_Multiple_SaveChanges()
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();
            using (var context = new AppDbContext())
            {
                var account1 = context.BankAccounts.Find("1");
                var account2 = context.BankAccounts.Find("2");

                decimal amountToTransfer = 100m;

                account1?.Withdraw(amountToTransfer);
                context.SaveChanges();

                if (rendom.Next(0, 3) == 0)
                {
                    throw new Exception();
                }

                account2?.Deposit(amountToTransfer);
                context.SaveChanges();
            }
        }


        private static void Run_Changes_Within_Single_SaveChanges()
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();
            using (var context = new AppDbContext())
            {
                var account1 = context.BankAccounts.Find("1");
                var account2 = context.BankAccounts.Find("2");

                decimal amountToTransfer = 100m;

                account1?.Withdraw(amountToTransfer);

                if (rendom.Next(0, 3) == 0)
                {
                    throw new Exception();
                }

                account2?.Deposit(amountToTransfer);


                context.SaveChanges();  // EF by default ensure that all chnages will be in a transaction.
            }
        }


        private static void Run_Changes_Within_Multiple_SaveChanges_In_DbTransaction()
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var account1 = context.BankAccounts.Find("1");
                    var account2 = context.BankAccounts.Find("2");

                    decimal amountToTransfer = 100m;

                    account1?.Withdraw(amountToTransfer);
                    context.SaveChanges();

                    if (rendom.Next(0, 3) == 0)
                    {
                        throw new Exception();
                    }

                    account2?.Deposit(amountToTransfer);
                    context.SaveChanges();

                    transaction.Commit();
                }
            }
        }


        private static void Run_Changes_Within_Multiple_SaveChanges_In_DbTransaction_BestPractices()
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var account1 = context.BankAccounts.Find("1");
                        var account2 = context.BankAccounts.Find("2");

                        decimal amountToTransfer = 100m;

                        account1?.Withdraw(amountToTransfer);
                        context.SaveChanges();

                        if (rendom.Next(0, 3) == 0)
                        {
                            throw new Exception();
                        }

                        account2?.Deposit(amountToTransfer);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        private static void Run_Changes_DbTransaction_SavePoints()
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();
            using (var context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var account1 = context.BankAccounts.Find("1");
                        var account2 = context.BankAccounts.Find("2");

                        transaction.CreateSavepoint("read_accounts");
                        decimal amountToTransfer = 100m;

                        account1?.Withdraw(amountToTransfer);
                        context.SaveChanges();

                        transaction.CreateSavepoint("withdraw");

                        if (rendom.Next(0, 3) == 0)
                        {
                            throw new Exception();
                        }

                        account2?.Deposit(amountToTransfer);
                        context.SaveChanges();

                        transaction.CreateSavepoint("deposit");

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.RollbackToSavepoint("read_accounts");
                    }
                }
            }
        }
    }
}
