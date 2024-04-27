using Data;
using Microsoft.EntityFrameworkCore;

namespace _04.LoadRelatedEntities.Eager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new AppDbContext())
            //{
            //    int sectionId = 1;

            //    var sectionQuery = context.Sections
            //        .Include(s => s.Participants)
            //        .Where(s => s.Id == sectionId);

            //    Console.WriteLine(sectionQuery.ToQueryString());

            //    var section = sectionQuery.FirstOrDefault();
            //    Console.WriteLine($"\nsection: {section.SectionName}");
            //    Console.WriteLine($"--------------------");
            //    foreach (var participant in section.Participants)
            //        Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
            //}

            using (var context = new AppDbContext())
            {
                int sectionId = 1;

                var sectionQuery = context.Sections
                    .Include(s => s.Instructor)
                    .ThenInclude(i => i.Office)
                    .Where(s => s.Id == sectionId);

                Console.WriteLine(sectionQuery.ToQueryString());


                var section = sectionQuery.FirstOrDefault();

                Console.WriteLine($"section: {section?.SectionName} " +
                    $"[{section?.Instructor?.FName} " +
                    $"{section?.Instructor?.LName} " +
                    $"({section?.Instructor?.Office?.OfficeName})]");
            }
        }
    }
}
