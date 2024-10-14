using ExampleStore.src.Domain.Entities;

namespace ExampleStore.src.Infra.EntityFramework.Configuration;

public class DbSeeder
{
    public static void Seed(ProductDb dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();
        if (!dbContext.Categories.Any())
        {
            var categories = new Category[]
            {
                new("louças"),
                new("tecidos"),
                new("enfeites")
            };

            foreach(var category in categories)
                dbContext.Categories.Add(category);
        }

        if (!dbContext.Employees.Any())
        {
            var employees = new Employee[]
            {
                new("Ábida Moreira"),
                new("Letícia Firmino"),
            };

            foreach (var employee in employees)
                dbContext.Employees.Add(employee);
        }

        dbContext.SaveChanges();
    }
}