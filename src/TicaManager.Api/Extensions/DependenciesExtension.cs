using TicaManager.Domain.Handlers;
using TicaManager.Domain.Repositories;
using TicaManager.Infra.FakeRepositories;

namespace TicaManager.Api.Extensions;

public static class DependenciesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    }
    
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<CreateEmployeeHandler>();
    }
}