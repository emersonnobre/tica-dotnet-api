namespace ExampleStore.src.Domain.Entities;

public record Category 
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    
    public Category(string description)
    {
        Description = description;
    }
}