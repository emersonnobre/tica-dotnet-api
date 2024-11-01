using TicaManager.Domain.Entities;
using TicaManager.Domain.Repositories;

namespace TicaManager.Infra.FakeRepositories;

public class EmployeeRepository : IEmployeeRepository
{
    public EmployeeRepository()
    {
        Console.WriteLine("Criou nova instância!");
    }
    public async Task SaveAsync(Employee employee)
    {
        await Task.Delay(0);
    }

    public async Task<bool> ExistsWithCpfAsync(string cpf)
    { 
        await Task.Delay(5000);
        return cpf.Equals("11111111111");
    }

    public async Task<bool> ExistsWithEmailAsync(string email)
    {
        await Task.Delay(5000);
        return email.Equals("test@test.com");
    }

    public async Task<List<Employee>> GetAsync()
    {
        await Task.Delay(5000);
        return [];
    }
}