using C01.SplitQuery.QueryData.Data;
using C01.SplitQuery.QueryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01.SplitQueries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //// proper projection (select) reduce network traffic
                //// and reduce the effect on app performance
                //var coursesProjection = context.Courses.AsNoTracking()
                //    .Select(c => new
                //    {
                //        CourseId = c.Id,
                //        CourseName = c.CourseName,
                //        Hours = c.HoursToComplete,
                //        Sections = c.Sections.Select(s => new
                //        {
                //            SectionId = s.Id,
                //            SectionName = s.SectionName,
                //            DateRate = s.DateRange.ToString(),
                //            TimeSlot = s.TimeSlot.ToString()
                //        }),
                //        Reviews = c.Reviews.Select(r => new
                //        {
                //            FeedBack = r.Feedback,
                //            CreatedAt = r.CreatedAt
                //        })
                //    })
                //    .ToList();

                //foreach (var course in coursesProjection)
                //{
                //    Console.WriteLine(course);
                //}

                // =============================================================

                //var courses1 = context.Courses.AsNoTracking()
                //    .Include(c => c.Sections)
                //    .Include(c => c.Reviews)
                //    .AsSplitQuery()  // explicit splitting
                //    .ToList();

                //var courses2 = context.Courses.AsNoTracking()
                //    .Include(c => c.Sections)
                //    .Include(c => c.Reviews)    // use configuration splitting
                //    .ToList();

                var courses3 = context.Courses.AsNoTracking()
                    .Include(c => c.Sections)
                    .Include(c => c.Reviews)    
                    .AsSingleQuery()        // remove/override configuration splitting query 
                    .ToList();
            }
        }
    }
}
