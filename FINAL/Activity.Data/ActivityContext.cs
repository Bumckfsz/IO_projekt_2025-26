using Activity.Domain.Models; 
using Microsoft.EntityFrameworkCore;

namespace Activity.Domain.Data
{
    public class ActivityContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<Models.Activity> Activities { get; set; }

        public DbSet<Points> Points { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Nazwa pliku bazy danych
            options.UseSqlite(@"Data Source=C:\Users\Julci\source\repos\Bumckfsz\IO_projekt_2025-26\FINAL\Activity.Data\bin\Debug\net8.0\activity_app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProjectTask>()
                .HasKey(t => t.TaskId);

            modelBuilder.Entity<Project>()
                .HasKey(p => p.ProjectId);

            modelBuilder.Entity<Models.Activity>()
                .HasKey(a => a.ActivityId);

            modelBuilder.Entity<Points>()
                .Property<int>("PointsId")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Points>()
                .HasKey("PointsId");


            // Relacja Project (1) -> (N) Tasks
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey("ProjectId") 
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja ProjectTask (1) -> (N) Activities
            modelBuilder.Entity<ProjectTask>()
                .HasMany(t => t.Activities)
                .WithOne()
                .HasForeignKey("ProjectTaskId") 
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}