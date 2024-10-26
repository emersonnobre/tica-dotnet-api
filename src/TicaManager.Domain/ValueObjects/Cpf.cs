using TicaManager.Domain.Common;

namespace TicaManager.Domain.ValueObjects;

public class Cpf : Notifiable
{
    public string Number { get; private set; }

    public Cpf(string number)
    {
        Number = number;

        if (Number.Length != 11)
            AddNotification("CPF inválido!");
    }
}