using C01.SplitQuery.QueryData.Data;

namespace _06.CallingTableValuedFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var section in context.GetSectionsExceedingParticipantCount(21))
                {
                    Console.WriteLine($"{section.Id}\t{section.SectionName}\t{section.DateRange}\t{section.TimeSlot}");
                }
            }
        }
    }
}
