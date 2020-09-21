using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public class HttpRequestInterceptionExecuter
    {
        public void ExecuteAllInterceptions(ref HttpContext context)
        {
            var interceptionIds = ExtractAllInterceptionClassNames(ref context);
            foreach (var id in interceptionIds)
                HttpRequestInterceptorLibrary.GetInterceptorByClassName(id)
                    .OnRequestInterception(ref context);
        }

        List<string> ExtractAllInterceptionClassNames(ref HttpContext context)
        {
            var names = HttpRequestInterceptorLibrary.GetAllClassNames();
            var interceptionsExtracted = new List<string>();
            bool didContainInterception = false;
            foreach (var name in names)
            {
                didContainInterception = context.Request.Headers.Remove(name);
                if (didContainInterception)
                    interceptionsExtracted.Add(name);
            }
            return interceptionsExtracted;
        }
    }
}
