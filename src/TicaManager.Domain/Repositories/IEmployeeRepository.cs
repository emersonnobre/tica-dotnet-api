using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Repositories;

public interface IEmployeeRepository
{
    Task SaveAsync(Employee employee);
    Task<bool> ExistsWithCpfAsync(string cpf);
    Task<bool> ExistsWithEmailAsync(string email);
    Task<List<Employee>> GetAsync();
}