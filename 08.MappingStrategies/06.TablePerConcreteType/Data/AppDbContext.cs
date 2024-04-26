using Data.Config;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Participant> Participants { get; set; }
        
        public DbSet<MultipleChoiceQuiz> MultipleChoiceQuizzes { get; set; }
        public DbSet<TrueOrFalseQuiz> TrueOrFalseQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new CourseConfiguration());         // Not best practice
            //modelBuilder.ApplyConfiguration(new InstructorConfiguration());     // Not best practice

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);     // best practice
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetSection("ConnectionStrings:DefaultString").Value!;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
