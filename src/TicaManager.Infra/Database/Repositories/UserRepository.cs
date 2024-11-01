using Microsoft.EntityFrameworkCore;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Repositories;

namespace TicaManager.Infra.Database.Repositories;

public class UserRepository(TicaContext db) : IUserRepository
{
    public async Task SaveAsync(User user)
    {
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await db.Users.FirstOrDefaultAsync(e => e.Username == username);
    }

    public async Task<bool> ExistsWithUsernameAsync(string username)
    {
        return await db.Users.AnyAsync(e => e.Username == username);
    }
}