using _02.SeedDataModel;
using Entities;
using Enums;
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

            //builder.Property(s => s.Title)
            //    .HasColumnType("VARCHAR")
            //    .HasMaxLength(255)
            //    .IsRequired(); 

            builder.Property(s => s.Title)
                .HasConversion(
                    t => t.ToString(),
                    t => (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), t)
                );

            builder.ToTable("Schedules");

            //builder.HasData(SeedData.LoadSchedules());
        }
    }
}
