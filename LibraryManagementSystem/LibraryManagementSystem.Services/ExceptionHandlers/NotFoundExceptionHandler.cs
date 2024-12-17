using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LibraryManagementSystem.Services.ExceptionHandlers
{
    public class NotFoundExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is NotFoundException)
            {
                var problemDetail = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = "The requested resource could not be found. Please verify the ID and try again.",
                    Detail = exception.Message,
                    Type = exception.GetType().Name,
                    Instance = httpContext.Request.Path
                };

                httpContext.Response.StatusCode = problemDetail.Status.Value;
                httpContext.Response.ContentType = "application/problem+json";

                var result = JsonSerializer.Serialize(problemDetail);
                await httpContext.Response.WriteAsync(result, cancellationToken);

                return true;
            }
            return false;
        }
    }
}
