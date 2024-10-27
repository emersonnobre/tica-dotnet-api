using TicaManager.Domain.Repositories;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;

namespace TicaManager.Domain.Handlers;

public class CreateEmployeeHandler(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;
    
    public Response<CreateEmployeeResponse> Handle(CreateEmployeeRequest request)
    {
        var employee = request.MapToEntity();
        if (!employee.IsValid)
            return Response<CreateEmployeeResponse>.NewFailure(string.Join("\n", employee.Notifications));

        if (_repository.ExistsWithCpf(employee.Cpf.Number))
            return Response<CreateEmployeeResponse>.NewFailure("Já existe um funcionário com este CPF!");
        
        if (_repository.ExistsWithEmail(employee.Email.Address))
            return Response<CreateEmployeeResponse>.NewFailure("Já existe um funcionário com este e-mail!");

        _repository.Save(employee);
        var response = new CreateEmployeeResponse(employee.Id, employee.Name.Value, employee.Email.Address, employee.Cpf.Number);
        return Response<CreateEmployeeResponse>.NewSuccess(response);
    }
}