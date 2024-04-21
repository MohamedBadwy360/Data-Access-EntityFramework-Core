namespace _04.InsertData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wallet wallet = new Wallet
            {
                Holder = "Salah",
                Balance = 1200m
            };

            using (var context = new AppDbContext())
            {
                context.Wallets.Add(wallet);
                context.SaveChanges();
            }
        }
    }
}
