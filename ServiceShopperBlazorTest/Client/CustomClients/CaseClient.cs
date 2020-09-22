using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;
using System.Net.Http;

namespace ServiceShopperBlazorTest.Client.Services
{
    public class CaseClient
    {
        HttpClient client;
        public CaseClient(HttpClient client)
        {
            this.client = client;
            client.AddRequestInterceptor<ApiKeyService>();
        }

        public void DoMiddlewareCall()
        {
            client.GetAsync("/n");
        }
    }
}
