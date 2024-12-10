using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class RedisExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is RedisConnectionException)
            {
                var response = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Title = "An error occurred while accessing Redis Cache.",
                    Detail = exception.Message,
                    Type = exception.GetType().Name,
                    Instance = httpContext.Request.Path
                };

                var result = JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsync(result, cancellationToken);

                return true;
            }
            return false;
        }
    }
}
