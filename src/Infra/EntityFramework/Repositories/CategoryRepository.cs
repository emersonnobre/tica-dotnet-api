using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ExampleStore.src.Infra.EntityFramework.Repositories;

public class CategoryRepository(ProductDb db) : ICategoryRepository
{
    private readonly ProductDb _db = db;

    public async Task<Category> Create(Category category)
    {
        await _db.Categories.AddAsync(category);
        return category;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Category>> Get()
    {
        return await _db.Categories.ToListAsync();
    }

    public async Task<Category?> GetByDescription(string description)
    {
        return await _db.Categories.FirstOrDefaultAsync(c => c.Description.Equals(description));
    }

    public async void SaveChanges()
    {
        await _db.SaveChangesAsync();
    }
}