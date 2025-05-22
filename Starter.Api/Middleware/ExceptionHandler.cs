using Microsoft.AspNetCore.Diagnostics;
using Starter.Api.Shared.Errors;

namespace Starter.Api.Middleware;

public class ExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var error = new Error(nameof(Exception), exception.Message, ErrorType.Problem, exception.Source ?? nameof(exception));
        
        httpContext.Response.WriteAsJsonAsync(error, cancellationToken: cancellationToken);
        
        return new ValueTask<bool>(true);
    }
}