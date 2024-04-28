using C01.SplitQuery.QueryData.Data;

namespace _06.GroupBy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // •  Ins#1
            //         S1, S2, s3
            // •  Ins#2
            //         S5, S2, s1

           

            using (var context = new AppDbContext())
            {
                // Query Syntax
                //var instructorSections = from s in context.Sections
                //                         group s by s.Instructor
                //                         into g
                //                         select new
                //                         {
                //                             Key = g.Key,
                //                             Sections = g.ToList()
                //                         };

                //foreach (var group in instructorSections)
                //{
                //    Console.WriteLine($"-- {group.Key.FName} {group.Key.LName}");

                //    foreach (var section in group.Sections)
                //    {
                //        Console.WriteLine($"\t{section.SectionName}");
                //    }
                //}

                //var instructorSections = from s in context.Sections
                //                         group s by s.Instructor
                //                         into g
                //                         select new
                //                         {
                //                             Key = g.Key,
                //                             TotalSections = g.Count()
                //                         };

                //foreach (var group in instructorSections)
                //{
                //    Console.WriteLine($"-- {group.Key.FName} {group.Key.LName} => Total sections [{group.TotalSections}]");
                //}

                //------------------------------
                // Method Syntax

                var instructorSections = context.Sections
                    .GroupBy(s => s.Instructor)
                    .Select(group => new
                    {
                        Key = group.Key,
                        TotalSections = group.Count()
                    });

                foreach (var group in instructorSections)
                {
                    Console.WriteLine($"-- {group.Key.FName} {group.Key.LName} => Total sections [{group.TotalSections}]");
                }
            }
        }
    }
}
