namespace TicaManager.Domain.Responses;

public class GetEmployeesResponse(string id, string name)
{
    public string Id { get; init; } = id;
    public string Name { get; init; } = name;
}