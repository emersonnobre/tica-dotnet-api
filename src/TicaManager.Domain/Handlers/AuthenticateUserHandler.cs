using TicaManager.Domain.Repositories;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;
using TicaManager.Domain.Services;

namespace TicaManager.Domain.Handlers;

public class AuthenticateUserHandler(IUserRepository repository, IPasswordService passwordService, ITokenService tokenService)
{
    public async Task<Response<string?>> Handle(AuthenticateUserRequest request)
    {
        var user = await repository.GetByUsernameAsync(request.Username);
        if (user == null)
            return Response<string?>.NewFailure("Username ou senha inválidos!");
        var passwordIsValid = passwordService.VerifyPassword(user, request.Password, user.PasswordHash);
        return passwordIsValid ? 
            Response<string?>.NewSuccess(tokenService.GenerateToken(user)) : 
            Response<string?>.NewFailure("Username ou senha inválidos!");;
    }
}