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
using VirtualPharmaRep.API.DbContexts;
using VirtualPharmaRep.API.Entities;
using VirtualPharmaRep.API.Repositories;

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
				options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VirtualPharmaRep;Integrated Security=True;MultipleActiveResultSets=True"));

			services.AddScoped<ClinicRepository>();
			services.AddScoped<DoctorEmploymentRepository>();
			services.AddScoped<DoctorRepository>();
			services.AddScoped<DrugPropertyRepository>();
			services.AddScoped<DrugCategoryRepository>();
			services.AddScoped<DrugPropertyReportRepository>();
			services.AddScoped<DrugRepository>();
			services.AddScoped<GradeRepository>();
			services.AddScoped<TeamMemberRepository>();
			services.AddScoped<TeamRepository>();
			services.AddScoped<VisitRepository>();

			services.AddIdentity<ApplicationUser, IdentityRole>(
					opts =>
					{
						opts.Password.RequireDigit = true;
						opts.Password.RequireLowercase = true;
						opts.Password.RequireUppercase = true;
						opts.Password.RequireNonAlphanumeric = true;
						opts.Password.RequiredLength = 9;
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


			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Version = "v1",
					Title = "Moje API .NET Core",
					Description = "Przykładowy opis"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
