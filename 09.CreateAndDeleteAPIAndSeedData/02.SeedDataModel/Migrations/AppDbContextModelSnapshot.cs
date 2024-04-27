﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _02.SeedDataModel.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "Mathematics",
                            Price = 1000.00m
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "Physics",
                            Price = 2000.00m
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "Chemistry",
                            Price = 1500.00m
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "Biology",
                            Price = 1200.00m
                        },
                        new
                        {
                            Id = 5,
                            CourseName = "CS-50",
                            Price = 3000.00m
                        });
                });

            modelBuilder.Entity("Entities.Enrollment", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.HasKey("SectionId", "ParticipantId");

                    b.HasIndex("ParticipantId");

                    b.ToTable("Enrollments", (string)null);

                    b.HasData(
                        new
                        {
                            SectionId = 6,
                            ParticipantId = 1
                        },
                        new
                        {
                            SectionId = 6,
                            ParticipantId = 2
                        },
                        new
                        {
                            SectionId = 7,
                            ParticipantId = 3
                        },
                        new
                        {
                            SectionId = 7,
                            ParticipantId = 4
                        },
                        new
                        {
                            SectionId = 8,
                            ParticipantId = 5
                        },
                        new
                        {
                            SectionId = 8,
                            ParticipantId = 6
                        },
                        new
                        {
                            SectionId = 9,
                            ParticipantId = 7
                        },
                        new
                        {
                            SectionId = 9,
                            ParticipantId = 8
                        },
                        new
                        {
                            SectionId = 10,
                            ParticipantId = 9
                        },
                        new
                        {
                            SectionId = 10,
                            ParticipantId = 10
                        });
                });

            modelBuilder.Entity("Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique()
                        .HasFilter("[OfficeId] IS NOT NULL");

                    b.ToTable("Instructors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ahmed",
                            LastName = "Abdullah",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Yasmeen",
                            LastName = "Mohammed",
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Khalid",
                            LastName = "Hassan",
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Nadia",
                            LastName = "Ali",
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Omar",
                            LastName = "Ibrahim",
                            OfficeId = 5
                        });
                });

            modelBuilder.Entity("Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("OfficeLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Offices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OfficeLocation = "Building A",
                            OfficeName = "Off_05"
                        },
                        new
                        {
                            Id = 2,
                            OfficeLocation = "Building B",
                            OfficeName = "Off_12"
                        },
                        new
                        {
                            Id = 3,
                            OfficeLocation = "Administration",
                            OfficeName = "Off_32"
                        },
                        new
                        {
                            Id = 4,
                            OfficeLocation = "IT Department",
                            OfficeName = "Off_44"
                        },
                        new
                        {
                            Id = 5,
                            OfficeLocation = "IT Department",
                            OfficeName = "Off_43"
                        });
                });

            modelBuilder.Entity("Entities.Participant", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Participants", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("FRI")
                        .HasColumnType("bit");

                    b.Property<bool>("MON")
                        .HasColumnType("bit");

                    b.Property<bool>("SAT")
                        .HasColumnType("bit");

                    b.Property<bool>("SUN")
                        .HasColumnType("bit");

                    b.Property<bool>("THU")
                        .HasColumnType("bit");

                    b.Property<bool>("TUE")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WED")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FRI = false,
                            MON = true,
                            SAT = false,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "Daily",
                            WED = true
                        },
                        new
                        {
                            Id = 2,
                            FRI = false,
                            MON = false,
                            SAT = false,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "DayAfterDay",
                            WED = false
                        },
                        new
                        {
                            Id = 3,
                            FRI = false,
                            MON = true,
                            SAT = false,
                            SUN = false,
                            THU = false,
                            TUE = false,
                            Title = "TwiceAWeek",
                            WED = true
                        },
                        new
                        {
                            Id = 4,
                            FRI = true,
                            MON = false,
                            SAT = true,
                            SUN = false,
                            THU = false,
                            TUE = false,
                            Title = "Weekend",
                            WED = false
                        },
                        new
                        {
                            Id = 5,
                            FRI = true,
                            MON = true,
                            SAT = true,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "Compact",
                            WED = true
                        });
                });

            modelBuilder.Entity("Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Sections", (string)null);
                });

            modelBuilder.Entity("Entities.Corporate", b =>
                {
                    b.HasBaseType("Entities.Participant");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Corporates", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FirstName = "Noor",
                            LastName = "Saleh",
                            Company = "ABC",
                            JobTitle = "Developer"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Huda",
                            LastName = "Ahmed",
                            Company = "ABC",
                            JobTitle = "QA"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Yousef",
                            LastName = "Farid",
                            Company = "EFG",
                            JobTitle = "Developer"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Layla",
                            LastName = "Mustafa",
                            Company = "EFG",
                            JobTitle = "QA"
                        });
                });

            modelBuilder.Entity("Entities.Individual", b =>
                {
                    b.HasBaseType("Entities.Participant");

                    b.Property<bool>("IsIntern")
                        .HasColumnType("bit");

                    b.Property<string>("University")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearOfGraduation")
                        .HasColumnType("int");

                    b.ToTable("Individuals", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Fatima",
                            LastName = "Ali",
                            IsIntern = false,
                            University = "XYZ",
                            YearOfGraduation = 2024
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Omar",
                            LastName = "Youssef",
                            IsIntern = true,
                            University = "POQ",
                            YearOfGraduation = 2023
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Amira",
                            LastName = "Tariq",
                            IsIntern = false,
                            University = "POQ",
                            YearOfGraduation = 2025
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Zainab",
                            LastName = "Ismail",
                            IsIntern = true,
                            University = "POQ",
                            YearOfGraduation = 2023
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Mohammed",
                            LastName = "Adel",
                            IsIntern = false,
                            University = "XYZ",
                            YearOfGraduation = 2024
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Samira",
                            LastName = "Nabil",
                            IsIntern = false,
                            University = "XYZ",
                            YearOfGraduation = 2024
                        });
                });

            modelBuilder.Entity("Entities.Enrollment", b =>
                {
                    b.HasOne("Entities.Participant", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Section", "Section")
                        .WithMany("Enrollments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Entities.Instructor", b =>
                {
                    b.HasOne("Entities.Office", "Office")
                        .WithOne("Instructor")
                        .HasForeignKey("Entities.Instructor", "OfficeId");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("Entities.Section", b =>
                {
                    b.HasOne("Entities.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Instructor", "Instructor")
                        .WithMany("Sections")
                        .HasForeignKey("InstructorId");

                    b.HasOne("Entities.Schedule", "Schedule")
                        .WithMany("Sections")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Entities.TimeSlot", "TimeSlot", b1 =>
                        {
                            b1.Property<int>("SectionId")
                                .HasColumnType("int");

                            b1.Property<TimeSpan>("EndTime")
                                .HasColumnType("TIME")
                                .HasColumnName("EndTime");

                            b1.Property<TimeSpan>("StartTime")
                                .HasColumnType("TIME")
                                .HasColumnName("StartTime");

                            b1.HasKey("SectionId");

                            b1.ToTable("Sections");

                            b1.WithOwner()
                                .HasForeignKey("SectionId");
                        });

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Schedule");

                    b.Navigation("TimeSlot")
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Corporate", b =>
                {
                    b.HasOne("Entities.Participant", null)
                        .WithOne()
                        .HasForeignKey("Entities.Corporate", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Individual", b =>
                {
                    b.HasOne("Entities.Participant", null)
                        .WithOne()
                        .HasForeignKey("Entities.Individual", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Course", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Entities.Instructor", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Entities.Office", b =>
                {
                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Entities.Schedule", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("Entities.Section", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
