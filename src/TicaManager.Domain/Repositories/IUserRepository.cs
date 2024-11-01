using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Repositories;

public interface IUserRepository
{
    Task SaveAsync(User user);
    Task<User?> GetByUsernameAsync(string username);
    Task<bool> ExistsWithUsernameAsync(string username);
}