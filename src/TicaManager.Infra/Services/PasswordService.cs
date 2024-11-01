using Microsoft.AspNetCore.Identity;
using TicaManager.Domain.Entities;
using TicaManager.Domain.Services;

namespace TicaManager.Infra.Services;

public class PasswordService : IPasswordService
{
    private readonly PasswordHasher<User> _hasher = new();
    
    public string HashPassword(User user, string password)
    {
        return _hasher.HashPassword(user, password);
    }

    public bool VerifyPassword(User user, string password, string hash)
    {
        var result = _hasher.VerifyHashedPassword(user, hash, password);
        return result == PasswordVerificationResult.Success;
    }
}