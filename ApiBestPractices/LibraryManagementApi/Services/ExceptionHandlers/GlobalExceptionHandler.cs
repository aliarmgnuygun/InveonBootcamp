using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var statusCode = exception switch
            {
                RedisConnectionException => StatusCodes.Status503ServiceUnavailable,
                RedisTimeoutException => StatusCodes.Status504GatewayTimeout,

                ArgumentException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/problem+json";

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Title = "An error occurred while processing your request.",
                    Detail = exception.Message,
                    Type = exception.GetType().Name,
                    Instance = httpContext.Request.Path
                }
            });
        }
    }
}