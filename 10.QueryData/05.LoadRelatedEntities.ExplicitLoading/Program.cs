using Data;
using Microsoft.EntityFrameworkCore;

namespace _05.LoadRelatedEntities.ExplicitLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                int sectionId = 1;

                var section = context.Sections.FirstOrDefault(s => s.Id == sectionId);
                Console.WriteLine($"[{section?.Id}] {section?.SectionName}\n");
                
                var query = context.Entry(section).Collection(s => s.Participants).Query();
                Console.WriteLine(query.ToQueryString());

                Console.WriteLine($"\nsection: {section.SectionName}");
                Console.WriteLine($"--------------------");
                foreach (var participant in query)
                    Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
            }
        }
    }
}
