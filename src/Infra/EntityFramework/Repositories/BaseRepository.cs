using ExampleStore.src.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ExampleStore.src.Infra.EntityFramework.Repositories;
public abstract class BaseRepository(DbContext context) : IBaseRepository
{
    private readonly DbContext _context = context;

    public async void BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async void CommitChanges()
    {
        await _context.SaveChangesAsync();
        await _context.Database.CommitTransactionAsync();
    }

    public void Rollback()
    {
        _context.Database.RollbackTransactionAsync();
    }
}