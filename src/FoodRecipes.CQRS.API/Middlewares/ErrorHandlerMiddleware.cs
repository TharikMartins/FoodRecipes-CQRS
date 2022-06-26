namespace FoodRecipes.CQRS.Api.Middlewares;

using System.Net;
using System.Text.Json;
using FoodRecipes.CQRS.Application.Responses;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandlerErrorAsync(context, ex, _logger);
        }
    }

    private async Task HandlerErrorAsync(HttpContext context, Exception ex, ILogger logger)
    {
        logger.LogError(ex, $"{ex.Message} , {ex.StackTrace}");

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        await context.Response.WriteAsync(JsonSerializer.Serialize(new ErrorResponse(Message: $"{ex.Message} , {ex.StackTrace}")));
    }
}