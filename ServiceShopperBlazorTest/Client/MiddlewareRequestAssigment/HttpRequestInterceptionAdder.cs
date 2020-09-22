using ServiceShopperBlazorTest.Client.Services;
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public static class HttpRequestInterceptionAdder
    {
        public static void AddRequestInterceptor<T>(this HttpClient client)where T: IHttpRequestInterceptor
        {
            client.DefaultRequestHeaders.Add(HttpRequestInterceptionExecuter.interceptorPreFormatting + typeof(T).Name, "f");
        }

    }
}
