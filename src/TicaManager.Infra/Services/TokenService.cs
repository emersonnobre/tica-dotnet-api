using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TicaManager.Domain.Services;

namespace TicaManager.Infra.Services;

public class TokenService : ITokenService
{
    private const string Key = "opss123opss123opss123opss123opss123opss123";
    public string GenerateToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var keybyte = Encoding.ASCII.GetBytes(Key);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.Name, "emersonnobre"),
                new Claim(ClaimTypes.Role, "admin")
            ]),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(keybyte),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}