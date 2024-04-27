using _02.SeedDataModel;
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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(e => new { e.SectionId, e.ParticipantId });
            //builder.Property(e => new { e.SectionId, e.StudentId }).ValueGeneratedNever();

            builder.ToTable("Enrollments");

            //builder.HasData(SeedData.LoadEnrollments());
        }
    }
}
