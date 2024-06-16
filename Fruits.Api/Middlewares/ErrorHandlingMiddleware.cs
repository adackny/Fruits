using System.Net;
using System.Text.Json;

namespace Fruits.Api.Middlewares;

public class ErrorHandlingMiddleware(RequestDelegate _next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch
        {
            await HandleExceptionAsync(context);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new
        {
            error = "An error occurred while proccessing your request"
        });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}
