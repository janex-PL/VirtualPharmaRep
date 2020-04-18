using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using VirtualPharmaRep.Data.Entities;
using VirtualPharmaRep.Database.DbContexts;
using VirtualPharmaRep.Database.Seeders;
using VirtualPharmaRep.Repositories;

namespace VirtualPharmaRep.API
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
					"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VirtualPharmaRep;Integrated Security=True;MultipleActiveResultSets=True",
					b => b.MigrationsAssembly("VirtualPharmaRep.Database")));

			services.AddIdentity<ApplicationUser, IdentityRole>(
					opts =>
					{
						opts.Password.RequireDigit = false;
						opts.Password.RequireLowercase = true;
						opts.Password.RequireUppercase = true;
						opts.Password.RequireNonAlphanumeric = false;
						opts.Password.RequiredLength = 12;
					})
				.AddEntityFrameworkStores<ApplicationDbContext>();

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
					cfg.TokenValidationParameters = new TokenValidationParameters()
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
			services.AddScoped<ClinicRepository>();
			services.AddScoped<DoctorEmploymentRepository>();
			services.AddScoped<DoctorRepository>();
			services.AddScoped<DrugCategoryRepository>();
			services.AddScoped<DrugRepository>();
			services.AddScoped<DrugPropertyReportRepository>();
			services.AddScoped<GradeRepository>();
			services.AddScoped<TeamMemberRepository>();
			services.AddScoped<TeamRepository>();
			services.AddScoped<VisitRepository>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Version = "v1",
					Title = "Moje API .NET Core",
					Description = "Przykładowy opis"
				});

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.DocExpansion(DocExpansion.None);
			});

			app.UseRouting();

            app.UseAuthentication();

			app.UseAuthorization();

            app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
			var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
			var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
			var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();

			DbSeeder.Seed(dbContext, roleManager, userManager);
		}
	}
}
