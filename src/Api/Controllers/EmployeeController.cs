using ExampleStore.src.Api.Controllers.Interfaces;
using ExampleStore.src.Application.UseCases;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using ExampleStore.src.Infra.EntityFramework.Repositories;

namespace ExampleStore.src.Api.Controllers;

public class EmployeeController(WebApplication app) : IController
{
    private readonly WebApplication app = app;

    public void RegisterRoutes()
    {
        var group = app.MapGroup("/employees").WithTags("Employees");

        group.MapGet("/", async (ProductDb db) => {
            EmployeeRepository repository = new(db);
            GetEmployeesUseCase useCase = new(repository);

            var response = await useCase.Execute();
            if (response.Message is not null)
                return Results.BadRequest(new { message=response.Message });

            return Results.Ok(response.Data);
        });
    }
}