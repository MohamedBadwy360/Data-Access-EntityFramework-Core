using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace _01.InitialMigration.Data.Config
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedNever();

            builder.Property(o => o.OfficeName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(o => o.OfiiceLocation)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.ToTable("Offices");

            //builder.HasData(LoadOffices());
        }

        //-- Inserting data for Offices
        //INSERT INTO Offices(Id, OfficeName, OfficeLocation) VALUES(1, 'Off_05', 'building A');
        //INSERT INTO Offices(Id, OfficeName, OfficeLocation) VALUES(2, 'Off_12', 'building B');
        //INSERT INTO Offices(Id, OfficeName, OfficeLocation) VALUES(3, 'Off_32', 'Adminstration');
        //INSERT INTO Offices(Id, OfficeName, OfficeLocation) VALUES(4, 'Off_44', 'IT Department');
        //INSERT INTO Offices(Id, OfficeName, OfficeLocation) VALUES(5, 'Off_43', 'IT Department');
        //private static List<Office> LoadOffices()
        //{
        //    return new List<Office>
        //    {
        //        new Office { Id = 1, OfficeName = "Off_05", OfiiceLocation = "building A" },
        //        new Office { Id = 2, OfficeName = "Off_12", OfiiceLocation = "building B" },
        //        new Office { Id = 3, OfficeName = "Off_32", OfiiceLocation = "Adminstration" },
        //        new Office { Id = 4, OfficeName = "Off_44", OfiiceLocation = "IT Department" },
        //        new Office { Id = 5, OfficeName = "Off_43", OfiiceLocation = "IT Department" }
        //    };
        //}
    }
}
