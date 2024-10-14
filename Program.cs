using Microsoft.OpenApi.Models;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using ExampleStore.src.Api.Controllers;
using ExampleStore.src.Api.Middlewares;
using ExampleStore.src.Api.Controllers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example Store API", Description = "General purpose store API", Version = "v1" });
});

builder.Services.AddDbContext<ProductDb>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("MysqlConnection"), new MySqlServerVersion(new Version(8, 0, 28)));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseMiddleware<CustomExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1");
    });
    app.SeedDatabase();
}

app.MapGet("/health-check", () => "Ok!").WithTags("Health Check");

IEnumerable<IController> controllers = [ 
    new CategoryController(app), 
    new EmployeeController(app),
    new ProductController(app), 
];

foreach (var controller in controllers)
    controller.RegisterRoutes();

app.Run();
