using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public class HttpRequestInterceptionExecuter
    {
        public static readonly string interceptorPreFormatting = "interceptor1";
        public HttpRequestInterceptionFactory interceptionFactory;
        public HttpRequestInterceptionExecuter(HttpRequestInterceptionFactory interceptionFactory)
        {
            this.interceptionFactory = interceptionFactory;
        }
        public void ExecuteAllInterceptions(ref HttpContext context)
        {
            var interceptionIds = ExtractAllInterceptionClassNames(ref context);
            foreach (var id in interceptionIds)
                interceptionFactory.GetInterceptorByClassName(id)
                    .OnRequestInterception(ref context);
        }

        List<string> ExtractAllInterceptionClassNames(ref HttpContext context)
        {
            var names = new List<string>();
            var disposableHeaderKeys = new List<string>();
            foreach (var header in context.Request.Headers)
                if (header.Key.Contains(interceptorPreFormatting))
                {
                    names.Add(header.Key.Substring(interceptorPreFormatting.Length));
                    disposableHeaderKeys.Add(header.Key);
                }
            foreach (var key in disposableHeaderKeys)
                context.Request.Headers.Remove(key);

            return names;
        }
    }
}
