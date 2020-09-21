using ServiceShopperBlazorTest.Client.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    static class ExecuteableAssigmentLibrary
    {
        public static IEnumerable<ServiceAssigment> ServiceAssigments = new List<ServiceAssigment>()
        {
            new ServiceAssigment
            {
                RequestHeaderId = "apiKey",
                service = new ApiKeyService(new HttpClient())
            }
        };
    }
}
