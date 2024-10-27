namespace TicaManager.Domain.Responses;

public class Response<T>
{
    public bool Success { get; private set; }
    public string? Message { get; private set; }
    public T? Data { get; private set; }

    public static Response<T> NewSuccess(T data)
    {
        return new Response<T>() { Success = true, Data = data };
    }

    public static Response<T> NewFailure(string message)
    {
        return new Response<T>() { Success = false, Message = message };
    }
}