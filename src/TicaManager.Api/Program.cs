using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TicaManager.Api.Configuration;
using TicaManager.Api.Extensions;
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
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureJwtAuthentication();

// app configuration
var app = builder.Build();
app.ConfigureSwaggerForApp();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();