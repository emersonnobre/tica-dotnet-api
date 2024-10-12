using ExampleStore.src.Application.DTO;
using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;

namespace ExampleStore.src.Application.UseCases;

public class GetCategoriesUseCase(ICategoryRepository repository)
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<UseCaseResponseDTO<List<Category>>> Execute()
    {
        var categories = await _repository.Get();

        return new UseCaseResponseDTO<List<Category>>(){Data=categories ?? []};
    }
}