using ExampleStore.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleStore.src.Infra.EntityFramework.Configuration;

public class ProductDb(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; } = null!; 
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
}