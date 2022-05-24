using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecuredApplication.Areas.Identity.Data;
using SecuredApplication.Data;

[assembly: HostingStartup(typeof(SecuredApplication.Areas.Identity.IdentityHostingStartup))]
namespace SecuredApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecuredApplicationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecuredApplicationDbContextConnection")));

                services.AddDefaultIdentity<SecuredApplicationUser>(options => {

                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = true;
                    
                    
                    })
                    .AddEntityFrameworkStores<SecuredApplicationDbContext>();
            });
        }
    }
}