using C01.SplitQuery.QueryData.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace _03.CallingStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var startDateParameter = new SqlParameter("@startDate", SqlDbType.Date)
                {
                    Value = new DateTime(2023, 01, 01)
                };

                var endDateParameter = new SqlParameter("@endDate", SqlDbType.Date)
                {
                    Value = new DateTime(2023, 6, 30)
                };

                var sectionDetails = context.SectionDetails.FromSql($"Exec dbo.sp_GetSectionWithninDateRange {startDateParameter}, {endDateParameter}")
                    .ToList();

                foreach (var s in sectionDetails)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
