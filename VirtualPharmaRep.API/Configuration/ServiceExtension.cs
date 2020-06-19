using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Configuration
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ClinicCrudService>();
            services.AddScoped<DoctorCrudService>();
            services.AddScoped<DoctorEmploymentCrudService>();
            services.AddScoped<DrugCategoryCrudService>();
            services.AddScoped<DrugCrudService>();
            services.AddScoped<DrugPropertyCrudService>();
            services.AddScoped<DrugPropertyReportCrudService>();
            services.AddScoped<DrugReportCrudService>();
            services.AddScoped<TeamCrudService>();
            services.AddScoped<TeamMemberCrudService>();
            services.AddScoped<VisitCrudService>();
            

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPermissionResolverService, PermissionResolverService>();
            services.AddScoped<IPermissionDetailCrudService, PermissionDetailCrudService>();
            return services;
        }
    }
}
