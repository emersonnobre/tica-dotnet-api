using TicaManager.Domain.Entities;
using TicaManager.Domain.Handlers;
using TicaManager.Domain.Requests;
using TicaManager.Domain.ValueObjects;
using TicaManager.Infra.FakeRepositories;

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
        var name = new Name("Emerson");
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

app.MapPost("/api/v1/employees", (CreateEmployeeRequest request) =>
    {
        if (!request.IsValid)
            return Results.BadRequest(string.Join("\n", request.Notifications));
        var repository = new EmployeeRepository();
        var handler = new CreateEmployeeHandler(repository);
        var response = handler.Handle(request);
        return response.Success ? Results.Created(new Uri("/api/v1/employees"), response) : Results.BadRequest(response);
    })
.WithName("CreateEmployee")
.WithOpenApi()
.Produces(400)
.Produces(201)
.Produces(500);

app.Run();