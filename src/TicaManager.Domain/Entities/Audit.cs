namespace TicaManager.Domain.Entities;

public class Audit
{
    public string Id { get; private set; }
    public string Action { get; private set; }
    public string EmployeeId { get; private set; }
    public Employee Employee { get; private set; }
    public DateTime Date { get; private set; }
}