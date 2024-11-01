using TicaManager.Domain.Common;
using TicaManager.Domain.Entities;
using TicaManager.Domain.ValueObjects;
// ReSharper disable MemberCanBePrivate.Global

namespace TicaManager.Domain.Requests;

// ReSharper disable once ClassNeverInstantiated.Global
public class CreateEmployeeRequest : Notifiable
{
    public string Name { get; }
    public string Email { get; }
    public string Cpf { get; }

    public CreateEmployeeRequest(string name, string email, string cpf)
    {
        Name = name;
        Email = email;
        Cpf = cpf;
        
        if (string.IsNullOrEmpty(name))
            AddNotification("O nome deve ser informado!");
        if (string.IsNullOrEmpty(email))
            AddNotification("O e-mail deve ser informado!");
        if (string.IsNullOrEmpty(cpf))
            AddNotification("O CPF deve ser informado!");
    }
    
    public Employee MapToEntity()
    {
        var name = new Name(Name);
        var email = new Email(Email);
        var cpf = new Cpf(Cpf);
        return new Employee(name, email, cpf);
    }
}