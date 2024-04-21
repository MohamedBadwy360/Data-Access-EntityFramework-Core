namespace _08.ImplementTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    // transfer 500$ from wallet with Id = 2 to wallet with Id = 4
                    Wallet fromWallet = context.Wallets.Single(w => w.Id == 2);

                    Wallet toWallet = context.Wallets.Single(w => w.Id == 4);

                    decimal amountToTransfer = 500m;
                    // Operation #1 => withdraw 500$ from wallet with Id = 2
                    fromWallet.Balance -= amountToTransfer;
                    context.SaveChanges();

                    // Operation #1 => deposit 500$ to wallet with Id = 4
                    toWallet.Balance += amountToTransfer;
                    context.SaveChanges();

                    // Commit transaction => apply on database
                    transaction.Commit();
                }
            }
        }
    }
}
