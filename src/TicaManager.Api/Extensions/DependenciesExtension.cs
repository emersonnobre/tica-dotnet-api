using TicaManager.Domain.Handlers;
using TicaManager.Domain.Repositories;
using TicaManager.Domain.Services;
using TicaManager.Infra.Database.Repositories;
using TicaManager.Infra.Services;

namespace TicaManager.Api.Extensions;

public static class DependenciesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    }
    
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<CreateEmployeeHandler>();
        services.AddTransient<GetEmployeesHandler>();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}