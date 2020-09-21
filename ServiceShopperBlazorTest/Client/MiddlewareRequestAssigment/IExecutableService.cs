using Microsoft.AspNetCore.Http;

namespace ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment
{
    public interface IExecutableService
    {
        public void Execute(ref HttpContext context);
    }
}
