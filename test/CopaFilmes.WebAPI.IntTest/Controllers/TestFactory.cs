using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CopaFilmes.WebAPI.IntTest.Controllers
{
    public class TestFactory : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
               .ConfigureWebHost(webHost =>
               {
                   webHost.UseStartup<Startup>().UseTestServer();
               })
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
               });
        }
    }
}
