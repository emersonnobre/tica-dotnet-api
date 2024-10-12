using ExampleStore.src.Application.DTO;

namespace ExampleStore.src.Application.UseCases.Interfaces;

public interface IUseCase<Y, T>
{
    Task<UseCaseResponseDTO<T>> Execute(Y request);
}