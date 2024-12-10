using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LibraryManagementApi.Services.ExceptionHandlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            // Handle 404 Not Found
            if (exception is NotFoundException)
            {
                var response = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = "Record not found for the id you are looking for.",
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