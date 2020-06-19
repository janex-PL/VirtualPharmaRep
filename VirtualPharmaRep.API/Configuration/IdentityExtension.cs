using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.API.Configuration
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(
                    opts =>
                    {
                        opts.Password.RequireDigit = false;
                        opts.Password.RequireLowercase = true;
                        opts.Password.RequireUppercase = true;
                        opts.Password.RequireNonAlphanumeric = false;
                        opts.Password.RequiredLength = 1;
                    })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            return services;
        }
    }
}
