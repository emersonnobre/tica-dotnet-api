namespace TicaManager.Domain.Common;

public abstract class Notifiable
{
    public bool IsValid { get; private set; } = true;
    private readonly List<string> _notifications = [];

    protected void AddNotification(string notification)
    {
        IsValid = false;
        _notifications.Add(notification);
    }
    
    private void AddNotifications(List<string> notifications)
    {
        if (notifications.Count > 0)
            IsValid = false;
        _notifications.AddRange(notifications);
    }

    protected void AggregateNotifiables(params Notifiable[] notifiables)
    {
        foreach (var not in notifiables)
            AddNotifications(not.Notifications);
    }
    
    protected void ClearNotifications()
    {
        IsValid = true;
        _notifications.Clear();
    }
    
    public List<string> Notifications => _notifications.ToList();
}