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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.SectionId, e.StudentId });
            //builder.Property(e => new { e.SectionId, e.StudentId }).ValueGeneratedNever();

            builder.ToTable("Enrollments");

            builder.HasData(LoadEnrollments());
        }

        private static List<Enrollment> LoadEnrollments()
        {
            return new List<Enrollment>
            {
                new Enrollment() { StudentId = 1, SectionId = 6 },
                new Enrollment() { StudentId = 2, SectionId = 6 },
                new Enrollment() { StudentId = 3, SectionId = 7 },
                new Enrollment() { StudentId = 4, SectionId = 7 },
                new Enrollment() { StudentId = 5, SectionId = 8 },
                new Enrollment() { StudentId = 6, SectionId = 8 },
                new Enrollment() { StudentId = 7, SectionId = 9 },
                new Enrollment() { StudentId = 8, SectionId = 9 },
                new Enrollment() { StudentId = 9, SectionId = 10 },
                new Enrollment() { StudentId = 10, SectionId = 10 }
            };
        }
    }
}
