using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Wagering.Areas.Identity.IdentityHostingStartup))]
namespace Wagering.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}