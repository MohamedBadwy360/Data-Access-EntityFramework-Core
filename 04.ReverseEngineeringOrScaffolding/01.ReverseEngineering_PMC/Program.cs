using _01.ReverseEngineering_PMC.Data;

namespace _01.ReverseEngineering_PMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step #1: Package Manager Console (PMC)
            //    Tools -> Nuget Package Manager -> Package Manager Console

            // Step #2: Package Manager Console (PMC) Tool 
            //    Install-Package Microsoft.EntityFrameworkCore.Tools

            // Step #3: Install Nuget Page on Project Microsoft.EntityFrameworkCore.Design
            // Microsoft.EntityFrameworkCore.SqlServer

            // Step #4: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

            // Step #5: Run Command (Full)
            //    Scaffold-DbContext '[Connection String]' [Provider]

            // Step #5: If I want to use Data Annotations in generated Code => Run Command (Full)
            //    Scaffold-DbContext '[Connection String]' [Provider] -DataAnnotations

            // Step #5: If I want to change DbContext Name in generated Code => Run Command (Full)
            //    Scaffold-DbContext '[Connection String]' [Provider] -Context [Context Name]

            // Step #5: If I want to DbContext in folder and Entities in folder in generated Code => Run Command (Full)
            //    Scaffold-DbContext '[Connection String]' [Provider] -ContextDir [Folder Name] -OutputDir [Folder Name]

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
