using Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace _02.ClientVsServerSideEvaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                int courseId = 1;

                //  DECLARE @__courseId_0 int = 1;
                //  SELECT[s].[Id], [s].[SectionName] AS[Section]
                //  FROM[Sections] AS[s]
                //  WHERE[s].[CourseId] = @__courseId_0
                var result = context.Sections
                    .Where(s => s.CourseId == courseId)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Name = s.SectionName
                    });

                Console.WriteLine(result.ToQueryString());
                Console.WriteLine("---------------------------\n");

                foreach (var section in result)
                {
                    Console.WriteLine($"[{section.Id}] \t {section.Name}");
                }
            }

            Console.WriteLine("\n=========================\n");
            
            using (var context = new AppDbContext())
            {
                var courseId = 1;

                //  SELECT[s].[Id], [s].[SectionName], [s].[StartDate], [s].[EndDate]
                //  FROM [Sections] AS [s]
                //  WHERE [s].[CourseId] = @__courseId_0
                var result = context.Sections
                    .Where(s => s.CourseId == courseId)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Name = s.SectionName,
                        TotalDays = CalculateTotalDays(s.DateRange.StartDate, s.DateRange.EndDate)
                    });

                Console.WriteLine(result.ToQueryString());
                Console.WriteLine("----------------------------");

                foreach (var section in result)
                {
                    Console.WriteLine($"[{section.Id}] \t {section.Name} \t Total Days: {section.TotalDays}");
                }
            }
        }

        private static int CalculateTotalDays(DateOnly startDate, DateOnly endDate)
        {
            return endDate.DayNumber - startDate.DayNumber;     // 0001-01-01
        }
    }
}
