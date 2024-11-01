using Microsoft.EntityFrameworkCore;
using TicaManager.Api.Extensions;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Handlers;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;
using TicaManager.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddDbContext<TicaContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/v1/employees", (TicaContext ctx) =>
    {
        var employees = ctx.Employees.Take(10).ToList();
        return Results.Ok(employees);
})
.WithName("GetEmployees")
.WithOpenApi()
.Produces(400)
.Produces(200)
.Produces(500);

app.MapPost("/api/v1/employees", async (CreateEmployeeRequest request, CreateEmployeeHandler handler) =>
    {
        var initial = DateTime.Now;
    if (!request.IsValid)
        return Results.BadRequest(Response<Employee>.NewFailure(request.Notifications));
    var response = await handler.Handle(request);
    var responsetime = DateTime.Now.Subtract(initial);
    Console.WriteLine(responsetime);
    return response.Success ? Results.Created(new Uri("/api/v1/employees"), response) : Results.BadRequest(response);
})
.WithName("CreateEmployee")
.WithOpenApi()
.Produces(400)
.Produces(201)
.Produces(500);

app.Run();