using C01.SplitQuery.QueryData.Data;
using Microsoft.EntityFrameworkCore;

namespace _05.SelectMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Query syntax

            // front end (angular, react)
            //  اسماء الطلاب اللي بيدرسوا فرونت اند
            
            using (var context = new AppDbContext())
            {
                //var frontendParticipants = from c in context.Courses
                //                           where c.CourseName!.Contains("frontend")
                //                           from s in c.Sections
                //                           from p in s.Participants
                //                           select new
                //                           {
                //                               Name = $"{p.FullName}"
                //                           };

                //foreach (var participant in frontendParticipants)
                //{
                //    Console.WriteLine(participant);
                //}


                // Method Syntax
                var frontendParticipants = context.Courses
                    .Where(c => c.CourseName!.Contains("frontend"))
                    .SelectMany(c => c.Sections)        // angular, react
                    .SelectMany(s => s.Participants)    // s1, s2, s3 ...
                    .Select(p => new
                    {
                        Name = $"{p.FullName}"
                    })
                    .ToList();

                foreach (var participant in frontendParticipants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }
}
