using Microsoft.AspNetCore.Http;
using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ServiceShopperBlazorTest.Client.Services
{
    public class  ApiKeyService : IHttpRequestInterceptor
    {
        public ApiKeyService(HttpClient client)
        {
            if (client == null)
                throw new Exception("client was null");
        }

        public void OnRequestInterception(ref HttpContext context)
        {
            context.Request.Headers.Add("moliriApiKey", GetCurrentKey());
        }

        string GetCurrentKey()
        {
            return "1234";
        }
    }
}
