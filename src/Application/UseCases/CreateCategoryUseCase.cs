using ExampleStore.src.Application.DTO;
using ExampleStore.src.Application.UseCases.Interfaces;
using ExampleStore.src.Domain.Entities;
using ExampleStore.src.Domain.Interfaces;

namespace ExampleStore.src.Application.UseCases;

public class CreateCategoryUseCase(ICategoryRepository repository) : IUseCase<CreateCategoryDTO, Category>
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<UseCaseResponseDTO<Category>> Execute(CreateCategoryDTO categoryDTO)
    {
        if (categoryDTO.Description is null || categoryDTO.Description.Trim().Equals(""))
            return new UseCaseResponseDTO<Category>(){Data=null, Message="Informe a descrição da categoria!"};

        var existentCategory = await _repository.GetByDescription(categoryDTO.Description);
        if (existentCategory is not null)
            return new UseCaseResponseDTO<Category>(){Data=null, Message="Já existe uma categoria com essa descrição!"};

        var category = new Category(categoryDTO.Description);
        await _repository.Create(category);
        await _repository.SaveChanges();

        return new UseCaseResponseDTO<Category>(){Data=category};
    }
}