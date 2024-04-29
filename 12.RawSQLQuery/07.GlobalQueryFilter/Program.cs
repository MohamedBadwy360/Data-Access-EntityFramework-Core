using C01.SplitQuery.QueryData.Data;

namespace _07.GlobalQueryFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var section in context.Sections)
                {
                    Console.WriteLine($"{section.Id}\t{section.SectionName}\t{section.DateRange}\t{section.TimeSlot}");
                }
            }
        }
    }
}
