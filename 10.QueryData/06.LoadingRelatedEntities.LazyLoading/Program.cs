using Data;

namespace _06.LoadingRelatedEntities.LazyLoading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                int sectionId = 1;

                var section = context.Sections.FirstOrDefault(s => s.Id == sectionId);

                foreach (var participant in section?.Participants)
                {
                    Console.WriteLine($"[{participant.Id}] {participant.FName} {participant.LName}");
                }
            }
        }
    }
}
