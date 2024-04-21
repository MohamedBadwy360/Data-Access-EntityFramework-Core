namespace _03.RetrieveSingleItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var wallet = context.Wallets.FirstOrDefault(w => w.Id == 2);

                Console.WriteLine(wallet);
            }
        }
    }
}
