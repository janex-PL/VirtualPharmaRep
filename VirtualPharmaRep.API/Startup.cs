using System;
using System.Net;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using VirtualPharmaRep.API.Configuration;
using VirtualPharmaRep.API.Filters;
using VirtualPharmaRep.API.Middleware;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.Seeders;

namespace VirtualPharmaRep.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(config => config.Filters.Add(typeof(ExceptionFilter)))
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddRazorPages();
            services.AddCors();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardLimit = 2;
                options.KnownProxies.Add(IPAddress.Parse("127.0.10.1"));
                options.ForwardedForHeaderName = "X-Forwarded-For-My-Custom-Header-Name";
            });
            services.AddMemoryCache();
            services.AddSwagger().AddDatabase().AddIdentity().AddEntityValidators().AddServices();
            services.AddAuthentication(opts =>
                {
                    opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["Auth:Jwt:Issuer"],
                        ValidAudience = Configuration["Auth:Jwt:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Auth:Jwt:Key"])),
                        ClockSkew = TimeSpan.Zero,

                        RequireExpirationTime = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true
                    };
                });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/VirtualPharmaRepAPI/swagger.json", "VirtualPharmaRep API");
            });

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware(typeof(ExecutionTimeMeasureMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            context.Database.Migrate();

            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

            DbSeeder.Seed(context, roleManager, userManager);
        }
    }
}
