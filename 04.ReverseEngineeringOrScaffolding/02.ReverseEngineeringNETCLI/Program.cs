using _01.ReverseEngineering_PMC.Data;

namespace _02.ReverseEngineeringNETCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step #1: Windows Terminal (Command Prompt) 

            // Step #2: Install Ef-Core tool globally
            //    dotnet tool install --global dotnet-ef    (new)
            //    dotnet tool update --global dotnet-ef     (to upgrade)

            // Step #3: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

            // Step #4: Run Command (Full)
            //    dotnet ef dbcontext scaffold '[Connection String]' [Provider]

            using (var context = new AppDbContext())
            {
                foreach (var speaker in context.Speakers)
                {
                    Console.WriteLine($"[{speaker.Id}] {speaker.FirstName} {speaker.LastName}");
                }
            }
        }
    }
}
