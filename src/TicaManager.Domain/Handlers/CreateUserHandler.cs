using TicaManager.Domain.Repositories;
using TicaManager.Domain.Requests;
using TicaManager.Domain.Responses;

namespace TicaManager.Domain.Handlers;

public class CreateUserHandler(IUserRepository repository)
{
    public async Task<Response<string>> Handle(CreateUserRequest request)
    {
        var alreadyExists = await repository.ExistsWithUsernameAsync(request.Username);
        if (alreadyExists)
            return Response<string>.NewFailure("Já existe um usuário com este username!");
        var user = request.MapToEntity();
        await repository.SaveAsync(user);
        return Response<string>.NewSuccess(user.Username);
    }
}