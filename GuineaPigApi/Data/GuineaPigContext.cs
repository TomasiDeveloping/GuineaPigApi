using GuineaPigApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GuineaPigApi.Data
{
    public class GuineaPigContext : DbContext 
    {
        public GuineaPigContext(DbContextOptions<GuineaPigContext> options): base(options)
        {
        }
        public DbSet<GuineaPig> GuineaPigs { get; set; }
        public DbSet<HealthCheck> HealthChecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // HealthCheck config
            modelBuilder.Entity<HealthCheck>()
                .HasOne(h => h.GuineaPig)
                .WithMany()
                .HasForeignKey(h => h.GuineaPigId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsPawsCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsChinCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsMouthCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsNoseCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsTeethCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsEyesCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsEarsCheck).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<HealthCheck>().Property(h => h.IsFurCheck).IsRequired().HasDefaultValue(false);

            modelBuilder.Entity<HealthCheck>().Property(h => h.HealthCheckDate).IsRequired().HasDefaultValue(DateTime.Now);

            modelBuilder.Entity<HealthCheck>().Property(h => h.PawsComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.ChinComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.MouthComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.NoseComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.TeethComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.EyesComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.EarsComment).IsRequired(false).HasMaxLength(250);
            modelBuilder.Entity<HealthCheck>().Property(h => h.FurComment).IsRequired(false).HasMaxLength(250);

            // GuineaPig config
            modelBuilder.Entity<GuineaPig>().Property(g => g.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<GuineaPig>().Property(g => g.Birth).IsRequired();
            modelBuilder.Entity<GuineaPig>().Property(g => g.Gender).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<GuineaPig>().Property(g => g.Race).IsRequired().HasMaxLength(50);
        }
    }
}
