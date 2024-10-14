using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleStore.src.Domain.Entities;
public record Employee 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    public Employee(string name)
    {
        Name = name;
        CreatedAt = DateTime.Now;
    }
}
