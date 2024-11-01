namespace TicaManager.Domain.Responses;

public class Response<T>
{
    public bool Success { get; private set; }
    public IList<string> Messages { get; private set; } = new List<string>();
    public T? Data { get; private set; }

    public static Response<T> NewSuccess(T data)
    {
        return new Response<T>() { Success = true, Data = data };
    }

    public static Response<T> NewFailure(string message)
    {
        return new Response<T>() { Success = false, Messages = [message] };
    }

    public static Response<T> NewFailure(IList<string> messages)
    {
        return new Response<T>() { Success = false, Messages = messages };
    }
}