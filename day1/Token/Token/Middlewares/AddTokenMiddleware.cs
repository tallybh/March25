using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Token.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AddTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public AddTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.Add("Token", "value");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AddTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseAddTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddTokenMiddleware>();
        }
    }
}
