using C01.SplitQuery.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace _01.SQLQuery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var courses = context.Courses.FromSql($"Select * from Courses;");

                var courses2 = context.Courses.FromSqlInterpolated($"Select * from Courses;");

                var courses3 = context.Courses.FromSqlRaw($"Select * from Courses;");

                foreach (var course  in courses3)
                {
                    Console.WriteLine($"{course.CourseName} ({course.HoursToComplete})");
                }

            }
        }
    }
}
