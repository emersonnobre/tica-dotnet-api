using ExampleStore.src.Api.Controllers.Interfaces;
using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using ExampleStore.src.Infra.EntityFramework.Repositories;

namespace ExampleStore.src.Api.Controllers;

public class ProductController(WebApplication app) : IController
{
    private readonly WebApplication app = app;

    public void RegisterRoutes()
    {
        var group = app.MapGroup("/products").WithTags("Products");

        group.MapPost("/", async (ProductDb db, Product product) =>
        {
            IProductRepository repository = new ProductRepository(db);
            
            await repository.Create(product);
            await db.SaveChangesAsync();

            return product;
        });

        group.MapGet("/", async (ProductDb db) =>
        {
            IProductRepository repository = new ProductRepository(db);
            var products = await repository.Get();
            return products;
        });

        group.MapGet("/{id}", async (ProductDb db, int id) =>
        {
            IProductRepository repository = new ProductRepository(db);
            var product = await repository.Get(id);
            if (product is null)
            {
                return Results.NotFound(new { message="Produto não encontrado" });
            }
            return Results.Ok(product);
        });
    }
}