using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MovieShopMVC.Infra
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("inside exception middleware");

            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception happened, handle here");
                await HandleExceptionLogic(httpContext, ex);
            }           
        }

        private async Task HandleExceptionLogic(HttpContext httpContext, Exception exception)
        {
            _logger.LogError("something went wrong");
            var exceptionDetails = new
            {
                ExceptionMessage = exception.Message,
                ExceptionStackTrace = exception.StackTrace,
                ExceptionType = exception.GetType(),
                ExceptionDetails = exception.InnerException?.Message,
                ExceptionDateTime = DateTime.UtcNow,
                Path = httpContext.Request.Path,
                HttpMethod = httpContext.Request.Method,
                User = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name : null,

            };

            _logger.LogError(exceptionDetails.ExceptionMessage);
            httpContext.Response.Redirect("/home/error");
            await Task.CompletedTask;

       
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
