using Microsoft.AspNetCore.Diagnostics;

namespace BlazorApp2.Exceptions
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> logger;
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            this.logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            (int statusCode, string message) = exception switch
            {
                FormatException ex => (403, ex.Message),
                BadHttpRequestException ex => (400, ex.Message),
                ArgumentException ex => (400, ex.Message),
                InvalidOperationException ex => (400, ex.Message),
                NotFiniteNumberException ex => (404, ex.Message),
                _ => (500, "An error occurred while processing your request.")
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";
            //await httpContext.Response.WriteAsync( message, cancellationToken);
            await httpContext.Response.WriteAsJsonAsync(message, cancellationToken);


            return true;
            //return ValueTask.FromResult(false);
        }
    }
}
