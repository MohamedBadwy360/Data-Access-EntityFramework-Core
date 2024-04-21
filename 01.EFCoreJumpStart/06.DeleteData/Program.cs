namespace _06.DeleteData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Delete wallet with Id = 1002
            using (AppDbContext db = new AppDbContext())
            {
                Wallet wallet = db.Wallets.Single(w => w.Id == 1002);

                db.Wallets.Remove(wallet);

                db.SaveChanges();
            }
        }
    }
}
