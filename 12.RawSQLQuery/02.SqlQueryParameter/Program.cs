using C01.SplitQuery.QueryData.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _02.SqlQueryParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // on DbSet.
            // primary key only to search.
            // (local cache) first. if not exist it queries the database.
            // Returns null if the entity is not found.

            //var c1 = context.Courses.Find(1);
            //Console.WriteLine($"{c1.CourseName} ({c1.HoursToComplete})");

            // On IEnumerable or IQueryable.
            // Retrieves the first element of a sequence, or a default value.
            // You can provide a predicate(a condition) to filter the results. 
            //var c2 = context.Courses.FirstOrDefault(x => x.Id == 1);
            //Console.WriteLine($"{c2.CourseName} ({c2.HoursToComplete})");

            // On IEnumerable or IQueryable.
            // Retrieves the single element of a sequence or a default value.
            // more than one element satisfies, exception thrown.
            // Useful when you expect the query to return only one result.

            //var c3 = context.Courses.SingleOrDefault(x => x.Id == 1);
            //Console.WriteLine($"{c3.CourseName} ({c3.HoursToComplete})");

            // ===========================================================================
            
            using(var context = new AppDbContext())
            {
                var c1 = context.Courses.FromSql($"Select * from Courses Where Id = {1}")
                    .FirstOrDefault();
                Console.WriteLine($"{c1.CourseName} ({c1.HoursToComplete})");


                var c2 = context.Courses.FromSqlInterpolated($"Select * from Courses Where Id = {1}")
                    .FirstOrDefault();
                Console.WriteLine($"{c2.CourseName} ({c2.HoursToComplete})");


                var courseIdParameter = new SqlParameter("@courseId", 1);   // To prevent Sql Injection
                var c3 = context.Courses.FromSqlRaw($"Select * from Courses Where Id = @courseId", courseIdParameter)
                    .FirstOrDefault();
                Console.WriteLine($"{c3.CourseName} ({c3.HoursToComplete})");
            }


        }
    }
}
