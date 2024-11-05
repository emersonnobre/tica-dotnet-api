using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TicaManager.Api.Configuration;
using TicaManager.Api.Extensions;
using TicaManager.Domain.Common;
using TicaManager.Infra.Database;

var builder = WebApplication.CreateBuilder(args);

// DI
builder.Services.AddRepositories();
builder.Services.AddHandlers();
builder.Services.AddServices();
builder.Services.AddDbContext<TicaContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// build configuration
builder.Services.ConfigureSwaggerForBuild();
builder.Services.AddControllers().AddJsonOptions(c =>
{
    c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureJwtAuthentication();
builder.Services.AddMemoryCache();


// app configuration
var app = builder.Build();
app.ConfigureSwaggerForApp();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

var jwtKey = app.Configuration.GetValue<string>("JwtKey");
Configuration.JwtKey = jwtKey ?? string.Empty;

app.Run();