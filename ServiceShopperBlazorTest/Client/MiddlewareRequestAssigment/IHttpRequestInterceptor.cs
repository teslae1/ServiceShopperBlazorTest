using Microsoft.AspNetCore.Http;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public interface IHttpRequestInterceptor
    {
        public void OnRequestInterception(ref HttpContext context);
    }
}
