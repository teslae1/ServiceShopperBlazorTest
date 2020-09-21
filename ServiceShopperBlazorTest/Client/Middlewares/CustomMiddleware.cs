using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;

namespace ServiceShopperBlazorTest.Client.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        HttpRequestInterceptionExecuter requestInterceptor;

        public CustomMiddleware(RequestDelegate next, HttpRequestInterceptionExecuter requestInterceptor)
        {
            _next = next;
            this.requestInterceptor = requestInterceptor;
        }

        public Task Invoke(HttpContext httpContext)
        {
            requestInterceptor.ExecuteAllInterceptions(ref httpContext);
            var apiKey = httpContext.Request.Headers["moliriApiKey"];
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
