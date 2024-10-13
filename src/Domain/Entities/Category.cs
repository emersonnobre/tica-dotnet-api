using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleStore.src.Domain.Entities;

public record Category 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; private set; }
    public string Description { get; private set; }
    
    public Category(string description)
    {
        Description = description;
    }
}