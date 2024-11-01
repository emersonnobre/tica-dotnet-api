using TicaManager.Domain.Repositories;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;

namespace TicaManager.Domain.Handlers;

public class CreateEmployeeHandler(IEmployeeRepository repository)
{
    // private readonly IEmployeeRepository _repository = repository;
    
    public async Task<Response<CreateEmployeeResponse>> Handle(CreateEmployeeRequest request)
    {
        var employee = request.MapToEntity();
        if (!employee.IsValid)
            return Response<CreateEmployeeResponse>.NewFailure(employee.Notifications);

        if (await repository.ExistsWithCpfAsync(employee.Cpf.Number))
            return Response<CreateEmployeeResponse>.NewFailure("Já existe um funcionário com este CPF!");
        
        if (await repository.ExistsWithEmailAsync(employee.Email.Address))
            return Response<CreateEmployeeResponse>.NewFailure("Já existe um funcionário com este e-mail!");

        repository.SaveAsync(employee);
        var response = new CreateEmployeeResponse(employee.Id);
        return Response<CreateEmployeeResponse>.NewSuccess(response);
    }
}