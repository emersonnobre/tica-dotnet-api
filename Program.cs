using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Infra.EntityFramework.Repositories;
using Microsoft.OpenApi.Models;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using ExampleStore.src.Domain.Interfaces;
using ExampleStore.src.Api.Controllers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); // for swagger
builder.Services.AddSwaggerGen(c => 
{ // for swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Example Store API", Description = "General purpose store API", Version = "v1" });
});
var connectionString = builder.Configuration.GetConnectionString("Products") ?? "Data Source=Products.db";
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
}

app.MapGet("/", () => "Te amo minha vida!");
app.MapGet("/check", () => "Ok!");


app.MapPost("/products", async (ProductDb db, Product product) =>
{
    IProductRepository repository = new ProductRepository(db);
    
    await repository.Create(product);
    await db.SaveChangesAsync();

    return product;
});

app.MapGet("/products", async (ProductDb db) =>
{
    IProductRepository repository = new ProductRepository(db);
    var products = await repository.Get();
    return products;
});

app.MapGet("/products/{id}", async (ProductDb db, int id) =>
{
    IProductRepository repository = new ProductRepository(db);
    var product = await repository.Get(id);
    if (product is null)
    {
        return Results.NotFound(new { message="Produto não encontrado" });
    }
    return Results.Ok(product);
});

CategoryController categoryController = new(app);
categoryController.RegisterRoutes();

app.Run();
