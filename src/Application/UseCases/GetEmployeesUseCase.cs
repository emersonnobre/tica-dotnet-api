using ExampleStore.src.Application.DTO;
using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;

namespace ExampleStore.src.Application.UseCases;
public class GetEmployeesUseCase(IEmployeeRepository repository)
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task<UseCaseResponseDTO<List<Employee>>> Execute()
    {
        var employees = await _repository.Get();
        return new UseCaseResponseDTO<List<Employee>>(){Data=employees ?? []};
    }
}