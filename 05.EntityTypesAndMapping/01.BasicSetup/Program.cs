using Data;

namespace _01.BasicSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var product in context.Products)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }
    }
}
