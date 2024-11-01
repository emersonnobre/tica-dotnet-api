using Microsoft.EntityFrameworkCore;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Repositories;
using TicaManager.Domain.ValueObjects;

namespace TicaManager.Infra.Database.Repositories;

public class EmployeeRepository(TicaContext db) : IEmployeeRepository
{
    public async Task SaveAsync(Employee employee)
    {
        await db.AddAsync(employee);
        await db.SaveChangesAsync();
    }

    public async Task<bool> ExistsWithCpfAsync(string cpf)
    {
        var count = await db.Employees.Where(x => x.Cpf.Number == cpf).CountAsync();
        return count > 0;
    }

    public async Task<bool> ExistsWithEmailAsync(string email)
    {
        var count = await db.Employees.Where(x => x.Email.Address == email).CountAsync();
        return count > 0;
    }

    public async Task<List<Employee>> GetAsync()
    {
        return await db.Employees.Take(10).ToListAsync();
    }
}