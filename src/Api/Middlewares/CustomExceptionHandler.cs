public class CustomExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<CustomExceptionHandler> _logger;

    public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "Ocorreu um erro durante o processamento da requisição.");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        Console.WriteLine(exception.Message);

        var errorResponse = new
        {
            Mensagem = "Ocorreu um erro interno no servidor.",
            Detalhes = exception.Message // Em ambiente de desenvolvimento, pode incluir mais detalhes
        };

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}