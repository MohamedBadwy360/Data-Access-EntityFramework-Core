using C01.SplitQuery.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace _02.InnerJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Query Syntax
                var resultQuerySyntax = (from c in context.Courses.AsNoTracking()
                              join s in context.Sections.AsNoTracking()     // Inner Join
                              on c.Id equals s.CourseId
                              select new
                              {
                                  CourseName = c.CourseName,
                                  SectionName = s.SectionName,
                                  DateRange = s.DateRange.ToString(),
                                  TimeSlot = s.TimeSlot.ToString()
                              }).ToList();

                // ---------------------------------
                // Method Syntax
                var resultMethodSyntax = context.Courses.AsNoTracking().Join(
                    context.Sections.AsNoTracking(),
                    c => c.Id,
                    s => s.CourseId,
                    (c, s) => new
                    {
                        CourseName = c.CourseName,
                        SectionName = s.SectionName,
                        DateRange = s.DateRange.ToString(),
                        TimeSlot = s.TimeSlot.ToString()
                    }).ToList();
            }
        }
    }
}
