using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.Title)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired(); 

            builder.HasMany(schedule => schedule.Sections)
                .WithMany(section => section.Schedules)
                .UsingEntity<SectionSchedule>();
            // If I declare navigation propertites in SectionSchedule class I use this explicit foreign key
            // UsingEntity<SectionSchedule>(
            // l.HasOne(schedule => schedule.SectionSchedules).WithMany(ss => ss.Schedule).HasForeignKey(ss => ss.SchduleId),
            // r.HasOne(section => section.SectionSchedules).WithMany(ss => ss.Section).HasForeignKey(ss => ss.sectionId))

            builder.ToTable("Schedules");

            builder.HasData(LoadSchedules());
        }

        private static List<Schedule> LoadSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, Title = "Daily", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 2, Title = "DayAfterDay", SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 3, Title = "Twice-a-Week", SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, Title = "Weekend", SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
                new Schedule { Id = 5, Title = "Compact", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
            };
        }
    }
}
