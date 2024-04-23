using Data;
using Microsoft.EntityFrameworkCore;

namespace _03.IncludeEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //var itemsinOrder1 = context.OrderDetails.Where(od => od.OrderId == 1);

                var itemsinOrder1 = context.Orders
                    //.Include("OrderDetails")
                    .Include(o => o.OrderDetails)
                    .FirstOrDefault(o => o.Id == 1)!
                    .OrderDetails;
                    

                Console.WriteLine($"Number of items in order 1 = {itemsinOrder1.Count()}");
            }
        }
    }
}
