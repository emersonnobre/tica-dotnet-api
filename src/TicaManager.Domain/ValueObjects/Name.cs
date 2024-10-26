using TicaManager.Domain.Common;

namespace TicaManager.Domain.ValueObjects;

public class Name : Notifiable
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        if (string.IsNullOrEmpty(firstName) || firstName.Length > 255)
            AddNotification("Primeiro nome inválido!");
        if (string.IsNullOrEmpty(lastName) || lastName.Length > 255)
            AddNotification("Último nome inválido!");
    }
}