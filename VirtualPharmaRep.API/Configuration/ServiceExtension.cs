using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Services.CrudServices;
using VirtualPharmaRep.Services.CrudServices.Interfaces;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Configuration
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IClinicCrudService, ClinicCrudService>();
            services.AddScoped<IDoctorCrudService, DoctorCrudService>();
            services.AddScoped<IDoctorEmploymentCrudService, DoctorEmploymentCrudService>();
            services.AddScoped<IDrugCategoryCrudService, DrugCategoryCrudService>();
            services.AddScoped<IDrugCrudService, DrugCrudService>();
            services.AddScoped<IDrugPropertyCrudService, DrugPropertyCrudService>();
            services.AddScoped<IDrugPropertyReportCrudService, DrugPropertyReportCrudService>();
            services.AddScoped<IDrugReportCrudService, DrugReportCrudService>();
            services.AddScoped<ITeamCrudService, TeamCrudService>();
            services.AddScoped<ITeamMemberCrudService, TeamMemberCrudService>();
            services.AddScoped<IVisitCrudService, VisitCrudService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
