using TicaManager.Domain.Common;
using TicaManager.Domain.ValueObjects;

namespace TicaManager.Domain.Entities;

public class User : Notifiable
{
    public string Username { get; private set; }
    public string PasswordHash { get; private set; }
    public DateTime CreatedAt { get; private set; }

    protected User()
    {
        Username = string.Empty;
        PasswordHash = string.Empty;
        CreatedAt = DateTime.Now;
    }

    public User(string username)
    {
        Username = username;
        PasswordHash = string.Empty;
        CreatedAt = DateTime.Now;
    }

    public void ChangePassword(string password)
    {
        PasswordHash = password;
    }
}