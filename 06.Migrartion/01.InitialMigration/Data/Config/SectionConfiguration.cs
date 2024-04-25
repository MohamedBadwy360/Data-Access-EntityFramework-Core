﻿using Entities;
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

            builder.HasOne(s => s.Course)
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .IsRequired();

            builder.HasOne(s => s.Instructor)
                .WithMany(i => i.Sections)
                .HasForeignKey(s => s.InstructorId)
                .IsRequired(false);

            // Any One of them. => configure relation here or in the other configuration file
            //builder.HasMany(section => section.Schedules)
            //    .WithMany(schedule => schedule.Sections)
            //    .UsingEntity<SectionSchedule>();

            builder.HasMany(s => s.Students)
                .WithMany(s => s.Sections)
                .UsingEntity<Enrollment>();

            builder.ToTable("Sections");

            builder.HasData(LoadSections());
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1 },
                new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2 },
                new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1 },
                new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3 },
                new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2 },
                new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3 },
                new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4 },
                new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5 },
                new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4 },
                new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5 },
                new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4  }
            };
        }
    }
}
