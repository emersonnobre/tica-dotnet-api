using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Repositories;

public interface IEmployeeRepository
{
    void Save(Employee employee);
    bool ExistsWithCpf(string cpf);
    bool ExistsWithEmail(string email);
}