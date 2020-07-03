using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VirtualPharmaRep.API.Swagger;

namespace VirtualPharmaRep.API.Configuration
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<ApplySummariesOperationFilter>();

                c.SwaggerDoc("VirtualPharmaRepAPI", new OpenApiInfo
                {
                    Version = "v1.0.0",
                    Title = "VirtualPharmaRep API",
                    Description = "VirtualPharmaRep API"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
