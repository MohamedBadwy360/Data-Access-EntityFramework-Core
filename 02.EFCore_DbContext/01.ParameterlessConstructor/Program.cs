using Data;
using Entities;

namespace _01.InternalConfiguration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                foreach (Wallet wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }
        }
    }
}
