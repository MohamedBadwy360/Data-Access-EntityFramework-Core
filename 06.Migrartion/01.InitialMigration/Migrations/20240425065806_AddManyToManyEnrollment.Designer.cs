﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _01.InitialMigration.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240425065806_AddManyToManyEnrollment")]
    partial class AddManyToManyEnrollment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
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
                            Price = 1000m
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "Physics",
                            Price = 2000m
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "Chemistry",
                            Price = 1500m
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "Biology",
                            Price = 1200m
                        },
                        new
                        {
                            Id = 5,
                            CourseName = "Computer Science",
                            Price = 3000m
                        });
                });

            modelBuilder.Entity("Entities.Enrollment", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SectionId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments", (string)null);

                    b.HasData(
                        new
                        {
                            SectionId = 6,
                            StudentId = 1
                        },
                        new
                        {
                            SectionId = 6,
                            StudentId = 2
                        },
                        new
                        {
                            SectionId = 7,
                            StudentId = 3
                        },
                        new
                        {
                            SectionId = 7,
                            StudentId = 4
                        },
                        new
                        {
                            SectionId = 8,
                            StudentId = 5
                        },
                        new
                        {
                            SectionId = 8,
                            StudentId = 6
                        },
                        new
                        {
                            SectionId = 9,
                            StudentId = 7
                        },
                        new
                        {
                            SectionId = 9,
                            StudentId = 8
                        },
                        new
                        {
                            SectionId = 10,
                            StudentId = 9
                        },
                        new
                        {
                            SectionId = 10,
                            StudentId = 10
                        });
                });

            modelBuilder.Entity("Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
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
                            Name = "Ahmed Abdullah",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yasmeen Mohammed",
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Khalid Hassan",
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nadia Ali",
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Omar Ibrahim",
                            OfficeId = 5
                        });
                });

            modelBuilder.Entity("Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("OfiiceLocation")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Offices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OfficeName = "Off_05",
                            OfiiceLocation = "building A"
                        },
                        new
                        {
                            Id = 2,
                            OfficeName = "Off_12",
                            OfiiceLocation = "building B"
                        },
                        new
                        {
                            Id = 3,
                            OfficeName = "Off_32",
                            OfiiceLocation = "Adminstration"
                        },
                        new
                        {
                            Id = 4,
                            OfficeName = "Off_44",
                            OfiiceLocation = "IT Department"
                        },
                        new
                        {
                            Id = 5,
                            OfficeName = "Off_43",
                            OfiiceLocation = "IT Department"
                        });
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
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

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
                            Title = "Twice-a-Week",
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

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Sections", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            InstructorId = 1,
                            SectionName = "S_MA1"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            InstructorId = 2,
                            SectionName = "S_MA2"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            InstructorId = 1,
                            SectionName = "S_PH1"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            InstructorId = 3,
                            SectionName = "S_PH2"
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 3,
                            InstructorId = 2,
                            SectionName = "S_CH1"
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 3,
                            InstructorId = 3,
                            SectionName = "S_CH2"
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 4,
                            InstructorId = 4,
                            SectionName = "S_BI1"
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 4,
                            InstructorId = 5,
                            SectionName = "S_BI2"
                        },
                        new
                        {
                            Id = 9,
                            CourseId = 5,
                            InstructorId = 4,
                            SectionName = "S_CS1"
                        },
                        new
                        {
                            Id = 10,
                            CourseId = 5,
                            InstructorId = 5,
                            SectionName = "S_CS2"
                        },
                        new
                        {
                            Id = 11,
                            CourseId = 5,
                            InstructorId = 4,
                            SectionName = "S_CS3"
                        });
                });

            modelBuilder.Entity("Entities.SectionSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TIME");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TIME");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SectionId");

                    b.ToTable("SectionSchedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            ScheduleId = 1,
                            SectionId = 1,
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            ScheduleId = 3,
                            SectionId = 2,
                            StartTime = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            ScheduleId = 4,
                            SectionId = 3,
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            ScheduleId = 1,
                            SectionId = 4,
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            ScheduleId = 1,
                            SectionId = 5,
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            ScheduleId = 2,
                            SectionId = 6,
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            ScheduleId = 3,
                            SectionId = 7,
                            StartTime = new TimeSpan(0, 11, 0, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            ScheduleId = 4,
                            SectionId = 8,
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            ScheduleId = 4,
                            SectionId = 9,
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            ScheduleId = 3,
                            SectionId = 10,
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            EndTime = new TimeSpan(0, 11, 0, 0, 0),
                            ScheduleId = 5,
                            SectionId = 11,
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Entities.Student", b =>
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

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Fatima",
                            LastName = "Ali"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Noor",
                            LastName = "Saleh"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Omar",
                            LastName = "Youssef"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Huda",
                            LastName = "Ahmed"
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Amira",
                            LastName = "Tariq"
                        },
                        new
                        {
                            Id = 6,
                            FirstName = "Zainab",
                            LastName = "Ismail"
                        },
                        new
                        {
                            Id = 7,
                            FirstName = "Yousef",
                            LastName = "Farid"
                        },
                        new
                        {
                            Id = 8,
                            FirstName = "Layla",
                            LastName = "Mustafa"
                        },
                        new
                        {
                            Id = 9,
                            FirstName = "Mohammed",
                            LastName = "Adel"
                        },
                        new
                        {
                            Id = 10,
                            FirstName = "Samira",
                            LastName = "Nabil"
                        });
                });

            modelBuilder.Entity("Entities.Enrollment", b =>
                {
                    b.HasOne("Entities.Section", "Section")
                        .WithMany("Enrollments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("Student");
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

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Entities.SectionSchedule", b =>
                {
                    b.HasOne("Entities.Schedule", null)
                        .WithMany("SectionSchedules")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Section", null)
                        .WithMany("SectionSchedules")
                        .HasForeignKey("SectionId")
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
                    b.Navigation("SectionSchedules");
                });

            modelBuilder.Entity("Entities.Section", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("SectionSchedules");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
