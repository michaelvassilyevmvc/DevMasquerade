using System.Text.Json;
using DevMasquerade.Application.Exceptions;
using Shared;

namespace DevMasquerade.Web.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
        _logger.LogError(exception, exception.Message);
        var (code, errors) = exception switch
        {
            BadRequestException => (StatusCodes.Status500InternalServerError,
                JsonSerializer.Deserialize<Error[]>(exception.Message)),
            NotFoundException => (StatusCodes.Status404NotFound,
                JsonSerializer.Deserialize<Error[]>(exception.Message)),
            _ => (StatusCodes.Status500InternalServerError, [Error.Failure(null, "Something went wrong")]),
        };
        context.Response.StatusCode = code;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(errors);
    }
}

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this WebApplication app)
    {
        return app.UseMiddleware<ExceptionMiddleware>();
    }
}