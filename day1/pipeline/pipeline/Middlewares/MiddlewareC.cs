using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace pipeline.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareC
    {
        private readonly RequestDelegate _next;

        public MiddlewareC(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Method == HttpMethods.Get && httpContext.Request.Query["custom"] == "1")
            {
                await httpContext.Response.WriteAsync(" Middle C\n");
            }
            await _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareCExtensions
    {
        public static IApplicationBuilder UseMiddlewareC(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareC>();
        }
    }
}
