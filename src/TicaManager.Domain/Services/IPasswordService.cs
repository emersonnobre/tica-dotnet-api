using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Services;

public interface IPasswordService
{
    string HashPassword(User user, string password);
    bool VerifyPassword(User user, string password, string hash);
    
}