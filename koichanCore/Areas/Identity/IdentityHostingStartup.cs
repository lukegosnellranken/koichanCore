using System;
using koichanCore.Areas.Identity.Data;
using koichanCore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(koichanCore.Areas.Identity.IdentityHostingStartup))]
namespace koichanCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<koichanCoreDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("koichanCoreDBContextConnection")));

                services.AddDefaultIdentity<koichanCoreUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<koichanCoreDBContext>();
            });
        }
    }
}