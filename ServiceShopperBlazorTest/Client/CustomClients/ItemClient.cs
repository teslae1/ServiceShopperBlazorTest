using ServiceShopperBlazorTest.Client.MiddlewareRequestAssigment;
using ServiceShopperBlazorTest.Client.Services;
using System.Net.Http;

namespace ServiceShopperBlazorTest.Client.CustomClients
{
    public class ItemClient
    {
        HttpClient client;
        public ItemClient(HttpClient client)
        {
            this.client = client;
        }

        public void DoMiddlewareCall()
        {
            client.GetAsync("/n");
        }
    }
}
