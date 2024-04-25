using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.Property(i => i.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();


            builder.HasOne(i => i.Office)
                .WithOne(o => o.Instructor)
                .HasForeignKey<Instructor>(i => i.OfficeId)
                .IsRequired(false);

            builder.ToTable("Instructors");

            builder.HasData(LoadCourses());
        }

        private static List<Instructor> LoadCourses()
        {
            //--Inserting data for Instructors
            //INSERT INTO Instructors(Id, Name) VALUES(1, 'Ahmed Abdullah');
            //INSERT INTO Instructors(Id, Name) VALUES(2, 'Yasmeen Mohammed');
            //INSERT INTO Instructors(Id, Name) VALUES(3, 'Khalid Hassan');
            //INSERT INTO Instructors(Id, Name) VALUES(4, 'Nadia Ali');
            //INSERT INTO Instructors(Id, Name) VALUES(5, 'Omar Ibrahim');

            return new List<Instructor>
            {
                new Instructor { Id = 1, Name = "Ahmed Abdullah", OfficeId = 1 },
                new Instructor { Id = 2, Name = "Yasmeen Mohammed", OfficeId = 2 },
                new Instructor { Id = 3, Name = "Khalid Hassan", OfficeId = 3 },
                new Instructor { Id = 4, Name = "Nadia Ali", OfficeId = 4 },
                new Instructor { Id = 5, Name = "Omar Ibrahim", OfficeId = 5 }
            };
        }
    }
}
