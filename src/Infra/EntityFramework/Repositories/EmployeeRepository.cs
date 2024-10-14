using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ExampleStore.src.Infra.EntityFramework.Repositories;
public class EmployeeRepository(ProductDb db) : IEmployeeRepository
{
    private readonly ProductDb _db = db;

    async Task<List<Employee>> IEmployeeRepository.Get()
    {
        return await _db.Employees.ToListAsync();
    }
}