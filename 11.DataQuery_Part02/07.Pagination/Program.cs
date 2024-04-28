using C01.SplitQuery.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace _07.Pagination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                int pageNumber = 1;
                int pageSize = 10;
                int totalSections = context.Sections.Count();
                int totalPages = (int)Math.Ceiling((double)totalSections / pageSize);

                var query = context.Sections.AsNoTracking()
                    .Include(s => s.Course)
                    .Include(c => c.Instructor)
                    .Include(i => i.Schedule)
                    .Select(s => new
                    {
                        Course = s.Course.CourseName,
                        Instructor = $"{s.Instructor.FName} {s.Instructor.LName}",
                        DateRange = s.DateRange.ToString(),
                        TimeSlot = s.TimeSlot.ToString(),
                        Days = string.Join(" ",   // "SAT SUN MON"
                               s.Schedule.SUN ? "SUN" : "",
                               s.Schedule.SAT ? "SAT" : "",
                               s.Schedule.MON ? "MON" : "",
                               s.Schedule.TUE ? "TUE" : "",
                               s.Schedule.WED ? "WED" : "",
                               s.Schedule.THU ? "THU" : "",
                               s.Schedule.FRI ? "FRI" : "")
                    });

                while (pageNumber < totalPages)
                {
                    Console.WriteLine("|           Course                   |          Instructor            |       Date Range        |   Time Slot   |            Days                |");
                    Console.WriteLine("|------------------------------------|--------------------------------|-------------------------|---------------|--------------------------------|");

                    var pagedResult = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                    foreach (var section in pagedResult)
                    {
                        Console.WriteLine($"| {section.Course,-34} | {section.Instructor,-30} | {section.DateRange.ToString(),-23} | {section.TimeSlot.ToString(),-12} | {section.Days,-30} |");
                    }

                    Console.WriteLine();

                    for (int p = 1; p <= totalPages; p++)
                    {
                        Console.ForegroundColor = p == pageNumber ? ConsoleColor.Yellow : ConsoleColor.DarkGray;
                        Console.Write($"{p} "); // 1 2 3 4 5 .... 20
                    }

                    Console.ReadKey();
                    ++pageNumber;
                    Console.Clear();
                }

            }
        }
    }
}
