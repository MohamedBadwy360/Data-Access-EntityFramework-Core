using Data;
using Microsoft.EntityFrameworkCore;

namespace _01.CreateAndDropAPI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                await context.Database.EnsureCreatedAsync();

                var sqlScript = context.Database.GenerateCreateScript();

                await Task.Delay(30000);

                await context.Database.EnsureDeletedAsync();
            }
        }
    }
}
