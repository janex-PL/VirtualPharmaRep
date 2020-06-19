using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Database.DbContexts;

namespace VirtualPharmaRep.API.Configuration
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies()
                    .UseSqlServer(
                        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VirtualPharmaRep;Integrated Security=True;MultipleActiveResultSets=True",
                        b => b.MigrationsAssembly("VirtualPharmaRep.Database")));
            return services;
        }
    }
}
