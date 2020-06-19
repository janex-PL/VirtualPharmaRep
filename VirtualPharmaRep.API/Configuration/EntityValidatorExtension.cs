using Microsoft.Extensions.DependencyInjection;
using VirtualPharmaRep.Database.EntityValidators;

namespace VirtualPharmaRep.API.Configuration
{
    public static class EntityValidatorExtension
    {
        public static IServiceCollection AddEntityValidators(this IServiceCollection services)
        {
            services.AddScoped<ClinicEntityValidator>();
            services.AddScoped<DoctorEntityValidator>();
            services.AddScoped<DoctorEmploymentEntityValidator>();
            services.AddScoped<DrugCategoryEntityValidator>();
            services.AddScoped<DrugEntityValidator>();
            services.AddScoped<DrugPropertyEntityValidator>();
            services.AddScoped<DrugPropertyReportEntityValidator>();
            services.AddScoped<DrugReportEntityValidator>();
            services.AddScoped<TeamMemberEntityValidator>();
            services.AddScoped<TeamEntityValidator>();
            services.AddScoped<VisitEntityValidator>();

            return services;
        }
    }
}
