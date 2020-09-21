using Microsoft.AspNetCore.Http;
using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceShopperBlazorTest.Client.Services
{
    public class  ApiKeyService : IExecutableService
    {
        public ApiKeyService(HttpClient client)
        {

        }

        public void Execute(ref HttpContext context)
        {
            throw new NotImplementedException();
        }

        string GetCurrentKey()
        {
            return "1234";
        }
    }
}
