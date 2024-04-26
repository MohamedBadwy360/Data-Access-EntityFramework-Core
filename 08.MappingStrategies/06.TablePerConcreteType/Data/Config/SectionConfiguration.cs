using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.InitialMigration.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedNever();

            builder.Property(s => s.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.OwnsOne(s => s.TimeSlot, ts =>
            {
                ts.Property(ts => ts.StartTime).HasColumnType("TIME").HasColumnName("StartTime");
                ts.Property(ts => ts.EndTime).HasColumnType("TIME").HasColumnName("EndTime");
            });

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();

            builder.HasOne(s => s.Instructor)
                .WithMany(i => i.Sections)
                .HasForeignKey(s => s.InstructorId)
                .IsRequired(false);

            builder.HasOne(section => section.Schedule)
                .WithMany(scehdule => scehdule.Sections)
                .HasForeignKey(section => section.ScheduleId)
                .IsRequired();


            builder.HasMany(s => s.Participants)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>();

            builder.ToTable("Sections");

            //builder.HasData(LoadSections());
        }
    }
}
