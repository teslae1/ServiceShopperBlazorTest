using System.Net.Http;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public static class HttpRequestInterceptionAdder
    {
        public static void AddRequestInterceptor<T>(this HttpClient client)
        {
            ValidateClass<T>();
            client.DefaultRequestHeaders.Add(typeof(T).Name, "");
        }

        static void ValidateClass<T>()
        {
            if (!HttpRequestInterceptorLibrary.Contains<T>())
                throw new NoMatchingRequestInterceptorFoundInLibraryException
                    ("No matching request interceptor was found in interceptorLibrary");
        }
    }
}
