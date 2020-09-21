using ServiceShopperBlazorTest.Client.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Resources;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public class HttpRequestInterceptionFactory
    {
        private List<IHttpRequestInterceptor> interceptors = new List<IHttpRequestInterceptor>();
        public IHttpRequestInterceptor GetInterceptorByClassName(string id)
        {
            var interceptor = interceptors.FirstOrDefault(i => i.GetType().Name == id);
            if (interceptor == null)
            {
                interceptor = CreateNewInstanceOfClass(id);
                interceptors.Add(interceptor);
            }
            return interceptor;
        }

        IHttpRequestInterceptor CreateNewInstanceOfClass(string className)
        {
            var type = GetTypeFromStringClassName(className);
            var instance = TryGetInstanceParameterLessConstruction(type);
            if (instance == null)
                instance = TryGetInstanceHttpClientParamConstruction(type);
            if (instance == null)
                throw new NoSetupToCreateInstanceOfClassWithThoseParameters(
                    "RequestInterceptionFactory does not have setup for a class with those construction parameters");
            return instance;
        }

        Type GetTypeFromStringClassName(string className)
        {

            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(t => t.Name.ToLower() == className.ToLower());
        }

        IHttpRequestInterceptor TryGetInstanceParameterLessConstruction(Type type)
        {
            try
            {
            return (IHttpRequestInterceptor)Activator.CreateInstance(type);
            }
            catch
            {
                return null;
            }
        }

        IHttpRequestInterceptor TryGetInstanceHttpClientParamConstruction(Type type)
        {
            try
            {
            return (IHttpRequestInterceptor)Activator.CreateInstance(type, new HttpClient());
            }
            catch
            {
                return null;
            }
        }
    }
}
