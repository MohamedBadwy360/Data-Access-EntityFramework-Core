namespace _07.QueryData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Retrieve all wallets with balance over 9000
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Wallets.Where(w => w.Balance > 9000m);

                foreach (var wallet in result)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
