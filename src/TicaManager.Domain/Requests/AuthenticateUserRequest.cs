namespace TicaManager.Domain.Requests;

public class AuthenticateUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}