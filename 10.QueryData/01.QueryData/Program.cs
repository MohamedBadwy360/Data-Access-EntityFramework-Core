using Data;
using Microsoft.EntityFrameworkCore;

namespace _01.QueryData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                // IQueryable<Course> courses = context.Courses;
                //var courses = context.Courses;

                //Console.WriteLine(courses.ToQueryString());
                //Console.WriteLine("-------------------------\n");

                //foreach (var course in courses)
                //{
                //    Console.WriteLine($"course name: {course.CourseName}, {course.HoursToComplete} hrs., {course.Price.ToString("C")}");
                //}

                // ====================================================

                //var course = context.Courses.Single(c => c.Id == 1);
                //Console.WriteLine($"course name: {course.CourseName}, {course.HoursToComplete} hrs., {course.Price.ToString("C")}");

                // ====================================================

                //var course = context.Courses.First(c => c.HoursToComplete == 25);
                //Console.WriteLine($"course name: {course.CourseName}, {course.HoursToComplete} hrs., {course.Price.ToString("C")}");

                // ====================================================

                //var course = context.Courses.FirstOrDefault(c => c.HoursToComplete == 999);
                //Console.WriteLine($"course name: {course?.CourseName}, {course?.HoursToComplete} hrs., {course?.Price.ToString("C")}");

                // ====================================================

                var courses = context.Courses.Where(c => c.Price > 3000);
                Console.WriteLine(courses.ToQueryString());
                Console.WriteLine("-------------------------\n");
                foreach (var course in courses)
                {
                    Console.WriteLine($"course name: {course?.CourseName}, {course?.HoursToComplete} hrs., {course?.Price.ToString("C")}");
                }

            }
        }
    }
}
