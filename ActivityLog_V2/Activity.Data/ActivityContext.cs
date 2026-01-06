using Microsoft.EntityFrameworkCore;
using Activity.Domain.Models; // Ważne: import ich modeli

namespace Activity.Domain.Data
{
    public class ActivityContext : DbContext
    {
        // Rejestrujemy ich klasy jako tabele
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }

        // Uwaga: Activity to częsta nazwa w .NET, więc upewnij się, że używasz ich modelu
        public DbSet<Models.Activity> Activities { get; set; }

        public DbSet<Points> Points { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Nazwa pliku bazy danych
            optionsBuilder.UseSqlite("Data Source=activity_app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // === 1. DEFINICJA KLUCZY GŁÓWNYCH (To naprawia Twój błąd) ===

            // Dla ProjectTask wskazujemy, że TaskId to klucz
            modelBuilder.Entity<ProjectTask>()
                .HasKey(t => t.TaskId);

            // Dla Project (dla pewności, choć ProjectId zazwyczaj działa z automatu)
            modelBuilder.Entity<Project>()
                .HasKey(p => p.ProjectId);

            // Dla Activity (Models.Activity)
            modelBuilder.Entity<Models.Activity>()
                .HasKey(a => a.ActivityId);

            // Dla Points (które w ogóle nie mają ID w klasie) - tworzymy sztuczny klucz
            modelBuilder.Entity<Points>()
                .Property<int>("PointsId")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Points>()
                .HasKey("PointsId");


            // === 2. DEFINICJA RELACJI (Shadow Properties) ===

            // Relacja Project (1) -> (*) Tasks
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey("ProjectId") // Tworzy kolumnę ProjectId w tabeli ProjectTasks
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja ProjectTask (1) -> (*) Activities
            modelBuilder.Entity<ProjectTask>()
                .HasMany(t => t.Activities)
                .WithOne()
                .HasForeignKey("ProjectTaskId") // Tworzy kolumnę ProjectTaskId w tabeli Activities
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}