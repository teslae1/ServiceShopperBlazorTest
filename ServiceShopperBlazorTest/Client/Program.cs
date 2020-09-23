using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ServiceShopperBlazorTest.Client.CustomClients;
using ServiceShopperBlazorTest.Client.Services;

namespace ServiceShopperBlazorTest.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddScoped<CaseClient, CaseClient>();
            builder.Services.AddScoped<ItemClient, ItemClient>();
            await builder.Build().RunAsync();
        }
    }
}
