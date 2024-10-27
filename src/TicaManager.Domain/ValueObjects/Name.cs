using TicaManager.Domain.Common;

namespace TicaManager.Domain.ValueObjects;

public class Name : Notifiable
{
    public string Value { get; private set; }

    public Name(string name)
    {
        Value = name;

        if (string.IsNullOrEmpty(Value) || Value.Length > 255)
            AddNotification("Nome inválido!");;
    }
}