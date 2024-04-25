using Data;

namespace _01.InitialMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                foreach (var course in context.Courses)
                {
                    Console.WriteLine($"[{course.Id}] {course.CourseName}");
                }
            }
        }
    }
}
