using TicaManager.Domain.Repositories;
using TicaManager.Domain.Responses;

namespace TicaManager.Domain.Handlers;

public class GetEmployeesHandler(IEmployeeRepository repository)
{
    public async Task<Response<IEnumerable<GetEmployeesResponse>>> Handle()
    {
        var employees = await repository.GetAsync();
        var response = employees.Select(
            x => new GetEmployeesResponse(x.Id, x.Name.Value));
        return Response<IEnumerable<GetEmployeesResponse>>.NewSuccess(response);
    }
}