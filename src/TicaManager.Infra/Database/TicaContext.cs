using Microsoft.EntityFrameworkCore;
using TicaManager.Domain.Entities;
using TicaManager.Infra.Database.Mappings;

namespace TicaManager.Infra.Database;

public class TicaContext(DbContextOptions<TicaContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // base.OnModelCreating(modelBuilder);
        // modelBuilder.Entity<Employee>().Ta("Employee");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeMap).Assembly);
    }
}