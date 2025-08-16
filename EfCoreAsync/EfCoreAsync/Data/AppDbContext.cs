using Microsoft.EntityFrameworkCore;
using EfCoreAsync.Entities;

namespace EfCoreAsync.Data;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = System.IO.Path.Combine(AppContext.BaseDirectory, "students.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(b =>
        {
            b.ToTable("Students");
            b.HasKey(x => x.Id);
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);
            b.HasIndex(x => x.Name).IsUnique();
        });
    }
}