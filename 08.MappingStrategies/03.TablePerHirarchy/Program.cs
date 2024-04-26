using Data;
using Entities;

namespace _03.TablePerHirarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var participant01 = new Individual
            {
                Id = 1,
                FirstName = "Mohamed",
                LastName = "Badwy",
                University = "Mansoura",
                IsIntern = false,
                YearOfGraduation = 2023
            };

            var participant02 = new Coporate
            {
                Id = 2,
                FirstName = "Ismail",
                LastName = "Hamada",
                Company = "Naseej",
                JobTitle = "Senior Flutter Mobile Engineer"
            };

            using (var context = new AppDbContext())
            {
                context.Participants.Add(participant01);
                context.Participants.Add(participant02);
                context.SaveChanges();


                Console.WriteLine("Coporate Participants");
                foreach (var individual in context.Set<Participant>()/*Participants*/.OfType<Individual>())
                {
                    Console.WriteLine(individual);
                }

                Console.WriteLine("Individual Participants");
                foreach (var coporate in context.Set<Participant>()/*Participants*/.OfType<Coporate>())
                {
                    Console.WriteLine(coporate);
                }
            }
        }
    }
}
