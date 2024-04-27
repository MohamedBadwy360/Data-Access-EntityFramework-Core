using _02.SeedDataModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            //builder.Property(c => c.CourseName).HasMaxLength(255);  // nvarchar(255)
            builder.Property(c => c.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(c => c.Price)
                .HasPrecision(15, 2);

            builder.ToTable("Courses");

            builder.HasData(SeedData.LoadCourses());
        }
    }
}
