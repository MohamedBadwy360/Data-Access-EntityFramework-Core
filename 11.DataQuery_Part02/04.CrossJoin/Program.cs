using C01.SplitQuery.QueryData.Data;
using static System.Net.Mime.MediaTypeNames;

namespace _04.CrossJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //var sectionInstructorQuerySyntax = (from s in context.Sections  // 200
                //                                    from i in context.Instructors   // 100
                //                                    select new
                //                                    {
                //                                        s.SectionName,
                //                                        Instructor = $"{i.FName} {i.LName}"
                //                                    })
                //                                    .ToList();

                //Console.WriteLine(sectionInstructorQuerySyntax.Count());    // 20000

                // ------------------------------

                var sectionInstructorMethodSyntax = context.Sections
                    .SelectMany(s => context.Instructors,
                    (s, i) => new
                    {
                        s.SectionName,
                        Instructor = $"{i.FName} {i.LName}"
                    }).ToList();

                Console.WriteLine(sectionInstructorMethodSyntax.Count());
            }
        }
    }
}
