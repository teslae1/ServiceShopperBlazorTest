using Microsoft.AspNetCore.Http;
using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceShopperBlazorTest.Client.Services
{
    public class MoliriTenantService : IHttpRequestInterceptor
    {
        public void OnRequestInterception(ref HttpContext context)
        {
            context.Request.Headers.Add("moliriTenantPassword", GetData());
        }

        string GetData()
        {
            return "moliriTenantData";
        }
    }
}
