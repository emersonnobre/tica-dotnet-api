namespace ExampleStore.src.Application.DTO;

public record UseCaseResponseDTO<T>
{
    public string? Message { get; set; }
    public T? Data { get; set; }
}