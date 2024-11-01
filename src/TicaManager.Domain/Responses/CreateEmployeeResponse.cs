namespace TicaManager.Domain.Responses;

public class CreateEmployeeResponse(string id)
{
    public string Id { get; set; } = id;
}