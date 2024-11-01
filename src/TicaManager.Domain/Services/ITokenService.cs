using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}