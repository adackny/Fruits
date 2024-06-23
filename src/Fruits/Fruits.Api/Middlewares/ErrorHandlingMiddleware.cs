using System.Net;
using System.Text.Json;
using Fruits.Api.Communication.Wrappers;

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
        var error = ErrorOr.Error.Unexpected(
            code:"internal-server-error",
            description: "An error occurred while proccessing your request."
        );
        
        var result = JsonSerializer.Serialize(new Response(error));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        return context.Response.WriteAsync(result);
    }
}
