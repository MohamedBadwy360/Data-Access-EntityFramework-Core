using C01.BasicSaveWithTracking.Data;
using C01.BasicSaveWithTracking.Helpers;

namespace _01.Interceptors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseHelper.RecreateCleanDatabase();
            DatabaseHelper.PopulateDatabase();

            Console.WriteLine();
            Console.WriteLine("Before Delete");
            Console.WriteLine();

            DatabaseHelper.ShowBooks();

            using (var context = new AppDbContext())
            {
                var book = context.Books.First();
                context.Books.Remove(book);
                context.SaveChanges();
            }

            Console.WriteLine();
            Console.WriteLine("After Delete Book with Id = 1");

            DatabaseHelper.ShowBooks();
        }
    }
}
