namespace _05.UpdateData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Update wallet with Id = 2
            using (AppDbContext context = new AppDbContext())
            {
                Wallet wallet = context.Wallets.Single(w => w.Id == 2);

                wallet.Balance += 1000;

                context.SaveChanges();
            }
        }
    }
}
