using ExampleStore.src.Application.DTO;
using ExampleStore.src.Application.UseCases;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using ExampleStore.src.Infra.EntityFramework.Repositories;

namespace ExampleStore.src.Api.Controllers;

public class CategoryController(WebApplication app)
{
    private readonly WebApplication app = app;

    public void RegisterRoutes()
    {
        app.MapPost("/categories", async (ProductDb db, CreateCategoryDTO categoryDTO) => {
            CategoryRepository repository = new(db);
            CreateCategoryUseCase useCase = new(repository);

            var response = await useCase.Execute(categoryDTO);

            if (response.Message is not null)
                return Results.BadRequest(new { message=response.Message });
                
            return Results.Created(new Uri("/category/{id}"), response.Data);
        });

        app.MapGet("/categories", async (ProductDb db) => {
            CategoryRepository repository = new(db);
            GetCategoriesUseCase useCase = new(repository);

            var response = await useCase.Execute();

            if (response.Message is not null)
                return Results.BadRequest(new { message=response.Message });
            return Results.Created(new Uri("/category/{id}"), response.Data);
        });
    }
}