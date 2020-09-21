using ServiceShopperBlazorTest.Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    static class HttpRequestInterceptorLibrary
    {
        private static IEnumerable<IHttpRequestInterceptor> requestInterceptors = new IHttpRequestInterceptor[]
        {
            new ApiKeyService(new HttpClient()),
        };

        internal static IHttpRequestInterceptor GetInterceptorByClassName(string id)
        {
            return requestInterceptors.First(i => i.GetType().Name == id);
        }

        public static bool Contains<T>() {
            return requestInterceptors.Any(i => i.GetType().Name == typeof(T).Name);
        }

        public static string[] GetAllClassNames()
        {
            var names = new List<string>();
            foreach (var interceptor in requestInterceptors)
                names.Add(interceptor.GetType().Name);
            return names.ToArray();
        }
    }
}
