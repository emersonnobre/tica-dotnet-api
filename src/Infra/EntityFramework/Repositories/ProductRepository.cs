using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;
using ExampleStore.src.Infra.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ExampleStore.src.Infra.EntityFramework.Repositories;

public class ProductRepository(ProductDb db) : IProductRepository
{
    private readonly ProductDb _db = db;

    public async Task<Product> Create(Product product)
    {
        await _db.Products.AddAsync(product);
        return product;
    }

    public async Task<List<Product>> Get()
    {
        return await _db.Products.ToListAsync();
    }

    public async Task<Product?> Get(int id)
    {
        return await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Product Update(Product product)
    {
        throw new NotImplementedException();
    }
}