using C01.SplitQuery.QueryData.Data;
using C01.SplitQuery.QueryData.Entities;

namespace _03.LeftJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                //var officeOccupancyQuerySyntax = (from o in context.Offices
                //                                  join i in context.Instructors
                //                                  on o.Id equals i.OfficeId into officeVacancy
                //                                  from ov in officeVacancy.DefaultIfEmpty()
                //                                  select new
                //                                  {
                //                                      OfficeId = o.Id,
                //                                      Name = o.OfficeName,
                //                                      Location = o.OfficeLocation,
                //                                      Instructor = (ov != null) ? $"{ov.FName} {ov.LName}" : "<EMPTY>"
                //                                  }).ToList();

                //foreach (var ov in officeOccupancyQuerySyntax)
                //{
                //    Console.WriteLine(ov);
                //}

                //---------------------------------------
                var officeOccupancyMethodSyntax = context.Offices
                    .GroupJoin(context.Instructors,
                    o => o.Id,
                    i => i.OfficeId,
                    (office, instructor) => new { office, instructor })
                    .SelectMany(ov => ov.instructor.DefaultIfEmpty(),
                    (ov, instructor) => new
                    {
                        OfficeId = ov.office.Id,
                        Name = ov.office.OfficeName,
                        Location = ov.office.OfficeLocation,
                        Instructor = instructor != null ? $"{instructor.FName} {instructor.LName}" : "<<EMPTY>>"
                    }).ToList();

                foreach (var office in officeOccupancyMethodSyntax)
                {
                    Console.WriteLine($"{office.Name} -> {office.Instructor}");
                }

            }
        }
    }
}
