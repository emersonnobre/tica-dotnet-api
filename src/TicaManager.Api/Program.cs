using Microsoft.AspNetCore.Http.HttpResults;
using TicaManager.Domain.Entities;
using TicaManager.Domain.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.MapGet("/api/v1/employees", () => { 
        var name = new Name("Emerson", "");
        var email = new Email("emersongmail.com");
        var cpf = new Cpf("1234568900");
        var employee = new Employee(name, email, cpf);
        return employee.IsValid ? Results.Ok(employee) : Results.BadRequest(employee.Notifications);
})
.WithName("GetEmployees")
.WithOpenApi()
.Produces(400)
.Produces(200)
.Produces(500);

app.Run();