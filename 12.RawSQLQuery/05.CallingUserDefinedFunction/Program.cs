﻿using C01.SplitQuery.QueryData.Data;

namespace _05.CallingUserDefinedFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var startDate = new DateTime(2023, 09, 24);
                var endDate = new DateTime(2023, 12, 26);
                var startTime = new TimeSpan(08, 00, 00);
                var endTime = new TimeSpan(11, 00, 00);

                var result = context.Instructors.Select(i => new
                {
                    Id = i.Id,
                    FullName = $"{i.FName} {i.LName}",
                    DateRange = $"{startDate.ToShortDateString()} - {endDate.ToShortDateString()}",
                    TimeRange = $"{startTime.ToString("hh\\:mm")} - {endTime.ToString("hh\\:mm")}",
                    Status = AppDbContext.GetInstructorAvailability(i.Id, startDate, endDate, startTime, endTime)
                });

                foreach (var item in result)
                {
                    Console.WriteLine(
                        $"{item.Id}\t{item.FullName,-20}\t{item.DateRange}\t{item.TimeRange}\t{item.Status}");
                }
            }
        }
    }
}
