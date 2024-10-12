using ExampleStore.src.Domain.Entities;

namespace ExampleStore.src.Domain.Interfaces;

public interface IProductRepository : IBaseRepository
{
    Task<List<Product>> Get();
    Task<Product?> Get(int id);
    Task<Product> Create(Product product);
    Product Update(Product product);
}