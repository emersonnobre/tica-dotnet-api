using TicaManager.Domain.Common;
using TicaManager.Domain.Entities;

namespace TicaManager.Domain.Requests;

public class CreateUserRequest : Notifiable
{
    public string Username { get; }
    public string Password { get; }

    public CreateUserRequest(string username, string password)
    {
        Username = username;
        Password = password;
        
        if (string.IsNullOrWhiteSpace(username))
            AddNotification("Informe o usuário!");
        if (string.IsNullOrEmpty(password))
            AddNotification("Informe a senha!");
    }

    public User MapToEntity()
    {
        return new User(Username);
    }
}