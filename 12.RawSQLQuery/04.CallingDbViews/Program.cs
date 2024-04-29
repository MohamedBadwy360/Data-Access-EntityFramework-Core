using C01.SplitQuery.QueryData.Data;

namespace _04.CallingDbViews
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var courseOverviews = context.CourseOverviews.ToList();

                foreach (var courseOverview in courseOverviews)
                {
                    Console.WriteLine(courseOverview);
                }
            }
        }
    }
}
