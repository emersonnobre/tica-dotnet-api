using TicaManager.Domain.Common;
using TicaManager.Domain.ValueObjects;

namespace TicaManager.Domain.Entities;

public class Employee : Notifiable
{
    public string Id { get; private set; }
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Cpf Cpf { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public ICollection<Audit> Audits { get; private set; }
    
    public Employee() {}
    
    public Employee(Name name, Email email, Cpf cpf)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Email = email;
        Cpf = cpf;
        CreatedAt = DateTime.Now;
        Audits = [];
        
        AggregateNotifiables(Name, Email, Cpf);
    }
}