using ExampleStore.src.Domain.Entities;

namespace ExampleStore.src.Domain.Interfaces;
public interface IEmployeeRepository
{
    Task<List<Employee>> Get();
}