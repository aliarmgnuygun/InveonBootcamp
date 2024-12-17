using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace LibraryManagementSystem.Services.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var problemDetail = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "An error occurred while processing your request.",
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
    }
}
