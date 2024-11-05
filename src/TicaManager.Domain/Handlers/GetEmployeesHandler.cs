using Microsoft.Extensions.Caching.Memory;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Repositories;
using TicaManager.Domain.Responses;

namespace TicaManager.Domain.Handlers;

public class GetEmployeesHandler(IEmployeeRepository repository, IMemoryCache cache)
{
    public async Task<Response<IEnumerable<GetEmployeesResponse>>> Handle()
    {
        var employees = await cache.GetOrCreateAsync<List<Employee>>("EmployeesCache", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);
            return await GetEmployeesAsync();
        });
        employees ??= [];
        // var employees = await repository.GetAsync();
        var response = employees.Select(
            x => new GetEmployeesResponse(x.Id, x.Name.Value));
        return Response<IEnumerable<GetEmployeesResponse>>.NewSuccess(response);
    }

    private async Task<List<Employee>> GetEmployeesAsync()
    {
        Console.WriteLine("entrou GetEmployeesAsync");
        return await repository.GetAsync();
    } 
}