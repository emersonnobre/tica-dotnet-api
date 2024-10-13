using ExampleStore.src.Domain.Entities;

namespace ExampleStore.src.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> Get();
    Task<Category?> GetByDescription(string description);
    Task<Category> Create(Category category);
    Task<int> SaveChanges();
    void Delete(int id);
}