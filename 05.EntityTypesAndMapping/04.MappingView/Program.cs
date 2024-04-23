using Data;

namespace _04.MappingView
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var orderWithDetail in context.OrderWithDetailsViews)
                {
                    Console.WriteLine(orderWithDetail);
                }
            }
        }
    }
}
