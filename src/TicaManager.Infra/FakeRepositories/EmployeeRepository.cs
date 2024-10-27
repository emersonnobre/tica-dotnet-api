using TicaManager.Domain.Entities;
using TicaManager.Domain.Repositories;

namespace TicaManager.Infra.FakeRepositories;

public class EmployeeRepository : IEmployeeRepository
{
    public void Save(Employee employee)
    {
    }

    public bool ExistsWithCpf(string cpf)
    { 
        return cpf.Equals("11111111111");
    }

    public bool ExistsWithEmail(string email)
    {
        return email.Equals("test@test.com");
    }
}