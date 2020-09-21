using ServiceShopperBlazorTest.Shared.MiddlewareRequestAssigment;
using System.Net.Http;

namespace ServiceShopperBlazorTest.Client.Services
{
    public class CaseClient
    {
        HttpClient client;
        public CaseClient(HttpClient client)
        {
            this.client = client;
            HttpRequestAssigmentAdder.AddApiKeyAssigment(client);
        }

        public void DoMiddlewareCall()
        {
            client.GetAsync("/n");
        }
    }
}
