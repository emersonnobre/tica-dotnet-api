namespace TicaManager.Domain.Responses;

public class CreateEmployeeResponse(string id, string name, string email, string cpf)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Email { get; set; } = email;
    public string Cpf { get; set; } = cpf;
}