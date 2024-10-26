using TicaManager.Domain.Common;

namespace TicaManager.Domain.ValueObjects;

public class Email : Notifiable
{
    public string Address { get; private set; }

    public Email(string address)
    {
        Address = address;
        
        if (!address.Contains('@'))
            AddNotification("E-mail inválido!");
    }
}