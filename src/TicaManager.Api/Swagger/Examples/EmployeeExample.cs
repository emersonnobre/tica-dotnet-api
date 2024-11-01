using Swashbuckle.AspNetCore.Filters;
using TicaManager.Domain.Requests;

namespace TicaManager.Api.Swagger.Examples;

public class EmployeeExample : IExamplesProvider<CreateEmployeeRequest>
{
    public CreateEmployeeRequest GetExamples()
    {
        return new CreateEmployeeRequest("John Doe", "john@gmail.com", "0000000000");
    }
}