using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace _05.MappingTableValuedFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var order1BillDetails = context.Set<OrderBill>()
                    .FromSqlInterpolated($"SELECT * FROM GetOrderBill({1})");

                foreach (var orderBillDetail in order1BillDetails)
                {
                    Console.WriteLine(orderBillDetail);
                }
            }
        }
    }
}
